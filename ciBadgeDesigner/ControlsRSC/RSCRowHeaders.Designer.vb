<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCRowHeaders
    Inherits __RSCWindowsControlLibrary.RSCMoveableControlVB

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
        Me.textRowHeader1 = New ciBadgeDesigner.RSCRowHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LinkLabelConditional
        '
        Me.LinkLabelConditional.Visible = True
        '
        'textRowHeader1
        '
        Me.textRowHeader1.Location = New System.Drawing.Point(0, 38)
        Me.textRowHeader1.Margin = New System.Windows.Forms.Padding(0)
        Me.textRowHeader1.Name = "textRowHeader1"
        ''11/2023 td Me.textRowHeader1.RowIndex = 0
        Me.textRowHeader1.Size = New System.Drawing.Size(143, 24)
        Me.textRowHeader1.TabIndex = 2
        Me.textRowHeader1.Text_RowNumber = "1"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 49)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Only the first row's header exists at design time!!"
        Me.Label1.Visible = False
        '
        'RSCRowHeaders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Thistle
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.textRowHeader1)
        Me.Name = "RSCRowHeaders"
        Me.Size = New System.Drawing.Size(143, 500)
        Me.Controls.SetChildIndex(Me.LinkLabelConditional, 0)
        Me.Controls.SetChildIndex(Me.textRowHeader1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textRowHeader1 As RSCRowHeader
    Friend WithEvents Label1 As Label
    ''Friend WithEvents PictureBox11a As PictureBox
End Class
