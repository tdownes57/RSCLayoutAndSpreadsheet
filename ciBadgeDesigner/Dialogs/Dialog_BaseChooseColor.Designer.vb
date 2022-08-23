Imports ciBadgeInterfaces

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dialog_BaseChooseColor
    Inherits Dialog_Base ''System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ButtonForecolor = New System.Windows.Forms.Button()
        Me.FlowLayoutColors2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LinkLabelAddColors = New System.Windows.Forms.LinkLabel()
        Me.RscColorDisplayMini1 = New __RSCWindowsControlLibrary.RSCColorDisplayMini()
        Me.RscColorDisplayMini2 = New __RSCWindowsControlLibrary.RSCColorDisplayMini()
        Me.ButtonUndo = New System.Windows.Forms.Button()
        Me.ButtonBackground = New System.Windows.Forms.Button()
        Me.FlowLayoutColors1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.RscColorDisplayLabel1 = New __RSCWindowsControlLibrary.RSCColorDisplayLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.rscLabelDisplayColorSelected = New __RSCWindowsControlLibrary.RSCColorDisplayLabel()
        Me.ButtonSaveColor = New System.Windows.Forms.Button()
        Me.FlowLayoutColors2.SuspendLayout()
        Me.FlowLayoutColors1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonForecolor
        '
        Me.ButtonForecolor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonForecolor.Location = New System.Drawing.Point(784, 353)
        Me.ButtonForecolor.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonForecolor.Name = "ButtonForecolor"
        Me.ButtonForecolor.Size = New System.Drawing.Size(95, 36)
        Me.ButtonForecolor.TabIndex = 12
        Me.ButtonForecolor.Text = "◄ Apply to Font"
        Me.ButtonForecolor.UseVisualStyleBackColor = True
        '
        'FlowLayoutColors2
        '
        Me.FlowLayoutColors2.AutoScroll = True
        Me.FlowLayoutColors2.BackColor = System.Drawing.Color.LemonChiffon
        Me.FlowLayoutColors2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutColors2.Controls.Add(Me.LinkLabelAddColors)
        Me.FlowLayoutColors2.Controls.Add(Me.RscColorDisplayMini1)
        Me.FlowLayoutColors2.Controls.Add(Me.RscColorDisplayMini2)
        Me.FlowLayoutColors2.Location = New System.Drawing.Point(857, 59)
        Me.FlowLayoutColors2.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutColors2.Name = "FlowLayoutColors2"
        Me.FlowLayoutColors2.Size = New System.Drawing.Size(119, 254)
        Me.FlowLayoutColors2.TabIndex = 13
        '
        'LinkLabelAddColors
        '
        Me.LinkLabelAddColors.AutoSize = True
        Me.LinkLabelAddColors.Location = New System.Drawing.Point(13, 13)
        Me.LinkLabelAddColors.Margin = New System.Windows.Forms.Padding(13)
        Me.LinkLabelAddColors.Name = "LinkLabelAddColors"
        Me.LinkLabelAddColors.Size = New System.Drawing.Size(53, 13)
        Me.LinkLabelAddColors.TabIndex = 0
        Me.LinkLabelAddColors.TabStop = True
        Me.LinkLabelAddColors.Text = "Add Color"
        '
        'RscColorDisplayMini1
        '
        Me.RscColorDisplayMini1.DisplayRSCColor = Nothing
        Me.RscColorDisplayMini1.HideBackgroundLabels = True
        Me.RscColorDisplayMini1.HideForegroundLabels = True
        Me.RscColorDisplayMini1.Location = New System.Drawing.Point(3, 42)
        Me.RscColorDisplayMini1.Name = "RscColorDisplayMini1"
        Me.RscColorDisplayMini1.Size = New System.Drawing.Size(86, 68)
        Me.RscColorDisplayMini1.TabIndex = 1
        '
        'RscColorDisplayMini2
        '
        Me.RscColorDisplayMini2.DisplayRSCColor = Nothing
        Me.RscColorDisplayMini2.HideBackgroundLabels = True
        Me.RscColorDisplayMini2.HideForegroundLabels = True
        Me.RscColorDisplayMini2.Location = New System.Drawing.Point(3, 116)
        Me.RscColorDisplayMini2.Name = "RscColorDisplayMini2"
        Me.RscColorDisplayMini2.Size = New System.Drawing.Size(86, 68)
        Me.RscColorDisplayMini2.TabIndex = 2
        '
        'ButtonUndo
        '
        Me.ButtonUndo.Location = New System.Drawing.Point(883, 353)
        Me.ButtonUndo.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonUndo.Name = "ButtonUndo"
        Me.ButtonUndo.Size = New System.Drawing.Size(69, 36)
        Me.ButtonUndo.TabIndex = 19
        Me.ButtonUndo.Text = "Undo"
        Me.ButtonUndo.UseVisualStyleBackColor = True
        '
        'ButtonBackground
        '
        Me.ButtonBackground.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonBackground.Location = New System.Drawing.Point(629, 353)
        Me.ButtonBackground.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonBackground.Name = "ButtonBackground"
        Me.ButtonBackground.Size = New System.Drawing.Size(151, 36)
        Me.ButtonBackground.TabIndex = 20
        Me.ButtonBackground.Text = "◄ Apply to Background"
        Me.ToolTip1.SetToolTip(Me.ButtonBackground, "Set Background Color of the Element")
        Me.ButtonBackground.UseVisualStyleBackColor = True
        '
        'FlowLayoutColors1
        '
        Me.FlowLayoutColors1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutColors1.AutoScroll = True
        Me.FlowLayoutColors1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutColors1.Controls.Add(Me.RscColorDisplayLabel1)
        Me.FlowLayoutColors1.Location = New System.Drawing.Point(629, 59)
        Me.FlowLayoutColors1.Name = "FlowLayoutColors1"
        Me.FlowLayoutColors1.Size = New System.Drawing.Size(223, 254)
        Me.FlowLayoutColors1.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.FlowLayoutColors1, "Microsoft Web Colors, e.g. ""Rosy Brown"".")
        '
        'RscColorDisplayLabel1
        '
        Me.RscColorDisplayLabel1.Location = New System.Drawing.Point(3, 3)
        Me.RscColorDisplayLabel1.Name = "RscColorDisplayLabel1"
        Me.RscColorDisplayLabel1.RSCDisplayColor = Nothing
        Me.RscColorDisplayLabel1.Size = New System.Drawing.Size(200, 28)
        Me.RscColorDisplayLabel1.TabIndex = 0
        '
        'rscLabelDisplayColorSelected
        '
        Me.rscLabelDisplayColorSelected.Location = New System.Drawing.Point(629, 320)
        Me.rscLabelDisplayColorSelected.Name = "rscLabelDisplayColorSelected"
        Me.rscLabelDisplayColorSelected.RSCDisplayColor = Nothing
        Me.rscLabelDisplayColorSelected.Size = New System.Drawing.Size(200, 28)
        Me.rscLabelDisplayColorSelected.TabIndex = 23
        '
        'ButtonSaveColor
        '
        Me.ButtonSaveColor.Location = New System.Drawing.Point(837, 313)
        Me.ButtonSaveColor.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonSaveColor.Name = "ButtonSaveColor"
        Me.ButtonSaveColor.Size = New System.Drawing.Size(69, 36)
        Me.ButtonSaveColor.TabIndex = 24
        Me.ButtonSaveColor.Text = "Save Color"
        Me.ButtonSaveColor.UseVisualStyleBackColor = True
        '
        'Dialog_BaseChooseColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 506)
        Me.Controls.Add(Me.ButtonSaveColor)
        Me.Controls.Add(Me.rscLabelDisplayColorSelected)
        Me.Controls.Add(Me.FlowLayoutColors1)
        Me.Controls.Add(Me.ButtonBackground)
        Me.Controls.Add(Me.ButtonUndo)
        Me.Controls.Add(Me.FlowLayoutColors2)
        Me.Controls.Add(Me.ButtonForecolor)
        Me.Name = "Dialog_BaseChooseColor"
        Me.Text = "Dialog_BaseBackgroundColor"
        Me.Controls.SetChildIndex(Me.ButtonForecolor, 0)
        Me.Controls.SetChildIndex(Me.FlowLayoutColors2, 0)
        Me.Controls.SetChildIndex(Me.ButtonUndo, 0)
        Me.Controls.SetChildIndex(Me.ButtonBackground, 0)
        Me.Controls.SetChildIndex(Me.FlowLayoutColors1, 0)
        Me.Controls.SetChildIndex(Me.rscLabelDisplayColorSelected, 0)
        Me.Controls.SetChildIndex(Me.ButtonSaveColor, 0)
        Me.FlowLayoutColors2.ResumeLayout(False)
        Me.FlowLayoutColors2.PerformLayout()
        Me.FlowLayoutColors1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonForecolor As Button
    Friend WithEvents FlowLayoutColors2 As FlowLayoutPanel
    Friend WithEvents ButtonUndo As Button
    Friend WithEvents ButtonBackground As Button
    Friend WithEvents LinkLabelAddColors As LinkLabel
    Friend WithEvents RscColorDisplayMini1 As __RSCWindowsControlLibrary.RSCColorDisplayMini
    Friend WithEvents RscColorDisplayMini2 As __RSCWindowsControlLibrary.RSCColorDisplayMini
    Friend WithEvents FlowLayoutColors1 As FlowLayoutPanel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents RscColorDisplayLabel1 As __RSCWindowsControlLibrary.RSCColorDisplayLabel
    Friend WithEvents rscLabelDisplayColorSelected As __RSCWindowsControlLibrary.RSCColorDisplayLabel
    Friend WithEvents ButtonSaveColor As Button
End Class
