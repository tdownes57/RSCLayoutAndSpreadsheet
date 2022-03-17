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
        Me.UserAddFieldControl1 = New ciBadgeDesigner.CtlAddCustomField()
        Me.LabelHeaderCaption = New System.Windows.Forms.Label()
        Me.LinkLabelCancel = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelSave = New System.Windows.Forms.LinkLabel()
        Me.linklabelExport = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelAddField = New System.Windows.Forms.LinkLabel()
        Me.linkLabelRefresh = New System.Windows.Forms.LinkLabel()
        Me.chkIncludeCIBField = New System.Windows.Forms.CheckBox()
        Me.chkIncludeExampleValues = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1.SuspendLayout()
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
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(11, 68)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(737, 425)
        Me.FlowLayoutPanel1.TabIndex = 12
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'UserAddFieldControl1
        '
        Me.UserAddFieldControl1.BackColor = System.Drawing.Color.LightCyan
        Me.UserAddFieldControl1.Location = New System.Drawing.Point(2, 2)
        Me.UserAddFieldControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.UserAddFieldControl1.Name = "UserAddFieldControl1"
        Me.UserAddFieldControl1.Size = New System.Drawing.Size(691, 70)
        Me.UserAddFieldControl1.TabIndex = 4
        '
        'LabelHeaderCaption
        '
        Me.LabelHeaderCaption.AutoSize = True
        Me.LabelHeaderCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderCaption.Location = New System.Drawing.Point(9, 16)
        Me.LabelHeaderCaption.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeaderCaption.Name = "LabelHeaderCaption"
        Me.LabelHeaderCaption.Size = New System.Drawing.Size(354, 29)
        Me.LabelHeaderCaption.TabIndex = 11
        Me.LabelHeaderCaption.Tag = "Custom Fields - {0}"
        Me.LabelHeaderCaption.Text = "Both Custom && Standard Fields "
        '
        'LinkLabelCancel
        '
        Me.LinkLabelCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelCancel.AutoSize = True
        Me.LinkLabelCancel.Location = New System.Drawing.Point(443, 508)
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
        Me.LinkLabelSave.Location = New System.Drawing.Point(674, 508)
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
        Me.LinkLabelAddField.Location = New System.Drawing.Point(275, 508)
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
        Me.chkIncludeCIBField.Location = New System.Drawing.Point(577, 38)
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
        Me.chkIncludeExampleValues.Location = New System.Drawing.Point(577, 16)
        Me.chkIncludeExampleValues.Margin = New System.Windows.Forms.Padding(2)
        Me.chkIncludeExampleValues.Name = "chkIncludeExampleValues"
        Me.chkIncludeExampleValues.Size = New System.Drawing.Size(140, 17)
        Me.chkIncludeExampleValues.TabIndex = 13
        Me.chkIncludeExampleValues.Text = "Include example values."
        Me.chkIncludeExampleValues.UseVisualStyleBackColor = True
        '
        'DialogListBothTypeFields
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 547)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.LabelHeaderCaption)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents UserAddFieldControl1 As CtlAddCustomField
    Friend WithEvents LabelHeaderCaption As Label
    Friend WithEvents LinkLabelCancel As LinkLabel
    Friend WithEvents LinkLabelSave As LinkLabel
    Friend WithEvents linklabelExport As LinkLabel
    Friend WithEvents LinkLabelAddField As LinkLabel
    Friend WithEvents linkLabelRefresh As LinkLabel
    Friend WithEvents chkIncludeCIBField As CheckBox
    Friend WithEvents chkIncludeExampleValues As CheckBox
End Class
