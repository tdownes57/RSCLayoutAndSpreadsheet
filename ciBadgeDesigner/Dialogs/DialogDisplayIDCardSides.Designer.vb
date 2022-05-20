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
        Me.pictureBackgroundFront = New System.Windows.Forms.PictureBox()
        Me.pictureJustAButton = New System.Windows.Forms.PictureBox()
        Me.labelProceedToBackside = New System.Windows.Forms.Label()
        Me.LabelReturnToFrontSide = New System.Windows.Forms.Label()
        CType(Me.pictureBackgroundFront, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureJustAButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureBackgroundFront
        '
        Me.pictureBackgroundFront.BackColor = System.Drawing.Color.White
        Me.pictureBackgroundFront.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBackgroundFront.Location = New System.Drawing.Point(58, 79)
        Me.pictureBackgroundFront.Name = "pictureBackgroundFront"
        Me.pictureBackgroundFront.Size = New System.Drawing.Size(603, 380)
        Me.pictureBackgroundFront.TabIndex = 86
        Me.pictureBackgroundFront.TabStop = False
        '
        'pictureJustAButton
        '
        Me.pictureJustAButton.BackColor = System.Drawing.Color.Silver
        Me.pictureJustAButton.Location = New System.Drawing.Point(78, 100)
        Me.pictureJustAButton.Name = "pictureJustAButton"
        Me.pictureJustAButton.Size = New System.Drawing.Size(622, 379)
        Me.pictureJustAButton.TabIndex = 87
        Me.pictureJustAButton.TabStop = False
        Me.pictureJustAButton.Visible = False
        '
        'labelProceedToBackside
        '
        Me.labelProceedToBackside.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelProceedToBackside.ForeColor = System.Drawing.Color.Navy
        Me.labelProceedToBackside.Location = New System.Drawing.Point(295, 52)
        Me.labelProceedToBackside.Name = "labelProceedToBackside"
        Me.labelProceedToBackside.Size = New System.Drawing.Size(365, 23)
        Me.labelProceedToBackside.TabIndex = 88
        Me.labelProceedToBackside.Tag = ">>> Show backside of ID Card."
        Me.labelProceedToBackside.Text = ">>> Add backside of ID Card."
        Me.labelProceedToBackside.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelReturnToFrontSide
        '
        Me.LabelReturnToFrontSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelReturnToFrontSide.ForeColor = System.Drawing.Color.Navy
        Me.LabelReturnToFrontSide.Location = New System.Drawing.Point(54, 53)
        Me.LabelReturnToFrontSide.Name = "LabelReturnToFrontSide"
        Me.LabelReturnToFrontSide.Size = New System.Drawing.Size(392, 23)
        Me.LabelReturnToFrontSide.TabIndex = 89
        Me.LabelReturnToFrontSide.Text = "<<< Return to front of ID Card."
        Me.LabelReturnToFrontSide.Visible = False
        '
        'DialogDisplayIDCardSides
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 523)
        Me.Controls.Add(Me.labelProceedToBackside)
        Me.Controls.Add(Me.LabelReturnToFrontSide)
        Me.Controls.Add(Me.pictureBackgroundFront)
        Me.Controls.Add(Me.pictureJustAButton)
        Me.Name = "DialogDisplayIDCardSides"
        Me.Text = "DialogDisplayIDCardSides"
        CType(Me.pictureBackgroundFront, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureJustAButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pictureBackgroundFront As PictureBox
    Friend WithEvents pictureJustAButton As PictureBox
    Friend WithEvents labelProceedToBackside As Label
    Friend WithEvents LabelReturnToFrontSide As Label
End Class
