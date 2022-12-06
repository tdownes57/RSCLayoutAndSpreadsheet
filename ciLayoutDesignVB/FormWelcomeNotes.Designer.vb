<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWelcomeNotes
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ButtonCancelEdits = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.LabelFooter1 = New System.Windows.Forms.Label()
        Me.pictureBoxLogo = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabelShowWarnings = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelTurnOffWarnings = New System.Windows.Forms.LinkLabel()
        Me.imgCIS = New System.Windows.Forms.PictureBox()
        CType(Me.pictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgCIS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(12, 250)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(541, 166)
        Me.TextBox1.TabIndex = 0
        '
        'ButtonCancelEdits
        '
        Me.ButtonCancelEdits.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancelEdits.Location = New System.Drawing.Point(631, 452)
        Me.ButtonCancelEdits.Name = "ButtonCancelEdits"
        Me.ButtonCancelEdits.Size = New System.Drawing.Size(157, 25)
        Me.ButtonCancelEdits.TabIndex = 1
        Me.ButtonCancelEdits.Text = "Cancel Any Edits Made"
        Me.ButtonCancelEdits.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(496, 443)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(129, 34)
        Me.ButtonOK.TabIndex = 2
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(425, 24)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(322, 31)
        Me.LabelHeader1.TabIndex = 3
        Me.LabelHeader1.Text = "Welcome to RSC ID Card"
        '
        'LabelFooter1
        '
        Me.LabelFooter1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelFooter1.AutoSize = True
        Me.LabelFooter1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFooter1.Location = New System.Drawing.Point(12, 443)
        Me.LabelFooter1.Name = "LabelFooter1"
        Me.LabelFooter1.Size = New System.Drawing.Size(286, 18)
        Me.LabelFooter1.TabIndex = 4
        Me.LabelFooter1.Text = "Pressing OK will save any edits you make."
        '
        'pictureBoxLogo
        '
        Me.pictureBoxLogo.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.feather_logo_RSC
        Me.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictureBoxLogo.Location = New System.Drawing.Point(569, 92)
        Me.pictureBoxLogo.Name = "pictureBoxLogo"
        Me.pictureBoxLogo.Size = New System.Drawing.Size(219, 324)
        Me.pictureBoxLogo.TabIndex = 5
        Me.pictureBoxLogo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(378, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(369, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "by R Software Consulting 123 / Thomas C. Downes"
        '
        'LinkLabelShowWarnings
        '
        Me.LinkLabelShowWarnings.AutoSize = True
        Me.LinkLabelShowWarnings.Location = New System.Drawing.Point(297, 444)
        Me.LinkLabelShowWarnings.Name = "LinkLabelShowWarnings"
        Me.LinkLabelShowWarnings.Size = New System.Drawing.Size(176, 13)
        Me.LinkLabelShowWarnings.TabIndex = 7
        Me.LinkLabelShowWarnings.TabStop = True
        Me.LinkLabelShowWarnings.Text = "Show Warnings / Debug Messages"
        '
        'LinkLabelTurnOffWarnings
        '
        Me.LinkLabelTurnOffWarnings.AutoSize = True
        Me.LinkLabelTurnOffWarnings.Location = New System.Drawing.Point(297, 458)
        Me.LinkLabelTurnOffWarnings.Name = "LinkLabelTurnOffWarnings"
        Me.LinkLabelTurnOffWarnings.Size = New System.Drawing.Size(193, 13)
        Me.LinkLabelTurnOffWarnings.TabIndex = 8
        Me.LinkLabelTurnOffWarnings.TabStop = True
        Me.LinkLabelTurnOffWarnings.Text = "Suppress Warnings / Debug Messages"
        Me.LinkLabelTurnOffWarnings.Visible = False
        '
        'imgCIS
        '
        Me.imgCIS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgCIS.Image = Global.ciLayoutDesignVB.My.Resources.Resources.RSC_IDs___Tags__FF__01
        Me.imgCIS.Location = New System.Drawing.Point(15, -24)
        Me.imgCIS.Name = "imgCIS"
        Me.imgCIS.Size = New System.Drawing.Size(331, 251)
        Me.imgCIS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgCIS.TabIndex = 18
        Me.imgCIS.TabStop = False
        '
        'FormWelcomeNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 489)
        Me.Controls.Add(Me.imgCIS)
        Me.Controls.Add(Me.LinkLabelTurnOffWarnings)
        Me.Controls.Add(Me.LinkLabelShowWarnings)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pictureBoxLogo)
        Me.Controls.Add(Me.LabelFooter1)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.ButtonCancelEdits)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "FormWelcomeNotes"
        Me.Text = "FormWelcomeNotes"
        CType(Me.pictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgCIS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ButtonCancelEdits As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents LabelFooter1 As Label
    Friend WithEvents pictureBoxLogo As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkLabelShowWarnings As LinkLabel
    Friend WithEvents LinkLabelTurnOffWarnings As LinkLabel
    Friend WithEvents imgCIS As PictureBox
End Class
