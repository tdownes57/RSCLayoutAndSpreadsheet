<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RSCDataCell
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Textbox1a = New System.Windows.Forms.TextBox()
        Me.LinkLabelCrLf = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelOutlier = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelEmptyRow = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Textbox1a
        '
        Me.Textbox1a.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Textbox1a.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Textbox1a.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textbox1a.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Textbox1a.Location = New System.Drawing.Point(0, 0)
        Me.Textbox1a.Margin = New System.Windows.Forms.Padding(2)
        Me.Textbox1a.Multiline = True
        Me.Textbox1a.Name = "Textbox1a"
        Me.Textbox1a.Size = New System.Drawing.Size(150, 23)
        Me.Textbox1a.TabIndex = 37
        '
        'LinkLabelCrLf
        '
        Me.LinkLabelCrLf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelCrLf.AutoSize = True
        Me.LinkLabelCrLf.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabelCrLf.Location = New System.Drawing.Point(121, 0)
        Me.LinkLabelCrLf.Name = "LinkLabelCrLf"
        Me.LinkLabelCrLf.Size = New System.Drawing.Size(26, 13)
        Me.LinkLabelCrLf.TabIndex = 38
        Me.LinkLabelCrLf.TabStop = True
        Me.LinkLabelCrLf.Text = "CrLf"
        Me.LinkLabelCrLf.Visible = False
        '
        'LinkLabelOutlier
        '
        Me.LinkLabelOutlier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelOutlier.AutoSize = True
        Me.LinkLabelOutlier.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabelOutlier.Location = New System.Drawing.Point(110, 0)
        Me.LinkLabelOutlier.Name = "LinkLabelOutlier"
        Me.LinkLabelOutlier.Size = New System.Drawing.Size(37, 13)
        Me.LinkLabelOutlier.TabIndex = 39
        Me.LinkLabelOutlier.TabStop = True
        Me.LinkLabelOutlier.Text = "Outlier"
        Me.LinkLabelOutlier.Visible = False
        '
        'LinkLabelEmptyRow
        '
        Me.LinkLabelEmptyRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelEmptyRow.AutoSize = True
        Me.LinkLabelEmptyRow.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabelEmptyRow.Location = New System.Drawing.Point(3, 0)
        Me.LinkLabelEmptyRow.Name = "LinkLabelEmptyRow"
        Me.LinkLabelEmptyRow.Size = New System.Drawing.Size(70, 13)
        Me.LinkLabelEmptyRow.TabIndex = 40
        Me.LinkLabelEmptyRow.TabStop = True
        Me.LinkLabelEmptyRow.Tag = "Row has data in unselected fields"
        Me.LinkLabelEmptyRow.Text = "Row is empty"
        Me.LinkLabelEmptyRow.Visible = False
        '
        'RSCDataCell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LinkLabelEmptyRow)
        Me.Controls.Add(Me.LinkLabelOutlier)
        Me.Controls.Add(Me.LinkLabelCrLf)
        Me.Controls.Add(Me.Textbox1a)
        Me.Name = "RSCDataCell"
        Me.Size = New System.Drawing.Size(150, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Textbox1a As TextBox
    Friend WithEvents LinkLabelCrLf As LinkLabel
    Friend WithEvents LinkLabelOutlier As LinkLabel
    Friend WithEvents LinkLabelEmptyRow As LinkLabel
End Class
