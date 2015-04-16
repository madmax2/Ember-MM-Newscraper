﻿' ################################################################################
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

Imports System.Xml.Serialization

Namespace MediaContainers

    <XmlRoot("episodedetails")> _
    Public Class EpisodeDetails

#Region "Fields"

        Private _actors As New List(Of Person)
        Private _aired As String
        Private _credits As New List(Of String)
        Private _dateadded As String
        Private _directors As New List(Of String)
        Private _displayepisode As Integer
        Private _displayseason As Integer
        Private _episode As Integer
        Private _fanart As New Images
        Private _fileInfo As New MediaInfo.Fileinfo
        Private _localfile As String
        Private _playcount As String
        Private _plot As String
        Private _poster As New Images
        Private _posterurl As String
        Private _rating As String
        Private _runtime As String
        Private _season As Integer
        Private _subepisode As Integer
        Private _title As String
        Private _videosource As String
        Private _votes As String

        <XmlIgnore()> _
        Public displaySEset As Boolean = False


#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Me.Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"

        <XmlElement("title")> _
        Public Property Title() As String
            Get
                Return Me._title
            End Get
            Set(ByVal value As String)
                Me._title = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property TitleSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._title)
            End Get
        End Property

        <XmlElement("runtime")> _
        Public Property Runtime() As String
            Get
                Return Me._runtime
            End Get
            Set(ByVal value As String)
                Me._runtime = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property RuntimeSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._runtime)
            End Get
        End Property

        <XmlElement("aired")> _
        Public Property Aired() As String
            Get
                Return Me._aired
            End Get
            Set(ByVal value As String)
                Me._aired = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property AiredSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._aired)
            End Get
        End Property

        <XmlElement("rating")> _
        Public Property Rating() As String
            Get
                Return Me._rating.Replace(",", ".")
            End Get
            Set(ByVal value As String)
                Me._rating = value.Replace(",", ".")
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property RatingSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._rating)
            End Get
        End Property

        <XmlElement("videosource")> _
        Public Property VideoSource() As String
            Get
                Return Me._videosource
            End Get
            Set(ByVal value As String)
                Me._videosource = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property VideoSourceSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._videosource)
            End Get
        End Property

        <XmlElement("votes")> _
        Public Property Votes() As String
            Get
                Return Me._votes
            End Get
            Set(ByVal value As String)
                Me._votes = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property VotesSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._votes)
            End Get
        End Property

        <XmlElement("season")> _
        Public Property Season() As Integer
            Get
                Return Me._season
            End Get
            Set(ByVal value As Integer)
                Me._season = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property SeasonSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._season.ToString)
            End Get
        End Property

        <XmlElement("episode")> _
        Public Property Episode() As Integer
            Get
                Return Me._episode
            End Get
            Set(ByVal value As Integer)
                Me._episode = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property EpisodeSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._episode.ToString)
            End Get
        End Property

        <XmlElement("subepisode")> _
        Public Property SubEpisode() As Integer
            Get
                Return Me._subepisode
            End Get
            Set(ByVal value As Integer)
                Me._subepisode = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property SubEpisodeSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._subepisode.ToString) AndAlso Me._subepisode > 0
            End Get
        End Property

        <XmlElement("displayseason")> _
        Public Property DisplaySeason() As Integer
            Get
                Return Me._displayseason
            End Get
            Set(ByVal value As Integer)
                Me._displayseason = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property DisplaySeasonSpecified() As Boolean
            Get
                Return displaySEset
            End Get
        End Property

        <XmlElement("displayepisode")> _
        Public Property DisplayEpisode() As Integer
            Get
                Return Me._displayepisode
            End Get
            Set(ByVal value As Integer)
                Me._displayepisode = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property DisplayEpisodeSpecified() As Boolean
            Get
                Return displaySEset
            End Get
        End Property

        <XmlElement("plot")> _
        Public Property Plot() As String
            Get
                Return Me._plot
            End Get
            Set(ByVal value As String)
                Me._plot = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property PlotSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._plot)
            End Get
        End Property

        <Obsolete("This property is depreciated. Use Episode.Credits [List(Of String)] instead.")> _
        <XmlIgnore()> _
        Public Property OldCredits() As String
            Get
                Return String.Join(" / ", _credits.ToArray)
            End Get
            Set(ByVal value As String)
                _credits.Clear()
                AddCredit(value)
            End Set
        End Property

        <XmlElement("credits")> _
        Public Property Credits() As List(Of String)
            Get
                Return _credits
            End Get
            Set(ByVal value As List(Of String))
                If value Is Nothing Then
                    _credits.Clear()
                Else
                    _credits = value
                End If
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property CreditsSpecified() As Boolean
            Get
                Return Me._credits.Count > 0
            End Get
        End Property

        <XmlElement("playcount")> _
        Public Property Playcount() As String
            Get
                Return Me._playcount
            End Get
            Set(ByVal value As String)
                Me._playcount = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property PlaycountSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._playcount)
            End Get
        End Property

        <Obsolete("This property is depreciated. Use Episode.Directors [List(Of String)] instead.")> _
        <XmlIgnore()> _
        Public Property Director() As String
            Get
                Return String.Join(" / ", _directors.ToArray)
            End Get
            Set(ByVal value As String)
                _directors.Clear()
                AddDirector(value)
            End Set
        End Property

        <XmlElement("director")> _
        Public Property Directors() As List(Of String)
            Get
                Return _directors
            End Get
            Set(ByVal value As List(Of String))
                If value Is Nothing Then
                    _directors.Clear()
                Else
                    _directors = value
                End If
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property DirectorSpecified() As Boolean
            Get
                Return Me._directors.Count > 0
            End Get
        End Property

        <XmlElement("actor")> _
        Public Property Actors() As List(Of Person)
            Get
                Return Me._actors
            End Get
            Set(ByVal Value As List(Of Person))
                Me._actors = Value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property ActorsSpecified() As Boolean
            Get
                Return Me._actors.Count > 0
            End Get
        End Property

        <XmlElement("fileinfo")> _
        Public Property FileInfo() As MediaInfo.Fileinfo
            Get
                Return Me._fileInfo
            End Get
            Set(ByVal value As MediaInfo.Fileinfo)
                Me._fileInfo = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property FileInfoSpecified() As Boolean
            Get
                If Me._fileInfo.StreamDetails.Video.Count > 0 OrElse _
                Me._fileInfo.StreamDetails.Audio.Count > 0 OrElse _
                 Me._fileInfo.StreamDetails.Subtitle.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        <XmlIgnore()> _
        Public Property Poster() As Images
            Get
                Return Me._poster
            End Get
            Set(ByVal value As Images)
                Me._poster = value
            End Set
        End Property

        <XmlIgnore()> _
        Public Property PosterURL() As String
            Get
                Return Me._posterurl
            End Get
            Set(ByVal value As String)
                Me._posterurl = value
            End Set
        End Property

        <XmlIgnore()> _
        Public Property LocalFile() As String
            Get
                Return Me._localfile
            End Get
            Set(ByVal value As String)
                Me._localfile = value
            End Set
        End Property

        <XmlIgnore()> _
        Public Property Fanart() As Images
            Get
                Return Me._fanart
            End Get
            Set(ByVal value As Images)
                Me._fanart = value
            End Set
        End Property

        <XmlElement("dateadded")> _
        Public Property DateAdded() As String
            Get
                Return Me._dateadded
            End Get
            Set(ByVal value As String)
                Me._dateadded = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property DateAddedSpecified() As Boolean
            Get
                Return Me._dateadded IsNot Nothing
            End Get
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clear()
            Me._actors.Clear()
            Me._aired = String.Empty
            Me._credits.Clear()
            Me._dateadded = String.Empty
            Me._directors.Clear()
            Me._displayepisode = -999
            Me._displayseason = -999
            Me._episode = -999
            Me._fanart = New Images
            Me._fileInfo = New MediaInfo.Fileinfo
            Me._localfile = String.Empty
            Me._playcount = String.Empty
            Me._plot = String.Empty
            Me._poster = New Images
            Me._posterurl = String.Empty
            Me._rating = String.Empty
            Me._runtime = String.Empty
            Me._season = -999
            Me._subepisode = -999
            Me._title = String.Empty
            Me._videosource = String.Empty
            Me._votes = String.Empty
        End Sub

        Public Sub AddCredit(ByVal value As String)
            If String.IsNullOrEmpty(value) Then Return

            If value.Contains("/") Then
                Dim values As String() = value.Split(New [Char]() {"/"c})
                For Each credit As String In values
                    credit = credit.Trim
                    If Not _credits.Contains(credit) And Not value = "See more" Then
                        _credits.Add(credit)
                    End If
                Next
            Else
                value = value.Trim
                If Not _credits.Contains(value) And Not value = "See more" Then
                    _credits.Add(value.Trim)
                End If
            End If
        End Sub

        Public Sub AddDirector(ByVal value As String)
            If String.IsNullOrEmpty(value) Then Return

            If value.Contains("/") Then
                Dim values As String() = value.Split(New [Char]() {"/"c})
                For Each director As String In values
                    director = director.Trim
                    If Not _directors.Contains(director) And Not value = "See more" Then
                        _directors.Add(director)
                    End If
                Next
            Else
                value = value.Trim
                If Not _directors.Contains(value) And Not value = "See more" Then
                    _directors.Add(value.Trim)
                End If
            End If
        End Sub

