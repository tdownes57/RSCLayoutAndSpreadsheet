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
        Me.RscColorFlowPanel1 = New __RSCWindowsControlLibrary.RSCColorFlowPanel()
        Me.rscLabelDisplayColorSelected = New __RSCWindowsControlLibrary.RSCColorDisplayLabel()
        Me.LinkLabelAddColor1 = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'ButtonForecolor
        '
        Me.ButtonForecolor.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonForecolor.Location = New System.Drawing.Point(648, 359)
        Me.ButtonForecolor.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonForecolor.Name = "ButtonForecolor"
        Me.ButtonForecolor.Size = New System.Drawing.Size(164, 36)
        Me.ButtonForecolor.TabIndex = 12
        Me.ButtonForecolor.Text = "◄ Apply to Font"
        Me.ButtonForecolor.UseVisualStyleBackColor = True
        '
        'ButtonUndoColorFont
        '
        Me.ButtonUndoColorFont.Location = New System.Drawing.Point(816, 359)
        Me.ButtonUndoColorFont.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonUndoColorFont.Name = "ButtonUndoColorFont"
        Me.ButtonUndoColorFont.Size = New System.Drawing.Size(69, 36)
        Me.ButtonUndoColorFont.TabIndex = 19
        Me.ButtonUndoColorFont.Text = "Undo"
        Me.ToolTip1.SetToolTip(Me.ButtonUndoColorFont, "Unfo Font Color")
        Me.ButtonUndoColorFont.UseVisualStyleBackColor = True
        '
        'ButtonBackground
        '
        Me.ButtonBackground.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonBackground.Location = New System.Drawing.Point(629, 399)
        Me.ButtonBackground.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonBackground.Name = "ButtonBackground"
        Me.ButtonBackground.Size = New System.Drawing.Size(224, 36)
        Me.ButtonBackground.TabIndex = 20
        Me.ButtonBackground.Text = "◄ Apply to Background"
        Me.ToolTip1.SetToolTip(Me.ButtonBackground, "Set Background Color of the Element")
        Me.ButtonBackground.UseVisualStyleBackColor = True
        '
        'ButtonUndoColorBackground
        '
        Me.ButtonUndoColorBackground.Location = New System.Drawing.Point(857, 399)
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
        Me.ButtonSaveColor.Location = New System.Drawing.Point(970, 342)
        Me.ButtonSaveColor.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonSaveColor.Name = "ButtonSaveColor"
        Me.ButtonSaveColor.Size = New System.Drawing.Size(69, 36)
        Me.ButtonSaveColor.TabIndex = 24
        Me.ButtonSaveColor.Text = "Save Color"
        Me.ButtonSaveColor.UseVisualStyleBackColor = True
        Me.ButtonSaveColor.Visible = False
        '
        'RscColorFlowPanel1
        '
        Me.RscColorFlowPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RscColorFlowPanel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RscColorFlowPanel1.Location = New System.Drawing.Point(629, 39)
        Me.RscColorFlowPanel1.Name = "RscColorFlowPanel1"
        Me.RscColorFlowPanel1.Size = New System.Drawing.Size(410, 269)
        Me.RscColorFlowPanel1.TabIndex = 25
        '
        'rscLabelDisplayColorSelected
        '
        Me.rscLabelDisplayColorSelected.Location = New System.Drawing.Point(629, 320)
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
        'Dialog_BaseChooseColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 506)
        Me.Controls.Add(Me.LinkLabelAddColor1)
        Me.Controls.Add(Me.ButtonUndoColorBackground)
        Me.Controls.Add(Me.RscColorFlowPanel1)
        Me.Controls.Add(Me.ButtonSaveColor)
        Me.Controls.Add(Me.rscLabelDisplayColorSelected)
        Me.Controls.Add(Me.ButtonBackground)
        Me.Controls.Add(Me.ButtonUndoColorFont)
        Me.Controls.Add(Me.ButtonForecolor)
        Me.Name = "Dialog_BaseChooseColor"
        Me.Text = "Dialog_BaseBackgroundColor"
        Me.Controls.SetChildIndex(Me.ButtonForecolor, 0)
        Me.Controls.SetChildIndex(Me.ButtonUndoColorFont, 0)
        Me.Controls.SetChildIndex(Me.ButtonBackground, 0)
        Me.Controls.SetChildIndex(Me.rscLabelDisplayColorSelected, 0)
        Me.Controls.SetChildIndex(Me.ButtonSaveColor, 0)
        Me.Controls.SetChildIndex(Me.RscColorFlowPanel1, 0)
        Me.Controls.SetChildIndex(Me.ButtonUndoColorBackground, 0)
        Me.Controls.SetChildIndex(Me.LinkLabelAddColor1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonForecolor As Button
    Friend WithEvents ButtonUndoColorFont As Button
    Friend WithEvents ButtonBackground As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents rscLabelDisplayColorSelected As __RSCWindowsControlLibrary.RSCColorDisplayLabel
    Friend WithEvents ButtonSaveColor As Button
    Friend WithEvents RscColorFlowPanel1 As __RSCWindowsControlLibrary.RSCColorFlowPanel
    Friend WithEvents ButtonUndoColorBackground As Button
    Friend WithEvents LinkLabelAddColor1 As LinkLabel
End Class
