Imports __RSCWindowsControlLibrary ''Added 4/08/2022 thomas downes

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RSCFieldColumnV2
    Inherits RSCMoveableControlVB
    ''April08 2022 td ''Inherits System.Windows.Forms.UserControl

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
        Me.LinkLabelRightClick = New System.Windows.Forms.LinkLabel()
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.LabelMoveLeft = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RscDataCell1 = New ciBadgeDesigner.RSCDataCell()
        Me.RscSelectCIBField1 = New ciBadgeDesigner.RSCSelectCIBField()
        Me.SuspendLayout()
        '
        'LinkLabelConditional
        '
        Me.LinkLabelConditional.Location = New System.Drawing.Point(82, 0)
        '
        'LinkLabelRightClick
        '
        Me.LinkLabelRightClick.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelRightClick.AutoSize = True
        Me.LinkLabelRightClick.Location = New System.Drawing.Point(126, 91)
        Me.LinkLabelRightClick.Name = "LinkLabelRightClick"
        Me.LinkLabelRightClick.Size = New System.Drawing.Size(58, 13)
        Me.LinkLabelRightClick.TabIndex = 66
        Me.LinkLabelRightClick.TabStop = True
        Me.LinkLabelRightClick.Text = "Right-Click"
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(10, 104)
        Me.LabelHeader1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(115, 20)
        Me.LabelHeader1.TabIndex = 64
        Me.LabelHeader1.Text = "Recipient Data"
        '
        'LabelMoveLeft
        '
        Me.LabelMoveLeft.AutoSize = True
        Me.LabelMoveLeft.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMoveLeft.Location = New System.Drawing.Point(2, 2)
        Me.LabelMoveLeft.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelMoveLeft.Name = "LabelMoveLeft"
        Me.LabelMoveLeft.Size = New System.Drawing.Size(40, 18)
        Me.LabelMoveLeft.TabIndex = 86
        Me.LabelMoveLeft.Text = "◄◄"
        Me.ToolTip1.SetToolTip(Me.LabelMoveLeft, "Switch column position with the column to the left")
        '
        'RscDataCell1
        '
        Me.RscDataCell1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RscDataCell1.BorderStyle_Textbox = System.Windows.Forms.BorderStyle.None
        Me.RscDataCell1.Location = New System.Drawing.Point(0, 125)
        Me.RscDataCell1.Margin = New System.Windows.Forms.Padding(0)
        Me.RscDataCell1.Name = "RscDataCell1"
        Me.RscDataCell1.Size = New System.Drawing.Size(184, 23)
        Me.RscDataCell1.TabIndex = 67
        Me.RscDataCell1.Tag_Text = ""
        Me.RscDataCell1.Text_CellValue = ""
        '
        'RscSelectCIBField1
        '
        Me.RscSelectCIBField1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RscSelectCIBField1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RscSelectCIBField1.Location = New System.Drawing.Point(0, 25)
        Me.RscSelectCIBField1.Margin = New System.Windows.Forms.Padding(2)
        Me.RscSelectCIBField1.Name = "RscSelectCIBField1"
        Me.RscSelectCIBField1.SelectedValue = ciBadgeInterfaces.ModEnumsAndStructs.EnumCIBFields.Undetermined
        Me.RscSelectCIBField1.Size = New System.Drawing.Size(184, 64)
        Me.RscSelectCIBField1.TabIndex = 87
        '
        'RSCFieldColumnV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Controls.Add(Me.RscSelectCIBField1)
        Me.Controls.Add(Me.LabelMoveLeft)
        Me.Controls.Add(Me.RscDataCell1)
        Me.Controls.Add(Me.LinkLabelRightClick)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Name = "RSCFieldColumnV2"
        Me.Size = New System.Drawing.Size(188, 408)
        Me.Controls.SetChildIndex(Me.LabelHeader1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabelRightClick, 0)
        Me.Controls.SetChildIndex(Me.RscDataCell1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabelConditional, 0)
        Me.Controls.SetChildIndex(Me.LabelMoveLeft, 0)
        Me.Controls.SetChildIndex(Me.RscSelectCIBField1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkLabelRightClick As LinkLabel
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents RscDataCell1 As RSCDataCell
    Friend WithEvents LabelMoveLeft As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents RscSelectCIBField1 As RSCSelectCIBField
End Class
