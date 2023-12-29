Public Class OptionsDialog

  Private m_originalDraw As Draw = Draw.One
  Private m_originalScoring As Scoring = Scoring.Standard
  Private m_originalTimedGame As Boolean = True

  Sub OptionsDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    ' Cache options when dialog is shown to be able to calculate Redraw property.
    m_originalDraw = Draw
    m_originalScoring = Scoring
    m_originalTimedGame = TimedGame
  End Sub

  Private Sub ScoreStandardRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles ScoreStandardRadioButton.CheckedChanged
    CummulativeScoreCheckBox.Enabled = False
  End Sub

  Private Sub ScoreVegasRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles ScoreVegasRadioButton.CheckedChanged
    CummulativeScoreCheckBox.Enabled = True
  End Sub

  Private Sub ScoreNoneRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles ScoreNoneRadioButton.CheckedChanged
    CummulativeScoreCheckBox.Enabled = False
  End Sub

  Friend Property Draw() As Draw
    Get
      Return If(DrawOneRadioButton.Checked, Draw.One, Draw.Three)
    End Get
    Set(value As Draw)
      DrawOneRadioButton.Checked = (value = Draw.One)
      DrawThreeRadioButton.Checked = (value = Draw.Three)
    End Set
  End Property

  Friend Property Scoring() As Scoring
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
    Set(Value As Scoring)
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
    Set(Value As Boolean)
      TimedGameCheckBox.Checked = Value
    End Set
  End Property

  Public Property StatusBar() As Boolean
    Get
      Return StatusBarCheckBox.Checked
    End Get
    Set(Value As Boolean)
      StatusBarCheckBox.Checked = Value
    End Set
  End Property

  Public Property OutlineDragging() As Boolean
    Get
      Return OutlineDraggingCheckBox.Checked
    End Get
    Set(Value As Boolean)
      OutlineDraggingCheckBox.Checked = Value
    End Set
  End Property

  Public ReadOnly Property Redeal() As Boolean
    Get
      If Draw <> m_originalDraw OrElse TimedGame <> m_originalTimedGame Then
        Return True
      End If
      If Scoring <> m_originalScoring Then
        ' Vegas -> VegasCummulative or VegasCummulative -> Vegas not worth a redeal.
        If Scoring = Scoring.Vegas AndAlso m_originalScoring = Scoring.VegasCumulative Then
          Return False
        End If
        If Scoring = Scoring.VegasCumulative AndAlso m_originalScoring = Scoring.Vegas Then
          Return False
        End If
        Return True
      End If
      Return False
    End Get
  End Property

End Class