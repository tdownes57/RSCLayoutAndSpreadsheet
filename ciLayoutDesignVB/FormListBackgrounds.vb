''
''Added 11/25/2021 thomas downes
''
Imports ciLayoutPrintLib ''added 11/25 

Public Class FormListBackgrounds

    Public DemoMode As Boolean ''Added 5/13/2022 thomas downes
    Public ImageFilePath As String
    Public ImageFileInfo As System.IO.FileInfo

    Public TemporarySelectedFileInfo As System.IO.FileInfo

    ''
    ''Added 11/25/2021 thomas downes
    ''
    Public Sub ChangeHeaderLabelCaption()
        ''
        ''Added 5/13/2022 
        ''
        If (Me.DemoMode) Then

            LabelHeading1.Text = "Background, Demo Mode"

        Else
            LabelHeading1.Text = "Select Background Image"

        End If ''End of ""If (Me.DemoMode) Then... Else ..." 

    End Sub ''Endof ""Public Sub ChangeHeaderLabelCaption()""


    Public Sub LoadSelection(par_controlBack As CtlBackground)
        ''
        ''Added 11/25/2021 thomas downes
        ''
        Dim boolNotParameter As Boolean

        Me.TemporarySelectedFileInfo = par_controlBack.ImageFileInfo

        For Each ctlBack As CtlBackground In FlowLayoutPanel1.Controls

            boolNotParameter = (ctlBack IsNot par_controlBack)
            If (boolNotParameter) Then ctlBack.LoadIsSelectedValue(False)

        Next ctlBack

    End Sub

    Private Sub FormListBackgrounds_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 11/25/2021 thomas downes
        ''
        DeleteControlsDevoidOfData()

        ''5/13/2022 td ''LoadControlsFromFolderImagesBack()
        LoadControlsFromFolderImagesBack(Me.DemoMode)

        ''Added 5/13/2022 
        ChangeHeaderLabelCaption()

    End Sub

    Private Sub buttonOK_Click(sender As Object, e As EventArgs) Handles buttonOK.Click
        ''
        ''Added 11/25/2021 thomas downes
        ''
        Me.ImageFileInfo = Me.TemporarySelectedFileInfo
        Me.ImageFilePath = Me.TemporarySelectedFileInfo.FullName

        ''
        ''Open the dialog for addressing dimensional ratios.
        ''---12/2/2021 thomas d.
        ''
        Const c_bAddressDimensionalRatio As Boolean = False
        If (c_bAddressDimensionalRatio) Then
            Dim objChildDialog As New FormUploadDimensionsMsg
            objChildDialog.UploadedImageFile(Me.ImageFilePath)
            objChildDialog.ShowDialog()
        End If ''end of ""If (c_bAddressDimensionalRatio) Then""

        ''Close the form.  
        Me.Close()

    End Sub


    Private Sub DeleteControlsDevoidOfData()
        ''Added 11/25/2021 td
        ''---FlowLayoutPanel1.Controls.Clear()
        For Each each_ctlBack As CtlBackground In FlowLayoutPanel1.Controls
            If (each_ctlBack.ImageFileInfo Is Nothing) Then
                FlowLayoutPanel1.Controls.Remove(each_ctlBack)
            End If
        Next each_ctlBack
        ''Fuck it, let's just make sure it's all cleared. 
        If (0 < FlowLayoutPanel1.Controls.Count) Then
            ''Throw New Exception("Controls still left in FlowLayoutPanel.")
            FlowLayoutPanel1.Controls.Clear()
        End If
    End Sub ''End of ""Private Sub DeleteControlsDevoidOfData()""


    Private Sub LoadControlsFromFolderImagesBack(pboolExampleDemoImages As Boolean)
        ''
        '' added 11/25
        ''
        Dim boolNoneFound As Boolean ''Added 10/15/2019 td 
        Dim strFolderPath As String

        BackImageExamples.CurrentIndex += 1

        If (pboolExampleDemoImages) Then
            strFolderPath = DiskFolders.PathToFolder_BackExampleDemos
        Else
            ''Added 5/13/2022 thomas downes
            strFolderPath = DiskFolders.PathToFolder_BackgroundImages
        End If ''End of "If (pboolExampleDemoImages) Then ... Else... "

        BackImageExamples.PathToFolderWithBacks = strFolderPath

        ''//------Me.Designer.BackgroundBox.Image = BackImageExamples.GetCurrentImage(boolNoneFound)

        Dim listFiles As IO.FileInfo()
        listFiles = (New IO.DirectoryInfo(strFolderPath)).GetFiles("*.jpg") '' ("*.jpg,*.png")

        For Each eachFileInfo As IO.FileInfo In listFiles
            ''Added 11/25/2021 td
            Dim new_ctlBack As New CtlBackground()
            new_ctlBack.Visible = True
            FlowLayoutPanel1.Controls.Add(new_ctlBack)
            new_ctlBack.LoadImageFileByFileInfo(eachFileInfo, False)
            ''new_ctlBack.ParentForm = Me
            new_ctlBack.ParentListingForm = Me
        Next eachFileInfo

    End Sub ''End of "Private Sub LoadControlsFromFolderImagesBack()"

    Private Sub buttonCancel_Click(sender As Object, e As EventArgs) Handles buttonCancel.Click

        Me.Close() ''Added 11/26/2021 thomas downes 

    End Sub

    Private Sub CtlBackground2_Load(sender As Object, e As EventArgs) Handles CtlBackground2.Load

    End Sub

    Private Sub CtlBackground_Click(sender As Object, e As EventArgs) Handles CtlBackground2.Click
        ''
        ''Added 12/10/2021 thomas downes 
        ''
        ''Dim objControl As CtlBackground
        ''objControl = sender
        ''objControl.SetFocus  


    End Sub

    Private Sub buttonUpload_Click(sender As Object, e As EventArgs) _
        Handles buttonUpload1.Click, buttonUpload2.Click
        ''
        ''Added 12/10/2021 thomas downes
        ''
        Dim objFormToShow As New FormUploadBackground
        objFormToShow.AutoShowOpenFileDialog = True
        objFormToShow.ShowDialog()

    End Sub


    Private Sub ButtonShowDemos_Click(sender As Object, e As EventArgs) _
        Handles ButtonShowDemos1.Click, ButtonShowDemos2.Click
        ''
        ''Added 5/13/2022 td
        ''
        Me.DemoMode = True ''True, so that DemoMode is activated. . 
        ButtonShowDemos1.Visible = False
        ButtonShowDemos2.Visible = False
        ButtonRegularMode1.Visible = True ''True, so that Demo Mode can be turned off. 
        ButtonRegularMode2.Visible = True ''True, so that Demo Mode can be turned off. 
        FlowLayoutPanel1.Controls.Clear()
        LoadControlsFromFolderImagesBack(Me.DemoMode)
        ''Added 5/13/2022 
        ChangeHeaderLabelCaption()

    End Sub

    Private Sub ButtonRegularMode2_Click(sender As Object, e As EventArgs) _
        Handles ButtonRegularMode2.Click, ButtonRegularMode1.Click
        ''
        ''Added 5/13/2022 td
        ''
        Me.DemoMode = False ''False, so we can have Regular Mode instead. 
        ButtonShowDemos1.Visible = True ''True, so that Demo Mode can be turned on, if desired. 
        ButtonShowDemos2.Visible = True ''True, so that Demo Mode can be turned on, if desired. 
        ButtonRegularMode1.Visible = False
        ButtonRegularMode2.Visible = False
        FlowLayoutPanel1.Controls.Clear()
        LoadControlsFromFolderImagesBack(Me.DemoMode)
        ''Added 5/13/2022 
        ChangeHeaderLabelCaption()

    End Sub
End Class