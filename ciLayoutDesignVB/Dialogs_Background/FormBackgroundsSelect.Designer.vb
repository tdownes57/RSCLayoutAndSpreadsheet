<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBackgroundsSelect
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
        Me.CtlBackground2 = New ciLayoutDesignVB.CtlBackground()
        Me.CtlBackground3 = New ciLayoutDesignVB.CtlBackground()
        Me.CtlBackground1 = New ciLayoutDesignVB.CtlBackground()
        Me.LabelHeading1 = New System.Windows.Forms.Label()
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.buttonOK = New System.Windows.Forms.Button()
        Me.buttonUpload1 = New System.Windows.Forms.Button()
        Me.ButtonShowDemos1 = New System.Windows.Forms.Button()
        Me.ButtonShowDemos2 = New System.Windows.Forms.Button()
        Me.buttonUpload2 = New System.Windows.Forms.Button()
        Me.ButtonRegularMode1 = New System.Windows.Forms.Button()
        Me.ButtonRegularMode2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picturePreview = New System.Windows.Forms.PictureBox()
        Me.LinkTestScreengrab = New System.Windows.Forms.LinkLabel()
        Me.LabelSelectedTitle = New System.Windows.Forms.Label()
        Me.ButtonEditImage = New System.Windows.Forms.Button()
        Me.textImageFileTitleEdited = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.LabelModeHeader = New System.Windows.Forms.Label()
        Me.LabelImageFolderPath = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FlowLayoutPanel1.Controls.Add(Me.CtlBackground2)
        Me.FlowLayoutPanel1.Controls.Add(Me.CtlBackground3)
        Me.FlowLayoutPanel1.Controls.Add(Me.CtlBackground1)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(9, 58)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(589, 422)
        Me.FlowLayoutPanel1.TabIndex = 13
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'CtlBackground2
        '
        Me.CtlBackground2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlBackground2.IsNotSelectableItemOfAList = False
        Me.CtlBackground2.Location = New System.Drawing.Point(2, 2)
        Me.CtlBackground2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CtlBackground2.Name = "CtlBackground2"
        Me.CtlBackground2.Size = New System.Drawing.Size(544, 262)
        Me.CtlBackground2.TabIndex = 1
        '
        'CtlBackground3
        '
        Me.CtlBackground3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlBackground3.IsNotSelectableItemOfAList = False
        Me.CtlBackground3.Location = New System.Drawing.Point(2, 268)
        Me.CtlBackground3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CtlBackground3.Name = "CtlBackground3"
        Me.CtlBackground3.Size = New System.Drawing.Size(544, 262)
        Me.CtlBackground3.TabIndex = 2
        '
        'CtlBackground1
        '
        Me.CtlBackground1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlBackground1.IsNotSelectableItemOfAList = False
        Me.CtlBackground1.Location = New System.Drawing.Point(2, 534)
        Me.CtlBackground1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CtlBackground1.Name = "CtlBackground1"
        Me.CtlBackground1.Size = New System.Drawing.Size(544, 262)
        Me.CtlBackground1.TabIndex = 0
        '
        'LabelHeading1
        '
        Me.LabelHeading1.AutoSize = True
        Me.LabelHeading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeading1.Location = New System.Drawing.Point(9, 16)
        Me.LabelHeading1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeading1.Name = "LabelHeading1"
        Me.LabelHeading1.Size = New System.Drawing.Size(287, 29)
        Me.LabelHeading1.TabIndex = 14
        Me.LabelHeading1.Tag = "Select Background Image"
        Me.LabelHeading1.Text = "Background, Demo Mode"
        '
        'buttonCancel
        '
        Me.buttonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonCancel.Location = New System.Drawing.Point(1040, 512)
        Me.buttonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(81, 28)
        Me.buttonCancel.TabIndex = 16
        Me.buttonCancel.Text = "Cancel"
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'buttonOK
        '
        Me.buttonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonOK.Location = New System.Drawing.Point(932, 512)
        Me.buttonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.buttonOK.Name = "buttonOK"
        Me.buttonOK.Size = New System.Drawing.Size(104, 28)
        Me.buttonOK.TabIndex = 15
        Me.buttonOK.Text = "OK"
        Me.buttonOK.UseVisualStyleBackColor = True
        '
        'buttonUpload1
        '
        Me.buttonUpload1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonUpload1.Location = New System.Drawing.Point(805, 11)
        Me.buttonUpload1.Margin = New System.Windows.Forms.Padding(2)
        Me.buttonUpload1.Name = "buttonUpload1"
        Me.buttonUpload1.Size = New System.Drawing.Size(316, 39)
        Me.buttonUpload1.TabIndex = 17
        Me.buttonUpload1.Text = "Upload / Select Background Image From File System"
        Me.buttonUpload1.UseVisualStyleBackColor = True
        '
        'ButtonShowDemos1
        '
        Me.ButtonShowDemos1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonShowDemos1.Location = New System.Drawing.Point(681, 11)
        Me.ButtonShowDemos1.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonShowDemos1.Name = "ButtonShowDemos1"
        Me.ButtonShowDemos1.Size = New System.Drawing.Size(120, 39)
        Me.ButtonShowDemos1.TabIndex = 18
        Me.ButtonShowDemos1.Text = "Demos / Examples"
        Me.ButtonShowDemos1.UseVisualStyleBackColor = True
        '
        'ButtonShowDemos2
        '
        Me.ButtonShowDemos2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonShowDemos2.Location = New System.Drawing.Point(10, 495)
        Me.ButtonShowDemos2.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonShowDemos2.Name = "ButtonShowDemos2"
        Me.ButtonShowDemos2.Size = New System.Drawing.Size(120, 39)
        Me.ButtonShowDemos2.TabIndex = 20
        Me.ButtonShowDemos2.Text = "Demos / Examples"
        Me.ButtonShowDemos2.UseVisualStyleBackColor = True
        '
        'buttonUpload2
        '
        Me.buttonUpload2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonUpload2.Location = New System.Drawing.Point(148, 495)
        Me.buttonUpload2.Margin = New System.Windows.Forms.Padding(2)
        Me.buttonUpload2.Name = "buttonUpload2"
        Me.buttonUpload2.Size = New System.Drawing.Size(316, 39)
        Me.buttonUpload2.TabIndex = 19
        Me.buttonUpload2.Text = "Upload / Select Background Image From File System"
        Me.buttonUpload2.UseVisualStyleBackColor = True
        '
        'ButtonRegularMode1
        '
        Me.ButtonRegularMode1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRegularMode1.Location = New System.Drawing.Point(681, 11)
        Me.ButtonRegularMode1.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonRegularMode1.Name = "ButtonRegularMode1"
        Me.ButtonRegularMode1.Size = New System.Drawing.Size(120, 39)
        Me.ButtonRegularMode1.TabIndex = 21
        Me.ButtonRegularMode1.Text = "Regular Mode"
        Me.ButtonRegularMode1.UseVisualStyleBackColor = True
        Me.ButtonRegularMode1.Visible = False
        '
        'ButtonRegularMode2
        '
        Me.ButtonRegularMode2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonRegularMode2.Location = New System.Drawing.Point(518, 495)
        Me.ButtonRegularMode2.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonRegularMode2.Name = "ButtonRegularMode2"
        Me.ButtonRegularMode2.Size = New System.Drawing.Size(120, 39)
        Me.ButtonRegularMode2.TabIndex = 22
        Me.ButtonRegularMode2.Text = "Regular Mode"
        Me.ButtonRegularMode2.UseVisualStyleBackColor = True
        Me.ButtonRegularMode2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(609, 77)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 29)
        Me.Label1.TabIndex = 24
        Me.Label1.Tag = "Select Background Image"
        Me.Label1.Text = "Selected*:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(760, 482)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(246, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "*Resized to about 75% normal size for display here."
        '
        'picturePreview
        '
        Me.picturePreview.BackColor = System.Drawing.Color.White
        Me.picturePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePreview.Location = New System.Drawing.Point(655, 109)
        Me.picturePreview.Name = "picturePreview"
        Me.picturePreview.Size = New System.Drawing.Size(466, 277)
        Me.picturePreview.TabIndex = 48
        Me.picturePreview.TabStop = False
        '
        'LinkTestScreengrab
        '
        Me.LinkTestScreengrab.AutoSize = True
        Me.LinkTestScreengrab.Location = New System.Drawing.Point(706, 522)
        Me.LinkTestScreengrab.Name = "LinkTestScreengrab"
        Me.LinkTestScreengrab.Size = New System.Drawing.Size(147, 13)
        Me.LinkTestScreengrab.TabIndex = 49
        Me.LinkTestScreengrab.TabStop = True
        Me.LinkTestScreengrab.Text = "Test screenshot / screengrab"
        '
        'LabelSelectedTitle
        '
        Me.LabelSelectedTitle.AutoSize = True
        Me.LabelSelectedTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSelectedTitle.Location = New System.Drawing.Point(746, 88)
        Me.LabelSelectedTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelSelectedTitle.Name = "LabelSelectedTitle"
        Me.LabelSelectedTitle.Size = New System.Drawing.Size(107, 18)
        Me.LabelSelectedTitle.TabIndex = 50
        Me.LabelSelectedTitle.Tag = "Select Background Image"
        Me.LabelSelectedTitle.Text = "(image file-title)"
        '
        'ButtonEditImage
        '
        Me.ButtonEditImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEditImage.Location = New System.Drawing.Point(655, 391)
        Me.ButtonEditImage.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonEditImage.Name = "ButtonEditImage"
        Me.ButtonEditImage.Size = New System.Drawing.Size(101, 28)
        Me.ButtonEditImage.TabIndex = 51
        Me.ButtonEditImage.Text = "Edit Image"
        Me.ButtonEditImage.UseVisualStyleBackColor = True
        '
        'textImageFileTitleEdited
        '
        Me.textImageFileTitleEdited.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textImageFileTitleEdited.Location = New System.Drawing.Point(785, 391)
        Me.textImageFileTitleEdited.Name = "textImageFileTitleEdited"
        Me.textImageFileTitleEdited.Size = New System.Drawing.Size(335, 26)
        Me.textImageFileTitleEdited.TabIndex = 53
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Uploaded Backgrounds", "Demo Backgrounds", "Original Backgrounds", "Uploaded Graphics", "Demo Graphics", "Uploaded Portraits", "Demo Portraits"})
        Me.ComboBox1.Location = New System.Drawing.Point(457, 7)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(203, 28)
        Me.ComboBox1.TabIndex = 54
        '
        'LabelModeHeader
        '
        Me.LabelModeHeader.AutoSize = True
        Me.LabelModeHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelModeHeader.Location = New System.Drawing.Point(371, 3)
        Me.LabelModeHeader.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelModeHeader.Name = "LabelModeHeader"
        Me.LabelModeHeader.Size = New System.Drawing.Size(81, 29)
        Me.LabelModeHeader.TabIndex = 55
        Me.LabelModeHeader.Tag = "Mode:"
        Me.LabelModeHeader.Text = "Mode:"
        '
        'LabelImageFolderPath
        '
        Me.LabelImageFolderPath.AutoSize = True
        Me.LabelImageFolderPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelImageFolderPath.Location = New System.Drawing.Point(652, 421)
        Me.LabelImageFolderPath.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelImageFolderPath.Name = "LabelImageFolderPath"
        Me.LabelImageFolderPath.Size = New System.Drawing.Size(264, 18)
        Me.LabelImageFolderPath.TabIndex = 56
        Me.LabelImageFolderPath.Tag = "Select Background Image"
        Me.LabelImageFolderPath.Text = "(image folder path a.k.a. directory path)"
        '
        'FormBackgroundsSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1161, 551)
        Me.Controls.Add(Me.LabelImageFolderPath)
        Me.Controls.Add(Me.LabelModeHeader)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.textImageFileTitleEdited)
        Me.Controls.Add(Me.ButtonEditImage)
        Me.Controls.Add(Me.LabelSelectedTitle)
        Me.Controls.Add(Me.LinkTestScreengrab)
        Me.Controls.Add(Me.picturePreview)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonRegularMode2)
        Me.Controls.Add(Me.ButtonShowDemos2)
        Me.Controls.Add(Me.buttonUpload2)
        Me.Controls.Add(Me.ButtonShowDemos1)
        Me.Controls.Add(Me.buttonUpload1)
        Me.Controls.Add(Me.buttonCancel)
        Me.Controls.Add(Me.buttonOK)
        Me.Controls.Add(Me.LabelHeading1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.ButtonRegularMode1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FormBackgroundsSelect"
        Me.Text = "FormListBackgrounds"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents CtlBackground1 As CtlBackground
    Friend WithEvents CtlBackground2 As CtlBackground
    Friend WithEvents CtlBackground3 As CtlBackground
    Friend WithEvents LabelHeading1 As Label
    Friend WithEvents buttonCancel As Button
    Friend WithEvents buttonOK As Button
    Friend WithEvents buttonUpload1 As Button
    Friend WithEvents ButtonShowDemos1 As Button
    Friend WithEvents ButtonShowDemos2 As Button
    Friend WithEvents buttonUpload2 As Button
    Friend WithEvents ButtonRegularMode1 As Button
    Friend WithEvents ButtonRegularMode2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents picturePreview As PictureBox
    Friend WithEvents LinkTestScreengrab As LinkLabel
    Friend WithEvents LabelSelectedTitle As Label
    Friend WithEvents ButtonEditImage As Button
    Friend WithEvents textImageFileTitleEdited As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents LabelModeHeader As Label
    Friend WithEvents LabelImageFolderPath As Label
End Class
