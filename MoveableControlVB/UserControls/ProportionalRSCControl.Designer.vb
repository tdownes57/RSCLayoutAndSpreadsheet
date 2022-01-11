<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProportionalRSCControl
    Inherits __RSCWindowsControlLibrary.RSCMoveableControlVB_PriorComments
    ''Dec3 2022 td''Inherits System.Windows.Forms.UserControl

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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSavedCount = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(15, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 112)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This child of RSCMoveableControl is complex in that it resizes proportionally."
        '
        'lblSavedCount
        '
        Me.lblSavedCount.AutoSize = True
        Me.lblSavedCount.Location = New System.Drawing.Point(3, 10)
        Me.lblSavedCount.Name = "lblSavedCount"
        Me.lblSavedCount.Size = New System.Drawing.Size(91, 17)
        Me.lblSavedCount.TabIndex = 1
        Me.lblSavedCount.Tag = "0"
        Me.lblSavedCount.Text = "Saved count:"
        '
        'ProportionalRSCControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblSavedCount)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ProportionalRSCControl"
        Me.Size = New System.Drawing.Size(327, 202)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblSavedCount As Label
End Class