#End Region 'Methods

    End Class

    <Serializable()> _
    Public Class EpisodeGuide

#Region "Fields"

        Private _url As String

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Me.Clean()
        End Sub

#End Region 'Constructors

#Region "Properties"

        <XmlElement("url")> _
        Public Property URL() As String
            Get
                Return Me._url
            End Get
            Set(ByVal Value As String)
                Me._url = Value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clean()
            Me._url = String.Empty
        End Sub

#End Region 'Methods

    End Class

    <Serializable()> _
    Public Class Fanart

#Region "Fields"

        Private _thumb As New List(Of Thumb)
        Private _url As String

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Me.Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"

        <XmlElement("thumb")> _
        Public Property Thumb() As List(Of Thumb)
            Get
                Return Me._thumb
            End Get
            Set(ByVal value As List(Of Thumb))
                Me._thumb = value
            End Set
        End Property

        <XmlAttribute("url")> _
        Public Property URL() As String
            Get
                Return Me._url
            End Get
            Set(ByVal value As String)
                Me._url = value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clear()
            Me._thumb.Clear()
            Me._url = String.Empty
        End Sub

#End Region 'Methods

    End Class

    <Serializable()> _
    <XmlRoot("movie")> _
    Public Class Movie
        Implements IComparable(Of Movie)

#Region "Fields"

        Private _title As String
        Private _originaltitle As String
        Private _sorttitle As String
        Private _year As String
        Private _releaseDate As String
        Private _top250 As String
        Private _countries As New List(Of String)
        Private _rating As String
        Private _votes As String
        Private _mpaa As String
        Private _certifications As New List(Of String)
        Private _tags As New List(Of String)
        Private _genres As New List(Of String)
        Private _studios As New List(Of String)
        Private _directors As New List(Of String)
        Private _credits As New List(Of String)
        Private _tagline As String
        Private _outline As String
        Private _plot As String
        Private _runtime As String
        Private _trailer As String
        Private _playcount As String
        'Private _watched As String
        Private _actors As New List(Of Person)
        Private _thumb As New List(Of String)
        Private _fanart As New Fanart
        Private _xsets As New List(Of [Set])
        Private _ysets As New SetContainer
        Private _fileInfo As New MediaInfo.Fileinfo
        Private _lev As Integer
        Private _videosource As String
        Private _tmdbcolid As String
        Private _dateadded As String
        Private _scrapersource As String
        Private _datemodified As String
#End Region 'Fields

