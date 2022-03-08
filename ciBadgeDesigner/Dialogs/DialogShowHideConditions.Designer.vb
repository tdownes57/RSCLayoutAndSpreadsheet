<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogShowHideConditions
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ButtonShowConditionAdd = New System.Windows.Forms.Button()
        Me.ButtonHideConditionAdd = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ButtonShowConditionAdd)
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(339, 229)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Show Conditions"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonHideConditionAdd)
        Me.GroupBox2.Controls.Add(Me.ListBox2)
        Me.GroupBox2.Location = New System.Drawing.Point(376, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(339, 229)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hide Conditions"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Items.AddRange(New Object() {"No Show/Visible conditions yet"})
        Me.ListBox1.Location = New System.Drawing.Point(16, 27)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(306, 132)
        Me.ListBox1.TabIndex = 0
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 16
        Me.ListBox2.Items.AddRange(New Object() {"No Hide/Invisible conditions yet"})
        Me.ListBox2.Location = New System.Drawing.Point(16, 27)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(306, 132)
        Me.ListBox2.TabIndex = 1
        '
        'ButtonShowConditionAdd
        '
        Me.ButtonShowConditionAdd.Location = New System.Drawing.Point(69, 174)
        Me.ButtonShowConditionAdd.Name = "ButtonShowConditionAdd"
        Me.ButtonShowConditionAdd.Size = New System.Drawing.Size(137, 36)
        Me.ButtonShowConditionAdd.TabIndex = 1
        Me.ButtonShowConditionAdd.Text = "Add"
        Me.ButtonShowConditionAdd.UseVisualStyleBackColor = True
        '
        'ButtonHideConditionAdd
        '
        Me.ButtonHideConditionAdd.Location = New System.Drawing.Point(88, 174)
        Me.ButtonHideConditionAdd.Name = "ButtonHideConditionAdd"
        Me.ButtonHideConditionAdd.Size = New System.Drawing.Size(137, 36)
        Me.ButtonHideConditionAdd.TabIndex = 2
        Me.ButtonHideConditionAdd.Text = "Add"
        Me.ButtonHideConditionAdd.UseVisualStyleBackColor = True
        '
        'DialogShowHideConditions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 294)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "DialogShowHideConditions"
        Me.Text = "DialogShowHideConditions"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents ButtonShowConditionAdd As Button
    Friend WithEvents ButtonHideConditionAdd As Button
End Class
