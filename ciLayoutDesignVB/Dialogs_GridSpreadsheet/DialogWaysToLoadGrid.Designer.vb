<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogWaysToLoadGrid
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
        Me.ButtonColumnPrimary = New System.Windows.Forms.Button()
        Me.ButtonLoadByRecipientRows = New System.Windows.Forms.Button()
        Me.ButtonLoadBothAboveMethods = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.lblHeader1 = New System.Windows.Forms.Label()
        Me.LabelTEST_CHECK_CONFIRM = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonColumnPrimary
        '
        Me.ButtonColumnPrimary.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonColumnPrimary.Location = New System.Drawing.Point(45, 116)
        Me.ButtonColumnPrimary.Name = "ButtonColumnPrimary"
        Me.ButtonColumnPrimary.Size = New System.Drawing.Size(319, 66)
        Me.ButtonColumnPrimary.TabIndex = 0
        Me.ButtonColumnPrimary.Text = "Load column by column (w/ column-cell cache)"
        Me.ButtonColumnPrimary.UseVisualStyleBackColor = True
        '
        'ButtonLoadByRecipientRows
        '
        Me.ButtonLoadByRecipientRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonLoadByRecipientRows.Location = New System.Drawing.Point(45, 188)
        Me.ButtonLoadByRecipientRows.Name = "ButtonLoadByRecipientRows"
        Me.ButtonLoadByRecipientRows.Size = New System.Drawing.Size(319, 66)
        Me.ButtonLoadByRecipientRows.TabIndex = 1
        Me.ButtonLoadByRecipientRows.Text = "Load by Rows (ID recipients)"
        Me.ButtonLoadByRecipientRows.UseVisualStyleBackColor = True
        '
        'ButtonLoadBothAboveMethods
        '
        Me.ButtonLoadBothAboveMethods.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonLoadBothAboveMethods.Location = New System.Drawing.Point(45, 298)
        Me.ButtonLoadBothAboveMethods.Name = "ButtonLoadBothAboveMethods"
        Me.ButtonLoadBothAboveMethods.Size = New System.Drawing.Size(319, 66)
        Me.ButtonLoadBothAboveMethods.TabIndex = 2
        Me.ButtonLoadBothAboveMethods.Text = "Show both for comparison"
        Me.ButtonLoadBothAboveMethods.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(222, 388)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(142, 66)
        Me.ButtonCancel.TabIndex = 3
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'lblHeader1
        '
        Me.lblHeader1.AutoSize = True
        Me.lblHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader1.Location = New System.Drawing.Point(28, 22)
        Me.lblHeader1.Name = "lblHeader1"
        Me.lblHeader1.Size = New System.Drawing.Size(250, 24)
        Me.lblHeader1.TabIndex = 4
        Me.lblHeader1.Text = "How to load the spreadsheet"
        '
        'LabelTEST_CHECK_CONFIRM
        '
        Me.LabelTEST_CHECK_CONFIRM.AutoSize = True
        Me.LabelTEST_CHECK_CONFIRM.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTEST_CHECK_CONFIRM.ForeColor = System.Drawing.Color.Red
        Me.LabelTEST_CHECK_CONFIRM.Location = New System.Drawing.Point(52, 66)
        Me.LabelTEST_CHECK_CONFIRM.Name = "LabelTEST_CHECK_CONFIRM"
        Me.LabelTEST_CHECK_CONFIRM.Size = New System.Drawing.Size(296, 24)
        Me.LabelTEST_CHECK_CONFIRM.TabIndex = 5
        Me.LabelTEST_CHECK_CONFIRM.Text = "TEST_CHECK_CONFIRM_SLOW"
        '
        'DialogWaysToLoadGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 492)
        Me.Controls.Add(Me.LabelTEST_CHECK_CONFIRM)
        Me.Controls.Add(Me.lblHeader1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonLoadBothAboveMethods)
        Me.Controls.Add(Me.ButtonLoadByRecipientRows)
        Me.Controls.Add(Me.ButtonColumnPrimary)
        Me.Name = "DialogWaysToLoadGrid"
        Me.Text = "How to load the spreadsheet grid?"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonColumnPrimary As Button
    Friend WithEvents ButtonLoadByRecipientRows As Button
    Friend WithEvents ButtonLoadBothAboveMethods As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents lblHeader1 As Label
    Friend WithEvents LabelTEST_CHECK_CONFIRM As Label
End Class
