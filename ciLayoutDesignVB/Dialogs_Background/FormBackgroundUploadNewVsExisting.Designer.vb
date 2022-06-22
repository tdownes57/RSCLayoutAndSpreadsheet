<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBackgroundUploadNewVsExisting
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
        Me.CtlBackground1Existing = New ciLayoutDesignVB.CtlBackground()
        Me.CtlBackground2Proposed = New ciLayoutDesignVB.CtlBackground()
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.buttonKeepBothImages = New System.Windows.Forms.Button()
        Me.LabelHeading1 = New System.Windows.Forms.Label()
        Me.LabelSelectOriginal = New System.Windows.Forms.Label()
        Me.LabelSelectNewImage = New System.Windows.Forms.Label()
        Me.textFiletitle_NewImage = New System.Windows.Forms.TextBox()
        Me.ButtonReplaceOlderImage = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.textFileTitle_OriginalImage = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'CtlBackground1Existing
        '
        Me.CtlBackground1Existing.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlBackground1Existing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CtlBackground1Existing.IsNotSelectableItemOfAList = False
        Me.CtlBackground1Existing.Location = New System.Drawing.Point(9, 59)
        Me.CtlBackground1Existing.Margin = New System.Windows.Forms.Padding(2)
        Me.CtlBackground1Existing.Name = "CtlBackground1Existing"
        Me.CtlBackground1Existing.Size = New System.Drawing.Size(499, 276)
        Me.CtlBackground1Existing.TabIndex = 1
        '
        'CtlBackground2Proposed
        '
        Me.CtlBackground2Proposed.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlBackground2Proposed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CtlBackground2Proposed.IsNotSelectableItemOfAList = False
        Me.CtlBackground2Proposed.Location = New System.Drawing.Point(523, 59)
        Me.CtlBackground2Proposed.Margin = New System.Windows.Forms.Padding(2)
        Me.CtlBackground2Proposed.Name = "CtlBackground2Proposed"
        Me.CtlBackground2Proposed.Size = New System.Drawing.Size(499, 276)
        Me.CtlBackground2Proposed.TabIndex = 2
        '
        'buttonCancel
        '
        Me.buttonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonCancel.Location = New System.Drawing.Point(941, 370)
        Me.buttonCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(81, 28)
        Me.buttonCancel.TabIndex = 4
        Me.buttonCancel.Text = "Cancel"
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'buttonKeepBothImages
        '
        Me.buttonKeepBothImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonKeepBothImages.Location = New System.Drawing.Point(733, 370)
        Me.buttonKeepBothImages.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.buttonKeepBothImages.Name = "buttonKeepBothImages"
        Me.buttonKeepBothImages.Size = New System.Drawing.Size(204, 28)
        Me.buttonKeepBothImages.TabIndex = 3
        Me.buttonKeepBothImages.Text = "Save Both Images w/ Indicated Names"
        Me.buttonKeepBothImages.UseVisualStyleBackColor = True
        '
        'LabelHeading1
        '
        Me.LabelHeading1.AutoSize = True
        Me.LabelHeading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeading1.Location = New System.Drawing.Point(9, 17)
        Me.LabelHeading1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeading1.Name = "LabelHeading1"
        Me.LabelHeading1.Size = New System.Drawing.Size(822, 29)
        Me.LabelHeading1.TabIndex = 5
        Me.LabelHeading1.Text = "Select which same-named background image you prefer for the background"
        '
        'LabelSelectOriginal
        '
        Me.LabelSelectOriginal.AutoSize = True
        Me.LabelSelectOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSelectOriginal.Location = New System.Drawing.Point(4, 338)
        Me.LabelSelectOriginal.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelSelectOriginal.Name = "LabelSelectOriginal"
        Me.LabelSelectOriginal.Size = New System.Drawing.Size(320, 29)
        Me.LabelSelectOriginal.TabIndex = 6
        Me.LabelSelectOriginal.Text = "▲ Select to keep the original."
        '
        'LabelSelectNewImage
        '
        Me.LabelSelectNewImage.AutoSize = True
        Me.LabelSelectNewImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSelectNewImage.Location = New System.Drawing.Point(518, 338)
        Me.LabelSelectNewImage.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelSelectNewImage.Name = "LabelSelectNewImage"
        Me.LabelSelectNewImage.Size = New System.Drawing.Size(378, 29)
        Me.LabelSelectNewImage.TabIndex = 7
        Me.LabelSelectNewImage.Text = "▲ Select to upload the new image."
        '
        'textFiletitle_NewImage
        '
        Me.textFiletitle_NewImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFiletitle_NewImage.Location = New System.Drawing.Point(644, 59)
        Me.textFiletitle_NewImage.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.textFiletitle_NewImage.Name = "textFiletitle_NewImage"
        Me.textFiletitle_NewImage.Size = New System.Drawing.Size(355, 27)
        Me.textFiletitle_NewImage.TabIndex = 8
        '
        'ButtonReplaceOlderImage
        '
        Me.ButtonReplaceOlderImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonReplaceOlderImage.Location = New System.Drawing.Point(523, 370)
        Me.ButtonReplaceOlderImage.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonReplaceOlderImage.Name = "ButtonReplaceOlderImage"
        Me.ButtonReplaceOlderImage.Size = New System.Drawing.Size(190, 28)
        Me.ButtonReplaceOlderImage.TabIndex = 9
        Me.ButtonReplaceOlderImage.Text = "▲ Replace Original Image w/ New"
        Me.ButtonReplaceOlderImage.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(9, 370)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(148, 28)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "▲ Keep Original Image"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'textFileTitle_OriginalImage
        '
        Me.textFileTitle_OriginalImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFileTitle_OriginalImage.Location = New System.Drawing.Point(133, 59)
        Me.textFileTitle_OriginalImage.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.textFileTitle_OriginalImage.Name = "textFileTitle_OriginalImage"
        Me.textFileTitle_OriginalImage.Size = New System.Drawing.Size(355, 27)
        Me.textFileTitle_OriginalImage.TabIndex = 11
        '
        'FormBackgroundUploadNewVsExisting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1036, 416)
        Me.Controls.Add(Me.textFileTitle_OriginalImage)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonReplaceOlderImage)
        Me.Controls.Add(Me.textFiletitle_NewImage)
        Me.Controls.Add(Me.LabelSelectNewImage)
        Me.Controls.Add(Me.LabelSelectOriginal)
        Me.Controls.Add(Me.LabelHeading1)
        Me.Controls.Add(Me.buttonCancel)
        Me.Controls.Add(Me.buttonKeepBothImages)
        Me.Controls.Add(Me.CtlBackground2Proposed)
        Me.Controls.Add(Me.CtlBackground1Existing)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FormBackgroundUploadNewVsExisting"
        Me.Text = "FormUploadBackgroundNewVsExisting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CtlBackground1Existing As CtlBackground
    Friend WithEvents CtlBackground2Proposed As CtlBackground
    Friend WithEvents buttonCancel As Button
    Friend WithEvents buttonKeepBothImages As Button
    Friend WithEvents LabelHeading1 As Label
    Friend WithEvents LabelSelectOriginal As Label
    Friend WithEvents LabelSelectNewImage As Label
    Friend WithEvents textFiletitle_NewImage As TextBox
    Friend WithEvents ButtonReplaceOlderImage As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents textFileTitle_OriginalImage As TextBox
End Class
