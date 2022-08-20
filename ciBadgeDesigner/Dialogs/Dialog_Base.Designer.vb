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
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.LabelHeading1 = New System.Windows.Forms.Label()
        Me.LabelHeading2 = New System.Windows.Forms.Label()
        Me.buttonColor = New System.Windows.Forms.Button()
        Me.buttonFont = New System.Windows.Forms.Button()
        Me.buttonRotation = New System.Windows.Forms.Button()
        Me.buttonBorder = New System.Windows.Forms.Button()
        Me.buttonTextPlacement = New System.Windows.Forms.Button()
        Me.PanelEditorControls = New System.Windows.Forms.Panel()
        Me.buttonTextstring = New System.Windows.Forms.Button()
        Me.checkBoxArrowVisible = New System.Windows.Forms.CheckBox()
        Me.checkArrowMovesWithElem = New System.Windows.Forms.CheckBox()
        Me.panelDisplayElement = New System.Windows.Forms.PictureBox()
        Me.panelArrowRight = New __RSCWindowsControlLibrary.RSCMoveableControlVB()
        Me.panelArrowLeft = New __RSCWindowsControlLibrary.RSCMoveableControlVB()
        Me.PanelEditorControls.SuspendLayout()
        CType(Me.panelDisplayElement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.LabelHeading2.Location = New System.Drawing.Point(620, 59)
        Me.LabelHeading2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeading2.Name = "LabelHeading2"
        Me.LabelHeading2.Size = New System.Drawing.Size(458, 13)
        Me.LabelHeading2.TabIndex = 5
        Me.LabelHeading2.Text = "(See element at center of the following box.  Any edits made below the box will b" &
    "e visible within.)"
        Me.LabelHeading2.Visible = False
        '
        'buttonColor
        '
        Me.buttonColor.BackColor = System.Drawing.Color.Thistle
        Me.buttonColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonColor.ForeColor = System.Drawing.Color.Purple
        Me.buttonColor.Location = New System.Drawing.Point(120, 11)
        Me.buttonColor.Margin = New System.Windows.Forms.Padding(2)
        Me.buttonColor.Name = "buttonColor"
        Me.buttonColor.Size = New System.Drawing.Size(101, 34)
        Me.buttonColor.TabIndex = 7
        Me.buttonColor.Text = "Colors"
        Me.buttonColor.UseVisualStyleBackColor = False
        '
        'buttonFont
        '
        Me.buttonFont.Font = New System.Drawing.Font("Ink Free", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonFont.Location = New System.Drawing.Point(7, 11)
        Me.buttonFont.Margin = New System.Windows.Forms.Padding(2)
        Me.buttonFont.Name = "buttonFont"
        Me.buttonFont.Size = New System.Drawing.Size(101, 34)
        Me.buttonFont.TabIndex = 6
        Me.buttonFont.Text = "Font"
        Me.buttonFont.UseVisualStyleBackColor = True
        '
        'buttonRotation
        '
        Me.buttonRotation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonRotation.Location = New System.Drawing.Point(351, 11)
        Me.buttonRotation.Margin = New System.Windows.Forms.Padding(2)
        Me.buttonRotation.Name = "buttonRotation"
        Me.buttonRotation.Size = New System.Drawing.Size(122, 34)
        Me.buttonRotation.TabIndex = 9
        Me.buttonRotation.Text = "▼Rotation▲"
        Me.buttonRotation.UseVisualStyleBackColor = True
        '
        'buttonBorder
        '
        Me.buttonBorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonBorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonBorder.Location = New System.Drawing.Point(238, 11)
        Me.buttonBorder.Margin = New System.Windows.Forms.Padding(2)
        Me.buttonBorder.Name = "buttonBorder"
        Me.buttonBorder.Size = New System.Drawing.Size(101, 34)
        Me.buttonBorder.TabIndex = 8
        Me.buttonBorder.Text = "Border"
        Me.buttonBorder.UseVisualStyleBackColor = True
        '
        'buttonTextPlacement
        '
        Me.buttonTextPlacement.Location = New System.Drawing.Point(488, 11)
        Me.buttonTextPlacement.Margin = New System.Windows.Forms.Padding(2)
        Me.buttonTextPlacement.Name = "buttonTextPlacement"
        Me.buttonTextPlacement.Size = New System.Drawing.Size(101, 34)
        Me.buttonTextPlacement.TabIndex = 10
        Me.buttonTextPlacement.Text = "Text Placement"
        Me.buttonTextPlacement.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.buttonTextPlacement.UseVisualStyleBackColor = True
        '
        'PanelEditorControls
        '
        Me.PanelEditorControls.BackColor = System.Drawing.Color.LightBlue
        Me.PanelEditorControls.Controls.Add(Me.buttonTextstring)
        Me.PanelEditorControls.Controls.Add(Me.buttonTextPlacement)
        Me.PanelEditorControls.Controls.Add(Me.buttonFont)
        Me.PanelEditorControls.Controls.Add(Me.buttonRotation)
        Me.PanelEditorControls.Controls.Add(Me.buttonColor)
        Me.PanelEditorControls.Controls.Add(Me.buttonBorder)
        Me.PanelEditorControls.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEditorControls.Location = New System.Drawing.Point(0, 447)
        Me.PanelEditorControls.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelEditorControls.Name = "PanelEditorControls"
        Me.PanelEditorControls.Size = New System.Drawing.Size(945, 55)
        Me.PanelEditorControls.TabIndex = 11
        '
        'buttonTextstring
        '
        Me.buttonTextstring.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonTextstring.Location = New System.Drawing.Point(605, 11)
        Me.buttonTextstring.Margin = New System.Windows.Forms.Padding(2)
        Me.buttonTextstring.Name = "buttonTextstring"
        Me.buttonTextstring.Size = New System.Drawing.Size(234, 34)
        Me.buttonTextstring.TabIndex = 11
        Me.buttonTextstring.Text = "Text / Words you want to see on ID card"
        Me.buttonTextstring.UseVisualStyleBackColor = True
        '
        'checkBoxArrowVisible
        '
        Me.checkBoxArrowVisible.AutoSize = True
        Me.checkBoxArrowVisible.Location = New System.Drawing.Point(506, 16)
        Me.checkBoxArrowVisible.Name = "checkBoxArrowVisible"
        Me.checkBoxArrowVisible.Size = New System.Drawing.Size(237, 17)
        Me.checkBoxArrowVisible.TabIndex = 12
        Me.checkBoxArrowVisible.Text = "Display a gold arrow for the editable element."
        Me.checkBoxArrowVisible.UseVisualStyleBackColor = True
        '
        'checkArrowMovesWithElem
        '
        Me.checkArrowMovesWithElem.AutoSize = True
        Me.checkArrowMovesWithElem.Location = New System.Drawing.Point(643, 39)
        Me.checkArrowMovesWithElem.Name = "checkArrowMovesWithElem"
        Me.checkArrowMovesWithElem.Size = New System.Drawing.Size(207, 17)
        Me.checkArrowMovesWithElem.TabIndex = 18
        Me.checkArrowMovesWithElem.Text = "Gold arrow moves if element is moved."
        Me.checkArrowMovesWithElem.UseVisualStyleBackColor = True
        '
        'panelDisplayElement
        '
        Me.panelDisplayElement.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.panelDisplayElement.Location = New System.Drawing.Point(12, 39)
        Me.panelDisplayElement.Name = "panelDisplayElement"
        Me.panelDisplayElement.Size = New System.Drawing.Size(603, 380)
        Me.panelDisplayElement.TabIndex = 0
        Me.panelDisplayElement.TabStop = False
        '
        'panelArrowRight
        '
        Me.panelArrowRight.BackColor = System.Drawing.Color.Transparent
        Me.panelArrowRight.BackgroundImage = Global.ciBadgeDesigner.My.Resources.Resources.Gold_Arrow__crop____Right
        Me.panelArrowRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.panelArrowRight.ElementInfo_Base = Nothing
        Me.panelArrowRight.ImageLocation = Nothing
        Me.panelArrowRight.Location = New System.Drawing.Point(120, 16)
        Me.panelArrowRight.Margin = New System.Windows.Forms.Padding(2)
        Me.panelArrowRight.MoveabilityEventsForGroupCtls = Nothing
        Me.panelArrowRight.MoveabilityEventsForSingleMove = Nothing
        Me.panelArrowRight.Name = "panelArrowRight"
        Me.panelArrowRight.Size = New System.Drawing.Size(73, 41)
        Me.panelArrowRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
        Me.panelArrowRight.TabIndex = 17
        '
        'panelArrowLeft
        '
        Me.panelArrowLeft.BackColor = System.Drawing.Color.Transparent
        Me.panelArrowLeft.BackgroundImage = Global.ciBadgeDesigner.My.Resources.Resources.Gold_Arrow__crop_
        Me.panelArrowLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.panelArrowLeft.ElementInfo_Base = Nothing
        Me.panelArrowLeft.ImageLocation = Nothing
        Me.panelArrowLeft.Location = New System.Drawing.Point(24, 16)
        Me.panelArrowLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.panelArrowLeft.MoveabilityEventsForGroupCtls = Nothing
        Me.panelArrowLeft.MoveabilityEventsForSingleMove = Nothing
        Me.panelArrowLeft.Name = "panelArrowLeft"
        Me.panelArrowLeft.Size = New System.Drawing.Size(73, 41)
        Me.panelArrowLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
        Me.panelArrowLeft.TabIndex = 16
        '
        'Dialog_Base
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 502)
        Me.Controls.Add(Me.panelArrowRight)
        Me.Controls.Add(Me.panelArrowLeft)
        Me.Controls.Add(Me.checkArrowMovesWithElem)
        Me.Controls.Add(Me.panelDisplayElement)
        Me.Controls.Add(Me.checkBoxArrowVisible)
        Me.Controls.Add(Me.PanelEditorControls)
        Me.Controls.Add(Me.LabelHeading2)
        Me.Controls.Add(Me.LabelHeading1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Dialog_Base"
        Me.Text = "Dialog_Base"
        Me.PanelEditorControls.ResumeLayout(False)
        CType(Me.panelDisplayElement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents LabelHeading1 As Label
    Friend WithEvents LabelHeading2 As Label
    Friend WithEvents buttonColor As Button
    Friend WithEvents buttonFont As Button
    Friend WithEvents buttonRotation As Button
    Friend WithEvents buttonBorder As Button
    Friend WithEvents buttonTextPlacement As Button
    Friend WithEvents PanelEditorControls As Panel
    Friend WithEvents buttonTextstring As Button
    Friend WithEvents checkBoxArrowVisible As CheckBox
    Friend WithEvents panelArrowLeft As __RSCWindowsControlLibrary.RSCMoveableControlVB
    Friend WithEvents panelArrowRight As __RSCWindowsControlLibrary.RSCMoveableControlVB
    Friend WithEvents panelDisplayElement As PictureBox
    Friend WithEvents checkArrowMovesWithElem As CheckBox
End Class
