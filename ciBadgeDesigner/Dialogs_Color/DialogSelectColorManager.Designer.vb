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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogSelectColorManager))
        Me.RscColorFlowPanel1All = New __RSCWindowsControlLibrary.RSCColorFlowPanel()
        Me.RscColorFlowPanel2Chosen = New __RSCWindowsControlLibrary.RSCColorFlowPanel()
        Me.RscElementArrowRight = New __RSCWindowsControlLibrary.RSCElementArrowLeft()
        Me.RscElementArrowLeft = New __RSCWindowsControlLibrary.RSCElementArrowRight()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.RscColorDisplayLabel1 = New __RSCWindowsControlLibrary.RSCColorDisplayLabel()
        Me.LabelSelectedColor = New System.Windows.Forms.Label()
        Me.LabelHeaderColorsAvailable = New System.Windows.Forms.Label()
        Me.LabelHeaderColorsSelected = New System.Windows.Forms.Label()
        Me.ButtonSelect = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LabelSubheadingSelected = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'RscColorFlowPanel1All
        '
        Me.RscColorFlowPanel1All.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RscColorFlowPanel1All.Location = New System.Drawing.Point(7, 72)
        Me.RscColorFlowPanel1All.Name = "RscColorFlowPanel1All"
        Me.RscColorFlowPanel1All.Size = New System.Drawing.Size(421, 260)
        Me.RscColorFlowPanel1All.TabIndex = 0
        '
        'RscColorFlowPanel2Chosen
        '
        Me.RscColorFlowPanel2Chosen.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RscColorFlowPanel2Chosen.Location = New System.Drawing.Point(594, 72)
        Me.RscColorFlowPanel2Chosen.Name = "RscColorFlowPanel2Chosen"
        Me.RscColorFlowPanel2Chosen.Size = New System.Drawing.Size(421, 260)
        Me.RscColorFlowPanel2Chosen.TabIndex = 1
        '
        'RscElementArrowRight
        '
        Me.RscElementArrowRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RscElementArrowRight.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RscElementArrowRight.ElementInfo_Base = Nothing
        Me.RscElementArrowRight.ImageLocation = Nothing
        Me.RscElementArrowRight.Location = New System.Drawing.Point(433, 217)
        Me.RscElementArrowRight.Margin = New System.Windows.Forms.Padding(2)
        Me.RscElementArrowRight.MoveabilityEventsForGroupCtls = Nothing
        Me.RscElementArrowRight.MoveabilityEventsForSingleMove = Nothing
        Me.RscElementArrowRight.Name = "RscElementArrowRight"
        Me.RscElementArrowRight.Size = New System.Drawing.Size(156, 100)
        Me.RscElementArrowRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
        Me.RscElementArrowRight.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.RscElementArrowRight, "Select the Color for General Use")
        '
        'RscElementArrowLeft
        '
        Me.RscElementArrowLeft.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RscElementArrowLeft.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RscElementArrowLeft.ElementInfo_Base = Nothing
        Me.RscElementArrowLeft.ImageLocation = Nothing
        Me.RscElementArrowLeft.Location = New System.Drawing.Point(433, 113)
        Me.RscElementArrowLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.RscElementArrowLeft.MoveabilityEventsForGroupCtls = Nothing
        Me.RscElementArrowLeft.MoveabilityEventsForSingleMove = Nothing
        Me.RscElementArrowLeft.Name = "RscElementArrowLeft"
        Me.RscElementArrowLeft.Size = New System.Drawing.Size(156, 100)
        Me.RscElementArrowLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
        Me.RscElementArrowLeft.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.RscElementArrowLeft, "Deselect the color from general use.")
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.BackColor = System.Drawing.Color.PaleGreen
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(964, 354)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(101, 34)
        Me.ButtonCancel.TabIndex = 5
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.BackColor = System.Drawing.Color.PaleGreen
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(859, 354)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(101, 34)
        Me.ButtonOK.TabIndex = 4
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'RscColorDisplayLabel1
        '
        Me.RscColorDisplayLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RscColorDisplayLabel1.Location = New System.Drawing.Point(406, 355)
        Me.RscColorDisplayLabel1.MSNetColorName = Nothing
        Me.RscColorDisplayLabel1.Name = "RscColorDisplayLabel1"
        Me.RscColorDisplayLabel1.RSCDisplayColor = CType(resources.GetObject("RscColorDisplayLabel1.RSCDisplayColor"), ciBadgeInterfaces.RSCColor)
        Me.RscColorDisplayLabel1.Size = New System.Drawing.Size(200, 25)
        Me.RscColorDisplayLabel1.TabIndex = 6
        Me.RscColorDisplayLabel1.Visible = False
        '
        'LabelSelectedColor
        '
        Me.LabelSelectedColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelSelectedColor.AutoSize = True
        Me.LabelSelectedColor.Location = New System.Drawing.Point(322, 362)
        Me.LabelSelectedColor.Name = "LabelSelectedColor"
        Me.LabelSelectedColor.Size = New System.Drawing.Size(78, 13)
        Me.LabelSelectedColor.TabIndex = 7
        Me.LabelSelectedColor.Text = "Selected color:"
        Me.LabelSelectedColor.Visible = False
        '
        'LabelHeaderColorsAvailable
        '
        Me.LabelHeaderColorsAvailable.AutoSize = True
        Me.LabelHeaderColorsAvailable.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderColorsAvailable.Location = New System.Drawing.Point(12, 9)
        Me.LabelHeaderColorsAvailable.Name = "LabelHeaderColorsAvailable"
        Me.LabelHeaderColorsAvailable.Size = New System.Drawing.Size(188, 29)
        Me.LabelHeaderColorsAvailable.TabIndex = 8
        Me.LabelHeaderColorsAvailable.Text = "Available Colors"
        '
        'LabelHeaderColorsSelected
        '
        Me.LabelHeaderColorsSelected.AutoSize = True
        Me.LabelHeaderColorsSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderColorsSelected.Location = New System.Drawing.Point(582, 9)
        Me.LabelHeaderColorsSelected.Name = "LabelHeaderColorsSelected"
        Me.LabelHeaderColorsSelected.Size = New System.Drawing.Size(192, 29)
        Me.LabelHeaderColorsSelected.TabIndex = 9
        Me.LabelHeaderColorsSelected.Text = "Selected Colors "
        '
        'ButtonSelect
        '
        Me.ButtonSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSelect.BackColor = System.Drawing.Color.PaleGreen
        Me.ButtonSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSelect.Location = New System.Drawing.Point(406, 323)
        Me.ButtonSelect.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonSelect.Name = "ButtonSelect"
        Me.ButtonSelect.Size = New System.Drawing.Size(200, 34)
        Me.ButtonSelect.TabIndex = 10
        Me.ButtonSelect.Text = ">> Select >>"
        Me.ToolTip1.SetToolTip(Me.ButtonSelect, "Select the Color for General Use")
        Me.ButtonSelect.UseVisualStyleBackColor = False
        Me.ButtonSelect.Visible = False
        '
        'LabelSubheadingSelected
        '
        Me.LabelSubheadingSelected.AutoSize = True
        Me.LabelSubheadingSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSubheadingSelected.Location = New System.Drawing.Point(605, 40)
        Me.LabelSubheadingSelected.Name = "LabelSubheadingSelected"
        Me.LabelSubheadingSelected.Size = New System.Drawing.Size(399, 20)
        Me.LabelSubheadingSelected.TabIndex = 11
        Me.LabelSubheadingSelected.Text = "(general use in current card, foreground or background)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "(supplied by Microsoft)"
        '
        'DialogSelectColorManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1091, 399)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelSubheadingSelected)
        Me.Controls.Add(Me.ButtonSelect)
        Me.Controls.Add(Me.RscColorFlowPanel2Chosen)
        Me.Controls.Add(Me.LabelHeaderColorsSelected)
        Me.Controls.Add(Me.LabelHeaderColorsAvailable)
        Me.Controls.Add(Me.LabelSelectedColor)
        Me.Controls.Add(Me.RscColorDisplayLabel1)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.RscElementArrowLeft)
        Me.Controls.Add(Me.RscElementArrowRight)
        Me.Controls.Add(Me.RscColorFlowPanel1All)
        Me.Name = "DialogSelectColorManager"
        Me.Text = "DialogSelectColorManager"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RscColorFlowPanel1All As __RSCWindowsControlLibrary.RSCColorFlowPanel
    Friend WithEvents RscColorFlowPanel2Chosen As __RSCWindowsControlLibrary.RSCColorFlowPanel
    Friend WithEvents RscElementArrowRight As __RSCWindowsControlLibrary.RSCElementArrowLeft
    Friend WithEvents RscElementArrowLeft As __RSCWindowsControlLibrary.RSCElementArrowRight
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents RscColorDisplayLabel1 As __RSCWindowsControlLibrary.RSCColorDisplayLabel
    Friend WithEvents LabelSelectedColor As Label
    Friend WithEvents LabelHeaderColorsAvailable As Label
    Friend WithEvents LabelHeaderColorsSelected As Label
    Friend WithEvents ButtonSelect As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents LabelSubheadingSelected As Label
    Friend WithEvents Label1 As Label
End Class
