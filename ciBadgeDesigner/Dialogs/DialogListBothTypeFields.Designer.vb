<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogListBothTypeFields
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelHeaderCaption1 = New System.Windows.Forms.Label()
        Me.LinkLabelCancel = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelSave = New System.Windows.Forms.LinkLabel()
        Me.linklabelExport = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelAddField = New System.Windows.Forms.LinkLabel()
        Me.linkLabelRefresh = New System.Windows.Forms.LinkLabel()
        Me.chkIncludeCIBField = New System.Windows.Forms.CheckBox()
        Me.chkIncludeExampleValues = New System.Windows.Forms.CheckBox()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.LinkLabelShowAllFieldsRNR = New System.Windows.Forms.LinkLabel()
        Me.LinkShowRelevantOnly = New System.Windows.Forms.LinkLabel()
        Me.LinkShowOnlyNotRelevant = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelShowAllFieldsCS = New System.Windows.Forms.LinkLabel()
        Me.LinkShowOnlyStandardFields = New System.Windows.Forms.LinkLabel()
        Me.CheckBoxGotIt = New System.Windows.Forms.CheckBox()
        Me.LabelHeaderCaption2 = New System.Windows.Forms.Label()
        Me.UserAddFieldControl1 = New ciBadgeDesigner.CtlAddCustomField()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FlowLayoutPanel1.Controls.Add(Me.UserAddFieldControl1)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(11, 106)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1052, 387)
        Me.FlowLayoutPanel1.TabIndex = 12
        '
        'LabelHeaderCaption1
        '
        Me.LabelHeaderCaption1.AutoSize = True
        Me.LabelHeaderCaption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderCaption1.Location = New System.Drawing.Point(8, 5)
        Me.LabelHeaderCaption1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeaderCaption1.Name = "LabelHeaderCaption1"
        Me.LabelHeaderCaption1.Size = New System.Drawing.Size(354, 29)
        Me.LabelHeaderCaption1.TabIndex = 11
        Me.LabelHeaderCaption1.Tag = "Custom Fields - {0}"
        Me.LabelHeaderCaption1.Text = "Both Custom && Standard Fields "
        '
        'LinkLabelCancel
        '
        Me.LinkLabelCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelCancel.AutoSize = True
        Me.LinkLabelCancel.Location = New System.Drawing.Point(328, 525)
        Me.LinkLabelCancel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabelCancel.Name = "LinkLabelCancel"
        Me.LinkLabelCancel.Size = New System.Drawing.Size(148, 13)
        Me.LinkLabelCancel.TabIndex = 19
        Me.LinkLabelCancel.TabStop = True
        Me.LinkLabelCancel.Text = "Cancel / Undo Edits / Reload"
        '
        'LinkLabelSave
        '
        Me.LinkLabelSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelSave.AutoSize = True
        Me.LinkLabelSave.Location = New System.Drawing.Point(592, 512)
        Me.LinkLabelSave.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabelSave.Name = "LinkLabelSave"
        Me.LinkLabelSave.Size = New System.Drawing.Size(32, 13)
        Me.LinkLabelSave.TabIndex = 18
        Me.LinkLabelSave.TabStop = True
        Me.LinkLabelSave.Text = "Save"
        '
        'linklabelExport
        '
        Me.linklabelExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.linklabelExport.AutoSize = True
        Me.linklabelExport.Location = New System.Drawing.Point(13, 508)
        Me.linklabelExport.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.linklabelExport.Name = "linklabelExport"
        Me.linklabelExport.Size = New System.Drawing.Size(37, 13)
        Me.linklabelExport.TabIndex = 17
        Me.linklabelExport.TabStop = True
        Me.linklabelExport.Text = "Export"
        '
        'LinkLabelAddField
        '
        Me.LinkLabelAddField.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelAddField.AutoSize = True
        Me.LinkLabelAddField.Location = New System.Drawing.Point(195, 525)
        Me.LinkLabelAddField.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabelAddField.Name = "LinkLabelAddField"
        Me.LinkLabelAddField.Size = New System.Drawing.Size(114, 13)
        Me.LinkLabelAddField.TabIndex = 16
        Me.LinkLabelAddField.TabStop = True
        Me.LinkLabelAddField.Text = "Add New Custom Field"
        '
        'linkLabelRefresh
        '
        Me.linkLabelRefresh.AutoSize = True
        Me.linkLabelRefresh.Location = New System.Drawing.Point(109, 510)
        Me.linkLabelRefresh.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.linkLabelRefresh.Name = "linkLabelRefresh"
        Me.linkLabelRefresh.Size = New System.Drawing.Size(141, 13)
        Me.linkLabelRefresh.TabIndex = 15
        Me.linkLabelRefresh.TabStop = True
        Me.linkLabelRefresh.Text = "Save && Refresh the Window"
        '
        'chkIncludeCIBField
        '
        Me.chkIncludeCIBField.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIncludeCIBField.AutoSize = True
        Me.chkIncludeCIBField.Location = New System.Drawing.Point(892, 38)
        Me.chkIncludeCIBField.Margin = New System.Windows.Forms.Padding(2)
        Me.chkIncludeCIBField.Name = "chkIncludeCIBField"
        Me.chkIncludeCIBField.Size = New System.Drawing.Size(170, 17)
        Me.chkIncludeCIBField.TabIndex = 14
        Me.chkIncludeCIBField.Text = "Include Table Card Data Field."
        Me.chkIncludeCIBField.UseVisualStyleBackColor = True
        '
        'chkIncludeExampleValues
        '
        Me.chkIncludeExampleValues.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIncludeExampleValues.AutoSize = True
        Me.chkIncludeExampleValues.Checked = True
        Me.chkIncludeExampleValues.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncludeExampleValues.Location = New System.Drawing.Point(892, 16)
        Me.chkIncludeExampleValues.Margin = New System.Windows.Forms.Padding(2)
        Me.chkIncludeExampleValues.Name = "chkIncludeExampleValues"
        Me.chkIncludeExampleValues.Size = New System.Drawing.Size(140, 17)
        Me.chkIncludeExampleValues.TabIndex = 13
        Me.chkIncludeExampleValues.Text = "Include example values."
        Me.chkIncludeExampleValues.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(989, 497)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(74, 44)
        Me.ButtonCancel.TabIndex = 21
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(819, 497)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(167, 44)
        Me.ButtonOK.TabIndex = 20
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'LinkLabelShowAllFieldsRNR
        '
        Me.LinkLabelShowAllFieldsRNR.AutoSize = True
        Me.LinkLabelShowAllFieldsRNR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabelShowAllFieldsRNR.Location = New System.Drawing.Point(13, 79)
        Me.LinkLabelShowAllFieldsRNR.Name = "LinkLabelShowAllFieldsRNR"
        Me.LinkLabelShowAllFieldsRNR.Size = New System.Drawing.Size(264, 17)
        Me.LinkLabelShowAllFieldsRNR.TabIndex = 23
        Me.LinkLabelShowAllFieldsRNR.TabStop = True
        Me.LinkLabelShowAllFieldsRNR.Text = "Show all fields, Relevant && Not Relevant."
        '
        'LinkShowRelevantOnly
        '
        Me.LinkShowRelevantOnly.AutoSize = True
        Me.LinkShowRelevantOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkShowRelevantOnly.Location = New System.Drawing.Point(307, 79)
        Me.LinkShowRelevantOnly.Name = "LinkShowRelevantOnly"
        Me.LinkShowRelevantOnly.Size = New System.Drawing.Size(173, 17)
        Me.LinkShowRelevantOnly.TabIndex = 24
        Me.LinkShowRelevantOnly.TabStop = True
        Me.LinkShowRelevantOnly.Text = "Show only Relevant fields."
        '
        'LinkShowOnlyNotRelevant
        '
        Me.LinkShowOnlyNotRelevant.AutoSize = True
        Me.LinkShowOnlyNotRelevant.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkShowOnlyNotRelevant.Location = New System.Drawing.Point(504, 79)
        Me.LinkShowOnlyNotRelevant.Name = "LinkShowOnlyNotRelevant"
        Me.LinkShowOnlyNotRelevant.Size = New System.Drawing.Size(203, 17)
        Me.LinkShowOnlyNotRelevant.TabIndex = 25
        Me.LinkShowOnlyNotRelevant.TabStop = True
        Me.LinkShowOnlyNotRelevant.Text = "Show only Not Relevant Fields."
        '
        'LinkLabelShowAllFieldsCS
        '
        Me.LinkLabelShowAllFieldsCS.AutoSize = True
        Me.LinkLabelShowAllFieldsCS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabelShowAllFieldsCS.Location = New System.Drawing.Point(381, 15)
        Me.LinkLabelShowAllFieldsCS.Name = "LinkLabelShowAllFieldsCS"
        Me.LinkLabelShowAllFieldsCS.Size = New System.Drawing.Size(227, 17)
        Me.LinkLabelShowAllFieldsCS.TabIndex = 26
        Me.LinkLabelShowAllFieldsCS.TabStop = True
        Me.LinkLabelShowAllFieldsCS.Text = "Show all fields, Custom && Standard"
        '
        'LinkShowOnlyStandardFields
        '
        Me.LinkShowOnlyStandardFields.AutoSize = True
        Me.LinkShowOnlyStandardFields.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkShowOnlyStandardFields.Location = New System.Drawing.Point(625, 15)
        Me.LinkShowOnlyStandardFields.Name = "LinkShowOnlyStandardFields"
        Me.LinkShowOnlyStandardFields.Size = New System.Drawing.Size(175, 17)
        Me.LinkShowOnlyStandardFields.TabIndex = 27
        Me.LinkShowOnlyStandardFields.TabStop = True
        Me.LinkShowOnlyStandardFields.Text = "Show only Standard Fields"
        '
        'CheckBoxGotIt
        '
        Me.CheckBoxGotIt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxGotIt.AutoCheck = False
        Me.CheckBoxGotIt.AutoSize = True
        Me.CheckBoxGotIt.BackColor = System.Drawing.Color.Gold
        Me.CheckBoxGotIt.Location = New System.Drawing.Point(662, 7)
        Me.CheckBoxGotIt.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBoxGotIt.Name = "CheckBoxGotIt"
        Me.CheckBoxGotIt.Size = New System.Drawing.Size(143, 17)
        Me.CheckBoxGotIt.TabIndex = 28
        Me.CheckBoxGotIt.Text = "I understand? Rephrase."
        Me.CheckBoxGotIt.UseVisualStyleBackColor = False
        '
        'LabelHeaderCaption2
        '
        Me.LabelHeaderCaption2.BackColor = System.Drawing.Color.Gold
        Me.LabelHeaderCaption2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderCaption2.Location = New System.Drawing.Point(2, 0)
        Me.LabelHeaderCaption2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeaderCaption2.Name = "LabelHeaderCaption2"
        Me.LabelHeaderCaption2.Size = New System.Drawing.Size(803, 24)
        Me.LabelHeaderCaption2.TabIndex = 22
        Me.LabelHeaderCaption2.Tag = "Custom Fields - {0}"
        Me.LabelHeaderCaption2.Text = "You determine which fields are Relevant (i.e. available).  Review carefully."
        '
        'UserAddFieldControl1
        '
        Me.UserAddFieldControl1.BackColor = System.Drawing.Color.LightCyan
        Me.UserAddFieldControl1.Location = New System.Drawing.Point(2, 2)
        Me.UserAddFieldControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.UserAddFieldControl1.Name = "UserAddFieldControl1"
        Me.UserAddFieldControl1.Size = New System.Drawing.Size(691, 72)
        Me.UserAddFieldControl1.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CheckBoxGotIt)
        Me.Panel1.Controls.Add(Me.LabelHeaderCaption2)
        Me.Panel1.Location = New System.Drawing.Point(13, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(807, 31)
        Me.Panel1.TabIndex = 5
        '
        'DialogListBothTypeFields
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 547)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LinkShowOnlyStandardFields)
        Me.Controls.Add(Me.LinkLabelShowAllFieldsCS)
        Me.Controls.Add(Me.LinkShowOnlyNotRelevant)
        Me.Controls.Add(Me.LinkShowRelevantOnly)
        Me.Controls.Add(Me.LinkLabelShowAllFieldsRNR)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.LabelHeaderCaption1)
        Me.Controls.Add(Me.LinkLabelCancel)
        Me.Controls.Add(Me.LinkLabelSave)
        Me.Controls.Add(Me.linklabelExport)
        Me.Controls.Add(Me.LinkLabelAddField)
        Me.Controls.Add(Me.linkLabelRefresh)
        Me.Controls.Add(Me.chkIncludeCIBField)
        Me.Controls.Add(Me.chkIncludeExampleValues)
        Me.Name = "DialogListBothTypeFields"
        Me.Text = "DialogListBothTypeFields"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents UserAddFieldControl1 As CtlAddCustomField
    Friend WithEvents LabelHeaderCaption1 As Label
    Friend WithEvents LinkLabelCancel As LinkLabel
    Friend WithEvents LinkLabelSave As LinkLabel
    Friend WithEvents linklabelExport As LinkLabel
    Friend WithEvents LinkLabelAddField As LinkLabel
    Friend WithEvents linkLabelRefresh As LinkLabel
    Friend WithEvents chkIncludeCIBField As CheckBox
    Friend WithEvents chkIncludeExampleValues As CheckBox
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents LinkLabelShowAllFieldsRNR As LinkLabel
    Friend WithEvents LinkShowRelevantOnly As LinkLabel
    Friend WithEvents LinkShowOnlyNotRelevant As LinkLabel
    Friend WithEvents LinkLabelShowAllFieldsCS As LinkLabel
    Friend WithEvents LinkShowOnlyStandardFields As LinkLabel
    Friend WithEvents CheckBoxGotIt As CheckBox
    Friend WithEvents LabelHeaderCaption2 As Label
    Friend WithEvents Panel1 As Panel
End Class
