<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDisplayCacheLayouts
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
        Me.LabelCaptionPathToTheFileXML = New System.Windows.Forms.Label()
        Me.LabelHeader3 = New System.Windows.Forms.Label()
        Me.LabelFullPathToXML = New System.Windows.Forms.Label()
        Me.ButtonOpenCurrentLayout = New System.Windows.Forms.Button()
        Me.ButtonOpenNewBlank = New System.Windows.Forms.Button()
        Me.LabelPriorLayoutsHdr = New System.Windows.Forms.Label()
        Me.FlowLayoutPanelPriorLays = New System.Windows.Forms.FlowLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ButtonSelectLayoutFromDrive = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.LabelWarningMessage = New System.Windows.Forms.Label()
        Me.ButtonUserCancels = New System.Windows.Forms.Button()
        Me.ButtonExitApp = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonFindLayout = New System.Windows.Forms.Button()
        Me.picturePreviewFront = New System.Windows.Forms.PictureBox()
        Me.picturePreviewBackside = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabelClearPath = New System.Windows.Forms.LinkLabel()
        Me.ButtonBrowseForImageFile = New System.Windows.Forms.Button()
        Me.textboxPathToCacheXmlFile = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.FlowLayoutPanelPriorLays.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picturePreviewFront, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picturePreviewBackside, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelCaptionPathToTheFileXML
        '
        Me.LabelCaptionPathToTheFileXML.AutoSize = True
        Me.LabelCaptionPathToTheFileXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCaptionPathToTheFileXML.Location = New System.Drawing.Point(80, 12)
        Me.LabelCaptionPathToTheFileXML.Name = "LabelCaptionPathToTheFileXML"
        Me.LabelCaptionPathToTheFileXML.Size = New System.Drawing.Size(171, 18)
        Me.LabelCaptionPathToTheFileXML.TabIndex = 77
        Me.LabelCaptionPathToTheFileXML.Text = "Path to the XML file..."
        '
        'LabelHeader3
        '
        Me.LabelHeader3.AutoSize = True
        Me.LabelHeader3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader3.Location = New System.Drawing.Point(211, 96)
        Me.LabelHeader3.Name = "LabelHeader3"
        Me.LabelHeader3.Size = New System.Drawing.Size(141, 18)
        Me.LabelHeader3.TabIndex = 78
        Me.LabelHeader3.Text = "Badge card preview:"
        '
        'LabelFullPathToXML
        '
        Me.LabelFullPathToXML.AutoSize = True
        Me.LabelFullPathToXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFullPathToXML.Location = New System.Drawing.Point(257, 12)
        Me.LabelFullPathToXML.Name = "LabelFullPathToXML"
        Me.LabelFullPathToXML.Size = New System.Drawing.Size(168, 18)
        Me.LabelFullPathToXML.TabIndex = 79
        Me.LabelFullPathToXML.Text = "\\.....Path to the XML file."
        '
        'ButtonOpenCurrentLayout
        '
        Me.ButtonOpenCurrentLayout.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOpenCurrentLayout.Location = New System.Drawing.Point(26, 135)
        Me.ButtonOpenCurrentLayout.Name = "ButtonOpenCurrentLayout"
        Me.ButtonOpenCurrentLayout.Size = New System.Drawing.Size(171, 89)
        Me.ButtonOpenCurrentLayout.TabIndex = 80
        Me.ButtonOpenCurrentLayout.Text = "Open This Layout ►►"
        Me.ButtonOpenCurrentLayout.UseVisualStyleBackColor = True
        '
        'ButtonOpenNewBlank
        '
        Me.ButtonOpenNewBlank.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOpenNewBlank.Location = New System.Drawing.Point(26, 40)
        Me.ButtonOpenNewBlank.Name = "ButtonOpenNewBlank"
        Me.ButtonOpenNewBlank.Size = New System.Drawing.Size(171, 89)
        Me.ButtonOpenNewBlank.TabIndex = 82
        Me.ButtonOpenNewBlank.Text = "Open New Blank Layout"
        Me.ButtonOpenNewBlank.UseVisualStyleBackColor = True
        '
        'LabelPriorLayoutsHdr
        '
        Me.LabelPriorLayoutsHdr.AutoSize = True
        Me.LabelPriorLayoutsHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPriorLayoutsHdr.Location = New System.Drawing.Point(724, 44)
        Me.LabelPriorLayoutsHdr.Name = "LabelPriorLayoutsHdr"
        Me.LabelPriorLayoutsHdr.Size = New System.Drawing.Size(95, 18)
        Me.LabelPriorLayoutsHdr.TabIndex = 83
        Me.LabelPriorLayoutsHdr.Text = "Prior layouts:"
        '
        'FlowLayoutPanelPriorLays
        '
        Me.FlowLayoutPanelPriorLays.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanelPriorLays.AutoScroll = True
        Me.FlowLayoutPanelPriorLays.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanelPriorLays.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FlowLayoutPanelPriorLays.Controls.Add(Me.PictureBox1)
        Me.FlowLayoutPanelPriorLays.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanelPriorLays.Location = New System.Drawing.Point(822, 41)
        Me.FlowLayoutPanelPriorLays.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FlowLayoutPanelPriorLays.Name = "FlowLayoutPanelPriorLays"
        Me.FlowLayoutPanelPriorLays.Size = New System.Drawing.Size(572, 456)
        Me.FlowLayoutPanelPriorLays.TabIndex = 84
        Me.FlowLayoutPanelPriorLays.WrapContents = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(319, 205)
        Me.PictureBox1.TabIndex = 76
        Me.PictureBox1.TabStop = False
        '
        'ButtonSelectLayoutFromDrive
        '
        Me.ButtonSelectLayoutFromDrive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSelectLayoutFromDrive.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSelectLayoutFromDrive.Location = New System.Drawing.Point(980, 513)
        Me.ButtonSelectLayoutFromDrive.Name = "ButtonSelectLayoutFromDrive"
        Me.ButtonSelectLayoutFromDrive.Size = New System.Drawing.Size(228, 44)
        Me.ButtonSelectLayoutFromDrive.TabIndex = 85
        Me.ButtonSelectLayoutFromDrive.Text = "Find Layout in Drive(s)"
        Me.ButtonSelectLayoutFromDrive.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'LabelWarningMessage
        '
        Me.LabelWarningMessage.AutoSize = True
        Me.LabelWarningMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWarningMessage.ForeColor = System.Drawing.Color.Red
        Me.LabelWarningMessage.Location = New System.Drawing.Point(257, 30)
        Me.LabelWarningMessage.Name = "LabelWarningMessage"
        Me.LabelWarningMessage.Size = New System.Drawing.Size(149, 18)
        Me.LabelWarningMessage.TabIndex = 86
        Me.LabelWarningMessage.Text = "[warning message]"
        Me.LabelWarningMessage.Visible = False
        '
        'ButtonUserCancels
        '
        Me.ButtonUserCancels.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonUserCancels.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonUserCancels.Location = New System.Drawing.Point(1223, 514)
        Me.ButtonUserCancels.Name = "ButtonUserCancels"
        Me.ButtonUserCancels.Size = New System.Drawing.Size(171, 42)
        Me.ButtonUserCancels.TabIndex = 87
        Me.ButtonUserCancels.Text = "Cancel"
        Me.ButtonUserCancels.UseVisualStyleBackColor = True
        Me.ButtonUserCancels.Visible = False
        '
        'ButtonExitApp
        '
        Me.ButtonExitApp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonExitApp.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonExitApp.Location = New System.Drawing.Point(1223, 514)
        Me.ButtonExitApp.Name = "ButtonExitApp"
        Me.ButtonExitApp.Size = New System.Drawing.Size(171, 45)
        Me.ButtonExitApp.TabIndex = 88
        Me.ButtonExitApp.Text = "Exit"
        Me.ButtonExitApp.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(825, 521)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(127, 45)
        Me.ButtonOK.TabIndex = 89
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonFindLayout
        '
        Me.ButtonFindLayout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFindLayout.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFindLayout.Location = New System.Drawing.Point(26, 390)
        Me.ButtonFindLayout.Name = "ButtonFindLayout"
        Me.ButtonFindLayout.Size = New System.Drawing.Size(144, 86)
        Me.ButtonFindLayout.TabIndex = 90
        Me.ButtonFindLayout.Text = "Find Layout using Open File"
        Me.ButtonFindLayout.UseVisualStyleBackColor = True
        '
        'picturePreviewFront
        '
        Me.picturePreviewFront.BackColor = System.Drawing.Color.White
        Me.picturePreviewFront.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePreviewFront.Location = New System.Drawing.Point(215, 117)
        Me.picturePreviewFront.Name = "picturePreviewFront"
        Me.picturePreviewFront.Size = New System.Drawing.Size(466, 277)
        Me.picturePreviewFront.TabIndex = 91
        Me.picturePreviewFront.TabStop = False
        '
        'picturePreviewBackside
        '
        Me.picturePreviewBackside.BackColor = System.Drawing.Color.White
        Me.picturePreviewBackside.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.No_backside_exists
        Me.picturePreviewBackside.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picturePreviewBackside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePreviewBackside.Location = New System.Drawing.Point(312, 191)
        Me.picturePreviewBackside.Name = "picturePreviewBackside"
        Me.picturePreviewBackside.Size = New System.Drawing.Size(466, 277)
        Me.picturePreviewBackside.TabIndex = 92
        Me.picturePreviewBackside.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(221, 471)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 24)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "Path to selected file *:"
        '
        'LinkLabelClearPath
        '
        Me.LinkLabelClearPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelClearPath.AutoSize = True
        Me.LinkLabelClearPath.Location = New System.Drawing.Point(226, 581)
        Me.LinkLabelClearPath.Name = "LinkLabelClearPath"
        Me.LinkLabelClearPath.Size = New System.Drawing.Size(131, 17)
        Me.LinkLabelClearPath.TabIndex = 95
        Me.LinkLabelClearPath.TabStop = True
        Me.LinkLabelClearPath.Text = "Clear path from box"
        '
        'ButtonBrowseForImageFile
        '
        Me.ButtonBrowseForImageFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonBrowseForImageFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonBrowseForImageFile.Location = New System.Drawing.Point(405, 526)
        Me.ButtonBrowseForImageFile.Name = "ButtonBrowseForImageFile"
        Me.ButtonBrowseForImageFile.Size = New System.Drawing.Size(314, 39)
        Me.ButtonBrowseForImageFile.TabIndex = 94
        Me.ButtonBrowseForImageFile.Text = "Browse your file folders for image file *"
        Me.ButtonBrowseForImageFile.UseVisualStyleBackColor = True
        '
        'textboxPathToCacheXmlFile
        '
        Me.textboxPathToCacheXmlFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxPathToCacheXmlFile.Location = New System.Drawing.Point(225, 498)
        Me.textboxPathToCacheXmlFile.Name = "textboxPathToCacheXmlFile"
        Me.textboxPathToCacheXmlFile.Size = New System.Drawing.Size(727, 22)
        Me.textboxPathToCacheXmlFile.TabIndex = 93
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(222, 528)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(131, 17)
        Me.LinkLabel1.TabIndex = 97
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Clear path from box"
        '
        'FormDisplayCacheLayouts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1406, 574)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.ButtonExitApp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LinkLabelClearPath)
        Me.Controls.Add(Me.ButtonBrowseForImageFile)
        Me.Controls.Add(Me.textboxPathToCacheXmlFile)
        Me.Controls.Add(Me.picturePreviewFront)
        Me.Controls.Add(Me.ButtonFindLayout)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.ButtonUserCancels)
        Me.Controls.Add(Me.LabelWarningMessage)
        Me.Controls.Add(Me.ButtonSelectLayoutFromDrive)
        Me.Controls.Add(Me.FlowLayoutPanelPriorLays)
        Me.Controls.Add(Me.LabelPriorLayoutsHdr)
        Me.Controls.Add(Me.ButtonOpenNewBlank)
        Me.Controls.Add(Me.ButtonOpenCurrentLayout)
        Me.Controls.Add(Me.LabelFullPathToXML)
        Me.Controls.Add(Me.LabelHeader3)
        Me.Controls.Add(Me.LabelCaptionPathToTheFileXML)
        Me.Controls.Add(Me.picturePreviewBackside)
        Me.Name = "FormDisplayCacheLayouts"
        Me.Text = "FormDisplayCacheLayouts"
        Me.FlowLayoutPanelPriorLays.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picturePreviewFront, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picturePreviewBackside, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelCaptionPathToTheFileXML As Label
    Friend WithEvents LabelHeader3 As Label
    Friend WithEvents LabelFullPathToXML As Label
    Friend WithEvents ButtonOpenCurrentLayout As Button
    Friend WithEvents ButtonOpenNewBlank As Button
    Friend WithEvents LabelPriorLayoutsHdr As Label
    Friend WithEvents FlowLayoutPanelPriorLays As FlowLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ButtonSelectLayoutFromDrive As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents LabelWarningMessage As Label
    Friend WithEvents ButtonUserCancels As Button
    Friend WithEvents ButtonExitApp As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonFindLayout As Button
    Friend WithEvents picturePreviewFront As PictureBox
    Friend WithEvents picturePreviewBackside As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LinkLabelClearPath As LinkLabel
    Friend WithEvents ButtonBrowseForImageFile As Button
    Friend WithEvents textboxPathToCacheXmlFile As TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
