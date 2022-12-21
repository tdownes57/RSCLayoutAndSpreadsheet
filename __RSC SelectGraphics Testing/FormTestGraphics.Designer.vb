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
        Me.PictureBoxOuter = New System.Windows.Forms.PictureBox()
        Me.ButtonSaveArrow = New System.Windows.Forms.Button()
        Me.ButtonRectangle = New System.Windows.Forms.Button()
        Me.PictureBoxInner1 = New System.Windows.Forms.PictureBox()
        Me.PictureBoxForTriangle = New System.Windows.Forms.PictureBox()
        Me.ButtonClearBoxForTriangle = New System.Windows.Forms.Button()
        Me.LabelTriangleInstructions = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textNameOfArrow = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonRefresh = New System.Windows.Forms.Button()
        Me.TimerRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBoxDummy = New System.Windows.Forms.PictureBox()
        Me.LinkUndoLatestClick = New System.Windows.Forms.LinkLabel()
        Me.LinkRedoClick = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelPaintArrows = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBoxOuter2 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBoxOuter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxInner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxForTriangle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxDummy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxOuter2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBoxOuter
        '
        Me.PictureBoxOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxOuter.Location = New System.Drawing.Point(455, 127)
        Me.PictureBoxOuter.Name = "PictureBoxOuter"
        Me.PictureBoxOuter.Size = New System.Drawing.Size(226, 233)
        Me.PictureBoxOuter.TabIndex = 0
        Me.PictureBoxOuter.TabStop = False
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
        Me.ButtonRectangle.Location = New System.Drawing.Point(499, 436)
        Me.ButtonRectangle.Name = "ButtonRectangle"
        Me.ButtonRectangle.Size = New System.Drawing.Size(182, 69)
        Me.ButtonRectangle.TabIndex = 2
        Me.ButtonRectangle.Text = "Make rectangular border around inside box above"
        Me.ButtonRectangle.UseVisualStyleBackColor = True
        '
        'PictureBoxInner1
        '
        Me.PictureBoxInner1.BackColor = System.Drawing.Color.White
        Me.PictureBoxInner1.Location = New System.Drawing.Point(515, 166)
        Me.PictureBoxInner1.Name = "PictureBoxInner1"
        Me.PictureBoxInner1.Size = New System.Drawing.Size(68, 50)
        Me.PictureBoxInner1.TabIndex = 3
        Me.PictureBoxInner1.TabStop = False
        '
        'PictureBoxForTriangle
        '
        Me.PictureBoxForTriangle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxForTriangle.Location = New System.Drawing.Point(101, 117)
        Me.PictureBoxForTriangle.Name = "PictureBoxForTriangle"
        Me.PictureBoxForTriangle.Size = New System.Drawing.Size(100, 100)
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
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(762, 75)
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
        'textNameOfArrow
        '
        Me.textNameOfArrow.Location = New System.Drawing.Point(258, 297)
        Me.textNameOfArrow.Name = "textNameOfArrow"
        Me.textNameOfArrow.Size = New System.Drawing.Size(172, 23)
        Me.textNameOfArrow.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(762, 47)
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
        'ButtonRefresh
        '
        Me.ButtonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonRefresh.Location = New System.Drawing.Point(858, 36)
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.Size = New System.Drawing.Size(223, 33)
        Me.ButtonRefresh.TabIndex = 12
        Me.ButtonRefresh.Text = "Save, Clear && Refresh in 4 secs"
        Me.ButtonRefresh.UseVisualStyleBackColor = True
        '
        'TimerRefresh
        '
        Me.TimerRefresh.Interval = 1000
        '
        'PictureBoxDummy
        '
        Me.PictureBoxDummy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxDummy.Location = New System.Drawing.Point(12, 455)
        Me.PictureBoxDummy.Name = "PictureBoxDummy"
        Me.PictureBoxDummy.Size = New System.Drawing.Size(100, 20)
        Me.PictureBoxDummy.TabIndex = 13
        Me.PictureBoxDummy.TabStop = False
        Me.PictureBoxDummy.Visible = False
        '
        'LinkUndoLatestClick
        '
        Me.LinkUndoLatestClick.AutoSize = True
        Me.LinkUndoLatestClick.Location = New System.Drawing.Point(207, 201)
        Me.LinkUndoLatestClick.Name = "LinkUndoLatestClick"
        Me.LinkUndoLatestClick.Size = New System.Drawing.Size(93, 15)
        Me.LinkUndoLatestClick.TabIndex = 14
        Me.LinkUndoLatestClick.TabStop = True
        Me.LinkUndoLatestClick.Text = "Undo Clickpoint"
        '
        'LinkRedoClick
        '
        Me.LinkRedoClick.AutoSize = True
        Me.LinkRedoClick.Enabled = False
        Me.LinkRedoClick.Location = New System.Drawing.Point(230, 216)
        Me.LinkRedoClick.Name = "LinkRedoClick"
        Me.LinkRedoClick.Size = New System.Drawing.Size(91, 15)
        Me.LinkRedoClick.TabIndex = 15
        Me.LinkRedoClick.TabStop = True
        Me.LinkRedoClick.Text = "Redo Clickpoint"
        '
        'LinkLabelPaintArrows
        '
        Me.LinkLabelPaintArrows.AutoSize = True
        Me.LinkLabelPaintArrows.Location = New System.Drawing.Point(533, 29)
        Me.LinkLabelPaintArrows.Name = "LinkLabelPaintArrows"
        Me.LinkLabelPaintArrows.Size = New System.Drawing.Size(74, 15)
        Me.LinkLabelPaintArrows.TabIndex = 16
        Me.LinkLabelPaintArrows.TabStop = True
        Me.LinkLabelPaintArrows.Text = "Paint Arrows"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 421)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(431, 15)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Click the form (Form_MouseDown) and watch the arrows disappear && reappear!!"
        '
        'PictureBoxOuter2
        '
        Me.PictureBoxOuter2.BackColor = System.Drawing.Color.White
        Me.PictureBoxOuter2.Location = New System.Drawing.Point(555, 265)
        Me.PictureBoxOuter2.Name = "PictureBoxOuter2"
        Me.PictureBoxOuter2.Size = New System.Drawing.Size(68, 50)
        Me.PictureBoxOuter2.TabIndex = 18
        Me.PictureBoxOuter2.TabStop = False
        '
        'FormTestGraphics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 517)
        Me.Controls.Add(Me.PictureBoxOuter2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LinkLabelPaintArrows)
        Me.Controls.Add(Me.LinkRedoClick)
        Me.Controls.Add(Me.LinkUndoLatestClick)
        Me.Controls.Add(Me.PictureBoxDummy)
        Me.Controls.Add(Me.ButtonRefresh)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.textNameOfArrow)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.LabelTriangleInstructions)
        Me.Controls.Add(Me.ButtonClearBoxForTriangle)
        Me.Controls.Add(Me.PictureBoxForTriangle)
        Me.Controls.Add(Me.PictureBoxInner1)
        Me.Controls.Add(Me.ButtonRectangle)
        Me.Controls.Add(Me.ButtonSaveArrow)
        Me.Controls.Add(Me.PictureBoxOuter)
        Me.Name = "FormTestGraphics"
        Me.Text = "Form1"
        CType(Me.PictureBoxOuter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxInner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxForTriangle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxDummy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxOuter2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBoxOuter As PictureBox
    Friend WithEvents ButtonSaveArrow As Button
    Friend WithEvents ButtonRectangle As Button
    Friend WithEvents PictureBoxInner1 As PictureBox
    Friend WithEvents PictureBoxForTriangle As PictureBox
    Friend WithEvents ButtonClearBoxForTriangle As Button
    Friend WithEvents LabelTriangleInstructions As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents textNameOfArrow As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonRefresh As Button
    Friend WithEvents TimerRefresh As Timer
    Friend WithEvents PictureBoxDummy As PictureBox
    Friend WithEvents LinkUndoLatestClick As LinkLabel
    Friend WithEvents LinkRedoClick As LinkLabel
    Friend WithEvents LinkLabelPaintArrows As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBoxOuter2 As PictureBox
End Class
