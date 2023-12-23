<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlOperation
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
        buttonMoveItems = New Button()
        buttonDelete = New Button()
        buttonInsert = New Button()
        Label15 = New Label()
        Label14 = New Label()
        numMoveAnchorBenchmark = New NumericUpDown()
        Label11 = New Label()
        Label12 = New Label()
        Label13 = New Label()
        numMoveRangeHowMany = New NumericUpDown()
        numMoveRangeStartBenchmark = New NumericUpDown()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        numDeleteHowMany = New NumericUpDown()
        numDeleteRangeBenchmarkStart = New NumericUpDown()
        Label6 = New Label()
        textInsertListOfValuesCSV = New TextBox()
        LabelInsertHeader = New Label()
        LabelInsertHowMany = New Label()
        LabelInsertAnchorHeader = New Label()
        numInsertHowMany = New NumericUpDown()
        numInsertAnchorBenchmark = New NumericUpDown()
        listInsertAfterOr = New ListBox()
        listMoveAfterOr = New ListBox()
        LinkInsertRandomize = New LinkLabel()
        LinkDeleteRandomize = New LinkLabel()
        LinkMoveRandomize = New LinkLabel()
        LabelBenchmarkVsIndex = New Label()
        CType(numMoveAnchorBenchmark, ComponentModel.ISupportInitialize).BeginInit()
        CType(numMoveRangeHowMany, ComponentModel.ISupportInitialize).BeginInit()
        CType(numMoveRangeStartBenchmark, ComponentModel.ISupportInitialize).BeginInit()
        CType(numDeleteHowMany, ComponentModel.ISupportInitialize).BeginInit()
        CType(numDeleteRangeBenchmarkStart, ComponentModel.ISupportInitialize).BeginInit()
        CType(numInsertHowMany, ComponentModel.ISupportInitialize).BeginInit()
        CType(numInsertAnchorBenchmark, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' buttonMoveItems
        ' 
        buttonMoveItems.Location = New Point(485, 311)
        buttonMoveItems.Name = "buttonMoveItems"
        buttonMoveItems.Size = New Size(133, 39)
        buttonMoveItems.TabIndex = 57
        buttonMoveItems.Text = "Move Items"
        buttonMoveItems.UseVisualStyleBackColor = True
        ' 
        ' buttonDelete
        ' 
        buttonDelete.Location = New Point(274, 180)
        buttonDelete.Name = "buttonDelete"
        buttonDelete.Size = New Size(133, 39)
        buttonDelete.TabIndex = 56
        buttonDelete.Text = "Delete Items"
        buttonDelete.UseVisualStyleBackColor = True
        ' 
        ' buttonInsert
        ' 
        buttonInsert.Location = New Point(488, 45)
        buttonInsert.Name = "buttonInsert"
        buttonInsert.Size = New Size(133, 39)
        buttonInsert.TabIndex = 55
        buttonInsert.Text = "Insert New Items"
        buttonInsert.UseVisualStyleBackColor = True
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(19, 344)
        Label15.Name = "Label15"
        Label15.Size = New Size(0, 15)
        Label15.TabIndex = 54
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(19, 318)
        Label14.Name = "Label14"
        Label14.Size = New Size(314, 15)
        Label14.TabIndex = 52
        Label14.Text = "What benchmark position to anchor (paste moved items)?"
        ' 
        ' numMoveAnchorBenchmark
        ' 
        numMoveAnchorBenchmark.Location = New Point(339, 316)
        numMoveAnchorBenchmark.Name = "numMoveAnchorBenchmark"
        numMoveAnchorBenchmark.Size = New Size(50, 23)
        numMoveAnchorBenchmark.TabIndex = 51
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label11.Location = New Point(19, 228)
        Label11.Name = "Label11"
        Label11.Size = New Size(99, 21)
        Label11.TabIndex = 50
        Label11.Text = "Move Items"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(19, 288)
        Label12.Name = "Label12"
        Label12.Size = New Size(120, 15)
        Label12.TabIndex = 49
        Label12.Text = "How many list items?"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(19, 259)
        Label13.Name = "Label13"
        Label13.Size = New Size(399, 15)
        Label13.TabIndex = 48
        Label13.Text = "What benchmark position to begin select (start of cut; inclusive; leftmost)?"
        ' 
        ' numMoveRangeHowMany
        ' 
        numMoveRangeHowMany.Location = New Point(257, 286)
        numMoveRangeHowMany.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        numMoveRangeHowMany.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numMoveRangeHowMany.Name = "numMoveRangeHowMany"
        numMoveRangeHowMany.Size = New Size(50, 23)
        numMoveRangeHowMany.TabIndex = 47
        numMoveRangeHowMany.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' numMoveRangeStartBenchmark
        ' 
        numMoveRangeStartBenchmark.Location = New Point(424, 257)
        numMoveRangeStartBenchmark.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numMoveRangeStartBenchmark.Name = "numMoveRangeStartBenchmark"
        numMoveRangeStartBenchmark.Size = New Size(50, 23)
        numMoveRangeStartBenchmark.TabIndex = 46
        numMoveRangeStartBenchmark.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(13, 228)
        Label7.Name = "Label7"
        Label7.Size = New Size(0, 15)
        Label7.TabIndex = 45
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label8.Location = New Point(13, 138)
        Label8.Name = "Label8"
        Label8.Size = New Size(106, 21)
        Label8.TabIndex = 44
        Label8.Text = "Delete Items"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(13, 198)
        Label9.Name = "Label9"
        Label9.Size = New Size(120, 15)
        Label9.TabIndex = 43
        Label9.Text = "How many list items?"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(13, 169)
        Label10.Name = "Label10"
        Label10.Size = New Size(189, 15)
        Label10.TabIndex = 42
        Label10.Text = "What benchmark position to start?"
        ' 
        ' numDeleteHowMany
        ' 
        numDeleteHowMany.Location = New Point(208, 196)
        numDeleteHowMany.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        numDeleteHowMany.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numDeleteHowMany.Name = "numDeleteHowMany"
        numDeleteHowMany.Size = New Size(50, 23)
        numDeleteHowMany.TabIndex = 41
        numDeleteHowMany.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' numDeleteRangeBenchmarkStart
        ' 
        numDeleteRangeBenchmarkStart.Location = New Point(208, 167)
        numDeleteRangeBenchmarkStart.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numDeleteRangeBenchmarkStart.Name = "numDeleteRangeBenchmarkStart"
        numDeleteRangeBenchmarkStart.Size = New Size(50, 23)
        numDeleteRangeBenchmarkStart.TabIndex = 40
        numDeleteRangeBenchmarkStart.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(13, 108)
        Label6.Name = "Label6"
        Label6.Size = New Size(324, 15)
        Label6.TabIndex = 39
        Label6.Text = "List of two-character values, separated by spaces:  (optional)"
        ' 
        ' textInsertListOfValuesCSV
        ' 
        textInsertListOfValuesCSV.BorderStyle = BorderStyle.FixedSingle
        textInsertListOfValuesCSV.Location = New Point(354, 105)
        textInsertListOfValuesCSV.Name = "textInsertListOfValuesCSV"
        textInsertListOfValuesCSV.Size = New Size(267, 23)
        textInsertListOfValuesCSV.TabIndex = 38
        textInsertListOfValuesCSV.Tag = "00"
        textInsertListOfValuesCSV.Text = "00 is default"
        ' 
        ' LabelInsertHeader
        ' 
        LabelInsertHeader.AutoSize = True
        LabelInsertHeader.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        LabelInsertHeader.Location = New Point(13, 18)
        LabelInsertHeader.Name = "LabelInsertHeader"
        LabelInsertHeader.Size = New Size(138, 21)
        LabelInsertHeader.TabIndex = 37
        LabelInsertHeader.Text = "Insert New Items"
        ' 
        ' LabelInsertHowMany
        ' 
        LabelInsertHowMany.AutoSize = True
        LabelInsertHowMany.Location = New Point(13, 78)
        LabelInsertHowMany.Name = "LabelInsertHowMany"
        LabelInsertHowMany.Size = New Size(120, 15)
        LabelInsertHowMany.TabIndex = 36
        LabelInsertHowMany.Text = "How many list items?"
        ' 
        ' LabelInsertAnchorHeader
        ' 
        LabelInsertAnchorHeader.AutoSize = True
        LabelInsertAnchorHeader.Location = New Point(13, 54)
        LabelInsertAnchorHeader.Name = "LabelInsertAnchorHeader"
        LabelInsertAnchorHeader.Size = New Size(304, 15)
        LabelInsertAnchorHeader.TabIndex = 35
        LabelInsertAnchorHeader.Text = "What benchmark position to anchor (attach new items)?"
        ' 
        ' numInsertHowMany
        ' 
        numInsertHowMany.Location = New Point(139, 76)
        numInsertHowMany.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        numInsertHowMany.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numInsertHowMany.Name = "numInsertHowMany"
        numInsertHowMany.Size = New Size(50, 23)
        numInsertHowMany.TabIndex = 34
        numInsertHowMany.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' numInsertAnchorBenchmark
        ' 
        numInsertAnchorBenchmark.Location = New Point(322, 52)
        numInsertAnchorBenchmark.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numInsertAnchorBenchmark.Name = "numInsertAnchorBenchmark"
        numInsertAnchorBenchmark.Size = New Size(50, 23)
        numInsertAnchorBenchmark.TabIndex = 33
        numInsertAnchorBenchmark.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' listInsertAfterOr
        ' 
        listInsertAfterOr.FormattingEnabled = True
        listInsertAfterOr.ItemHeight = 15
        listInsertAfterOr.Items.AddRange(New Object() {"After", "Before"})
        listInsertAfterOr.Location = New Point(378, 52)
        listInsertAfterOr.Name = "listInsertAfterOr"
        listInsertAfterOr.Size = New Size(54, 34)
        listInsertAfterOr.TabIndex = 58
        ' 
        ' listMoveAfterOr
        ' 
        listMoveAfterOr.FormattingEnabled = True
        listMoveAfterOr.ItemHeight = 15
        listMoveAfterOr.Items.AddRange(New Object() {"After", "Before"})
        listMoveAfterOr.Location = New Point(395, 316)
        listMoveAfterOr.Name = "listMoveAfterOr"
        listMoveAfterOr.Size = New Size(54, 34)
        listMoveAfterOr.TabIndex = 59
        ' 
        ' LinkInsertRandomize
        ' 
        LinkInsertRandomize.AutoSize = True
        LinkInsertRandomize.Location = New Point(488, 87)
        LinkInsertRandomize.Name = "LinkInsertRandomize"
        LinkInsertRandomize.Size = New Size(130, 15)
        LinkInsertRandomize.TabIndex = 60
        LinkInsertRandomize.TabStop = True
        LinkInsertRandomize.Text = "Perform Random Insert"
        ' 
        ' LinkDeleteRandomize
        ' 
        LinkDeleteRandomize.AutoSize = True
        LinkDeleteRandomize.Location = New Point(274, 222)
        LinkDeleteRandomize.Name = "LinkDeleteRandomize"
        LinkDeleteRandomize.Size = New Size(134, 15)
        LinkDeleteRandomize.TabIndex = 61
        LinkDeleteRandomize.TabStop = True
        LinkDeleteRandomize.Text = "Perform Random Delete"
        ' 
        ' LinkMoveRandomize
        ' 
        LinkMoveRandomize.AutoSize = True
        LinkMoveRandomize.Location = New Point(484, 353)
        LinkMoveRandomize.Name = "LinkMoveRandomize"
        LinkMoveRandomize.Size = New Size(131, 15)
        LinkMoveRandomize.TabIndex = 62
        LinkMoveRandomize.TabStop = True
        LinkMoveRandomize.Text = "Perform Random Move"
        ' 
        ' LabelBenchmarkVsIndex
        ' 
        LabelBenchmarkVsIndex.AutoSize = True
        LabelBenchmarkVsIndex.Location = New Point(25, 353)
        LabelBenchmarkVsIndex.Name = "LabelBenchmarkVsIndex"
        LabelBenchmarkVsIndex.Size = New Size(210, 15)
        LabelBenchmarkVsIndex.TabIndex = 63
        LabelBenchmarkVsIndex.Text = "(Benchmark equals Index Plus(+) One)"
        ' 
        ' UserControlOperation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LabelBenchmarkVsIndex)
        Controls.Add(LinkMoveRandomize)
        Controls.Add(LinkDeleteRandomize)
        Controls.Add(LinkInsertRandomize)
        Controls.Add(listMoveAfterOr)
        Controls.Add(listInsertAfterOr)
        Controls.Add(buttonMoveItems)
        Controls.Add(buttonDelete)
        Controls.Add(buttonInsert)
        Controls.Add(Label15)
        Controls.Add(Label14)
        Controls.Add(numMoveAnchorBenchmark)
        Controls.Add(Label11)
        Controls.Add(Label12)
        Controls.Add(Label13)
        Controls.Add(numMoveRangeHowMany)
        Controls.Add(numMoveRangeStartBenchmark)
        Controls.Add(Label7)
        Controls.Add(Label8)
        Controls.Add(Label9)
        Controls.Add(Label10)
        Controls.Add(numDeleteHowMany)
        Controls.Add(numDeleteRangeBenchmarkStart)
        Controls.Add(Label6)
        Controls.Add(textInsertListOfValuesCSV)
        Controls.Add(LabelInsertHeader)
        Controls.Add(LabelInsertHowMany)
        Controls.Add(LabelInsertAnchorHeader)
        Controls.Add(numInsertHowMany)
        Controls.Add(numInsertAnchorBenchmark)
        Name = "UserControlOperation"
        Size = New Size(646, 388)
        CType(numMoveAnchorBenchmark, ComponentModel.ISupportInitialize).EndInit()
        CType(numMoveRangeHowMany, ComponentModel.ISupportInitialize).EndInit()
        CType(numMoveRangeStartBenchmark, ComponentModel.ISupportInitialize).EndInit()
        CType(numDeleteHowMany, ComponentModel.ISupportInitialize).EndInit()
        CType(numDeleteRangeBenchmarkStart, ComponentModel.ISupportInitialize).EndInit()
        CType(numInsertHowMany, ComponentModel.ISupportInitialize).EndInit()
        CType(numInsertAnchorBenchmark, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents buttonMoveItems As Button
    Friend WithEvents buttonDelete As Button
    Friend WithEvents buttonInsert As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents numMoveAnchorBenchmark As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents numMoveRangeHowMany As NumericUpDown
    Friend WithEvents numMoveRangeStartBenchmark As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents numDeleteHowMany As NumericUpDown
    Friend WithEvents numDeleteRangeBenchmarkStart As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents textInsertListOfValuesCSV As TextBox
    Friend WithEvents LabelInsertHeader As Label
    Friend WithEvents LabelInsertHowMany As Label
    Friend WithEvents LabelInsertAnchorHeader As Label
    Friend WithEvents numInsertHowMany As NumericUpDown
    Friend WithEvents numInsertAnchorBenchmark As NumericUpDown
    Friend WithEvents listInsertAfterOr As ListBox
    Friend WithEvents listMoveAfterOr As ListBox
    Friend WithEvents LinkInsertRandomize As LinkLabel
    Friend WithEvents LinkDeleteRandomize As LinkLabel
    Friend WithEvents LinkMoveRandomize As LinkLabel
    Friend WithEvents LabelBenchmarkVsIndex As Label

End Class
