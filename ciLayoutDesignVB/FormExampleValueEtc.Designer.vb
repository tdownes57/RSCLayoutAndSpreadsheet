<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormExampleValueEtc
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.LabelHeaderTop = New System.Windows.Forms.Label()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.dropdownCIBFields = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.listPresetValues = New System.Windows.Forms.ListBox()
        Me.checkHasPresetValues = New System.Windows.Forms.CheckBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ButtonAddValue = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LabelFieldLabelCaption
        '
        Me.LabelFieldLabelCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFieldLabelCaption.Location = New System.Drawing.Point(38, 58)
        Me.LabelFieldLabelCaption.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelFieldLabelCaption.Name = "LabelFieldLabelCaption"
        Me.LabelFieldLabelCaption.Size = New System.Drawing.Size(122, 20)
        Me.LabelFieldLabelCaption.TabIndex = 4
        Me.LabelFieldLabelCaption.Text = "Example Value"
        '
        'textExampleValue
        '
        Me.textExampleValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textExampleValue.Location = New System.Drawing.Point(164, 54)
        Me.textExampleValue.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.textExampleValue.Name = "textExampleValue"
        Me.textExampleValue.Size = New System.Drawing.Size(162, 26)
        Me.textExampleValue.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 88)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "CI Badge Field"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 125)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Other Db Field"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(164, 123)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(162, 26)
        Me.TextBox1.TabIndex = 8
        '
        'LabelHeaderTop
        '
        Me.LabelHeaderTop.AutoSize = True
        Me.LabelHeaderTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderTop.Location = New System.Drawing.Point(6, 7)
        Me.LabelHeaderTop.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeaderTop.Name = "LabelHeaderTop"
        Me.LabelHeaderTop.Size = New System.Drawing.Size(208, 26)
        Me.LabelHeaderTop.TabIndex = 9
        Me.LabelHeaderTop.Text = "Optional Information"
        Me.LabelHeaderTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(157, 168)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(94, 48)
        Me.ButtonOK.TabIndex = 10
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(268, 168)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(58, 48)
        Me.ButtonCancel.TabIndex = 11
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'dropdownCIBFields
        '
        Me.dropdownCIBFields.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dropdownCIBFields.FormattingEnabled = True
        Me.dropdownCIBFields.Items.AddRange(New Object() {"TextField01", "TextField02", "TextField03", "TextField04", "TextField05", "TextFiedl06", "DateField01", "DateField02", "DateField03", "DateField04", "DateField05"})
        Me.dropdownCIBFields.Location = New System.Drawing.Point(164, 85)
        Me.dropdownCIBFields.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dropdownCIBFields.Name = "dropdownCIBFields"
        Me.dropdownCIBFields.Size = New System.Drawing.Size(162, 28)
        Me.dropdownCIBFields.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 243)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 26)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Preset Values"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'listPresetValues
        '
        Me.listPresetValues.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listPresetValues.FormattingEnabled = True
        Me.listPresetValues.ItemHeight = 16
        Me.listPresetValues.Location = New System.Drawing.Point(67, 335)
        Me.listPresetValues.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.listPresetValues.Name = "listPresetValues"
        Me.listPresetValues.Size = New System.Drawing.Size(237, 52)
        Me.listPresetValues.TabIndex = 15
        '
        'checkHasPresetValues
        '
        Me.checkHasPresetValues.AutoSize = True
        Me.checkHasPresetValues.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkHasPresetValues.Location = New System.Drawing.Point(67, 275)
        Me.checkHasPresetValues.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.checkHasPresetValues.Name = "checkHasPresetValues"
        Me.checkHasPresetValues.Size = New System.Drawing.Size(183, 21)
        Me.checkHasPresetValues.TabIndex = 14
        Me.checkHasPresetValues.Text = "Are there preset values?"
        Me.checkHasPresetValues.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(67, 300)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(179, 26)
        Me.TextBox2.TabIndex = 18
        '
        'ButtonAddValue
        '
        Me.ButtonAddValue.Location = New System.Drawing.Point(249, 295)
        Me.ButtonAddValue.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonAddValue.Name = "ButtonAddValue"
        Me.ButtonAddValue.Size = New System.Drawing.Size(78, 29)
        Me.ButtonAddValue.TabIndex = 19
        Me.ButtonAddValue.Text = "Add Value"
        Me.ButtonAddValue.UseVisualStyleBackColor = True
        '
        'FormExampleValueEtc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 226)
        Me.Controls.Add(Me.ButtonAddValue)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.listPresetValues)
        Me.Controls.Add(Me.checkHasPresetValues)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dropdownCIBFields)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.LabelHeaderTop)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelFieldLabelCaption)
        Me.Controls.Add(Me.textExampleValue)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FormExampleValueEtc"
        Me.Text = "FormExampleValueEtc"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelFieldLabelCaption As Label
    Friend WithEvents textExampleValue As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents LabelHeaderTop As Label
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents dropdownCIBFields As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents listPresetValues As ListBox
    Friend WithEvents checkHasPresetValues As CheckBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ButtonAddValue As Button
End Class
