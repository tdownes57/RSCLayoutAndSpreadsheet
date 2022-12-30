<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCColorLabelInvertedText
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.LabelBackcolorLeft = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'LabelBackcolorLeft
        '
        Me.LabelBackcolorLeft.BackColor = System.Drawing.Color.Blue
        Me.LabelBackcolorLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBackcolorLeft.ForeColor = System.Drawing.Color.Yellow
        Me.LabelBackcolorLeft.Location = New System.Drawing.Point(0, 0)
        Me.LabelBackcolorLeft.Name = "LabelBackcolorLeft"
        Me.LabelBackcolorLeft.Size = New System.Drawing.Size(200, 25)
        Me.LabelBackcolorLeft.TabIndex = 9
        Me.LabelBackcolorLeft.Text = "Text / Name of Color"
        Me.LabelBackcolorLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RSCColorLabelInvertedText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelBackcolorLeft)
        Me.Name = "RSCColorLabelInvertedText"
        Me.Size = New System.Drawing.Size(200, 25)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelBackcolorLeft As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
