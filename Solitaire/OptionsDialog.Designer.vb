<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsDialog
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
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
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsDialog))
    OutlineDraggingCheckBox = New CheckBox()
    StatusBarCheckBox = New CheckBox()
    TimedGameCheckBox = New CheckBox()
    ScoringGroupBox = New GroupBox()
    ScoreNoneRadioButton = New RadioButton()
    ScoreVegasRadioButton = New RadioButton()
    ScoreStandardRadioButton = New RadioButton()
    DrawGroupBox = New GroupBox()
    DrawThreeRadioButton = New RadioButton()
    DrawOneRadioButton = New RadioButton()
    CancelActionButton = New Button()
    OkButton = New Button()
    CummulativeScoreCheckBox = New CheckBox()
    HelpProvider = New HelpProvider()
    ScoringGroupBox.SuspendLayout()
    DrawGroupBox.SuspendLayout()
    SuspendLayout()
    ' 
    ' OutlineDraggingCheckBox
    ' 
    OutlineDraggingCheckBox.FlatStyle = FlatStyle.System
    HelpProvider.SetHelpString(OutlineDraggingCheckBox, "Specifies that an outline of a card (rather than the actual card) appears while you drag a card to a new location.")
    OutlineDraggingCheckBox.Location = New Point(15, 144)
    OutlineDraggingCheckBox.Name = "OutlineDraggingCheckBox"
    HelpProvider.SetShowHelp(OutlineDraggingCheckBox, True)
    OutlineDraggingCheckBox.Size = New Size(130, 30)
    OutlineDraggingCheckBox.TabIndex = 4
    OutlineDraggingCheckBox.Text = "Outline dragging"
    ' 
    ' StatusBarCheckBox
    ' 
    StatusBarCheckBox.Checked = True
    StatusBarCheckBox.CheckState = CheckState.Checked
    StatusBarCheckBox.FlatStyle = FlatStyle.System
    HelpProvider.SetHelpString(StatusBarCheckBox, "Specifies whether the notification area showing the score and time played will be visible.")
    StatusBarCheckBox.Location = New Point(15, 120)
    StatusBarCheckBox.Name = "StatusBarCheckBox"
    HelpProvider.SetShowHelp(StatusBarCheckBox, True)
    StatusBarCheckBox.Size = New Size(96, 29)
    StatusBarCheckBox.TabIndex = 3
    StatusBarCheckBox.Text = "Status bar"
    ' 
    ' TimedGameCheckBox
    ' 
    TimedGameCheckBox.Checked = True
    TimedGameCheckBox.CheckState = CheckState.Checked
    TimedGameCheckBox.FlatStyle = FlatStyle.System
    HelpProvider.SetHelpString(TimedGameCheckBox, "Specifies whether the game will be timed.  To play a more challenging game, click to select Timed game.")
    TimedGameCheckBox.Location = New Point(15, 93)
    TimedGameCheckBox.Name = "TimedGameCheckBox"
    HelpProvider.SetShowHelp(TimedGameCheckBox, True)
    TimedGameCheckBox.Size = New Size(106, 29)
    TimedGameCheckBox.TabIndex = 2
    TimedGameCheckBox.Text = "Timed game"
    ' 
    ' ScoringGroupBox
    ' 
    ScoringGroupBox.Controls.Add(ScoreNoneRadioButton)
    ScoringGroupBox.Controls.Add(ScoreVegasRadioButton)
    ScoringGroupBox.Controls.Add(ScoreStandardRadioButton)
    ScoringGroupBox.FlatStyle = FlatStyle.System
    ScoringGroupBox.ForeColor = SystemColors.ActiveCaption
    ScoringGroupBox.Location = New Point(140, 14)
    ScoringGroupBox.Name = "ScoringGroupBox"
    ScoringGroupBox.Size = New Size(115, 96)
    ScoringGroupBox.TabIndex = 5
    ScoringGroupBox.TabStop = False
    ScoringGroupBox.Text = "Scoring"
    ' 
    ' ScoreNoneRadioButton
    ' 
    ScoreNoneRadioButton.FlatStyle = FlatStyle.System
    ScoreNoneRadioButton.ForeColor = SystemColors.ControlText
    HelpProvider.SetHelpString(ScoreNoneRadioButton, "Specifies the type of scoring to be used.  Click None to play without keeping score.")
    ScoreNoneRadioButton.Location = New Point(7, 63)
    ScoreNoneRadioButton.Name = "ScoreNoneRadioButton"
    HelpProvider.SetShowHelp(ScoreNoneRadioButton, True)
    ScoreNoneRadioButton.Size = New Size(97, 29)
    ScoreNoneRadioButton.TabIndex = 2
    ScoreNoneRadioButton.Text = "None"
    ' 
    ' ScoreVegasRadioButton
    ' 
    ScoreVegasRadioButton.FlatStyle = FlatStyle.System
    ScoreVegasRadioButton.ForeColor = SystemColors.ControlText
    HelpProvider.SetHelpString(ScoreVegasRadioButton, resources.GetString("ScoreVegasRadioButton.HelpString"))
    ScoreVegasRadioButton.Location = New Point(7, 39)
    ScoreVegasRadioButton.Name = "ScoreVegasRadioButton"
    HelpProvider.SetShowHelp(ScoreVegasRadioButton, True)
    ScoreVegasRadioButton.Size = New Size(97, 30)
    ScoreVegasRadioButton.TabIndex = 1
    ScoreVegasRadioButton.Text = "Vegas"
    ' 
    ' ScoreStandardRadioButton
    ' 
    ScoreStandardRadioButton.Checked = True
    ScoreStandardRadioButton.FlatStyle = FlatStyle.System
    ScoreStandardRadioButton.ForeColor = SystemColors.ControlText
    HelpProvider.SetHelpString(ScoreStandardRadioButton, "Specifies the type of scoring to be used.  Click Standard to play a game where you start the game with 0 dollars and you win 10 dollars for every card you play on a suit stack.")
    ScoreStandardRadioButton.Location = New Point(7, 16)
    ScoreStandardRadioButton.Name = "ScoreStandardRadioButton"
    HelpProvider.SetShowHelp(ScoreStandardRadioButton, True)
    ScoreStandardRadioButton.Size = New Size(97, 30)
    ScoreStandardRadioButton.TabIndex = 0
    ScoreStandardRadioButton.TabStop = True
    ScoreStandardRadioButton.Text = "Standard"
    ' 
    ' DrawGroupBox
    ' 
    DrawGroupBox.Controls.Add(DrawThreeRadioButton)
    DrawGroupBox.Controls.Add(DrawOneRadioButton)
    DrawGroupBox.FlatStyle = FlatStyle.System
    DrawGroupBox.ForeColor = SystemColors.ActiveCaption
    DrawGroupBox.Location = New Point(6, 14)
    DrawGroupBox.Name = "DrawGroupBox"
    DrawGroupBox.Size = New Size(127, 71)
    DrawGroupBox.TabIndex = 1
    DrawGroupBox.TabStop = False
    DrawGroupBox.Text = "Draw"
    ' 
    ' DrawThreeRadioButton
    ' 
    DrawThreeRadioButton.FlatStyle = FlatStyle.System
    DrawThreeRadioButton.ForeColor = SystemColors.ControlText
    HelpProvider.SetHelpString(DrawThreeRadioButton, "Specifies the number of cards drawn each time you click the deck of cards.  Click Draw One to turn over one card at a time, or click Draw Three to turn over three cards at a time.")
    DrawThreeRadioButton.Location = New Point(7, 39)
    DrawThreeRadioButton.Name = "DrawThreeRadioButton"
    HelpProvider.SetShowHelp(DrawThreeRadioButton, True)
    DrawThreeRadioButton.Size = New Size(97, 30)
    DrawThreeRadioButton.TabIndex = 1
    DrawThreeRadioButton.Text = "Draw Three"
    ' 
    ' DrawOneRadioButton
    ' 
    DrawOneRadioButton.Checked = True
    DrawOneRadioButton.FlatStyle = FlatStyle.System
    DrawOneRadioButton.ForeColor = SystemColors.ControlText
    HelpProvider.SetHelpString(DrawOneRadioButton, "Specifies the number of cards drawn each time you click the deck of cards.  Click Draw One to turn over one card at a time, or click Draw Three to turn over three cards at a time.")
    DrawOneRadioButton.Location = New Point(7, 16)
    DrawOneRadioButton.Name = "DrawOneRadioButton"
    HelpProvider.SetShowHelp(DrawOneRadioButton, True)
    DrawOneRadioButton.Size = New Size(90, 30)
    DrawOneRadioButton.TabIndex = 0
    DrawOneRadioButton.TabStop = True
    DrawOneRadioButton.Text = "Draw One"
    ' 
    ' CancelActionButton
    ' 
    CancelActionButton.DialogResult = DialogResult.Cancel
    CancelActionButton.FlatStyle = FlatStyle.System
    HelpProvider.SetHelpString(CancelActionButton, "Closes the dialog box without saving any changes you have made.")
    CancelActionButton.Location = New Point(140, 181)
    CancelActionButton.Name = "CancelActionButton"
    HelpProvider.SetShowHelp(CancelActionButton, True)
    CancelActionButton.Size = New Size(72, 30)
    CancelActionButton.TabIndex = 8
    CancelActionButton.Text = "Cancel"
    ' 
    ' OkButton
    ' 
    OkButton.DialogResult = DialogResult.OK
    OkButton.FlatStyle = FlatStyle.System
    HelpProvider.SetHelpString(OkButton, "Closes the dialog box and saves any changes you have made.")
    OkButton.Location = New Point(63, 181)
    OkButton.Name = "OkButton"
    HelpProvider.SetShowHelp(OkButton, True)
    OkButton.Size = New Size(67, 30)
    OkButton.TabIndex = 7
    OkButton.Text = "OK"
    ' 
    ' CummulativeScoreCheckBox
    ' 
    CummulativeScoreCheckBox.Enabled = False
    CummulativeScoreCheckBox.FlatStyle = FlatStyle.System
    HelpProvider.SetHelpString(CummulativeScoreCheckBox, "Only available on Vegas scoring, keeps track of your score through multiple games.")
    CummulativeScoreCheckBox.Location = New Point(140, 122)
    CummulativeScoreCheckBox.Name = "CummulativeScoreCheckBox"
    HelpProvider.SetShowHelp(CummulativeScoreCheckBox, True)
    CummulativeScoreCheckBox.Size = New Size(106, 40)
    CummulativeScoreCheckBox.TabIndex = 6
    CummulativeScoreCheckBox.Text = "Cumulative Score"
    CummulativeScoreCheckBox.TextAlign = ContentAlignment.TopLeft
    ' 
    ' Form1
    ' 
    AcceptButton = OkButton
    AutoScaleMode = AutoScaleMode.Inherit
    CancelButton = CancelActionButton
    ClientSize = New Size(260, 224)
    Controls.Add(OutlineDraggingCheckBox)
    Controls.Add(StatusBarCheckBox)
    Controls.Add(TimedGameCheckBox)
    Controls.Add(ScoringGroupBox)
    Controls.Add(DrawGroupBox)
    Controls.Add(CancelActionButton)
    Controls.Add(OkButton)
    Controls.Add(CummulativeScoreCheckBox)
    FormBorderStyle = FormBorderStyle.FixedDialog
    HelpButton = True
    MaximizeBox = False
    MaximumSize = New Size(276, 263)
    MinimizeBox = False
    MinimumSize = New Size(276, 263)
    Name = "Form1"
    ShowInTaskbar = False
    StartPosition = FormStartPosition.CenterParent
    Text = "Options"
    ScoringGroupBox.ResumeLayout(False)
    DrawGroupBox.ResumeLayout(False)
    ResumeLayout(False)
  End Sub

  Friend WithEvents OutlineDraggingCheckBox As CheckBox
  Friend WithEvents HelpProvider As HelpProvider
  Friend WithEvents StatusBarCheckBox As CheckBox
  Friend WithEvents TimedGameCheckBox As CheckBox
  Friend WithEvents ScoringGroupBox As GroupBox
  Friend WithEvents ScoreNoneRadioButton As RadioButton
  Friend WithEvents ScoreVegasRadioButton As RadioButton
  Friend WithEvents ScoreStandardRadioButton As RadioButton
  Friend WithEvents DrawGroupBox As GroupBox
  Friend WithEvents DrawThreeRadioButton As RadioButton
  Friend WithEvents DrawOneRadioButton As RadioButton
  Friend WithEvents CancelActionButton As Button
  Friend WithEvents OkButton As Button
  Friend WithEvents CummulativeScoreCheckBox As CheckBox
End Class
