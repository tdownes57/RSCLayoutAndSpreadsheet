<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlWidthHeight
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.textHeight = New System.Windows.Forms.TextBox()
        Me.textWidth = New System.Windows.Forms.TextBox()
        Me.LabelRatioMessage = New System.Windows.Forms.Label()
        Me.LabelLossOfPixelsHeight = New System.Windows.Forms.Label()
        Me.LabelLossOfPixelsWidth = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 8)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 26)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Height"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(218, 11)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 26)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "/ Width"
        '
        'textHeight
        '
        Me.textHeight.Location = New System.Drawing.Point(99, 8)
        Me.textHeight.Margin = New System.Windows.Forms.Padding(8)
        Me.textHeight.Name = "textHeight"
        Me.textHeight.Size = New System.Drawing.Size(117, 32)
        Me.textHeight.TabIndex = 12
        '
        'textWidth
        '
        Me.textWidth.Location = New System.Drawing.Point(299, 8)
        Me.textWidth.Margin = New System.Windows.Forms.Padding(8)
        Me.textWidth.Name = "textWidth"
        Me.textWidth.Size = New System.Drawing.Size(109, 32)
        Me.textWidth.TabIndex = 11
        '
        'LabelRatioMessage
        '
        Me.LabelRatioMessage.AutoSize = True
        Me.LabelRatioMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRatioMessage.Location = New System.Drawing.Point(3, 48)
        Me.LabelRatioMessage.Name = "LabelRatioMessage"
        Me.LabelRatioMessage.Size = New System.Drawing.Size(540, 18)
        Me.LabelRatioMessage.TabIndex = 15
        Me.LabelRatioMessage.Tag = "The ratio of these values is {0:0.00}. PVC cards have a ratio of 2.13/3.38, or 0." &
    "63"
        Me.LabelRatioMessage.Text = "The ratio of these values is {0:0.00}. PVC cards have a ratio of 2.13 / 3.38, or " &
    "0.63"
        '
        'LabelLossOfPixelsHeight
        '
        Me.LabelLossOfPixelsHeight.AutoSize = True
        Me.LabelLossOfPixelsHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLossOfPixelsHeight.Location = New System.Drawing.Point(13, 75)
        Me.LabelLossOfPixelsHeight.Name = "LabelLossOfPixelsHeight"
        Me.LabelLossOfPixelsHeight.Size = New System.Drawing.Size(237, 18)
        Me.LabelLossOfPixelsHeight.TabIndex = 16
        Me.LabelLossOfPixelsHeight.Tag = "Potential loss of pixels: {0} (Height)"
        Me.LabelLossOfPixelsHeight.Text = "Potential loss of pixels: {0} (Height)"
        '
        'LabelLossOfPixelsWidth
        '
        Me.LabelLossOfPixelsWidth.AutoSize = True
        Me.LabelLossOfPixelsWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLossOfPixelsWidth.Location = New System.Drawing.Point(269, 75)
        Me.LabelLossOfPixelsWidth.Name = "LabelLossOfPixelsWidth"
        Me.LabelLossOfPixelsWidth.Size = New System.Drawing.Size(233, 18)
        Me.LabelLossOfPixelsWidth.TabIndex = 17
        Me.LabelLossOfPixelsWidth.Tag = "Potential loss of pixels: {0} (Width)"
        Me.LabelLossOfPixelsWidth.Text = "Potential loss of pixels: {0} (Width)"
        '
        'CtlWidthHeight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 26.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelLossOfPixelsWidth)
        Me.Controls.Add(Me.LabelLossOfPixelsHeight)
        Me.Controls.Add(Me.LabelRatioMessage)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.textHeight)
        Me.Controls.Add(Me.textWidth)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "CtlWidthHeight"
        Me.Size = New System.Drawing.Size(551, 103)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents textHeight As TextBox
    Friend WithEvents textWidth As TextBox
    Friend WithEvents LabelRatioMessage As Label
    Friend WithEvents LabelLossOfPixelsHeight As Label
    Friend WithEvents LabelLossOfPixelsWidth As Label
End Class
