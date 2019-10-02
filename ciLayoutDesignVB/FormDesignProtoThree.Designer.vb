<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDesignProtoThree
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDesignProtoThree))
        Me.flowFieldsNotListed = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblFieldsNotCurrentlyShownHdr = New System.Windows.Forms.Label()
        Me.picturePreview = New System.Windows.Forms.PictureBox()
        Me.pictureBack = New System.Windows.Forms.PictureBox()
        Me.CtlGraphicPortrait_Lady = New ciLayoutDesignVB.CtlGraphicPortrait()
        Me.checkAutoPreview = New System.Windows.Forms.CheckBox()
        Me.flowFieldsNotListed.SuspendLayout()
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'flowFieldsNotListed
        '
        Me.flowFieldsNotListed.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.flowFieldsNotListed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flowFieldsNotListed.Controls.Add(Me.lblFieldsNotCurrentlyShownHdr)
        Me.flowFieldsNotListed.Location = New System.Drawing.Point(989, 421)
        Me.flowFieldsNotListed.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.flowFieldsNotListed.Name = "flowFieldsNotListed"
        Me.flowFieldsNotListed.Size = New System.Drawing.Size(449, 102)
        Me.flowFieldsNotListed.TabIndex = 56
        '
        'lblFieldsNotCurrentlyShownHdr
        '
        Me.lblFieldsNotCurrentlyShownHdr.AutoSize = True
        Me.lblFieldsNotCurrentlyShownHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFieldsNotCurrentlyShownHdr.Location = New System.Drawing.Point(4, 0)
        Me.lblFieldsNotCurrentlyShownHdr.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFieldsNotCurrentlyShownHdr.Name = "lblFieldsNotCurrentlyShownHdr"
        Me.lblFieldsNotCurrentlyShownHdr.Size = New System.Drawing.Size(160, 18)
        Me.lblFieldsNotCurrentlyShownHdr.TabIndex = 0
        Me.lblFieldsNotCurrentlyShownHdr.Text = "Fields not yet displayed"
        '
        'picturePreview
        '
        Me.picturePreview.BackColor = System.Drawing.Color.White
        Me.picturePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePreview.Location = New System.Drawing.Point(989, 74)
        Me.picturePreview.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.picturePreview.Name = "picturePreview"
        Me.picturePreview.Size = New System.Drawing.Size(622, 339)
        Me.picturePreview.TabIndex = 55
        Me.picturePreview.TabStop = False
        '
        'pictureBack
        '
        Me.pictureBack.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pictureBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBack.Image = CType(resources.GetObject("pictureBack.Image"), System.Drawing.Image)
        Me.pictureBack.Location = New System.Drawing.Point(48, 47)
        Me.pictureBack.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pictureBack.Name = "pictureBack"
        Me.pictureBack.Size = New System.Drawing.Size(907, 523)
        Me.pictureBack.TabIndex = 53
        Me.pictureBack.TabStop = False
        '
        'CtlGraphicPortrait_Lady
        '
        Me.CtlGraphicPortrait_Lady.Location = New System.Drawing.Point(733, 55)
        Me.CtlGraphicPortrait_Lady.Margin = New System.Windows.Forms.Padding(5)
        Me.CtlGraphicPortrait_Lady.Name = "CtlGraphicPortrait_Lady"
        Me.CtlGraphicPortrait_Lady.Size = New System.Drawing.Size(200, 224)
        Me.CtlGraphicPortrait_Lady.TabIndex = 54
        '
        'checkAutoPreview
        '
        Me.checkAutoPreview.AutoSize = True
        Me.checkAutoPreview.Checked = True
        Me.checkAutoPreview.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkAutoPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkAutoPreview.Location = New System.Drawing.Point(989, 35)
        Me.checkAutoPreview.Margin = New System.Windows.Forms.Padding(2)
        Me.checkAutoPreview.Name = "checkAutoPreview"
        Me.checkAutoPreview.Size = New System.Drawing.Size(117, 22)
        Me.checkAutoPreview.TabIndex = 57
        Me.checkAutoPreview.Text = "Auto-Preview"
        Me.checkAutoPreview.UseVisualStyleBackColor = True
        '
        'FormDesignProtoThree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1660, 725)
        Me.Controls.Add(Me.checkAutoPreview)
        Me.Controls.Add(Me.flowFieldsNotListed)
        Me.Controls.Add(Me.picturePreview)
        Me.Controls.Add(Me.CtlGraphicPortrait_Lady)
        Me.Controls.Add(Me.pictureBack)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormDesignProtoThree"
        Me.Text = "FormDesignProtoThree"
        Me.flowFieldsNotListed.ResumeLayout(False)
        Me.flowFieldsNotListed.PerformLayout()
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents flowFieldsNotListed As FlowLayoutPanel
    Friend WithEvents lblFieldsNotCurrentlyShownHdr As Label
    Friend WithEvents picturePreview As PictureBox
    Friend WithEvents CtlGraphicPortrait_Lady As CtlGraphicPortrait
    Friend WithEvents pictureBack As PictureBox
    Friend WithEvents checkAutoPreview As CheckBox
End Class
