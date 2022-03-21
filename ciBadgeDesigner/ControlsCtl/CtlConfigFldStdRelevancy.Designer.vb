<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlConfigFldStdRelevancy
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
        Me.CtlConfigFldStandard1 = New ciBadgeDesigner.CtlConfigFldStandard()
        Me.LabelNotYetRelevant = New System.Windows.Forms.Label()
        Me.LabelQuestion = New System.Windows.Forms.Label()
        Me.CheckBoxRelevant = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'CtlConfigFldStandard1
        '
        Me.CtlConfigFldStandard1.BackColor = System.Drawing.Color.PowderBlue
        Me.CtlConfigFldStandard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CtlConfigFldStandard1.Location = New System.Drawing.Point(203, 28)
        Me.CtlConfigFldStandard1.Name = "CtlConfigFldStandard1"
        Me.CtlConfigFldStandard1.Size = New System.Drawing.Size(562, 126)
        Me.CtlConfigFldStandard1.TabIndex = 0
        '
        'LabelNotYetRelevant
        '
        Me.LabelNotYetRelevant.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNotYetRelevant.Location = New System.Drawing.Point(0, 0)
        Me.LabelNotYetRelevant.Name = "LabelNotYetRelevant"
        Me.LabelNotYetRelevant.Size = New System.Drawing.Size(192, 147)
        Me.LabelNotYetRelevant.TabIndex = 1
        Me.LabelNotYetRelevant.Text = "Not yet selected by you as Relevant for the Personality / Organization...."
        '
        'LabelQuestion
        '
        Me.LabelQuestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelQuestion.Location = New System.Drawing.Point(198, 0)
        Me.LabelQuestion.Name = "LabelQuestion"
        Me.LabelQuestion.Size = New System.Drawing.Size(455, 25)
        Me.LabelQuestion.TabIndex = 2
        Me.LabelQuestion.Text = "Is this field relevant to your organization/ID card?"
        '
        'CheckBoxRelevant
        '
        Me.CheckBoxRelevant.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxRelevant.AutoSize = True
        Me.CheckBoxRelevant.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxRelevant.Location = New System.Drawing.Point(632, 3)
        Me.CheckBoxRelevant.Name = "CheckBoxRelevant"
        Me.CheckBoxRelevant.Size = New System.Drawing.Size(140, 24)
        Me.CheckBoxRelevant.TabIndex = 3
        Me.CheckBoxRelevant.Text = "Yes, Relevant"
        Me.CheckBoxRelevant.UseVisualStyleBackColor = True
        '
        'CtlConfigFldStdRelevancy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.CheckBoxRelevant)
        Me.Controls.Add(Me.LabelQuestion)
        Me.Controls.Add(Me.LabelNotYetRelevant)
        Me.Controls.Add(Me.CtlConfigFldStandard1)
        Me.Name = "CtlConfigFldStdRelevancy"
        Me.Size = New System.Drawing.Size(775, 161)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CtlConfigFldStandard1 As CtlConfigFldStandard
    Friend WithEvents LabelNotYetRelevant As Label
    Friend WithEvents LabelQuestion As Label
    Friend WithEvents CheckBoxRelevant As CheckBox
End Class
