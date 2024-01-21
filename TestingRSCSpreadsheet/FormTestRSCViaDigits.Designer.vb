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
        labelBenchmark = New Label()
        labelItemsDisplay = New Label()
        Label3 = New Label()
        Label7 = New Label()
        buttonReDo = New Button()
        buttonUndo = New Button()
        labelNumOperations = New Label()
        userControlOperation1 = New UserControlOperation()
        linkSingleItemOnly = New LinkLabel()
        linkEndpointHeading = New LinkLabel()
        linkToEndpoint = New LinkLabel()
        linkToPenultimate = New LinkLabel()
        labelAnchorLinkLabels = New Label()
        LinkClearRecordedOps = New LinkLabel()
        LabelNotTestingManager = New Label()
        SuspendLayout()
        ' 
        ' LabelHeader1
        ' 
        LabelHeader1.AutoSize = True
        LabelHeader1.Font = New Font("Segoe UI", 12F)
        LabelHeader1.Location = New Point(9, 9)
        LabelHeader1.Name = "LabelHeader1"
        LabelHeader1.Size = New Size(303, 21)
        LabelHeader1.TabIndex = 0
        LabelHeader1.Text = "Testing RSC Doubly-Linked List operations"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 35)
        Label1.Name = "Label1"
        Label1.Size = New Size(226, 15)
        Label1.TabIndex = 1
        Label1.Text = "List of column positions, as a benchmark:"
        ' 
        ' labelBenchmark
        ' 
        labelBenchmark.BorderStyle = BorderStyle.FixedSingle
        labelBenchmark.Location = New Point(35, 65)
        labelBenchmark.Name = "labelBenchmark"
        labelBenchmark.Size = New Size(598, 24)
        labelBenchmark.TabIndex = 2
        labelBenchmark.Tag = "         01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30 "
        labelBenchmark.Text = "         01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30 "
        ' 
        ' labelItemsDisplay
        ' 
        labelItemsDisplay.BorderStyle = BorderStyle.FixedSingle
        labelItemsDisplay.Location = New Point(58, 89)
        labelItemsDisplay.Name = "labelItemsDisplay"
        labelItemsDisplay.Size = New Size(595, 24)
        labelItemsDisplay.TabIndex = 3
        labelItemsDisplay.Tag = "  01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16 "
        labelItemsDisplay.Text = "  01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(35, 50)
        Label3.Name = "Label3"
        Label3.Size = New Size(178, 15)
        Label3.TabIndex = 4
        Label3.Text = "List of current column positions:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(12, 379)
        Label7.Name = "Label7"
        Label7.Size = New Size(0, 15)
        Label7.TabIndex = 18
        ' 
        ' buttonReDo
        ' 
        buttonReDo.Enabled = False
        buttonReDo.Location = New Point(789, 84)
        buttonReDo.Name = "buttonReDo"
        buttonReDo.Size = New Size(86, 27)
        buttonReDo.TabIndex = 19
        buttonReDo.Text = "Re-do >>>"
        buttonReDo.UseVisualStyleBackColor = True
        ' 
        ' buttonUndo
        ' 
        buttonUndo.Enabled = False
        buttonUndo.Location = New Point(669, 84)
        buttonUndo.Name = "buttonUndo"
        buttonUndo.Size = New Size(114, 27)
        buttonUndo.TabIndex = 20
        buttonUndo.Text = "<<< Undo"
        buttonUndo.UseVisualStyleBackColor = True
        ' 
        ' labelNumOperations
        ' 
        labelNumOperations.AutoSize = True
        labelNumOperations.Location = New Point(684, 68)
        labelNumOperations.Name = "labelNumOperations"
        labelNumOperations.Size = New Size(99, 15)
        labelNumOperations.TabIndex = 33
        labelNumOperations.Tag = "Number of ops: {0}"
        labelNumOperations.Text = "Number of ops: 0"
        ' 
        ' userControlOperation1
        ' 
        userControlOperation1.BackColor = SystemColors.ActiveCaption
        userControlOperation1.Location = New Point(18, 144)
        userControlOperation1.Name = "userControlOperation1"
        userControlOperation1.Size = New Size(649, 450)
        userControlOperation1.TabIndex = 34
        ' 
        ' linkSingleItemOnly
        ' 
        linkSingleItemOnly.AutoSize = True
        linkSingleItemOnly.Location = New Point(735, 127)
        linkSingleItemOnly.Name = "linkSingleItemOnly"
        linkSingleItemOnly.Size = New Size(140, 15)
        linkSingleItemOnly.TabIndex = 62
        linkSingleItemOnly.TabStop = True
        linkSingleItemOnly.Text = "Toggle Single-Item Mode"
        ' 
        ' linkEndpointHeading
        ' 
        linkEndpointHeading.AutoSize = True
        linkEndpointHeading.Location = New Point(459, 35)
        linkEndpointHeading.Name = "linkEndpointHeading"
        linkEndpointHeading.Size = New Size(126, 15)
        linkEndpointHeading.TabIndex = 63
        linkEndpointHeading.TabStop = True
        linkEndpointHeading.Text = "Use Final Endpoint......."
        ' 
        ' linkToEndpoint
        ' 
        linkToEndpoint.AutoSize = True
        linkToEndpoint.Location = New Point(616, 35)
        linkToEndpoint.Name = "linkToEndpoint"
        linkToEndpoint.Size = New Size(19, 15)
        linkToEndpoint.TabIndex = 64
        linkToEndpoint.TabStop = True
        linkToEndpoint.Tag = "Link to "
        linkToEndpoint.Text = "30"
        ' 
        ' linkToPenultimate
        ' 
        linkToPenultimate.AutoSize = True
        linkToPenultimate.Location = New Point(591, 35)
        linkToPenultimate.Name = "linkToPenultimate"
        linkToPenultimate.Size = New Size(19, 15)
        linkToPenultimate.TabIndex = 65
        linkToPenultimate.TabStop = True
        linkToPenultimate.Text = "29"
        ' 
        ' labelAnchorLinkLabels
        ' 
        labelAnchorLinkLabels.BorderStyle = BorderStyle.FixedSingle
        labelAnchorLinkLabels.Location = New Point(58, 117)
        labelAnchorLinkLabels.Name = "labelAnchorLinkLabels"
        labelAnchorLinkLabels.Size = New Size(632, 24)
        labelAnchorLinkLabels.TabIndex = 66
        labelAnchorLinkLabels.Tag = "  01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16 "
        labelAnchorLinkLabels.Text = "  List of subclassed LinkLabel controls, representing linked items.  Newly-operated items will be designated as Visited."
        ' 
        ' LinkClearRecordedOps
        ' 
        LinkClearRecordedOps.AutoSize = True
        LinkClearRecordedOps.Location = New Point(735, 50)
        LinkClearRecordedOps.Name = "LinkClearRecordedOps"
        LinkClearRecordedOps.Size = New Size(143, 15)
        LinkClearRecordedOps.TabIndex = 68
        LinkClearRecordedOps.TabStop = True
        LinkClearRecordedOps.Text = "Clear recorded operations"
        ' 
        ' LabelNotTestingManager
        ' 
        LabelNotTestingManager.AutoSize = True
        LabelNotTestingManager.BackColor = Color.Transparent
        LabelNotTestingManager.BorderStyle = BorderStyle.FixedSingle
        LabelNotTestingManager.Font = New Font("Segoe UI", 12F)
        LabelNotTestingManager.ForeColor = SystemColors.ControlDark
        LabelNotTestingManager.Location = New Point(335, 7)
        LabelNotTestingManager.Name = "LabelNotTestingManager"
        LabelNotTestingManager.Size = New Size(404, 23)
        LabelNotTestingManager.TabIndex = 69
        LabelNotTestingManager.Text = "////not//// TESTING THE OPERATIONS MANAGER CLASS"
        ' 
        ' FormTestRSCViaDigits
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(895, 632)
        Controls.Add(LabelNotTestingManager)
        Controls.Add(LinkClearRecordedOps)
        Controls.Add(labelAnchorLinkLabels)
        Controls.Add(linkToPenultimate)
        Controls.Add(linkToEndpoint)
        Controls.Add(linkEndpointHeading)
        Controls.Add(linkSingleItemOnly)
        Controls.Add(userControlOperation1)
        Controls.Add(labelNumOperations)
        Controls.Add(buttonUndo)
        Controls.Add(buttonReDo)
        Controls.Add(Label7)
        Controls.Add(Label3)
        Controls.Add(labelItemsDisplay)
        Controls.Add(labelBenchmark)
        Controls.Add(Label1)
        Controls.Add(LabelHeader1)
        Name = "FormTestRSCViaDigits"
        Text = "Testing RSC Column-Operations via Digits"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents labelBenchmark As Label
    Friend WithEvents labelItemsDisplay As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents buttonReDo As Button
    Friend WithEvents buttonUndo As Button
    Friend WithEvents labelNumOperations As Label
    Friend WithEvents userControlOperation1 As UserControlOperation
    Friend WithEvents linkSingleItemOnly As LinkLabel
    Friend WithEvents linkEndpointHeading As LinkLabel
    Friend WithEvents linkToEndpoint As LinkLabel
    Friend WithEvents linkToPenultimate As LinkLabel
    Friend WithEvents labelAnchorLinkLabels As Label
    Friend WithEvents LinkClearRecordedOps As LinkLabel
    Friend WithEvents LabelNotTestingManager As Label

End Class
