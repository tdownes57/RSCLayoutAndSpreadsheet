<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCRowHeaders_Test
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.RscRowHeader1 = New ciBadgeDesigner.RSCRowHeader()
        Me.RscRowHeader2 = New ciBadgeDesigner.RSCRowHeader()
        Me.RscRowHeader3 = New ciBadgeDesigner.RSCRowHeader()
        Me.RscRowHeader4 = New ciBadgeDesigner.RSCRowHeader()
        Me.SuspendLayout()
        '
        'RscRowHeader1
        '
        Me.RscRowHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RscRowHeader1.Location = New System.Drawing.Point(0, 0)
        Me.RscRowHeader1.Margin = New System.Windows.Forms.Padding(0)
        Me.RscRowHeader1.Name = "RscRowHeader1"
        Me.RscRowHeader1.Size = New System.Drawing.Size(147, 24)
        Me.RscRowHeader1.TabIndex = 0
        '
        'RscRowHeader2
        '
        Me.RscRowHeader2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RscRowHeader2.Location = New System.Drawing.Point(0, 24)
        Me.RscRowHeader2.Margin = New System.Windows.Forms.Padding(0)
        Me.RscRowHeader2.Name = "RscRowHeader2"
        Me.RscRowHeader2.Size = New System.Drawing.Size(147, 24)
        Me.RscRowHeader2.TabIndex = 1
        '
        'RscRowHeader3
        '
        Me.RscRowHeader3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RscRowHeader3.Location = New System.Drawing.Point(0, 48)
        Me.RscRowHeader3.Margin = New System.Windows.Forms.Padding(0)
        Me.RscRowHeader3.Name = "RscRowHeader3"
        Me.RscRowHeader3.Size = New System.Drawing.Size(147, 24)
        Me.RscRowHeader3.TabIndex = 2
        '
        'RscRowHeader4
        '
        Me.RscRowHeader4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RscRowHeader4.Location = New System.Drawing.Point(0, 72)
        Me.RscRowHeader4.Margin = New System.Windows.Forms.Padding(0)
        Me.RscRowHeader4.Name = "RscRowHeader4"
        Me.RscRowHeader4.Size = New System.Drawing.Size(147, 24)
        Me.RscRowHeader4.TabIndex = 3
        '
        'RSCRowHeaders_Test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RscRowHeader4)
        Me.Controls.Add(Me.RscRowHeader3)
        Me.Controls.Add(Me.RscRowHeader2)
        Me.Controls.Add(Me.RscRowHeader1)
        Me.Name = "RSCRowHeaders_Test"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RscRowHeader1 As RSCRowHeader
    Friend WithEvents RscRowHeader2 As RSCRowHeader
    Friend WithEvents RscRowHeader3 As RSCRowHeader
    Friend WithEvents RscRowHeader4 As RSCRowHeader
End Class
