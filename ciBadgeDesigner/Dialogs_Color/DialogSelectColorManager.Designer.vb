<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogSelectColorManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogSelectColorManager))
        Me.RscColorFlowPanel1 = New __RSCWindowsControlLibrary.RSCColorFlowPanel()
        Me.RscColorFlowPanel2 = New __RSCWindowsControlLibrary.RSCColorFlowPanel()
        Me.RscElementArrowLeft1 = New __RSCWindowsControlLibrary.RSCElementArrowLeft()
        Me.RscElementArrowRight1 = New __RSCWindowsControlLibrary.RSCElementArrowRight()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.RscColorDisplayLabel1 = New __RSCWindowsControlLibrary.RSCColorDisplayLabel()
        Me.LabelSelectedColor = New System.Windows.Forms.Label()
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'RscColorFlowPanel1
        '
        Me.RscColorFlowPanel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RscColorFlowPanel1.ConfirmColorSelection = False
        Me.RscColorFlowPanel1.Location = New System.Drawing.Point(12, 46)
        Me.RscColorFlowPanel1.Name = "RscColorFlowPanel1"
        Me.RscColorFlowPanel1.Size = New System.Drawing.Size(421, 260)
        Me.RscColorFlowPanel1.TabIndex = 0
        '
        'RscColorFlowPanel2
        '
        Me.RscColorFlowPanel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RscColorFlowPanel2.ConfirmColorSelection = False
        Me.RscColorFlowPanel2.Location = New System.Drawing.Point(587, 46)
        Me.RscColorFlowPanel2.Name = "RscColorFlowPanel2"
        Me.RscColorFlowPanel2.Size = New System.Drawing.Size(421, 260)
        Me.RscColorFlowPanel2.TabIndex = 1
        '
        'RscElementArrowLeft1
        '
        Me.RscElementArrowLeft1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RscElementArrowLeft1.ElementInfo_Base = Nothing
        Me.RscElementArrowLeft1.ImageLocation = Nothing
        Me.RscElementArrowLeft1.Location = New System.Drawing.Point(455, 84)
        Me.RscElementArrowLeft1.Margin = New System.Windows.Forms.Padding(2)
        Me.RscElementArrowLeft1.MoveabilityEventsForGroupCtls = Nothing
        Me.RscElementArrowLeft1.MoveabilityEventsForSingleMove = Nothing
        Me.RscElementArrowLeft1.Name = "RscElementArrowLeft1"
        Me.RscElementArrowLeft1.Size = New System.Drawing.Size(98, 55)
        Me.RscElementArrowLeft1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
        Me.RscElementArrowLeft1.TabIndex = 2
        '
        'RscElementArrowRight1
        '
        Me.RscElementArrowRight1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RscElementArrowRight1.ElementInfo_Base = Nothing
        Me.RscElementArrowRight1.ImageLocation = Nothing
        Me.RscElementArrowRight1.Location = New System.Drawing.Point(455, 212)
        Me.RscElementArrowRight1.Margin = New System.Windows.Forms.Padding(2)
        Me.RscElementArrowRight1.MoveabilityEventsForGroupCtls = Nothing
        Me.RscElementArrowRight1.MoveabilityEventsForSingleMove = Nothing
        Me.RscElementArrowRight1.Name = "RscElementArrowRight1"
        Me.RscElementArrowRight1.Size = New System.Drawing.Size(98, 55)
        Me.RscElementArrowRight1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
        Me.RscElementArrowRight1.TabIndex = 3
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.BackColor = System.Drawing.Color.PaleGreen
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(964, 311)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(101, 34)
        Me.ButtonCancel.TabIndex = 5
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        Me.ButtonCancel.Visible = False
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.BackColor = System.Drawing.Color.PaleGreen
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(859, 311)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(101, 34)
        Me.ButtonOK.TabIndex = 4
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'RscColorDisplayLabel1
        '
        Me.RscColorDisplayLabel1.Location = New System.Drawing.Point(406, 319)
        Me.RscColorDisplayLabel1.Name = "RscColorDisplayLabel1"
        Me.RscColorDisplayLabel1.RSCDisplayColor = CType(resources.GetObject("RscColorDisplayLabel1.RSCDisplayColor"), ciBadgeInterfaces.RSCColor)
        Me.RscColorDisplayLabel1.Size = New System.Drawing.Size(200, 25)
        Me.RscColorDisplayLabel1.TabIndex = 6
        Me.RscColorDisplayLabel1.Visible = False
        '
        'LabelSelectedColor
        '
        Me.LabelSelectedColor.AutoSize = True
        Me.LabelSelectedColor.Location = New System.Drawing.Point(322, 331)
        Me.LabelSelectedColor.Name = "LabelSelectedColor"
        Me.LabelSelectedColor.Size = New System.Drawing.Size(78, 13)
        Me.LabelSelectedColor.TabIndex = 7
        Me.LabelSelectedColor.Text = "Selected color:"
        Me.LabelSelectedColor.Visible = False
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(12, 9)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(199, 30)
        Me.LabelHeader1.TabIndex = 8
        Me.LabelHeader1.Text = "Available Colors"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(582, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 30)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Selected Colors"
        '
        'DialogSelectColorManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1091, 356)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Controls.Add(Me.LabelSelectedColor)
        Me.Controls.Add(Me.RscColorDisplayLabel1)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.RscElementArrowRight1)
        Me.Controls.Add(Me.RscElementArrowLeft1)
        Me.Controls.Add(Me.RscColorFlowPanel2)
        Me.Controls.Add(Me.RscColorFlowPanel1)
        Me.Name = "DialogSelectColorManager"
        Me.Text = "DialogSelectColorManager"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RscColorFlowPanel1 As __RSCWindowsControlLibrary.RSCColorFlowPanel
    Friend WithEvents RscColorFlowPanel2 As __RSCWindowsControlLibrary.RSCColorFlowPanel
    Friend WithEvents RscElementArrowLeft1 As __RSCWindowsControlLibrary.RSCElementArrowLeft
    Friend WithEvents RscElementArrowRight1 As __RSCWindowsControlLibrary.RSCElementArrowRight
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents RscColorDisplayLabel1 As __RSCWindowsControlLibrary.RSCColorDisplayLabel
    Friend WithEvents LabelSelectedColor As Label
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents Label1 As Label
End Class
