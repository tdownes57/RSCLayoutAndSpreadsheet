<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRSCColorConfirmTiny
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRSCColorConfirmTiny))
        Me.RscColorDisplayLabel1 = New __RSCWindowsControlLibrary.RSCColorDisplayLabel()
        Me.textboxRSCDescription = New System.Windows.Forms.TextBox()
        Me.LabelDescription = New System.Windows.Forms.Label()
        Me.textboxRSCColorName = New System.Windows.Forms.TextBox()
        Me.LabelNameOfColor = New System.Windows.Forms.Label()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.LabelHeadingConfirmColor = New System.Windows.Forms.Label()
        Me.textboxMSColorName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.checkDontShowAgain = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'RscColorDisplayLabel1
        '
        Me.RscColorDisplayLabel1.Location = New System.Drawing.Point(20, 67)
        Me.RscColorDisplayLabel1.MSNetColorName = Nothing
        Me.RscColorDisplayLabel1.Name = "RscColorDisplayLabel1"
        Me.RscColorDisplayLabel1.RSCDisplayColor = CType(resources.GetObject("RscColorDisplayLabel1.RSCDisplayColor"), ciBadgeInterfaces.RSCColor)
        Me.RscColorDisplayLabel1.Size = New System.Drawing.Size(200, 25)
        Me.RscColorDisplayLabel1.TabIndex = 0
        '
        'textboxRSCDescription
        '
        Me.textboxRSCDescription.Location = New System.Drawing.Point(168, 162)
        Me.textboxRSCDescription.Multiline = True
        Me.textboxRSCDescription.Name = "textboxRSCDescription"
        Me.textboxRSCDescription.Size = New System.Drawing.Size(241, 39)
        Me.textboxRSCDescription.TabIndex = 25
        '
        'LabelDescription
        '
        Me.LabelDescription.AutoSize = True
        Me.LabelDescription.Location = New System.Drawing.Point(56, 166)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(106, 13)
        Me.LabelDescription.TabIndex = 24
        Me.LabelDescription.Text = "Description (optional)"
        '
        'textboxRSCColorName
        '
        Me.textboxRSCColorName.Location = New System.Drawing.Point(168, 136)
        Me.textboxRSCColorName.Name = "textboxRSCColorName"
        Me.textboxRSCColorName.Size = New System.Drawing.Size(241, 20)
        Me.textboxRSCColorName.TabIndex = 23
        '
        'LabelNameOfColor
        '
        Me.LabelNameOfColor.AutoSize = True
        Me.LabelNameOfColor.Location = New System.Drawing.Point(26, 139)
        Me.LabelNameOfColor.Name = "LabelNameOfColor"
        Me.LabelNameOfColor.Size = New System.Drawing.Size(142, 13)
        Me.LabelNameOfColor.TabIndex = 22
        Me.LabelNameOfColor.Text = "Your name of color (optional)"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.Color.PaleGreen
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(296, 224)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(101, 34)
        Me.ButtonCancel.TabIndex = 21
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'ButtonOK
        '
        Me.ButtonOK.BackColor = System.Drawing.Color.PaleGreen
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(192, 224)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(101, 34)
        Me.ButtonOK.TabIndex = 20
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'LabelHeadingConfirmColor
        '
        Me.LabelHeadingConfirmColor.AutoSize = True
        Me.LabelHeadingConfirmColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeadingConfirmColor.Location = New System.Drawing.Point(12, 9)
        Me.LabelHeadingConfirmColor.Name = "LabelHeadingConfirmColor"
        Me.LabelHeadingConfirmColor.Size = New System.Drawing.Size(303, 31)
        Me.LabelHeadingConfirmColor.TabIndex = 26
        Me.LabelHeadingConfirmColor.Text = "Confirm (&& Name) Color"
        '
        'textboxMSColorName
        '
        Me.textboxMSColorName.Location = New System.Drawing.Point(140, 110)
        Me.textboxMSColorName.Name = "textboxMSColorName"
        Me.textboxMSColorName.ReadOnly = True
        Me.textboxMSColorName.Size = New System.Drawing.Size(188, 20)
        Me.textboxMSColorName.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Microsoft name of color"
        '
        'checkDontShowAgain
        '
        Me.checkDontShowAgain.AutoSize = True
        Me.checkDontShowAgain.Location = New System.Drawing.Point(20, 280)
        Me.checkDontShowAgain.Name = "checkDontShowAgain"
        Me.checkDontShowAgain.Size = New System.Drawing.Size(181, 17)
        Me.checkDontShowAgain.TabIndex = 29
        Me.checkDontShowAgain.Text = "Don't show this dialog box again."
        Me.checkDontShowAgain.UseVisualStyleBackColor = True
        '
        'FormRSCColorConfirmTiny
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 309)
        Me.Controls.Add(Me.checkDontShowAgain)
        Me.Controls.Add(Me.textboxMSColorName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelHeadingConfirmColor)
        Me.Controls.Add(Me.textboxRSCDescription)
        Me.Controls.Add(Me.LabelDescription)
        Me.Controls.Add(Me.textboxRSCColorName)
        Me.Controls.Add(Me.LabelNameOfColor)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.RscColorDisplayLabel1)
        Me.Name = "FormRSCColorConfirmTiny"
        Me.Text = "FormRSCColorConfirmTiny"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RscColorDisplayLabel1 As RSCColorDisplayLabel
    Friend WithEvents textboxRSCDescription As TextBox
    Friend WithEvents LabelDescription As Label
    Friend WithEvents textboxRSCColorName As TextBox
    Friend WithEvents LabelNameOfColor As Label
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents LabelHeadingConfirmColor As Label
    Friend WithEvents textboxMSColorName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents checkDontShowAgain As CheckBox
End Class
