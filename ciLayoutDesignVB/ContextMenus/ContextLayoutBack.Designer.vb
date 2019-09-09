<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContextLayoutBack
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
        Me.cmdBackgroundImage = New System.Windows.Forms.Button()
        Me.cmdBackgroundColor = New System.Windows.Forms.Button()
        Me.cmdClearGroupEditing = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'cmdBackgroundImage
        '
        Me.cmdBackgroundImage.Location = New System.Drawing.Point(3, 3)
        Me.cmdBackgroundImage.Name = "cmdBackgroundImage"
        Me.cmdBackgroundImage.Size = New System.Drawing.Size(201, 23)
        Me.cmdBackgroundImage.TabIndex = 0
        Me.cmdBackgroundImage.Text = "Change Background Image"
        Me.cmdBackgroundImage.UseVisualStyleBackColor = True
        '
        'cmdBackgroundColor
        '
        Me.cmdBackgroundColor.Location = New System.Drawing.Point(3, 32)
        Me.cmdBackgroundColor.Name = "cmdBackgroundColor"
        Me.cmdBackgroundColor.Size = New System.Drawing.Size(201, 23)
        Me.cmdBackgroundColor.TabIndex = 1
        Me.cmdBackgroundColor.Text = "Change Background Color"
        Me.cmdBackgroundColor.UseVisualStyleBackColor = True
        '
        'cmdClearGroupEditing
        '
        Me.cmdClearGroupEditing.Location = New System.Drawing.Point(3, 61)
        Me.cmdClearGroupEditing.Name = "cmdClearGroupEditing"
        Me.cmdClearGroupEditing.Size = New System.Drawing.Size(201, 23)
        Me.cmdClearGroupEditing.TabIndex = 2
        Me.cmdClearGroupEditing.Text = "Clear Group Element Selector"
        Me.cmdClearGroupEditing.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 90)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(201, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Front Side / Back Side"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(3, 119)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(201, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Add Missing Field"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(3, 159)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(156, 47)
        Me.LinkLabel1.TabIndex = 13
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "These buttons might be cleared and rebuilt via program code.  (Design-time messag" &
    "e)"
        '
        'ContextLayoutBack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdClearGroupEditing)
        Me.Controls.Add(Me.cmdBackgroundColor)
        Me.Controls.Add(Me.cmdBackgroundImage)
        Me.Name = "ContextLayoutBack"
        Me.Size = New System.Drawing.Size(211, 224)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdBackgroundImage As Button
    Friend WithEvents cmdBackgroundColor As Button
    Friend WithEvents cmdClearGroupEditing As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
