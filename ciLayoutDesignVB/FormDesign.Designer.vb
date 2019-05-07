<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDesign
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDesign))
        Me.linkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.linkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.radioButton2 = New System.Windows.Forms.RadioButton()
        Me.radioButton1 = New System.Windows.Forms.RadioButton()
        Me.labelLayoutDesignHdr1 = New System.Windows.Forms.Label()
        Me.panelLayout = New System.Windows.Forms.Panel()
        Me.picPortrait = New System.Windows.Forms.PictureBox()
        Me.LabelDefault2 = New System.Windows.Forms.Label()
        Me.labelDefault1 = New System.Windows.Forms.Label()
        Me.ButtonGenerateImage = New System.Windows.Forms.Button()
        Me.panelLayout.SuspendLayout()
        CType(Me.picPortrait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'linkLabel3
        '
        Me.linkLabel3.AutoSize = True
        Me.linkLabel3.Location = New System.Drawing.Point(36, 457)
        Me.linkLabel3.Name = "linkLabel3"
        Me.linkLabel3.Size = New System.Drawing.Size(422, 13)
        Me.linkLabel3.TabIndex = 17
        Me.linkLabel3.TabStop = True
        Me.linkLabel3.Text = "https://www.codeproject.com/articles/38137/easy-drag-and-drop-of-controls-at-run-" &
    "time"
        '
        'linkLabel2
        '
        Me.linkLabel2.AutoSize = True
        Me.linkLabel2.Location = New System.Drawing.Point(31, 517)
        Me.linkLabel2.Name = "linkLabel2"
        Me.linkLabel2.Size = New System.Drawing.Size(427, 13)
        Me.linkLabel2.TabIndex = 16
        Me.linkLabel2.TabStop = True
        Me.linkLabel2.Text = "https://stackoverflow.com/questions/8022174/how-can-i-write-on-an-image-using-vb-" &
    "net"
        '
        'linkLabel1
        '
        Me.linkLabel1.AutoSize = True
        Me.linkLabel1.Location = New System.Drawing.Point(26, 488)
        Me.linkLabel1.Name = "linkLabel1"
        Me.linkLabel1.Size = New System.Drawing.Size(616, 13)
        Me.linkLabel1.TabIndex = 15
        Me.linkLabel1.TabStop = True
        Me.linkLabel1.Text = "https://www.experts-exchange.com/questions/28618021/how-to-print-a-jpg-file-using" &
    "-vb-net-without-showing-the-print-dialog.html"
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(17, 89)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(173, 23)
        Me.button2.TabIndex = 14
        Me.button2.Text = "Select Background Image"
        Me.button2.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(17, 118)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(144, 23)
        Me.button1.TabIndex = 13
        Me.button1.Text = "Add a Label"
        Me.button1.UseVisualStyleBackColor = True
        '
        'radioButton2
        '
        Me.radioButton2.AutoSize = True
        Me.radioButton2.Location = New System.Drawing.Point(17, 170)
        Me.radioButton2.Name = "radioButton2"
        Me.radioButton2.Size = New System.Drawing.Size(78, 17)
        Me.radioButton2.TabIndex = 12
        Me.radioButton2.Text = "Landscape"
        Me.radioButton2.UseVisualStyleBackColor = True
        '
        'radioButton1
        '
        Me.radioButton1.AutoSize = True
        Me.radioButton1.Checked = True
        Me.radioButton1.Location = New System.Drawing.Point(17, 147)
        Me.radioButton1.Name = "radioButton1"
        Me.radioButton1.Size = New System.Drawing.Size(58, 17)
        Me.radioButton1.TabIndex = 11
        Me.radioButton1.TabStop = True
        Me.radioButton1.Text = "Portrait"
        Me.radioButton1.UseVisualStyleBackColor = True
        '
        'labelLayoutDesignHdr1
        '
        Me.labelLayoutDesignHdr1.AutoSize = True
        Me.labelLayoutDesignHdr1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelLayoutDesignHdr1.Location = New System.Drawing.Point(12, 27)
        Me.labelLayoutDesignHdr1.Name = "labelLayoutDesignHdr1"
        Me.labelLayoutDesignHdr1.Size = New System.Drawing.Size(197, 29)
        Me.labelLayoutDesignHdr1.TabIndex = 10
        Me.labelLayoutDesignHdr1.Text = "Layout Designer"
        '
        'panelLayout
        '
        Me.panelLayout.BackColor = System.Drawing.Color.White
        Me.panelLayout.BackgroundImage = CType(resources.GetObject("panelLayout.BackgroundImage"), System.Drawing.Image)
        Me.panelLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.panelLayout.Controls.Add(Me.picPortrait)
        Me.panelLayout.Controls.Add(Me.LabelDefault2)
        Me.panelLayout.Controls.Add(Me.labelDefault1)
        Me.panelLayout.Location = New System.Drawing.Point(283, 36)
        Me.panelLayout.Name = "panelLayout"
        Me.panelLayout.Size = New System.Drawing.Size(644, 400)
        Me.panelLayout.TabIndex = 9
        '
        'picPortrait
        '
        Me.picPortrait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picPortrait.Location = New System.Drawing.Point(433, 23)
        Me.picPortrait.Name = "picPortrait"
        Me.picPortrait.Size = New System.Drawing.Size(170, 220)
        Me.picPortrait.TabIndex = 2
        Me.picPortrait.TabStop = False
        '
        'LabelDefault2
        '
        Me.LabelDefault2.AutoSize = True
        Me.LabelDefault2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDefault2.Location = New System.Drawing.Point(24, 284)
        Me.LabelDefault2.Name = "LabelDefault2"
        Me.LabelDefault2.Size = New System.Drawing.Size(179, 19)
        Me.LabelDefault2.TabIndex = 1
        Me.LabelDefault2.Text = "Student or Employee ID"
        '
        'labelDefault1
        '
        Me.labelDefault1.AutoSize = True
        Me.labelDefault1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelDefault1.Location = New System.Drawing.Point(24, 345)
        Me.labelDefault1.Name = "labelDefault1"
        Me.labelDefault1.Size = New System.Drawing.Size(203, 19)
        Me.labelDefault1.TabIndex = 0
        Me.labelDefault1.Text = "Student or Employee Name"
        '
        'ButtonGenerateImage
        '
        Me.ButtonGenerateImage.Location = New System.Drawing.Point(19, 413)
        Me.ButtonGenerateImage.Name = "ButtonGenerateImage"
        Me.ButtonGenerateImage.Size = New System.Drawing.Size(210, 23)
        Me.ButtonGenerateImage.TabIndex = 18
        Me.ButtonGenerateImage.Text = "Generate Image To Print (Test)"
        Me.ButtonGenerateImage.UseVisualStyleBackColor = True
        '
        'FormDesign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 544)
        Me.Controls.Add(Me.ButtonGenerateImage)
        Me.Controls.Add(Me.linkLabel3)
        Me.Controls.Add(Me.linkLabel2)
        Me.Controls.Add(Me.linkLabel1)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.radioButton2)
        Me.Controls.Add(Me.radioButton1)
        Me.Controls.Add(Me.labelLayoutDesignHdr1)
        Me.Controls.Add(Me.panelLayout)
        Me.Name = "FormDesign"
        Me.Text = "Form1"
        Me.panelLayout.ResumeLayout(False)
        Me.panelLayout.PerformLayout()
        CType(Me.picPortrait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents linkLabel3 As LinkLabel
    Private WithEvents linkLabel2 As LinkLabel
    Private WithEvents linkLabel1 As LinkLabel
    Private WithEvents button2 As Button
    Private WithEvents button1 As Button
    Private WithEvents radioButton2 As RadioButton
    Private WithEvents radioButton1 As RadioButton
    Private WithEvents labelLayoutDesignHdr1 As Label
    Private WithEvents panelLayout As Panel
    Private WithEvents labelDefault1 As Label
    Private WithEvents ButtonGenerateImage As Button
    Private WithEvents LabelDefault2 As Label
    Friend WithEvents picPortrait As PictureBox
End Class
