<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInputNameDescription
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
        Me.LabelPrompt_Name = New System.Windows.Forms.Label()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.textUsersResponse_Name = New System.Windows.Forms.TextBox()
        Me.LabelMainInstructions = New System.Windows.Forms.Label()
        Me.LabelPrompt_Description = New System.Windows.Forms.Label()
        Me.textUsersResponse_Descr = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'LabelPrompt_Name
        '
        Me.LabelPrompt_Name.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelPrompt_Name.AutoSize = True
        Me.LabelPrompt_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.LabelPrompt_Name.Location = New System.Drawing.Point(33, 163)
        Me.LabelPrompt_Name.Name = "LabelPrompt_Name"
        Me.LabelPrompt_Name.Size = New System.Drawing.Size(372, 22)
        Me.LabelPrompt_Name.TabIndex = 30
        Me.LabelPrompt_Name.Text = "What is the name of the new ID Card Layout?"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.BackColor = System.Drawing.Color.White
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(707, 231)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(80, 39)
        Me.ButtonCancel.TabIndex = 29
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.BackColor = System.Drawing.Color.White
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(564, 231)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(139, 39)
        Me.ButtonOK.TabIndex = 28
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'textUsersResponse_Name
        '
        Me.textUsersResponse_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textUsersResponse_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textUsersResponse_Name.Location = New System.Drawing.Point(443, 160)
        Me.textUsersResponse_Name.Name = "textUsersResponse_Name"
        Me.textUsersResponse_Name.Size = New System.Drawing.Size(325, 26)
        Me.textUsersResponse_Name.TabIndex = 27
        '
        'LabelMainInstructions
        '
        Me.LabelMainInstructions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMainInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMainInstructions.Location = New System.Drawing.Point(34, 9)
        Me.LabelMainInstructions.Name = "LabelMainInstructions"
        Me.LabelMainInstructions.Size = New System.Drawing.Size(722, 148)
        Me.LabelMainInstructions.TabIndex = 26
        Me.LabelMainInstructions.Text = "You are creating a new ID Card Layout."
        '
        'LabelPrompt_Description
        '
        Me.LabelPrompt_Description.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelPrompt_Description.AutoSize = True
        Me.LabelPrompt_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.LabelPrompt_Description.Location = New System.Drawing.Point(33, 199)
        Me.LabelPrompt_Description.Name = "LabelPrompt_Description"
        Me.LabelPrompt_Description.Size = New System.Drawing.Size(110, 22)
        Me.LabelPrompt_Description.TabIndex = 32
        Me.LabelPrompt_Description.Text = "Description?"
        '
        'textUsersResponse_Descr
        '
        Me.textUsersResponse_Descr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textUsersResponse_Descr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textUsersResponse_Descr.Location = New System.Drawing.Point(37, 224)
        Me.textUsersResponse_Descr.Name = "textUsersResponse_Descr"
        Me.textUsersResponse_Descr.Size = New System.Drawing.Size(502, 26)
        Me.textUsersResponse_Descr.TabIndex = 31
        '
        'FormInputNameDescription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 280)
        Me.Controls.Add(Me.LabelPrompt_Description)
        Me.Controls.Add(Me.textUsersResponse_Descr)
        Me.Controls.Add(Me.LabelPrompt_Name)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.textUsersResponse_Name)
        Me.Controls.Add(Me.LabelMainInstructions)
        Me.Name = "FormInputNameDescription"
        Me.Text = "FormInputNameDescription"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelPrompt_Name As Windows.Forms.Label
    Friend WithEvents ButtonCancel As Windows.Forms.Button
    Friend WithEvents ButtonOK As Windows.Forms.Button
    Friend WithEvents textUsersResponse_Name As Windows.Forms.TextBox
    Friend WithEvents LabelMainInstructions As Windows.Forms.Label
    Friend WithEvents LabelPrompt_Description As Windows.Forms.Label
    Friend WithEvents textUsersResponse_Descr As Windows.Forms.TextBox
End Class
