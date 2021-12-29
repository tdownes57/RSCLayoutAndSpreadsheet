<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSaveMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSaveAsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurationOfFieldsEtcToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StandardFieldsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomFieldsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DemoModeVideoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DemoModeActiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BadgeRecipientsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowBadgeRecipientsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseListOfRecipentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintAllBadgesToFileFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitRecipientModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectFromExistingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.flowSidebar = New System.Windows.Forms.FlowLayoutPanel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.flowSidebar.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(12, 41)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(713, 39)
        Me.LabelHeader1.TabIndex = 0
        Me.LabelHeader1.Tag = "Edit {0}"
        Me.LabelHeader1.Text = "Edit Recipient (Student, Employee, Supporter)"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(495, 376)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(135, 35)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(648, 376)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(135, 35)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ConfigurationOfFieldsEtcToolStripMenuItem, Me.BackgroundImagesToolStripMenuItem, Me.DemoModeVideoToolStripMenuItem, Me.BadgeRecipientsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(1166, 30)
        Me.MenuStrip1.TabIndex = 40
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.FileSaveMenuItem, Me.FileSaveAsMenuItem, Me.ExitToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(46, 24)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(236, 26)
        Me.OpenToolStripMenuItem.Text = "Open Layout XML....."
        '
        'FileSaveMenuItem
        '
        Me.FileSaveMenuItem.Name = "FileSaveMenuItem"
        Me.FileSaveMenuItem.Size = New System.Drawing.Size(236, 26)
        Me.FileSaveMenuItem.Text = "Save"
        '
        'FileSaveAsMenuItem
        '
        Me.FileSaveAsMenuItem.Name = "FileSaveAsMenuItem"
        Me.FileSaveAsMenuItem.Size = New System.Drawing.Size(236, 26)
        Me.FileSaveAsMenuItem.Text = "Save Layout As XML...."
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(236, 26)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ConfigurationOfFieldsEtcToolStripMenuItem
        '
        Me.ConfigurationOfFieldsEtcToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StandardFieldsToolStripMenuItem, Me.CustomFieldsToolStripMenuItem})
        Me.ConfigurationOfFieldsEtcToolStripMenuItem.Name = "ConfigurationOfFieldsEtcToolStripMenuItem"
        Me.ConfigurationOfFieldsEtcToolStripMenuItem.Size = New System.Drawing.Size(204, 24)
        Me.ConfigurationOfFieldsEtcToolStripMenuItem.Text = "Configuration of Fields, Etc."
        '
        'StandardFieldsToolStripMenuItem
        '
        Me.StandardFieldsToolStripMenuItem.Name = "StandardFieldsToolStripMenuItem"
        Me.StandardFieldsToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.StandardFieldsToolStripMenuItem.Text = "Standard Fields"
        '
        'CustomFieldsToolStripMenuItem
        '
        Me.CustomFieldsToolStripMenuItem.Name = "CustomFieldsToolStripMenuItem"
        Me.CustomFieldsToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.CustomFieldsToolStripMenuItem.Text = "Custom Fields"
        '
        'DemoModeVideoToolStripMenuItem
        '
        Me.DemoModeVideoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DemoModeActiveToolStripMenuItem})
        Me.DemoModeVideoToolStripMenuItem.Name = "DemoModeVideoToolStripMenuItem"
        Me.DemoModeVideoToolStripMenuItem.Size = New System.Drawing.Size(160, 24)
        Me.DemoModeVideoToolStripMenuItem.Text = "Demo Mode (Video)"
        Me.DemoModeVideoToolStripMenuItem.Visible = False
        '
        'DemoModeActiveToolStripMenuItem
        '
        Me.DemoModeActiveToolStripMenuItem.Name = "DemoModeActiveToolStripMenuItem"
        Me.DemoModeActiveToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.DemoModeActiveToolStripMenuItem.Text = "Demo Mode Active"
        '
        'BadgeRecipientsToolStripMenuItem
        '
        Me.BadgeRecipientsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowBadgeRecipientsToolStripMenuItem, Me.CloseListOfRecipentsToolStripMenuItem, Me.PrintAllBadgesToFileFolderToolStripMenuItem, Me.ExitRecipientModeToolStripMenuItem})
        Me.BadgeRecipientsToolStripMenuItem.Name = "BadgeRecipientsToolStripMenuItem"
        Me.BadgeRecipientsToolStripMenuItem.Size = New System.Drawing.Size(138, 24)
        Me.BadgeRecipientsToolStripMenuItem.Text = "Badge Recipients"
        '
        'ShowBadgeRecipientsToolStripMenuItem
        '
        Me.ShowBadgeRecipientsToolStripMenuItem.Name = "ShowBadgeRecipientsToolStripMenuItem"
        Me.ShowBadgeRecipientsToolStripMenuItem.Size = New System.Drawing.Size(318, 26)
        Me.ShowBadgeRecipientsToolStripMenuItem.Text = "Show Badge Recipients in Sidebar"
        '
        'CloseListOfRecipentsToolStripMenuItem
        '
        Me.CloseListOfRecipentsToolStripMenuItem.Name = "CloseListOfRecipentsToolStripMenuItem"
        Me.CloseListOfRecipentsToolStripMenuItem.Size = New System.Drawing.Size(318, 26)
        Me.CloseListOfRecipentsToolStripMenuItem.Text = "Close List of Recipents"
        '
        'PrintAllBadgesToFileFolderToolStripMenuItem
        '
        Me.PrintAllBadgesToFileFolderToolStripMenuItem.Name = "PrintAllBadgesToFileFolderToolStripMenuItem"
        Me.PrintAllBadgesToFileFolderToolStripMenuItem.Size = New System.Drawing.Size(318, 26)
        Me.PrintAllBadgesToFileFolderToolStripMenuItem.Text = "Print all Badges to File Folder"
        '
        'ExitRecipientModeToolStripMenuItem
        '
        Me.ExitRecipientModeToolStripMenuItem.Name = "ExitRecipientModeToolStripMenuItem"
        Me.ExitRecipientModeToolStripMenuItem.Size = New System.Drawing.Size(318, 26)
        Me.ExitRecipientModeToolStripMenuItem.Text = "Exit Recipient Mode"
        '
        'UploadNewToolStripMenuItem
        '
        Me.UploadNewToolStripMenuItem.Name = "UploadNewToolStripMenuItem"
        Me.UploadNewToolStripMenuItem.Size = New System.Drawing.Size(337, 26)
        Me.UploadNewToolStripMenuItem.Text = "Upload new background...."
        '
        'SelectFromExistingToolStripMenuItem
        '
        Me.SelectFromExistingToolStripMenuItem.Name = "SelectFromExistingToolStripMenuItem"
        Me.SelectFromExistingToolStripMenuItem.Size = New System.Drawing.Size(337, 26)
        Me.SelectFromExistingToolStripMenuItem.Text = "Select from uploaded backgrounds...."
        '
        'BackgroundImagesToolStripMenuItem
        '
        Me.BackgroundImagesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadNewToolStripMenuItem, Me.SelectFromExistingToolStripMenuItem})
        Me.BackgroundImagesToolStripMenuItem.Name = "BackgroundImagesToolStripMenuItem"
        Me.BackgroundImagesToolStripMenuItem.Size = New System.Drawing.Size(154, 24)
        Me.BackgroundImagesToolStripMenuItem.Text = "Background Images"
        '
        'flowSidebar
        '
        Me.flowSidebar.BackColor = System.Drawing.SystemColors.Info
        Me.flowSidebar.Controls.Add(Me.LinkLabel1)
        Me.flowSidebar.Dock = System.Windows.Forms.DockStyle.Right
        Me.flowSidebar.Location = New System.Drawing.Point(1145, 30)
        Me.flowSidebar.Name = "flowSidebar"
        Me.flowSidebar.Size = New System.Drawing.Size(21, 420)
        Me.flowSidebar.TabIndex = 55
        Me.flowSidebar.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(3, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(17, 204)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Close sidebar"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1166, 450)
        Me.Controls.Add(Me.flowSidebar)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.flowSidebar.ResumeLayout(False)
        Me.flowSidebar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileSaveMenuItem As ToolStripMenuItem
    Friend WithEvents FileSaveAsMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfigurationOfFieldsEtcToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StandardFieldsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomFieldsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackgroundImagesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadNewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectFromExistingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DemoModeVideoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DemoModeActiveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BadgeRecipientsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowBadgeRecipientsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseListOfRecipentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintAllBadgesToFileFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitRecipientModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents flowSidebar As FlowLayoutPanel
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
