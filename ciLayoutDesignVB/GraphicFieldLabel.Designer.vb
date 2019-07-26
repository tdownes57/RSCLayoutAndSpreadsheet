<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GraphicFieldLabel
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
        Me.pictureLabel = New System.Windows.Forms.PictureBox()
        CType(Me.pictureLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureLabel
        '
        Me.pictureLabel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pictureLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pictureLabel.Location = New System.Drawing.Point(0, 0)
        Me.pictureLabel.Name = "pictureLabel"
        Me.pictureLabel.Size = New System.Drawing.Size(253, 33)
        Me.pictureLabel.TabIndex = 0
        Me.pictureLabel.TabStop = False
        '
        'GraphicFieldLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pictureLabel)
        Me.Name = "GraphicFieldLabel"
        Me.Size = New System.Drawing.Size(253, 33)
        CType(Me.pictureLabel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pictureLabel As PictureBox
End Class
