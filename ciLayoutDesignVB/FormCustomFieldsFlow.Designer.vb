<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCustomFieldsFlow
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
        Me.LabelHeaderCaption = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.UserAddFieldControl1 = New ciLayoutDesignVB.CtlAddCustomField()
        Me.chkIncludeExampleValues = New System.Windows.Forms.CheckBox()
        Me.chkIncludeCIBField = New System.Windows.Forms.CheckBox()
        Me.linkLabelRefresh = New System.Windows.Forms.LinkLabel()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelHeaderCaption
        '
        Me.LabelHeaderCaption.AutoSize = True
        Me.LabelHeaderCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderCaption.Location = New System.Drawing.Point(9, 12)
        Me.LabelHeaderCaption.Name = "LabelHeaderCaption"
        Me.LabelHeaderCaption.Size = New System.Drawing.Size(398, 36)
        Me.LabelHeaderCaption.TabIndex = 2
        Me.LabelHeaderCaption.Tag = "Custom Fields - {0}"
        Me.LabelHeaderCaption.Text = "Custom Fields - {Personality}"
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
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 76)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(872, 539)
        Me.FlowLayoutPanel1.TabIndex = 3
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'UserAddFieldControl1
        '
        Me.UserAddFieldControl1.BackColor = System.Drawing.Color.LightCyan
        Me.UserAddFieldControl1.Location = New System.Drawing.Point(3, 3)
        Me.UserAddFieldControl1.Name = "UserAddFieldControl1"
        Me.UserAddFieldControl1.Size = New System.Drawing.Size(837, 123)
        Me.UserAddFieldControl1.TabIndex = 4
        '
        'chkIncludeExampleValues
        '
        Me.chkIncludeExampleValues.AutoSize = True
        Me.chkIncludeExampleValues.Checked = True
        Me.chkIncludeExampleValues.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncludeExampleValues.Location = New System.Drawing.Point(679, 12)
        Me.chkIncludeExampleValues.Name = "chkIncludeExampleValues"
        Me.chkIncludeExampleValues.Size = New System.Drawing.Size(180, 21)
        Me.chkIncludeExampleValues.TabIndex = 4
        Me.chkIncludeExampleValues.Text = "Include example values."
        Me.chkIncludeExampleValues.UseVisualStyleBackColor = True
        '
        'chkIncludeCIBField
        '
        Me.chkIncludeCIBField.AutoSize = True
        Me.chkIncludeCIBField.Location = New System.Drawing.Point(679, 39)
        Me.chkIncludeCIBField.Name = "chkIncludeCIBField"
        Me.chkIncludeCIBField.Size = New System.Drawing.Size(221, 21)
        Me.chkIncludeCIBField.TabIndex = 5
        Me.chkIncludeCIBField.Text = "Include Table Card Data Field."
        Me.chkIncludeCIBField.UseVisualStyleBackColor = True
        '
        'linkLabelRefresh
        '
        Me.linkLabelRefresh.AutoSize = True
        Me.linkLabelRefresh.Location = New System.Drawing.Point(343, 56)
        Me.linkLabelRefresh.Name = "linkLabelRefresh"
        Me.linkLabelRefresh.Size = New System.Drawing.Size(184, 17)
        Me.linkLabelRefresh.TabIndex = 6
        Me.linkLabelRefresh.TabStop = True
        Me.linkLabelRefresh.Text = "Save && Refresh the Window"
        '
        'FormCustomFieldsFlow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 646)
        Me.Controls.Add(Me.linkLabelRefresh)
        Me.Controls.Add(Me.chkIncludeCIBField)
        Me.Controls.Add(Me.chkIncludeExampleValues)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.LabelHeaderCaption)
        Me.Name = "FormCustomFieldsFlow"
        Me.Text = "FormCustomFieldsFlow"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelHeaderCaption As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents UserAddFieldControl1 As CtlAddCustomField
    Friend WithEvents chkIncludeExampleValues As CheckBox
    Friend WithEvents chkIncludeCIBField As CheckBox
    Friend WithEvents linkLabelRefresh As LinkLabel
End Class