#Region "Constructors"

        Public Sub New(ByVal sID As String, ByVal sTitle As String, ByVal sYear As String, ByVal iLev As Integer)
            Me.Clear()
            Me.MovieID.ID = sID
            Me._title = sTitle
            Me._year = sYear
            Me._lev = iLev
        End Sub

        Sub New()
            Me.Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"
        <XmlElement("id")> _
        Public MovieID As New _MovieID

        <XmlElement("title")> _
        Public Property Title() As String
            Get
                Return Me._title
            End Get
            Set(ByVal value As String)
                Me._title = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property TitleSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._title)
            End Get
        End Property

        <XmlElement("originaltitle")> _
        Public Property OriginalTitle() As String
            Get
                Return Me._originaltitle
            End Get
            Set(ByVal value As String)
                Me._originaltitle = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property OriginalTitleSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._originaltitle)
            End Get
        End Property

        <XmlElement("sorttitle")> _
        Public Property SortTitle() As String
            Get
                Return Me._sorttitle
            End Get
            Set(ByVal value As String)
                Me._sorttitle = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property SortTitleSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._sorttitle) AndAlso Not Me._sorttitle = StringUtils.SortTokens_Movie(Me._title)
            End Get
        End Property

        <XmlIgnore()> _
        Public Property ID() As String
            Get
                Return Me.MovieID.ID
            End Get
            Set(ByVal value As String)
                Me.MovieID.ID = value
            End Set
        End Property

        <XmlIgnore()> _
        Public Property IDMovieDB() As String
            Get
                Return Me.MovieID.IDMovieDB
            End Get
            Set(ByVal value As String)
                Me.MovieID.IDMovieDB = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property IDMovieDBSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me.MovieID.IDMovieDB)
            End Get
        End Property

        <XmlIgnore()> _
        Public Property TMDBID() As String
            Get
                Return Me.MovieID.IDTMDB
            End Get
            Set(ByVal value As String)
                Me.MovieID.IDTMDB = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property TMDBIDSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me.MovieID.IDTMDB)
            End Get
        End Property

        <XmlIgnore()> _
        Public Property IMDBID() As String
            Get
                Return MovieID.ID.Replace("tt", String.Empty).Trim
            End Get
            Set(ByVal value As String)
                Me.MovieID.ID = value
            End Set
        End Property

        <XmlElement("year")> _
        Public Property Year() As String
            Get
                Return Me._year
            End Get
            Set(ByVal value As String)
                Me._year = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property YearSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._year)
            End Get
        End Property

        <XmlElement("releasedate")> _
        Public Property ReleaseDate() As String
            Get
                Return Me._releaseDate
            End Get
            Set(ByVal value As String)
                Me._releaseDate = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property ReleaseDateSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._releaseDate)
            End Get
        End Property

        <XmlElement("top250")> _
        Public Property Top250() As String
            Get
                Return Me._top250
            End Get
            Set(ByVal value As String)
                Me._top250 = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property Top250Specified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._top250) AndAlso Not Me._top250 = "0"
            End Get
        End Property

        <Obsolete("This property is depreciated. Use Movie.Countries [List(Of String)] instead.")> _
        <XmlIgnore()> _
        Public Property Country() As String
            Get
                Return String.Join(" / ", _countries.ToArray)
            End Get
            Set(ByVal value As String)
                _countries.Clear()
                AddCountry(value)
            End Set
        End Property

        <XmlElement("country")> _
        Public Property Countries() As List(Of String)
            Get
                Return _countries
            End Get
            Set(ByVal value As List(Of String))
                If value Is Nothing Then
                    _countries.Clear()
                Else
                    _countries = value
                End If
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property CountriesSpecified() As Boolean
            Get
                Return Me._countries.Count > 0
            End Get
        End Property

        <XmlElement("rating")> _
        Public Property Rating() As String
            Get
                Return Me._rating.Replace(",", ".")
            End Get
            Set(ByVal value As String)
                Me._rating = value.Replace(",", ".")
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property RatingSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._rating)
            End Get
        End Property

        <XmlElement("votes")> _
        Public Property Votes() As String
            Get
                Return Me._votes
            End Get
            Set(ByVal value As String)
                Me._votes = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property VotesSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._votes)
            End Get
        End Property

        <XmlElement("mpaa")> _
        Public Property MPAA() As String
            Get
                Return Me._mpaa
            End Get
            Set(ByVal value As String)
                Me._mpaa = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property MPAASpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._mpaa)
            End Get
        End Property

        <Obsolete("This property is depreciated. Use Movie.Certifications [List(Of String)] instead.")> _
        <XmlIgnore()> _
        Public Property Certification() As String
            Get
                Return String.Join(" / ", _certifications.ToArray)
            End Get
            Set(ByVal value As String)
                _certifications.Clear()
                AddCertification(value)
            End Set
        End Property

        <XmlElement("certification")> _
        Public Property Certifications() As List(Of String)
            Get
                Return _certifications
            End Get
            Set(ByVal value As List(Of String))
                If value Is Nothing Then
                    _certifications.Clear()
                Else
                    _certifications = value
                End If
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property CertificationsSpecified() As Boolean
            Get
                Return Me._certifications.Count > 0
            End Get
        End Property

        <XmlElement("tag")> _
        Public Property Tags() As List(Of String)
            Get
                Return _tags
            End Get
            Set(ByVal value As List(Of String))
                If value Is Nothing Then
                    _tags.Clear()
                Else
                    _tags = value
                End If
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property TagsSpecified() As Boolean
            Get
                Return Me._tags.Count > 0
            End Get
        End Property

        <Obsolete("This property is depreciated. Use Movie.Genres [List(Of String)] instead.")> _
        <XmlIgnore()> _
        Public Property Genre() As String
            Get
                Return String.Join(" / ", _genres.ToArray)
            End Get
            Set(ByVal value As String)
                _genres.Clear()
                AddGenre(value)
            End Set
        End Property

        <XmlElement("genre")> _
        Public Property Genres() As List(Of String)
            Get
                Return _genres
            End Get
            Set(ByVal value As List(Of String))
                If value Is Nothing Then
                    _genres.Clear()
                Else
                    _genres = value
                End If
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property GenresSpecified() As Boolean
            Get
                Return Me._genres.Count > 0
            End Get
        End Property

        <Obsolete("This property is depreciated. Use Movie.Studios [List(Of String)] instead.")> _
        <XmlIgnore()> _
        Public Property Studio() As String
            Get
                Return String.Join(" / ", _studios.ToArray)
            End Get
            Set(ByVal value As String)
                _studios.Clear()
                AddStudio(value)
            End Set
        End Property

        <XmlElement("studio")> _
        Public Property Studios() As List(Of String)
            Get
                Return _studios
            End Get
            Set(ByVal value As List(Of String))
                If value Is Nothing Then
                    _studios.Clear()
                Else
                    _studios = value
                End If
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property StudiosSpecified() As Boolean
            Get
                Return Me._studios.Count > 0
            End Get
        End Property

        <Obsolete("This property is depreciated. Use Movie.Directors [List(Of String)] instead.")> _
        <XmlIgnore()> _
        Public Property Director() As String
            Get
                Return String.Join(" / ", _directors.ToArray)
            End Get
            Set(ByVal value As String)
                _directors.Clear()
                AddDirector(value)
            End Set
        End Property

        <XmlElement("director")> _
        Public Property Directors() As List(Of String)
            Get
                Return _directors
            End Get
            Set(ByVal value As List(Of String))
                If value Is Nothing Then
                    _directors.Clear()
                Else
                    _directors = value
                End If
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property DirectorsSpecified() As Boolean
            Get
                Return Me._directors.Count > 0
            End Get
        End Property

        <Obsolete("This property is depreciated. Use Movie.Credits [List(Of String)] instead.")> _
        <XmlIgnore()> _
        Public Property OldCredits() As String
            Get
                Return String.Join(" / ", _credits.ToArray)
            End Get
            Set(ByVal value As String)
                _credits.Clear()
                AddCredit(value)
            End Set
        End Property

        <XmlElement("credits")> _
        Public Property Credits() As List(Of String)
            Get
                Return _credits
            End Get
            Set(ByVal value As List(Of String))
                If value Is Nothing Then
                    _credits.Clear()
                Else
                    _credits = value
                End If
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property CreditsSpecified() As Boolean
            Get
                Return Me._credits.Count > 0
            End Get
        End Property

        <XmlElement("tagline")> _
        Public Property Tagline() As String
            Get
                Return Me._tagline
            End Get
            Set(ByVal value As String)
                Me._tagline = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property TaglineSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._tagline)
            End Get
        End Property

        <XmlIgnore()> _
        Public Property Scrapersource() As String
            Get
                Return Me._scrapersource
            End Get
            Set(ByVal value As String)
                Me._scrapersource = value
            End Set
        End Property

        <XmlElement("outline")> _
        Public Property Outline() As String
            Get
                Return Me._outline
            End Get
            Set(ByVal value As String)
                Me._outline = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property OutlineSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._outline)
            End Get
        End Property

        <XmlElement("plot")> _
        Public Property Plot() As String
            Get
                Return Me._plot
            End Get
            Set(ByVal value As String)
                Me._plot = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property PlotSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._plot)
            End Get
        End Property

        <XmlElement("runtime")> _
        Public Property Runtime() As String
            Get
                Return Me._runtime
            End Get
            Set(ByVal value As String)
                Me._runtime = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property RuntimeSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._runtime)
            End Get
        End Property

        <XmlElement("trailer")> _
        Public Property Trailer() As String
            Get
                Return Me._trailer
            End Get
            Set(ByVal value As String)
                Me._trailer = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property TrailerSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._trailer)
            End Get
        End Property

        <XmlElement("playcount")> _
        Public Property PlayCount() As String
            Get
                Return Me._playcount
            End Get
            Set(ByVal value As String)
                Me._playcount = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property PlayCountSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._playcount) AndAlso Not Me._playcount = "0"
            End Get
        End Property

        <XmlElement("dateadded")> _
        Public Property DateAdded() As String
            Get
                Return Me._dateadded
            End Get
            Set(ByVal value As String)
                Me._dateadded = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property DateAddedSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._dateadded)
            End Get
        End Property

        <XmlElement("datemodified")> _
        Public Property DateModified() As String
            Get
                Return Me._datemodified
            End Get
            Set(ByVal value As String)
                Me._datemodified = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property DateModifiedSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._datemodified)
            End Get
        End Property

        '<XmlElement("watched")> _
        'Public Property Watched() As String
        '    Get
        '        Return Me._watched
        '    End Get
        '    Set(ByVal value As String)
        '        Me._watched = value
        '    End Set
        'End Property

        '<XmlIgnore()> _
        'Public ReadOnly Property WatchedSpecified() As Boolean
        '    Get
        '        Return Not String.IsNullOrEmpty(Me._watched)
        '    End Get
        'End Property

        <XmlElement("actor")> _
        Public Property Actors() As List(Of Person)
            Get
                Return Me._actors
            End Get
            Set(ByVal Value As List(Of Person))
                Me._actors = Value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property ActorsSpecified() As Boolean
            Get
                Return Me._actors.Count > 0
            End Get
        End Property

        <XmlElement("thumb")> _
        Public Property Thumb() As List(Of String)
            Get
                Return Me._thumb
            End Get
            Set(ByVal value As List(Of String))
                Me._thumb = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property ThumbSpecified() As Boolean
            Get
                Return Me._thumb.Count > 0
            End Get
        End Property

        <XmlElement("fanart")> _
        Public Property Fanart() As Fanart
            Get
                Return Me._fanart
            End Get
            Set(ByVal value As Fanart)
                Me._fanart = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property FanartSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._fanart.URL)
            End Get
        End Property

        <XmlIgnore()> _
        Public Property Sets() As List(Of [Set])
            Get
                Return If(Master.eSettings.MovieYAMJCompatibleSets, Me._ysets.Sets, Me._xsets)
            End Get
            Set(ByVal value As List(Of [Set]))
                If Master.eSettings.MovieYAMJCompatibleSets Then
                    Me._ysets.Sets = value
                Else
                    Me._xsets = value
                End If
            End Set
        End Property

        <XmlElement("set")> _
        Public Property XSets() As List(Of [Set])
            Get
                Return Me._xsets
            End Get
            Set(ByVal value As List(Of [Set]))
                _xsets = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property XSetsSpecified() As Boolean
            Get
                Return Me._xsets.Count > 0
            End Get
        End Property

        <XmlElement("sets")> _
        Public Property YSets() As SetContainer
            Get
                Return _ysets
            End Get
            Set(ByVal value As SetContainer)
                _ysets = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property YSetsSpecified() As Boolean
            Get
                Return Me._ysets.Sets.Count > 0
            End Get
        End Property

        <XmlElement("fileinfo")> _
        Public Property FileInfo() As MediaInfo.Fileinfo
            Get
                Return Me._fileInfo
            End Get
            Set(ByVal value As MediaInfo.Fileinfo)
                Me._fileInfo = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property FileInfoSpecified() As Boolean
            Get
                If Me._fileInfo.StreamDetails.Video IsNot Nothing AndAlso _
                (Me._fileInfo.StreamDetails.Video.Count > 0 OrElse _
                 Me._fileInfo.StreamDetails.Audio.Count > 0 OrElse _
                 Me._fileInfo.StreamDetails.Subtitle.Count > 0) Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        <XmlIgnore()> _
        Public Property Lev() As Integer
            Get
                Return Me._lev
            End Get
            Set(ByVal value As Integer)
                Me._lev = value
            End Set
        End Property

        <XmlElement("videosource")> _
        Public Property VideoSource() As String
            Get
                Return Me._videosource
            End Get
            Set(ByVal value As String)
                Me._videosource = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property VideoSourceSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._videosource)
            End Get
        End Property

        <XmlElement("tmdbcolid")> _
        Public Property TMDBColID() As String
            Get
                Return Me._tmdbcolid
            End Get
            Set(ByVal value As String)
                Me._tmdbcolid = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property TMDBColIDSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._tmdbcolid)
            End Get
        End Property

        <Serializable()> _
        Class _MovieID
            Private _imdbid As String
            Private _moviedb As String
            Private _tmdbid As String

            Sub New()
                Me.Clear()
            End Sub

            Public Sub Clear()
                _imdbid = String.Empty
                _moviedb = String.Empty
                _tmdbid = String.Empty
            End Sub

            <XmlText()> _
            Public Property ID() As String
                Get
                    Return If(Not String.IsNullOrEmpty(_imdbid), If(_imdbid.Substring(0, 2) = "tt", If(Not String.IsNullOrEmpty(_moviedb) AndAlso _imdbid.Trim = "tt-1", _imdbid.Replace("tt", String.Empty), _imdbid.Trim), If(Not _imdbid.Trim = "tt-1", If(Not String.IsNullOrEmpty(_imdbid), String.Concat("tt", _imdbid), String.Empty), _imdbid)), String.Empty)
                End Get
                Set(ByVal value As String)
                    _imdbid = If(Not String.IsNullOrEmpty(value), If(value.Substring(0, 2) = "tt", value.Trim, String.Concat("tt", value.Trim)), String.Empty)
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property IDSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(_imdbid) AndAlso Not _imdbid = "tt"
                End Get
            End Property

            <XmlAttribute("moviedb")> _
            Public Property IDMovieDB() As String
                Get
                    Return _moviedb.Trim
                End Get
                Set(ByVal value As String)
                    Me._moviedb = value.Trim
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property IDMovieDBSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._moviedb)
                End Get
            End Property

            <XmlAttribute("TMDB")> _
            Public Property IDTMDB() As String
                Get
                    Return _tmdbid.Trim
                End Get
                Set(ByVal value As String)
                    Me._tmdbid = value.Trim
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property IDTMDBSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._tmdbid)
                End Get
            End Property

        End Class

