<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogTextBorder
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
        Me.CtlGraphicFldLabel1 = New ciLayoutDesignVB.CtlGraphicFldLabel()
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.ButtonXDecrease = New System.Windows.Forms.Button()
        Me.ButtonXIncrease = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CtlGraphicFldLabel1
        '
        Me.CtlGraphicFldLabel1.Location = New System.Drawing.Point(17, 121)
        Me.CtlGraphicFldLabel1.Name = "CtlGraphicFldLabel1"
        Me.CtlGraphicFldLabel1.Size = New System.Drawing.Size(272, 19)
        Me.CtlGraphicFldLabel1.TabIndex = 33
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(16, 15)
        Me.LabelHeader1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(199, 31)
        Me.LabelHeader1.TabIndex = 32
        Me.LabelHeader1.Text = "Border of Text  "
        '
        'ButtonXDecrease
        '
        Me.ButtonXDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonXDecrease.Location = New System.Drawing.Point(17, 84)
        Me.ButtonXDecrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonXDecrease.Name = "ButtonXDecrease"
        Me.ButtonXDecrease.Size = New System.Drawing.Size(29, 31)
        Me.ButtonXDecrease.TabIndex = 31
        Me.ButtonXDecrease.Text = "<"
        Me.ButtonXDecrease.UseVisualStyleBackColor = True
        '
        'ButtonXIncrease
        '
        Me.ButtonXIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonXIncrease.Location = New System.Drawing.Point(50, 84)
        Me.ButtonXIncrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonXIncrease.Name = "ButtonXIncrease"
        Me.ButtonXIncrease.Size = New System.Drawing.Size(29, 31)
        Me.ButtonXIncrease.TabIndex = 30
        Me.ButtonXIncrease.Text = ">"
        Me.ButtonXIncrease.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(383, 204)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(56, 38)
        Me.ButtonCancel.TabIndex = 29
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(295, 204)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(81, 38)
        Me.ButtonOK.TabIndex = 28
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'DialogTextBorder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LimeGreen
        Me.ClientSize = New System.Drawing.Size(447, 253)
        Me.Controls.Add(Me.CtlGraphicFldLabel1)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Controls.Add(Me.ButtonXDecrease)
        Me.Controls.Add(Me.ButtonXIncrease)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Name = "DialogTextBorder"
        Me.Text = "FormTextBorder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CtlGraphicFldLabel1 As CtlGraphicFldLabel
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents ButtonXDecrease As Button
    Friend WithEvents ButtonXIncrease As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
End Class
