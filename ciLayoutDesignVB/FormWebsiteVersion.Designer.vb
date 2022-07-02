<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWebsiteVersion
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
        Me.LabelMainHeading = New System.Windows.Forms.Label()
        Me.LabelHeader2 = New System.Windows.Forms.Label()
        Me.pictureBackgroundFront = New System.Windows.Forms.PictureBox()
        CType(Me.pictureBackgroundFront, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelMainHeading
        '
        Me.LabelMainHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMainHeading.ForeColor = System.Drawing.Color.Navy
        Me.LabelMainHeading.Location = New System.Drawing.Point(12, 9)
        Me.LabelMainHeading.Name = "LabelMainHeading"
        Me.LabelMainHeading.Size = New System.Drawing.Size(587, 34)
        Me.LabelMainHeading.TabIndex = 105
        Me.LabelMainHeading.Text = "RSC ID Card Designer--Website Version"
        '
        'LabelHeader2
        '
        Me.LabelHeader2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader2.ForeColor = System.Drawing.Color.Navy
        Me.LabelHeader2.Location = New System.Drawing.Point(39, 43)
        Me.LabelHeader2.Name = "LabelHeader2"
        Me.LabelHeader2.Size = New System.Drawing.Size(587, 61)
        Me.LabelHeader2.TabIndex = 106
        Me.LabelHeader2.Text = "Before resizing or moving an element, it must be selected.  A new window will ope" &
    "n with the selected control highlighted."
        '
        'pictureBackgroundFront
        '
        Me.pictureBackgroundFront.BackColor = System.Drawing.Color.White
        Me.pictureBackgroundFront.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBackgroundFront.Location = New System.Drawing.Point(18, 107)
        Me.pictureBackgroundFront.Name = "pictureBackgroundFront"
        Me.pictureBackgroundFront.Size = New System.Drawing.Size(603, 380)
        Me.pictureBackgroundFront.TabIndex = 107
        Me.pictureBackgroundFront.TabStop = False
        '
        'FormWebsiteVersion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(962, 552)
        Me.Controls.Add(Me.pictureBackgroundFront)
        Me.Controls.Add(Me.LabelHeader2)
        Me.Controls.Add(Me.LabelMainHeading)
        Me.Name = "FormWebsiteVersion"
        Me.Text = "FormWebsiteVersion"
        CType(Me.pictureBackgroundFront, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelMainHeading As Label
    Friend WithEvents LabelHeader2 As Label
    Friend WithEvents pictureBackgroundFront As PictureBox
End Class
