<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOffsetText
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
        Me.components = New System.ComponentModel.Container()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ButtonXIncrease = New System.Windows.Forms.Button()
        Me.ButtonXDecrease = New System.Windows.Forms.Button()
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.ButtonYIncrease = New System.Windows.Forms.Button()
        Me.ButtonYDecrease = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.LabelHeader2 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.LabelNumberOffsetY = New System.Windows.Forms.Label()
        Me.LabelNumberOffsetX = New System.Windows.Forms.Label()
        Me.LabelFontSizeNum = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.CtlGraphicFldLabel1 = New ciLayoutDesignVB.CtlGraphicFldLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.checkFontSizeLocked = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(511, 336)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 35)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(621, 336)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 35)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ButtonXIncrease
        '
        Me.ButtonXIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonXIncrease.Location = New System.Drawing.Point(201, 230)
        Me.ButtonXIncrease.Name = "ButtonXIncrease"
        Me.ButtonXIncrease.Size = New System.Drawing.Size(52, 40)
        Me.ButtonXIncrease.TabIndex = 3
        Me.ButtonXIncrease.Text = ">"
        Me.ButtonXIncrease.UseVisualStyleBackColor = True
        '
        'ButtonXDecrease
        '
        Me.ButtonXDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonXDecrease.Location = New System.Drawing.Point(143, 230)
        Me.ButtonXDecrease.Name = "ButtonXDecrease"
        Me.ButtonXDecrease.Size = New System.Drawing.Size(52, 40)
        Me.ButtonXDecrease.TabIndex = 4
        Me.ButtonXDecrease.Text = "<"
        Me.ButtonXDecrease.UseVisualStyleBackColor = True
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(12, 9)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(192, 31)
        Me.LabelHeader1.TabIndex = 5
        Me.LabelHeader1.Text = "Offset of Text  "
        '
        'ButtonYIncrease
        '
        Me.ButtonYIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonYIncrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.IncreaseY
        Me.ButtonYIncrease.Location = New System.Drawing.Point(658, 143)
        Me.ButtonYIncrease.Name = "ButtonYIncrease"
        Me.ButtonYIncrease.Size = New System.Drawing.Size(52, 38)
        Me.ButtonYIncrease.TabIndex = 8
        Me.ButtonYIncrease.UseVisualStyleBackColor = True
        '
        'ButtonYDecrease
        '
        Me.ButtonYDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonYDecrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.DecreaseY
        Me.ButtonYDecrease.Location = New System.Drawing.Point(658, 104)
        Me.ButtonYDecrease.Name = "ButtonYDecrease"
        Me.ButtonYDecrease.Size = New System.Drawing.Size(52, 33)
        Me.ButtonYDecrease.TabIndex = 7
        Me.ButtonYDecrease.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(96, 350)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(202, 20)
        Me.TextBox1.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 353)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Example Value"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(304, 347)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(149, 24)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Set edited example value"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'LabelHeader2
        '
        Me.LabelHeader2.AutoSize = True
        Me.LabelHeader2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader2.Location = New System.Drawing.Point(29, 50)
        Me.LabelHeader2.Name = "LabelHeader2"
        Me.LabelHeader2.Size = New System.Drawing.Size(234, 26)
        Me.LabelHeader2.TabIndex = 12
        Me.LabelHeader2.Text = "(from upper-left corner)"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(102, 289)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(164, 24)
        Me.Button4.TabIndex = 13
        Me.Button4.Text = "Left Justify Text"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(272, 289)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(164, 24)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "Center Text"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(442, 289)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(164, 24)
        Me.Button6.TabIndex = 15
        Me.Button6.Text = "Right Justify Text"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'LabelNumberOffsetY
        '
        Me.LabelNumberOffsetY.AutoSize = True
        Me.LabelNumberOffsetY.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumberOffsetY.Location = New System.Drawing.Point(138, 202)
        Me.LabelNumberOffsetY.Name = "LabelNumberOffsetY"
        Me.LabelNumberOffsetY.Size = New System.Drawing.Size(129, 26)
        Me.LabelNumberOffsetY.TabIndex = 16
        Me.LabelNumberOffsetY.Tag = "Offset X: {0}"
        Me.LabelNumberOffsetY.Text = "Offset X: {0}"
        '
        'LabelNumberOffsetX
        '
        Me.LabelNumberOffsetX.AutoSize = True
        Me.LabelNumberOffsetX.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumberOffsetX.Location = New System.Drawing.Point(589, 68)
        Me.LabelNumberOffsetX.Name = "LabelNumberOffsetX"
        Me.LabelNumberOffsetX.Size = New System.Drawing.Size(130, 26)
        Me.LabelNumberOffsetX.TabIndex = 17
        Me.LabelNumberOffsetX.Tag = "Offset Y: {0}"
        Me.LabelNumberOffsetX.Text = "Offset Y: {0}"
        '
        'LabelFontSizeNum
        '
        Me.LabelFontSizeNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFontSizeNum.Location = New System.Drawing.Point(449, 190)
        Me.LabelFontSizeNum.Name = "LabelFontSizeNum"
        Me.LabelFontSizeNum.Size = New System.Drawing.Size(123, 26)
        Me.LabelFontSizeNum.TabIndex = 18
        Me.LabelFontSizeNum.Tag = "Font Size: {0}"
        Me.LabelFontSizeNum.Text = "Font Size: {0}"
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Image = Global.ciLayoutDesignVB.My.Resources.Resources.IncreaseY
        Me.Button7.Location = New System.Drawing.Point(453, 244)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(30, 26)
        Me.Button7.TabIndex = 20
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = Global.ciLayoutDesignVB.My.Resources.Resources.DecreaseY
        Me.Button8.Location = New System.Drawing.Point(453, 219)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(30, 26)
        Me.Button8.TabIndex = 19
        Me.Button8.UseVisualStyleBackColor = True
        '
        'CtlGraphicFldLabel1
        '
        Me.CtlGraphicFldLabel1.Location = New System.Drawing.Point(18, 104)
        Me.CtlGraphicFldLabel1.Name = "CtlGraphicFldLabel1"
        Me.CtlGraphicFldLabel1.Size = New System.Drawing.Size(253, 33)
        Me.CtlGraphicFldLabel1.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(298, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(421, 49)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "This window is for the fine detail work which will determine where the text is di" &
    "splayed within the element."
        '
        'checkFontSizeLocked
        '
        Me.checkFontSizeLocked.AutoSize = True
        Me.checkFontSizeLocked.Location = New System.Drawing.Point(10, 319)
        Me.checkFontSizeLocked.Name = "checkFontSizeLocked"
        Me.checkFontSizeLocked.Size = New System.Drawing.Size(416, 17)
        Me.checkFontSizeLocked.TabIndex = 29
        Me.checkFontSizeLocked.Text = "Lock font size, so changing the height of the element has no effect on the font s" &
    "ize"
        Me.checkFontSizeLocked.UseVisualStyleBackColor = True
        '
        'FormOffsetText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 380)
        Me.Controls.Add(Me.checkFontSizeLocked)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CtlGraphicFldLabel1)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.LabelFontSizeNum)
        Me.Controls.Add(Me.LabelNumberOffsetX)
        Me.Controls.Add(Me.LabelNumberOffsetY)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.LabelHeader2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ButtonYIncrease)
        Me.Controls.Add(Me.ButtonYDecrease)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Controls.Add(Me.ButtonXDecrease)
        Me.Controls.Add(Me.ButtonXIncrease)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormOffsetText"
        Me.Text = "FormOffsetText"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ButtonXIncrease As Button
    Friend WithEvents ButtonXDecrease As Button
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents ButtonYIncrease As Button
    Friend WithEvents ButtonYDecrease As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents LabelHeader2 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents LabelNumberOffsetY As Label
    Friend WithEvents LabelNumberOffsetX As Label
    Friend WithEvents LabelFontSizeNum As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents CtlGraphicFldLabel1 As CtlGraphicFldLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents checkFontSizeLocked As CheckBox
End Class
