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

Imports System.Net 'Namespace für HttpWeb
Imports System.Text 'Namespace für das Encoding
Imports System.IO 'Namespace für den Stream 
Imports NLog

Namespace Kodi

    Public Class JSON

        Public Function SetMovieDetails() As Boolean
            Dim test As String = SendJSON("test")
            Return True
        End Function

        Private Function SendJSON(ByRef Send As String) As String
            Dim request As HttpWebRequest
            Dim response As HttpWebResponse

            Dim authInfo As String
            Dim Kodi_URI As String

            Dim KodiIP As String = "localhost"
            Dim user As String = "kodi"
            Dim pass As String = "kodi"

            Dim Ret As String

            Kodi_URI = "http://" & KodiIP & ":8090/jsonrpc?request="

            authInfo = user & ":" & pass
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo))

            request = CType(HttpWebRequest.Create(Kodi_URI), HttpWebRequest)
            request.Headers("Authorization") = "Basic " & authInfo
            request.Method = "Post"

            'Send = "{" & Chr(34) & "jsonrpc" & Chr(34) & ":" & Chr(34) & "2.0" & Chr(34) & "," _
            '    & Chr(34) & "method" & Chr(34) & ":" & Chr(34) & tbBefehl.Text & Chr(34) & "," _
            '    & Chr(34) & "params" & Chr(34) & ":{" & tbParameter.Text & "}," _
            '    & Chr(34) & "id" & Chr(34) & ":" & "1" & "}"

            'Send = "{""jsonrpc"": ""2.0"", ""method"": ""VideoLibrary.SetMovieDetails"", ""params"": {""art"": {""logo"": ""nfs://192.168.0.3/mnt/share/media/Video/MoviesHD/Zombieland (2009)[BDRip]-poster.jpg""}, ""movieid"": 1}, ""id"": ""1""}"

            'Send = "{""jsonrpc"": ""2.0"", ""method"": ""Player.GetActivePlayers"", ""id"": 1}"

            'Send = "{""jsonrpc"": ""2.0"", ""method"": ""Player.GetItem"", ""params"": { ""properties"": [""title"", ""album"", ""artist"", ""duration"", ""thumbnail"", ""file"", ""fanart"", ""streamdetails""], ""playerid"": 1 }, ""id"": ""VideoGetItem""}"

            Send = "{""jsonrpc"": ""2.0"", ""method"": ""VideoLibrary.GetMovies"", ""params"": { ""properties"" : [""file"", ""imdbnumber""]}, ""id"": ""libMovies""}"

            'Send = "{""jsonrpc"": ""2.0"", ""method"": ""List.Items.Sources"", ""id"": 1}"

            Dim StreamWriter As StreamWriter = New StreamWriter(request.GetRequestStream)
            StreamWriter.Write(Send)
            StreamWriter.Close()

            'empfang
            response = CType(request.GetResponse, HttpWebResponse)

            Dim StreamReader As StreamReader = New StreamReader(response.GetResponseStream)
            Ret = StreamReader.ReadToEnd

            StreamReader.Close()
            response.Close()

            Return WebUtility.UrlDecode(Ret)
        End Function

    End Class

End Namespace
