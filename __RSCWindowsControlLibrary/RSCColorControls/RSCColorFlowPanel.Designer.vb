<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCColorFlowPanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RSCColorFlowPanel))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LinkLabelAddColor1 = New System.Windows.Forms.LinkLabel()
        Me.RscColorDisplayLabel2 = New __RSCWindowsControlLibrary.RSCColorDisplayLabel()
        Me.RscColorDisplayLabel1 = New __RSCWindowsControlLibrary.RSCColorDisplayLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.LinkLabelAddColor1)
        Me.FlowLayoutPanel1.Controls.Add(Me.RscColorDisplayLabel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.RscColorDisplayLabel1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(617, 387)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'LinkLabelAddColor1
        '
        Me.LinkLabelAddColor1.AutoSize = True
        Me.LinkLabelAddColor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabelAddColor1.Location = New System.Drawing.Point(3, 0)
        Me.LinkLabelAddColor1.Name = "LinkLabelAddColor1"
        Me.LinkLabelAddColor1.Size = New System.Drawing.Size(150, 20)
        Me.LinkLabelAddColor1.TabIndex = 2
        Me.LinkLabelAddColor1.TabStop = True
        Me.LinkLabelAddColor1.Text = "Add/Remove Colors"
        '
        'RscColorDisplayLabel2
        '
        Me.RscColorDisplayLabel2.Location = New System.Drawing.Point(159, 3)
        Me.RscColorDisplayLabel2.Name = "RscColorDisplayLabel2"
        Me.RscColorDisplayLabel2.RSCDisplayColor = CType(resources.GetObject("RscColorDisplayLabel2.RSCDisplayColor"), ciBadgeInterfaces.RSCColor)
        Me.RscColorDisplayLabel2.Size = New System.Drawing.Size(200, 28)
        Me.RscColorDisplayLabel2.TabIndex = 1
        '
        'RscColorDisplayLabel1
        '
        Me.RscColorDisplayLabel1.Location = New System.Drawing.Point(365, 3)
        Me.RscColorDisplayLabel1.Name = "RscColorDisplayLabel1"
        Me.RscColorDisplayLabel1.RSCDisplayColor = CType(resources.GetObject("RscColorDisplayLabel1.RSCDisplayColor"), ciBadgeInterfaces.RSCColor)
        Me.RscColorDisplayLabel1.Size = New System.Drawing.Size(200, 28)
        Me.RscColorDisplayLabel1.TabIndex = 0
        '
        'RSCColorFlowPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "RSCColorFlowPanel"
        Me.Size = New System.Drawing.Size(617, 387)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RscColorDisplayLabel1 As RSCColorDisplayLabel
    Friend WithEvents RscColorDisplayLabel2 As RSCColorDisplayLabel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents LinkLabelAddColor1 As LinkLabel
    Friend WithEvents ToolTip1 As ToolTip
End Class
