<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBackgroundUploadDimensionsMsg
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PanelDimensionsAreOff = New System.Windows.Forms.Panel()
        Me.CtlWidthHeightInputWidth = New ciLayoutDesignVB.CtlWidthHeight()
        Me.CtlWidthHeightInputHeight = New ciLayoutDesignVB.CtlWidthHeight()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelHeading1 = New System.Windows.Forms.Label()
        Me.ButtonHelpMeDecide = New System.Windows.Forms.Button()
        Me.ButtonSkipEditor = New System.Windows.Forms.Button()
        Me.ButtonGreat = New System.Windows.Forms.Button()
        Me.picturePVCCards = New System.Windows.Forms.PictureBox()
        Me.pictureUploaded = New System.Windows.Forms.PictureBox()
        Me.checkShowDetail = New System.Windows.Forms.CheckBox()
        Me.checkExpandBadgeView = New System.Windows.Forms.CheckBox()
        Me.pictureAnchorOnly = New System.Windows.Forms.PictureBox()
        Me.LabelLossOfPixelsMaximum = New System.Windows.Forms.Label()
        Me.CtlWidthHeightUploaded = New ciLayoutDesignVB.CtlWidthHeight()
        Me.LabelDimensionsAreAllOkay = New System.Windows.Forms.Label()
        Me.PanelDimensionsAreOff.SuspendLayout()
        CType(Me.picturePVCCards, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureUploaded, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureAnchorOnly, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 76)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(469, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "The image you uploaded has the following size:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 296)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 26)
        Me.Label2.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 211)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 26)
        Me.Label3.TabIndex = 4
        '
        'PanelDimensionsAreOff
        '
        Me.PanelDimensionsAreOff.Controls.Add(Me.CtlWidthHeightInputWidth)
        Me.PanelDimensionsAreOff.Controls.Add(Me.CtlWidthHeightInputHeight)
        Me.PanelDimensionsAreOff.Controls.Add(Me.Label5)
        Me.PanelDimensionsAreOff.Controls.Add(Me.Label4)
        Me.PanelDimensionsAreOff.Location = New System.Drawing.Point(31, 143)
        Me.PanelDimensionsAreOff.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelDimensionsAreOff.Name = "PanelDimensionsAreOff"
        Me.PanelDimensionsAreOff.Size = New System.Drawing.Size(621, 294)
        Me.PanelDimensionsAreOff.TabIndex = 5
        '
        'CtlWidthHeightInputWidth
        '
        Me.CtlWidthHeightInputWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtlWidthHeightInputWidth.Location = New System.Drawing.Point(73, 196)
        Me.CtlWidthHeightInputWidth.Margin = New System.Windows.Forms.Padding(5)
        Me.CtlWidthHeightInputWidth.Name = "CtlWidthHeightInputWidth"
        Me.CtlWidthHeightInputWidth.Size = New System.Drawing.Size(543, 93)
        Me.CtlWidthHeightInputWidth.TabIndex = 13
        '
        'CtlWidthHeightInputHeight
        '
        Me.CtlWidthHeightInputHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtlWidthHeightInputHeight.Location = New System.Drawing.Point(73, 44)
        Me.CtlWidthHeightInputHeight.Margin = New System.Windows.Forms.Padding(5)
        Me.CtlWidthHeightInputHeight.Name = "CtlWidthHeightInputHeight"
        Me.CtlWidthHeightInputHeight.Size = New System.Drawing.Size(543, 106)
        Me.CtlWidthHeightInputHeight.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 165)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(456, 26)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Using the width, the preferred dimensions are:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 13)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(464, 26)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Using the height, the preferred dimensions are:"
        '
        'LabelHeading1
        '
        Me.LabelHeading1.AutoSize = True
        Me.LabelHeading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeading1.Location = New System.Drawing.Point(15, 15)
        Me.LabelHeading1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LabelHeading1.Name = "LabelHeading1"
        Me.LabelHeading1.Size = New System.Drawing.Size(258, 36)
        Me.LabelHeading1.TabIndex = 6
        Me.LabelHeading1.Text = "Image Dimensions"
        '
        'ButtonHelpMeDecide
        '
        Me.ButtonHelpMeDecide.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonHelpMeDecide.Location = New System.Drawing.Point(30, 463)
        Me.ButtonHelpMeDecide.Name = "ButtonHelpMeDecide"
        Me.ButtonHelpMeDecide.Size = New System.Drawing.Size(391, 70)
        Me.ButtonHelpMeDecide.TabIndex = 7
        Me.ButtonHelpMeDecide.Text = "Help Me Decide How to Proceed (Recommended)"
        Me.ButtonHelpMeDecide.UseVisualStyleBackColor = True
        Me.ButtonHelpMeDecide.Visible = False
        '
        'ButtonSkipEditor
        '
        Me.ButtonSkipEditor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonSkipEditor.Location = New System.Drawing.Point(437, 463)
        Me.ButtonSkipEditor.Name = "ButtonSkipEditor"
        Me.ButtonSkipEditor.Size = New System.Drawing.Size(253, 70)
        Me.ButtonSkipEditor.TabIndex = 8
        Me.ButtonSkipEditor.Text = "Bypass / Skip"
        Me.ButtonSkipEditor.UseVisualStyleBackColor = True
        Me.ButtonSkipEditor.Visible = False
        '
        'ButtonGreat
        '
        Me.ButtonGreat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonGreat.Location = New System.Drawing.Point(1056, 463)
        Me.ButtonGreat.Name = "ButtonGreat"
        Me.ButtonGreat.Size = New System.Drawing.Size(165, 70)
        Me.ButtonGreat.TabIndex = 12
        Me.ButtonGreat.Text = "OK"
        Me.ButtonGreat.UseVisualStyleBackColor = True
        Me.ButtonGreat.Visible = False
        '
        'picturePVCCards
        '
        Me.picturePVCCards.Image = Global.ciLayoutDesignVB.My.Resources.Resources.PVC_Cards__MS_Bing_
        Me.picturePVCCards.Location = New System.Drawing.Point(675, 123)
        Me.picturePVCCards.Name = "picturePVCCards"
        Me.picturePVCCards.Size = New System.Drawing.Size(265, 239)
        Me.picturePVCCards.TabIndex = 13
        Me.picturePVCCards.TabStop = False
        '
        'pictureUploaded
        '
        Me.pictureUploaded.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.Badge001
        Me.pictureUploaded.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictureUploaded.Location = New System.Drawing.Point(951, 121)
        Me.pictureUploaded.Name = "pictureUploaded"
        Me.pictureUploaded.Size = New System.Drawing.Size(270, 237)
        Me.pictureUploaded.TabIndex = 14
        Me.pictureUploaded.TabStop = False
        '
        'checkShowDetail
        '
        Me.checkShowDetail.AutoSize = True
        Me.checkShowDetail.Checked = True
        Me.checkShowDetail.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkShowDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkShowDetail.Location = New System.Drawing.Point(30, 121)
        Me.checkShowDetail.Name = "checkShowDetail"
        Me.checkShowDetail.Size = New System.Drawing.Size(121, 24)
        Me.checkShowDetail.TabIndex = 15
        Me.checkShowDetail.Text = "Show Detail"
        Me.checkShowDetail.UseVisualStyleBackColor = True
        '
        'checkExpandBadgeView
        '
        Me.checkExpandBadgeView.AutoSize = True
        Me.checkExpandBadgeView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkExpandBadgeView.Location = New System.Drawing.Point(951, 359)
        Me.checkExpandBadgeView.Name = "checkExpandBadgeView"
        Me.checkExpandBadgeView.Size = New System.Drawing.Size(171, 21)
        Me.checkExpandBadgeView.TabIndex = 16
        Me.checkExpandBadgeView.Text = "Double width of viewer"
        Me.checkExpandBadgeView.UseVisualStyleBackColor = True
        '
        'pictureAnchorOnly
        '
        Me.pictureAnchorOnly.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.Badge001
        Me.pictureAnchorOnly.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictureAnchorOnly.Location = New System.Drawing.Point(951, 121)
        Me.pictureAnchorOnly.Name = "pictureAnchorOnly"
        Me.pictureAnchorOnly.Size = New System.Drawing.Size(270, 237)
        Me.pictureAnchorOnly.TabIndex = 17
        Me.pictureAnchorOnly.TabStop = False
        Me.pictureAnchorOnly.Visible = False
        '
        'LabelLossOfPixelsMaximum
        '
        Me.LabelLossOfPixelsMaximum.AutoSize = True
        Me.LabelLossOfPixelsMaximum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLossOfPixelsMaximum.Location = New System.Drawing.Point(220, 123)
        Me.LabelLossOfPixelsMaximum.Name = "LabelLossOfPixelsMaximum"
        Me.LabelLossOfPixelsMaximum.Size = New System.Drawing.Size(248, 18)
        Me.LabelLossOfPixelsMaximum.TabIndex = 18
        Me.LabelLossOfPixelsMaximum.Tag = "Maximum potential loss of pixels: {0}"
        Me.LabelLossOfPixelsMaximum.Text = "Maximum potential loss of pixels: {0}"
        '
        'CtlWidthHeightUploaded
        '
        Me.CtlWidthHeightUploaded.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtlWidthHeightUploaded.Location = New System.Drawing.Point(520, 27)
        Me.CtlWidthHeightUploaded.Margin = New System.Windows.Forms.Padding(5)
        Me.CtlWidthHeightUploaded.Name = "CtlWidthHeightUploaded"
        Me.CtlWidthHeightUploaded.Size = New System.Drawing.Size(551, 75)
        Me.CtlWidthHeightUploaded.TabIndex = 11
        '
        'LabelDimensionsAreAllOkay
        '
        Me.LabelDimensionsAreAllOkay.AutoSize = True
        Me.LabelDimensionsAreAllOkay.Location = New System.Drawing.Point(359, 485)
        Me.LabelDimensionsAreAllOkay.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LabelDimensionsAreAllOkay.Name = "LabelDimensionsAreAllOkay"
        Me.LabelDimensionsAreAllOkay.Size = New System.Drawing.Size(566, 26)
        Me.LabelDimensionsAreAllOkay.TabIndex = 19
        Me.LabelDimensionsAreAllOkay.Text = "The image you uploaded has the appropriate aspect ratio."
        Me.LabelDimensionsAreAllOkay.Visible = False
        '
        'FormUploadDimensionsMsg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 26.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1238, 545)
        Me.Controls.Add(Me.LabelDimensionsAreAllOkay)
        Me.Controls.Add(Me.LabelLossOfPixelsMaximum)
        Me.Controls.Add(Me.checkExpandBadgeView)
        Me.Controls.Add(Me.pictureUploaded)
        Me.Controls.Add(Me.checkShowDetail)
        Me.Controls.Add(Me.ButtonGreat)
        Me.Controls.Add(Me.CtlWidthHeightUploaded)
        Me.Controls.Add(Me.ButtonSkipEditor)
        Me.Controls.Add(Me.ButtonHelpMeDecide)
        Me.Controls.Add(Me.LabelHeading1)
        Me.Controls.Add(Me.PanelDimensionsAreOff)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pictureAnchorOnly)
        Me.Controls.Add(Me.picturePVCCards)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "FormUploadDimensionsMsg"
        Me.Text = "FormUploadDimensionsMsg"
        Me.PanelDimensionsAreOff.ResumeLayout(False)
        Me.PanelDimensionsAreOff.PerformLayout()
        CType(Me.picturePVCCards, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureUploaded, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureAnchorOnly, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PanelDimensionsAreOff As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LabelHeading1 As Label
    Friend WithEvents ButtonHelpMeDecide As Button
    Friend WithEvents ButtonSkipEditor As Button
    Friend WithEvents CtlWidthHeightUploaded As CtlWidthHeight
    Friend WithEvents CtlWidthHeightInputWidth As CtlWidthHeight
    Friend WithEvents CtlWidthHeightInputHeight As CtlWidthHeight
    Friend WithEvents ButtonGreat As Button
    Friend WithEvents picturePVCCards As PictureBox
    Friend WithEvents pictureUploaded As PictureBox
    Friend WithEvents checkShowDetail As CheckBox
    Friend WithEvents checkExpandBadgeView As CheckBox
    Friend WithEvents pictureAnchorOnly As PictureBox
    Friend WithEvents LabelLossOfPixelsMaximum As Label
    Friend WithEvents LabelDimensionsAreAllOkay As Label
End Class
