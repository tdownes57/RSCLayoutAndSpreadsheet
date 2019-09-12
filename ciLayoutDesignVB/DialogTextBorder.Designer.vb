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
        Me.ButtonDecrease = New System.Windows.Forms.Button()
        Me.ButtonIncrease = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.LabelBorderWidth = New System.Windows.Forms.Label()
        Me.chkBorderDisplayed = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'CtlGraphicFldLabel1
        '
        Me.CtlGraphicFldLabel1.Location = New System.Drawing.Point(59, 134)
        Me.CtlGraphicFldLabel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
        Me.LabelHeader1.Size = New System.Drawing.Size(320, 31)
        Me.LabelHeader1.TabIndex = 32
        Me.LabelHeader1.Text = "Border of Layout Element"
        '
        'ButtonDecrease
        '
        Me.ButtonDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDecrease.Location = New System.Drawing.Point(59, 83)
        Me.ButtonDecrease.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonDecrease.Name = "ButtonDecrease"
        Me.ButtonDecrease.Size = New System.Drawing.Size(29, 45)
        Me.ButtonDecrease.TabIndex = 31
        Me.ButtonDecrease.Text = "<"
        Me.ButtonDecrease.UseVisualStyleBackColor = True
        '
        'ButtonIncrease
        '
        Me.ButtonIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonIncrease.Location = New System.Drawing.Point(92, 83)
        Me.ButtonIncrease.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonIncrease.Name = "ButtonIncrease"
        Me.ButtonIncrease.Size = New System.Drawing.Size(29, 45)
        Me.ButtonIncrease.TabIndex = 30
        Me.ButtonIncrease.Text = ">"
        Me.ButtonIncrease.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(383, 173)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(56, 38)
        Me.ButtonCancel.TabIndex = 29
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(295, 173)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(81, 38)
        Me.ButtonOK.TabIndex = 28
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'LabelBorderWidth
        '
        Me.LabelBorderWidth.AutoSize = True
        Me.LabelBorderWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBorderWidth.Location = New System.Drawing.Point(135, 100)
        Me.LabelBorderWidth.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelBorderWidth.Name = "LabelBorderWidth"
        Me.LabelBorderWidth.Size = New System.Drawing.Size(143, 22)
        Me.LabelBorderWidth.TabIndex = 34
        Me.LabelBorderWidth.Tag = "Border width: {0}"
        Me.LabelBorderWidth.Text = "Border width: {0}"
        '
        'chkBorderDisplayed
        '
        Me.chkBorderDisplayed.AutoSize = True
        Me.chkBorderDisplayed.Checked = True
        Me.chkBorderDisplayed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBorderDisplayed.Location = New System.Drawing.Point(22, 61)
        Me.chkBorderDisplayed.Name = "chkBorderDisplayed"
        Me.chkBorderDisplayed.Size = New System.Drawing.Size(233, 17)
        Me.chkBorderDisplayed.TabIndex = 35
        Me.chkBorderDisplayed.Text = "Display a border around the layout element. "
        Me.chkBorderDisplayed.UseVisualStyleBackColor = True
        '
        'DialogTextBorder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGreen
        Me.ClientSize = New System.Drawing.Size(447, 222)
        Me.Controls.Add(Me.chkBorderDisplayed)
        Me.Controls.Add(Me.LabelBorderWidth)
        Me.Controls.Add(Me.CtlGraphicFldLabel1)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Controls.Add(Me.ButtonDecrease)
        Me.Controls.Add(Me.ButtonIncrease)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Name = "DialogTextBorder"
        Me.Text = "FormTextBorder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CtlGraphicFldLabel1 As CtlGraphicFldLabel
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents ButtonDecrease As Button
    Friend WithEvents ButtonIncrease As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents LabelBorderWidth As Label
    Friend WithEvents chkBorderDisplayed As CheckBox
End Class
