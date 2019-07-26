<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlAddCustomField
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
        Me.buttonAddField = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'buttonAddField
        '
        Me.buttonAddField.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonAddField.Location = New System.Drawing.Point(364, 36)
        Me.buttonAddField.Name = "buttonAddField"
        Me.buttonAddField.Size = New System.Drawing.Size(108, 51)
        Me.buttonAddField.TabIndex = 9
        Me.buttonAddField.Text = "Add Field"
        Me.buttonAddField.UseVisualStyleBackColor = True
        '
        'UserAddFieldControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.Controls.Add(Me.buttonAddField)
        Me.Name = "UserAddFieldControl"
        Me.Size = New System.Drawing.Size(837, 123)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents buttonAddField As Button
End Class
