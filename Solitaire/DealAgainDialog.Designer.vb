<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DealAgainDialog
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DealAgainDialog))
    Label = New Label()
    NoButton = New Button()
    PictureBox = New PictureBox()
    YesButton = New Button()
    CType(PictureBox, ComponentModel.ISupportInitialize).BeginInit()
    SuspendLayout()
    ' 
    ' Label
    ' 
    Label.FlatStyle = FlatStyle.System
    Label.Location = New Point(77, 27)
    Label.Name = "Label"
    Label.Size = New Size(96, 29)
    Label.TabIndex = 11
    Label.Text = "Deal Again?"
    ' 
    ' NoButton
    ' 
    NoButton.DialogResult = DialogResult.No
    NoButton.FlatStyle = FlatStyle.System
    NoButton.Location = New Point(112, 76)
    NoButton.Name = "NoButton"
    NoButton.Size = New Size(86, 29)
    NoButton.TabIndex = 10
    NoButton.Text = "&No"
    ' 
    ' PictureBox
    ' 
    PictureBox.BackgroundImage = CType(resources.GetObject("PictureBox.BackgroundImage"), Image)
    PictureBox.Location = New Point(32, 15)
    PictureBox.Name = "PictureBox"
    PictureBox.Size = New Size(34, 35)
    PictureBox.TabIndex = 9
    PictureBox.TabStop = False
    ' 
    ' YesButton
    ' 
    YesButton.DialogResult = DialogResult.Yes
    YesButton.FlatStyle = FlatStyle.System
    YesButton.Location = New Point(16, 76)
    YesButton.Name = "YesButton"
    YesButton.Size = New Size(86, 29)
    YesButton.TabIndex = 8
    YesButton.Text = "&Yes"
    ' 
    ' DealAgainDialog
    ' 
    AcceptButton = YesButton
    AutoScaleMode = AutoScaleMode.Inherit
    CancelButton = NoButton
    ClientSize = New Size(214, 121)
    Controls.Add(Label)
    Controls.Add(NoButton)
    Controls.Add(PictureBox)
    Controls.Add(YesButton)
    FormBorderStyle = FormBorderStyle.FixedDialog
    MaximizeBox = False
    MinimizeBox = False
    Name = "DealAgainDialog"
    ShowInTaskbar = False
    StartPosition = FormStartPosition.CenterParent
    Text = "'Classic' Solitaire"
    CType(PictureBox, ComponentModel.ISupportInitialize).EndInit()
    ResumeLayout(False)
  End Sub

  Friend WithEvents Label As Label
  Friend WithEvents NoButton As Button
  Friend WithEvents PictureBox As PictureBox
  Friend WithEvents YesButton As Button
End Class
