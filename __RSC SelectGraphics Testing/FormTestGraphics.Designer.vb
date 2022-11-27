<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTestGraphics
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
        Me.components = New System.ComponentModel.Container()
        Me.PictureBoxForBorder = New System.Windows.Forms.PictureBox()
        Me.ButtonSaveArrow = New System.Windows.Forms.Button()
        Me.ButtonRectangle = New System.Windows.Forms.Button()
        Me.PictureBoxInner = New System.Windows.Forms.PictureBox()
        Me.PictureBoxForTriangle = New System.Windows.Forms.PictureBox()
        Me.ButtonClearBoxForTriangle = New System.Windows.Forms.Button()
        Me.LabelTriangleInstructions = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBoxForBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxInner, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxForTriangle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBoxForBorder
        '
        Me.PictureBoxForBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxForBorder.Location = New System.Drawing.Point(451, 126)
        Me.PictureBoxForBorder.Name = "PictureBoxForBorder"
        Me.PictureBoxForBorder.Size = New System.Drawing.Size(172, 233)
        Me.PictureBoxForBorder.TabIndex = 0
        Me.PictureBoxForBorder.TabStop = False
        '
        'ButtonSaveArrow
        '
        Me.ButtonSaveArrow.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonSaveArrow.Location = New System.Drawing.Point(101, 333)
        Me.ButtonSaveArrow.Name = "ButtonSaveArrow"
        Me.ButtonSaveArrow.Size = New System.Drawing.Size(134, 40)
        Me.ButtonSaveArrow.TabIndex = 1
        Me.ButtonSaveArrow.Text = "Save 2-triangle arrow"
        Me.ButtonSaveArrow.UseVisualStyleBackColor = True
        '
        'ButtonRectangle
        '
        Me.ButtonRectangle.Location = New System.Drawing.Point(451, 365)
        Me.ButtonRectangle.Name = "ButtonRectangle"
        Me.ButtonRectangle.Size = New System.Drawing.Size(182, 69)
        Me.ButtonRectangle.TabIndex = 2
        Me.ButtonRectangle.Text = "Make rectangular border around inside box"
        Me.ButtonRectangle.UseVisualStyleBackColor = True
        '
        'PictureBoxInner
        '
        Me.PictureBoxInner.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PictureBoxInner.Location = New System.Drawing.Point(487, 201)
        Me.PictureBoxInner.Name = "PictureBoxInner"
        Me.PictureBoxInner.Size = New System.Drawing.Size(100, 50)
        Me.PictureBoxInner.TabIndex = 3
        Me.PictureBoxInner.TabStop = False
        '
        'PictureBoxForTriangle
        '
        Me.PictureBoxForTriangle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxForTriangle.Location = New System.Drawing.Point(101, 109)
        Me.PictureBoxForTriangle.Name = "PictureBoxForTriangle"
        Me.PictureBoxForTriangle.Size = New System.Drawing.Size(117, 115)
        Me.PictureBoxForTriangle.TabIndex = 4
        Me.PictureBoxForTriangle.TabStop = False
        '
        'ButtonClearBoxForTriangle
        '
        Me.ButtonClearBoxForTriangle.Location = New System.Drawing.Point(101, 237)
        Me.ButtonClearBoxForTriangle.Name = "ButtonClearBoxForTriangle"
        Me.ButtonClearBoxForTriangle.Size = New System.Drawing.Size(241, 41)
        Me.ButtonClearBoxForTriangle.TabIndex = 5
        Me.ButtonClearBoxForTriangle.Text = "Clear box above"
        Me.ButtonClearBoxForTriangle.UseVisualStyleBackColor = True
        '
        'LabelTriangleInstructions
        '
        Me.LabelTriangleInstructions.AutoSize = True
        Me.LabelTriangleInstructions.Location = New System.Drawing.Point(26, 75)
        Me.LabelTriangleInstructions.Name = "LabelTriangleInstructions"
        Me.LabelTriangleInstructions.Size = New System.Drawing.Size(325, 15)
        Me.LabelTriangleInstructions.TabIndex = 6
        Me.LabelTriangleInstructions.Text = "Click inside the square three times to draw && fill the triangle."
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(675, 75)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(327, 435)
        Me.FlowLayoutPanel1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(101, 300)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Brief name (e.g. North, SW)"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(258, 297)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(172, 23)
        Me.TextBox1.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(675, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Saved Arrows"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(12, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(481, 25)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Arrows to point at elements && borders around elements"
        '
        'FormTestGraphics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 517)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.LabelTriangleInstructions)
        Me.Controls.Add(Me.ButtonClearBoxForTriangle)
        Me.Controls.Add(Me.PictureBoxForTriangle)
        Me.Controls.Add(Me.PictureBoxInner)
        Me.Controls.Add(Me.ButtonRectangle)
        Me.Controls.Add(Me.ButtonSaveArrow)
        Me.Controls.Add(Me.PictureBoxForBorder)
        Me.Name = "FormTestGraphics"
        Me.Text = "Form1"
        CType(Me.PictureBoxForBorder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxInner, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxForTriangle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBoxForBorder As PictureBox
    Friend WithEvents ButtonSaveArrow As Button
    Friend WithEvents ButtonRectangle As Button
    Friend WithEvents PictureBoxInner As PictureBox
    Friend WithEvents PictureBoxForTriangle As PictureBox
    Friend WithEvents ButtonClearBoxForTriangle As Button
    Friend WithEvents LabelTriangleInstructions As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label3 As Label
End Class
