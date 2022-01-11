<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlGraphicStaticGraphic
    Inherits __RSCWindowsControlLibrary.RSCMoveableControlVB

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
        Me.pictureStaticGraphic = New System.Windows.Forms.PictureBox()
        CType(Me.pictureStaticGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureStaticGraphic
        '
        Me.pictureStaticGraphic.BackColor = System.Drawing.Color.Transparent
        Me.pictureStaticGraphic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pictureStaticGraphic.Image = Global.ciBadgeDesigner.My.Resources.Resources.code_ninjas_logo_png
        Me.pictureStaticGraphic.Location = New System.Drawing.Point(0, 0)
        Me.pictureStaticGraphic.Name = "pictureStaticGraphic"
        Me.pictureStaticGraphic.Size = New System.Drawing.Size(352, 76)
        Me.pictureStaticGraphic.TabIndex = 5
        Me.pictureStaticGraphic.TabStop = False
        '
        'CtlGraphicStaticGraphic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pictureStaticGraphic)
        Me.Name = "CtlGraphicStaticGraphic"
        Me.Size = New System.Drawing.Size(352, 76)
        CType(Me.pictureStaticGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pictureStaticGraphic As PictureBox
End Class
