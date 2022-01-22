<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPickGraphic
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.textboxPathToImageFile = New System.Windows.Forms.TextBox()
        Me.ButtonBrowseForImageFile = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabelClearPath = New System.Windows.Forms.LinkLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelImagesWillBeCopied = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(25, 36)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(758, 376)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(552, 461)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(107, 52)
        Me.ButtonOK.TabIndex = 1
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(676, 461)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(107, 52)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'textboxPathToImageFile
        '
        Me.textboxPathToImageFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxPathToImageFile.Location = New System.Drawing.Point(25, 442)
        Me.textboxPathToImageFile.Name = "textboxPathToImageFile"
        Me.textboxPathToImageFile.Size = New System.Drawing.Size(494, 22)
        Me.textboxPathToImageFile.TabIndex = 3
        '
        'ButtonBrowseForImageFile
        '
        Me.ButtonBrowseForImageFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonBrowseForImageFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonBrowseForImageFile.Location = New System.Drawing.Point(205, 474)
        Me.ButtonBrowseForImageFile.Name = "ButtonBrowseForImageFile"
        Me.ButtonBrowseForImageFile.Size = New System.Drawing.Size(314, 39)
        Me.ButtonBrowseForImageFile.TabIndex = 4
        Me.ButtonBrowseForImageFile.Text = "Browse your file folders for image file *"
        Me.ButtonBrowseForImageFile.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(738, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Select an image file for the graphic element.  Images are temporarily resized if " &
    "too large."
        '
        'LinkLabelClearPath
        '
        Me.LinkLabelClearPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelClearPath.AutoSize = True
        Me.LinkLabelClearPath.Location = New System.Drawing.Point(26, 495)
        Me.LinkLabelClearPath.Name = "LinkLabelClearPath"
        Me.LinkLabelClearPath.Size = New System.Drawing.Size(131, 17)
        Me.LinkLabelClearPath.TabIndex = 6
        Me.LinkLabelClearPath.TabStop = True
        Me.LinkLabelClearPath.Text = "Clear path from box"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 415)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 24)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Path to selected file *:"
        '
        'LabelImagesWillBeCopied
        '
        Me.LabelImagesWillBeCopied.AutoSize = True
        Me.LabelImagesWillBeCopied.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelImagesWillBeCopied.Location = New System.Drawing.Point(26, 516)
        Me.LabelImagesWillBeCopied.Name = "LabelImagesWillBeCopied"
        Me.LabelImagesWillBeCopied.Size = New System.Drawing.Size(383, 17)
        Me.LabelImagesWillBeCopied.TabIndex = 8
        Me.LabelImagesWillBeCopied.Text = "* Selected images will be re-copied into the Graphics folder."
        '
        'FormPickGraphic
        '
        Me.AcceptButton = Me.ButtonOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(800, 538)
        Me.Controls.Add(Me.LabelImagesWillBeCopied)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LinkLabelClearPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonBrowseForImageFile)
        Me.Controls.Add(Me.textboxPathToImageFile)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "FormPickGraphic"
        Me.Text = "Select an image file to populate the ID Card"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents textboxPathToImageFile As TextBox
    Friend WithEvents ButtonBrowseForImageFile As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkLabelClearPath As LinkLabel
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents LabelImagesWillBeCopied As Label
End Class
