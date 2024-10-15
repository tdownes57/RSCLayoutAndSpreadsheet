<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWhichTesting
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
        LinkOperationsManager = New LinkLabel()
        LinkFormManagesOps = New LinkLabel()
        LinkOpsManagerTwoLists = New LinkLabel()
        LinkLabelCSharpSimple1D = New LinkLabel()
        Label1ProbablyObselete = New Label()
        SuspendLayout()
        ' 
        ' LinkOperationsManager
        ' 
        LinkOperationsManager.AutoSize = True
        LinkOperationsManager.Location = New Point(218, 267)
        LinkOperationsManager.Name = "LinkOperationsManager"
        LinkOperationsManager.Size = New Size(469, 15)
        LinkOperationsManager.TabIndex = 0
        LinkOperationsManager.TabStop = True
        LinkOperationsManager.Text = "Testing the MVC approach... Operations Manager --REMOVED FROM THE APPLICATION"
        ' 
        ' LinkFormManagesOps
        ' 
        LinkFormManagesOps.AutoSize = True
        LinkFormManagesOps.Location = New Point(218, 241)
        LinkFormManagesOps.Name = "LinkFormManagesOps"
        LinkFormManagesOps.Size = New Size(231, 15)
        LinkFormManagesOps.TabIndex = 1
        LinkFormManagesOps.TabStop = True
        LinkFormManagesOps.Text = "Works well!  Form manages the operations"
        ' 
        ' LinkOpsManagerTwoLists
        ' 
        LinkOpsManagerTwoLists.AutoSize = True
        LinkOpsManagerTwoLists.Location = New Point(218, 291)
        LinkOpsManagerTwoLists.Name = "LinkOpsManagerTwoLists"
        LinkOpsManagerTwoLists.Size = New Size(323, 15)
        LinkOpsManagerTwoLists.TabIndex = 2
        LinkOpsManagerTwoLists.TabStop = True
        LinkOpsManagerTwoLists.Text = "Testing the Two-List Operations Manager (Cyan && Magenta)"
        ' 
        ' LinkLabelCSharpSimple1D
        ' 
        LinkLabelCSharpSimple1D.AutoSize = True
        LinkLabelCSharpSimple1D.Location = New Point(32, 180)
        LinkLabelCSharpSimple1D.Name = "LinkLabelCSharpSimple1D"
        LinkLabelCSharpSimple1D.Size = New Size(306, 15)
        LinkLabelCSharpSimple1D.TabIndex = 3
        LinkLabelCSharpSimple1D.TabStop = True
        LinkLabelCSharpSimple1D.Text = "Testing a simple 1-Dimensional version of the C# Library."
        ' 
        ' Label1ProbablyObselete
        ' 
        Label1ProbablyObselete.AutoSize = True
        Label1ProbablyObselete.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        Label1ProbablyObselete.Location = New Point(203, 209)
        Label1ProbablyObselete.Name = "Label1ProbablyObselete"
        Label1ProbablyObselete.Size = New Size(368, 15)
        Label1ProbablyObselete.TabIndex = 4
        Label1ProbablyObselete.Text = "The ones below are probably obselete and won't work, unfortunately"
        ' 
        ' FormWhichTesting
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label1ProbablyObselete)
        Controls.Add(LinkLabelCSharpSimple1D)
        Controls.Add(LinkOpsManagerTwoLists)
        Controls.Add(LinkFormManagesOps)
        Controls.Add(LinkOperationsManager)
        Name = "FormWhichTesting"
        Text = "FormWhichTesting"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LinkOperationsManager As LinkLabel
    Friend WithEvents LinkFormManagesOps As LinkLabel
    Friend WithEvents LinkOpsManagerTwoLists As LinkLabel
    Friend WithEvents LinkLabelCSharpSimple1D As LinkLabel
    Friend WithEvents Label1ProbablyObselete As Label
End Class
