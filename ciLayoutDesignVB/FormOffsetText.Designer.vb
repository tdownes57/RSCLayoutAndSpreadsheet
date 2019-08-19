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
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonXIncrease = New System.Windows.Forms.Button()
        Me.ButtonXDecrease = New System.Windows.Forms.Button()
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.ButtonYIncrease = New System.Windows.Forms.Button()
        Me.ButtonYDecrease = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TextExampleValue = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonApplyExample = New System.Windows.Forms.Button()
        Me.LabelHeader2 = New System.Windows.Forms.Label()
        Me.ButtonLeft = New System.Windows.Forms.Button()
        Me.ButtonCenter = New System.Windows.Forms.Button()
        Me.ButtonRight = New System.Windows.Forms.Button()
        Me.LabelNumberOffsetX = New System.Windows.Forms.Label()
        Me.LabelNumberOffsetY = New System.Windows.Forms.Label()
        Me.LabelFontSizeNum = New System.Windows.Forms.Label()
        Me.ButtonFontIncrease = New System.Windows.Forms.Button()
        Me.ButtonFontDecrease = New System.Windows.Forms.Button()
        Me.CtlGraphicFldLabel1 = New ciLayoutDesignVB.CtlGraphicFldLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.checkFontSizeLocked = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(479, 340)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(108, 50)
        Me.ButtonOK.TabIndex = 1
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(596, 340)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(74, 50)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonXIncrease
        '
        Me.ButtonXIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonXIncrease.Location = New System.Drawing.Point(55, 97)
        Me.ButtonXIncrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonXIncrease.Name = "ButtonXIncrease"
        Me.ButtonXIncrease.Size = New System.Drawing.Size(39, 41)
        Me.ButtonXIncrease.TabIndex = 3
        Me.ButtonXIncrease.Text = ">"
        Me.ButtonXIncrease.UseVisualStyleBackColor = True
        '
        'ButtonXDecrease
        '
        Me.ButtonXDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonXDecrease.Location = New System.Drawing.Point(11, 97)
        Me.ButtonXDecrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonXDecrease.Name = "ButtonXDecrease"
        Me.ButtonXDecrease.Size = New System.Drawing.Size(39, 41)
        Me.ButtonXDecrease.TabIndex = 4
        Me.ButtonXDecrease.Text = "<"
        Me.ButtonXDecrease.UseVisualStyleBackColor = True
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(9, 7)
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
        Me.ButtonYIncrease.Location = New System.Drawing.Point(494, 109)
        Me.ButtonYIncrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonYIncrease.Name = "ButtonYIncrease"
        Me.ButtonYIncrease.Size = New System.Drawing.Size(39, 29)
        Me.ButtonYIncrease.TabIndex = 8
        Me.ButtonYIncrease.UseVisualStyleBackColor = True
        '
        'ButtonYDecrease
        '
        Me.ButtonYDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonYDecrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.DecreaseY
        Me.ButtonYDecrease.Location = New System.Drawing.Point(494, 80)
        Me.ButtonYDecrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonYDecrease.Name = "ButtonYDecrease"
        Me.ButtonYDecrease.Size = New System.Drawing.Size(39, 25)
        Me.ButtonYDecrease.TabIndex = 7
        Me.ButtonYDecrease.UseVisualStyleBackColor = True
        '
        'TextExampleValue
        '
        Me.TextExampleValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextExampleValue.Location = New System.Drawing.Point(55, 382)
        Me.TextExampleValue.Margin = New System.Windows.Forms.Padding(2)
        Me.TextExampleValue.Name = "TextExampleValue"
        Me.TextExampleValue.Size = New System.Drawing.Size(139, 23)
        Me.TextExampleValue.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 363)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Example Value"
        '
        'ButtonApplyExample
        '
        Me.ButtonApplyExample.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonApplyExample.Location = New System.Drawing.Point(283, 361)
        Me.ButtonApplyExample.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonApplyExample.Name = "ButtonApplyExample"
        Me.ButtonApplyExample.Size = New System.Drawing.Size(112, 39)
        Me.ButtonApplyExample.TabIndex = 11
        Me.ButtonApplyExample.Text = "Apply"
        Me.ButtonApplyExample.UseVisualStyleBackColor = True
        '
        'LabelHeader2
        '
        Me.LabelHeader2.AutoSize = True
        Me.LabelHeader2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader2.Location = New System.Drawing.Point(22, 38)
        Me.LabelHeader2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeader2.Name = "LabelHeader2"
        Me.LabelHeader2.Size = New System.Drawing.Size(292, 31)
        Me.LabelHeader2.TabIndex = 12
        Me.LabelHeader2.Text = "(from upper-left corner)"
        '
        'ButtonLeft
        '
        Me.ButtonLeft.Location = New System.Drawing.Point(8, 259)
        Me.ButtonLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonLeft.Name = "ButtonLeft"
        Me.ButtonLeft.Size = New System.Drawing.Size(186, 39)
        Me.ButtonLeft.TabIndex = 13
        Me.ButtonLeft.Text = "Left Justify Text"
        Me.ButtonLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonLeft.UseVisualStyleBackColor = True
        '
        'ButtonCenter
        '
        Me.ButtonCenter.Location = New System.Drawing.Point(250, 259)
        Me.ButtonCenter.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCenter.Name = "ButtonCenter"
        Me.ButtonCenter.Size = New System.Drawing.Size(145, 39)
        Me.ButtonCenter.TabIndex = 14
        Me.ButtonCenter.Text = "Center Text"
        Me.ButtonCenter.UseVisualStyleBackColor = True
        '
        'ButtonRight
        '
        Me.ButtonRight.Location = New System.Drawing.Point(420, 259)
        Me.ButtonRight.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonRight.Name = "ButtonRight"
        Me.ButtonRight.Size = New System.Drawing.Size(197, 39)
        Me.ButtonRight.TabIndex = 15
        Me.ButtonRight.Text = "Right Justify Text"
        Me.ButtonRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonRight.UseVisualStyleBackColor = True
        '
        'LabelNumberOffsetX
        '
        Me.LabelNumberOffsetX.AutoSize = True
        Me.LabelNumberOffsetX.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumberOffsetX.Location = New System.Drawing.Point(8, 76)
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
        Me.LabelNumberOffsetY.Location = New System.Drawing.Point(490, 57)
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
        Me.LabelFontSizeNum.Location = New System.Drawing.Point(525, 151)
        Me.LabelFontSizeNum.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelFontSizeNum.Name = "LabelFontSizeNum"
        Me.LabelFontSizeNum.Size = New System.Drawing.Size(92, 20)
        Me.LabelFontSizeNum.TabIndex = 18
        Me.LabelFontSizeNum.Tag = "Font Size: {0}"
        Me.LabelFontSizeNum.Text = "Font Size: {0}"
        '
        'ButtonFontIncrease
        '
        Me.ButtonFontIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFontIncrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.IncreaseY
        Me.ButtonFontIncrease.Location = New System.Drawing.Point(529, 210)
        Me.ButtonFontIncrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonFontIncrease.Name = "ButtonFontIncrease"
        Me.ButtonFontIncrease.Size = New System.Drawing.Size(69, 31)
        Me.ButtonFontIncrease.TabIndex = 20
        Me.ButtonFontIncrease.UseVisualStyleBackColor = True
        '
        'ButtonFontDecrease
        '
        Me.ButtonFontDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFontDecrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.DecreaseY
        Me.ButtonFontDecrease.Location = New System.Drawing.Point(528, 173)
        Me.ButtonFontDecrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonFontDecrease.Name = "ButtonFontDecrease"
        Me.ButtonFontDecrease.Size = New System.Drawing.Size(69, 33)
        Me.ButtonFontDecrease.TabIndex = 19
        Me.ButtonFontDecrease.UseVisualStyleBackColor = True
        '
        'CtlGraphicFldLabel1
        '
        Me.CtlGraphicFldLabel1.Location = New System.Drawing.Point(11, 145)
        Me.CtlGraphicFldLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlGraphicFldLabel1.Name = "CtlGraphicFldLabel1"
        Me.CtlGraphicFldLabel1.Size = New System.Drawing.Size(362, 25)
        Me.CtlGraphicFldLabel1.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(279, 7)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(391, 37)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "This window is for the fine detail work which will determine where the text is di" &
    "splayed within the element."
        '
        'checkFontSizeLocked
        '
        Me.checkFontSizeLocked.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.checkFontSizeLocked.AutoSize = True
        Me.checkFontSizeLocked.Location = New System.Drawing.Point(8, 319)
        Me.checkFontSizeLocked.Margin = New System.Windows.Forms.Padding(2)
        Me.checkFontSizeLocked.Name = "checkFontSizeLocked"
        Me.checkFontSizeLocked.Size = New System.Drawing.Size(550, 21)
        Me.checkFontSizeLocked.TabIndex = 29
        Me.checkFontSizeLocked.Text = "Lock font size, so changing the height of the element has no effect on the font s" &
    "ize"
        Me.checkFontSizeLocked.UseVisualStyleBackColor = True
        '
        'FormOffsetText
        '
        Me.AcceptButton = Me.ButtonOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Orchid
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(687, 423)
        Me.Controls.Add(Me.checkFontSizeLocked)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CtlGraphicFldLabel1)
        Me.Controls.Add(Me.ButtonFontIncrease)
        Me.Controls.Add(Me.ButtonFontDecrease)
        Me.Controls.Add(Me.LabelFontSizeNum)
        Me.Controls.Add(Me.LabelNumberOffsetY)
        Me.Controls.Add(Me.LabelNumberOffsetX)
        Me.Controls.Add(Me.ButtonRight)
        Me.Controls.Add(Me.ButtonCenter)
        Me.Controls.Add(Me.ButtonLeft)
        Me.Controls.Add(Me.LabelHeader2)
        Me.Controls.Add(Me.ButtonApplyExample)
        Me.Controls.Add(Me.Label1)
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
        Me.Name = "FormOffsetText"
        Me.Text = "FormOffsetText"
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
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonApplyExample As Button
    Friend WithEvents LabelHeader2 As Label
    Friend WithEvents ButtonLeft As Button
    Friend WithEvents ButtonCenter As Button
    Friend WithEvents ButtonRight As Button
    Friend WithEvents LabelNumberOffsetX As Label
    Friend WithEvents LabelNumberOffsetY As Label
    Friend WithEvents LabelFontSizeNum As Label
    Friend WithEvents ButtonFontIncrease As Button
    Friend WithEvents ButtonFontDecrease As Button
    Friend WithEvents CtlGraphicFldLabel1 As CtlGraphicFldLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents checkFontSizeLocked As CheckBox
End Class
