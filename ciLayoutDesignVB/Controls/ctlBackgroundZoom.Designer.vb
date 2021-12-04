<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlBackgroundZoom
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
        Me.pictureBackZoom = New System.Windows.Forms.PictureBox()
        CType(Me.pictureBackZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureBackZoom
        '
        Me.pictureBackZoom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pictureBackZoom.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pictureBackZoom.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.Native_drawing___Not_bad_40
        Me.pictureBackZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictureBackZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBackZoom.Location = New System.Drawing.Point(0, 0)
        Me.pictureBackZoom.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.pictureBackZoom.Name = "pictureBackZoom"
        Me.pictureBackZoom.Size = New System.Drawing.Size(681, 425)
        Me.pictureBackZoom.TabIndex = 22
        Me.pictureBackZoom.TabStop = False
        '
        'ctlBackgroundZoom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pictureBackZoom)
        Me.Name = "ctlBackgroundZoom"
        Me.Size = New System.Drawing.Size(681, 426)
        CType(Me.pictureBackZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pictureBackZoom As PictureBox
End Class
