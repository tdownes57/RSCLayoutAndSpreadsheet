<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTestUsingManager
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
        labelAnchorLinkLabels = New Label()
        linkToPenultimate = New LinkLabel()
        linkToEndpoint = New LinkLabel()
        linkEndpointHeading = New LinkLabel()
        linkSingleItemOnly = New LinkLabel()
        userControlOperation1 = New UserControlOperation()
        labelNumOperations = New Label()
        buttonUndo = New Button()
        buttonReDo = New Button()
        Label7 = New Label()
        Label3 = New Label()
        labelItemsDisplay = New Label()
        labelBenchmark = New Label()
        Label1 = New Label()
        LabelHeader1 = New Label()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' labelAnchorLinkLabels
        ' 
        labelAnchorLinkLabels.BorderStyle = BorderStyle.FixedSingle
        labelAnchorLinkLabels.Location = New Point(48, 113)
        labelAnchorLinkLabels.Name = "labelAnchorLinkLabels"
        labelAnchorLinkLabels.Size = New Size(632, 24)
        labelAnchorLinkLabels.TabIndex = 81
        labelAnchorLinkLabels.Tag = "  01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16 "
        labelAnchorLinkLabels.Text = "  List of subclassed LinkLabel controls, representing linked items.  Newly-operated items will be designated as Visited."
        ' 
        ' linkToPenultimate
        ' 
        linkToPenultimate.AutoSize = True
        linkToPenultimate.Location = New Point(581, 31)
        linkToPenultimate.Name = "linkToPenultimate"
        linkToPenultimate.Size = New Size(19, 15)
        linkToPenultimate.TabIndex = 80
        linkToPenultimate.TabStop = True
        linkToPenultimate.Text = "29"
        ' 
        ' linkToEndpoint
        ' 
        linkToEndpoint.AutoSize = True
        linkToEndpoint.Location = New Point(606, 31)
        linkToEndpoint.Name = "linkToEndpoint"
        linkToEndpoint.Size = New Size(19, 15)
        linkToEndpoint.TabIndex = 79
        linkToEndpoint.TabStop = True
        linkToEndpoint.Tag = "Link to "
        linkToEndpoint.Text = "30"
        ' 
        ' linkEndpointHeading
        ' 
        linkEndpointHeading.AutoSize = True
        linkEndpointHeading.Location = New Point(449, 31)
        linkEndpointHeading.Name = "linkEndpointHeading"
        linkEndpointHeading.Size = New Size(126, 15)
        linkEndpointHeading.TabIndex = 78
        linkEndpointHeading.TabStop = True
        linkEndpointHeading.Text = "Use Final Endpoint......."
        ' 
        ' linkSingleItemOnly
        ' 
        linkSingleItemOnly.AutoSize = True
        linkSingleItemOnly.Location = New Point(725, 123)
        linkSingleItemOnly.Name = "linkSingleItemOnly"
        linkSingleItemOnly.Size = New Size(140, 15)
        linkSingleItemOnly.TabIndex = 77
        linkSingleItemOnly.TabStop = True
        linkSingleItemOnly.Text = "Toggle Single-Item Mode"
        ' 
        ' userControlOperation1
        ' 
        userControlOperation1.BackColor = SystemColors.ActiveCaption
        userControlOperation1.Location = New Point(8, 140)
        userControlOperation1.Name = "userControlOperation1"
        userControlOperation1.Size = New Size(649, 450)
        userControlOperation1.TabIndex = 76
        ' 
        ' labelNumOperations
        ' 
        labelNumOperations.AutoSize = True
        labelNumOperations.Location = New Point(674, 64)
        labelNumOperations.Name = "labelNumOperations"
        labelNumOperations.Size = New Size(99, 15)
        labelNumOperations.TabIndex = 75
        labelNumOperations.Tag = "Number of ops: {0}"
        labelNumOperations.Text = "Number of ops: 0"
        ' 
        ' buttonUndo
        ' 
        buttonUndo.Enabled = False
        buttonUndo.Location = New Point(659, 80)
        buttonUndo.Name = "buttonUndo"
        buttonUndo.Size = New Size(114, 27)
        buttonUndo.TabIndex = 74
        buttonUndo.Text = "<<< Undo"
        buttonUndo.UseVisualStyleBackColor = True
        ' 
        ' buttonReDo
        ' 
        buttonReDo.Enabled = False
        buttonReDo.Location = New Point(779, 80)
        buttonReDo.Name = "buttonReDo"
        buttonReDo.Size = New Size(86, 27)
        buttonReDo.TabIndex = 73
        buttonReDo.Text = "Re-do >>>"
        buttonReDo.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(2, 375)
        Label7.Name = "Label7"
        Label7.Size = New Size(0, 15)
        Label7.TabIndex = 72
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(25, 46)
        Label3.Name = "Label3"
        Label3.Size = New Size(178, 15)
        Label3.TabIndex = 71
        Label3.Text = "List of current column positions:"
        ' 
        ' labelItemsDisplay
        ' 
        labelItemsDisplay.BorderStyle = BorderStyle.FixedSingle
        labelItemsDisplay.Location = New Point(48, 85)
        labelItemsDisplay.Name = "labelItemsDisplay"
        labelItemsDisplay.Size = New Size(595, 24)
        labelItemsDisplay.TabIndex = 70
        labelItemsDisplay.Tag = "  01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16 "
        labelItemsDisplay.Text = "  01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30"
        ' 
        ' labelBenchmark
        ' 
        labelBenchmark.BorderStyle = BorderStyle.FixedSingle
        labelBenchmark.Location = New Point(25, 61)
        labelBenchmark.Name = "labelBenchmark"
        labelBenchmark.Size = New Size(598, 24)
        labelBenchmark.TabIndex = 69
        labelBenchmark.Tag = "         01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30 "
        labelBenchmark.Text = "         01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30 "
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(2, 31)
        Label1.Name = "Label1"
        Label1.Size = New Size(226, 15)
        Label1.TabIndex = 68
        Label1.Text = "List of column positions, as a benchmark:"
        ' 
        ' LabelHeader1
        ' 
        LabelHeader1.AutoSize = True
        LabelHeader1.Font = New Font("Segoe UI", 12F)
        LabelHeader1.Location = New Point(-1, 5)
        LabelHeader1.Name = "LabelHeader1"
        LabelHeader1.Size = New Size(551, 21)
        LabelHeader1.TabIndex = 67
        LabelHeader1.Text = "Testing RSC Doubly-Linked List operations--TESTING OPERATIONS MANAGER"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.GreenYellow
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(300, 5)
        Label2.Name = "Label2"
        Label2.Size = New Size(327, 21)
        Label2.TabIndex = 82
        Label2.Text = "TESTING THE OPERATIONS MANAGER CLASS"
        ' 
        ' FormTestUsingManager
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(897, 594)
        Controls.Add(Label2)
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
        Name = "FormTestUsingManager"
        Text = "FormTestUsingManager-- TESTING OPERATIONS MANAGER"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents labelAnchorLinkLabels As Label
    Friend WithEvents linkToPenultimate As LinkLabel
    Friend WithEvents linkToEndpoint As LinkLabel
    Friend WithEvents linkEndpointHeading As LinkLabel
    Friend WithEvents linkSingleItemOnly As LinkLabel
    Friend WithEvents userControlOperation1 As UserControlOperation
    Friend WithEvents labelNumOperations As Label
    Friend WithEvents buttonUndo As Button
    Friend WithEvents buttonReDo As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents labelItemsDisplay As Label
    Friend WithEvents labelBenchmark As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents Label2 As Label
End Class
