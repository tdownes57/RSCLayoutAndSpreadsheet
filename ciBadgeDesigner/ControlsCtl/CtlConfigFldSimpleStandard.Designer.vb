<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlConfigFldSimpleStandard
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
        Me.LabelHeaderTop = New System.Windows.Forms.Label()
        Me.CheckBoxRelevant = New System.Windows.Forms.CheckBox()
        Me.LabelQuestion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelHeaderTop
        '
        Me.LabelHeaderTop.AutoSize = True
        Me.LabelHeaderTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderTop.Location = New System.Drawing.Point(2, 0)
        Me.LabelHeaderTop.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeaderTop.Name = "LabelHeaderTop"
        Me.LabelHeaderTop.Size = New System.Drawing.Size(457, 26)
        Me.LabelHeaderTop.TabIndex = 18
        Me.LabelHeaderTop.Text = "ID  (Recipient ID / Student ID / Staffperson ID)"
        Me.LabelHeaderTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckBoxRelevant
        '
        Me.CheckBoxRelevant.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxRelevant.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxRelevant.Location = New System.Drawing.Point(466, 28)
        Me.CheckBoxRelevant.Name = "CheckBoxRelevant"
        Me.CheckBoxRelevant.Size = New System.Drawing.Size(148, 24)
        Me.CheckBoxRelevant.TabIndex = 28
        Me.CheckBoxRelevant.Text = "Relevant"
        Me.CheckBoxRelevant.UseVisualStyleBackColor = True
        '
        'LabelQuestion
        '
        Me.LabelQuestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelQuestion.Location = New System.Drawing.Point(30, 26)
        Me.LabelQuestion.Name = "LabelQuestion"
        Me.LabelQuestion.Size = New System.Drawing.Size(455, 25)
        Me.LabelQuestion.TabIndex = 27
        Me.LabelQuestion.Text = "Is this field relevant to your organization/ID card?"
        '
        'CtlConfigFldSimpleStandard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CheckBoxRelevant)
        Me.Controls.Add(Me.LabelQuestion)
        Me.Controls.Add(Me.LabelHeaderTop)
        Me.Name = "CtlConfigFldSimpleStandard"
        Me.Size = New System.Drawing.Size(617, 59)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelHeaderTop As Label
    Friend WithEvents CheckBoxRelevant As CheckBox
    Friend WithEvents LabelQuestion As Label
End Class
