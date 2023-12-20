<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTestRSCViaDigits
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
        LabelHeader1 = New Label()
        Label1 = New Label()
        LabelBenchmark = New Label()
        Label2 = New Label()
        Label3 = New Label()
        NumericUpDown1 = New NumericUpDown()
        NumericUpDown2 = New NumericUpDown()
        Label4 = New Label()
        Label5 = New Label()
        LabelInsertHeader = New Label()
        textListOfValuesCSV = New TextBox()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        NumericUpDown3 = New NumericUpDown()
        NumericUpDown4 = New NumericUpDown()
        ButtonReDo = New Button()
        ButtonUndo = New Button()
        Label11 = New Label()
        Label12 = New Label()
        Label13 = New Label()
        NumericUpDown5 = New NumericUpDown()
        NumericUpDown6 = New NumericUpDown()
        Label14 = New Label()
        NumericUpDown7 = New NumericUpDown()
        Label15 = New Label()
        NumericUpDown8 = New NumericUpDown()
        ButtonInsert = New Button()
        ButtonDelete = New Button()
        ButtonMoveItems = New Button()
        LabelNumOperations = New Label()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown3, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown4, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown5, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown6, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown7, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown8, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LabelHeader1
        ' 
        LabelHeader1.AutoSize = True
        LabelHeader1.Location = New Point(12, 25)
        LabelHeader1.Name = "LabelHeader1"
        LabelHeader1.Size = New Size(229, 15)
        LabelHeader1.TabIndex = 0
        LabelHeader1.Text = "Testing RSC Doubly-Linked List operations"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 62)
        Label1.Name = "Label1"
        Label1.Size = New Size(226, 15)
        Label1.TabIndex = 1
        Label1.Text = "List of column positions, as a benchmark:"
        ' 
        ' LabelBenchmark
        ' 
        LabelBenchmark.BorderStyle = BorderStyle.FixedSingle
        LabelBenchmark.Location = New Point(12, 97)
        LabelBenchmark.Name = "LabelBenchmark"
        LabelBenchmark.Size = New Size(598, 24)
        LabelBenchmark.TabIndex = 2
        LabelBenchmark.Tag = "        01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30 "
        LabelBenchmark.Text = "        01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30 "
        ' 
        ' Label2
        ' 
        Label2.BorderStyle = BorderStyle.FixedSingle
        Label2.Location = New Point(35, 121)
        Label2.Name = "Label2"
        Label2.Size = New Size(595, 24)
        Label2.TabIndex = 3
        Label2.Tag = "01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16 "
        Label2.Text = " 01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(35, 77)
        Label3.Name = "Label3"
        Label3.Size = New Size(178, 15)
        Label3.TabIndex = 4
        Label3.Text = "List of current column positions:"
        ' 
        ' NumericUpDown1
        ' 
        NumericUpDown1.Location = New Point(321, 203)
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.Size = New Size(80, 23)
        NumericUpDown1.TabIndex = 5
        ' 
        ' NumericUpDown2
        ' 
        NumericUpDown2.Location = New Point(207, 227)
        NumericUpDown2.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        NumericUpDown2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        NumericUpDown2.Name = "NumericUpDown2"
        NumericUpDown2.Size = New Size(80, 23)
        NumericUpDown2.TabIndex = 6
        NumericUpDown2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 205)
        Label4.Name = "Label4"
        Label4.Size = New Size(303, 15)
        Label4.TabIndex = 7
        Label4.Text = "What benchmark position to anchor (new items below)?"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(12, 229)
        Label5.Name = "Label5"
        Label5.Size = New Size(120, 15)
        Label5.TabIndex = 8
        Label5.Text = "How many list items?"
        ' 
        ' LabelInsertHeader
        ' 
        LabelInsertHeader.AutoSize = True
        LabelInsertHeader.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        LabelInsertHeader.Location = New Point(12, 169)
        LabelInsertHeader.Name = "LabelInsertHeader"
        LabelInsertHeader.Size = New Size(138, 21)
        LabelInsertHeader.TabIndex = 9
        LabelInsertHeader.Text = "Insert New Items"
        ' 
        ' textListOfValuesCSV
        ' 
        textListOfValuesCSV.BorderStyle = BorderStyle.FixedSingle
        textListOfValuesCSV.Location = New Point(353, 256)
        textListOfValuesCSV.Name = "textListOfValuesCSV"
        textListOfValuesCSV.Size = New Size(267, 23)
        textListOfValuesCSV.TabIndex = 10
        textListOfValuesCSV.Tag = "00"
        textListOfValuesCSV.Text = "00 is default"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(12, 259)
        Label6.Name = "Label6"
        Label6.Size = New Size(335, 15)
        Label6.TabIndex = 11
        Label6.Text = "List of two-character values, separated by commas:  (optional)"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(12, 379)
        Label7.Name = "Label7"
        Label7.Size = New Size(0, 15)
        Label7.TabIndex = 18
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label8.Location = New Point(12, 289)
        Label8.Name = "Label8"
        Label8.Size = New Size(106, 21)
        Label8.TabIndex = 16
        Label8.Text = "Delete Items"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(12, 349)
        Label9.Name = "Label9"
        Label9.Size = New Size(120, 15)
        Label9.TabIndex = 15
        Label9.Text = "How many list items?"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(12, 320)
        Label10.Name = "Label10"
        Label10.Size = New Size(189, 15)
        Label10.TabIndex = 14
        Label10.Text = "What benchmark position to start?"
        ' 
        ' NumericUpDown3
        ' 
        NumericUpDown3.Location = New Point(207, 347)
        NumericUpDown3.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        NumericUpDown3.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        NumericUpDown3.Name = "NumericUpDown3"
        NumericUpDown3.Size = New Size(80, 23)
        NumericUpDown3.TabIndex = 13
        NumericUpDown3.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' NumericUpDown4
        ' 
        NumericUpDown4.Location = New Point(207, 318)
        NumericUpDown4.Name = "NumericUpDown4"
        NumericUpDown4.Size = New Size(80, 23)
        NumericUpDown4.TabIndex = 12
        ' 
        ' ButtonReDo
        ' 
        ButtonReDo.Location = New Point(463, 25)
        ButtonReDo.Name = "ButtonReDo"
        ButtonReDo.Size = New Size(147, 27)
        ButtonReDo.TabIndex = 19
        ButtonReDo.Text = "Re-do >>>"
        ButtonReDo.UseVisualStyleBackColor = True
        ' 
        ' ButtonUndo
        ' 
        ButtonUndo.Location = New Point(327, 25)
        ButtonUndo.Name = "ButtonUndo"
        ButtonUndo.Size = New Size(147, 27)
        ButtonUndo.TabIndex = 20
        ButtonUndo.Text = "<<< Undo"
        ButtonUndo.UseVisualStyleBackColor = True
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label11.Location = New Point(18, 379)
        Label11.Name = "Label11"
        Label11.Size = New Size(99, 21)
        Label11.TabIndex = 25
        Label11.Text = "Move Items"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(18, 439)
        Label12.Name = "Label12"
        Label12.Size = New Size(120, 15)
        Label12.TabIndex = 24
        Label12.Text = "How many list items?"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(18, 410)
        Label13.Name = "Label13"
        Label13.Size = New Size(300, 15)
        Label13.TabIndex = 23
        Label13.Text = "What benchmark position to start (include as leftmost)?"
        ' 
        ' NumericUpDown5
        ' 
        NumericUpDown5.Location = New Point(256, 437)
        NumericUpDown5.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        NumericUpDown5.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        NumericUpDown5.Name = "NumericUpDown5"
        NumericUpDown5.Size = New Size(80, 23)
        NumericUpDown5.TabIndex = 22
        NumericUpDown5.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' NumericUpDown6
        ' 
        NumericUpDown6.Location = New Point(324, 408)
        NumericUpDown6.Name = "NumericUpDown6"
        NumericUpDown6.Size = New Size(80, 23)
        NumericUpDown6.TabIndex = 21
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(18, 469)
        Label14.Name = "Label14"
        Label14.Size = New Size(439, 15)
        Label14.TabIndex = 27
        Label14.Text = "What benchmark position to anchor (paste moved items) below (right of anchor)?"
        ' 
        ' NumericUpDown7
        ' 
        NumericUpDown7.Location = New Point(463, 464)
        NumericUpDown7.Name = "NumericUpDown7"
        NumericUpDown7.Size = New Size(80, 23)
        NumericUpDown7.TabIndex = 26
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(18, 495)
        Label15.Name = "Label15"
        Label15.Size = New Size(431, 15)
        Label15.TabIndex = 29
        Label15.Text = "What benchmark position to anchor (paste moved items) above (left of anchor)?"
        ' 
        ' NumericUpDown8
        ' 
        NumericUpDown8.Location = New Point(463, 487)
        NumericUpDown8.Name = "NumericUpDown8"
        NumericUpDown8.Size = New Size(80, 23)
        NumericUpDown8.TabIndex = 28
        ' 
        ' ButtonInsert
        ' 
        ButtonInsert.Location = New Point(451, 205)
        ButtonInsert.Name = "ButtonInsert"
        ButtonInsert.Size = New Size(133, 39)
        ButtonInsert.TabIndex = 30
        ButtonInsert.Text = "Insert New Items"
        ButtonInsert.UseVisualStyleBackColor = True
        ' 
        ' ButtonDelete
        ' 
        ButtonDelete.Location = New Point(324, 331)
        ButtonDelete.Name = "ButtonDelete"
        ButtonDelete.Size = New Size(133, 39)
        ButtonDelete.TabIndex = 31
        ButtonDelete.Text = "Delete Items"
        ButtonDelete.UseVisualStyleBackColor = True
        ' 
        ' ButtonMoveItems
        ' 
        ButtonMoveItems.Location = New Point(410, 419)
        ButtonMoveItems.Name = "ButtonMoveItems"
        ButtonMoveItems.Size = New Size(133, 39)
        ButtonMoveItems.TabIndex = 32
        ButtonMoveItems.Text = "Move Items"
        ButtonMoveItems.UseVisualStyleBackColor = True
        ' 
        ' LabelNumOperations
        ' 
        LabelNumOperations.AutoSize = True
        LabelNumOperations.Location = New Point(342, 9)
        LabelNumOperations.Name = "LabelNumOperations"
        LabelNumOperations.Size = New Size(99, 15)
        LabelNumOperations.TabIndex = 33
        LabelNumOperations.Tag = "Number of ops: {0}"
        LabelNumOperations.Text = "Number of ops: 0"
        ' 
        ' FormTestRSCViaDigits
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(669, 530)
        Controls.Add(LabelNumOperations)
        Controls.Add(ButtonMoveItems)
        Controls.Add(ButtonDelete)
        Controls.Add(ButtonInsert)
        Controls.Add(Label15)
        Controls.Add(NumericUpDown8)
        Controls.Add(Label14)
        Controls.Add(NumericUpDown7)
        Controls.Add(Label11)
        Controls.Add(Label12)
        Controls.Add(Label13)
        Controls.Add(NumericUpDown5)
        Controls.Add(NumericUpDown6)
        Controls.Add(ButtonUndo)
        Controls.Add(ButtonReDo)
        Controls.Add(Label7)
        Controls.Add(Label8)
        Controls.Add(Label9)
        Controls.Add(Label10)
        Controls.Add(NumericUpDown3)
        Controls.Add(NumericUpDown4)
        Controls.Add(Label6)
        Controls.Add(textListOfValuesCSV)
        Controls.Add(LabelInsertHeader)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(NumericUpDown2)
        Controls.Add(NumericUpDown1)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(LabelBenchmark)
        Controls.Add(Label1)
        Controls.Add(LabelHeader1)
        Name = "FormTestRSCViaDigits"
        Text = "Testing RSC Column-Operations via Digits"
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown3, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown4, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown5, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown6, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown7, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown8, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelBenchmark As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LabelInsertHeader As Label
    Friend WithEvents textListOfValuesCSV As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents NumericUpDown3 As NumericUpDown
    Friend WithEvents NumericUpDown4 As NumericUpDown
    Friend WithEvents ButtonReDo As Button
    Friend WithEvents ButtonUndo As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents NumericUpDown5 As NumericUpDown
    Friend WithEvents NumericUpDown6 As NumericUpDown
    Friend WithEvents Label14 As Label
    Friend WithEvents NumericUpDown7 As NumericUpDown
    Friend WithEvents Label15 As Label
    Friend WithEvents NumericUpDown8 As NumericUpDown
    Friend WithEvents ButtonInsert As Button
    Friend WithEvents ButtonDelete As Button
    Friend WithEvents ButtonMoveItems As Button
    Friend WithEvents LabelNumOperations As Label

End Class
