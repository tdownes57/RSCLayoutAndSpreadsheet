<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogStaticText
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
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.checkboxSingleLine = New System.Windows.Forms.CheckBox()
        Me.textboxSingleLine = New System.Windows.Forms.TextBox()
        Me.textboxMultiLine = New System.Windows.Forms.TextBox()
        Me.checkboxMultiLine = New System.Windows.Forms.CheckBox()
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(536, 455)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(131, 37)
        Me.ButtonCancel.TabIndex = 93
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(403, 455)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(127, 37)
        Me.ButtonOK.TabIndex = 92
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'checkboxSingleLine
        '
        Me.checkboxSingleLine.AutoSize = True
        Me.checkboxSingleLine.BackColor = System.Drawing.Color.Transparent
        Me.checkboxSingleLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkboxSingleLine.Location = New System.Drawing.Point(57, 53)
        Me.checkboxSingleLine.Name = "checkboxSingleLine"
        Me.checkboxSingleLine.Size = New System.Drawing.Size(158, 24)
        Me.checkboxSingleLine.TabIndex = 94
        Me.checkboxSingleLine.Text = "Single Line of Text"
        Me.checkboxSingleLine.UseVisualStyleBackColor = False
        '
        'textboxSingleLine
        '
        Me.textboxSingleLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxSingleLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textboxSingleLine.Location = New System.Drawing.Point(57, 83)
        Me.textboxSingleLine.Name = "textboxSingleLine"
        Me.textboxSingleLine.Size = New System.Drawing.Size(610, 26)
        Me.textboxSingleLine.TabIndex = 95
        '
        'textboxMultiLine
        '
        Me.textboxMultiLine.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxMultiLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textboxMultiLine.Location = New System.Drawing.Point(57, 145)
        Me.textboxMultiLine.Multiline = True
        Me.textboxMultiLine.Name = "textboxMultiLine"
        Me.textboxMultiLine.Size = New System.Drawing.Size(610, 294)
        Me.textboxMultiLine.TabIndex = 97
        Me.textboxMultiLine.Visible = False
        '
        'checkboxMultiLine
        '
        Me.checkboxMultiLine.AutoSize = True
        Me.checkboxMultiLine.BackColor = System.Drawing.Color.Transparent
        Me.checkboxMultiLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkboxMultiLine.Location = New System.Drawing.Point(57, 115)
        Me.checkboxMultiLine.Name = "checkboxMultiLine"
        Me.checkboxMultiLine.Size = New System.Drawing.Size(176, 24)
        Me.checkboxMultiLine.TabIndex = 96
        Me.checkboxMultiLine.Text = "Multiple Lines of Text"
        Me.checkboxMultiLine.UseVisualStyleBackColor = False
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.BackColor = System.Drawing.Color.Transparent
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(12, 9)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(396, 29)
        Me.LabelHeader1.TabIndex = 98
        Me.LabelHeader1.Text = "Single Line of Text or Multiple Lines"
        '
        'DialogStaticText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ciBadgeDesigner.My.Resources.Resources.Liz_005
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(685, 512)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Controls.Add(Me.textboxMultiLine)
        Me.Controls.Add(Me.checkboxMultiLine)
        Me.Controls.Add(Me.textboxSingleLine)
        Me.Controls.Add(Me.checkboxSingleLine)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DialogStaticText"
        Me.Text = "DialogStaticText"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents checkboxSingleLine As CheckBox
    Friend WithEvents textboxSingleLine As TextBox
    Friend WithEvents textboxMultiLine As TextBox
    Friend WithEvents checkboxMultiLine As CheckBox
    Friend WithEvents LabelHeader1 As Label
End Class
