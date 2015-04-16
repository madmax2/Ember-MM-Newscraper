' ################################################################################
' #                             EMBER MEDIA MANAGER                              #
' ################################################################################
' ################################################################################
' # This file is part of Ember Media Manager.                                    #
' #                                                                              #
' # Ember Media Manager is free software: you can redistribute it and/or modify  #
' # it under the terms of the GNU General Public License as published by         #
' # the Free Software Foundation, either version 3 of the License, or            #
' # (at your option) any later version.                                          #
' #                                                                              #
' # Ember Media Manager is distributed in the hope that it will be useful,       #
' # but WITHOUT ANY WARRANTY; without even the implied warranty of               #
' # MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                #
' # GNU General Public License for more details.                                 #
' #                                                                              #
' # You should have received a copy of the GNU General Public License            #
' # along with Ember Media Manager.  If not, see <http://www.gnu.org/licenses/>. #
' ################################################################################

Imports EmberAPI

Public Class KodiInterface
    Implements Interfaces.GenericModule

#Region "Delegates"

    Public Delegate Sub Delegate_SetToolsStripItem(value As System.Windows.Forms.ToolStripItem)
    Public Delegate Sub Delegate_RemoveToolsStripItem(value As System.Windows.Forms.ToolStripItem)
    Public Delegate Sub Delegate_AddToolsStripItem(tsi As System.Windows.Forms.ToolStripMenuItem, value As System.Windows.Forms.ToolStripMenuItem)

#End Region 'Delegates

#Region "Fields"

    Private WithEvents mnuMainToolsKodi As New System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmnuTrayToolsKodi As New System.Windows.Forms.ToolStripMenuItem
    Private MySettings As New _MySettings
    Private _AssemblyName As String = String.Empty
    Private _enabled As Boolean = False
    Private _Name As String = "Kodi"
    Private _setup As frmSettingsHolder
    Private cmnuKodi_Movies As New System.Windows.Forms.ToolStripMenuItem
    Private cmnuKodi_Episodes As New System.Windows.Forms.ToolStripMenuItem
    Private cmnuKodi_Shows As New System.Windows.Forms.ToolStripMenuItem
    Private cmnuSep_Movies As New System.Windows.Forms.ToolStripSeparator
    Private cmnuSep_Episodes As New System.Windows.Forms.ToolStripSeparator
    Private cmnuSep_Shows As New System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmnuKodiAdd_Movie As New System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmnuKodiSync_Movie As New System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmnuKodiSync_TVEpisode As New System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmnuKodiSync_TVShow As New System.Windows.Forms.ToolStripMenuItem

#End Region 'Fields

#Region "Events"

    Public Event GenericEvent(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object)) Implements Interfaces.GenericModule.GenericEvent

    Public Event ModuleEnabledChanged(ByVal Name As String, ByVal State As Boolean, ByVal diffOrder As Integer) Implements Interfaces.GenericModule.ModuleSetupChanged

    Public Event ModuleSettingsChanged() Implements Interfaces.GenericModule.ModuleSettingsChanged

    Public Event SetupNeedsRestart() Implements EmberAPI.Interfaces.GenericModule.SetupNeedsRestart

#End Region 'Events

#Region "Properties"

    Public ReadOnly Property ModuleType() As List(Of Enums.ModuleEventType) Implements Interfaces.GenericModule.ModuleType
        Get
            Return New List(Of Enums.ModuleEventType)(New Enums.ModuleEventType() {Enums.ModuleEventType.Sync_Movie})
        End Get
    End Property

    Property Enabled() As Boolean Implements Interfaces.GenericModule.Enabled
        Get
            Return _enabled
        End Get
        Set(ByVal value As Boolean)
            If _enabled = value Then Return
            _enabled = value
            If _enabled Then
                Enable()
            Else
                Disable()
            End If
        End Set
    End Property

    ReadOnly Property ModuleName() As String Implements Interfaces.GenericModule.ModuleName
        Get
            Return _Name
        End Get
    End Property

    ReadOnly Property ModuleVersion() As String Implements Interfaces.GenericModule.ModuleVersion
        Get
            Return FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileVersion.ToString
        End Get
    End Property

#End Region 'Properties

