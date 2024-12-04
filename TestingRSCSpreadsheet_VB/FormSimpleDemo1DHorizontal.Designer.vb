<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSimpleDemo1DHorizontal
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
        LinkClearRecordedOps = New LinkLabel()
        labelNumOperations = New Label()
        buttonUndo = New Button()
        buttonReDo = New Button()
        Label5 = New Label()
        Label4 = New Label()
        textboxMoveRange = New TextBox()
        listMoveAfterOrBefore = New ListBox()
        buttonMoveItems = New Button()
        Label7 = New Label()
        Label11 = New Label()
        numMoveAnchorBenchmark = New NumericUpDown()
        richtextItemsDisplayH = New RichTextBox()
        labelItemsDisplay = New Label()
        richtextBenchmark = New RichTextBox()
        buttonRedoOp = New Button()
        buttonUndoLastStep = New Button()
        labelBenchmark = New Label()
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
        Label3 = New Label()
        Label1 = New Label()
        LabelHeader1 = New Label()
        buttonInsertMultiple = New Button()
        LabelInsertHeader = New Label()
        LabelInsertAnchorHeader = New Label()
        numInsertAnchorBenchmark = New NumericUpDown()
        LabelHdrHoriz = New Label()
        LabelHdrVerti = New Label()
        richtextItemsDisplayV = New RichTextBox()
        LabelHeaderHorizontalOnly = New Label()
        Label12 = New Label()
        CType(numMoveAnchorBenchmark, ComponentModel.ISupportInitialize).BeginInit()
        CType(numInsertHowMany, ComponentModel.ISupportInitialize).BeginInit()
        CType(numDeleteHowMany, ComponentModel.ISupportInitialize).BeginInit()
        CType(numDeleteRangeBenchmarkStart, ComponentModel.ISupportInitialize).BeginInit()
        CType(numInsertAnchorBenchmark, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LinkClearRecordedOps
        ' 
        LinkClearRecordedOps.AutoSize = True
        LinkClearRecordedOps.Location = New Point(843, 185)
        LinkClearRecordedOps.Name = "LinkClearRecordedOps"
        LinkClearRecordedOps.Size = New Size(143, 15)
        LinkClearRecordedOps.TabIndex = 136
        LinkClearRecordedOps.TabStop = True
        LinkClearRecordedOps.Text = "Clear recorded operations"
        ' 
        ' labelNumOperations
        ' 
        labelNumOperations.BorderStyle = BorderStyle.FixedSingle
        labelNumOperations.Location = New Point(777, 233)
        labelNumOperations.Name = "labelNumOperations"
        labelNumOperations.Size = New Size(182, 45)
        labelNumOperations.TabIndex = 135
        labelNumOperations.Tag = "Number of ops: {0}"
        labelNumOperations.Text = "Number of ops recorded: 0"
        ' 
        ' buttonUndo
        ' 
        buttonUndo.Enabled = False
        buttonUndo.Location = New Point(777, 202)
        buttonUndo.Name = "buttonUndo"
        buttonUndo.Size = New Size(114, 27)
        buttonUndo.TabIndex = 134
        buttonUndo.Text = "<<< Undo"
        buttonUndo.UseVisualStyleBackColor = True
        ' 
        ' buttonReDo
        ' 
        buttonReDo.Enabled = False
        buttonReDo.Location = New Point(897, 203)
        buttonReDo.Name = "buttonReDo"
        buttonReDo.Size = New Size(86, 27)
        buttonReDo.TabIndex = 133
        buttonReDo.Text = "Re-do >>>"
        buttonReDo.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(260, 532)
        Label5.Name = "Label5"
        Label5.Size = New Size(163, 15)
        Label5.TabIndex = 132
        Label5.Tag = "Number of items in range: {0)"
        Label5.Text = "Number of items in range: {0)"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 509)
        Label4.Name = "Label4"
        Label4.Size = New Size(245, 15)
        Label4.TabIndex = 131
        Label4.Text = "Range to move (Click the bottom row items.)"
        ' 
        ' textboxMoveRange
        ' 
        textboxMoveRange.BackColor = SystemColors.InactiveCaption
        textboxMoveRange.BorderStyle = BorderStyle.None
        textboxMoveRange.Font = New Font("Segoe UI", 12F)
        textboxMoveRange.Location = New Point(260, 506)
        textboxMoveRange.Name = "textboxMoveRange"
        textboxMoveRange.Size = New Size(284, 22)
        textboxMoveRange.TabIndex = 130
        textboxMoveRange.Tag = "00"
        textboxMoveRange.Text = "++"
        ' 
        ' listMoveAfterOrBefore
        ' 
        listMoveAfterOrBefore.FormattingEnabled = True
        listMoveAfterOrBefore.ItemHeight = 15
        listMoveAfterOrBefore.Items.AddRange(New Object() {"Insert After Anchor", """      "" Before Anchor"})
        listMoveAfterOrBefore.Location = New Point(415, 458)
        listMoveAfterOrBefore.Name = "listMoveAfterOrBefore"
        listMoveAfterOrBefore.Size = New Size(115, 34)
        listMoveAfterOrBefore.TabIndex = 129
        ' 
        ' buttonMoveItems
        ' 
        buttonMoveItems.BackColor = Color.Cyan
        buttonMoveItems.Location = New Point(560, 490)
        buttonMoveItems.Name = "buttonMoveItems"
        buttonMoveItems.Size = New Size(166, 39)
        buttonMoveItems.TabIndex = 128
        buttonMoveItems.Text = "Move Range of Items"
        buttonMoveItems.UseVisualStyleBackColor = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label7.Location = New Point(12, 424)
        Label7.Name = "Label7"
        Label7.Size = New Size(99, 21)
        Label7.TabIndex = 127
        Label7.Text = "Move Items"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(12, 460)
        Label11.Name = "Label11"
        Label11.Size = New Size(319, 15)
        Label11.TabIndex = 126
        Label11.Text = "What benchmark position to anchor (attach moved items)?"
        ' 
        ' numMoveAnchorBenchmark
        ' 
        numMoveAnchorBenchmark.Font = New Font("Segoe UI", 12F)
        numMoveAnchorBenchmark.Location = New Point(353, 458)
        numMoveAnchorBenchmark.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numMoveAnchorBenchmark.Name = "numMoveAnchorBenchmark"
        numMoveAnchorBenchmark.Size = New Size(56, 29)
        numMoveAnchorBenchmark.TabIndex = 125
        numMoveAnchorBenchmark.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' richtextItemsDisplayH
        ' 
        richtextItemsDisplayH.BorderStyle = BorderStyle.FixedSingle
        richtextItemsDisplayH.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        richtextItemsDisplayH.Location = New Point(68, 125)
        richtextItemsDisplayH.Name = "richtextItemsDisplayH"
        richtextItemsDisplayH.Size = New Size(860, 23)
        richtextItemsDisplayH.TabIndex = 124
        richtextItemsDisplayH.Tag = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        richtextItemsDisplayH.Text = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        ' 
        ' labelItemsDisplay
        ' 
        labelItemsDisplay.BorderStyle = BorderStyle.FixedSingle
        labelItemsDisplay.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        labelItemsDisplay.Location = New Point(353, 42)
        labelItemsDisplay.Name = "labelItemsDisplay"
        labelItemsDisplay.Size = New Size(657, 24)
        labelItemsDisplay.TabIndex = 120
        labelItemsDisplay.Tag = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        labelItemsDisplay.Text = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        labelItemsDisplay.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' richtextBenchmark
        ' 
        richtextBenchmark.BorderStyle = BorderStyle.None
        richtextBenchmark.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        richtextBenchmark.Location = New Point(68, 107)
        richtextBenchmark.Name = "richtextBenchmark"
        richtextBenchmark.Size = New Size(860, 23)
        richtextBenchmark.TabIndex = 123
        richtextBenchmark.Tag = "01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        richtextBenchmark.Text = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        ' 
        ' buttonRedoOp
        ' 
        buttonRedoOp.Enabled = False
        buttonRedoOp.Location = New Point(817, 518)
        buttonRedoOp.Name = "buttonRedoOp"
        buttonRedoOp.Size = New Size(166, 39)
        buttonRedoOp.TabIndex = 122
        buttonRedoOp.Text = "Redo (if applicable)"
        buttonRedoOp.UseVisualStyleBackColor = True
        ' 
        ' buttonUndoLastStep
        ' 
        buttonUndoLastStep.Enabled = False
        buttonUndoLastStep.Location = New Point(732, 473)
        buttonUndoLastStep.Name = "buttonUndoLastStep"
        buttonUndoLastStep.Size = New Size(166, 39)
        buttonUndoLastStep.TabIndex = 121
        buttonUndoLastStep.Text = "Undo Last Step"
        buttonUndoLastStep.UseVisualStyleBackColor = True
        ' 
        ' labelBenchmark
        ' 
        labelBenchmark.BorderStyle = BorderStyle.FixedSingle
        labelBenchmark.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        labelBenchmark.Location = New Point(353, 18)
        labelBenchmark.Name = "labelBenchmark"
        labelBenchmark.Size = New Size(648, 24)
        labelBenchmark.TabIndex = 119
        labelBenchmark.Tag = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        labelBenchmark.Text = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        labelBenchmark.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' buttonInsertSingle
        ' 
        buttonInsertSingle.Location = New Point(498, 267)
        buttonInsertSingle.Name = "buttonInsertSingle"
        buttonInsertSingle.Size = New Size(166, 39)
        buttonInsertSingle.TabIndex = 118
        buttonInsertSingle.Text = "Insert New Item (Single)"
        buttonInsertSingle.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(15, 280)
        Label6.Name = "Label6"
        Label6.Size = New Size(324, 15)
        Label6.TabIndex = 117
        Label6.Text = "List of two-character values, separated by spaces:  (optional)"
        ' 
        ' textInsertListOfValuesCSV
        ' 
        textInsertListOfValuesCSV.BorderStyle = BorderStyle.FixedSingle
        textInsertListOfValuesCSV.Location = New Point(353, 277)
        textInsertListOfValuesCSV.Name = "textInsertListOfValuesCSV"
        textInsertListOfValuesCSV.Size = New Size(139, 23)
        textInsertListOfValuesCSV.TabIndex = 116
        textInsertListOfValuesCSV.Tag = "00"
        textInsertListOfValuesCSV.Text = "++"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(15, 256)
        Label2.Name = "Label2"
        Label2.Size = New Size(164, 15)
        Label2.TabIndex = 115
        Label2.Text = "How many list items? (Count)"
        ' 
        ' numInsertHowMany
        ' 
        numInsertHowMany.Location = New Point(207, 254)
        numInsertHowMany.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        numInsertHowMany.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numInsertHowMany.Name = "numInsertHowMany"
        numInsertHowMany.Size = New Size(50, 23)
        numInsertHowMany.TabIndex = 114
        numInsertHowMany.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' listInsertAfterOrBefore
        ' 
        listInsertAfterOrBefore.FormattingEnabled = True
        listInsertAfterOrBefore.ItemHeight = 15
        listInsertAfterOrBefore.Items.AddRange(New Object() {"Insert After Anchor", """      "" Before Anchor"})
        listInsertAfterOrBefore.Location = New Point(377, 229)
        listInsertAfterOrBefore.Name = "listInsertAfterOrBefore"
        listInsertAfterOrBefore.Size = New Size(115, 34)
        listInsertAfterOrBefore.TabIndex = 104
        ' 
        ' buttonDelete
        ' 
        buttonDelete.Location = New Point(276, 344)
        buttonDelete.Name = "buttonDelete"
        buttonDelete.Size = New Size(133, 39)
        buttonDelete.TabIndex = 113
        buttonDelete.Text = "Delete Items"
        buttonDelete.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label8.Location = New Point(15, 325)
        Label8.Name = "Label8"
        Label8.Size = New Size(106, 21)
        Label8.TabIndex = 112
        Label8.Text = "Delete Items"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(15, 385)
        Label9.Name = "Label9"
        Label9.Size = New Size(164, 15)
        Label9.TabIndex = 111
        Label9.Text = "How many list items? (Count)"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(15, 356)
        Label10.Name = "Label10"
        Label10.Size = New Size(189, 15)
        Label10.TabIndex = 110
        Label10.Text = "What benchmark position to start?"
        ' 
        ' numDeleteHowMany
        ' 
        numDeleteHowMany.Location = New Point(207, 383)
        numDeleteHowMany.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        numDeleteHowMany.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numDeleteHowMany.Name = "numDeleteHowMany"
        numDeleteHowMany.Size = New Size(50, 23)
        numDeleteHowMany.TabIndex = 109
        numDeleteHowMany.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' numDeleteRangeBenchmarkStart
        ' 
        numDeleteRangeBenchmarkStart.Location = New Point(207, 354)
        numDeleteRangeBenchmarkStart.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numDeleteRangeBenchmarkStart.Name = "numDeleteRangeBenchmarkStart"
        numDeleteRangeBenchmarkStart.Size = New Size(50, 23)
        numDeleteRangeBenchmarkStart.TabIndex = 108
        numDeleteRangeBenchmarkStart.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(38, 80)
        Label3.Name = "Label3"
        Label3.Size = New Size(178, 15)
        Label3.TabIndex = 107
        Label3.Text = "List of current column positions:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(15, 65)
        Label1.Name = "Label1"
        Label1.Size = New Size(226, 15)
        Label1.TabIndex = 106
        Label1.Text = "List of column positions, as a benchmark:"
        ' 
        ' LabelHeader1
        ' 
        LabelHeader1.AutoSize = True
        LabelHeader1.Font = New Font("Segoe UI", 12F)
        LabelHeader1.Location = New Point(12, 39)
        LabelHeader1.Name = "LabelHeader1"
        LabelHeader1.Size = New Size(303, 21)
        LabelHeader1.TabIndex = 105
        LabelHeader1.Text = "Testing RSC Doubly-Linked List operations"
        ' 
        ' buttonInsertMultiple
        ' 
        buttonInsertMultiple.BackColor = Color.Cyan
        buttonInsertMultiple.Location = New Point(498, 222)
        buttonInsertMultiple.Name = "buttonInsertMultiple"
        buttonInsertMultiple.Size = New Size(166, 39)
        buttonInsertMultiple.TabIndex = 103
        buttonInsertMultiple.Text = "Insert New Items (Multiple)"
        buttonInsertMultiple.UseVisualStyleBackColor = False
        ' 
        ' LabelInsertHeader
        ' 
        LabelInsertHeader.AutoSize = True
        LabelInsertHeader.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        LabelInsertHeader.Location = New Point(15, 195)
        LabelInsertHeader.Name = "LabelInsertHeader"
        LabelInsertHeader.Size = New Size(138, 21)
        LabelInsertHeader.TabIndex = 102
        LabelInsertHeader.Text = "Insert New Items"
        ' 
        ' LabelInsertAnchorHeader
        ' 
        LabelInsertAnchorHeader.AutoSize = True
        LabelInsertAnchorHeader.Location = New Point(15, 231)
        LabelInsertAnchorHeader.Name = "LabelInsertAnchorHeader"
        LabelInsertAnchorHeader.Size = New Size(304, 15)
        LabelInsertAnchorHeader.TabIndex = 101
        LabelInsertAnchorHeader.Text = "What benchmark position to anchor (attach new items)?"
        ' 
        ' numInsertAnchorBenchmark
        ' 
        numInsertAnchorBenchmark.Location = New Point(321, 229)
        numInsertAnchorBenchmark.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numInsertAnchorBenchmark.Name = "numInsertAnchorBenchmark"
        numInsertAnchorBenchmark.Size = New Size(50, 23)
        numInsertAnchorBenchmark.TabIndex = 100
        numInsertAnchorBenchmark.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' LabelHdrHoriz
        ' 
        LabelHdrHoriz.AutoSize = True
        LabelHdrHoriz.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Underline)
        LabelHdrHoriz.Location = New Point(0, 127)
        LabelHdrHoriz.Name = "LabelHdrHoriz"
        LabelHdrHoriz.Size = New Size(65, 15)
        LabelHdrHoriz.TabIndex = 137
        LabelHdrHoriz.Text = "Horizontal"
        ' 
        ' LabelHdrVerti
        ' 
        LabelHdrVerti.AutoSize = True
        LabelHdrVerti.Location = New Point(68, 166)
        LabelHdrVerti.Name = "LabelHdrVerti"
        LabelHdrVerti.Size = New Size(529, 15)
        LabelHdrVerti.TabIndex = 138
        LabelHdrVerti.Text = "Vertical-- a non-vertically-oriented box will be coming soon!   However, it'll be for a different form!!"
        ' 
        ' richtextItemsDisplayV
        ' 
        richtextItemsDisplayV.BorderStyle = BorderStyle.FixedSingle
        richtextItemsDisplayV.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        richtextItemsDisplayV.Location = New Point(603, 158)
        richtextItemsDisplayV.Name = "richtextItemsDisplayV"
        richtextItemsDisplayV.Size = New Size(207, 23)
        richtextItemsDisplayV.TabIndex = 139
        richtextItemsDisplayV.Tag = "AA BB CC"
        richtextItemsDisplayV.Text = " AA BB CC--Not in use..."
        ' 
        ' LabelHeaderHorizontalOnly
        ' 
        LabelHeaderHorizontalOnly.AutoSize = True
        LabelHeaderHorizontalOnly.Font = New Font("Segoe UI", 16F)
        LabelHeaderHorizontalOnly.Location = New Point(12, 9)
        LabelHeaderHorizontalOnly.Name = "LabelHeaderHorizontalOnly"
        LabelHeaderHorizontalOnly.Size = New Size(335, 30)
        LabelHeaderHorizontalOnly.TabIndex = 140
        LabelHeaderHorizontalOnly.Text = "Horizontal Sub-Class Items Only!!"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Underline)
        Label12.Location = New Point(12, 151)
        Label12.Name = "Label12"
        Label12.Size = New Size(307, 15)
        Label12.TabIndex = 141
        Label12.Text = "Only subclassed Horizontal Items tested on this form!!"
        ' 
        ' FormSimpleDemo1DHorizontal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1023, 606)
        Controls.Add(Label12)
        Controls.Add(LabelHeaderHorizontalOnly)
        Controls.Add(richtextItemsDisplayV)
        Controls.Add(LabelHdrVerti)
        Controls.Add(LabelHdrHoriz)
        Controls.Add(LinkClearRecordedOps)
        Controls.Add(labelNumOperations)
        Controls.Add(buttonUndo)
        Controls.Add(buttonReDo)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(textboxMoveRange)
        Controls.Add(listMoveAfterOrBefore)
        Controls.Add(buttonMoveItems)
        Controls.Add(Label7)
        Controls.Add(Label11)
        Controls.Add(numMoveAnchorBenchmark)
        Controls.Add(richtextItemsDisplayH)
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
        Name = "FormSimpleDemo1DHorizontal"
        Text = "FormSimpleDemo1D--Horizontal Items Only... Sub-Classed from TwoCharacterItem"
        CType(numMoveAnchorBenchmark, ComponentModel.ISupportInitialize).EndInit()
        CType(numInsertHowMany, ComponentModel.ISupportInitialize).EndInit()
        CType(numDeleteHowMany, ComponentModel.ISupportInitialize).EndInit()
        CType(numDeleteRangeBenchmarkStart, ComponentModel.ISupportInitialize).EndInit()
        CType(numInsertAnchorBenchmark, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LinkClearRecordedOps As LinkLabel
    Friend WithEvents labelNumOperations As Label
    Friend WithEvents buttonUndo As Button
    Friend WithEvents buttonReDo As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents textboxMoveRange As TextBox
    Friend WithEvents listMoveAfterOrBefore As ListBox
    Friend WithEvents buttonMoveItems As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents numMoveAnchorBenchmark As NumericUpDown
    Friend WithEvents richtextItemsDisplayH As RichTextBox
    Friend WithEvents labelItemsDisplay As Label
    Friend WithEvents richtextBenchmark As RichTextBox
    Friend WithEvents buttonRedoOp As Button
    Friend WithEvents buttonUndoLastStep As Button
    Friend WithEvents labelBenchmark As Label
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
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents buttonInsertMultiple As Button
    Friend WithEvents LabelInsertHeader As Label
    Friend WithEvents LabelInsertAnchorHeader As Label
    Friend WithEvents numInsertAnchorBenchmark As NumericUpDown
    Friend WithEvents LabelHdrHoriz As Label
    Friend WithEvents LabelHdrVerti As Label
    Friend WithEvents richtextItemsDisplayV As RichTextBox
    Friend WithEvents LabelHeaderHorizontalOnly As Label
    Friend WithEvents Label12 As Label
End Class
