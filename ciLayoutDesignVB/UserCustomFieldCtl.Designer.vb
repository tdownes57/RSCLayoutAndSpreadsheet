<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserCustomFieldCtl
    Inherits System.Windows.Forms.UserControl

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
        Me.textFieldLabel = New System.Windows.Forms.TextBox()
        Me.checkIsFieldForDates = New System.Windows.Forms.CheckBox()
        Me.LabelFieldLabelCaption = New System.Windows.Forms.Label()
        Me.checkHasPresetValues = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.buttonAddField = New System.Windows.Forms.Button()
        Me.listPresetValues = New System.Windows.Forms.ListBox()
        Me.linkDeleteField = New System.Windows.Forms.LinkLabel()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.linkAddPresetValue = New System.Windows.Forms.LinkLabel()
        Me.LinkSupplementary = New System.Windows.Forms.LinkLabel()
        Me.LabelHeaderTop = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'textFieldLabel
        '
        Me.textFieldLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFieldLabel.Location = New System.Drawing.Point(207, 63)
        Me.textFieldLabel.Name = "textFieldLabel"
        Me.textFieldLabel.Size = New System.Drawing.Size(215, 30)
        Me.textFieldLabel.TabIndex = 0
        '
        'checkIsFieldForDates
        '
        Me.checkIsFieldForDates.AutoSize = True
        Me.checkIsFieldForDates.Location = New System.Drawing.Point(212, 12)
        Me.checkIsFieldForDates.Name = "checkIsFieldForDates"
        Me.checkIsFieldForDates.Size = New System.Drawing.Size(154, 21)
        Me.checkIsFieldForDates.TabIndex = 1
        Me.checkIsFieldForDates.Text = "Is this a Date Field?"
        Me.checkIsFieldForDates.UseVisualStyleBackColor = True
        '
        'LabelFieldLabelCaption
        '
        Me.LabelFieldLabelCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFieldLabelCaption.Location = New System.Drawing.Point(3, 68)
        Me.LabelFieldLabelCaption.Name = "LabelFieldLabelCaption"
        Me.LabelFieldLabelCaption.Size = New System.Drawing.Size(180, 25)
        Me.LabelFieldLabelCaption.TabIndex = 2
        Me.LabelFieldLabelCaption.Text = "Field Label Caption"
        '
        'checkHasPresetValues
        '
        Me.checkHasPresetValues.AutoSize = True
        Me.checkHasPresetValues.Location = New System.Drawing.Point(458, 3)
        Me.checkHasPresetValues.Name = "checkHasPresetValues"
        Me.checkHasPresetValues.Size = New System.Drawing.Size(186, 21)
        Me.checkHasPresetValues.TabIndex = 6
        Me.checkHasPresetValues.Text = "Are there preset values?"
        Me.checkHasPresetValues.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(212, 33)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(200, 21)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Is this locked to stop edits?"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'buttonAddField
        '
        Me.buttonAddField.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonAddField.Location = New System.Drawing.Point(713, 43)
        Me.buttonAddField.Name = "buttonAddField"
        Me.buttonAddField.Size = New System.Drawing.Size(108, 51)
        Me.buttonAddField.TabIndex = 8
        Me.buttonAddField.Text = "Add Field"
        Me.buttonAddField.UseVisualStyleBackColor = True
        '
        'listPresetValues
        '
        Me.listPresetValues.FormattingEnabled = True
        Me.listPresetValues.ItemHeight = 16
        Me.listPresetValues.Location = New System.Drawing.Point(481, 30)
        Me.listPresetValues.Name = "listPresetValues"
        Me.listPresetValues.Size = New System.Drawing.Size(195, 68)
        Me.listPresetValues.TabIndex = 9
        '
        'linkDeleteField
        '
        Me.linkDeleteField.AutoSize = True
        Me.linkDeleteField.Location = New System.Drawing.Point(728, 97)
        Me.linkDeleteField.Name = "linkDeleteField"
        Me.linkDeleteField.Size = New System.Drawing.Size(83, 17)
        Me.linkDeleteField.TabIndex = 10
        Me.linkDeleteField.TabStop = True
        Me.linkDeleteField.Text = "Delete Field"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(458, 104)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(194, 21)
        Me.CheckBox2.TabIndex = 12
        Me.CheckBox2.Text = "Is this an Additional Field?"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'linkAddPresetValue
        '
        Me.linkAddPresetValue.AutoSize = True
        Me.linkAddPresetValue.Location = New System.Drawing.Point(650, 4)
        Me.linkAddPresetValue.Name = "linkAddPresetValue"
        Me.linkAddPresetValue.Size = New System.Drawing.Size(115, 17)
        Me.linkAddPresetValue.TabIndex = 11
        Me.linkAddPresetValue.TabStop = True
        Me.linkAddPresetValue.Text = "Add preset value"
        '
        'LinkSupplementary
        '
        Me.LinkSupplementary.AutoSize = True
        Me.LinkSupplementary.Location = New System.Drawing.Point(128, 104)
        Me.LinkSupplementary.Name = "LinkSupplementary"
        Me.LinkSupplementary.Size = New System.Drawing.Size(296, 17)
        Me.LinkSupplementary.TabIndex = 13
        Me.LinkSupplementary.TabStop = True
        Me.LinkSupplementary.Text = "Example Value, CIBadge Field, Other Db Field"
        '
        'LabelHeaderTop
        '
        Me.LabelHeaderTop.AutoSize = True
        Me.LabelHeaderTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderTop.Location = New System.Drawing.Point(6, 12)
        Me.LabelHeaderTop.Name = "LabelHeaderTop"
        Me.LabelHeaderTop.Size = New System.Drawing.Size(177, 31)
        Me.LabelHeaderTop.TabIndex = 4
        Me.LabelHeaderTop.Text = "Text Field # 1"
        Me.LabelHeaderTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UserCustomFieldCtl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.LinkSupplementary)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.linkAddPresetValue)
        Me.Controls.Add(Me.linkDeleteField)
        Me.Controls.Add(Me.listPresetValues)
        Me.Controls.Add(Me.buttonAddField)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.checkHasPresetValues)
        Me.Controls.Add(Me.LabelHeaderTop)
        Me.Controls.Add(Me.LabelFieldLabelCaption)
        Me.Controls.Add(Me.checkIsFieldForDates)
        Me.Controls.Add(Me.textFieldLabel)
        Me.Name = "UserCustomFieldCtl"
        Me.Size = New System.Drawing.Size(837, 130)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textFieldLabel As TextBox
    Friend WithEvents checkIsFieldForDates As CheckBox
    Friend WithEvents LabelFieldLabelCaption As Label
    Friend WithEvents checkHasPresetValues As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents buttonAddField As Button
    Friend WithEvents listPresetValues As ListBox
    Friend WithEvents linkDeleteField As LinkLabel
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents linkAddPresetValue As LinkLabel
    Friend WithEvents LinkSupplementary As LinkLabel
    Friend WithEvents LabelHeaderTop As Label
End Class
