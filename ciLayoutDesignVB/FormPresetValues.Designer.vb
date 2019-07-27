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
        Me.LabelPresetValueHdr = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkCreateSubsection = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'ButtonAddValue
        '
        Me.ButtonAddValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAddValue.Location = New System.Drawing.Point(332, 89)
        Me.ButtonAddValue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
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
        Me.TextBox2.Location = New System.Drawing.Point(89, 95)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(237, 30)
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
        Me.listPresetValues.Location = New System.Drawing.Point(89, 138)
        Me.listPresetValues.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.listPresetValues.Name = "listPresetValues"
        Me.listPresetValues.Size = New System.Drawing.Size(345, 184)
        Me.listPresetValues.TabIndex = 24
        '
        'checkHasPresetValues
        '
        Me.checkHasPresetValues.AutoSize = True
        Me.checkHasPresetValues.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkHasPresetValues.Location = New System.Drawing.Point(89, 64)
        Me.checkHasPresetValues.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
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
        Me.Label3.Location = New System.Drawing.Point(15, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(183, 31)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Preset Values"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(372, 406)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(77, 59)
        Me.ButtonCancel.TabIndex = 21
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Location = New System.Drawing.Point(224, 406)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(125, 59)
        Me.ButtonOK.TabIndex = 20
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'LabelPresetValueHdr
        '
        Me.LabelPresetValueHdr.AutoSize = True
        Me.LabelPresetValueHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPresetValueHdr.Location = New System.Drawing.Point(17, 333)
        Me.LabelPresetValueHdr.Name = "LabelPresetValueHdr"
        Me.LabelPresetValueHdr.Size = New System.Drawing.Size(107, 20)
        Me.LabelPresetValueHdr.TabIndex = 27
        Me.LabelPresetValueHdr.Text = "Preset value:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(130, 333)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 20)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Washington High"
        '
        'LinkCreateSubsection
        '
        Me.LinkCreateSubsection.AutoSize = True
        Me.LinkCreateSubsection.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkCreateSubsection.Location = New System.Drawing.Point(18, 365)
        Me.LinkCreateSubsection.Name = "LinkCreateSubsection"
        Me.LinkCreateSubsection.Size = New System.Drawing.Size(327, 20)
        Me.LinkCreateSubsection.TabIndex = 29
        Me.LinkCreateSubsection.TabStop = True
        Me.LinkCreateSubsection.Tag = "Create a sub-section for: {0}"
        Me.LinkCreateSubsection.Text = "Create a sub-section for Washington High."
        '
        'FormPresetValues
        '
        Me.AcceptButton = Me.ButtonOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(464, 479)
        Me.Controls.Add(Me.LinkCreateSubsection)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelPresetValueHdr)
        Me.Controls.Add(Me.ButtonAddValue)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.listPresetValues)
        Me.Controls.Add(Me.checkHasPresetValues)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Margin = New System.Windows.Forms.Padding(4)
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
    Friend WithEvents LabelPresetValueHdr As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkCreateSubsection As LinkLabel
End Class
