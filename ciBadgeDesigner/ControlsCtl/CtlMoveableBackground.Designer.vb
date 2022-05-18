<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CtlMoveableBackground
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
        Me.ctlMoveable1 = New ciBadgeDesigner.CtlGraphicStaticGraphic()
        Me.SuspendLayout()
        '
        'ctlMoveable1
        '
        Me.ctlMoveable1.BackColor = System.Drawing.Color.Transparent
        Me.ctlMoveable1.ElementInfo_Base = Nothing
        Me.ctlMoveable1.Location = New System.Drawing.Point(0, 0)
        Me.ctlMoveable1.Margin = New System.Windows.Forms.Padding(2)
        Me.ctlMoveable1.MoveabilityEventsForGroupCtls = Nothing
        Me.ctlMoveable1.MoveabilityEventsForSingleMove = Nothing
        Me.ctlMoveable1.Name = "ctlMoveable1"
        Me.ctlMoveable1.Size = New System.Drawing.Size(805, 648)
        Me.ctlMoveable1.TabIndex = 0
        '
        'CtlMoveableBackground
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ctlMoveable1)
        Me.Name = "CtlMoveableBackground"
        Me.Size = New System.Drawing.Size(348, 223)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ctlMoveable1 As CtlGraphicStaticGraphic
End Class
