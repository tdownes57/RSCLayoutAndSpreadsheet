<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.MoveableControl1 = New ciBadgeDesigner.MoveableControl()
        Me.MoveableControlVB1 = New MoveableControlTestVB.MoveableControlVB()
        Me.SuspendLayout()
        '
        'MoveableControl1
        '
        Me.MoveableControl1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MoveableControl1.Location = New System.Drawing.Point(70, 49)
        Me.MoveableControl1.Name = "MoveableControl1"
        Me.MoveableControl1.Size = New System.Drawing.Size(308, 109)
        Me.MoveableControl1.TabIndex = 0
        '
        'MoveableControlVB1
        '
        Me.MoveableControlVB1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MoveableControlVB1.Location = New System.Drawing.Point(428, 49)
        Me.MoveableControlVB1.Name = "MoveableControlVB1"
        Me.MoveableControlVB1.Size = New System.Drawing.Size(262, 108)
        Me.MoveableControlVB1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MoveableControlVB1)
        Me.Controls.Add(Me.MoveableControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MoveableControl1 As ciBadgeDesigner.MoveableControl
    Friend WithEvents MoveableControlVB1 As MoveableControlVB
End Class
