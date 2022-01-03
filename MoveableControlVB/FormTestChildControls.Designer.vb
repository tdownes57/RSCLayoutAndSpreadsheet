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
        Me.SimpleChildOfRSCControl1 = New MoveableControlTestVB.SimpleChildOfRSCControl1()
        Me.SimpleChildOfRSCControl21 = New MoveableControlTestVB.SimpleChildOfRSCControl2()
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
        'SimpleChildOfRSCControl21
        '
        Me.SimpleChildOfRSCControl21.BackColor = System.Drawing.Color.Thistle
        Me.SimpleChildOfRSCControl21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SimpleChildOfRSCControl21.Location = New System.Drawing.Point(358, 193)
        Me.SimpleChildOfRSCControl21.Name = "SimpleChildOfRSCControl21"
        Me.SimpleChildOfRSCControl21.Size = New System.Drawing.Size(309, 150)
        Me.SimpleChildOfRSCControl21.TabIndex = 6
        '
        'FormTestChildControls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SimpleChildOfRSCControl21)
        Me.Controls.Add(Me.ProportionalRSCControl1)
        Me.Controls.Add(Me.SimpleChildOfRSCControl1)
        Me.Name = "FormTestChildControls"
        Me.Text = "FormTestChildControls"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ProportionalRSCControl1 As ProportionalRSCControl
    Friend WithEvents SimpleChildOfRSCControl1 As SimpleChildOfRSCControl1
    Friend WithEvents SimpleChildOfRSCControl21 As SimpleChildOfRSCControl2
End Class
