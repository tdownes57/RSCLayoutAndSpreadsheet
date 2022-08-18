<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogPositioning
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
        Me.checkArrowMovesWithElem = New System.Windows.Forms.CheckBox()
        Me.checkBoxArrowVisible = New System.Windows.Forms.CheckBox()
        Me.LabelHeading2 = New System.Windows.Forms.Label()
        Me.LabelHeading1 = New System.Windows.Forms.Label()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.RscMoveableControlVB1 = New __RSCWindowsControlLibrary.RSCMoveableControlVB()
        Me.panelArrowRight = New __RSCWindowsControlLibrary.RSCMoveableControlVB()
        Me.panelArrowLeft = New __RSCWindowsControlLibrary.RSCMoveableControlVB()
        Me.panelDisplayElement = New System.Windows.Forms.PictureBox()
        CType(Me.panelDisplayElement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'checkArrowMovesWithElem
        '
        Me.checkArrowMovesWithElem.AutoSize = True
        Me.checkArrowMovesWithElem.Location = New System.Drawing.Point(643, 46)
        Me.checkArrowMovesWithElem.Name = "checkArrowMovesWithElem"
        Me.checkArrowMovesWithElem.Size = New System.Drawing.Size(207, 17)
        Me.checkArrowMovesWithElem.TabIndex = 27
        Me.checkArrowMovesWithElem.Text = "Gold arrow moves if element is moved."
        Me.checkArrowMovesWithElem.UseVisualStyleBackColor = True
        '
        'checkBoxArrowVisible
        '
        Me.checkBoxArrowVisible.AutoSize = True
        Me.checkBoxArrowVisible.Location = New System.Drawing.Point(643, 23)
        Me.checkBoxArrowVisible.Name = "checkBoxArrowVisible"
        Me.checkBoxArrowVisible.Size = New System.Drawing.Size(237, 17)
        Me.checkBoxArrowVisible.TabIndex = 24
        Me.checkBoxArrowVisible.Text = "Display a gold arrow for the editable element."
        Me.checkBoxArrowVisible.UseVisualStyleBackColor = True
        '
        'LabelHeading2
        '
        Me.LabelHeading2.AutoSize = True
        Me.LabelHeading2.Location = New System.Drawing.Point(620, 66)
        Me.LabelHeading2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeading2.Name = "LabelHeading2"
        Me.LabelHeading2.Size = New System.Drawing.Size(458, 13)
        Me.LabelHeading2.TabIndex = 23
        Me.LabelHeading2.Text = "(See element at center of the following box.  Any edits made below the box will b" &
    "e visible within.)"
        Me.LabelHeading2.Visible = False
        '
        'LabelHeading1
        '
        Me.LabelHeading1.AutoSize = True
        Me.LabelHeading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeading1.Location = New System.Drawing.Point(9, 14)
        Me.LabelHeading1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeading1.Name = "LabelHeading1"
        Me.LabelHeading1.Size = New System.Drawing.Size(473, 26)
        Me.LabelHeading1.TabIndex = 22
        Me.LabelHeading1.Text = "Modify the element indicated by the gold arrow. "
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonCancel.BackColor = System.Drawing.Color.PaleGreen
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(906, 400)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(101, 34)
        Me.ButtonCancel.TabIndex = 21
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonOK.BackColor = System.Drawing.Color.PaleGreen
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(786, 400)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(101, 34)
        Me.ButtonOK.TabIndex = 20
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'RscMoveableControlVB1
        '
        Me.RscMoveableControlVB1.BackColor = System.Drawing.Color.Transparent
        Me.RscMoveableControlVB1.BackgroundImage = Global.ciBadgeDesigner.My.Resources.Resources.Gold_Arrow__crop____Right
        Me.RscMoveableControlVB1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RscMoveableControlVB1.ElementInfo_Base = Nothing
        Me.RscMoveableControlVB1.ImageLocation = Nothing
        Me.RscMoveableControlVB1.Location = New System.Drawing.Point(885, 11)
        Me.RscMoveableControlVB1.Margin = New System.Windows.Forms.Padding(2)
        Me.RscMoveableControlVB1.MoveabilityEventsForGroupCtls = Nothing
        Me.RscMoveableControlVB1.MoveabilityEventsForSingleMove = Nothing
        Me.RscMoveableControlVB1.Name = "RscMoveableControlVB1"
        Me.RscMoveableControlVB1.Size = New System.Drawing.Size(73, 41)
        Me.RscMoveableControlVB1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
        Me.RscMoveableControlVB1.TabIndex = 28
        '
        'panelArrowRight
        '
        Me.panelArrowRight.BackColor = System.Drawing.Color.Transparent
        Me.panelArrowRight.BackgroundImage = Global.ciBadgeDesigner.My.Resources.Resources.Gold_Arrow__crop____Right
        Me.panelArrowRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.panelArrowRight.ElementInfo_Base = Nothing
        Me.panelArrowRight.ImageLocation = Nothing
        Me.panelArrowRight.Location = New System.Drawing.Point(807, 118)
        Me.panelArrowRight.Margin = New System.Windows.Forms.Padding(2)
        Me.panelArrowRight.MoveabilityEventsForGroupCtls = Nothing
        Me.panelArrowRight.MoveabilityEventsForSingleMove = Nothing
        Me.panelArrowRight.Name = "panelArrowRight"
        Me.panelArrowRight.Size = New System.Drawing.Size(73, 41)
        Me.panelArrowRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
        Me.panelArrowRight.TabIndex = 26
        '
        'panelArrowLeft
        '
        Me.panelArrowLeft.BackColor = System.Drawing.Color.Transparent
        Me.panelArrowLeft.BackgroundImage = Global.ciBadgeDesigner.My.Resources.Resources.Gold_Arrow__crop_
        Me.panelArrowLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.panelArrowLeft.ElementInfo_Base = Nothing
        Me.panelArrowLeft.ImageLocation = Nothing
        Me.panelArrowLeft.Location = New System.Drawing.Point(807, 163)
        Me.panelArrowLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.panelArrowLeft.MoveabilityEventsForGroupCtls = Nothing
        Me.panelArrowLeft.MoveabilityEventsForSingleMove = Nothing
        Me.panelArrowLeft.Name = "panelArrowLeft"
        Me.panelArrowLeft.Size = New System.Drawing.Size(73, 41)
        Me.panelArrowLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
        Me.panelArrowLeft.TabIndex = 25
        '
        'panelDisplayElement
        '
        Me.panelDisplayElement.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.panelDisplayElement.Location = New System.Drawing.Point(12, 46)
        Me.panelDisplayElement.Name = "panelDisplayElement"
        Me.panelDisplayElement.Size = New System.Drawing.Size(603, 380)
        Me.panelDisplayElement.TabIndex = 19
        Me.panelDisplayElement.TabStop = False
        '
        'DialogPositioning
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1114, 450)
        Me.Controls.Add(Me.RscMoveableControlVB1)
        Me.Controls.Add(Me.panelArrowRight)
        Me.Controls.Add(Me.panelArrowLeft)
        Me.Controls.Add(Me.checkArrowMovesWithElem)
        Me.Controls.Add(Me.panelDisplayElement)
        Me.Controls.Add(Me.checkBoxArrowVisible)
        Me.Controls.Add(Me.LabelHeading2)
        Me.Controls.Add(Me.LabelHeading1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Name = "DialogPositioning"
        Me.Text = "DialogPositioning"
        CType(Me.panelDisplayElement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panelArrowRight As __RSCWindowsControlLibrary.RSCMoveableControlVB
    Friend WithEvents panelArrowLeft As __RSCWindowsControlLibrary.RSCMoveableControlVB
    Friend WithEvents checkArrowMovesWithElem As CheckBox
    Friend WithEvents panelDisplayElement As PictureBox
    Friend WithEvents checkBoxArrowVisible As CheckBox
    Friend WithEvents LabelHeading2 As Label
    Friend WithEvents LabelHeading1 As Label
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents RscMoveableControlVB1 As __RSCWindowsControlLibrary.RSCMoveableControlVB
End Class
