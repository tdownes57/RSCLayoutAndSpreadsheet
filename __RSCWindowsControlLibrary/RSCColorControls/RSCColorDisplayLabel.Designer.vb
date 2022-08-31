<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCColorDisplayLabel
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
        Me.LabelBackcolorRight = New System.Windows.Forms.Label()
        Me.LabelBackcolorLeft = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelBackcolorRight
        '
        Me.LabelBackcolorRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelBackcolorRight.BackColor = System.Drawing.Color.RosyBrown
        Me.LabelBackcolorRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBackcolorRight.ForeColor = System.Drawing.Color.White
        Me.LabelBackcolorRight.Location = New System.Drawing.Point(100, 0)
        Me.LabelBackcolorRight.Name = "LabelBackcolorRight"
        Me.LabelBackcolorRight.Size = New System.Drawing.Size(100, 25)
        Me.LabelBackcolorRight.TabIndex = 9
        Me.LabelBackcolorRight.Text = "Text"
        Me.LabelBackcolorRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelBackcolorLeft
        '
        Me.LabelBackcolorLeft.BackColor = System.Drawing.Color.RosyBrown
        Me.LabelBackcolorLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBackcolorLeft.Location = New System.Drawing.Point(0, 0)
        Me.LabelBackcolorLeft.Name = "LabelBackcolorLeft"
        Me.LabelBackcolorLeft.Size = New System.Drawing.Size(100, 25)
        Me.LabelBackcolorLeft.TabIndex = 8
        Me.LabelBackcolorLeft.Text = "Text"
        Me.LabelBackcolorLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RSCColorDisplayLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelBackcolorRight)
        Me.Controls.Add(Me.LabelBackcolorLeft)
        Me.Name = "RSCColorDisplayLabel"
        Me.Size = New System.Drawing.Size(200, 25)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelBackcolorRight As Label
    Friend WithEvents LabelBackcolorLeft As Label
End Class
