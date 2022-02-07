<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_Base
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
        Me.PanelDisplayElement = New System.Windows.Forms.Panel()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.LabelHeading1 = New System.Windows.Forms.Label()
        Me.LabelHeading2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PanelDisplayElement
        '
        Me.PanelDisplayElement.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDisplayElement.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PanelDisplayElement.Location = New System.Drawing.Point(17, 69)
        Me.PanelDisplayElement.Name = "PanelDisplayElement"
        Me.PanelDisplayElement.Size = New System.Drawing.Size(878, 146)
        Me.PanelDisplayElement.TabIndex = 1
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(628, 358)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(135, 42)
        Me.ButtonOK.TabIndex = 2
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.Location = New System.Drawing.Point(779, 358)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(135, 42)
        Me.ButtonCancel.TabIndex = 3
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'LabelHeading1
        '
        Me.LabelHeading1.AutoSize = True
        Me.LabelHeading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeading1.Location = New System.Drawing.Point(12, 9)
        Me.LabelHeading1.Name = "LabelHeading1"
        Me.LabelHeading1.Size = New System.Drawing.Size(257, 31)
        Me.LabelHeading1.TabIndex = 4
        Me.LabelHeading1.Text = "Modify the element. "
        '
        'LabelHeading2
        '
        Me.LabelHeading2.AutoSize = True
        Me.LabelHeading2.Location = New System.Drawing.Point(14, 49)
        Me.LabelHeading2.Name = "LabelHeading2"
        Me.LabelHeading2.Size = New System.Drawing.Size(608, 17)
        Me.LabelHeading2.TabIndex = 5
        Me.LabelHeading2.Text = "(See element at center of the following box.  Any edits made below the box will b" &
    "e visible within.)"
        '
        'Dialog_Base
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 412)
        Me.Controls.Add(Me.LabelHeading2)
        Me.Controls.Add(Me.LabelHeading1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.PanelDisplayElement)
        Me.Name = "Dialog_Base"
        Me.Text = "Dialog_Base"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelDisplayElement As Panel
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents LabelHeading1 As Label
    Friend WithEvents LabelHeading2 As Label
End Class
