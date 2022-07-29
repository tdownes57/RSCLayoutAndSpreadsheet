<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dialog_BaseBorder
    Inherits Dialog_Base ''Added 7/28/2022 td 
    ''7/08/2022 td---Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.CtlLeftRightBorderWidth = New ciBadgeDesigner.CtlPropertyLeftRight()
        Me.chkBorderDisplayed = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'CtlLeftRightBorderWidth
        '
        Me.CtlLeftRightBorderWidth.BackColor = System.Drawing.Color.Transparent
        Me.CtlLeftRightBorderWidth.Location = New System.Drawing.Point(625, 202)
        Me.CtlLeftRightBorderWidth.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlLeftRightBorderWidth.MinimumValue = 0
        Me.CtlLeftRightBorderWidth.Name = "CtlLeftRightBorderWidth"
        Me.CtlLeftRightBorderWidth.PropertyName = "Border Width"
        Me.CtlLeftRightBorderWidth.PropertyValue = 0
        Me.CtlLeftRightBorderWidth.Size = New System.Drawing.Size(175, 113)
        Me.CtlLeftRightBorderWidth.TabIndex = 38
        '
        'chkBorderDisplayed
        '
        Me.chkBorderDisplayed.AutoSize = True
        Me.chkBorderDisplayed.Checked = True
        Me.chkBorderDisplayed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBorderDisplayed.Location = New System.Drawing.Point(625, 178)
        Me.chkBorderDisplayed.Name = "chkBorderDisplayed"
        Me.chkBorderDisplayed.Size = New System.Drawing.Size(233, 17)
        Me.chkBorderDisplayed.TabIndex = 37
        Me.chkBorderDisplayed.Text = "Display a border around the layout element. "
        Me.chkBorderDisplayed.UseVisualStyleBackColor = True
        '
        'Dialog_BaseBorder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 499)
        Me.Controls.Add(Me.CtlLeftRightBorderWidth)
        Me.Controls.Add(Me.chkBorderDisplayed)
        Me.Name = "Dialog_BaseBorder"
        Me.Text = "Dialog_BaseBorder"
        Me.Controls.SetChildIndex(Me.chkBorderDisplayed, 0)
        Me.Controls.SetChildIndex(Me.CtlLeftRightBorderWidth, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CtlLeftRightBorderWidth As CtlPropertyLeftRight
    Friend WithEvents chkBorderDisplayed As CheckBox
End Class
