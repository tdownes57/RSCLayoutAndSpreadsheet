<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogEditRecipients
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
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabelOpenFieldsDialog = New System.Windows.Forms.LinkLabel()
        Me.ButtonPasteData = New System.Windows.Forms.Button()
        Me.RscFieldSpreadsheet1 = New ciBadgeDesigner.RSCFieldSpreadsheet()
        Me.LinkLabelWarningNotSaved = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelSaveAsRecipients = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelRefreshFromRecipients = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelSaveColumnData = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelAlignBars = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelClearSpreadsheet = New System.Windows.Forms.LinkLabel()
        Me.ButtonScrollDown20 = New System.Windows.Forms.Button()
        Me.ButtonScrollUp = New System.Windows.Forms.Button()
        Me.ButtonScrollDown5 = New System.Windows.Forms.Button()
        Me.LinkRefreshRowHeaderHeights = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(821, 541)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(80, 48)
        Me.ButtonCancel.TabIndex = 15
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(664, 541)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(139, 48)
        Me.ButtonOK.TabIndex = 14
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(401, 24)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Paste && Edit Recipients (Students or Members)"
        '
        'LinkLabelOpenFieldsDialog
        '
        Me.LinkLabelOpenFieldsDialog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelOpenFieldsDialog.AutoSize = True
        Me.LinkLabelOpenFieldsDialog.Location = New System.Drawing.Point(9, 544)
        Me.LinkLabelOpenFieldsDialog.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabelOpenFieldsDialog.Name = "LinkLabelOpenFieldsDialog"
        Me.LinkLabelOpenFieldsDialog.Size = New System.Drawing.Size(198, 13)
        Me.LinkLabelOpenFieldsDialog.TabIndex = 17
        Me.LinkLabelOpenFieldsDialog.TabStop = True
        Me.LinkLabelOpenFieldsDialog.Text = "Review Fields / Mark Fields as Relevant"
        '
        'ButtonPasteData
        '
        Me.ButtonPasteData.Location = New System.Drawing.Point(9, 39)
        Me.ButtonPasteData.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonPasteData.Name = "ButtonPasteData"
        Me.ButtonPasteData.Size = New System.Drawing.Size(277, 28)
        Me.ButtonPasteData.TabIndex = 18
        Me.ButtonPasteData.Text = "Paste Data   (...from MS Excel or Google Sheets)"
        Me.ButtonPasteData.UseVisualStyleBackColor = True
        '
        'RscFieldSpreadsheet1
        '
        Me.RscFieldSpreadsheet1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RscFieldSpreadsheet1.AutoScroll = True
        Me.RscFieldSpreadsheet1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.RscFieldSpreadsheet1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RscFieldSpreadsheet1.BackColorOfColumns = System.Drawing.Color.AntiqueWhite
        Me.RscFieldSpreadsheet1.ElementInfo_Base = Nothing
        Me.RscFieldSpreadsheet1.Location = New System.Drawing.Point(9, 71)
        Me.RscFieldSpreadsheet1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RscFieldSpreadsheet1.MoveabilityEventsForGroupCtls = Nothing
        Me.RscFieldSpreadsheet1.MoveabilityEventsForSingleMove = Nothing
        Me.RscFieldSpreadsheet1.Name = "RscFieldSpreadsheet1"
        Me.RscFieldSpreadsheet1.Size = New System.Drawing.Size(880, 451)
        Me.RscFieldSpreadsheet1.TabIndex = 19
        '
        'LinkLabelWarningNotSaved
        '
        Me.LinkLabelWarningNotSaved.AutoSize = True
        Me.LinkLabelWarningNotSaved.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabelWarningNotSaved.LinkColor = System.Drawing.Color.Red
        Me.LinkLabelWarningNotSaved.Location = New System.Drawing.Point(302, 47)
        Me.LinkLabelWarningNotSaved.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabelWarningNotSaved.Name = "LinkLabelWarningNotSaved"
        Me.LinkLabelWarningNotSaved.Size = New System.Drawing.Size(628, 13)
        Me.LinkLabelWarningNotSaved.TabIndex = 20
        Me.LinkLabelWarningNotSaved.TabStop = True
        Me.LinkLabelWarningNotSaved.Text = "Please note, the data below has not been saved as recipient data. (The data was s" &
    "aved in non-usable state.)"
        '
        'LinkLabelSaveAsRecipients
        '
        Me.LinkLabelSaveAsRecipients.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelSaveAsRecipients.AutoSize = True
        Me.LinkLabelSaveAsRecipients.Location = New System.Drawing.Point(264, 561)
        Me.LinkLabelSaveAsRecipients.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabelSaveAsRecipients.Name = "LinkLabelSaveAsRecipients"
        Me.LinkLabelSaveAsRecipients.Size = New System.Drawing.Size(120, 13)
        Me.LinkLabelSaveAsRecipients.TabIndex = 21
        Me.LinkLabelSaveAsRecipients.TabStop = True
        Me.LinkLabelSaveAsRecipients.Text = "Save as Recipient Data"
        '
        'LinkLabelRefreshFromRecipients
        '
        Me.LinkLabelRefreshFromRecipients.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelRefreshFromRecipients.AutoSize = True
        Me.LinkLabelRefreshFromRecipients.Location = New System.Drawing.Point(274, 576)
        Me.LinkLabelRefreshFromRecipients.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabelRefreshFromRecipients.Name = "LinkLabelRefreshFromRecipients"
        Me.LinkLabelRefreshFromRecipients.Size = New System.Drawing.Size(132, 13)
        Me.LinkLabelRefreshFromRecipients.TabIndex = 22
        Me.LinkLabelRefreshFromRecipients.TabStop = True
        Me.LinkLabelRefreshFromRecipients.Text = "Refresh as Recipient Data"
        '
        'LinkLabelSaveColumnData
        '
        Me.LinkLabelSaveColumnData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelSaveColumnData.AutoSize = True
        Me.LinkLabelSaveColumnData.Location = New System.Drawing.Point(255, 544)
        Me.LinkLabelSaveColumnData.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabelSaveColumnData.Name = "LinkLabelSaveColumnData"
        Me.LinkLabelSaveColumnData.Size = New System.Drawing.Size(201, 13)
        Me.LinkLabelSaveColumnData.TabIndex = 23
        Me.LinkLabelSaveColumnData.TabStop = True
        Me.LinkLabelSaveColumnData.Text = "Save as Column Data (not as Recipients)"
        '
        'LinkLabelAlignBars
        '
        Me.LinkLabelAlignBars.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelAlignBars.AutoSize = True
        Me.LinkLabelAlignBars.Location = New System.Drawing.Point(11, 561)
        Me.LinkLabelAlignBars.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabelAlignBars.Name = "LinkLabelAlignBars"
        Me.LinkLabelAlignBars.Size = New System.Drawing.Size(131, 13)
        Me.LinkLabelAlignBars.TabIndex = 24
        Me.LinkLabelAlignBars.TabStop = True
        Me.LinkLabelAlignBars.Text = "Align Bars In RowHeaders"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(11, 578)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(116, 13)
        Me.LinkLabel1.TabIndex = 25
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Load Recipient objects"
        '
        'LinkLabelClearSpreadsheet
        '
        Me.LinkLabelClearSpreadsheet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelClearSpreadsheet.AutoSize = True
        Me.LinkLabelClearSpreadsheet.Location = New System.Drawing.Point(476, 544)
        Me.LinkLabelClearSpreadsheet.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabelClearSpreadsheet.Name = "LinkLabelClearSpreadsheet"
        Me.LinkLabelClearSpreadsheet.Size = New System.Drawing.Size(141, 13)
        Me.LinkLabelClearSpreadsheet.TabIndex = 26
        Me.LinkLabelClearSpreadsheet.TabStop = True
        Me.LinkLabelClearSpreadsheet.Text = "Clear spreadsheet of all data"
        '
        'ButtonScrollDown20
        '
        Me.ButtonScrollDown20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonScrollDown20.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonScrollDown20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonScrollDown20.Location = New System.Drawing.Point(893, 369)
        Me.ButtonScrollDown20.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonScrollDown20.Name = "ButtonScrollDown20"
        Me.ButtonScrollDown20.Size = New System.Drawing.Size(37, 87)
        Me.ButtonScrollDown20.TabIndex = 27
        Me.ButtonScrollDown20.Text = " ▼ ▼ ▼ ▼"
        Me.ButtonScrollDown20.UseVisualStyleBackColor = False
        '
        'ButtonScrollUp
        '
        Me.ButtonScrollUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonScrollUp.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonScrollUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonScrollUp.Location = New System.Drawing.Point(892, 71)
        Me.ButtonScrollUp.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonScrollUp.Name = "ButtonScrollUp"
        Me.ButtonScrollUp.Size = New System.Drawing.Size(38, 109)
        Me.ButtonScrollUp.TabIndex = 28
        Me.ButtonScrollUp.Text = "▲ ▲ ▲ ▲ ▲ ▲"
        Me.ButtonScrollUp.UseVisualStyleBackColor = False
        '
        'ButtonScrollDown5
        '
        Me.ButtonScrollDown5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonScrollDown5.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonScrollDown5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonScrollDown5.Location = New System.Drawing.Point(892, 460)
        Me.ButtonScrollDown5.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonScrollDown5.Name = "ButtonScrollDown5"
        Me.ButtonScrollDown5.Size = New System.Drawing.Size(38, 62)
        Me.ButtonScrollDown5.TabIndex = 29
        Me.ButtonScrollDown5.Text = " ▼"
        Me.ButtonScrollDown5.UseVisualStyleBackColor = False
        '
        'LinkRefreshRowHeaderHeights
        '
        Me.LinkRefreshRowHeaderHeights.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkRefreshRowHeaderHeights.AutoSize = True
        Me.LinkRefreshRowHeaderHeights.Location = New System.Drawing.Point(476, 561)
        Me.LinkRefreshRowHeaderHeights.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkRefreshRowHeaderHeights.Name = "LinkRefreshRowHeaderHeights"
        Me.LinkRefreshRowHeaderHeights.Size = New System.Drawing.Size(188, 13)
        Me.LinkRefreshRowHeaderHeights.TabIndex = 30
        Me.LinkRefreshRowHeaderHeights.TabStop = True
        Me.LinkRefreshRowHeaderHeights.Text = "Refresh the height of the row headers."
        '
        'DialogEditRecipients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 600)
        Me.Controls.Add(Me.LinkRefreshRowHeaderHeights)
        Me.Controls.Add(Me.ButtonScrollDown5)
        Me.Controls.Add(Me.ButtonScrollUp)
        Me.Controls.Add(Me.ButtonScrollDown20)
        Me.Controls.Add(Me.LinkLabelClearSpreadsheet)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.LinkLabelAlignBars)
        Me.Controls.Add(Me.LinkLabelSaveColumnData)
        Me.Controls.Add(Me.LinkLabelRefreshFromRecipients)
        Me.Controls.Add(Me.LinkLabelSaveAsRecipients)
        Me.Controls.Add(Me.LinkLabelWarningNotSaved)
        Me.Controls.Add(Me.RscFieldSpreadsheet1)
        Me.Controls.Add(Me.ButtonPasteData)
        Me.Controls.Add(Me.LinkLabelOpenFieldsDialog)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "DialogEditRecipients"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "DialogEditRecipients"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkLabelOpenFieldsDialog As LinkLabel
    Friend WithEvents ButtonPasteData As Button
    Friend WithEvents RscFieldSpreadsheet1 As ciBadgeDesigner.RSCFieldSpreadsheet
    Friend WithEvents LinkLabelWarningNotSaved As LinkLabel
    Friend WithEvents LinkLabelSaveAsRecipients As LinkLabel
    Friend WithEvents LinkLabelRefreshFromRecipients As LinkLabel
    Friend WithEvents LinkLabelSaveColumnData As LinkLabel
    Friend WithEvents LinkLabelAlignBars As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabelClearSpreadsheet As LinkLabel
    Friend WithEvents ButtonScrollDown20 As Button
    Friend WithEvents ButtonScrollUp As Button
    Friend WithEvents ButtonScrollDown5 As Button
    Friend WithEvents LinkRefreshRowHeaderHeights As LinkLabel
End Class