#End Region 'Properties

#Region "Methods"

        Public Sub AddSet(ByVal SetID As Long, ByVal SetName As String, ByVal Order As Integer, ByVal SetTMDBColID As String)
            Dim tSet = From bSet As [Set] In Sets Where bSet.ID = SetID
            Dim iSet = From bset As [Set] In Sets Where bset.TMDBColID = SetTMDBColID

            If tSet.Count > 0 Then
                Sets.Remove(tSet(0))
            End If

            If iSet.Count > 0 Then
                Sets.Remove(iSet(0))
            End If

            Sets.Add(New [Set] With {.ID = SetID, .Title = SetName, .Order = If(Order > 0, Order.ToString, String.Empty), .TMDBColID = SetTMDBColID})
        End Sub

        Public Sub AddTag(ByVal value As String)
            If String.IsNullOrEmpty(value) Then Return
            If Not _tags.Contains(value) Then
                _tags.Add(value.Trim)
            End If
        End Sub

        Public Sub AddCertification(ByVal value As String)
            If String.IsNullOrEmpty(value) Then Return

            If value.Contains("/") Then
                Dim values As String() = value.Split(New [Char]() {"/"c})
                For Each certification As String In values
                    certification = certification.Trim
                    If Not _certifications.Contains(certification) Then
                        _certifications.Add(certification)
                    End If
                Next
            Else
                If Not _certifications.Contains(value) Then
                    _certifications.Add(value.Trim)
                End If
            End If
        End Sub

        Public Sub AddGenre(ByVal value As String)
            If String.IsNullOrEmpty(value) Then Return

            If value.Contains("/") Then
                Dim values As String() = value.Split(New [Char]() {"/"c})
                For Each genre As String In values
                    genre = genre.Trim
                    If Not _genres.Contains(genre) Then
                        _genres.Add(genre)
                    End If
                Next
            Else
                If Not _genres.Contains(value) Then
                    _genres.Add(value.Trim)
                End If
            End If
        End Sub

        Public Sub AddStudio(ByVal value As String)
            If String.IsNullOrEmpty(value) Then Return

            If value.Contains("/") Then
                Dim values As String() = value.Split(New [Char]() {"/"c})
                For Each studio As String In values
                    studio = studio.Trim
                    If Not _studios.Contains(studio) Then
                        _studios.Add(studio)
                    End If
                Next
            Else
                If Not _studios.Contains(value) Then
                    _studios.Add(value.Trim)
                End If
            End If
        End Sub

        Public Sub AddDirector(ByVal value As String)
            If String.IsNullOrEmpty(value) Then Return

            If value.Contains("/") Then
                Dim values As String() = value.Split(New [Char]() {"/"c})
                For Each director As String In values
                    director = director.Trim
                    If Not _directors.Contains(director) And Not value = "See more" Then
                        _directors.Add(director)
                    End If
                Next
            Else
                value = value.Trim
                If Not _directors.Contains(value) And Not value = "See more" Then
                    _directors.Add(value.Trim)
                End If
            End If
        End Sub

        Public Sub AddCredit(ByVal value As String)
            If String.IsNullOrEmpty(value) Then Return

            If value.Contains("/") Then
                Dim values As String() = value.Split(New [Char]() {"/"c})
                For Each credit As String In values
                    credit = credit.Trim
                    If Not _credits.Contains(credit) And Not value = "See more" Then
                        _credits.Add(credit)
                    End If
                Next
            Else
                value = value.Trim
                If Not _credits.Contains(value) And Not value = "See more" Then
                    _credits.Add(value.Trim)
                End If
            End If
        End Sub

        Public Sub AddCountry(ByVal value As String)
            If String.IsNullOrEmpty(value) Then Return

            If value.Contains("/") Then
                Dim values As String() = value.Split(New [Char]() {"/"c})
                For Each country As String In values
                    country = country.Trim
                    If Not _countries.Contains(country) Then
                        _countries.Add(country)
                    End If
                Next
            Else
                value = value.Trim
                If Not _countries.Contains(value) Then
                    _countries.Add(value.Trim)
                End If
            End If
        End Sub

        Public Sub Clear()
            'Me._imdbid = String.Empty
            Me._actors.Clear()
            Me._certifications.Clear()
            Me._countries.Clear()
            Me._credits.Clear()
            Me._dateadded = String.Empty
            Me._datemodified = String.Empty
            Me._directors.Clear()
            Me._fanart = New Fanart
            Me._fileInfo = New MediaInfo.Fileinfo
            Me._tags.Clear()
            Me._genres.Clear()
            Me._lev = 0
            Me._mpaa = String.Empty
            Me._originaltitle = String.Empty
            Me._outline = String.Empty
            Me._playcount = String.Empty
            Me._plot = String.Empty
            Me._rating = String.Empty
            Me._releaseDate = String.Empty
            Me._runtime = String.Empty
            Me._scrapersource = String.Empty
            Me._sorttitle = String.Empty
            Me._studios.Clear()
            Me._tagline = String.Empty
            Me._thumb.Clear()
            Me._title = String.Empty
            Me._tmdbcolid = String.Empty
            Me._top250 = String.Empty
            Me._trailer = String.Empty
            Me._videosource = String.Empty
            Me._votes = String.Empty
            Me._xsets.Clear()
            Me._year = String.Empty
            Me._ysets = New SetContainer
            Me.MovieID.Clear()
        End Sub

        Public Sub ClearForOfflineHolder()
            'Me._imdbid = String.Empty
            'Me._title = String.Empty
            Me._originaltitle = String.Empty
            Me._sorttitle = String.Empty
            'Me._year = String.Empty
            Me._rating = String.Empty
            Me._votes = String.Empty
            Me._mpaa = String.Empty
            Me._top250 = String.Empty
            Me._countries.Clear()
            Me._outline = String.Empty
            Me._plot = String.Empty
            Me._tagline = String.Empty
            Me._trailer = String.Empty
            Me._certifications.Clear()
            Me._tags.Clear()
            Me._genres.Clear()
            Me._runtime = String.Empty
            Me._releaseDate = String.Empty
            Me._studios.Clear()
            Me._directors.Clear()
            Me._credits.Clear()
            Me._playcount = String.Empty
            Me._thumb.Clear()
            Me._fanart = New Fanart
            Me._actors.Clear()
            ' Me._fileInfo = New MediaInfo.Fileinfo
            Me._ysets = New SetContainer
            Me._xsets.Clear()
            Me._lev = 0
            'Me._videosource = String.Empty
            Me._dateadded = String.Empty
            Me._datemodified = String.Empty
            Me.MovieID.Clear()
        End Sub

        Public Function CompareTo(ByVal other As Movie) As Integer Implements IComparable(Of Movie).CompareTo
            Dim retVal As Integer = (Me.Lev).CompareTo(other.Lev)
            If retVal = 0 Then
                retVal = (Me.Year).CompareTo(other.Year) * -1
            End If
            Return retVal
        End Function

        Public Sub RemoveSet(ByVal SetName As String)
            Dim tSet = From bSet As [Set] In Sets Where bSet.Title = SetName
            If tSet.Count > 0 Then
                Sets.Remove(tSet(0))
            End If
        End Sub

        Public Sub RemoveSet(ByVal SetID As Long)
            Dim tSet = From bSet As [Set] In Sets Where bSet.ID = SetID
            If tSet.Count > 0 Then
                Sets.Remove(tSet(0))
            End If
        End Sub

