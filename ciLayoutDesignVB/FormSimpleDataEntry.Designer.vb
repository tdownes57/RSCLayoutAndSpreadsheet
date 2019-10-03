Imports ciBadgeDesigner

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSimpleDataEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSimpleDataEntry))
        Me.CtlMainEntryBox_v901 = New ciLayoutDesignVB.CtlMainEntryBox_v90()
        Me.CtlMainEntryBox_v902 = New ciLayoutDesignVB.CtlMainEntryBox_v90()
        Me.CtlMainEntryBox_v903 = New ciLayoutDesignVB.CtlMainEntryBox_v90()
        Me.pictureBack = New System.Windows.Forms.PictureBox()
        Me.lblRecipientID = New System.Windows.Forms.Label()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.CtlGraphicPortrait_Lady = New ciLayoutDesignVB.CtlGraphicPortrait()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.CtlMainEntryBox_v904 = New ciLayoutDesignVB.CtlMainEntryBox_v90()
        CType(Me.pictureBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CtlMainEntryBox_v901
        '
        Me.CtlMainEntryBox_v901.Location = New System.Drawing.Point(23, 147)
        Me.CtlMainEntryBox_v901.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CtlMainEntryBox_v901.Name = "CtlMainEntryBox_v901"
        Me.CtlMainEntryBox_v901.Size = New System.Drawing.Size(266, 34)
        Me.CtlMainEntryBox_v901.TabIndex = 0
        '
        'CtlMainEntryBox_v902
        '
        Me.CtlMainEntryBox_v902.Location = New System.Drawing.Point(23, 100)
        Me.CtlMainEntryBox_v902.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CtlMainEntryBox_v902.Name = "CtlMainEntryBox_v902"
        Me.CtlMainEntryBox_v902.Size = New System.Drawing.Size(266, 34)
        Me.CtlMainEntryBox_v902.TabIndex = 1
        '
        'CtlMainEntryBox_v903
        '
        Me.CtlMainEntryBox_v903.Location = New System.Drawing.Point(23, 194)
        Me.CtlMainEntryBox_v903.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CtlMainEntryBox_v903.Name = "CtlMainEntryBox_v903"
        Me.CtlMainEntryBox_v903.Size = New System.Drawing.Size(266, 34)
        Me.CtlMainEntryBox_v903.TabIndex = 2
        '
        'pictureBack
        '
        Me.pictureBack.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pictureBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBack.Image = CType(resources.GetObject("pictureBack.Image"), System.Drawing.Image)
        Me.pictureBack.Location = New System.Drawing.Point(307, 30)
        Me.pictureBack.Margin = New System.Windows.Forms.Padding(2)
        Me.pictureBack.Name = "pictureBack"
        Me.pictureBack.Size = New System.Drawing.Size(681, 425)
        Me.pictureBack.TabIndex = 22
        Me.pictureBack.TabStop = False
        '
        'lblRecipientID
        '
        Me.lblRecipientID.AutoSize = True
        Me.lblRecipientID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecipientID.Location = New System.Drawing.Point(19, 64)
        Me.lblRecipientID.Name = "lblRecipientID"
        Me.lblRecipientID.Size = New System.Drawing.Size(101, 24)
        Me.lblRecipientID.TabIndex = 23
        Me.lblRecipientID.Text = "Student ID:"
        '
        'ButtonSave
        '
        Me.ButtonSave.Location = New System.Drawing.Point(176, 425)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(113, 30)
        Me.ButtonSave.TabIndex = 24
        Me.ButtonSave.Text = "Save"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'CtlGraphicPortrait_Lady
        '
        Me.CtlGraphicPortrait_Lady.Location = New System.Drawing.Point(23, 302)
        Me.CtlGraphicPortrait_Lady.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlGraphicPortrait_Lady.Name = "CtlGraphicPortrait_Lady"
        Me.CtlGraphicPortrait_Lady.Size = New System.Drawing.Size(120, 153)
        Me.CtlGraphicPortrait_Lady.TabIndex = 42
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(20, 30)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(131, 24)
        Me.LinkLabel1.TabIndex = 43
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Select Student"
        '
        'CtlMainEntryBox_v904
        '
        Me.CtlMainEntryBox_v904.Location = New System.Drawing.Point(23, 241)
        Me.CtlMainEntryBox_v904.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CtlMainEntryBox_v904.Name = "CtlMainEntryBox_v904"
        Me.CtlMainEntryBox_v904.Size = New System.Drawing.Size(266, 34)
        Me.CtlMainEntryBox_v904.TabIndex = 44
        '
        'FormSimpleDataEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 482)
        Me.Controls.Add(Me.CtlMainEntryBox_v904)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.CtlGraphicPortrait_Lady)
        Me.Controls.Add(Me.ButtonSave)
        Me.Controls.Add(Me.lblRecipientID)
        Me.Controls.Add(Me.pictureBack)
        Me.Controls.Add(Me.CtlMainEntryBox_v903)
        Me.Controls.Add(Me.CtlMainEntryBox_v902)
        Me.Controls.Add(Me.CtlMainEntryBox_v901)
        Me.Name = "FormSimpleDataEntry"
        Me.Text = "FormSimpleDataEntry"
        CType(Me.pictureBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CtlMainEntryBox_v901 As CtlMainEntryBox_v90
    Friend WithEvents CtlMainEntryBox_v902 As CtlMainEntryBox_v90
    Friend WithEvents CtlMainEntryBox_v903 As CtlMainEntryBox_v90
    Friend WithEvents pictureBack As PictureBox
    Friend WithEvents lblRecipientID As Label
    Friend WithEvents ButtonSave As Button
    Friend WithEvents CtlGraphicPortrait_Lady As CtlGraphicPortrait
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents CtlMainEntryBox_v904 As CtlMainEntryBox_v90
End Class
