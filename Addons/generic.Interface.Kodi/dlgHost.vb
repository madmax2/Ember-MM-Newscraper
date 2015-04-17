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
Imports System.IO
Imports NLog

Public Class dlgHost

#Region "Fields"

    Shared logger As Logger = NLog.LogManager.GetCurrentClassLogger()

    Friend WithEvents bwLoadInfo As New System.ComponentModel.BackgroundWorker

    Public kHosts As New List(Of KodiInterface.Host)
    Public hostid As String = Nothing
    Private kHost As New KodiInterface.Host
    Private RemotePathSeparator As String = String.Empty
    Private Paths As New Hashtable
    Private EmberSources As New List(Of EmberSource)
    Private xc As New KodiInterface.Host
    Private XBMCSources As New List(Of Kodi.JSON.KodiSource)


#End Region 'Fields

#Region "Methods"

    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Sub PopulateSources()
        Try
            dgvSources.Rows.Clear()
            Dim sPath As String
            For Each s As Structures.MovieSource In Master.MovieSources
                Try
                    sPath = s.Path
                    Dim i As Integer = dgvSources.Rows.Add(sPath)
                    Dim dcb As DataGridViewComboBoxCell = DirectCast(dgvSources.Rows(i).Cells(1), DataGridViewComboBoxCell)
                    Dim l As New List(Of String)
                    l.Add("") 'Empty Entrie for combo
                    If Not kHost.Paths Is Nothing Then
                        For Each sp As Object In kHost.Paths.Values
                            If Not String.IsNullOrEmpty(sp.ToString) AndAlso Not l.Contains(sp.ToString) Then l.Add(sp.ToString)
                        Next
                    End If
                    dcb.DataSource = l.ToArray
                    If Not kHost.Paths Is Nothing AndAlso kHost.Paths.Count > 0 AndAlso Not sPath Is Nothing AndAlso Not kHost.Paths(sPath) Is Nothing Then
                        dcb.Value = kHost.Paths(sPath).ToString
                    End If
                Catch ex As Exception
                    Logger.Error(New StackFrame().GetMethod().Name, ex)
                End Try
            Next
        Catch ex As Exception
            Logger.Error(New StackFrame().GetMethod().Name, ex)
        End Try
    End Sub

    Private Sub dlgHost_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Setup()
        kHost = kHosts.FirstOrDefault(Function(y) y.Label = hostid)
        If Not kHost Is Nothing Then
            Try
                Paths = kHost.Paths
                Me.txtLabel.Text = kHost.Label
                Me.txtHostIP.Text = kHost.HostIP
                Me.txtWebPort.Text = kHost.WebPort
                Me.txtUsername.Text = kHost.Username
                Me.txtPassword.Text = kHost.Password
                If kHost.RemotePathSeparator = Path.DirectorySeparatorChar Then
                    Me.rbWindows.Checked = True
                Else
                    Me.rbLinux.Checked = True
                End If
                RemotePathSeparator = kHost.RemotePathSeparator
                chkRealTimeSync.Checked = kHost.RealTimeSync
                PopulateSources()
            Catch ex As Exception
                Logger.Error(New StackFrame().GetMethod().Name, ex)
            End Try
        Else
            kHost = New KodiInterface.Host
            kHosts.Add(kHost)
            PopulateSources()
        End If

        dgvSources.Enabled = True
    End Sub

    Public Shared Function GetSources(ByVal kHost As KodiInterface.Host) As List(Of Kodi.JSON.KodiSource)
        Dim listSources As New List(Of Kodi.JSON.KodiSource)
        Try
            Dim Settings As Kodi.JSON.MySettings
            Settings.HostIP = kHost.HostIP
            Settings.Password = kHost.Password
            Settings.Username = kHost.Username
            Settings.WebPort = kHost.WebPort

            Dim _json As New Kodi.JSON(Settings)
            listSources = _json.GetVideoSources

        Catch ex As Exception
            logger.Error(New StackFrame().GetMethod().Name, ex)
        End Try
        Return listSources
    End Function

    Public Shared Function GetFiles(ByVal kHost As KodiInterface.Host) As List(Of String)
        Dim listFiles As New List(Of String)
        Try
            Dim Settings As Kodi.JSON.MySettings
            Settings.HostIP = kHost.HostIP
            Settings.Password = kHost.Password
            Settings.Username = kHost.Username
            Settings.WebPort = kHost.WebPort

            Dim _json As New Kodi.JSON(Settings)
            Dim FileList As List(Of Kodi.JSON.KodiMovie) = _json.GetMovies
            For Each kMovie In FileList
                listFiles.Add(kMovie.Path)
            Next

        Catch ex As Exception
            logger.Error(New StackFrame().GetMethod().Name, ex)
        End Try
        Return listFiles
    End Function

    Private Sub btnPopulateSources_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPopulateSources.Click
        pnlLoading.Visible = True
        GroupBox1.Enabled = False
        btnPopulateSources.Enabled = False
        btnOK.Enabled = False
        btnCancel.Enabled = False
        txtHostIP.Enabled = False
        txtLabel.Enabled = False
        txtPassword.Enabled = False
        txtWebPort.Enabled = False
        txtUsername.Enabled = False
        dgvSources.Enabled = False
        EmberSources.Clear()
        If Paths Is Nothing Then Paths = New Hashtable
        Paths.Clear()

        xc = New KodiInterface.Host With {.Label = txtLabel.Text, .HostIP = txtHostIP.Text, .WebPort = txtWebPort.Text, .Username = txtUsername.Text, .Password = txtPassword.Text, .RealTimeSync = chkRealTimeSync.Checked}
        bwLoadInfo.RunWorkerAsync()
        While bwLoadInfo.IsBusy
            Application.DoEvents()
            Threading.Thread.Sleep(50)
        End While
        If XBMCSources.Count > 0 Then
            Try
                dgvSources.Rows.Clear()
                For Each s As Structures.MovieSource In Master.MovieSources
                    Dim sPath As String = s.Path
                    Dim i As Integer = dgvSources.Rows.Add(sPath)
                    Dim dcb As DataGridViewComboBoxCell = DirectCast(dgvSources.Rows(i).Cells(1), DataGridViewComboBoxCell)
                    Dim tmp As New List(Of String)
                    For Each tSource As Kodi.JSON.KodiSource In XBMCSources
                        tmp.Add(tSource.Path)
                    Next
                    dcb.DataSource = tmp.ToArray
                    Dim es As EmberSource = EmberSources.FirstOrDefault(Function(y) y.Path = sPath)
                    Paths.Add(es.Path, String.Empty)
                    '' If it match > 90% of the movies
                    'If Convert.ToInt32(es.XBMCSource(getMaxSourceCount(es.XBMCSource))) > es.ElemCounts * 0.9 Then
                    '    dcb.Value = getMaxSourceCount(es.XBMCSource)
                    '    Paths.Add(es.Path, dcb.Value)
                    'Else
                    '    Paths.Add(es.Path, "")
                    'End If
                Next
            Catch ex As Exception
                logger.Error(New StackFrame().GetMethod().Name, ex)
            End Try

        End If
        pnlLoading.Visible = False
        btnPopulateSources.Enabled = True
        btnOK.Enabled = True
        btnCancel.Enabled = True
        txtHostIP.Enabled = True
        txtLabel.Enabled = True
        txtPassword.Enabled = True
        txtWebPort.Enabled = True
        txtUsername.Enabled = True
        dgvSources.Enabled = True
        GroupBox1.Enabled = True
    End Sub
    Private Sub bwLoadInfo_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLoadInfo.DoWork
        SourceGuessing()
    End Sub

    Sub SourceGuessing()
        Dim files As List(Of String) = Nothing
        XBMCSources = GetSources(xc)
        If XBMCSources.Count = 0 Then Return
        '"command=queryvideodatabase(select movie.*,path.strpath,files.strfilename,path.strcontent,path.strHash from movie inner join files on movie.idfile=files.idfile inner join path on files.idpath = path.idpath)"
        'Dim cmd As String = "command=queryvideodatabase(select movie.*,path.strpath,files.strfilename from movie inner join files on movie.idfile=files.idfile inner join path on files.idpath = path.idpath)"
        files = GetFiles(xc)

        For Each s As Structures.MovieSource In Master.MovieSources
            Dim myPaths As New List(Of String)
            For Each di As String In Master.DB.GetMoviePathsBySource(s.Path)
                myPaths.Add(GetFilePath(s.Path, di))
            Next

            Dim es As New EmberSource With {.Path = s.Path, .XBMCSource = New Hashtable, .ElemCounts = myPaths.Count}
            For Each xs As Kodi.JSON.KodiSource In XBMCSources
                es.XBMCSource.Add(xs, 0) 'Populate Hashtable
            Next

            'For Each f As String In files.Where(Function(y) y.Count >= 24)
            '    Dim fPath As String = String.Concat(f(23), f(24))
            '    Dim xs As String = XBMCSources.FirstOrDefault(Function(y) fPath.StartsWith(y.Path)).ToString
            '    If fPath.StartsWith(xs) AndAlso myPaths.Contains(GetFilePath(xs, fPath, RemotePathSeparator)) Then
            '        es.XBMCSource(xs) = Convert.ToInt32(es.XBMCSource(xs)) + 1
            '    End If
            'Next
            EmberSources.Add(es)
        Next
    End Sub

    Function GetFilePath(ByVal base As String, ByVal mypath As String, Optional ByVal sep As String = "") As String
        If String.IsNullOrEmpty(sep) Then sep = Path.DirectorySeparatorChar
        If mypath.StartsWith(base) Then mypath = mypath.Substring(base.Length).Replace(sep, Path.DirectorySeparatorChar)
        If mypath.StartsWith(Path.DirectorySeparatorChar) Then mypath = mypath.Substring(1)
        Return mypath
    End Function

    Private Sub rbLinux_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbLinux.CheckedChanged
        Me.kHost.RemotePathSeparator = If(rbWindows.Checked, Path.DirectorySeparatorChar, "/")
        RemotePathSeparator = Me.kHost.RemotePathSeparator
    End Sub

    Private Sub rbWindows_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWindows.CheckedChanged
        Me.kHost.RemotePathSeparator = If(rbWindows.Checked, Path.DirectorySeparatorChar, "/")
        RemotePathSeparator = Me.kHost.RemotePathSeparator
    End Sub

    Sub Setup()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Structure EmberSource
        Dim Path As String
        Dim ElemCounts As Integer
        Dim XBMCSource As Hashtable
    End Structure

#End Region 'Nested Types

End Class