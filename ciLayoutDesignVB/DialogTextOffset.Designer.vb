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
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TextExampleValue = New System.Windows.Forms.TextBox()
        Me.LabelExampleValueHdr = New System.Windows.Forms.Label()
        Me.ButtonCenter = New System.Windows.Forms.Button()
        Me.ButtonRight = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.checkFontSizeScalesYN = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonLeft = New System.Windows.Forms.Button()
        Me.CtlTextOffsetX = New ciLayoutDesignVB.CtlPropertyLeftRight()
        Me.CtlElementWidth = New ciLayoutDesignVB.CtlPropertyLeftRight()
        Me.CtlElementHeight = New ciLayoutDesignVB.CtlPropertyUpDownvb()
        Me.CtlFontSize = New ciLayoutDesignVB.CtlPropertyUpDownvb()
        Me.ctlTextOffsetY = New ciLayoutDesignVB.CtlPropertyUpDownvb()
        Me.CtlGraphicFldLabel1 = New ciLayoutDesignVB.CtlGraphicFldLabel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(612, 496)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(86, 29)
        Me.ButtonOK.TabIndex = 1
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(702, 496)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(67, 29)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(11, 4)
        Me.LabelHeader1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(334, 39)
        Me.LabelHeader1.TabIndex = 5
        Me.LabelHeader1.Text = "Positioning the Text  "
        '
        'TextExampleValue
        '
        Me.TextExampleValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextExampleValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextExampleValue.Location = New System.Drawing.Point(197, 420)
        Me.TextExampleValue.Margin = New System.Windows.Forms.Padding(2)
        Me.TextExampleValue.Name = "TextExampleValue"
        Me.TextExampleValue.Size = New System.Drawing.Size(283, 26)
        Me.TextExampleValue.TabIndex = 9
        '
        'LabelExampleValueHdr
        '
        Me.LabelExampleValueHdr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelExampleValueHdr.AutoSize = True
        Me.LabelExampleValueHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelExampleValueHdr.Location = New System.Drawing.Point(11, 426)
        Me.LabelExampleValueHdr.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelExampleValueHdr.Name = "LabelExampleValueHdr"
        Me.LabelExampleValueHdr.Size = New System.Drawing.Size(176, 20)
        Me.LabelExampleValueHdr.TabIndex = 10
        Me.LabelExampleValueHdr.Text = "Example Display Text:"
        '
        'ButtonCenter
        '
        Me.ButtonCenter.Location = New System.Drawing.Point(199, 5)
        Me.ButtonCenter.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCenter.Name = "ButtonCenter"
        Me.ButtonCenter.Size = New System.Drawing.Size(82, 23)
        Me.ButtonCenter.TabIndex = 14
        Me.ButtonCenter.Text = "Center Text"
        Me.ButtonCenter.UseVisualStyleBackColor = True
        '
        'ButtonRight
        '
        Me.ButtonRight.Location = New System.Drawing.Point(288, 6)
        Me.ButtonRight.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonRight.Name = "ButtonRight"
        Me.ButtonRight.Size = New System.Drawing.Size(186, 23)
        Me.ButtonRight.TabIndex = 15
        Me.ButtonRight.Text = "Right Justify Text"
        Me.ButtonRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonRight.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 41)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(540, 39)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "This window is for the fine detail work which will determine where the text is di" &
    "splayed within the element, and the relevant sizes."
        '
        'checkFontSizeScalesYN
        '
        Me.checkFontSizeScalesYN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.checkFontSizeScalesYN.BackColor = System.Drawing.Color.Plum
        Me.checkFontSizeScalesYN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkFontSizeScalesYN.Location = New System.Drawing.Point(14, 459)
        Me.checkFontSizeScalesYN.Margin = New System.Windows.Forms.Padding(2)
        Me.checkFontSizeScalesYN.Name = "checkFontSizeScalesYN"
        Me.checkFontSizeScalesYN.Size = New System.Drawing.Size(492, 26)
        Me.checkFontSizeScalesYN.TabIndex = 29
        Me.checkFontSizeScalesYN.Text = "Scale the font size, so changing the height of the element changes the font size." &
    ""
        Me.checkFontSizeScalesYN.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Plum
        Me.Panel1.Controls.Add(Me.ButtonLeft)
        Me.Panel1.Controls.Add(Me.ButtonCenter)
        Me.Panel1.Controls.Add(Me.ButtonRight)
        Me.Panel1.Location = New System.Drawing.Point(17, 280)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(486, 31)
        Me.Panel1.TabIndex = 32
        '
        'ButtonLeft
        '
        Me.ButtonLeft.Location = New System.Drawing.Point(10, 5)
        Me.ButtonLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonLeft.Name = "ButtonLeft"
        Me.ButtonLeft.Size = New System.Drawing.Size(176, 23)
        Me.ButtonLeft.TabIndex = 31
        Me.ButtonLeft.Text = "Left Justify Text"
        Me.ButtonLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonLeft.UseVisualStyleBackColor = True
        '
        'CtlTextOffsetX
        '
        Me.CtlTextOffsetX.BackColor = System.Drawing.Color.Plum
        Me.CtlTextOffsetX.Location = New System.Drawing.Point(12, 162)
        Me.CtlTextOffsetX.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlTextOffsetX.Name = "CtlTextOffsetX"
        Me.CtlTextOffsetX.PropertyName = "Text Offset Horizontal"
        Me.CtlTextOffsetX.PropertyValue = 4
        Me.CtlTextOffsetX.Size = New System.Drawing.Size(175, 113)
        Me.CtlTextOffsetX.TabIndex = 43
        Me.ToolTip1.SetToolTip(Me.CtlTextOffsetX, "Text Offset is from the top-left corner of the label.")
        '
        'CtlElementWidth
        '
        Me.CtlElementWidth.BackColor = System.Drawing.Color.Plum
        Me.CtlElementWidth.Location = New System.Drawing.Point(193, 162)
        Me.CtlElementWidth.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlElementWidth.Name = "CtlElementWidth"
        Me.CtlElementWidth.PropertyName = "Total Width of Label"
        Me.CtlElementWidth.PropertyValue = 100
        Me.CtlElementWidth.Size = New System.Drawing.Size(175, 113)
        Me.CtlElementWidth.TabIndex = 42
        '
        'CtlElementHeight
        '
        Me.CtlElementHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtlElementHeight.BackColor = System.Drawing.Color.Plum
        Me.CtlElementHeight.ElementInfo_Base = Nothing
        Me.CtlElementHeight.ElementInfo_Text = Nothing
        Me.CtlElementHeight.Location = New System.Drawing.Point(588, 341)
        Me.CtlElementHeight.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CtlElementHeight.Name = "CtlElementHeight"
        Me.CtlElementHeight.PropertyName = "Total Height of Label"
        Me.CtlElementHeight.PropertyValue = 10
        Me.CtlElementHeight.Size = New System.Drawing.Size(181, 135)
        Me.CtlElementHeight.TabIndex = 41
        '
        'CtlFontSize
        '
        Me.CtlFontSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtlFontSize.BackColor = System.Drawing.Color.Plum
        Me.CtlFontSize.ElementInfo_Base = Nothing
        Me.CtlFontSize.ElementInfo_Text = Nothing
        Me.CtlFontSize.Location = New System.Drawing.Point(540, 182)
        Me.CtlFontSize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CtlFontSize.Name = "CtlFontSize"
        Me.CtlFontSize.PropertyName = "Font Size Pixels"
        Me.CtlFontSize.PropertyValue = 25
        Me.CtlFontSize.Size = New System.Drawing.Size(181, 129)
        Me.CtlFontSize.TabIndex = 40
        '
        'ctlTextOffsetY
        '
        Me.ctlTextOffsetY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ctlTextOffsetY.BackColor = System.Drawing.Color.Plum
        Me.ctlTextOffsetY.ElementInfo_Base = Nothing
        Me.ctlTextOffsetY.ElementInfo_Text = Nothing
        Me.ctlTextOffsetY.Location = New System.Drawing.Point(621, 22)
        Me.ctlTextOffsetY.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ctlTextOffsetY.Name = "ctlTextOffsetY"
        Me.ctlTextOffsetY.PropertyName = "Text Offset Vertical"
        Me.ctlTextOffsetY.PropertyValue = 10
        Me.ctlTextOffsetY.Size = New System.Drawing.Size(181, 136)
        Me.ctlTextOffsetY.TabIndex = 39
        Me.ToolTip1.SetToolTip(Me.ctlTextOffsetY, "Text Offset is from the top-left corner of the label.")
        '
        'CtlGraphicFldLabel1
        '
        Me.CtlGraphicFldLabel1.Location = New System.Drawing.Point(17, 83)
        Me.CtlGraphicFldLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlGraphicFldLabel1.Name = "CtlGraphicFldLabel1"
        Me.CtlGraphicFldLabel1.Size = New System.Drawing.Size(463, 24)
        Me.CtlGraphicFldLabel1.TabIndex = 27
        '
        'DialogTextOffset
        '
        Me.AcceptButton = Me.ButtonOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Thistle
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(815, 536)
        Me.Controls.Add(Me.CtlTextOffsetX)
        Me.Controls.Add(Me.CtlElementWidth)
        Me.Controls.Add(Me.CtlElementHeight)
        Me.Controls.Add(Me.CtlFontSize)
        Me.Controls.Add(Me.ctlTextOffsetY)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.checkFontSizeScalesYN)
        Me.Controls.Add(Me.CtlGraphicFldLabel1)
        Me.Controls.Add(Me.LabelExampleValueHdr)
        Me.Controls.Add(Me.TextExampleValue)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.Label4)
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
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TextExampleValue As TextBox
    Friend WithEvents LabelExampleValueHdr As Label
    Friend WithEvents ButtonCenter As Button
    Friend WithEvents ButtonRight As Button
    Friend WithEvents CtlGraphicFldLabel1 As CtlGraphicFldLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents checkFontSizeScalesYN As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ButtonLeft As Button
    Friend WithEvents ctlTextOffsetY As CtlPropertyUpDownvb
    Friend WithEvents CtlFontSize As CtlPropertyUpDownvb
    Friend WithEvents CtlElementHeight As CtlPropertyUpDownvb
    Friend WithEvents CtlElementWidth As CtlPropertyLeftRight
    Friend WithEvents CtlTextOffsetX As CtlPropertyLeftRight
End Class
