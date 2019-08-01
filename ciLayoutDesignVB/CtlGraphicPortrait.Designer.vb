<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlGraphicPortrait
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CtlGraphicPortrait))
        Me.pictureLabel = New System.Windows.Forms.PictureBox()
        CType(Me.pictureLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureLabel
        '
        Me.pictureLabel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pictureLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pictureLabel.Image = CType(resources.GetObject("pictureLabel.Image"), System.Drawing.Image)
        Me.pictureLabel.Location = New System.Drawing.Point(0, 0)
        Me.pictureLabel.Name = "pictureLabel"
        Me.pictureLabel.Size = New System.Drawing.Size(144, 182)
        Me.pictureLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureLabel.TabIndex = 1
        Me.pictureLabel.TabStop = False
        '
        'CtlGraphicPortrait
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pictureLabel)
        Me.Name = "CtlGraphicPortrait"
        Me.Size = New System.Drawing.Size(144, 182)
        CType(Me.pictureLabel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pictureLabel As PictureBox
End Class
