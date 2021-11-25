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
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picturePreview
        '
        Me.picturePreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picturePreview.BackColor = System.Drawing.Color.Transparent
        Me.picturePreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picturePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePreview.Location = New System.Drawing.Point(3, 29)
        Me.picturePreview.Name = "picturePreview"
        Me.picturePreview.Size = New System.Drawing.Size(830, 277)
        Me.picturePreview.TabIndex = 45
        Me.picturePreview.TabStop = False
        '
        'labelHeading1
        '
        Me.labelHeading1.AutoSize = True
        Me.labelHeading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelHeading1.Location = New System.Drawing.Point(-4, 6)
        Me.labelHeading1.Name = "labelHeading1"
        Me.labelHeading1.Size = New System.Drawing.Size(164, 20)
        Me.labelHeading1.TabIndex = 46
        Me.labelHeading1.Text = "Background Image"
        '
        'LabelFileName
        '
        Me.LabelFileName.AutoSize = True
        Me.LabelFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFileName.Location = New System.Drawing.Point(166, 6)
        Me.LabelFileName.Name = "LabelFileName"
        Me.LabelFileName.Size = New System.Drawing.Size(153, 20)
        Me.LabelFileName.TabIndex = 47
        Me.LabelFileName.Tag = ""
        Me.LabelFileName.Text = "[ image file title ]"
        '
        'checkSelection
        '
        Me.checkSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.checkSelection.AutoEllipsis = True
        Me.checkSelection.AutoSize = True
        Me.checkSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkSelection.Location = New System.Drawing.Point(3, 312)
        Me.checkSelection.Name = "checkSelection"
        Me.checkSelection.Size = New System.Drawing.Size(578, 21)
        Me.checkSelection.TabIndex = 48
        Me.checkSelection.Text = "This above is my selection--use this image as the background of my badge."
        Me.checkSelection.UseVisualStyleBackColor = True
        '
        'CtlBackground
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.checkSelection)
        Me.Controls.Add(Me.LabelFileName)
        Me.Controls.Add(Me.labelHeading1)
        Me.Controls.Add(Me.picturePreview)
        Me.Name = "CtlBackground"
        Me.Size = New System.Drawing.Size(858, 336)
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picturePreview As PictureBox
    Friend WithEvents labelHeading1 As Label
    Friend WithEvents LabelFileName As Label
    Friend WithEvents checkSelection As CheckBox
End Class
