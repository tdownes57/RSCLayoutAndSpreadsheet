<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSpecialButton
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.LabelMainPrompt = New System.Windows.Forms.Label()
        Me.ButtonSpecialButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBox1.Location = New System.Drawing.Point(12, 46)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(479, 159)
        Me.TextBox1.TabIndex = 32
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(371, 210)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(121, 48)
        Me.ButtonOK.TabIndex = 31
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'LabelMainPrompt
        '
        Me.LabelMainPrompt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMainPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMainPrompt.Location = New System.Drawing.Point(7, 10)
        Me.LabelMainPrompt.Name = "LabelMainPrompt"
        Me.LabelMainPrompt.Size = New System.Drawing.Size(484, 33)
        Me.LabelMainPrompt.TabIndex = 30
        Me.LabelMainPrompt.Text = "Here is the entire message. "
        '
        'ButtonSpecialButton
        '
        Me.ButtonSpecialButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonSpecialButton.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonSpecialButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSpecialButton.Location = New System.Drawing.Point(9, 210)
        Me.ButtonSpecialButton.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonSpecialButton.Name = "ButtonSpecialButton"
        Me.ButtonSpecialButton.Size = New System.Drawing.Size(249, 48)
        Me.ButtonSpecialButton.TabIndex = 33
        Me.ButtonSpecialButton.Text = "This is a special button."
        Me.ButtonSpecialButton.UseVisualStyleBackColor = False
        '
        'FormSpecialButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 269)
        Me.Controls.Add(Me.ButtonSpecialButton)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.LabelMainPrompt)
        Me.Name = "FormSpecialButton"
        Me.Text = "FormSpecialButton"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents ButtonOK As Windows.Forms.Button
    Friend WithEvents LabelMainPrompt As Windows.Forms.Label
    Friend WithEvents ButtonSpecialButton As Windows.Forms.Button
End Class
