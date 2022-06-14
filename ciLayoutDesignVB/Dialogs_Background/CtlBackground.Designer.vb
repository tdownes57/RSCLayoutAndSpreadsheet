<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlBackground
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
        Me.picturePreview = New System.Windows.Forms.PictureBox()
        Me.labelHeading1 = New System.Windows.Forms.Label()
        Me.LabelFileName = New System.Windows.Forms.Label()
        Me.checkSelection = New System.Windows.Forms.CheckBox()
        Me.LinkRemoveImage = New System.Windows.Forms.LinkLabel()
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picturePreview
        '
        Me.picturePreview.BackColor = System.Drawing.Color.White
        Me.picturePreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picturePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePreview.Dock = System.Windows.Forms.DockStyle.Right
        Me.picturePreview.Location = New System.Drawing.Point(64, 0)
        Me.picturePreview.Margin = New System.Windows.Forms.Padding(2)
        Me.picturePreview.Name = "picturePreview"
        Me.picturePreview.Size = New System.Drawing.Size(498, 319)
        Me.picturePreview.TabIndex = 45
        Me.picturePreview.TabStop = False
        '
        'labelHeading1
        '
        Me.labelHeading1.AutoSize = True
        Me.labelHeading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelHeading1.Location = New System.Drawing.Point(-3, 5)
        Me.labelHeading1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.labelHeading1.Name = "labelHeading1"
        Me.labelHeading1.Size = New System.Drawing.Size(142, 17)
        Me.labelHeading1.TabIndex = 46
        Me.labelHeading1.Text = "Background Image"
        '
        'LabelFileName
        '
        Me.LabelFileName.AutoSize = True
        Me.LabelFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFileName.Location = New System.Drawing.Point(124, 5)
        Me.LabelFileName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelFileName.Name = "LabelFileName"
        Me.LabelFileName.Size = New System.Drawing.Size(130, 17)
        Me.LabelFileName.TabIndex = 47
        Me.LabelFileName.Tag = ""
        Me.LabelFileName.Text = "[ image file title ]"
        '
        'checkSelection
        '
        Me.checkSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.checkSelection.AutoSize = True
        Me.checkSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkSelection.Location = New System.Drawing.Point(2, 300)
        Me.checkSelection.Margin = New System.Windows.Forms.Padding(2)
        Me.checkSelection.Name = "checkSelection"
        Me.checkSelection.Size = New System.Drawing.Size(452, 17)
        Me.checkSelection.TabIndex = 48
        Me.checkSelection.Text = "This above is my selection--use this image as the background of my badge."
        Me.checkSelection.UseVisualStyleBackColor = True
        '
        'LinkRemoveImage
        '
        Me.LinkRemoveImage.AutoSize = True
        Me.LinkRemoveImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkRemoveImage.Location = New System.Drawing.Point(80, 285)
        Me.LinkRemoveImage.Name = "LinkRemoveImage"
        Me.LinkRemoveImage.Size = New System.Drawing.Size(255, 15)
        Me.LinkRemoveImage.TabIndex = 49
        Me.LinkRemoveImage.TabStop = True
        Me.LinkRemoveImage.Text = "Remove this background image from this list. "
        '
        'CtlBackground
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Controls.Add(Me.LinkRemoveImage)
        Me.Controls.Add(Me.checkSelection)
        Me.Controls.Add(Me.LabelFileName)
        Me.Controls.Add(Me.labelHeading1)
        Me.Controls.Add(Me.picturePreview)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "CtlBackground"
        Me.Size = New System.Drawing.Size(562, 319)
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picturePreview As PictureBox
    Friend WithEvents labelHeading1 As Label
    Friend WithEvents LabelFileName As Label
    Friend WithEvents checkSelection As CheckBox
    Friend WithEvents LinkRemoveImage As LinkLabel
End Class