#End Region 'Methods

    End Class

    <Serializable()> _
    <XmlRoot("movieset")> _
    Public Class MovieSet

#Region "Fields"

        Private _id As String
        Private _plot As String
        Private _title As String

#End Region 'Fields

#Region "Constructors"

        Public Sub New(ByVal sID As String, ByVal sTitle As String, ByVal sPlot As String)
            Me.Clear()
            Me._id = sID
            Me._title = sTitle
            Me._plot = sPlot
        End Sub

        Public Sub New()
            Me.Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"

        <XmlElement("title")> _
        Public Property Title() As String
            Get
                Return Me._title
            End Get
            Set(ByVal value As String)
                Me._title = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property TitleSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._title)
            End Get
        End Property

        <XmlElement("id")> _
        Public Property ID() As String
            Get
                Return Me._id.Trim
            End Get
            Set(ByVal value As String)
                Me._id = value.Trim
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property IDSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._id)
            End Get
        End Property

        <XmlElement("plot")> _
        Public Property Plot() As String
            Get
                Return Me._plot
            End Get
            Set(ByVal value As String)
                Me._plot = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property PlotSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._plot)
            End Get
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clear()
            _title = String.Empty
            _id = String.Empty
            _plot = String.Empty
        End Sub

#End Region 'Methods

    End Class

    <Serializable()> _
    Public Class Person

