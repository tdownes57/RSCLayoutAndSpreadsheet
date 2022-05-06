<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRandomLocation
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
        Me.LabelHeaderDescription = New System.Windows.Forms.Label()
        Me.LabelHeading1 = New System.Windows.Forms.Label()
        Me.LabelParenthetical = New System.Windows.Forms.Label()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonRandomize = New System.Windows.Forms.Button()
        CType(Me.pictureBackgroundFront, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureBackgroundFront
        '
        Me.pictureBackgroundFront.BackColor = System.Drawing.Color.White
        Me.pictureBackgroundFront.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.Badge001
        Me.pictureBackgroundFront.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictureBackgroundFront.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBackgroundFront.Location = New System.Drawing.Point(17, 92)
        Me.pictureBackgroundFront.Name = "pictureBackgroundFront"
        Me.pictureBackgroundFront.Size = New System.Drawing.Size(603, 380)
        Me.pictureBackgroundFront.TabIndex = 75
        Me.pictureBackgroundFront.TabStop = False
        '
        'LabelHeaderDescription
        '
        Me.LabelHeaderDescription.AutoSize = True
        Me.LabelHeaderDescription.Location = New System.Drawing.Point(12, 44)
        Me.LabelHeaderDescription.Name = "LabelHeaderDescription"
        Me.LabelHeaderDescription.Size = New System.Drawing.Size(466, 13)
        Me.LabelHeaderDescription.TabIndex = 76
        Me.LabelHeaderDescription.Text = "A random location has been selected.   Press the button ""Try another..."" to try a" &
    " different location."
        '
        'LabelHeading1
        '
        Me.LabelHeading1.AutoSize = True
        Me.LabelHeading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeading1.Location = New System.Drawing.Point(12, 9)
        Me.LabelHeading1.Name = "LabelHeading1"
        Me.LabelHeading1.Size = New System.Drawing.Size(406, 29)
        Me.LabelHeading1.TabIndex = 77
        Me.LabelHeading1.Text = "Random Location Generator (Only)"
        '
        'LabelParenthetical
        '
        Me.LabelParenthetical.AutoSize = True
        Me.LabelParenthetical.Location = New System.Drawing.Point(26, 66)
        Me.LabelParenthetical.Name = "LabelParenthetical"
        Me.LabelParenthetical.Size = New System.Drawing.Size(517, 13)
        Me.LabelParenthetical.TabIndex = 78
        Me.LabelParenthetical.Text = "(Please note, this dialog form is NOT a layout-designer.  It purposefully simple " &
    "&& lacks functionality by design.)"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(509, 477)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(131, 37)
        Me.ButtonCancel.TabIndex = 93
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(376, 477)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(127, 37)
        Me.ButtonOK.TabIndex = 92
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonRandomize
        '
        Me.ButtonRandomize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonRandomize.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonRandomize.Location = New System.Drawing.Point(17, 478)
        Me.ButtonRandomize.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonRandomize.Name = "ButtonRandomize"
        Me.ButtonRandomize.Size = New System.Drawing.Size(326, 37)
        Me.ButtonRandomize.TabIndex = 94
        Me.ButtonRandomize.Text = "Try another random location!!"
        Me.ButtonRandomize.UseVisualStyleBackColor = True
        '
        'FormRandomLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 526)
        Me.Controls.Add(Me.ButtonRandomize)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.LabelParenthetical)
        Me.Controls.Add(Me.LabelHeading1)
        Me.Controls.Add(Me.LabelHeaderDescription)
        Me.Controls.Add(Me.pictureBackgroundFront)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRandomLocation"
        Me.Text = "Random Location Generator"
        CType(Me.pictureBackgroundFront, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pictureBackgroundFront As PictureBox
    Friend WithEvents LabelHeaderDescription As Label
    Friend WithEvents LabelHeading1 As Label
    Friend WithEvents LabelParenthetical As Label
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonRandomize As Button
End Class
