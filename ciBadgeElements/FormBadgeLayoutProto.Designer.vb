<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBadgeLayoutProto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBadgeLayoutProto))
        Me.pictureBack = New System.Windows.Forms.PictureBox()
        Me.picturePortrait = New System.Windows.Forms.PictureBox()
        Me.pictureQRCode = New System.Windows.Forms.PictureBox()
        Me.pictureSignature = New System.Windows.Forms.PictureBox()
        Me.labelText1 = New System.Windows.Forms.PictureBox()
        CType(Me.pictureBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picturePortrait, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.labelText1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureBack
        '
        Me.pictureBack.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pictureBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBack.Image = CType(resources.GetObject("pictureBack.Image"), System.Drawing.Image)
        Me.pictureBack.Location = New System.Drawing.Point(11, 11)
        Me.pictureBack.Margin = New System.Windows.Forms.Padding(2)
        Me.pictureBack.Name = "pictureBack"
        Me.pictureBack.Size = New System.Drawing.Size(681, 425)
        Me.pictureBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBack.TabIndex = 22
        Me.pictureBack.TabStop = False
        '
        'picturePortrait
        '
        Me.picturePortrait.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.picturePortrait.Image = CType(resources.GetObject("picturePortrait.Image"), System.Drawing.Image)
        Me.picturePortrait.Location = New System.Drawing.Point(205, 25)
        Me.picturePortrait.Margin = New System.Windows.Forms.Padding(4)
        Me.picturePortrait.Name = "picturePortrait"
        Me.picturePortrait.Size = New System.Drawing.Size(133, 166)
        Me.picturePortrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picturePortrait.TabIndex = 23
        Me.picturePortrait.TabStop = False
        '
        'pictureQRCode
        '
        Me.pictureQRCode.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pictureQRCode.Location = New System.Drawing.Point(492, 25)
        Me.pictureQRCode.Margin = New System.Windows.Forms.Padding(4)
        Me.pictureQRCode.Name = "pictureQRCode"
        Me.pictureQRCode.Size = New System.Drawing.Size(143, 137)
        Me.pictureQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureQRCode.TabIndex = 24
        Me.pictureQRCode.TabStop = False
        '
        'pictureSignature
        '
        Me.pictureSignature.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pictureSignature.Image = CType(resources.GetObject("pictureSignature.Image"), System.Drawing.Image)
        Me.pictureSignature.Location = New System.Drawing.Point(380, 332)
        Me.pictureSignature.Margin = New System.Windows.Forms.Padding(4)
        Me.pictureSignature.Name = "pictureSignature"
        Me.pictureSignature.Size = New System.Drawing.Size(312, 104)
        Me.pictureSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureSignature.TabIndex = 25
        Me.pictureSignature.TabStop = False
        '
        'labelText1
        '
        Me.labelText1.BackColor = System.Drawing.Color.White
        Me.labelText1.Location = New System.Drawing.Point(13, 377)
        Me.labelText1.Margin = New System.Windows.Forms.Padding(4)
        Me.labelText1.Name = "labelText1"
        Me.labelText1.Size = New System.Drawing.Size(475, 39)
        Me.labelText1.TabIndex = 27
        Me.labelText1.TabStop = False
        '
        'FormBadgeLayoutProto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 457)
        Me.Controls.Add(Me.labelText1)
        Me.Controls.Add(Me.pictureSignature)
        Me.Controls.Add(Me.pictureQRCode)
        Me.Controls.Add(Me.picturePortrait)
        Me.Controls.Add(Me.pictureBack)
        Me.Name = "FormBadgeLayoutProto"
        Me.Text = "FormBadgeLayoutProto"
        CType(Me.pictureBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picturePortrait, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureSignature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.labelText1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents pictureBack As Windows.Forms.PictureBox
    Public WithEvents picturePortrait As Windows.Forms.PictureBox
    Public WithEvents pictureQRCode As Windows.Forms.PictureBox
    Public WithEvents pictureSignature As Windows.Forms.PictureBox
    Public WithEvents labelText1 As Windows.Forms.PictureBox
End Class
