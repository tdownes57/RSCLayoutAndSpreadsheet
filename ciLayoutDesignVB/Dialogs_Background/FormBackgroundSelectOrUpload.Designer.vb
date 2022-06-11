<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBackgroundSelectOrUpload
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
        Me.ButtonUploadImage = New System.Windows.Forms.Button()
        Me.ButtonSelectLoaded = New System.Windows.Forms.Button()
        Me.LabelAddingElementsHdr = New System.Windows.Forms.Label()
        Me.LabelFooter1 = New System.Windows.Forms.Label()
        Me.LabelFooter2 = New System.Windows.Forms.Label()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonSelectDemos = New System.Windows.Forms.Button()
        Me.textboxPathToImageJPG = New System.Windows.Forms.TextBox()
        Me.LabelCurrentPathHeaderLbl = New System.Windows.Forms.Label()
        Me.LinkLabelOpenFile = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelOpenFolder = New System.Windows.Forms.LinkLabel()
        Me.ButtonEditBackground = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonUploadImage
        '
        Me.ButtonUploadImage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonUploadImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonUploadImage.Location = New System.Drawing.Point(32, 95)
        Me.ButtonUploadImage.Name = "ButtonUploadImage"
        Me.ButtonUploadImage.Size = New System.Drawing.Size(505, 57)
        Me.ButtonUploadImage.TabIndex = 8
        Me.ButtonUploadImage.Text = "1.  Upload a Background Image *"
        Me.ButtonUploadImage.UseVisualStyleBackColor = True
        '
        'ButtonSelectLoaded
        '
        Me.ButtonSelectLoaded.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSelectLoaded.Enabled = False
        Me.ButtonSelectLoaded.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSelectLoaded.Location = New System.Drawing.Point(32, 189)
        Me.ButtonSelectLoaded.Name = "ButtonSelectLoaded"
        Me.ButtonSelectLoaded.Size = New System.Drawing.Size(505, 57)
        Me.ButtonSelectLoaded.TabIndex = 7
        Me.ButtonSelectLoaded.Text = "2. Select a Background Image **"
        Me.ButtonSelectLoaded.UseVisualStyleBackColor = True
        '
        'LabelAddingElementsHdr
        '
        Me.LabelAddingElementsHdr.AutoSize = True
        Me.LabelAddingElementsHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAddingElementsHdr.Location = New System.Drawing.Point(12, 62)
        Me.LabelAddingElementsHdr.Name = "LabelAddingElementsHdr"
        Me.LabelAddingElementsHdr.Size = New System.Drawing.Size(218, 20)
        Me.LabelAddingElementsHdr.TabIndex = 10
        Me.LabelAddingElementsHdr.Text = "Managing Background Image"
        '
        'LabelFooter1
        '
        Me.LabelFooter1.AutoSize = True
        Me.LabelFooter1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFooter1.Location = New System.Drawing.Point(2, 157)
        Me.LabelFooter1.Name = "LabelFooter1"
        Me.LabelFooter1.Size = New System.Drawing.Size(566, 17)
        Me.LabelFooter1.TabIndex = 9
        Me.LabelFooter1.Text = "* You will see a button asking you to select an image from your PC or laptop's ha" &
    "rd drive."
        '
        'LabelFooter2
        '
        Me.LabelFooter2.AutoSize = True
        Me.LabelFooter2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFooter2.Location = New System.Drawing.Point(2, 249)
        Me.LabelFooter2.Name = "LabelFooter2"
        Me.LabelFooter2.Size = New System.Drawing.Size(470, 17)
        Me.LabelFooter2.TabIndex = 11
        Me.LabelFooter2.Text = "** This is available if you have up already loaded one (1) or more images."
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.Location = New System.Drawing.Point(454, 426)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(146, 35)
        Me.ButtonCancel.TabIndex = 13
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonSelectDemos
        '
        Me.ButtonSelectDemos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSelectDemos.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSelectDemos.Location = New System.Drawing.Point(32, 283)
        Me.ButtonSelectDemos.Name = "ButtonSelectDemos"
        Me.ButtonSelectDemos.Size = New System.Drawing.Size(505, 57)
        Me.ButtonSelectDemos.TabIndex = 12
        Me.ButtonSelectDemos.Text = "(Browse Pre-Loaded Demo Images)"
        Me.ButtonSelectDemos.UseVisualStyleBackColor = True
        '
        'textboxPathToImageJPG
        '
        Me.textboxPathToImageJPG.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxPathToImageJPG.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.textboxPathToImageJPG.Location = New System.Drawing.Point(16, 385)
        Me.textboxPathToImageJPG.Name = "textboxPathToImageJPG"
        Me.textboxPathToImageJPG.ReadOnly = True
        Me.textboxPathToImageJPG.Size = New System.Drawing.Size(584, 20)
        Me.textboxPathToImageJPG.TabIndex = 14
        '
        'LabelCurrentPathHeaderLbl
        '
        Me.LabelCurrentPathHeaderLbl.AutoSize = True
        Me.LabelCurrentPathHeaderLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCurrentPathHeaderLbl.Location = New System.Drawing.Point(12, 364)
        Me.LabelCurrentPathHeaderLbl.Name = "LabelCurrentPathHeaderLbl"
        Me.LabelCurrentPathHeaderLbl.Size = New System.Drawing.Size(227, 17)
        Me.LabelCurrentPathHeaderLbl.TabIndex = 15
        Me.LabelCurrentPathHeaderLbl.Text = "Path to current background image:"
        '
        'LinkLabelOpenFile
        '
        Me.LinkLabelOpenFile.AutoSize = True
        Me.LinkLabelOpenFile.Location = New System.Drawing.Point(13, 408)
        Me.LinkLabelOpenFile.Name = "LinkLabelOpenFile"
        Me.LinkLabelOpenFile.Size = New System.Drawing.Size(84, 13)
        Me.LinkLabelOpenFile.TabIndex = 16
        Me.LinkLabelOpenFile.TabStop = True
        Me.LinkLabelOpenFile.Text = "Open Image File"
        '
        'LinkLabelOpenFolder
        '
        Me.LinkLabelOpenFolder.AutoSize = True
        Me.LinkLabelOpenFolder.Location = New System.Drawing.Point(127, 408)
        Me.LinkLabelOpenFolder.Name = "LinkLabelOpenFolder"
        Me.LinkLabelOpenFolder.Size = New System.Drawing.Size(97, 13)
        Me.LinkLabelOpenFolder.TabIndex = 17
        Me.LinkLabelOpenFolder.TabStop = True
        Me.LinkLabelOpenFolder.Text = "Open Image Folder"
        '
        'ButtonEditBackground
        '
        Me.ButtonEditBackground.BackColor = System.Drawing.Color.MediumAquamarine
        Me.ButtonEditBackground.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.Background_Image_H
        Me.ButtonEditBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonEditBackground.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonEditBackground.Location = New System.Drawing.Point(12, 12)
        Me.ButtonEditBackground.Name = "ButtonEditBackground"
        Me.ButtonEditBackground.Size = New System.Drawing.Size(582, 32)
        Me.ButtonEditBackground.TabIndex = 104
        Me.ButtonEditBackground.UseVisualStyleBackColor = False
        '
        'FormBackgroundSelectOrUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 473)
        Me.Controls.Add(Me.ButtonEditBackground)
        Me.Controls.Add(Me.LinkLabelOpenFolder)
        Me.Controls.Add(Me.LinkLabelOpenFile)
        Me.Controls.Add(Me.LabelCurrentPathHeaderLbl)
        Me.Controls.Add(Me.textboxPathToImageJPG)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonSelectDemos)
        Me.Controls.Add(Me.LabelFooter2)
        Me.Controls.Add(Me.LabelAddingElementsHdr)
        Me.Controls.Add(Me.LabelFooter1)
        Me.Controls.Add(Me.ButtonUploadImage)
        Me.Controls.Add(Me.ButtonSelectLoaded)
        Me.Name = "FormBackgroundSelectOrUpload"
        Me.Text = "FormSelectOrUpload"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonUploadImage As Button
    Friend WithEvents ButtonSelectLoaded As Button
    Friend WithEvents LabelAddingElementsHdr As Label
    Friend WithEvents LabelFooter1 As Label
    Friend WithEvents LabelFooter2 As Label
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonSelectDemos As Button
    Friend WithEvents textboxPathToImageJPG As TextBox
    Friend WithEvents LabelCurrentPathHeaderLbl As Label
    Friend WithEvents LinkLabelOpenFile As LinkLabel
    Friend WithEvents LinkLabelOpenFolder As LinkLabel
    Friend WithEvents ButtonEditBackground As Button
End Class
