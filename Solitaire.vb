Option Explicit On 
Option Strict On

Public Enum Draw
  One
  Three
End Enum

Public Enum CardSuit
  Spades
  Diamonds
  Clubs
  Hearts
End Enum

Public Class Solitaire
  Inherits System.Windows.Forms.Form

#Region "Interop"
  Private Declare Function ShellAbout Lib "shell32.dll" Alias "ShellAboutA" (ByVal hwnd As IntPtr, ByVal szApp As String, ByVal szOtherStuff As String, ByVal hIcon As IntPtr) As Integer
#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call.

    Startup()

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer.
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents StackPictureBox_0 As System.Windows.Forms.PictureBox
  Friend WithEvents StackPictureBox_1 As System.Windows.Forms.PictureBox
  Friend WithEvents StackPictureBox_2 As System.Windows.Forms.PictureBox
  Friend WithEvents MenuGame As System.Windows.Forms.MenuItem
  Friend WithEvents MenuGameDeal As System.Windows.Forms.MenuItem
  Friend WithEvents MenuGameSeparater1 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuGameUndo As System.Windows.Forms.MenuItem
  Friend WithEvents MenuGameDeck As System.Windows.Forms.MenuItem
  Friend WithEvents MenuGameOptions As System.Windows.Forms.MenuItem
  Friend WithEvents menuItem1 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuGameWin As System.Windows.Forms.MenuItem
  Friend WithEvents MenuGameSeparator2 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuGameExit As System.Windows.Forms.MenuItem
  Friend WithEvents MenuHelp As System.Windows.Forms.MenuItem
  Friend WithEvents MenuHelpContents As System.Windows.Forms.MenuItem
  Friend WithEvents MenuHelpSearch As System.Windows.Forms.MenuItem
  Friend WithEvents MenuHelpHowto As System.Windows.Forms.MenuItem
  Friend WithEvents MenuHelpSeparator As System.Windows.Forms.MenuItem
  Friend WithEvents MenuHelpAbout As System.Windows.Forms.MenuItem
  Friend WithEvents StackPictureBox_4 As System.Windows.Forms.PictureBox
  Friend WithEvents StackPictureBox_5 As System.Windows.Forms.PictureBox
  Friend WithEvents StackPictureBox_6 As System.Windows.Forms.PictureBox
  Friend WithEvents AcePictureBox_0 As System.Windows.Forms.PictureBox
  Friend WithEvents AcePictureBox_1 As System.Windows.Forms.PictureBox
  Friend WithEvents DeckToDealPictureBox As System.Windows.Forms.PictureBox
  Friend WithEvents AcePictureBox_2 As System.Windows.Forms.PictureBox
  Friend WithEvents AcePictureBox_3 As System.Windows.Forms.PictureBox
  Friend WithEvents StackPictureBox_3 As System.Windows.Forms.PictureBox
  Friend WithEvents DropPanelPictureBox As System.Windows.Forms.PictureBox
  Friend WithEvents GameTimer As System.Windows.Forms.Timer
  Friend WithEvents DragBoxPictureBox_1 As System.Windows.Forms.PictureBox
  Friend WithEvents DragBoxPictureBox_2 As System.Windows.Forms.PictureBox
  Friend WithEvents DragBoxPictureBox_3 As System.Windows.Forms.PictureBox
  Friend WithEvents DragBoxPictureBox_4 As System.Windows.Forms.PictureBox
  Friend WithEvents GameStatusBar As System.Windows.Forms.StatusBar
  Friend WithEvents GameStatusBarPanel As System.Windows.Forms.StatusBarPanel
  Friend WithEvents GameMainMenu As System.Windows.Forms.MainMenu
  Friend WithEvents ClubsImageList As System.Windows.Forms.ImageList
  Friend WithEvents DiamondsImageList As System.Windows.Forms.ImageList
  Friend WithEvents SpadesImageList As System.Windows.Forms.ImageList
  Friend WithEvents CardBacksImageList As System.Windows.Forms.ImageList
  Friend WithEvents HeartsImageList As System.Windows.Forms.ImageList
  Friend WithEvents CardSlotsImageList As System.Windows.Forms.ImageList
  Friend WithEvents AceSpadesImageList As System.Windows.Forms.ImageList
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Solitaire))
    Me.StackPictureBox_0 = New System.Windows.Forms.PictureBox
    Me.StackPictureBox_1 = New System.Windows.Forms.PictureBox
    Me.StackPictureBox_2 = New System.Windows.Forms.PictureBox
    Me.GameMainMenu = New System.Windows.Forms.MainMenu
    Me.MenuGame = New System.Windows.Forms.MenuItem
    Me.MenuGameDeal = New System.Windows.Forms.MenuItem
    Me.MenuGameSeparater1 = New System.Windows.Forms.MenuItem
    Me.MenuGameUndo = New System.Windows.Forms.MenuItem
    Me.MenuGameDeck = New System.Windows.Forms.MenuItem
    Me.MenuGameOptions = New System.Windows.Forms.MenuItem
    Me.menuItem1 = New System.Windows.Forms.MenuItem
    Me.MenuGameWin = New System.Windows.Forms.MenuItem
    Me.MenuGameSeparator2 = New System.Windows.Forms.MenuItem
    Me.MenuGameExit = New System.Windows.Forms.MenuItem
    Me.MenuHelp = New System.Windows.Forms.MenuItem
    Me.MenuHelpContents = New System.Windows.Forms.MenuItem
    Me.MenuHelpSearch = New System.Windows.Forms.MenuItem
    Me.MenuHelpHowto = New System.Windows.Forms.MenuItem
    Me.MenuHelpSeparator = New System.Windows.Forms.MenuItem
    Me.MenuHelpAbout = New System.Windows.Forms.MenuItem
    Me.StackPictureBox_4 = New System.Windows.Forms.PictureBox
    Me.StackPictureBox_5 = New System.Windows.Forms.PictureBox
    Me.StackPictureBox_6 = New System.Windows.Forms.PictureBox
    Me.AcePictureBox_0 = New System.Windows.Forms.PictureBox
    Me.AcePictureBox_1 = New System.Windows.Forms.PictureBox
    Me.DeckToDealPictureBox = New System.Windows.Forms.PictureBox
    Me.ClubsImageList = New System.Windows.Forms.ImageList(Me.components)
    Me.AcePictureBox_2 = New System.Windows.Forms.PictureBox
    Me.AcePictureBox_3 = New System.Windows.Forms.PictureBox
    Me.StackPictureBox_3 = New System.Windows.Forms.PictureBox
    Me.DropPanelPictureBox = New System.Windows.Forms.PictureBox
    Me.GameTimer = New System.Windows.Forms.Timer(Me.components)
    Me.DragBoxPictureBox_1 = New System.Windows.Forms.PictureBox
    Me.DiamondsImageList = New System.Windows.Forms.ImageList(Me.components)
    Me.DragBoxPictureBox_2 = New System.Windows.Forms.PictureBox
    Me.DragBoxPictureBox_3 = New System.Windows.Forms.PictureBox
    Me.DragBoxPictureBox_4 = New System.Windows.Forms.PictureBox
    Me.SpadesImageList = New System.Windows.Forms.ImageList(Me.components)
    Me.CardBacksImageList = New System.Windows.Forms.ImageList(Me.components)
    Me.HeartsImageList = New System.Windows.Forms.ImageList(Me.components)
    Me.CardSlotsImageList = New System.Windows.Forms.ImageList(Me.components)
    Me.AceSpadesImageList = New System.Windows.Forms.ImageList(Me.components)
    Me.GameStatusBarPanel = New System.Windows.Forms.StatusBarPanel
    Me.GameStatusBar = New System.Windows.Forms.StatusBar
    CType(Me.GameStatusBarPanel, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'StackPictureBox_0
    '
    Me.StackPictureBox_0.Location = New System.Drawing.Point(11, 107)
    Me.StackPictureBox_0.Name = "StackPictureBox_0"
    Me.StackPictureBox_0.Size = New System.Drawing.Size(71, 96)
    Me.StackPictureBox_0.TabIndex = 7
    Me.StackPictureBox_0.TabStop = False
    '
    'StackPictureBox_1
    '
    Me.StackPictureBox_1.Location = New System.Drawing.Point(93, 107)
    Me.StackPictureBox_1.Name = "StackPictureBox_1"
    Me.StackPictureBox_1.Size = New System.Drawing.Size(71, 99)
    Me.StackPictureBox_1.TabIndex = 8
    Me.StackPictureBox_1.TabStop = False
    '
    'StackPictureBox_2
    '
    Me.StackPictureBox_2.Location = New System.Drawing.Point(175, 107)
    Me.StackPictureBox_2.Name = "StackPictureBox_2"
    Me.StackPictureBox_2.Size = New System.Drawing.Size(71, 102)
    Me.StackPictureBox_2.TabIndex = 9
    Me.StackPictureBox_2.TabStop = False
    '
    'GameMainMenu
    '
    Me.GameMainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuGame, Me.MenuHelp})
    '
    'MenuGame
    '
    Me.MenuGame.Index = 0
    Me.MenuGame.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuGameDeal, Me.MenuGameSeparater1, Me.MenuGameUndo, Me.MenuGameDeck, Me.MenuGameOptions, Me.menuItem1, Me.MenuGameWin, Me.MenuGameSeparator2, Me.MenuGameExit})
    Me.MenuGame.Text = "Game"
    '
    'MenuGameDeal
    '
    Me.MenuGameDeal.Index = 0
    Me.MenuGameDeal.Shortcut = System.Windows.Forms.Shortcut.F2
    Me.MenuGameDeal.Text = "&Deal"
    '
    'MenuGameSeparater1
    '
    Me.MenuGameSeparater1.Index = 1
    Me.MenuGameSeparater1.Text = "-"
    '
    'MenuGameUndo
    '
    Me.MenuGameUndo.Index = 2
    Me.MenuGameUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
    Me.MenuGameUndo.Text = "&Undo"
    '
    'MenuGameDeck
    '
    Me.MenuGameDeck.Index = 3
    Me.MenuGameDeck.Text = "De&ck..."
    '
    'MenuGameOptions
    '
    Me.MenuGameOptions.Index = 4
    Me.MenuGameOptions.Text = "&Options..."
    '
    'menuItem1
    '
    Me.menuItem1.Index = 5
    Me.menuItem1.Shortcut = System.Windows.Forms.Shortcut.CtrlA
    Me.menuItem1.Text = "ALL"
    Me.menuItem1.Visible = False
    '
    'MenuGameWin
    '
    Me.MenuGameWin.Index = 6
    Me.MenuGameWin.Shortcut = System.Windows.Forms.Shortcut.CtrlShift2
    Me.MenuGameWin.Text = "WIN"
    Me.MenuGameWin.Visible = False
    '
    'MenuGameSeparator2
    '
    Me.MenuGameSeparator2.Index = 7
    Me.MenuGameSeparator2.Text = "-"
    '
    'MenuGameExit
    '
    Me.MenuGameExit.Index = 8
    Me.MenuGameExit.Text = "E&xit"
    '
    'MenuHelp
    '
    Me.MenuHelp.Index = 1
    Me.MenuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuHelpContents, Me.MenuHelpSearch, Me.MenuHelpHowto, Me.MenuHelpSeparator, Me.MenuHelpAbout})
    Me.MenuHelp.Text = "Help"
    '
    'MenuHelpContents
    '
    Me.MenuHelpContents.Index = 0
    Me.MenuHelpContents.Shortcut = System.Windows.Forms.Shortcut.F1
    Me.MenuHelpContents.Text = "&Contents"
    '
    'MenuHelpSearch
    '
    Me.MenuHelpSearch.Index = 1
    Me.MenuHelpSearch.Text = "&Search for Help on..."
    '
    'MenuHelpHowto
    '
    Me.MenuHelpHowto.Index = 2
    Me.MenuHelpHowto.Text = "&How to Use Help"
    '
    'MenuHelpSeparator
    '
    Me.MenuHelpSeparator.Index = 3
    Me.MenuHelpSeparator.Text = "-"
    '
    'MenuHelpAbout
    '
    Me.MenuHelpAbout.Index = 4
    Me.MenuHelpAbout.Text = "&About Solitaire"
    '
    'StackPictureBox_4
    '
    Me.StackPictureBox_4.Location = New System.Drawing.Point(339, 107)
    Me.StackPictureBox_4.Name = "StackPictureBox_4"
    Me.StackPictureBox_4.Size = New System.Drawing.Size(71, 108)
    Me.StackPictureBox_4.TabIndex = 11
    Me.StackPictureBox_4.TabStop = False
    '
    'StackPictureBox_5
    '
    Me.StackPictureBox_5.Location = New System.Drawing.Point(421, 107)
    Me.StackPictureBox_5.Name = "StackPictureBox_5"
    Me.StackPictureBox_5.Size = New System.Drawing.Size(71, 111)
    Me.StackPictureBox_5.TabIndex = 12
    Me.StackPictureBox_5.TabStop = False
    '
    'StackPictureBox_6
    '
    Me.StackPictureBox_6.Location = New System.Drawing.Point(503, 107)
    Me.StackPictureBox_6.Name = "StackPictureBox_6"
    Me.StackPictureBox_6.Size = New System.Drawing.Size(71, 114)
    Me.StackPictureBox_6.TabIndex = 13
    Me.StackPictureBox_6.TabStop = False
    '
    'AcePictureBox_0
    '
    Me.AcePictureBox_0.BackColor = System.Drawing.Color.Transparent
    Me.AcePictureBox_0.Location = New System.Drawing.Point(257, 5)
    Me.AcePictureBox_0.Name = "AcePictureBox_0"
    Me.AcePictureBox_0.Size = New System.Drawing.Size(72, 96)
    Me.AcePictureBox_0.TabIndex = 3
    Me.AcePictureBox_0.TabStop = False
    '
    'AcePictureBox_1
    '
    Me.AcePictureBox_1.BackColor = System.Drawing.Color.Transparent
    Me.AcePictureBox_1.Location = New System.Drawing.Point(339, 5)
    Me.AcePictureBox_1.Name = "AcePictureBox_1"
    Me.AcePictureBox_1.Size = New System.Drawing.Size(72, 96)
    Me.AcePictureBox_1.TabIndex = 4
    Me.AcePictureBox_1.TabStop = False
    '
    'DeckToDealPictureBox
    '
    Me.DeckToDealPictureBox.BackColor = System.Drawing.Color.Green
    Me.DeckToDealPictureBox.Location = New System.Drawing.Point(11, 5)
    Me.DeckToDealPictureBox.Name = "DeckToDealPictureBox"
    Me.DeckToDealPictureBox.Size = New System.Drawing.Size(80, 99)
    Me.DeckToDealPictureBox.TabIndex = 1
    Me.DeckToDealPictureBox.TabStop = False
    '
    'ClubsImageList
    '
    Me.ClubsImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
    Me.ClubsImageList.ImageSize = New System.Drawing.Size(71, 96)
    Me.ClubsImageList.ImageStream = CType(resources.GetObject("ClubsImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ClubsImageList.TransparentColor = System.Drawing.Color.Fuchsia
    '
    'AcePictureBox_2
    '
    Me.AcePictureBox_2.BackColor = System.Drawing.Color.Transparent
    Me.AcePictureBox_2.Location = New System.Drawing.Point(421, 5)
    Me.AcePictureBox_2.Name = "AcePictureBox_2"
    Me.AcePictureBox_2.Size = New System.Drawing.Size(72, 96)
    Me.AcePictureBox_2.TabIndex = 5
    Me.AcePictureBox_2.TabStop = False
    '
    'AcePictureBox_3
    '
    Me.AcePictureBox_3.BackColor = System.Drawing.Color.Transparent
    Me.AcePictureBox_3.Location = New System.Drawing.Point(503, 5)
    Me.AcePictureBox_3.Name = "AcePictureBox_3"
    Me.AcePictureBox_3.Size = New System.Drawing.Size(72, 96)
    Me.AcePictureBox_3.TabIndex = 6
    Me.AcePictureBox_3.TabStop = False
    '
    'StackPictureBox_3
    '
    Me.StackPictureBox_3.BackColor = System.Drawing.Color.Transparent
    Me.StackPictureBox_3.Location = New System.Drawing.Point(257, 107)
    Me.StackPictureBox_3.Name = "StackPictureBox_3"
    Me.StackPictureBox_3.Size = New System.Drawing.Size(71, 105)
    Me.StackPictureBox_3.TabIndex = 10
    Me.StackPictureBox_3.TabStop = False
    '
    'DropPanelPictureBox
    '
    Me.DropPanelPictureBox.AllowDrop = True
    Me.DropPanelPictureBox.BackColor = System.Drawing.Color.Green
    Me.DropPanelPictureBox.Location = New System.Drawing.Point(93, 5)
    Me.DropPanelPictureBox.Name = "DropPanelPictureBox"
    Me.DropPanelPictureBox.Size = New System.Drawing.Size(104, 99)
    Me.DropPanelPictureBox.TabIndex = 17
    Me.DropPanelPictureBox.TabStop = False
    '
    'GameTimer
    '
    Me.GameTimer.Enabled = True
    Me.GameTimer.Interval = 1000
    '
    'DragBoxPictureBox_1
    '
    Me.DragBoxPictureBox_1.BackColor = System.Drawing.Color.Gray
    Me.DragBoxPictureBox_1.Location = New System.Drawing.Point(0, 0)
    Me.DragBoxPictureBox_1.Name = "DragBoxPictureBox_1"
    Me.DragBoxPictureBox_1.Size = New System.Drawing.Size(0, 0)
    Me.DragBoxPictureBox_1.TabIndex = 14
    Me.DragBoxPictureBox_1.TabStop = False
    '
    'DiamondsImageList
    '
    Me.DiamondsImageList.ImageSize = New System.Drawing.Size(71, 96)
    Me.DiamondsImageList.ImageStream = CType(resources.GetObject("DiamondsImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.DiamondsImageList.TransparentColor = System.Drawing.Color.Blue
    '
    'DragBoxPictureBox_2
    '
    Me.DragBoxPictureBox_2.BackColor = System.Drawing.Color.Gray
    Me.DragBoxPictureBox_2.Location = New System.Drawing.Point(0, 0)
    Me.DragBoxPictureBox_2.Name = "DragBoxPictureBox_2"
    Me.DragBoxPictureBox_2.Size = New System.Drawing.Size(0, 0)
    Me.DragBoxPictureBox_2.TabIndex = 14
    Me.DragBoxPictureBox_2.TabStop = False
    '
    'DragBoxPictureBox_3
    '
    Me.DragBoxPictureBox_3.BackColor = System.Drawing.Color.Gray
    Me.DragBoxPictureBox_3.Location = New System.Drawing.Point(0, 0)
    Me.DragBoxPictureBox_3.Name = "DragBoxPictureBox_3"
    Me.DragBoxPictureBox_3.Size = New System.Drawing.Size(0, 0)
    Me.DragBoxPictureBox_3.TabIndex = 14
    Me.DragBoxPictureBox_3.TabStop = False
    '
    'DragBoxPictureBox_4
    '
    Me.DragBoxPictureBox_4.BackColor = System.Drawing.Color.Gray
    Me.DragBoxPictureBox_4.Location = New System.Drawing.Point(0, 0)
    Me.DragBoxPictureBox_4.Name = "DragBoxPictureBox_4"
    Me.DragBoxPictureBox_4.Size = New System.Drawing.Size(0, 0)
    Me.DragBoxPictureBox_4.TabIndex = 14
    Me.DragBoxPictureBox_4.TabStop = False
    '
    'SpadesImageList
    '
    Me.SpadesImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
    Me.SpadesImageList.ImageSize = New System.Drawing.Size(71, 96)
    Me.SpadesImageList.ImageStream = CType(resources.GetObject("SpadesImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.SpadesImageList.TransparentColor = System.Drawing.Color.Fuchsia
    '
    'CardBacksImageList
    '
    Me.CardBacksImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
    Me.CardBacksImageList.ImageSize = New System.Drawing.Size(71, 96)
    Me.CardBacksImageList.ImageStream = CType(resources.GetObject("CardBacksImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.CardBacksImageList.TransparentColor = System.Drawing.Color.Fuchsia
    '
    'HeartsImageList
    '
    Me.HeartsImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
    Me.HeartsImageList.ImageSize = New System.Drawing.Size(71, 96)
    Me.HeartsImageList.ImageStream = CType(resources.GetObject("HeartsImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.HeartsImageList.TransparentColor = System.Drawing.Color.Blue
    '
    'CardSlotsImageList
    '
    Me.CardSlotsImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
    Me.CardSlotsImageList.ImageSize = New System.Drawing.Size(72, 96)
    Me.CardSlotsImageList.ImageStream = CType(resources.GetObject("CardSlotsImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.CardSlotsImageList.TransparentColor = System.Drawing.Color.Transparent
    '
    'AceSpadesImageList
    '
    Me.AceSpadesImageList.ImageSize = New System.Drawing.Size(72, 96)
    Me.AceSpadesImageList.ImageStream = CType(resources.GetObject("AceSpadesImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.AceSpadesImageList.TransparentColor = System.Drawing.Color.Transparent
    '
    'GameStatusBarPanel
    '
    Me.GameStatusBarPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
    Me.GameStatusBarPanel.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None
    Me.GameStatusBarPanel.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
    Me.GameStatusBarPanel.Width = 584
    '
    'GameStatusBar
    '
    Me.GameStatusBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GameStatusBar.Location = New System.Drawing.Point(0, 421)
    Me.GameStatusBar.Name = "GameStatusBar"
    Me.GameStatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.GameStatusBarPanel})
    Me.GameStatusBar.ShowPanels = True
    Me.GameStatusBar.Size = New System.Drawing.Size(584, 17)
    Me.GameStatusBar.SizingGrip = False
    Me.GameStatusBar.TabIndex = 15
    '
    'Solitaire
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.BackColor = System.Drawing.Color.Green
    Me.ClientSize = New System.Drawing.Size(584, 438)
    Me.Controls.Add(Me.DragBoxPictureBox_4)
    Me.Controls.Add(Me.DragBoxPictureBox_3)
    Me.Controls.Add(Me.DragBoxPictureBox_2)
    Me.Controls.Add(Me.DragBoxPictureBox_1)
    Me.Controls.Add(Me.GameStatusBar)
    Me.Controls.Add(Me.StackPictureBox_6)
    Me.Controls.Add(Me.StackPictureBox_5)
    Me.Controls.Add(Me.StackPictureBox_4)
    Me.Controls.Add(Me.StackPictureBox_3)
    Me.Controls.Add(Me.StackPictureBox_2)
    Me.Controls.Add(Me.StackPictureBox_1)
    Me.Controls.Add(Me.StackPictureBox_0)
    Me.Controls.Add(Me.AcePictureBox_3)
    Me.Controls.Add(Me.AcePictureBox_2)
    Me.Controls.Add(Me.AcePictureBox_1)
    Me.Controls.Add(Me.AcePictureBox_0)
    Me.Controls.Add(Me.DropPanelPictureBox)
    Me.Controls.Add(Me.DeckToDealPictureBox)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Menu = Me.GameMainMenu
    Me.MinimumSize = New System.Drawing.Size(592, 472)
    Me.Name = "Solitaire"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "Solitaire"
    CType(Me.GameStatusBarPanel, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "Member Variables"

  Private m_mouseX As Integer ' Current x position of mouse.
  Private m_mouseY As Integer ' Current y position of mouse.
  Private m_stacks As Array = Array.CreateInstance(GetType(Int32), 7, 5, 19) ' Stack array, (stack)(suit, card value, x, y, flipped)(index).
  Private m_deck As Array = Array.CreateInstance(GetType(Int32), 2, 24) ' Deck array, (suit, card value)(index).
  Private m_drop As Array = Array.CreateInstance(GetType(Int32), 4, 24) ' Drop array, (suit, card value, x, y)(index).
  Private m_drag As Array = Array.CreateInstance(GetType(Int32), 3, 13) ' Drag array, (suit, card value, y)(index).
  Private m_aceStacks As Array = Array.CreateInstance(GetType(Int32), 4, 2, 13) ' Ace drop array, (stack)(suit, card value)(index).
  Private m_stackLengths(6) As Integer ' Length of stack (one greater than last used index).
  Private m_deckLength As Integer = 0 ' Cards in dealing deck, -1 when flipping over deck.
  Private m_dropLength As Integer = 0 ' Cards in dropping deck.
  Private m_dragLength As Integer = 0 ' Cards in drag/drop action.
  Private m_aceStackLengths(3) As Integer ' Cards in each ace drop.
  Private m_random As New Random   ' Random number generator to shuffle deck.
  Private m_drawing As Boolean = False ' True when in process of drawing m_winParabola card from deck.
  Private m_hitCard As Integer ' Card that the mouse was over when dragging, needed for multiple card drag.
  Private m_dragStack As Integer ' Stack dragging cards were originally from: m_stacks < 7; DropPanelPictureBox = 7; aces>7.
  Private m_dragging As Boolean = False ' True when drag/drop in process.
  Private m_cycleDeck As Integer = 1 ' Number of times player has flipped the deck.
  Private m_win As Boolean = False ' False until user wins game.
  Private m_winStack As Integer = 0 ' Current stack during win effect.
  Private m_winCard As Integer = 12 ' Current card during win effect.
  Private m_winX As Integer ' X location of card during win effect.
  Private m_winY As Integer ' Y location of card during win effect.
  Private m_yMultiplier As Single = 0 ' Multiply Y intercept by this ratio during win effect.
  Private m_xMovement As Integer = 0 ' XShift on the win effect.
  Private m_xVertex As Integer = 0 ' Horizontal vertex value of current win parabola.
  Private m_yVertex As Integer = 0 ' Vertical vertex value of current win parabola.
  Private m_winParabola As Single = 0 ' Value of win parabola (y = ax ^ 2 + bx + c).
  Private m_newWinStack As Boolean = True ' True when new stack when displaying win effect.
  Private m_bounce As Boolean = False ' True if in same stack but bouncing, win effect.
  Private m_win2 As Boolean = False ' False until drag panel is set up for win effect.
  Private m_suit(3) As Integer ' Suits: spades=0, diamonds=1, clubs=2, hearts=3.
  Private m_aceLocation As Array = Array.CreateInstance(GetType(Integer), 2, 4) ' X, Y and suit for ace drops.
  Private m_undoType As Integer = 0 ' Undo type for switch and to get info from undo array.
  Private m_undo As Array = Array.CreateInstance(GetType(Integer), 7, 3) ' Keeps undo information, (type)(data).
  Private m_dragStartY As Integer = 0 ' The y to drop the card at, used for refresh problems.
  Private m_dragStartX As Integer = 0 ' The x to drop the card at, used for refresh problems.
  Private m_score As Integer = 0 ' Score if keeping score.
  Private m_time As Integer = 0 ' Time if keeping time.

#End Region

#Region "User Settings"

  Private m_settings As Settings

  'Private m_cardBack As Integer = 3 ' Index of picture to use for deck back.
  'Private m_drawOne As Boolean = True ' True when drawing one card not 3.
  'Private m_outline As Boolean = False ' True when outline dragging.
  'Private m_scoring As Scoring = Scoring.Standard ' None, standard, vegas or vegas cumulative.
  'Private m_timedGame As Boolean = True ' True if game is timed.
  'Private m_viewStatusBar As Boolean = True ' True if the status bar is visible.

#End Region

#Region "Graphical Layout Constants"

  Private m_xShift As Integer = 2 ' X shift for DropPanelPictureBox and DeckToDealPictureBox when m_drawOne = True.
  Private m_yShift As Integer = 1 ' Y shift for DropPanelPictureBox and DeckToDealPictureBox.
  Private m_xBigShift As Integer = 15 ' DropPanelPictureBox X shift when m_drawOne = False.
  Private m_small As Integer = 3 ' Unflipped card Y shift.
  Private m_large As Integer = 15 ' Flipped card Y shift.
  Private m_cardHeight As Integer = 96
  Private m_cardWidth As Integer = 71 ' Card width, must corespond to bmp or png width.

#End Region

  <STAThread()> _
  Shared Sub Main()
    Application.EnableVisualStyles()
    Application.DoEvents()
    Application.Run(New Solitaire)
  End Sub

  Private Const EnhancedMode As Boolean = True

  Private Sub Startup()

    m_settings = Settings.Load()

    If EnhancedMode Then
      If Not m_settings.Location.Equals(Location.Empty) AndAlso Not m_settings.Size.Equals(Size.Empty) Then
        Me.Location = m_settings.Location
        'HACK: shorten the size by 20, somehow we are growing in height.
        Dim size As New Size(m_settings.Size.Width, m_settings.Size.Height - 20)
        Me.Size = size
      Else
        'TODO: should probably validate that the coordinates are visible on the screen.
        Dim x As Integer = (Screen.PrimaryScreen.WorkingArea.Width - Me.Size.Width) \ 2
        Dim y As Integer = (Screen.PrimaryScreen.WorkingArea.Height - Me.Size.Height) \ 2
        Me.Location = New Point(x, y)
      End If
    Else
      Me.StartPosition = FormStartPosition.WindowsDefaultLocation
      Me.MinimumSize = New Size(0, 0)
    End If

    ' Deal Cards.
    Deal()

    ' Redo layout.
    WindowSizeChanged(Nothing, Nothing)

    ' Check user settings.
    UpdateStatus()

    ' Set drag panel.
    DragBoxPictureBox_1.BringToFront()
    DragBoxPictureBox_2.BringToFront()
    DragBoxPictureBox_3.BringToFront()
    DragBoxPictureBox_4.BringToFront()

  End Sub

  Private Sub GameTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GameTimer.Tick
    m_time += 1
    If m_time Mod 10 = 0 Then
      m_score -= 2
    End If
    UpdateStatus()
  End Sub

#Region "Dealing/Shuffling Methods"

  Public Sub Deal()

    ' Temporary array for picking out cards (pseudoshuffle).
    Dim cards As Array = Array.CreateInstance(GetType(Int32), 4, 13)
    Dim suitCard As New Point(0, 0)
    m_cycleDeck = 0

    ' Update options.
    UpdateStatus()

    ' Initialize cards.
    For i As Integer = 0 To 3
      For j As Integer = 0 To 12
        cards.SetValue(0, i, j)
      Next
    Next

    ' Initialize aces.
    For i As Integer = 0 To 3
      m_aceStackLengths(i) = 0
    Next

    ' Clear stacks.
    For i As Integer = 0 To 6
      For j As Integer = 0 To 4
        For k As Integer = 0 To 18
          m_stacks.SetValue(0, i, j, k)
        Next
      Next
    Next

    ' Clear deck.
    For i As Integer = 0 To 23
      m_deck.SetValue(0, 0, i)
      m_deck.SetValue(0, 1, i)
    Next

    ' Clear drop.
    For i As Integer = 0 To 23
      m_drop.SetValue(0, 0, i)
      m_drop.SetValue(0, 1, i)
    Next
    m_dropLength = 0

    ' Reset DragBox.
    DragBoxPictureBox_1.Size = New System.Drawing.Size(1, 1)
    DragBoxPictureBox_1.Location = New System.Drawing.Point(0, 0)

    For i As Integer = 0 To 6 ' Stack.
      Dim y As Integer = 0
      ' Darddepth up to stack #.
      For j As Integer = 0 To i - 1
        suitCard = NextCard(cards)
        ' Stack, suit, cardvalue, x, y, flipped, index.
        SetCard(i, suitCard.X, suitCard.Y, 0, y, 0, j)
        y += m_small
      Next
      ' Last card is flipped up.
      suitCard = NextCard(cards)
      ' Stack, suit, cardvalue, x, y, flipped, index=stack.
      SetCard(i, suitCard.X, suitCard.Y, 0, y, 1, i)
    Next

    ' Set deck.
    Dim kk As Integer = 0
    For i As Integer = 0 To 3
      For j As Integer = 0 To 12
        If CInt(cards.GetValue(i, j)) = 0 Then
          cards.SetValue(1, i, j) ' Set used flag.
          m_deck.SetValue(i, 0, kk)
          m_deck.SetValue(j, 1, kk)
          kk += 1
        End If
      Next
    Next
    m_deckLength = 24

    Shuffle()

    ' Clear or set variables.
    For i As Integer = 0 To 6
      m_stackLengths(i) = i + 1
    Next
    For i As Integer = 0 To 3
      m_aceStackLengths(i) = 0
    Next
    m_cycleDeck = 1
    If m_settings.Scoring = Scoring.Standard Then
      m_score = 0
    ElseIf m_settings.Scoring = Scoring.Vegas Then
      m_score = -52
    ElseIf m_settings.Scoring = Scoring.VegasCumulative Then
      m_score += -52
    End If

    ' Timer.
    m_time = 0
    GameTimer.Stop()
    UpdateStatus()

    ' Enable undo.
    MenuGameUndo.Enabled = False

    Me.Invalidate(True)

  End Sub

  Private Function NextCard(ByVal cards As Array) As Point

    ' Get next random unused card in deck.

    Dim suit As CardSuit
    Dim cardValue As Integer

    Do
      ' Randomly select m_winParabola suit and card value.
      suit = CType(m_random.Next(4), CardSuit)
      cardValue = m_random.Next(13)
      ' Check to see if the card is already used.
      If CInt(cards.GetValue(suit, cardValue)) = 0 Then
        ' Not used, so we are done.
        Exit Do
      End If
    Loop

    'While CInt(cards.GetValue(suit, cardValue)) = 1 ' Card already used.
    '  suit = CType(m_random.Next(4), CardSuit)
    '  cardValue = m_random.Next(13)
    'End While

    cards.SetValue(1, CInt(suit), cardValue) ' Set used flag.

    Dim suitCard As New Point(CInt(suit), cardValue)

    Return suitCard

  End Function

  Private Sub SetCard(ByVal stack As Integer, ByVal suit As Integer, ByVal cardValue As Integer, ByVal x As Integer, ByVal y As Integer, ByVal flipped As Integer, ByVal index As Integer)
    m_stacks.SetValue(suit, stack, 0, index) ' Suit.
    m_stacks.SetValue(cardValue, stack, 1, index) ' Card value.
    m_stacks.SetValue(x, stack, 2, index) ' X location.
    m_stacks.SetValue(y, stack, 3, index) ' Y location.
    m_stacks.SetValue(flipped, stack, 4, index) ' Flipped.
  End Sub

  Private Sub Shuffle()

    Dim temp As Array = Array.CreateInstance(GetType(Int32), 2, 24)
    Dim templength As Integer = m_deckLength
    Dim index As Integer
    Dim j As Integer = 0

    ' Copy data to temp.
    For i As Integer = 0 To m_deckLength - 1
      temp.SetValue(CInt(m_deck.GetValue(0, i)), 0, i)
      temp.SetValue(CInt(m_deck.GetValue(1, i)), 1, i)
    Next

    For i As Integer = 0 To 23

      ' Get random index.
      index = m_random.Next(templength)

      ' Copy data at that index to deck.
      m_deck.SetValue(CInt(temp.GetValue(0, index)), 0, j)
      m_deck.SetValue(CInt(temp.GetValue(1, index)), 1, j)

      ' Increment location in deck.
      j += 1

      ' Get last set in temp and move to index.
      temp.SetValue(CInt(temp.GetValue(0, templength - 1)), 0, index)
      temp.SetValue(CInt(temp.GetValue(1, templength - 1)), 1, index)

      ' Shorten temp.
      templength -= 1

    Next

  End Sub

#End Region

#Region "Paint/Draw Methods (includes drawing new cards)"

  Private Sub WindowSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

    Dim offset As Integer

    If m_win Then
      DragBoxPictureBox_1.Width = Me.Width - 8
      DragBoxPictureBox_1.Height = Me.Height - 54
    End If

    If Me.Width > 593 Then
      offset = (Me.Width - 8 - 7 * m_cardWidth) \ 8
      DeckToDealPictureBox.Location = New System.Drawing.Point(offset, DeckToDealPictureBox.Location.Y)
      DropPanelPictureBox.Location = New System.Drawing.Point(2 * offset + m_cardWidth, DropPanelPictureBox.Location.Y)
      AcePictureBox_0.Location = New System.Drawing.Point(4 * offset + 3 * m_cardWidth, AcePictureBox_0.Location.Y)
      AcePictureBox_1.Location = New System.Drawing.Point(5 * offset + 4 * m_cardWidth, AcePictureBox_1.Location.Y)
      AcePictureBox_2.Location = New System.Drawing.Point(6 * offset + 5 * m_cardWidth, AcePictureBox_2.Location.Y)
      AcePictureBox_3.Location = New System.Drawing.Point(7 * offset + 6 * m_cardWidth, AcePictureBox_3.Location.Y)

      StackPictureBox_0.Location = New System.Drawing.Point(offset, StackPictureBox_0.Location.Y)
      StackPictureBox_1.Location = New System.Drawing.Point(2 * offset + m_cardWidth, StackPictureBox_1.Location.Y)
      StackPictureBox_2.Location = New System.Drawing.Point(3 * offset + 2 * m_cardWidth, StackPictureBox_2.Location.Y)
      StackPictureBox_3.Location = New System.Drawing.Point(4 * offset + 3 * m_cardWidth, StackPictureBox_3.Location.Y)
      StackPictureBox_4.Location = New System.Drawing.Point(5 * offset + 4 * m_cardWidth, StackPictureBox_4.Location.Y)
      StackPictureBox_5.Location = New System.Drawing.Point(6 * offset + 5 * m_cardWidth, StackPictureBox_5.Location.Y)
      StackPictureBox_6.Location = New System.Drawing.Point(7 * offset + 6 * m_cardWidth, StackPictureBox_6.Location.Y)
    Else
      offset = (593 - 8 - 7 * m_cardWidth) \ 8
      DeckToDealPictureBox.Location = New System.Drawing.Point(offset, DeckToDealPictureBox.Location.Y)
      DropPanelPictureBox.Location = New System.Drawing.Point(2 * offset + m_cardWidth, DropPanelPictureBox.Location.Y)
      AcePictureBox_0.Location = New System.Drawing.Point(4 * offset + 3 * m_cardWidth, AcePictureBox_0.Location.Y)
      AcePictureBox_1.Location = New System.Drawing.Point(5 * offset + 4 * m_cardWidth, AcePictureBox_1.Location.Y)
      AcePictureBox_2.Location = New System.Drawing.Point(6 * offset + 5 * m_cardWidth, AcePictureBox_2.Location.Y)
      AcePictureBox_3.Location = New System.Drawing.Point(7 * offset + 6 * m_cardWidth, AcePictureBox_3.Location.Y)

      StackPictureBox_0.Location = New System.Drawing.Point(offset, StackPictureBox_0.Location.Y)
      StackPictureBox_1.Location = New System.Drawing.Point(2 * offset + m_cardWidth, StackPictureBox_1.Location.Y)
      StackPictureBox_2.Location = New System.Drawing.Point(3 * offset + 2 * m_cardWidth, StackPictureBox_2.Location.Y)
      StackPictureBox_3.Location = New System.Drawing.Point(4 * offset + 3 * m_cardWidth, StackPictureBox_3.Location.Y)
      StackPictureBox_4.Location = New System.Drawing.Point(5 * offset + 4 * m_cardWidth, StackPictureBox_4.Location.Y)
      StackPictureBox_5.Location = New System.Drawing.Point(6 * offset + 5 * m_cardWidth, StackPictureBox_5.Location.Y)
      StackPictureBox_6.Location = New System.Drawing.Point(7 * offset + 6 * m_cardWidth, StackPictureBox_6.Location.Y)
    End If

  End Sub

  Private Sub DoPaint(ByVal stack As Integer, ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    Dim i As Integer = 0
    Dim suit As Integer = 0
    Dim cardvalue As Integer = 0
    Dim x As Integer = 0
    Dim y As Integer = 0
    Dim flipped As Integer = 1
    Dim index As Integer = 0
    Dim stackheight As Integer = 0

    If stack < 7 Then
      index = m_stackLengths(stack)
    Else ' Aces.
      index = m_aceStackLengths(stack - 7)
    End If

    If stack < 7 Then
      If m_stackLengths(stack) <> 0 Then
        stackheight = CInt(m_stacks.GetValue(stack, 3, m_stackLengths(stack) - 1)) + m_cardHeight
      Else
        stackheight = m_cardHeight
      End If
      ' Set stack height.
      If stack = 0 Then
        StackPictureBox_0.Height = stackheight
      ElseIf stack = 1 Then
        StackPictureBox_1.Height = stackheight
      ElseIf stack = 2 Then
        StackPictureBox_2.Height = stackheight
      ElseIf stack = 3 Then
        StackPictureBox_3.Height = stackheight
      ElseIf stack = 4 Then
        StackPictureBox_4.Height = stackheight
      ElseIf stack = 5 Then
        StackPictureBox_5.Height = stackheight
      Else ' stack = 6.
        StackPictureBox_6.Height = stackheight
      End If
    End If

    Me.SuspendLayout()

    For i = 0 To index - 1

      If stack < 7 Then
        suit = CInt(m_stacks.GetValue(stack, 0, i))
        cardvalue = CInt(m_stacks.GetValue(stack, 1, i))
        y = CInt(m_stacks.GetValue(stack, 3, i))
        flipped = CInt(m_stacks.GetValue(stack, 4, i))
      Else ' Aces.
        suit = CInt(m_aceStacks.GetValue(stack - 7, 0, i))
        cardvalue = CInt(m_aceStacks.GetValue(stack - 7, 1, i))
      End If

      If flipped = 0 Then
        e.Graphics.DrawImage(CardBacksImageList.Images(m_settings.CardBack), x, y)
      ElseIf suit = 0 Then ' Spades.
        e.Graphics.DrawImage(SpadesImageList.Images(cardvalue), x, y)
      ElseIf suit = 1 Then ' Diamonds.
        e.Graphics.DrawImage(DiamondsImageList.Images(cardvalue), x, y)
      ElseIf suit = 2 Then ' Clubs.
        e.Graphics.DrawImage(ClubsImageList.Images(cardvalue), x, y)
      Else ' Hearts.
        e.Graphics.DrawImage(HeartsImageList.Images(cardvalue), x, y)
      End If

    Next

    Me.ResumeLayout(False)

  End Sub

  Private Sub StackPictureBox_0_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles StackPictureBox_0.Paint
    DoPaint(0, sender, e)
  End Sub

  Private Sub StackPictureBox_1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles StackPictureBox_1.Paint
    DoPaint(1, sender, e)
  End Sub

  Private Sub StackPictureBox_2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles StackPictureBox_2.Paint
    DoPaint(2, sender, e)
  End Sub

  Private Sub StackPictureBox_3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles StackPictureBox_3.Paint
    DoPaint(3, sender, e)
  End Sub

  Private Sub StackPictureBox_4_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles StackPictureBox_4.Paint
    DoPaint(4, sender, e)
  End Sub

  Private Sub StackPictureBox_5_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles StackPictureBox_5.Paint
    DoPaint(5, sender, e)
  End Sub

  Private Sub StackPictureBox_6_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles StackPictureBox_6.Paint
    DoPaint(6, sender, e)
  End Sub

  Private Sub AcePictureBox_0_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles AcePictureBox_0.Paint
    If m_aceStackLengths(0) = 0 Then
      e.Graphics.DrawImage(CardSlotsImageList.Images(2), 0, 0)
    Else
      DoPaint(7, sender, e)
    End If
  End Sub

  Private Sub AcePictureBox_1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles AcePictureBox_1.Paint
    If m_aceStackLengths(1) = 0 Then
      e.Graphics.DrawImage(CardSlotsImageList.Images(2), 0, 0)
    Else
      DoPaint(8, sender, e)
    End If
  End Sub

  Private Sub AcePictureBox_2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles AcePictureBox_2.Paint
    If m_aceStackLengths(2) = 0 Then
      e.Graphics.DrawImage(CardSlotsImageList.Images(2), 0, 0)
    Else
      DoPaint(9, sender, e)
    End If
  End Sub

  Private Sub AcePictureBox_3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles AcePictureBox_3.Paint
    If m_aceStackLengths(3) = 0 Then
      e.Graphics.DrawImage(CardSlotsImageList.Images(2), 0, 0)
    Else
      DoPaint(10, sender, e)
    End If

  End Sub

  Private Sub DeckToDealPictureBox_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DeckToDealPictureBox.Paint
    Me.SuspendLayout()
    If m_deckLength < 0 OrElse (m_deckLength = 0 AndAlso m_dropLength = 0) Then
      ' Display empty deck image.
      e.Graphics.DrawImage(CardSlotsImageList.Images(0), 0, 0)
    Else
      ' Display card backs.
      e.Graphics.DrawImage(CardBacksImageList.Images(m_settings.CardBack), 0, 0)
      If m_deckLength > 10 Then
        e.Graphics.DrawImage(CardBacksImageList.Images(m_settings.CardBack), m_xShift, m_yShift)
      End If
      If m_deckLength > 20 Then
        e.Graphics.DrawImage(CardBacksImageList.Images(m_settings.CardBack), m_xShift + m_xShift, m_yShift + m_yShift)
      End If
    End If
    Me.ResumeLayout(False)
  End Sub

  Private Sub DragBoxPictureBox_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DragBoxPictureBox_1.Paint, DragBoxPictureBox_2.Paint, DragBoxPictureBox_3.Paint, DragBoxPictureBox_4.Paint
    If m_win Then
      ' Win effect.
      Win(sender, e)
    Else
      ' Draw images in DragBoxPictureBox.
      Dim x As Integer = 0
      Me.SuspendLayout()
      For index As Integer = 0 To m_dragLength - 1
        Dim suit As Integer = CInt(m_drag.GetValue(0, index))
        Dim cardValue As Integer = CInt(m_drag.GetValue(1, index))
        Dim y As Integer = CInt(m_drag.GetValue(2, index))
        If Not m_settings.Outline Then
          If suit = 0 Then ' Spades.
            e.Graphics.DrawImage(SpadesImageList.Images(cardValue), x, y)
          ElseIf suit = 1 Then ' Diamonds.
            e.Graphics.DrawImage(DiamondsImageList.Images(cardValue), x, y)
          ElseIf suit = 2 Then ' Clubs.
            e.Graphics.DrawImage(ClubsImageList.Images(cardValue), x, y)
          Else ' Hearts.
            e.Graphics.DrawImage(HeartsImageList.Images(cardValue), x, y)
          End If
        Else
          ' Outline dragging.
        End If
      Next
      Me.ResumeLayout(False)
    End If
  End Sub

  Private Sub DeckToDealPictureBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DeckToDealPictureBox.MouseDown
    If e.Button = MouseButtons.Right Then
      MoveAllPossibleCardsUp()
      Return
    End If
    ' Check if actually over card.
    If m_deckLength < 11 AndAlso _
       e.X < m_cardWidth AndAlso _
       e.Y < m_cardHeight OrElse _
       (m_deckLength > 10 AndAlso _
        m_deckLength < 21 AndAlso _
        e.X > m_xShift AndAlso _
        e.X < m_xShift + m_cardWidth AndAlso _
        e.Y > m_yShift AndAlso _
        e.Y < m_yShift + m_cardHeight) OrElse _
       (m_deckLength > 20 AndAlso _
        e.X > 2 * m_xShift AndAlso _
        e.X < 2 * m_xShift + m_cardWidth AndAlso _
        e.Y > 2 * m_yShift AndAlso _
        e.Y < 2 * m_yShift + m_cardHeight) Then
      m_drawing = True
      DropPanelPictureBox.Invalidate(New System.Drawing.Region(New System.Drawing.Rectangle(0, 0, DropPanelPictureBox.Width, DropPanelPictureBox.Height)), False)
      If m_deckLength = 1 OrElse m_deckLength = 11 OrElse m_deckLength = 21 Then
        DeckToDealPictureBox.Invalidate(New System.Drawing.Region(New System.Drawing.Rectangle(0, 0, DeckToDealPictureBox.Width, DeckToDealPictureBox.Height)), False)
      End If
    End If
  End Sub

  Private Sub DropPanelPictureBox_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DropPanelPictureBox.Paint
    Me.SuspendLayout()
    If m_drawing Then
      Dim limit As Integer = 1
      Dim i As Integer
      If m_deckLength > 0 Then
        If Not m_settings.DrawOne Then
          limit = 3
          If m_deckLength < 3 Then
            limit = m_deckLength
          End If
        End If
        ' Set undo information.
        m_undo.SetValue(limit, 0, 0)
        m_undoType = 0
        Dim undoCount As Integer = 0
        If m_dropLength > 0 Then
          If CInt(m_drop.GetValue(3, m_dropLength - 1)) <> 0 Then
            undoCount += 1
          End If
        End If
        If m_dropLength > 1 Then
          If CInt(m_drop.GetValue(3, m_dropLength - 2)) <> 0 Then
            undoCount += 1
          End If
        End If
        m_undo.SetValue(undoCount, 0, 1)

        For i = 0 To limit - 1

          Dim suit, cardvalue As Integer

          ' Get card for card drop.
          suit = CInt(m_deck.GetValue(0, m_deckLength - 1))
          cardvalue = CInt(m_deck.GetValue(1, m_deckLength - 1))
          m_deckLength -= 1

          ' Add card to m_drop array.
          m_drop.SetValue(suit, 0, m_dropLength)
          m_drop.SetValue(cardvalue, 1, m_dropLength)
          m_drop.SetValue(i * m_xBigShift, 2, m_dropLength)
          m_drop.SetValue(i * m_yShift, 3, m_dropLength)
          m_dropLength += 1

          If m_dropLength > 3 AndAlso CInt(m_drop.GetValue(3, m_dropLength - 3)) <> 0 Then
            m_drop.SetValue(0, 2, m_dropLength - 3)
            m_drop.SetValue(0, 3, m_dropLength - 3)
          End If
          If m_dropLength > 4 AndAlso CInt(m_drop.GetValue(3, m_dropLength - 4)) <> 0 Then
            m_drop.SetValue(0, 2, m_dropLength - 4)
            m_drop.SetValue(0, 3, m_dropLength - 4)
          End If
        Next i
        ' Start timer if first move.
        If m_time = 0 AndAlso m_settings.TimedGame Then
          GameTimer.Start()
        End If
      End If
      If m_deckLength <= 0 Then ' Reset deck.
        If m_deckLength = -1 Then

          ' Set undo information.
          m_undoType = 6

          m_cycleDeck += 1
          m_deckLength = m_dropLength

          ' Move drop to deck.
          Dim k As Integer = 0
          For i = m_dropLength - 1 To 0 Step -1
            m_deck.SetValue(m_drop.GetValue(0, i), 0, k)
            m_deck.SetValue(m_drop.GetValue(1, i), 1, k)
            k += 1
          Next
          m_dropLength = 0

          ' Scoring.
          If m_settings.Scoring = Scoring.Standard AndAlso m_cycleDeck > 3 AndAlso Not m_settings.DrawOne Then
            m_score -= 20
          ElseIf m_settings.Scoring = Scoring.Standard AndAlso m_cycleDeck > 1 AndAlso m_settings.DrawOne Then
            m_score -= 100
          End If
          If m_settings.Scoring <> Scoring.None Then
            UpdateStatus()
          End If
          DeckToDealPictureBox.Invalidate(False)
        Else
          m_deckLength -= 1 ' Set to -1 to flip deck.
          DeckToDealPictureBox.Invalidate(False)
        End If
      End If
      m_drawing = False
      MenuGameUndo.Enabled = True
    End If
    ' Refresh cards.
    DealtDeck_Paint(sender, e)

    Me.ResumeLayout(False)

  End Sub

  Private Sub DealtDeck_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    ' Refresh cards.

    Dim x As Integer = 0
    Dim y As Integer = 0
    Dim newSuit, newCardValue As Integer

    'TODO: Optimize this code so it only draws the last 3 (or less) cards - those that are visible.
    '      Right now, it's drawing every card over each other.

    For j As Integer = 0 To m_dropLength - 1

      If m_settings.DrawOne Then
        If j = 11 Then
          ' Draw one thickness.
          y += m_yShift
          x += m_xShift
        End If
        If j = 21 Then
          ' Draw one extra thickness.
          y += m_yShift
          x += m_xShift
        End If
      Else
        ' Draw three actual locations.
        x = CInt(m_drop.GetValue(2, j))
        y = CInt(m_drop.GetValue(3, j))
        'FIX: To clear the background if the last card is being displayed.
        If j = m_dropLength - 1 AndAlso x = 0 AndAlso y = 0 Then
          ' This is the last card on the pile, clear the background.
          e.Graphics.Clear(Me.BackColor)
        End If
      End If

      newSuit = CInt(m_drop.GetValue(0, j))
      newCardValue = CInt(m_drop.GetValue(1, j))

      If newSuit = 0 Then ' Spades.
        e.Graphics.DrawImage(SpadesImageList.Images(newCardValue), x, y)
      ElseIf newSuit = 1 Then ' Diamonds.
        e.Graphics.DrawImage(DiamondsImageList.Images(newCardValue), x, y)
      ElseIf newSuit = 2 Then ' Clubs.
        e.Graphics.DrawImage(ClubsImageList.Images(newCardValue), x, y)
      Else ' Hearts.
        e.Graphics.DrawImage(HeartsImageList.Images(newCardValue), x, y)
      End If

    Next

  End Sub

  Private Sub GameStatusBar_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles GameStatusBar.Layout
    UpdateStatus()
  End Sub

  ' Have to owner draw the panel to get it to be red
  ' as panels don't have ForeColors (and StatusBars don't have right alignment).
  Sub GameStatusBar_DrawItem(ByVal sender As Object, ByVal e As StatusBarDrawItemEventArgs) Handles GameStatusBar.DrawItem

    Const labelScore As String = "Score: "
    Const labelTime As String = "Time: "
    Const charSpace As Integer = 8

    Dim extraChar As Integer = 0
    Dim bar As StatusBar = CType(sender, StatusBar)
    Dim textColor As Color = bar.ForeColor
    Dim output As String = ""

    ' Score: xxx.
    Select Case m_settings.Scoring
      Case Scoring.None

      Case Scoring.Standard
        output &= m_score

      Case Scoring.Vegas, Scoring.VegasCumulative
        If m_score < 0 Then
          output &= "-$" & Math.Abs(m_score)
          textColor = Color.Red
          extraChar = 2
        Else
          output &= "$" & m_score
          extraChar = 1
        End If

      Case Else
        Debug.Assert(False)
    End Select

    If m_settings.Scoring <> Scoring.None Then

      ' Draw the score label.
      Dim format As New StringFormat
      format.Alignment = StringAlignment.Far
      format.LineAlignment = StringAlignment.Center
      Dim rect As Rectangle = bar.ClientRectangle
      If m_settings.TimedGame Then
        If m_score = 0 OrElse m_time = 0 Then
          rect.Width -= 64
        Else
          rect.Width -= 64 + (CInt(Math.Floor(Math.Log10(CDbl(m_score)))) * charSpace) + (CInt(Math.Floor(Math.Log10(CDbl(m_time)))) * charSpace)
        End If
      Else
        If m_score = 0 Then
          rect.Width -= 20
        Else
          rect.Width -= 20 + CInt(Math.Floor(Math.Log10(CDbl(m_score)))) * charSpace
        End If
      End If
      rect.Width -= extraChar * charSpace
      e.Graphics.DrawString(labelScore, bar.Font, Brushes.Black, RectangleF.op_Implicit(rect), format)

      ' Draw the score.
      Dim brush As Brush = New SolidBrush(textColor)
      Try
        format = New StringFormat
        format.Alignment = StringAlignment.Far
        format.LineAlignment = StringAlignment.Center
        rect = bar.ClientRectangle
        If m_settings.TimedGame Then
          If m_time = 0 Then
            rect.Width -= 49
          Else
            rect.Width -= 49 + CInt(Math.Floor(Math.Log10(CDbl(m_time)))) * charSpace
          End If
        Else
          rect.Width -= 8
        End If
        e.Graphics.DrawString(output, bar.Font, brush, RectangleF.op_Implicit(rect), format)
      Finally
        brush.Dispose()
      End Try

    End If

    ' Time: xxx.
    If m_settings.TimedGame Then
      Dim format As New StringFormat
      format.Alignment = StringAlignment.Far
      format.LineAlignment = StringAlignment.Center
      Dim rect As Rectangle = bar.ClientRectangle
      rect.Width -= 5
      e.Graphics.DrawString(labelTime & m_time.ToString, bar.Font, Brushes.Black, RectangleF.op_Implicit(rect), format)
    End If

  End Sub

  Public Sub UpdateStatus()
    If Not m_settings Is Nothing Then
      If Not m_settings.Outline AndAlso Not DragBoxPictureBox_1.BackColor.Equals(System.Drawing.Color.Transparent) Then
        DragBoxPictureBox_1.BackColor = System.Drawing.Color.Transparent
      ElseIf m_settings.Outline AndAlso DragBoxPictureBox_1.BackColor.Equals(System.Drawing.Color.Transparent) Then
        DragBoxPictureBox_1.BackColor = System.Drawing.Color.Gray
      End If
      If m_settings.Scoring = Scoring.Standard AndAlso m_score < 0 Then
        m_score = 0
      End If
      If m_settings.ViewStatusBar Then
        GameStatusBar.Visible = True
      Else
        GameStatusBar.Visible = False
      End If
      ' Refresh.
      GameStatusBar.Invalidate(True)
    End If
  End Sub

  Private Sub InvalidateStack(ByVal stack As Integer)
    Select Case stack
      Case 0
        StackPictureBox_0.Invalidate(False)
      Case 1
        StackPictureBox_1.Invalidate(False)
      Case 2
        StackPictureBox_2.Invalidate(False)
      Case 3
        StackPictureBox_3.Invalidate(False)
      Case 4
        StackPictureBox_4.Invalidate(False)
      Case 5
        StackPictureBox_5.Invalidate(False)
      Case 6
        StackPictureBox_6.Invalidate(False)
      Case 7 ' Dealt cards.
        DropPanelPictureBox.Invalidate(False)
      Case 8
        AcePictureBox_0.Invalidate(False)
      Case 9
        AcePictureBox_1.Invalidate(False)
      Case 10
        AcePictureBox_2.Invalidate(False)
      Case 11
        AcePictureBox_3.Invalidate(False)
    End Select

  End Sub

#End Region

#Region "Drag/Drop Methods"

  Private Sub GenericMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GameStatusBar.MouseMove, DeckToDealPictureBox.MouseMove, MyBase.MouseMove

    If m_dragging Then

      Dim deltaX As Integer = DragBoxPictureBox_1.Location.X + (e.X - m_mouseX)
      Dim deltaY As Integer = DragBoxPictureBox_1.Location.Y + (e.Y - m_mouseY)

      ' Move DragBoxPictureBox to new delta'd mouse position.
      DragBoxPictureBox_1.Location = New System.Drawing.Point(deltaX, deltaY)

      If m_settings.Outline Then
        deltaX = DragBoxPictureBox_2.Location.X + (e.X - m_mouseX)
        deltaY = DragBoxPictureBox_2.Location.Y + (e.Y - m_mouseY)
        DragBoxPictureBox_2.Location = New System.Drawing.Point(deltaX, deltaY)

        deltaX = DragBoxPictureBox_3.Location.X + (e.X - m_mouseX)
        deltaY = DragBoxPictureBox_3.Location.Y + (e.Y - m_mouseY)
        DragBoxPictureBox_3.Location = New System.Drawing.Point(deltaX, deltaY)

        deltaX = DragBoxPictureBox_4.Location.X + (e.X - m_mouseX)
        deltaY = DragBoxPictureBox_4.Location.Y + (e.Y - m_mouseY)
        DragBoxPictureBox_4.Location = New System.Drawing.Point(deltaX, deltaY)

      End If
    End If

    m_mouseX = e.X
    m_mouseY = e.Y

  End Sub

  Private Sub DoMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs, ByVal stack As Integer)
    If m_dragging Then
      Dim deltaX As Integer = DragBoxPictureBox_1.Location.X + (e.X - m_mouseX)
      Dim deltaY As Integer = DragBoxPictureBox_1.Location.Y + (e.Y - m_mouseY)

      ' Move DragBoxPictureBox to new delta'd mouse position.
      DragBoxPictureBox_1.Location = New System.Drawing.Point(deltax, deltay)

      If m_settings.Outline Then
        deltax = DragBoxPictureBox_2.Location.X + (e.X - m_mouseX)
        deltay = DragBoxPictureBox_2.Location.Y + (e.Y - m_mouseY)
        DragBoxPictureBox_2.Location = New System.Drawing.Point(deltax, deltay)

        deltax = DragBoxPictureBox_3.Location.X + (e.X - m_mouseX)
        deltay = DragBoxPictureBox_3.Location.Y + (e.Y - m_mouseY)
        DragBoxPictureBox_3.Location = New System.Drawing.Point(deltax, deltay)

        deltax = DragBoxPictureBox_4.Location.X + (e.X - m_mouseX)
        deltay = DragBoxPictureBox_4.Location.Y + (e.Y - m_mouseY)
        DragBoxPictureBox_4.Location = New System.Drawing.Point(deltax, deltay)
      End If
    ElseIf e.Button = System.Windows.Forms.MouseButtons.Left Then
      ' Start timer if first move.
      If m_time = 0 AndAlso m_settings.TimedGame Then
        GameTimer.Start()
      End If
      ' Find which card was hit.
      If FindHit(stack) Then
        m_dragStack = stack
        m_dragging = True
        If stack > 6 OrElse CInt(m_stacks.GetValue(stack, 4, m_hitCard)) = 1 Then ' Flipped up or from DropPanelPictureBox or Aces.
          Dim x As Integer = 0
          Dim y As Integer = 0
          Dim i As Integer = 0
          Dim locationX As Integer = 0
          Dim locationY As Integer = 0

          If stack < 7 Then
            x = CInt(m_stacks.GetValue(stack, 2, m_hitCard))
            y = CInt(m_stacks.GetValue(stack, 3, m_hitCard))
          ElseIf stack = 7 Then ' DropPanelPictureBox.
            x = CInt(m_drop.GetValue(2, m_hitCard))
            y = CInt(m_drop.GetValue(3, m_hitCard))
          End If

          If stack > 7 Then ' Aces.
            x = 0
            y = 0
          End If

          ' Get position of card for position of DragBoxPictureBox.
          If stack = 0 Then
            locationX = StackPictureBox_0.Location.X
            locationY = StackPictureBox_0.Location.Y
          ElseIf stack = 1 Then
            locationX = StackPictureBox_1.Location.X
            locationY = StackPictureBox_1.Location.Y
          ElseIf stack = 2 Then
            locationX = StackPictureBox_2.Location.X
            locationY = StackPictureBox_2.Location.Y
          ElseIf stack = 3 Then
            locationX = StackPictureBox_3.Location.X
            locationY = StackPictureBox_3.Location.Y
          ElseIf stack = 4 Then
            locationX = StackPictureBox_4.Location.X
            locationY = StackPictureBox_4.Location.Y
          ElseIf stack = 5 Then
            locationX = StackPictureBox_5.Location.X
            locationY = StackPictureBox_5.Location.Y
          ElseIf stack = 6 Then
            locationX = StackPictureBox_6.Location.X
            locationY = StackPictureBox_6.Location.Y
          ElseIf stack = 7 Then
            locationX = DropPanelPictureBox.Location.X
            locationY = DropPanelPictureBox.Location.Y
          ElseIf stack = 8 Then
            locationX = AcePictureBox_0.Location.X
            locationY = AcePictureBox_0.Location.Y
          ElseIf stack = 9 Then
            locationX = AcePictureBox_1.Location.X
            locationY = AcePictureBox_1.Location.Y
          ElseIf stack = 10 Then
            locationX = AcePictureBox_2.Location.X
            locationY = AcePictureBox_2.Location.Y
          ElseIf stack = 11 Then
            locationX = AcePictureBox_3.Location.X
            locationY = AcePictureBox_3.Location.Y
          End If

          ' Calculate height of DragBoxPictureBox.
          Dim dragboxheight As Integer
          If stack > 6 Then ' Aces and drop box.
            dragboxheight = m_cardHeight
          Else
            dragboxheight = m_cardHeight + m_large * (m_stackLengths(stack) - m_hitCard - 1)
          End If
          ' Copy information of dragging cards to drag array.
          i = m_hitCard
          Dim j As Integer = 0
          If stack > 7 Then ' Aces.
            m_drag.SetValue(m_aceStacks.GetValue(stack - 8, 0, i), 0, j) ' Copy suit.
            m_drag.SetValue(m_aceStacks.GetValue(stack - 8, 1, i), 1, j) ' Copy card value.
            m_drag.SetValue(0, 2, j) ' Set y = 0.
            m_dragLength = 1 ' Set drag length to 1 card.
            If Not m_settings.Outline Then
              m_aceStackLengths((stack - 8)) -= 1 ' Make ace stack length 1 card smaller.
            End If
          ElseIf stack = 7 Then ' Drop box.
            m_drag.SetValue(m_drop.GetValue(0, i), 0, j) ' Copy suit.
            m_drag.SetValue(m_drop.GetValue(1, i), 1, j) ' Copy card value.
            m_drag.SetValue(0, 2, j) ' Set y = 0.
            m_dragLength = 1 ' Set drag length to 1 card.
            If Not m_settings.Outline Then
              m_dropLength -= 1 ' Make drop 1 card smaller.
            End If
          Else ' Stacks.
            While i < m_stackLengths(stack)
              m_drag.SetValue(m_stacks.GetValue(stack, 0, i), 0, j) ' Copy suit.
              m_drag.SetValue(m_stacks.GetValue(stack, 1, i), 1, j) ' Copy card value.
              m_drag.SetValue(CInt(m_stacks.GetValue(stack, 3, i)) - y, 2, j) ' Copy Y (adjusting for offset).
              i += 1
              j += 1
            End While

            ' Calculate length of drag array.
            m_dragLength = m_stackLengths(stack) - m_hitCard

            ' Shorten stack.
            If Not m_settings.Outline Then
              m_stackLengths(stack) = m_hitCard ' Note that the dragging cards are still in the stack.
            End If
          End If ' Modify DragBoxPictureBox for move.
          DragBoxPictureBox_1.Location = New System.Drawing.Point(locationX + x, locationY + y)
          If Not m_settings.Outline Then
            DragBoxPictureBox_1.Size = New System.Drawing.Size(m_cardWidth, dragboxheight)
          Else
            DragBoxPictureBox_1.Size = New System.Drawing.Size(1, dragboxheight)
            DragBoxPictureBox_2.Location = New System.Drawing.Point(locationX + x, locationY + y)
            DragBoxPictureBox_2.Size = New System.Drawing.Size(m_cardWidth, 1)
            DragBoxPictureBox_3.Location = New System.Drawing.Point(locationX + x + m_cardWidth, locationY + y)
            DragBoxPictureBox_3.Size = New System.Drawing.Size(1, dragboxheight + 1)
            DragBoxPictureBox_4.Location = New System.Drawing.Point(locationX + x, locationY + y + dragboxheight)
            DragBoxPictureBox_4.Size = New System.Drawing.Size(m_cardWidth, 1)
          End If

          ' Refresh bug fix.
          m_dragStartX = locationX + x
          m_dragStartY = locationY + y

          Dim deltax As Integer = DragBoxPictureBox_1.Location.X + (e.X - m_mouseX)
          Dim deltay As Integer = DragBoxPictureBox_1.Location.Y + (e.Y - m_mouseY)

          ' Move DragBoxPictureBox to new delta'd mouse position.
          DragBoxPictureBox_1.Location = New System.Drawing.Point(deltax, deltay)

          If m_settings.Outline Then
            deltax = DragBoxPictureBox_2.Location.X + (e.X - m_mouseX)
            deltay = DragBoxPictureBox_2.Location.Y + (e.Y - m_mouseY)
            DragBoxPictureBox_2.Location = New System.Drawing.Point(deltax, deltay)

            deltax = DragBoxPictureBox_3.Location.X + (e.X - m_mouseX)
            deltay = DragBoxPictureBox_3.Location.Y + (e.Y - m_mouseY)
            DragBoxPictureBox_3.Location = New System.Drawing.Point(deltax, deltay)

            deltax = DragBoxPictureBox_4.Location.X + (e.X - m_mouseX)
            deltay = DragBoxPictureBox_4.Location.Y + (e.Y - m_mouseY)
            DragBoxPictureBox_4.Location = New System.Drawing.Point(deltax, deltay)
          End If

          Me.Invalidate(New System.Drawing.Rectangle(deltax, deltay, DragBoxPictureBox_1.Width, DragBoxPictureBox_1.Height), True)
          If m_settings.Outline Then
            Me.Invalidate(True)
          End If
        Else ' Card flipped down.
          m_dragging = False
        End If
      End If
    End If

    ' Save new mouse position.
    m_mouseX = e.X
    m_mouseY = e.Y

  End Sub

  Private Function FindHit(ByVal stack As Integer) As Boolean

    Dim i As Integer = 0
    Dim x, y As Integer
    Dim found As Boolean = False

    If stack > 7 Then ' Aces.
      If m_aceStackLengths((stack - 8)) <> 0 Then
        found = True
        m_hitCard = m_aceStackLengths((stack - 8)) - 1
      End If
    ElseIf stack = 7 Then ' DropBox.
      If m_dropLength <> 0 Then
        If Not m_settings.DrawOne Then
          x = CInt(m_drop.GetValue(2, m_dropLength - 1))
          y = CInt(m_drop.GetValue(3, m_dropLength - 1))
          If m_mouseX > x AndAlso m_mouseX < x + m_cardWidth Then
            If m_mouseY > y AndAlso m_mouseY < y + m_cardWidth Then
              m_hitCard = m_dropLength - 1
              found = True
            End If
          End If
          i += 1
        Else ' Draw One.
          If m_mouseX < m_cardWidth Then
            m_hitCard = m_dropLength - 1
            found = True
          End If
        End If
      End If
    Else ' Stacks.
      i = 0
      Dim offset As Integer
      While i < m_stackLengths(stack) AndAlso Not found
        y = CInt(m_stacks.GetValue(stack, 3, i))
        If i = m_stackLengths(stack) - 1 Then ' Flipped down.
          offset = y + m_cardHeight
        Else
          offset = CInt(m_stacks.GetValue(stack, 3, i + 1))
        End If
        If m_mouseY >= y AndAlso i = m_stackLengths(stack) - 1 AndAlso m_mouseY < offset OrElse (m_mouseY >= y AndAlso m_mouseY < offset) Then
          m_hitCard = i
          found = True
        End If
        i += 1
      End While
    End If

    Return found

  End Function

  Private Function HoverTest(ByVal i As Integer, ByVal left As Integer, ByVal right As Integer, ByVal top As Integer, ByVal bottom As Integer, ByVal thisStack As Integer) As Boolean

    Dim found As Boolean = False
    Dim cleft, cright, ctop, cbottom As Integer

    cleft = Me.Controls(i).Location.X
    cright = cleft + m_cardWidth
    ctop = Me.Controls(i).Location.Y
    cbottom = ctop + Me.Controls(i).Height

    If cleft < left AndAlso cright > left OrElse (cleft > left AndAlso cleft < right) AndAlso thisStack <> Me.Controls(i).TabIndex Then
      ' Horizontal match.
      If ctop < top AndAlso cbottom > top OrElse (ctop > top AndAlso ctop < bottom) Then
        ' Vertical match.
        found = True
      End If
    End If

    Return found

  End Function

  Private Sub StackPictureBox_0_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles StackPictureBox_0.MouseMove
    DoMouseMove(sender, e, 0)
  End Sub

  Private Sub StackPictureBox_1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles StackPictureBox_1.MouseMove
    DoMouseMove(sender, e, 1)
  End Sub

  Private Sub StackPictureBox_2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles StackPictureBox_2.MouseMove
    DoMouseMove(sender, e, 2)
  End Sub

  Private Sub StackPictureBox_3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles StackPictureBox_3.MouseMove
    DoMouseMove(sender, e, 3)
  End Sub

  Private Sub StackPictureBox_4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles StackPictureBox_4.MouseMove
    DoMouseMove(sender, e, 4)
  End Sub

  Private Sub StackPictureBox_5_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles StackPictureBox_5.MouseMove
    DoMouseMove(sender, e, 5)
  End Sub

  Private Sub StackPictureBox_6_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles StackPictureBox_6.MouseMove
    DoMouseMove(sender, e, 6)
  End Sub

  Private Sub DropPanelPictureBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DropPanelPictureBox.MouseMove
    DoMouseMove(sender, e, 7)
  End Sub

  Private Sub AcePictureBox_0_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AcePictureBox_0.MouseMove
    DoMouseMove(sender, e, 8)
  End Sub

  Private Sub AcePictureBox_1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AcePictureBox_1.MouseMove
    DoMouseMove(sender, e, 9)
  End Sub

  Private Sub AcePictureBox_2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AcePictureBox_2.MouseMove
    DoMouseMove(sender, e, 10)
  End Sub

  Private Sub AcePictureBox_3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AcePictureBox_3.MouseMove
    DoMouseMove(sender, e, 11)
  End Sub

  Sub MoveAllPossibleCardsUp()

    Dim working As Boolean = True ' Are there more iterations to try?
    Dim cardsMoved As Integer = 0 ' Number of cards moved to ace stacks. Used for scoring.
    Dim i As Integer = 0 ' Ace iteration variable.
    Dim j As Integer = 0 ' Stack iteration variable.
    Dim aceSuit As Integer = 0 ' Suits: spades=0, diamonds=1, clubs=2, hearts=3, undetermined=4.
    Dim aceCard As Integer = 0 ' Top ace card value.
    Dim currentSuit As Integer = 0 ' Suits: spades=0, diamonds=1, clubs=2, hearts=3.
    Dim currentCard As Integer = 0 ' Top stack card value.
    Dim currentFlipped As Integer = 0 ' Whether card on stack is face up; no=0, yes=1.

    ' Find out what can be moved and move it.
    While working
      working = False
      For i = 0 To 3 ' Go through each ace.
        ' Get ace info.
        If CInt(m_aceStackLengths.GetValue(i)) <> 0 Then
          aceSuit = CInt(m_aceStacks.GetValue(i, 0, 0))
          aceCard = CInt(m_aceStackLengths.GetValue(i)) - 1
        Else
          aceSuit = 4
        End If
        If m_dropLength <> 0 Then ' Check for empty dealt card stack.
          ' Get drop info.
          currentSuit = CInt(m_drop.GetValue(0, m_dropLength - 1))
          currentCard = CInt(m_drop.GetValue(1, m_dropLength - 1))
          If currentSuit = aceSuit AndAlso currentCard = aceCard + 1 OrElse (aceSuit = 4 AndAlso currentCard = 0) Then ' Check dealt card.
            ' Move card.
            m_dropLength -= 1
            m_aceStackLengths(i) += 1
            m_aceStacks.SetValue(currentSuit, i, 0, m_aceStackLengths(i) - 1)
            m_aceStacks.SetValue(currentCard, i, 1, m_aceStackLengths(i) - 1)
            ' Set undo info.
            m_undoType = 4
            m_undo.SetValue(i, 4, 0)
            m_undo.SetValue(7, 4, 1)
            MenuGameUndo.Enabled = True
            ' Invalidate stacks.
            InvalidateStack((i + 8))
            InvalidateStack(7)
            ' Get new ace info.
            aceSuit = CInt(m_aceStacks.GetValue(i, 0, 0))
            aceCard = CInt(m_aceStackLengths.GetValue(i)) - 1
            cardsMoved += 1
            working = True
          End If
        End If
        For j = 0 To 6 ' Go through each stack.
          If m_stackLengths(j) <> 0 Then ' Check for empty stack.
            currentSuit = CInt(m_stacks.GetValue(j, 0, m_stackLengths(j) - 1))
            currentCard = CInt(m_stacks.GetValue(j, 1, m_stackLengths(j) - 1))
            currentFlipped = CInt(m_stacks.GetValue(j, 4, m_stackLengths(j) - 1))
            If currentSuit = aceSuit AndAlso currentCard = aceCard + 1 AndAlso currentFlipped = 1 OrElse (aceSuit = 4 AndAlso currentCard = 0 AndAlso currentFlipped = 1) Then ' See if stack is one more than ace in same suit.
              ' Move card.
              m_stackLengths(j) -= 1
              m_aceStackLengths(i) += 1
              m_aceStacks.SetValue(currentSuit, i, 0, m_aceStackLengths(i) - 1)
              m_aceStacks.SetValue(currentCard, i, 1, m_aceStackLengths(i) - 1)
              ' Set undo info.
              m_undoType = 4
              m_undo.SetValue(i, 4, 0)
              m_undo.SetValue(j, 4, 1)
              MenuGameUndo.Enabled = True
              ' Invalidate stacks.
              InvalidateStack((i + 8))
              InvalidateStack(j)
              ' Get new ace info.
              aceSuit = CInt(m_aceStacks.GetValue(i, 0, 0))
              aceCard = CInt(m_aceStackLengths.GetValue(i)) - 1
              cardsMoved += 1
              working = True
            End If
          End If
        Next
      Next
    End While

    ' Update scoring.
    If m_settings.Scoring = Scoring.Standard Then
      m_score += 10 * cardsMoved
      UpdateStatus()
    End If

  End Sub

  Private Sub HandleMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
    Handles AcePictureBox_1.MouseUp, _
            AcePictureBox_2.MouseUp, _
            AcePictureBox_0.MouseUp, _
            AcePictureBox_3.MouseUp, _
            StackPictureBox_4.MouseUp, _
            StackPictureBox_6.MouseUp, _
            StackPictureBox_5.MouseUp, _
            StackPictureBox_1.MouseUp, _
            StackPictureBox_0.MouseUp, _
            StackPictureBox_2.MouseUp, _
            StackPictureBox_3.MouseUp, _
            DropPanelPictureBox.MouseUp, _
            DragBoxPictureBox_1.MouseUp, _
            DragBoxPictureBox_2.MouseUp, _
            DragBoxPictureBox_3.MouseUp, _
            DragBoxPictureBox_4.MouseUp, _
            MyBase.MouseUp
    If Not m_dragging Then
      If e.Button = MouseButtons.Right Then
        MoveAllPossibleCardsUp()
      End If
      Return
    End If

    Me.SuspendLayout()

    Dim left, right, top, bottom As Integer
    Dim found As Boolean = False
    Dim i As Integer = 0

    ' Find DragBoxPictureBox_1 location.
    left = DragBoxPictureBox_1.Location.X
    right = left + m_cardWidth
    top = DragBoxPictureBox_1.Location.Y
    bottom = top + DragBoxPictureBox_1.Height

    ' Get drag stack so it's not same stack.
    Dim thisstack As Integer = 0
    If m_dragStack < 7 Then ' Stacks.
      thisstack = m_dragStack + 7
    ElseIf m_dragStack > 6 Then ' DropBox.
      thisstack = m_dragStack - 5
    End If
    ' Find which panel the DragBoxPictureBox_1 is over, first go through each panel.
    For i = 0 To (Me.Controls.Count) - 1
      ' If over winParabola panel, drop if card match.
      If HoverTest(i, left, right, top, bottom, thisstack) AndAlso Not found Then
        ' If match, drop cards.
        If Me.Controls(i).TabIndex > 6 AndAlso Me.Controls(i).TabIndex < 14 Then ' Stacks.
          ' Set undo information.
          m_undoType = 1
          m_undo.SetValue(m_dragStack, 1, 0) ' Set drag from.
          m_undo.SetValue(Me.Controls(i).TabIndex, 1, 1) ' Set drag to.
          m_undo.SetValue(m_dragLength, 1, 2) ' Set length.
          MenuGameUndo.Enabled = True

          ' New stack.
          Dim stack As Integer = 0
          Dim suit As Integer = 0
          Dim flipped As Integer = 0
          Dim cardvalue As Integer = 0
          stack = Me.Controls(i).TabIndex - 7
          If m_stackLengths(stack) <> 0 Then
            suit = CInt(m_stacks.GetValue(stack, 0, m_stackLengths(stack) - 1))
            cardvalue = CInt(m_stacks.GetValue(stack, 1, m_stackLengths(stack) - 1))
            flipped = CInt(m_stacks.GetValue(stack, 4, m_stackLengths(stack) - 1))
          End If

          ' Drag stack.
          Dim dSuit As Integer
          Dim dCardValue As Integer
          dSuit = CInt(m_drag.GetValue(0, 0))
          dCardValue = CInt(m_drag.GetValue(1, 0))

          ' Drop card.
          If dcardvalue = 12 AndAlso m_stackLengths(stack) = 0 OrElse (flipped = 1 AndAlso suit Mod 2 <> dsuit Mod 2 AndAlso dcardvalue = cardvalue - 1) Then ' Not flipped down, not same color, next card down.
            ' Drop cards on new stack.
            Dim k As Integer = 0
            Dim newY As Integer
            While k < m_dragLength
              dsuit = CInt(m_drag.GetValue(0, k))
              dcardvalue = CInt(m_drag.GetValue(1, k))
              newY = 0
              If dcardvalue <> 12 Then
                newY = CInt(m_stacks.GetValue(stack, 3, m_stackLengths(stack) - 1)) + m_large
              End If
              If k = 0 Then
                m_dragStartY = newY
              End If
              SetCard(stack, dsuit, dcardvalue, 0, newY, 1, m_stackLengths(stack))
              m_stackLengths(stack) += 1
              found = True
              k += 1
            End While

            ' Scoring.
            If m_settings.Scoring = Scoring.Standard Then
              If m_dragStack = 7 Then
                m_score += 5
              ElseIf m_dragStack > 7 Then
                m_score -= 15
              End If
              UpdateStatus()
            End If

            Me.Controls(i).Invalidate(New System.Drawing.Region(New System.Drawing.Rectangle(0, m_dragStartY, m_cardWidth, Me.Controls(i).Height)), False)
          End If
        ElseIf Me.Controls(i).TabIndex > 2 AndAlso Me.Controls(i).TabIndex < 7 Then ' Ace drops.
          ' Set undo information.
          m_undoType = 1
          m_undo.SetValue(m_dragStack, 1, 0) ' Set drag from.
          m_undo.SetValue(Me.Controls(i).TabIndex, 1, 1) ' Set drag to.
          m_undo.SetValue(1, 1, 2)
          MenuGameUndo.Enabled = True

          ' Drag stack.
          Dim dsuit, dcardvalue As Integer
          dsuit = CInt(m_drag.GetValue(0, 0))
          dcardvalue = CInt(m_drag.GetValue(1, 0))

          ' New stack.
          Dim suit As Integer = 0
          Dim cardvalue As Integer = 0
          Dim stack As Integer = 0
          stack = Me.Controls(i).TabIndex - 3
          If m_aceStackLengths(stack) <> 0 Then
            suit = CInt(m_aceStacks.GetValue(stack, 0, m_aceStackLengths(stack) - 1))
            cardvalue = CInt(m_aceStacks.GetValue(stack, 1, m_aceStackLengths(stack) - 1))
          End If

          If m_aceStackLengths(stack) = 0 AndAlso dcardvalue = 0 OrElse (m_dragLength = 1 AndAlso dsuit = suit AndAlso dcardvalue = cardvalue + 1 AndAlso m_aceStackLengths(stack) <> 0) Then ' Next card or ace on new stack.
            ' Update data.
            m_aceStacks.SetValue(dsuit, stack, 0, m_aceStackLengths(stack))
            m_aceStacks.SetValue(dcardvalue, stack, 1, m_aceStackLengths(stack))
            m_aceStackLengths(stack) += 1

            ' Scoring.
            If m_settings.Scoring = Scoring.Standard Then
              m_score += 10
            ElseIf m_settings.Scoring = Scoring.Vegas OrElse m_settings.Scoring = Scoring.VegasCumulative Then
              m_score += 5
            End If
            If m_settings.Scoring <> Scoring.None Then
              UpdateStatus()
            End If
            If m_aceStackLengths(0) + m_aceStackLengths(1) + m_aceStackLengths(2) + m_aceStackLengths(3) = 52 Then ' Win.
              m_win = True
              MenuGameUndo.Enabled = False ' Disable undo.
              DragBoxPictureBox_1.Location = New System.Drawing.Point(0, 0)
              DragBoxPictureBox_1.Height = 1
              DragBoxPictureBox_1.Width = 1
              DragBoxPictureBox_1.Invalidate(False)
            End If
            found = True

            ' Refresh stack.
            Me.Controls(i).Invalidate(False)
          End If
        End If
      End If
    Next i
    If Not found AndAlso Not m_settings.Outline Then ' Not on dropable control or no card match, return to original.
      If m_dragStack > 7 Then ' Aces.
        m_aceStackLengths((m_dragStack - 8)) += 1
      ElseIf m_dragStack = 7 Then ' Drop panel.
        m_dropLength += 1
      Else
        m_stackLengths(m_dragStack) += m_dragLength
      End If
      ' Refresh stack.
      If m_dragStack < 7 Then
        Me.Invalidate(New System.Drawing.Rectangle(m_dragStartX, m_dragStartY, m_cardWidth, m_cardHeight + m_large * m_dragLength), True)
      ElseIf m_dragStack = 7 Then
        Me.Invalidate(New System.Drawing.Rectangle(m_dragStartX, m_dragStartY, m_cardWidth, m_cardHeight), True)
      Else
        Me.Invalidate(New System.Drawing.Rectangle(m_dragStartX, m_dragStartY, m_cardWidth, m_cardHeight), True)
      End If
    ElseIf found AndAlso m_settings.Outline Then ' Remove from first stack.
      If m_dragStack > 7 Then ' Aces.
        m_aceStackLengths((m_dragStack - 8)) -= 1
      ElseIf m_dragStack = 7 Then ' Drop panel.
        m_dropLength -= 1
      Else
        m_stackLengths(m_dragStack) -= m_dragLength
      End If
      ' Refresh stack.
      If m_dragStack < 7 Then
        Me.InvalidateStack(m_dragStack)
      Else ' Aces or drop panel.
        Me.Invalidate(True)
      End If
    End If
    ' Reset drag box.
    DragBoxPictureBox_1.Size = New System.Drawing.Size(0, 0)
    DragBoxPictureBox_2.Size = New System.Drawing.Size(0, 0)
    DragBoxPictureBox_3.Size = New System.Drawing.Size(0, 0)
    DragBoxPictureBox_4.Size = New System.Drawing.Size(0, 0)
    m_dragLength = 0 ' Note data is still in stack.
    m_dragging = False

    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "Menu Item Methods"

  Private Sub MenuGameDeal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuGameDeal.Click
    ' Deal m_winParabola new game.
    Deal()
  End Sub

  Private Sub MenuGameUndo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuGameUndo.Click

    ' Undo 1 move.

    Select Case m_undoType
      Case 0 ' Deal m_winParabola card (or three if not deal one).

        m_drawing = False

        ' Put card(s) back.
        If m_settings.DrawOne Then
          If m_deckLength = -1 Then
            m_deckLength = 0
          End If
          m_deckLength += 1
          m_dropLength -= 1
        Else
          m_deckLength += CInt(m_undo.GetValue(0, 0))
          m_dropLength -= CInt(m_undo.GetValue(0, 0))
          If CInt(m_undo.GetValue(0, 1)) = 1 Then
            m_drop.SetValue(m_xBigShift, 2, m_dropLength - 1)
            m_drop.SetValue(m_yShift, 3, m_dropLength - 1)
          End If
          If CInt(m_undo.GetValue(0, 1)) = 2 Then
            m_drop.SetValue(m_xBigShift, 2, m_dropLength - 2)
            m_drop.SetValue(m_yShift, 3, m_dropLength - 2)
            m_drop.SetValue(2 * m_xBigShift, 2, m_dropLength - 1)
            m_drop.SetValue(2 * m_yShift, 3, m_dropLength - 1)
          End If
        End If

        ' Refresh stacks.
        If m_deckLength = 1 OrElse m_deckLength = 11 OrElse m_deckLength = 21 Then
          DeckToDealPictureBox.Invalidate(False)
        End If
        InvalidateStack(7) ' DropPanelPictureBox.

      Case 1 ' Drag drop.
        Dim dragfrom, dragto, dragquantity As Integer
        dragfrom = CInt(m_undo.GetValue(1, 0))
        dragto = CInt(m_undo.GetValue(1, 1))
        dragquantity = CInt(m_undo.GetValue(1, 2))
        ' Add cards to old stack.
        If dragfrom < 7 Then ' Stacks.
          ' Add back to stack.
          m_stackLengths(dragfrom) += dragquantity
          ' Scoring.
          If dragto < 7 AndAlso m_settings.Scoring = Scoring.Standard Then
            m_score -= 10
          ElseIf dragto < 7 AndAlso (m_settings.Scoring = Scoring.Vegas OrElse m_settings.Scoring = Scoring.VegasCumulative) Then
            m_score -= 5
          End If
        ElseIf dragfrom = 7 Then ' DropPanelPictureBox.
          m_dropLength += 1
          ' Scoring.
          If dragto < 7 AndAlso m_settings.Scoring = Scoring.Standard Then
            m_score -= 10
          ElseIf dragto < 7 AndAlso (m_settings.Scoring = Scoring.Vegas OrElse m_settings.Scoring = Scoring.VegasCumulative) Then
            m_score -= 5
          ElseIf dragto > 6 AndAlso m_settings.Scoring = Scoring.Standard Then
            m_score -= 5
          End If
        Else ' Ace stacks.
          m_aceStackLengths((dragfrom - 8)) += 1
          ' Scoring.
          If dragto > 6 AndAlso m_settings.Scoring = Scoring.Standard Then
            m_score += 15
          ElseIf dragto > 6 AndAlso (m_settings.Scoring = Scoring.Vegas OrElse m_settings.Scoring = Scoring.VegasCumulative) Then
            m_score += 5
          End If
        End If
        If m_settings.Scoring <> Scoring.None Then
          UpdateStatus()
        End If
        ' Remove cards from new stack.
        If dragto > 2 AndAlso dragto < 7 Then ' Aces.
          m_aceStackLengths((dragto - 3)) -= 1
        ElseIf dragto > 6 AndAlso dragto < 14 Then ' Stacks.
          m_stackLengths((dragto - 7)) -= dragquantity
        End If
        ' Refresh drag from.
        InvalidateStack(dragfrom)

        ' Refresh drag to.
        If dragto < 7 Then ' Aces.
          InvalidateStack((dragto + 5))
        ElseIf dragto > 6 Then ' Stacks.
          InvalidateStack((dragto - 7))
        End If

      Case 2 ' Extra...

      Case 3 ' Extra...

      Case 4 ' Drop 1 card on aces from stack or DropPanelPictureBox from double click.
        ' Take off aces.
        m_aceStackLengths(CInt(m_undo.GetValue(4, 0))) -= 1

        ' Scoring.
        If m_settings.Scoring = Scoring.Standard Then
          m_score -= 10
        ElseIf m_settings.Scoring = Scoring.Vegas OrElse m_settings.Scoring = Scoring.VegasCumulative Then
          m_score -= 5
        End If
        If m_settings.Scoring <> Scoring.None Then
          UpdateStatus()
        End If
        ' Replace card.
        If CInt(m_undo.GetValue(4, 1)) = 7 Then
          m_dropLength += 1
        Else
          m_stackLengths(CInt(m_undo.GetValue(4, 1))) += 1
        End If
        ' Refresh ace drop.
        If CInt(m_undo.GetValue(4, 0)) < 4 Then
          InvalidateStack((CInt(m_undo.GetValue(4, 0)) + 8))
        End If
        ' Refresh stack.
        If CInt(m_undo.GetValue(4, 1)) < 7 Then
          InvalidateStack(CInt(m_undo.GetValue(4, 1)))
        End If
        ' Refresh DropPanelPictureBox.
        InvalidateStack(7)

      Case 5 ' Flip m_winParabola card.
        ' Set flip bit.
        m_stacks.SetValue(0, CInt(m_undo.GetValue(5, 0)), 4, m_stackLengths(CInt(m_undo.GetValue(5, 0))) - 1)

        ' Scoring.
        If m_settings.Scoring = Scoring.Standard Then
          m_score -= 5
          UpdateStatus()
        End If

        ' Refresh stack.
        If CInt(m_undo.GetValue(5, 0)) < 7 Then
          InvalidateStack(CInt(m_undo.GetValue(5, 0)))
        End If

      Case 6 ' Flip over deck for drawing.
        m_cycleDeck -= 1
        m_dropLength = m_deckLength ' Reset m_dropLength to # of cards in deck.
        m_deckLength = -1  ' To show empty image.
        m_drawing = False

        ' Scoring.
        If m_settings.Scoring = Scoring.Standard AndAlso m_cycleDeck > 2 AndAlso Not m_settings.DrawOne Then
          m_score += 20
        ElseIf m_settings.Scoring = Scoring.Standard AndAlso m_cycleDeck > 0 AndAlso m_settings.DrawOne Then
          m_score += 100
        End If
        If m_settings.Scoring <> Scoring.None Then
          UpdateStatus()
        End If
        ' Refresh.
        DropPanelPictureBox.Invalidate(New System.Drawing.Region(New System.Drawing.Rectangle(0, 0, DropPanelPictureBox.Width, DropPanelPictureBox.Height)))
        DeckToDealPictureBox.Invalidate(False)

      Case Else

    End Select

    MenuGameUndo.Enabled = False

  End Sub

  Private Sub MenuGameDeck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuGameDeck.Click

    ' Open deck dialog.

    Dim dialog As CardBackDialog = New CardBackDialog
    dialog.Cardback = m_settings.CardBack
    If dialog.ShowDialog(Me) = DialogResult.OK Then
      m_settings.CardBack = dialog.Cardback
      Deal()
    End If

  End Sub

  Private Sub MenuGameOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuGameOptions.Click

    ' Open options dialog box.

    Dim dialog As OptionsDialog = New OptionsDialog
    dialog.Draw = CType(IIf(m_settings.DrawOne, Draw.One, Draw.Three), Draw)
    dialog.Scoring = m_settings.Scoring
    dialog.TimedGame = m_settings.TimedGame
    dialog.StatusBar = m_settings.ViewStatusBar
    dialog.OutlineDragging = m_settings.Outline

    If dialog.ShowDialog(Me) = DialogResult.OK Then
      ' Update options.
      m_settings.DrawOne = dialog.Draw = Draw.One
      m_settings.Scoring = dialog.Scoring
      m_settings.TimedGame = dialog.TimedGame
      m_settings.Outline = dialog.OutlineDragging
      m_settings.ViewStatusBar = dialog.StatusBar

      ' Check if we need to redeal.
      If dialog.Redeal Then
        If dialog.Scoring <> m_settings.Scoring Then
          m_score = 0
        End If
        Deal()
      Else
        UpdateStatus()
      End If
    End If

  End Sub

  Private Sub MenuGameExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuGameExit.Click

    ' Exit game.
    Me.Close()

  End Sub

  Private Sub menuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItem1.Click
    MoveAllPossibleCardsUp()
  End Sub

  Sub MenuHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuHelpAbout.Click
    ShellAbout(Me.Handle, "Solitaire", "Developed by Cory Smith.  Based on C# version by Christine Morin (with tweaks by Chris Sells).", Me.Icon.Handle)
  End Sub

#End Region

#Region "Single Click Methods - Flip Cards"

  Private Sub DoClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal stack As Integer)

    If m_stackLengths(stack) <> 0 AndAlso CInt(m_stacks.GetValue(stack, 4, m_stackLengths(stack) - 1)) = 0 Then

      m_stacks.SetValue(1, stack, 4, m_stackLengths(stack) - 1)

      ' Scoring.
      If m_settings.Scoring = Scoring.Standard Then
        m_score += 5
        UpdateStatus()
      End If

      ' Set undo info - NOT IMPLEMENTED IN REAL SOLITAIRE.
      'm_undo.SetValue(stack, 5, 0)
      'm_undoType = 5
      'MenuGameUndo.Enabled = True
      MenuGameUndo.Enabled = False

      ' Refresh stack.
      InvalidateStack(stack)
    End If

  End Sub

  Private Sub StackPictureBox_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackPictureBox_0.Click
    DoClick(sender, e, 0)
  End Sub

  Private Sub StackPictureBox_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackPictureBox_1.Click
    DoClick(sender, e, 1)
  End Sub

  Private Sub StackPictureBox_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackPictureBox_2.Click
    DoClick(sender, e, 2)
  End Sub

  Private Sub StackPictureBox_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackPictureBox_3.Click
    DoClick(sender, e, 3)
  End Sub

  Private Sub StackPictureBox_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackPictureBox_4.Click
    DoClick(sender, e, 4)
  End Sub

  Private Sub StackPictureBox_5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackPictureBox_5.Click
    DoClick(sender, e, 5)
  End Sub

  Private Sub StackPictureBox_6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackPictureBox_6.Click
    DoClick(sender, e, 6)
  End Sub

#End Region

#Region "DoubleClick Methods - Send to ace drops."

  Private Sub DoDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal stack As Integer)
    Dim x, y, xRight, yBottom, suit, cardValue, i As Integer
    If stack = 7 AndAlso m_dropLength <> 0 OrElse (stack <> 7 AndAlso m_stackLengths(stack) <> 0) Then ' Stack not empty.
      If stack = 7 Then ' Drop box.
        suit = CInt(m_drop.GetValue(0, m_dropLength - 1))
        cardValue = CInt(m_drop.GetValue(1, m_dropLength - 1))
        x = CInt(m_drop.GetValue(2, m_dropLength - 1))
        y = CInt(m_drop.GetValue(3, m_dropLength - 1))
      Else ' Stacks.
        suit = CInt(m_stacks.GetValue(stack, 0, m_stackLengths(stack) - 1))
        cardValue = CInt(m_stacks.GetValue(stack, 1, m_stackLengths(stack) - 1))
        x = CInt(m_stacks.GetValue(stack, 2, m_stackLengths(stack) - 1))
        y = CInt(m_stacks.GetValue(stack, 3, m_stackLengths(stack) - 1))
      End If

      xRight = x + m_cardWidth
      yBottom = y + m_cardHeight

      ' Check if mouse is over last card.
      If m_mouseX > x AndAlso m_mouseX < xRight AndAlso m_mouseY > y AndAlso m_mouseY < yBottom Then
        If cardValue = 0 Then ' Ace.
          i = 0
          While i < 4
            If m_aceStackLengths(i) = 0 Then
              m_aceStacks.SetValue(suit, i, 0, 0) ' Set suit.
              m_aceStacks.SetValue(cardValue, i, 1, 0) ' Set card value.
              m_aceStackLengths(i) += 1 ' Increment ace stack length.
              If stack = 7 Then ' Drop box.
                m_dropLength -= 1
              Else ' Stacks
                m_stackLengths(stack) -= 1
              End If
              ' Scoring.
              If m_settings.Scoring = Scoring.Standard Then
                m_score += 10
              ElseIf m_settings.Scoring = Scoring.Vegas OrElse m_settings.Scoring = Scoring.VegasCumulative Then
                m_score += 5
              End If
              If m_settings.Scoring <> Scoring.None Then
                UpdateStatus()
              End If
              ' Refresh stack.
              InvalidateStack(stack)

              ' Refresh aces.
              InvalidateStack((i + 8))

              ' Set undo info.
              m_undoType = 4
              m_undo.SetValue(i, 4, 0)
              m_undo.SetValue(stack, 4, 1)
              MenuGameUndo.Enabled = True

              i = 3 ' Exit loop.
            End If
            i += 1
          End While
        Else ' Non-Ace.
          i = 0
          While i < 4
            If m_aceStackLengths(i) <> 0 AndAlso CType(m_aceStacks.GetValue(i, 0, m_aceStackLengths(i) - 1), System.Int32) = suit AndAlso CType(m_aceStacks.GetValue(i, 1, m_aceStackLengths(i) - 1), System.Int32) = cardValue - 1 Then
              m_aceStacks.SetValue(suit, i, 0, m_aceStackLengths(i)) ' Set suit.
              m_aceStacks.SetValue(cardValue, i, 1, m_aceStackLengths(i)) ' Set card value.
              m_aceStackLengths(i) += 1 ' Increment ace stack length.
              If stack = 7 Then ' Drop box.
                m_dropLength -= 1
              Else ' Stacks.
                m_stackLengths(stack) -= 1
              End If
              ' Refresh stack.
              InvalidateStack(stack)

              ' Refresh aces.
              InvalidateStack((i + 8))

              ' Scoring.
              If m_settings.Scoring = Scoring.Standard Then
                m_score += 10
              ElseIf m_settings.Scoring = Scoring.Vegas OrElse m_settings.Scoring = Scoring.VegasCumulative Then
                m_score += 5
              End If
              If m_settings.Scoring <> Scoring.None Then
                UpdateStatus()
              End If
              ' Set undo info.
              m_undoType = 4
              m_undo.SetValue(i, 4, 0)
              m_undo.SetValue(stack, 4, 1)
              MenuGameUndo.Enabled = True

              If m_aceStackLengths(0) + m_aceStackLengths(1) + m_aceStackLengths(2) + m_aceStackLengths(3) = 52 Then ' Win.
                m_win = True
                MenuGameUndo.Enabled = False ' Disable undo.
                DragBoxPictureBox_1.Location = New System.Drawing.Point(0, 0)
                DragBoxPictureBox_1.Height = 1
                DragBoxPictureBox_1.Width = 1
                DragBoxPictureBox_1.Invalidate(False)
              End If

              i = 3
            End If
            i += 1
          End While
        End If
      End If
    Else ' Stack is empty.
      ' Do nothing.
    End If

  End Sub

  Private Sub StackPictureBox_0_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackPictureBox_0.DoubleClick
    DoDoubleClick(sender, e, 0)
  End Sub

  Private Sub StackPictureBox_1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackPictureBox_1.DoubleClick
    DoDoubleClick(sender, e, 1)
  End Sub

  Private Sub StackPictureBox_2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackPictureBox_2.DoubleClick
    DoDoubleClick(sender, e, 2)
  End Sub

  Private Sub StackPictureBox_3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackPictureBox_3.DoubleClick
    DoDoubleClick(sender, e, 3)
  End Sub

  Private Sub StackPictureBox_4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackPictureBox_4.DoubleClick
    DoDoubleClick(sender, e, 4)
  End Sub

  Private Sub StackPictureBox_5_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackPictureBox_5.DoubleClick
    DoDoubleClick(sender, e, 5)
  End Sub

  Private Sub StackPictureBox_6_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackPictureBox_6.DoubleClick
    DoDoubleClick(sender, e, 6)
  End Sub

  Private Sub DropPanelPictureBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropPanelPictureBox.DoubleClick
    DoDoubleClick(sender, e, 7)
  End Sub

#End Region

#Region "Win Effect"

  Private Sub MenuGameWin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuGameWin.Click

    m_win = True

    For index As Integer = 0 To 12
      m_aceStacks.SetValue(0, 0, 0, index) ' Suit.
      m_aceStacks.SetValue(index, 0, 1, index) ' Card value.
      m_aceStacks.SetValue(1, 1, 0, index) ' Suit.
      m_aceStacks.SetValue(index, 1, 1, index) ' Card value.
      m_aceStacks.SetValue(2, 2, 0, index) ' Suit.
      m_aceStacks.SetValue(index, 2, 1, index) ' Card value.
      m_aceStacks.SetValue(3, 3, 0, index) ' Suit.
      m_aceStacks.SetValue(index, 3, 1, index) ' Card value.
    Next

    m_aceStackLengths(0) = 13
    m_aceStackLengths(1) = 13
    m_aceStackLengths(2) = 13
    m_aceStackLengths(3) = 13

    m_stackLengths(0) = 0
    m_stackLengths(1) = 0
    m_stackLengths(2) = 0
    m_stackLengths(3) = 0
    m_stackLengths(4) = 0
    m_stackLengths(5) = 0
    m_stackLengths(6) = 0

    m_dropLength = 0
    m_deckLength = 0

    DragBoxPictureBox_1.Location = New System.Drawing.Point(200, 200)
    DragBoxPictureBox_1.Height = 35
    DragBoxPictureBox_1.Width = 35

    DragBoxPictureBox_1.Invalidate(False)

  End Sub

  Private Sub Win(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    If Not m_win2 Then

      ' Set up drawing surface. Using drag box.
      DragBoxPictureBox_1.Location = New System.Drawing.Point(0, 0)
      DragBoxPictureBox_1.Width = Me.Width - 8
      DragBoxPictureBox_1.Height = Me.Height - 54

      ' Get ace stack locatons
      m_aceLocation.SetValue(AcePictureBox_0.Location.X, 0, 0)
      m_aceLocation.SetValue(AcePictureBox_0.Location.Y, 1, 0)
      m_aceLocation.SetValue(AcePictureBox_1.Location.X, 0, 1)
      m_aceLocation.SetValue(AcePictureBox_1.Location.Y, 1, 1)
      m_aceLocation.SetValue(AcePictureBox_2.Location.X, 0, 2)
      m_aceLocation.SetValue(AcePictureBox_2.Location.Y, 1, 2)
      m_aceLocation.SetValue(AcePictureBox_3.Location.X, 0, 3)
      m_aceLocation.SetValue(AcePictureBox_3.Location.Y, 1, 3)

      ' Get suits.
      m_suit(0) = CInt(m_aceStacks.GetValue(0, 0, 0))
      m_suit(1) = CInt(m_aceStacks.GetValue(1, 0, 0))
      m_suit(2) = CInt(m_aceStacks.GetValue(2, 0, 0))
      m_suit(3) = CInt(m_aceStacks.GetValue(3, 0, 0))

      m_win2 = True
      m_winX = CInt(m_aceLocation.GetValue(0, 0))
      m_winY = CInt(m_aceLocation.GetValue(1, 0))
      m_winStack = 0
      m_winCard = 12

    End If

    ' Fix transparency issue.
    e.Graphics.FillRegion(New System.Drawing.SolidBrush(System.Drawing.Color.White), New System.Drawing.Region(New System.Drawing.Rectangle(m_winX, m_winY, m_cardWidth, m_cardHeight)))

    If m_suit(m_winStack) = 0 Then ' Spades.
      e.Graphics.DrawImage(SpadesImageList.Images(m_winCard), m_winX, m_winY)
    ElseIf m_suit(m_winStack) = 1 Then ' Diamonds.
      e.Graphics.DrawImage(DiamondsImageList.Images(m_winCard), m_winX, m_winY)
    ElseIf m_suit(m_winStack) = 2 Then ' Clubs.
      e.Graphics.DrawImage(ClubsImageList.Images(m_winCard), m_winX, m_winY)
    Else ' Hearts.
      e.Graphics.DrawImage(HeartsImageList.Images(m_winCard), m_winX, m_winY)
    End If

    WinAlgorithm()

    ' Check if at end of window.
    If m_winY + m_cardHeight >= DragBoxPictureBox_1.Height Then 'do new m_bounce
      m_bounce = True
    End If
    If m_winX + m_cardWidth <= 0 OrElse m_winX >= DragBoxPictureBox_1.Width Then
      If m_winStack = 3 Then
        ' Done with win effect.
        If m_winCard = 0 Then
          m_win = False
          ' Clear drag box.
          DragBoxPictureBox_1.Invalidate()
          ' Reset variables.
          m_win2 = False
          ' Play again dialog.
          Dim dialog As New DealAgainDialog
          If dialog.ShowDialog(Me) = DialogResult.Yes Then
            Deal()
          End If
        Else
          m_winCard -= 1
          m_winStack = 0
          m_newWinStack = True
          m_winX = CInt(m_aceLocation.GetValue(0, m_winStack))
          m_winY = CInt(m_aceLocation.GetValue(1, m_winStack))
        End If
      ElseIf m_winCard <> 0 OrElse m_winStack <> 3 Then
        m_winStack += 1
        m_newWinStack = True
        m_winX = CInt(m_aceLocation.GetValue(0, m_winStack))
        m_winY = CInt(m_aceLocation.GetValue(1, m_winStack))
      End If
    End If
    DragBoxPictureBox_1.Invalidate(New System.Drawing.Region(New System.Drawing.Rectangle(m_winX, m_winY, m_cardWidth, m_cardHeight)), False)
    System.Threading.Thread.Sleep(7)
  End Sub

  Private Sub WinAlgorithm()

    Dim xint1 As Integer = 0
    Dim xint2 As Integer = 0
    Dim ymultrand As Integer = 0
    Dim z As Single = 0

    ' NOTE: CARTESIAN COORDINATES ARE REVERSE POSITIVE AND NEGATIVE: 
    '       to correct, won't make parabola negative.
    ' PARABOLA FORMULA: m_winY = m_winParabola * (m_winX - m_xVertex) ^ 2 + m_yVertex.
    If m_newWinStack Then ' On new stack, must reset variables.

      m_newWinStack = False

      ' Pick m_winParabola vertex somewhere in window above 
      m_xVertex = m_random.Next(0, 2)
      If m_xVertex = 0 Then
        m_xVertex = m_winX + 24
      Else
        m_xVertex = m_winX - 24
      End If
      m_yVertex = m_random.Next(-m_cardWidth, m_winY)

      ' Set m_xMovement (pixels, random), compensate for non-true randomness.
      Dim i As Integer
      i = m_random.Next(0, 4)
      If i = 0 Then
        m_xMovement = m_random.Next(-3, -1)
      ElseIf i = 1 Then
        m_xMovement = m_random.Next(2, 4)
      ElseIf i = 2 Then
        i = m_random.Next(0, 2)
        If i = 0 Then
          m_xMovement = m_random.Next(-4, 0)
        Else
          m_xMovement = m_random.Next(-4, -1)
        End If
      Else
        i = m_random.Next(0, 2)
        If i = 0 Then
          m_xMovement = m_random.Next(1, 5)
        Else
          m_xMovement = m_random.Next(2, 5)
        End If
      End If

      ' Set m_yMultiplier (4/3, 5/4, or 6/5; float).
      ymultrand = m_random.Next(3, 7)
      m_yMultiplier = (CSng(ymultrand) + 1) / CSng(ymultrand)

      z = CSng(m_winX) - CSng(m_xVertex)
      m_winParabola = CSng(CSng(m_winY) - CSng(m_yVertex)) / (z * z)

    ElseIf m_bounce Then ' Same stack bounce.

      Dim newyvertex As Integer = 0
      Dim newxvertex As Integer = 0

      ' Get new m_yVertex, shift for inverted cartesian coordinates, take percentage, and revert.
      newyvertex = CInt(System.Math.Ceiling(CSng(DragBoxPictureBox_1.Height) - (CInt(CSng(DragBoxPictureBox_1.Height) - CSng(m_yVertex))) \ CInt(m_yMultiplier)))

      ' formula: solve for m_xVertex (note - will get 2 answers keep greater answer if horizontal
      '          move is positive, else keep lesser answer).
      '
      ' Set old = new:
      '   m_winParabola(m_winX - m_xVertex)(m_winX - m_xVertex) + m_yVertex = m_winParabola(m_winX - newxvertex)(m_winX - newxvertex) + newyvertex.
      ' solve for newxvertex:
      '   newxvertex = -Sqrt((m_winParabola(m_winX - m_xVertex)(m_winX - m_xVertex) + m_yVertex - newyvertex) / m_winParabola) + m_winX.
      z = (m_winParabola * CSng(m_winX - m_xVertex) * (m_winX - m_xVertex) + CSng(m_yVertex) - CSng(newyvertex)) / m_winParabola
      If z < 0 OrElse DragBoxPictureBox_1.Height - newyvertex - m_cardHeight < 6 Then ' Too m_small of m_winParabola m_bounce, reduce to 4/5ths of m_winParabola bounce.
        newyvertex = m_yVertex + 4
        z = (m_winParabola * CSng(m_winX - m_xVertex) * (m_winX - m_xVertex) + CSng(m_yVertex) - CSng(newyvertex)) / m_winParabola
      End If

      xint1 = CInt(-System.Math.Sqrt(z) + m_winX)
      xint2 = CInt(System.Math.Sqrt(z) + m_winX)

      If m_xMovement > 0 AndAlso xint1 > xint2 Then
        newxvertex = xint1
      ElseIf m_xMovement > 0 AndAlso xint2 > xint1 Then
        newxvertex = xint2
      ElseIf m_xMovement < 0 AndAlso xint1 < xint2 Then
        newxvertex = xint1
      ElseIf m_xMovement < 0 AndAlso xint2 < xint1 Then
        newxvertex = xint2
      ElseIf m_xMovement < 0 AndAlso xint1 = xint2 AndAlso xint1 < m_xVertex Then
        newxvertex = xint1
      ElseIf m_xMovement > 0 AndAlso xint1 = xint2 AndAlso xint1 > m_xVertex Then
        newxvertex = xint1
      Else
        If m_xMovement < 0 Then
          newxvertex = m_xVertex - 1
        End If
        If m_xMovement > 0 Then
          newxvertex = m_xVertex - 1
        End If
      End If
      ' Update vertices.
      m_xVertex = newxvertex
      m_yVertex = newyvertex
    End If
    ' Update m_winX.
    m_winX += m_xMovement

    ' Update m_winY.
    z = CSng(m_winX - m_xVertex)
    If m_winParabola * z * z + CSng(m_yVertex) > m_winY AndAlso m_bounce Then
      m_winY = m_winY 'BUG: Shouldn't get here.
    Else
      m_winY = CInt(m_winParabola * z * z + CSng(m_yVertex))
    End If
    m_bounce = False

  End Sub

#End Region

  Private Sub Solitaire_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

    If EnhancedMode Then
      m_settings.Location = Me.Location
      m_settings.Size = Me.Size
    Else
      m_settings.Location = Location.Empty
      m_settings.Size = Size.Empty
    End If
    Settings.Persist(m_settings)

  End Sub

  Private Sub MenuHelpContents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuHelpContents.Click
    Me.Refresh() ' To handle a slight refresh bug.
    Me.Cursor = Cursors.WaitCursor
    Help.ShowHelp(Me, "sol.chm")
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub MenuHelpSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuHelpSearch.Click
    Me.Refresh() ' To handle a slight refresh bug.
    Me.Cursor = Cursors.WaitCursor
    Help.ShowHelp(Me, "sol.chm", HelpNavigator.Index)
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub MenuHelpHowto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuHelpHowto.Click
    Me.Refresh() ' To handle a slight refresh bug.
    Me.Cursor = Cursors.WaitCursor
    Help.ShowHelp(Me, "nthelp.chm")
    Me.Cursor = Cursors.Default
  End Sub

End Class