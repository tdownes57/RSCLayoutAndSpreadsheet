<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlRichbox
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
        RichTextBox3 = New RichTextBox()
        SuspendLayout()
        ' 
        ' RichTextBox3
        ' 
        RichTextBox3.BorderStyle = BorderStyle.FixedSingle
        RichTextBox3.Location = New Point(0, 0)
        RichTextBox3.Name = "RichTextBox3"
        RichTextBox3.Size = New Size(22, 23)
        RichTextBox3.TabIndex = 156
        RichTextBox3.Text = "01"
        ' 
        ' UserControlRichbox
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(RichTextBox3)
        Name = "UserControlRichbox"
        Size = New Size(22, 23)
        ResumeLayout(False)
    End Sub

    Friend WithEvents RichTextBox3 As RichTextBox

End Class
