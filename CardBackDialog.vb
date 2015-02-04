Option Explicit On 
Option Strict On

Public Class CardBackDialog
  Inherits System.Windows.Forms.Form

  Private m_cardBack As Integer = 0

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
  Friend WithEvents Button9 As System.Windows.Forms.Button
  Friend WithEvents Button10 As System.Windows.Forms.Button
  Friend WithEvents Button11 As System.Windows.Forms.Button
  Friend WithEvents Button12 As System.Windows.Forms.Button
  Friend WithEvents Button13 As System.Windows.Forms.Button
  Friend WithEvents Button14 As System.Windows.Forms.Button
  Friend WithEvents Button8 As System.Windows.Forms.Button
  Friend WithEvents Button7 As System.Windows.Forms.Button
  Friend WithEvents Button6 As System.Windows.Forms.Button
  Friend WithEvents Button5 As System.Windows.Forms.Button
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents CancelActionButton As System.Windows.Forms.Button
  Friend WithEvents OkButton As System.Windows.Forms.Button
  Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CardBackDialog))
    Me.Button9 = New System.Windows.Forms.Button
    Me.Button10 = New System.Windows.Forms.Button
    Me.Button11 = New System.Windows.Forms.Button
    Me.Button12 = New System.Windows.Forms.Button
    Me.Button13 = New System.Windows.Forms.Button
    Me.Button14 = New System.Windows.Forms.Button
    Me.Button8 = New System.Windows.Forms.Button
    Me.Button7 = New System.Windows.Forms.Button
    Me.Button6 = New System.Windows.Forms.Button
    Me.Button5 = New System.Windows.Forms.Button
    Me.Button4 = New System.Windows.Forms.Button
    Me.Button3 = New System.Windows.Forms.Button
    Me.CancelActionButton = New System.Windows.Forms.Button
    Me.OkButton = New System.Windows.Forms.Button
    Me.HelpProvider = New System.Windows.Forms.HelpProvider
    Me.SuspendLayout()
    '
    'Button9
    '
    Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.HelpProvider.SetHelpString(Me.Button9, "Click a card type to specify the deck you want to play the game with.")
    Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
    Me.Button9.Location = New System.Drawing.Point(218, 75)
    Me.Button9.Name = "Button9"
    Me.HelpProvider.SetShowHelp(Me.Button9, True)
    Me.Button9.Size = New System.Drawing.Size(32, 56)
    Me.Button9.TabIndex = 27
    '
    'Button10
    '
    Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.HelpProvider.SetHelpString(Me.Button10, "Click a card type to specify the deck you want to play the game with.")
    Me.Button10.Image = CType(resources.GetObject("Button10.Image"), System.Drawing.Image)
    Me.Button10.Location = New System.Drawing.Point(178, 75)
    Me.Button10.Name = "Button10"
    Me.HelpProvider.SetShowHelp(Me.Button10, True)
    Me.Button10.Size = New System.Drawing.Size(32, 56)
    Me.Button10.TabIndex = 26
    '
    'Button11
    '
    Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.HelpProvider.SetHelpString(Me.Button11, "Click a card type to specify the deck you want to play the game with.")
    Me.Button11.Image = CType(resources.GetObject("Button11.Image"), System.Drawing.Image)
    Me.Button11.Location = New System.Drawing.Point(138, 75)
    Me.Button11.Name = "Button11"
    Me.HelpProvider.SetShowHelp(Me.Button11, True)
    Me.Button11.Size = New System.Drawing.Size(32, 56)
    Me.Button11.TabIndex = 25
    '
    'Button12
    '
    Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.HelpProvider.SetHelpString(Me.Button12, "Click a card type to specify the deck you want to play the game with.")
    Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
    Me.Button12.Location = New System.Drawing.Point(98, 75)
    Me.Button12.Name = "Button12"
    Me.HelpProvider.SetShowHelp(Me.Button12, True)
    Me.Button12.Size = New System.Drawing.Size(32, 56)
    Me.Button12.TabIndex = 24
    '
    'Button13
    '
    Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.HelpProvider.SetHelpString(Me.Button13, "Click a card type to specify the deck you want to play the game with.")
    Me.Button13.Image = CType(resources.GetObject("Button13.Image"), System.Drawing.Image)
    Me.Button13.Location = New System.Drawing.Point(58, 75)
    Me.Button13.Name = "Button13"
    Me.HelpProvider.SetShowHelp(Me.Button13, True)
    Me.Button13.Size = New System.Drawing.Size(32, 56)
    Me.Button13.TabIndex = 23
    '
    'Button14
    '
    Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.HelpProvider.SetHelpString(Me.Button14, "Click a card type to specify the deck you want to play the game with.")
    Me.Button14.Image = CType(resources.GetObject("Button14.Image"), System.Drawing.Image)
    Me.Button14.Location = New System.Drawing.Point(18, 75)
    Me.Button14.Name = "Button14"
    Me.HelpProvider.SetShowHelp(Me.Button14, True)
    Me.Button14.Size = New System.Drawing.Size(32, 56)
    Me.Button14.TabIndex = 22
    '
    'Button8
    '
    Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.HelpProvider.SetHelpString(Me.Button8, "Click a card type to specify the deck you want to play the game with.")
    Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
    Me.Button8.Location = New System.Drawing.Point(218, 11)
    Me.Button8.Name = "Button8"
    Me.HelpProvider.SetShowHelp(Me.Button8, True)
    Me.Button8.Size = New System.Drawing.Size(32, 56)
    Me.Button8.TabIndex = 21
    '
    'Button7
    '
    Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.HelpProvider.SetHelpString(Me.Button7, "Click a card type to specify the deck you want to play the game with.")
    Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
    Me.Button7.Location = New System.Drawing.Point(178, 11)
    Me.Button7.Name = "Button7"
    Me.HelpProvider.SetShowHelp(Me.Button7, True)
    Me.Button7.Size = New System.Drawing.Size(32, 56)
    Me.Button7.TabIndex = 20
    '
    'Button6
    '
    Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.HelpProvider.SetHelpString(Me.Button6, "Click a card type to specify the deck you want to play the game with.")
    Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
    Me.Button6.Location = New System.Drawing.Point(138, 11)
    Me.Button6.Name = "Button6"
    Me.HelpProvider.SetShowHelp(Me.Button6, True)
    Me.Button6.Size = New System.Drawing.Size(32, 56)
    Me.Button6.TabIndex = 19
    '
    'Button5
    '
    Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.HelpProvider.SetHelpString(Me.Button5, "Click a card type to specify the deck you want to play the game with.")
    Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
    Me.Button5.Location = New System.Drawing.Point(98, 11)
    Me.Button5.Name = "Button5"
    Me.HelpProvider.SetShowHelp(Me.Button5, True)
    Me.Button5.Size = New System.Drawing.Size(32, 56)
    Me.Button5.TabIndex = 18
    '
    'Button4
    '
    Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.HelpProvider.SetHelpString(Me.Button4, "Click a card type to specify the deck you want to play the game with.")
    Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
    Me.Button4.Location = New System.Drawing.Point(58, 11)
    Me.Button4.Name = "Button4"
    Me.HelpProvider.SetShowHelp(Me.Button4, True)
    Me.Button4.Size = New System.Drawing.Size(32, 56)
    Me.Button4.TabIndex = 17
    '
    'Button3
    '
    Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.HelpProvider.SetHelpString(Me.Button3, "Click a card type to specify the deck you want to play the game with.")
    Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
    Me.Button3.Location = New System.Drawing.Point(18, 11)
    Me.Button3.Name = "Button3"
    Me.HelpProvider.SetShowHelp(Me.Button3, True)
    Me.Button3.Size = New System.Drawing.Size(32, 56)
    Me.Button3.TabIndex = 16
    '
    'CancelActionButton
    '
    Me.CancelActionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.CancelActionButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.HelpProvider.SetHelpString(Me.CancelActionButton, "Closes the dialog box without saving any changes you have made.")
    Me.CancelActionButton.Location = New System.Drawing.Point(146, 147)
    Me.CancelActionButton.Name = "CancelActionButton"
    Me.HelpProvider.SetShowHelp(Me.CancelActionButton, True)
    Me.CancelActionButton.Size = New System.Drawing.Size(64, 24)
    Me.CancelActionButton.TabIndex = 15
    Me.CancelActionButton.Text = "Cancel"
    '
    'OkButton
    '
    Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.HelpProvider.SetHelpString(Me.OkButton, "Closes the dialog box and saves any changes you have made.")
    Me.OkButton.Location = New System.Drawing.Point(66, 147)
    Me.OkButton.Name = "OkButton"
    Me.HelpProvider.SetShowHelp(Me.OkButton, True)
    Me.OkButton.Size = New System.Drawing.Size(64, 24)
    Me.OkButton.TabIndex = 14
    Me.OkButton.Text = "OK"
    '
    'CardBackDialog
    '
    Me.AcceptButton = Me.OkButton
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.CancelButton = Me.CancelActionButton
    Me.ClientSize = New System.Drawing.Size(269, 182)
    Me.Controls.Add(Me.Button9)
    Me.Controls.Add(Me.Button10)
    Me.Controls.Add(Me.Button11)
    Me.Controls.Add(Me.Button12)
    Me.Controls.Add(Me.Button13)
    Me.Controls.Add(Me.Button14)
    Me.Controls.Add(Me.Button8)
    Me.Controls.Add(Me.Button7)
    Me.Controls.Add(Me.Button6)
    Me.Controls.Add(Me.Button5)
    Me.Controls.Add(Me.Button4)
    Me.Controls.Add(Me.Button3)
    Me.Controls.Add(Me.CancelActionButton)
    Me.Controls.Add(Me.OkButton)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.HelpButton = True
    Me.MaximizeBox = False
    Me.MaximumSize = New System.Drawing.Size(275, 214)
    Me.MinimizeBox = False
    Me.MinimumSize = New System.Drawing.Size(275, 214)
    Me.Name = "CardBackDialog"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Select Card Back"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
    m_cardBack = 0
  End Sub

  Private Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
    m_cardBack = 1
  End Sub

  Private Sub button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
    m_cardBack = 2
  End Sub

  Private Sub button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
    m_cardBack = 3
  End Sub

  Private Sub button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
    m_cardBack = 4
  End Sub

  Private Sub button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
    m_cardBack = 5
  End Sub

  Private Sub button14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button14.Click
    m_cardBack = 6
  End Sub

  Private Sub button13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button13.Click
    m_cardBack = 7
  End Sub

  Private Sub button12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button12.Click
    m_cardBack = 8
  End Sub

  Private Sub button11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.Click
    m_cardBack = 9
  End Sub

  Private Sub button10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.Click
    m_cardBack = 10
  End Sub

  Private Sub button9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.Click
    m_cardBack = 11
  End Sub

  Public Property Cardback() As Integer
    Get
      Return m_cardBack
    End Get
    Set(ByVal Value As Integer)
      Value = m_cardBack
    End Set
  End Property

End Class
