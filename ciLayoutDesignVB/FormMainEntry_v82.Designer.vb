<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMainEntry_v82
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMainEntry_v82))
        Me.CtlGraphicPortrait1 = New ciLayoutDesignVB.CtlGraphicPortrait()
        Me.CtlMainEntryBox_v821 = New ciLayoutDesignVB.CtlMainEntryBox_v82()
        Me.CtlMainStep3_v821 = New ciLayoutDesignVB.CtlMainStep3_v82()
        Me.CtlMainEntryBox_v822 = New ciLayoutDesignVB.CtlMainEntryBox_v82()
        Me.SuspendLayout()
        '
        'CtlGraphicPortrait1
        '
        Me.CtlGraphicPortrait1.Location = New System.Drawing.Point(921, 293)
        Me.CtlGraphicPortrait1.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlGraphicPortrait1.Name = "CtlGraphicPortrait1"
        Me.CtlGraphicPortrait1.Size = New System.Drawing.Size(279, 311)
        Me.CtlGraphicPortrait1.TabIndex = 0
        '
        'CtlMainEntryBox_v821
        '
        Me.CtlMainEntryBox_v821.BackColor = System.Drawing.Color.LightSkyBlue
        Me.CtlMainEntryBox_v821.BackgroundImage = CType(resources.GetObject("CtlMainEntryBox_v821.BackgroundImage"), System.Drawing.Image)
        Me.CtlMainEntryBox_v821.LabelText = "First:"
        Me.CtlMainEntryBox_v821.Location = New System.Drawing.Point(13, 229)
        Me.CtlMainEntryBox_v821.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlMainEntryBox_v821.Name = "CtlMainEntryBox_v821"
        Me.CtlMainEntryBox_v821.Size = New System.Drawing.Size(405, 45)
        Me.CtlMainEntryBox_v821.TabIndex = 1
        Me.CtlMainEntryBox_v821.WidthOfBoxByPercent = 67
        '
        'CtlMainStep3_v821
        '
        Me.CtlMainStep3_v821.BackColor = System.Drawing.Color.CornflowerBlue
        Me.CtlMainStep3_v821.BackgroundImage = CType(resources.GetObject("CtlMainStep3_v821.BackgroundImage"), System.Drawing.Image)
        Me.CtlMainStep3_v821.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CtlMainStep3_v821.Location = New System.Drawing.Point(921, 161)
        Me.CtlMainStep3_v821.Name = "CtlMainStep3_v821"
        Me.CtlMainStep3_v821.Size = New System.Drawing.Size(279, 135)
        Me.CtlMainStep3_v821.TabIndex = 2
        '
        'CtlMainEntryBox_v822
        '
        Me.CtlMainEntryBox_v822.BackColor = System.Drawing.Color.LightSkyBlue
        Me.CtlMainEntryBox_v822.BackgroundImage = CType(resources.GetObject("CtlMainEntryBox_v822.BackgroundImage"), System.Drawing.Image)
        Me.CtlMainEntryBox_v822.LabelText = "Last:"
        Me.CtlMainEntryBox_v822.Location = New System.Drawing.Point(13, 267)
        Me.CtlMainEntryBox_v822.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlMainEntryBox_v822.Name = "CtlMainEntryBox_v822"
        Me.CtlMainEntryBox_v822.Size = New System.Drawing.Size(405, 45)
        Me.CtlMainEntryBox_v822.TabIndex = 3
        Me.CtlMainEntryBox_v822.WidthOfBoxByPercent = 67
        '
        'FormMainEntry_v82
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.__UI_for_V831_v101
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1311, 901)
        Me.Controls.Add(Me.CtlMainEntryBox_v822)
        Me.Controls.Add(Me.CtlMainStep3_v821)
        Me.Controls.Add(Me.CtlMainEntryBox_v821)
        Me.Controls.Add(Me.CtlGraphicPortrait1)
        Me.DoubleBuffered = True
        Me.Name = "FormMainEntry_v82"
        Me.Text = "FormMainEntry_v82"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CtlGraphicPortrait1 As CtlGraphicPortrait
    Friend WithEvents CtlMainEntryBox_v821 As CtlMainEntryBox_v82
    Friend WithEvents CtlMainStep3_v821 As CtlMainStep3_v82
    Friend WithEvents CtlMainEntryBox_v822 As CtlMainEntryBox_v82
End Class
