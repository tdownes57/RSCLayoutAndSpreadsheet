<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContextLayoutDesignToolstrip
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Item1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Item2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Item3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.AutoClose = False
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Item1ToolStripMenuItem, Me.Item2ToolStripMenuItem, Me.Item3ToolStripMenuItem})
        Me.ContextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(130, 76)
        '
        'Item1ToolStripMenuItem
        '
        Me.Item1ToolStripMenuItem.Name = "Item1ToolStripMenuItem"
        Me.Item1ToolStripMenuItem.Size = New System.Drawing.Size(129, 24)
        Me.Item1ToolStripMenuItem.Text = "Item #1"
        '
        'Item2ToolStripMenuItem
        '
        Me.Item2ToolStripMenuItem.Name = "Item2ToolStripMenuItem"
        Me.Item2ToolStripMenuItem.Size = New System.Drawing.Size(129, 24)
        Me.Item2ToolStripMenuItem.Text = "Item #2"
        '
        'Item3ToolStripMenuItem
        '
        Me.Item3ToolStripMenuItem.Name = "Item3ToolStripMenuItem"
        Me.Item3ToolStripMenuItem.Size = New System.Drawing.Size(129, 24)
        Me.Item3ToolStripMenuItem.Text = "Item #3"
        '
        'ContextLayoutDesignToolstrip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "ContextLayoutDesignToolstrip"
        Me.Size = New System.Drawing.Size(274, 444)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Item1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Item2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Item3ToolStripMenuItem As ToolStripMenuItem
End Class
