<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUploadBackground
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.CtlBackground1 = New ciLayoutDesignVB.CtlBackground()
        Me.buttonOK = New System.Windows.Forms.Button()
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.buttonUpload = New System.Windows.Forms.Button()
        Me.LabelHeading1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'CtlBackground1
        '
        Me.CtlBackground1.Location = New System.Drawing.Point(12, 69)
        Me.CtlBackground1.Name = "CtlBackground1"
        Me.CtlBackground1.Size = New System.Drawing.Size(710, 340)
        Me.CtlBackground1.TabIndex = 0
        '
        'buttonOK
        '
        Me.buttonOK.Location = New System.Drawing.Point(500, 415)
        Me.buttonOK.Name = "buttonOK"
        Me.buttonOK.Size = New System.Drawing.Size(108, 34)
        Me.buttonOK.TabIndex = 1
        Me.buttonOK.Text = "OK"
        Me.buttonOK.UseVisualStyleBackColor = True
        '
        'buttonCancel
        '
        Me.buttonCancel.Location = New System.Drawing.Point(614, 415)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(108, 34)
        Me.buttonCancel.TabIndex = 2
        Me.buttonCancel.Text = "Cancel"
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'buttonUpload
        '
        Me.buttonUpload.Location = New System.Drawing.Point(411, 29)
        Me.buttonUpload.Name = "buttonUpload"
        Me.buttonUpload.Size = New System.Drawing.Size(311, 34)
        Me.buttonUpload.TabIndex = 3
        Me.buttonUpload.Text = "Select Background Image From File System"
        Me.buttonUpload.UseVisualStyleBackColor = True
        '
        'LabelHeading1
        '
        Me.LabelHeading1.AutoSize = True
        Me.LabelHeading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeading1.Location = New System.Drawing.Point(12, 29)
        Me.LabelHeading1.Name = "LabelHeading1"
        Me.LabelHeading1.Size = New System.Drawing.Size(270, 26)
        Me.LabelHeading1.TabIndex = 4
        Me.LabelHeading1.Text = "Upload Background Image"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FormUploadBackground
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 466)
        Me.Controls.Add(Me.LabelHeading1)
        Me.Controls.Add(Me.buttonUpload)
        Me.Controls.Add(Me.buttonCancel)
        Me.Controls.Add(Me.buttonOK)
        Me.Controls.Add(Me.CtlBackground1)
        Me.Name = "FormUploadBackground"
        Me.Text = "FormUploadBackground"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CtlBackground1 As CtlBackground
    Friend WithEvents buttonOK As Button
    Friend WithEvents buttonCancel As Button
    Friend WithEvents buttonUpload As Button
    Friend WithEvents LabelHeading1 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
