<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSCFieldSpreadsheet
    Inherits __RSCWindowsControlLibrary.RSCMoveableControlVB ''System.Windows.Forms.UserControl

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
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.RscRowHeaders1 = New ciBadgeDesigner.RSCRowHeaders()
        Me.RscFieldColumn1 = New ciBadgeDesigner.RSCFieldColumn()
        Me.SuspendLayout()
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(654, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(153, 13)
        Me.LinkLabel1.TabIndex = 6
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Right-click will present a menu."
        '
        'LinkLabel2
        '
        Me.LinkLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(401, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(234, 13)
        Me.LinkLabel2.TabIndex = 7
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Review which fields are Relevant and available."
        '
        'RscRowHeaders1
        '
        Me.RscRowHeaders1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RscRowHeaders1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RscRowHeaders1.ElementInfo_Base = Nothing
        Me.RscRowHeaders1.Location = New System.Drawing.Point(2, 137)
        Me.RscRowHeaders1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RscRowHeaders1.MoveabilityEventsForGroupCtls = Nothing
        Me.RscRowHeaders1.MoveabilityEventsForSingleMove = Nothing
        Me.RscRowHeaders1.Name = "RscRowHeaders1"
        Me.RscRowHeaders1.Size = New System.Drawing.Size(94, 318)
        Me.RscRowHeaders1.TabIndex = 8
        '
        'RscFieldColumn1
        '
        Me.RscFieldColumn1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RscFieldColumn1.ColumnWidthAndData = Nothing
        Me.RscFieldColumn1.ElementInfo_Base = Nothing
        Me.RscFieldColumn1.ListOfColumnsToBumpRight = Nothing
        Me.RscFieldColumn1.Location = New System.Drawing.Point(100, 19)
        Me.RscFieldColumn1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RscFieldColumn1.MoveabilityEventsForGroupCtls = Nothing
        Me.RscFieldColumn1.MoveabilityEventsForSingleMove = Nothing
        Me.RscFieldColumn1.Name = "RscFieldColumn1"
        Me.RscFieldColumn1.Size = New System.Drawing.Size(198, 304)
        Me.RscFieldColumn1.TabIndex = 9
        '
        'RSCFieldSpreadsheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Controls.Add(Me.RscFieldColumn1)
        Me.Controls.Add(Me.RscRowHeaders1)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Name = "RSCFieldSpreadsheet"
        Me.Size = New System.Drawing.Size(821, 457)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents RscRowHeaders1 As RSCRowHeaders
    Friend WithEvents RscFieldColumn1 As RSCFieldColumn
End Class
