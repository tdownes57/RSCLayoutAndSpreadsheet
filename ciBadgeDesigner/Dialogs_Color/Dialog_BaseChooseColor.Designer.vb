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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog_BaseChooseColor))
        Me.ButtonForecolor = New System.Windows.Forms.Button()
        Me.ButtonUndoColorFont = New System.Windows.Forms.Button()
        Me.ButtonBackground = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ButtonUndoColorBackground = New System.Windows.Forms.Button()
        Me.ButtonSaveColor = New System.Windows.Forms.Button()
        Me.rscLabelDisplayColorSelected = New __RSCWindowsControlLibrary.RSCColorDisplayLabel()
        Me.LinkLabelAddColor1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelRefreshColors = New System.Windows.Forms.LinkLabel()
        Me.ButtonApplyBF = New System.Windows.Forms.Button()
        Me.ButtonApplyFB = New System.Windows.Forms.Button()
        Me.LabelSelected = New System.Windows.Forms.Label()
        Me.RscColorFlowPanel1 = New __RSCWindowsControlLibrary.RSCColorFlowPanel()
        Me.SuspendLayout()
        '
        'ButtonForecolor
        '
        Me.ButtonForecolor.Enabled = False
        Me.ButtonForecolor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonForecolor.Location = New System.Drawing.Point(842, 367)
        Me.ButtonForecolor.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonForecolor.Name = "ButtonForecolor"
        Me.ButtonForecolor.Size = New System.Drawing.Size(148, 36)
        Me.ButtonForecolor.TabIndex = 12
        Me.ButtonForecolor.Text = "◄ Apply to Text"
        Me.ButtonForecolor.UseVisualStyleBackColor = True
        '
        'ButtonUndoColorFont
        '
        Me.ButtonUndoColorFont.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.ButtonUndoColorFont.Location = New System.Drawing.Point(994, 367)
        Me.ButtonUndoColorFont.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonUndoColorFont.Name = "ButtonUndoColorFont"
        Me.ButtonUndoColorFont.Size = New System.Drawing.Size(69, 76)
        Me.ButtonUndoColorFont.TabIndex = 19
        Me.ButtonUndoColorFont.Text = "Undo"
        Me.ToolTip1.SetToolTip(Me.ButtonUndoColorFont, "Unfo Font Color")
        Me.ButtonUndoColorFont.UseVisualStyleBackColor = True
        '
        'ButtonBackground
        '
        Me.ButtonBackground.Enabled = False
        Me.ButtonBackground.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonBackground.Location = New System.Drawing.Point(842, 407)
        Me.ButtonBackground.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonBackground.Name = "ButtonBackground"
        Me.ButtonBackground.Size = New System.Drawing.Size(148, 36)
        Me.ButtonBackground.TabIndex = 20
        Me.ButtonBackground.Text = "◄ Apply to Back"
        Me.ToolTip1.SetToolTip(Me.ButtonBackground, "Set Background Color of the Element")
        Me.ButtonBackground.UseVisualStyleBackColor = True
        '
        'ButtonUndoColorBackground
        '
        Me.ButtonUndoColorBackground.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonUndoColorBackground.Location = New System.Drawing.Point(994, 407)
        Me.ButtonUndoColorBackground.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonUndoColorBackground.Name = "ButtonUndoColorBackground"
        Me.ButtonUndoColorBackground.Size = New System.Drawing.Size(69, 36)
        Me.ButtonUndoColorBackground.TabIndex = 26
        Me.ButtonUndoColorBackground.Text = "Undo"
        Me.ToolTip1.SetToolTip(Me.ButtonUndoColorBackground, "Undo Background color")
        Me.ButtonUndoColorBackground.UseVisualStyleBackColor = True
        '
        'ButtonSaveColor
        '
        Me.ButtonSaveColor.Location = New System.Drawing.Point(996, 327)
        Me.ButtonSaveColor.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonSaveColor.Name = "ButtonSaveColor"
        Me.ButtonSaveColor.Size = New System.Drawing.Size(69, 36)
        Me.ButtonSaveColor.TabIndex = 24
        Me.ButtonSaveColor.Text = "Save Color"
        Me.ButtonSaveColor.UseVisualStyleBackColor = True
        Me.ButtonSaveColor.Visible = False
        '
        'rscLabelDisplayColorSelected
        '
        Me.rscLabelDisplayColorSelected.Location = New System.Drawing.Point(685, 335)
        Me.rscLabelDisplayColorSelected.MSNetColorName = Nothing
        Me.rscLabelDisplayColorSelected.Name = "rscLabelDisplayColorSelected"
        Me.rscLabelDisplayColorSelected.RSCDisplayColor = CType(resources.GetObject("rscLabelDisplayColorSelected.RSCDisplayColor"), ciBadgeInterfaces.RSCColor)
        Me.rscLabelDisplayColorSelected.Size = New System.Drawing.Size(200, 28)
        Me.rscLabelDisplayColorSelected.TabIndex = 23
        Me.rscLabelDisplayColorSelected.Visible = False
        '
        'LinkLabelAddColor1
        '
        Me.LinkLabelAddColor1.AutoSize = True
        Me.LinkLabelAddColor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabelAddColor1.Location = New System.Drawing.Point(889, 311)
        Me.LinkLabelAddColor1.Name = "LinkLabelAddColor1"
        Me.LinkLabelAddColor1.Size = New System.Drawing.Size(150, 20)
        Me.LinkLabelAddColor1.TabIndex = 27
        Me.LinkLabelAddColor1.TabStop = True
        Me.LinkLabelAddColor1.Text = "Add/Remove Colors"
        '
        'LinkLabelRefreshColors
        '
        Me.LinkLabelRefreshColors.AutoSize = True
        Me.LinkLabelRefreshColors.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabelRefreshColors.Location = New System.Drawing.Point(735, 297)
        Me.LinkLabelRefreshColors.Name = "LinkLabelRefreshColors"
        Me.LinkLabelRefreshColors.Size = New System.Drawing.Size(121, 15)
        Me.LinkLabelRefreshColors.TabIndex = 29
        Me.LinkLabelRefreshColors.TabStop = True
        Me.LinkLabelRefreshColors.Text = "Refresh Above Panel"
        '
        'ButtonApplyBF
        '
        Me.ButtonApplyBF.Enabled = False
        Me.ButtonApplyBF.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonApplyBF.Location = New System.Drawing.Point(629, 367)
        Me.ButtonApplyBF.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonApplyBF.Name = "ButtonApplyBF"
        Me.ButtonApplyBF.Size = New System.Drawing.Size(109, 36)
        Me.ButtonApplyBF.TabIndex = 32
        Me.ButtonApplyBF.Text = "◄ Apply"
        Me.ButtonApplyBF.UseVisualStyleBackColor = True
        '
        'ButtonApplyFB
        '
        Me.ButtonApplyFB.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonApplyFB.Enabled = False
        Me.ButtonApplyFB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonApplyFB.ForeColor = System.Drawing.Color.White
        Me.ButtonApplyFB.Location = New System.Drawing.Point(629, 407)
        Me.ButtonApplyFB.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonApplyFB.Name = "ButtonApplyFB"
        Me.ButtonApplyFB.Size = New System.Drawing.Size(109, 36)
        Me.ButtonApplyFB.TabIndex = 33
        Me.ButtonApplyFB.Text = "◄ Apply"
        Me.ButtonApplyFB.UseVisualStyleBackColor = False
        '
        'LabelSelected
        '
        Me.LabelSelected.AutoSize = True
        Me.LabelSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSelected.Location = New System.Drawing.Point(635, 311)
        Me.LabelSelected.Name = "LabelSelected"
        Me.LabelSelected.Size = New System.Drawing.Size(114, 20)
        Me.LabelSelected.TabIndex = 34
        Me.LabelSelected.Text = "Selected color:"
        '
        'RscColorFlowPanel1
        '
        Me.RscColorFlowPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RscColorFlowPanel1.Location = New System.Drawing.Point(645, 42)
        Me.RscColorFlowPanel1.Name = "RscColorFlowPanel1"
        Me.RscColorFlowPanel1.Size = New System.Drawing.Size(418, 252)
        Me.RscColorFlowPanel1.TabIndex = 35
        '
        'Dialog_BaseChooseColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1081, 506)
        Me.Controls.Add(Me.RscColorFlowPanel1)
        Me.Controls.Add(Me.ButtonUndoColorFont)
        Me.Controls.Add(Me.LabelSelected)
        Me.Controls.Add(Me.ButtonApplyFB)
        Me.Controls.Add(Me.ButtonApplyBF)
        Me.Controls.Add(Me.LinkLabelAddColor1)
        Me.Controls.Add(Me.ButtonUndoColorBackground)
        Me.Controls.Add(Me.ButtonSaveColor)
        Me.Controls.Add(Me.rscLabelDisplayColorSelected)
        Me.Controls.Add(Me.ButtonBackground)
        Me.Controls.Add(Me.ButtonForecolor)
        Me.Controls.Add(Me.LinkLabelRefreshColors)
        Me.Name = "Dialog_BaseChooseColor"
        Me.Text = "Dialog_BaseBackgroundColor"
        Me.Controls.SetChildIndex(Me.LinkLabelRefreshColors, 0)
        Me.Controls.SetChildIndex(Me.ButtonForecolor, 0)
        Me.Controls.SetChildIndex(Me.ButtonBackground, 0)
        Me.Controls.SetChildIndex(Me.rscLabelDisplayColorSelected, 0)
        Me.Controls.SetChildIndex(Me.ButtonSaveColor, 0)
        Me.Controls.SetChildIndex(Me.ButtonUndoColorBackground, 0)
        Me.Controls.SetChildIndex(Me.LinkLabelAddColor1, 0)
        Me.Controls.SetChildIndex(Me.ButtonApplyBF, 0)
        Me.Controls.SetChildIndex(Me.ButtonApplyFB, 0)
        Me.Controls.SetChildIndex(Me.LabelSelected, 0)
        Me.Controls.SetChildIndex(Me.ButtonUndoColorFont, 0)
        Me.Controls.SetChildIndex(Me.RscColorFlowPanel1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonForecolor As Button
    Friend WithEvents ButtonUndoColorFont As Button
    Friend WithEvents ButtonBackground As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents rscLabelDisplayColorSelected As __RSCWindowsControlLibrary.RSCColorDisplayLabel
    Friend WithEvents ButtonSaveColor As Button
    Friend WithEvents ButtonUndoColorBackground As Button
    Friend WithEvents LinkLabelAddColor1 As LinkLabel
    Friend WithEvents LinkLabelRefreshColors As LinkLabel
    Friend WithEvents RscColorFlowPanel2 As __RSCWindowsControlLibrary.RSCColorFlowPanel
    Friend WithEvents ButtonApplyBF As Button
    Friend WithEvents ButtonApplyFB As Button
    Friend WithEvents LabelSelected As Label
    Friend WithEvents RscColorFlowPanel1 As __RSCWindowsControlLibrary.RSCColorFlowPanel
End Class
