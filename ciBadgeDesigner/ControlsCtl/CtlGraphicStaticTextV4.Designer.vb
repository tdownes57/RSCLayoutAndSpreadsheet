<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlGraphicStaticTextV4
    Inherits CtlGraphicFieldOrTextV4 ''Added 1/30/2022 td 

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
        Me.textTypeExample.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textTypeExample.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textTypeExample.Location = New System.Drawing.Point(14, 0)
        Me.textTypeExample.Margin = New System.Windows.Forms.Padding(2)
        Me.textTypeExample.Name = "textTypeExample"
        Me.textTypeExample.Size = New System.Drawing.Size(274, 19)
        Me.textTypeExample.TabIndex = 4
        Me.textTypeExample.Visible = False
        '
        'CtlGraphicStaticTextV4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.textTypeExample)
        Me.Name = "CtlGraphicStaticTextV4"
        Me.Controls.SetChildIndex(Me.textTypeExample, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textTypeExample As TextBox
End Class
