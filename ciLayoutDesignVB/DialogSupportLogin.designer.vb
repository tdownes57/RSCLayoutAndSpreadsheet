<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogSupportLogin
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
        Me.lblExportInfo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelLoginName = New System.Windows.Forms.Label()
        Me.LabelPassword = New System.Windows.Forms.Label()
        Me.textLoginName = New System.Windows.Forms.TextBox()
        Me.textPasscode = New System.Windows.Forms.TextBox()
        Me.buttonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.linklabelSelectFileMDB = New System.Windows.Forms.LinkLabel()
        Me.chkExportAdvanced = New System.Windows.Forms.CheckBox()
        Me.imgCIS = New System.Windows.Forms.PictureBox()
        CType(Me.imgCIS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblExportInfo
        '
        Me.lblExportInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExportInfo.Location = New System.Drawing.Point(41, 254)
        Me.lblExportInfo.Name = "lblExportInfo"
        Me.lblExportInfo.Size = New System.Drawing.Size(376, 22)
        Me.lblExportInfo.TabIndex = 8
        Me.lblExportInfo.Text = "Enter your login data for Support."
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 218)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(376, 36)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Login to Support Mode"
        '
        'LabelLoginName
        '
        Me.LabelLoginName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelLoginName.AutoSize = True
        Me.LabelLoginName.Location = New System.Drawing.Point(111, 277)
        Me.LabelLoginName.Name = "LabelLoginName"
        Me.LabelLoginName.Size = New System.Drawing.Size(38, 13)
        Me.LabelLoginName.TabIndex = 10
        Me.LabelLoginName.Text = "Name:"
        '
        'LabelPassword
        '
        Me.LabelPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelPassword.AutoSize = True
        Me.LabelPassword.Location = New System.Drawing.Point(111, 299)
        Me.LabelPassword.Name = "LabelPassword"
        Me.LabelPassword.Size = New System.Drawing.Size(56, 13)
        Me.LabelPassword.TabIndex = 11
        Me.LabelPassword.Text = "Password:"
        '
        'textLoginName
        '
        Me.textLoginName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.textLoginName.Location = New System.Drawing.Point(201, 274)
        Me.textLoginName.Name = "textLoginName"
        Me.textLoginName.Size = New System.Drawing.Size(194, 20)
        Me.textLoginName.TabIndex = 12
        '
        'textPasscode
        '
        Me.textPasscode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.textPasscode.Location = New System.Drawing.Point(201, 296)
        Me.textPasscode.Name = "textPasscode"
        Me.textPasscode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textPasscode.Size = New System.Drawing.Size(194, 20)
        Me.textPasscode.TabIndex = 13
        '
        'buttonOK
        '
        Me.buttonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.buttonOK.Location = New System.Drawing.Point(284, 326)
        Me.buttonOK.Name = "buttonOK"
        Me.buttonOK.Size = New System.Drawing.Size(135, 24)
        Me.buttonOK.TabIndex = 14
        Me.buttonOK.Text = "OK"
        Me.buttonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(425, 326)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(135, 24)
        Me.ButtonCancel.TabIndex = 15
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'linklabelSelectFileMDB
        '
        Me.linklabelSelectFileMDB.AutoSize = True
        Me.linklabelSelectFileMDB.Location = New System.Drawing.Point(320, 229)
        Me.linklabelSelectFileMDB.Name = "linklabelSelectFileMDB"
        Me.linklabelSelectFileMDB.Size = New System.Drawing.Size(124, 13)
        Me.linklabelSelectFileMDB.TabIndex = 17
        Me.linklabelSelectFileMDB.TabStop = True
        Me.linklabelSelectFileMDB.Text = "Select relevant file MDB."
        Me.linklabelSelectFileMDB.Visible = False
        '
        'chkExportAdvanced
        '
        Me.chkExportAdvanced.AutoSize = True
        Me.chkExportAdvanced.Location = New System.Drawing.Point(201, 326)
        Me.chkExportAdvanced.Name = "chkExportAdvanced"
        Me.chkExportAdvanced.Size = New System.Drawing.Size(75, 17)
        Me.chkExportAdvanced.TabIndex = 18
        Me.chkExportAdvanced.Text = "Advanced"
        Me.chkExportAdvanced.UseVisualStyleBackColor = True
        Me.chkExportAdvanced.Visible = False
        '
        'imgCIS
        '
        Me.imgCIS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgCIS.Image = Global.ciLayoutDesignVB.My.Resources.Resources.CI_Logo
        Me.imgCIS.Location = New System.Drawing.Point(12, 12)
        Me.imgCIS.Name = "imgCIS"
        Me.imgCIS.Size = New System.Drawing.Size(548, 203)
        Me.imgCIS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgCIS.TabIndex = 16
        Me.imgCIS.TabStop = False
        '
        'FormSupportLogin
        '
        Me.AcceptButton = Me.buttonOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(571, 362)
        Me.Controls.Add(Me.chkExportAdvanced)
        Me.Controls.Add(Me.linklabelSelectFileMDB)
        Me.Controls.Add(Me.imgCIS)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.buttonOK)
        Me.Controls.Add(Me.textPasscode)
        Me.Controls.Add(Me.textLoginName)
        Me.Controls.Add(Me.LabelPassword)
        Me.Controls.Add(Me.LabelLoginName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblExportInfo)
        Me.Name = "FormSupportLogin"
        Me.Text = "Login to Copy-Move Files"
        CType(Me.imgCIS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblExportInfo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelLoginName As Label
    Friend WithEvents LabelPassword As Label
    Friend WithEvents textLoginName As TextBox
    Friend WithEvents textPasscode As TextBox
    Friend WithEvents buttonOK As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents imgCIS As PictureBox
    Friend WithEvents linklabelSelectFileMDB As LinkLabel
    Friend WithEvents chkExportAdvanced As CheckBox
End Class
