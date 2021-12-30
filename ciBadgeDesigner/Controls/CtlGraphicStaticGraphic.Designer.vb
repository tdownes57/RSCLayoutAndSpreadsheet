<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlGraphicStaticGraphic
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelHeader0 = New System.Windows.Forms.Label()
        Me.LabelSubHeader0a = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(628, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Arguments for && against simply using RSCMoveableControlVB instead."
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(99, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(653, 44)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "For using only RSCMoveableControl, not using this control:  Less administrative o" &
    "verhead && perhaps better performance. "
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(99, 202)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(638, 49)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "For using this control (CtlGraphicStaticGraphic):  A place to put the necessary p" &
    "rogram code which allow element-related settings to be saved to XML file."
        Me.Label3.Visible = False
        '
        'LabelHeader0
        '
        Me.LabelHeader0.AutoSize = True
        Me.LabelHeader0.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader0.Location = New System.Drawing.Point(27, 11)
        Me.LabelHeader0.Name = "LabelHeader0"
        Me.LabelHeader0.Size = New System.Drawing.Size(236, 25)
        Me.LabelHeader0.TabIndex = 3
        Me.LabelHeader0.Text = "CTLGraphicStaticGraphic"
        Me.LabelHeader0.Visible = False
        '
        'LabelSubHeader0a
        '
        Me.LabelSubHeader0a.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSubHeader0a.Location = New System.Drawing.Point(98, 36)
        Me.LabelSubHeader0a.Name = "LabelSubHeader0a"
        Me.LabelSubHeader0a.Size = New System.Drawing.Size(719, 46)
        Me.LabelSubHeader0a.TabIndex = 4
        Me.LabelSubHeader0a.Text = "A control for managing a badge-design element which will contain a pictorial (gra" &
    "phic) element which is Static && hence will not change from badge to badge."
        Me.LabelSubHeader0a.Visible = False
        '
        'CtlGraphicStaticGraphic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelSubHeader0a)
        Me.Controls.Add(Me.LabelHeader0)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CtlGraphicStaticGraphic"
        Me.Size = New System.Drawing.Size(866, 271)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents LabelHeader0 As Windows.Forms.Label
    Friend WithEvents LabelSubHeader0a As Windows.Forms.Label
End Class
