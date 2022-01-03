<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTestQRCode
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
        Me.CtlQRCode1 = New ciBadgeDesigner.CtlGraphicQRCode()
        Me.RscMoveableControlVB1 = New __RSCWindowsControlLibrary.RSCMoveableControlVB()
        Me.SimpleChildOfRSCControl1 = New MoveableControlTestVB.SimpleChildOfRSCControl()
        Me.ProportionalRSCControl1 = New MoveableControlTestVB.ProportionalRSCControl()
        Me.SuspendLayout()
        '
        'CtlQRCode1
        '
        Me.CtlQRCode1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CtlQRCode1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CtlQRCode1.Location = New System.Drawing.Point(12, 24)
        Me.CtlQRCode1.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlQRCode1.Name = "CtlQRCode1"
        Me.CtlQRCode1.Size = New System.Drawing.Size(301, 105)
        Me.CtlQRCode1.TabIndex = 0
        '
        'RscMoveableControlVB1
        '
        Me.RscMoveableControlVB1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RscMoveableControlVB1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RscMoveableControlVB1.Location = New System.Drawing.Point(383, 58)
        Me.RscMoveableControlVB1.Name = "RscMoveableControlVB1"
        Me.RscMoveableControlVB1.Size = New System.Drawing.Size(353, 103)
        Me.RscMoveableControlVB1.TabIndex = 1
        '
        'SimpleChildOfRSCControl1
        '
        Me.SimpleChildOfRSCControl1.BackColor = System.Drawing.Color.White
        Me.SimpleChildOfRSCControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SimpleChildOfRSCControl1.Location = New System.Drawing.Point(44, 203)
        Me.SimpleChildOfRSCControl1.Name = "SimpleChildOfRSCControl1"
        Me.SimpleChildOfRSCControl1.Size = New System.Drawing.Size(499, 61)
        Me.SimpleChildOfRSCControl1.TabIndex = 2
        '
        'ProportionalRSCControl1
        '
        Me.ProportionalRSCControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ProportionalRSCControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProportionalRSCControl1.Location = New System.Drawing.Point(64, 277)
        Me.ProportionalRSCControl1.Name = "ProportionalRSCControl1"
        Me.ProportionalRSCControl1.Size = New System.Drawing.Size(169, 161)
        Me.ProportionalRSCControl1.TabIndex = 3
        '
        'FormTestQRCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ProportionalRSCControl1)
        Me.Controls.Add(Me.SimpleChildOfRSCControl1)
        Me.Controls.Add(Me.RscMoveableControlVB1)
        Me.Controls.Add(Me.CtlQRCode1)
        Me.Name = "FormTestQRCode"
        Me.Text = "FormTestQRCode"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CtlQRCode1 As ciBadgeDesigner.CtlGraphicQRCode
    Friend WithEvents RscMoveableControlVB1 As __RSCWindowsControlLibrary.RSCMoveableControlVB
    Friend WithEvents SimpleChildOfRSCControl1 As SimpleChildOfRSCControl
    Friend WithEvents ProportionalRSCControl1 As ProportionalRSCControl
End Class
