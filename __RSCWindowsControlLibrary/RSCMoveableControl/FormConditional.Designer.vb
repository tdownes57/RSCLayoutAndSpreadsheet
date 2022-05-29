<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConditional
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
        Me.RscSelectCIBField_Simple1 = New __RSCWindowsControlLibrary.RSCSelectCIBField_Simple()
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.LabelValueOfFieldCaption = New System.Windows.Forms.Label()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.TextBoxRelevantValue = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBoxActivated = New System.Windows.Forms.CheckBox()
        Me.PanelExpression = New System.Windows.Forms.Panel()
        Me.LinkLabelActivateThis = New System.Windows.Forms.LinkLabel()
        Me.PanelExpression.SuspendLayout()
        Me.SuspendLayout()
        '
        'RscSelectCIBField_Simple1
        '
        Me.RscSelectCIBField_Simple1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RscSelectCIBField_Simple1.Location = New System.Drawing.Point(7, 5)
        Me.RscSelectCIBField_Simple1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RscSelectCIBField_Simple1.Name = "RscSelectCIBField_Simple1"
        Me.RscSelectCIBField_Simple1.SelectedValue = ciBadgeInterfaces.ModEnumsAndStructs.EnumCIBFields.Undetermined
        Me.RscSelectCIBField_Simple1.Size = New System.Drawing.Size(182, 64)
        Me.RscSelectCIBField_Simple1.TabIndex = 0
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(12, 9)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(373, 20)
        Me.LabelHeader1.TabIndex = 1
        Me.LabelHeader1.Text = "Condition for appearance of element, Field && Value:"
        '
        'LabelValueOfFieldCaption
        '
        Me.LabelValueOfFieldCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelValueOfFieldCaption.Location = New System.Drawing.Point(197, 25)
        Me.LabelValueOfFieldCaption.Name = "LabelValueOfFieldCaption"
        Me.LabelValueOfFieldCaption.Size = New System.Drawing.Size(341, 63)
        Me.LabelValueOfFieldCaption.TabIndex = 2
        Me.LabelValueOfFieldCaption.Text = "Element will appear on ID Cards if the Student, Member, or Staff has the followin" &
    "g value for the Relevant Field :"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(510, 233)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(74, 44)
        Me.ButtonCancel.TabIndex = 23
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(340, 233)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(167, 44)
        Me.ButtonOK.TabIndex = 22
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'TextBoxRelevantValue
        '
        Me.TextBoxRelevantValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxRelevantValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxRelevantValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxRelevantValue.Location = New System.Drawing.Point(317, 68)
        Me.TextBoxRelevantValue.Name = "TextBoxRelevantValue"
        Me.TextBoxRelevantValue.Size = New System.Drawing.Size(221, 24)
        Me.TextBoxRelevantValue.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(196, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 20)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Value"
        '
        'CheckBoxActivated
        '
        Me.CheckBoxActivated.AutoSize = True
        Me.CheckBoxActivated.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxActivated.Location = New System.Drawing.Point(35, 65)
        Me.CheckBoxActivated.Name = "CheckBoxActivated"
        Me.CheckBoxActivated.Size = New System.Drawing.Size(136, 22)
        Me.CheckBoxActivated.TabIndex = 26
        Me.CheckBoxActivated.Text = "Activated for use"
        Me.CheckBoxActivated.UseVisualStyleBackColor = True
        '
        'PanelExpression
        '
        Me.PanelExpression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelExpression.Controls.Add(Me.RscSelectCIBField_Simple1)
        Me.PanelExpression.Controls.Add(Me.Label1)
        Me.PanelExpression.Controls.Add(Me.TextBoxRelevantValue)
        Me.PanelExpression.Controls.Add(Me.LabelValueOfFieldCaption)
        Me.PanelExpression.Enabled = False
        Me.PanelExpression.Location = New System.Drawing.Point(35, 93)
        Me.PanelExpression.Name = "PanelExpression"
        Me.PanelExpression.Size = New System.Drawing.Size(550, 107)
        Me.PanelExpression.TabIndex = 27
        '
        'LinkLabelActivateThis
        '
        Me.LinkLabelActivateThis.AutoSize = True
        Me.LinkLabelActivateThis.Location = New System.Drawing.Point(32, 203)
        Me.LinkLabelActivateThis.Name = "LinkLabelActivateThis"
        Me.LinkLabelActivateThis.Size = New System.Drawing.Size(245, 13)
        Me.LinkLabelActivateThis.TabIndex = 28
        Me.LinkLabelActivateThis.TabStop = True
        Me.LinkLabelActivateThis.Text = "Make this Conditional Expression available for use."
        '
        'FormConditional
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 288)
        Me.Controls.Add(Me.LinkLabelActivateThis)
        Me.Controls.Add(Me.PanelExpression)
        Me.Controls.Add(Me.CheckBoxActivated)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Name = "FormConditional"
        Me.Text = "FormConditional"
        Me.PanelExpression.ResumeLayout(False)
        Me.PanelExpression.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RscSelectCIBField_Simple1 As RSCSelectCIBField_Simple
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents LabelValueOfFieldCaption As Label
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents TextBoxRelevantValue As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBoxActivated As CheckBox
    Friend WithEvents PanelExpression As Panel
    Friend WithEvents LinkLabelActivateThis As LinkLabel
End Class
