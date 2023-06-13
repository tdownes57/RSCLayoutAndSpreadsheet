<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCSelectCIBField
    ''6/22/2022 Inherits System.Windows.Forms.UserControl
    Inherits __RSCWindowsControlLibrary.RSCMoveableControlVB

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
        Me.LabelHeader = New System.Windows.Forms.Label()
        Me.LinkLabelOnlyRelevant = New System.Windows.Forms.LinkLabel()
        Me.comboBoxRelevantFields = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'LabelHeader
        '
        Me.LabelHeader.BackColor = System.Drawing.Color.Transparent
        Me.LabelHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader.Location = New System.Drawing.Point(2, 0)
        Me.LabelHeader.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(178, 18)
        Me.LabelHeader.TabIndex = 4
        Me.LabelHeader.Text = "Relevant Field"
        '
        'LinkLabelOnlyRelevant
        '
        Me.LinkLabelOnlyRelevant.AutoSize = True
        Me.LinkLabelOnlyRelevant.Location = New System.Drawing.Point(2, 45)
        Me.LinkLabelOnlyRelevant.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabelOnlyRelevant.Name = "LinkLabelOnlyRelevant"
        Me.LinkLabelOnlyRelevant.Size = New System.Drawing.Size(162, 13)
        Me.LinkLabelOnlyRelevant.TabIndex = 3
        Me.LinkLabelOnlyRelevant.TabStop = True
        Me.LinkLabelOnlyRelevant.Text = "Only ""Relevant"" Fields are listed."
        '
        'comboBoxRelevantFields
        '
        Me.comboBoxRelevantFields.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comboBoxRelevantFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxRelevantFields.FormattingEnabled = True
        Me.comboBoxRelevantFields.Location = New System.Drawing.Point(2, 23)
        Me.comboBoxRelevantFields.Margin = New System.Windows.Forms.Padding(2)
        Me.comboBoxRelevantFields.Name = "comboBoxRelevantFields"
        Me.comboBoxRelevantFields.Size = New System.Drawing.Size(179, 21)
        Me.comboBoxRelevantFields.TabIndex = 5
        '
        'RSCSelectCIBField
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelHeader)
        Me.Controls.Add(Me.LinkLabelOnlyRelevant)
        Me.Controls.Add(Me.comboBoxRelevantFields)
        Me.Name = "RSCSelectCIBField"
        Me.Size = New System.Drawing.Size(182, 64)
        Me.Controls.SetChildIndex(Me.comboBoxRelevantFields, 0)
        Me.Controls.SetChildIndex(Me.LinkLabelOnlyRelevant, 0)
        Me.Controls.SetChildIndex(Me.LabelHeader, 0)
        Me.Controls.SetChildIndex(Me.LinkLabelConditional, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelHeader As Windows.Forms.Label
    Friend WithEvents LinkLabelOnlyRelevant As Windows.Forms.LinkLabel
    Friend WithEvents comboBoxRelevantFields As Windows.Forms.ComboBox
End Class
