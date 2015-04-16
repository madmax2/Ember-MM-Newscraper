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

        Public Function UpdateMovieInfo(ByRef movieID As Long) As Boolean
            Dim uMovie As Structures.DBMovie = Master.DB.LoadMovieFromDB(movieID)

            'search movie ID in Kodi DB
            Dim KodiID As Long = GetMovieIdByPath(uMovie.Filename)

            If KodiID > -1 Then

                Dim mPlaycount As String = If(uMovie.Movie.PlayCountSpecified, uMovie.Movie.PlayCount, "0")      'integer
                Dim mRuntime As String = If(uMovie.Movie.RuntimeSpecified, uMovie.Movie.Runtime, "0")            'integer
                Dim mYear As String = If(uMovie.Movie.YearSpecified, uMovie.Movie.Year, "0")                     'integer
                Dim mRating As String = If(uMovie.Movie.RatingSpecified, uMovie.Movie.Rating, "0")               'integer
                Dim mTop250 As String = If(uMovie.Movie.Top250Specified, uMovie.Movie.Top250, "0")               'integer
                Dim mTrailer As String = If(Not String.IsNullOrEmpty(uMovie.TrailerPath), uMovie.TrailerPath, If(uMovie.Movie.TrailerSpecified, uMovie.Movie.Trailer, "null"))
                Dim mSet As String = If(uMovie.Movie.Sets.Count > 0, uMovie.Movie.Sets.Item(0).Title, String.Empty)
                Dim mBanner As String = If(Not String.IsNullOrEmpty(uMovie.BannerPath), """" & uMovie.BannerPath & """", "null")
                Dim mClearArt As String = If(Not String.IsNullOrEmpty(uMovie.ClearArtPath), """" & uMovie.ClearArtPath & """", "null")
                Dim mClearLogo As String = If(Not String.IsNullOrEmpty(uMovie.ClearLogoPath), """" & uMovie.ClearLogoPath & """", "null")
                Dim mDiscArt As String = If(Not String.IsNullOrEmpty(uMovie.DiscArtPath), """" & uMovie.DiscArtPath & """", "null")
                Dim mFanart As String = If(Not String.IsNullOrEmpty(uMovie.FanartPath), """" & uMovie.FanartPath & """", "null")
                Dim mLandscape As String = If(Not String.IsNullOrEmpty(uMovie.LandscapePath), """" & uMovie.LandscapePath & """", "null")
                Dim mPoster As String = If(Not String.IsNullOrEmpty(uMovie.PosterPath), """" & uMovie.PosterPath & """", "null")

                Dim Command As String = Regex.Replace(String.Concat("{""jsonrpc"": ""2.0"", ""method"": ""VideoLibrary.SetMovieDetails"", ""params"": {", _
                                                                    """title"": """, uMovie.Movie.Title, """, ", _
                                                                    """playcount"": ", mPlaycount, ", ", _
                                                                    """runtime"": ", mRuntime, ", ", _
                                                                    """year"": ", mYear, ", ", _
                                                                    """plot"": """, uMovie.Movie.Plot, """, ", _
                                                                    """rating"": ", mRating, ", ", _
                                                                    """mpaa"": """, uMovie.Movie.MPAA, """, ", _
                                                                    """imdbnumber"": """, uMovie.Movie.ID, """, ", _
                                                                    """votes"": """, uMovie.Movie.Votes, """, ", _
                                                                    """originaltitle"": """, uMovie.Movie.OriginalTitle, """, ", _
                                                                    """trailer"": """, mTrailer, """, ", _
                                                                    """tagline"": """, uMovie.Movie.Tagline, """, ", _
                                                                    """plotoutline"": """, uMovie.Movie.Outline, """, ", _
                                                                    """top250"": ", mTop250, ", ", _
                                                                    """sorttitle"": """, uMovie.Movie.SortTitle, """, ", _
                                                                    """set"": """, mSet, """, ", _
                                                                    """art"": {", _
                                                                    """banner"": ", mBanner, ", ", _
                                                                    """clearart"": ", mClearArt, ", ", _
                                                                    """clearlogo"": ", mClearLogo, ", ", _
                                                                    """discart"": ", mDiscArt, ", ", _
                                                                    """fanart"": ", mFanart, ", ", _
                                                                    """landscape"": ", mLandscape, ", ", _
                                                                    """poster"": ", mPoster, "}, ", _
                                                                    """movieid"": ", KodiID, "}, ", _
                                                                    """id"": ""1""}"), "\\", "\\")

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

        Public Function SetMovieDetails() As Boolean
            Dim test As String = SendJSON("test")
            Return True
        End Function

        Private Function SendJSON(ByRef Send As String) As String
            Dim Ret As String = String.Empty

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
