<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTestRSCViaDigits_Backup
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
        ButtonUndo = New Button()
        ButtonReDo = New Button()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        NumericUpDown3 = New NumericUpDown()
        NumericUpDown4 = New NumericUpDown()
        Label6 = New Label()
        textListOfValuesCSV = New TextBox()
        LabelInsertHeader = New Label()
        Label5 = New Label()
        Label4 = New Label()
        NumericUpDown2 = New NumericUpDown()
        NumericUpDown1 = New NumericUpDown()
        Label3 = New Label()
        Label2 = New Label()
        LabelBenchmark = New Label()
        Label1 = New Label()
        LabelHeader1 = New Label()
        CType(NumericUpDown3, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown4, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ButtonUndo
        ' 
        ButtonUndo.Location = New Point(419, 407)
        ButtonUndo.Name = "ButtonUndo"
        ButtonUndo.Size = New Size(147, 27)
        ButtonUndo.TabIndex = 39
        ButtonUndo.Text = "<<< Undo"
        ButtonUndo.UseVisualStyleBackColor = True
        ' 
        ' ButtonReDo
        ' 
        ButtonReDo.Location = New Point(555, 407)
        ButtonReDo.Name = "ButtonReDo"
        ButtonReDo.Size = New Size(147, 27)
        ButtonReDo.TabIndex = 38
        ButtonReDo.Text = "Re-do >>>"
        ButtonReDo.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label8.Location = New Point(18, 280)
        Label8.Name = "Label8"
        Label8.Size = New Size(106, 21)
        Label8.TabIndex = 37
        Label8.Text = "Delete Items"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(18, 340)
        Label9.Name = "Label9"
        Label9.Size = New Size(120, 15)
        Label9.TabIndex = 36
        Label9.Text = "How many list items?"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(18, 311)
        Label10.Name = "Label10"
        Label10.Size = New Size(189, 15)
        Label10.TabIndex = 35
        Label10.Text = "What benchmark position to start?"
        ' 
        ' NumericUpDown3
        ' 
        NumericUpDown3.Location = New Point(213, 338)
        NumericUpDown3.Name = "NumericUpDown3"
        NumericUpDown3.Size = New Size(80, 23)
        NumericUpDown3.TabIndex = 34
        ' 
        ' NumericUpDown4
        ' 
        NumericUpDown4.Location = New Point(213, 309)
        NumericUpDown4.Name = "NumericUpDown4"
        NumericUpDown4.Size = New Size(80, 23)
        NumericUpDown4.TabIndex = 33
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(18, 250)
        Label6.Name = "Label6"
        Label6.Size = New Size(335, 15)
        Label6.TabIndex = 32
        Label6.Text = "List of two-character values, separated by commas:  (optional)"
        ' 
        ' textListOfValuesCSV
        ' 
        textListOfValuesCSV.BorderStyle = BorderStyle.FixedSingle
        textListOfValuesCSV.Location = New Point(359, 247)
        textListOfValuesCSV.Name = "textListOfValuesCSV"
        textListOfValuesCSV.Size = New Size(267, 23)
        textListOfValuesCSV.TabIndex = 31
        textListOfValuesCSV.Tag = "00"
        textListOfValuesCSV.Text = "xx"
        ' 
        ' LabelInsertHeader
        ' 
        LabelInsertHeader.AutoSize = True
        LabelInsertHeader.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        LabelInsertHeader.Location = New Point(18, 160)
        LabelInsertHeader.Name = "LabelInsertHeader"
        LabelInsertHeader.Size = New Size(138, 21)
        LabelInsertHeader.TabIndex = 30
        LabelInsertHeader.Text = "Insert New Items"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(18, 220)
        Label5.Name = "Label5"
        Label5.Size = New Size(120, 15)
        Label5.TabIndex = 29
        Label5.Text = "How many list items?"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(18, 191)
        Label4.Name = "Label4"
        Label4.Size = New Size(189, 15)
        Label4.TabIndex = 28
        Label4.Text = "What benchmark position to start?"
        ' 
        ' NumericUpDown2
        ' 
        NumericUpDown2.Location = New Point(213, 218)
        NumericUpDown2.Name = "NumericUpDown2"
        NumericUpDown2.Size = New Size(80, 23)
        NumericUpDown2.TabIndex = 27
        ' 
        ' NumericUpDown1
        ' 
        NumericUpDown1.Location = New Point(213, 189)
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.Size = New Size(80, 23)
        NumericUpDown1.TabIndex = 26
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(41, 68)
        Label3.Name = "Label3"
        Label3.Size = New Size(178, 15)
        Label3.TabIndex = 25
        Label3.Text = "List of current column positions:"
        ' 
        ' Label2
        ' 
        Label2.BorderStyle = BorderStyle.FixedSingle
        Label2.Location = New Point(41, 112)
        Label2.Name = "Label2"
        Label2.Size = New Size(742, 24)
        Label2.TabIndex = 24
        Label2.Tag = "01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16 "
        Label2.Text = " 01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30"
        ' 
        ' LabelBenchmark
        ' 
        LabelBenchmark.BorderStyle = BorderStyle.FixedSingle
        LabelBenchmark.Location = New Point(18, 88)
        LabelBenchmark.Name = "LabelBenchmark"
        LabelBenchmark.Size = New Size(742, 24)
        LabelBenchmark.TabIndex = 23
        LabelBenchmark.Tag = "        01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30 "
        LabelBenchmark.Text = "        01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30 "
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(18, 53)
        Label1.Name = "Label1"
        Label1.Size = New Size(226, 15)
        Label1.TabIndex = 22
        Label1.Text = "List of column positions, as a benchmark:"
        ' 
        ' LabelHeader1
        ' 
        LabelHeader1.AutoSize = True
        LabelHeader1.Location = New Point(18, 16)
        LabelHeader1.Name = "LabelHeader1"
        LabelHeader1.Size = New Size(229, 15)
        LabelHeader1.TabIndex = 21
        LabelHeader1.Text = "Testing RSC Doubly-Linked List operations"
        ' 
        ' FrmTestRSCViaDigits_Backup
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(ButtonUndo)
        Controls.Add(ButtonReDo)
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
        Name = "FrmTestRSCViaDigits_Backup"
        Text = "FrmTestRSCViaDigits"
        CType(NumericUpDown3, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown4, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ButtonUndo As Button
    Friend WithEvents ButtonReDo As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents NumericUpDown3 As NumericUpDown
    Friend WithEvents NumericUpDown4 As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents textListOfValuesCSV As TextBox
    Friend WithEvents LabelInsertHeader As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LabelBenchmark As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelHeader1 As Label
End Class
