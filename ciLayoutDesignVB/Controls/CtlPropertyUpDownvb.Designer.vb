<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlPropertyUpDownvb
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
        Me.ButtonFontIncrease = New System.Windows.Forms.Button()
        Me.ButtonFontDecrease = New System.Windows.Forms.Button()
        Me.LabelProperty = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonFontIncrease
        '
        Me.ButtonFontIncrease.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonFontIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFontIncrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.IncreaseY
        Me.ButtonFontIncrease.Location = New System.Drawing.Point(7, 73)
        Me.ButtonFontIncrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonFontIncrease.Name = "ButtonFontIncrease"
        Me.ButtonFontIncrease.Size = New System.Drawing.Size(50, 27)
        Me.ButtonFontIncrease.TabIndex = 22
        Me.ButtonFontIncrease.UseVisualStyleBackColor = True
        '
        'ButtonFontDecrease
        '
        Me.ButtonFontDecrease.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonFontDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFontDecrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.DecreaseY
        Me.ButtonFontDecrease.Location = New System.Drawing.Point(7, 42)
        Me.ButtonFontDecrease.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonFontDecrease.Name = "ButtonFontDecrease"
        Me.ButtonFontDecrease.Size = New System.Drawing.Size(50, 27)
        Me.ButtonFontDecrease.TabIndex = 21
        Me.ButtonFontDecrease.UseVisualStyleBackColor = True
        '
        'LabelProperty
        '
        Me.LabelProperty.BackColor = System.Drawing.Color.Plum
        Me.LabelProperty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelProperty.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProperty.Location = New System.Drawing.Point(0, 0)
        Me.LabelProperty.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelProperty.Name = "LabelProperty"
        Me.LabelProperty.Size = New System.Drawing.Size(164, 106)
        Me.LabelProperty.TabIndex = 23
        Me.LabelProperty.Tag = "Property: {0}"
        Me.LabelProperty.Text = "Property: {0}"
        '
        'CtlPropertyUpDownvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Plum
        Me.Controls.Add(Me.ButtonFontIncrease)
        Me.Controls.Add(Me.ButtonFontDecrease)
        Me.Controls.Add(Me.LabelProperty)
        Me.Name = "CtlPropertyUpDownvb"
        Me.Size = New System.Drawing.Size(164, 106)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonFontIncrease As Button
    Friend WithEvents ButtonFontDecrease As Button
    Friend WithEvents LabelProperty As Label
End Class
