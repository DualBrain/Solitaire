Option Explicit On 
Option Strict On

Imports System.Environment
Imports System.IO
Imports System.IO.IsolatedStorage

Public Enum Scoring
  None
  Standard
  Vegas
  VegasCumulative
End Enum

Public Class Settings

  Private Const DefaultFileName As String = "settings.xml"
  Private Const DefaultUseIsolatedStorage As Boolean = False

  Private m_position As Point ' Location of the main window.
  Private m_size As Size ' Size of the main window.

  Private m_cardBack As Integer = 3 ' Index of picture to use for deck back.
  Private m_drawOne As Boolean = True ' True when drawing one card not 3.
  Private m_outline As Boolean = False ' True when outline dragging.
  Private m_scoring As Scoring = Scoring.Standard ' None, standard, vegas or vegas cumulative.
  Private m_timedGame As Boolean = True ' True if game is timed.
  Private m_viewStatusBar As Boolean = True ' True if the status bar is visible.

#Region "Loading and Saving"

  Overloads Shared Function GetFileStreamForWriting() As IO.Stream
    Return GetFileStreamForWriting(DefaultFileName, DefaultUseIsolatedStorage)
  End Function

  Overloads Shared Function GetFileStreamForWriting(ByVal filename As String) As IO.Stream
    Return GetFileStreamForWriting(filename, DefaultUseIsolatedStorage)
  End Function

  Overloads Shared Function GetFileStreamForWriting(ByVal filename As String, ByVal useIsolatedStorage As Boolean) As IO.Stream
    If useIsolatedStorage Then
      Dim isf As IsolatedStorageFile
      isf = IsolatedStorageFile.GetUserStoreForAssembly()
      Dim file As New IsolatedStorageFileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None, isf)
      isf.Close()
      Return file
    Else
      Dim workingPath As String
      workingPath = IO.Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), Application.CompanyName)
      workingPath = IO.Path.Combine(workingPath, Application.ProductName)
      If Not IO.Directory.Exists(workingPath) Then
        Directory.CreateDirectory(workingPath)
      End If
      workingPath = IO.Path.Combine(workingPath, filename)
      Return New FileStream(workingPath, FileMode.Create, FileAccess.Write, FileShare.None)
    End If
  End Function

  Overloads Shared Function GetFileStreamForReading() As IO.Stream
    Return GetFileStreamForReading(DefaultFileName, DefaultUseIsolatedStorage)
  End Function

  Overloads Shared Function GetFileStreamForReading(ByVal filename As String) As IO.Stream
    Return GetFileStreamForReading(filename, DefaultUseIsolatedStorage)
  End Function

  Overloads Shared Function GetFileStreamForReading(ByVal filename As String, ByVal useIsolatedStorage As Boolean) As IO.Stream
    If useIsolatedStorage Then
      Dim isf As IO.IsolatedStorage.IsolatedStorageFile
      isf = IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForAssembly()
      Dim file As New IO.IsolatedStorage.IsolatedStorageFileStream(filename, IO.FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read, isf)
      isf.Close()
      Return file
    Else
      Dim workingPath As String
      workingPath = IO.Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), Application.CompanyName)
      workingPath = IO.Path.Combine(workingPath, Application.ProductName)
      If Not IO.Directory.Exists(workingPath) Then
        Directory.CreateDirectory(workingPath)
      End If
      workingPath = IO.Path.Combine(workingPath, filename)
      Return New IO.FileStream(workingPath, IO.FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)
      End If
  End Function

  Shared Sub Persist(ByVal settings As Settings)
    Try
      Dim outputStream As IO.Stream = GetFileStreamForWriting()
      Persist(settings, outputStream)
    Catch ex As Exception
      Dim e As New Exception("Could not save Settings", ex)
      Throw e
    End Try
  End Sub

  Shared Sub Persist(ByVal settings As Settings, ByVal outputStream As IO.Stream)
    Dim xs As New Xml.Serialization.XmlSerializer(GetType(Settings))
    xs.Serialize(outputStream, settings)
    outputStream.Close()
  End Sub

  Public Sub PersistMe()
    Settings.Persist(Me)
  End Sub

  Public Sub PersistMe(ByVal stream As IO.Stream)
    Settings.Persist(Me, stream)
  End Sub

  Shared Function Load() As Settings
    Try
      Dim inputStream As IO.Stream = GetFileStreamForReading()
      Return Load(inputStream)
    Catch ex As Exception
      Dim e As New Exception("Could not load Settings", ex)
      Throw e
    End Try
  End Function

  Shared Function Load(ByVal stream As IO.Stream) As Settings
    Dim result As Settings
    If stream.Length = 0 Then
      result = New Settings
    Else
      Dim xs As New Xml.Serialization.XmlSerializer(GetType(Settings))
      result = CType(xs.Deserialize(stream), Settings)
    End If
    stream.Close()
    Return result
  End Function

#End Region

  Public Property Location() As Point
    Get
      Return m_position
    End Get
    Set(ByVal Value As Point)
      m_position = Value
    End Set
  End Property

  Public Property Size() As Size
    Get
      Return m_size
    End Get
    Set(ByVal Value As Size)
      m_size = Value
    End Set
  End Property

  Public Property CardBack() As Integer
    Get
      Return m_cardBack
    End Get
    Set(ByVal Value As Integer)
      If Value > -1 AndAlso Value < 12 Then
        m_cardBack = Value
      Else
        Throw New ArgumentException("Invalid CardBack specified.  Valid range is 0 to 11.")
      End If
    End Set
  End Property

  Public Property DrawOne() As Boolean
    Get
      Return m_drawOne
    End Get
    Set(ByVal Value As Boolean)
      m_drawOne = Value
    End Set
  End Property

  Public Property Outline() As Boolean
    Get
      Return m_outline
    End Get
    Set(ByVal Value As Boolean)
      m_outline = Value
    End Set
  End Property

  Public Property Scoring() As Scoring
    Get
      Return m_scoring
    End Get
    Set(ByVal Value As Scoring)
      m_scoring = Value
    End Set
  End Property

  Public Property TimedGame() As Boolean
    Get
      Return m_timedGame
    End Get
    Set(ByVal Value As Boolean)
      m_timedGame = Value
    End Set
  End Property

  Public Property ViewStatusBar() As Boolean
    Get
      Return m_viewStatusBar
    End Get
    Set(ByVal Value As Boolean)
      m_viewStatusBar = Value
    End Set
  End Property

End Class
