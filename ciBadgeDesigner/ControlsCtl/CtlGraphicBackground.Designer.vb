<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CtlGraphicBackground
    Inherits __RSCWindowsControlLibrary.RSCMoveableControlVB
    ''Jan14 2022 td''Inherits System.Windows.Forms.UserControl

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
        Me.SuspendLayout()
        '
        'CtlGraphicBackground
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ciBadgeDesigner.My.Resources.Resources.layout_BW
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Name = "CtlGraphicBackground"
        Me.Size = New System.Drawing.Size(559, 331)
        Me.ResumeLayout(False)

    End Sub

End Class
