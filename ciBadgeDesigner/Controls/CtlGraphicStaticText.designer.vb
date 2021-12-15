Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CtlGraphicStaticText
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
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip()
        Me.LinkInvisible = New System.Windows.Forms.LinkLabel()
        Me.textTypeExample = New System.Windows.Forms.TextBox()
        Me.pictureLabel = New System.Windows.Forms.PictureBox()
        CType(Me.pictureLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'LinkInvisible
        '
        Me.LinkInvisible.AutoSize = True
        Me.LinkInvisible.Location = New System.Drawing.Point(208, 0)
        Me.LinkInvisible.Name = "LinkInvisible"
        Me.LinkInvisible.Size = New System.Drawing.Size(125, 13)
        Me.LinkInvisible.TabIndex = 4
        Me.LinkInvisible.TabStop = True
        Me.LinkInvisible.Text = "Won't appear in preview."
        Me.LinkInvisible.Visible = False
        '
        'textTypeExample
        '
        Me.textTypeExample.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textTypeExample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textTypeExample.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textTypeExample.Location = New System.Drawing.Point(12, 2)
        Me.textTypeExample.Margin = New System.Windows.Forms.Padding(2)
        Me.textTypeExample.Name = "textTypeExample"
        Me.textTypeExample.Size = New System.Drawing.Size(316, 27)
        Me.textTypeExample.TabIndex = 3
        Me.textTypeExample.Visible = False
        '
        'pictureLabel
        '
        Me.pictureLabel.BackColor = System.Drawing.Color.White
        Me.pictureLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pictureLabel.Image = Global.ciBadgeDesigner.My.Resources.Resources.Static_Text
        Me.pictureLabel.Location = New System.Drawing.Point(0, 0)
        Me.pictureLabel.Name = "pictureLabel"
        Me.pictureLabel.Size = New System.Drawing.Size(356, 32)
        Me.pictureLabel.TabIndex = 1
        Me.pictureLabel.TabStop = False
        '
        'CtlGraphicText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LinkInvisible)
        Me.Controls.Add(Me.pictureLabel)
        Me.Controls.Add(Me.textTypeExample)
        Me.Name = "CtlGraphicText"
        Me.Size = New System.Drawing.Size(356, 32)
        CType(Me.pictureLabel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pictureLabel As PictureBox
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents LinkInvisible As LinkLabel
    Friend WithEvents textTypeExample As TextBox
End Class
