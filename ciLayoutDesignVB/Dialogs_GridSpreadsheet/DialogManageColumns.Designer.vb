<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogManageColumns
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
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ButtonSelectLoaded = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.LabelHeader2 = New System.Windows.Forms.Label()
        Me.ButtonMoveLeft = New System.Windows.Forms.Button()
        Me.ButtonMoveRight = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(12, 26)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(329, 29)
        Me.LabelHeader1.TabIndex = 0
        Me.LabelHeader1.Text = "Manage Spreadsheet Fields"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.PowderBlue
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 72)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(899, 100)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'ButtonSelectLoaded
        '
        Me.ButtonSelectLoaded.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonSelectLoaded.Enabled = False
        Me.ButtonSelectLoaded.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSelectLoaded.Location = New System.Drawing.Point(12, 182)
        Me.ButtonSelectLoaded.Name = "ButtonSelectLoaded"
        Me.ButtonSelectLoaded.Size = New System.Drawing.Size(285, 40)
        Me.ButtonSelectLoaded.TabIndex = 8
        Me.ButtonSelectLoaded.Text = "Add/Remove Relevant Fields"
        Me.ButtonSelectLoaded.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Enabled = False
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(685, 182)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(91, 40)
        Me.ButtonOK.TabIndex = 9
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(782, 182)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(129, 40)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'LabelHeader2
        '
        Me.LabelHeader2.AutoSize = True
        Me.LabelHeader2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader2.Location = New System.Drawing.Point(375, 31)
        Me.LabelHeader2.Name = "LabelHeader2"
        Me.LabelHeader2.Size = New System.Drawing.Size(477, 22)
        Me.LabelHeader2.TabIndex = 11
        Me.LabelHeader2.Text = "Toggle selection by clicking, use arrow buttons to re-order."
        '
        'ButtonMoveLeft
        '
        Me.ButtonMoveLeft.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonMoveLeft.BackColor = System.Drawing.Color.Cyan
        Me.ButtonMoveLeft.Enabled = False
        Me.ButtonMoveLeft.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonMoveLeft.Location = New System.Drawing.Point(317, 181)
        Me.ButtonMoveLeft.Name = "ButtonMoveLeft"
        Me.ButtonMoveLeft.Size = New System.Drawing.Size(69, 40)
        Me.ButtonMoveLeft.TabIndex = 12
        Me.ButtonMoveLeft.Text = "◄"
        Me.ButtonMoveLeft.UseVisualStyleBackColor = False
        '
        'ButtonMoveRight
        '
        Me.ButtonMoveRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonMoveRight.BackColor = System.Drawing.Color.Cyan
        Me.ButtonMoveRight.Enabled = False
        Me.ButtonMoveRight.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonMoveRight.Location = New System.Drawing.Point(392, 181)
        Me.ButtonMoveRight.Name = "ButtonMoveRight"
        Me.ButtonMoveRight.Size = New System.Drawing.Size(64, 40)
        Me.ButtonMoveRight.TabIndex = 13
        Me.ButtonMoveRight.Text = "►"
        Me.ButtonMoveRight.UseVisualStyleBackColor = False
        '
        'DialogManageColumns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 234)
        Me.Controls.Add(Me.ButtonMoveRight)
        Me.Controls.Add(Me.ButtonMoveLeft)
        Me.Controls.Add(Me.LabelHeader2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.ButtonSelectLoaded)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.LabelHeader1)
        Me.KeyPreview = True
        Me.Name = "DialogManageColumns"
        Me.Text = "DialogAddColumns"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents ButtonSelectLoaded As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents LabelHeader2 As Label
    Friend WithEvents ButtonMoveLeft As Button
    Friend WithEvents ButtonMoveRight As Button
End Class
