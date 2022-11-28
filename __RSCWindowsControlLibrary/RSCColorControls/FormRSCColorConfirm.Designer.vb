<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRSCColorConfirm
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
        Me.rscColorPicker1 = New __RSCWindowsControlLibrary.RSCColorPicker()
        Me.LabelHeadingConfirmColor = New System.Windows.Forms.Label()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.textboxDescription = New System.Windows.Forms.TextBox()
        Me.LabelDescription = New System.Windows.Forms.Label()
        Me.textboxColorName = New System.Windows.Forms.TextBox()
        Me.LabelNameOfColor = New System.Windows.Forms.Label()
        Me.LabelMSNetNameCaption = New System.Windows.Forms.Label()
        Me.LabelMicrosoftName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'rscColorPicker1
        '
        Me.rscColorPicker1.BackColor = System.Drawing.Color.White
        Me.rscColorPicker1.Location = New System.Drawing.Point(20, 67)
        Me.rscColorPicker1.Name = "rscColorPicker1"
        Me.rscColorPicker1.RSCColor_Input = Nothing
        Me.rscColorPicker1.Size = New System.Drawing.Size(351, 219)
        Me.rscColorPicker1.TabIndex = 0
        '
        'LabelHeadingConfirmColor
        '
        Me.LabelHeadingConfirmColor.AutoSize = True
        Me.LabelHeadingConfirmColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeadingConfirmColor.Location = New System.Drawing.Point(12, 9)
        Me.LabelHeadingConfirmColor.Name = "LabelHeadingConfirmColor"
        Me.LabelHeadingConfirmColor.Size = New System.Drawing.Size(255, 44)
        Me.LabelHeadingConfirmColor.TabIndex = 1
        Me.LabelHeadingConfirmColor.Text = "Confirm Color"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.Color.PaleGreen
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(270, 366)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(101, 34)
        Me.ButtonCancel.TabIndex = 5
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'ButtonOK
        '
        Me.ButtonOK.BackColor = System.Drawing.Color.PaleGreen
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(166, 366)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(101, 34)
        Me.ButtonOK.TabIndex = 4
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'textboxDescription
        '
        Me.textboxDescription.Location = New System.Drawing.Point(101, 341)
        Me.textboxDescription.Name = "textboxDescription"
        Me.textboxDescription.Size = New System.Drawing.Size(269, 20)
        Me.textboxDescription.TabIndex = 19
        '
        'LabelDescription
        '
        Me.LabelDescription.AutoSize = True
        Me.LabelDescription.Location = New System.Drawing.Point(35, 344)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(60, 13)
        Me.LabelDescription.TabIndex = 18
        Me.LabelDescription.Text = "Description"
        '
        'textboxColorName
        '
        Me.textboxColorName.Location = New System.Drawing.Point(102, 292)
        Me.textboxColorName.Name = "textboxColorName"
        Me.textboxColorName.Size = New System.Drawing.Size(188, 20)
        Me.textboxColorName.TabIndex = 17
        '
        'LabelNameOfColor
        '
        Me.LabelNameOfColor.AutoSize = True
        Me.LabelNameOfColor.Location = New System.Drawing.Point(23, 295)
        Me.LabelNameOfColor.Name = "LabelNameOfColor"
        Me.LabelNameOfColor.Size = New System.Drawing.Size(73, 13)
        Me.LabelNameOfColor.TabIndex = 16
        Me.LabelNameOfColor.Text = "Name of color"
        '
        'LabelMSNetNameCaption
        '
        Me.LabelMSNetNameCaption.AutoSize = True
        Me.LabelMSNetNameCaption.Location = New System.Drawing.Point(98, 315)
        Me.LabelMSNetNameCaption.Name = "LabelMSNetNameCaption"
        Me.LabelMSNetNameCaption.Size = New System.Drawing.Size(127, 13)
        Me.LabelMSNetNameCaption.TabIndex = 20
        Me.LabelMSNetNameCaption.Text = "Microsoft's name of color:"
        Me.LabelMSNetNameCaption.Visible = False
        '
        'LabelMicrosoftName
        '
        Me.LabelMicrosoftName.AutoSize = True
        Me.LabelMicrosoftName.Location = New System.Drawing.Point(231, 315)
        Me.LabelMicrosoftName.Name = "LabelMicrosoftName"
        Me.LabelMicrosoftName.Size = New System.Drawing.Size(55, 13)
        Me.LabelMicrosoftName.TabIndex = 21
        Me.LabelMicrosoftName.Text = "[MS color]"
        Me.LabelMicrosoftName.Visible = False
        '
        'FormRSCColorConfirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 411)
        Me.Controls.Add(Me.LabelMicrosoftName)
        Me.Controls.Add(Me.LabelMSNetNameCaption)
        Me.Controls.Add(Me.textboxDescription)
        Me.Controls.Add(Me.LabelDescription)
        Me.Controls.Add(Me.textboxColorName)
        Me.Controls.Add(Me.LabelNameOfColor)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.LabelHeadingConfirmColor)
        Me.Controls.Add(Me.rscColorPicker1)
        Me.Name = "FormRSCColorConfirm"
        Me.Text = "FormRSCColorConfirm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rscColorPicker1 As RSCColorPicker
    Friend WithEvents LabelHeadingConfirmColor As Label
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents textboxDescription As TextBox
    Friend WithEvents LabelDescription As Label
    Friend WithEvents textboxColorName As TextBox
    Friend WithEvents LabelNameOfColor As Label
    Friend WithEvents LabelMSNetNameCaption As Label
    Friend WithEvents LabelMicrosoftName As Label
End Class
