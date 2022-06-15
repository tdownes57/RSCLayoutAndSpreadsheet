Option Explicit On ''5/17/2022 thomas downes
Option Strict On ''5/17/2022 thomas downes
''
''Added 11/25/2021 thomas downes
''
Imports ciLayoutPrintLib ''added 11/25 


Public Class FormBackgroundsSelect ''5/16/2022 Public Class FormListBackgrounds  
    ''5/16/2022 Public Class FormListBackgrounds 

    Public DemoMode As Boolean ''Added 5/13/2022 thomas downes

    ''These "Current" properties are (possibly) needed in case the current image is being deleted.--6/15/2022 
    Public CurrentBackgroundImagePath_Front As String ''Added 6/15/2022 thomas downes
    Public CurrentBackgroundImagePath_Back As String ''Added 6/15/2022 thomas downes

    Public Output_ImageFilePath As String
    Public Output_ImageFilePath_Temp As String ''Added 6/10/2022 thomas downes
    Public Output_ImageFileInfo As System.IO.FileInfo

    Public ImageDirectoryPath As String ''Add 5/23/202 

    Public TemporarySelectedFileInfo As System.IO.FileInfo
    ''Public Output_ImageFilePath As String ''Added 6/13/2022 thomas d.

    Private mod_strImageFiletitleEdited As String ''Added 5/20/2022

    Public ReadOnly Property EditedImage As Image
        Get
            ''
            ''Added 5/18/2022 td
            ''
            Return picturePreview.Image

        End Get
    End Property


    Public ReadOnly Property ImageFileLocation_Edited As String
        Get
            ''
            ''Added 5/18/2022 td
            ''
            ''---Dim strFileTitle_Edited As String
            ''---strFileTitle_Edited = Me.textImageFileTitleEdited.Text

            Return mod_strImageFiletitleEdited

        End Get
    End Property


    Public Shared Function HasOneOrMoreBackgrounds() As Boolean
        ''
        ''5/17/2022 thomas downes
        ''
        Dim strPathToFolderWithBackgrounds As String = ""
        Dim objFolderInfo As IO.DirectoryInfo
        Dim each_fileInfo As IO.FileInfo
        Dim bOneOrMoreImagesExist As Boolean
        Dim bJpegFilesExist As Boolean ''Aded 5/17/2022
        Dim bPngFilesExist As Boolean ''Aded 5/17/2022

        strPathToFolderWithBackgrounds = DiskFolders.PathToFolder_BackgroundImages
        objFolderInfo = New IO.DirectoryInfo(strPathToFolderWithBackgrounds)

        ''Look for any Jpeg-format image files which exist. 
        For Each each_fileInfo In objFolderInfo.GetFiles("*.jpg", IO.SearchOption.TopDirectoryOnly)
            bJpegFilesExist = True
            If (bJpegFilesExist) Then
                bOneOrMoreImagesExist = True
                Exit For
            End If ''End of ""If (bJpegFilesExist) Then""
        Next each_fileInfo

        ''Look for any PNG-format image files which exist. 
        For Each each_fileInfo In objFolderInfo.GetFiles("*.png", IO.SearchOption.TopDirectoryOnly)
            bPngFilesExist = True
            If (bPngFilesExist) Then
                bOneOrMoreImagesExist = True
                Exit For
            End If ''End of ""If (bPngFilesExist) Then""
        Next each_fileInfo

        Return bOneOrMoreImagesExist

    End Function ''End of ""Public Shared Function HasOneOrMoreBackgrounds() As Boolean""


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


    Public Sub LoadSelection_ByUserControl(par_controlBack As CtlBackground)
        ''5/23/2022 Public Sub LoadSelection
        ''
        ''Added 11/25/2021 thomas downes
        ''
        Dim boolNotParameter As Boolean

        Me.TemporarySelectedFileInfo = par_controlBack.ImageFileInfo

        ''Added 5/17/2022 
        picturePreview.ImageLocation = par_controlBack.ImageFilePath
        picturePreview.SizeMode = PictureBoxSizeMode.Zoom
        picturePreview.Load()
        LabelSelectedTitle.Text = par_controlBack.ImageFileTitle
        textImageFileTitleEdited.Text = par_controlBack.ImageFileTitle

        ''Added 5/23/2022 thomas d.
        LabelImageFolderPath.Text = par_controlBack.ImageFileInfo.DirectoryName

        ''
        ''Clear the other checkboxes (in the other UserControl CtlBackground):
        ''
        For Each ctlBack As CtlBackground In FlowLayoutPanel1.Controls

            boolNotParameter = (ctlBack IsNot par_controlBack)
            If (boolNotParameter) Then ctlBack.LoadIsSelectedValue(False)

        Next ctlBack

    End Sub ''eND OF ""Public Sub LoadSelection_ByUserControl""


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
        Dim strPathToEditedImage_temp As String ''Added 5/23/2022 
        Dim strPathToEditedImage As String ''Added 5/23/2022 
        Dim strPathToUploadedImages As String ''Added 5/23/2022

        Try

            Me.Output_ImageFileInfo = Me.TemporarySelectedFileInfo
            Me.Output_ImageFilePath = Me.TemporarySelectedFileInfo.FullName
            ''Added 5/23/2022 
            Me.ImageDirectoryPath = Me.TemporarySelectedFileInfo.DirectoryName

            ''Added 5/18/2022
            mod_strImageFiletitleEdited = Me.textImageFileTitleEdited.Text

            ''Added 5/23/2022 
            ''
            ''  Save the image to disk file.  
            ''
            Const c_bSaveEditedImageHere As Boolean = True
            If (c_bSaveEditedImageHere) Then
                strPathToUploadedImages = DiskFolders.PathToFolder_BackgroundImages()
                strPathToEditedImage = IO.Path.Combine(strPathToUploadedImages,
                                                       mod_strImageFiletitleEdited)
                strPathToEditedImage_temp = strPathToEditedImage &
                                            "_temp" & DateTime.Now.ToString("ss")

                ''6/10/2022 Me.picturePreview.Image.Save(strPathToEditedImage)
                Me.picturePreview.Image.Save(strPathToEditedImage_temp)

                Me.Output_ImageFilePath = strPathToEditedImage
                ''Added 6/10/2022 td
                Me.Output_ImageFilePath_Temp = strPathToEditedImage_temp

            End If ''End of ""If (c_bSaveEditedImageHere) Then""

            ''
            ''Open the dialog for addressing dimensional ratios.
            ''---12/2/2021 thomas d.
            ''
            Const c_bAddressDimensionalRatio As Boolean = False
            If (c_bAddressDimensionalRatio) Then
                Dim objChildDialog As New FormBackgroundUploadDimensionsMsg
                objChildDialog.UploadedImageFile(Me.Output_ImageFilePath)
                objChildDialog.ShowDialog()
            End If ''end of ""If (c_bAddressDimensionalRatio) Then""

        Catch ex As Exception

            ''Added 6/14/2022 thomas downes
            System.Diagnostics.Debugger.Break()

        End Try

        ''
        ''Try-Catch added 6/14/2022
        ''
        Try
            ''Close the form.  
            Me.Close()
        Catch ex As Exception
            ''Added 6/14/2022 thomas downes
            System.Diagnostics.Debugger.Break()
        End Try

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
            strFolderPath = DiskFolders.PathToFolder_BackgroundExampleDemos
        Else
            ''Added 5/13/2022 thomas downes
            strFolderPath = DiskFolders.PathToFolder_BackgroundImages
        End If ''End of "If (pboolExampleDemoImages) Then ... Else... "

        BackImageExamples.PathToFolderWithBacks = strFolderPath

        ''//------Me.Designer.BackgroundBox.Image = BackImageExamples.GetCurrentImage(boolNoneFound)

        Dim listFilesJpg As IO.FileInfo() ''Suffixed 6/14/2022 
        Dim listFilesPng As IO.FileInfo() ''Added 6/14/2022  
        Dim listFilesAll As List(Of IO.FileInfo) ''Added 6/14/2022

        listFilesJpg = (New IO.DirectoryInfo(strFolderPath)).GetFiles("*.jpg") '' ("*.jpg,*.png")
        ''Added 6/14/2022 thomas d. 
        listFilesPng = (New IO.DirectoryInfo(strFolderPath)).GetFiles("*.png") '' ("*.jpg,*.png")
        listFilesAll = New List(Of IO.FileInfo)(listFilesJpg)
        ''Add *.png files to the list. ---6/14/2022 thomas downes
        For Each each_Png As IO.FileInfo In listFilesPng
            listFilesAll.Add(each_Png)
        Next each_Png

        ''
        ''Add the image files to the Flow-Layout Panel (container).
        ''
        For Each eachFileInfo As IO.FileInfo In listFilesAll ''Added 6/14/2022 listFiles
            ''Added 11/25/2021 td
            Dim new_ctlBack As New CtlBackground()
            new_ctlBack.Visible = True
            FlowLayoutPanel1.Controls.Add(new_ctlBack)
            new_ctlBack.LoadImageFileByFileInfo(eachFileInfo, False)
            ''new_ctlBack.ParentForm = Me
            new_ctlBack.ParentListingForm = Me

            ''Added 5/17/2022 thomas d.
            ''   5/23/2022 AddHandler new_ctlBack.SelectedImageFilePath, AddressOf CtlBackground1_SelectedImageFilePath
            AddHandler new_ctlBack.SelectedImageFilePathV2, AddressOf CtlBackground1_SelectedImageFilePathV2
            ''Added 6/15/2022 thomas d. 
            AddHandler new_ctlBack.DeletingImageFilePath, AddressOf DeletingImageFilePath_Handler

        Next eachFileInfo

        ''Added 6/15/2022 thomas d.
        Dim intCountFiles As Integer
        intCountFiles = listFilesAll.Count
        With LabelCountOfFiles
            LabelCountOfFiles.Text = String.Format(.Tag.ToString(), intCountFiles)
        End With

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
        Dim objFormToShow As New FormBackgroundUpload
        objFormToShow.AutoShowOpenFileDialog = False ''5/17/2022 True
        objFormToShow.ShowDialog()

        ''Added 5/17/2022 
        FlowLayoutPanel1.Controls.Clear()
        LoadControlsFromFolderImagesBack(False)


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

    Private Sub picturePreview_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub CtlBackground1_SelectedImageFilePathV1(strImageFilePath As String) _
        Handles CtlBackground1.SelectedImageFilePathV1,
                CtlBackground2.SelectedImageFilePathV1,
                CtlBackground3.SelectedImageFilePathV1

        ''Added 5/17/2022 td
        ''Added 5/17/2022 thomas downes
        ''  The current EventHandler (Private Sub CtlBackground1_SelectedImageFilePath)
        ''  is probably not needed. See the UserControl CtlBackground's command line: 
        ''       Me.ParentListingForm.LoadSelection(Me)
        ''  in the following event-handler below (also in CtlBackground.vb):  
        ''       Private Sub checkSelection_CheckedChanged
        ''  which contains the command
        ''       Me.ParentListingForm.LoadSelection(Me)
        ''  and propagates the image selection to the parent form.
        ''    ---5/17/2022 td
        ''
        picturePreview.ImageLocation = strImageFilePath
        picturePreview.SizeMode = PictureBoxSizeMode.Zoom

    End Sub


    Private Sub CtlBackground1_SelectedImageFilePathV2(par_control As CtlBackground,
                                                     strImageFilePath As String) _
        Handles CtlBackground1.SelectedImageFilePathV2,
                CtlBackground2.SelectedImageFilePathV2,
                CtlBackground3.SelectedImageFilePathV2

        ''Added 5/23/2022 thomas downes
        ''  The current EventHandler (Private Sub CtlBackground1_SelectedImageFilePath)
        ''  is probably not needed. See the UserControl CtlBackground's command line: 
        ''       Me.ParentListingForm.LoadSelection(Me)
        ''  in the following event-handler below (also in CtlBackground.vb):  
        ''       Private Sub checkSelection_CheckedChanged
        ''  which contains the command
        ''       Me.ParentListingForm.LoadSelection(Me)
        ''  and propagates the image selection to the parent form.
        ''    ---5/17/2022 td
        ''
        picturePreview.ImageLocation = strImageFilePath
        picturePreview.SizeMode = PictureBoxSizeMode.Zoom

    End Sub


    Private Sub DeletingImageFilePath_Handler(par_sender As UserControl, pstrImageFilePath As String)
        ''--June2022--Private Sub DeletingImageFilePath_Handler(pstrImageFilePath As String)
        ''--June2022--   Handles CtlBackground1.DeletingImageFilePath
        ''
        ''Added 6/15/2022 thomas downes
        ''
        Dim bMatches_Front As Boolean ''Added 6/15/2022 td
        Dim bMatches_Back As Boolean ''Added 6/15/2022 td

        par_sender.Dispose() ''Added 6/15

        bMatches_Front = (pstrImageFilePath = Me.CurrentBackgroundImagePath_Front)
        bMatches_Back = (pstrImageFilePath = Me.CurrentBackgroundImagePath_Back)

        If (bMatches_Front Or bMatches_Back) Then
            ''Added 6/15/2022 
            MessageBoxTD.Show_Statement("This image is in use for the ID Card.")

        ElseIf (picturePreview.ImageLocation = pstrImageFilePath) Then

            picturePreview.Image?.Dispose()
            picturePreview.BackgroundImage?.Dispose()

        ElseIf (String.IsNullOrEmpty(picturePreview.ImageLocation)) Then

            picturePreview.BackgroundImage?.Dispose()

        End If ''End of "" If (picturePreview.ImageLocation = pstrImageFilePath) Then""

        ''Added 6/15/2022 thomas d.
        Dim intCountFiles As Integer
        intCountFiles = FlowLayoutPanel1.Controls.Count
        With LabelCountOfFiles
            LabelCountOfFiles.Text = String.Format(.Tag.ToString(), intCountFiles)
        End With

    End Sub


    Private Sub LinkTestScreengrab_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkTestScreengrab.LinkClicked

        ''Added 5/17/2022 td
        Dim objFormToShow As New FormBackgroundTestScreenscrape
        objFormToShow.ImageFilePathInitial = picturePreview.ImageLocation
        objFormToShow.ShowDialog()


    End Sub

    Private Sub ButtonEditImage_Click(sender As Object, e As EventArgs) _
        Handles ButtonEditImage1.Click, ButtonEditImage2.Click

        ''Added 5/17/2022 td
        Dim objFormToShow As New FormBackgroundEditImage
        Dim diag_res As DialogResult ''Added 6/13/2022

        objFormToShow.ImageFilePath_input = picturePreview.ImageLocation

        ''
        ''Show the dialog. 
        ''
        diag_res =
        objFormToShow.ShowDialog()

        ''Added 5/17/2022 td
        picturePreview.Image = Nothing
        picturePreview.ImageLocation = ""
        objFormToShow.Dispose() ''Added 6/14/2022
        Application.DoEvents() ''Added 6/14/2022

        If (diag_res = DialogResult.OK) Then
            With objFormToShow
                If (Not String.IsNullOrEmpty(.ImageFilePath_output)) Then
                    If (IO.File.Exists(.ImageFilePath_output)) Then
                        ''
                        ''Show  the edited image. ---5/18/2022 td
                        ''
                        picturePreview.ImageLocation = .ImageFilePath_output
                        picturePreview.Load()
                        Me.Output_ImageFilePath = .ImageFilePath_output
                        ''Added 6/14/2022
                        Me.TemporarySelectedFileInfo = New IO.FileInfo(.ImageFilePath_output)

                    End If ''End of ""If (IO.File.Exists(.ImageFilePath_output)) Then""
                End If ''ENd of ""If (Not String.IsNullOrEmpty(.ImageFilePath_output)) Then""
            End With ''End of ""With objFormToShow""

            ''Added 6/14/2022 
            ''   Allow the user to access the "OK" button underneath.  
            ButtonEditImage2.Visible = False

        End If ''End of ""If (diag_res = DialogResult.OK) Then""

    End Sub


    Private Sub FormBackgroundsSelect_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp

        ''Added 6/13/2022 thomas downes

        If (e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageDown) Then

            ''FlowLayoutPanel1.VerticalScroll.LargeChange
            With FlowLayoutPanel1
                .AutoScrollPosition = New Point(.AutoScrollPosition.X, .AutoScrollPosition.Y - 10)
            End With

        End If


    End Sub
End Class