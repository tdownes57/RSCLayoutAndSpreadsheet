<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlPropertyLeftRight
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
        Me.LabelProperty = New System.Windows.Forms.Label()
        Me.ButtonIncrease = New System.Windows.Forms.Button()
        Me.ButtonDecrease = New System.Windows.Forms.Button()
        Me.Numeric1 = New System.Windows.Forms.NumericUpDown()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.Numeric1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelProperty
        '
        Me.LabelProperty.BackColor = System.Drawing.Color.Transparent
        Me.LabelProperty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelProperty.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProperty.Location = New System.Drawing.Point(0, 0)
        Me.LabelProperty.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelProperty.Name = "LabelProperty"
        Me.LabelProperty.Size = New System.Drawing.Size(175, 113)
        Me.LabelProperty.TabIndex = 24
        Me.LabelProperty.Tag = "Property: {0}"
        Me.LabelProperty.Text = "Property: {0}"
        '
        'ButtonIncrease
        '
        Me.ButtonIncrease.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonIncrease.Location = New System.Drawing.Point(58, 55)
        Me.ButtonIncrease.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonIncrease.Name = "ButtonIncrease"
        Me.ButtonIncrease.Size = New System.Drawing.Size(50, 40)
        Me.ButtonIncrease.TabIndex = 26
        Me.ButtonIncrease.Text = ">"
        Me.ButtonIncrease.UseVisualStyleBackColor = True
        '
        'ButtonDecrease
        '
        Me.ButtonDecrease.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDecrease.Location = New System.Drawing.Point(4, 55)
        Me.ButtonDecrease.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonDecrease.Name = "ButtonDecrease"
        Me.ButtonDecrease.Size = New System.Drawing.Size(50, 40)
        Me.ButtonDecrease.TabIndex = 25
        Me.ButtonDecrease.Text = "<"
        Me.ButtonDecrease.UseVisualStyleBackColor = True
        '
        'Numeric1
        '
        Me.Numeric1.Location = New System.Drawing.Point(113, 55)
        Me.Numeric1.Name = "Numeric1"
        Me.Numeric1.Size = New System.Drawing.Size(39, 20)
        Me.Numeric1.TabIndex = 27
        Me.ToolTip1.SetToolTip(Me.Numeric1, "Change how much each <> button changes the value.")
        Me.Numeric1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'CtlPropertyLeftRight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Plum
        Me.Controls.Add(Me.Numeric1)
        Me.Controls.Add(Me.ButtonIncrease)
        Me.Controls.Add(Me.ButtonDecrease)
        Me.Controls.Add(Me.LabelProperty)
        Me.Name = "CtlPropertyLeftRight"
        Me.Size = New System.Drawing.Size(175, 113)
        CType(Me.Numeric1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelProperty As Label
    Friend WithEvents ButtonIncrease As Button
    Friend WithEvents ButtonDecrease As Button
    Friend WithEvents Numeric1 As NumericUpDown
    Friend WithEvents ToolTip1 As ToolTip
End Class
