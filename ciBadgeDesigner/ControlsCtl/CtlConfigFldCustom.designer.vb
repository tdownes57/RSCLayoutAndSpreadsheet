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
        Me.checkRelevantToPersonality = New System.Windows.Forms.CheckBox()
        Me.LabelDatabaseFieldname = New System.Windows.Forms.Label()
        Me.LabelDateEdited = New System.Windows.Forms.Label()
        Me.checkBadgeFront = New System.Windows.Forms.CheckBox()
        Me.checkBadgeBackside = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'textFieldLabel
        '
        Me.textFieldLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFieldLabel.Location = New System.Drawing.Point(207, 63)
        Me.textFieldLabel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.textFieldLabel.Name = "textFieldLabel"
        Me.textFieldLabel.Size = New System.Drawing.Size(215, 30)
        Me.textFieldLabel.TabIndex = 0
        '
        'checkIsFieldForDates
        '
        Me.checkIsFieldForDates.AutoSize = True
        Me.checkIsFieldForDates.Location = New System.Drawing.Point(212, 12)
        Me.checkIsFieldForDates.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
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
        Me.checkHasPresetValues.Location = New System.Drawing.Point(459, 2)
        Me.checkHasPresetValues.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.checkHasPresetValues.Name = "checkHasPresetValues"
        Me.checkHasPresetValues.Size = New System.Drawing.Size(186, 21)
        Me.checkHasPresetValues.TabIndex = 6
        Me.checkHasPresetValues.Text = "Are there preset values?"
        Me.checkHasPresetValues.UseVisualStyleBackColor = True
        '
        'checkIsLocked
        '
        Me.checkIsLocked.AutoSize = True
        Me.checkIsLocked.Location = New System.Drawing.Point(212, 33)
        Me.checkIsLocked.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.checkIsLocked.Name = "checkIsLocked"
        Me.checkIsLocked.Size = New System.Drawing.Size(200, 21)
        Me.checkIsLocked.TabIndex = 7
        Me.checkIsLocked.Text = "Is this locked to stop edits?"
        Me.checkIsLocked.UseVisualStyleBackColor = True
        '
        'buttonAddField
        '
        Me.buttonAddField.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonAddField.Location = New System.Drawing.Point(800, 97)
        Me.buttonAddField.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.buttonAddField.Name = "buttonAddField"
        Me.buttonAddField.Size = New System.Drawing.Size(108, 27)
        Me.buttonAddField.TabIndex = 8
        Me.buttonAddField.Text = "Add Field"
        Me.buttonAddField.UseVisualStyleBackColor = True
        Me.buttonAddField.Visible = False
        '
        'listPresetValues
        '
        Me.listPresetValues.FormattingEnabled = True
        Me.listPresetValues.ItemHeight = 16
        Me.listPresetValues.Location = New System.Drawing.Point(459, 34)
        Me.listPresetValues.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.listPresetValues.Name = "listPresetValues"
        Me.listPresetValues.Size = New System.Drawing.Size(195, 68)
        Me.listPresetValues.TabIndex = 9
        '
        'linkDeleteField
        '
        Me.linkDeleteField.AutoSize = True
        Me.linkDeleteField.Location = New System.Drawing.Point(699, 103)
        Me.linkDeleteField.Name = "linkDeleteField"
        Me.linkDeleteField.Size = New System.Drawing.Size(83, 17)
        Me.linkDeleteField.TabIndex = 10
        Me.linkDeleteField.TabStop = True
        Me.linkDeleteField.Text = "Delete Field"
        '
        'checkIsAdditionalField
        '
        Me.checkIsAdditionalField.AutoSize = True
        Me.checkIsAdditionalField.Location = New System.Drawing.Point(277, 116)
        Me.checkIsAdditionalField.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.checkIsAdditionalField.Name = "checkIsAdditionalField"
        Me.checkIsAdditionalField.Size = New System.Drawing.Size(194, 21)
        Me.checkIsAdditionalField.TabIndex = 12
        Me.checkIsAdditionalField.Text = "Is this an Additional Field?"
        Me.checkIsAdditionalField.UseVisualStyleBackColor = True
        Me.checkIsAdditionalField.Visible = False
        '
        'linkAddPresetValue
        '
        Me.linkAddPresetValue.AutoSize = True
        Me.linkAddPresetValue.Location = New System.Drawing.Point(539, 104)
        Me.linkAddPresetValue.Name = "linkAddPresetValue"
        Me.linkAddPresetValue.Size = New System.Drawing.Size(115, 17)
        Me.linkAddPresetValue.TabIndex = 11
        Me.linkAddPresetValue.TabStop = True
        Me.linkAddPresetValue.Text = "Add preset value"
        '
        'LinkSupplementary
        '
        Me.LinkSupplementary.AutoSize = True
        Me.LinkSupplementary.Location = New System.Drawing.Point(83, 97)
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
        Me.LabelHeaderTop.Location = New System.Drawing.Point(3, 2)
        Me.LabelHeaderTop.Name = "LabelHeaderTop"
        Me.LabelHeaderTop.Size = New System.Drawing.Size(177, 31)
        Me.LabelHeaderTop.TabIndex = 4
        Me.LabelHeaderTop.Text = "Text Field # 1"
        Me.LabelHeaderTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'checkDisplayOnBadge
        '
        Me.checkDisplayOnBadge.AutoSize = True
        Me.checkDisplayOnBadge.Checked = True
        Me.checkDisplayOnBadge.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkDisplayOnBadge.Location = New System.Drawing.Point(680, 46)
        Me.checkDisplayOnBadge.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.checkDisplayOnBadge.Name = "checkDisplayOnBadge"
        Me.checkDisplayOnBadge.Size = New System.Drawing.Size(192, 21)
        Me.checkDisplayOnBadge.TabIndex = 23
        Me.checkDisplayOnBadge.Text = "Display on printed badge."
        Me.checkDisplayOnBadge.UseVisualStyleBackColor = True
        '
        'checkDisplayForEdits
        '
        Me.checkDisplayForEdits.AutoSize = True
        Me.checkDisplayForEdits.Checked = True
        Me.checkDisplayForEdits.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkDisplayForEdits.Location = New System.Drawing.Point(680, 27)
        Me.checkDisplayForEdits.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.checkDisplayForEdits.Name = "checkDisplayForEdits"
        Me.checkDisplayForEdits.Size = New System.Drawing.Size(201, 21)
        Me.checkDisplayForEdits.TabIndex = 22
        Me.checkDisplayForEdits.Text = "Display on Main Data Entry"
        Me.checkDisplayForEdits.UseVisualStyleBackColor = True
        '
        'checkRelevantToPersonality
        '
        Me.checkRelevantToPersonality.AutoSize = True
        Me.checkRelevantToPersonality.Checked = True
        Me.checkRelevantToPersonality.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkRelevantToPersonality.Location = New System.Drawing.Point(662, 2)
        Me.checkRelevantToPersonality.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.checkRelevantToPersonality.Name = "checkRelevantToPersonality"
        Me.checkRelevantToPersonality.Size = New System.Drawing.Size(202, 21)
        Me.checkRelevantToPersonality.TabIndex = 24
        Me.checkRelevantToPersonality.Text = "Relevant to this Personality"
        Me.checkRelevantToPersonality.UseVisualStyleBackColor = True
        '
        'LabelDatabaseFieldname
        '
        Me.LabelDatabaseFieldname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDatabaseFieldname.Location = New System.Drawing.Point(4, 34)
        Me.LabelDatabaseFieldname.Name = "LabelDatabaseFieldname"
        Me.LabelDatabaseFieldname.Size = New System.Drawing.Size(180, 25)
        Me.LabelDatabaseFieldname.TabIndex = 25
        Me.LabelDatabaseFieldname.Text = "Database Field Name"
        '
        'LabelDateEdited
        '
        Me.LabelDateEdited.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDateEdited.Location = New System.Drawing.Point(6, 117)
        Me.LabelDateEdited.Name = "LabelDateEdited"
        Me.LabelDateEdited.Size = New System.Drawing.Size(250, 20)
        Me.LabelDateEdited.TabIndex = 26
        Me.LabelDateEdited.Text = "[ Date Edited ]"
        '
        'checkBadgeFront
        '
        Me.checkBadgeFront.AutoSize = True
        Me.checkBadgeFront.Checked = True
        Me.checkBadgeFront.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBadgeFront.Location = New System.Drawing.Point(702, 63)
        Me.checkBadgeFront.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.checkBadgeFront.Name = "checkBadgeFront"
        Me.checkBadgeFront.Size = New System.Drawing.Size(63, 21)
        Me.checkBadgeFront.TabIndex = 27
        Me.checkBadgeFront.Text = "Front"
        Me.checkBadgeFront.UseVisualStyleBackColor = True
        '
        'checkBadgeBackside
        '
        Me.checkBadgeBackside.AutoSize = True
        Me.checkBadgeBackside.Checked = True
        Me.checkBadgeBackside.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBadgeBackside.Location = New System.Drawing.Point(771, 63)
        Me.checkBadgeBackside.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.checkBadgeBackside.Name = "checkBadgeBackside"
        Me.checkBadgeBackside.Size = New System.Drawing.Size(87, 21)
        Me.checkBadgeBackside.TabIndex = 28
        Me.checkBadgeBackside.Text = "Backside"
        Me.checkBadgeBackside.UseVisualStyleBackColor = True
        '
        'CtlConfigFldCustom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.checkBadgeBackside)
        Me.Controls.Add(Me.checkBadgeFront)
        Me.Controls.Add(Me.LabelDateEdited)
        Me.Controls.Add(Me.LabelDatabaseFieldname)
        Me.Controls.Add(Me.checkRelevantToPersonality)
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
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "CtlConfigFldCustom"
        Me.Size = New System.Drawing.Size(939, 135)
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
    Friend WithEvents checkRelevantToPersonality As CheckBox
    Friend WithEvents LabelDatabaseFieldname As Label
    Friend WithEvents LabelDateEdited As Label
    Friend WithEvents checkBadgeFront As CheckBox
    Friend WithEvents checkBadgeBackside As CheckBox
End Class
