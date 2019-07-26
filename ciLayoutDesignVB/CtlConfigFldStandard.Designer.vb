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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
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
        Me.checkIsLocked.Location = New System.Drawing.Point(177, 88)
        Me.checkIsLocked.Margin = New System.Windows.Forms.Padding(2)
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
        Me.LabelFieldLabelCaption.Location = New System.Drawing.Point(2, 45)
        Me.LabelFieldLabelCaption.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelFieldLabelCaption.Name = "LabelFieldLabelCaption"
        Me.LabelFieldLabelCaption.Size = New System.Drawing.Size(219, 20)
        Me.LabelFieldLabelCaption.TabIndex = 16
        Me.LabelFieldLabelCaption.Text = "Field Label Caption (Optional)"
        '
        'textFieldLabel
        '
        Me.textFieldLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFieldLabel.Location = New System.Drawing.Point(223, 42)
        Me.textFieldLabel.Margin = New System.Windows.Forms.Padding(2)
        Me.textFieldLabel.Name = "textFieldLabel"
        Me.textFieldLabel.Size = New System.Drawing.Size(170, 26)
        Me.textFieldLabel.TabIndex = 14
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(7, 88)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(166, 17)
        Me.CheckBox1.TabIndex = 20
        Me.CheckBox1.Text = "Displayed on Main Data Entry"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(7, 67)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(147, 17)
        Me.CheckBox2.TabIndex = 21
        Me.CheckBox2.Text = "Displayed on card-badge."
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CtlConfigFldStandard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.LinkSupplementary)
        Me.Controls.Add(Me.checkIsLocked)
        Me.Controls.Add(Me.LabelHeaderTop)
        Me.Controls.Add(Me.LabelFieldLabelCaption)
        Me.Controls.Add(Me.textFieldLabel)
        Me.Name = "CtlConfigFldStandard"
        Me.Size = New System.Drawing.Size(562, 107)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkSupplementary As LinkLabel
    Friend WithEvents checkIsLocked As CheckBox
    Friend WithEvents LabelHeaderTop As Label
    Friend WithEvents LabelFieldLabelCaption As Label
    Friend WithEvents textFieldLabel As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
End Class
