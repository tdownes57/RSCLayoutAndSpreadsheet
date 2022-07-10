<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCBrowseExistingColors
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonAddNewColor = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonDeleteColor = New System.Windows.Forms.Button()
        Me.LabelSelectForecolor = New System.Windows.Forms.Label()
        Me.LabelSelectBackcolor = New System.Windows.Forms.Label()
        Me.RscColorDisplay3 = New __RSCWindowsControlLibrary.RSCColorDisplay()
        Me.RscColorDisplay1 = New __RSCWindowsControlLibrary.RSCColorDisplay()
        Me.RscColorDisplay2 = New __RSCWindowsControlLibrary.RSCColorDisplay()
        Me.LabelNameOfColor = New System.Windows.Forms.Label()
        Me.textboxColorName = New System.Windows.Forms.TextBox()
        Me.textboxDescription = New System.Windows.Forms.TextBox()
        Me.LabelDescription = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.RscColorDisplay1)
        Me.FlowLayoutPanel1.Controls.Add(Me.RscColorDisplay2)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(33, 93)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(419, 287)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(498, 141)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Selected Color:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Existing Colors:"
        '
        'ButtonAddNewColor
        '
        Me.ButtonAddNewColor.Location = New System.Drawing.Point(458, 93)
        Me.ButtonAddNewColor.Name = "ButtonAddNewColor"
        Me.ButtonAddNewColor.Size = New System.Drawing.Size(125, 30)
        Me.ButtonAddNewColor.TabIndex = 6
        Me.ButtonAddNewColor.Text = "Add New Color"
        Me.ButtonAddNewColor.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.Location = New System.Drawing.Point(776, 350)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(125, 30)
        Me.ButtonCancel.TabIndex = 7
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(645, 350)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(125, 30)
        Me.ButtonOK.TabIndex = 8
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonDeleteColor
        '
        Me.ButtonDeleteColor.Location = New System.Drawing.Point(751, 141)
        Me.ButtonDeleteColor.Name = "ButtonDeleteColor"
        Me.ButtonDeleteColor.Size = New System.Drawing.Size(94, 30)
        Me.ButtonDeleteColor.TabIndex = 9
        Me.ButtonDeleteColor.Text = "Delete"
        Me.ButtonDeleteColor.UseVisualStyleBackColor = True
        '
        'LabelSelectForecolor
        '
        Me.LabelSelectForecolor.AutoSize = True
        Me.LabelSelectForecolor.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSelectForecolor.Location = New System.Drawing.Point(12, 9)
        Me.LabelSelectForecolor.Name = "LabelSelectForecolor"
        Me.LabelSelectForecolor.Size = New System.Drawing.Size(464, 29)
        Me.LabelSelectForecolor.TabIndex = 10
        Me.LabelSelectForecolor.Text = "Select Font Color (or ""Foreground Color"") "
        Me.LabelSelectForecolor.Visible = False
        '
        'LabelSelectBackcolor
        '
        Me.LabelSelectBackcolor.AutoSize = True
        Me.LabelSelectBackcolor.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSelectBackcolor.Location = New System.Drawing.Point(12, 26)
        Me.LabelSelectBackcolor.Name = "LabelSelectBackcolor"
        Me.LabelSelectBackcolor.Size = New System.Drawing.Size(281, 29)
        Me.LabelSelectBackcolor.TabIndex = 11
        Me.LabelSelectBackcolor.Text = "Select Background Color"
        Me.LabelSelectBackcolor.Visible = False
        '
        'RscColorDisplay3
        '
        Me.RscColorDisplay3.HideBackgroundLabels = True
        Me.RscColorDisplay3.HideForegroundLabels = True
        Me.RscColorDisplay3.Location = New System.Drawing.Point(606, 141)
        Me.RscColorDisplay3.Name = "RscColorDisplay3"
        Me.RscColorDisplay3.Size = New System.Drawing.Size(139, 122)
        Me.RscColorDisplay3.TabIndex = 3
        '
        'RscColorDisplay1
        '
        Me.RscColorDisplay1.HideBackgroundLabels = True
        Me.RscColorDisplay1.HideForegroundLabels = True
        Me.RscColorDisplay1.Location = New System.Drawing.Point(3, 3)
        Me.RscColorDisplay1.Name = "RscColorDisplay1"
        Me.RscColorDisplay1.Size = New System.Drawing.Size(139, 122)
        Me.RscColorDisplay1.TabIndex = 0
        '
        'RscColorDisplay2
        '
        Me.RscColorDisplay2.HideBackgroundLabels = True
        Me.RscColorDisplay2.HideForegroundLabels = True
        Me.RscColorDisplay2.Location = New System.Drawing.Point(148, 3)
        Me.RscColorDisplay2.Name = "RscColorDisplay2"
        Me.RscColorDisplay2.Size = New System.Drawing.Size(139, 122)
        Me.RscColorDisplay2.TabIndex = 1
        '
        'LabelNameOfColor
        '
        Me.LabelNameOfColor.AutoSize = True
        Me.LabelNameOfColor.Location = New System.Drawing.Point(497, 283)
        Me.LabelNameOfColor.Name = "LabelNameOfColor"
        Me.LabelNameOfColor.Size = New System.Drawing.Size(73, 13)
        Me.LabelNameOfColor.TabIndex = 12
        Me.LabelNameOfColor.Text = "Name of color"
        '
        'textboxColorName
        '
        Me.textboxColorName.Location = New System.Drawing.Point(576, 280)
        Me.textboxColorName.Name = "textboxColorName"
        Me.textboxColorName.Size = New System.Drawing.Size(188, 20)
        Me.textboxColorName.TabIndex = 13
        '
        'textboxDescription
        '
        Me.textboxDescription.Location = New System.Drawing.Point(576, 306)
        Me.textboxDescription.Multiline = True
        Me.textboxDescription.Name = "textboxDescription"
        Me.textboxDescription.Size = New System.Drawing.Size(269, 29)
        Me.textboxDescription.TabIndex = 15
        '
        'LabelDescription
        '
        Me.LabelDescription.AutoSize = True
        Me.LabelDescription.Location = New System.Drawing.Point(510, 309)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(60, 13)
        Me.LabelDescription.TabIndex = 14
        Me.LabelDescription.Text = "Description"
        '
        'RSCBrowseExistingColors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 397)
        Me.Controls.Add(Me.textboxDescription)
        Me.Controls.Add(Me.LabelDescription)
        Me.Controls.Add(Me.textboxColorName)
        Me.Controls.Add(Me.LabelNameOfColor)
        Me.Controls.Add(Me.LabelSelectBackcolor)
        Me.Controls.Add(Me.LabelSelectForecolor)
        Me.Controls.Add(Me.ButtonDeleteColor)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonAddNewColor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RscColorDisplay3)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "RSCBrowseExistingColors"
        Me.Text = "RSCBrowseExistingColors"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents RscColorDisplay1 As RSCColorDisplay
    Friend WithEvents RscColorDisplay2 As RSCColorDisplay
    Friend WithEvents RscColorDisplay3 As RSCColorDisplay
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ButtonAddNewColor As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonDeleteColor As Button
    Friend WithEvents LabelSelectForecolor As Label
    Friend WithEvents LabelSelectBackcolor As Label
    Friend WithEvents LabelNameOfColor As Label
    Friend WithEvents textboxColorName As TextBox
    Friend WithEvents textboxDescription As TextBox
    Friend WithEvents LabelDescription As Label
End Class
