<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListStandardFields
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
        Me.LinkLabelCancel = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelSave = New System.Windows.Forms.LinkLabel()
        Me.linklabelExport = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelAddField = New System.Windows.Forms.LinkLabel()
        Me.linkLabelRefresh = New System.Windows.Forms.LinkLabel()
        Me.chkIncludeCIBField = New System.Windows.Forms.CheckBox()
        Me.chkIncludeExampleValues = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelHeaderCaption = New System.Windows.Forms.Label()
        Me.CtlAddStandardField1 = New ciLayoutDesignVB.CtlAddStandardField()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LinkLabelCancel
        '
        Me.LinkLabelCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelCancel.AutoSize = True
        Me.LinkLabelCancel.Location = New System.Drawing.Point(694, 625)
        Me.LinkLabelCancel.Name = "LinkLabelCancel"
        Me.LinkLabelCancel.Size = New System.Drawing.Size(51, 17)
        Me.LinkLabelCancel.TabIndex = 19
        Me.LinkLabelCancel.TabStop = True
        Me.LinkLabelCancel.Text = "Cancel"
        '
        'LinkLabelSave
        '
        Me.LinkLabelSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelSave.AutoSize = True
        Me.LinkLabelSave.Location = New System.Drawing.Point(794, 625)
        Me.LinkLabelSave.Name = "LinkLabelSave"
        Me.LinkLabelSave.Size = New System.Drawing.Size(40, 17)
        Me.LinkLabelSave.TabIndex = 18
        Me.LinkLabelSave.TabStop = True
        Me.LinkLabelSave.Text = "Save"
        '
        'linklabelExport
        '
        Me.linklabelExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.linklabelExport.AutoSize = True
        Me.linklabelExport.Location = New System.Drawing.Point(25, 625)
        Me.linklabelExport.Name = "linklabelExport"
        Me.linklabelExport.Size = New System.Drawing.Size(48, 17)
        Me.linklabelExport.TabIndex = 17
        Me.linklabelExport.TabStop = True
        Me.linklabelExport.Text = "Export"
        '
        'LinkLabelAddField
        '
        Me.LinkLabelAddField.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelAddField.AutoSize = True
        Me.LinkLabelAddField.Location = New System.Drawing.Point(374, 625)
        Me.LinkLabelAddField.Name = "LinkLabelAddField"
        Me.LinkLabelAddField.Size = New System.Drawing.Size(160, 17)
        Me.LinkLabelAddField.TabIndex = 16
        Me.LinkLabelAddField.TabStop = True
        Me.LinkLabelAddField.Text = "Add New Standard Field"
        '
        'linkLabelRefresh
        '
        Me.linkLabelRefresh.AutoSize = True
        Me.linkLabelRefresh.Location = New System.Drawing.Point(153, 625)
        Me.linkLabelRefresh.Name = "linkLabelRefresh"
        Me.linkLabelRefresh.Size = New System.Drawing.Size(184, 17)
        Me.linkLabelRefresh.TabIndex = 15
        Me.linkLabelRefresh.TabStop = True
        Me.linkLabelRefresh.Text = "Save && Refresh the Window"
        '
        'chkIncludeCIBField
        '
        Me.chkIncludeCIBField.AutoSize = True
        Me.chkIncludeCIBField.Location = New System.Drawing.Point(632, 42)
        Me.chkIncludeCIBField.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkIncludeCIBField.Name = "chkIncludeCIBField"
        Me.chkIncludeCIBField.Size = New System.Drawing.Size(221, 21)
        Me.chkIncludeCIBField.TabIndex = 14
        Me.chkIncludeCIBField.Text = "Include Table Card Data Field."
        Me.chkIncludeCIBField.UseVisualStyleBackColor = True
        '
        'chkIncludeExampleValues
        '
        Me.chkIncludeExampleValues.AutoSize = True
        Me.chkIncludeExampleValues.Checked = True
        Me.chkIncludeExampleValues.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncludeExampleValues.Location = New System.Drawing.Point(632, 17)
        Me.chkIncludeExampleValues.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkIncludeExampleValues.Name = "chkIncludeExampleValues"
        Me.chkIncludeExampleValues.Size = New System.Drawing.Size(180, 21)
        Me.chkIncludeExampleValues.TabIndex = 13
        Me.chkIncludeExampleValues.Text = "Include example values."
        Me.chkIncludeExampleValues.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FlowLayoutPanel1.Controls.Add(Me.CtlAddStandardField1)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(22, 81)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(815, 526)
        Me.FlowLayoutPanel1.TabIndex = 12
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'LabelHeaderCaption
        '
        Me.LabelHeaderCaption.AutoSize = True
        Me.LabelHeaderCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderCaption.Location = New System.Drawing.Point(19, 17)
        Me.LabelHeaderCaption.Name = "LabelHeaderCaption"
        Me.LabelHeaderCaption.Size = New System.Drawing.Size(418, 36)
        Me.LabelHeaderCaption.TabIndex = 11
        Me.LabelHeaderCaption.Tag = "Custom Fields - {0}"
        Me.LabelHeaderCaption.Text = "Standard Fields - {Personality}"
        '
        'CtlAddStandardField1
        '
        Me.CtlAddStandardField1.BackColor = System.Drawing.Color.SkyBlue
        Me.CtlAddStandardField1.Location = New System.Drawing.Point(3, 3)
        Me.CtlAddStandardField1.Name = "CtlAddStandardField1"
        Me.CtlAddStandardField1.Size = New System.Drawing.Size(799, 98)
        Me.CtlAddStandardField1.TabIndex = 0
        '
        'FormStandardFields
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 658)
        Me.Controls.Add(Me.LinkLabelCancel)
        Me.Controls.Add(Me.LinkLabelSave)
        Me.Controls.Add(Me.linklabelExport)
        Me.Controls.Add(Me.LinkLabelAddField)
        Me.Controls.Add(Me.linkLabelRefresh)
        Me.Controls.Add(Me.chkIncludeCIBField)
        Me.Controls.Add(Me.chkIncludeExampleValues)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.LabelHeaderCaption)
        Me.Name = "FormStandardFields"
        Me.Text = "FormStandardFields"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkLabelCancel As LinkLabel
    Friend WithEvents LinkLabelSave As LinkLabel
    Friend WithEvents linklabelExport As LinkLabel
    Friend WithEvents LinkLabelAddField As LinkLabel
    Friend WithEvents linkLabelRefresh As LinkLabel
    Friend WithEvents chkIncludeCIBField As CheckBox
    Friend WithEvents chkIncludeExampleValues As CheckBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents LabelHeaderCaption As Label
    Friend WithEvents CtlAddStandardField1 As CtlAddStandardField
End Class
