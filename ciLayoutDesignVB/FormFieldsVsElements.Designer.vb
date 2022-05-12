<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFieldsVsElements
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
        Me.ButtonAddFields = New System.Windows.Forms.Button()
        Me.ButtonAddElements = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LabelFooter1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonAddFields
        '
        Me.ButtonAddFields.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAddFields.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAddFields.Location = New System.Drawing.Point(43, 30)
        Me.ButtonAddFields.Name = "ButtonAddFields"
        Me.ButtonAddFields.Size = New System.Drawing.Size(348, 57)
        Me.ButtonAddFields.TabIndex = 0
        Me.ButtonAddFields.Text = "Add Data Fields *"
        Me.ToolTip1.SetToolTip(Me.ButtonAddFields, "Add or Remove Data Fields")
        Me.ButtonAddFields.UseVisualStyleBackColor = True
        '
        'ButtonAddElements
        '
        Me.ButtonAddElements.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAddElements.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAddElements.Location = New System.Drawing.Point(43, 103)
        Me.ButtonAddElements.Name = "ButtonAddElements"
        Me.ButtonAddElements.Size = New System.Drawing.Size(348, 57)
        Me.ButtonAddElements.TabIndex = 1
        Me.ButtonAddElements.Text = "Add Graphical Elements"
        Me.ButtonAddElements.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.Location = New System.Drawing.Point(287, 180)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(104, 35)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'LabelFooter1
        '
        Me.LabelFooter1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelFooter1.AutoSize = True
        Me.LabelFooter1.Location = New System.Drawing.Point(12, 228)
        Me.LabelFooter1.Name = "LabelFooter1"
        Me.LabelFooter1.Size = New System.Drawing.Size(344, 13)
        Me.LabelFooter1.TabIndex = 3
        Me.LabelFooter1.Text = "* Add or Remove data fields.   Fields are designated as Relevant or not."
        '
        'FormFieldsVsElements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 250)
        Me.Controls.Add(Me.LabelFooter1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonAddElements)
        Me.Controls.Add(Me.ButtonAddFields)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FormFieldsVsElements"
        Me.Text = "FormFieldsVsElements"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonAddFields As Button
    Friend WithEvents ButtonAddElements As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents LabelFooter1 As Label
End Class
