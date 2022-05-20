<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogDisplayIDCardSides
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
        Me.pictureBadgeFrontside = New System.Windows.Forms.PictureBox()
        Me.pictureBadgeBackside = New System.Windows.Forms.PictureBox()
        Me.labelProceedToBackside = New System.Windows.Forms.Label()
        Me.LabelReturnToFrontSide = New System.Windows.Forms.Label()
        Me.ButtonOK = New System.Windows.Forms.Button()
        CType(Me.pictureBadgeFrontside, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBadgeBackside, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureBadgeFrontside
        '
        Me.pictureBadgeFrontside.BackColor = System.Drawing.Color.White
        Me.pictureBadgeFrontside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBadgeFrontside.Location = New System.Drawing.Point(24, 54)
        Me.pictureBadgeFrontside.Name = "pictureBadgeFrontside"
        Me.pictureBadgeFrontside.Size = New System.Drawing.Size(603, 380)
        Me.pictureBadgeFrontside.TabIndex = 86
        Me.pictureBadgeFrontside.TabStop = False
        '
        'pictureBadgeBackside
        '
        Me.pictureBadgeBackside.BackColor = System.Drawing.Color.Silver
        Me.pictureBadgeBackside.Location = New System.Drawing.Point(81, 115)
        Me.pictureBadgeBackside.Name = "pictureBadgeBackside"
        Me.pictureBadgeBackside.Size = New System.Drawing.Size(622, 379)
        Me.pictureBadgeBackside.TabIndex = 87
        Me.pictureBadgeBackside.TabStop = False
        Me.pictureBadgeBackside.Visible = False
        '
        'labelProceedToBackside
        '
        Me.labelProceedToBackside.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelProceedToBackside.ForeColor = System.Drawing.Color.Navy
        Me.labelProceedToBackside.Location = New System.Drawing.Point(317, 27)
        Me.labelProceedToBackside.Name = "labelProceedToBackside"
        Me.labelProceedToBackside.Size = New System.Drawing.Size(309, 23)
        Me.labelProceedToBackside.TabIndex = 88
        Me.labelProceedToBackside.Tag = ">>> Show backside of ID Card."
        Me.labelProceedToBackside.Text = ">>> Show backside of ID Card."
        Me.labelProceedToBackside.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelReturnToFrontSide
        '
        Me.LabelReturnToFrontSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelReturnToFrontSide.ForeColor = System.Drawing.Color.Navy
        Me.LabelReturnToFrontSide.Location = New System.Drawing.Point(20, 28)
        Me.LabelReturnToFrontSide.Name = "LabelReturnToFrontSide"
        Me.LabelReturnToFrontSide.Size = New System.Drawing.Size(324, 23)
        Me.LabelReturnToFrontSide.TabIndex = 89
        Me.LabelReturnToFrontSide.Text = "<<< Return to front of ID Card."
        Me.LabelReturnToFrontSide.Visible = False
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(633, 499)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(127, 37)
        Me.ButtonOK.TabIndex = 92
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'DialogDisplayIDCardSides
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 547)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.labelProceedToBackside)
        Me.Controls.Add(Me.LabelReturnToFrontSide)
        Me.Controls.Add(Me.pictureBadgeFrontside)
        Me.Controls.Add(Me.pictureBadgeBackside)
        Me.Name = "DialogDisplayIDCardSides"
        Me.Text = "DialogDisplayIDCardSides"
        CType(Me.pictureBadgeFrontside, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBadgeBackside, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pictureBadgeFrontside As PictureBox
    Friend WithEvents pictureBadgeBackside As PictureBox
    Friend WithEvents labelProceedToBackside As Label
    Friend WithEvents LabelReturnToFrontSide As Label
    Friend WithEvents ButtonOK As Button
End Class
