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
        Me.pictureBackgroundFront = New System.Windows.Forms.PictureBox()
        Me.LabelCaptionPathToTheFileXML = New System.Windows.Forms.Label()
        Me.LabelHeader3 = New System.Windows.Forms.Label()
        Me.LabelFullPathToXML = New System.Windows.Forms.Label()
        Me.ButtonOpenLayout = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ButtonSelectDrive = New System.Windows.Forms.Button()
        CType(Me.pictureBackgroundFront, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureBackgroundFront
        '
        Me.pictureBackgroundFront.BackColor = System.Drawing.Color.White
        Me.pictureBackgroundFront.Location = New System.Drawing.Point(214, 117)
        Me.pictureBackgroundFront.Name = "pictureBackgroundFront"
        Me.pictureBackgroundFront.Size = New System.Drawing.Size(603, 368)
        Me.pictureBackgroundFront.TabIndex = 75
        Me.pictureBackgroundFront.TabStop = False
        '
        'LabelCaptionPathToTheFileXML
        '
        Me.LabelCaptionPathToTheFileXML.AutoSize = True
        Me.LabelCaptionPathToTheFileXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCaptionPathToTheFileXML.Location = New System.Drawing.Point(211, 41)
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
        Me.LabelFullPathToXML.Location = New System.Drawing.Point(241, 68)
        Me.LabelFullPathToXML.Name = "LabelFullPathToXML"
        Me.LabelFullPathToXML.Size = New System.Drawing.Size(168, 18)
        Me.LabelFullPathToXML.TabIndex = 79
        Me.LabelFullPathToXML.Text = "\\.....Path to the XML file."
        '
        'ButtonOpenLayout
        '
        Me.ButtonOpenLayout.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOpenLayout.Location = New System.Drawing.Point(26, 117)
        Me.ButtonOpenLayout.Name = "ButtonOpenLayout"
        Me.ButtonOpenLayout.Size = New System.Drawing.Size(171, 89)
        Me.ButtonOpenLayout.TabIndex = 80
        Me.ButtonOpenLayout.Text = "Open This Layout ►►"
        Me.ButtonOpenLayout.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(26, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(171, 89)
        Me.Button2.TabIndex = 82
        Me.Button2.Text = "Open New Blank Layout"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(816, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 18)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Prior layouts:"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FlowLayoutPanel1.Controls.Add(Me.PictureBox1)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(844, 41)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(349, 444)
        Me.FlowLayoutPanel1.TabIndex = 84
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(312, 183)
        Me.PictureBox1.TabIndex = 76
        Me.PictureBox1.TabStop = False
        '
        'ButtonSelectDrive
        '
        Me.ButtonSelectDrive.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSelectDrive.Location = New System.Drawing.Point(26, 396)
        Me.ButtonSelectDrive.Name = "ButtonSelectDrive"
        Me.ButtonSelectDrive.Size = New System.Drawing.Size(171, 89)
        Me.ButtonSelectDrive.TabIndex = 85
        Me.ButtonSelectDrive.Text = "Find Layout in Drive(s)"
        Me.ButtonSelectDrive.UseVisualStyleBackColor = True
        '
        'FormDisplayCacheLayouts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1205, 503)
        Me.Controls.Add(Me.ButtonSelectDrive)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ButtonOpenLayout)
        Me.Controls.Add(Me.LabelFullPathToXML)
        Me.Controls.Add(Me.LabelHeader3)
        Me.Controls.Add(Me.LabelCaptionPathToTheFileXML)
        Me.Controls.Add(Me.pictureBackgroundFront)
        Me.Name = "FormDisplayCacheLayouts"
        Me.Text = "FormDisplayCacheLayouts"
        CType(Me.pictureBackgroundFront, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pictureBackgroundFront As PictureBox
    Friend WithEvents LabelCaptionPathToTheFileXML As Label
    Friend WithEvents LabelHeader3 As Label
    Friend WithEvents LabelFullPathToXML As Label
    Friend WithEvents ButtonOpenLayout As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ButtonSelectDrive As Button
End Class
