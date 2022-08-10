<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_BaseChooseFont
    ''----Inherits System.Windows.Forms.Form ''Modified 8/7/2022 Thomas Downes  
    Inherits Dialog_Base ''Added 8/7/2022 Thomas Downes  

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
        Me.ButtonSelectFont = New System.Windows.Forms.Button()
        Me.flowLayoutFontFamilies = New System.Windows.Forms.FlowLayoutPanel()
        Me.LinkLabelAddFont = New System.Windows.Forms.LinkLabel()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.flowLayoutFontFamilies.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonSelectFont
        '
        Me.ButtonSelectFont.Location = New System.Drawing.Point(939, 90)
        Me.ButtonSelectFont.Name = "ButtonSelectFont"
        Me.ButtonSelectFont.Size = New System.Drawing.Size(156, 44)
        Me.ButtonSelectFont.TabIndex = 20
        Me.ButtonSelectFont.Text = "Confirm Selection"
        Me.ButtonSelectFont.UseVisualStyleBackColor = True
        '
        'flowLayoutFontFamilies
        '
        Me.flowLayoutFontFamilies.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flowLayoutFontFamilies.Controls.Add(Me.LinkLabelAddFont)
        Me.flowLayoutFontFamilies.Location = New System.Drawing.Point(625, 90)
        Me.flowLayoutFontFamilies.Name = "flowLayoutFontFamilies"
        Me.flowLayoutFontFamilies.Size = New System.Drawing.Size(298, 287)
        Me.flowLayoutFontFamilies.TabIndex = 21
        '
        'LinkLabelAddFont
        '
        Me.LinkLabelAddFont.AutoSize = True
        Me.LinkLabelAddFont.Location = New System.Drawing.Point(13, 13)
        Me.LinkLabelAddFont.Margin = New System.Windows.Forms.Padding(13)
        Me.LinkLabelAddFont.Name = "LinkLabelAddFont"
        Me.LinkLabelAddFont.Size = New System.Drawing.Size(93, 13)
        Me.LinkLabelAddFont.TabIndex = 2
        Me.LinkLabelAddFont.TabStop = True
        Me.LinkLabelAddFont.Text = "Add a Font to Use"
        '
        'Dialog_BaseChooseFont
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 486)
        Me.Controls.Add(Me.flowLayoutFontFamilies)
        Me.Controls.Add(Me.ButtonSelectFont)
        Me.Name = "Dialog_BaseChooseFont"
        Me.Text = "Dialog_BaseChooseFont"
        Me.Controls.SetChildIndex(Me.ButtonSelectFont, 0)
        Me.Controls.SetChildIndex(Me.flowLayoutFontFamilies, 0)
        Me.flowLayoutFontFamilies.ResumeLayout(False)
        Me.flowLayoutFontFamilies.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonSelectFont As Button
    Friend WithEvents flowLayoutFontFamilies As FlowLayoutPanel
    Friend WithEvents LinkLabelAddFont As LinkLabel
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents ToolTip1 As ToolTip
End Class
