<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dialog_BaseEditElement
    Inherits Dialog_Base ''Added 5/31/2022 
    ''5/31/2022 Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.LabelHeaderBelowBox = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelHeaderBelowBox
        '
        Me.LabelHeaderBelowBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderBelowBox.Location = New System.Drawing.Point(632, 257)
        Me.LabelHeaderBelowBox.Name = "LabelHeaderBelowBox"
        Me.LabelHeaderBelowBox.Size = New System.Drawing.Size(222, 99)
        Me.LabelHeaderBelowBox.TabIndex = 12
        Me.LabelHeaderBelowBox.Text = "Press a button below to edit the properties suggested by the button caption."
        '
        'Dialog_BaseEditElement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 512)
        Me.Controls.Add(Me.LabelHeaderBelowBox)
        Me.Name = "Dialog_BaseEditElement"
        Me.Text = "Form_BaseEditElement"
        Me.Controls.SetChildIndex(Me.LabelHeaderBelowBox, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelHeaderBelowBox As Label
End Class