#Region "Methods"

    Public Function RunGeneric(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object), ByRef _refparam As Object, ByRef _dbmovie As Structures.DBMovie, ByRef _dbtv As Structures.DBTV) As Interfaces.ModuleResult Implements Interfaces.GenericModule.RunGeneric
        Select mType
            Case Enums.ModuleEventType.Sync_Movie
                If Master.currMovie.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_Movie(Master.currMovie, True) Then
                    Cursor.Current = Cursors.WaitCursor
                    Dim tDBMovie As EmberAPI.Structures.DBMovie = DirectCast(_refparam, EmberAPI.Structures.DBMovie)

                    Dim Settings As Kodi.JSON.MySettings
                    Settings.HostIP = MySettings.HostIP
                    Settings.Password = MySettings.Password
                    Settings.Username = MySettings.Username
                    Settings.WebserverPort = MySettings.WebserverPort

                    Dim _json As New Kodi.JSON(Settings)

                    If _json.UpdateMovieInfo(tDBMovie.ID) Then
                        ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"info", Nothing, "Kodi Interface", "Sync OK", New Bitmap(My.Resources.logo)}))
                    Else
                        ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"error", 1, "Kodi Interface", "Sync failed", Nothing}))
                    End If

                    Cursor.Current = Cursors.Default
                End If
                '    Case Enums.ModuleEventType.ScraperMulti_Movie
                '        If MySettings.RenameMulti_Movies AndAlso Not String.IsNullOrEmpty(MySettings.FoldersPattern_Movies) AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern_Movies) Then
                '            FileFolderRenamer.RenameSingle_Movie(_dbmovie, MySettings.FoldersPattern_Movies, MySettings.FilesPattern_Movies, False, False, False, False)
                '        End If
                '    Case Enums.ModuleEventType.ScraperSingle_Movie
                '        If MySettings.RenameSingle_Movies AndAlso Not String.IsNullOrEmpty(MySettings.FoldersPattern_Movies) AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern_Movies) Then
                '            FileFolderRenamer.RenameSingle_Movie(_dbmovie, MySettings.FoldersPattern_Movies, MySettings.FilesPattern_Movies, False, False, False, True)
                '        End If
                '    Case Enums.ModuleEventType.AfterEdit_TVEpisode
                '        If MySettings.RenameEdit_Episodes AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern_Episodes) Then
                '            Dim tDBTV As EmberAPI.Structures.DBTV = DirectCast(_refparam, EmberAPI.Structures.DBTV)
                '            Dim BatchMode As Boolean = DirectCast(_params(0), Boolean)
                '            Dim ToNFO As Boolean = DirectCast(_params(1), Boolean)
                '            Dim ShowErrors As Boolean = DirectCast(_params(2), Boolean)
                '            FileFolderRenamer.RenameSingle_Episode(tDBTV, MySettings.FoldersPattern_Seasons, MySettings.FilesPattern_Episodes, BatchMode, ToNFO, ShowErrors, True)
                '        End If
                '    Case Enums.ModuleEventType.AfterUpdateDB_TV
                '        If MySettings.RenameUpdate_Episodes AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern_Episodes) Then
                '            Dim BatchMode As Boolean = DirectCast(_params(0), Boolean)
                '            Dim ToNFO As Boolean = DirectCast(_params(1), Boolean)
                '            Dim ShowErrors As Boolean = DirectCast(_params(2), Boolean)
                '            Dim ToDB As Boolean = DirectCast(_params(3), Boolean)
                '            Dim Source As String = DirectCast(_params(4), String)
                '            Dim FFRenamer As New FileFolderRenamer
                '            FFRenamer.RenameAfterUpdateDB_TV(Source, MySettings.FoldersPattern_Seasons, MySettings.FilesPattern_Episodes, BatchMode, ToNFO, ShowErrors, ToDB)
                '        End If
                '    Case Enums.ModuleEventType.ScraperMulti_TVEpisode
                '        If MySettings.RenameMulti_Shows AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern_Episodes) Then
                '            FileFolderRenamer.RenameSingle_Episode(_dbtv, MySettings.FoldersPattern_Seasons, MySettings.FilesPattern_Episodes, True, False, False, False)
                '        End If
                '    Case Enums.ModuleEventType.ScraperSingle_TVEpisode
                '        If MySettings.RenameSingle_Shows AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern_Episodes) Then
                '            FileFolderRenamer.RenameSingle_Episode(_dbtv, MySettings.FoldersPattern_Seasons, MySettings.FilesPattern_Episodes, False, False, False, True)
                '        End If
        End Select
        Return New Interfaces.ModuleResult With {.breakChain = False}
    End Function

    Private Sub cmnuKodiAdd_Movie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuKodiAdd_Movie.Click
        If Master.currMovie.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_Movie(Master.currMovie, True) Then
            Cursor.Current = Cursors.WaitCursor
            Dim indX As Integer = ModulesManager.Instance.RuntimeObjects.MediaListMovies.SelectedRows(0).Index
            Dim ID As Integer = Convert.ToInt32(ModulesManager.Instance.RuntimeObjects.MediaListMovies.Item(0, indX).Value)

            Dim Settings As Kodi.JSON.MySettings
            Settings.HostIP = MySettings.HostIP
            Settings.Password = MySettings.Password
            Settings.Username = MySettings.Username
            Settings.WebserverPort = MySettings.WebserverPort

            Dim _json As New Kodi.JSON(Settings)

            If _json.ScanVideoPath(Master.currMovie.ID) Then
                ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"info", Nothing, "Kodi Interface", "Kodi running update...", New Bitmap(My.Resources.logo)}))
            Else
                ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"error", 1, "Kodi Interface", "Update failed", Nothing}))
            End If

            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub cmnuKodiSync_TVEpisode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuKodiSync_TVEpisode.Click
        If Master.currShow.IsOnlineEp OrElse FileUtils.Common.CheckOnlineStatus_Episode(Master.currShow, True) Then
            Cursor.Current = Cursors.WaitCursor
            Dim indX As Integer = ModulesManager.Instance.RuntimeObjects.MediaListEpisodes.SelectedRows(0).Index
            Dim ID As Integer = Convert.ToInt32(ModulesManager.Instance.RuntimeObjects.MediaListEpisodes.Item(0, indX).Value)
            'FileFolderRenamer.RenameSingle_Episode(Master.currShow, MySettings.FoldersPattern_Seasons, MySettings.FilesPattern_Episodes, False, True, True, True)
            RaiseEvent GenericEvent(Enums.ModuleEventType.AfterEdit_TVEpisode, New List(Of Object)(New Object() {ID, indX}))
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub cmnuKodiSync_Movie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuKodiSync_Movie.Click
        If Master.currMovie.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_Movie(Master.currMovie, True) Then
            Cursor.Current = Cursors.WaitCursor
            Dim indX As Integer = ModulesManager.Instance.RuntimeObjects.MediaListMovies.SelectedRows(0).Index
            Dim ID As Integer = Convert.ToInt32(ModulesManager.Instance.RuntimeObjects.MediaListMovies.Item(0, indX).Value)

            Dim Settings As Kodi.JSON.MySettings
            Settings.HostIP = MySettings.HostIP
            Settings.Password = MySettings.Password
            Settings.Username = MySettings.Username
            Settings.WebserverPort = MySettings.WebserverPort

            Dim _json As New Kodi.JSON(Settings)

            If _json.UpdateMovieInfo(Master.currMovie.ID) Then
                ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"info", Nothing, "Kodi Interface", "Sync OK", New Bitmap(My.Resources.logo)}))
            Else
                ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"error", 1, "Kodi Interface", "Sync failed", Nothing}))
            End If

            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub cmnuKodiSync_TVShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuKodiSync_TVShow.Click
        If Master.currShow.isOnlineShow OrElse FileUtils.Common.CheckOnlineStatus_Show(Master.currShow, True) Then
            Cursor.Current = Cursors.WaitCursor
            Dim indX As Integer = ModulesManager.Instance.RuntimeObjects.MediaListShows.SelectedRows(0).Index
            Dim ID As Integer = Convert.ToInt32(ModulesManager.Instance.RuntimeObjects.MediaListShows.Item(0, indX).Value)
            'FileFolderRenamer.RenameSingle_Show(Master.currShow, MySettings.FoldersPattern_Shows, False, False, True, True)
            RaiseEvent GenericEvent(Enums.ModuleEventType.AfterEdit_TVShow, New List(Of Object)(New Object() {ID, indX}))
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Sub Disable()
        Dim tsi As New ToolStripMenuItem
        tsi = DirectCast(ModulesManager.Instance.RuntimeObjects.TopMenu.Items("mnuMainTools"), ToolStripMenuItem)
        tsi.DropDownItems.Remove(mnuMainToolsKodi)
        tsi = DirectCast(ModulesManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayTools"), ToolStripMenuItem)
        tsi.DropDownItems.Remove(cmnuTrayToolsKodi)
        'cmnuMovies
        RemoveToolsStripItem_Movies(cmnuSep_Movies)
        RemoveToolsStripItem_Movies(cmnuKodi_Movies)
        'cmnuEpisodes
        RemoveToolsStripItem_Episodes(cmnuSep_Episodes)
        RemoveToolsStripItem_Episodes(cmnuKodi_Episodes)
        'cmnuShows
        RemoveToolsStripItem_Shows(cmnuSep_Shows)
        RemoveToolsStripItem_Shows(cmnuKodi_Shows)
    End Sub

    Public Sub RemoveToolsStripItem_Episodes(value As System.Windows.Forms.ToolStripItem)
        If (ModulesManager.Instance.RuntimeObjects.MenuTVEpisodeList.InvokeRequired) Then
            ModulesManager.Instance.RuntimeObjects.MenuTVEpisodeList.Invoke(New Delegate_RemoveToolsStripItem(AddressOf RemoveToolsStripItem_Episodes), New Object() {value})
            Exit Sub
        End If
        ModulesManager.Instance.RuntimeObjects.MenuTVEpisodeList.Items.Remove(value)
    End Sub

    Public Sub RemoveToolsStripItem_Movies(value As System.Windows.Forms.ToolStripItem)
        If (ModulesManager.Instance.RuntimeObjects.MenuMovieList.InvokeRequired) Then
            ModulesManager.Instance.RuntimeObjects.MenuMovieList.Invoke(New Delegate_RemoveToolsStripItem(AddressOf RemoveToolsStripItem_Movies), New Object() {value})
            Exit Sub
        End If
        ModulesManager.Instance.RuntimeObjects.MenuMovieList.Items.Remove(value)
    End Sub

    Public Sub RemoveToolsStripItem_Shows(value As System.Windows.Forms.ToolStripItem)
        If (ModulesManager.Instance.RuntimeObjects.MenuTVShowList.InvokeRequired) Then
            ModulesManager.Instance.RuntimeObjects.MenuTVShowList.Invoke(New Delegate_RemoveToolsStripItem(AddressOf RemoveToolsStripItem_Shows), New Object() {value})
            Exit Sub
        End If
        ModulesManager.Instance.RuntimeObjects.MenuTVShowList.Items.Remove(value)
    End Sub

    Sub Enable()
        Dim tsi As New ToolStripMenuItem
        mnuMainToolsKodi.Image = New Bitmap(My.Resources.icon)
        mnuMainToolsKodi.Text = "Kodi"
        mnuMainToolsKodi.Tag = New Structures.ModulesMenus With {.ForMovies = True, .IfTabMovies = True, .ForTVShows = True, .IfTabTVShows = True}
        tsi = DirectCast(ModulesManager.Instance.RuntimeObjects.TopMenu.Items("mnuMainTools"), ToolStripMenuItem)
        AddToolsStripItem(tsi, mnuMainToolsKodi)
        cmnuTrayToolsKodi.Image = New Bitmap(My.Resources.icon)
        cmnuTrayToolsKodi.Text = "Kodi"
        tsi = DirectCast(ModulesManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayTools"), ToolStripMenuItem)
        AddToolsStripItem(tsi, cmnuTrayToolsKodi)

        'cmnuMovies
        cmnuKodi_Movies.Image = New Bitmap(My.Resources.icon)
        cmnuKodi_Movies.Text = "Kodi"
        cmnuKodi_Movies.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        cmnuKodiAdd_Movie.Image = New Bitmap(My.Resources.menuAdd)
        cmnuKodiAdd_Movie.Text = "Add"
        cmnuKodiSync_Movie.Image = New Bitmap(My.Resources.menuSync)
        cmnuKodiSync_Movie.Text = "Sync"
        cmnuKodi_Movies.DropDownItems.Add(cmnuKodiAdd_Movie)
        cmnuKodi_Movies.DropDownItems.Add(cmnuKodiSync_Movie)

        SetToolsStripItem_Movies(cmnuSep_Movies)
        SetToolsStripItem_Movies(cmnuKodi_Movies)

        'cmnuEpisodes
        cmnuKodi_Episodes.Image = New Bitmap(My.Resources.icon)
        cmnuKodi_Episodes.Text = "Kodi"
        cmnuKodi_Episodes.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        cmnuKodiSync_TVEpisode.Image = New Bitmap(My.Resources.menuSync)
        cmnuKodiSync_TVEpisode.Text = "Sync"
        cmnuKodi_Episodes.DropDownItems.Add(cmnuKodiSync_TVEpisode)

        SetToolsStripItem_Episodes(cmnuSep_Episodes)
        SetToolsStripItem_Episodes(cmnuKodi_Episodes)

        'cmnuShows
        cmnuKodi_Shows.Image = New Bitmap(My.Resources.icon)
        cmnuKodi_Shows.Text = "Kodi"
        cmnuKodi_Shows.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        cmnuKodiSync_TVShow.Image = New Bitmap(My.Resources.menuSync)
        cmnuKodiSync_TVShow.Text = "Sync"
        cmnuKodi_Shows.DropDownItems.Add(cmnuKodiSync_TVShow)

        SetToolsStripItem_Shows(cmnuSep_Shows)
        SetToolsStripItem_Shows(cmnuKodi_Shows)
    End Sub

    Public Sub AddToolsStripItem(control As System.Windows.Forms.ToolStripMenuItem, value As System.Windows.Forms.ToolStripItem)
        If (control.Owner.InvokeRequired) Then
            control.Owner.Invoke(New Delegate_AddToolsStripItem(AddressOf AddToolsStripItem), New Object() {control, value})
            Exit Sub
        End If
        control.DropDownItems.Add(value)
    End Sub

    Public Sub SetToolsStripItem_Episodes(value As System.Windows.Forms.ToolStripItem)
        If (ModulesManager.Instance.RuntimeObjects.MenuTVEpisodeList.InvokeRequired) Then
            ModulesManager.Instance.RuntimeObjects.MenuTVEpisodeList.Invoke(New Delegate_SetToolsStripItem(AddressOf SetToolsStripItem_Episodes), New Object() {value})
            Exit Sub
        End If
        ModulesManager.Instance.RuntimeObjects.MenuTVEpisodeList.Items.Add(value)
    End Sub

    Public Sub SetToolsStripItem_Movies(value As System.Windows.Forms.ToolStripItem)
        If (ModulesManager.Instance.RuntimeObjects.MenuMovieList.InvokeRequired) Then
            ModulesManager.Instance.RuntimeObjects.MenuMovieList.Invoke(New Delegate_SetToolsStripItem(AddressOf SetToolsStripItem_Movies), New Object() {value})
            Exit Sub
        End If
        ModulesManager.Instance.RuntimeObjects.MenuMovieList.Items.Add(value)
    End Sub

    Public Sub SetToolsStripItem_Shows(value As System.Windows.Forms.ToolStripItem)
        If (ModulesManager.Instance.RuntimeObjects.MenuTVShowList.InvokeRequired) Then
            ModulesManager.Instance.RuntimeObjects.MenuTVShowList.Invoke(New Delegate_SetToolsStripItem(AddressOf SetToolsStripItem_Shows), New Object() {value})
            Exit Sub
        End If
        ModulesManager.Instance.RuntimeObjects.MenuTVShowList.Items.Add(value)
    End Sub

    Private Sub Handle_ModuleSettingsChanged()
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub Handle_SetupChanged(ByVal state As Boolean, ByVal difforder As Integer)
        RaiseEvent ModuleEnabledChanged(Me._Name, state, difforder)
    End Sub

    Sub Init(ByVal sAssemblyName As String, ByVal sExecutable As String) Implements Interfaces.GenericModule.Init
        _AssemblyName = sAssemblyName
        LoadSettings()
    End Sub

    Function InjectSetup() As Containers.SettingsPanel Implements Interfaces.GenericModule.InjectSetup
        Dim SPanel As New Containers.SettingsPanel
        Me._setup = New frmSettingsHolder
        Me._setup.chkEnabled.Checked = Me._enabled
        Me._setup.txtHostIP.Text = MySettings.HostIP
        Me._setup.txtPassword.Text = MySettings.Password
        Me._setup.txtUsername.Text = MySettings.Username
        Me._setup.txtWebserverPort.Text = MySettings.WebserverPort
        SPanel.Name = Me._Name
        SPanel.Text = "Kodi Interface"
        SPanel.Prefix = "Kodi_"
        SPanel.Type = Master.eLang.GetString(802, "Modules")
        SPanel.ImageIndex = If(Me._enabled, 9, 10)
        SPanel.Order = 100
        SPanel.Panel = Me._setup.pnlSettings()
        AddHandler _setup.ModuleEnabledChanged, AddressOf Handle_SetupChanged
        AddHandler _setup.ModuleSettingsChanged, AddressOf Handle_ModuleSettingsChanged
        Return SPanel
    End Function

    Sub LoadSettings()
        MySettings.HostIP = clsAdvancedSettings.GetSetting("HostIP", String.Empty)
        MySettings.Password = clsAdvancedSettings.GetSetting("Password", String.Empty)
        MySettings.Username = clsAdvancedSettings.GetSetting("Username", String.Empty)
        MySettings.WebserverPort = clsAdvancedSettings.GetSetting("WebserverPort", String.Empty)
    End Sub

    Private Sub mnuMainToolsRenamer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainToolsKodi.Click, cmnuTrayToolsKodi.Click
        RaiseEvent GenericEvent(Enums.ModuleEventType.Generic, New List(Of Object)(New Object() {"controlsenabled", False}))
        Select Case ModulesManager.Instance.RuntimeObjects.MediaTabSelected.ContentType
            Case Enums.Content_Type.Movie
                'Using dBulkRename As New dlgBulkRenamer_Movie
                '    dBulkRename.FilterMovies = ModulesManager.Instance.RuntimeObjects.FilterMovies
                '    dBulkRename.FilterMoviesSearch = ModulesManager.Instance.RuntimeObjects.FilterMoviesSearch
                '    dBulkRename.FilterMoviesType = ModulesManager.Instance.RuntimeObjects.FilterMoviesType
                '    dBulkRename.ListMovies = ModulesManager.Instance.RuntimeObjects.ListMovies
                '    dBulkRename.txtFilePattern.Text = MySettings.FilesPattern_Movies
                '    dBulkRename.txtFolderPattern.Text = MySettings.FoldersPattern_Movies
                '    dBulkRename.ShowDialog()
                'End Using
            Case Enums.Content_Type.TV
                'Using dBulkRename As New dlgBulkRenamer_TV
                '    dBulkRename.FilterShows = ModulesManager.Instance.RuntimeObjects.FilterShows
                '    dBulkRename.FilterShowsSearch = ModulesManager.Instance.RuntimeObjects.FilterShowsSearch
                '    dBulkRename.FilterShowsType = ModulesManager.Instance.RuntimeObjects.FilterShowsType
                '    dBulkRename.ListShows = ModulesManager.Instance.RuntimeObjects.ListShows
                '    dBulkRename.txtFilePatternEpisodes.Text = MySettings.FilesPattern_Episodes
                '    dBulkRename.txtFolderPatternSeasons.Text = MySettings.FoldersPattern_Seasons
                '    dBulkRename.txtFolderPatternShows.Text = MySettings.FoldersPattern_Shows
                '    dBulkRename.ShowDialog()
                'End Using
        End Select
        RaiseEvent GenericEvent(Enums.ModuleEventType.Generic, New List(Of Object)(New Object() {"controlsenabled", True}))
        RaiseEvent GenericEvent(Enums.ModuleEventType.Generic, New List(Of Object)(New Object() {"filllist", True, True, True}))
    End Sub

    Sub SaveEmberExternalModule(ByVal DoDispose As Boolean) Implements Interfaces.GenericModule.SaveSetup
        Me._enabled = Me._setup.chkEnabled.Checked
        MySettings.HostIP = Me._setup.txtHostIP.Text
        MySettings.Password = Me._setup.txtPassword.Text
        MySettings.Username = Me._setup.txtUsername.Text
        MySettings.WebserverPort = Me._setup.txtWebserverPort.Text
        SaveSettings()
        If DoDispose Then
            RemoveHandler Me._setup.ModuleEnabledChanged, AddressOf Handle_SetupChanged
            RemoveHandler Me._setup.ModuleSettingsChanged, AddressOf Handle_ModuleSettingsChanged
            _setup.Dispose()
        End If
    End Sub

    Sub SaveSettings()
        Using settings = New clsAdvancedSettings()
            settings.SetSetting("HostIP", MySettings.HostIP)
            settings.SetSetting("Password", MySettings.Password)
            settings.SetSetting("Username", MySettings.Username)
            settings.SetSetting("WebserverPort", MySettings.WebserverPort)
        End Using
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Structure _MySettings

#Region "Fields"

        Dim Username As String
        Dim Password As String
        Dim HostIP As String
        Dim WebserverPort As String

#End Region 'Fields

    End Structure

#End Region 'Nested Types

End Class
