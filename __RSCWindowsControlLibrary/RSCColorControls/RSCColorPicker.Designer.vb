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
        Me.SuspendLayout()
        '
        'RscColorDisplay1
        '
        Me.RscColorDisplay1.Location = New System.Drawing.Point(18, 13)
        Me.RscColorDisplay1.Name = "RscColorDisplay1"
        Me.RscColorDisplay1.Size = New System.Drawing.Size(139, 122)
        Me.RscColorDisplay1.TabIndex = 0
        '
        'textboxHexadecimal
        '
        Me.textboxHexadecimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textboxHexadecimal.Location = New System.Drawing.Point(178, 180)
        Me.textboxHexadecimal.Name = "textboxHexadecimal"
        Me.textboxHexadecimal.Size = New System.Drawing.Size(165, 26)
        Me.textboxHexadecimal.TabIndex = 1
        '
        'LabelHexadecimal
        '
        Me.LabelHexadecimal.AutoSize = True
        Me.LabelHexadecimal.Location = New System.Drawing.Point(106, 188)
        Me.LabelHexadecimal.Name = "LabelHexadecimal"
        Me.LabelHexadecimal.Size = New System.Drawing.Size(68, 13)
        Me.LabelHexadecimal.TabIndex = 2
        Me.LabelHexadecimal.Text = "Hexadecimal"
        '
        'HScrollBar1Alpha
        '
        Me.HScrollBar1Alpha.Location = New System.Drawing.Point(213, 13)
        Me.HScrollBar1Alpha.Maximum = 255
        Me.HScrollBar1Alpha.Name = "HScrollBar1Alpha"
        Me.HScrollBar1Alpha.Size = New System.Drawing.Size(130, 33)
        Me.HScrollBar1Alpha.TabIndex = 3
        '
        'HScrollBar2Red
        '
        Me.HScrollBar2Red.Location = New System.Drawing.Point(213, 46)
        Me.HScrollBar2Red.Maximum = 255
        Me.HScrollBar2Red.Name = "HScrollBar2Red"
        Me.HScrollBar2Red.Size = New System.Drawing.Size(130, 33)
        Me.HScrollBar2Red.TabIndex = 4
        '
        'HScrollBar3Green
        '
        Me.HScrollBar3Green.Location = New System.Drawing.Point(213, 79)
        Me.HScrollBar3Green.Maximum = 255
        Me.HScrollBar3Green.Name = "HScrollBar3Green"
        Me.HScrollBar3Green.Size = New System.Drawing.Size(130, 33)
        Me.HScrollBar3Green.TabIndex = 5
        '
        'HScrollBar4Blue
        '
        Me.HScrollBar4Blue.Location = New System.Drawing.Point(213, 112)
        Me.HScrollBar4Blue.Maximum = 255
        Me.HScrollBar4Blue.Name = "HScrollBar4Blue"
        Me.HScrollBar4Blue.Size = New System.Drawing.Size(130, 33)
        Me.HScrollBar4Blue.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(106, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Decimal"
        '
        'textboxColorDecimal
        '
        Me.textboxColorDecimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textboxColorDecimal.Location = New System.Drawing.Point(178, 148)
        Me.textboxColorDecimal.Name = "textboxColorDecimal"
        Me.textboxColorDecimal.Size = New System.Drawing.Size(165, 26)
        Me.textboxColorDecimal.TabIndex = 7
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
        Me.LabelRed.Location = New System.Drawing.Point(175, 24)
        Me.LabelRed.Name = "LabelRed"
        Me.LabelRed.Size = New System.Drawing.Size(34, 13)
        Me.LabelRed.TabIndex = 10
        Me.LabelRed.Text = "Alpha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(184, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Red"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(175, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Green"
        '
        'LabelHue
        '
        Me.LabelHue.AutoSize = True
        Me.LabelHue.Location = New System.Drawing.Point(183, 122)
        Me.LabelHue.Name = "LabelHue"
        Me.LabelHue.Size = New System.Drawing.Size(28, 13)
        Me.LabelHue.TabIndex = 13
        Me.LabelHue.Text = "Blue"
        '
        'RSCColorPicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
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
        Me.Size = New System.Drawing.Size(351, 219)
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
End Class
