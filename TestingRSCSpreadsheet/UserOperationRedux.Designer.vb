<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserOperationRedux
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
        LinkUndoDelete = New LinkLabel()
        checkDeleteToEndpoint = New CheckBox()
        LinkDeleteToEndpoint = New LinkLabel()
        LinkDeleteRandomize = New LinkLabel()
        buttonDelete = New Button()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        numDeleteHowMany = New NumericUpDown()
        numDeleteRangeBenchmarkStart = New NumericUpDown()
        buttonSortList = New Button()
        listBoxAscendDescend = New ListBox()
        Label1 = New Label()
        Label2 = New Label()
        CType(numDeleteHowMany, ComponentModel.ISupportInitialize).BeginInit()
        CType(numDeleteRangeBenchmarkStart, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LinkUndoDelete
        ' 
        LinkUndoDelete.AutoSize = True
        LinkUndoDelete.Location = New Point(589, 230)
        LinkUndoDelete.Name = "LinkUndoDelete"
        LinkUndoDelete.Size = New Size(72, 15)
        LinkUndoDelete.TabIndex = 80
        LinkUndoDelete.TabStop = True
        LinkUndoDelete.Text = "Undo Delete"
        ' 
        ' checkDeleteToEndpoint
        ' 
        checkDeleteToEndpoint.AutoSize = True
        checkDeleteToEndpoint.Location = New Point(300, 233)
        checkDeleteToEndpoint.Name = "checkDeleteToEndpoint"
        checkDeleteToEndpoint.Size = New Size(283, 19)
        checkDeleteToEndpoint.TabIndex = 79
        checkDeleteToEndpoint.Text = "Bypass Count--Delete range extends to Endpoint"
        checkDeleteToEndpoint.UseVisualStyleBackColor = True
        ' 
        ' LinkDeleteToEndpoint
        ' 
        LinkDeleteToEndpoint.AutoSize = True
        LinkDeleteToEndpoint.Location = New Point(296, 233)
        LinkDeleteToEndpoint.Name = "LinkDeleteToEndpoint"
        LinkDeleteToEndpoint.Size = New Size(201, 15)
        LinkDeleteToEndpoint.TabIndex = 78
        LinkDeleteToEndpoint.TabStop = True
        LinkDeleteToEndpoint.Text = "Bypass Count--Delete Until Endpoint"
        LinkDeleteToEndpoint.Visible = False
        ' 
        ' LinkDeleteRandomize
        ' 
        LinkDeleteRandomize.AutoSize = True
        LinkDeleteRandomize.Location = New Point(391, 212)
        LinkDeleteRandomize.Name = "LinkDeleteRandomize"
        LinkDeleteRandomize.Size = New Size(134, 15)
        LinkDeleteRandomize.TabIndex = 77
        LinkDeleteRandomize.TabStop = True
        LinkDeleteRandomize.Text = "Perform Random Delete"
        ' 
        ' buttonDelete
        ' 
        buttonDelete.Location = New Point(531, 188)
        buttonDelete.Name = "buttonDelete"
        buttonDelete.Size = New Size(133, 39)
        buttonDelete.TabIndex = 76
        buttonDelete.Text = "Delete Items"
        buttonDelete.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label8.Location = New Point(45, 167)
        Label8.Name = "Label8"
        Label8.Size = New Size(106, 21)
        Label8.TabIndex = 75
        Label8.Text = "Delete Items"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(45, 227)
        Label9.Name = "Label9"
        Label9.Size = New Size(164, 15)
        Label9.TabIndex = 74
        Label9.Text = "How many list items? (Count)"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(45, 198)
        Label10.Name = "Label10"
        Label10.Size = New Size(189, 15)
        Label10.TabIndex = 73
        Label10.Text = "What benchmark position to start?"
        ' 
        ' numDeleteHowMany
        ' 
        numDeleteHowMany.Location = New Point(240, 225)
        numDeleteHowMany.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        numDeleteHowMany.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numDeleteHowMany.Name = "numDeleteHowMany"
        numDeleteHowMany.Size = New Size(50, 23)
        numDeleteHowMany.TabIndex = 72
        numDeleteHowMany.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' numDeleteRangeBenchmarkStart
        ' 
        numDeleteRangeBenchmarkStart.Location = New Point(240, 196)
        numDeleteRangeBenchmarkStart.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numDeleteRangeBenchmarkStart.Name = "numDeleteRangeBenchmarkStart"
        numDeleteRangeBenchmarkStart.Size = New Size(50, 23)
        numDeleteRangeBenchmarkStart.TabIndex = 71
        numDeleteRangeBenchmarkStart.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' buttonSortList
        ' 
        buttonSortList.Location = New Point(209, 282)
        buttonSortList.Name = "buttonSortList"
        buttonSortList.Size = New Size(133, 39)
        buttonSortList.TabIndex = 83
        buttonSortList.Text = "Sort Items in List"
        buttonSortList.UseVisualStyleBackColor = True
        ' 
        ' listBoxAscendDescend
        ' 
        listBoxAscendDescend.FormattingEnabled = True
        listBoxAscendDescend.ItemHeight = 15
        listBoxAscendDescend.Items.AddRange(New Object() {"Ascending", "Descending"})
        listBoxAscendDescend.Location = New Point(62, 287)
        listBoxAscendDescend.Name = "listBoxAscendDescend"
        listBoxAscendDescend.Size = New Size(141, 34)
        listBoxAscendDescend.TabIndex = 82
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label1.Location = New Point(45, 263)
        Label1.Name = "Label1"
        Label1.Size = New Size(87, 21)
        Label1.TabIndex = 81
        Label1.Text = "Sort Items"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 20F)
        Label2.Location = New Point(45, 77)
        Label2.Name = "Label2"
        Label2.Size = New Size(461, 37)
        Label2.TabIndex = 84
        Label2.Text = "Let's start slowly.... we can insert later."
        ' 
        ' UserOperationRedux
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Label2)
        Controls.Add(buttonSortList)
        Controls.Add(listBoxAscendDescend)
        Controls.Add(Label1)
        Controls.Add(LinkUndoDelete)
        Controls.Add(checkDeleteToEndpoint)
        Controls.Add(LinkDeleteToEndpoint)
        Controls.Add(LinkDeleteRandomize)
        Controls.Add(buttonDelete)
        Controls.Add(Label8)
        Controls.Add(Label9)
        Controls.Add(Label10)
        Controls.Add(numDeleteHowMany)
        Controls.Add(numDeleteRangeBenchmarkStart)
        Name = "UserOperationRedux"
        Size = New Size(744, 490)
        CType(numDeleteHowMany, ComponentModel.ISupportInitialize).EndInit()
        CType(numDeleteRangeBenchmarkStart, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LinkUndoDelete As LinkLabel
    Friend WithEvents checkDeleteToEndpoint As CheckBox
    Friend WithEvents LinkDeleteToEndpoint As LinkLabel
    Friend WithEvents LinkDeleteRandomize As LinkLabel
    Friend WithEvents buttonDelete As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents numDeleteHowMany As NumericUpDown
    Friend WithEvents numDeleteRangeBenchmarkStart As NumericUpDown
    Friend WithEvents buttonSortList As Button
    Friend WithEvents listBoxAscendDescend As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label

End Class
