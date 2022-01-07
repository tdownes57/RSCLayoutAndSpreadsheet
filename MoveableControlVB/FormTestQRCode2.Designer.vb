<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTestQRCode2
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
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.PictureBox_BadgeFront = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox_BadgeFront, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.ForeColor = System.Drawing.Color.Gray
        Me.LabelHeader1.Location = New System.Drawing.Point(12, 19)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(844, 54)
        Me.LabelHeader1.TabIndex = 0
        Me.LabelHeader1.Text = "Run the application to test the QR Code"
        Me.LabelHeader1.Visible = False
        '
        'PictureBox_BadgeFront
        '
        Me.PictureBox_BadgeFront.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox_BadgeFront.Location = New System.Drawing.Point(69, 104)
        Me.PictureBox_BadgeFront.Name = "PictureBox_BadgeFront"
        Me.PictureBox_BadgeFront.Size = New System.Drawing.Size(673, 278)
        Me.PictureBox_BadgeFront.TabIndex = 1
        Me.PictureBox_BadgeFront.TabStop = False
        '
        'FormTestQRCode2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 450)
        Me.Controls.Add(Me.PictureBox_BadgeFront)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Name = "FormTestQRCode2"
        Me.Text = "FormTestQRCode2"
        CType(Me.PictureBox_BadgeFront, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents PictureBox_BadgeFront As PictureBox
End Class
