<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBackgroundUpload
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
        Me.buttonOK = New System.Windows.Forms.Button()
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.buttonUpload1 = New System.Windows.Forms.Button()
        Me.LabelHeading1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.CtlBackground1 = New ciLayoutDesignVB.CtlBackground()
        Me.buttonUpload2 = New System.Windows.Forms.Button()
        Me.textImageFileTitleEdited = New System.Windows.Forms.TextBox()
        Me.ButtonEditImage = New System.Windows.Forms.Button()
        Me.LabelSelectedTitle = New System.Windows.Forms.Label()
        Me.picturePreview = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelOriginalHdr = New System.Windows.Forms.Label()
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'buttonOK
        '
        Me.buttonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonOK.Location = New System.Drawing.Point(770, 418)
        Me.buttonOK.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.buttonOK.Name = "buttonOK"
        Me.buttonOK.Size = New System.Drawing.Size(81, 28)
        Me.buttonOK.TabIndex = 1
        Me.buttonOK.Text = "OK"
        Me.buttonOK.UseVisualStyleBackColor = True
        '
        'buttonCancel
        '
        Me.buttonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonCancel.Location = New System.Drawing.Point(855, 418)
        Me.buttonCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(81, 28)
        Me.buttonCancel.TabIndex = 2
        Me.buttonCancel.Text = "Cancel"
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'buttonUpload1
        '
        Me.buttonUpload1.Location = New System.Drawing.Point(22, 366)
        Me.buttonUpload1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.buttonUpload1.Name = "buttonUpload1"
        Me.buttonUpload1.Size = New System.Drawing.Size(233, 28)
        Me.buttonUpload1.TabIndex = 3
        Me.buttonUpload1.Text = "Select Background Image From File System"
        Me.buttonUpload1.UseVisualStyleBackColor = True
        '
        'LabelHeading1
        '
        Me.LabelHeading1.AutoSize = True
        Me.LabelHeading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeading1.Location = New System.Drawing.Point(11, 9)
        Me.LabelHeading1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeading1.Name = "LabelHeading1"
        Me.LabelHeading1.Size = New System.Drawing.Size(299, 29)
        Me.LabelHeading1.TabIndex = 4
        Me.LabelHeading1.Text = "Upload Background Image"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CtlBackground1
        '
        Me.CtlBackground1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlBackground1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CtlBackground1.IsNotSelectableItemOfAList = False
        Me.CtlBackground1.Location = New System.Drawing.Point(22, 82)
        Me.CtlBackground1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CtlBackground1.Name = "CtlBackground1"
        Me.CtlBackground1.Size = New System.Drawing.Size(512, 277)
        Me.CtlBackground1.TabIndex = 0
        '
        'buttonUpload2
        '
        Me.buttonUpload2.Location = New System.Drawing.Point(148, 50)
        Me.buttonUpload2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.buttonUpload2.Name = "buttonUpload2"
        Me.buttonUpload2.Size = New System.Drawing.Size(233, 28)
        Me.buttonUpload2.TabIndex = 5
        Me.buttonUpload2.Text = "Select Background Image From File System"
        Me.buttonUpload2.UseVisualStyleBackColor = True
        '
        'textImageFileTitleEdited
        '
        Me.textImageFileTitleEdited.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textImageFileTitleEdited.Location = New System.Drawing.Point(689, 366)
        Me.textImageFileTitleEdited.Name = "textImageFileTitleEdited"
        Me.textImageFileTitleEdited.Size = New System.Drawing.Size(335, 26)
        Me.textImageFileTitleEdited.TabIndex = 58
        '
        'ButtonEditImage
        '
        Me.ButtonEditImage.Location = New System.Drawing.Point(580, 364)
        Me.ButtonEditImage.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonEditImage.Name = "ButtonEditImage"
        Me.ButtonEditImage.Size = New System.Drawing.Size(101, 28)
        Me.ButtonEditImage.TabIndex = 57
        Me.ButtonEditImage.Text = "Edit Image"
        Me.ButtonEditImage.UseVisualStyleBackColor = True
        '
        'LabelSelectedTitle
        '
        Me.LabelSelectedTitle.AutoSize = True
        Me.LabelSelectedTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSelectedTitle.Location = New System.Drawing.Point(719, 61)
        Me.LabelSelectedTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelSelectedTitle.Name = "LabelSelectedTitle"
        Me.LabelSelectedTitle.Size = New System.Drawing.Size(107, 18)
        Me.LabelSelectedTitle.TabIndex = 56
        Me.LabelSelectedTitle.Tag = "Select Background Image"
        Me.LabelSelectedTitle.Text = "(image file-title)"
        '
        'picturePreview
        '
        Me.picturePreview.BackColor = System.Drawing.Color.White
        Me.picturePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePreview.Location = New System.Drawing.Point(583, 82)
        Me.picturePreview.Name = "picturePreview"
        Me.picturePreview.Size = New System.Drawing.Size(466, 277)
        Me.picturePreview.TabIndex = 55
        Me.picturePreview.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(579, 60)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 22)
        Me.Label1.TabIndex = 54
        Me.Label1.Tag = ""
        Me.Label1.Text = "Edited:"
        '
        'LabelOriginalHdr
        '
        Me.LabelOriginalHdr.AutoSize = True
        Me.LabelOriginalHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelOriginalHdr.Location = New System.Drawing.Point(18, 60)
        Me.LabelOriginalHdr.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelOriginalHdr.Name = "LabelOriginalHdr"
        Me.LabelOriginalHdr.Size = New System.Drawing.Size(77, 22)
        Me.LabelOriginalHdr.TabIndex = 59
        Me.LabelOriginalHdr.Tag = "Select Background Image"
        Me.LabelOriginalHdr.Text = "Original:"
        '
        'FormBackgroundUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 457)
        Me.Controls.Add(Me.LabelOriginalHdr)
        Me.Controls.Add(Me.textImageFileTitleEdited)
        Me.Controls.Add(Me.ButtonEditImage)
        Me.Controls.Add(Me.LabelSelectedTitle)
        Me.Controls.Add(Me.picturePreview)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.buttonUpload2)
        Me.Controls.Add(Me.LabelHeading1)
        Me.Controls.Add(Me.buttonUpload1)
        Me.Controls.Add(Me.buttonCancel)
        Me.Controls.Add(Me.buttonOK)
        Me.Controls.Add(Me.CtlBackground1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FormBackgroundUpload"
        Me.Text = "FormUploadBackground"
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CtlBackground1 As CtlBackground
    Friend WithEvents buttonOK As Button
    Friend WithEvents buttonCancel As Button
    Friend WithEvents buttonUpload1 As Button
    Friend WithEvents LabelHeading1 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents buttonUpload2 As Button
    Friend WithEvents textImageFileTitleEdited As TextBox
    Friend WithEvents ButtonEditImage As Button
    Friend WithEvents LabelSelectedTitle As Label
    Friend WithEvents picturePreview As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelOriginalHdr As Label
End Class
