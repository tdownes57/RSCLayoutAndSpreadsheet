<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlGraphicQRCode
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
        Me.pictureQRCode = New System.Windows.Forms.PictureBox()
        CType(Me.pictureQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureQRCode
        '
        Me.pictureQRCode.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pictureQRCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pictureQRCode.Image = Global.ciBadgeDesigner.My.Resources.Resources.CodeNinjas_in_NB
        Me.pictureQRCode.Location = New System.Drawing.Point(0, 0)
        Me.pictureQRCode.Margin = New System.Windows.Forms.Padding(4)
        Me.pictureQRCode.Name = "pictureQRCode"
        Me.pictureQRCode.Size = New System.Drawing.Size(166, 168)
        Me.pictureQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureQRCode.TabIndex = 2
        Me.pictureQRCode.TabStop = False
        '
        'CtlGraphicQRCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pictureQRCode)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CtlGraphicQRCode"
        Me.Size = New System.Drawing.Size(166, 168)
        CType(Me.pictureQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pictureQRCode As Windows.Forms.PictureBox
End Class
