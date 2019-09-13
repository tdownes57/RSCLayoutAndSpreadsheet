<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogTextOffset
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
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonXIncrease = New System.Windows.Forms.Button()
        Me.ButtonXDecrease = New System.Windows.Forms.Button()
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.ButtonYIncrease = New System.Windows.Forms.Button()
        Me.ButtonYDecrease = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TextExampleValue = New System.Windows.Forms.TextBox()
        Me.LabelExampleValueHdr = New System.Windows.Forms.Label()
        Me.ButtonApplyExample = New System.Windows.Forms.Button()
        Me.LabelHeader2 = New System.Windows.Forms.Label()
        Me.ButtonCenter = New System.Windows.Forms.Button()
        Me.ButtonRight = New System.Windows.Forms.Button()
        Me.LabelNumberOffsetX = New System.Windows.Forms.Label()
        Me.LabelNumberOffsetY = New System.Windows.Forms.Label()
        Me.LabelFontSizeNum = New System.Windows.Forms.Label()
        Me.ButtonFontIncrease = New System.Windows.Forms.Button()
        Me.ButtonFontDecrease = New System.Windows.Forms.Button()
        Me.CtlGraphicFldLabel1 = New ciLayoutDesignVB.CtlGraphicFldLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.checkFontSizeScalesYN = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonLeft = New System.Windows.Forms.Button()
        Me.ButtonElementHghtIncrease = New System.Windows.Forms.Button()
        Me.ButtonElementHghtDecrease = New System.Windows.Forms.Button()
        Me.LabelElementHghtNum = New System.Windows.Forms.Label()
        Me.LabelElementWidthNum = New System.Windows.Forms.Label()
        Me.ButtonElementWidthDecrease = New System.Windows.Forms.Button()
        Me.ButtonElementWidthIncrease = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(433, 398)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(114, 38)
        Me.ButtonOK.TabIndex = 1
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(551, 398)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(56, 38)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonXIncrease
        '
        Me.ButtonXIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonXIncrease.Location = New System.Drawing.Point(52, 97)
        Me.ButtonXIncrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonXIncrease.Name = "ButtonXIncrease"
        Me.ButtonXIncrease.Size = New System.Drawing.Size(29, 39)
        Me.ButtonXIncrease.TabIndex = 3
        Me.ButtonXIncrease.Text = ">"
        Me.ButtonXIncrease.UseVisualStyleBackColor = True
        '
        'ButtonXDecrease
        '
        Me.ButtonXDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonXDecrease.Location = New System.Drawing.Point(19, 97)
        Me.ButtonXDecrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonXDecrease.Name = "ButtonXDecrease"
        Me.ButtonXDecrease.Size = New System.Drawing.Size(29, 39)
        Me.ButtonXDecrease.TabIndex = 4
        Me.ButtonXDecrease.Text = "<"
        Me.ButtonXDecrease.UseVisualStyleBackColor = True
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(7, 5)
        Me.LabelHeader1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(236, 39)
        Me.LabelHeader1.TabIndex = 5
        Me.LabelHeader1.Text = "Offset of Text  "
        '
        'ButtonYIncrease
        '
        Me.ButtonYIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonYIncrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.IncreaseY
        Me.ButtonYIncrease.Location = New System.Drawing.Point(398, 110)
        Me.ButtonYIncrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonYIncrease.Name = "ButtonYIncrease"
        Me.ButtonYIncrease.Size = New System.Drawing.Size(58, 26)
        Me.ButtonYIncrease.TabIndex = 8
        Me.ButtonYIncrease.UseVisualStyleBackColor = True
        '
        'ButtonYDecrease
        '
        Me.ButtonYDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonYDecrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.DecreaseY
        Me.ButtonYDecrease.Location = New System.Drawing.Point(399, 80)
        Me.ButtonYDecrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonYDecrease.Name = "ButtonYDecrease"
        Me.ButtonYDecrease.Size = New System.Drawing.Size(57, 26)
        Me.ButtonYDecrease.TabIndex = 7
        Me.ButtonYDecrease.UseVisualStyleBackColor = True
        '
        'TextExampleValue
        '
        Me.TextExampleValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextExampleValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextExampleValue.Location = New System.Drawing.Point(32, 408)
        Me.TextExampleValue.Margin = New System.Windows.Forms.Padding(2)
        Me.TextExampleValue.Name = "TextExampleValue"
        Me.TextExampleValue.Size = New System.Drawing.Size(218, 26)
        Me.TextExampleValue.TabIndex = 9
        '
        'LabelExampleValueHdr
        '
        Me.LabelExampleValueHdr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelExampleValueHdr.AutoSize = True
        Me.LabelExampleValueHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelExampleValueHdr.Location = New System.Drawing.Point(10, 387)
        Me.LabelExampleValueHdr.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelExampleValueHdr.Name = "LabelExampleValueHdr"
        Me.LabelExampleValueHdr.Size = New System.Drawing.Size(120, 20)
        Me.LabelExampleValueHdr.TabIndex = 10
        Me.LabelExampleValueHdr.Text = "Example Value"
        '
        'ButtonApplyExample
        '
        Me.ButtonApplyExample.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonApplyExample.Location = New System.Drawing.Point(284, 398)
        Me.ButtonApplyExample.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonApplyExample.Name = "ButtonApplyExample"
        Me.ButtonApplyExample.Size = New System.Drawing.Size(84, 36)
        Me.ButtonApplyExample.TabIndex = 11
        Me.ButtonApplyExample.Text = "Apply"
        Me.ButtonApplyExample.UseVisualStyleBackColor = True
        '
        'LabelHeader2
        '
        Me.LabelHeader2.AutoSize = True
        Me.LabelHeader2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader2.Location = New System.Drawing.Point(47, 36)
        Me.LabelHeader2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeader2.Name = "LabelHeader2"
        Me.LabelHeader2.Size = New System.Drawing.Size(271, 29)
        Me.LabelHeader2.TabIndex = 12
        Me.LabelHeader2.Text = "(from upper-left corner)"
        '
        'ButtonCenter
        '
        Me.ButtonCenter.Location = New System.Drawing.Point(161, 6)
        Me.ButtonCenter.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCenter.Name = "ButtonCenter"
        Me.ButtonCenter.Size = New System.Drawing.Size(109, 30)
        Me.ButtonCenter.TabIndex = 14
        Me.ButtonCenter.Text = "Center Text"
        Me.ButtonCenter.UseVisualStyleBackColor = True
        '
        'ButtonRight
        '
        Me.ButtonRight.Location = New System.Drawing.Point(283, 6)
        Me.ButtonRight.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonRight.Name = "ButtonRight"
        Me.ButtonRight.Size = New System.Drawing.Size(148, 30)
        Me.ButtonRight.TabIndex = 15
        Me.ButtonRight.Text = "Right Justify Text"
        Me.ButtonRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonRight.UseVisualStyleBackColor = True
        '
        'LabelNumberOffsetX
        '
        Me.LabelNumberOffsetX.AutoSize = True
        Me.LabelNumberOffsetX.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumberOffsetX.Location = New System.Drawing.Point(11, 73)
        Me.LabelNumberOffsetX.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelNumberOffsetX.Name = "LabelNumberOffsetX"
        Me.LabelNumberOffsetX.Size = New System.Drawing.Size(129, 26)
        Me.LabelNumberOffsetX.TabIndex = 16
        Me.LabelNumberOffsetX.Tag = "Offset X: {0}"
        Me.LabelNumberOffsetX.Text = "Offset X: {0}"
        '
        'LabelNumberOffsetY
        '
        Me.LabelNumberOffsetY.AutoSize = True
        Me.LabelNumberOffsetY.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumberOffsetY.Location = New System.Drawing.Point(369, 48)
        Me.LabelNumberOffsetY.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelNumberOffsetY.Name = "LabelNumberOffsetY"
        Me.LabelNumberOffsetY.Size = New System.Drawing.Size(130, 26)
        Me.LabelNumberOffsetY.TabIndex = 17
        Me.LabelNumberOffsetY.Tag = "Offset Y: {0}"
        Me.LabelNumberOffsetY.Text = "Offset Y: {0}"
        '
        'LabelFontSizeNum
        '
        Me.LabelFontSizeNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFontSizeNum.Location = New System.Drawing.Point(493, 179)
        Me.LabelFontSizeNum.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelFontSizeNum.Name = "LabelFontSizeNum"
        Me.LabelFontSizeNum.Size = New System.Drawing.Size(122, 23)
        Me.LabelFontSizeNum.TabIndex = 18
        Me.LabelFontSizeNum.Tag = "Font Size: {0}"
        Me.LabelFontSizeNum.Text = "Font Size: {0}"
        '
        'ButtonFontIncrease
        '
        Me.ButtonFontIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFontIncrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.IncreaseY
        Me.ButtonFontIncrease.Location = New System.Drawing.Point(512, 241)
        Me.ButtonFontIncrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonFontIncrease.Name = "ButtonFontIncrease"
        Me.ButtonFontIncrease.Size = New System.Drawing.Size(66, 32)
        Me.ButtonFontIncrease.TabIndex = 20
        Me.ButtonFontIncrease.UseVisualStyleBackColor = True
        '
        'ButtonFontDecrease
        '
        Me.ButtonFontDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFontDecrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.DecreaseY
        Me.ButtonFontDecrease.Location = New System.Drawing.Point(510, 205)
        Me.ButtonFontDecrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonFontDecrease.Name = "ButtonFontDecrease"
        Me.ButtonFontDecrease.Size = New System.Drawing.Size(67, 32)
        Me.ButtonFontDecrease.TabIndex = 19
        Me.ButtonFontDecrease.UseVisualStyleBackColor = True
        '
        'CtlGraphicFldLabel1
        '
        Me.CtlGraphicFldLabel1.Location = New System.Drawing.Point(20, 141)
        Me.CtlGraphicFldLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlGraphicFldLabel1.Name = "CtlGraphicFldLabel1"
        Me.CtlGraphicFldLabel1.Size = New System.Drawing.Size(272, 19)
        Me.CtlGraphicFldLabel1.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(192, 5)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(385, 36)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "This window is for the fine detail work which will determine where the text is di" &
    "splayed within the element."
        '
        'checkFontSizeScalesYN
        '
        Me.checkFontSizeScalesYN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.checkFontSizeScalesYN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkFontSizeScalesYN.Location = New System.Drawing.Point(13, 303)
        Me.checkFontSizeScalesYN.Margin = New System.Windows.Forms.Padding(2)
        Me.checkFontSizeScalesYN.Name = "checkFontSizeScalesYN"
        Me.checkFontSizeScalesYN.Size = New System.Drawing.Size(237, 57)
        Me.checkFontSizeScalesYN.TabIndex = 29
        Me.checkFontSizeScalesYN.Text = "Scale the font size, so changing the height of the element changes the font size." &
    ""
        Me.checkFontSizeScalesYN.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ButtonLeft)
        Me.Panel1.Controls.Add(Me.ButtonCenter)
        Me.Panel1.Controls.Add(Me.ButtonRight)
        Me.Panel1.Location = New System.Drawing.Point(36, 241)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(435, 40)
        Me.Panel1.TabIndex = 32
        '
        'ButtonLeft
        '
        Me.ButtonLeft.Location = New System.Drawing.Point(14, 6)
        Me.ButtonLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonLeft.Name = "ButtonLeft"
        Me.ButtonLeft.Size = New System.Drawing.Size(143, 30)
        Me.ButtonLeft.TabIndex = 31
        Me.ButtonLeft.Text = "Left Justify Text"
        Me.ButtonLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonLeft.UseVisualStyleBackColor = True
        '
        'ButtonElementHghtIncrease
        '
        Me.ButtonElementHghtIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonElementHghtIncrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.IncreaseY
        Me.ButtonElementHghtIncrease.Location = New System.Drawing.Point(299, 354)
        Me.ButtonElementHghtIncrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonElementHghtIncrease.Name = "ButtonElementHghtIncrease"
        Me.ButtonElementHghtIncrease.Size = New System.Drawing.Size(66, 24)
        Me.ButtonElementHghtIncrease.TabIndex = 35
        Me.ButtonElementHghtIncrease.UseVisualStyleBackColor = True
        '
        'ButtonElementHghtDecrease
        '
        Me.ButtonElementHghtDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonElementHghtDecrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.DecreaseY
        Me.ButtonElementHghtDecrease.Location = New System.Drawing.Point(298, 325)
        Me.ButtonElementHghtDecrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonElementHghtDecrease.Name = "ButtonElementHghtDecrease"
        Me.ButtonElementHghtDecrease.Size = New System.Drawing.Size(67, 25)
        Me.ButtonElementHghtDecrease.TabIndex = 34
        Me.ButtonElementHghtDecrease.UseVisualStyleBackColor = True
        '
        'LabelElementHghtNum
        '
        Me.LabelElementHghtNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelElementHghtNum.Location = New System.Drawing.Point(266, 300)
        Me.LabelElementHghtNum.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelElementHghtNum.Name = "LabelElementHghtNum"
        Me.LabelElementHghtNum.Size = New System.Drawing.Size(156, 23)
        Me.LabelElementHghtNum.TabIndex = 33
        Me.LabelElementHghtNum.Tag = "Label Height: {0}"
        Me.LabelElementHghtNum.Text = "Label Height: {0}"
        '
        'LabelElementWidthNum
        '
        Me.LabelElementWidthNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelElementWidthNum.Location = New System.Drawing.Point(422, 300)
        Me.LabelElementWidthNum.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelElementWidthNum.Name = "LabelElementWidthNum"
        Me.LabelElementWidthNum.Size = New System.Drawing.Size(156, 23)
        Me.LabelElementWidthNum.TabIndex = 36
        Me.LabelElementWidthNum.Tag = "Label Width: {0}"
        Me.LabelElementWidthNum.Text = "Label Width: {0}"
        '
        'ButtonElementWidthDecrease
        '
        Me.ButtonElementWidthDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonElementWidthDecrease.Location = New System.Drawing.Point(462, 325)
        Me.ButtonElementWidthDecrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonElementWidthDecrease.Name = "ButtonElementWidthDecrease"
        Me.ButtonElementWidthDecrease.Size = New System.Drawing.Size(29, 53)
        Me.ButtonElementWidthDecrease.TabIndex = 38
        Me.ButtonElementWidthDecrease.Text = "<"
        Me.ButtonElementWidthDecrease.UseVisualStyleBackColor = True
        '
        'ButtonElementWidthIncrease
        '
        Me.ButtonElementWidthIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonElementWidthIncrease.Location = New System.Drawing.Point(495, 325)
        Me.ButtonElementWidthIncrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonElementWidthIncrease.Name = "ButtonElementWidthIncrease"
        Me.ButtonElementWidthIncrease.Size = New System.Drawing.Size(29, 53)
        Me.ButtonElementWidthIncrease.TabIndex = 37
        Me.ButtonElementWidthIncrease.Text = ">"
        Me.ButtonElementWidthIncrease.UseVisualStyleBackColor = True
        '
        'DialogTextOffset
        '
        Me.AcceptButton = Me.ButtonOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Thistle
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(618, 447)
        Me.Controls.Add(Me.ButtonElementWidthDecrease)
        Me.Controls.Add(Me.ButtonElementWidthIncrease)
        Me.Controls.Add(Me.LabelElementWidthNum)
        Me.Controls.Add(Me.ButtonElementHghtIncrease)
        Me.Controls.Add(Me.ButtonElementHghtDecrease)
        Me.Controls.Add(Me.LabelElementHghtNum)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.checkFontSizeScalesYN)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CtlGraphicFldLabel1)
        Me.Controls.Add(Me.ButtonFontIncrease)
        Me.Controls.Add(Me.ButtonFontDecrease)
        Me.Controls.Add(Me.LabelFontSizeNum)
        Me.Controls.Add(Me.LabelNumberOffsetY)
        Me.Controls.Add(Me.LabelNumberOffsetX)
        Me.Controls.Add(Me.LabelHeader2)
        Me.Controls.Add(Me.ButtonApplyExample)
        Me.Controls.Add(Me.LabelExampleValueHdr)
        Me.Controls.Add(Me.TextExampleValue)
        Me.Controls.Add(Me.ButtonYIncrease)
        Me.Controls.Add(Me.ButtonYDecrease)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Controls.Add(Me.ButtonXDecrease)
        Me.Controls.Add(Me.ButtonXIncrease)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "DialogTextOffset"
        Me.Text = "FormOffsetText"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonXIncrease As Button
    Friend WithEvents ButtonXDecrease As Button
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents ButtonYIncrease As Button
    Friend WithEvents ButtonYDecrease As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TextExampleValue As TextBox
    Friend WithEvents LabelExampleValueHdr As Label
    Friend WithEvents ButtonApplyExample As Button
    Friend WithEvents LabelHeader2 As Label
    Friend WithEvents ButtonCenter As Button
    Friend WithEvents ButtonRight As Button
    Friend WithEvents LabelNumberOffsetX As Label
    Friend WithEvents LabelNumberOffsetY As Label
    Friend WithEvents LabelFontSizeNum As Label
    Friend WithEvents ButtonFontIncrease As Button
    Friend WithEvents ButtonFontDecrease As Button
    Friend WithEvents CtlGraphicFldLabel1 As CtlGraphicFldLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents checkFontSizeScalesYN As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ButtonLeft As Button
    Friend WithEvents ButtonElementHghtIncrease As Button
    Friend WithEvents ButtonElementHghtDecrease As Button
    Friend WithEvents LabelElementHghtNum As Label
    Friend WithEvents LabelElementWidthNum As Label
    Friend WithEvents ButtonElementWidthDecrease As Button
    Friend WithEvents ButtonElementWidthIncrease As Button
End Class
