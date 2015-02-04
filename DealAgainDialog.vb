Option Explicit On 
Option Strict On

Public Class DealAgainDialog
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
  Friend WithEvents NoButton As System.Windows.Forms.Button
  Friend WithEvents YesButton As System.Windows.Forms.Button
  Friend WithEvents Label As System.Windows.Forms.Label
  Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DealAgainDialog))
    Me.Label = New System.Windows.Forms.Label
    Me.NoButton = New System.Windows.Forms.Button
    Me.PictureBox = New System.Windows.Forms.PictureBox
    Me.YesButton = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'Label
    '
    Me.Label.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.Label.Location = New System.Drawing.Point(64, 24)
    Me.Label.Name = "Label"
    Me.Label.Size = New System.Drawing.Size(80, 24)
    Me.Label.TabIndex = 7
    Me.Label.Text = "Deal Again?"
    '
    'NoButton
    '
    Me.NoButton.DialogResult = System.Windows.Forms.DialogResult.No
    Me.NoButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.NoButton.Location = New System.Drawing.Point(93, 64)
    Me.NoButton.Name = "NoButton"
    Me.NoButton.Size = New System.Drawing.Size(72, 24)
    Me.NoButton.TabIndex = 6
    Me.NoButton.Text = "&No"
    '
    'PictureBox
    '
    Me.PictureBox.BackgroundImage = CType(resources.GetObject("PictureBox.BackgroundImage"), System.Drawing.Image)
    Me.PictureBox.Location = New System.Drawing.Point(16, 8)
    Me.PictureBox.Name = "PictureBox"
    Me.PictureBox.Size = New System.Drawing.Size(32, 40)
    Me.PictureBox.TabIndex = 5
    Me.PictureBox.TabStop = False
    '
    'YesButton
    '
    Me.YesButton.DialogResult = System.Windows.Forms.DialogResult.Yes
    Me.YesButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.YesButton.Location = New System.Drawing.Point(13, 64)
    Me.YesButton.Name = "YesButton"
    Me.YesButton.Size = New System.Drawing.Size(72, 24)
    Me.YesButton.TabIndex = 4
    Me.YesButton.Text = "&Yes"
    '
    'DealAgainDialog
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(178, 96)
    Me.Controls.Add(Me.Label)
    Me.Controls.Add(Me.NoButton)
    Me.Controls.Add(Me.PictureBox)
    Me.Controls.Add(Me.YesButton)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "DealAgainDialog"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Solitaire"
    Me.ResumeLayout(False)

  End Sub

#End Region

End Class
