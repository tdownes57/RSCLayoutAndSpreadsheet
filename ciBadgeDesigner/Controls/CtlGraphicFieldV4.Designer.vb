<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlGraphicFieldV4
    Inherits CtlGraphicFieldOrTextV4
    ''---Feb3 2022----Inherits UserControl

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
        Me.textTypeExample = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'textTypeExample
        '
        Me.textTypeExample.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textTypeExample.BackColor = System.Drawing.Color.White
        Me.textTypeExample.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textTypeExample.Location = New System.Drawing.Point(195, 0)
        Me.textTypeExample.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.textTypeExample.Name = "textTypeExample"
        Me.textTypeExample.Size = New System.Drawing.Size(189, 32)
        Me.textTypeExample.TabIndex = 4
        Me.textTypeExample.Visible = False
        '
        'CtlGraphicFieldV4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.textTypeExample)
        Me.Name = "CtlGraphicFieldV4"
        Me.Controls.SetChildIndex(Me.textTypeExample, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textTypeExample As TextBox
End Class
