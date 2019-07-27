<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCustomFieldsGrid
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
        Me.components = New System.ComponentModel.Container()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextFieldIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateFieldIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsDateFieldDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TextorDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelCaptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExampleValueToUseInLayoutDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClassFieldsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClassFieldsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TextFieldIdDataGridViewTextBoxColumn, Me.DateFieldIdDataGridViewTextBoxColumn, Me.IsDateFieldDataGridViewCheckBoxColumn, Me.TextorDateDataGridViewTextBoxColumn, Me.LabelCaptionDataGridViewTextBoxColumn, Me.ExampleValueToUseInLayoutDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ClassFieldsBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(31, 84)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1035, 425)
        Me.DataGridView1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 36)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Grid for Custom Fields"
        '
        'TextFieldIdDataGridViewTextBoxColumn
        '
        Me.TextFieldIdDataGridViewTextBoxColumn.DataPropertyName = "TextFieldId"
        Me.TextFieldIdDataGridViewTextBoxColumn.HeaderText = "TextFieldId"
        Me.TextFieldIdDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.TextFieldIdDataGridViewTextBoxColumn.Name = "TextFieldIdDataGridViewTextBoxColumn"
        Me.TextFieldIdDataGridViewTextBoxColumn.Width = 125
        '
        'DateFieldIdDataGridViewTextBoxColumn
        '
        Me.DateFieldIdDataGridViewTextBoxColumn.DataPropertyName = "DateFieldId"
        Me.DateFieldIdDataGridViewTextBoxColumn.HeaderText = "DateFieldId"
        Me.DateFieldIdDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.DateFieldIdDataGridViewTextBoxColumn.Name = "DateFieldIdDataGridViewTextBoxColumn"
        Me.DateFieldIdDataGridViewTextBoxColumn.Width = 125
        '
        'IsDateFieldDataGridViewCheckBoxColumn
        '
        Me.IsDateFieldDataGridViewCheckBoxColumn.DataPropertyName = "IsDateField"
        Me.IsDateFieldDataGridViewCheckBoxColumn.HeaderText = "IsDateField"
        Me.IsDateFieldDataGridViewCheckBoxColumn.MinimumWidth = 6
        Me.IsDateFieldDataGridViewCheckBoxColumn.Name = "IsDateFieldDataGridViewCheckBoxColumn"
        Me.IsDateFieldDataGridViewCheckBoxColumn.Width = 125
        '
        'TextorDateDataGridViewTextBoxColumn
        '
        Me.TextorDateDataGridViewTextBoxColumn.DataPropertyName = "Text_orDate"
        Me.TextorDateDataGridViewTextBoxColumn.HeaderText = "Text_orDate"
        Me.TextorDateDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.TextorDateDataGridViewTextBoxColumn.Name = "TextorDateDataGridViewTextBoxColumn"
        Me.TextorDateDataGridViewTextBoxColumn.Width = 125
        '
        'LabelCaptionDataGridViewTextBoxColumn
        '
        Me.LabelCaptionDataGridViewTextBoxColumn.DataPropertyName = "LabelCaption"
        Me.LabelCaptionDataGridViewTextBoxColumn.HeaderText = "LabelCaption"
        Me.LabelCaptionDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.LabelCaptionDataGridViewTextBoxColumn.Name = "LabelCaptionDataGridViewTextBoxColumn"
        Me.LabelCaptionDataGridViewTextBoxColumn.Width = 125
        '
        'ExampleValueToUseInLayoutDataGridViewTextBoxColumn
        '
        Me.ExampleValueToUseInLayoutDataGridViewTextBoxColumn.DataPropertyName = "ExampleValueToUseInLayout"
        Me.ExampleValueToUseInLayoutDataGridViewTextBoxColumn.HeaderText = "ExampleValueToUseInLayout"
        Me.ExampleValueToUseInLayoutDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.ExampleValueToUseInLayoutDataGridViewTextBoxColumn.Name = "ExampleValueToUseInLayoutDataGridViewTextBoxColumn"
        Me.ExampleValueToUseInLayoutDataGridViewTextBoxColumn.Width = 225
        '
        'ClassFieldsBindingSource
        '
        Me.ClassFieldsBindingSource.DataSource = GetType(ciLayoutDesignVB.ClassFieldCustomized)
        '
        'FormCustomFieldsGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1112, 535)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormCustomFieldsGrid"
        Me.Text = "FormCustomFields"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClassFieldsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ClassFieldsBindingSource As BindingSource
    Friend WithEvents Label1 As Label
    Friend WithEvents TextFieldIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateFieldIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IsDateFieldDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents TextorDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LabelCaptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExampleValueToUseInLayoutDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
