<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FieldSelector
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
        Me.Label1FieldSelected = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelIsUnselected = New System.Windows.Forms.Label()
        Me.LinkSelectOrUnselect = New System.Windows.Forms.LinkLabel()
        Me.LabelIsSelected = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1FieldSelected
        '
        Me.Label1FieldSelected.AutoSize = True
        Me.Label1FieldSelected.BackColor = System.Drawing.Color.Transparent
        Me.Label1FieldSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1FieldSelected.Location = New System.Drawing.Point(0, 0)
        Me.Label1FieldSelected.Name = "Label1FieldSelected"
        Me.Label1FieldSelected.Size = New System.Drawing.Size(122, 17)
        Me.Label1FieldSelected.TabIndex = 0
        Me.Label1FieldSelected.Text = "Field - Selected"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Field Unselected"
        '
        'LabelIsUnselected
        '
        Me.LabelIsUnselected.AutoSize = True
        Me.LabelIsUnselected.BackColor = System.Drawing.Color.Transparent
        Me.LabelIsUnselected.Location = New System.Drawing.Point(0, 108)
        Me.LabelIsUnselected.Name = "LabelIsUnselected"
        Me.LabelIsUnselected.Size = New System.Drawing.Size(69, 13)
        Me.LabelIsUnselected.TabIndex = 2
        Me.LabelIsUnselected.Text = "is unselected"
        '
        'LinkSelectOrUnselect
        '
        Me.LinkSelectOrUnselect.AutoSize = True
        Me.LinkSelectOrUnselect.Location = New System.Drawing.Point(3, 47)
        Me.LinkSelectOrUnselect.Name = "LinkSelectOrUnselect"
        Me.LinkSelectOrUnselect.Size = New System.Drawing.Size(83, 13)
        Me.LinkSelectOrUnselect.TabIndex = 3
        Me.LinkSelectOrUnselect.TabStop = True
        Me.LinkSelectOrUnselect.Tag = "Unelect the Field."
        Me.LinkSelectOrUnselect.Text = "Select the Field."
        '
        'LabelIsSelected
        '
        Me.LabelIsSelected.AutoSize = True
        Me.LabelIsSelected.BackColor = System.Drawing.Color.Transparent
        Me.LabelIsSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelIsSelected.Location = New System.Drawing.Point(0, 20)
        Me.LabelIsSelected.Name = "LabelIsSelected"
        Me.LabelIsSelected.Size = New System.Drawing.Size(72, 13)
        Me.LabelIsSelected.TabIndex = 4
        Me.LabelIsSelected.Text = "is selected."
        '
        'FieldSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Plum
        Me.Controls.Add(Me.LinkSelectOrUnselect)
        Me.Controls.Add(Me.LabelIsUnselected)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1FieldSelected)
        Me.Controls.Add(Me.LabelIsSelected)
        Me.Name = "FieldSelector"
        Me.Size = New System.Drawing.Size(125, 122)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1FieldSelected As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LabelIsUnselected As Label
    Friend WithEvents LinkSelectOrUnselect As LinkLabel
    Friend WithEvents LabelIsSelected As Label
End Class
