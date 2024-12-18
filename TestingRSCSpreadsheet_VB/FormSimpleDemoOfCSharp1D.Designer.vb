<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSimpleDemoOfCSharp1D
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
        listInsertAfterOrBefore = New ListBox()
        buttonInsertMultiple = New Button()
        LabelInsertHeader = New Label()
        LabelInsertAnchorHeader = New Label()
        numInsertAnchorBenchmark = New NumericUpDown()
        Label3 = New Label()
        Label1 = New Label()
        LabelHeader1 = New Label()
        buttonDelete = New Button()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        numDeleteHowMany = New NumericUpDown()
        numDeleteRangeBenchmarkStart = New NumericUpDown()
        Label2 = New Label()
        numInsertHowMany = New NumericUpDown()
        Label6 = New Label()
        textInsertListOfValuesCSV = New TextBox()
        buttonInsertSingle = New Button()
        labelItemsDisplay = New Label()
        labelBenchmark = New Label()
        buttonUndoLastStep = New Button()
        buttonRedoOp = New Button()
        richtextBenchmark = New RichTextBox()
        richtextItemsDisplay = New RichTextBox()
        Label4 = New Label()
        textboxMoveRange = New TextBox()
        Label7 = New Label()
        Label5 = New Label()
        LinkClearRecordedOps = New LinkLabel()
        labelNumOperations = New Label()
        buttonUndo = New Button()
        buttonReDo = New Button()
        buttonMoveShiftLeft = New Button()
        GroupMoveByShifting = New GroupBox()
        numericShiftRight = New NumericUpDown()
        buttonMoveShiftRight = New Button()
        numericShiftLeft = New NumericUpDown()
        GroupMoveByAnchor = New GroupBox()
        buttonMoveItemsByAnchor = New Button()
        listMoveAfterOrBefore = New ListBox()
        LabelMoveBenchmark = New Label()
        numMoveAnchorBenchmark = New NumericUpDown()
        ButtonSortForward = New Button()
        LinkRefreshList = New LinkLabel()
        CType(numInsertAnchorBenchmark, ComponentModel.ISupportInitialize).BeginInit()
        CType(numDeleteHowMany, ComponentModel.ISupportInitialize).BeginInit()
        CType(numDeleteRangeBenchmarkStart, ComponentModel.ISupportInitialize).BeginInit()
        CType(numInsertHowMany, ComponentModel.ISupportInitialize).BeginInit()
        GroupMoveByShifting.SuspendLayout()
        CType(numericShiftRight, ComponentModel.ISupportInitialize).BeginInit()
        CType(numericShiftLeft, ComponentModel.ISupportInitialize).BeginInit()
        GroupMoveByAnchor.SuspendLayout()
        CType(numMoveAnchorBenchmark, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' listInsertAfterOrBefore
        ' 
        listInsertAfterOrBefore.FormattingEnabled = True
        listInsertAfterOrBefore.ItemHeight = 15
        listInsertAfterOrBefore.Items.AddRange(New Object() {"Insert After Anchor", """      "" Before Anchor"})
        listInsertAfterOrBefore.Location = New Point(380, 195)
        listInsertAfterOrBefore.Name = "listInsertAfterOrBefore"
        listInsertAfterOrBefore.Size = New Size(115, 34)
        listInsertAfterOrBefore.TabIndex = 63
        ' 
        ' buttonInsertMultiple
        ' 
        buttonInsertMultiple.BackColor = Color.Cyan
        buttonInsertMultiple.Location = New Point(501, 188)
        buttonInsertMultiple.Name = "buttonInsertMultiple"
        buttonInsertMultiple.Size = New Size(166, 39)
        buttonInsertMultiple.TabIndex = 62
        buttonInsertMultiple.Text = "Insert New Items (Multiple)"
        buttonInsertMultiple.UseVisualStyleBackColor = False
        ' 
        ' LabelInsertHeader
        ' 
        LabelInsertHeader.AutoSize = True
        LabelInsertHeader.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        LabelInsertHeader.Location = New Point(18, 161)
        LabelInsertHeader.Name = "LabelInsertHeader"
        LabelInsertHeader.Size = New Size(138, 21)
        LabelInsertHeader.TabIndex = 61
        LabelInsertHeader.Text = "Insert New Items"
        ' 
        ' LabelInsertAnchorHeader
        ' 
        LabelInsertAnchorHeader.AutoSize = True
        LabelInsertAnchorHeader.Location = New Point(18, 197)
        LabelInsertAnchorHeader.Name = "LabelInsertAnchorHeader"
        LabelInsertAnchorHeader.Size = New Size(304, 15)
        LabelInsertAnchorHeader.TabIndex = 60
        LabelInsertAnchorHeader.Text = "What benchmark position to anchor (attach new items)?"
        ' 
        ' numInsertAnchorBenchmark
        ' 
        numInsertAnchorBenchmark.Location = New Point(324, 195)
        numInsertAnchorBenchmark.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numInsertAnchorBenchmark.Name = "numInsertAnchorBenchmark"
        numInsertAnchorBenchmark.Size = New Size(50, 23)
        numInsertAnchorBenchmark.TabIndex = 59
        numInsertAnchorBenchmark.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(41, 71)
        Label3.Name = "Label3"
        Label3.Size = New Size(178, 15)
        Label3.TabIndex = 67
        Label3.Text = "List of current column positions:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(18, 56)
        Label1.Name = "Label1"
        Label1.Size = New Size(226, 15)
        Label1.TabIndex = 65
        Label1.Text = "List of column positions, as a benchmark:"
        ' 
        ' LabelHeader1
        ' 
        LabelHeader1.AutoSize = True
        LabelHeader1.Font = New Font("Segoe UI", 12F)
        LabelHeader1.Location = New Point(15, 30)
        LabelHeader1.Name = "LabelHeader1"
        LabelHeader1.Size = New Size(303, 21)
        LabelHeader1.TabIndex = 64
        LabelHeader1.Text = "Testing RSC Doubly-Linked List operations"
        ' 
        ' buttonDelete
        ' 
        buttonDelete.Location = New Point(279, 310)
        buttonDelete.Name = "buttonDelete"
        buttonDelete.Size = New Size(133, 39)
        buttonDelete.TabIndex = 73
        buttonDelete.Text = "Delete Items"
        buttonDelete.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label8.Location = New Point(18, 291)
        Label8.Name = "Label8"
        Label8.Size = New Size(106, 21)
        Label8.TabIndex = 72
        Label8.Text = "Delete Items"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(18, 351)
        Label9.Name = "Label9"
        Label9.Size = New Size(164, 15)
        Label9.TabIndex = 71
        Label9.Text = "How many list items? (Count)"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(18, 322)
        Label10.Name = "Label10"
        Label10.Size = New Size(189, 15)
        Label10.TabIndex = 70
        Label10.Text = "What benchmark position to start?"
        ' 
        ' numDeleteHowMany
        ' 
        numDeleteHowMany.Location = New Point(210, 349)
        numDeleteHowMany.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        numDeleteHowMany.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numDeleteHowMany.Name = "numDeleteHowMany"
        numDeleteHowMany.Size = New Size(50, 23)
        numDeleteHowMany.TabIndex = 69
        numDeleteHowMany.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' numDeleteRangeBenchmarkStart
        ' 
        numDeleteRangeBenchmarkStart.Location = New Point(210, 320)
        numDeleteRangeBenchmarkStart.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numDeleteRangeBenchmarkStart.Name = "numDeleteRangeBenchmarkStart"
        numDeleteRangeBenchmarkStart.Size = New Size(50, 23)
        numDeleteRangeBenchmarkStart.TabIndex = 68
        numDeleteRangeBenchmarkStart.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(18, 222)
        Label2.Name = "Label2"
        Label2.Size = New Size(164, 15)
        Label2.TabIndex = 76
        Label2.Text = "How many list items? (Count)"
        ' 
        ' numInsertHowMany
        ' 
        numInsertHowMany.Location = New Point(210, 220)
        numInsertHowMany.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        numInsertHowMany.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numInsertHowMany.Name = "numInsertHowMany"
        numInsertHowMany.Size = New Size(50, 23)
        numInsertHowMany.TabIndex = 75
        numInsertHowMany.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(18, 246)
        Label6.Name = "Label6"
        Label6.Size = New Size(324, 15)
        Label6.TabIndex = 78
        Label6.Text = "List of two-character values, separated by spaces:  (optional)"
        ' 
        ' textInsertListOfValuesCSV
        ' 
        textInsertListOfValuesCSV.BorderStyle = BorderStyle.FixedSingle
        textInsertListOfValuesCSV.Location = New Point(356, 243)
        textInsertListOfValuesCSV.Name = "textInsertListOfValuesCSV"
        textInsertListOfValuesCSV.Size = New Size(139, 23)
        textInsertListOfValuesCSV.TabIndex = 77
        textInsertListOfValuesCSV.Tag = "00"
        textInsertListOfValuesCSV.Text = "++"
        ' 
        ' buttonInsertSingle
        ' 
        buttonInsertSingle.Location = New Point(501, 233)
        buttonInsertSingle.Name = "buttonInsertSingle"
        buttonInsertSingle.Size = New Size(166, 39)
        buttonInsertSingle.TabIndex = 79
        buttonInsertSingle.Text = "Insert New Item (Single)"
        buttonInsertSingle.UseVisualStyleBackColor = True
        ' 
        ' labelItemsDisplay
        ' 
        labelItemsDisplay.BorderStyle = BorderStyle.FixedSingle
        labelItemsDisplay.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        labelItemsDisplay.Location = New Point(356, 33)
        labelItemsDisplay.Name = "labelItemsDisplay"
        labelItemsDisplay.Size = New Size(657, 24)
        labelItemsDisplay.TabIndex = 81
        labelItemsDisplay.Tag = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        labelItemsDisplay.Text = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        labelItemsDisplay.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' labelBenchmark
        ' 
        labelBenchmark.BorderStyle = BorderStyle.FixedSingle
        labelBenchmark.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        labelBenchmark.Location = New Point(356, 9)
        labelBenchmark.Name = "labelBenchmark"
        labelBenchmark.Size = New Size(648, 24)
        labelBenchmark.TabIndex = 80
        labelBenchmark.Tag = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        labelBenchmark.Text = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        labelBenchmark.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' buttonUndoLastStep
        ' 
        buttonUndoLastStep.Enabled = False
        buttonUndoLastStep.Location = New Point(838, 427)
        buttonUndoLastStep.Name = "buttonUndoLastStep"
        buttonUndoLastStep.Size = New Size(166, 39)
        buttonUndoLastStep.TabIndex = 82
        buttonUndoLastStep.Text = "Undo Last Step"
        buttonUndoLastStep.UseVisualStyleBackColor = True
        ' 
        ' buttonRedoOp
        ' 
        buttonRedoOp.Enabled = False
        buttonRedoOp.Location = New Point(850, 472)
        buttonRedoOp.Name = "buttonRedoOp"
        buttonRedoOp.Size = New Size(154, 39)
        buttonRedoOp.TabIndex = 83
        buttonRedoOp.Text = "Redo (if applicable)"
        buttonRedoOp.UseVisualStyleBackColor = True
        ' 
        ' richtextBenchmark
        ' 
        richtextBenchmark.BorderStyle = BorderStyle.None
        richtextBenchmark.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        richtextBenchmark.Location = New Point(36, 98)
        richtextBenchmark.Name = "richtextBenchmark"
        richtextBenchmark.Size = New Size(895, 23)
        richtextBenchmark.TabIndex = 84
        richtextBenchmark.Tag = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        richtextBenchmark.Text = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        ' 
        ' richtextItemsDisplay
        ' 
        richtextItemsDisplay.BorderStyle = BorderStyle.FixedSingle
        richtextItemsDisplay.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        richtextItemsDisplay.Location = New Point(36, 116)
        richtextItemsDisplay.Name = "richtextItemsDisplay"
        richtextItemsDisplay.Size = New Size(895, 23)
        richtextItemsDisplay.TabIndex = 85
        richtextItemsDisplay.Tag = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        richtextItemsDisplay.Text = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(129, 396)
        Label4.Name = "Label4"
        Label4.Size = New Size(245, 15)
        Label4.TabIndex = 94
        Label4.Text = "Range to move (Click the bottom row items.)"
        ' 
        ' textboxMoveRange
        ' 
        textboxMoveRange.BackColor = SystemColors.InactiveCaption
        textboxMoveRange.BorderStyle = BorderStyle.None
        textboxMoveRange.Font = New Font("Segoe UI", 12F)
        textboxMoveRange.Location = New Point(380, 389)
        textboxMoveRange.Name = "textboxMoveRange"
        textboxMoveRange.Size = New Size(270, 22)
        textboxMoveRange.TabIndex = 93
        textboxMoveRange.Tag = "00"
        textboxMoveRange.Text = "++"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label7.Location = New Point(15, 390)
        Label7.Name = "Label7"
        Label7.Size = New Size(99, 21)
        Label7.TabIndex = 88
        Label7.Text = "Move Items"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(656, 395)
        Label5.Name = "Label5"
        Label5.Size = New Size(163, 15)
        Label5.TabIndex = 95
        Label5.Tag = "Number of items in range: {0)"
        Label5.Text = "Number of items in range: {0)"
        ' 
        ' LinkClearRecordedOps
        ' 
        LinkClearRecordedOps.AutoSize = True
        LinkClearRecordedOps.Location = New Point(846, 151)
        LinkClearRecordedOps.Name = "LinkClearRecordedOps"
        LinkClearRecordedOps.Size = New Size(143, 15)
        LinkClearRecordedOps.TabIndex = 99
        LinkClearRecordedOps.TabStop = True
        LinkClearRecordedOps.Text = "Clear recorded operations"
        ' 
        ' labelNumOperations
        ' 
        labelNumOperations.BorderStyle = BorderStyle.FixedSingle
        labelNumOperations.Location = New Point(780, 199)
        labelNumOperations.Name = "labelNumOperations"
        labelNumOperations.Size = New Size(182, 45)
        labelNumOperations.TabIndex = 98
        labelNumOperations.Tag = "Number of ops: {0}"
        labelNumOperations.Text = "Number of ops recorded: 0"
        ' 
        ' buttonUndo
        ' 
        buttonUndo.Enabled = False
        buttonUndo.Location = New Point(780, 168)
        buttonUndo.Name = "buttonUndo"
        buttonUndo.Size = New Size(114, 27)
        buttonUndo.TabIndex = 97
        buttonUndo.Text = "<<< Undo"
        buttonUndo.UseVisualStyleBackColor = True
        ' 
        ' buttonReDo
        ' 
        buttonReDo.Enabled = False
        buttonReDo.Location = New Point(900, 169)
        buttonReDo.Name = "buttonReDo"
        buttonReDo.Size = New Size(86, 27)
        buttonReDo.TabIndex = 96
        buttonReDo.Text = "Re-do >>>"
        buttonReDo.UseVisualStyleBackColor = True
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
        ' GroupMoveByShifting
        ' 
        GroupMoveByShifting.BackColor = Color.RosyBrown
        GroupMoveByShifting.Controls.Add(numericShiftRight)
        GroupMoveByShifting.Controls.Add(buttonMoveShiftRight)
        GroupMoveByShifting.Controls.Add(numericShiftLeft)
        GroupMoveByShifting.Controls.Add(buttonMoveShiftLeft)
        GroupMoveByShifting.Location = New Point(552, 417)
        GroupMoveByShifting.Name = "GroupMoveByShifting"
        GroupMoveByShifting.Size = New Size(236, 101)
        GroupMoveByShifting.TabIndex = 102
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
        ' GroupMoveByAnchor
        ' 
        GroupMoveByAnchor.BackColor = Color.RosyBrown
        GroupMoveByAnchor.Controls.Add(buttonMoveItemsByAnchor)
        GroupMoveByAnchor.Controls.Add(listMoveAfterOrBefore)
        GroupMoveByAnchor.Controls.Add(LabelMoveBenchmark)
        GroupMoveByAnchor.Controls.Add(numMoveAnchorBenchmark)
        GroupMoveByAnchor.Location = New Point(53, 417)
        GroupMoveByAnchor.Name = "GroupMoveByAnchor"
        GroupMoveByAnchor.Size = New Size(457, 101)
        GroupMoveByAnchor.TabIndex = 103
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
        ' ButtonSortForward
        ' 
        ButtonSortForward.BackColor = Color.Cyan
        ButtonSortForward.Location = New Point(706, 60)
        ButtonSortForward.Name = "ButtonSortForward"
        ButtonSortForward.Size = New Size(137, 39)
        ButtonSortForward.TabIndex = 104
        ButtonSortForward.Text = "Sort Items Forward"
        ButtonSortForward.UseVisualStyleBackColor = False
        ' 
        ' LinkRefreshList
        ' 
        LinkRefreshList.AutoSize = True
        LinkRefreshList.Location = New Point(39, 142)
        LinkRefreshList.Name = "LinkRefreshList"
        LinkRefreshList.Size = New Size(143, 15)
        LinkRefreshList.TabIndex = 105
        LinkRefreshList.TabStop = True
        LinkRefreshList.Text = "Clear recorded operations"
        ' 
        ' FormSimpleDemoOfCSharp1D
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1023, 541)
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
        Controls.Add(richtextItemsDisplay)
        Controls.Add(labelItemsDisplay)
        Controls.Add(richtextBenchmark)
        Controls.Add(buttonRedoOp)
        Controls.Add(buttonUndoLastStep)
        Controls.Add(labelBenchmark)
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
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(LabelHeader1)
        Controls.Add(buttonInsertMultiple)
        Controls.Add(LabelInsertHeader)
        Controls.Add(LabelInsertAnchorHeader)
        Controls.Add(numInsertAnchorBenchmark)
        Name = "FormSimpleDemoOfCSharp1D"
        Padding = New Padding(3, 0, 0, 0)
        Text = "Simple Demo of One-Dimensional Manager"
        CType(numInsertAnchorBenchmark, ComponentModel.ISupportInitialize).EndInit()
        CType(numDeleteHowMany, ComponentModel.ISupportInitialize).EndInit()
        CType(numDeleteRangeBenchmarkStart, ComponentModel.ISupportInitialize).EndInit()
        CType(numInsertHowMany, ComponentModel.ISupportInitialize).EndInit()
        GroupMoveByShifting.ResumeLayout(False)
        CType(numericShiftRight, ComponentModel.ISupportInitialize).EndInit()
        CType(numericShiftLeft, ComponentModel.ISupportInitialize).EndInit()
        GroupMoveByAnchor.ResumeLayout(False)
        CType(numMoveAnchorBenchmark, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents listInsertAfterOrBefore As ListBox
    Friend WithEvents buttonInsertMultiple As Button
    Friend WithEvents LabelInsertHeader As Label
    Friend WithEvents LabelInsertAnchorHeader As Label
    Friend WithEvents numInsertAnchorBenchmark As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents buttonDelete As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents numDeleteHowMany As NumericUpDown
    Friend WithEvents numDeleteRangeBenchmarkStart As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents numInsertHowMany As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents textInsertListOfValuesCSV As TextBox
    Friend WithEvents buttonInsertSingle As Button
    Friend WithEvents labelItemsDisplay As Label
    Friend WithEvents labelBenchmark As Label
    Friend WithEvents buttonUndoLastStep As Button
    Friend WithEvents buttonRedoOp As Button
    Friend WithEvents richtextBenchmark As RichTextBox
    Friend WithEvents richtextItemsDisplay As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents textboxMoveRange As TextBox
    Friend WithEvents buttonMoveShiftRight As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LinkClearRecordedOps As LinkLabel
    Friend WithEvents labelNumOperations As Label
    Friend WithEvents buttonUndo As Button
    Friend WithEvents buttonReDo As Button
    Friend WithEvents buttonMoveShiftLeft As Button
    Friend WithEvents GroupMoveByShifting As GroupBox
    Friend WithEvents numericShiftRight As NumericUpDown
    Friend WithEvents numericShiftLeft As NumericUpDown
    Friend WithEvents GroupMoveByAnchor As GroupBox
    Friend WithEvents buttonMoveItemsByAnchor As Button
    Friend WithEvents listMoveAfterOrBefore As ListBox
    Friend WithEvents LabelMoveBenchmark As Label
    Friend WithEvents numMoveAnchorBenchmark As NumericUpDown
    Friend WithEvents ButtonSortForward As Button
    Friend WithEvents LinkRefreshList As LinkLabel

End Class
