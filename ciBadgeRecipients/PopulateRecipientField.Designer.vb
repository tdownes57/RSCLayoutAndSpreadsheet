<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopulateRecipientField
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
        Me.LinkLabelOnlyRelevant = New System.Windows.Forms.LinkLabel()
        Me.LabelHeader = New System.Windows.Forms.Label()
        Me.comboBoxRelevantFields = New System.Windows.Forms.ComboBox()
        Me.textboxExample1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.LinkLabelPasteData = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelClearData = New System.Windows.Forms.LinkLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LinkLabelAddFieldOfData = New System.Windows.Forms.LinkLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PanelLeftPane = New System.Windows.Forms.Panel()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel7 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel8 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.PanelLeftPane.SuspendLayout()
        Me.SuspendLayout()
        '
        'LinkLabelOnlyRelevant
        '
        Me.LinkLabelOnlyRelevant.AutoSize = True
        Me.LinkLabelOnlyRelevant.Location = New System.Drawing.Point(5, 60)
        Me.LinkLabelOnlyRelevant.Name = "LinkLabelOnlyRelevant"
        Me.LinkLabelOnlyRelevant.Size = New System.Drawing.Size(214, 17)
        Me.LinkLabelOnlyRelevant.TabIndex = 0
        Me.LinkLabelOnlyRelevant.TabStop = True
        Me.LinkLabelOnlyRelevant.Text = "Only ""Relevant"" Fields are listed."
        Me.ToolTip1.SetToolTip(Me.LinkLabelOnlyRelevant, "Fields which have not been marked ""Relevant"" Fields are omitted.")
        '
        'LabelHeader
        '
        Me.LabelHeader.AutoSize = True
        Me.LabelHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader.Location = New System.Drawing.Point(6, 5)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(135, 25)
        Me.LabelHeader.TabIndex = 1
        Me.LabelHeader.Text = "Relevant Field"
        '
        'comboBoxRelevantFields
        '
        Me.comboBoxRelevantFields.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comboBoxRelevantFields.FormattingEnabled = True
        Me.comboBoxRelevantFields.Location = New System.Drawing.Point(1, 33)
        Me.comboBoxRelevantFields.Name = "comboBoxRelevantFields"
        Me.comboBoxRelevantFields.Size = New System.Drawing.Size(199, 24)
        Me.comboBoxRelevantFields.TabIndex = 2
        '
        'textboxExample1
        '
        Me.textboxExample1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxExample1.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.textboxExample1.Location = New System.Drawing.Point(0, 149)
        Me.textboxExample1.Name = "textboxExample1"
        Me.textboxExample1.Size = New System.Drawing.Size(200, 22)
        Me.textboxExample1.TabIndex = 3
        Me.textboxExample1.Text = "Example"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Recipient Data"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.PictureBox1.Location = New System.Drawing.Point(-3, 170)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(267, 2)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.PictureBox2.Location = New System.Drawing.Point(-3, 199)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(267, 2)
        Me.PictureBox2.TabIndex = 14
        Me.PictureBox2.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.TextBox1.Location = New System.Drawing.Point(0, 178)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(199, 22)
        Me.TextBox1.TabIndex = 13
        Me.TextBox1.Text = "Example"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.PictureBox3.Location = New System.Drawing.Point(-4, 228)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(267, 2)
        Me.PictureBox3.TabIndex = 16
        Me.PictureBox3.TabStop = False
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.TextBox2.Location = New System.Drawing.Point(-1, 207)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(201, 22)
        Me.TextBox2.TabIndex = 15
        Me.TextBox2.Text = "Example"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.PictureBox4.Location = New System.Drawing.Point(-3, 315)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(267, 2)
        Me.PictureBox4.TabIndex = 22
        Me.PictureBox4.TabStop = False
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.TextBox3.Location = New System.Drawing.Point(0, 294)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(199, 22)
        Me.TextBox3.TabIndex = 21
        Me.TextBox3.Text = "Example"
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.PictureBox5.Location = New System.Drawing.Point(-2, 286)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(267, 2)
        Me.PictureBox5.TabIndex = 20
        Me.PictureBox5.TabStop = False
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.TextBox4.Location = New System.Drawing.Point(1, 265)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(199, 22)
        Me.TextBox4.TabIndex = 19
        Me.TextBox4.Text = "Example"
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.PictureBox6.Location = New System.Drawing.Point(-2, 257)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(267, 2)
        Me.PictureBox6.TabIndex = 18
        Me.PictureBox6.TabStop = False
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox5.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.TextBox5.Location = New System.Drawing.Point(1, 236)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(199, 22)
        Me.TextBox5.TabIndex = 17
        Me.TextBox5.Text = "Example"
        '
        'PictureBox7
        '
        Me.PictureBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox7.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.PictureBox7.Location = New System.Drawing.Point(-3, 488)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(267, 2)
        Me.PictureBox7.TabIndex = 34
        Me.PictureBox7.TabStop = False
        '
        'TextBox6
        '
        Me.TextBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox6.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.TextBox6.Location = New System.Drawing.Point(0, 467)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(199, 22)
        Me.TextBox6.TabIndex = 33
        Me.TextBox6.Text = "Example"
        '
        'PictureBox8
        '
        Me.PictureBox8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox8.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.PictureBox8.Location = New System.Drawing.Point(-2, 459)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(267, 2)
        Me.PictureBox8.TabIndex = 32
        Me.PictureBox8.TabStop = False
        '
        'TextBox7
        '
        Me.TextBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox7.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.TextBox7.Location = New System.Drawing.Point(1, 438)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(199, 22)
        Me.TextBox7.TabIndex = 31
        Me.TextBox7.Text = "Example"
        '
        'PictureBox9
        '
        Me.PictureBox9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox9.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.PictureBox9.Location = New System.Drawing.Point(-2, 430)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(267, 2)
        Me.PictureBox9.TabIndex = 30
        Me.PictureBox9.TabStop = False
        '
        'TextBox8
        '
        Me.TextBox8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox8.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.TextBox8.Location = New System.Drawing.Point(1, 409)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(199, 22)
        Me.TextBox8.TabIndex = 29
        Me.TextBox8.Text = "Example"
        '
        'PictureBox10
        '
        Me.PictureBox10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox10.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.PictureBox10.Location = New System.Drawing.Point(-4, 401)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(267, 2)
        Me.PictureBox10.TabIndex = 28
        Me.PictureBox10.TabStop = False
        '
        'TextBox9
        '
        Me.TextBox9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox9.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.TextBox9.Location = New System.Drawing.Point(-1, 380)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(201, 22)
        Me.TextBox9.TabIndex = 27
        Me.TextBox9.Text = "Example"
        '
        'PictureBox11
        '
        Me.PictureBox11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox11.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.PictureBox11.Location = New System.Drawing.Point(-3, 372)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(267, 2)
        Me.PictureBox11.TabIndex = 26
        Me.PictureBox11.TabStop = False
        '
        'TextBox10
        '
        Me.TextBox10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox10.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.TextBox10.Location = New System.Drawing.Point(0, 351)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(199, 22)
        Me.TextBox10.TabIndex = 25
        Me.TextBox10.Text = "Example"
        '
        'PictureBox12
        '
        Me.PictureBox12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox12.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.PictureBox12.Location = New System.Drawing.Point(-3, 343)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(267, 2)
        Me.PictureBox12.TabIndex = 24
        Me.PictureBox12.TabStop = False
        '
        'TextBox11
        '
        Me.TextBox11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox11.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.TextBox11.Location = New System.Drawing.Point(0, 322)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(200, 22)
        Me.TextBox11.TabIndex = 23
        Me.TextBox11.Text = "Example"
        '
        'LinkLabelPasteData
        '
        Me.LinkLabelPasteData.AutoSize = True
        Me.LinkLabelPasteData.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabelPasteData.Location = New System.Drawing.Point(3, 90)
        Me.LinkLabelPasteData.Name = "LinkLabelPasteData"
        Me.LinkLabelPasteData.Size = New System.Drawing.Size(231, 20)
        Me.LinkLabelPasteData.TabIndex = 35
        Me.LinkLabelPasteData.TabStop = True
        Me.LinkLabelPasteData.Text = "Paste Data from Spreadsheet"
        Me.ToolTip1.SetToolTip(Me.LinkLabelPasteData, "The 2nd step of a Copy-Paste (from spreadsheet of recipient data)")
        '
        'LinkLabelClearData
        '
        Me.LinkLabelClearData.AutoSize = True
        Me.LinkLabelClearData.Location = New System.Drawing.Point(157, 4)
        Me.LinkLabelClearData.Name = "LinkLabelClearData"
        Me.LinkLabelClearData.Size = New System.Drawing.Size(75, 17)
        Me.LinkLabelClearData.TabIndex = 36
        Me.LinkLabelClearData.TabStop = True
        Me.LinkLabelClearData.Text = "Clear Data"
        Me.ToolTip1.SetToolTip(Me.LinkLabelClearData, "This removes recipient data from this field.")
        '
        'LinkLabelAddFieldOfData
        '
        Me.LinkLabelAddFieldOfData.AutoSize = True
        Me.LinkLabelAddFieldOfData.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabelAddFieldOfData.Location = New System.Drawing.Point(3, 16)
        Me.LinkLabelAddFieldOfData.Name = "LinkLabelAddFieldOfData"
        Me.LinkLabelAddFieldOfData.Size = New System.Drawing.Size(139, 20)
        Me.LinkLabelAddFieldOfData.TabIndex = 36
        Me.LinkLabelAddFieldOfData.TabStop = True
        Me.LinkLabelAddFieldOfData.Text = "Add Field of Data"
        Me.ToolTip1.SetToolTip(Me.LinkLabelAddFieldOfData, "The 2nd step of a Copy-Paste (from spreadsheet of recipient data)")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PanelLeftPane)
        Me.SplitContainer1.Panel1MinSize = 100
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.SplitContainer1.Panel2.Controls.Add(Me.LinkLabel5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LinkLabel6)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LinkLabel7)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LinkLabel8)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LinkLabel3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LinkLabel4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LinkLabel2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LinkLabel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LinkLabelAddFieldOfData)
        Me.SplitContainer1.Size = New System.Drawing.Size(484, 558)
        Me.SplitContainer1.SplitterDistance = 250
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 37
        '
        'PanelLeftPane
        '
        Me.PanelLeftPane.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelLeftPane.AutoScroll = True
        Me.PanelLeftPane.Controls.Add(Me.LinkLabelPasteData)
        Me.PanelLeftPane.Controls.Add(Me.LabelHeader)
        Me.PanelLeftPane.Controls.Add(Me.LinkLabelOnlyRelevant)
        Me.PanelLeftPane.Controls.Add(Me.TextBox11)
        Me.PanelLeftPane.Controls.Add(Me.PictureBox4)
        Me.PanelLeftPane.Controls.Add(Me.comboBoxRelevantFields)
        Me.PanelLeftPane.Controls.Add(Me.PictureBox12)
        Me.PanelLeftPane.Controls.Add(Me.LinkLabelClearData)
        Me.PanelLeftPane.Controls.Add(Me.TextBox3)
        Me.PanelLeftPane.Controls.Add(Me.textboxExample1)
        Me.PanelLeftPane.Controls.Add(Me.TextBox10)
        Me.PanelLeftPane.Controls.Add(Me.Label1)
        Me.PanelLeftPane.Controls.Add(Me.PictureBox5)
        Me.PanelLeftPane.Controls.Add(Me.PictureBox7)
        Me.PanelLeftPane.Controls.Add(Me.PictureBox11)
        Me.PanelLeftPane.Controls.Add(Me.PictureBox1)
        Me.PanelLeftPane.Controls.Add(Me.TextBox4)
        Me.PanelLeftPane.Controls.Add(Me.TextBox6)
        Me.PanelLeftPane.Controls.Add(Me.TextBox9)
        Me.PanelLeftPane.Controls.Add(Me.TextBox1)
        Me.PanelLeftPane.Controls.Add(Me.PictureBox6)
        Me.PanelLeftPane.Controls.Add(Me.PictureBox8)
        Me.PanelLeftPane.Controls.Add(Me.PictureBox10)
        Me.PanelLeftPane.Controls.Add(Me.PictureBox2)
        Me.PanelLeftPane.Controls.Add(Me.TextBox5)
        Me.PanelLeftPane.Controls.Add(Me.TextBox7)
        Me.PanelLeftPane.Controls.Add(Me.TextBox8)
        Me.PanelLeftPane.Controls.Add(Me.TextBox2)
        Me.PanelLeftPane.Controls.Add(Me.PictureBox3)
        Me.PanelLeftPane.Controls.Add(Me.PictureBox9)
        Me.PanelLeftPane.Location = New System.Drawing.Point(3, 27)
        Me.PanelLeftPane.Name = "PanelLeftPane"
        Me.PanelLeftPane.Size = New System.Drawing.Size(244, 528)
        Me.PanelLeftPane.TabIndex = 37
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.Location = New System.Drawing.Point(6, 389)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(165, 17)
        Me.LinkLabel5.TabIndex = 44
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "Delete Student/Recipient"
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.Location = New System.Drawing.Point(6, 358)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(165, 17)
        Me.LinkLabel6.TabIndex = 43
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "Delete Student/Recipient"
        '
        'LinkLabel7
        '
        Me.LinkLabel7.AutoSize = True
        Me.LinkLabel7.Location = New System.Drawing.Point(6, 329)
        Me.LinkLabel7.Name = "LinkLabel7"
        Me.LinkLabel7.Size = New System.Drawing.Size(165, 17)
        Me.LinkLabel7.TabIndex = 42
        Me.LinkLabel7.TabStop = True
        Me.LinkLabel7.Text = "Delete Student/Recipient"
        '
        'LinkLabel8
        '
        Me.LinkLabel8.AutoSize = True
        Me.LinkLabel8.Location = New System.Drawing.Point(6, 298)
        Me.LinkLabel8.Name = "LinkLabel8"
        Me.LinkLabel8.Size = New System.Drawing.Size(165, 17)
        Me.LinkLabel8.TabIndex = 41
        Me.LinkLabel8.TabStop = True
        Me.LinkLabel8.Text = "Delete Student/Recipient"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(6, 268)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(165, 17)
        Me.LinkLabel3.TabIndex = 40
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Delete Student/Recipient"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Location = New System.Drawing.Point(6, 237)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(165, 17)
        Me.LinkLabel4.TabIndex = 39
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Delete Student/Recipient"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(6, 208)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(165, 17)
        Me.LinkLabel2.TabIndex = 38
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Delete Student/Recipient"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 177)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(165, 17)
        Me.LinkLabel1.TabIndex = 37
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Delete Student/Recipient"
        '
        'PopulateRecipientField
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "PopulateRecipientField"
        Me.Size = New System.Drawing.Size(493, 566)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.PanelLeftPane.ResumeLayout(False)
        Me.PanelLeftPane.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LinkLabelOnlyRelevant As Windows.Forms.LinkLabel
    Friend WithEvents LabelHeader As Windows.Forms.Label
    Friend WithEvents comboBoxRelevantFields As Windows.Forms.ComboBox
    Friend WithEvents textboxExample1 As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As Windows.Forms.PictureBox
    Friend WithEvents TextBox2 As Windows.Forms.TextBox
    Friend WithEvents PictureBox4 As Windows.Forms.PictureBox
    Friend WithEvents TextBox3 As Windows.Forms.TextBox
    Friend WithEvents PictureBox5 As Windows.Forms.PictureBox
    Friend WithEvents TextBox4 As Windows.Forms.TextBox
    Friend WithEvents PictureBox6 As Windows.Forms.PictureBox
    Friend WithEvents TextBox5 As Windows.Forms.TextBox
    Friend WithEvents PictureBox7 As Windows.Forms.PictureBox
    Friend WithEvents TextBox6 As Windows.Forms.TextBox
    Friend WithEvents PictureBox8 As Windows.Forms.PictureBox
    Friend WithEvents TextBox7 As Windows.Forms.TextBox
    Friend WithEvents PictureBox9 As Windows.Forms.PictureBox
    Friend WithEvents TextBox8 As Windows.Forms.TextBox
    Friend WithEvents PictureBox10 As Windows.Forms.PictureBox
    Friend WithEvents TextBox9 As Windows.Forms.TextBox
    Friend WithEvents PictureBox11 As Windows.Forms.PictureBox
    Friend WithEvents TextBox10 As Windows.Forms.TextBox
    Friend WithEvents PictureBox12 As Windows.Forms.PictureBox
    Friend WithEvents TextBox11 As Windows.Forms.TextBox
    Friend WithEvents LinkLabelPasteData As Windows.Forms.LinkLabel
    Friend WithEvents LinkLabelClearData As Windows.Forms.LinkLabel
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
    Friend WithEvents LinkLabelAddFieldOfData As Windows.Forms.LinkLabel
    Friend WithEvents PanelLeftPane As Windows.Forms.Panel
    Friend WithEvents LinkLabel1 As Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel5 As Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel6 As Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel7 As Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel8 As Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel3 As Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel4 As Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As Windows.Forms.LinkLabel
End Class
