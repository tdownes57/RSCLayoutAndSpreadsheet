<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDemo1DVertical
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
        ButtonSortBackward = New Button()
        LinkRefreshFirstItem = New LinkLabel()
        LinkApplicationDoevents = New LinkLabel()
        LinkRefreshList = New LinkLabel()
        ButtonSortForward = New Button()
        GroupMoveByAnchor = New GroupBox()
        buttonMoveItemsByAnchor = New Button()
        listMoveAfterOrBefore = New ListBox()
        LabelMoveBenchmark = New Label()
        numMoveAnchorBenchmark = New NumericUpDown()
        GroupMoveByShifting = New GroupBox()
        numericShiftRight = New NumericUpDown()
        buttonMoveShiftRight = New Button()
        numericShiftLeft = New NumericUpDown()
        buttonMoveShiftLeft = New Button()
        LinkClearRecordedOps = New LinkLabel()
        labelNumOperations = New Label()
        buttonUndo = New Button()
        buttonReDo = New Button()
        Label5 = New Label()
        Label4 = New Label()
        textboxMoveRange = New TextBox()
        Label7 = New Label()
        buttonRedoOp = New Button()
        buttonUndoLastStep = New Button()
        buttonInsertSingle = New Button()
        Label6 = New Label()
        textInsertListOfValuesCSV = New TextBox()
        Label2 = New Label()
        numInsertHowMany = New NumericUpDown()
        listInsertAfterOrBefore = New ListBox()
        buttonDelete = New Button()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        numDeleteHowMany = New NumericUpDown()
        numDeleteRangeBenchmarkStart = New NumericUpDown()
        buttonInsertMultiple = New Button()
        LabelInsertHeader = New Label()
        LabelInsertAnchorHeader = New Label()
        numInsertAnchorBenchmark = New NumericUpDown()
        richtextItemsDisplay = New RichTextBox()
        richtextBenchmark = New RichTextBox()
        Label1 = New Label()
        RichTextBox1 = New RichTextBox()
        RichTextBox2 = New RichTextBox()
        RichTextBox3 = New RichTextBox()
        LabelHeader1 = New Label()
        GroupMoveByAnchor.SuspendLayout()
        CType(numMoveAnchorBenchmark, ComponentModel.ISupportInitialize).BeginInit()
        GroupMoveByShifting.SuspendLayout()
        CType(numericShiftRight, ComponentModel.ISupportInitialize).BeginInit()
        CType(numericShiftLeft, ComponentModel.ISupportInitialize).BeginInit()
        CType(numInsertHowMany, ComponentModel.ISupportInitialize).BeginInit()
        CType(numDeleteHowMany, ComponentModel.ISupportInitialize).BeginInit()
        CType(numDeleteRangeBenchmarkStart, ComponentModel.ISupportInitialize).BeginInit()
        CType(numInsertAnchorBenchmark, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ButtonSortBackward
        ' 
        ButtonSortBackward.BackColor = Color.Cyan
        ButtonSortBackward.Location = New Point(1005, 272)
        ButtonSortBackward.Name = "ButtonSortBackward"
        ButtonSortBackward.Size = New Size(102, 39)
        ButtonSortBackward.TabIndex = 141
        ButtonSortBackward.Text = "Backward"
        ButtonSortBackward.UseVisualStyleBackColor = False
        ' 
        ' LinkRefreshFirstItem
        ' 
        LinkRefreshFirstItem.AutoSize = True
        LinkRefreshFirstItem.Location = New Point(377, 110)
        LinkRefreshFirstItem.Name = "LinkRefreshFirstItem"
        LinkRefreshFirstItem.Size = New Size(244, 15)
        LinkRefreshFirstItem.TabIndex = 140
        LinkRefreshFirstItem.TabStop = True
        LinkRefreshFirstItem.Text = "Displaying List should refresh First Item--OFF"
        ' 
        ' LinkApplicationDoevents
        ' 
        LinkApplicationDoevents.AutoSize = True
        LinkApplicationDoevents.Location = New Point(274, 110)
        LinkApplicationDoevents.Name = "LinkApplicationDoevents"
        LinkApplicationDoevents.Size = New Size(87, 15)
        LinkApplicationDoevents.TabIndex = 139
        LinkApplicationDoevents.TabStop = True
        LinkApplicationDoevents.Text = "DoEvents--OFF"
        ' 
        ' LinkRefreshList
        ' 
        LinkRefreshList.AutoSize = True
        LinkRefreshList.Location = New Point(184, 110)
        LinkRefreshList.Name = "LinkRefreshList"
        LinkRefreshList.Size = New Size(67, 15)
        LinkRefreshList.TabIndex = 138
        LinkRefreshList.TabStop = True
        LinkRefreshList.Text = "Refresh List"
        ' 
        ' ButtonSortForward
        ' 
        ButtonSortForward.BackColor = Color.Cyan
        ButtonSortForward.Location = New Point(862, 272)
        ButtonSortForward.Name = "ButtonSortForward"
        ButtonSortForward.Size = New Size(137, 39)
        ButtonSortForward.TabIndex = 137
        ButtonSortForward.Text = "Sort Items Forward"
        ButtonSortForward.UseVisualStyleBackColor = False
        ' 
        ' GroupMoveByAnchor
        ' 
        GroupMoveByAnchor.BackColor = Color.RosyBrown
        GroupMoveByAnchor.Controls.Add(buttonMoveItemsByAnchor)
        GroupMoveByAnchor.Controls.Add(listMoveAfterOrBefore)
        GroupMoveByAnchor.Controls.Add(LabelMoveBenchmark)
        GroupMoveByAnchor.Controls.Add(numMoveAnchorBenchmark)
        GroupMoveByAnchor.Location = New Point(164, 385)
        GroupMoveByAnchor.Name = "GroupMoveByAnchor"
        GroupMoveByAnchor.Size = New Size(457, 101)
        GroupMoveByAnchor.TabIndex = 136
        GroupMoveByAnchor.TabStop = False
        GroupMoveByAnchor.Text = "Move Range by Destination Anchor"
        ' 
        ' buttonMoveItemsByAnchor
        ' 
        buttonMoveItemsByAnchor.BackColor = Color.Cyan
        buttonMoveItemsByAnchor.Location = New Point(355, 30)
        buttonMoveItemsByAnchor.Name = "buttonMoveItemsByAnchor"
        buttonMoveItemsByAnchor.Size = New Size(87, 61)
        buttonMoveItemsByAnchor.TabIndex = 94
        buttonMoveItemsByAnchor.Text = "Move Range of Items"
        buttonMoveItemsByAnchor.UseVisualStyleBackColor = False
        ' 
        ' listMoveAfterOrBefore
        ' 
        listMoveAfterOrBefore.FormattingEnabled = True
        listMoveAfterOrBefore.ItemHeight = 15
        listMoveAfterOrBefore.Items.AddRange(New Object() {"Insert After Anchor", """      "" Before Anchor"})
        listMoveAfterOrBefore.Location = New Point(219, 36)
        listMoveAfterOrBefore.Name = "listMoveAfterOrBefore"
        listMoveAfterOrBefore.Size = New Size(115, 34)
        listMoveAfterOrBefore.TabIndex = 93
        ' 
        ' LabelMoveBenchmark
        ' 
        LabelMoveBenchmark.Location = New Point(-3, 30)
        LabelMoveBenchmark.Name = "LabelMoveBenchmark"
        LabelMoveBenchmark.Size = New Size(157, 57)
        LabelMoveBenchmark.TabIndex = 92
        LabelMoveBenchmark.Text = "What benchmark position to anchor (attach moved items)?"
        ' 
        ' numMoveAnchorBenchmark
        ' 
        numMoveAnchorBenchmark.Font = New Font("Segoe UI", 12F)
        numMoveAnchorBenchmark.Location = New Point(157, 36)
        numMoveAnchorBenchmark.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numMoveAnchorBenchmark.Name = "numMoveAnchorBenchmark"
        numMoveAnchorBenchmark.Size = New Size(56, 29)
        numMoveAnchorBenchmark.TabIndex = 91
        numMoveAnchorBenchmark.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' GroupMoveByShifting
        ' 
        GroupMoveByShifting.BackColor = Color.RosyBrown
        GroupMoveByShifting.Controls.Add(numericShiftRight)
        GroupMoveByShifting.Controls.Add(buttonMoveShiftRight)
        GroupMoveByShifting.Controls.Add(numericShiftLeft)
        GroupMoveByShifting.Controls.Add(buttonMoveShiftLeft)
        GroupMoveByShifting.Location = New Point(663, 385)
        GroupMoveByShifting.Name = "GroupMoveByShifting"
        GroupMoveByShifting.Size = New Size(236, 101)
        GroupMoveByShifting.TabIndex = 135
        GroupMoveByShifting.TabStop = False
        GroupMoveByShifting.Text = "Move Range by Shifting / Swapping"
        ' 
        ' numericShiftRight
        ' 
        numericShiftRight.Font = New Font("Segoe UI", 12F)
        numericShiftRight.Location = New Point(115, 58)
        numericShiftRight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numericShiftRight.Name = "numericShiftRight"
        numericShiftRight.Size = New Size(56, 29)
        numericShiftRight.TabIndex = 104
        numericShiftRight.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' buttonMoveShiftRight
        ' 
        buttonMoveShiftRight.BackColor = Color.Cyan
        buttonMoveShiftRight.Location = New Point(22, 56)
        buttonMoveShiftRight.Name = "buttonMoveShiftRight"
        buttonMoveShiftRight.Size = New Size(87, 28)
        buttonMoveShiftRight.TabIndex = 103
        buttonMoveShiftRight.Text = "Move Right"
        buttonMoveShiftRight.UseVisualStyleBackColor = False
        ' 
        ' numericShiftLeft
        ' 
        numericShiftLeft.Font = New Font("Segoe UI", 12F)
        numericShiftLeft.Location = New Point(115, 24)
        numericShiftLeft.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numericShiftLeft.Name = "numericShiftLeft"
        numericShiftLeft.Size = New Size(56, 29)
        numericShiftLeft.TabIndex = 102
        numericShiftLeft.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' buttonMoveShiftLeft
        ' 
        buttonMoveShiftLeft.BackColor = Color.Cyan
        buttonMoveShiftLeft.Location = New Point(22, 22)
        buttonMoveShiftLeft.Name = "buttonMoveShiftLeft"
        buttonMoveShiftLeft.Size = New Size(87, 28)
        buttonMoveShiftLeft.TabIndex = 100
        buttonMoveShiftLeft.Text = "Move Left"
        buttonMoveShiftLeft.UseVisualStyleBackColor = False
        ' 
        ' LinkClearRecordedOps
        ' 
        LinkClearRecordedOps.AutoSize = True
        LinkClearRecordedOps.Location = New Point(991, 119)
        LinkClearRecordedOps.Name = "LinkClearRecordedOps"
        LinkClearRecordedOps.Size = New Size(143, 15)
        LinkClearRecordedOps.TabIndex = 134
        LinkClearRecordedOps.TabStop = True
        LinkClearRecordedOps.Text = "Clear recorded operations"
        ' 
        ' labelNumOperations
        ' 
        labelNumOperations.BorderStyle = BorderStyle.FixedSingle
        labelNumOperations.Location = New Point(925, 167)
        labelNumOperations.Name = "labelNumOperations"
        labelNumOperations.Size = New Size(182, 45)
        labelNumOperations.TabIndex = 133
        labelNumOperations.Tag = "Number of ops: {0}"
        labelNumOperations.Text = "Number of ops recorded: 0"
        ' 
        ' buttonUndo
        ' 
        buttonUndo.Enabled = False
        buttonUndo.Location = New Point(925, 136)
        buttonUndo.Name = "buttonUndo"
        buttonUndo.Size = New Size(114, 27)
        buttonUndo.TabIndex = 132
        buttonUndo.Text = "<<< Undo"
        buttonUndo.UseVisualStyleBackColor = True
        ' 
        ' buttonReDo
        ' 
        buttonReDo.Enabled = False
        buttonReDo.Location = New Point(1045, 137)
        buttonReDo.Name = "buttonReDo"
        buttonReDo.Size = New Size(86, 27)
        buttonReDo.TabIndex = 131
        buttonReDo.Text = "Re-do >>>"
        buttonReDo.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(801, 363)
        Label5.Name = "Label5"
        Label5.Size = New Size(163, 15)
        Label5.TabIndex = 130
        Label5.Tag = "Number of items in range: {0)"
        Label5.Text = "Number of items in range: {0)"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(274, 364)
        Label4.Name = "Label4"
        Label4.Size = New Size(245, 15)
        Label4.TabIndex = 129
        Label4.Text = "Range to move (Click the bottom row items.)"
        ' 
        ' textboxMoveRange
        ' 
        textboxMoveRange.BackColor = SystemColors.InactiveCaption
        textboxMoveRange.BorderStyle = BorderStyle.None
        textboxMoveRange.Font = New Font("Segoe UI", 12F)
        textboxMoveRange.Location = New Point(525, 357)
        textboxMoveRange.Name = "textboxMoveRange"
        textboxMoveRange.Size = New Size(270, 22)
        textboxMoveRange.TabIndex = 128
        textboxMoveRange.Tag = "00"
        textboxMoveRange.Text = "++"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label7.Location = New Point(160, 358)
        Label7.Name = "Label7"
        Label7.Size = New Size(99, 21)
        Label7.TabIndex = 127
        Label7.Text = "Move Items"
        ' 
        ' buttonRedoOp
        ' 
        buttonRedoOp.Enabled = False
        buttonRedoOp.Location = New Point(995, 440)
        buttonRedoOp.Name = "buttonRedoOp"
        buttonRedoOp.Size = New Size(154, 39)
        buttonRedoOp.TabIndex = 126
        buttonRedoOp.Text = "Redo (if applicable)"
        buttonRedoOp.UseVisualStyleBackColor = True
        ' 
        ' buttonUndoLastStep
        ' 
        buttonUndoLastStep.Enabled = False
        buttonUndoLastStep.Location = New Point(983, 395)
        buttonUndoLastStep.Name = "buttonUndoLastStep"
        buttonUndoLastStep.Size = New Size(166, 39)
        buttonUndoLastStep.TabIndex = 125
        buttonUndoLastStep.Text = "Undo Last Step"
        buttonUndoLastStep.UseVisualStyleBackColor = True
        ' 
        ' buttonInsertSingle
        ' 
        buttonInsertSingle.Location = New Point(646, 201)
        buttonInsertSingle.Name = "buttonInsertSingle"
        buttonInsertSingle.Size = New Size(166, 39)
        buttonInsertSingle.TabIndex = 124
        buttonInsertSingle.Text = "Insert New Item (Single)"
        buttonInsertSingle.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(163, 214)
        Label6.Name = "Label6"
        Label6.Size = New Size(324, 15)
        Label6.TabIndex = 123
        Label6.Text = "List of two-character values, separated by spaces:  (optional)"
        ' 
        ' textInsertListOfValuesCSV
        ' 
        textInsertListOfValuesCSV.BorderStyle = BorderStyle.FixedSingle
        textInsertListOfValuesCSV.Location = New Point(501, 211)
        textInsertListOfValuesCSV.Name = "textInsertListOfValuesCSV"
        textInsertListOfValuesCSV.Size = New Size(139, 23)
        textInsertListOfValuesCSV.TabIndex = 122
        textInsertListOfValuesCSV.Tag = "00"
        textInsertListOfValuesCSV.Text = "++"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(163, 190)
        Label2.Name = "Label2"
        Label2.Size = New Size(164, 15)
        Label2.TabIndex = 121
        Label2.Text = "How many list items? (Count)"
        ' 
        ' numInsertHowMany
        ' 
        numInsertHowMany.Location = New Point(355, 188)
        numInsertHowMany.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        numInsertHowMany.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numInsertHowMany.Name = "numInsertHowMany"
        numInsertHowMany.Size = New Size(50, 23)
        numInsertHowMany.TabIndex = 120
        numInsertHowMany.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' listInsertAfterOrBefore
        ' 
        listInsertAfterOrBefore.FormattingEnabled = True
        listInsertAfterOrBefore.ItemHeight = 15
        listInsertAfterOrBefore.Items.AddRange(New Object() {"Insert After Anchor", """      "" Before Anchor"})
        listInsertAfterOrBefore.Location = New Point(525, 163)
        listInsertAfterOrBefore.Name = "listInsertAfterOrBefore"
        listInsertAfterOrBefore.Size = New Size(115, 34)
        listInsertAfterOrBefore.TabIndex = 113
        ' 
        ' buttonDelete
        ' 
        buttonDelete.Location = New Point(424, 278)
        buttonDelete.Name = "buttonDelete"
        buttonDelete.Size = New Size(133, 39)
        buttonDelete.TabIndex = 119
        buttonDelete.Text = "Delete Items"
        buttonDelete.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label8.Location = New Point(163, 259)
        Label8.Name = "Label8"
        Label8.Size = New Size(106, 21)
        Label8.TabIndex = 118
        Label8.Text = "Delete Items"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(163, 319)
        Label9.Name = "Label9"
        Label9.Size = New Size(164, 15)
        Label9.TabIndex = 117
        Label9.Text = "How many list items? (Count)"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(163, 290)
        Label10.Name = "Label10"
        Label10.Size = New Size(189, 15)
        Label10.TabIndex = 116
        Label10.Text = "What benchmark position to start?"
        ' 
        ' numDeleteHowMany
        ' 
        numDeleteHowMany.Location = New Point(355, 317)
        numDeleteHowMany.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        numDeleteHowMany.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numDeleteHowMany.Name = "numDeleteHowMany"
        numDeleteHowMany.Size = New Size(50, 23)
        numDeleteHowMany.TabIndex = 115
        numDeleteHowMany.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' numDeleteRangeBenchmarkStart
        ' 
        numDeleteRangeBenchmarkStart.Location = New Point(355, 288)
        numDeleteRangeBenchmarkStart.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numDeleteRangeBenchmarkStart.Name = "numDeleteRangeBenchmarkStart"
        numDeleteRangeBenchmarkStart.Size = New Size(50, 23)
        numDeleteRangeBenchmarkStart.TabIndex = 114
        numDeleteRangeBenchmarkStart.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' buttonInsertMultiple
        ' 
        buttonInsertMultiple.BackColor = Color.Cyan
        buttonInsertMultiple.Location = New Point(646, 156)
        buttonInsertMultiple.Name = "buttonInsertMultiple"
        buttonInsertMultiple.Size = New Size(166, 39)
        buttonInsertMultiple.TabIndex = 112
        buttonInsertMultiple.Text = "Insert New Items (Multiple)"
        buttonInsertMultiple.UseVisualStyleBackColor = False
        ' 
        ' LabelInsertHeader
        ' 
        LabelInsertHeader.AutoSize = True
        LabelInsertHeader.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        LabelInsertHeader.Location = New Point(163, 129)
        LabelInsertHeader.Name = "LabelInsertHeader"
        LabelInsertHeader.Size = New Size(138, 21)
        LabelInsertHeader.TabIndex = 111
        LabelInsertHeader.Text = "Insert New Items"
        ' 
        ' LabelInsertAnchorHeader
        ' 
        LabelInsertAnchorHeader.AutoSize = True
        LabelInsertAnchorHeader.Location = New Point(163, 165)
        LabelInsertAnchorHeader.Name = "LabelInsertAnchorHeader"
        LabelInsertAnchorHeader.Size = New Size(304, 15)
        LabelInsertAnchorHeader.TabIndex = 110
        LabelInsertAnchorHeader.Text = "What benchmark position to anchor (attach new items)?"
        ' 
        ' numInsertAnchorBenchmark
        ' 
        numInsertAnchorBenchmark.Location = New Point(469, 163)
        numInsertAnchorBenchmark.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numInsertAnchorBenchmark.Name = "numInsertAnchorBenchmark"
        numInsertAnchorBenchmark.Size = New Size(50, 23)
        numInsertAnchorBenchmark.TabIndex = 109
        numInsertAnchorBenchmark.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' richtextItemsDisplay
        ' 
        richtextItemsDisplay.BackColor = SystemColors.InactiveCaption
        richtextItemsDisplay.BorderStyle = BorderStyle.FixedSingle
        richtextItemsDisplay.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        richtextItemsDisplay.Location = New Point(28, 27)
        richtextItemsDisplay.Name = "richtextItemsDisplay"
        richtextItemsDisplay.Size = New Size(27, 469)
        richtextItemsDisplay.TabIndex = 143
        richtextItemsDisplay.Tag = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        richtextItemsDisplay.Text = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        ' 
        ' richtextBenchmark
        ' 
        richtextBenchmark.BackColor = SystemColors.Control
        richtextBenchmark.BorderStyle = BorderStyle.None
        richtextBenchmark.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        richtextBenchmark.Location = New Point(8, 29)
        richtextBenchmark.Name = "richtextBenchmark"
        richtextBenchmark.Size = New Size(24, 480)
        richtextBenchmark.TabIndex = 142
        richtextBenchmark.Tag = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        richtextBenchmark.Text = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label1.Location = New Point(28, 3)
        Label1.Name = "Label1"
        Label1.Size = New Size(122, 21)
        Label1.TabIndex = 144
        Label1.Text = "A     B1    B2  B3"
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BorderStyle = BorderStyle.FixedSingle
        RichTextBox1.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox1.Location = New Point(61, 27)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(27, 469)
        RichTextBox1.TabIndex = 145
        RichTextBox1.Tag = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        RichTextBox1.Text = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        ' 
        ' RichTextBox2
        ' 
        RichTextBox2.BorderStyle = BorderStyle.FixedSingle
        RichTextBox2.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox2.Location = New Point(96, 27)
        RichTextBox2.Name = "RichTextBox2"
        RichTextBox2.Size = New Size(27, 469)
        RichTextBox2.TabIndex = 146
        RichTextBox2.Tag = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        RichTextBox2.Text = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        ' 
        ' RichTextBox3
        ' 
        RichTextBox3.BorderStyle = BorderStyle.FixedSingle
        RichTextBox3.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox3.Location = New Point(127, 27)
        RichTextBox3.Name = "RichTextBox3"
        RichTextBox3.Size = New Size(27, 469)
        RichTextBox3.TabIndex = 147
        RichTextBox3.Tag = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        RichTextBox3.Text = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        ' 
        ' LabelHeader1
        ' 
        LabelHeader1.AutoSize = True
        LabelHeader1.Font = New Font("Segoe UI", 17F, FontStyle.Bold)
        LabelHeader1.Location = New Point(163, 29)
        LabelHeader1.Name = "LabelHeader1"
        LabelHeader1.Size = New Size(630, 31)
        LabelHeader1.TabIndex = 148
        LabelHeader1.Text = "Vertical Header Column (A) with Parallel Lists (B1, B2, B3)"
        ' 
        ' FormDemo1DVertical
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1162, 504)
        Controls.Add(LabelHeader1)
        Controls.Add(RichTextBox3)
        Controls.Add(RichTextBox2)
        Controls.Add(RichTextBox1)
        Controls.Add(Label1)
        Controls.Add(richtextItemsDisplay)
        Controls.Add(richtextBenchmark)
        Controls.Add(ButtonSortBackward)
        Controls.Add(LinkRefreshFirstItem)
        Controls.Add(LinkApplicationDoevents)
        Controls.Add(LinkRefreshList)
        Controls.Add(ButtonSortForward)
        Controls.Add(GroupMoveByAnchor)
        Controls.Add(GroupMoveByShifting)
        Controls.Add(LinkClearRecordedOps)
        Controls.Add(labelNumOperations)
        Controls.Add(buttonUndo)
        Controls.Add(buttonReDo)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(textboxMoveRange)
        Controls.Add(Label7)
        Controls.Add(buttonRedoOp)
        Controls.Add(buttonUndoLastStep)
        Controls.Add(buttonInsertSingle)
        Controls.Add(Label6)
        Controls.Add(textInsertListOfValuesCSV)
        Controls.Add(Label2)
        Controls.Add(numInsertHowMany)
        Controls.Add(listInsertAfterOrBefore)
        Controls.Add(buttonDelete)
        Controls.Add(Label8)
        Controls.Add(Label9)
        Controls.Add(Label10)
        Controls.Add(numDeleteHowMany)
        Controls.Add(numDeleteRangeBenchmarkStart)
        Controls.Add(buttonInsertMultiple)
        Controls.Add(LabelInsertHeader)
        Controls.Add(LabelInsertAnchorHeader)
        Controls.Add(numInsertAnchorBenchmark)
        Name = "FormDemo1DVertical"
        Text = "FormDemo1DVertical"
        GroupMoveByAnchor.ResumeLayout(False)
        CType(numMoveAnchorBenchmark, ComponentModel.ISupportInitialize).EndInit()
        GroupMoveByShifting.ResumeLayout(False)
        CType(numericShiftRight, ComponentModel.ISupportInitialize).EndInit()
        CType(numericShiftLeft, ComponentModel.ISupportInitialize).EndInit()
        CType(numInsertHowMany, ComponentModel.ISupportInitialize).EndInit()
        CType(numDeleteHowMany, ComponentModel.ISupportInitialize).EndInit()
        CType(numDeleteRangeBenchmarkStart, ComponentModel.ISupportInitialize).EndInit()
        CType(numInsertAnchorBenchmark, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ButtonSortBackward As Button
    Friend WithEvents LinkRefreshFirstItem As LinkLabel
    Friend WithEvents LinkApplicationDoevents As LinkLabel
    Friend WithEvents LinkRefreshList As LinkLabel
    Friend WithEvents ButtonSortForward As Button
    Friend WithEvents GroupMoveByAnchor As GroupBox
    Friend WithEvents buttonMoveItemsByAnchor As Button
    Friend WithEvents listMoveAfterOrBefore As ListBox
    Friend WithEvents LabelMoveBenchmark As Label
    Friend WithEvents numMoveAnchorBenchmark As NumericUpDown
    Friend WithEvents GroupMoveByShifting As GroupBox
    Friend WithEvents numericShiftRight As NumericUpDown
    Friend WithEvents buttonMoveShiftRight As Button
    Friend WithEvents numericShiftLeft As NumericUpDown
    Friend WithEvents buttonMoveShiftLeft As Button
    Friend WithEvents LinkClearRecordedOps As LinkLabel
    Friend WithEvents labelNumOperations As Label
    Friend WithEvents buttonUndo As Button
    Friend WithEvents buttonReDo As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents textboxMoveRange As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents buttonRedoOp As Button
    Friend WithEvents buttonUndoLastStep As Button
    Friend WithEvents buttonInsertSingle As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents textInsertListOfValuesCSV As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents numInsertHowMany As NumericUpDown
    Friend WithEvents listInsertAfterOrBefore As ListBox
    Friend WithEvents buttonDelete As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents numDeleteHowMany As NumericUpDown
    Friend WithEvents numDeleteRangeBenchmarkStart As NumericUpDown
    Friend WithEvents buttonInsertMultiple As Button
    Friend WithEvents LabelInsertHeader As Label
    Friend WithEvents LabelInsertAnchorHeader As Label
    Friend WithEvents numInsertAnchorBenchmark As NumericUpDown
    Friend WithEvents richtextItemsDisplay As RichTextBox
    Friend WithEvents richtextBenchmark As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents LabelHeader1 As Label
End Class
