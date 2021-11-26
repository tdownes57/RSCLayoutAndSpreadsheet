<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlAdjustImageOffset
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ButtonHorizontalBottomLeft = New System.Windows.Forms.Button()
        Me.ButtonHorizontalBottomRight = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ButtonHorizontalTopRight = New System.Windows.Forms.Button()
        Me.ButtonVerticalTopLeft = New System.Windows.Forms.Button()
        Me.ButtonVerticalBottomLeft = New System.Windows.Forms.Button()
        Me.ButtonVerticalBottomRight = New System.Windows.Forms.Button()
        Me.ButtonVerticalTopRight = New System.Windows.Forms.Button()
        Me.radioClickPerPixel = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picturePreview
        '
        Me.picturePreview.BackColor = System.Drawing.Color.White
        Me.picturePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePreview.Location = New System.Drawing.Point(41, 88)
        Me.picturePreview.Name = "picturePreview"
        Me.picturePreview.Size = New System.Drawing.Size(466, 277)
        Me.picturePreview.TabIndex = 45
        Me.picturePreview.TabStop = False
        '
        'ButtonHorizontalBottomLeft
        '
        Me.ButtonHorizontalBottomLeft.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonHorizontalBottomLeft.Location = New System.Drawing.Point(43, 369)
        Me.ButtonHorizontalBottomLeft.Name = "ButtonHorizontalBottomLeft"
        Me.ButtonHorizontalBottomLeft.Size = New System.Drawing.Size(229, 29)
        Me.ButtonHorizontalBottomLeft.TabIndex = 46
        Me.ButtonHorizontalBottomLeft.Tag = "◄◄◄◄◄"
        Me.ButtonHorizontalBottomLeft.Text = "◄"
        Me.ButtonHorizontalBottomLeft.UseVisualStyleBackColor = True
        '
        'ButtonHorizontalBottomRight
        '
        Me.ButtonHorizontalBottomRight.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonHorizontalBottomRight.Location = New System.Drawing.Point(278, 369)
        Me.ButtonHorizontalBottomRight.Name = "ButtonHorizontalBottomRight"
        Me.ButtonHorizontalBottomRight.Size = New System.Drawing.Size(229, 29)
        Me.ButtonHorizontalBottomRight.TabIndex = 47
        Me.ButtonHorizontalBottomRight.Tag = "►►►►►"
        Me.ButtonHorizontalBottomRight.Text = "►"
        Me.ButtonHorizontalBottomRight.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(43, 53)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(229, 29)
        Me.Button3.TabIndex = 48
        Me.Button3.Tag = "◄◄◄◄◄"
        Me.Button3.Text = "◄"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ButtonHorizontalTopRight
        '
        Me.ButtonHorizontalTopRight.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonHorizontalTopRight.Location = New System.Drawing.Point(278, 53)
        Me.ButtonHorizontalTopRight.Name = "ButtonHorizontalTopRight"
        Me.ButtonHorizontalTopRight.Size = New System.Drawing.Size(229, 29)
        Me.ButtonHorizontalTopRight.TabIndex = 49
        Me.ButtonHorizontalTopRight.Tag = "►►►►►"
        Me.ButtonHorizontalTopRight.Text = "►"
        Me.ButtonHorizontalTopRight.UseVisualStyleBackColor = True
        '
        'ButtonVerticalTopLeft
        '
        Me.ButtonVerticalTopLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonVerticalTopLeft.Location = New System.Drawing.Point(3, 88)
        Me.ButtonVerticalTopLeft.Name = "ButtonVerticalTopLeft"
        Me.ButtonVerticalTopLeft.Size = New System.Drawing.Size(32, 113)
        Me.ButtonVerticalTopLeft.TabIndex = 50
        Me.ButtonVerticalTopLeft.Tag = "▲▲▲▲▲"
        Me.ButtonVerticalTopLeft.Text = "▲"
        Me.ButtonVerticalTopLeft.UseVisualStyleBackColor = True
        '
        'ButtonVerticalBottomLeft
        '
        Me.ButtonVerticalBottomLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonVerticalBottomLeft.Location = New System.Drawing.Point(0, 252)
        Me.ButtonVerticalBottomLeft.Name = "ButtonVerticalBottomLeft"
        Me.ButtonVerticalBottomLeft.Size = New System.Drawing.Size(32, 113)
        Me.ButtonVerticalBottomLeft.TabIndex = 51
        Me.ButtonVerticalBottomLeft.Tag = "▼▼▼▼▼"
        Me.ButtonVerticalBottomLeft.Text = "▼"
        Me.ButtonVerticalBottomLeft.UseVisualStyleBackColor = True
        '
        'ButtonVerticalBottomRight
        '
        Me.ButtonVerticalBottomRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonVerticalBottomRight.Location = New System.Drawing.Point(510, 252)
        Me.ButtonVerticalBottomRight.Name = "ButtonVerticalBottomRight"
        Me.ButtonVerticalBottomRight.Size = New System.Drawing.Size(32, 113)
        Me.ButtonVerticalBottomRight.TabIndex = 53
        Me.ButtonVerticalBottomRight.Tag = "▼▼▼▼▼"
        Me.ButtonVerticalBottomRight.Text = "▼"
        Me.ButtonVerticalBottomRight.UseVisualStyleBackColor = True
        '
        'ButtonVerticalTopRight
        '
        Me.ButtonVerticalTopRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonVerticalTopRight.Location = New System.Drawing.Point(513, 88)
        Me.ButtonVerticalTopRight.Name = "ButtonVerticalTopRight"
        Me.ButtonVerticalTopRight.Size = New System.Drawing.Size(32, 113)
        Me.ButtonVerticalTopRight.TabIndex = 52
        Me.ButtonVerticalTopRight.Tag = "▲▲▲▲▲"
        Me.ButtonVerticalTopRight.Text = "▲"
        Me.ButtonVerticalTopRight.UseVisualStyleBackColor = True
        '
        'radioClickPerPixel
        '
        Me.radioClickPerPixel.AutoSize = True
        Me.radioClickPerPixel.Checked = True
        Me.radioClickPerPixel.Location = New System.Drawing.Point(3, 3)
        Me.radioClickPerPixel.Name = "radioClickPerPixel"
        Me.radioClickPerPixel.Size = New System.Drawing.Size(227, 21)
        Me.radioClickPerPixel.TabIndex = 54
        Me.radioClickPerPixel.TabStop = True
        Me.radioClickPerPixel.Text = "Move one pixel per button click."
        Me.radioClickPerPixel.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(3, 26)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(301, 21)
        Me.RadioButton2.TabIndex = 55
        Me.RadioButton2.Text = "Press && hold button, five pixels per second."
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'CtlAdjustImageOffset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.radioClickPerPixel)
        Me.Controls.Add(Me.ButtonVerticalBottomRight)
        Me.Controls.Add(Me.ButtonVerticalTopRight)
        Me.Controls.Add(Me.ButtonVerticalBottomLeft)
        Me.Controls.Add(Me.ButtonVerticalTopLeft)
        Me.Controls.Add(Me.ButtonHorizontalTopRight)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ButtonHorizontalBottomRight)
        Me.Controls.Add(Me.ButtonHorizontalBottomLeft)
        Me.Controls.Add(Me.picturePreview)
        Me.Name = "CtlAdjustImageOffset"
        Me.Size = New System.Drawing.Size(552, 401)
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picturePreview As PictureBox
    Friend WithEvents ButtonHorizontalBottomLeft As Button
    Friend WithEvents ButtonHorizontalBottomRight As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ButtonHorizontalTopRight As Button
    Friend WithEvents ButtonVerticalTopLeft As Button
    Friend WithEvents ButtonVerticalBottomLeft As Button
    Friend WithEvents ButtonVerticalBottomRight As Button
    Friend WithEvents ButtonVerticalTopRight As Button
    Friend WithEvents radioClickPerPixel As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents Timer1 As Timer
End Class
