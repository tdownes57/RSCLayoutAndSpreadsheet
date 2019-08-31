<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSerialize
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ButtonSerializeToXML = New System.Windows.Forms.Button()
        Me.ButtonDeserializeBin = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonDeserializeXML = New System.Windows.Forms.Button()
        Me.ButtonSerializeToBinary = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Serialization"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(945, 28)
        Me.MenuStrip1.TabIndex = 19
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(46, 24)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(203, 26)
        Me.OpenToolStripMenuItem.Text = "Open Layout....."
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(203, 26)
        Me.SaveToolStripMenuItem.Text = "Save Layout As...."
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(203, 26)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ButtonSerializeToXML
        '
        Me.ButtonSerializeToXML.Location = New System.Drawing.Point(605, 218)
        Me.ButtonSerializeToXML.Name = "ButtonSerializeToXML"
        Me.ButtonSerializeToXML.Size = New System.Drawing.Size(266, 49)
        Me.ButtonSerializeToXML.TabIndex = 20
        Me.ButtonSerializeToXML.Text = "Serialize"
        Me.ButtonSerializeToXML.UseVisualStyleBackColor = True
        '
        'ButtonDeserializeBin
        '
        Me.ButtonDeserializeBin.Location = New System.Drawing.Point(48, 287)
        Me.ButtonDeserializeBin.Name = "ButtonDeserializeBin"
        Me.ButtonDeserializeBin.Size = New System.Drawing.Size(266, 49)
        Me.ButtonDeserializeBin.TabIndex = 21
        Me.ButtonDeserializeBin.Text = "Deserialize"
        Me.ButtonDeserializeBin.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(42, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(304, 36)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Serialization to Binary"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(599, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(282, 36)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Serialization to XML"
        '
        'ButtonDeserializeXML
        '
        Me.ButtonDeserializeXML.Location = New System.Drawing.Point(605, 287)
        Me.ButtonDeserializeXML.Name = "ButtonDeserializeXML"
        Me.ButtonDeserializeXML.Size = New System.Drawing.Size(266, 49)
        Me.ButtonDeserializeXML.TabIndex = 24
        Me.ButtonDeserializeXML.Text = "Deserialize"
        Me.ButtonDeserializeXML.UseVisualStyleBackColor = True
        '
        'ButtonSerializeToBinary
        '
        Me.ButtonSerializeToBinary.Location = New System.Drawing.Point(48, 218)
        Me.ButtonSerializeToBinary.Name = "ButtonSerializeToBinary"
        Me.ButtonSerializeToBinary.Size = New System.Drawing.Size(266, 49)
        Me.ButtonSerializeToBinary.TabIndex = 25
        Me.ButtonSerializeToBinary.Text = "Serialize"
        Me.ButtonSerializeToBinary.UseVisualStyleBackColor = True
        '
        'FormSerialize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 450)
        Me.Controls.Add(Me.ButtonSerializeToBinary)
        Me.Controls.Add(Me.ButtonDeserializeXML)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonDeserializeBin)
        Me.Controls.Add(Me.ButtonSerializeToXML)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormSerialize"
        Me.Text = "Serialization"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ButtonSerializeToXML As Button
    Friend WithEvents ButtonDeserializeBin As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonDeserializeXML As Button
    Friend WithEvents ButtonSerializeToBinary As Button
End Class
