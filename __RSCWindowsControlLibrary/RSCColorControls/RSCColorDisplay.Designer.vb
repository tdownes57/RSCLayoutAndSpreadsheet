<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCColorDisplay
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
        Me.LabelForecolorLeft = New System.Windows.Forms.Label()
        Me.LabelForecolorRight = New System.Windows.Forms.Label()
        Me.LabelBackcolorTop = New System.Windows.Forms.Label()
        Me.LabelBackcolorBottom = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelForecolorLeft
        '
        Me.LabelForecolorLeft.BackColor = System.Drawing.Color.White
        Me.LabelForecolorLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelForecolorLeft.ForeColor = System.Drawing.Color.RosyBrown
        Me.LabelForecolorLeft.Location = New System.Drawing.Point(0, 44)
        Me.LabelForecolorLeft.Name = "LabelForecolorLeft"
        Me.LabelForecolorLeft.Size = New System.Drawing.Size(68, 34)
        Me.LabelForecolorLeft.TabIndex = 0
        Me.LabelForecolorLeft.Text = "Text"
        Me.LabelForecolorLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelForecolorRight
        '
        Me.LabelForecolorRight.BackColor = System.Drawing.Color.Black
        Me.LabelForecolorRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelForecolorRight.ForeColor = System.Drawing.Color.RosyBrown
        Me.LabelForecolorRight.Location = New System.Drawing.Point(71, 44)
        Me.LabelForecolorRight.Name = "LabelForecolorRight"
        Me.LabelForecolorRight.Size = New System.Drawing.Size(68, 34)
        Me.LabelForecolorRight.TabIndex = 1
        Me.LabelForecolorRight.Text = "Text"
        Me.LabelForecolorRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBackcolorTop
        '
        Me.LabelBackcolorTop.BackColor = System.Drawing.Color.RosyBrown
        Me.LabelBackcolorTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBackcolorTop.Location = New System.Drawing.Point(-3, 0)
        Me.LabelBackcolorTop.Name = "LabelBackcolorTop"
        Me.LabelBackcolorTop.Size = New System.Drawing.Size(144, 37)
        Me.LabelBackcolorTop.TabIndex = 2
        Me.LabelBackcolorTop.Text = "Text"
        Me.LabelBackcolorTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelBackcolorBottom
        '
        Me.LabelBackcolorBottom.BackColor = System.Drawing.Color.RosyBrown
        Me.LabelBackcolorBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBackcolorBottom.ForeColor = System.Drawing.Color.White
        Me.LabelBackcolorBottom.Location = New System.Drawing.Point(-3, 83)
        Me.LabelBackcolorBottom.Name = "LabelBackcolorBottom"
        Me.LabelBackcolorBottom.Size = New System.Drawing.Size(144, 37)
        Me.LabelBackcolorBottom.TabIndex = 3
        Me.LabelBackcolorBottom.Text = "Text"
        Me.LabelBackcolorBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RSCColorDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelBackcolorBottom)
        Me.Controls.Add(Me.LabelBackcolorTop)
        Me.Controls.Add(Me.LabelForecolorRight)
        Me.Controls.Add(Me.LabelForecolorLeft)
        Me.Name = "RSCColorDisplay"
        Me.Size = New System.Drawing.Size(139, 122)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelForecolorLeft As Label
    Friend WithEvents LabelForecolorRight As Label
    Friend WithEvents LabelBackcolorTop As Label
    Friend WithEvents LabelBackcolorBottom As Label
End Class
