<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStep3TakePic_VBA
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
        Me.pictBackStep3_v82 = New System.Windows.Forms.PictureBox()
        CType(Me.pictBackStep3_v82, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictBackStep3_v82
        '
        Me.pictBackStep3_v82.BackgroundImage = Global.ciBadgeDesktop.My.Resources.Resources.__UI__v82_Step_3a_
        Me.pictBackStep3_v82.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pictBackStep3_v82.Location = New System.Drawing.Point(12, 12)
        Me.pictBackStep3_v82.Name = "pictBackStep3_v82"
        Me.pictBackStep3_v82.Size = New System.Drawing.Size(987, 663)
        Me.pictBackStep3_v82.TabIndex = 0
        Me.pictBackStep3_v82.TabStop = False
        '
        'FormStep3TakePic_VBA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 687)
        Me.Controls.Add(Me.pictBackStep3_v82)
        Me.Name = "FormStep3TakePic_VBA"
        Me.Text = "FormStep3TakePic"
        CType(Me.pictBackStep3_v82, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pictBackStep3_v82 As PictureBox
End Class
