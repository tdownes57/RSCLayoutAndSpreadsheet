<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormListBackgrounds
    Inherits System.Windows.Forms.Form

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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Labelesding1 = New System.Windows.Forms.Label()
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.buttonOK = New System.Windows.Forms.Button()
        Me.CtlBackground2 = New ciLayoutDesignVB.CtlBackground()
        Me.CtlBackground3 = New ciLayoutDesignVB.CtlBackground()
        Me.CtlBackground1 = New ciLayoutDesignVB.CtlBackground()
        Me.buttonUpload = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FlowLayoutPanel1.Controls.Add(Me.CtlBackground2)
        Me.FlowLayoutPanel1.Controls.Add(Me.CtlBackground3)
        Me.FlowLayoutPanel1.Controls.Add(Me.CtlBackground1)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 72)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1024, 434)
        Me.FlowLayoutPanel1.TabIndex = 13
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'Labelesding1
        '
        Me.Labelesding1.AutoSize = True
        Me.Labelesding1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelesding1.Location = New System.Drawing.Point(12, 20)
        Me.Labelesding1.Name = "Labelesding1"
        Me.Labelesding1.Size = New System.Drawing.Size(378, 36)
        Me.Labelesding1.TabIndex = 14
        Me.Labelesding1.Text = "Select a Background Image"
        '
        'buttonCancel
        '
        Me.buttonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonCancel.Location = New System.Drawing.Point(907, 531)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(108, 34)
        Me.buttonCancel.TabIndex = 16
        Me.buttonCancel.Text = "Cancel"
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'buttonOK
        '
        Me.buttonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonOK.Location = New System.Drawing.Point(763, 531)
        Me.buttonOK.Name = "buttonOK"
        Me.buttonOK.Size = New System.Drawing.Size(108, 34)
        Me.buttonOK.TabIndex = 15
        Me.buttonOK.Text = "OK"
        Me.buttonOK.UseVisualStyleBackColor = True
        '
        'CtlBackground2
        '
        Me.CtlBackground2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlBackground2.Location = New System.Drawing.Point(3, 3)
        Me.CtlBackground2.Name = "CtlBackground2"
        Me.CtlBackground2.Size = New System.Drawing.Size(838, 323)
        Me.CtlBackground2.TabIndex = 1
        '
        'CtlBackground3
        '
        Me.CtlBackground3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlBackground3.Location = New System.Drawing.Point(3, 332)
        Me.CtlBackground3.Name = "CtlBackground3"
        Me.CtlBackground3.Size = New System.Drawing.Size(838, 323)
        Me.CtlBackground3.TabIndex = 2
        '
        'CtlBackground1
        '
        Me.CtlBackground1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlBackground1.Location = New System.Drawing.Point(3, 661)
        Me.CtlBackground1.Name = "CtlBackground1"
        Me.CtlBackground1.Size = New System.Drawing.Size(838, 323)
        Me.CtlBackground1.TabIndex = 0
        '
        'buttonUpload
        '
        Me.buttonUpload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonUpload.Location = New System.Drawing.Point(704, 27)
        Me.buttonUpload.Name = "buttonUpload"
        Me.buttonUpload.Size = New System.Drawing.Size(311, 34)
        Me.buttonUpload.TabIndex = 17
        Me.buttonUpload.Text = "Select Background Image From File System"
        Me.buttonUpload.UseVisualStyleBackColor = True
        '
        'FormListBackgrounds
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 593)
        Me.Controls.Add(Me.buttonUpload)
        Me.Controls.Add(Me.buttonCancel)
        Me.Controls.Add(Me.buttonOK)
        Me.Controls.Add(Me.Labelesding1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "FormListBackgrounds"
        Me.Text = "FormListBackgrounds"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents CtlBackground1 As CtlBackground
    Friend WithEvents CtlBackground2 As CtlBackground
    Friend WithEvents CtlBackground3 As CtlBackground
    Friend WithEvents Labelesding1 As Label
    Friend WithEvents buttonCancel As Button
    Friend WithEvents buttonOK As Button
    Friend WithEvents buttonUpload As Button
End Class
