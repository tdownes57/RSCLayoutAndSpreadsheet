<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditImagePlacement
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
        Me.picturePreview = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.LabelLayoutNone = New System.Windows.Forms.Label()
        Me.labelBackgroundCenter = New System.Windows.Forms.Label()
        Me.LabelBackgroundScarier = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CtlAdjustImageOffset1 = New ciLayoutDesignVB.CtlAdjustImageOffset()
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.buttonOK = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picturePreview
        '
        Me.picturePreview.BackColor = System.Drawing.Color.White
        Me.picturePreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picturePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePreview.Location = New System.Drawing.Point(38, 67)
        Me.picturePreview.Name = "picturePreview"
        Me.picturePreview.Size = New System.Drawing.Size(466, 277)
        Me.picturePreview.TabIndex = 45
        Me.picturePreview.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(1104, 67)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(466, 277)
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Location = New System.Drawing.Point(41, 392)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(466, 277)
        Me.PictureBox2.TabIndex = 47
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.White
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(1104, 392)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(466, 277)
        Me.PictureBox3.TabIndex = 48
        Me.PictureBox3.TabStop = False
        '
        'LabelLayoutNone
        '
        Me.LabelLayoutNone.AutoSize = True
        Me.LabelLayoutNone.Location = New System.Drawing.Point(38, 47)
        Me.LabelLayoutNone.Name = "LabelLayoutNone"
        Me.LabelLayoutNone.Size = New System.Drawing.Size(219, 17)
        Me.LabelLayoutNone.TabIndex = 49
        Me.LabelLayoutNone.Text = "Background Image Layout:  None"
        '
        'labelBackgroundCenter
        '
        Me.labelBackgroundCenter.AutoSize = True
        Me.labelBackgroundCenter.Location = New System.Drawing.Point(1101, 47)
        Me.labelBackgroundCenter.Name = "labelBackgroundCenter"
        Me.labelBackgroundCenter.Size = New System.Drawing.Size(223, 17)
        Me.labelBackgroundCenter.TabIndex = 50
        Me.labelBackgroundCenter.Text = "Background Image Layout: Center"
        '
        'LabelBackgroundScarier
        '
        Me.LabelBackgroundScarier.AutoSize = True
        Me.LabelBackgroundScarier.Location = New System.Drawing.Point(38, 361)
        Me.LabelBackgroundScarier.Name = "LabelBackgroundScarier"
        Me.LabelBackgroundScarier.Size = New System.Drawing.Size(217, 17)
        Me.LabelBackgroundScarier.TabIndex = 51
        Me.LabelBackgroundScarier.Text = "Background Image Layout: Zoom"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1101, 361)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(226, 17)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Background Image Layout: Stretch"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(323, 40)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(112, 21)
        Me.RadioButton1.TabIndex = 53
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Select below."
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(1340, 43)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(112, 21)
        Me.RadioButton2.TabIndex = 54
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Select below."
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(323, 365)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(112, 21)
        Me.RadioButton3.TabIndex = 55
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Select below."
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(1329, 365)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(112, 21)
        Me.RadioButton4.TabIndex = 56
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Select below."
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(246, 20)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Select which Layout is best."
        '
        'CtlAdjustImageOffset1
        '
        Me.CtlAdjustImageOffset1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlAdjustImageOffset1.Location = New System.Drawing.Point(524, 8)
        Me.CtlAdjustImageOffset1.Name = "CtlAdjustImageOffset1"
        Me.CtlAdjustImageOffset1.Size = New System.Drawing.Size(552, 401)
        Me.CtlAdjustImageOffset1.TabIndex = 58
        '
        'buttonCancel
        '
        Me.buttonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonCancel.Location = New System.Drawing.Point(990, 654)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(108, 34)
        Me.buttonCancel.TabIndex = 60
        Me.buttonCancel.Text = "Cancel"
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'buttonOK
        '
        Me.buttonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonOK.Location = New System.Drawing.Point(876, 655)
        Me.buttonOK.Name = "buttonOK"
        Me.buttonOK.Size = New System.Drawing.Size(108, 34)
        Me.buttonOK.TabIndex = 59
        Me.buttonOK.Text = "OK"
        Me.buttonOK.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.GreenYellow
        Me.Button1.Location = New System.Drawing.Point(524, 654)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(252, 34)
        Me.Button1.TabIndex = 61
        Me.Button1.Text = "Push Preview to All 5 Boxes"
        Me.ToolTip1.SetToolTip(Me.Button1, "This will allow you to make further adjustments.")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(524, 415)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(115, 21)
        Me.RadioButton5.TabIndex = 62
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "Select above."
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.White
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox4.Location = New System.Drawing.Point(688, 415)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(388, 231)
        Me.PictureBox4.TabIndex = 64
        Me.PictureBox4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox4, "Click the Preview box to update.")
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.GreenYellow
        Me.Label2.Font = New System.Drawing.Font("Franklin Gothic Medium", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(646, 420)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 231)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "P R E V I E W"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Label2, "Click here to update the Preview box.")
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.GreenYellow
        Me.LinkLabel1.Location = New System.Drawing.Point(580, 577)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(60, 74)
        Me.LinkLabel1.TabIndex = 66
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Click to update Preview"
        '
        'FormEditImagePlacement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1609, 701)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.RadioButton5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.buttonCancel)
        Me.Controls.Add(Me.buttonOK)
        Me.Controls.Add(Me.CtlAdjustImageOffset1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LabelBackgroundScarier)
        Me.Controls.Add(Me.labelBackgroundCenter)
        Me.Controls.Add(Me.LabelLayoutNone)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.picturePreview)
        Me.Name = "FormEditImagePlacement"
        Me.Text = "FormCroppingBackground"
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picturePreview As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents LabelLayoutNone As Label
    Friend WithEvents labelBackgroundCenter As Label
    Friend WithEvents LabelBackgroundScarier As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents CtlAdjustImageOffset1 As CtlAdjustImageOffset
    Friend WithEvents buttonCancel As Button
    Friend WithEvents buttonOK As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
