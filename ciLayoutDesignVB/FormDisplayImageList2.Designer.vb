<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDisplayImageList2
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
        Me.ButtonRefresh = New System.Windows.Forms.Button()
        Me.LabelHeaderCaption = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'ButtonRefresh
        '
        Me.ButtonRefresh.Location = New System.Drawing.Point(596, 24)
        Me.ButtonRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.Size = New System.Drawing.Size(216, 47)
        Me.ButtonRefresh.TabIndex = 8
        Me.ButtonRefresh.Text = "Refresh"
        Me.ButtonRefresh.UseVisualStyleBackColor = True
        '
        'LabelHeaderCaption
        '
        Me.LabelHeaderCaption.AutoSize = True
        Me.LabelHeaderCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeaderCaption.Location = New System.Drawing.Point(10, 24)
        Me.LabelHeaderCaption.Name = "LabelHeaderCaption"
        Me.LabelHeaderCaption.Size = New System.Drawing.Size(216, 36)
        Me.LabelHeaderCaption.TabIndex = 7
        Me.LabelHeaderCaption.Tag = "Custom Fields - {0}"
        Me.LabelHeaderCaption.Text = "Display Images"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Thistle
        Me.Panel1.Location = New System.Drawing.Point(16, 90)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(796, 484)
        Me.Panel1.TabIndex = 9
        '
        'FormDisplayImageList2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 608)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonRefresh)
        Me.Controls.Add(Me.LabelHeaderCaption)
        Me.Name = "FormDisplayImageList2"
        Me.Text = "FormDisplayImageList2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonRefresh As Button
    Friend WithEvents LabelHeaderCaption As Label
    Friend WithEvents Panel1 As Panel
End Class
