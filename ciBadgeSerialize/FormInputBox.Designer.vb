<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInputBox
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
        Me.LabelFinalPrompt = New System.Windows.Forms.Label()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.textUsersResponse = New System.Windows.Forms.TextBox()
        Me.LabelMainInstructions = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelFinalPrompt
        '
        Me.LabelFinalPrompt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelFinalPrompt.AutoSize = True
        Me.LabelFinalPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.LabelFinalPrompt.Location = New System.Drawing.Point(12, 136)
        Me.LabelFinalPrompt.Name = "LabelFinalPrompt"
        Me.LabelFinalPrompt.Size = New System.Drawing.Size(372, 22)
        Me.LabelFinalPrompt.TabIndex = 25
        Me.LabelFinalPrompt.Text = "What is the name of the new ID Card Layout?"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.BackColor = System.Drawing.Color.White
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(685, 174)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(80, 39)
        Me.ButtonCancel.TabIndex = 24
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.BackColor = System.Drawing.Color.White
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(542, 174)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(139, 39)
        Me.ButtonOK.TabIndex = 23
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'textUsersResponse
        '
        Me.textUsersResponse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textUsersResponse.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textUsersResponse.Location = New System.Drawing.Point(422, 133)
        Me.textUsersResponse.Name = "textUsersResponse"
        Me.textUsersResponse.Size = New System.Drawing.Size(325, 26)
        Me.textUsersResponse.TabIndex = 22
        '
        'LabelMainInstructions
        '
        Me.LabelMainInstructions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMainInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMainInstructions.Location = New System.Drawing.Point(12, 9)
        Me.LabelMainInstructions.Name = "LabelMainInstructions"
        Me.LabelMainInstructions.Size = New System.Drawing.Size(722, 121)
        Me.LabelMainInstructions.TabIndex = 21
        Me.LabelMainInstructions.Text = "You are creating a new ID Card Layout."
        '
        'FormInputBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 224)
        Me.Controls.Add(Me.LabelFinalPrompt)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.textUsersResponse)
        Me.Controls.Add(Me.LabelMainInstructions)
        Me.Name = "FormInputBox"
        Me.Text = "FormInputBox"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelFinalPrompt As Windows.Forms.Label
    Friend WithEvents ButtonCancel As Windows.Forms.Button
    Friend WithEvents ButtonOK As Windows.Forms.Button
    Friend WithEvents textUsersResponse As Windows.Forms.TextBox
    Friend WithEvents LabelMainInstructions As Windows.Forms.Label
End Class
