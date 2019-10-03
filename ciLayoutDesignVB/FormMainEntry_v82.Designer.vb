Imports ciBadgeDesigner

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.txtNameFirst = New ciLayoutDesignVB.CtlMainEntryBox_v82()
        Me.CtlMainStep3_v821 = New ciLayoutDesignVB.CtlMainStep3_v82()
        Me.txtNameLast = New ciLayoutDesignVB.CtlMainEntryBox_v82()
        Me.txtID = New ciLayoutDesignVB.CtlMainEntryBox_v82()
        Me.DateField01 = New ciLayoutDesignVB.CtlMainEntryBox_v82()
        Me.SearchByLastNm = New ciLayoutDesignVB.CtlMainEntryBox_v82()
        Me.CtlMainEntryBox_v821 = New ciLayoutDesignVB.CtlMainEntryBox_v82()
        Me.SuspendLayout()
        '
        'CtlGraphicPortrait1
        '
        Me.CtlGraphicPortrait1.Location = New System.Drawing.Point(926, 294)
        Me.CtlGraphicPortrait1.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlGraphicPortrait1.Name = "CtlGraphicPortrait1"
        Me.CtlGraphicPortrait1.Size = New System.Drawing.Size(266, 344)
        Me.CtlGraphicPortrait1.TabIndex = 0
        '
        'txtNameFirst
        '
        Me.txtNameFirst.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNameFirst.BackgroundImage = CType(resources.GetObject("txtNameFirst.BackgroundImage"), System.Drawing.Image)
        Me.txtNameFirst.FieldValue = ""
        Me.txtNameFirst.LabelText = "First:"
        Me.txtNameFirst.Location = New System.Drawing.Point(13, 229)
        Me.txtNameFirst.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNameFirst.Name = "txtNameFirst"
        Me.txtNameFirst.Size = New System.Drawing.Size(405, 45)
        Me.txtNameFirst.TabIndex = 1
        Me.txtNameFirst.WidthOfBoxByPercent = 67
        '
        'CtlMainStep3_v821
        '
        Me.CtlMainStep3_v821.BackColor = System.Drawing.Color.CornflowerBlue
        Me.CtlMainStep3_v821.BackgroundImage = CType(resources.GetObject("CtlMainStep3_v821.BackgroundImage"), System.Drawing.Image)
        Me.CtlMainStep3_v821.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CtlMainStep3_v821.Location = New System.Drawing.Point(921, 171)
        Me.CtlMainStep3_v821.Name = "CtlMainStep3_v821"
        Me.CtlMainStep3_v821.Size = New System.Drawing.Size(279, 125)
        Me.CtlMainStep3_v821.TabIndex = 2
        '
        'txtNameLast
        '
        Me.txtNameLast.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNameLast.BackgroundImage = CType(resources.GetObject("txtNameLast.BackgroundImage"), System.Drawing.Image)
        Me.txtNameLast.FieldValue = ""
        Me.txtNameLast.LabelText = "Last:"
        Me.txtNameLast.Location = New System.Drawing.Point(13, 267)
        Me.txtNameLast.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNameLast.Name = "txtNameLast"
        Me.txtNameLast.Size = New System.Drawing.Size(405, 45)
        Me.txtNameLast.TabIndex = 3
        Me.txtNameLast.WidthOfBoxByPercent = 67
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtID.BackgroundImage = CType(resources.GetObject("txtID.BackgroundImage"), System.Drawing.Image)
        Me.txtID.FieldValue = "12345"
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.ForeColor = System.Drawing.Color.Crimson
        Me.txtID.LabelText = "ID Number:"
        Me.txtID.Location = New System.Drawing.Point(25, 320)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(381, 38)
        Me.txtID.TabIndex = 5
        Me.txtID.WidthOfBoxByPercent = 60
        '
        'DateField01
        '
        Me.DateField01.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DateField01.BackgroundImage = CType(resources.GetObject("DateField01.BackgroundImage"), System.Drawing.Image)
        Me.DateField01.FieldValue = "12345"
        Me.DateField01.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateField01.ForeColor = System.Drawing.Color.Black
        Me.DateField01.LabelText = "Date Entered:"
        Me.DateField01.Location = New System.Drawing.Point(25, 355)
        Me.DateField01.Margin = New System.Windows.Forms.Padding(4)
        Me.DateField01.Name = "DateField01"
        Me.DateField01.Size = New System.Drawing.Size(381, 38)
        Me.DateField01.TabIndex = 6
        Me.DateField01.WidthOfBoxByPercent = 60
        '
        'SearchByLastNm
        '
        Me.SearchByLastNm.BackColor = System.Drawing.Color.LightSkyBlue
        Me.SearchByLastNm.BackgroundImage = CType(resources.GetObject("SearchByLastNm.BackgroundImage"), System.Drawing.Image)
        Me.SearchByLastNm.FieldValue = "12345"
        Me.SearchByLastNm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchByLastNm.ForeColor = System.Drawing.Color.Black
        Me.SearchByLastNm.LabelText = "Last:"
        Me.SearchByLastNm.Location = New System.Drawing.Point(384, 70)
        Me.SearchByLastNm.Margin = New System.Windows.Forms.Padding(4)
        Me.SearchByLastNm.Name = "SearchByLastNm"
        Me.SearchByLastNm.Size = New System.Drawing.Size(328, 38)
        Me.SearchByLastNm.TabIndex = 7
        Me.SearchByLastNm.WidthOfBoxByPercent = 79
        '
        'CtlMainEntryBox_v821
        '
        Me.CtlMainEntryBox_v821.BackColor = System.Drawing.Color.LightSkyBlue
        Me.CtlMainEntryBox_v821.BackgroundImage = CType(resources.GetObject("CtlMainEntryBox_v821.BackgroundImage"), System.Drawing.Image)
        Me.CtlMainEntryBox_v821.FieldValue = "12345"
        Me.CtlMainEntryBox_v821.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtlMainEntryBox_v821.ForeColor = System.Drawing.Color.Black
        Me.CtlMainEntryBox_v821.LabelText = "DL Number:"
        Me.CtlMainEntryBox_v821.Location = New System.Drawing.Point(25, 389)
        Me.CtlMainEntryBox_v821.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlMainEntryBox_v821.Name = "CtlMainEntryBox_v821"
        Me.CtlMainEntryBox_v821.Size = New System.Drawing.Size(381, 38)
        Me.CtlMainEntryBox_v821.TabIndex = 8
        Me.CtlMainEntryBox_v821.WidthOfBoxByPercent = 60
        '
        'FormMainEntry_v82
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ciLayoutDesignVB.My.Resources.Resources.__UI_for_V831_v101
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1311, 901)
        Me.Controls.Add(Me.CtlMainEntryBox_v821)
        Me.Controls.Add(Me.SearchByLastNm)
        Me.Controls.Add(Me.DateField01)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.txtNameLast)
        Me.Controls.Add(Me.CtlMainStep3_v821)
        Me.Controls.Add(Me.txtNameFirst)
        Me.Controls.Add(Me.CtlGraphicPortrait1)
        Me.DoubleBuffered = True
        Me.Name = "FormMainEntry_v82"
        Me.Text = "FormMainEntry_v82"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CtlGraphicPortrait1 As CtlGraphicPortrait
    Friend WithEvents txtNameFirst As CtlMainEntryBox_v82
    Friend WithEvents CtlMainStep3_v821 As CtlMainStep3_v82
    Friend WithEvents txtNameLast As CtlMainEntryBox_v82
    Friend WithEvents txtID As CtlMainEntryBox_v82
    Friend WithEvents DateField01 As CtlMainEntryBox_v82
    Friend WithEvents SearchByLastNm As CtlMainEntryBox_v82
    Friend WithEvents CtlMainEntryBox_v821 As CtlMainEntryBox_v82
End Class
