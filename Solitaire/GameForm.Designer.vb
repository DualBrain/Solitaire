<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GameForm
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    components = New ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GameForm))
    ScoreToolStripStatusLabel = New ToolStripStatusLabel()
    CardSlotsImageList = New ImageList(components)
    AceSpadesImageList = New ImageList(components)
    MenuStrip1 = New MenuStrip()
    FileToolStripMenuItem = New ToolStripMenuItem()
    CheatWinToolStripMenuItem = New ToolStripMenuItem()
    DealToolStripMenuItem = New ToolStripMenuItem()
    ToolStripSeparator1 = New ToolStripSeparator()
    UndoToolStripMenuItem = New ToolStripMenuItem()
    DeckToolStripMenuItem = New ToolStripMenuItem()
    OptionsToolStripMenuItem = New ToolStripMenuItem()
    ToolStripSeparator2 = New ToolStripSeparator()
    ExitToolStripMenuItem = New ToolStripMenuItem()
    HelpToolStripMenuItem = New ToolStripMenuItem()
    ContentsToolStripMenuItem = New ToolStripMenuItem()
    SearchToolStripMenuItem = New ToolStripMenuItem()
    HowToUseToolStripMenuItem = New ToolStripMenuItem()
    ToolStripSeparator5 = New ToolStripSeparator()
    AboutToolStripMenuItem = New ToolStripMenuItem()
    HeartsImageList = New ImageList(components)
    GameStatusStrip = New StatusStrip()
    InfoToolStripStatusLabel = New ToolStripStatusLabel()
    TimeToolStripStatusLabel = New ToolStripStatusLabel()
    CardBacksImageList = New ImageList(components)
    StackPictureBox_6 = New PictureBox()
    StackPictureBox_5 = New PictureBox()
    StackPictureBox_4 = New PictureBox()
    StackPictureBox_2 = New PictureBox()
    StackPictureBox_1 = New PictureBox()
    StackPictureBox_0 = New PictureBox()
    AcePictureBox_1 = New PictureBox()
    AcePictureBox_0 = New PictureBox()
    DeckToDealPictureBox = New PictureBox()
    SpadesImageList = New ImageList(components)
    ClubsImageList = New ImageList(components)
    StackPictureBox_3 = New PictureBox()
    AcePictureBox_3 = New PictureBox()
    DropPanelPictureBox = New PictureBox()
    GameTimer = New Timer(components)
    DragBoxPictureBox_1 = New PictureBox()
    DiamondsImageList = New ImageList(components)
    DragBoxPictureBox_4 = New PictureBox()
    DragBoxPictureBox_3 = New PictureBox()
    DragBoxPictureBox_2 = New PictureBox()
    AcePictureBox_2 = New PictureBox()
    MenuStrip1.SuspendLayout()
    GameStatusStrip.SuspendLayout()
    CType(StackPictureBox_6, ComponentModel.ISupportInitialize).BeginInit()
    CType(StackPictureBox_5, ComponentModel.ISupportInitialize).BeginInit()
    CType(StackPictureBox_4, ComponentModel.ISupportInitialize).BeginInit()
    CType(StackPictureBox_2, ComponentModel.ISupportInitialize).BeginInit()
    CType(StackPictureBox_1, ComponentModel.ISupportInitialize).BeginInit()
    CType(StackPictureBox_0, ComponentModel.ISupportInitialize).BeginInit()
    CType(AcePictureBox_1, ComponentModel.ISupportInitialize).BeginInit()
    CType(AcePictureBox_0, ComponentModel.ISupportInitialize).BeginInit()
    CType(DeckToDealPictureBox, ComponentModel.ISupportInitialize).BeginInit()
    CType(StackPictureBox_3, ComponentModel.ISupportInitialize).BeginInit()
    CType(AcePictureBox_3, ComponentModel.ISupportInitialize).BeginInit()
    CType(DropPanelPictureBox, ComponentModel.ISupportInitialize).BeginInit()
    CType(DragBoxPictureBox_1, ComponentModel.ISupportInitialize).BeginInit()
    CType(DragBoxPictureBox_4, ComponentModel.ISupportInitialize).BeginInit()
    CType(DragBoxPictureBox_3, ComponentModel.ISupportInitialize).BeginInit()
    CType(DragBoxPictureBox_2, ComponentModel.ISupportInitialize).BeginInit()
    CType(AcePictureBox_2, ComponentModel.ISupportInitialize).BeginInit()
    SuspendLayout()
    ' 
    ' ScoreToolStripStatusLabel
    ' 
    ScoreToolStripStatusLabel.Name = "ScoreToolStripStatusLabel"
    ScoreToolStripStatusLabel.Size = New Size(48, 17)
    ScoreToolStripStatusLabel.Text = "Score: 0"
    ' 
    ' CardSlotsImageList
    ' 
    CardSlotsImageList.ColorDepth = ColorDepth.Depth16Bit
    CardSlotsImageList.ImageStream = CType(resources.GetObject("CardSlotsImageList.ImageStream"), ImageListStreamer)
    CardSlotsImageList.TransparentColor = Color.Transparent
    CardSlotsImageList.Images.SetKeyName(0, "")
    CardSlotsImageList.Images.SetKeyName(1, "")
    CardSlotsImageList.Images.SetKeyName(2, "")
    ' 
    ' AceSpadesImageList
    ' 
    AceSpadesImageList.ColorDepth = ColorDepth.Depth8Bit
    AceSpadesImageList.ImageStream = CType(resources.GetObject("AceSpadesImageList.ImageStream"), ImageListStreamer)
    AceSpadesImageList.TransparentColor = Color.Transparent
    AceSpadesImageList.Images.SetKeyName(0, "")
    AceSpadesImageList.Images.SetKeyName(1, "")
    AceSpadesImageList.Images.SetKeyName(2, "")
    AceSpadesImageList.Images.SetKeyName(3, "")
    AceSpadesImageList.Images.SetKeyName(4, "")
    AceSpadesImageList.Images.SetKeyName(5, "")
    ' 
    ' MenuStrip1
    ' 
    MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, HelpToolStripMenuItem})
    MenuStrip1.Location = New Point(0, 0)
    MenuStrip1.Name = "MenuStrip1"
    MenuStrip1.Size = New Size(694, 24)
    MenuStrip1.TabIndex = 18
    MenuStrip1.Text = "MenuStrip1"
    ' 
    ' FileToolStripMenuItem
    ' 
    FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CheatWinToolStripMenuItem, DealToolStripMenuItem, ToolStripSeparator1, UndoToolStripMenuItem, DeckToolStripMenuItem, OptionsToolStripMenuItem, ToolStripSeparator2, ExitToolStripMenuItem})
    FileToolStripMenuItem.Name = "FileToolStripMenuItem"
    FileToolStripMenuItem.Size = New Size(50, 20)
    FileToolStripMenuItem.Text = "&Game"
    ' 
    ' CheatWinToolStripMenuItem
    ' 
    CheatWinToolStripMenuItem.Name = "CheatWinToolStripMenuItem"
    CheatWinToolStripMenuItem.Size = New Size(137, 22)
    CheatWinToolStripMenuItem.Text = "Cheat - Win"
    ' 
    ' DealToolStripMenuItem
    ' 
    DealToolStripMenuItem.Name = "DealToolStripMenuItem"
    DealToolStripMenuItem.Size = New Size(137, 22)
    DealToolStripMenuItem.Text = "&Deal"
    ' 
    ' ToolStripSeparator1
    ' 
    ToolStripSeparator1.Name = "ToolStripSeparator1"
    ToolStripSeparator1.Size = New Size(134, 6)
    ' 
    ' UndoToolStripMenuItem
    ' 
    UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
    UndoToolStripMenuItem.Size = New Size(137, 22)
    UndoToolStripMenuItem.Text = "&Undo"
    ' 
    ' DeckToolStripMenuItem
    ' 
    DeckToolStripMenuItem.Name = "DeckToolStripMenuItem"
    DeckToolStripMenuItem.Size = New Size(137, 22)
    DeckToolStripMenuItem.Text = "De&ck..."
    ' 
    ' OptionsToolStripMenuItem
    ' 
    OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
    OptionsToolStripMenuItem.Size = New Size(137, 22)
    OptionsToolStripMenuItem.Text = "&Options..."
    ' 
    ' ToolStripSeparator2
    ' 
    ToolStripSeparator2.Name = "ToolStripSeparator2"
    ToolStripSeparator2.Size = New Size(134, 6)
    ' 
    ' ExitToolStripMenuItem
    ' 
    ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
    ExitToolStripMenuItem.Size = New Size(137, 22)
    ExitToolStripMenuItem.Text = "E&xit"
    ' 
    ' HelpToolStripMenuItem
    ' 
    HelpToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ContentsToolStripMenuItem, SearchToolStripMenuItem, HowToUseToolStripMenuItem, ToolStripSeparator5, AboutToolStripMenuItem})
    HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
    HelpToolStripMenuItem.Size = New Size(44, 20)
    HelpToolStripMenuItem.Text = "&Help"
    ' 
    ' ContentsToolStripMenuItem
    ' 
    ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
    ContentsToolStripMenuItem.Size = New Size(206, 22)
    ContentsToolStripMenuItem.Text = "&Contents"
    ' 
    ' SearchToolStripMenuItem
    ' 
    SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
    SearchToolStripMenuItem.Size = New Size(206, 22)
    SearchToolStripMenuItem.Text = "&Search for Help on..."
    ' 
    ' HowToUseToolStripMenuItem
    ' 
    HowToUseToolStripMenuItem.Name = "HowToUseToolStripMenuItem"
    HowToUseToolStripMenuItem.Size = New Size(206, 22)
    HowToUseToolStripMenuItem.Text = "&How to Use Help"
    ' 
    ' ToolStripSeparator5
    ' 
    ToolStripSeparator5.Name = "ToolStripSeparator5"
    ToolStripSeparator5.Size = New Size(203, 6)
    ' 
    ' AboutToolStripMenuItem
    ' 
    AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
    AboutToolStripMenuItem.Size = New Size(206, 22)
    AboutToolStripMenuItem.Text = "&About 'Classic' Solitaire..."
    ' 
    ' HeartsImageList
    ' 
    HeartsImageList.ColorDepth = ColorDepth.Depth16Bit
    HeartsImageList.ImageStream = CType(resources.GetObject("HeartsImageList.ImageStream"), ImageListStreamer)
    HeartsImageList.TransparentColor = Color.Blue
    HeartsImageList.Images.SetKeyName(0, "")
    HeartsImageList.Images.SetKeyName(1, "")
    HeartsImageList.Images.SetKeyName(2, "")
    HeartsImageList.Images.SetKeyName(3, "")
    HeartsImageList.Images.SetKeyName(4, "")
    HeartsImageList.Images.SetKeyName(5, "")
    HeartsImageList.Images.SetKeyName(6, "")
    HeartsImageList.Images.SetKeyName(7, "")
    HeartsImageList.Images.SetKeyName(8, "")
    HeartsImageList.Images.SetKeyName(9, "")
    HeartsImageList.Images.SetKeyName(10, "")
    HeartsImageList.Images.SetKeyName(11, "")
    HeartsImageList.Images.SetKeyName(12, "")
    ' 
    ' GameStatusStrip
    ' 
    GameStatusStrip.BackColor = SystemColors.Control
    GameStatusStrip.Items.AddRange(New ToolStripItem() {InfoToolStripStatusLabel, ScoreToolStripStatusLabel, TimeToolStripStatusLabel})
    GameStatusStrip.Location = New Point(0, 520)
    GameStatusStrip.Name = "GameStatusStrip"
    GameStatusStrip.Size = New Size(694, 22)
    GameStatusStrip.TabIndex = 19
    GameStatusStrip.Text = "StatusStrip1"
    ' 
    ' InfoToolStripStatusLabel
    ' 
    InfoToolStripStatusLabel.Name = "InfoToolStripStatusLabel"
    InfoToolStripStatusLabel.Size = New Size(586, 17)
    InfoToolStripStatusLabel.Spring = True
    ' 
    ' TimeToolStripStatusLabel
    ' 
    TimeToolStripStatusLabel.Name = "TimeToolStripStatusLabel"
    TimeToolStripStatusLabel.Size = New Size(45, 17)
    TimeToolStripStatusLabel.Text = "Time: 0"
    ' 
    ' CardBacksImageList
    ' 
    CardBacksImageList.ColorDepth = ColorDepth.Depth32Bit
    CardBacksImageList.ImageStream = CType(resources.GetObject("CardBacksImageList.ImageStream"), ImageListStreamer)
    CardBacksImageList.TransparentColor = Color.Fuchsia
    CardBacksImageList.Images.SetKeyName(0, "")
    CardBacksImageList.Images.SetKeyName(1, "")
    CardBacksImageList.Images.SetKeyName(2, "")
    CardBacksImageList.Images.SetKeyName(3, "")
    CardBacksImageList.Images.SetKeyName(4, "")
    CardBacksImageList.Images.SetKeyName(5, "")
    CardBacksImageList.Images.SetKeyName(6, "")
    CardBacksImageList.Images.SetKeyName(7, "")
    CardBacksImageList.Images.SetKeyName(8, "")
    CardBacksImageList.Images.SetKeyName(9, "")
    CardBacksImageList.Images.SetKeyName(10, "")
    CardBacksImageList.Images.SetKeyName(11, "")
    ' 
    ' StackPictureBox_6
    ' 
    StackPictureBox_6.Location = New Point(603, 169)
    StackPictureBox_6.Name = "StackPictureBox_6"
    StackPictureBox_6.Size = New Size(85, 140)
    StackPictureBox_6.TabIndex = 13
    StackPictureBox_6.TabStop = False
    ' 
    ' StackPictureBox_5
    ' 
    StackPictureBox_5.Location = New Point(504, 169)
    StackPictureBox_5.Name = "StackPictureBox_5"
    StackPictureBox_5.Size = New Size(85, 136)
    StackPictureBox_5.TabIndex = 12
    StackPictureBox_5.TabStop = False
    ' 
    ' StackPictureBox_4
    ' 
    StackPictureBox_4.Location = New Point(406, 169)
    StackPictureBox_4.Name = "StackPictureBox_4"
    StackPictureBox_4.Size = New Size(85, 133)
    StackPictureBox_4.TabIndex = 11
    StackPictureBox_4.TabStop = False
    ' 
    ' StackPictureBox_2
    ' 
    StackPictureBox_2.Location = New Point(209, 169)
    StackPictureBox_2.Name = "StackPictureBox_2"
    StackPictureBox_2.Size = New Size(85, 125)
    StackPictureBox_2.TabIndex = 9
    StackPictureBox_2.TabStop = False
    ' 
    ' StackPictureBox_1
    ' 
    StackPictureBox_1.Location = New Point(111, 169)
    StackPictureBox_1.Name = "StackPictureBox_1"
    StackPictureBox_1.Size = New Size(85, 122)
    StackPictureBox_1.TabIndex = 8
    StackPictureBox_1.TabStop = False
    ' 
    ' StackPictureBox_0
    ' 
    StackPictureBox_0.Location = New Point(12, 169)
    StackPictureBox_0.Name = "StackPictureBox_0"
    StackPictureBox_0.Size = New Size(85, 118)
    StackPictureBox_0.TabIndex = 7
    StackPictureBox_0.TabStop = False
    ' 
    ' AcePictureBox_1
    ' 
    AcePictureBox_1.BackColor = Color.Transparent
    AcePictureBox_1.Location = New Point(406, 43)
    AcePictureBox_1.Name = "AcePictureBox_1"
    AcePictureBox_1.Size = New Size(86, 118)
    AcePictureBox_1.TabIndex = 4
    AcePictureBox_1.TabStop = False
    ' 
    ' AcePictureBox_0
    ' 
    AcePictureBox_0.BackColor = Color.Transparent
    AcePictureBox_0.Location = New Point(307, 43)
    AcePictureBox_0.Name = "AcePictureBox_0"
    AcePictureBox_0.Size = New Size(87, 118)
    AcePictureBox_0.TabIndex = 3
    AcePictureBox_0.TabStop = False
    ' 
    ' DeckToDealPictureBox
    ' 
    DeckToDealPictureBox.BackColor = Color.Green
    DeckToDealPictureBox.Location = New Point(12, 43)
    DeckToDealPictureBox.Name = "DeckToDealPictureBox"
    DeckToDealPictureBox.Size = New Size(96, 122)
    DeckToDealPictureBox.TabIndex = 1
    DeckToDealPictureBox.TabStop = False
    ' 
    ' SpadesImageList
    ' 
    SpadesImageList.ColorDepth = ColorDepth.Depth32Bit
    SpadesImageList.ImageStream = CType(resources.GetObject("SpadesImageList.ImageStream"), ImageListStreamer)
    SpadesImageList.TransparentColor = Color.Fuchsia
    SpadesImageList.Images.SetKeyName(0, "")
    SpadesImageList.Images.SetKeyName(1, "")
    SpadesImageList.Images.SetKeyName(2, "")
    SpadesImageList.Images.SetKeyName(3, "")
    SpadesImageList.Images.SetKeyName(4, "")
    SpadesImageList.Images.SetKeyName(5, "")
    SpadesImageList.Images.SetKeyName(6, "")
    SpadesImageList.Images.SetKeyName(7, "")
    SpadesImageList.Images.SetKeyName(8, "")
    SpadesImageList.Images.SetKeyName(9, "")
    SpadesImageList.Images.SetKeyName(10, "")
    SpadesImageList.Images.SetKeyName(11, "")
    SpadesImageList.Images.SetKeyName(12, "")
    ' 
    ' ClubsImageList
    ' 
    ClubsImageList.ColorDepth = ColorDepth.Depth16Bit
    ClubsImageList.ImageStream = CType(resources.GetObject("ClubsImageList.ImageStream"), ImageListStreamer)
    ClubsImageList.TransparentColor = Color.Fuchsia
    ClubsImageList.Images.SetKeyName(0, "")
    ClubsImageList.Images.SetKeyName(1, "")
    ClubsImageList.Images.SetKeyName(2, "")
    ClubsImageList.Images.SetKeyName(3, "")
    ClubsImageList.Images.SetKeyName(4, "")
    ClubsImageList.Images.SetKeyName(5, "")
    ClubsImageList.Images.SetKeyName(6, "")
    ClubsImageList.Images.SetKeyName(7, "")
    ClubsImageList.Images.SetKeyName(8, "")
    ClubsImageList.Images.SetKeyName(9, "")
    ClubsImageList.Images.SetKeyName(10, "")
    ClubsImageList.Images.SetKeyName(11, "")
    ClubsImageList.Images.SetKeyName(12, "")
    ' 
    ' StackPictureBox_3
    ' 
    StackPictureBox_3.BackColor = Color.Transparent
    StackPictureBox_3.Location = New Point(307, 169)
    StackPictureBox_3.Name = "StackPictureBox_3"
    StackPictureBox_3.Size = New Size(86, 129)
    StackPictureBox_3.TabIndex = 10
    StackPictureBox_3.TabStop = False
    ' 
    ' AcePictureBox_3
    ' 
    AcePictureBox_3.BackColor = Color.Transparent
    AcePictureBox_3.Location = New Point(603, 43)
    AcePictureBox_3.Name = "AcePictureBox_3"
    AcePictureBox_3.Size = New Size(86, 118)
    AcePictureBox_3.TabIndex = 6
    AcePictureBox_3.TabStop = False
    ' 
    ' DropPanelPictureBox
    ' 
    DropPanelPictureBox.AllowDrop = True
    DropPanelPictureBox.BackColor = Color.Green
    DropPanelPictureBox.Location = New Point(111, 43)
    DropPanelPictureBox.Name = "DropPanelPictureBox"
    DropPanelPictureBox.Size = New Size(124, 122)
    DropPanelPictureBox.TabIndex = 17
    DropPanelPictureBox.TabStop = False
    ' 
    ' GameTimer
    ' 
    GameTimer.Enabled = True
    GameTimer.Interval = 1000
    ' 
    ' DragBoxPictureBox_1
    ' 
    DragBoxPictureBox_1.BackColor = Color.Gray
    DragBoxPictureBox_1.Location = New Point(0, 0)
    DragBoxPictureBox_1.Name = "DragBoxPictureBox_1"
    DragBoxPictureBox_1.Size = New Size(0, 0)
    DragBoxPictureBox_1.TabIndex = 14
    DragBoxPictureBox_1.TabStop = False
    ' 
    ' DiamondsImageList
    ' 
    DiamondsImageList.ColorDepth = ColorDepth.Depth8Bit
    DiamondsImageList.ImageStream = CType(resources.GetObject("DiamondsImageList.ImageStream"), ImageListStreamer)
    DiamondsImageList.TransparentColor = Color.Blue
    DiamondsImageList.Images.SetKeyName(0, "")
    DiamondsImageList.Images.SetKeyName(1, "")
    DiamondsImageList.Images.SetKeyName(2, "")
    DiamondsImageList.Images.SetKeyName(3, "")
    DiamondsImageList.Images.SetKeyName(4, "")
    DiamondsImageList.Images.SetKeyName(5, "")
    DiamondsImageList.Images.SetKeyName(6, "")
    DiamondsImageList.Images.SetKeyName(7, "")
    DiamondsImageList.Images.SetKeyName(8, "")
    DiamondsImageList.Images.SetKeyName(9, "")
    DiamondsImageList.Images.SetKeyName(10, "")
    DiamondsImageList.Images.SetKeyName(11, "")
    DiamondsImageList.Images.SetKeyName(12, "")
    ' 
    ' DragBoxPictureBox_4
    ' 
    DragBoxPictureBox_4.BackColor = Color.Gray
    DragBoxPictureBox_4.Location = New Point(0, 0)
    DragBoxPictureBox_4.Name = "DragBoxPictureBox_4"
    DragBoxPictureBox_4.Size = New Size(0, 0)
    DragBoxPictureBox_4.TabIndex = 14
    DragBoxPictureBox_4.TabStop = False
    ' 
    ' DragBoxPictureBox_3
    ' 
    DragBoxPictureBox_3.BackColor = Color.Gray
    DragBoxPictureBox_3.Location = New Point(0, 0)
    DragBoxPictureBox_3.Name = "DragBoxPictureBox_3"
    DragBoxPictureBox_3.Size = New Size(0, 0)
    DragBoxPictureBox_3.TabIndex = 14
    DragBoxPictureBox_3.TabStop = False
    ' 
    ' DragBoxPictureBox_2
    ' 
    DragBoxPictureBox_2.BackColor = Color.Gray
    DragBoxPictureBox_2.Location = New Point(0, 0)
    DragBoxPictureBox_2.Name = "DragBoxPictureBox_2"
    DragBoxPictureBox_2.Size = New Size(0, 0)
    DragBoxPictureBox_2.TabIndex = 14
    DragBoxPictureBox_2.TabStop = False
    ' 
    ' AcePictureBox_2
    ' 
    AcePictureBox_2.BackColor = Color.Transparent
    AcePictureBox_2.Location = New Point(504, 43)
    AcePictureBox_2.Name = "AcePictureBox_2"
    AcePictureBox_2.Size = New Size(87, 118)
    AcePictureBox_2.TabIndex = 5
    AcePictureBox_2.TabStop = False
    ' 
    ' GameForm
    ' 
    AutoScaleMode = AutoScaleMode.Inherit
    BackColor = Color.Green
    ClientSize = New Size(694, 542)
    Controls.Add(MenuStrip1)
    Controls.Add(GameStatusStrip)
    Controls.Add(StackPictureBox_6)
    Controls.Add(StackPictureBox_5)
    Controls.Add(StackPictureBox_4)
    Controls.Add(StackPictureBox_2)
    Controls.Add(StackPictureBox_1)
    Controls.Add(StackPictureBox_0)
    Controls.Add(AcePictureBox_1)
    Controls.Add(AcePictureBox_0)
    Controls.Add(DeckToDealPictureBox)
    Controls.Add(StackPictureBox_3)
    Controls.Add(AcePictureBox_3)
    Controls.Add(DropPanelPictureBox)
    Controls.Add(DragBoxPictureBox_1)
    Controls.Add(DragBoxPictureBox_4)
    Controls.Add(DragBoxPictureBox_3)
    Controls.Add(DragBoxPictureBox_2)
    Controls.Add(AcePictureBox_2)
    Icon = CType(resources.GetObject("$this.Icon"), Icon)
    MinimumSize = New Size(710, 581)
    Name = "GameForm"
    StartPosition = FormStartPosition.Manual
    Text = "'Classic' Solitaire"
    MenuStrip1.ResumeLayout(False)
    MenuStrip1.PerformLayout()
    GameStatusStrip.ResumeLayout(False)
    GameStatusStrip.PerformLayout()
    CType(StackPictureBox_6, ComponentModel.ISupportInitialize).EndInit()
    CType(StackPictureBox_5, ComponentModel.ISupportInitialize).EndInit()
    CType(StackPictureBox_4, ComponentModel.ISupportInitialize).EndInit()
    CType(StackPictureBox_2, ComponentModel.ISupportInitialize).EndInit()
    CType(StackPictureBox_1, ComponentModel.ISupportInitialize).EndInit()
    CType(StackPictureBox_0, ComponentModel.ISupportInitialize).EndInit()
    CType(AcePictureBox_1, ComponentModel.ISupportInitialize).EndInit()
    CType(AcePictureBox_0, ComponentModel.ISupportInitialize).EndInit()
    CType(DeckToDealPictureBox, ComponentModel.ISupportInitialize).EndInit()
    CType(StackPictureBox_3, ComponentModel.ISupportInitialize).EndInit()
    CType(AcePictureBox_3, ComponentModel.ISupportInitialize).EndInit()
    CType(DropPanelPictureBox, ComponentModel.ISupportInitialize).EndInit()
    CType(DragBoxPictureBox_1, ComponentModel.ISupportInitialize).EndInit()
    CType(DragBoxPictureBox_4, ComponentModel.ISupportInitialize).EndInit()
    CType(DragBoxPictureBox_3, ComponentModel.ISupportInitialize).EndInit()
    CType(DragBoxPictureBox_2, ComponentModel.ISupportInitialize).EndInit()
    CType(AcePictureBox_2, ComponentModel.ISupportInitialize).EndInit()
    ResumeLayout(False)
    PerformLayout()
  End Sub

  Private WithEvents StackPictureBox_0 As PictureBox
  Private WithEvents StackPictureBox_1 As PictureBox
  Private WithEvents StackPictureBox_2 As PictureBox
  Private WithEvents StackPictureBox_3 As PictureBox
  Private WithEvents StackPictureBox_4 As PictureBox
  Private WithEvents StackPictureBox_5 As PictureBox
  Private WithEvents StackPictureBox_6 As PictureBox
  Private WithEvents AcePictureBox_0 As PictureBox
  Private WithEvents AcePictureBox_1 As PictureBox
  Private WithEvents AcePictureBox_2 As PictureBox
  Private WithEvents AcePictureBox_3 As PictureBox
  Private WithEvents DeckToDealPictureBox As PictureBox
  Private WithEvents DropPanelPictureBox As PictureBox
  Private WithEvents DragBoxPictureBox_1 As PictureBox
  Private WithEvents DragBoxPictureBox_2 As PictureBox
  Private WithEvents DragBoxPictureBox_3 As PictureBox
  Private WithEvents DragBoxPictureBox_4 As PictureBox
  Private WithEvents ScoreToolStripStatusLabel As ToolStripStatusLabel
  Private WithEvents MenuStrip1 As MenuStrip
  Private WithEvents FileToolStripMenuItem As ToolStripMenuItem
  Private WithEvents DealToolStripMenuItem As ToolStripMenuItem
  Private WithEvents UndoToolStripMenuItem As ToolStripMenuItem
  Private WithEvents DeckToolStripMenuItem As ToolStripMenuItem
  Private WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
  Private WithEvents ToolStripSeparator2 As ToolStripSeparator
  Private WithEvents ExitToolStripMenuItem As ToolStripMenuItem
  Private WithEvents HelpToolStripMenuItem As ToolStripMenuItem
  Private WithEvents ContentsToolStripMenuItem As ToolStripMenuItem
  Private WithEvents HowToUseToolStripMenuItem As ToolStripMenuItem
  Private WithEvents SearchToolStripMenuItem As ToolStripMenuItem
  Private WithEvents ToolStripSeparator5 As ToolStripSeparator
  Private WithEvents AboutToolStripMenuItem As ToolStripMenuItem
  Private WithEvents GameStatusStrip As StatusStrip
  Private WithEvents InfoToolStripStatusLabel As ToolStripStatusLabel
  Private WithEvents TimeToolStripStatusLabel As ToolStripStatusLabel
  Private WithEvents CardSlotsImageList As ImageList
  Private WithEvents AceSpadesImageList As ImageList
  Private WithEvents CardBacksImageList As ImageList
  Private WithEvents HeartsImageList As ImageList
  Private WithEvents SpadesImageList As ImageList
  Private WithEvents ClubsImageList As ImageList
  Private WithEvents DiamondsImageList As ImageList
  Private WithEvents GameTimer As Timer
  Private WithEvents ToolStripSeparator1 As ToolStripSeparator
  Friend WithEvents CheatWinToolStripMenuItem As ToolStripMenuItem
End Class
