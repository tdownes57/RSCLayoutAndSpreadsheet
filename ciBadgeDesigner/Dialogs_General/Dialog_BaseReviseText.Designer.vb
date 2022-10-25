<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_BaseReviseText
    Inherits Dialog_Base ''feb7 2022 tomdownes1@gmail.com
    ''Feb7 2022''Inherits System.Windows.Forms.Form

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
        Me.textboxMultiLine = New System.Windows.Forms.TextBox()
        Me.checkboxMultiLine = New System.Windows.Forms.CheckBox()
        Me.textboxSingleLine = New System.Windows.Forms.TextBox()
        Me.checkboxSingleLine = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'textboxMultiLine
        '
        Me.textboxMultiLine.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxMultiLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textboxMultiLine.Location = New System.Drawing.Point(632, 149)
        Me.textboxMultiLine.Multiline = True
        Me.textboxMultiLine.Name = "textboxMultiLine"
        Me.textboxMultiLine.Size = New System.Drawing.Size(459, 206)
        Me.textboxMultiLine.TabIndex = 101
        Me.textboxMultiLine.Visible = False
        '
        'checkboxMultiLine
        '
        Me.checkboxMultiLine.AutoSize = True
        Me.checkboxMultiLine.BackColor = System.Drawing.Color.Transparent
        Me.checkboxMultiLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkboxMultiLine.Location = New System.Drawing.Point(632, 119)
        Me.checkboxMultiLine.Name = "checkboxMultiLine"
        Me.checkboxMultiLine.Size = New System.Drawing.Size(176, 24)
        Me.checkboxMultiLine.TabIndex = 100
        Me.checkboxMultiLine.Text = "Multiple Lines of Text"
        Me.checkboxMultiLine.UseVisualStyleBackColor = False
        '
        'textboxSingleLine
        '
        Me.textboxSingleLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxSingleLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textboxSingleLine.Location = New System.Drawing.Point(632, 77)
        Me.textboxSingleLine.Name = "textboxSingleLine"
        Me.textboxSingleLine.Size = New System.Drawing.Size(242, 26)
        Me.textboxSingleLine.TabIndex = 99
        '
        'checkboxSingleLine
        '
        Me.checkboxSingleLine.AutoSize = True
        Me.checkboxSingleLine.BackColor = System.Drawing.Color.Transparent
        Me.checkboxSingleLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkboxSingleLine.Location = New System.Drawing.Point(632, 47)
        Me.checkboxSingleLine.Name = "checkboxSingleLine"
        Me.checkboxSingleLine.Size = New System.Drawing.Size(158, 24)
        Me.checkboxSingleLine.TabIndex = 98
        Me.checkboxSingleLine.Text = "Single Line of Text"
        Me.checkboxSingleLine.UseVisualStyleBackColor = False
        '
        'Dialog_BaseReviseText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1113, 503)
        Me.Controls.Add(Me.textboxMultiLine)
        Me.Controls.Add(Me.checkboxMultiLine)
        Me.Controls.Add(Me.textboxSingleLine)
        Me.Controls.Add(Me.checkboxSingleLine)
        Me.Name = "Dialog_BaseReviseText"
        Me.Text = "DialogReviseText"
        Me.Controls.SetChildIndex(Me.checkboxSingleLine, 0)
        Me.Controls.SetChildIndex(Me.textboxSingleLine, 0)
        Me.Controls.SetChildIndex(Me.checkboxMultiLine, 0)
        Me.Controls.SetChildIndex(Me.textboxMultiLine, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textboxMultiLine As TextBox
    Friend WithEvents checkboxMultiLine As CheckBox
    Friend WithEvents textboxSingleLine As TextBox
    Friend WithEvents checkboxSingleLine As CheckBox
End Class
