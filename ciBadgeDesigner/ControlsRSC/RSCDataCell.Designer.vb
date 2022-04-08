<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RSCDataCell
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
        Me.Textbox1a = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Textbox1a
        '
        Me.Textbox1a.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Textbox1a.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Textbox1a.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textbox1a.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Textbox1a.Location = New System.Drawing.Point(0, 0)
        Me.Textbox1a.Margin = New System.Windows.Forms.Padding(2)
        Me.Textbox1a.Multiline = True
        Me.Textbox1a.Name = "Textbox1a"
        Me.Textbox1a.Size = New System.Drawing.Size(150, 22)
        Me.Textbox1a.TabIndex = 37
        Me.Textbox1a.Text = "Example"
        '
        'RSCDataCell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Textbox1a)
        Me.Name = "RSCDataCell"
        Me.Size = New System.Drawing.Size(150, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Textbox1a As TextBox
End Class
