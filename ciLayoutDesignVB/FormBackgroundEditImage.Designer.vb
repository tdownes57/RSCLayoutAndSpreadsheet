<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBackgroundEditImage
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
        Me.components = New System.ComponentModel.Container()
        Me.pictureLayoutNormal = New System.Windows.Forms.PictureBox()
        Me.pictureLayoutCenter = New System.Windows.Forms.PictureBox()
        Me.pictureLayoutZoom = New System.Windows.Forms.PictureBox()
        Me.pictureLayoutStretch = New System.Windows.Forms.PictureBox()
        Me.LabelLayoutNone = New System.Windows.Forms.Label()
        Me.labelBackgroundCenter = New System.Windows.Forms.Label()
        Me.LabelBackgroundScarier = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.radioLayoutNormal = New System.Windows.Forms.RadioButton()
        Me.radioLayoutCenter = New System.Windows.Forms.RadioButton()
        Me.radioLayoutZoom = New System.Windows.Forms.RadioButton()
        Me.radioLayoutStretch = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picturePreview = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ButtonPushPreview = New System.Windows.Forms.Button()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.CtlMoveableBackground1 = New ciBadgeDesigner.CtlMoveableBackground()
        Me.LabelMoveableBackground = New System.Windows.Forms.Label()
        Me.radioLayoutMoveable = New System.Windows.Forms.RadioButton()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.pictureLayoutMoveable = New System.Windows.Forms.PictureBox()
        CType(Me.pictureLayoutNormal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureLayoutCenter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureLayoutZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureLayoutStretch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureLayoutMoveable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureLayoutNormal
        '
        Me.pictureLayoutNormal.BackColor = System.Drawing.Color.White
        Me.pictureLayoutNormal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pictureLayoutNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureLayoutNormal.Location = New System.Drawing.Point(28, 54)
        Me.pictureLayoutNormal.Margin = New System.Windows.Forms.Padding(2)
        Me.pictureLayoutNormal.Name = "pictureLayoutNormal"
        Me.pictureLayoutNormal.Size = New System.Drawing.Size(350, 225)
        Me.pictureLayoutNormal.TabIndex = 45
        Me.pictureLayoutNormal.TabStop = False
        '
        'pictureLayoutCenter
        '
        Me.pictureLayoutCenter.BackColor = System.Drawing.Color.White
        Me.pictureLayoutCenter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pictureLayoutCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureLayoutCenter.Location = New System.Drawing.Point(388, 54)
        Me.pictureLayoutCenter.Margin = New System.Windows.Forms.Padding(2)
        Me.pictureLayoutCenter.Name = "pictureLayoutCenter"
        Me.pictureLayoutCenter.Size = New System.Drawing.Size(350, 225)
        Me.pictureLayoutCenter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pictureLayoutCenter.TabIndex = 46
        Me.pictureLayoutCenter.TabStop = False
        '
        'pictureLayoutZoom
        '
        Me.pictureLayoutZoom.BackColor = System.Drawing.Color.White
        Me.pictureLayoutZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureLayoutZoom.Location = New System.Drawing.Point(31, 318)
        Me.pictureLayoutZoom.Margin = New System.Windows.Forms.Padding(2)
        Me.pictureLayoutZoom.Name = "pictureLayoutZoom"
        Me.pictureLayoutZoom.Size = New System.Drawing.Size(350, 226)
        Me.pictureLayoutZoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureLayoutZoom.TabIndex = 47
        Me.pictureLayoutZoom.TabStop = False
        '
        'pictureLayoutStretch
        '
        Me.pictureLayoutStretch.BackColor = System.Drawing.Color.White
        Me.pictureLayoutStretch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureLayoutStretch.Location = New System.Drawing.Point(389, 319)
        Me.pictureLayoutStretch.Margin = New System.Windows.Forms.Padding(2)
        Me.pictureLayoutStretch.Name = "pictureLayoutStretch"
        Me.pictureLayoutStretch.Size = New System.Drawing.Size(350, 225)
        Me.pictureLayoutStretch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureLayoutStretch.TabIndex = 48
        Me.pictureLayoutStretch.TabStop = False
        '
        'LabelLayoutNone
        '
        Me.LabelLayoutNone.AutoSize = True
        Me.LabelLayoutNone.Location = New System.Drawing.Point(28, 38)
        Me.LabelLayoutNone.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelLayoutNone.Name = "LabelLayoutNone"
        Me.LabelLayoutNone.Size = New System.Drawing.Size(174, 13)
        Me.LabelLayoutNone.TabIndex = 49
        Me.LabelLayoutNone.Text = "Background Image Layout:  Normal"
        '
        'labelBackgroundCenter
        '
        Me.labelBackgroundCenter.AutoSize = True
        Me.labelBackgroundCenter.Location = New System.Drawing.Point(386, 38)
        Me.labelBackgroundCenter.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.labelBackgroundCenter.Name = "labelBackgroundCenter"
        Me.labelBackgroundCenter.Size = New System.Drawing.Size(169, 13)
        Me.labelBackgroundCenter.TabIndex = 50
        Me.labelBackgroundCenter.Text = "Background Image Layout: Center"
        '
        'LabelBackgroundScarier
        '
        Me.LabelBackgroundScarier.AutoSize = True
        Me.LabelBackgroundScarier.Location = New System.Drawing.Point(28, 301)
        Me.LabelBackgroundScarier.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelBackgroundScarier.Name = "LabelBackgroundScarier"
        Me.LabelBackgroundScarier.Size = New System.Drawing.Size(165, 13)
        Me.LabelBackgroundScarier.TabIndex = 51
        Me.LabelBackgroundScarier.Text = "Background Image Layout: Zoom"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(386, 301)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(172, 13)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Background Image Layout: Stretch"
        '
        'radioLayoutNormal
        '
        Me.radioLayoutNormal.AutoSize = True
        Me.radioLayoutNormal.Location = New System.Drawing.Point(242, 36)
        Me.radioLayoutNormal.Margin = New System.Windows.Forms.Padding(2)
        Me.radioLayoutNormal.Name = "radioLayoutNormal"
        Me.radioLayoutNormal.Size = New System.Drawing.Size(89, 17)
        Me.radioLayoutNormal.TabIndex = 53
        Me.radioLayoutNormal.TabStop = True
        Me.radioLayoutNormal.Text = "Select below."
        Me.radioLayoutNormal.UseVisualStyleBackColor = True
        '
        'radioLayoutCenter
        '
        Me.radioLayoutCenter.AutoSize = True
        Me.radioLayoutCenter.Location = New System.Drawing.Point(614, 36)
        Me.radioLayoutCenter.Margin = New System.Windows.Forms.Padding(2)
        Me.radioLayoutCenter.Name = "radioLayoutCenter"
        Me.radioLayoutCenter.Size = New System.Drawing.Size(89, 17)
        Me.radioLayoutCenter.TabIndex = 54
        Me.radioLayoutCenter.TabStop = True
        Me.radioLayoutCenter.Text = "Select below."
        Me.radioLayoutCenter.UseVisualStyleBackColor = True
        '
        'radioLayoutZoom
        '
        Me.radioLayoutZoom.AutoSize = True
        Me.radioLayoutZoom.Location = New System.Drawing.Point(242, 299)
        Me.radioLayoutZoom.Margin = New System.Windows.Forms.Padding(2)
        Me.radioLayoutZoom.Name = "radioLayoutZoom"
        Me.radioLayoutZoom.Size = New System.Drawing.Size(89, 17)
        Me.radioLayoutZoom.TabIndex = 55
        Me.radioLayoutZoom.TabStop = True
        Me.radioLayoutZoom.Text = "Select below."
        Me.radioLayoutZoom.UseVisualStyleBackColor = True
        '
        'radioLayoutStretch
        '
        Me.radioLayoutStretch.AutoSize = True
        Me.radioLayoutStretch.Location = New System.Drawing.Point(614, 301)
        Me.radioLayoutStretch.Margin = New System.Windows.Forms.Padding(2)
        Me.radioLayoutStretch.Name = "radioLayoutStretch"
        Me.radioLayoutStretch.Size = New System.Drawing.Size(89, 17)
        Me.radioLayoutStretch.TabIndex = 56
        Me.radioLayoutStretch.TabStop = True
        Me.radioLayoutStretch.Text = "Select below."
        Me.radioLayoutStretch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(210, 17)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Select which Layout is best."
        '
        'picturePreview
        '
        Me.picturePreview.BackColor = System.Drawing.Color.White
        Me.picturePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePreview.Location = New System.Drawing.Point(749, 319)
        Me.picturePreview.Margin = New System.Windows.Forms.Padding(2)
        Me.picturePreview.Name = "picturePreview"
        Me.picturePreview.Size = New System.Drawing.Size(350, 225)
        Me.picturePreview.TabIndex = 64
        Me.picturePreview.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picturePreview, "Click the Preview box to update.")
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.GreenYellow
        Me.Label2.Font = New System.Drawing.Font("Franklin Gothic Medium", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(749, 287)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(350, 30)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "P R E V I E W"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Label2, "Click here to update the Preview box.")
        '
        'ButtonPushPreview
        '
        Me.ButtonPushPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPushPreview.BackColor = System.Drawing.Color.GreenYellow
        Me.ButtonPushPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPushPreview.Location = New System.Drawing.Point(749, 548)
        Me.ButtonPushPreview.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonPushPreview.Name = "ButtonPushPreview"
        Me.ButtonPushPreview.Size = New System.Drawing.Size(160, 28)
        Me.ButtonPushPreview.TabIndex = 61
        Me.ButtonPushPreview.Text = "Push Preview to All 5 Boxes"
        Me.ToolTip1.SetToolTip(Me.ButtonPushPreview, "This will allow you to make further adjustments.")
        Me.ButtonPushPreview.UseVisualStyleBackColor = False
        Me.ButtonPushPreview.Visible = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel2.Location = New System.Drawing.Point(558, 540)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(66, 25)
        Me.LinkLabel2.TabIndex = 67
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Undo Push"
        Me.LinkLabel2.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.GreenYellow
        Me.LinkLabel1.Location = New System.Drawing.Point(340, 531)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(45, 60)
        Me.LinkLabel1.TabIndex = 66
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Click to update Preview"
        Me.LinkLabel1.Visible = False
        '
        'CtlMoveableBackground1
        '
        Me.CtlMoveableBackground1.BackColor = System.Drawing.Color.White
        Me.CtlMoveableBackground1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CtlMoveableBackground1.Image_NotInUse = Nothing
        Me.CtlMoveableBackground1.ImageFileLocation = Nothing
        Me.CtlMoveableBackground1.Location = New System.Drawing.Point(749, 54)
        Me.CtlMoveableBackground1.Name = "CtlMoveableBackground1"
        Me.CtlMoveableBackground1.Size = New System.Drawing.Size(349, 225)
        Me.CtlMoveableBackground1.TabIndex = 68
        '
        'LabelMoveableBackground
        '
        Me.LabelMoveableBackground.AutoSize = True
        Me.LabelMoveableBackground.Location = New System.Drawing.Point(746, 38)
        Me.LabelMoveableBackground.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelMoveableBackground.Name = "LabelMoveableBackground"
        Me.LabelMoveableBackground.Size = New System.Drawing.Size(203, 13)
        Me.LabelMoveableBackground.TabIndex = 69
        Me.LabelMoveableBackground.Text = "Moveable--Click and drag to move image."
        '
        'radioLayoutMoveable
        '
        Me.radioLayoutMoveable.AutoSize = True
        Me.radioLayoutMoveable.Location = New System.Drawing.Point(1009, 36)
        Me.radioLayoutMoveable.Margin = New System.Windows.Forms.Padding(2)
        Me.radioLayoutMoveable.Name = "radioLayoutMoveable"
        Me.radioLayoutMoveable.Size = New System.Drawing.Size(89, 17)
        Me.radioLayoutMoveable.TabIndex = 70
        Me.radioLayoutMoveable.TabStop = True
        Me.radioLayoutMoveable.Text = "Select below."
        Me.radioLayoutMoveable.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.BackColor = System.Drawing.Color.Violet
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(1062, 589)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(129, 40)
        Me.ButtonCancel.TabIndex = 72
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.BackColor = System.Drawing.Color.MediumTurquoise
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(965, 589)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(91, 40)
        Me.ButtonOK.TabIndex = 71
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'pictureLayoutMoveable
        '
        Me.pictureLayoutMoveable.BackColor = System.Drawing.Color.White
        Me.pictureLayoutMoveable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pictureLayoutMoveable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureLayoutMoveable.Location = New System.Drawing.Point(749, 54)
        Me.pictureLayoutMoveable.Margin = New System.Windows.Forms.Padding(2)
        Me.pictureLayoutMoveable.Name = "pictureLayoutMoveable"
        Me.pictureLayoutMoveable.Size = New System.Drawing.Size(350, 225)
        Me.pictureLayoutMoveable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pictureLayoutMoveable.TabIndex = 73
        Me.pictureLayoutMoveable.TabStop = False
        '
        'FormBackgroundEditImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1203, 641)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.radioLayoutMoveable)
        Me.Controls.Add(Me.LabelMoveableBackground)
        Me.Controls.Add(Me.CtlMoveableBackground1)
        Me.Controls.Add(Me.picturePreview)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonPushPreview)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.radioLayoutStretch)
        Me.Controls.Add(Me.radioLayoutZoom)
        Me.Controls.Add(Me.radioLayoutCenter)
        Me.Controls.Add(Me.radioLayoutNormal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LabelBackgroundScarier)
        Me.Controls.Add(Me.labelBackgroundCenter)
        Me.Controls.Add(Me.LabelLayoutNone)
        Me.Controls.Add(Me.pictureLayoutStretch)
        Me.Controls.Add(Me.pictureLayoutZoom)
        Me.Controls.Add(Me.pictureLayoutCenter)
        Me.Controls.Add(Me.pictureLayoutNormal)
        Me.Controls.Add(Me.pictureLayoutMoveable)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FormBackgroundEditImage"
        Me.Text = "FormCroppingBackground"
        CType(Me.pictureLayoutNormal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureLayoutCenter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureLayoutZoom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureLayoutStretch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureLayoutMoveable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pictureLayoutNormal As PictureBox
    Friend WithEvents pictureLayoutCenter As PictureBox
    Friend WithEvents pictureLayoutZoom As PictureBox
    Friend WithEvents pictureLayoutStretch As PictureBox
    Friend WithEvents LabelLayoutNone As Label
    Friend WithEvents labelBackgroundCenter As Label
    Friend WithEvents LabelBackgroundScarier As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents radioLayoutNormal As RadioButton
    Friend WithEvents radioLayoutCenter As RadioButton
    Friend WithEvents radioLayoutZoom As RadioButton
    Friend WithEvents radioLayoutStretch As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents picturePreview As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents ButtonPushPreview As Button
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents CtlMoveableBackground1 As ciBadgeDesigner.CtlMoveableBackground
    Friend WithEvents LabelMoveableBackground As Label
    Friend WithEvents radioLayoutMoveable As RadioButton
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents pictureLayoutMoveable As PictureBox
End Class
