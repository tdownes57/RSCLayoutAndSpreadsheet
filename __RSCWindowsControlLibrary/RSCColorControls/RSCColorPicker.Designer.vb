<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCColorPicker
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
        Me.RscColorDisplay1 = New __RSCWindowsControlLibrary.RSCColorDisplay()
        Me.textboxHexadecimal = New System.Windows.Forms.TextBox()
        Me.LabelHexadecimal = New System.Windows.Forms.Label()
        Me.HScrollBar1Alpha = New System.Windows.Forms.HScrollBar()
        Me.HScrollBar2Red = New System.Windows.Forms.HScrollBar()
        Me.HScrollBar3Green = New System.Windows.Forms.HScrollBar()
        Me.HScrollBar4Blue = New System.Windows.Forms.HScrollBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textboxColorDecimal = New System.Windows.Forms.TextBox()
        Me.LinkLabelOpenDialog = New System.Windows.Forms.LinkLabel()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.LabelRed = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelHue = New System.Windows.Forms.Label()
        Me.checkAdvancedControls = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'RscColorDisplay1
        '
        Me.RscColorDisplay1.DisplayRSCColor = Nothing
        Me.RscColorDisplay1.HideBackgroundLabels = True
        Me.RscColorDisplay1.HideForegroundLabels = True
        Me.RscColorDisplay1.Location = New System.Drawing.Point(18, 13)
        Me.RscColorDisplay1.Name = "RscColorDisplay1"
        Me.RscColorDisplay1.Size = New System.Drawing.Size(139, 122)
        Me.RscColorDisplay1.TabIndex = 0
        '
        'textboxHexadecimal
        '
        Me.textboxHexadecimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textboxHexadecimal.Location = New System.Drawing.Point(180, 195)
        Me.textboxHexadecimal.Name = "textboxHexadecimal"
        Me.textboxHexadecimal.Size = New System.Drawing.Size(165, 26)
        Me.textboxHexadecimal.TabIndex = 1
        Me.textboxHexadecimal.Tag = "advanced"
        Me.textboxHexadecimal.Visible = False
        '
        'LabelHexadecimal
        '
        Me.LabelHexadecimal.AutoSize = True
        Me.LabelHexadecimal.Location = New System.Drawing.Point(106, 195)
        Me.LabelHexadecimal.Name = "LabelHexadecimal"
        Me.LabelHexadecimal.Size = New System.Drawing.Size(68, 13)
        Me.LabelHexadecimal.TabIndex = 2
        Me.LabelHexadecimal.Tag = "advanced"
        Me.LabelHexadecimal.Text = "Hexadecimal"
        Me.LabelHexadecimal.Visible = False
        '
        'HScrollBar1Alpha
        '
        Me.HScrollBar1Alpha.Location = New System.Drawing.Point(215, 28)
        Me.HScrollBar1Alpha.Maximum = 255
        Me.HScrollBar1Alpha.Name = "HScrollBar1Alpha"
        Me.HScrollBar1Alpha.Size = New System.Drawing.Size(130, 33)
        Me.HScrollBar1Alpha.TabIndex = 3
        Me.HScrollBar1Alpha.Tag = "advanced"
        Me.HScrollBar1Alpha.Visible = False
        '
        'HScrollBar2Red
        '
        Me.HScrollBar2Red.Location = New System.Drawing.Point(215, 61)
        Me.HScrollBar2Red.Maximum = 255
        Me.HScrollBar2Red.Name = "HScrollBar2Red"
        Me.HScrollBar2Red.Size = New System.Drawing.Size(130, 33)
        Me.HScrollBar2Red.TabIndex = 4
        Me.HScrollBar2Red.Tag = "advanced"
        Me.HScrollBar2Red.Visible = False
        '
        'HScrollBar3Green
        '
        Me.HScrollBar3Green.Location = New System.Drawing.Point(215, 94)
        Me.HScrollBar3Green.Maximum = 255
        Me.HScrollBar3Green.Name = "HScrollBar3Green"
        Me.HScrollBar3Green.Size = New System.Drawing.Size(130, 33)
        Me.HScrollBar3Green.TabIndex = 5
        Me.HScrollBar3Green.Tag = "advanced"
        Me.HScrollBar3Green.Visible = False
        '
        'HScrollBar4Blue
        '
        Me.HScrollBar4Blue.Location = New System.Drawing.Point(215, 127)
        Me.HScrollBar4Blue.Maximum = 255
        Me.HScrollBar4Blue.Name = "HScrollBar4Blue"
        Me.HScrollBar4Blue.Size = New System.Drawing.Size(130, 33)
        Me.HScrollBar4Blue.TabIndex = 6
        Me.HScrollBar4Blue.Tag = "advanced"
        Me.HScrollBar4Blue.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(106, 163)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Tag = "advanced"
        Me.Label1.Text = "Decimal"
        Me.Label1.Visible = False
        '
        'textboxColorDecimal
        '
        Me.textboxColorDecimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textboxColorDecimal.Location = New System.Drawing.Point(180, 163)
        Me.textboxColorDecimal.Name = "textboxColorDecimal"
        Me.textboxColorDecimal.Size = New System.Drawing.Size(165, 26)
        Me.textboxColorDecimal.TabIndex = 7
        Me.textboxColorDecimal.Tag = "advanced"
        Me.textboxColorDecimal.Visible = False
        '
        'LinkLabelOpenDialog
        '
        Me.LinkLabelOpenDialog.AutoSize = True
        Me.LinkLabelOpenDialog.Location = New System.Drawing.Point(15, 171)
        Me.LinkLabelOpenDialog.Name = "LinkLabelOpenDialog"
        Me.LinkLabelOpenDialog.Size = New System.Drawing.Size(66, 13)
        Me.LinkLabelOpenDialog.TabIndex = 9
        Me.LinkLabelOpenDialog.TabStop = True
        Me.LinkLabelOpenDialog.Text = "Open Dialog"
        '
        'LabelRed
        '
        Me.LabelRed.AutoSize = True
        Me.LabelRed.Location = New System.Drawing.Point(177, 39)
        Me.LabelRed.Name = "LabelRed"
        Me.LabelRed.Size = New System.Drawing.Size(34, 13)
        Me.LabelRed.TabIndex = 10
        Me.LabelRed.Tag = "advanced"
        Me.LabelRed.Text = "Alpha"
        Me.LabelRed.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(186, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Tag = "advanced"
        Me.Label2.Text = "Red"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(177, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Tag = "advanced"
        Me.Label3.Text = "Green"
        Me.Label3.Visible = False
        '
        'LabelHue
        '
        Me.LabelHue.AutoSize = True
        Me.LabelHue.Location = New System.Drawing.Point(185, 137)
        Me.LabelHue.Name = "LabelHue"
        Me.LabelHue.Size = New System.Drawing.Size(28, 13)
        Me.LabelHue.TabIndex = 13
        Me.LabelHue.Tag = "advanced"
        Me.LabelHue.Text = "Blue"
        Me.LabelHue.Visible = False
        '
        'checkAdvancedControls
        '
        Me.checkAdvancedControls.AutoSize = True
        Me.checkAdvancedControls.Location = New System.Drawing.Point(180, 8)
        Me.checkAdvancedControls.Name = "checkAdvancedControls"
        Me.checkAdvancedControls.Size = New System.Drawing.Size(146, 17)
        Me.checkAdvancedControls.TabIndex = 14
        Me.checkAdvancedControls.Text = "Show Advanced Controls"
        Me.checkAdvancedControls.UseVisualStyleBackColor = True
        '
        'RSCColorPicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.checkAdvancedControls)
        Me.Controls.Add(Me.LabelHue)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelRed)
        Me.Controls.Add(Me.LinkLabelOpenDialog)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.textboxColorDecimal)
        Me.Controls.Add(Me.HScrollBar4Blue)
        Me.Controls.Add(Me.HScrollBar3Green)
        Me.Controls.Add(Me.HScrollBar2Red)
        Me.Controls.Add(Me.HScrollBar1Alpha)
        Me.Controls.Add(Me.LabelHexadecimal)
        Me.Controls.Add(Me.textboxHexadecimal)
        Me.Controls.Add(Me.RscColorDisplay1)
        Me.Name = "RSCColorPicker"
        Me.Size = New System.Drawing.Size(351, 230)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RscColorDisplay1 As RSCColorDisplay
    Friend WithEvents textboxHexadecimal As TextBox
    Friend WithEvents LabelHexadecimal As Label
    Friend WithEvents HScrollBar1Alpha As HScrollBar
    Friend WithEvents HScrollBar2Red As HScrollBar
    Friend WithEvents HScrollBar3Green As HScrollBar
    Friend WithEvents HScrollBar4Blue As HScrollBar
    Friend WithEvents Label1 As Label
    Friend WithEvents textboxColorDecimal As TextBox
    Friend WithEvents LinkLabelOpenDialog As LinkLabel
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents LabelRed As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LabelHue As Label
    Friend WithEvents checkAdvancedControls As CheckBox
End Class
