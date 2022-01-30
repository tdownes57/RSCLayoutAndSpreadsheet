Imports ciBadgeDesigner

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.chkBorderDisplayed = New System.Windows.Forms.CheckBox()
        Me.CtlGraphicFldLabel1 = New CtlGraphicFldLabelV3("DialogTextBorder")
        Me.CtlBorderWidth = New ciLayoutDesignVB.CtlPropertyLeftRight()
        Me.SuspendLayout()
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
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(383, 273)
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
        Me.ButtonOK.Location = New System.Drawing.Point(295, 273)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(81, 38)
        Me.ButtonOK.TabIndex = 28
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
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
        'CtlGraphicFldLabel1
        '
        Me.CtlGraphicFldLabel1.Location = New System.Drawing.Point(22, 97)
        Me.CtlGraphicFldLabel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CtlGraphicFldLabel1.Name = "CtlGraphicFldLabel1"
        Me.CtlGraphicFldLabel1.Size = New System.Drawing.Size(272, 19)
        Me.CtlGraphicFldLabel1.TabIndex = 33
        '
        'CtlBorderWidth
        '
        Me.CtlBorderWidth.BackColor = System.Drawing.Color.LightGreen
        Me.CtlBorderWidth.Location = New System.Drawing.Point(22, 197)
        Me.CtlBorderWidth.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CtlBorderWidth.Name = "CtlBorderWidth"
        Me.CtlBorderWidth.PropertyName = "Border Width"
        Me.CtlBorderWidth.PropertyValue = 0
        Me.CtlBorderWidth.Size = New System.Drawing.Size(175, 113)
        Me.CtlBorderWidth.TabIndex = 36
        '
        'DialogTextBorder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGreen
        Me.ClientSize = New System.Drawing.Size(447, 322)
        Me.Controls.Add(Me.CtlBorderWidth)
        Me.Controls.Add(Me.chkBorderDisplayed)
        Me.Controls.Add(Me.CtlGraphicFldLabel1)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Name = "DialogTextBorder"
        Me.Text = "FormTextBorder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CtlGraphicFldLabel1 As CtlGraphicFldLabelV3
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents chkBorderDisplayed As CheckBox
    Friend WithEvents CtlBorderWidth As CtlPropertyLeftRight
End Class
