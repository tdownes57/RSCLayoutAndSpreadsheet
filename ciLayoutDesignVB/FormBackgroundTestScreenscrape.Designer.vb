<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBackgroundTestScreenscrape
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
        Me.pictureLeft = New System.Windows.Forms.PictureBox()
        Me.pictureRight = New System.Windows.Forms.PictureBox()
        Me.LinkLoadLeft = New System.Windows.Forms.LinkLabel()
        Me.LinkLoadViaScrape = New System.Windows.Forms.LinkLabel()
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.LinkToStackOverflow = New System.Windows.Forms.LinkLabel()
        Me.LinkSizeModeZoom = New System.Windows.Forms.LinkLabel()
        Me.LinkSizeModeStretch = New System.Windows.Forms.LinkLabel()
        Me.LinkSizeModeAuto = New System.Windows.Forms.LinkLabel()
        Me.LinkSizeModeNormal = New System.Windows.Forms.LinkLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.LinkBackcolorMistyRose = New System.Windows.Forms.LinkLabel()
        Me.LinkBackcolorWhite = New System.Windows.Forms.LinkLabel()
        Me.LinkRemoveBorder = New System.Windows.Forms.LinkLabel()
        Me.LinkAddBorder = New System.Windows.Forms.LinkLabel()
        Me.checkOmitBorder = New System.Windows.Forms.CheckBox()
        CType(Me.pictureLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureLeft
        '
        Me.pictureLeft.BackColor = System.Drawing.Color.White
        Me.pictureLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictureLeft.Location = New System.Drawing.Point(54, 71)
        Me.pictureLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.pictureLeft.Name = "pictureLeft"
        Me.pictureLeft.Size = New System.Drawing.Size(318, 210)
        Me.pictureLeft.TabIndex = 46
        Me.pictureLeft.TabStop = False
        '
        'pictureRight
        '
        Me.pictureRight.BackColor = System.Drawing.Color.MistyRose
        Me.pictureRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictureRight.Location = New System.Drawing.Point(389, 71)
        Me.pictureRight.Margin = New System.Windows.Forms.Padding(2)
        Me.pictureRight.Name = "pictureRight"
        Me.pictureRight.Size = New System.Drawing.Size(463, 267)
        Me.pictureRight.TabIndex = 47
        Me.pictureRight.TabStop = False
        '
        'LinkLoadLeft
        '
        Me.LinkLoadLeft.AutoSize = True
        Me.LinkLoadLeft.Location = New System.Drawing.Point(51, 292)
        Me.LinkLoadLeft.Name = "LinkLoadLeft"
        Me.LinkLoadLeft.Size = New System.Drawing.Size(111, 13)
        Me.LinkLoadLeft.TabIndex = 48
        Me.LinkLoadLeft.TabStop = True
        Me.LinkLoadLeft.Text = "Load from PC / laptop"
        '
        'LinkLoadViaScrape
        '
        Me.LinkLoadViaScrape.AutoSize = True
        Me.LinkLoadViaScrape.Location = New System.Drawing.Point(386, 340)
        Me.LinkLoadViaScrape.Name = "LinkLoadViaScrape"
        Me.LinkLoadViaScrape.Size = New System.Drawing.Size(167, 13)
        Me.LinkLoadViaScrape.TabIndex = 49
        Me.LinkLoadViaScrape.TabStop = True
        Me.LinkLoadViaScrape.Text = "Load via screengrab / screenshot"
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(12, 9)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(442, 31)
        Me.LabelHeader1.TabIndex = 50
        Me.LabelHeader1.Text = "Editing via Screengrab / screenshot"
        '
        'LinkToStackOverflow
        '
        Me.LinkToStackOverflow.AutoSize = True
        Me.LinkToStackOverflow.Location = New System.Drawing.Point(315, 40)
        Me.LinkToStackOverflow.Name = "LinkToStackOverflow"
        Me.LinkToStackOverflow.Size = New System.Drawing.Size(402, 13)
        Me.LinkToStackOverflow.TabIndex = 51
        Me.LinkToStackOverflow.TabStop = True
        Me.LinkToStackOverflow.Text = "https://stackoverflow.com/questions/10930569/high-quality-full-screenshots-vb-net" &
    ""
        '
        'LinkSizeModeZoom
        '
        Me.LinkSizeModeZoom.AutoSize = True
        Me.LinkSizeModeZoom.Location = New System.Drawing.Point(261, 292)
        Me.LinkSizeModeZoom.Name = "LinkSizeModeZoom"
        Me.LinkSizeModeZoom.Size = New System.Drawing.Size(34, 13)
        Me.LinkSizeModeZoom.TabIndex = 52
        Me.LinkSizeModeZoom.TabStop = True
        Me.LinkSizeModeZoom.Text = "Zoom"
        '
        'LinkSizeModeStretch
        '
        Me.LinkSizeModeStretch.AutoSize = True
        Me.LinkSizeModeStretch.Location = New System.Drawing.Point(261, 316)
        Me.LinkSizeModeStretch.Name = "LinkSizeModeStretch"
        Me.LinkSizeModeStretch.Size = New System.Drawing.Size(41, 13)
        Me.LinkSizeModeStretch.TabIndex = 53
        Me.LinkSizeModeStretch.TabStop = True
        Me.LinkSizeModeStretch.Text = "Stretch"
        '
        'LinkSizeModeAuto
        '
        Me.LinkSizeModeAuto.AutoSize = True
        Me.LinkSizeModeAuto.Location = New System.Drawing.Point(261, 340)
        Me.LinkSizeModeAuto.Name = "LinkSizeModeAuto"
        Me.LinkSizeModeAuto.Size = New System.Drawing.Size(49, 13)
        Me.LinkSizeModeAuto.TabIndex = 54
        Me.LinkSizeModeAuto.TabStop = True
        Me.LinkSizeModeAuto.Text = "AutoSize"
        '
        'LinkSizeModeNormal
        '
        Me.LinkSizeModeNormal.AutoSize = True
        Me.LinkSizeModeNormal.Location = New System.Drawing.Point(261, 362)
        Me.LinkSizeModeNormal.Name = "LinkSizeModeNormal"
        Me.LinkSizeModeNormal.Size = New System.Drawing.Size(40, 13)
        Me.LinkSizeModeNormal.TabIndex = 55
        Me.LinkSizeModeNormal.TabStop = True
        Me.LinkSizeModeNormal.Text = "Normal"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'LinkBackcolorMistyRose
        '
        Me.LinkBackcolorMistyRose.AutoSize = True
        Me.LinkBackcolorMistyRose.Location = New System.Drawing.Point(603, 342)
        Me.LinkBackcolorMistyRose.Name = "LinkBackcolorMistyRose"
        Me.LinkBackcolorMistyRose.Size = New System.Drawing.Size(59, 13)
        Me.LinkBackcolorMistyRose.TabIndex = 56
        Me.LinkBackcolorMistyRose.TabStop = True
        Me.LinkBackcolorMistyRose.Text = "Misty Rose"
        '
        'LinkBackcolorWhite
        '
        Me.LinkBackcolorWhite.AutoSize = True
        Me.LinkBackcolorWhite.Location = New System.Drawing.Point(687, 342)
        Me.LinkBackcolorWhite.Name = "LinkBackcolorWhite"
        Me.LinkBackcolorWhite.Size = New System.Drawing.Size(35, 13)
        Me.LinkBackcolorWhite.TabIndex = 57
        Me.LinkBackcolorWhite.TabStop = True
        Me.LinkBackcolorWhite.Text = "White"
        '
        'LinkRemoveBorder
        '
        Me.LinkRemoveBorder.AutoSize = True
        Me.LinkRemoveBorder.Location = New System.Drawing.Point(72, 362)
        Me.LinkRemoveBorder.Name = "LinkRemoveBorder"
        Me.LinkRemoveBorder.Size = New System.Drawing.Size(81, 13)
        Me.LinkRemoveBorder.TabIndex = 59
        Me.LinkRemoveBorder.TabStop = True
        Me.LinkRemoveBorder.Text = "Remove Border"
        '
        'LinkAddBorder
        '
        Me.LinkAddBorder.AutoSize = True
        Me.LinkAddBorder.Location = New System.Drawing.Point(51, 340)
        Me.LinkAddBorder.Name = "LinkAddBorder"
        Me.LinkAddBorder.Size = New System.Drawing.Size(111, 13)
        Me.LinkAddBorder.TabIndex = 58
        Me.LinkAddBorder.TabStop = True
        Me.LinkAddBorder.Text = "Set PictureBox Border"
        '
        'checkOmitBorder
        '
        Me.checkOmitBorder.AutoSize = True
        Me.checkOmitBorder.Location = New System.Drawing.Point(461, 375)
        Me.checkOmitBorder.Name = "checkOmitBorder"
        Me.checkOmitBorder.Size = New System.Drawing.Size(203, 17)
        Me.checkOmitBorder.TabIndex = 60
        Me.checkOmitBorder.Text = "Try to omit/remove PictureBox Border"
        Me.checkOmitBorder.UseVisualStyleBackColor = True
        '
        'FormBackgroundTestScreenscrape
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 445)
        Me.Controls.Add(Me.checkOmitBorder)
        Me.Controls.Add(Me.LinkRemoveBorder)
        Me.Controls.Add(Me.LinkAddBorder)
        Me.Controls.Add(Me.LinkBackcolorWhite)
        Me.Controls.Add(Me.LinkBackcolorMistyRose)
        Me.Controls.Add(Me.LinkSizeModeNormal)
        Me.Controls.Add(Me.LinkSizeModeAuto)
        Me.Controls.Add(Me.LinkSizeModeStretch)
        Me.Controls.Add(Me.LinkSizeModeZoom)
        Me.Controls.Add(Me.LinkToStackOverflow)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Controls.Add(Me.LinkLoadViaScrape)
        Me.Controls.Add(Me.LinkLoadLeft)
        Me.Controls.Add(Me.pictureRight)
        Me.Controls.Add(Me.pictureLeft)
        Me.Name = "FormBackgroundTestScreenscrape"
        Me.Text = "FormBackgroundTestScreenscrape"
        CType(Me.pictureLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pictureLeft As PictureBox
    Friend WithEvents pictureRight As PictureBox
    Friend WithEvents LinkLoadLeft As LinkLabel
    Friend WithEvents LinkLoadViaScrape As LinkLabel
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents LinkToStackOverflow As LinkLabel
    Friend WithEvents LinkSizeModeZoom As LinkLabel
    Friend WithEvents LinkSizeModeStretch As LinkLabel
    Friend WithEvents LinkSizeModeAuto As LinkLabel
    Friend WithEvents LinkSizeModeNormal As LinkLabel
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents LinkBackcolorMistyRose As LinkLabel
    Friend WithEvents LinkBackcolorWhite As LinkLabel
    Friend WithEvents LinkRemoveBorder As LinkLabel
    Friend WithEvents LinkAddBorder As LinkLabel
    Friend WithEvents checkOmitBorder As CheckBox
End Class
