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
        Me.ButtonForecolor = New System.Windows.Forms.Button()
        Me.FlowLayoutColors2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LinkLabelAddColors = New System.Windows.Forms.LinkLabel()
        Me.RscColorDisplayMini1 = New __RSCWindowsControlLibrary.RSCColorDisplayMini()
        Me.RscColorDisplayMini2 = New __RSCWindowsControlLibrary.RSCColorDisplayMini()
        Me.ButtonUndo = New System.Windows.Forms.Button()
        Me.ButtonBackground = New System.Windows.Forms.Button()
        Me.FlowLayoutColors = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutColors2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonForecolor
        '
        Me.ButtonForecolor.Location = New System.Drawing.Point(734, 323)
        Me.ButtonForecolor.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonForecolor.Name = "ButtonForecolor"
        Me.ButtonForecolor.Size = New System.Drawing.Size(95, 36)
        Me.ButtonForecolor.TabIndex = 12
        Me.ButtonForecolor.Text = "Fore / Font"
        Me.ButtonForecolor.UseVisualStyleBackColor = True
        '
        'FlowLayoutColors2
        '
        Me.FlowLayoutColors2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutColors2.AutoScroll = True
        Me.FlowLayoutColors2.BackColor = System.Drawing.Color.LemonChiffon
        Me.FlowLayoutColors2.Controls.Add(Me.LinkLabelAddColors)
        Me.FlowLayoutColors2.Controls.Add(Me.RscColorDisplayMini1)
        Me.FlowLayoutColors2.Controls.Add(Me.RscColorDisplayMini2)
        Me.FlowLayoutColors2.Location = New System.Drawing.Point(751, 59)
        Me.FlowLayoutColors2.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutColors2.Name = "FlowLayoutColors2"
        Me.FlowLayoutColors2.Size = New System.Drawing.Size(108, 254)
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
        Me.RscColorDisplayMini1.HideBackgroundLabels = False
        Me.RscColorDisplayMini1.HideForegroundLabels = False
        Me.RscColorDisplayMini1.Location = New System.Drawing.Point(3, 42)
        Me.RscColorDisplayMini1.Name = "RscColorDisplayMini1"
        Me.RscColorDisplayMini1.Size = New System.Drawing.Size(86, 68)
        Me.RscColorDisplayMini1.TabIndex = 1
        '
        'RscColorDisplayMini2
        '
        Me.RscColorDisplayMini2.DisplayRSCColor = Nothing
        Me.RscColorDisplayMini2.HideBackgroundLabels = False
        Me.RscColorDisplayMini2.HideForegroundLabels = False
        Me.RscColorDisplayMini2.Location = New System.Drawing.Point(3, 116)
        Me.RscColorDisplayMini2.Name = "RscColorDisplayMini2"
        Me.RscColorDisplayMini2.Size = New System.Drawing.Size(86, 68)
        Me.RscColorDisplayMini2.TabIndex = 2
        '
        'ButtonUndo
        '
        Me.ButtonUndo.Location = New System.Drawing.Point(863, 323)
        Me.ButtonUndo.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonUndo.Name = "ButtonUndo"
        Me.ButtonUndo.Size = New System.Drawing.Size(69, 36)
        Me.ButtonUndo.TabIndex = 19
        Me.ButtonUndo.Text = "Undo"
        Me.ButtonUndo.UseVisualStyleBackColor = True
        '
        'ButtonBackground
        '
        Me.ButtonBackground.Location = New System.Drawing.Point(635, 323)
        Me.ButtonBackground.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonBackground.Name = "ButtonBackground"
        Me.ButtonBackground.Size = New System.Drawing.Size(95, 36)
        Me.ButtonBackground.TabIndex = 20
        Me.ButtonBackground.Text = "Background"
        Me.ButtonBackground.UseVisualStyleBackColor = True
        '
        'FlowLayoutColors
        '
        Me.FlowLayoutColors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutColors.Location = New System.Drawing.Point(629, 59)
        Me.FlowLayoutColors.Name = "FlowLayoutColors"
        Me.FlowLayoutColors.Size = New System.Drawing.Size(117, 254)
        Me.FlowLayoutColors.TabIndex = 22
        '
        'Dialog_BaseChooseColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 506)
        Me.Controls.Add(Me.FlowLayoutColors)
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
        Me.Controls.SetChildIndex(Me.FlowLayoutColors, 0)
        Me.FlowLayoutColors2.ResumeLayout(False)
        Me.FlowLayoutColors2.PerformLayout()
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
    Friend WithEvents FlowLayoutColors As FlowLayoutPanel
End Class
