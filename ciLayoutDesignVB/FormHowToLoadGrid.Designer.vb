<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHowToLoadGrid
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
        Me.SuspendLayout()
        '
        'ButtonColumnPrimary
        '
        Me.ButtonColumnPrimary.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonColumnPrimary.Location = New System.Drawing.Point(45, 37)
        Me.ButtonColumnPrimary.Name = "ButtonColumnPrimary"
        Me.ButtonColumnPrimary.Size = New System.Drawing.Size(319, 66)
        Me.ButtonColumnPrimary.TabIndex = 0
        Me.ButtonColumnPrimary.Text = "Load column by column (w/ column-cell cache)"
        Me.ButtonColumnPrimary.UseVisualStyleBackColor = True
        '
        'ButtonLoadByRecipientRows
        '
        Me.ButtonLoadByRecipientRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonLoadByRecipientRows.Location = New System.Drawing.Point(45, 128)
        Me.ButtonLoadByRecipientRows.Name = "ButtonLoadByRecipientRows"
        Me.ButtonLoadByRecipientRows.Size = New System.Drawing.Size(319, 66)
        Me.ButtonLoadByRecipientRows.TabIndex = 1
        Me.ButtonLoadByRecipientRows.Text = "Load by Rows (ID recipients)"
        Me.ButtonLoadByRecipientRows.UseVisualStyleBackColor = True
        '
        'ButtonLoadBothAboveMethods
        '
        Me.ButtonLoadBothAboveMethods.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonLoadBothAboveMethods.Location = New System.Drawing.Point(45, 220)
        Me.ButtonLoadBothAboveMethods.Name = "ButtonLoadBothAboveMethods"
        Me.ButtonLoadBothAboveMethods.Size = New System.Drawing.Size(319, 66)
        Me.ButtonLoadBothAboveMethods.TabIndex = 2
        Me.ButtonLoadBothAboveMethods.Text = "Show both for comparison"
        Me.ButtonLoadBothAboveMethods.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(222, 310)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(142, 66)
        Me.ButtonCancel.TabIndex = 3
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'FormHowToLoadGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 388)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonLoadBothAboveMethods)
        Me.Controls.Add(Me.ButtonLoadByRecipientRows)
        Me.Controls.Add(Me.ButtonColumnPrimary)
        Me.Name = "FormHowToLoadGrid"
        Me.Text = "How to load the spreadsheet grid?"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonColumnPrimary As Button
    Friend WithEvents ButtonLoadByRecipientRows As Button
    Friend WithEvents ButtonLoadBothAboveMethods As Button
    Friend WithEvents ButtonCancel As Button
End Class
