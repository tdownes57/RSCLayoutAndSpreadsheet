<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CtlGraphicStaticGraphic
    Inherits CtlGraphic__Factory ''Added 4/2/2023
    ''4/2023 Inherits __RSCWindowsControlLibrary.RSCMoveableControlVB

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
        Me.pictureStaticGraphic = New System.Windows.Forms.PictureBox()
        CType(Me.pictureStaticGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureStaticGraphic
        '
        Me.pictureStaticGraphic.BackColor = System.Drawing.Color.Transparent
        Me.pictureStaticGraphic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pictureStaticGraphic.Image = Global.ciBadgeDesigner.My.Resources.Resources.code_ninjas_logo
        Me.pictureStaticGraphic.Location = New System.Drawing.Point(0, 0)
        Me.pictureStaticGraphic.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pictureStaticGraphic.Name = "pictureStaticGraphic"
        Me.pictureStaticGraphic.Size = New System.Drawing.Size(264, 62)
        Me.pictureStaticGraphic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureStaticGraphic.TabIndex = 5
        Me.pictureStaticGraphic.TabStop = False
        '
        'CtlGraphicStaticGraphic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pictureStaticGraphic)
        Me.Name = "CtlGraphicStaticGraphic"
        Me.Size = New System.Drawing.Size(264, 62)
        Me.Controls.SetChildIndex(Me.pictureStaticGraphic, 0)
        CType(Me.pictureStaticGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pictureStaticGraphic As PictureBox
End Class
