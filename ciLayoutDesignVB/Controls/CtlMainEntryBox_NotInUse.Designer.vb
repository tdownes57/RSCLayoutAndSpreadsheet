<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlMainEntryBox_NotInUse
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
        Me.txtMainEntry = New System.Windows.Forms.TextBox()
        Me.lblFieldCaption = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtMainEntry
        '
        Me.txtMainEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMainEntry.Location = New System.Drawing.Point(150, 4)
        Me.txtMainEntry.Name = "txtMainEntry"
        Me.txtMainEntry.Size = New System.Drawing.Size(195, 23)
        Me.txtMainEntry.TabIndex = 0
        '
        'lblFieldCaption
        '
        Me.lblFieldCaption.AutoSize = True
        Me.lblFieldCaption.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFieldCaption.Location = New System.Drawing.Point(3, 7)
        Me.lblFieldCaption.Name = "lblFieldCaption"
        Me.lblFieldCaption.Size = New System.Drawing.Size(85, 17)
        Me.lblFieldCaption.TabIndex = 1
        Me.lblFieldCaption.Text = "Field Caption"
        '
        'CtlMainEntryBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblFieldCaption)
        Me.Controls.Add(Me.txtMainEntry)
        Me.Name = "CtlMainEntryBox"
        Me.Size = New System.Drawing.Size(354, 36)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtMainEntry As TextBox
    Friend WithEvents lblFieldCaption As Label
End Class
