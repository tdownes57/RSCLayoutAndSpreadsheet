<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DLLUserControlRichbox
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
        TextBox1 = New RichTextBox()
        SuspendLayout()
        ' 
        ' RichTextBox3
        ' 
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Location = New Point(0, 0)
        TextBox1.Name = "RichTextBox3"
        TextBox1.Size = New Size(22, 23)
        TextBox1.TabIndex = 156
        TextBox1.Text = "01"
        ' 
        ' UserControlRichbox
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(TextBox1)
        Name = "UserControlRichbox"
        Size = New Size(22, 23)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TextBox1 As RichTextBox

End Class
