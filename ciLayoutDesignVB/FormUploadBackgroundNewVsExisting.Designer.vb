<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUploadBackgroundNewVsExisting
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
        Me.txtFiletitle_OriginalImage = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'CtlBackground1Existing
        '
        Me.CtlBackground1Existing.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlBackground1Existing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CtlBackground1Existing.IsNotSelectableItemOfAList = False
        Me.CtlBackground1Existing.Location = New System.Drawing.Point(12, 73)
        Me.CtlBackground1Existing.Name = "CtlBackground1Existing"
        Me.CtlBackground1Existing.Size = New System.Drawing.Size(665, 340)
        Me.CtlBackground1Existing.TabIndex = 1
        '
        'CtlBackground2Proposed
        '
        Me.CtlBackground2Proposed.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlBackground2Proposed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CtlBackground2Proposed.IsNotSelectableItemOfAList = False
        Me.CtlBackground2Proposed.Location = New System.Drawing.Point(697, 73)
        Me.CtlBackground2Proposed.Name = "CtlBackground2Proposed"
        Me.CtlBackground2Proposed.Size = New System.Drawing.Size(665, 340)
        Me.CtlBackground2Proposed.TabIndex = 2
        '
        'buttonCancel
        '
        Me.buttonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonCancel.Location = New System.Drawing.Point(1255, 455)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(108, 34)
        Me.buttonCancel.TabIndex = 4
        Me.buttonCancel.Text = "Cancel"
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'buttonKeepBothImages
        '
        Me.buttonKeepBothImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonKeepBothImages.Location = New System.Drawing.Point(977, 455)
        Me.buttonKeepBothImages.Name = "buttonKeepBothImages"
        Me.buttonKeepBothImages.Size = New System.Drawing.Size(272, 34)
        Me.buttonKeepBothImages.TabIndex = 3
        Me.buttonKeepBothImages.Text = "Save Both Images w/ Indicated Names"
        Me.buttonKeepBothImages.UseVisualStyleBackColor = True
        '
        'LabelHeading1
        '
        Me.LabelHeading1.AutoSize = True
        Me.LabelHeading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeading1.Location = New System.Drawing.Point(12, 21)
        Me.LabelHeading1.Name = "LabelHeading1"
        Me.LabelHeading1.Size = New System.Drawing.Size(1013, 36)
        Me.LabelHeading1.TabIndex = 5
        Me.LabelHeading1.Text = "Select which same-named background image you prefer for the background"
        '
        'LabelSelectOriginal
        '
        Me.LabelSelectOriginal.AutoSize = True
        Me.LabelSelectOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSelectOriginal.Location = New System.Drawing.Point(6, 416)
        Me.LabelSelectOriginal.Name = "LabelSelectOriginal"
        Me.LabelSelectOriginal.Size = New System.Drawing.Size(395, 36)
        Me.LabelSelectOriginal.TabIndex = 6
        Me.LabelSelectOriginal.Text = "▲ Select to keep the original."
        '
        'LabelSelectNewImage
        '
        Me.LabelSelectNewImage.AutoSize = True
        Me.LabelSelectNewImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSelectNewImage.Location = New System.Drawing.Point(691, 416)
        Me.LabelSelectNewImage.Name = "LabelSelectNewImage"
        Me.LabelSelectNewImage.Size = New System.Drawing.Size(466, 36)
        Me.LabelSelectNewImage.TabIndex = 7
        Me.LabelSelectNewImage.Text = "▲ Select to upload the new image."
        '
        'textFiletitle_NewImage
        '
        Me.textFiletitle_NewImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFiletitle_NewImage.Location = New System.Drawing.Point(859, 73)
        Me.textFiletitle_NewImage.Name = "textFiletitle_NewImage"
        Me.textFiletitle_NewImage.Size = New System.Drawing.Size(472, 32)
        Me.textFiletitle_NewImage.TabIndex = 8
        '
        'ButtonReplaceOlderImage
        '
        Me.ButtonReplaceOlderImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonReplaceOlderImage.Location = New System.Drawing.Point(697, 455)
        Me.ButtonReplaceOlderImage.Name = "ButtonReplaceOlderImage"
        Me.ButtonReplaceOlderImage.Size = New System.Drawing.Size(254, 34)
        Me.ButtonReplaceOlderImage.TabIndex = 9
        Me.ButtonReplaceOlderImage.Text = "▲ Replace Original Image w/ New"
        Me.ButtonReplaceOlderImage.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(12, 455)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(198, 34)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "▲ Keep Original Image"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtFiletitle_OriginalImage
        '
        Me.txtFiletitle_OriginalImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiletitle_OriginalImage.Location = New System.Drawing.Point(177, 73)
        Me.txtFiletitle_OriginalImage.Name = "txtFiletitle_OriginalImage"
        Me.txtFiletitle_OriginalImage.Size = New System.Drawing.Size(472, 32)
        Me.txtFiletitle_OriginalImage.TabIndex = 11
        '
        'FormUploadBackgroundNewVsExisting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1381, 512)
        Me.Controls.Add(Me.txtFiletitle_OriginalImage)
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
        Me.Name = "FormUploadBackgroundNewVsExisting"
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
    Friend WithEvents txtFiletitle_OriginalImage As TextBox
End Class
