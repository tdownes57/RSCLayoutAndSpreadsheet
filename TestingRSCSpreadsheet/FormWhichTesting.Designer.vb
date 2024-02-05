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
        SuspendLayout()
        ' 
        ' LinkOperationsManager
        ' 
        LinkOperationsManager.AutoSize = True
        LinkOperationsManager.Location = New Point(35, 112)
        LinkOperationsManager.Name = "LinkOperationsManager"
        LinkOperationsManager.Size = New Size(269, 15)
        LinkOperationsManager.TabIndex = 0
        LinkOperationsManager.TabStop = True
        LinkOperationsManager.Text = "Testing the MVC approach... Operations Manager."
        ' 
        ' LinkFormManagesOps
        ' 
        LinkFormManagesOps.AutoSize = True
        LinkFormManagesOps.Location = New Point(35, 74)
        LinkFormManagesOps.Name = "LinkFormManagesOps"
        LinkFormManagesOps.Size = New Size(231, 15)
        LinkFormManagesOps.TabIndex = 1
        LinkFormManagesOps.TabStop = True
        LinkFormManagesOps.Text = "Works well!  Form manages the operations"
        ' 
        ' LinkOpsManagerTwoLists
        ' 
        LinkOpsManagerTwoLists.AutoSize = True
        LinkOpsManagerTwoLists.Location = New Point(35, 148)
        LinkOpsManagerTwoLists.Name = "LinkOpsManagerTwoLists"
        LinkOpsManagerTwoLists.Size = New Size(323, 15)
        LinkOpsManagerTwoLists.TabIndex = 2
        LinkOpsManagerTwoLists.TabStop = True
        LinkOpsManagerTwoLists.Text = "Testing the Two-List Operations Manager (Cyan && Magenta)"
        ' 
        ' FormWhichTesting
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
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
End Class
