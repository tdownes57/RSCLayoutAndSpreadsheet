<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTestChildControls
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
        Me.ProportionalRSCControl1 = New MoveableControlTestVB.ProportionalRSCControl()
        Me.SimpleChildOfRSCControl1 = New MoveableControlTestVB.SimpleChildOfRSCControl()
        Me.SuspendLayout()
        '
        'ProportionalRSCControl1
        '
        Me.ProportionalRSCControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ProportionalRSCControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProportionalRSCControl1.Location = New System.Drawing.Point(171, 182)
        Me.ProportionalRSCControl1.Name = "ProportionalRSCControl1"
        Me.ProportionalRSCControl1.Size = New System.Drawing.Size(169, 161)
        Me.ProportionalRSCControl1.TabIndex = 5
        '
        'SimpleChildOfRSCControl1
        '
        Me.SimpleChildOfRSCControl1.BackColor = System.Drawing.Color.White
        Me.SimpleChildOfRSCControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SimpleChildOfRSCControl1.Location = New System.Drawing.Point(151, 108)
        Me.SimpleChildOfRSCControl1.Name = "SimpleChildOfRSCControl1"
        Me.SimpleChildOfRSCControl1.Size = New System.Drawing.Size(499, 61)
        Me.SimpleChildOfRSCControl1.TabIndex = 4
        '
        'FormTestChildControls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ProportionalRSCControl1)
        Me.Controls.Add(Me.SimpleChildOfRSCControl1)
        Me.Name = "FormTestChildControls"
        Me.Text = "FormTestChildControls"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ProportionalRSCControl1 As ProportionalRSCControl
    Friend WithEvents SimpleChildOfRSCControl1 As SimpleChildOfRSCControl
End Class
