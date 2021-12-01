<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlQRCode
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
        Me.CtlGraphicQRCode1 = New ciBadgeDesigner.CtlGraphicQRCode()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CtlGraphicQRCode1
        '
        Me.CtlGraphicQRCode1.Location = New System.Drawing.Point(4, 0)
        Me.CtlGraphicQRCode1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CtlGraphicQRCode1.Name = "CtlGraphicQRCode1"
        Me.CtlGraphicQRCode1.Size = New System.Drawing.Size(94, 99)
        Me.CtlGraphicQRCode1.TabIndex = 66
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(121, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(237, 17)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "See project called ciBadgeDesigner."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(137, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(249, 17)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "In that project, find the folder Controls."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(156, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(315, 17)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "In that folder, find the control ctlGraphicQRCode."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(528, 17)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "The control you see above && to the left is that same control from that other pro" &
    "ject."
        '
        'CtlQRCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CtlGraphicQRCode1)
        Me.Name = "CtlQRCode"
        Me.Size = New System.Drawing.Size(609, 142)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CtlGraphicQRCode1 As ciBadgeDesigner.CtlGraphicQRCode
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
