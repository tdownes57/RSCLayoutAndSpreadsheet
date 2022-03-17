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
        Me.SuspendLayout()
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(801, 541)
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
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(644, 541)
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
        Me.RscFieldSpreadsheet1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RscFieldSpreadsheet1.BackColorOfColumns = System.Drawing.Color.AntiqueWhite
        Me.RscFieldSpreadsheet1.Location = New System.Drawing.Point(9, 71)
        Me.RscFieldSpreadsheet1.Margin = New System.Windows.Forms.Padding(2)
        Me.RscFieldSpreadsheet1.Name = "RscFieldSpreadsheet1"
        Me.RscFieldSpreadsheet1.Size = New System.Drawing.Size(875, 451)
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
        Me.LinkLabelSaveColumnData.AutoSize = True
        Me.LinkLabelSaveColumnData.Location = New System.Drawing.Point(255, 544)
        Me.LinkLabelSaveColumnData.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabelSaveColumnData.Name = "LinkLabelSaveColumnData"
        Me.LinkLabelSaveColumnData.Size = New System.Drawing.Size(201, 13)
        Me.LinkLabelSaveColumnData.TabIndex = 23
        Me.LinkLabelSaveColumnData.TabStop = True
        Me.LinkLabelSaveColumnData.Text = "Save as Column Data (not as Recipients)"
        '
        'DialogEditRecipients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 600)
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
End Class
