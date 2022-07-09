<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCBrowseExistingColors
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.RscColorDisplay1 = New __RSCWindowsControlLibrary.RSCColorDisplay()
        Me.RscColorDisplay2 = New __RSCWindowsControlLibrary.RSCColorDisplay()
        Me.RscColorDisplay3 = New __RSCWindowsControlLibrary.RSCColorDisplay()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.RscColorDisplay1)
        Me.FlowLayoutPanel1.Controls.Add(Me.RscColorDisplay2)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(33, 31)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(419, 287)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'RscColorDisplay1
        '
        Me.RscColorDisplay1.DisplayColor = System.Drawing.Color.Empty
        Me.RscColorDisplay1.Location = New System.Drawing.Point(3, 3)
        Me.RscColorDisplay1.Name = "RscColorDisplay1"
        Me.RscColorDisplay1.Size = New System.Drawing.Size(139, 122)
        Me.RscColorDisplay1.TabIndex = 0
        '
        'RscColorDisplay2
        '
        Me.RscColorDisplay2.DisplayColor = System.Drawing.Color.Empty
        Me.RscColorDisplay2.Location = New System.Drawing.Point(148, 3)
        Me.RscColorDisplay2.Name = "RscColorDisplay2"
        Me.RscColorDisplay2.Size = New System.Drawing.Size(139, 122)
        Me.RscColorDisplay2.TabIndex = 1
        '
        'RscColorDisplay3
        '
        Me.RscColorDisplay3.DisplayColor = System.Drawing.Color.Empty
        Me.RscColorDisplay3.Location = New System.Drawing.Point(606, 79)
        Me.RscColorDisplay3.Name = "RscColorDisplay3"
        Me.RscColorDisplay3.Size = New System.Drawing.Size(139, 122)
        Me.RscColorDisplay3.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(498, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Selected Color:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Existing Colors:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(458, 31)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 30)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Add New Color"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(673, 288)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(125, 30)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(542, 288)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(125, 30)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "OK"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(606, 207)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(125, 30)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Delete"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'RSCBrowseExistingColors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 340)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RscColorDisplay3)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "RSCBrowseExistingColors"
        Me.Text = "RSCBrowseExistingColors"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents RscColorDisplay1 As RSCColorDisplay
    Friend WithEvents RscColorDisplay2 As RSCColorDisplay
    Friend WithEvents RscColorDisplay3 As RSCColorDisplay
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
