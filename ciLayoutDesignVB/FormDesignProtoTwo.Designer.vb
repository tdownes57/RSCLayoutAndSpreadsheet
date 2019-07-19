<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDesignProtoTwo
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
        Me.pictureBack = New System.Windows.Forms.PictureBox()
        CType(Me.pictureBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureBack
        '
        Me.pictureBack.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pictureBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBack.Image = Global.ciLayoutDesignVB.My.Resources.Resources.CI_Logo
        Me.pictureBack.Location = New System.Drawing.Point(151, 84)
        Me.pictureBack.Name = "pictureBack"
        Me.pictureBack.Size = New System.Drawing.Size(859, 492)
        Me.pictureBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBack.TabIndex = 21
        Me.pictureBack.TabStop = False
        '
        'FormDesignProtoTwo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1161, 660)
        Me.Controls.Add(Me.pictureBack)
        Me.Name = "FormDesignProtoTwo"
        Me.Text = "FormDesignProtoTwo"
        CType(Me.pictureBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pictureBack As PictureBox
End Class
