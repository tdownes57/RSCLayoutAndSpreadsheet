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
        Me.CtlGraphicPortrait_Lady = New ciLayoutDesignVB.CtlGraphicPortrait()
        Me.pictureBack = New System.Windows.Forms.PictureBox()
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
        Me.flowFieldsNotListed.Location = New System.Drawing.Point(207, 468)
        Me.flowFieldsNotListed.Name = "flowFieldsNotListed"
        Me.flowFieldsNotListed.Size = New System.Drawing.Size(337, 83)
        Me.flowFieldsNotListed.TabIndex = 56
        '
        'lblFieldsNotCurrentlyShownHdr
        '
        Me.lblFieldsNotCurrentlyShownHdr.AutoSize = True
        Me.lblFieldsNotCurrentlyShownHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFieldsNotCurrentlyShownHdr.Location = New System.Drawing.Point(3, 0)
        Me.lblFieldsNotCurrentlyShownHdr.Name = "lblFieldsNotCurrentlyShownHdr"
        Me.lblFieldsNotCurrentlyShownHdr.Size = New System.Drawing.Size(133, 15)
        Me.lblFieldsNotCurrentlyShownHdr.TabIndex = 0
        Me.lblFieldsNotCurrentlyShownHdr.Text = "Fields not yet displayed"
        '
        'picturePreview
        '
        Me.picturePreview.BackColor = System.Drawing.Color.White
        Me.picturePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePreview.Location = New System.Drawing.Point(742, 60)
        Me.picturePreview.Name = "picturePreview"
        Me.picturePreview.Size = New System.Drawing.Size(467, 276)
        Me.picturePreview.TabIndex = 55
        Me.picturePreview.TabStop = False
        '
        'CtlGraphicPortrait_Lady
        '
        Me.CtlGraphicPortrait_Lady.Location = New System.Drawing.Point(550, 45)
        Me.CtlGraphicPortrait_Lady.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlGraphicPortrait_Lady.Name = "CtlGraphicPortrait_Lady"
        Me.CtlGraphicPortrait_Lady.Size = New System.Drawing.Size(150, 182)
        Me.CtlGraphicPortrait_Lady.TabIndex = 54
        '
        'pictureBack
        '
        Me.pictureBack.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pictureBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBack.Image = CType(resources.GetObject("pictureBack.Image"), System.Drawing.Image)
        Me.pictureBack.Location = New System.Drawing.Point(36, 38)
        Me.pictureBack.Margin = New System.Windows.Forms.Padding(2)
        Me.pictureBack.Name = "pictureBack"
        Me.pictureBack.Size = New System.Drawing.Size(681, 425)
        Me.pictureBack.TabIndex = 53
        Me.pictureBack.TabStop = False
        '
        'FormDesignProtoThree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1245, 589)
        Me.Controls.Add(Me.flowFieldsNotListed)
        Me.Controls.Add(Me.picturePreview)
        Me.Controls.Add(Me.CtlGraphicPortrait_Lady)
        Me.Controls.Add(Me.pictureBack)
        Me.Name = "FormDesignProtoThree"
        Me.Text = "FormDesignProtoThree"
        Me.flowFieldsNotListed.ResumeLayout(False)
        Me.flowFieldsNotListed.PerformLayout()
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents flowFieldsNotListed As FlowLayoutPanel
    Friend WithEvents lblFieldsNotCurrentlyShownHdr As Label
    Friend WithEvents picturePreview As PictureBox
    Friend WithEvents CtlGraphicPortrait_Lady As CtlGraphicPortrait
    Friend WithEvents pictureBack As PictureBox
End Class
