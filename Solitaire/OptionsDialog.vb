Option Explicit On 
Option Strict On

Public Class OptionsDialog
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

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

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents OutlineDraggingCheckBox As System.Windows.Forms.CheckBox
  Friend WithEvents StatusBarCheckBox As System.Windows.Forms.CheckBox
  Friend WithEvents TimedGameCheckBox As System.Windows.Forms.CheckBox
  Friend WithEvents ScoringGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents ScoreNoneRadioButton As System.Windows.Forms.RadioButton
  Friend WithEvents ScoreVegasRadioButton As System.Windows.Forms.RadioButton
  Friend WithEvents ScoreStandardRadioButton As System.Windows.Forms.RadioButton
  Friend WithEvents DrawGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents DrawThreeRadioButton As System.Windows.Forms.RadioButton
  Friend WithEvents DrawOneRadioButton As System.Windows.Forms.RadioButton
  Friend WithEvents OkButton As System.Windows.Forms.Button
  Friend WithEvents CummulativeScoreCheckBox As System.Windows.Forms.CheckBox
  Friend WithEvents CancelActionButton As System.Windows.Forms.Button
  Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.OutlineDraggingCheckBox = New System.Windows.Forms.CheckBox
    Me.StatusBarCheckBox = New System.Windows.Forms.CheckBox
    Me.TimedGameCheckBox = New System.Windows.Forms.CheckBox
    Me.ScoringGroupBox = New System.Windows.Forms.GroupBox
    Me.ScoreNoneRadioButton = New System.Windows.Forms.RadioButton
    Me.ScoreVegasRadioButton = New System.Windows.Forms.RadioButton
    Me.ScoreStandardRadioButton = New System.Windows.Forms.RadioButton
    Me.DrawGroupBox = New System.Windows.Forms.GroupBox
    Me.DrawThreeRadioButton = New System.Windows.Forms.RadioButton
    Me.DrawOneRadioButton = New System.Windows.Forms.RadioButton
    Me.CancelActionButton = New System.Windows.Forms.Button
    Me.OkButton = New System.Windows.Forms.Button
    Me.CummulativeScoreCheckBox = New System.Windows.Forms.CheckBox
    Me.HelpProvider = New System.Windows.Forms.HelpProvider
    Me.ScoringGroupBox.SuspendLayout()
    Me.DrawGroupBox.SuspendLayout()
    Me.SuspendLayout()
    '
    'OutlineDraggingCheckBox
    '
    Me.OutlineDraggingCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.HelpProvider.SetHelpString(Me.OutlineDraggingCheckBox, "Specifies that an outline of a card (rather than the actual card) appears while y" & _
    "ou drag a card to a new location.")
    Me.OutlineDraggingCheckBox.Location = New System.Drawing.Point(16, 114)
    Me.OutlineDraggingCheckBox.Name = "OutlineDraggingCheckBox"
    Me.HelpProvider.SetShowHelp(Me.OutlineDraggingCheckBox, True)
    Me.OutlineDraggingCheckBox.Size = New System.Drawing.Size(108, 24)
    Me.OutlineDraggingCheckBox.TabIndex = 13
    Me.OutlineDraggingCheckBox.Text = "Outline dragging"
    '
    'StatusBarCheckBox
    '
    Me.StatusBarCheckBox.Checked = True
    Me.StatusBarCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
    Me.StatusBarCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.HelpProvider.SetHelpString(Me.StatusBarCheckBox, "Specifies whether the notification area showing the score and time played will be" & _
    " visible.")
    Me.StatusBarCheckBox.Location = New System.Drawing.Point(16, 94)
    Me.StatusBarCheckBox.Name = "StatusBarCheckBox"
    Me.HelpProvider.SetShowHelp(Me.StatusBarCheckBox, True)
    Me.StatusBarCheckBox.Size = New System.Drawing.Size(80, 24)
    Me.StatusBarCheckBox.TabIndex = 12
    Me.StatusBarCheckBox.Text = "Status bar"
    '
    'TimedGameCheckBox
    '
    Me.TimedGameCheckBox.Checked = True
    Me.TimedGameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
    Me.TimedGameCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.HelpProvider.SetHelpString(Me.TimedGameCheckBox, "Specifies whether the game will be timed.  To play a more challenging game, click" & _
    " to select Timed game.")
    Me.TimedGameCheckBox.Location = New System.Drawing.Point(16, 72)
    Me.TimedGameCheckBox.Name = "TimedGameCheckBox"
    Me.HelpProvider.SetShowHelp(Me.TimedGameCheckBox, True)
    Me.TimedGameCheckBox.Size = New System.Drawing.Size(88, 24)
    Me.TimedGameCheckBox.TabIndex = 11
    Me.TimedGameCheckBox.Text = "Timed game"
    '
    'ScoringGroupBox
    '
    Me.ScoringGroupBox.Controls.Add(Me.ScoreNoneRadioButton)
    Me.ScoringGroupBox.Controls.Add(Me.ScoreVegasRadioButton)
    Me.ScoringGroupBox.Controls.Add(Me.ScoreStandardRadioButton)
    Me.ScoringGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.ScoringGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaption
    Me.ScoringGroupBox.Location = New System.Drawing.Point(120, 8)
    Me.ScoringGroupBox.Name = "ScoringGroupBox"
    Me.ScoringGroupBox.Size = New System.Drawing.Size(96, 78)
    Me.ScoringGroupBox.TabIndex = 10
    Me.ScoringGroupBox.TabStop = False
    Me.ScoringGroupBox.Text = "Scoring"
    '
    'ScoreNoneRadioButton
    '
    Me.ScoreNoneRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.ScoreNoneRadioButton.ForeColor = System.Drawing.SystemColors.ControlText
    Me.HelpProvider.SetHelpString(Me.ScoreNoneRadioButton, "Specifies the type of scoring to be used.  Click None to play without keeping sco" & _
    "re.")
    Me.ScoreNoneRadioButton.Location = New System.Drawing.Point(6, 51)
    Me.ScoreNoneRadioButton.Name = "ScoreNoneRadioButton"
    Me.HelpProvider.SetShowHelp(Me.ScoreNoneRadioButton, True)
    Me.ScoreNoneRadioButton.Size = New System.Drawing.Size(81, 24)
    Me.ScoreNoneRadioButton.TabIndex = 2
    Me.ScoreNoneRadioButton.Text = "None"
    '
    'ScoreVegasRadioButton
    '
    Me.ScoreVegasRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.ScoreVegasRadioButton.ForeColor = System.Drawing.SystemColors.ControlText
    Me.HelpProvider.SetHelpString(Me.ScoreVegasRadioButton, "Specifies the type of scoring to be used.  Click Vegas to play a more challenging" & _
    " game.  The object of the Vegas-style game is to earn more money than your wager" & _
    ".  You start the game with a debt of 52 dollars and you win 5 dollars for every " & _
    "card you play on the suit stack.")
    Me.ScoreVegasRadioButton.Location = New System.Drawing.Point(6, 32)
    Me.ScoreVegasRadioButton.Name = "ScoreVegasRadioButton"
    Me.HelpProvider.SetShowHelp(Me.ScoreVegasRadioButton, True)
    Me.ScoreVegasRadioButton.Size = New System.Drawing.Size(81, 24)
    Me.ScoreVegasRadioButton.TabIndex = 1
    Me.ScoreVegasRadioButton.Text = "Vegas"
    '
    'ScoreStandardRadioButton
    '
    Me.ScoreStandardRadioButton.Checked = True
    Me.ScoreStandardRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.ScoreStandardRadioButton.ForeColor = System.Drawing.SystemColors.ControlText
    Me.HelpProvider.SetHelpString(Me.ScoreStandardRadioButton, "Specifies the type of scoring to be used.  Click Standard to play a game where yo" & _
    "u start the game with 0 dollars and you win 10 dollars for every card you play o" & _
    "n a suit stack.")
    Me.ScoreStandardRadioButton.Location = New System.Drawing.Point(6, 13)
    Me.ScoreStandardRadioButton.Name = "ScoreStandardRadioButton"
    Me.HelpProvider.SetShowHelp(Me.ScoreStandardRadioButton, True)
    Me.ScoreStandardRadioButton.Size = New System.Drawing.Size(81, 24)
    Me.ScoreStandardRadioButton.TabIndex = 0
    Me.ScoreStandardRadioButton.TabStop = True
    Me.ScoreStandardRadioButton.Text = "Standard"
    '
    'DrawGroupBox
    '
    Me.DrawGroupBox.Controls.Add(Me.DrawThreeRadioButton)
    Me.DrawGroupBox.Controls.Add(Me.DrawOneRadioButton)
    Me.DrawGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.DrawGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaption
    Me.DrawGroupBox.Location = New System.Drawing.Point(8, 8)
    Me.DrawGroupBox.Name = "DrawGroupBox"
    Me.DrawGroupBox.Size = New System.Drawing.Size(106, 58)
    Me.DrawGroupBox.TabIndex = 9
    Me.DrawGroupBox.TabStop = False
    Me.DrawGroupBox.Text = "Draw"
    '
    'DrawThreeRadioButton
    '
    Me.DrawThreeRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.DrawThreeRadioButton.ForeColor = System.Drawing.SystemColors.ControlText
    Me.HelpProvider.SetHelpString(Me.DrawThreeRadioButton, "Specifies the number of cards drawn each time you click the deck of cards.  Click" & _
    " Draw One to turn over one card at a time, or click Draw Three to turn over thre" & _
    "e cards at a time.")
    Me.DrawThreeRadioButton.Location = New System.Drawing.Point(6, 32)
    Me.DrawThreeRadioButton.Name = "DrawThreeRadioButton"
    Me.HelpProvider.SetShowHelp(Me.DrawThreeRadioButton, True)
    Me.DrawThreeRadioButton.Size = New System.Drawing.Size(81, 24)
    Me.DrawThreeRadioButton.TabIndex = 1
    Me.DrawThreeRadioButton.Text = "Draw Three"
    '
    'DrawOneRadioButton
    '
    Me.DrawOneRadioButton.Checked = True
    Me.DrawOneRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.DrawOneRadioButton.ForeColor = System.Drawing.SystemColors.ControlText
    Me.HelpProvider.SetHelpString(Me.DrawOneRadioButton, "Specifies the number of cards drawn each time you click the deck of cards.  Click" & _
    " Draw One to turn over one card at a time, or click Draw Three to turn over thre" & _
    "e cards at a time.")
    Me.DrawOneRadioButton.Location = New System.Drawing.Point(6, 13)
    Me.DrawOneRadioButton.Name = "DrawOneRadioButton"
    Me.HelpProvider.SetShowHelp(Me.DrawOneRadioButton, True)
    Me.DrawOneRadioButton.Size = New System.Drawing.Size(75, 24)
    Me.DrawOneRadioButton.TabIndex = 0
    Me.DrawOneRadioButton.TabStop = True
    Me.DrawOneRadioButton.Text = "Draw One"
    '
    'CancelActionButton
    '
    Me.CancelActionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.CancelActionButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.HelpProvider.SetHelpString(Me.CancelActionButton, "Closes the dialog box without saving any changes you have made.")
    Me.CancelActionButton.Location = New System.Drawing.Point(120, 144)
    Me.CancelActionButton.Name = "CancelActionButton"
    Me.HelpProvider.SetShowHelp(Me.CancelActionButton, True)
    Me.CancelActionButton.Size = New System.Drawing.Size(60, 24)
    Me.CancelActionButton.TabIndex = 16
    Me.CancelActionButton.Text = "Cancel"
    '
    'OkButton
    '
    Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.HelpProvider.SetHelpString(Me.OkButton, "Closes the dialog box and saves any changes you have made.")
    Me.OkButton.Location = New System.Drawing.Point(56, 144)
    Me.OkButton.Name = "OkButton"
    Me.HelpProvider.SetShowHelp(Me.OkButton, True)
    Me.OkButton.Size = New System.Drawing.Size(56, 24)
    Me.OkButton.TabIndex = 15
    Me.OkButton.Text = "OK"
    '
    'CummulativeScoreCheckBox
    '
    Me.CummulativeScoreCheckBox.Enabled = False
    Me.CummulativeScoreCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.HelpProvider.SetHelpString(Me.CummulativeScoreCheckBox, "Only available on Vegas scoring, keeps track of your score through multiple games" & _
    ".")
    Me.CummulativeScoreCheckBox.Location = New System.Drawing.Point(120, 96)
    Me.CummulativeScoreCheckBox.Name = "CummulativeScoreCheckBox"
    Me.HelpProvider.SetShowHelp(Me.CummulativeScoreCheckBox, True)
    Me.CummulativeScoreCheckBox.Size = New System.Drawing.Size(88, 32)
    Me.CummulativeScoreCheckBox.TabIndex = 14
    Me.CummulativeScoreCheckBox.Text = "Cumulative Score"
    Me.CummulativeScoreCheckBox.TextAlign = System.Drawing.ContentAlignment.TopLeft
    '
    'OptionsDialog
    '
    Me.AcceptButton = Me.OkButton
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.CancelButton = Me.CancelActionButton
    Me.ClientSize = New System.Drawing.Size(224, 182)
    Me.Controls.Add(Me.OutlineDraggingCheckBox)
    Me.Controls.Add(Me.StatusBarCheckBox)
    Me.Controls.Add(Me.TimedGameCheckBox)
    Me.Controls.Add(Me.ScoringGroupBox)
    Me.Controls.Add(Me.DrawGroupBox)
    Me.Controls.Add(Me.CancelActionButton)
    Me.Controls.Add(Me.OkButton)
    Me.Controls.Add(Me.CummulativeScoreCheckBox)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.HelpButton = True
    Me.MaximizeBox = False
    Me.MaximumSize = New System.Drawing.Size(230, 214)
    Me.MinimizeBox = False
    Me.MinimumSize = New System.Drawing.Size(230, 214)
    Me.Name = "OptionsDialog"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Options"
    Me.ScoringGroupBox.ResumeLayout(False)
    Me.DrawGroupBox.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private m_originalDraw As Draw = Draw.One
  Private m_originalScoring As Scoring = Scoring.Standard
  Private m_originalTimedGame As Boolean = True

  Sub OptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ' Cache options when dialog is shown to be able to calculate Redraw property.
    m_originalDraw = Draw
    m_originalScoring = Scoring
    m_originalTimedGame = TimedGame
  End Sub

  Private Sub ScoreStandardRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScoreStandardRadioButton.CheckedChanged
    CummulativeScoreCheckBox.Enabled = False
  End Sub

  Private Sub ScoreVegasRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScoreVegasRadioButton.CheckedChanged
    CummulativeScoreCheckBox.Enabled = True
  End Sub

  Private Sub ScoreNoneRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScoreNoneRadioButton.CheckedChanged
    CummulativeScoreCheckBox.Enabled = False
  End Sub

  Public Property Draw() As Draw
    Get
      Return CType(IIf(DrawOneRadioButton.Checked, Draw.One, Draw.Three), Draw)
    End Get
    Set(ByVal Value As Draw)
      DrawOneRadioButton.Checked = (Value = Draw.One)
      DrawThreeRadioButton.Checked = (Value = Draw.Three)
    End Set
  End Property

  Public Property Scoring() As Scoring
    Get
      If ScoreNoneRadioButton.Checked Then
        Return Scoring.None
      End If
      If ScoreStandardRadioButton.Checked Then
        Return Scoring.Standard
      End If
      If ScoreVegasRadioButton.Checked Then
        Return CType(IIf(CummulativeScoreCheckBox.Checked, Scoring.VegasCumulative, Scoring.Vegas), Scoring)
      End If
      Debug.Assert(False)
      Return Scoring.None
    End Get
    Set(ByVal Value As Scoring)
      ScoreNoneRadioButton.Checked = False
      ScoreStandardRadioButton.Checked = False
      ScoreVegasRadioButton.Checked = False
      CummulativeScoreCheckBox.Checked = False
      CummulativeScoreCheckBox.Enabled = False
      Select Case Value
        Case Scoring.None
          ScoreNoneRadioButton.Checked = True
        Case Scoring.Standard
          ScoreStandardRadioButton.Checked = True
        Case Scoring.Vegas
          ScoreVegasRadioButton.Checked = True
        Case Scoring.VegasCumulative
          ScoreVegasRadioButton.Checked = True
          CummulativeScoreCheckBox.Checked = True
          CummulativeScoreCheckBox.Enabled = True
        Case Else
          Debug.Assert(False)
      End Select
    End Set
  End Property

  Public Property TimedGame() As Boolean
    Get
      Return TimedGameCheckBox.Checked
    End Get
    Set(ByVal Value As Boolean)
      TimedGameCheckBox.Checked = Value
    End Set
  End Property

  Public Property StatusBar() As Boolean
    Get
      Return StatusBarCheckBox.Checked
    End Get
    Set(ByVal Value As Boolean)
      StatusBarCheckBox.Checked = Value
    End Set
  End Property

  Public Property OutlineDragging() As Boolean
    Get
      Return OutlineDraggingCheckBox.Checked
    End Get
    Set(ByVal Value As Boolean)
      OutlineDraggingCheckBox.Checked = Value
    End Set
  End Property

  Public ReadOnly Property Redeal() As Boolean
    Get
      If Me.Draw <> m_originalDraw OrElse Me.TimedGame <> m_originalTimedGame Then
        Return True
      End If
      If Me.Scoring <> m_originalScoring Then
        ' Vegas -> VegasCummulative or VegasCummulative -> Vegas not worth a redeal.
        If Me.Scoring = Scoring.Vegas AndAlso m_originalScoring = Scoring.VegasCumulative Then
          Return False
        End If
        If Me.Scoring = Scoring.VegasCumulative AndAlso m_originalScoring = Scoring.Vegas Then
          Return False
        End If
        Return True
      End If
      Return False
    End Get
  End Property

End Class
