<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlConfigFldCustom
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
        Me.checkIsLocked = New System.Windows.Forms.CheckBox()
        Me.buttonAddField = New System.Windows.Forms.Button()
        Me.listPresetValues = New System.Windows.Forms.ListBox()
        Me.linkDeleteField = New System.Windows.Forms.LinkLabel()
        Me.checkIsAdditionalField = New System.Windows.Forms.CheckBox()
        Me.linkAddPresetValue = New System.Windows.Forms.LinkLabel()
        Me.LinkSupplementary = New System.Windows.Forms.LinkLabel()
        Me.LabelHeaderTop = New System.Windows.Forms.Label()
        Me.checkDisplayOnBadge = New System.Windows.Forms.CheckBox()
        Me.checkDisplayForEdits = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'textFieldLabel
        '
        Me.textFieldLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFieldLabel.Location = New System.Drawing.Point(155, 51)
        Me.textFieldLabel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.textFieldLabel.Name = "textFieldLabel"
        Me.textFieldLabel.Size = New System.Drawing.Size(162, 26)
        Me.textFieldLabel.TabIndex = 0
        '
        'checkIsFieldForDates
        '
        Me.checkIsFieldForDates.AutoSize = True
        Me.checkIsFieldForDates.Location = New System.Drawing.Point(159, 10)
        Me.checkIsFieldForDates.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.checkIsFieldForDates.Name = "checkIsFieldForDates"
        Me.checkIsFieldForDates.Size = New System.Drawing.Size(119, 17)
        Me.checkIsFieldForDates.TabIndex = 1
        Me.checkIsFieldForDates.Text = "Is this a Date Field?"
        Me.checkIsFieldForDates.UseVisualStyleBackColor = True
        '
        'LabelFieldLabelCaption
        '
        Me.LabelFieldLabelCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFieldLabelCaption.Location = New System.Drawing.Point(2, 55)
        Me.LabelFieldLabelCaption.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelFieldLabelCaption.Name = "LabelFieldLabelCaption"
        Me.LabelFieldLabelCaption.Size = New System.Drawing.Size(135, 20)
        Me.LabelFieldLabelCaption.TabIndex = 2
        Me.LabelFieldLabelCaption.Text = "Field Label Caption"
        '
        'checkHasPresetValues
        '
        Me.checkHasPresetValues.AutoSize = True
        Me.checkHasPresetValues.Location = New System.Drawing.Point(344, 2)
        Me.checkHasPresetValues.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.checkHasPresetValues.Name = "checkHasPresetValues"
        Me.checkHasPresetValues.Size = New System.Drawing.Size(141, 17)
        Me.checkHasPresetValues.TabIndex = 6
        Me.checkHasPresetValues.Text = "Are there preset values?"
        Me.checkHasPresetValues.UseVisualStyleBackColor = True
        '
        'checkIsLocked
        '
        Me.checkIsLocked.AutoSize = True
        Me.checkIsLocked.Location = New System.Drawing.Point(159, 27)
        Me.checkIsLocked.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.checkIsLocked.Name = "checkIsLocked"
        Me.checkIsLocked.Size = New System.Drawing.Size(154, 17)
        Me.checkIsLocked.TabIndex = 7
        Me.checkIsLocked.Text = "Is this locked to stop edits?"
        Me.checkIsLocked.UseVisualStyleBackColor = True
        '
        'buttonAddField
        '
        Me.buttonAddField.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonAddField.Location = New System.Drawing.Point(600, 79)
        Me.buttonAddField.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.buttonAddField.Name = "buttonAddField"
        Me.buttonAddField.Size = New System.Drawing.Size(81, 22)
        Me.buttonAddField.TabIndex = 8
        Me.buttonAddField.Text = "Add Field"
        Me.buttonAddField.UseVisualStyleBackColor = True
        Me.buttonAddField.Visible = False
        '
        'listPresetValues
        '
        Me.listPresetValues.FormattingEnabled = True
        Me.listPresetValues.Location = New System.Drawing.Point(361, 24)
        Me.listPresetValues.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.listPresetValues.Name = "listPresetValues"
        Me.listPresetValues.Size = New System.Drawing.Size(147, 56)
        Me.listPresetValues.TabIndex = 9
        '
        'linkDeleteField
        '
        Me.linkDeleteField.AutoSize = True
        Me.linkDeleteField.Location = New System.Drawing.Point(524, 84)
        Me.linkDeleteField.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.linkDeleteField.Name = "linkDeleteField"
        Me.linkDeleteField.Size = New System.Drawing.Size(63, 13)
        Me.linkDeleteField.TabIndex = 10
        Me.linkDeleteField.TabStop = True
        Me.linkDeleteField.Text = "Delete Field"
        '
        'checkIsAdditionalField
        '
        Me.checkIsAdditionalField.AutoSize = True
        Me.checkIsAdditionalField.Location = New System.Drawing.Point(344, 84)
        Me.checkIsAdditionalField.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.checkIsAdditionalField.Name = "checkIsAdditionalField"
        Me.checkIsAdditionalField.Size = New System.Drawing.Size(148, 17)
        Me.checkIsAdditionalField.TabIndex = 12
        Me.checkIsAdditionalField.Text = "Is this an Additional Field?"
        Me.checkIsAdditionalField.UseVisualStyleBackColor = True
        '
        'linkAddPresetValue
        '
        Me.linkAddPresetValue.AutoSize = True
        Me.linkAddPresetValue.Location = New System.Drawing.Point(488, 3)
        Me.linkAddPresetValue.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.linkAddPresetValue.Name = "linkAddPresetValue"
        Me.linkAddPresetValue.Size = New System.Drawing.Size(87, 13)
        Me.linkAddPresetValue.TabIndex = 11
        Me.linkAddPresetValue.TabStop = True
        Me.linkAddPresetValue.Text = "Add preset value"
        '
        'LinkSupplementary
        '
        Me.LinkSupplementary.AutoSize = True
        Me.LinkSupplementary.Location = New System.Drawing.Point(96, 84)
        Me.LinkSupplementary.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkSupplementary.Name = "LinkSupplementary"
        Me.LinkSupplementary.Size = New System.Drawing.Size(223, 13)
        Me.LinkSupplementary.TabIndex = 13
        Me.LinkSupplementary.TabStop = True
        Me.LinkSupplementary.Text = "Example Value, CIBadge Field, Other Db Field"
        '
        'LabelHeaderTop
        '
        Me.LabelHeaderTop.AutoSize = True
        Me.LabelHeaderTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderTop.Location = New System.Drawing.Point(4, 10)
        Me.LabelHeaderTop.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeaderTop.Name = "LabelHeaderTop"
        Me.LabelHeaderTop.Size = New System.Drawing.Size(142, 26)
        Me.LabelHeaderTop.TabIndex = 4
        Me.LabelHeaderTop.Text = "Text Field # 1"
        Me.LabelHeaderTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'checkDisplayOnBadge
        '
        Me.checkDisplayOnBadge.AutoSize = True
        Me.checkDisplayOnBadge.Checked = True
        Me.checkDisplayOnBadge.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkDisplayOnBadge.Location = New System.Drawing.Point(527, 28)
        Me.checkDisplayOnBadge.Margin = New System.Windows.Forms.Padding(2)
        Me.checkDisplayOnBadge.Name = "checkDisplayOnBadge"
        Me.checkDisplayOnBadge.Size = New System.Drawing.Size(146, 17)
        Me.checkDisplayOnBadge.TabIndex = 23
        Me.checkDisplayOnBadge.Text = "Display on printed badge."
        Me.checkDisplayOnBadge.UseVisualStyleBackColor = True
        '
        'checkDisplayForEdits
        '
        Me.checkDisplayForEdits.AutoSize = True
        Me.checkDisplayForEdits.Checked = True
        Me.checkDisplayForEdits.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkDisplayForEdits.Location = New System.Drawing.Point(527, 49)
        Me.checkDisplayForEdits.Margin = New System.Windows.Forms.Padding(2)
        Me.checkDisplayForEdits.Name = "checkDisplayForEdits"
        Me.checkDisplayForEdits.Size = New System.Drawing.Size(154, 17)
        Me.checkDisplayForEdits.TabIndex = 22
        Me.checkDisplayForEdits.Text = "Display on Main Data Entry"
        Me.checkDisplayForEdits.UseVisualStyleBackColor = True
        '
        'CtlConfigFldCustom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.checkDisplayOnBadge)
        Me.Controls.Add(Me.checkDisplayForEdits)
        Me.Controls.Add(Me.LinkSupplementary)
        Me.Controls.Add(Me.checkIsAdditionalField)
        Me.Controls.Add(Me.linkAddPresetValue)
        Me.Controls.Add(Me.linkDeleteField)
        Me.Controls.Add(Me.listPresetValues)
        Me.Controls.Add(Me.buttonAddField)
        Me.Controls.Add(Me.checkIsLocked)
        Me.Controls.Add(Me.checkHasPresetValues)
        Me.Controls.Add(Me.LabelHeaderTop)
        Me.Controls.Add(Me.LabelFieldLabelCaption)
        Me.Controls.Add(Me.checkIsFieldForDates)
        Me.Controls.Add(Me.textFieldLabel)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "CtlConfigFldCustom"
        Me.Size = New System.Drawing.Size(704, 110)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textFieldLabel As TextBox
    Friend WithEvents checkIsFieldForDates As CheckBox
    Friend WithEvents LabelFieldLabelCaption As Label
    Friend WithEvents checkHasPresetValues As CheckBox
    Friend WithEvents checkIsLocked As CheckBox
    Friend WithEvents buttonAddField As Button
    Friend WithEvents listPresetValues As ListBox
    Friend WithEvents linkDeleteField As LinkLabel
    Friend WithEvents checkIsAdditionalField As CheckBox
    Friend WithEvents linkAddPresetValue As LinkLabel
    Friend WithEvents LinkSupplementary As LinkLabel
    Friend WithEvents LabelHeaderTop As Label
    Friend WithEvents checkDisplayOnBadge As CheckBox
    Friend WithEvents checkDisplayForEdits As CheckBox
End Class
