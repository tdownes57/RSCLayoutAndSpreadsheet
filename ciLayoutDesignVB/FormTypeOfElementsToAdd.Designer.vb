<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTypeOfElementsToAdd
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
        Me.pictureBackgroundFront = New System.Windows.Forms.PictureBox()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.LabelMainHeader1 = New System.Windows.Forms.Label()
        Me.CtlGraphicStaticText1 = New ciBadgeDesigner.CtlGraphicStaticTextV4()
        Me.CtlGraphicQRCode1 = New ciBadgeDesigner.CtlGraphicQRCode()
        Me.CtlGraphicPortrait1 = New ciBadgeDesigner.CtlGraphicPortrait()
        Me.CtlGraphicSignature1 = New ciBadgeDesigner.CtlGraphicSignature()
        Me.RscSelectCIBField1 = New ciBadgeDesigner.RSCSelectCIBField()
        Me.LabelMainHeader2 = New System.Windows.Forms.Label()
        Me.CtlGraphicStaticGraphic1 = New ciBadgeDesigner.CtlGraphicStaticGraphic()
        Me.LabelMainHeader3 = New System.Windows.Forms.Label()
        Me.LabelMainHeader0 = New System.Windows.Forms.Label()
        Me.LabelFooter1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.pictureBackgroundFront, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureBackgroundFront
        '
        Me.pictureBackgroundFront.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pictureBackgroundFront.BackColor = System.Drawing.Color.White
        Me.pictureBackgroundFront.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBackgroundFront.Location = New System.Drawing.Point(20, 144)
        Me.pictureBackgroundFront.Name = "pictureBackgroundFront"
        Me.pictureBackgroundFront.Size = New System.Drawing.Size(603, 380)
        Me.pictureBackgroundFront.TabIndex = 75
        Me.pictureBackgroundFront.TabStop = False
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(512, 573)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(131, 37)
        Me.ButtonCancel.TabIndex = 93
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(379, 573)
        Me.ButtonOK.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(127, 37)
        Me.ButtonOK.TabIndex = 92
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'LabelMainHeader1
        '
        Me.LabelMainHeader1.AutoSize = True
        Me.LabelMainHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMainHeader1.Location = New System.Drawing.Point(16, 45)
        Me.LabelMainHeader1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelMainHeader1.Name = "LabelMainHeader1"
        Me.LabelMainHeader1.Size = New System.Drawing.Size(513, 20)
        Me.LabelMainHeader1.TabIndex = 94
        Me.LabelMainHeader1.Text = "Select which types of elements you want to add to the ID Card."
        '
        'CtlGraphicStaticText1
        '
        Me.CtlGraphicStaticText1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CtlGraphicStaticText1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CtlGraphicStaticText1.ElementClass_Obj = Nothing
        Me.CtlGraphicStaticText1.ElementInfo_Base = Nothing
        Me.CtlGraphicStaticText1.Location = New System.Drawing.Point(275, 250)
        Me.CtlGraphicStaticText1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CtlGraphicStaticText1.MoveabilityEventsForGroupCtls = Nothing
        Me.CtlGraphicStaticText1.MoveabilityEventsForSingleMove = Nothing
        Me.CtlGraphicStaticText1.Name = "CtlGraphicStaticText1"
        Me.CtlGraphicStaticText1.Size = New System.Drawing.Size(302, 27)
        Me.CtlGraphicStaticText1.TabIndex = 98
        Me.CtlGraphicStaticText1.TextToDisplay = "This is text which will be the same for everyone."
        Me.CtlGraphicStaticText1.TextToDisplay_DesignTime = "Text Label..."
        Me.ToolTip1.SetToolTip(Me.CtlGraphicStaticText1, "Static text.  The text which will be the same for every ID Card.")
        '
        'CtlGraphicQRCode1
        '
        Me.CtlGraphicQRCode1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CtlGraphicQRCode1.BackColor = System.Drawing.Color.Transparent
        Me.CtlGraphicQRCode1.ElementInfo_Base = Nothing
        Me.CtlGraphicQRCode1.Location = New System.Drawing.Point(512, 409)
        Me.CtlGraphicQRCode1.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlGraphicQRCode1.MoveabilityEventsForGroupCtls = Nothing
        Me.CtlGraphicQRCode1.MoveabilityEventsForSingleMove = Nothing
        Me.CtlGraphicQRCode1.Name = "CtlGraphicQRCode1"
        Me.CtlGraphicQRCode1.Size = New System.Drawing.Size(94, 100)
        Me.CtlGraphicQRCode1.TabIndex = 96
        Me.ToolTip1.SetToolTip(Me.CtlGraphicQRCode1, "QR Code.  Static, i.e. will be the same for every ID Card.")
        '
        'CtlGraphicPortrait1
        '
        Me.CtlGraphicPortrait1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CtlGraphicPortrait1.BackColor = System.Drawing.Color.White
        Me.CtlGraphicPortrait1.ElementInfo_Base = Nothing
        Me.CtlGraphicPortrait1.Location = New System.Drawing.Point(50, 160)
        Me.CtlGraphicPortrait1.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlGraphicPortrait1.MoveabilityEventsForGroupCtls = Nothing
        Me.CtlGraphicPortrait1.MoveabilityEventsForSingleMove = Nothing
        Me.CtlGraphicPortrait1.Name = "CtlGraphicPortrait1"
        Me.CtlGraphicPortrait1.Size = New System.Drawing.Size(123, 181)
        Me.CtlGraphicPortrait1.TabIndex = 95
        Me.ToolTip1.SetToolTip(Me.CtlGraphicPortrait1, "Photo of student, member, or staffperson.")
        '
        'CtlGraphicSignature1
        '
        Me.CtlGraphicSignature1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CtlGraphicSignature1.BackColor = System.Drawing.Color.Transparent
        Me.CtlGraphicSignature1.ElementInfo_Base = Nothing
        Me.CtlGraphicSignature1.Location = New System.Drawing.Point(50, 388)
        Me.CtlGraphicSignature1.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlGraphicSignature1.MoveabilityEventsForGroupCtls = Nothing
        Me.CtlGraphicSignature1.MoveabilityEventsForSingleMove = Nothing
        Me.CtlGraphicSignature1.Name = "CtlGraphicSignature1"
        Me.CtlGraphicSignature1.Size = New System.Drawing.Size(314, 104)
        Me.CtlGraphicSignature1.TabIndex = 97
        Me.ToolTip1.SetToolTip(Me.CtlGraphicSignature1, "Signature.  Will differ for each student, member, or staffperson.")
        '
        'RscSelectCIBField1
        '
        Me.RscSelectCIBField1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RscSelectCIBField1.Location = New System.Drawing.Point(182, 303)
        Me.RscSelectCIBField1.Margin = New System.Windows.Forms.Padding(2)
        Me.RscSelectCIBField1.Name = "RscSelectCIBField1"
        Me.RscSelectCIBField1.SelectedValue = ciBadgeInterfaces.ModEnumsAndStructs.EnumCIBFields.Undetermined
        Me.RscSelectCIBField1.Size = New System.Drawing.Size(182, 64)
        Me.RscSelectCIBField1.TabIndex = 99
        Me.ToolTip1.SetToolTip(Me.RscSelectCIBField1, "Relevant Field value.   Will differ for each student, member, or staffperson. ")
        '
        'LabelMainHeader2
        '
        Me.LabelMainHeader2.AutoSize = True
        Me.LabelMainHeader2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMainHeader2.Location = New System.Drawing.Point(17, 76)
        Me.LabelMainHeader2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelMainHeader2.Name = "LabelMainHeader2"
        Me.LabelMainHeader2.Size = New System.Drawing.Size(645, 17)
        Me.LabelMainHeader2.TabIndex = 100
        Me.LabelMainHeader2.Text = "(Click to select.  Selected elements will have a blue border. Click the element a" &
    " 2nd time to un-select.)"
        '
        'CtlGraphicStaticGraphic1
        '
        Me.CtlGraphicStaticGraphic1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CtlGraphicStaticGraphic1.BackColor = System.Drawing.Color.Transparent
        Me.CtlGraphicStaticGraphic1.ElementInfo_Base = Nothing
        Me.CtlGraphicStaticGraphic1.Location = New System.Drawing.Point(206, 161)
        Me.CtlGraphicStaticGraphic1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CtlGraphicStaticGraphic1.MoveabilityEventsForGroupCtls = Nothing
        Me.CtlGraphicStaticGraphic1.MoveabilityEventsForSingleMove = Nothing
        Me.CtlGraphicStaticGraphic1.Name = "CtlGraphicStaticGraphic1"
        Me.CtlGraphicStaticGraphic1.Size = New System.Drawing.Size(356, 74)
        Me.CtlGraphicStaticGraphic1.TabIndex = 101
        Me.ToolTip1.SetToolTip(Me.CtlGraphicStaticGraphic1, "Graphic element.  Can be a photo or any graphic. ")
        '
        'LabelMainHeader3
        '
        Me.LabelMainHeader3.AutoSize = True
        Me.LabelMainHeader3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMainHeader3.Location = New System.Drawing.Point(17, 100)
        Me.LabelMainHeader3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelMainHeader3.Name = "LabelMainHeader3"
        Me.LabelMainHeader3.Size = New System.Drawing.Size(668, 17)
        Me.LabelMainHeader3.TabIndex = 102
        Me.LabelMainHeader3.Text = "(Content of graphic elements is easily modified by right-clicking the element fro" &
    "m the main design dialog.)"
        '
        'LabelMainHeader0
        '
        Me.LabelMainHeader0.AutoSize = True
        Me.LabelMainHeader0.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMainHeader0.Location = New System.Drawing.Point(15, 9)
        Me.LabelMainHeader0.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelMainHeader0.Name = "LabelMainHeader0"
        Me.LabelMainHeader0.Size = New System.Drawing.Size(317, 26)
        Me.LabelMainHeader0.TabIndex = 103
        Me.LabelMainHeader0.Text = "Add Elements to the ID Card"
        '
        'LabelFooter1
        '
        Me.LabelFooter1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelFooter1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFooter1.Location = New System.Drawing.Point(17, 529)
        Me.LabelFooter1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelFooter1.Name = "LabelFooter1"
        Me.LabelFooter1.Size = New System.Drawing.Size(535, 42)
        Me.LabelFooter1.TabIndex = 104
        Me.LabelFooter1.Text = "P.S. This dialog is for adding elements, not removing them.  To remove an element" &
    " on the main design dialog, right-click it and select ""Delete"" (or ""Remove"")."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 124)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(272, 17)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "(All elements are moveable and sizeable.)"
        '
        'FormTypeOfElementsToAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 621)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelMainHeader0)
        Me.Controls.Add(Me.LabelMainHeader3)
        Me.Controls.Add(Me.CtlGraphicStaticGraphic1)
        Me.Controls.Add(Me.LabelMainHeader2)
        Me.Controls.Add(Me.RscSelectCIBField1)
        Me.Controls.Add(Me.CtlGraphicStaticText1)
        Me.Controls.Add(Me.CtlGraphicQRCode1)
        Me.Controls.Add(Me.CtlGraphicPortrait1)
        Me.Controls.Add(Me.CtlGraphicSignature1)
        Me.Controls.Add(Me.LabelMainHeader1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.pictureBackgroundFront)
        Me.Controls.Add(Me.LabelFooter1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormTypeOfElementsToAdd"
        Me.Text = "FormTypeOfElementsToAdd"
        CType(Me.pictureBackgroundFront, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pictureBackgroundFront As PictureBox
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents LabelMainHeader1 As Label
    Friend WithEvents CtlGraphicQRCode1 As ciBadgeDesigner.CtlGraphicQRCode
    Friend WithEvents CtlGraphicPortrait1 As ciBadgeDesigner.CtlGraphicPortrait
    Friend WithEvents CtlGraphicSignature1 As ciBadgeDesigner.CtlGraphicSignature
    Friend WithEvents CtlGraphicStaticText1 As ciBadgeDesigner.CtlGraphicStaticTextV4
    Friend WithEvents RscSelectCIBField1 As ciBadgeDesigner.RSCSelectCIBField
    Friend WithEvents LabelMainHeader2 As Label
    Friend WithEvents CtlGraphicStaticGraphic1 As ciBadgeDesigner.CtlGraphicStaticGraphic
    Friend WithEvents LabelMainHeader3 As Label
    Friend WithEvents LabelMainHeader0 As Label
    Friend WithEvents LabelFooter1 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
