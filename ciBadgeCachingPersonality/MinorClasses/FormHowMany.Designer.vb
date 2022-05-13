<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHowMany
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
        Me.LabelMainPrompt = New System.Windows.Forms.Label()
        Me.textHowMany = New System.Windows.Forms.TextBox()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.LabelHowManyCaption = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.lblRedMessageNonnumeric = New System.Windows.Forms.Label()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelMainPrompt
        '
        Me.LabelMainPrompt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMainPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMainPrompt.Location = New System.Drawing.Point(12, 9)
        Me.LabelMainPrompt.Name = "LabelMainPrompt"
        Me.LabelMainPrompt.Size = New System.Drawing.Size(669, 29)
        Me.LabelMainPrompt.TabIndex = 0
        Me.LabelMainPrompt.Text = "How many angels can dance on the head of a pin?"
        '
        'textHowMany
        '
        Me.textHowMany.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.textHowMany.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textHowMany.Location = New System.Drawing.Point(112, 52)
        Me.textHowMany.Name = "textHowMany"
        Me.textHowMany.Size = New System.Drawing.Size(178, 32)
        Me.textHowMany.TabIndex = 1
        Me.textHowMany.Visible = False
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.BackColor = System.Drawing.Color.White
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(579, 52)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(80, 39)
        Me.ButtonCancel.TabIndex = 17
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.BackColor = System.Drawing.Color.White
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(436, 52)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(139, 39)
        Me.ButtonOK.TabIndex = 16
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'LabelHowManyCaption
        '
        Me.LabelHowManyCaption.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelHowManyCaption.AutoSize = True
        Me.LabelHowManyCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHowManyCaption.Location = New System.Drawing.Point(14, 58)
        Me.LabelHowManyCaption.Name = "LabelHowManyCaption"
        Me.LabelHowManyCaption.Size = New System.Drawing.Size(92, 20)
        Me.LabelHowManyCaption.TabIndex = 18
        Me.LabelHowManyCaption.Text = "How many?"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(112, 56)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(112, 26)
        Me.NumericUpDown1.TabIndex = 19
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblRedMessageNonnumeric
        '
        Me.lblRedMessageNonnumeric.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRedMessageNonnumeric.AutoSize = True
        Me.lblRedMessageNonnumeric.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRedMessageNonnumeric.ForeColor = System.Drawing.Color.Red
        Me.lblRedMessageNonnumeric.Location = New System.Drawing.Point(296, 59)
        Me.lblRedMessageNonnumeric.Name = "lblRedMessageNonnumeric"
        Me.lblRedMessageNonnumeric.Size = New System.Drawing.Size(140, 20)
        Me.lblRedMessageNonnumeric.TabIndex = 20
        Me.lblRedMessageNonnumeric.Tag = "Non-numeric value"
        Me.lblRedMessageNonnumeric.Text = "Non-numeric value"
        Me.lblRedMessageNonnumeric.Visible = False
        '
        'FormHowMany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 102)
        Me.Controls.Add(Me.lblRedMessageNonnumeric)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.LabelHowManyCaption)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.textHowMany)
        Me.Controls.Add(Me.LabelMainPrompt)
        Me.Name = "FormHowMany"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "RSC ID Card"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelMainPrompt As Windows.Forms.Label
    Friend WithEvents textHowMany As Windows.Forms.TextBox
    Friend WithEvents ButtonCancel As Windows.Forms.Button
    Friend WithEvents ButtonOK As Windows.Forms.Button
    Friend WithEvents LabelHowManyCaption As Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As Windows.Forms.NumericUpDown
    Friend WithEvents lblRedMessageNonnumeric As Windows.Forms.Label
End Class
