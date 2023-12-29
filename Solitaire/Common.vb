Imports System.Environment
Imports System.IO
Imports System.IO.IsolatedStorage

Imports System.Runtime.InteropServices

Friend Class Common

  Friend Const EnhancedMode As Boolean = True

End Class

Friend Class Win32

  'Private Declare Function ShellAbout Lib "shell32.dll" Alias "ShellAboutA" (hwnd As IntPtr,
  '                                                                           szApp As String,
  '                                                                           szOtherStuff As String,
  '                                                                           hIcon As IntPtr) As Integer

  <DllImport("shell32.dll", CharSet:=CharSet.Unicode)>
  Friend Shared Function ShellAbout(hWnd As IntPtr,
                                    szApp As String,
                                    szOtherStuff As String,
                                    hIcon As IntPtr) As Integer
  End Function

End Class

Friend Enum Draw
  One
  Three
End Enum

Friend Enum CardSuit
  Spades
  Diamonds
  Clubs
  Hearts
End Enum

Public Enum Scoring
  None
  Standard
  Vegas
  VegasCumulative
End Enum

Public Class Settings

  Private Const DEFAULT_FILENAME As String = "settings.xml"
  Private Const DEFAULT_USE_ISOLATED_STORAGE As Boolean = False

  Private m_cardBack As Integer = 3 ' Index of picture to use for deck back.

#Region "Loading and Saving"

  Overloads Shared Function GetFileStreamForWriting() As Stream
    Return GetFileStreamForWriting(DEFAULT_FILENAME, DEFAULT_USE_ISOLATED_STORAGE)
  End Function

  Overloads Shared Function GetFileStreamForWriting(filename As String) As Stream
    Return GetFileStreamForWriting(filename, DEFAULT_USE_ISOLATED_STORAGE)
  End Function

  Overloads Shared Function GetFileStreamForWriting(filename As String, useIsolatedStorage As Boolean) As Stream
    If useIsolatedStorage Then
      Using isf = IsolatedStorageFile.GetUserStoreForAssembly()
        Try
          Return New IsolatedStorageFileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None, isf)
        Finally
          isf.Close()
        End Try
      End Using
    Else
      Dim workingPath = Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), Application.CompanyName)
      workingPath = Path.Combine(workingPath, Application.ProductName)
      If Not Directory.Exists(workingPath) Then Directory.CreateDirectory(workingPath)
      workingPath = IO.Path.Combine(workingPath, filename)
      Return New FileStream(workingPath, FileMode.Create, FileAccess.Write, FileShare.None)
    End If
  End Function

  Overloads Shared Function GetFileStreamForReading() As Stream
    Return GetFileStreamForReading(DEFAULT_FILENAME, DEFAULT_USE_ISOLATED_STORAGE)
  End Function

  Overloads Shared Function GetFileStreamForReading(filename As String) As Stream
    Return GetFileStreamForReading(filename, DEFAULT_USE_ISOLATED_STORAGE)
  End Function

  Overloads Shared Function GetFileStreamForReading(filename As String, useIsolatedStorage As Boolean) As Stream
    If useIsolatedStorage Then
      Using isf = IsolatedStorageFile.GetUserStoreForAssembly()
        Try
          Return New IsolatedStorageFileStream(filename, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read, isf)
        Finally
          isf.Close()
        End Try
      End Using
    Else
      Dim workingPath = Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), Application.CompanyName)
      workingPath = Path.Combine(workingPath, Application.ProductName)
      If Not Directory.Exists(workingPath) Then Directory.CreateDirectory(workingPath)
      workingPath = Path.Combine(workingPath, filename)
      Return New FileStream(workingPath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)
    End If
  End Function

  Shared Sub Persist(settings As Settings)
    Try
      Dim outputStream = GetFileStreamForWriting()
      Persist(settings, outputStream)
    Catch ex As Exception
      Throw New Exception("Could not save Settings", ex)
    End Try
  End Sub

  Shared Sub Persist(settings As Settings, outputStream As Stream)
    Try
      Dim xs = New Xml.Serialization.XmlSerializer(GetType(Settings))
      xs.Serialize(outputStream, settings)
    Finally
      outputStream.Close()
    End Try
  End Sub

  Public Sub PersistMe()
    Settings.Persist(Me)
  End Sub

  Public Sub PersistMe(stream As Stream)
    Settings.Persist(Me, stream)
  End Sub

  Shared Function Load() As Settings
    Try
      Dim inputStream = GetFileStreamForReading()
      Return Load(inputStream)
    Catch ex As Exception
      Throw New Exception("Could not load Settings", ex)
    End Try
  End Function

  Shared Function Load(stream As Stream) As Settings
    Dim result As Settings
    Try
      If stream.Length = 0 Then
        result = New Settings
      Else
        Dim xs = New Xml.Serialization.XmlSerializer(GetType(Settings))
        result = CType(xs.Deserialize(stream), Settings)
      End If
    Finally
      stream.Close()
    End Try
    Return result
  End Function

#End Region

  ''' <summary>
  ''' Location of the main window.
  ''' </summary>
  ''' <returns></returns>
  Public Property Location() As Point

  ''' <summary>
  ''' Size of the main window.
  ''' </summary>
  ''' <returns></returns>
  Public Property Size() As Size

  Public Property CardBack() As Integer
    Get
      Return m_cardBack
    End Get
    Set(value As Integer)
      If value > -1 AndAlso value < 12 Then
        m_cardBack = value
      Else
        Throw New ArgumentException("Invalid CardBack specified.  Valid range is 0 to 11.")
      End If
    End Set
  End Property

  ''' <summary>
  ''' True when drawing one card not 3.
  ''' </summary>
  ''' <returns></returns>
  Public Property DrawOne() As Boolean = False

  ''' <summary>
  ''' True when outline dragging.
  ''' </summary>
  ''' <returns></returns>
  Public Property Outline() As Boolean = False

  ''' <summary>
  ''' None, standard, vegas or vegas cumulative.
  ''' </summary>
  ''' <returns></returns>
  Public Property Scoring() As Scoring = Scoring.Standard

  ''' <summary>
  ''' True if game is timed.
  ''' </summary>
  ''' <returns></returns>
  Public Property TimedGame() As Boolean = True

  ''' <summary>
  ''' True if the status bar is visible.
  ''' </summary>
  ''' <returns></returns>
  Public Property ViewStatusBar() As Boolean = True

End Class