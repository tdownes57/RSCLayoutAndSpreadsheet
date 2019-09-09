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
        Me.flowFieldsNotListed = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblFieldsNotCurrentlyShownHdr = New System.Windows.Forms.Label()
        Me.flowFieldsNotListed.SuspendLayout()
        Me.SuspendLayout()
        '
        'CtlGraphicPortrait_v90
        '
        Me.CtlGraphicPortrait_v90.Location = New System.Drawing.Point(587, 317)
        Me.CtlGraphicPortrait_v90.Name = "CtlGraphicPortrait_v90"
        Me.CtlGraphicPortrait_v90.Size = New System.Drawing.Size(197, 269)
        Me.CtlGraphicPortrait_v90.TabIndex = 0
        '
        'flowFieldsNotListed
        '
        Me.flowFieldsNotListed.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.flowFieldsNotListed.Controls.Add(Me.lblFieldsNotCurrentlyShownHdr)
        Me.flowFieldsNotListed.Location = New System.Drawing.Point(151, 724)
        Me.flowFieldsNotListed.Name = "flowFieldsNotListed"
        Me.flowFieldsNotListed.Size = New System.Drawing.Size(776, 50)
        Me.flowFieldsNotListed.TabIndex = 53
        '
        'lblFieldsNotCurrentlyShownHdr
        '
        Me.lblFieldsNotCurrentlyShownHdr.AutoSize = True
        Me.lblFieldsNotCurrentlyShownHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFieldsNotCurrentlyShownHdr.Location = New System.Drawing.Point(3, 0)
        Me.lblFieldsNotCurrentlyShownHdr.Name = "lblFieldsNotCurrentlyShownHdr"
        Me.lblFieldsNotCurrentlyShownHdr.Size = New System.Drawing.Size(133, 15)
        Me.lblFieldsNotCurrentlyShownHdr.TabIndex = 0
        Me.lblFieldsNotCurrentlyShownHdr.Text = "Fields not yet displayed"
        '
        'FormMainEntry_v90
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.The_UI_for_v900
        Me.ClientSize = New System.Drawing.Size(1549, 828)
        Me.Controls.Add(Me.flowFieldsNotListed)
        Me.Controls.Add(Me.CtlGraphicPortrait_v90)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FormMainEntry_v90"
        Me.Text = "FormMainEntry_v90"
        Me.flowFieldsNotListed.ResumeLayout(False)
        Me.flowFieldsNotListed.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CtlGraphicPortrait_v90 As CtlGraphicPortrait
    Friend WithEvents flowFieldsNotListed As FlowLayoutPanel
    Friend WithEvents lblFieldsNotCurrentlyShownHdr As Label
End Class
