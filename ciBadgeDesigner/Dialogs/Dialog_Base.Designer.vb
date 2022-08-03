<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_Base
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
        Me.PanelDisplayElement = New System.Windows.Forms.Panel()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.LabelHeading1 = New System.Windows.Forms.Label()
        Me.LabelHeading2 = New System.Windows.Forms.Label()
        Me.ButtonColor = New System.Windows.Forms.Button()
        Me.ButtonFont = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ButtonBorder = New System.Windows.Forms.Button()
        Me.ButtonTextPlacement = New System.Windows.Forms.Button()
        Me.PanelEditorControls = New System.Windows.Forms.Panel()
        Me.ButtonTextstring = New System.Windows.Forms.Button()
        Me.checkBoxArrow = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.panelArrowLeft = New __RSCWindowsControlLibrary.RSCMoveableControlVB()
        Me.panelArrowRight = New __RSCWindowsControlLibrary.RSCMoveableControlVB()
        Me.PanelEditorControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelDisplayElement
        '
        Me.PanelDisplayElement.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PanelDisplayElement.Location = New System.Drawing.Point(11, 47)
        Me.PanelDisplayElement.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelDisplayElement.Name = "PanelDisplayElement"
        Me.PanelDisplayElement.Size = New System.Drawing.Size(603, 380)
        Me.PanelDisplayElement.TabIndex = 1
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonOK.BackColor = System.Drawing.Color.PaleGreen
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(629, 393)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(101, 34)
        Me.ButtonOK.TabIndex = 2
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonCancel.BackColor = System.Drawing.Color.PaleGreen
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(749, 393)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(101, 34)
        Me.ButtonCancel.TabIndex = 3
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'LabelHeading1
        '
        Me.LabelHeading1.AutoSize = True
        Me.LabelHeading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeading1.Location = New System.Drawing.Point(9, 7)
        Me.LabelHeading1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeading1.Name = "LabelHeading1"
        Me.LabelHeading1.Size = New System.Drawing.Size(473, 26)
        Me.LabelHeading1.TabIndex = 4
        Me.LabelHeading1.Text = "Modify the element indicated by the gold arrow. "
        '
        'LabelHeading2
        '
        Me.LabelHeading2.AutoSize = True
        Me.LabelHeading2.Location = New System.Drawing.Point(581, 9)
        Me.LabelHeading2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeading2.Name = "LabelHeading2"
        Me.LabelHeading2.Size = New System.Drawing.Size(458, 13)
        Me.LabelHeading2.TabIndex = 5
        Me.LabelHeading2.Text = "(See element at center of the following box.  Any edits made below the box will b" &
    "e visible within.)"
        Me.LabelHeading2.Visible = False
        '
        'ButtonColor
        '
        Me.ButtonColor.Location = New System.Drawing.Point(120, 11)
        Me.ButtonColor.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonColor.Name = "ButtonColor"
        Me.ButtonColor.Size = New System.Drawing.Size(101, 34)
        Me.ButtonColor.TabIndex = 7
        Me.ButtonColor.Text = "Colors"
        Me.ButtonColor.UseVisualStyleBackColor = True
        '
        'ButtonFont
        '
        Me.ButtonFont.Location = New System.Drawing.Point(7, 11)
        Me.ButtonFont.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonFont.Name = "ButtonFont"
        Me.ButtonFont.Size = New System.Drawing.Size(101, 34)
        Me.ButtonFont.TabIndex = 6
        Me.ButtonFont.Text = "Font"
        Me.ButtonFont.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(351, 11)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(101, 34)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Rotation"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ButtonBorder
        '
        Me.ButtonBorder.Location = New System.Drawing.Point(238, 11)
        Me.ButtonBorder.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonBorder.Name = "ButtonBorder"
        Me.ButtonBorder.Size = New System.Drawing.Size(101, 34)
        Me.ButtonBorder.TabIndex = 8
        Me.ButtonBorder.Text = "Border"
        Me.ButtonBorder.UseVisualStyleBackColor = True
        '
        'ButtonTextPlacement
        '
        Me.ButtonTextPlacement.Location = New System.Drawing.Point(464, 11)
        Me.ButtonTextPlacement.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonTextPlacement.Name = "ButtonTextPlacement"
        Me.ButtonTextPlacement.Size = New System.Drawing.Size(101, 34)
        Me.ButtonTextPlacement.TabIndex = 10
        Me.ButtonTextPlacement.Text = "Text Placement"
        Me.ButtonTextPlacement.UseVisualStyleBackColor = True
        '
        'PanelEditorControls
        '
        Me.PanelEditorControls.BackColor = System.Drawing.Color.LightBlue
        Me.PanelEditorControls.Controls.Add(Me.ButtonTextstring)
        Me.PanelEditorControls.Controls.Add(Me.ButtonTextPlacement)
        Me.PanelEditorControls.Controls.Add(Me.ButtonFont)
        Me.PanelEditorControls.Controls.Add(Me.Button3)
        Me.PanelEditorControls.Controls.Add(Me.ButtonColor)
        Me.PanelEditorControls.Controls.Add(Me.ButtonBorder)
        Me.PanelEditorControls.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEditorControls.Location = New System.Drawing.Point(0, 447)
        Me.PanelEditorControls.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelEditorControls.Name = "PanelEditorControls"
        Me.PanelEditorControls.Size = New System.Drawing.Size(945, 55)
        Me.PanelEditorControls.TabIndex = 11
        '
        'ButtonTextstring
        '
        Me.ButtonTextstring.Location = New System.Drawing.Point(584, 11)
        Me.ButtonTextstring.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonTextstring.Name = "ButtonTextstring"
        Me.ButtonTextstring.Size = New System.Drawing.Size(101, 34)
        Me.ButtonTextstring.TabIndex = 11
        Me.ButtonTextstring.Text = "Text / String"
        Me.ButtonTextstring.UseVisualStyleBackColor = True
        '
        'checkBoxArrow
        '
        Me.checkBoxArrow.AutoSize = True
        Me.checkBoxArrow.Location = New System.Drawing.Point(506, 16)
        Me.checkBoxArrow.Name = "checkBoxArrow"
        Me.checkBoxArrow.Size = New System.Drawing.Size(237, 17)
        Me.checkBoxArrow.TabIndex = 12
        Me.checkBoxArrow.Text = "Display a gold arrow for the editable element."
        Me.checkBoxArrow.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.ciBadgeDesigner.My.Resources.Resources.Gold_Arrow__crop_
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Location = New System.Drawing.Point(749, 9)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(86, 37)
        Me.Panel2.TabIndex = 15
        '
        'panelArrowLeft
        '
        Me.panelArrowLeft.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.panelArrowLeft.BackgroundImage = Global.ciBadgeDesigner.My.Resources.Resources.Gold_Arrow__crop_
        Me.panelArrowLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.panelArrowLeft.ElementInfo_Base = Nothing
        Me.panelArrowLeft.Location = New System.Drawing.Point(677, 177)
        Me.panelArrowLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.panelArrowLeft.MoveabilityEventsForGroupCtls = Nothing
        Me.panelArrowLeft.MoveabilityEventsForSingleMove = Nothing
        Me.panelArrowLeft.Name = "panelArrowLeft"
        Me.panelArrowLeft.Size = New System.Drawing.Size(73, 41)
        Me.panelArrowLeft.TabIndex = 16
        '
        'panelArrowRight
        '
        Me.panelArrowRight.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.panelArrowRight.BackgroundImage = Global.ciBadgeDesigner.My.Resources.Resources.Gold_Arrow__crop____Right
        Me.panelArrowRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.panelArrowRight.ElementInfo_Base = Nothing
        Me.panelArrowRight.Location = New System.Drawing.Point(677, 234)
        Me.panelArrowRight.Margin = New System.Windows.Forms.Padding(2)
        Me.panelArrowRight.MoveabilityEventsForGroupCtls = Nothing
        Me.panelArrowRight.MoveabilityEventsForSingleMove = Nothing
        Me.panelArrowRight.Name = "panelArrowRight"
        Me.panelArrowRight.Size = New System.Drawing.Size(73, 41)
        Me.panelArrowRight.TabIndex = 17
        '
        'Dialog_Base
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 502)
        Me.Controls.Add(Me.panelArrowRight)
        Me.Controls.Add(Me.panelArrowLeft)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.checkBoxArrow)
        Me.Controls.Add(Me.PanelEditorControls)
        Me.Controls.Add(Me.LabelHeading2)
        Me.Controls.Add(Me.LabelHeading1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.PanelDisplayElement)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Dialog_Base"
        Me.Text = "Dialog_Base"
        Me.PanelEditorControls.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelDisplayElement As Panel
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents LabelHeading1 As Label
    Friend WithEvents LabelHeading2 As Label
    Friend WithEvents ButtonColor As Button
    Friend WithEvents ButtonFont As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ButtonBorder As Button
    Friend WithEvents ButtonTextPlacement As Button
    Friend WithEvents PanelEditorControls As Panel
    Friend WithEvents ButtonTextstring As Button
    Friend WithEvents checkBoxArrow As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents panelArrowLeft As __RSCWindowsControlLibrary.RSCMoveableControlVB
    Friend WithEvents panelArrowRight As __RSCWindowsControlLibrary.RSCMoveableControlVB
End Class
