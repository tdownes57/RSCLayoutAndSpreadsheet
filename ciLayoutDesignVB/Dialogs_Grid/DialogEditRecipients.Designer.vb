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
        Me.RscFieldSpreadsheet1 = New __RSCWindowsControlLibrary.RSCFieldSpreadsheet()
        Me.SuspendLayout()
        '
        'RscFieldSpreadsheet1
        '
        Me.RscFieldSpreadsheet1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RscFieldSpreadsheet1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RscFieldSpreadsheet1.Location = New System.Drawing.Point(-1, 1)
        Me.RscFieldSpreadsheet1.Name = "RscFieldSpreadsheet1"
        Me.RscFieldSpreadsheet1.Size = New System.Drawing.Size(433, 600)
        Me.RscFieldSpreadsheet1.TabIndex = 0
        '
        'DialogEditRecipients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 653)
        Me.Controls.Add(Me.RscFieldSpreadsheet1)
        Me.Name = "DialogEditRecipients"
        Me.Text = "DialogEditRecipients"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RscFieldSpreadsheet1 As __RSCWindowsControlLibrary.RSCFieldSpreadsheet
End Class
