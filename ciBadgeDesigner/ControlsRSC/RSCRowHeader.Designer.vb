<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCRowHeader
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
        Me.PictureBox1a = New System.Windows.Forms.PictureBox()
        Me.textRowHeader1 = New System.Windows.Forms.Label()
        Me.LinkLabelShowID = New System.Windows.Forms.LinkLabel()
        CType(Me.PictureBox1a, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1a
        '
        Me.PictureBox1a.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1a.BackColor = System.Drawing.Color.Plum
        Me.PictureBox1a.Location = New System.Drawing.Point(0, 22)
        Me.PictureBox1a.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1a.Name = "PictureBox1a"
        Me.PictureBox1a.Size = New System.Drawing.Size(149, 2)
        Me.PictureBox1a.TabIndex = 96
        Me.PictureBox1a.TabStop = False
        Me.PictureBox1a.Visible = False
        '
        'textRowHeader1
        '
        Me.textRowHeader1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textRowHeader1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.textRowHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textRowHeader1.ForeColor = System.Drawing.Color.Black
        Me.textRowHeader1.Location = New System.Drawing.Point(0, 0)
        Me.textRowHeader1.Margin = New System.Windows.Forms.Padding(0)
        Me.textRowHeader1.Name = "textRowHeader1"
        Me.textRowHeader1.Size = New System.Drawing.Size(143, 22)
        Me.textRowHeader1.TabIndex = 95
        Me.textRowHeader1.Text = "1"
        Me.textRowHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LinkLabelShowID
        '
        Me.LinkLabelShowID.AutoSize = True
        Me.LinkLabelShowID.Location = New System.Drawing.Point(-3, 0)
        Me.LinkLabelShowID.Name = "LinkLabelShowID"
        Me.LinkLabelShowID.Size = New System.Drawing.Size(48, 13)
        Me.LinkLabelShowID.TabIndex = 97
        Me.LinkLabelShowID.TabStop = True
        Me.LinkLabelShowID.Text = "Show ID"
        Me.LinkLabelShowID.Visible = False
        '
        'RSCRowHeader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LinkLabelShowID)
        Me.Controls.Add(Me.PictureBox1a)
        Me.Controls.Add(Me.textRowHeader1)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "RSCRowHeader"
        Me.Size = New System.Drawing.Size(150, 24)
        CType(Me.PictureBox1a, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1a As PictureBox
    Friend WithEvents textRowHeader1 As Label
    Friend WithEvents LinkLabelShowID As LinkLabel
End Class