#Region "Fields"

        Private _id As Long
        Private _name As String
        Private _order As Integer
        Private _role As String
        Private _thumbpath As String
        Private _thumburl As String

#End Region 'Fields

#Region "Constructors"

        Public Sub New(ByVal sName As String)
            Me._name = sName
        End Sub

        Public Sub New(ByVal sName As String, ByVal sRole As String, ByVal sThumb As String)
            Me._name = sName
            Me._role = sRole
            Me._thumburl = sThumb
        End Sub

        Public Sub New()
            Me.Clean()
        End Sub

#End Region 'Constructors

#Region "Properties"

        <XmlIgnore()> _
        Public Property ID() As Long
            Get
                Return Me._id
            End Get
            Set(ByVal Value As Long)
                Me._id = Value
            End Set
        End Property

        <XmlElement("name")> _
        Public Property Name() As String
            Get
                Return Me._name
            End Get
            Set(ByVal Value As String)
                Me._name = Value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property NameSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._name)
            End Get
        End Property

        <XmlElement("role")> _
        Public Property Role() As String
            Get
                Return Me._role
            End Get
            Set(ByVal Value As String)
                Me._role = Value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property RoleSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._role)
            End Get
        End Property

        <XmlElement("order")> _
        Public Property Order() As Integer
            Get
                Return Me._order
            End Get
            Set(ByVal Value As Integer)
                Me._order = Value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property OrderSpecified() As Boolean
            Get
                Return Me._order > -1
            End Get
        End Property

        <XmlElement("thumb")> _
        Public Property ThumbURL() As String
            Get
                Return Me._thumburl
            End Get
            Set(ByVal Value As String)
                Me._thumburl = Value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property ThumbURLSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._thumburl)
            End Get
        End Property

        <XmlIgnore()> _
        Public Property ThumbPath() As String
            Get
                Return Me._thumbpath
            End Get
            Set(ByVal Value As String)
                Me._thumbpath = Value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property ThumbPathSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._thumbpath)
            End Get
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clean()
            Me._id = -1
            Me._name = String.Empty
            Me._order = -1
            Me._role = String.Empty
            Me._thumbpath = String.Empty
            Me._thumburl = String.Empty
        End Sub

        Public Overrides Function ToString() As String
            Return Me._name
        End Function

#End Region 'Methods

    End Class

    <Serializable()> _
    Public Class SetContainer

