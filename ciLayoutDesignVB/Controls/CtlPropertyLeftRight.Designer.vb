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
        Me.LabelProperty = New System.Windows.Forms.Label()
        Me.ButtonFontIncrease = New System.Windows.Forms.Button()
        Me.ButtonFontDecrease = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LabelProperty
        '
        Me.LabelProperty.BackColor = System.Drawing.Color.Transparent
        Me.LabelProperty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelProperty.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProperty.Location = New System.Drawing.Point(0, 0)
        Me.LabelProperty.Name = "LabelProperty"
        Me.LabelProperty.Size = New System.Drawing.Size(233, 139)
        Me.LabelProperty.TabIndex = 24
        Me.LabelProperty.Tag = "Property: {0}"
        Me.LabelProperty.Text = "Property: {0}"
        '
        'ButtonFontIncrease
        '
        Me.ButtonFontIncrease.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonFontIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFontIncrease.Location = New System.Drawing.Point(107, 70)
        Me.ButtonFontIncrease.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonFontIncrease.Name = "ButtonFontIncrease"
        Me.ButtonFontIncrease.Size = New System.Drawing.Size(67, 49)
        Me.ButtonFontIncrease.TabIndex = 26
        Me.ButtonFontIncrease.Text = ">"
        Me.ButtonFontIncrease.UseVisualStyleBackColor = True
        '
        'ButtonFontDecrease
        '
        Me.ButtonFontDecrease.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonFontDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFontDecrease.Location = New System.Drawing.Point(35, 70)
        Me.ButtonFontDecrease.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonFontDecrease.Name = "ButtonFontDecrease"
        Me.ButtonFontDecrease.Size = New System.Drawing.Size(67, 49)
        Me.ButtonFontDecrease.TabIndex = 25
        Me.ButtonFontDecrease.Text = "<"
        Me.ButtonFontDecrease.UseVisualStyleBackColor = True
        '
        'CtlPropertyLeftRight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Plum
        Me.Controls.Add(Me.ButtonFontIncrease)
        Me.Controls.Add(Me.ButtonFontDecrease)
        Me.Controls.Add(Me.LabelProperty)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "CtlPropertyLeftRight"
        Me.Size = New System.Drawing.Size(233, 139)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelProperty As Label
    Friend WithEvents ButtonFontIncrease As Button
    Friend WithEvents ButtonFontDecrease As Button
End Class
