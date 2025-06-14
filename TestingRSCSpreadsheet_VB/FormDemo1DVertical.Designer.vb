﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        buttonUndoVertical = New Button()
        buttonRedoVertical = New Button()
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
        LabelA_B1_B2_B3 = New Label()
        LabelHeader1 = New Label()
        FlowColumnB1 = New FlowLayoutPanel()
        UserControlRichbox1 = New DLLUserControlRichbox()
        UserControlRichbox4 = New DLLUserControlRichbox()
        UserControlRichbox7 = New DLLUserControlRichbox()
        FlowColumnB2 = New FlowLayoutPanel()
        UserControlRichbox2 = New DLLUserControlRichbox()
        UserControlRichbox5 = New DLLUserControlRichbox()
        UserControlRichbox8 = New DLLUserControlRichbox()
        FlowColumnB3 = New FlowLayoutPanel()
        UserControlRichbox3 = New DLLUserControlRichbox()
        UserControlRichbox6 = New DLLUserControlRichbox()
        UserControlRichbox9 = New DLLUserControlRichbox()
        FlowRowNumbersOnly = New FlowLayoutPanel()
        TextBox13 = New TextBox()
        TextBox14 = New TextBox()
        TextBox15 = New TextBox()
        richtextItemsDisplay = New RichTextBox()
        DllUserControlRichbox1 = New DLLUserControlRichbox()
        checkOperateUponListA = New CheckBox()
        buttonUndoAnyOperation = New Button()
        buttonMoveColumnB = New Button()
        GroupMoveByAnchor.SuspendLayout()
        CType(numMoveAnchorBenchmark, ComponentModel.ISupportInitialize).BeginInit()
        GroupMoveByShifting.SuspendLayout()
        CType(numericShiftRight, ComponentModel.ISupportInitialize).BeginInit()
        CType(numericShiftLeft, ComponentModel.ISupportInitialize).BeginInit()
        CType(numInsertHowMany, ComponentModel.ISupportInitialize).BeginInit()
        CType(numDeleteHowMany, ComponentModel.ISupportInitialize).BeginInit()
        CType(numDeleteRangeBenchmarkStart, ComponentModel.ISupportInitialize).BeginInit()
        CType(numInsertAnchorBenchmark, ComponentModel.ISupportInitialize).BeginInit()
        FlowColumnB1.SuspendLayout()
        FlowColumnB2.SuspendLayout()
        FlowColumnB3.SuspendLayout()
        FlowRowNumbersOnly.SuspendLayout()
        SuspendLayout()
        ' 
        ' ButtonSortBackward
        ' 
        ButtonSortBackward.BackColor = Color.Cyan
        ButtonSortBackward.Location = New Point(976, 305)
        ButtonSortBackward.Name = "ButtonSortBackward"
        ButtonSortBackward.Size = New Size(172, 39)
        ButtonSortBackward.TabIndex = 141
        ButtonSortBackward.Text = "Backward Vertical Sort"
        ButtonSortBackward.UseVisualStyleBackColor = False
        ' 
        ' LinkRefreshFirstItem
        ' 
        LinkRefreshFirstItem.AutoSize = True
        LinkRefreshFirstItem.Location = New Point(443, 104)
        LinkRefreshFirstItem.Name = "LinkRefreshFirstItem"
        LinkRefreshFirstItem.Size = New Size(244, 15)
        LinkRefreshFirstItem.TabIndex = 140
        LinkRefreshFirstItem.TabStop = True
        LinkRefreshFirstItem.Text = "Displaying List should refresh First Item--OFF"
        ' 
        ' LinkApplicationDoevents
        ' 
        LinkApplicationDoevents.AutoSize = True
        LinkApplicationDoevents.Location = New Point(340, 104)
        LinkApplicationDoevents.Name = "LinkApplicationDoevents"
        LinkApplicationDoevents.Size = New Size(87, 15)
        LinkApplicationDoevents.TabIndex = 139
        LinkApplicationDoevents.TabStop = True
        LinkApplicationDoevents.Text = "DoEvents--OFF"
        ' 
        ' LinkRefreshList
        ' 
        LinkRefreshList.AutoSize = True
        LinkRefreshList.Location = New Point(250, 104)
        LinkRefreshList.Name = "LinkRefreshList"
        LinkRefreshList.Size = New Size(67, 15)
        LinkRefreshList.TabIndex = 138
        LinkRefreshList.TabStop = True
        LinkRefreshList.Text = "Refresh List"
        ' 
        ' ButtonSortForward
        ' 
        ButtonSortForward.BackColor = Color.Cyan
        ButtonSortForward.Location = New Point(876, 260)
        ButtonSortForward.Name = "ButtonSortForward"
        ButtonSortForward.Size = New Size(252, 39)
        ButtonSortForward.TabIndex = 137
        ButtonSortForward.Text = "Sort Items Forward (Vertical Sort)"
        ButtonSortForward.UseVisualStyleBackColor = False
        ' 
        ' GroupMoveByAnchor
        ' 
        GroupMoveByAnchor.BackColor = Color.RosyBrown
        GroupMoveByAnchor.Controls.Add(buttonMoveItemsByAnchor)
        GroupMoveByAnchor.Controls.Add(listMoveAfterOrBefore)
        GroupMoveByAnchor.Controls.Add(LabelMoveBenchmark)
        GroupMoveByAnchor.Controls.Add(numMoveAnchorBenchmark)
        GroupMoveByAnchor.Location = New Point(230, 379)
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
        GroupMoveByShifting.Location = New Point(729, 379)
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
        LinkClearRecordedOps.Location = New Point(976, 75)
        LinkClearRecordedOps.Name = "LinkClearRecordedOps"
        LinkClearRecordedOps.Size = New Size(134, 15)
        LinkClearRecordedOps.TabIndex = 134
        LinkClearRecordedOps.TabStop = True
        LinkClearRecordedOps.Text = "Clear vertical operations"
        ' 
        ' labelNumOperations
        ' 
        labelNumOperations.BorderStyle = BorderStyle.FixedSingle
        labelNumOperations.Location = New Point(910, 123)
        labelNumOperations.Name = "labelNumOperations"
        labelNumOperations.Size = New Size(254, 21)
        labelNumOperations.TabIndex = 133
        labelNumOperations.Tag = "Number of ops: {0}"
        labelNumOperations.Text = "Number of vertical ops recorded: 0"
        ' 
        ' buttonUndoVertical
        ' 
        buttonUndoVertical.Enabled = False
        buttonUndoVertical.Location = New Point(891, 92)
        buttonUndoVertical.Name = "buttonUndoVertical"
        buttonUndoVertical.Size = New Size(133, 28)
        buttonUndoVertical.TabIndex = 132
        buttonUndoVertical.Text = "<<< Undo Vertical"
        buttonUndoVertical.UseVisualStyleBackColor = True
        ' 
        ' buttonRedoVertical
        ' 
        buttonRedoVertical.Enabled = False
        buttonRedoVertical.Location = New Point(1030, 93)
        buttonRedoVertical.Name = "buttonRedoVertical"
        buttonRedoVertical.Size = New Size(134, 27)
        buttonRedoVertical.TabIndex = 131
        buttonRedoVertical.Text = "Re-do vertical >>>"
        buttonRedoVertical.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(867, 357)
        Label5.Name = "Label5"
        Label5.Size = New Size(163, 15)
        Label5.TabIndex = 130
        Label5.Tag = "Number of items in range: {0)"
        Label5.Text = "Number of items in range: {0)"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(340, 358)
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
        textboxMoveRange.Location = New Point(591, 351)
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
        Label7.Location = New Point(226, 352)
        Label7.Name = "Label7"
        Label7.Size = New Size(99, 21)
        Label7.TabIndex = 127
        Label7.Text = "Move Items"
        ' 
        ' buttonRedoOp
        ' 
        buttonRedoOp.Enabled = False
        buttonRedoOp.Location = New Point(1061, 434)
        buttonRedoOp.Name = "buttonRedoOp"
        buttonRedoOp.Size = New Size(154, 39)
        buttonRedoOp.TabIndex = 126
        buttonRedoOp.Text = "Redo (if applicable)"
        buttonRedoOp.UseVisualStyleBackColor = True
        ' 
        ' buttonUndoLastStep
        ' 
        buttonUndoLastStep.Enabled = False
        buttonUndoLastStep.Location = New Point(1049, 389)
        buttonUndoLastStep.Name = "buttonUndoLastStep"
        buttonUndoLastStep.Size = New Size(166, 39)
        buttonUndoLastStep.TabIndex = 125
        buttonUndoLastStep.Text = "Undo Last Step"
        buttonUndoLastStep.UseVisualStyleBackColor = True
        ' 
        ' buttonInsertSingle
        ' 
        buttonInsertSingle.Location = New Point(712, 195)
        buttonInsertSingle.Name = "buttonInsertSingle"
        buttonInsertSingle.Size = New Size(166, 39)
        buttonInsertSingle.TabIndex = 124
        buttonInsertSingle.Text = "Insert New Item (Single)"
        buttonInsertSingle.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(229, 208)
        Label6.Name = "Label6"
        Label6.Size = New Size(324, 15)
        Label6.TabIndex = 123
        Label6.Text = "List of two-character values, separated by spaces:  (optional)"
        ' 
        ' textInsertListOfValuesCSV
        ' 
        textInsertListOfValuesCSV.BorderStyle = BorderStyle.FixedSingle
        textInsertListOfValuesCSV.Location = New Point(567, 205)
        textInsertListOfValuesCSV.Name = "textInsertListOfValuesCSV"
        textInsertListOfValuesCSV.Size = New Size(139, 23)
        textInsertListOfValuesCSV.TabIndex = 122
        textInsertListOfValuesCSV.Tag = "00"
        textInsertListOfValuesCSV.Text = "++"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(229, 184)
        Label2.Name = "Label2"
        Label2.Size = New Size(164, 15)
        Label2.TabIndex = 121
        Label2.Text = "How many list items? (Count)"
        ' 
        ' numInsertHowMany
        ' 
        numInsertHowMany.Location = New Point(421, 182)
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
        listInsertAfterOrBefore.Location = New Point(591, 157)
        listInsertAfterOrBefore.Name = "listInsertAfterOrBefore"
        listInsertAfterOrBefore.Size = New Size(115, 34)
        listInsertAfterOrBefore.TabIndex = 113
        ' 
        ' buttonDelete
        ' 
        buttonDelete.Location = New Point(490, 272)
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
        Label8.Location = New Point(229, 253)
        Label8.Name = "Label8"
        Label8.Size = New Size(106, 21)
        Label8.TabIndex = 118
        Label8.Text = "Delete Items"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(229, 313)
        Label9.Name = "Label9"
        Label9.Size = New Size(164, 15)
        Label9.TabIndex = 117
        Label9.Text = "How many list items? (Count)"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(229, 284)
        Label10.Name = "Label10"
        Label10.Size = New Size(189, 15)
        Label10.TabIndex = 116
        Label10.Text = "What benchmark position to start?"
        ' 
        ' numDeleteHowMany
        ' 
        numDeleteHowMany.Location = New Point(421, 311)
        numDeleteHowMany.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        numDeleteHowMany.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numDeleteHowMany.Name = "numDeleteHowMany"
        numDeleteHowMany.Size = New Size(50, 23)
        numDeleteHowMany.TabIndex = 115
        numDeleteHowMany.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' numDeleteRangeBenchmarkStart
        ' 
        numDeleteRangeBenchmarkStart.Location = New Point(421, 282)
        numDeleteRangeBenchmarkStart.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numDeleteRangeBenchmarkStart.Name = "numDeleteRangeBenchmarkStart"
        numDeleteRangeBenchmarkStart.Size = New Size(50, 23)
        numDeleteRangeBenchmarkStart.TabIndex = 114
        numDeleteRangeBenchmarkStart.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' buttonInsertMultiple
        ' 
        buttonInsertMultiple.BackColor = Color.Cyan
        buttonInsertMultiple.Location = New Point(712, 150)
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
        LabelInsertHeader.Location = New Point(229, 123)
        LabelInsertHeader.Name = "LabelInsertHeader"
        LabelInsertHeader.Size = New Size(138, 21)
        LabelInsertHeader.TabIndex = 111
        LabelInsertHeader.Text = "Insert New Items"
        ' 
        ' LabelInsertAnchorHeader
        ' 
        LabelInsertAnchorHeader.AutoSize = True
        LabelInsertAnchorHeader.Location = New Point(229, 159)
        LabelInsertAnchorHeader.Name = "LabelInsertAnchorHeader"
        LabelInsertAnchorHeader.Size = New Size(304, 15)
        LabelInsertAnchorHeader.TabIndex = 110
        LabelInsertAnchorHeader.Text = "What benchmark position to anchor (attach new items)?"
        ' 
        ' numInsertAnchorBenchmark
        ' 
        numInsertAnchorBenchmark.Location = New Point(535, 157)
        numInsertAnchorBenchmark.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numInsertAnchorBenchmark.Name = "numInsertAnchorBenchmark"
        numInsertAnchorBenchmark.Size = New Size(50, 23)
        numInsertAnchorBenchmark.TabIndex = 109
        numInsertAnchorBenchmark.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' LabelA_B1_B2_B3
        ' 
        LabelA_B1_B2_B3.AutoSize = True
        LabelA_B1_B2_B3.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        LabelA_B1_B2_B3.Location = New Point(28, 3)
        LabelA_B1_B2_B3.Name = "LabelA_B1_B2_B3"
        LabelA_B1_B2_B3.Size = New Size(138, 21)
        LabelA_B1_B2_B3.TabIndex = 144
        LabelA_B1_B2_B3.Text = " A      B1    B2    B3"
        ' 
        ' LabelHeader1
        ' 
        LabelHeader1.AutoSize = True
        LabelHeader1.Font = New Font("Segoe UI", 17F, FontStyle.Bold)
        LabelHeader1.Location = New Point(261, 8)
        LabelHeader1.Name = "LabelHeader1"
        LabelHeader1.Size = New Size(630, 31)
        LabelHeader1.TabIndex = 148
        LabelHeader1.Text = "Vertical Header Column (A) with Parallel Lists (B1, B2, B3)"
        ' 
        ' FlowColumnB1
        ' 
        FlowColumnB1.BackColor = SystemColors.ActiveCaption
        FlowColumnB1.BorderStyle = BorderStyle.FixedSingle
        FlowColumnB1.Controls.Add(UserControlRichbox1)
        FlowColumnB1.Controls.Add(UserControlRichbox4)
        FlowColumnB1.Controls.Add(UserControlRichbox7)
        FlowColumnB1.Location = New Point(69, 27)
        FlowColumnB1.Name = "FlowColumnB1"
        FlowColumnB1.Size = New Size(29, 453)
        FlowColumnB1.TabIndex = 150
        ' 
        ' UserControlRichbox1
        ' 
        UserControlRichbox1.HighlightInBlue = False
        UserControlRichbox1.HighlightInCyan = False
        UserControlRichbox1.HighlightInGreen = False
        UserControlRichbox1.HighlightInRed = False
        UserControlRichbox1.Location = New Point(3, 3)
        UserControlRichbox1.Name = "UserControlRichbox1"
        UserControlRichbox1.Selected = False
        UserControlRichbox1.Size = New Size(22, 23)
        UserControlRichbox1.TabIndex = 155
        ' 
        ' UserControlRichbox4
        ' 
        UserControlRichbox4.HighlightInBlue = False
        UserControlRichbox4.HighlightInCyan = False
        UserControlRichbox4.HighlightInGreen = False
        UserControlRichbox4.HighlightInRed = False
        UserControlRichbox4.Location = New Point(3, 32)
        UserControlRichbox4.Name = "UserControlRichbox4"
        UserControlRichbox4.Selected = False
        UserControlRichbox4.Size = New Size(22, 23)
        UserControlRichbox4.TabIndex = 156
        ' 
        ' UserControlRichbox7
        ' 
        UserControlRichbox7.HighlightInBlue = False
        UserControlRichbox7.HighlightInCyan = False
        UserControlRichbox7.HighlightInGreen = False
        UserControlRichbox7.HighlightInRed = False
        UserControlRichbox7.Location = New Point(3, 61)
        UserControlRichbox7.Name = "UserControlRichbox7"
        UserControlRichbox7.Selected = False
        UserControlRichbox7.Size = New Size(22, 23)
        UserControlRichbox7.TabIndex = 157
        ' 
        ' FlowColumnB2
        ' 
        FlowColumnB2.BackColor = SystemColors.ActiveCaption
        FlowColumnB2.BorderStyle = BorderStyle.FixedSingle
        FlowColumnB2.Controls.Add(UserControlRichbox2)
        FlowColumnB2.Controls.Add(UserControlRichbox5)
        FlowColumnB2.Controls.Add(UserControlRichbox8)
        FlowColumnB2.Location = New Point(104, 27)
        FlowColumnB2.Name = "FlowColumnB2"
        FlowColumnB2.Size = New Size(29, 453)
        FlowColumnB2.TabIndex = 151
        ' 
        ' UserControlRichbox2
        ' 
        UserControlRichbox2.HighlightInBlue = False
        UserControlRichbox2.HighlightInCyan = False
        UserControlRichbox2.HighlightInGreen = False
        UserControlRichbox2.HighlightInRed = False
        UserControlRichbox2.Location = New Point(3, 3)
        UserControlRichbox2.Name = "UserControlRichbox2"
        UserControlRichbox2.Selected = False
        UserControlRichbox2.Size = New Size(22, 23)
        UserControlRichbox2.TabIndex = 156
        ' 
        ' UserControlRichbox5
        ' 
        UserControlRichbox5.HighlightInBlue = False
        UserControlRichbox5.HighlightInCyan = False
        UserControlRichbox5.HighlightInGreen = False
        UserControlRichbox5.HighlightInRed = False
        UserControlRichbox5.Location = New Point(3, 32)
        UserControlRichbox5.Name = "UserControlRichbox5"
        UserControlRichbox5.Selected = False
        UserControlRichbox5.Size = New Size(22, 23)
        UserControlRichbox5.TabIndex = 157
        ' 
        ' UserControlRichbox8
        ' 
        UserControlRichbox8.HighlightInBlue = False
        UserControlRichbox8.HighlightInCyan = False
        UserControlRichbox8.HighlightInGreen = False
        UserControlRichbox8.HighlightInRed = False
        UserControlRichbox8.Location = New Point(3, 61)
        UserControlRichbox8.Name = "UserControlRichbox8"
        UserControlRichbox8.Selected = False
        UserControlRichbox8.Size = New Size(22, 23)
        UserControlRichbox8.TabIndex = 158
        ' 
        ' FlowColumnB3
        ' 
        FlowColumnB3.BackColor = SystemColors.ActiveCaption
        FlowColumnB3.BorderStyle = BorderStyle.FixedSingle
        FlowColumnB3.Controls.Add(UserControlRichbox3)
        FlowColumnB3.Controls.Add(UserControlRichbox6)
        FlowColumnB3.Controls.Add(UserControlRichbox9)
        FlowColumnB3.Location = New Point(139, 27)
        FlowColumnB3.Name = "FlowColumnB3"
        FlowColumnB3.Size = New Size(29, 453)
        FlowColumnB3.TabIndex = 151
        ' 
        ' UserControlRichbox3
        ' 
        UserControlRichbox3.HighlightInBlue = False
        UserControlRichbox3.HighlightInCyan = False
        UserControlRichbox3.HighlightInGreen = False
        UserControlRichbox3.HighlightInRed = False
        UserControlRichbox3.Location = New Point(3, 3)
        UserControlRichbox3.Name = "UserControlRichbox3"
        UserControlRichbox3.Selected = False
        UserControlRichbox3.Size = New Size(22, 23)
        UserControlRichbox3.TabIndex = 156
        ' 
        ' UserControlRichbox6
        ' 
        UserControlRichbox6.HighlightInBlue = False
        UserControlRichbox6.HighlightInCyan = False
        UserControlRichbox6.HighlightInGreen = False
        UserControlRichbox6.HighlightInRed = False
        UserControlRichbox6.Location = New Point(3, 32)
        UserControlRichbox6.Name = "UserControlRichbox6"
        UserControlRichbox6.Selected = False
        UserControlRichbox6.Size = New Size(22, 23)
        UserControlRichbox6.TabIndex = 157
        ' 
        ' UserControlRichbox9
        ' 
        UserControlRichbox9.HighlightInBlue = False
        UserControlRichbox9.HighlightInCyan = False
        UserControlRichbox9.HighlightInGreen = False
        UserControlRichbox9.HighlightInRed = False
        UserControlRichbox9.Location = New Point(3, 61)
        UserControlRichbox9.Name = "UserControlRichbox9"
        UserControlRichbox9.Selected = False
        UserControlRichbox9.Size = New Size(22, 23)
        UserControlRichbox9.TabIndex = 158
        ' 
        ' FlowRowNumbersOnly
        ' 
        FlowRowNumbersOnly.BackColor = SystemColors.ButtonFace
        FlowRowNumbersOnly.BorderStyle = BorderStyle.FixedSingle
        FlowRowNumbersOnly.Controls.Add(TextBox13)
        FlowRowNumbersOnly.Controls.Add(TextBox14)
        FlowRowNumbersOnly.Controls.Add(TextBox15)
        FlowRowNumbersOnly.Location = New Point(-3, 29)
        FlowRowNumbersOnly.Name = "FlowRowNumbersOnly"
        FlowRowNumbersOnly.Size = New Size(29, 322)
        FlowRowNumbersOnly.TabIndex = 152
        ' 
        ' TextBox13
        ' 
        TextBox13.Location = New Point(3, 3)
        TextBox13.Name = "TextBox13"
        TextBox13.ReadOnly = True
        TextBox13.Size = New Size(22, 23)
        TextBox13.TabIndex = 0
        TextBox13.Text = "01"
        ' 
        ' TextBox14
        ' 
        TextBox14.Location = New Point(3, 32)
        TextBox14.Name = "TextBox14"
        TextBox14.ReadOnly = True
        TextBox14.Size = New Size(22, 23)
        TextBox14.TabIndex = 1
        TextBox14.Text = "02"
        ' 
        ' TextBox15
        ' 
        TextBox15.Location = New Point(3, 61)
        TextBox15.Name = "TextBox15"
        TextBox15.ReadOnly = True
        TextBox15.Size = New Size(22, 23)
        TextBox15.TabIndex = 2
        TextBox15.Text = "03"
        ' 
        ' richtextItemsDisplay
        ' 
        richtextItemsDisplay.BorderStyle = BorderStyle.FixedSingle
        richtextItemsDisplay.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        richtextItemsDisplay.Location = New Point(32, 27)
        richtextItemsDisplay.Name = "richtextItemsDisplay"
        richtextItemsDisplay.ScrollBars = RichTextBoxScrollBars.None
        richtextItemsDisplay.Size = New Size(31, 457)
        richtextItemsDisplay.TabIndex = 153
        richtextItemsDisplay.Tag = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        richtextItemsDisplay.Text = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        ' 
        ' DllUserControlRichbox1
        ' 
        DllUserControlRichbox1.HighlightInBlue = False
        DllUserControlRichbox1.HighlightInCyan = False
        DllUserControlRichbox1.HighlightInGreen = False
        DllUserControlRichbox1.HighlightInRed = False
        DllUserControlRichbox1.Location = New Point(1008, 27)
        DllUserControlRichbox1.Name = "DllUserControlRichbox1"
        DllUserControlRichbox1.Selected = False
        DllUserControlRichbox1.Size = New Size(22, 23)
        DllUserControlRichbox1.TabIndex = 156
        DllUserControlRichbox1.Visible = False
        ' 
        ' checkOperateUponListA
        ' 
        checkOperateUponListA.AutoSize = True
        checkOperateUponListA.Checked = True
        checkOperateUponListA.CheckState = CheckState.Checked
        checkOperateUponListA.Font = New Font("Segoe UI", 14F)
        checkOperateUponListA.Location = New Point(230, 48)
        checkOperateUponListA.Name = "checkOperateUponListA"
        checkOperateUponListA.Size = New Size(436, 29)
        checkOperateUponListA.TabIndex = 157
        checkOperateUponListA.Text = "Operate / Execute to List A (as well as B1, B2, B3)"
        checkOperateUponListA.UseVisualStyleBackColor = True
        ' 
        ' buttonUndoAnyOperation
        ' 
        buttonUndoAnyOperation.Enabled = False
        buttonUndoAnyOperation.Location = New Point(934, 150)
        buttonUndoAnyOperation.Name = "buttonUndoAnyOperation"
        buttonUndoAnyOperation.Size = New Size(214, 28)
        buttonUndoAnyOperation.TabIndex = 158
        buttonUndoAnyOperation.Text = "<<< Undo Any Operation"
        buttonUndoAnyOperation.UseVisualStyleBackColor = True
        ' 
        ' buttonMoveColumnB
        ' 
        buttonMoveColumnB.BackColor = Color.Cyan
        buttonMoveColumnB.Location = New Point(662, 306)
        buttonMoveColumnB.Name = "buttonMoveColumnB"
        buttonMoveColumnB.Size = New Size(293, 39)
        buttonMoveColumnB.TabIndex = 159
        buttonMoveColumnB.Text = "NEW!!  Move first B column to the far right."
        buttonMoveColumnB.UseVisualStyleBackColor = False
        ' 
        ' FormDemo1DVertical
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1227, 504)
        Controls.Add(buttonMoveColumnB)
        Controls.Add(buttonUndoAnyOperation)
        Controls.Add(checkOperateUponListA)
        Controls.Add(DllUserControlRichbox1)
        Controls.Add(richtextItemsDisplay)
        Controls.Add(FlowRowNumbersOnly)
        Controls.Add(FlowColumnB2)
        Controls.Add(FlowColumnB1)
        Controls.Add(FlowColumnB3)
        Controls.Add(LabelHeader1)
        Controls.Add(LabelA_B1_B2_B3)
        Controls.Add(ButtonSortBackward)
        Controls.Add(LinkRefreshFirstItem)
        Controls.Add(LinkApplicationDoevents)
        Controls.Add(LinkRefreshList)
        Controls.Add(ButtonSortForward)
        Controls.Add(GroupMoveByAnchor)
        Controls.Add(GroupMoveByShifting)
        Controls.Add(LinkClearRecordedOps)
        Controls.Add(labelNumOperations)
        Controls.Add(buttonUndoVertical)
        Controls.Add(buttonRedoVertical)
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
        Text = "  "
        GroupMoveByAnchor.ResumeLayout(False)
        CType(numMoveAnchorBenchmark, ComponentModel.ISupportInitialize).EndInit()
        GroupMoveByShifting.ResumeLayout(False)
        CType(numericShiftRight, ComponentModel.ISupportInitialize).EndInit()
        CType(numericShiftLeft, ComponentModel.ISupportInitialize).EndInit()
        CType(numInsertHowMany, ComponentModel.ISupportInitialize).EndInit()
        CType(numDeleteHowMany, ComponentModel.ISupportInitialize).EndInit()
        CType(numDeleteRangeBenchmarkStart, ComponentModel.ISupportInitialize).EndInit()
        CType(numInsertAnchorBenchmark, ComponentModel.ISupportInitialize).EndInit()
        FlowColumnB1.ResumeLayout(False)
        FlowColumnB2.ResumeLayout(False)
        FlowColumnB3.ResumeLayout(False)
        FlowRowNumbersOnly.ResumeLayout(False)
        FlowRowNumbersOnly.PerformLayout()
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
    Friend WithEvents buttonUndoVertical As Button
    Friend WithEvents buttonRedoVertical As Button
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
    Friend WithEvents LabelA_B1_B2_B3 As Label
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents FlowColumnB1 As FlowLayoutPanel
    Friend WithEvents FlowColumnB2 As FlowLayoutPanel
    Friend WithEvents FlowColumnB3 As FlowLayoutPanel
    Friend WithEvents FlowRowNumbersOnly As FlowLayoutPanel
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents UserControlRichbox1 As DLLUserControlRichbox
    Friend WithEvents UserControlRichbox2 As DLLUserControlRichbox
    Friend WithEvents UserControlRichbox3 As DLLUserControlRichbox
    Friend WithEvents UserControlRichbox4 As DLLUserControlRichbox
    Friend WithEvents UserControlRichbox7 As DLLUserControlRichbox
    Friend WithEvents UserControlRichbox5 As DLLUserControlRichbox
    Friend WithEvents UserControlRichbox8 As DLLUserControlRichbox
    Friend WithEvents UserControlRichbox6 As DLLUserControlRichbox
    Friend WithEvents UserControlRichbox9 As DLLUserControlRichbox
    Friend WithEvents richtextItemsDisplay As RichTextBox
    Friend WithEvents DllUserControlRichbox1 As DLLUserControlRichbox
    Friend WithEvents checkOperateUponListA As CheckBox
    Friend WithEvents buttonUndoAnyOperation As Button
    Friend WithEvents buttonMoveColumnB As Button
End Class
