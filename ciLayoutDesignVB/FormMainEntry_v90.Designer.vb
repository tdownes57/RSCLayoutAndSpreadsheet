<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMainEntry_v90
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
        Me.CtlGraphicPortrait_v90 = New ciLayoutDesignVB.CtlGraphicPortrait()
        Me.SuspendLayout()
        '
        'CtlGraphicPortrait_v90
        '
        Me.CtlGraphicPortrait_v90.Location = New System.Drawing.Point(783, 390)
        Me.CtlGraphicPortrait_v90.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CtlGraphicPortrait_v90.Name = "CtlGraphicPortrait_v90"
        Me.CtlGraphicPortrait_v90.Size = New System.Drawing.Size(263, 331)
        Me.CtlGraphicPortrait_v90.TabIndex = 0
        '
        'FormMainEntry_v90
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.The_UI_for_v900
        Me.ClientSize = New System.Drawing.Size(1474, 842)
        Me.Controls.Add(Me.CtlGraphicPortrait_v90)
        Me.Name = "FormMainEntry_v90"
        Me.Text = "FormMainEntry_v90"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CtlGraphicPortrait_v90 As CtlGraphicPortrait
End Class
