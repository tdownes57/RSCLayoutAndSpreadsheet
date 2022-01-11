Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CtlGraphicPortrait
    Inherits __RSCWindowsControlLibrary.RSCMoveableControlVB_PriorComments

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
        Me.components = New System.ComponentModel.Container()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.picturePortrait = New System.Windows.Forms.PictureBox()
        CType(Me.picturePortrait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'picturePortrait
        '
        Me.picturePortrait.BackColor = System.Drawing.Color.Transparent
        Me.picturePortrait.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picturePortrait.Image = Global.ciBadgeDesigner.My.Resources.Resources.Liz_20_percent
        Me.picturePortrait.Location = New System.Drawing.Point(0, 0)
        Me.picturePortrait.Margin = New System.Windows.Forms.Padding(4)
        Me.picturePortrait.Name = "picturePortrait"
        Me.picturePortrait.Size = New System.Drawing.Size(156, 230)
        Me.picturePortrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picturePortrait.TabIndex = 1
        Me.picturePortrait.TabStop = False
        '
        'CtlGraphicPortrait
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.picturePortrait)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CtlGraphicPortrait"
        Me.Size = New System.Drawing.Size(156, 230)
        CType(Me.picturePortrait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picturePortrait As PictureBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
End Class
