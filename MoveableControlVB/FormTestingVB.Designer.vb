<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTestingVB
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
        Me.MoveableControlObselete1 = New ciBadgeDesigner.MoveableControl()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MoveableControlObselete2 = New ciBadgeDesigner.MoveableControl()
        Me.MoveableControlVB4 = New MoveableControlTestVB.MoveableControlVB()
        Me.MoveableControlVB3 = New MoveableControlTestVB.MoveableControlVB()
        Me.MoveableControlVB2 = New MoveableControlTestVB.MoveableControlVB()
        Me.MoveableControlVB1 = New MoveableControlTestVB.MoveableControlVB()
        Me.SuspendLayout()
        '
        'MoveableControlObselete1
        '
        Me.MoveableControlObselete1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MoveableControlObselete1.Location = New System.Drawing.Point(975, 318)
        Me.MoveableControlObselete1.Name = "MoveableControlObselete1"
        Me.MoveableControlObselete1.Size = New System.Drawing.Size(308, 109)
        Me.MoveableControlObselete1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1004, 255)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(367, 32)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Show Pop-Up Menu for last Control Touched"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MoveableControlObselete2
        '
        Me.MoveableControlObselete2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MoveableControlObselete2.Location = New System.Drawing.Point(631, 318)
        Me.MoveableControlObselete2.Name = "MoveableControlObselete2"
        Me.MoveableControlObselete2.Size = New System.Drawing.Size(308, 109)
        Me.MoveableControlObselete2.TabIndex = 4
        '
        'MoveableControlVB4
        '
        Me.MoveableControlVB4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MoveableControlVB4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MoveableControlVB4.Location = New System.Drawing.Point(885, 12)
        Me.MoveableControlVB4.Name = "MoveableControlVB4"
        Me.MoveableControlVB4.Size = New System.Drawing.Size(262, 108)
        Me.MoveableControlVB4.TabIndex = 6
        '
        'MoveableControlVB3
        '
        Me.MoveableControlVB3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MoveableControlVB3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MoveableControlVB3.Location = New System.Drawing.Point(607, 12)
        Me.MoveableControlVB3.Name = "MoveableControlVB3"
        Me.MoveableControlVB3.Size = New System.Drawing.Size(262, 108)
        Me.MoveableControlVB3.TabIndex = 5
        '
        'MoveableControlVB2
        '
        Me.MoveableControlVB2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MoveableControlVB2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MoveableControlVB2.Location = New System.Drawing.Point(29, 12)
        Me.MoveableControlVB2.Name = "MoveableControlVB2"
        Me.MoveableControlVB2.Size = New System.Drawing.Size(262, 108)
        Me.MoveableControlVB2.TabIndex = 3
        '
        'MoveableControlVB1
        '
        Me.MoveableControlVB1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MoveableControlVB1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MoveableControlVB1.Location = New System.Drawing.Point(321, 12)
        Me.MoveableControlVB1.Name = "MoveableControlVB1"
        Me.MoveableControlVB1.Size = New System.Drawing.Size(262, 108)
        Me.MoveableControlVB1.TabIndex = 1
        '
        'FormTestingVB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1401, 562)
        Me.Controls.Add(Me.MoveableControlVB4)
        Me.Controls.Add(Me.MoveableControlVB3)
        Me.Controls.Add(Me.MoveableControlObselete2)
        Me.Controls.Add(Me.MoveableControlVB2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MoveableControlVB1)
        Me.Controls.Add(Me.MoveableControlObselete1)
        Me.Name = "FormTestingVB"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MoveableControlObselete1 As ciBadgeDesigner.MoveableControl
    Friend WithEvents MoveableControlVB1 As MoveableControlVB
    Friend WithEvents Button1 As Button
    Friend WithEvents MoveableControlVB2 As MoveableControlVB
    Friend WithEvents MoveableControlObselete2 As ciBadgeDesigner.MoveableControl
    Friend WithEvents MoveableControlVB3 As MoveableControlVB
    Friend WithEvents MoveableControlVB4 As MoveableControlVB
End Class
