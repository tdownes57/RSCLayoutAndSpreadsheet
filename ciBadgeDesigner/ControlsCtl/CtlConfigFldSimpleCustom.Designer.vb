﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlConfigFldSimpleCustom
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
        Me.LabelDatabaseFieldname = New System.Windows.Forms.Label()
        Me.LabelHeaderTop = New System.Windows.Forms.Label()
        Me.LabelFieldLabelCaption = New System.Windows.Forms.Label()
        Me.CheckBoxRelevant = New System.Windows.Forms.CheckBox()
        Me.LabelQuestion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'textFieldLabel
        '
        Me.textFieldLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFieldLabel.Location = New System.Drawing.Point(442, 0)
        Me.textFieldLabel.Margin = New System.Windows.Forms.Padding(2)
        Me.textFieldLabel.Name = "textFieldLabel"
        Me.textFieldLabel.Size = New System.Drawing.Size(162, 26)
        Me.textFieldLabel.TabIndex = 26
        '
        'LabelDatabaseFieldname
        '
        Me.LabelDatabaseFieldname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDatabaseFieldname.Location = New System.Drawing.Point(3, 26)
        Me.LabelDatabaseFieldname.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelDatabaseFieldname.Name = "LabelDatabaseFieldname"
        Me.LabelDatabaseFieldname.Size = New System.Drawing.Size(135, 20)
        Me.LabelDatabaseFieldname.TabIndex = 29
        Me.LabelDatabaseFieldname.Text = "Database Field Name"
        '
        'LabelHeaderTop
        '
        Me.LabelHeaderTop.AutoSize = True
        Me.LabelHeaderTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderTop.Location = New System.Drawing.Point(2, 0)
        Me.LabelHeaderTop.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeaderTop.Name = "LabelHeaderTop"
        Me.LabelHeaderTop.Size = New System.Drawing.Size(224, 26)
        Me.LabelHeaderTop.TabIndex = 28
        Me.LabelHeaderTop.Text = "Custom Text Field # 1"
        Me.LabelHeaderTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelFieldLabelCaption
        '
        Me.LabelFieldLabelCaption.BackColor = System.Drawing.Color.Transparent
        Me.LabelFieldLabelCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFieldLabelCaption.Location = New System.Drawing.Point(289, 4)
        Me.LabelFieldLabelCaption.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelFieldLabelCaption.Name = "LabelFieldLabelCaption"
        Me.LabelFieldLabelCaption.Size = New System.Drawing.Size(150, 20)
        Me.LabelFieldLabelCaption.TabIndex = 27
        Me.LabelFieldLabelCaption.Text = "Field Label Caption"
        '
        'CheckBoxRelevant
        '
        Me.CheckBoxRelevant.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxRelevant.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxRelevant.Location = New System.Drawing.Point(455, 48)
        Me.CheckBoxRelevant.Name = "CheckBoxRelevant"
        Me.CheckBoxRelevant.Size = New System.Drawing.Size(184, 24)
        Me.CheckBoxRelevant.TabIndex = 31
        Me.CheckBoxRelevant.Text = "Relevant"
        Me.CheckBoxRelevant.UseVisualStyleBackColor = True
        '
        'LabelQuestion
        '
        Me.LabelQuestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelQuestion.Location = New System.Drawing.Point(3, 46)
        Me.LabelQuestion.Name = "LabelQuestion"
        Me.LabelQuestion.Size = New System.Drawing.Size(455, 25)
        Me.LabelQuestion.TabIndex = 30
        Me.LabelQuestion.Text = "Is this field relevant to your organization/ID card?"
        '
        'CtlConfigFldSimpleCustom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGreen
        Me.Controls.Add(Me.CheckBoxRelevant)
        Me.Controls.Add(Me.LabelQuestion)
        Me.Controls.Add(Me.textFieldLabel)
        Me.Controls.Add(Me.LabelDatabaseFieldname)
        Me.Controls.Add(Me.LabelHeaderTop)
        Me.Controls.Add(Me.LabelFieldLabelCaption)
        Me.Name = "CtlConfigFldSimpleCustom"
        Me.Size = New System.Drawing.Size(642, 74)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textFieldLabel As TextBox
    Friend WithEvents LabelDatabaseFieldname As Label
    Friend WithEvents LabelHeaderTop As Label
    Friend WithEvents LabelFieldLabelCaption As Label
    Friend WithEvents CheckBoxRelevant As CheckBox
    Friend WithEvents LabelQuestion As Label
End Class
