<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFieldsVsElements
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
        Me.components = New System.ComponentModel.Container()
        Me.ButtonAddFields = New System.Windows.Forms.Button()
        Me.ButtonAddElements = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LabelFooter1 = New System.Windows.Forms.Label()
        Me.LabelFooter2 = New System.Windows.Forms.Label()
        Me.LabelAddingElementsHdr = New System.Windows.Forms.Label()
        Me.ButtonBackgroundImage = New System.Windows.Forms.Button()
        Me.ButtonAddElementsH = New System.Windows.Forms.Button()
        Me.pictBackground = New System.Windows.Forms.PictureBox()
        Me.pictAddElements = New System.Windows.Forms.PictureBox()
        Me.pictDataFields = New System.Windows.Forms.PictureBox()
        CType(Me.pictBackground, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictAddElements, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictDataFields, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonAddFields
        '
        Me.ButtonAddFields.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAddFields.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAddFields.Location = New System.Drawing.Point(132, 58)
        Me.ButtonAddFields.Name = "ButtonAddFields"
        Me.ButtonAddFields.Size = New System.Drawing.Size(390, 57)
        Me.ButtonAddFields.TabIndex = 0
        Me.ButtonAddFields.Text = "1. Add Data Fields (Administrative) *"
        Me.ToolTip1.SetToolTip(Me.ButtonAddFields, "Add or Remove Data Fields")
        Me.ButtonAddFields.UseVisualStyleBackColor = True
        '
        'ButtonAddElements
        '
        Me.ButtonAddElements.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAddElements.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAddElements.Location = New System.Drawing.Point(132, 250)
        Me.ButtonAddElements.Name = "ButtonAddElements"
        Me.ButtonAddElements.Size = New System.Drawing.Size(387, 57)
        Me.ButtonAddElements.TabIndex = 1
        Me.ButtonAddElements.Text = "3. Add Graphical or Text Elements **"
        Me.ButtonAddElements.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.Location = New System.Drawing.Point(418, 369)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(104, 35)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'LabelFooter1
        '
        Me.LabelFooter1.AutoSize = True
        Me.LabelFooter1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFooter1.Location = New System.Drawing.Point(12, 119)
        Me.LabelFooter1.Name = "LabelFooter1"
        Me.LabelFooter1.Size = New System.Drawing.Size(539, 17)
        Me.LabelFooter1.TabIndex = 3
        Me.LabelFooter1.Text = "* You can easily add or remove data fields, by  designating fields as Relevant or" &
    " not."
        '
        'LabelFooter2
        '
        Me.LabelFooter2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFooter2.Location = New System.Drawing.Point(12, 310)
        Me.LabelFooter2.Name = "LabelFooter2"
        Me.LabelFooter2.Size = New System.Drawing.Size(519, 41)
        Me.LabelFooter2.TabIndex = 4
        Me.LabelFooter2.Text = "** To remove an element from the ID Card, right-click the element and select the " &
    "context-menu item ""Delete Element from Badge"". "
        '
        'LabelAddingElementsHdr
        '
        Me.LabelAddingElementsHdr.AutoSize = True
        Me.LabelAddingElementsHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAddingElementsHdr.Location = New System.Drawing.Point(12, 21)
        Me.LabelAddingElementsHdr.Name = "LabelAddingElementsHdr"
        Me.LabelAddingElementsHdr.Size = New System.Drawing.Size(207, 20)
        Me.LabelAddingElementsHdr.TabIndex = 5
        Me.LabelAddingElementsHdr.Text = "Adding Elements to ID Card"
        '
        'ButtonBackgroundImage
        '
        Me.ButtonBackgroundImage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonBackgroundImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonBackgroundImage.Location = New System.Drawing.Point(132, 148)
        Me.ButtonBackgroundImage.Name = "ButtonBackgroundImage"
        Me.ButtonBackgroundImage.Size = New System.Drawing.Size(390, 57)
        Me.ButtonBackgroundImage.TabIndex = 6
        Me.ButtonBackgroundImage.Text = "2.  Select a Background Image"
        Me.ButtonBackgroundImage.UseVisualStyleBackColor = True
        '
        'ButtonAddElementsH
        '
        Me.ButtonAddElementsH.BackColor = System.Drawing.Color.RosyBrown
        Me.ButtonAddElementsH.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.Add_Elements_to_IDCard_H
        Me.ButtonAddElementsH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonAddElementsH.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonAddElementsH.Location = New System.Drawing.Point(54, 221)
        Me.ButtonAddElementsH.Name = "ButtonAddElementsH"
        Me.ButtonAddElementsH.Size = New System.Drawing.Size(465, 32)
        Me.ButtonAddElementsH.TabIndex = 94
        Me.ButtonAddElementsH.UseVisualStyleBackColor = False
        '
        'pictBackground
        '
        Me.pictBackground.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.flag_of_USA
        Me.pictBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictBackground.Location = New System.Drawing.Point(54, 148)
        Me.pictBackground.Name = "pictBackground"
        Me.pictBackground.Size = New System.Drawing.Size(72, 48)
        Me.pictBackground.TabIndex = 95
        Me.pictBackground.TabStop = False
        '
        'pictAddElements
        '
        Me.pictAddElements.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.Badge001
        Me.pictAddElements.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictAddElements.Location = New System.Drawing.Point(54, 259)
        Me.pictAddElements.Name = "pictAddElements"
        Me.pictAddElements.Size = New System.Drawing.Size(72, 48)
        Me.pictAddElements.TabIndex = 96
        Me.pictAddElements.TabStop = False
        '
        'pictDataFields
        '
        Me.pictDataFields.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.GoldDiagonal_Land
        Me.pictDataFields.Location = New System.Drawing.Point(54, 58)
        Me.pictDataFields.Name = "pictDataFields"
        Me.pictDataFields.Size = New System.Drawing.Size(72, 48)
        Me.pictDataFields.TabIndex = 97
        Me.pictDataFields.TabStop = False
        '
        'FormFieldsVsElements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 416)
        Me.Controls.Add(Me.pictDataFields)
        Me.Controls.Add(Me.pictAddElements)
        Me.Controls.Add(Me.pictBackground)
        Me.Controls.Add(Me.ButtonAddElementsH)
        Me.Controls.Add(Me.ButtonBackgroundImage)
        Me.Controls.Add(Me.LabelAddingElementsHdr)
        Me.Controls.Add(Me.LabelFooter2)
        Me.Controls.Add(Me.LabelFooter1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonAddElements)
        Me.Controls.Add(Me.ButtonAddFields)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FormFieldsVsElements"
        Me.Text = "FormFieldsVsElements"
        CType(Me.pictBackground, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictAddElements, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictDataFields, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonAddFields As Button
    Friend WithEvents ButtonAddElements As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents LabelFooter1 As Label
    Friend WithEvents LabelFooter2 As Label
    Friend WithEvents LabelAddingElementsHdr As Label
    Friend WithEvents ButtonBackgroundImage As Button
    Friend WithEvents ButtonAddElementsH As Button
    Friend WithEvents pictBackground As PictureBox
    Friend WithEvents pictAddElements As PictureBox
    Friend WithEvents pictDataFields As PictureBox
End Class
