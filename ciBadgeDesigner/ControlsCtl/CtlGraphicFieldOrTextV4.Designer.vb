Imports __RSCWindowsControlLibrary ''Added 1/30/2022 td

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CtlGraphicFieldOrTextV4
    ''4/2/2023 Inherits RSCMoveableControlVB ''Added 1/30/2022 td
    Inherits CtlGraphic__Factory ''Added 1/30/2022 td

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
        Me.pictureFieldOrText = New System.Windows.Forms.PictureBox()
        Me.LinkMessageFYI = New System.Windows.Forms.LinkLabel()
        CType(Me.pictureFieldOrText, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureFieldOrText
        '
        Me.pictureFieldOrText.BackColor = System.Drawing.Color.White
        Me.pictureFieldOrText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pictureFieldOrText.Location = New System.Drawing.Point(0, 0)
        Me.pictureFieldOrText.Margin = New System.Windows.Forms.Padding(4)
        Me.pictureFieldOrText.Name = "pictureFieldOrText"
        Me.pictureFieldOrText.Size = New System.Drawing.Size(387, 32)
        Me.pictureFieldOrText.TabIndex = 1
        Me.pictureFieldOrText.TabStop = False
        '
        'LinkMessageFYI
        '
        Me.LinkMessageFYI.AutoSize = True
        Me.LinkMessageFYI.Location = New System.Drawing.Point(84, 0)
        Me.LinkMessageFYI.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkMessageFYI.Name = "LinkMessageFYI"
        Me.LinkMessageFYI.Size = New System.Drawing.Size(130, 17)
        Me.LinkMessageFYI.TabIndex = 3
        Me.LinkMessageFYI.TabStop = True
        Me.LinkMessageFYI.Text = "Reminder message"
        Me.LinkMessageFYI.Visible = False
        '
        'CtlGraphicFieldOrTextV4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LinkMessageFYI)
        Me.Controls.Add(Me.pictureFieldOrText)
        Me.Name = "CtlGraphicFieldOrTextV4"
        Me.Size = New System.Drawing.Size(387, 32)
        CType(Me.pictureFieldOrText, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pictureFieldOrText As PictureBox
    Friend WithEvents LinkMessageFYI As LinkLabel
End Class
