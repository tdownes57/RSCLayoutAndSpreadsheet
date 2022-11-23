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
        Me.PictureBoxForBorder = New System.Windows.Forms.PictureBox()
        Me.ButtonTriangle = New System.Windows.Forms.Button()
        Me.ButtonRectangle = New System.Windows.Forms.Button()
        Me.PictureBoxInner = New System.Windows.Forms.PictureBox()
        Me.PictureBoxForTriangle = New System.Windows.Forms.PictureBox()
        Me.ButtonClearBoxForTriangle = New System.Windows.Forms.Button()
        Me.LabelTriangleInstructions = New System.Windows.Forms.Label()
        CType(Me.PictureBoxForBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxInner, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxForTriangle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBoxForBorder
        '
        Me.PictureBoxForBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxForBorder.Location = New System.Drawing.Point(436, 34)
        Me.PictureBoxForBorder.Name = "PictureBoxForBorder"
        Me.PictureBoxForBorder.Size = New System.Drawing.Size(335, 233)
        Me.PictureBoxForBorder.TabIndex = 0
        Me.PictureBoxForBorder.TabStop = False
        '
        'ButtonTriangle
        '
        Me.ButtonTriangle.Location = New System.Drawing.Point(101, 386)
        Me.ButtonTriangle.Name = "ButtonTriangle"
        Me.ButtonTriangle.Size = New System.Drawing.Size(241, 52)
        Me.ButtonTriangle.TabIndex = 1
        Me.ButtonTriangle.Text = "Make triangle"
        Me.ButtonTriangle.UseVisualStyleBackColor = True
        '
        'ButtonRectangle
        '
        Me.ButtonRectangle.Location = New System.Drawing.Point(454, 312)
        Me.ButtonRectangle.Name = "ButtonRectangle"
        Me.ButtonRectangle.Size = New System.Drawing.Size(281, 52)
        Me.ButtonRectangle.TabIndex = 2
        Me.ButtonRectangle.Text = "Make rectangular border around inside box"
        Me.ButtonRectangle.UseVisualStyleBackColor = True
        '
        'PictureBoxInner
        '
        Me.PictureBoxInner.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PictureBoxInner.Location = New System.Drawing.Point(567, 126)
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
        Me.PictureBoxForTriangle.Size = New System.Drawing.Size(250, 233)
        Me.PictureBoxForTriangle.TabIndex = 4
        Me.PictureBoxForTriangle.TabStop = False
        '
        'ButtonClearBoxForTriangle
        '
        Me.ButtonClearBoxForTriangle.Location = New System.Drawing.Point(101, 348)
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
        'FormTestGraphics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.LabelTriangleInstructions)
        Me.Controls.Add(Me.ButtonClearBoxForTriangle)
        Me.Controls.Add(Me.PictureBoxForTriangle)
        Me.Controls.Add(Me.PictureBoxInner)
        Me.Controls.Add(Me.ButtonRectangle)
        Me.Controls.Add(Me.ButtonTriangle)
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
    Friend WithEvents ButtonTriangle As Button
    Friend WithEvents ButtonRectangle As Button
    Friend WithEvents PictureBoxInner As PictureBox
    Friend WithEvents PictureBoxForTriangle As PictureBox
    Friend WithEvents ButtonClearBoxForTriangle As Button
    Friend WithEvents LabelTriangleInstructions As Label
End Class
