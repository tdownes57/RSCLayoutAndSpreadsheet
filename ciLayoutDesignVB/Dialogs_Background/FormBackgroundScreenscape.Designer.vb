<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBackgroundScreenscape
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
        Me.components = New System.ComponentModel.Container()
        Me.LinkToStackOverflow = New System.Windows.Forms.LinkLabel()
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.pictureRight = New System.Windows.Forms.PictureBox()
        Me.ButtonOkay1of3 = New System.Windows.Forms.Button()
        Me.LabelScreenshotCopy = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonOkay2of3 = New System.Windows.Forms.Button()
        Me.ButtonOkay3of3 = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonUndoOkay2 = New System.Windows.Forms.Button()
        Me.ButtonUndoOkay1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.picturePreview = New System.Windows.Forms.PictureBox()
        Me.LabelHeaderPreview = New System.Windows.Forms.Label()
        Me.pictureLeftOriginal = New System.Windows.Forms.PictureBox()
        Me.CtlMoveableBackground1 = New ciBadgeDesigner.CtlMoveableBackground()
        Me.LabelMoveableClickDrag = New System.Windows.Forms.Label()
        Me.PanelSizing1 = New System.Windows.Forms.Panel()
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.LabelAdjustSize = New System.Windows.Forms.Label()
        CType(Me.pictureRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureLeftOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSizing1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LinkToStackOverflow
        '
        Me.LinkToStackOverflow.AutoSize = True
        Me.LinkToStackOverflow.Location = New System.Drawing.Point(678, 9)
        Me.LinkToStackOverflow.Name = "LinkToStackOverflow"
        Me.LinkToStackOverflow.Size = New System.Drawing.Size(402, 13)
        Me.LinkToStackOverflow.TabIndex = 55
        Me.LinkToStackOverflow.TabStop = True
        Me.LinkToStackOverflow.Text = "https://stackoverflow.com/questions/10930569/high-quality-full-screenshots-vb-net" &
    ""
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(5, 9)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(314, 31)
        Me.LabelHeader1.TabIndex = 54
        Me.LabelHeader1.Text = "Screengrab / Screenshot"
        '
        'pictureRight
        '
        Me.pictureRight.BackColor = System.Drawing.Color.MistyRose
        Me.pictureRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictureRight.Location = New System.Drawing.Point(636, 80)
        Me.pictureRight.Margin = New System.Windows.Forms.Padding(2)
        Me.pictureRight.Name = "pictureRight"
        Me.pictureRight.Size = New System.Drawing.Size(603, 380)
        Me.pictureRight.TabIndex = 53
        Me.pictureRight.TabStop = False
        '
        'ButtonOkay1of3
        '
        Me.ButtonOkay1of3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOkay1of3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOkay1of3.Location = New System.Drawing.Point(274, 474)
        Me.ButtonOkay1of3.Name = "ButtonOkay1of3"
        Me.ButtonOkay1of3.Size = New System.Drawing.Size(205, 45)
        Me.ButtonOkay1of3.TabIndex = 56
        Me.ButtonOkay1of3.Text = "OK #1 Screenshot Copy"
        Me.ButtonOkay1of3.UseVisualStyleBackColor = True
        '
        'LabelScreenshotCopy
        '
        Me.LabelScreenshotCopy.AutoSize = True
        Me.LabelScreenshotCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelScreenshotCopy.Location = New System.Drawing.Point(632, 57)
        Me.LabelScreenshotCopy.Name = "LabelScreenshotCopy"
        Me.LabelScreenshotCopy.Size = New System.Drawing.Size(131, 20)
        Me.LabelScreenshotCopy.TabIndex = 57
        Me.LabelScreenshotCopy.Text = "Screenshot Copy"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 20)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Original"
        '
        'ButtonOkay2of3
        '
        Me.ButtonOkay2of3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOkay2of3.Enabled = False
        Me.ButtonOkay2of3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOkay2of3.Location = New System.Drawing.Point(538, 474)
        Me.ButtonOkay2of3.Name = "ButtonOkay2of3"
        Me.ButtonOkay2of3.Size = New System.Drawing.Size(174, 45)
        Me.ButtonOkay2of3.TabIndex = 59
        Me.ButtonOkay2of3.Text = "OK #2 Show Preview "
        Me.ButtonOkay2of3.UseVisualStyleBackColor = True
        '
        'ButtonOkay3of3
        '
        Me.ButtonOkay3of3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOkay3of3.Enabled = False
        Me.ButtonOkay3of3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOkay3of3.Location = New System.Drawing.Point(771, 471)
        Me.ButtonOkay3of3.Name = "ButtonOkay3of3"
        Me.ButtonOkay3of3.Size = New System.Drawing.Size(181, 45)
        Me.ButtonOkay3of3.TabIndex = 60
        Me.ButtonOkay3of3.Text = "OK #3 Return/Close "
        Me.ButtonOkay3of3.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(1109, 468)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(137, 45)
        Me.ButtonCancel.TabIndex = 61
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonUndoOkay2
        '
        Me.ButtonUndoOkay2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonUndoOkay2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonUndoOkay2.Location = New System.Drawing.Point(718, 471)
        Me.ButtonUndoOkay2.Name = "ButtonUndoOkay2"
        Me.ButtonUndoOkay2.Size = New System.Drawing.Size(47, 45)
        Me.ButtonUndoOkay2.TabIndex = 62
        Me.ButtonUndoOkay2.Text = "◄"
        Me.ToolTip1.SetToolTip(Me.ButtonUndoOkay2, "Undo OK#2")
        Me.ButtonUndoOkay2.UseVisualStyleBackColor = True
        '
        'ButtonUndoOkay1
        '
        Me.ButtonUndoOkay1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonUndoOkay1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonUndoOkay1.Location = New System.Drawing.Point(485, 474)
        Me.ButtonUndoOkay1.Name = "ButtonUndoOkay1"
        Me.ButtonUndoOkay1.Size = New System.Drawing.Size(47, 45)
        Me.ButtonUndoOkay1.TabIndex = 63
        Me.ButtonUndoOkay1.Text = "◄"
        Me.ToolTip1.SetToolTip(Me.ButtonUndoOkay1, "Undo OK #1")
        Me.ButtonUndoOkay1.UseVisualStyleBackColor = True
        '
        'picturePreview
        '
        Me.picturePreview.BackColor = System.Drawing.Color.White
        Me.picturePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePreview.Location = New System.Drawing.Point(753, 183)
        Me.picturePreview.Margin = New System.Windows.Forms.Padding(2)
        Me.picturePreview.Name = "picturePreview"
        Me.picturePreview.Size = New System.Drawing.Size(350, 225)
        Me.picturePreview.TabIndex = 66
        Me.picturePreview.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picturePreview, "Click the Preview box to update.")
        '
        'LabelHeaderPreview
        '
        Me.LabelHeaderPreview.BackColor = System.Drawing.Color.GreenYellow
        Me.LabelHeaderPreview.Font = New System.Drawing.Font("Franklin Gothic Medium", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderPreview.Location = New System.Drawing.Point(753, 151)
        Me.LabelHeaderPreview.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeaderPreview.Name = "LabelHeaderPreview"
        Me.LabelHeaderPreview.Size = New System.Drawing.Size(350, 30)
        Me.LabelHeaderPreview.TabIndex = 67
        Me.LabelHeaderPreview.Text = "P R E V I E W"
        Me.LabelHeaderPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LabelHeaderPreview, "Click here to update the Preview box.")
        '
        'pictureLeftOriginal
        '
        Me.pictureLeftOriginal.BackColor = System.Drawing.Color.White
        Me.pictureLeftOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureLeftOriginal.Location = New System.Drawing.Point(11, 82)
        Me.pictureLeftOriginal.Name = "pictureLeftOriginal"
        Me.pictureLeftOriginal.Size = New System.Drawing.Size(603, 380)
        Me.pictureLeftOriginal.TabIndex = 77
        Me.pictureLeftOriginal.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pictureLeftOriginal, "This is an editable view of the ID Card (front side).")
        '
        'CtlMoveableBackground1
        '
        Me.CtlMoveableBackground1.BackColor = System.Drawing.Color.White
        Me.CtlMoveableBackground1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CtlMoveableBackground1.Image_NotInUse = Nothing
        Me.CtlMoveableBackground1.ImageFileLocation = Nothing
        Me.CtlMoveableBackground1.Location = New System.Drawing.Point(11, 82)
        Me.CtlMoveableBackground1.Name = "CtlMoveableBackground1"
        Me.CtlMoveableBackground1.Size = New System.Drawing.Size(603, 380)
        Me.CtlMoveableBackground1.TabIndex = 78
        Me.CtlMoveableBackground1.Visible = False
        '
        'LabelMoveableClickDrag
        '
        Me.LabelMoveableClickDrag.AutoSize = True
        Me.LabelMoveableClickDrag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMoveableClickDrag.Location = New System.Drawing.Point(91, 57)
        Me.LabelMoveableClickDrag.Name = "LabelMoveableClickDrag"
        Me.LabelMoveableClickDrag.Size = New System.Drawing.Size(218, 20)
        Me.LabelMoveableClickDrag.TabIndex = 79
        Me.LabelMoveableClickDrag.Text = "Moveable by ""Click And Drag"""
        '
        'PanelSizing1
        '
        Me.PanelSizing1.BackColor = System.Drawing.Color.Black
        Me.PanelSizing1.Controls.Add(Me.HScrollBar1)
        Me.PanelSizing1.Location = New System.Drawing.Point(450, 26)
        Me.PanelSizing1.Name = "PanelSizing1"
        Me.PanelSizing1.Size = New System.Drawing.Size(164, 51)
        Me.PanelSizing1.TabIndex = 81
        Me.PanelSizing1.Visible = False
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HScrollBar1.Location = New System.Drawing.Point(7, 7)
        Me.HScrollBar1.Minimum = 5
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(150, 37)
        Me.HScrollBar1.TabIndex = 81
        Me.HScrollBar1.Value = 100
        '
        'LabelAdjustSize
        '
        Me.LabelAdjustSize.AutoSize = True
        Me.LabelAdjustSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAdjustSize.Location = New System.Drawing.Point(446, 3)
        Me.LabelAdjustSize.Name = "LabelAdjustSize"
        Me.LabelAdjustSize.Size = New System.Drawing.Size(128, 20)
        Me.LabelAdjustSize.TabIndex = 82
        Me.LabelAdjustSize.Text = "Adjust Size as %"
        Me.LabelAdjustSize.Visible = False
        '
        'FormBackgroundScreenscape
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1258, 528)
        Me.Controls.Add(Me.LabelAdjustSize)
        Me.Controls.Add(Me.PanelSizing1)
        Me.Controls.Add(Me.LabelMoveableClickDrag)
        Me.Controls.Add(Me.CtlMoveableBackground1)
        Me.Controls.Add(Me.pictureRight)
        Me.Controls.Add(Me.picturePreview)
        Me.Controls.Add(Me.LabelHeaderPreview)
        Me.Controls.Add(Me.pictureLeftOriginal)
        Me.Controls.Add(Me.ButtonUndoOkay1)
        Me.Controls.Add(Me.ButtonUndoOkay2)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOkay3of3)
        Me.Controls.Add(Me.ButtonOkay2of3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelScreenshotCopy)
        Me.Controls.Add(Me.ButtonOkay1of3)
        Me.Controls.Add(Me.LinkToStackOverflow)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Name = "FormBackgroundScreenscape"
        Me.Text = " "
        CType(Me.pictureRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picturePreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureLeftOriginal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSizing1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkToStackOverflow As LinkLabel
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents pictureRight As PictureBox
    Friend WithEvents ButtonOkay1of3 As Button
    Friend WithEvents LabelScreenshotCopy As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonOkay2of3 As Button
    Friend WithEvents ButtonOkay3of3 As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonUndoOkay2 As Button
    Friend WithEvents ButtonUndoOkay1 As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents picturePreview As PictureBox
    Friend WithEvents LabelHeaderPreview As Label
    Friend WithEvents pictureLeftOriginal As PictureBox
    Friend WithEvents CtlMoveableBackground1 As ciBadgeDesigner.CtlMoveableBackground
    Friend WithEvents LabelMoveableClickDrag As Label
    Friend WithEvents PanelSizing1 As Panel
    Friend WithEvents HScrollBar1 As HScrollBar
    Friend WithEvents LabelAdjustSize As Label
End Class
