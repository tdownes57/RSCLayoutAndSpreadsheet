<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPresetValues
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
        Me.ButtonAddValue = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.listPresetValues = New System.Windows.Forms.ListBox()
        Me.checkHasPresetValues = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'ButtonAddValue
        '
        Me.ButtonAddValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAddValue.Location = New System.Drawing.Point(359, 90)
        Me.ButtonAddValue.Name = "ButtonAddValue"
        Me.ButtonAddValue.Size = New System.Drawing.Size(104, 36)
        Me.ButtonAddValue.TabIndex = 26
        Me.ButtonAddValue.Text = "Add Value"
        Me.ButtonAddValue.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(86, 96)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(267, 30)
        Me.TextBox2.TabIndex = 25
        '
        'listPresetValues
        '
        Me.listPresetValues.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listPresetValues.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listPresetValues.FormattingEnabled = True
        Me.listPresetValues.ItemHeight = 20
        Me.listPresetValues.Location = New System.Drawing.Point(87, 140)
        Me.listPresetValues.Name = "listPresetValues"
        Me.listPresetValues.Size = New System.Drawing.Size(376, 144)
        Me.listPresetValues.TabIndex = 24
        '
        'checkHasPresetValues
        '
        Me.checkHasPresetValues.AutoSize = True
        Me.checkHasPresetValues.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkHasPresetValues.Location = New System.Drawing.Point(87, 66)
        Me.checkHasPresetValues.Name = "checkHasPresetValues"
        Me.checkHasPresetValues.Size = New System.Drawing.Size(214, 24)
        Me.checkHasPresetValues.TabIndex = 23
        Me.checkHasPresetValues.Text = "Are there preset values?"
        Me.checkHasPresetValues.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(183, 31)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Preset Values"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.Location = New System.Drawing.Point(385, 297)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(78, 59)
        Me.ButtonCancel.TabIndex = 21
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(237, 297)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(126, 59)
        Me.ButtonOK.TabIndex = 20
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(84, 287)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(89, 17)
        Me.LinkLabel1.TabIndex = 27
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Delete Value"
        '
        'FormPresetValues
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 369)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.ButtonAddValue)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.listPresetValues)
        Me.Controls.Add(Me.checkHasPresetValues)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Name = "FormPresetValues"
        Me.Text = "FormPresetValues"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonAddValue As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents listPresetValues As ListBox
    Friend WithEvents checkHasPresetValues As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
