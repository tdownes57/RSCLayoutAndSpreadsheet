Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLayoutEg
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLayoutEg))
        Me.picturePureWhite = New System.Windows.Forms.PictureBox()
        Me.pictureboxReview = New System.Windows.Forms.PictureBox()
        Me.PicturePersonLarge = New System.Windows.Forms.PictureBox()
        Me.panelLayout = New System.Windows.Forms.Panel()
        Me.PicturePersonInLayout = New System.Windows.Forms.PictureBox()
        Me.LabelRecipientID = New System.Windows.Forms.Label()
        Me.labelRecipientName = New System.Windows.Forms.Label()
        CType(Me.picturePureWhite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureboxReview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicturePersonLarge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelLayout.SuspendLayout()
        CType(Me.PicturePersonInLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picturePureWhite
        '
        Me.picturePureWhite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePureWhite.Image = CType(resources.GetObject("picturePureWhite.Image"), System.Drawing.Image)
        Me.picturePureWhite.Location = New System.Drawing.Point(311, 15)
        Me.picturePureWhite.Margin = New System.Windows.Forms.Padding(4)
        Me.picturePureWhite.Name = "picturePureWhite"
        Me.picturePureWhite.Size = New System.Drawing.Size(58, 43)
        Me.picturePureWhite.TabIndex = 30
        Me.picturePureWhite.TabStop = False
        Me.picturePureWhite.Visible = False
        '
        'pictureboxReview
        '
        Me.pictureboxReview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureboxReview.Image = CType(resources.GetObject("pictureboxReview.Image"), System.Drawing.Image)
        Me.pictureboxReview.Location = New System.Drawing.Point(1261, 44)
        Me.pictureboxReview.Margin = New System.Windows.Forms.Padding(4)
        Me.pictureboxReview.Name = "pictureboxReview"
        Me.pictureboxReview.Size = New System.Drawing.Size(277, 396)
        Me.pictureboxReview.TabIndex = 23
        Me.pictureboxReview.TabStop = False
        '
        'PicturePersonLarge
        '
        Me.PicturePersonLarge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicturePersonLarge.Image = Global.ciLayoutPrintLib.My.Resources.Resources.v9_lady
        Me.PicturePersonLarge.Location = New System.Drawing.Point(23, 156)
        Me.PicturePersonLarge.Margin = New System.Windows.Forms.Padding(4)
        Me.PicturePersonLarge.Name = "PicturePersonLarge"
        Me.PicturePersonLarge.Size = New System.Drawing.Size(300, 380)
        Me.PicturePersonLarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicturePersonLarge.TabIndex = 19
        Me.PicturePersonLarge.TabStop = False
        '
        'panelLayout
        '
        Me.panelLayout.BackColor = System.Drawing.Color.White
        Me.panelLayout.BackgroundImage = CType(resources.GetObject("panelLayout.BackgroundImage"), System.Drawing.Image)
        Me.panelLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.panelLayout.Controls.Add(Me.PicturePersonInLayout)
        Me.panelLayout.Controls.Add(Me.LabelRecipientID)
        Me.panelLayout.Controls.Add(Me.labelRecipientName)
        Me.panelLayout.Location = New System.Drawing.Point(377, 44)
        Me.panelLayout.Margin = New System.Windows.Forms.Padding(4)
        Me.panelLayout.Name = "panelLayout"
        Me.panelLayout.Size = New System.Drawing.Size(859, 492)
        Me.panelLayout.TabIndex = 9
        '
        'PicturePersonInLayout
        '
        Me.PicturePersonInLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicturePersonInLayout.Location = New System.Drawing.Point(537, 206)
        Me.PicturePersonInLayout.Margin = New System.Windows.Forms.Padding(4)
        Me.PicturePersonInLayout.Name = "PicturePersonInLayout"
        Me.PicturePersonInLayout.Size = New System.Drawing.Size(226, 270)
        Me.PicturePersonInLayout.TabIndex = 2
        Me.PicturePersonInLayout.TabStop = False
        '
        'LabelRecipientID
        '
        Me.LabelRecipientID.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRecipientID.Location = New System.Drawing.Point(32, 325)
        Me.LabelRecipientID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelRecipientID.Name = "LabelRecipientID"
        Me.LabelRecipientID.Size = New System.Drawing.Size(261, 34)
        Me.LabelRecipientID.TabIndex = 1
        Me.LabelRecipientID.Text = "Student or Employee ID"
        Me.LabelRecipientID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelRecipientName
        '
        Me.labelRecipientName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelRecipientName.Location = New System.Drawing.Point(32, 394)
        Me.labelRecipientName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelRecipientName.Name = "labelRecipientName"
        Me.labelRecipientName.Size = New System.Drawing.Size(497, 41)
        Me.labelRecipientName.TabIndex = 0
        Me.labelRecipientName.Text = "Student or Employee Name"
        Me.labelRecipientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormLayoutEg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1597, 552)
        Me.Controls.Add(Me.picturePureWhite)
        Me.Controls.Add(Me.pictureboxReview)
        Me.Controls.Add(Me.PicturePersonLarge)
        Me.Controls.Add(Me.panelLayout)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormLayoutEg"
        Me.Text = "FormLayoutEg"
        CType(Me.picturePureWhite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureboxReview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicturePersonLarge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelLayout.ResumeLayout(False)
        CType(Me.PicturePersonInLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelLayout As Panel
    Friend WithEvents labelRecipientName As Label
    Friend WithEvents LabelRecipientID As Label
    Friend WithEvents PicturePersonInLayout As PictureBox
    Friend WithEvents PicturePersonLarge As PictureBox
    Friend WithEvents pictureboxReview As PictureBox
    Friend WithEvents picturePureWhite As PictureBox
End Class
