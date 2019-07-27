<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PersonalityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentsToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StaffToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurationOfFieldsEtcToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigureFieldsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserControlsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridViewTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesignLayoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadBackgroundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlaceElementsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectFromExistingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pictureBack = New System.Windows.Forms.PictureBox()
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.pictureBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.PersonalityToolStripMenuItem, Me.ConfigurationOfFieldsEtcToolStripMenuItem, Me.DesignLayoutToolStripMenuItem, Me.BackgroundImagesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.OpenToolStripMenuItem.Text = "Open Layout....."
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.SaveToolStripMenuItem.Text = "Save Layout As...."
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'PersonalityToolStripMenuItem
        '
        Me.PersonalityToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StudentsToolStripMenuItem2, Me.StaffToolStripMenuItem2})
        Me.PersonalityToolStripMenuItem.Name = "PersonalityToolStripMenuItem"
        Me.PersonalityToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.PersonalityToolStripMenuItem.Text = "Personality"
        '
        'StudentsToolStripMenuItem2
        '
        Me.StudentsToolStripMenuItem2.Checked = True
        Me.StudentsToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.StudentsToolStripMenuItem2.Name = "StudentsToolStripMenuItem2"
        Me.StudentsToolStripMenuItem2.Size = New System.Drawing.Size(120, 22)
        Me.StudentsToolStripMenuItem2.Text = "Students"
        '
        'StaffToolStripMenuItem2
        '
        Me.StaffToolStripMenuItem2.Name = "StaffToolStripMenuItem2"
        Me.StaffToolStripMenuItem2.Size = New System.Drawing.Size(120, 22)
        Me.StaffToolStripMenuItem2.Text = "Staff"
        '
        'ConfigurationOfFieldsEtcToolStripMenuItem
        '
        Me.ConfigurationOfFieldsEtcToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigureFieldsToolStripMenuItem})
        Me.ConfigurationOfFieldsEtcToolStripMenuItem.Name = "ConfigurationOfFieldsEtcToolStripMenuItem"
        Me.ConfigurationOfFieldsEtcToolStripMenuItem.Size = New System.Drawing.Size(165, 20)
        Me.ConfigurationOfFieldsEtcToolStripMenuItem.Text = "Configuration of Fields, Etc."
        '
        'ConfigureFieldsToolStripMenuItem
        '
        Me.ConfigureFieldsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserControlsToolStripMenuItem, Me.GridViewTableToolStripMenuItem})
        Me.ConfigureFieldsToolStripMenuItem.Name = "ConfigureFieldsToolStripMenuItem"
        Me.ConfigureFieldsToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ConfigureFieldsToolStripMenuItem.Text = "Configure Fields"
        '
        'UserControlsToolStripMenuItem
        '
        Me.UserControlsToolStripMenuItem.Name = "UserControlsToolStripMenuItem"
        Me.UserControlsToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.UserControlsToolStripMenuItem.Text = "User Controls / Flow"
        '
        'GridViewTableToolStripMenuItem
        '
        Me.GridViewTableToolStripMenuItem.Name = "GridViewTableToolStripMenuItem"
        Me.GridViewTableToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.GridViewTableToolStripMenuItem.Text = "Grid View / Table"
        '
        'DesignLayoutToolStripMenuItem
        '
        Me.DesignLayoutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadBackgroundToolStripMenuItem, Me.PlaceElementsToolStripMenuItem})
        Me.DesignLayoutToolStripMenuItem.Name = "DesignLayoutToolStripMenuItem"
        Me.DesignLayoutToolStripMenuItem.Size = New System.Drawing.Size(94, 20)
        Me.DesignLayoutToolStripMenuItem.Text = "Design Layout"
        '
        'UploadBackgroundToolStripMenuItem
        '
        Me.UploadBackgroundToolStripMenuItem.Name = "UploadBackgroundToolStripMenuItem"
        Me.UploadBackgroundToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.UploadBackgroundToolStripMenuItem.Text = "Upload Background"
        '
        'PlaceElementsToolStripMenuItem
        '
        Me.PlaceElementsToolStripMenuItem.Name = "PlaceElementsToolStripMenuItem"
        Me.PlaceElementsToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.PlaceElementsToolStripMenuItem.Text = "Place Elements"
        '
        'BackgroundImagesToolStripMenuItem
        '
        Me.BackgroundImagesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadNewToolStripMenuItem, Me.SelectFromExistingToolStripMenuItem})
        Me.BackgroundImagesToolStripMenuItem.Name = "BackgroundImagesToolStripMenuItem"
        Me.BackgroundImagesToolStripMenuItem.Size = New System.Drawing.Size(124, 20)
        Me.BackgroundImagesToolStripMenuItem.Text = "Background Images"
        '
        'UploadNewToolStripMenuItem
        '
        Me.UploadNewToolStripMenuItem.Name = "UploadNewToolStripMenuItem"
        Me.UploadNewToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.UploadNewToolStripMenuItem.Text = "Upload new...."
        '
        'SelectFromExistingToolStripMenuItem
        '
        Me.SelectFromExistingToolStripMenuItem.Name = "SelectFromExistingToolStripMenuItem"
        Me.SelectFromExistingToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.SelectFromExistingToolStripMenuItem.Text = "Select from existing...."
        '
        'pictureBack
        '
        Me.pictureBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBack.Image = Global.ciLayoutDesignVB.My.Resources.Resources.CI_Logo
        Me.pictureBack.Location = New System.Drawing.Point(70, 68)
        Me.pictureBack.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pictureBack.Name = "pictureBack"
        Me.pictureBack.Size = New System.Drawing.Size(645, 400)
        Me.pictureBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBack.TabIndex = 20
        Me.pictureBack.TabStop = False
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(9, 35)
        Me.LabelHeader1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(222, 24)
        Me.LabelHeader1.TabIndex = 21
        Me.LabelHeader1.Text = "Your Badge Background:"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(800, 489)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Controls.Add(Me.pictureBack)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMain"
        Me.Text = "FormMain"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.pictureBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfigurationOfFieldsEtcToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfigureFieldsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesignLayoutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadBackgroundToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlaceElementsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pictureBack As PictureBox
    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents BackgroundImagesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadNewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectFromExistingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridViewTableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserControlsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PersonalityToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StudentsToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents StaffToolStripMenuItem2 As ToolStripMenuItem
End Class
