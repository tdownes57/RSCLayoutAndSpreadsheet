<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RSCMoveableControlVB
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.LinkLabelConditional = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'LinkLabelConditional
        '
        Me.LinkLabelConditional.AutoSize = True
        Me.LinkLabelConditional.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabelConditional.Location = New System.Drawing.Point(3, 0)
        Me.LinkLabelConditional.Name = "LinkLabelConditional"
        Me.LinkLabelConditional.Size = New System.Drawing.Size(59, 13)
        Me.LinkLabelConditional.TabIndex = 0
        Me.LinkLabelConditional.TabStop = True
        Me.LinkLabelConditional.Text = "Conditional"
        Me.LinkLabelConditional.Visible = False
        '
        'RSCMoveableControlVB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Controls.Add(Me.LinkLabelConditional)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "RSCMoveableControlVB"
        Me.Size = New System.Drawing.Size(256, 122)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkLabelConditional As LinkLabel
End Class
