﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlConfigFldCustRelevancy
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
        Me.LabelQuestion = New System.Windows.Forms.Label()
        Me.LabelNotYetRelevant = New System.Windows.Forms.Label()
        Me.CtlConfigFldCustom1 = New ciBadgeDesigner.CtlConfigFldCustom()
        Me.CheckBoxRelevant = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'LabelQuestion
        '
        Me.LabelQuestion.AutoSize = True
        Me.LabelQuestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelQuestion.Location = New System.Drawing.Point(201, 0)
        Me.LabelQuestion.Name = "LabelQuestion"
        Me.LabelQuestion.Size = New System.Drawing.Size(445, 24)
        Me.LabelQuestion.TabIndex = 4
        Me.LabelQuestion.Text = "Is this field relevant to your organization/personality? "
        '
        'LabelNotYetRelevant
        '
        Me.LabelNotYetRelevant.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNotYetRelevant.Location = New System.Drawing.Point(3, 0)
        Me.LabelNotYetRelevant.Name = "LabelNotYetRelevant"
        Me.LabelNotYetRelevant.Size = New System.Drawing.Size(192, 147)
        Me.LabelNotYetRelevant.TabIndex = 3
        Me.LabelNotYetRelevant.Tag = "Not yet selected by you as Relevant for the Personality / Organization...."
        Me.LabelNotYetRelevant.Text = "Not yet selected by you as Relevant for the Personality / Organization...."
        '
        'CtlConfigFldCustom1
        '
        Me.CtlConfigFldCustom1.BackColor = System.Drawing.Color.LightCyan
        Me.CtlConfigFldCustom1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CtlConfigFldCustom1.Location = New System.Drawing.Point(205, 27)
        Me.CtlConfigFldCustom1.Margin = New System.Windows.Forms.Padding(2)
        Me.CtlConfigFldCustom1.Name = "CtlConfigFldCustom1"
        Me.CtlConfigFldCustom1.Size = New System.Drawing.Size(670, 115)
        Me.CtlConfigFldCustom1.TabIndex = 5
        '
        'CheckBoxRelevant
        '
        Me.CheckBoxRelevant.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxRelevant.AutoSize = True
        Me.CheckBoxRelevant.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxRelevant.Location = New System.Drawing.Point(678, 3)
        Me.CheckBoxRelevant.Name = "CheckBoxRelevant"
        Me.CheckBoxRelevant.Size = New System.Drawing.Size(140, 24)
        Me.CheckBoxRelevant.TabIndex = 6
        Me.CheckBoxRelevant.Text = "Yes, Relevant"
        Me.CheckBoxRelevant.UseVisualStyleBackColor = True
        '
        'CtlConfigFldCustRelevancy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.CtlConfigFldCustom1)
        Me.Controls.Add(Me.LabelQuestion)
        Me.Controls.Add(Me.LabelNotYetRelevant)
        Me.Controls.Add(Me.CheckBoxRelevant)
        Me.Name = "CtlConfigFldCustRelevancy"
        Me.Size = New System.Drawing.Size(884, 143)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelQuestion As Label
    Friend WithEvents LabelNotYetRelevant As Label
    Friend WithEvents CtlConfigFldCustom1 As CtlConfigFldCustom
    Friend WithEvents CheckBoxRelevant As CheckBox
End Class
