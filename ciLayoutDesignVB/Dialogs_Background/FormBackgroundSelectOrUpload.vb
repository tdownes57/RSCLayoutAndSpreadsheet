''
''Added 5/13/2022  
''

Public Class FormBackgroundSelectOrUpload
    ''
    ''Added 5/13/2022  
    ''
    Public UserWantsToUpload As Boolean
    Public UserWantsToSelect As Boolean
    Public UserWantsToSeeDemos As Boolean
    Public Input_CurrentBackgroundImage As Image ''Added 6/10/2022 
    Public Input_BackgroundImagePath As String ''Added 6/11/2022 
    Public Output_PathToBackground As String ''Added 6/11/2022
    Public Output_EditedExistingBackgd As Boolean ''Added 6/11/2022 

    ''Added 6/11/2022 td
    Private mod_editOfPicturePreviewOK As Boolean '' = True
    Private mod_pathToEditedPicturePreview As String '' = strEditedImageFilePath

    Public Sub New(par_backgroundimage As Image, pstrPathToImageFileJPG As String)
        ''
        ''Added 5/13/2022  
        ''
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        textboxPathToImageJPG.Text = pstrPathToImageFileJPG ''Added 5/13/2022 td
        textboxPathToImageJPG.Visible = True
        Me.Input_BackgroundImagePath = pstrPathToImageFileJPG
        Me.Input_CurrentBackgroundImage = par_backgroundimage


    End Sub

    Private Sub ButtonUploadImage_Click(sender As Object, e As EventArgs) Handles ButtonUploadImage.Click
        ''
        ''Added 5/13/2022  
        ''
        UserWantsToUpload = True
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonSelectLoaded_Click(sender As Object, e As EventArgs) Handles ButtonSelectLoaded.Click
        ''
        ''Added 5/13/2022  
        ''
        UserWantsToSelect = True
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonSelectDemos_Click(sender As Object, e As EventArgs) Handles ButtonSelectDemos.Click
        ''
        ''Added 5/13/2022  
        ''
        UserWantsToSeeDemos = True
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        ''
        ''Added 5/13/2022  
        ''
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub FormSelectOrUpload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 5/17/2022 thomas  
        ''
        Dim bOneOrMoreImagesExist As Boolean
        bOneOrMoreImagesExist = FormBackgroundsSelect.HasOneOrMoreBackgrounds()

        ''Dim strPathToFolderWithBackgrounds As String = ""
        ''Dim objFolderInfo As IO.DirectoryInfo
        ''Dim each_fileInfo As IO.FileInfo
        ''Dim bOneOrMoreImagesExist As Boolean
        ''Dim bJpegFilesExist As Boolean ''Aded 5/17/2022
        ''Dim bPngFilesExist As Boolean ''Aded 5/17/2022

        ''strPathToFolderWithBackgrounds = DiskFolders.PathToFolder_BackgroundImages
        ''objFolderInfo = New IO.DirectoryInfo(strPathToFolderWithBackgrounds)

        ''''Look for any Jpeg-format image files which exist. 
        ''For Each each_fileInfo In objFolderInfo.GetFiles("*.jpg", IO.SearchOption.TopDirectoryOnly)
        ''    bJpegFilesExist = True
        ''    If (bJpegFilesExist) Then
        ''        bOneOrMoreImagesExist = True
        ''        Exit For
        ''    End If ''End of ""If (bJpegFilesExist) Then""
        ''Next each_fileInfo

        ''''Look for any PNG-format image files which exist. 
        ''For Each each_fileInfo In objFolderInfo.GetFiles("*.png", IO.SearchOption.TopDirectoryOnly)
        ''    bPngFilesExist = True
        ''    If (bPngFilesExist) Then
        ''        bOneOrMoreImagesExist = True
        ''        Exit For
        ''    End If ''End of ""If (bPngFilesExist) Then""
        ''Next each_fileInfo

        ''
        ''Activate the "Select" button. 
        ''
        If (bOneOrMoreImagesExist) Then
            ButtonSelectLoaded.Visible = bOneOrMoreImagesExist
            ButtonSelectLoaded.Enabled = bOneOrMoreImagesExist
        End If ''End of ""If (bOneOrMoreImagesExist) Then""

        ''
        ''If available, show the current background image. 
        ''
        If (Me.Input_CurrentBackgroundImage IsNot Nothing) Then

            Dim intRighthandMargin As Integer
            Dim intLefthandMargin As Integer
            Dim intWidthOfButtons As Integer

            picturePreview.Image = Me.Input_CurrentBackgroundImage
            picturePreview.SizeMode = PictureBoxSizeMode.Zoom
            picturePreview.Visible = True
            picturePreview.BringToFront()
            intWidthOfButtons = ButtonEditBackground.Width

            ''intRighthandMargin = Me.Width - ButtonSelectDemos.Left - ButtonSelectDemos.Width
            intLefthandMargin = ButtonSelectLoaded.Left
            intRighthandMargin = intLefthandMargin

            ButtonEditBackground.Width = intWidthOfButtons
            ButtonSelectDemos.Width = intWidthOfButtons
            ButtonSelectLoaded.Width = intWidthOfButtons
            ButtonUploadImage.Width = intWidthOfButtons ''Added 6/11/2022 thomas d.

            ''6/11/2022 picturePreview.Left = ButtonSelectLoaded.Left + ButtonSelectLoaded.Width + 20
            picturePreview.Left = ButtonSelectLoaded.Left + ButtonSelectLoaded.Width + intRighthandMargin
            picturePreview.Top = ButtonUploadImage.Top
            picturePreview.Visible = True
            Me.Width = picturePreview.Left + picturePreview.Width + intRighthandMargin

            LabelEditCurrentHdr1.Left = picturePreview.Left
            LabelEditCurrentHdr2.Left = picturePreview.Left
            LabelEditCurrentHdr1.Visible = True
            LabelEditCurrentHdr2.Visible = True

        End If ''End fo ""If (Me.Input_CurrentBackgroundImage IsNot Nothing) Then""



    End Sub

    Private Sub LinkLabelOpenFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelOpenFile.LinkClicked

        ''Added 5/23/2022 thomas  
        System.Diagnostics.Process.Start(textboxPathToImageJPG.Text)


    End Sub

    Private Sub LinkLabelOpenFolder_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelOpenFolder.LinkClicked

        ''Added 5/23/2022 td
        Dim objFileInfo_JPG As IO.FileInfo
        objFileInfo_JPG = New IO.FileInfo(textboxPathToImageJPG.Text)
        System.Diagnostics.Process.Start(objFileInfo_JPG.DirectoryName)


    End Sub

    Private Sub LabelEditCurrentHdr1_Click(sender As Object, e As EventArgs) Handles LabelEditCurrentHdr1.Click

    End Sub

    Private Sub picturePreview_Click(sender As Object, e As EventArgs) Handles picturePreview.Click
        ''
        ''Added 6/10/2022
        ''
        Dim objFormShow As FormBackgroundEditImage
        Dim diag_res As DialogResult ''Added 6/12/2022 

        objFormShow = New FormBackgroundEditImage()
        objFormShow.ImageFilePath_input = Me.Input_BackgroundImagePath
        objFormShow.Load_ImageFileToEdit(Me.Input_BackgroundImagePath)
        diag_res =
          objFormShow.ShowDialog()

        ''Added 6/11/2022
        Dim strEditedImageFilePath As String

        ''Added 6/11/2022
        If (diag_res = DialogResult.OK) Then
            ''Added 6/11/2022
            strEditedImageFilePath = objFormShow.ImageFilePath_output
            picturePreview.ImageLocation = strEditedImageFilePath
            picturePreview.SizeMode = PictureBoxSizeMode.Zoom
            picturePreview.Load()

            ''Added 6/11/2022 td
            mod_editOfPicturePreviewOK = True
            mod_pathToEditedPicturePreview = strEditedImageFilePath

        End If ''End of ""If (diag_res = DialogResult.OK) Then""

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ''
        ''Added 6/11/2022  
        ''
        Dim bFileCopyToReplaceInputJpeg As Boolean ''Added 6/11/2022 td  
        Dim bEditedExistingBackground As Boolean ''Added 6/12/2022 td

        Me.DialogResult = DialogResult.OK

        ''Added 6/11/2022 td
        ''
        '' Check to see if the user has edited the existing background image. 
        ''
        bEditedExistingBackground = (mod_editOfPicturePreviewOK) AndAlso
                        (Not String.IsNullOrEmpty(Me.Input_BackgroundImagePath)) AndAlso
                        IO.File.Exists(mod_pathToEditedPicturePreview)

        Const c_boolReplaceOriginal As Boolean = False ''True ''False ''False, because
        ''  the runtime error is saying that the file is locked or similar.
        ''  There is probably an Image reference that needs to be "Dispose()"d.
        ''  System.IO.IOException: 'The process cannot access the file 'D:\RSC ID Card\Images\BackgroundImagesUploaded\Cute wassail illustration.jpg'
        ''  because it is being used by another process.'
        ''  ----6/12/2022 Thomas Downes
        bFileCopyToReplaceInputJpeg = (bEditedExistingBackground And c_boolReplaceOriginal)

        If (bFileCopyToReplaceInputJpeg) Then ''Added 6/11/2022 td

            ''Added 6/11/2022 td
            picturePreview.Image?.Dispose()
            picturePreview.Image = Nothing
            Me.Input_CurrentBackgroundImage?.Dispose()
            Me.Input_CurrentBackgroundImage = Nothing

            ''
            ''Replace the original image with the edited version
            ''  of the image. ---6/12/2022
            ''
            If (c_boolReplaceOriginal) Then
                IO.File.Copy(mod_pathToEditedPicturePreview,
                         Me.Input_BackgroundImagePath, True)
                Me.Output_PathToBackground = Me.Input_BackgroundImagePath
            End If ''Endof ""If (c_boolReplaceOriginal) Then""

        ElseIf (bEditedExistingBackground) Then
            ''
            ''Added 6/12/2022 thomas downes
            ''
            Me.Output_EditedExistingBackgd = True
            Me.Output_PathToBackground = mod_pathToEditedPicturePreview

        Else
            Me.Output_PathToBackground = DiskFilesVB.PathToFile_BackgroundSuffixSeconds("Background")
            picturePreview.Image.Save(Me.Output_PathToBackground)

        End If ''End of ""If (bFileCopyToReplaceInputJpeg) Then ... ElseIf... Else..."

        Me.Close()

    End Sub ''End of .... Handlers ButtonOK_Click


End Class