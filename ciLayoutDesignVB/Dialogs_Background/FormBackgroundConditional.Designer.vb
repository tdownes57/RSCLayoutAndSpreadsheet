<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBackgroundConditional
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
        Me.LabelModeHeader = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.LabelHeading1 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.CtlBackground2 = New ciLayoutDesignVB.CtlBackground()
        Me.CtlBackground3 = New ciLayoutDesignVB.CtlBackground()
        Me.CtlBackground1 = New ciLayoutDesignVB.CtlBackground()
        Me.RscConditionalExpression1 = New __RSCWindowsControlLibrary.RSCConditionalExpression()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelModeHeader
        '
        Me.LabelModeHeader.AutoSize = True
        Me.LabelModeHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelModeHeader.Location = New System.Drawing.Point(385, 7)
        Me.LabelModeHeader.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelModeHeader.Name = "LabelModeHeader"
        Me.LabelModeHeader.Size = New System.Drawing.Size(81, 29)
        Me.LabelModeHeader.TabIndex = 59
        Me.LabelModeHeader.Tag = "Mode:"
        Me.LabelModeHeader.Text = "Mode:"
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Uploaded Backgrounds", "Demo Backgrounds", "Original Backgrounds", "Uploaded Graphics", "Demo Graphics", "Uploaded Portraits", "Demo Portraits"})
        Me.ComboBox1.Location = New System.Drawing.Point(471, 11)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(203, 28)
        Me.ComboBox1.TabIndex = 58
        '
        'LabelHeading1
        '
        Me.LabelHeading1.AutoSize = True
        Me.LabelHeading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeading1.Location = New System.Drawing.Point(23, 20)
        Me.LabelHeading1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeading1.Name = "LabelHeading1"
        Me.LabelHeading1.Size = New System.Drawing.Size(287, 29)
        Me.LabelHeading1.TabIndex = 57
        Me.LabelHeading1.Tag = "Select Background Image"
        Me.LabelHeading1.Text = "Background, Demo Mode"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FlowLayoutPanel1.Controls.Add(Me.CtlBackground2)
        Me.FlowLayoutPanel1.Controls.Add(Me.CtlBackground3)
        Me.FlowLayoutPanel1.Controls.Add(Me.CtlBackground1)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(23, 62)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(589, 394)
        Me.FlowLayoutPanel1.TabIndex = 56
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'CtlBackground2
        '
        Me.CtlBackground2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlBackground2.IsNotSelectableItemOfAList = False
        Me.CtlBackground2.Location = New System.Drawing.Point(2, 2)
        Me.CtlBackground2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CtlBackground2.Name = "CtlBackground2"
        Me.CtlBackground2.Size = New System.Drawing.Size(544, 262)
        Me.CtlBackground2.TabIndex = 1
        '
        'CtlBackground3
        '
        Me.CtlBackground3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlBackground3.IsNotSelectableItemOfAList = False
        Me.CtlBackground3.Location = New System.Drawing.Point(2, 268)
        Me.CtlBackground3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CtlBackground3.Name = "CtlBackground3"
        Me.CtlBackground3.Size = New System.Drawing.Size(544, 262)
        Me.CtlBackground3.TabIndex = 2
        '
        'CtlBackground1
        '
        Me.CtlBackground1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlBackground1.IsNotSelectableItemOfAList = False
        Me.CtlBackground1.Location = New System.Drawing.Point(2, 534)
        Me.CtlBackground1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CtlBackground1.Name = "CtlBackground1"
        Me.CtlBackground1.Size = New System.Drawing.Size(544, 262)
        Me.CtlBackground1.TabIndex = 0
        '
        'RscConditionalExpression1
        '
        Me.RscConditionalExpression1.Location = New System.Drawing.Point(617, 62)
        Me.RscConditionalExpression1.Name = "RscConditionalExpression1"
        Me.RscConditionalExpression1.Size = New System.Drawing.Size(530, 148)
        Me.RscConditionalExpression1.TabIndex = 60
        '
        'FormBackgroundConditional
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1171, 516)
        Me.Controls.Add(Me.RscConditionalExpression1)
        Me.Controls.Add(Me.LabelModeHeader)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.LabelHeading1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "FormBackgroundConditional"
        Me.Text = "FormBackgroundConditional"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelModeHeader As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents LabelHeading1 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents CtlBackground2 As CtlBackground
    Friend WithEvents CtlBackground3 As CtlBackground
    Friend WithEvents CtlBackground1 As CtlBackground
    Friend WithEvents RscConditionalExpression1 As __RSCWindowsControlLibrary.RSCConditionalExpression
End Class
