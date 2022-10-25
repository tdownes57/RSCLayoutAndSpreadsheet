Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DialogExampleValueEtc
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
        Me.LabelFieldLabelCaption = New System.Windows.Forms.Label()
        Me.textExampleValue = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.textOtherDbField = New System.Windows.Forms.TextBox()
        Me.LabelHeaderTop = New System.Windows.Forms.Label()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.dropdownCIBFields = New System.Windows.Forms.ComboBox()
        Me.LabelReminderFootnote = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelFieldLabelCaption
        '
        Me.LabelFieldLabelCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFieldLabelCaption.Location = New System.Drawing.Point(51, 71)
        Me.LabelFieldLabelCaption.Name = "LabelFieldLabelCaption"
        Me.LabelFieldLabelCaption.Size = New System.Drawing.Size(163, 25)
        Me.LabelFieldLabelCaption.TabIndex = 4
        Me.LabelFieldLabelCaption.Text = "Example Value"
        '
        'textExampleValue
        '
        Me.textExampleValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textExampleValue.Location = New System.Drawing.Point(219, 66)
        Me.textExampleValue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.textExampleValue.Name = "textExampleValue"
        Me.textExampleValue.Size = New System.Drawing.Size(215, 30)
        Me.textExampleValue.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 25)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "CI Badge Field"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 25)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Other Db Field"
        '
        'textOtherDbField
        '
        Me.textOtherDbField.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textOtherDbField.Location = New System.Drawing.Point(219, 151)
        Me.textOtherDbField.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.textOtherDbField.Name = "textOtherDbField"
        Me.textOtherDbField.Size = New System.Drawing.Size(215, 30)
        Me.textOtherDbField.TabIndex = 8
        '
        'LabelHeaderTop
        '
        Me.LabelHeaderTop.AutoSize = True
        Me.LabelHeaderTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderTop.Location = New System.Drawing.Point(8, 9)
        Me.LabelHeaderTop.Name = "LabelHeaderTop"
        Me.LabelHeaderTop.Size = New System.Drawing.Size(258, 31)
        Me.LabelHeaderTop.TabIndex = 9
        Me.LabelHeaderTop.Text = "Optional Information"
        Me.LabelHeaderTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonOK
        '
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Location = New System.Drawing.Point(209, 228)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(125, 59)
        Me.ButtonOK.TabIndex = 10
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(357, 228)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(77, 59)
        Me.ButtonCancel.TabIndex = 11
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'dropdownCIBFields
        '
        Me.dropdownCIBFields.BackColor = System.Drawing.SystemColors.Menu
        Me.dropdownCIBFields.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dropdownCIBFields.FormattingEnabled = True
        Me.dropdownCIBFields.Items.AddRange(New Object() {"TextField01", "TextField02", "TextField03", "TextField04", "TextField05", "TextFiedl06", "DateField01", "DateField02", "DateField03", "DateField04", "DateField05"})
        Me.dropdownCIBFields.Location = New System.Drawing.Point(219, 105)
        Me.dropdownCIBFields.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dropdownCIBFields.Name = "dropdownCIBFields"
        Me.dropdownCIBFields.Size = New System.Drawing.Size(215, 33)
        Me.dropdownCIBFields.TabIndex = 12
        '
        'LabelReminderFootnote
        '
        Me.LabelReminderFootnote.AutoSize = True
        Me.LabelReminderFootnote.Location = New System.Drawing.Point(112, 191)
        Me.LabelReminderFootnote.Name = "LabelReminderFootnote"
        Me.LabelReminderFootnote.Size = New System.Drawing.Size(317, 17)
        Me.LabelReminderFootnote.TabIndex = 20
        Me.LabelReminderFootnote.Text = "(Reminder, these are supplied only if applicable.)"
        '
        'FormExampleValueEtc
        '
        Me.AcceptButton = Me.ButtonOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(459, 300)
        Me.Controls.Add(Me.LabelReminderFootnote)
        Me.Controls.Add(Me.dropdownCIBFields)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.LabelHeaderTop)
        Me.Controls.Add(Me.textOtherDbField)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelFieldLabelCaption)
        Me.Controls.Add(Me.textExampleValue)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormExampleValueEtc"
        Me.Text = "FormExampleValueEtc"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelFieldLabelCaption As Label
    Friend WithEvents textExampleValue As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents textOtherDbField As TextBox
    Friend WithEvents LabelHeaderTop As Label
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents dropdownCIBFields As ComboBox
    Friend WithEvents LabelReminderFootnote As Label
End Class
