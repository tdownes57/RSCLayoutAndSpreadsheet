Public Class FormBackgroundUpload
    ''
    ''Added 11/25/2021 Thomas Downes
    ''
    ''June15 2022 ''Public ImageFilePath As String
    Public Output_ImageFileTitle As String ''Prefixed 6/15/2022
    Public Output_ImageFileInfo As System.IO.FileInfo ''Prefixed 6/15/2022

    Public Output_FilePath_CopyOriginal As String ''Added 6/15/2022 thomas downes
    Public Output_FilePath_CopyEdited As String ''Added 6/15/2022 thomas downes

    Public Selected As Boolean
    Public AutoShowOpenFileDialog As Boolean ''Added 12/10/2021 thomas downes

    Private mod_strPathToImageOriginal As String ''Added 5/24/2022 td 

    Private Sub EditImage_byLocation(pstrImageFilePath As String, par_fileInfo As IO.FileInfo)
        ''
        ''Encapsulated 5/24/2022 td
        ''
        Dim objEditingDialog As New FormBackgroundEditImage
        Dim dia_res As DialogResult
        ''---Dim strImageFilePath As String
        ''---Dim objImageFileInfo As IO.FileInfo
        Dim strImageFilePath_Edited As String ''Added 5/22/2022 thomas downes

        objEditingDialog.ImageFilePath_input = pstrImageFilePath ''Added 5/22/2022 
        ''5/24/2022 ''objEditingDialog.UploadedImageFile(strImageFilePath)
        objEditingDialog.Load_ImageFileToEdit(pstrImageFilePath)
        objEditingDialog.ShowDialog()
        dia_res = objEditingDialog.DialogResult
        If (dia_res = DialogResult.OK) Then

            ''Added 5/17/2022 
            strImageFilePath_Edited = objEditingDialog.ImageFilePath_output

            ''
            ''Article...
            ''   "?. and ?() null-conditional operators (Visual Basic)"
            ''Quote....
            ''   "The null-conditional operators are short-circuiting. If one operation
            ''   in a chain of conditional member access and index operations returns Nothing,
            ''   the rest of the chain’s execution stops. "
            '' https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/operators/null-conditional-operators
            ''  ----5/24/2023 td
            ''
            picturePreview.Image?.Dispose() ''Added 5/24/2022  
            picturePreview.ImageLocation = strImageFilePath_Edited
            picturePreview.SizeMode = PictureBoxSizeMode.Zoom
            picturePreview.Load()
            ''5/24/2022 LabelSelectedTitle.Text = objImageFileInfo.Name
            ''5/24/2022 textImageFileTitleEdited.Text = objImageFileInfo.Name
            LabelSelectedTitle.Text = par_fileInfo.Name
            textImageFileTitleEdited.Text = par_fileInfo.Name

        End If ''Endof ""If (dia_res = DialogResult.OK) Then""

    End Sub ''End of ""rivate Sub EditImage_byLocation""


    Private Sub buttonUpload_Click(sender As Object, e As EventArgs) Handles buttonUpload1.Click
        ''
        ''Added 11/25/2021 Thomas Downes
        ''
        Static s_strFolder As String
        ''Dim objCache As ciBadgeElements.ClassElementsCache_Deprecated

        If (String.IsNullOrEmpty(s_strFolder)) Then s_strFolder = My.Application.Info.DirectoryPath

        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.InitialDirectory = s_strFolder
        OpenFileDialog1.ShowDialog()

        ''Added 11/24/2021 
        Dim bConfirmFileExists As Boolean
        bConfirmFileExists = System.IO.File.Exists(OpenFileDialog1.FileName)
        ''---If (Not bConfirmFileExists) Then Return

        ''
        ''Almost done....
        ''
        If (bConfirmFileExists) Then
            ''
            ''We have an image file!
            ''
            Dim strImageFilePath As String
            Dim objImageFileInfo As IO.FileInfo
            ''---Dim strImageFilePath_Edited As String ''Added 5/22/2022 thomas downes
            Dim strImageFilePath_CopyToOriginals As String ''Added 5/23/2022 td
            Dim strFolderForOriginals As String ''Added 5/23/2022 td

            strImageFilePath = OpenFileDialog1.FileName
            objImageFileInfo = New IO.FileInfo(strImageFilePath)
            Const c_bOriginalCopy As Boolean = True
            strFolderForOriginals = DiskFolders.PathToFolder_BackgroundImages(c_bOriginalCopy)

            ''Added 5/24/2022 td
            strImageFilePath_CopyToOriginals = IO.Path.Combine(strFolderForOriginals,
                                                               objImageFileInfo.Name)
            IO.File.Copy(strImageFilePath, strImageFilePath_CopyToOriginals, True)
            mod_strPathToImageOriginal = strImageFilePath_CopyToOriginals
            Me.Output_FilePath_CopyOriginal = strImageFilePath_CopyToOriginals ''Added 6/15/2022

            ''Me.ImageFilePath = strImageFilePath
            ''Me.ImageFileInfo = New IO.FileInfo(strImageFilePath)
            ''Me.TemporaryFilePath = strImageFilePath

            ''Moved upward. 5/23/2022 objImageFileInfo = New IO.FileInfo(strImageFilePath)
            CtlBackground1.LoadImageFileByFileInfo(objImageFileInfo)

            ''
            ''Open the dialog for addressing dimensional ratios.
            ''---12/2/2021 thomas d.
            ''
            Const c_bExplainDimensionRatioForm As Boolean = False ''Added 5/20/2022

            If (c_bExplainDimensionRatioForm) Then ''Added 5/20/2022
                Dim objChildDialog As New FormBackgroundUploadDimensionsMsg
                objChildDialog.UploadedImageFile(strImageFilePath)
                objChildDialog.ShowDialog()

            Else
                ''Encapsulated 5/23/2022 thomas downes
                EditImage_byLocation(strImageFilePath, objImageFileInfo)

                ''Dim objEditingDialog As New FormBackgroundEditImage
                ''Dim dia_res As DialogResult
                ''objEditingDialog.ImageFilePath_input = strImageFilePath ''Added 5/22/2022 
                ''''5/24/2022 ''objEditingDialog.UploadedImageFile(strImageFilePath)
                ''objEditingDialog.Load_ImageFileToEdit(strImageFilePath)
                ''objEditingDialog.ShowDialog()
                ''dia_res = objEditingDialog.DialogResult
                ''If (dia_res = DialogResult.OK) Then
                ''
                ''    ''Added 5/17/2022 
                ''    strImageFilePath_Edited = objEditingDialog.ImageFilePath_output
                ''    picturePreview.ImageLocation = strImageFilePath_Edited
                ''    picturePreview.SizeMode = PictureBoxSizeMode.Zoom
                ''    picturePreview.Load()
                ''    LabelSelectedTitle.Text = objImageFileInfo.Name
                ''    textImageFileTitleEdited.Text = objImageFileInfo.Name
                ''
                ''End If ''Endof ""If (dia_res = DialogResult.OK) Then""

            End If ''End of ""If (c_bExplainDimensionRatioForm) Then ... Else ""

        Else
            ''Exit the Sub. 
            Return

        End If ''End of "If (bConfirmFileExists) Then ... Else ..."

    End Sub

    Private Sub buttonOK_Click(sender As Object, e As EventArgs) Handles buttonOK.Click
        ''
        ''Added 11/25/2021 thomas downes
        ''
        Me.Selected = CtlBackground1.ImageIsSelected
        Me.Output_ImageFileInfo = CtlBackground1.ImageFileInfo
        Dim strDestPathToFileJPG_Proposed As String = "" ''Dest = Destination
        Dim strDestPathToFileJPG_OriginalCopy As String = "" ''Added 5/18/2022 td
        Dim strDestPathToFileJPG_Old As String = "" ''Dest = Destination
        Dim strDestPathToFileJPG_New As String = "" ''Dest = Destination
        Dim strDestFolderPath As String ''Dest = Destination
        Dim strDestFolderPath_OriginalCopy As String ''Added 5/18/2022
        Dim strFileTitle_Original As String
        Dim strFileTitle_Incremented As String
        ''02/2023  Dim bFilePathIsFree_Good As Boolean
        ''02/2023  Dim strFileExtension As String

        ''---strDestFilePath = modFileFolders.ImageBackgroundFolder
        ''5/17/2022 td''strDestFolderPath = DiskFolders.PathToFolder_BackExampleDemos
        strDestFolderPath = DiskFolders.PathToFolder_BackgroundImages

        ''Added 5/18/2022 thomas downes
        strDestFolderPath_OriginalCopy =
            IO.Path.Combine(DiskFolders.PathToFolder_BackgroundImages, "Originals")

        ''Added 6/15/2022
        Me.Output_FilePath_CopyOriginal = strDestFolderPath_OriginalCopy ''Added 6/15/2022

        ''Added 12/10/2021 td
        strFileTitle_Original = Me.Output_ImageFileInfo.Name

        ''For intTryForNewFile As Integer = 1 To 10
        ''    ''strDestFilePath = System.IO.Path.Combine(strDestFilePath, Me.ImageFileInfo.Name)
        ''    strFileTitle_Incremented = DiskFilesVB.IncrementFileTitle(strFileTitle_Original, strFileExtension, intTryForNewFile)
        strDestPathToFileJPG_Proposed = System.IO.Path.Combine(strDestFolderPath, strFileTitle_Original)

        ''Added 6/15/2022 td
        Dim strFileTitleEdited As String ''Added 6/15/2022 td
        Dim bFileTitleNonEmpty As Boolean ''Added 6/15/2022 td
        strFileTitleEdited = textImageFileTitleEdited.Text
        bFileTitleNonEmpty = (Not String.IsNullOrEmpty(strFileTitleEdited))
        If (bFileTitleNonEmpty) Then
            strDestPathToFileJPG_Proposed = System.IO.Path.Combine(strDestFolderPath, strFileTitleEdited)
        Else
            strDestPathToFileJPG_Proposed = System.IO.Path.Combine(strDestFolderPath, strFileTitle_Original)
        End If ''End of ""If (bFileTitleNonEmpty) Then ... Else ...""

        ''Added 5/18/2022
        ''  Keep a copy of the original, prior to editing.
        strDestPathToFileJPG_OriginalCopy =
               System.IO.Path.Combine(strDestFolderPath_OriginalCopy, strFileTitle_Original)

        ''    bFilePathIsFree_Good = Not IO.File.Exists(strDestFilePath)
        ''    If (bFilePathIsFree_Good) Then Exit For
        ''Next intTryForNewFile

        Dim bIncrementingNeeded As Boolean = False ''Added 12/10/2021 td

        bIncrementingNeeded = IO.File.Exists(strDestPathToFileJPG_Proposed)

        If (bIncrementingNeeded) Then
            ''
            ''Suffix an incremented number until the file-title-with-suffix
            ''  is available for use. ---2/7/2022
            ''
            strFileTitle_Incremented = DiskFilesVB.IncrementFileTitle_UntilFree(strDestFolderPath,
                                                                            strFileTitle_Original,
                                                                            strDestPathToFileJPG_New)
        End If  ''end of "If (bIncrementingNeeded) Then"                   ''   bIncrementingNeeded)

        ''Added 12/10/2021 thomas downese
        ''02/2023  Dim boolFilePathConfirmed As Boolean
        ''02/2023  Dim bUserWantsToMakeOriginalCurrent As Boolean
        Dim bUserWantsToSaveTheNewFile As Boolean
        Dim bUserWantsToReplaceOldWithNew As Boolean

        If (bIncrementingNeeded) Then
            ''
            ''Important call.
            ''
            bUserWantsToSaveTheNewFile =
                FormBackgroundUploadNewVsExisting.ShowExistingVsNew(strDestPathToFileJPG_Old,
                                        strDestPathToFileJPG_New,
                                        bUserWantsToReplaceOldWithNew)

        Else
            strDestPathToFileJPG_New = strDestPathToFileJPG_Proposed

        End If ''End of "If (bIncrementingNeeded) Then ... Else"

        ''
        ''Ready to save the file. 
        ''
        Try
            ''Dec.10 2021''Me.ImageFileInfo.CopyTo(strDestPathToFileJPG_New)
            Me.Output_ImageFileInfo.CopyTo(strDestPathToFileJPG_New, bUserWantsToReplaceOldWithNew)

            ''Added 5/18/2022 td
            ''  Keep a copy of the original, a backup, prior to any editing
            ''  that might occur (cropping, resizing).---5/18/2022 
            ''5/23/2022 Me.ImageFileInfo.CopyTo(strDestPathToFileJPG_OriginalCopy, False)
            Me.Output_ImageFileInfo.CopyTo(strDestPathToFileJPG_OriginalCopy, True)

            ''Added 6/15/2022
            Me.Output_FilePath_CopyOriginal = strDestPathToFileJPG_OriginalCopy
            Me.Output_FilePath_CopyEdited = strDestPathToFileJPG_New

            ''Added 2/7/2022 td
            Me.Output_ImageFileInfo = New IO.FileInfo(strDestPathToFileJPG_New)
            ''6/15/2022 ''Me.ImageFilePath = Me.ImageFileInfo.FullName
            Me.Output_ImageFileTitle = Me.Output_ImageFileInfo.Name
            Me.Selected = True

            Me.CtlBackground1.Dispose_Image() ''Added 5/24/2022
            Me.CtlBackground1.Dispose() ''Added 5/24/2022
            picturePreview.Image.Dispose() ''Added 5/24/2022
            picturePreview.Dispose() ''Added 5/24/2022

            Me.Close() ''Close the window. 

        Catch ex_copy As Exception
            ''
            ''Added 11/26/2021 thomas d.
            ''
            If (ex_copy.Message.Contains("exists")) Then
                ''Added 11/26/2021 thomas d.
                MessageBox.Show("Please pick a file which is not already uploaded.",
                    "Try again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show(ex_copy.Message, "Try again",
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If ''end of "If (ex_copy.Message.Contains("exists")) Then ... Else"
        End Try


    End Sub


    Private Sub FormUploadBackground_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 11/25/2021 thomas downes
        ''
        ''The checkbox is not needed. 
        CtlBackground1.HideCheckbox()
        CtlBackground1.IsNotSelectableItemOfAList = True ''Added 12/10/2021 td

        ''Added 12/10/2021 
        If (Me.AutoShowOpenFileDialog) Then buttonUpload1.PerformClick()

    End Sub

    Private Sub buttonCancel_Click(sender As Object, e As EventArgs) Handles buttonCancel.Click

        ''Added 5/24/2022 thomas downes
        If (IO.File.Exists(mod_strPathToImageOriginal)) Then
            IO.File.Delete(mod_strPathToImageOriginal)
        End If ''Endof ""If (IO.File.Exists(mod_strPathToImageOriginal)) Then""

        ''Added 5/24/2022 thomas downes
        Dim strPathToEditedFile As String
        strPathToEditedFile = picturePreview.ImageLocation

        ''
        ''Article...
        ''   "?. and ?() null-conditional operators (Visual Basic)"
        ''Quote....
        ''   "The null-conditional operators are short-circuiting. If one operation
        ''   in a chain of conditional member access and index operations returns Nothing,
        ''   the rest of the chain’s execution stops. "
        '' https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/operators/null-conditional-operators
        ''
        picturePreview.Image?.Dispose()
        If (IO.File.Exists(strPathToEditedFile)) Then
            IO.File.Delete(strPathToEditedFile)
        End If ''Endof ""If (strPathToEditedFile)) Then""

        Me.CtlBackground1.Dispose_Image() ''Added 5/24/2022
        Me.CtlBackground1.Dispose() ''Added 5/24/2022
        picturePreview.Image?.Dispose() ''Added 5/24/2022
        picturePreview.Dispose() ''Added 5/24/2022

        Me.Close() ''Added 11/26/2021 

    End Sub

    Private Sub buttonUpload2_Click(sender As Object, e As EventArgs) Handles buttonUpload2.Click

        ''Added 2/7/2022 thomas downes tomdownes1@gmail.com
        buttonUpload2.Visible = False
        buttonUpload_Click(sender, e)

    End Sub


    Private Sub ButtonEditImageRaw_Click(sender As Object, e As EventArgs) Handles ButtonEditImageRaw.Click

        ''Added 5/23/2022 thomas 
        Dim objFileInfo_Original As IO.FileInfo

        If (IO.File.Exists(mod_strPathToImageOriginal)) Then
            objFileInfo_Original = New IO.FileInfo(mod_strPathToImageOriginal)
            EditImage_byLocation(mod_strPathToImageOriginal, objFileInfo_Original)
        End If ''Endof ""If (IO.File.Exists(mod_strPathToImageOriginal)) Then""

    End Sub


End Class