#Region "Fields"

        Private _set As New List(Of [Set])

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Me.Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"

        <XmlElement("set")> _
        Public Property Sets() As List(Of [Set])
            Get
                Return _set
            End Get
            Set(ByVal value As List(Of [Set]))
                _set = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property SetsSpecified() As Boolean
            Get
                Return Me._set.Count > 0
            End Get
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clear()
            Me._set = New List(Of [Set])
        End Sub

#End Region 'Methods

    End Class

    <Serializable()> _
    Public Class Thumb

#Region "Fields"

        Private _preview As String
        Private _text As String

#End Region 'Fields

#Region "Properties"

        <XmlAttribute("preview")> _
        Public Property Preview() As String
            Get
                Return Me._preview
            End Get
            Set(ByVal Value As String)
                Me._preview = Value
            End Set
        End Property

        <XmlText()> _
        Public Property [Text]() As String
            Get
                Return Me._text
            End Get
            Set(ByVal Value As String)
                Me._text = Value
            End Set
        End Property

#End Region 'Properties

    End Class

    <XmlRoot("tvshow")> _
    Public Class TVShow

#Region "Fields"

        Private _title As String
        Private _id As String
        Private _episodeguide As New EpisodeGuide
        Private _rating As String
        Private _genres As New List(Of String)
        Private _mpaa As String
        Private _premiered As String
        Private _studio As String
        Private _studios As New List(Of String)
        Private _plot As String
        Private _runtime As String
        Private _actors As New List(Of Person)
        Private _boxeeTvDb As String
        Private _status As String
        Private _tags As New List(Of String)
        Private _votes As String
        Private _directors As New List(Of String)

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Me.Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"

        <XmlElement("title")> _
        Public Property Title() As String
            Get
                Return Me._title
            End Get
            Set(ByVal value As String)
                Me._title = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property TitleSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._title)
            End Get
        End Property

        <XmlElement("id")> _
        Public Property ID() As String
            Get
                Return Me._id.Trim
            End Get
            Set(ByVal value As String)
                If Integer.TryParse(value, 0) Then Me._id = value.Trim
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property IDSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._id)
            End Get
        End Property

        <XmlElement("boxeeTvDb")> _
        Public Property BoxeeTvDb() As String
            Get
                Return Me._boxeeTvDb
            End Get
            Set(ByVal value As String)
                If Integer.TryParse(value, 0) Then Me._boxeeTvDb = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property BoxeeTvDbSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._boxeeTvDb)
            End Get
        End Property

        <XmlElement("episodeguide")> _
        Public Property EpisodeGuide() As EpisodeGuide
            Get
                Return Me._episodeguide
            End Get
            Set(ByVal value As EpisodeGuide)
                Me._episodeguide = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property EpisodeGuideSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._episodeguide.URL)
            End Get
        End Property

        <XmlElement("rating")> _
        Public Property Rating() As String
            Get
                Return Me._rating.Replace(",", ".")
            End Get
            Set(ByVal value As String)
                Me._rating = value.Replace(",", ".")
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property RatingSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._rating)
            End Get
        End Property

        <XmlElement("votes")> _
        Public Property Votes() As String
            Get
                Return Me._votes
            End Get
            Set(ByVal value As String)
                Me._votes = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property VotesSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._votes)
            End Get
        End Property

        <Obsolete("This property is depreciated. Use TVShow.Genres [List(Of String)] instead.")> _
        <XmlIgnore()> _
        Public Property Genre() As String
            Get
                Return String.Join(" / ", _genres.ToArray)
            End Get
            Set(ByVal value As String)
                _genres.Clear()
                AddGenre(value)
            End Set
        End Property

        <XmlElement("genre")> _
        Public Property Genres() As List(Of String)
            Get
                Return _genres
            End Get
            Set(ByVal value As List(Of String))
                If value Is Nothing Then
                    _genres.Clear()
                Else
                    _genres = value
                End If
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property GenresSpecified() As Boolean
            Get
                Return _genres.Count > 0
            End Get
        End Property

        <XmlElement("director")> _
        Public Property Directors() As List(Of String)
            Get
                Return _directors
            End Get
            Set(ByVal value As List(Of String))
                If value Is Nothing Then
                    _directors.Clear()
                Else
                    _directors = value
                End If
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property DirectorsSpecified() As Boolean
            Get
                Return _directors.Count > 0
            End Get
        End Property

        <XmlElement("mpaa")> _
        Public Property MPAA() As String
            Get
                Return Me._mpaa
            End Get
            Set(ByVal value As String)
                Me._mpaa = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property MPAASpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._mpaa)
            End Get
        End Property

        <XmlElement("premiered")> _
        Public Property Premiered() As String
            Get
                Return Me._premiered
            End Get
            Set(ByVal value As String)
                Me._premiered = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property PremieredSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._premiered)
            End Get
        End Property

        <Obsolete("This property is depreciated. Use TVShow.Studios [List(Of String)] instead.")> _
        <XmlIgnore()> _
        Public Property Studio() As String
            Get
                Return String.Join(" / ", _studios.ToArray)
            End Get
            Set(ByVal value As String)
                _studios.Clear()
                AddStudio(value)
            End Set
        End Property

        <XmlElement("studio")> _
        Public Property Studios() As List(Of String)
            Get
                Return Me._studios
            End Get
            Set(ByVal value As List(Of String))
                Me._studios = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property StudiosSpecified() As Boolean
            Get
                Return _studios.Count > 0
            End Get
        End Property

        <XmlElement("status")> _
        Public Property Status() As String
            Get
                Return Me._status
            End Get
            Set(ByVal value As String)
                Me._status = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property StatusSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._status)
            End Get
        End Property

        <XmlElement("plot")> _
        Public Property Plot() As String
            Get
                Return Me._plot
            End Get
            Set(ByVal value As String)
                Me._plot = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property PlotSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._plot)
            End Get
        End Property

        <XmlElement("tag")> _
        Public Property Tags() As List(Of String)
            Get
                Return _tags
            End Get
            Set(ByVal value As List(Of String))
                If value Is Nothing Then
                    _tags.Clear()
                Else
                    _tags = value
                End If
            End Set
        End Property

        <XmlElement("runtime")> _
        Public Property Runtime() As String
            Get
                Return Me._runtime
            End Get
            Set(ByVal value As String)
                Me._runtime = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property RuntimeSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._runtime)
            End Get
        End Property

        <XmlElement("actor")> _
        Public Property Actors() As List(Of Person)
            Get
                Return Me._actors
            End Get
            Set(ByVal Value As List(Of Person))
                Me._actors = Value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property ActorsSpecified() As Boolean
            Get
                Return Me._actors.Count > 0
            End Get
        End Property

        <XmlIgnore()> _
        Public Property TVDBID() As String
            Get
                Return Me._id.Trim
            End Get
            Set(ByVal value As String)
                Me._id = value.Trim
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub AddGenre(ByVal value As String)
            If String.IsNullOrEmpty(value) Then Return

            If value.Contains("/") Then
                Dim values As String() = value.Split(New [Char]() {"/"c})
                For Each genre As String In values
                    genre = genre.Trim
                    If Not _genres.Contains(genre) Then
                        _genres.Add(genre)
                    End If
                Next
            Else
                If Not _genres.Contains(value) Then
                    _genres.Add(value.Trim)
                End If
            End If
        End Sub

        Public Sub AddStudio(ByVal value As String)
            If String.IsNullOrEmpty(value) Then Return

            If value.Contains("/") Then
                Dim values As String() = value.Split(New [Char]() {"/"c})
                For Each studio As String In values
                    studio = studio.Trim
                    If Not _studios.Contains(studio) Then
                        _studios.Add(studio)
                    End If
                Next
            Else
                If Not _studios.Contains(value) Then
                    _studios.Add(value.Trim)
                End If
            End If
        End Sub

        Public Sub Clear()
            _title = String.Empty
            _id = String.Empty
            _boxeeTvDb = String.Empty
            _rating = String.Empty
            _plot = String.Empty
            _runtime = String.Empty
            _mpaa = String.Empty
            _genres.Clear()
            _premiered = String.Empty
            _status = String.Empty
            _studio = String.Empty
            _votes = String.Empty
            _actors.Clear()
            _episodeguide.URL = String.Empty
            _tags.Clear()
            _directors.Clear()
            _studios.Clear()
        End Sub

        Public Sub BlankId()
            Me._id = Nothing
        End Sub

        Public Sub BlankBoxeeId()
            Me._boxeeTvDb = Nothing
        End Sub

