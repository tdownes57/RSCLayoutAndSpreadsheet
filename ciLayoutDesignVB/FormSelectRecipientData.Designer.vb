<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSelectRecipientData
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
        Me.txtPathToRecipientFile = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.linkOpenFile = New System.Windows.Forms.LinkLabel()
        Me.linkOpenFolder = New System.Windows.Forms.LinkLabel()
        Me.buttonCopyDataFile = New System.Windows.Forms.Button()
        Me.buttonIgnoreFile = New System.Windows.Forms.Button()
        Me.buttonUseSameFile = New System.Windows.Forms.Button()
        Me.linkOpenFolderAndFile = New System.Windows.Forms.LinkLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtPathToRecipientFile
        '
        Me.txtPathToRecipientFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPathToRecipientFile.Location = New System.Drawing.Point(37, 56)
        Me.txtPathToRecipientFile.Name = "txtPathToRecipientFile"
        Me.txtPathToRecipientFile.Size = New System.Drawing.Size(935, 20)
        Me.txtPathToRecipientFile.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(464, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "What about exisiting Recipient data file?"
        '
        'linkOpenFile
        '
        Me.linkOpenFile.AutoSize = True
        Me.linkOpenFile.Location = New System.Drawing.Point(34, 79)
        Me.linkOpenFile.Name = "linkOpenFile"
        Me.linkOpenFile.Size = New System.Drawing.Size(52, 13)
        Me.linkOpenFile.TabIndex = 2
        Me.linkOpenFile.TabStop = True
        Me.linkOpenFile.Text = "Open File"
        '
        'linkOpenFolder
        '
        Me.linkOpenFolder.AutoSize = True
        Me.linkOpenFolder.Location = New System.Drawing.Point(114, 79)
        Me.linkOpenFolder.Name = "linkOpenFolder"
        Me.linkOpenFolder.Size = New System.Drawing.Size(65, 13)
        Me.linkOpenFolder.TabIndex = 3
        Me.linkOpenFolder.TabStop = True
        Me.linkOpenFolder.Text = "Open Folder"
        '
        'buttonCopyDataFile
        '
        Me.buttonCopyDataFile.Location = New System.Drawing.Point(37, 126)
        Me.buttonCopyDataFile.Name = "buttonCopyDataFile"
        Me.buttonCopyDataFile.Size = New System.Drawing.Size(221, 24)
        Me.buttonCopyDataFile.TabIndex = 4
        Me.buttonCopyDataFile.Text = "Copy Recipient Data"
        Me.buttonCopyDataFile.UseVisualStyleBackColor = True
        '
        'buttonIgnoreFile
        '
        Me.buttonIgnoreFile.Location = New System.Drawing.Point(289, 126)
        Me.buttonIgnoreFile.Name = "buttonIgnoreFile"
        Me.buttonIgnoreFile.Size = New System.Drawing.Size(221, 24)
        Me.buttonIgnoreFile.TabIndex = 5
        Me.buttonIgnoreFile.Text = "Ignore File / Start Over"
        Me.buttonIgnoreFile.UseVisualStyleBackColor = True
        '
        'buttonUseSameFile
        '
        Me.buttonUseSameFile.Location = New System.Drawing.Point(727, 126)
        Me.buttonUseSameFile.Name = "buttonUseSameFile"
        Me.buttonUseSameFile.Size = New System.Drawing.Size(221, 24)
        Me.buttonUseSameFile.TabIndex = 6
        Me.buttonUseSameFile.Text = "Use same data file"
        Me.buttonUseSameFile.UseVisualStyleBackColor = True
        '
        'linkOpenFolderAndFile
        '
        Me.linkOpenFolderAndFile.AutoSize = True
        Me.linkOpenFolderAndFile.Location = New System.Drawing.Point(203, 79)
        Me.linkOpenFolderAndFile.Name = "linkOpenFolderAndFile"
        Me.linkOpenFolderAndFile.Size = New System.Drawing.Size(93, 13)
        Me.linkOpenFolderAndFile.TabIndex = 7
        Me.linkOpenFolderAndFile.TabStop = True
        Me.linkOpenFolderAndFile.Text = "Open Folder && File"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(543, 126)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(153, 24)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Delete File / Start Over"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'buttonIgnore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 169)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.linkOpenFolderAndFile)
        Me.Controls.Add(Me.buttonUseSameFile)
        Me.Controls.Add(Me.buttonIgnoreFile)
        Me.Controls.Add(Me.buttonCopyDataFile)
        Me.Controls.Add(Me.linkOpenFolder)
        Me.Controls.Add(Me.linkOpenFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPathToRecipientFile)
        Me.Name = "buttonIgnore"
        Me.Text = "FormSelectRecipientData"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPathToRecipientFile As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents linkOpenFile As LinkLabel
    Friend WithEvents linkOpenFolder As LinkLabel
    Friend WithEvents buttonCopyDataFile As Button
    Friend WithEvents buttonIgnoreFile As Button
    Friend WithEvents buttonUseSameFile As Button
    Friend WithEvents linkOpenFolderAndFile As LinkLabel
    Friend WithEvents Button1 As Button
End Class
