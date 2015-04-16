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
Imports System.Net 'Namespace für HttpWeb
Imports System.Text 'Namespace für das Encoding
Imports System.Text.RegularExpressions
Imports System.IO 'Namespace für den Stream 
Imports NLog

Namespace Kodi

    Public Class JSON

#Region "Fields"

        Shared logger As Logger = NLog.LogManager.GetCurrentClassLogger()
        Private _mySettings As MySettings

#End Region 'Fields

#Region "Methods"

        Public Sub New(ByVal Settings As MySettings)
            _mySettings = Settings
        End Sub

        Public Sub SendMessage(ByRef Title As String, ByRef Message As String)
            If Not String.IsNullOrEmpty(Title) AndAlso Not String.IsNullOrEmpty(Message) Then
                Dim Command As String = String.Concat("{""jsonrpc"":""2.0"",""method"":""GUI.ShowNotification"",""params"":{""title"":""", Title, """,""message"":""", Message, """},""id"":1}")
                SendJSON(Command)
            End If
        End Sub

        Public Function ScanVideoPath(ByRef movieID As Long) As Boolean
            Dim uMovie As Structures.DBMovie = Master.DB.LoadMovieFromDB(movieID)
            Dim uPath As String = String.Empty

            If FileUtils.Common.isBDRip(uMovie.Filename) Then
            ElseIf FileUtils.Common.isVideoTS(uMovie.Filename) Then
            Else
                uPath = Directory.GetParent(uMovie.Filename).FullName
            End If

            Dim Command As String = Regex.Replace(String.Concat("{""jsonrpc"": ""2.0"", ""method"": ""VideoLibrary.Scan"", ""params"": {", _
                                                                """directory"": """, uPath, """}, ""id"": 1}"), "\\", "\\")

            Dim Result As String = SendJSON(Command)
            If Result.Contains("error") Then
                logger.Error(String.Concat("Kodi JSON: ", Result))
                Return False
            Else
                Return True
            End If
        End Function

        Public Function UpdateMovieInfo(ByRef movieID As Long) As Boolean
            Dim uMovie As Structures.DBMovie = Master.DB.LoadMovieFromDB(movieID)

            'search movie ID in Kodi DB
            Dim KodiID As Long = GetMovieIdByPath(uMovie.Filename)

            If KodiID > -1 Then

                'string or String.Empty
                Dim mTitle As String = Web.HttpUtility.JavaScriptStringEncode(uMovie.Movie.Title, True)
                Dim mPlot As String = Web.HttpUtility.JavaScriptStringEncode(uMovie.Movie.Plot, True)
                Dim mMPAA As String = Web.HttpUtility.JavaScriptStringEncode(uMovie.Movie.MPAA, True)
                Dim mImdbnumber As String = Web.HttpUtility.JavaScriptStringEncode(uMovie.Movie.ID, True)
                Dim mOriginalTitle As String = Web.HttpUtility.JavaScriptStringEncode(uMovie.Movie.OriginalTitle, True)
                Dim mTagline As String = Web.HttpUtility.JavaScriptStringEncode(uMovie.Movie.Tagline, True)
                Dim mOutline As String = Web.HttpUtility.JavaScriptStringEncode(uMovie.Movie.Outline, True)
                Dim mSortTitle As String = Web.HttpUtility.JavaScriptStringEncode(uMovie.Movie.SortTitle, True)
                Dim mTrailer As String = Web.HttpUtility.JavaScriptStringEncode(If(Not String.IsNullOrEmpty(uMovie.TrailerPath), uMovie.TrailerPath, If(uMovie.Movie.TrailerSpecified, uMovie.Movie.Trailer, String.Empty)), True)
                Dim mSet As String = Web.HttpUtility.JavaScriptStringEncode(If(uMovie.Movie.Sets.Count > 0, uMovie.Movie.Sets.Item(0).Title, String.Empty), True)

                'digit grouping symbol for Votes count
                Dim mVotes As String = Web.HttpUtility.JavaScriptStringEncode(uMovie.Movie.Votes, True)
                If Master.eSettings.GeneralDigitGrpSymbolVotes Then
                    If uMovie.Movie.VotesSpecified Then
                        Dim vote As String = Double.Parse(uMovie.Movie.Votes, Globalization.CultureInfo.InvariantCulture).ToString("N0", Globalization.CultureInfo.CurrentCulture)
                        If vote IsNot Nothing Then
                            mVotes = Web.HttpUtility.JavaScriptStringEncode(vote, True)
                        End If
                    End If
                End If

                'integer or 0
                Dim mPlaycount As String = If(uMovie.Movie.PlayCountSpecified, uMovie.Movie.PlayCount, "0")
                Dim mRuntime As String = If(uMovie.Movie.RuntimeSpecified, uMovie.Movie.Runtime, "0")
                Dim mYear As String = If(uMovie.Movie.YearSpecified, uMovie.Movie.Year, "0")
                Dim mRating As String = If(uMovie.Movie.RatingSpecified, uMovie.Movie.Rating, "0")
                Dim mTop250 As String = If(uMovie.Movie.Top250Specified, uMovie.Movie.Top250, "0")               '

                'string or null
                Dim mBanner As String = If(Not String.IsNullOrEmpty(uMovie.BannerPath), _
                                              Web.HttpUtility.JavaScriptStringEncode(uMovie.BannerPath, True), "null")
                Dim mClearArt As String = If(Not String.IsNullOrEmpty(uMovie.ClearArtPath), _
                                              Web.HttpUtility.JavaScriptStringEncode(uMovie.ClearArtPath, True), "null")
                Dim mClearLogo As String = If(Not String.IsNullOrEmpty(uMovie.ClearLogoPath), _
                                              Web.HttpUtility.JavaScriptStringEncode(uMovie.ClearLogoPath, True), "null")
                Dim mDiscArt As String = If(Not String.IsNullOrEmpty(uMovie.DiscArtPath), _
                                              Web.HttpUtility.JavaScriptStringEncode(uMovie.DiscArtPath, True), "null")
                Dim mFanart As String = If(Not String.IsNullOrEmpty(uMovie.FanartPath), _
                                              Web.HttpUtility.JavaScriptStringEncode(uMovie.FanartPath, True), "null")
                Dim mLandscape As String = If(Not String.IsNullOrEmpty(uMovie.LandscapePath), _
                                              Web.HttpUtility.JavaScriptStringEncode(uMovie.LandscapePath, True), "null")
                Dim mPoster As String = If(Not String.IsNullOrEmpty(uMovie.PosterPath), _
                                              Web.HttpUtility.JavaScriptStringEncode(uMovie.PosterPath, True), "null")

                Dim Command As String = String.Concat("{""jsonrpc"": ""2.0"", ""method"": ""VideoLibrary.SetMovieDetails"", ""params"": {", _
                                                      """title"": ", mTitle, ", ", _
                                                      """playcount"": ", mPlaycount, ", ", _
                                                      """runtime"": ", mRuntime, ", ", _
                                                      """year"": ", mYear, ", ", _
                                                      """plot"": ", mPlot, ", ", _
                                                      """rating"": ", mRating, ", ", _
                                                      """mpaa"": ", mMPAA, ", ", _
                                                      """imdbnumber"": ", mImdbnumber, ", ", _
                                                      """votes"": ", mVotes, ", ", _
                                                      """originaltitle"": ", mOriginalTitle, ", ", _
                                                      """trailer"": ", mTrailer, ", ", _
                                                      """tagline"": ", mTagline, ", ", _
                                                      """plotoutline"": ", mOutline, ", ", _
                                                      """top250"": ", mTop250, ", ", _
                                                      """sorttitle"": ", mSortTitle, ", ", _
                                                      """set"": ", mSet, ", ", _
                                                      """art"": {", _
                                                      """banner"": ", mBanner, ", ", _
                                                      """clearart"": ", mClearArt, ", ", _
                                                      """clearlogo"": ", mClearLogo, ", ", _
                                                      """discart"": ", mDiscArt, ", ", _
                                                      """fanart"": ", mFanart, ", ", _
                                                      """landscape"": ", mLandscape, ", ", _
                                                      """poster"": ", mPoster, "}, ", _
                                                      """movieid"": ", KodiID, "}, ", _
                                                      """id"": ""1""}")

                Dim Result As String = SendJSON(Command)
                If Result.Contains("error") Then
                    logger.Error(String.Concat("Kodi JSON: ", Result))
                    Return False
                Else
                    SendMessage("Ember Media Manager", String.Concat("Movie '", uMovie.Movie.Title, "' sucessfully updated"))
                    Return True
                End If
            Else
                Return False
            End If

        End Function

        Private Function GetMovies() As List(Of KodiMovie)
            Dim MovieList As New List(Of KodiMovie)
            Dim Command As String = "{""jsonrpc"": ""2.0"", ""method"": ""VideoLibrary.GetMovies"", ""params"": { ""properties"" : [""file"", ""imdbnumber""]}, ""id"": ""libMovies""}"
            Dim Result As MatchCollection = Regex.Matches(SendJSON(Command), "\{""file"":""(?<PATH>.*?)"",""imdbnumber"":""(?<IMDBID>.*?)"",""label"":""(?<LABEL>.*?)"",""movieid"":(?<ID>.*?)\}", RegexOptions.Singleline And RegexOptions.IgnoreCase)
            For Each kMovie As Match In Result
                MovieList.Add(New KodiMovie With {.Path = Regex.Replace(kMovie.Groups(1).Value.ToString, "\\\\", "\"), .ImdbID = kMovie.Groups(2).Value.ToString, .Label = kMovie.Groups(3).Value.ToString, .ID = CLng(kMovie.Groups(4).Value)})
            Next
            Return MovieList
        End Function

        Public Function GetMovieIdByPath(ByRef mPath As String) As Long
            Dim movieID As Long = -1

            'get a list of all movies saved in Kodi DB
            Dim kMovies As List(Of KodiMovie) = GetMovies()

            For Each kMovie In kMovies
                If kMovie.Path.ToLower = mPath.ToLower Then
                    movieID = kMovie.ID
                    Exit For
                End If
            Next
            Return movieID
        End Function

        Private Function SendJSON(ByRef Send As String) As String
            Dim Ret As String = String.Empty
            Try
                Dim authInfo As String = _mySettings.Username & ":" & _mySettings.Password
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo))
                Dim Uri As String = "http://" & _mySettings.HostIP & ":" & _mySettings.WebserverPort & "/jsonrpc?request="

                Dim request As HttpWebRequest = CType(HttpWebRequest.Create(Uri), HttpWebRequest)
                request.Headers("Authorization") = "Basic " & authInfo
                request.Method = "Post"

                Dim StreamWriter As StreamWriter = New StreamWriter(request.GetRequestStream)
                StreamWriter.Write(Send)
                StreamWriter.Close()

                'empfang
                Dim response As HttpWebResponse = CType(request.GetResponse, HttpWebResponse)

                Dim StreamReader As StreamReader = New StreamReader(response.GetResponseStream)
                Ret = StreamReader.ReadToEnd

                StreamReader.Close()
                response.Close()
            Catch ex As Exception
                logger.Error(New StackFrame().GetMethod().Name, ex)
                Ret = String.Concat("error_", ex.Message)
            End Try

            Return WebUtility.UrlDecode(Ret)
        End Function

#End Region 'Methods

#Region "Nested Types"

        Structure MySettings

#Region "Fields"

            Dim Username As String
            Dim Password As String
            Dim HostIP As String
            Dim WebserverPort As String

#End Region 'Fields

        End Structure

        Private Class KodiMovie


#Region "Fields"

            Private _path As String
            Private _imdbid As String
            Private _label As String
            Private _id As Long

#End Region 'Fields

#Region "Constructors"

            Public Sub New()
                Me.Clear()
            End Sub

#End Region 'Constructors

#Region "Properties"

            Public Property ID() As Long
                Get
                    Return _id
                End Get
                Set(ByVal value As Long)
                    _id = value
                End Set
            End Property

            Public Property ImdbID() As String
                Get
                    Return _imdbid
                End Get
                Set(ByVal value As String)
                    _imdbid = value
                End Set
            End Property

            Public Property Label() As String
                Get
                    Return _label
                End Get
                Set(ByVal value As String)
                    _label = value
                End Set
            End Property

            Public Property Path() As String
                Get
                    Return _path
                End Get
                Set(ByVal value As String)
                    _path = value
                End Set
            End Property

#End Region 'Properties

#Region "Methods"

            Public Sub Clear()
                Me._id = -1
                Me._imdbid = String.Empty
                Me._label = String.Empty
                Me._path = String.Empty
            End Sub

#End Region 'Methods

        End Class

#End Region 'Nested Types

    End Class

End Namespace