#End Region 'Methods

    End Class

    Public Class [Image]

#Region "Constructors"

        Public Sub New()
            Me.Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"
        Public Property Width As String
        Public Property Height As String
        Public Property Description As String 'Is the size of the image. Acceptable values are:
        ' POSTER
        ' "thumb" - smallest, the one downloaded to show in the dlgImgSelect. If no thumb format image will NOT be shown
        ' "w154" - Small
        ' "cover"- "w185" intermediate
        ' "w342" - Intermediate
        ' "mid" - w500 - Medium
        ' "original" - full size
        '
        ' FANART
        ' "thumb" - smallest, the one downloaded to show in the dlgImgSelect. If no thumb format image will NOT be shown
        ' "poster" - w780 - Medium
        ' "w1280" - Large
        ' "original" - full size
        Public Property isChecked As Boolean
        Public Property URL As String ' path to image (local or url)
        Public Property WebImage As Images
        Public Property ParentID As String 'All images of the same size must have this identical, is used to group the images.
        Public Property Season As Integer
        Public Property ShortLang As String
        Public Property LongLang As String
        Public Property Likes As Integer
        Public Property VoteAverage As String
        Public Property VoteCount As Integer
        Public Property Disc As Integer
        Public Property DiscType As String
        Public Property ThumbURL As String

#End Region 'Properties

#Region "Methods"

        Public Sub Clear()
            Me._Description = String.Empty
            Me._Disc = 0
            Me._DiscType = String.Empty
            Me._isChecked = False
            Me._Likes = 0
            Me._Season = -1
            Me._URL = String.Empty
            Me._VoteAverage = String.Empty
            Me._VoteCount = 0
            Me._WebImage = New Images
            Me._ThumbURL = String.Empty
        End Sub

#End Region 'Methods

    End Class

    Public Class GroupImg
#Region "Fields"
        Public pictures(4) As Image
        ' POSTER
        ' "thumb" - smallest, the one downloaded to show in the dlgImgSelect. If no thumb format image will NOT be shown
        ' "w154" - Small
        ' "cover"- "w185" intermediate
        ' "w342" - Intermediate
        ' "mid" - w500 - Medium
        ' "original" - full size
        '
        ' FANART
        ' "thumb" - smallest, the one downloaded to show in the dlgImgSelect. If no thumb format image will NOT be shown
        ' "poster" - w780 - Medium
        ' "w1280" - Large
        ' "original" - full size
#End Region
    End Class

    <Serializable()> _
    Public Class [Set]

#Region "Fields"

        Private _id As Long
        Private _order As String
        Private _title As String
        Private _tmdbcolid As String

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Me.Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"

        <XmlIgnore()> _
        Public Property ID() As Long
            Get
                Return _id
            End Get
            Set(ByVal value As Long)
                _id = value
            End Set
        End Property

        <XmlAttribute("order")> _
        Public Property Order() As String
            Get
                Return _order
            End Get
            Set(ByVal value As String)
                _order = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property OrderSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._order)
            End Get
        End Property

        <XmlAttribute("tmdbcolid")> _
        Public Property TMDBColID() As String
            Get
                Return _tmdbcolid
            End Get
            Set(ByVal value As String)
                _tmdbcolid = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property TMDBColIDSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._tmdbcolid)
            End Get
        End Property

        <XmlText()> _
        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal value As String)
                _title = value
            End Set
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property TitleSpecified() As Boolean
            Get
                Return Not String.IsNullOrEmpty(Me._title)
            End Get
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clear()
            _id = -1
            _title = String.Empty
            _order = String.Empty
            _tmdbcolid = String.Empty
        End Sub

#End Region 'Methods

    End Class

    Public Class [Theme]

#Region "Constructors"

        Public Sub New()
            Me.Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"
        Public Property Quality As String
        Public Property URL As String ' path to image (local or url)
        Public Property WebTheme As Themes
        Public Property ShortLang As String
        Public Property LongLang As String

#End Region 'Properties

#Region "Methods"

        Public Sub Clear()
            Me._URL = String.Empty
            Me._Quality = String.Empty
            Me._WebTheme = New Themes
        End Sub

#End Region 'Methods

    End Class

    Public Class [Trailer]

#Region "Constructors"

        Public Sub New()
            Me.Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"
        Public Property Quality As String
        Public Property URL As String ' path to image (local or url)
        Public Property WebTrailer As Trailers
        Public Property ShortLang As String
        Public Property LongLang As String

#End Region 'Properties

#Region "Methods"

        Public Sub Clear()
            Me._URL = String.Empty
            Me._Quality = String.Empty
            Me._WebTrailer = New Trailers
        End Sub

#End Region 'Methods

    End Class

End Namespace

