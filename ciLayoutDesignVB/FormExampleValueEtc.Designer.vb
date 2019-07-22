<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormExampleValueEtc
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.LabelFieldLabelCaption = New System.Windows.Forms.Label()
        Me.textExampleValue = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.textOtherDbField = New System.Windows.Forms.TextBox()
        Me.LabelHeaderTop = New System.Windows.Forms.Label()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.dropdownCIBadgeField = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'LabelFieldLabelCaption
        '
        Me.LabelFieldLabelCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFieldLabelCaption.Location = New System.Drawing.Point(50, 72)
        Me.LabelFieldLabelCaption.Name = "LabelFieldLabelCaption"
        Me.LabelFieldLabelCaption.Size = New System.Drawing.Size(162, 25)
        Me.LabelFieldLabelCaption.TabIndex = 4
        Me.LabelFieldLabelCaption.Text = "Example Value"
        '
        'textExampleValue
        '
        Me.textExampleValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textExampleValue.Location = New System.Drawing.Point(218, 67)
        Me.textExampleValue.Name = "textExampleValue"
        Me.textExampleValue.Size = New System.Drawing.Size(215, 30)
        Me.textExampleValue.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 25)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "CI Badge Field"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(50, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 25)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Other Db Field"
        '
        'textOtherDbField
        '
        Me.textOtherDbField.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textOtherDbField.Location = New System.Drawing.Point(218, 151)
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
        Me.ButtonOK.Location = New System.Drawing.Point(207, 204)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(126, 59)
        Me.ButtonOK.TabIndex = 10
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(355, 204)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(78, 59)
        Me.ButtonCancel.TabIndex = 11
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'dropdownCIBadgeField
        '
        Me.dropdownCIBadgeField.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dropdownCIBadgeField.FormattingEnabled = True
        Me.dropdownCIBadgeField.Items.AddRange(New Object() {"TextField01", "TextField02", "TextField03", "TextField04", "TextField05", "TextFiedl06", "DateField01", "DateField02", "DateField03", "DateField04", "DateField05"})
        Me.dropdownCIBadgeField.Location = New System.Drawing.Point(218, 105)
        Me.dropdownCIBadgeField.Name = "dropdownCIBadgeField"
        Me.dropdownCIBadgeField.Size = New System.Drawing.Size(215, 33)
        Me.dropdownCIBadgeField.TabIndex = 12
        '
        'FormExampleValueEtc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 285)
        Me.Controls.Add(Me.dropdownCIBadgeField)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.LabelHeaderTop)
        Me.Controls.Add(Me.textOtherDbField)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelFieldLabelCaption)
        Me.Controls.Add(Me.textExampleValue)
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
    Friend WithEvents dropdownCIBadgeField As ComboBox
End Class
