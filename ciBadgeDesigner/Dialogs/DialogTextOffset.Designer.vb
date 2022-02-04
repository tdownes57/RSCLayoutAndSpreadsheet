Imports ciBadgeDesigner
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.ButtonApply = New System.Windows.Forms.Button()
        Me.LabelResultHdr = New System.Windows.Forms.Label()
        Me.CtlTextOffsetX = New CtlPropertyLeftRight()
        Me.CtlElementWidth = New CtlPropertyLeftRight()
        Me.CtlElementHeight = New CtlPropertyUpDownvb()
        Me.CtlFontSize = New CtlPropertyUpDownvb()
        Me.ctlTextOffsetY = New CtlPropertyUpDownvb()
        Me.CtlGraphicFldLabel1 = New CtlGraphicFieldV3("DialogTextOffset")
        Me.LabelForBorderOnly = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(459, 451)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(64, 44)
        Me.ButtonOK.TabIndex = 1
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(526, 451)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(74, 44)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(8, 3)
        Me.LabelHeader1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(266, 31)
        Me.LabelHeader1.TabIndex = 5
        Me.LabelHeader1.Text = "Positioning the Text  "
        '
        'TextExampleValue
        '
        Me.TextExampleValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextExampleValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextExampleValue.Location = New System.Drawing.Point(13, 419)
        Me.TextExampleValue.Margin = New System.Windows.Forms.Padding(2)
        Me.TextExampleValue.Name = "TextExampleValue"
        Me.TextExampleValue.Size = New System.Drawing.Size(292, 23)
        Me.TextExampleValue.TabIndex = 9
        '
        'LabelExampleValueHdr
        '
        Me.LabelExampleValueHdr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelExampleValueHdr.AutoSize = True
        Me.LabelExampleValueHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelExampleValueHdr.Location = New System.Drawing.Point(12, 402)
        Me.LabelExampleValueHdr.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelExampleValueHdr.Name = "LabelExampleValueHdr"
        Me.LabelExampleValueHdr.Size = New System.Drawing.Size(128, 15)
        Me.LabelExampleValueHdr.TabIndex = 10
        Me.LabelExampleValueHdr.Text = "Example Display Text:"
        '
        'ButtonCenter
        '
        Me.ButtonCenter.Location = New System.Drawing.Point(149, 4)
        Me.ButtonCenter.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCenter.Name = "ButtonCenter"
        Me.ButtonCenter.Size = New System.Drawing.Size(62, 26)
        Me.ButtonCenter.TabIndex = 14
        Me.ButtonCenter.Text = "Center Text"
        Me.ButtonCenter.UseVisualStyleBackColor = True
        '
        'ButtonRight
        '
        Me.ButtonRight.Location = New System.Drawing.Point(216, 5)
        Me.ButtonRight.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonRight.Name = "ButtonRight"
        Me.ButtonRight.Size = New System.Drawing.Size(140, 25)
        Me.ButtonRight.TabIndex = 15
        Me.ButtonRight.Text = "Right Justify Text"
        Me.ButtonRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonRight.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 44)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(390, 51)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "This window is for the fine detail work which will determine where the text is di" &
    "splayed within the element, and the relevant sizes."
        '
        'checkFontSizeScalesYN
        '
        Me.checkFontSizeScalesYN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.checkFontSizeScalesYN.BackColor = System.Drawing.Color.Violet
        Me.checkFontSizeScalesYN.Checked = True
        Me.checkFontSizeScalesYN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkFontSizeScalesYN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkFontSizeScalesYN.Location = New System.Drawing.Point(476, 247)
        Me.checkFontSizeScalesYN.Margin = New System.Windows.Forms.Padding(2)
        Me.checkFontSizeScalesYN.Name = "checkFontSizeScalesYN"
        Me.checkFontSizeScalesYN.Size = New System.Drawing.Size(195, 58)
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
        Me.Panel1.Location = New System.Drawing.Point(10, 242)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(364, 32)
        Me.Panel1.TabIndex = 32
        '
        'ButtonLeft
        '
        Me.ButtonLeft.Location = New System.Drawing.Point(8, 4)
        Me.ButtonLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonLeft.Name = "ButtonLeft"
        Me.ButtonLeft.Size = New System.Drawing.Size(132, 26)
        Me.ButtonLeft.TabIndex = 31
        Me.ButtonLeft.Text = "Left Justify Text"
        Me.ButtonLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonLeft.UseVisualStyleBackColor = True
        '
        'ButtonApply
        '
        Me.ButtonApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonApply.Location = New System.Drawing.Point(9, 451)
        Me.ButtonApply.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonApply.Name = "ButtonApply"
        Me.ButtonApply.Size = New System.Drawing.Size(193, 44)
        Me.ButtonApply.TabIndex = 44
        Me.ButtonApply.Text = "Apply"
        Me.ButtonApply.UseVisualStyleBackColor = True
        '
        'LabelResultHdr
        '
        Me.LabelResultHdr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelResultHdr.AutoSize = True
        Me.LabelResultHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelResultHdr.Location = New System.Drawing.Point(5, 293)
        Me.LabelResultHdr.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelResultHdr.Name = "LabelResultHdr"
        Me.LabelResultHdr.Size = New System.Drawing.Size(257, 29)
        Me.LabelResultHdr.TabIndex = 45
        Me.LabelResultHdr.Text = "Preview of text display:"
        '
        'CtlTextOffsetX
        '
        Me.CtlTextOffsetX.BackColor = System.Drawing.Color.Plum
        Me.CtlTextOffsetX.Location = New System.Drawing.Point(10, 98)
        Me.CtlTextOffsetX.MinimumValue = 0
        Me.CtlTextOffsetX.Name = "CtlTextOffsetX"
        Me.CtlTextOffsetX.PropertyName = "Text Offset Horizontal"
        Me.CtlTextOffsetX.PropertyValue = 4
        Me.CtlTextOffsetX.Size = New System.Drawing.Size(163, 114)
        Me.CtlTextOffsetX.TabIndex = 43
        Me.ToolTip1.SetToolTip(Me.CtlTextOffsetX, "Text Offset is from the top-left corner of the label.")
        '
        'CtlElementWidth
        '
        Me.CtlElementWidth.BackColor = System.Drawing.Color.Plum
        Me.CtlElementWidth.Location = New System.Drawing.Point(188, 98)
        Me.CtlElementWidth.MinimumValue = 10
        Me.CtlElementWidth.Name = "CtlElementWidth"
        Me.CtlElementWidth.PropertyName = "Total Width of Label"
        Me.CtlElementWidth.PropertyValue = 100
        Me.CtlElementWidth.Size = New System.Drawing.Size(158, 114)
        Me.CtlElementWidth.TabIndex = 42
        '
        'CtlElementHeight
        '
        Me.CtlElementHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtlElementHeight.BackColor = System.Drawing.Color.Plum
        Me.CtlElementHeight.ElementInfo_Base = Nothing
        Me.CtlElementHeight.ElementInfo_Text = Nothing
        Me.CtlElementHeight.Location = New System.Drawing.Point(476, 127)
        Me.CtlElementHeight.MinimumValue = 0
        Me.CtlElementHeight.Name = "CtlElementHeight"
        Me.CtlElementHeight.PropertyName = "Total Height of Label"
        Me.CtlElementHeight.PropertyValue = 10
        Me.CtlElementHeight.Size = New System.Drawing.Size(197, 102)
        Me.CtlElementHeight.TabIndex = 41
        '
        'CtlFontSize
        '
        Me.CtlFontSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtlFontSize.BackColor = System.Drawing.Color.Violet
        Me.CtlFontSize.ElementInfo_Base = Nothing
        Me.CtlFontSize.ElementInfo_Text = Nothing
        Me.CtlFontSize.Enabled = False
        Me.CtlFontSize.Location = New System.Drawing.Point(496, 305)
        Me.CtlFontSize.MinimumValue = 0
        Me.CtlFontSize.Name = "CtlFontSize"
        Me.CtlFontSize.PropertyName = "Font Size Pixels"
        Me.CtlFontSize.PropertyValue = 25
        Me.CtlFontSize.Size = New System.Drawing.Size(174, 99)
        Me.CtlFontSize.TabIndex = 40
        '
        'ctlTextOffsetY
        '
        Me.ctlTextOffsetY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ctlTextOffsetY.BackColor = System.Drawing.Color.Plum
        Me.ctlTextOffsetY.ElementInfo_Base = Nothing
        Me.ctlTextOffsetY.ElementInfo_Text = Nothing
        Me.ctlTextOffsetY.Location = New System.Drawing.Point(476, 17)
        Me.ctlTextOffsetY.MinimumValue = 0
        Me.ctlTextOffsetY.Name = "ctlTextOffsetY"
        Me.ctlTextOffsetY.PropertyName = "Text Offset Vertical"
        Me.ctlTextOffsetY.PropertyValue = 10
        Me.ctlTextOffsetY.Size = New System.Drawing.Size(197, 104)
        Me.ctlTextOffsetY.TabIndex = 39
        Me.ToolTip1.SetToolTip(Me.ctlTextOffsetY, "Text Offset is from the top-left corner of the label.")
        '
        'CtlGraphicFldLabel1
        '
        Me.CtlGraphicFldLabel1.Location = New System.Drawing.Point(12, 346)
        Me.CtlGraphicFldLabel1.Name = "CtlGraphicFldLabel1"
        Me.CtlGraphicFldLabel1.Size = New System.Drawing.Size(347, 18)
        Me.CtlGraphicFldLabel1.TabIndex = 27
        '
        'LabelForBorderOnly
        '
        Me.LabelForBorderOnly.BackColor = System.Drawing.Color.Violet
        Me.LabelForBorderOnly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelForBorderOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelForBorderOnly.Location = New System.Drawing.Point(459, 242)
        Me.LabelForBorderOnly.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelForBorderOnly.Name = "LabelForBorderOnly"
        Me.LabelForBorderOnly.Size = New System.Drawing.Size(214, 175)
        Me.LabelForBorderOnly.TabIndex = 46
        '
        'DialogTextOffset
        '
        Me.AcceptButton = Me.ButtonOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Thistle
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(682, 504)
        Me.Controls.Add(Me.LabelResultHdr)
        Me.Controls.Add(Me.ButtonApply)
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
        Me.Controls.Add(Me.LabelForBorderOnly)
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
    Friend WithEvents CtlGraphicFldLabel1 As CtlGraphicFieldV3
    Friend WithEvents Label4 As Label
    Friend WithEvents checkFontSizeScalesYN As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ButtonLeft As Button
    Friend WithEvents ctlTextOffsetY As CtlPropertyUpDownvb
    Friend WithEvents CtlFontSize As CtlPropertyUpDownvb
    Friend WithEvents CtlElementHeight As CtlPropertyUpDownvb
    Friend WithEvents CtlElementWidth As CtlPropertyLeftRight
    Friend WithEvents CtlTextOffsetX As CtlPropertyLeftRight
    Friend WithEvents ButtonApply As Button
    Friend WithEvents LabelResultHdr As Label
    Friend WithEvents LabelForBorderOnly As Label
End Class
