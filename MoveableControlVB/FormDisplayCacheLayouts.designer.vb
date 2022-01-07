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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ButtonSelectLayoutFromDrive = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.LabelWarningMessage = New System.Windows.Forms.Label()
        Me.ButtonUserCancels = New System.Windows.Forms.Button()
        Me.ButtonExitApp = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonFindLayout = New System.Windows.Forms.Button()
        Me.picturePreview = New System.Windows.Forms.PictureBox()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelCaptionPathToTheFileXML
        '
        Me.LabelCaptionPathToTheFileXML.AutoSize = True
        Me.LabelCaptionPathToTheFileXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCaptionPathToTheFileXML.Location = New System.Drawing.Point(212, 12)
        Me.LabelCaptionPathToTheFileXML.Name = "LabelCaptionPathToTheFileXML"
        Me.LabelCaptionPathToTheFileXML.Size = New System.Drawing.Size(140, 18)
        Me.LabelCaptionPathToTheFileXML.TabIndex = 77
        Me.LabelCaptionPathToTheFileXML.Text = "Path to the XML file."
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
        Me.LabelFullPathToXML.Location = New System.Drawing.Point(241, 44)
        Me.LabelFullPathToXML.Name = "LabelFullPathToXML"
        Me.LabelFullPathToXML.Size = New System.Drawing.Size(168, 18)
        Me.LabelFullPathToXML.TabIndex = 79
        Me.LabelFullPathToXML.Text = "\\.....Path to the XML file."
        '
        'ButtonOpenCurrentLayout
        '
        Me.ButtonOpenCurrentLayout.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOpenCurrentLayout.Location = New System.Drawing.Point(26, 117)
        Me.ButtonOpenCurrentLayout.Name = "ButtonOpenCurrentLayout"
        Me.ButtonOpenCurrentLayout.Size = New System.Drawing.Size(171, 89)
        Me.ButtonOpenCurrentLayout.TabIndex = 80
        Me.ButtonOpenCurrentLayout.Text = "Open This Layout ►►"
        Me.ButtonOpenCurrentLayout.UseVisualStyleBackColor = True
        '
        'ButtonOpenNewBlank
        '
        Me.ButtonOpenNewBlank.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOpenNewBlank.Location = New System.Drawing.Point(26, 12)
        Me.ButtonOpenNewBlank.Name = "ButtonOpenNewBlank"
        Me.ButtonOpenNewBlank.Size = New System.Drawing.Size(171, 89)
        Me.ButtonOpenNewBlank.TabIndex = 82
        Me.ButtonOpenNewBlank.Text = "Open New Blank Layout"
        Me.ButtonOpenNewBlank.UseVisualStyleBackColor = True
        '
        'LabelPriorLayoutsHdr
        '
        Me.LabelPriorLayoutsHdr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelPriorLayoutsHdr.AutoSize = True
        Me.LabelPriorLayoutsHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPriorLayoutsHdr.Location = New System.Drawing.Point(1042, 9)
        Me.LabelPriorLayoutsHdr.Name = "LabelPriorLayoutsHdr"
        Me.LabelPriorLayoutsHdr.Size = New System.Drawing.Size(95, 18)
        Me.LabelPriorLayoutsHdr.TabIndex = 83
        Me.LabelPriorLayoutsHdr.Text = "Prior layouts:"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FlowLayoutPanel1.Controls.Add(Me.PictureBox1)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(1045, 41)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(349, 399)
        Me.FlowLayoutPanel1.TabIndex = 84
        Me.FlowLayoutPanel1.WrapContents = False
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
        Me.ButtonSelectLayoutFromDrive.Location = New System.Drawing.Point(980, 456)
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
        Me.LabelWarningMessage.Location = New System.Drawing.Point(241, 62)
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
        Me.ButtonUserCancels.Location = New System.Drawing.Point(1223, 457)
        Me.ButtonUserCancels.Name = "ButtonUserCancels"
        Me.ButtonUserCancels.Size = New System.Drawing.Size(171, 42)
        Me.ButtonUserCancels.TabIndex = 87
        Me.ButtonUserCancels.Text = "Cancel"
        Me.ButtonUserCancels.UseVisualStyleBackColor = True
        '
        'ButtonExitApp
        '
        Me.ButtonExitApp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonExitApp.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonExitApp.Location = New System.Drawing.Point(26, 425)
        Me.ButtonExitApp.Name = "ButtonExitApp"
        Me.ButtonExitApp.Size = New System.Drawing.Size(182, 72)
        Me.ButtonExitApp.TabIndex = 88
        Me.ButtonExitApp.Text = "Exit Application"
        Me.ButtonExitApp.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(875, 392)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(77, 105)
        Me.ButtonOK.TabIndex = 89
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonFindLayout
        '
        Me.ButtonFindLayout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFindLayout.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFindLayout.Location = New System.Drawing.Point(26, 333)
        Me.ButtonFindLayout.Name = "ButtonFindLayout"
        Me.ButtonFindLayout.Size = New System.Drawing.Size(144, 86)
        Me.ButtonFindLayout.TabIndex = 90
        Me.ButtonFindLayout.Text = "Find Layout using Open File"
        Me.ButtonFindLayout.UseVisualStyleBackColor = True
        '
        'picturePreview
        '
        Me.picturePreview.BackColor = System.Drawing.Color.White
        Me.picturePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePreview.Location = New System.Drawing.Point(215, 117)
        Me.picturePreview.Name = "picturePreview"
        Me.picturePreview.Size = New System.Drawing.Size(466, 277)
        Me.picturePreview.TabIndex = 91
        Me.picturePreview.TabStop = False
        '
        'FormDisplayCacheLayouts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1406, 517)
        Me.Controls.Add(Me.picturePreview)
        Me.Controls.Add(Me.ButtonFindLayout)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.ButtonExitApp)
        Me.Controls.Add(Me.ButtonUserCancels)
        Me.Controls.Add(Me.LabelWarningMessage)
        Me.Controls.Add(Me.ButtonSelectLayoutFromDrive)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.LabelPriorLayoutsHdr)
        Me.Controls.Add(Me.ButtonOpenNewBlank)
        Me.Controls.Add(Me.ButtonOpenCurrentLayout)
        Me.Controls.Add(Me.LabelFullPathToXML)
        Me.Controls.Add(Me.LabelHeader3)
        Me.Controls.Add(Me.LabelCaptionPathToTheFileXML)
        Me.Name = "FormDisplayCacheLayouts"
        Me.Text = "FormDisplayCacheLayouts"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelCaptionPathToTheFileXML As Label
    Friend WithEvents LabelHeader3 As Label
    Friend WithEvents LabelFullPathToXML As Label
    Friend WithEvents ButtonOpenCurrentLayout As Button
    Friend WithEvents ButtonOpenNewBlank As Button
    Friend WithEvents LabelPriorLayoutsHdr As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ButtonSelectLayoutFromDrive As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents LabelWarningMessage As Label
    Friend WithEvents ButtonUserCancels As Button
    Friend WithEvents ButtonExitApp As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonFindLayout As Button
    Friend WithEvents picturePreview As PictureBox
End Class
