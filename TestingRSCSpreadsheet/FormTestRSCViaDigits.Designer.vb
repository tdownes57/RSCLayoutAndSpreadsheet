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
        LabelItemsDisplay = New Label()
        Label3 = New Label()
        Label7 = New Label()
        ButtonReDo = New Button()
        ButtonUndo = New Button()
        LabelNumOperations = New Label()
        UserControlOperation1 = New UserControlOperation()
        LinkSingleItemOnly = New LinkLabel()
        LinkEndpointHeading = New LinkLabel()
        LinkToEndpoint = New LinkLabel()
        LinkToPenultimate = New LinkLabel()
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
        LabelBenchmark.Location = New Point(35, 92)
        LabelBenchmark.Name = "LabelBenchmark"
        LabelBenchmark.Size = New Size(598, 24)
        LabelBenchmark.TabIndex = 2
        LabelBenchmark.Tag = "         01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30 "
        LabelBenchmark.Text = "         01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30 "
        ' 
        ' LabelItemsDisplay
        ' 
        LabelItemsDisplay.BorderStyle = BorderStyle.FixedSingle
        LabelItemsDisplay.Location = New Point(58, 116)
        LabelItemsDisplay.Name = "LabelItemsDisplay"
        LabelItemsDisplay.Size = New Size(595, 24)
        LabelItemsDisplay.TabIndex = 3
        LabelItemsDisplay.Tag = "  01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16 "
        LabelItemsDisplay.Text = "  01  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30"
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
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(12, 379)
        Label7.Name = "Label7"
        Label7.Size = New Size(0, 15)
        Label7.TabIndex = 18
        ' 
        ' ButtonReDo
        ' 
        ButtonReDo.Enabled = False
        ButtonReDo.Location = New Point(480, 25)
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
        ' UserControlOperation1
        ' 
        UserControlOperation1.BackColor = SystemColors.ActiveCaption
        UserControlOperation1.Location = New Point(58, 166)
        UserControlOperation1.Name = "UserControlOperation1"
        UserControlOperation1.Size = New Size(649, 450)
        UserControlOperation1.TabIndex = 34
        ' 
        ' LinkSingleItemOnly
        ' 
        LinkSingleItemOnly.AutoSize = True
        LinkSingleItemOnly.Location = New Point(544, 148)
        LinkSingleItemOnly.Name = "LinkSingleItemOnly"
        LinkSingleItemOnly.Size = New Size(140, 15)
        LinkSingleItemOnly.TabIndex = 62
        LinkSingleItemOnly.TabStop = True
        LinkSingleItemOnly.Text = "Toggle Single-Item Mode"
        ' 
        ' LinkEndpointHeading
        ' 
        LinkEndpointHeading.AutoSize = True
        LinkEndpointHeading.Location = New Point(459, 77)
        LinkEndpointHeading.Name = "LinkEndpointHeading"
        LinkEndpointHeading.Size = New Size(126, 15)
        LinkEndpointHeading.TabIndex = 63
        LinkEndpointHeading.TabStop = True
        LinkEndpointHeading.Text = "Use Final Endpoint......."
        ' 
        ' LinkToEndpoint
        ' 
        LinkToEndpoint.AutoSize = True
        LinkToEndpoint.Location = New Point(616, 77)
        LinkToEndpoint.Name = "LinkToEndpoint"
        LinkToEndpoint.Size = New Size(19, 15)
        LinkToEndpoint.TabIndex = 64
        LinkToEndpoint.TabStop = True
        LinkToEndpoint.Tag = "Link to "
        LinkToEndpoint.Text = "30"
        ' 
        ' LinkToPenultimate
        ' 
        LinkToPenultimate.AutoSize = True
        LinkToPenultimate.Location = New Point(591, 77)
        LinkToPenultimate.Name = "LinkToPenultimate"
        LinkToPenultimate.Size = New Size(19, 15)
        LinkToPenultimate.TabIndex = 65
        LinkToPenultimate.TabStop = True
        LinkToPenultimate.Text = "29"
        ' 
        ' FormTestRSCViaDigits
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(763, 632)
        Controls.Add(LinkToPenultimate)
        Controls.Add(LinkToEndpoint)
        Controls.Add(LinkEndpointHeading)
        Controls.Add(LinkSingleItemOnly)
        Controls.Add(UserControlOperation1)
        Controls.Add(LabelNumOperations)
        Controls.Add(ButtonUndo)
        Controls.Add(ButtonReDo)
        Controls.Add(Label7)
        Controls.Add(Label3)
        Controls.Add(LabelItemsDisplay)
        Controls.Add(LabelBenchmark)
        Controls.Add(Label1)
        Controls.Add(LabelHeader1)
        Name = "FormTestRSCViaDigits"
        Text = "Testing RSC Column-Operations via Digits"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelBenchmark As Label
    Friend WithEvents LabelItemsDisplay As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ButtonReDo As Button
    Friend WithEvents ButtonUndo As Button
    Friend WithEvents LabelNumOperations As Label
    Friend WithEvents UserControlOperation1 As UserControlOperation
    Friend WithEvents LinkSingleItemOnly As LinkLabel
    Friend WithEvents LinkEndpointHeading As LinkLabel
    Friend WithEvents LinkToEndpoint As LinkLabel
    Friend WithEvents LinkToPenultimate As LinkLabel

End Class
