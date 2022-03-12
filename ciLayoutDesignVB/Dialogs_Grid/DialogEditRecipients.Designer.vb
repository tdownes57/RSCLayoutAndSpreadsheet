<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogEditRecipients
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
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.ButtonPasteData = New System.Windows.Forms.Button()
        Me.RscFieldSpreadsheet1 = New ciBadgeDesigner.RSCFieldSpreadsheet()
        Me.SuspendLayout()
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(848, 544)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(58, 48)
        Me.ButtonCancel.TabIndex = 15
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Location = New System.Drawing.Point(737, 544)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(94, 48)
        Me.ButtonOK.TabIndex = 14
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(401, 24)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Paste && Edit Recipients (Students or Members)"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(9, 544)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(198, 13)
        Me.LinkLabel1.TabIndex = 17
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Review Fields / Mark Fields as Relevant"
        '
        'ButtonPasteData
        '
        Me.ButtonPasteData.Location = New System.Drawing.Point(9, 39)
        Me.ButtonPasteData.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonPasteData.Name = "ButtonPasteData"
        Me.ButtonPasteData.Size = New System.Drawing.Size(277, 28)
        Me.ButtonPasteData.TabIndex = 18
        Me.ButtonPasteData.Text = "Paste Data   (...from MS Excel or Google Sheets)"
        Me.ButtonPasteData.UseVisualStyleBackColor = True
        '
        'RscFieldSpreadsheet1
        '
        Me.RscFieldSpreadsheet1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RscFieldSpreadsheet1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RscFieldSpreadsheet1.Location = New System.Drawing.Point(9, 71)
        Me.RscFieldSpreadsheet1.Margin = New System.Windows.Forms.Padding(2)
        Me.RscFieldSpreadsheet1.Name = "RscFieldSpreadsheet1"
        Me.RscFieldSpreadsheet1.Size = New System.Drawing.Size(875, 451)
        Me.RscFieldSpreadsheet1.TabIndex = 19
        '
        'DialogEditRecipients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 600)
        Me.Controls.Add(Me.RscFieldSpreadsheet1)
        Me.Controls.Add(Me.ButtonPasteData)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "DialogEditRecipients"
        Me.Text = "DialogEditRecipients"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents ButtonPasteData As Button
    Friend WithEvents RscFieldSpreadsheet1 As ciBadgeDesigner.RSCFieldSpreadsheet
End Class
