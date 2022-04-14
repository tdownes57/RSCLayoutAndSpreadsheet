<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlConfigFldStandard
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
        Me.LinkSupplementary = New System.Windows.Forms.LinkLabel()
        Me.checkIsLocked = New System.Windows.Forms.CheckBox()
        Me.LabelHeaderTop = New System.Windows.Forms.Label()
        Me.LabelFieldLabelCaption = New System.Windows.Forms.Label()
        Me.textFieldLabel = New System.Windows.Forms.TextBox()
        Me.checkDisplayForEdits = New System.Windows.Forms.CheckBox()
        Me.checkDisplayOnBadge = New System.Windows.Forms.CheckBox()
        Me.checkIsFieldForDates = New System.Windows.Forms.CheckBox()
        Me.checkRelevantToPersonality = New System.Windows.Forms.CheckBox()
        Me.checkBadgeBackside = New System.Windows.Forms.CheckBox()
        Me.checkBadgeFront = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'LinkSupplementary
        '
        Me.LinkSupplementary.AutoSize = True
        Me.LinkSupplementary.Location = New System.Drawing.Point(327, 88)
        Me.LinkSupplementary.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkSupplementary.Name = "LinkSupplementary"
        Me.LinkSupplementary.Size = New System.Drawing.Size(223, 13)
        Me.LinkSupplementary.TabIndex = 19
        Me.LinkSupplementary.TabStop = True
        Me.LinkSupplementary.Text = "Example Value, CIBadge Field, Other Db Field"
        '
        'checkIsLocked
        '
        Me.checkIsLocked.AutoSize = True
        Me.checkIsLocked.Location = New System.Drawing.Point(210, 72)
        Me.checkIsLocked.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.checkIsLocked.Name = "checkIsLocked"
        Me.checkIsLocked.Size = New System.Drawing.Size(113, 17)
        Me.checkIsLocked.TabIndex = 18
        Me.checkIsLocked.Text = "Locked / no edits."
        Me.checkIsLocked.UseVisualStyleBackColor = True
        '
        'LabelHeaderTop
        '
        Me.LabelHeaderTop.AutoSize = True
        Me.LabelHeaderTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderTop.Location = New System.Drawing.Point(2, 0)
        Me.LabelHeaderTop.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeaderTop.Name = "LabelHeaderTop"
        Me.LabelHeaderTop.Size = New System.Drawing.Size(457, 26)
        Me.LabelHeaderTop.TabIndex = 17
        Me.LabelHeaderTop.Text = "ID  (Recipient ID / Student ID / Staffperson ID)"
        Me.LabelHeaderTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelFieldLabelCaption
        '
        Me.LabelFieldLabelCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFieldLabelCaption.Location = New System.Drawing.Point(3, 42)
        Me.LabelFieldLabelCaption.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelFieldLabelCaption.Name = "LabelFieldLabelCaption"
        Me.LabelFieldLabelCaption.Size = New System.Drawing.Size(219, 20)
        Me.LabelFieldLabelCaption.TabIndex = 16
        Me.LabelFieldLabelCaption.Text = "Field Label Caption (Optional)"
        '
        'textFieldLabel
        '
        Me.textFieldLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFieldLabel.Location = New System.Drawing.Point(226, 39)
        Me.textFieldLabel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.textFieldLabel.Name = "textFieldLabel"
        Me.textFieldLabel.Size = New System.Drawing.Size(170, 26)
        Me.textFieldLabel.TabIndex = 14
        '
        'checkDisplayForEdits
        '
        Me.checkDisplayForEdits.AutoSize = True
        Me.checkDisplayForEdits.Location = New System.Drawing.Point(55, 89)
        Me.checkDisplayForEdits.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.checkDisplayForEdits.Name = "checkDisplayForEdits"
        Me.checkDisplayForEdits.Size = New System.Drawing.Size(154, 17)
        Me.checkDisplayForEdits.TabIndex = 20
        Me.checkDisplayForEdits.Text = "Display on Main Data Entry"
        Me.checkDisplayForEdits.UseVisualStyleBackColor = True
        '
        'checkDisplayOnBadge
        '
        Me.checkDisplayOnBadge.AutoSize = True
        Me.checkDisplayOnBadge.Location = New System.Drawing.Point(55, 107)
        Me.checkDisplayOnBadge.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.checkDisplayOnBadge.Name = "checkDisplayOnBadge"
        Me.checkDisplayOnBadge.Size = New System.Drawing.Size(152, 17)
        Me.checkDisplayOnBadge.TabIndex = 21
        Me.checkDisplayOnBadge.Text = "Display on ID Card/badge."
        Me.checkDisplayOnBadge.UseVisualStyleBackColor = True
        '
        'checkIsFieldForDates
        '
        Me.checkIsFieldForDates.AutoSize = True
        Me.checkIsFieldForDates.Location = New System.Drawing.Point(401, 68)
        Me.checkIsFieldForDates.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.checkIsFieldForDates.Name = "checkIsFieldForDates"
        Me.checkIsFieldForDates.Size = New System.Drawing.Size(119, 17)
        Me.checkIsFieldForDates.TabIndex = 22
        Me.checkIsFieldForDates.Text = "Is this a Date Field?"
        Me.checkIsFieldForDates.UseVisualStyleBackColor = True
        '
        'checkRelevantToPersonality
        '
        Me.checkRelevantToPersonality.AutoCheck = False
        Me.checkRelevantToPersonality.AutoSize = True
        Me.checkRelevantToPersonality.Location = New System.Drawing.Point(26, 68)
        Me.checkRelevantToPersonality.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.checkRelevantToPersonality.Name = "checkRelevantToPersonality"
        Me.checkRelevantToPersonality.Size = New System.Drawing.Size(154, 17)
        Me.checkRelevantToPersonality.TabIndex = 25
        Me.checkRelevantToPersonality.Text = "Relevant to this Personality"
        Me.checkRelevantToPersonality.UseVisualStyleBackColor = True
        '
        'checkBadgeBackside
        '
        Me.checkBadgeBackside.AutoSize = True
        Me.checkBadgeBackside.Checked = True
        Me.checkBadgeBackside.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBadgeBackside.Location = New System.Drawing.Point(251, 107)
        Me.checkBadgeBackside.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.checkBadgeBackside.Name = "checkBadgeBackside"
        Me.checkBadgeBackside.Size = New System.Drawing.Size(70, 17)
        Me.checkBadgeBackside.TabIndex = 30
        Me.checkBadgeBackside.Text = "Backside"
        Me.checkBadgeBackside.UseVisualStyleBackColor = True
        '
        'checkBadgeFront
        '
        Me.checkBadgeFront.AutoSize = True
        Me.checkBadgeFront.Checked = True
        Me.checkBadgeFront.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBadgeFront.Location = New System.Drawing.Point(206, 107)
        Me.checkBadgeFront.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.checkBadgeFront.Name = "checkBadgeFront"
        Me.checkBadgeFront.Size = New System.Drawing.Size(50, 17)
        Me.checkBadgeFront.TabIndex = 29
        Me.checkBadgeFront.Text = "Front"
        Me.checkBadgeFront.UseVisualStyleBackColor = True
        '
        'CtlConfigFldStandard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.Controls.Add(Me.checkBadgeBackside)
        Me.Controls.Add(Me.checkBadgeFront)
        Me.Controls.Add(Me.checkRelevantToPersonality)
        Me.Controls.Add(Me.checkIsFieldForDates)
        Me.Controls.Add(Me.checkDisplayOnBadge)
        Me.Controls.Add(Me.checkDisplayForEdits)
        Me.Controls.Add(Me.LinkSupplementary)
        Me.Controls.Add(Me.checkIsLocked)
        Me.Controls.Add(Me.LabelHeaderTop)
        Me.Controls.Add(Me.LabelFieldLabelCaption)
        Me.Controls.Add(Me.textFieldLabel)
        Me.Name = "CtlConfigFldStandard"
        Me.Size = New System.Drawing.Size(562, 126)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkSupplementary As LinkLabel
    Friend WithEvents checkIsLocked As CheckBox
    Friend WithEvents LabelHeaderTop As Label
    Friend WithEvents LabelFieldLabelCaption As Label
    Friend WithEvents textFieldLabel As TextBox
    Friend WithEvents checkDisplayForEdits As CheckBox
    Friend WithEvents checkDisplayOnBadge As CheckBox
    Friend WithEvents checkIsFieldForDates As CheckBox
    Friend WithEvents checkRelevantToPersonality As CheckBox
    Friend WithEvents checkBadgeBackside As CheckBox
    Friend WithEvents checkBadgeFront As CheckBox
End Class
