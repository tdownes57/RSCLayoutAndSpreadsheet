﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCFieldSpreadsheet
    Inherits __RSCWindowsControlLibrary.RSCMoveableControlVB ''System.Windows.Forms.UserControl

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
        Me.LinkLabelRightClickMenu = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelReviewFields = New System.Windows.Forms.LinkLabel()
        Me.ButtonPasteData1 = New System.Windows.Forms.Button()
        Me.ButtonAddColumns1 = New System.Windows.Forms.Button()
        Me.ButtonAddColumns2 = New System.Windows.Forms.Button()
        Me.ButtonPasteData2 = New System.Windows.Forms.Button()
        Me.RscFieldColumn1 = New ciBadgeDesigner.RSCFieldColumnV2()
        Me.RscRowHeaders1 = New ciBadgeDesigner.RSCRowHeaders()
        Me.linkPrintAll = New System.Windows.Forms.LinkLabel()
        Me.linkDisplayAll = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'LinkLabelRightClickMenu
        '
        Me.LinkLabelRightClickMenu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelRightClickMenu.AutoSize = True
        Me.LinkLabelRightClickMenu.Location = New System.Drawing.Point(525, 0)
        Me.LinkLabelRightClickMenu.Name = "LinkLabelRightClickMenu"
        Me.LinkLabelRightClickMenu.Size = New System.Drawing.Size(153, 13)
        Me.LinkLabelRightClickMenu.TabIndex = 6
        Me.LinkLabelRightClickMenu.TabStop = True
        Me.LinkLabelRightClickMenu.Text = "Right-click will present a menu."
        '
        'LinkLabelReviewFields
        '
        Me.LinkLabelReviewFields.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelReviewFields.AutoSize = True
        Me.LinkLabelReviewFields.Location = New System.Drawing.Point(444, 16)
        Me.LinkLabelReviewFields.Name = "LinkLabelReviewFields"
        Me.LinkLabelReviewFields.Size = New System.Drawing.Size(234, 13)
        Me.LinkLabelReviewFields.TabIndex = 7
        Me.LinkLabelReviewFields.TabStop = True
        Me.LinkLabelReviewFields.Text = "Review which fields are Relevant and available."
        '
        'ButtonPasteData1
        '
        Me.ButtonPasteData1.BackColor = System.Drawing.Color.White
        Me.ButtonPasteData1.Location = New System.Drawing.Point(20, 30)
        Me.ButtonPasteData1.Name = "ButtonPasteData1"
        Me.ButtonPasteData1.Size = New System.Drawing.Size(90, 51)
        Me.ButtonPasteData1.TabIndex = 10
        Me.ButtonPasteData1.Text = "Paste Data"
        Me.ButtonPasteData1.UseVisualStyleBackColor = False
        '
        'ButtonAddColumns1
        '
        Me.ButtonAddColumns1.BackColor = System.Drawing.Color.White
        Me.ButtonAddColumns1.Location = New System.Drawing.Point(20, 86)
        Me.ButtonAddColumns1.Name = "ButtonAddColumns1"
        Me.ButtonAddColumns1.Size = New System.Drawing.Size(90, 48)
        Me.ButtonAddColumns1.TabIndex = 11
        Me.ButtonAddColumns1.Text = "Add Columns"
        Me.ButtonAddColumns1.UseVisualStyleBackColor = False
        '
        'ButtonAddColumns2
        '
        Me.ButtonAddColumns2.BackColor = System.Drawing.Color.White
        Me.ButtonAddColumns2.Location = New System.Drawing.Point(530, 114)
        Me.ButtonAddColumns2.Name = "ButtonAddColumns2"
        Me.ButtonAddColumns2.Size = New System.Drawing.Size(150, 48)
        Me.ButtonAddColumns2.TabIndex = 13
        Me.ButtonAddColumns2.Text = "Add Columns"
        Me.ButtonAddColumns2.UseVisualStyleBackColor = False
        '
        'ButtonPasteData2
        '
        Me.ButtonPasteData2.BackColor = System.Drawing.Color.White
        Me.ButtonPasteData2.Location = New System.Drawing.Point(530, 58)
        Me.ButtonPasteData2.Name = "ButtonPasteData2"
        Me.ButtonPasteData2.Size = New System.Drawing.Size(150, 51)
        Me.ButtonPasteData2.TabIndex = 12
        Me.ButtonPasteData2.Text = "Paste Data"
        Me.ButtonPasteData2.UseVisualStyleBackColor = False
        '
        'RscFieldColumn1
        '
        Me.RscFieldColumn1.BackColor = System.Drawing.Color.MediumTurquoise
        Me.RscFieldColumn1.ColumnWidthAndData = Nothing
        Me.RscFieldColumn1.ElementInfo_Base = Nothing
        Me.RscFieldColumn1.ImageLocation = Nothing
        Me.RscFieldColumn1.Location = New System.Drawing.Point(115, 43)
        Me.RscFieldColumn1.Margin = New System.Windows.Forms.Padding(2)
        Me.RscFieldColumn1.MoveabilityEventsForGroupCtls = Nothing
        Me.RscFieldColumn1.MoveabilityEventsForSingleMove = Nothing
        Me.RscFieldColumn1.Name = "RscFieldColumn1"
        Me.RscFieldColumn1.PixelsFromRowToRow = 24
        Me.RscFieldColumn1.Size = New System.Drawing.Size(175, 555)
        Me.RscFieldColumn1.SizeabilityEventsForGroupCtls = Nothing
        Me.RscFieldColumn1.SizeabilityEventsForSingleMove = Nothing
        Me.RscFieldColumn1.SizeabilityEventsForSingleSize = Nothing
        Me.RscFieldColumn1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
        Me.RscFieldColumn1.TabIndex = 9
        '
        'RscRowHeaders1
        '
        Me.RscRowHeaders1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RscRowHeaders1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RscRowHeaders1.ColumnWidthAndData = Nothing
        Me.RscRowHeaders1.ElementInfo_Base = Nothing
        Me.RscRowHeaders1.ImageLocation = Nothing
        Me.RscRowHeaders1.Location = New System.Drawing.Point(2, 139)
        Me.RscRowHeaders1.Margin = New System.Windows.Forms.Padding(2)
        Me.RscRowHeaders1.MoveabilityEventsForGroupCtls = Nothing
        Me.RscRowHeaders1.MoveabilityEventsForSingleMove = Nothing
        Me.RscRowHeaders1.Name = "RscRowHeaders1"
        Me.RscRowHeaders1.PixelsFromRowToRow = 24
        Me.RscRowHeaders1.Size = New System.Drawing.Size(125, 613)
        Me.RscRowHeaders1.SizeabilityEventsForGroupCtls = Nothing
        Me.RscRowHeaders1.SizeabilityEventsForSingleMove = Nothing
        Me.RscRowHeaders1.SizeabilityEventsForSingleSize = Nothing
        Me.RscRowHeaders1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
        Me.RscRowHeaders1.TabIndex = 8
        '
        'linkPrintAll
        '
        Me.linkPrintAll.AutoSize = True
        Me.linkPrintAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linkPrintAll.Location = New System.Drawing.Point(328, 0)
        Me.linkPrintAll.Name = "linkPrintAll"
        Me.linkPrintAll.Size = New System.Drawing.Size(109, 25)
        Me.linkPrintAll.TabIndex = 14
        Me.linkPrintAll.TabStop = True
        Me.linkPrintAll.Text = "Print all IDs"
        '
        'linkDisplayAll
        '
        Me.linkDisplayAll.AutoSize = True
        Me.linkDisplayAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linkDisplayAll.Location = New System.Drawing.Point(145, 0)
        Me.linkDisplayAll.Name = "linkDisplayAll"
        Me.linkDisplayAll.Size = New System.Drawing.Size(134, 25)
        Me.linkDisplayAll.TabIndex = 15
        Me.linkDisplayAll.TabStop = True
        Me.linkDisplayAll.Text = "Display all IDs"
        '
        'RSCFieldSpreadsheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Controls.Add(Me.linkDisplayAll)
        Me.Controls.Add(Me.linkPrintAll)
        Me.Controls.Add(Me.ButtonAddColumns2)
        Me.Controls.Add(Me.ButtonPasteData2)
        Me.Controls.Add(Me.ButtonAddColumns1)
        Me.Controls.Add(Me.ButtonPasteData1)
        Me.Controls.Add(Me.RscFieldColumn1)
        Me.Controls.Add(Me.RscRowHeaders1)
        Me.Controls.Add(Me.LinkLabelReviewFields)
        Me.Controls.Add(Me.LinkLabelRightClickMenu)
        Me.Name = "RSCFieldSpreadsheet"
        Me.Size = New System.Drawing.Size(651, 542)
        Me.Controls.SetChildIndex(Me.LinkLabelConditional, 0)
        Me.Controls.SetChildIndex(Me.LinkLabelRightClickMenu, 0)
        Me.Controls.SetChildIndex(Me.LinkLabelReviewFields, 0)
        Me.Controls.SetChildIndex(Me.RscRowHeaders1, 0)
        Me.Controls.SetChildIndex(Me.RscFieldColumn1, 0)
        Me.Controls.SetChildIndex(Me.ButtonPasteData1, 0)
        Me.Controls.SetChildIndex(Me.ButtonAddColumns1, 0)
        Me.Controls.SetChildIndex(Me.ButtonPasteData2, 0)
        Me.Controls.SetChildIndex(Me.ButtonAddColumns2, 0)
        Me.Controls.SetChildIndex(Me.linkPrintAll, 0)
        Me.Controls.SetChildIndex(Me.linkDisplayAll, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkLabelRightClickMenu As LinkLabel
    Friend WithEvents LinkLabelReviewFields As LinkLabel
    Public WithEvents RscRowHeaders1 As RSCRowHeaders
    Public WithEvents RscFieldColumn1 As RSCFieldColumnV2
    Friend WithEvents ButtonPasteData1 As Button
    Friend WithEvents ButtonAddColumns1 As Button
    Friend WithEvents ButtonAddColumns2 As Button
    Friend WithEvents ButtonPasteData2 As Button
    Friend WithEvents linkPrintAll As LinkLabel
    Friend WithEvents linkDisplayAll As LinkLabel
End Class
