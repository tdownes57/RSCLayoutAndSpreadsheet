<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTestTwoLists2x2
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
        Label2 = New Label()
        labelAnchorLinkLabels = New Label()
        linkToPenultimate = New LinkLabel()
        linkToEndpoint = New LinkLabel()
        linkEndpointHeading = New LinkLabel()
        linkSingleItemOnly = New LinkLabel()
        userControlOperationBoth = New UserControlOperation()
        labelNumOperations = New Label()
        buttonUndo = New Button()
        buttonReDo = New Button()
        Label3 = New Label()
        labelItemsDisplay1 = New Label()
        labelBenchmark = New Label()
        Label1 = New Label()
        LabelHeader1 = New Label()
        labelItemsDisplay2 = New Label()
        LabelHdrHorizontalCols = New Label()
        LabelHdrVerticalRows = New Label()
        LabelHdrRowHeaders = New Label()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.Control
        Label2.BorderStyle = BorderStyle.FixedSingle
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(313, 7)
        Label2.Name = "Label2"
        Label2.Size = New Size(229, 23)
        Label2.TabIndex = 97
        Label2.Text = "TESTING TWO-LIST MANAGER "
        ' 
        ' labelAnchorLinkLabels
        ' 
        labelAnchorLinkLabels.BorderStyle = BorderStyle.FixedSingle
        labelAnchorLinkLabels.Location = New Point(729, 111)
        labelAnchorLinkLabels.Name = "labelAnchorLinkLabels"
        labelAnchorLinkLabels.Size = New Size(60, 24)
        labelAnchorLinkLabels.TabIndex = 96
        labelAnchorLinkLabels.Tag = "  01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16 "
        labelAnchorLinkLabels.Text = "  List of subclassed LinkLabel controls, representing linked items.  Newly-operated items will be designated as Visited."
        ' 
        ' linkToPenultimate
        ' 
        linkToPenultimate.AutoSize = True
        linkToPenultimate.Location = New Point(594, 33)
        linkToPenultimate.Name = "linkToPenultimate"
        linkToPenultimate.Size = New Size(19, 15)
        linkToPenultimate.TabIndex = 95
        linkToPenultimate.TabStop = True
        linkToPenultimate.Text = "29"
        ' 
        ' linkToEndpoint
        ' 
        linkToEndpoint.AutoSize = True
        linkToEndpoint.Location = New Point(619, 33)
        linkToEndpoint.Name = "linkToEndpoint"
        linkToEndpoint.Size = New Size(19, 15)
        linkToEndpoint.TabIndex = 94
        linkToEndpoint.TabStop = True
        linkToEndpoint.Tag = "Link to "
        linkToEndpoint.Text = "30"
        ' 
        ' linkEndpointHeading
        ' 
        linkEndpointHeading.AutoSize = True
        linkEndpointHeading.Location = New Point(462, 33)
        linkEndpointHeading.Name = "linkEndpointHeading"
        linkEndpointHeading.Size = New Size(126, 15)
        linkEndpointHeading.TabIndex = 93
        linkEndpointHeading.TabStop = True
        linkEndpointHeading.Text = "Use Final Endpoint......."
        ' 
        ' linkSingleItemOnly
        ' 
        linkSingleItemOnly.AutoSize = True
        linkSingleItemOnly.Location = New Point(729, 64)
        linkSingleItemOnly.Name = "linkSingleItemOnly"
        linkSingleItemOnly.Size = New Size(140, 15)
        linkSingleItemOnly.TabIndex = 92
        linkSingleItemOnly.TabStop = True
        linkSingleItemOnly.Text = "Toggle Single-Item Mode"
        ' 
        ' userControlOperationBoth
        ' 
        userControlOperationBoth.BackColor = Color.PaleGreen
        userControlOperationBoth.Location = New Point(113, 137)
        userControlOperationBoth.Name = "userControlOperationBoth"
        userControlOperationBoth.Size = New Size(649, 450)
        userControlOperationBoth.TabIndex = 91
        ' 
        ' labelNumOperations
        ' 
        labelNumOperations.AutoSize = True
        labelNumOperations.Location = New Point(678, 5)
        labelNumOperations.Name = "labelNumOperations"
        labelNumOperations.Size = New Size(99, 15)
        labelNumOperations.TabIndex = 90
        labelNumOperations.Tag = "Number of ops: {0}"
        labelNumOperations.Text = "Number of ops: 0"
        ' 
        ' buttonUndo
        ' 
        buttonUndo.Enabled = False
        buttonUndo.Location = New Point(663, 21)
        buttonUndo.Name = "buttonUndo"
        buttonUndo.Size = New Size(114, 27)
        buttonUndo.TabIndex = 89
        buttonUndo.Text = "<<< Undo"
        buttonUndo.UseVisualStyleBackColor = True
        ' 
        ' buttonReDo
        ' 
        buttonReDo.Enabled = False
        buttonReDo.Location = New Point(783, 21)
        buttonReDo.Name = "buttonReDo"
        buttonReDo.Size = New Size(86, 27)
        buttonReDo.TabIndex = 88
        buttonReDo.Text = "Re-do >>>"
        buttonReDo.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(38, 48)
        Label3.Name = "Label3"
        Label3.Size = New Size(178, 15)
        Label3.TabIndex = 87
        Label3.Text = "List of current column positions:"
        ' 
        ' labelItemsDisplay1
        ' 
        labelItemsDisplay1.BackColor = Color.PaleGreen
        labelItemsDisplay1.BorderStyle = BorderStyle.FixedSingle
        labelItemsDisplay1.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        labelItemsDisplay1.Location = New Point(113, 87)
        labelItemsDisplay1.Name = "labelItemsDisplay1"
        labelItemsDisplay1.Size = New Size(595, 24)
        labelItemsDisplay1.TabIndex = 86
        labelItemsDisplay1.Tag = "  01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16 "
        labelItemsDisplay1.Text = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        ' 
        ' labelBenchmark
        ' 
        labelBenchmark.BorderStyle = BorderStyle.FixedSingle
        labelBenchmark.Location = New Point(58, 63)
        labelBenchmark.Name = "labelBenchmark"
        labelBenchmark.Size = New Size(598, 24)
        labelBenchmark.TabIndex = 85
        labelBenchmark.Tag = "         01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30 "
        labelBenchmark.Text = "         01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30 "
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(15, 33)
        Label1.Name = "Label1"
        Label1.Size = New Size(226, 15)
        Label1.TabIndex = 84
        Label1.Text = "List of column positions, as a benchmark:"
        ' 
        ' LabelHeader1
        ' 
        LabelHeader1.AutoSize = True
        LabelHeader1.Font = New Font("Segoe UI", 12F)
        LabelHeader1.Location = New Point(12, 7)
        LabelHeader1.Name = "LabelHeader1"
        LabelHeader1.Size = New Size(456, 21)
        LabelHeader1.TabIndex = 83
        LabelHeader1.Text = "Testing RSC Doubly-Linked List operations--TESTING TWO LISTS"
        ' 
        ' labelItemsDisplay2
        ' 
        labelItemsDisplay2.BackColor = Color.Plum
        labelItemsDisplay2.BorderStyle = BorderStyle.FixedSingle
        labelItemsDisplay2.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        labelItemsDisplay2.Location = New Point(113, 111)
        labelItemsDisplay2.Name = "labelItemsDisplay2"
        labelItemsDisplay2.Size = New Size(595, 24)
        labelItemsDisplay2.TabIndex = 98
        labelItemsDisplay2.Tag = "  01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16 "
        labelItemsDisplay2.Text = " 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30"
        ' 
        ' LabelHdrHorizontalCols
        ' 
        LabelHdrHorizontalCols.BackColor = Color.PaleGreen
        LabelHdrHorizontalCols.BorderStyle = BorderStyle.FixedSingle
        LabelHdrHorizontalCols.Location = New Point(3, 87)
        LabelHdrHorizontalCols.Name = "LabelHdrHorizontalCols"
        LabelHdrHorizontalCols.Size = New Size(104, 24)
        LabelHdrHorizontalCols.TabIndex = 99
        LabelHdrHorizontalCols.Tag = " Horizontal"
        LabelHdrHorizontalCols.Text = " Horizontal (cols)"
        ' 
        ' LabelHdrVerticalRows
        ' 
        LabelHdrVerticalRows.BackColor = Color.Plum
        LabelHdrVerticalRows.BorderStyle = BorderStyle.FixedSingle
        LabelHdrVerticalRows.Location = New Point(3, 111)
        LabelHdrVerticalRows.Name = "LabelHdrVerticalRows"
        LabelHdrVerticalRows.Size = New Size(104, 24)
        LabelHdrVerticalRows.TabIndex = 100
        LabelHdrVerticalRows.Tag = "Vertical"
        LabelHdrVerticalRows.Text = "Vertical (rows)"
        ' 
        ' LabelHdrRowHeaders
        ' 
        LabelHdrRowHeaders.BackColor = Color.Plum
        LabelHdrRowHeaders.BorderStyle = BorderStyle.FixedSingle
        LabelHdrRowHeaders.Location = New Point(3, 137)
        LabelHdrRowHeaders.Name = "LabelHdrRowHeaders"
        LabelHdrRowHeaders.Size = New Size(104, 419)
        LabelHdrRowHeaders.TabIndex = 101
        LabelHdrRowHeaders.Tag = "Vertical"
        ' 
        ' FormTestTwoLists2x2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(890, 599)
        Controls.Add(LabelHdrRowHeaders)
        Controls.Add(LabelHdrVerticalRows)
        Controls.Add(LabelHdrHorizontalCols)
        Controls.Add(labelItemsDisplay2)
        Controls.Add(Label2)
        Controls.Add(labelAnchorLinkLabels)
        Controls.Add(linkToPenultimate)
        Controls.Add(linkToEndpoint)
        Controls.Add(linkEndpointHeading)
        Controls.Add(linkSingleItemOnly)
        Controls.Add(userControlOperationBoth)
        Controls.Add(labelNumOperations)
        Controls.Add(buttonUndo)
        Controls.Add(buttonReDo)
        Controls.Add(Label3)
        Controls.Add(labelItemsDisplay1)
        Controls.Add(labelBenchmark)
        Controls.Add(Label1)
        Controls.Add(LabelHeader1)
        Name = "FormTestTwoLists2x2"
        Text = "FormTestTwoLists"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents labelAnchorLinkLabels As Label
    Friend WithEvents linkToPenultimate As LinkLabel
    Friend WithEvents linkToEndpoint As LinkLabel
    Friend WithEvents linkEndpointHeading As LinkLabel
    Friend WithEvents linkSingleItemOnly As LinkLabel
    Friend WithEvents userControlOperationBoth As UserControlOperation
    Friend WithEvents labelNumOperations As Label
    Friend WithEvents buttonUndo As Button
    Friend WithEvents buttonReDo As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents labelItemsDisplay1 As Label
    Friend WithEvents labelBenchmark As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents labelItemsDisplay2 As Label
    Friend WithEvents LabelHdrHorizontalCols As Label
    Friend WithEvents LabelHdrVerticalRows As Label
    Friend WithEvents LabelHdrRowHeaders As Label
End Class
