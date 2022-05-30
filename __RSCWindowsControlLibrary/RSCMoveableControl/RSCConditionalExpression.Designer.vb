<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCConditionalExpression
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
        Me.checkboxPreviewDisplay = New System.Windows.Forms.CheckBox()
        Me.checkboxBlankValuesOkay = New System.Windows.Forms.CheckBox()
        Me.RscSelectCIBField_Simple1 = New __RSCWindowsControlLibrary.RSCSelectCIBField_Simple()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxRelevantValue = New System.Windows.Forms.TextBox()
        Me.LabelValueOfFieldCaption = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'checkboxPreviewDisplay
        '
        Me.checkboxPreviewDisplay.AutoSize = True
        Me.checkboxPreviewDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkboxPreviewDisplay.Location = New System.Drawing.Point(132, 120)
        Me.checkboxPreviewDisplay.Name = "checkboxPreviewDisplay"
        Me.checkboxPreviewDisplay.Size = New System.Drawing.Size(363, 21)
        Me.checkboxPreviewDisplay.TabIndex = 33
        Me.checkboxPreviewDisplay.Text = "If checked, element will display in Previews of ID card."
        Me.checkboxPreviewDisplay.UseVisualStyleBackColor = True
        '
        'checkboxBlankValuesOkay
        '
        Me.checkboxBlankValuesOkay.AutoSize = True
        Me.checkboxBlankValuesOkay.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkboxBlankValuesOkay.Location = New System.Drawing.Point(132, 93)
        Me.checkboxBlankValuesOkay.Name = "checkboxBlankValuesOkay"
        Me.checkboxBlankValuesOkay.Size = New System.Drawing.Size(386, 21)
        Me.checkboxBlankValuesOkay.TabIndex = 32
        Me.checkboxBlankValuesOkay.Text = "If checked, blank/missing values will satisfy this condition."
        Me.checkboxBlankValuesOkay.UseVisualStyleBackColor = True
        '
        'RscSelectCIBField_Simple1
        '
        Me.RscSelectCIBField_Simple1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RscSelectCIBField_Simple1.Location = New System.Drawing.Point(2, 0)
        Me.RscSelectCIBField_Simple1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RscSelectCIBField_Simple1.Name = "RscSelectCIBField_Simple1"
        Me.RscSelectCIBField_Simple1.SelectedValue = ciBadgeInterfaces.ModEnumsAndStructs.EnumCIBFields.Undetermined
        Me.RscSelectCIBField_Simple1.Size = New System.Drawing.Size(182, 64)
        Me.RscSelectCIBField_Simple1.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(191, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 20)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Value"
        '
        'TextBoxRelevantValue
        '
        Me.TextBoxRelevantValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxRelevantValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxRelevantValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxRelevantValue.Location = New System.Drawing.Point(312, 63)
        Me.TextBoxRelevantValue.Name = "TextBoxRelevantValue"
        Me.TextBoxRelevantValue.Size = New System.Drawing.Size(206, 24)
        Me.TextBoxRelevantValue.TabIndex = 30
        '
        'LabelValueOfFieldCaption
        '
        Me.LabelValueOfFieldCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelValueOfFieldCaption.Location = New System.Drawing.Point(192, 20)
        Me.LabelValueOfFieldCaption.Name = "LabelValueOfFieldCaption"
        Me.LabelValueOfFieldCaption.Size = New System.Drawing.Size(341, 63)
        Me.LabelValueOfFieldCaption.TabIndex = 29
        Me.LabelValueOfFieldCaption.Text = "Element will appear on ID Cards if the Student, Member, or Staff has the followin" &
    "g value for the Relevant Field :"
        '
        'RSCConditionalExpression
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.checkboxPreviewDisplay)
        Me.Controls.Add(Me.checkboxBlankValuesOkay)
        Me.Controls.Add(Me.RscSelectCIBField_Simple1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxRelevantValue)
        Me.Controls.Add(Me.LabelValueOfFieldCaption)
        Me.Name = "RSCConditionalExpression"
        Me.Size = New System.Drawing.Size(530, 148)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents checkboxPreviewDisplay As CheckBox
    Friend WithEvents checkboxBlankValuesOkay As CheckBox
    Friend WithEvents RscSelectCIBField_Simple1 As RSCSelectCIBField_Simple
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxRelevantValue As TextBox
    Friend WithEvents LabelValueOfFieldCaption As Label
End Class
