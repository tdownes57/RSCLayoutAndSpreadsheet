﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CtlGraphicSignature
    Inherits __RSCWindowsControlLibrary.RSCMoveableControlVB
    ''Jan2 2022 td''Inherits System.Windows.Forms.UserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CtlGraphicSignature))
        Me.pictureSignature = New System.Windows.Forms.PictureBox()
        CType(Me.pictureSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureSignature
        '
        Me.pictureSignature.BackColor = System.Drawing.Color.Transparent
        Me.pictureSignature.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictureSignature.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pictureSignature.Image = CType(resources.GetObject("pictureSignature.Image"), System.Drawing.Image)
        Me.pictureSignature.Location = New System.Drawing.Point(0, 0)
        Me.pictureSignature.Name = "pictureSignature"
        Me.pictureSignature.Size = New System.Drawing.Size(419, 150)
        Me.pictureSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureSignature.TabIndex = 3
        Me.pictureSignature.TabStop = False
        '
        'CtlGraphicSignature
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pictureSignature)
        Me.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.Name = "CtlGraphicSignature"
        Me.Size = New System.Drawing.Size(419, 150)
        CType(Me.pictureSignature, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pictureSignature As Windows.Forms.PictureBox
End Class
