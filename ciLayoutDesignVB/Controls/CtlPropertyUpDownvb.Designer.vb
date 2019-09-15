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
        Me.ButtonIncrease = New System.Windows.Forms.Button()
        Me.ButtonDecrease = New System.Windows.Forms.Button()
        Me.LabelProperty = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonIncrease
        '
        Me.ButtonIncrease.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonIncrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.IncreaseY
        Me.ButtonIncrease.Location = New System.Drawing.Point(9, 90)
        Me.ButtonIncrease.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonIncrease.Name = "ButtonIncrease"
        Me.ButtonIncrease.Size = New System.Drawing.Size(67, 33)
        Me.ButtonIncrease.TabIndex = 22
        Me.ButtonIncrease.UseVisualStyleBackColor = True
        '
        'ButtonDecrease
        '
        Me.ButtonDecrease.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonDecrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDecrease.Image = Global.ciLayoutDesignVB.My.Resources.Resources.DecreaseY
        Me.ButtonDecrease.Location = New System.Drawing.Point(9, 52)
        Me.ButtonDecrease.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonDecrease.Name = "ButtonDecrease"
        Me.ButtonDecrease.Size = New System.Drawing.Size(67, 33)
        Me.ButtonDecrease.TabIndex = 21
        Me.ButtonDecrease.UseVisualStyleBackColor = True
        '
        'LabelProperty
        '
        Me.LabelProperty.BackColor = System.Drawing.Color.Plum
        Me.LabelProperty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelProperty.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProperty.Location = New System.Drawing.Point(0, 0)
        Me.LabelProperty.Name = "LabelProperty"
        Me.LabelProperty.Size = New System.Drawing.Size(219, 130)
        Me.LabelProperty.TabIndex = 23
        Me.LabelProperty.Tag = "Property: {0}"
        Me.LabelProperty.Text = "Property: {0}"
        '
        'CtlPropertyUpDownvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Plum
        Me.Controls.Add(Me.ButtonIncrease)
        Me.Controls.Add(Me.ButtonDecrease)
        Me.Controls.Add(Me.LabelProperty)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "CtlPropertyUpDownvb"
        Me.Size = New System.Drawing.Size(219, 130)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonIncrease As Button
    Friend WithEvents ButtonDecrease As Button
    Friend WithEvents LabelProperty As Label
End Class
