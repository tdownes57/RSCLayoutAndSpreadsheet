<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlTextbox
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
        TextBox4 = New TextBox()
        SuspendLayout()
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(0, 0)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(22, 23)
        TextBox4.TabIndex = 1
        TextBox4.Text = "01"
        ' 
        ' UserControlTextbox
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(TextBox4)
        Name = "UserControlTextbox"
        Size = New Size(22, 23)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox4 As TextBox

End Class
