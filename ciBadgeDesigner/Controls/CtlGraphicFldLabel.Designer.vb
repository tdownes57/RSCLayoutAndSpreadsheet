Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CtlGraphicFldLabel
    Inherits __RSCWindowsControlLibrary.RSCMoveableControlVB
    ''Jan4 2022 td''Inherits System.Windows.Forms.UserControl

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
        Me.components = New System.ComponentModel.Container()
        Me.pictureLabel = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.textTypeExample = New System.Windows.Forms.TextBox()
        Me.LinkMessageFYI = New System.Windows.Forms.LinkLabel()
        CType(Me.pictureLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureLabel
        '
        Me.pictureLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pictureLabel.BackColor = System.Drawing.Color.White
        Me.pictureLabel.Location = New System.Drawing.Point(0, 0)
        Me.pictureLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.pictureLabel.Name = "pictureLabel"
        Me.pictureLabel.Size = New System.Drawing.Size(337, 41)
        Me.pictureLabel.TabIndex = 0
        Me.pictureLabel.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'textTypeExample
        '
        Me.textTypeExample.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textTypeExample.BackColor = System.Drawing.Color.White
        Me.textTypeExample.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textTypeExample.Location = New System.Drawing.Point(0, 0)
        Me.textTypeExample.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.textTypeExample.Name = "textTypeExample"
        Me.textTypeExample.Size = New System.Drawing.Size(336, 32)
        Me.textTypeExample.TabIndex = 1
        Me.textTypeExample.Visible = False
        '
        'LinkMessageFYI
        '
        Me.LinkMessageFYI.AutoSize = True
        Me.LinkMessageFYI.Location = New System.Drawing.Point(204, 0)
        Me.LinkMessageFYI.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkMessageFYI.Name = "LinkMessageFYI"
        Me.LinkMessageFYI.Size = New System.Drawing.Size(130, 17)
        Me.LinkMessageFYI.TabIndex = 2
        Me.LinkMessageFYI.TabStop = True
        Me.LinkMessageFYI.Text = "Reminder message"
        Me.LinkMessageFYI.Visible = False
        '
        'CtlGraphicFldLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.LinkMessageFYI)
        Me.Controls.Add(Me.textTypeExample)
        Me.Controls.Add(Me.pictureLabel)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CtlGraphicFldLabel"
        Me.Size = New System.Drawing.Size(337, 41)
        CType(Me.pictureLabel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pictureLabel As PictureBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents textTypeExample As TextBox
    Friend WithEvents LinkMessageFYI As LinkLabel
End Class
