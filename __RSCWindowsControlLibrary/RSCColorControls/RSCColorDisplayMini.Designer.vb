<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCColorDisplayMini
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
        Me.LabelBackcolorBottom = New System.Windows.Forms.Label()
        Me.LabelBackcolorTop = New System.Windows.Forms.Label()
        Me.LabelForecolorLeft = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelBackcolorBottom
        '
        Me.LabelBackcolorBottom.BackColor = System.Drawing.Color.RosyBrown
        Me.LabelBackcolorBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBackcolorBottom.ForeColor = System.Drawing.Color.White
        Me.LabelBackcolorBottom.Location = New System.Drawing.Point(0, 44)
        Me.LabelBackcolorBottom.Name = "LabelBackcolorBottom"
        Me.LabelBackcolorBottom.Size = New System.Drawing.Size(86, 24)
        Me.LabelBackcolorBottom.TabIndex = 7
        Me.LabelBackcolorBottom.Text = "Text"
        Me.LabelBackcolorBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelBackcolorTop
        '
        Me.LabelBackcolorTop.BackColor = System.Drawing.Color.RosyBrown
        Me.LabelBackcolorTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBackcolorTop.Location = New System.Drawing.Point(0, 0)
        Me.LabelBackcolorTop.Name = "LabelBackcolorTop"
        Me.LabelBackcolorTop.Size = New System.Drawing.Size(86, 25)
        Me.LabelBackcolorTop.TabIndex = 6
        Me.LabelBackcolorTop.Text = "Text"
        Me.LabelBackcolorTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelForecolorLeft
        '
        Me.LabelForecolorLeft.BackColor = System.Drawing.Color.White
        Me.LabelForecolorLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelForecolorLeft.ForeColor = System.Drawing.Color.RosyBrown
        Me.LabelForecolorLeft.Location = New System.Drawing.Point(0, 25)
        Me.LabelForecolorLeft.Name = "LabelForecolorLeft"
        Me.LabelForecolorLeft.Size = New System.Drawing.Size(86, 19)
        Me.LabelForecolorLeft.TabIndex = 4
        Me.LabelForecolorLeft.Text = "Text"
        Me.LabelForecolorLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RSCColorDisplayMini
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelBackcolorBottom)
        Me.Controls.Add(Me.LabelBackcolorTop)
        Me.Controls.Add(Me.LabelForecolorLeft)
        Me.Name = "RSCColorDisplayMini"
        Me.Size = New System.Drawing.Size(86, 68)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelBackcolorBottom As Label
    Friend WithEvents LabelBackcolorTop As Label
    Friend WithEvents LabelForecolorLeft As Label
End Class
