<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDisplay
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDisplay))
        Me.pictureboxFinalPrint = New System.Windows.Forms.PictureBox()
        Me.pictureboxLandscape = New System.Windows.Forms.PictureBox()
        CType(Me.pictureboxFinalPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureboxLandscape, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureboxFinalPrint
        '
        Me.pictureboxFinalPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureboxFinalPrint.Image = CType(resources.GetObject("pictureboxFinalPrint.Image"), System.Drawing.Image)
        Me.pictureboxFinalPrint.Location = New System.Drawing.Point(691, 101)
        Me.pictureboxFinalPrint.Name = "pictureboxFinalPrint"
        Me.pictureboxFinalPrint.Size = New System.Drawing.Size(208, 322)
        Me.pictureboxFinalPrint.TabIndex = 25
        Me.pictureboxFinalPrint.TabStop = False
        '
        'pictureboxLandscape
        '
        Me.pictureboxLandscape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureboxLandscape.Image = CType(resources.GetObject("pictureboxLandscape.Image"), System.Drawing.Image)
        Me.pictureboxLandscape.Location = New System.Drawing.Point(23, 23)
        Me.pictureboxLandscape.Name = "pictureboxLandscape"
        Me.pictureboxLandscape.Size = New System.Drawing.Size(644, 400)
        Me.pictureboxLandscape.TabIndex = 27
        Me.pictureboxLandscape.TabStop = False
        '
        'FormDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 438)
        Me.Controls.Add(Me.pictureboxLandscape)
        Me.Controls.Add(Me.pictureboxFinalPrint)
        Me.Name = "FormDisplay"
        Me.Text = "FormDisplay"
        CType(Me.pictureboxFinalPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureboxLandscape, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pictureboxFinalPrint As PictureBox
    Friend WithEvents pictureboxLandscape As PictureBox
End Class
