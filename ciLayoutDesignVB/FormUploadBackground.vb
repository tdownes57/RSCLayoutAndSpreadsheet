Public Class FormUploadBackground
    ''
    ''Added 11/25/2021 Thomas Downes
    ''
    Public ImageFilePath As String
    Public ImageFileInfo As System.IO.FileInfo
    Public Selected As Boolean
    Public AutoShowOpenFileDialog As Boolean ''Added 12/10/2021 thomas downes

    Private Sub buttonUpload_Click(sender As Object, e As EventArgs) Handles buttonUpload.Click
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

            strImageFilePath = OpenFileDialog1.FileName

            ''Me.ImageFilePath = strImageFilePath
            ''Me.ImageFileInfo = New IO.FileInfo(strImageFilePath)
            ''Me.TemporaryFilePath = strImageFilePath

            objImageFileInfo = New IO.FileInfo(strImageFilePath)
            CtlBackground1.LoadImageFileByFileInfo(objImageFileInfo)

            ''
            ''Open the dialog for addressing dimensional ratios.
            ''---12/2/2021 thomas d.
            ''
            Dim objChildDialog As New FormUploadDimensionsMsg
            objChildDialog.UploadedImageFile(strImageFilePath)
            objChildDialog.ShowDialog()

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
        Me.ImageFileInfo = CtlBackground1.ImageFileInfo
        Dim strDestPathToFileJPG_Proposed As String = "" ''Dest = Destination
        Dim strDestPathToFileJPG_Old As String = "" ''Dest = Destination
        Dim strDestPathToFileJPG_New As String = "" ''Dest = Destination
        Dim strDestFolderPath As String ''Dest = Destination
        Dim strFileTitle_Original As String
        Dim strFileTitle_Incremented As String
        Dim bFilePathIsFree_Good As Boolean
        Dim strFileExtension As String

        ''---strDestFilePath = modFileFolders.ImageBackgroundFolder
        strDestFolderPath = DiskFolders.PathToFolder_BackExamples

        ''Added 12/10/2021 td
        strFileTitle_Original = Me.ImageFileInfo.Name

        ''For intTryForNewFile As Integer = 1 To 10
        ''    ''strDestFilePath = System.IO.Path.Combine(strDestFilePath, Me.ImageFileInfo.Name)
        ''    strFileTitle_Incremented = DiskFilesVB.IncrementFileTitle(strFileTitle_Original, strFileExtension, intTryForNewFile)
        strDestPathToFileJPG_Proposed = System.IO.Path.Combine(strDestFolderPath, strFileTitle_Original)

        ''    bFilePathIsFree_Good = Not IO.File.Exists(strDestFilePath)
        ''    If (bFilePathIsFree_Good) Then Exit For
        ''Next intTryForNewFile

        Dim bIncrementingNeeded As Boolean = False ''Added 12/10/2021 td

        bIncrementingNeeded = IO.File.Exists(strDestPathToFileJPG_Proposed)

        If (bIncrementingNeeded) Then
            strFileTitle_Incremented = DiskFilesVB.IncrementFileTitle_UntilFree(strDestFolderPath,
                                                                            strFileTitle_Original,
                                                                            strDestPathToFileJPG_New)
        End If  '''end of "If (bIncrementingNeeded) Then"                   ''   bIncrementingNeeded)

        ''Added 12/10/2021 thomas downese
        Dim boolFilePathConfirmed As Boolean
        Dim bUserWantsToMakeOriginalCurrent As Boolean
        Dim bUserWantsToSaveTheNewFile As Boolean
        Dim bUserWantsToReplaceOldWithNew As Boolean

        If (bIncrementingNeeded) Then
            ''
            ''Important call.
            ''
            bUserWantsToSaveTheNewFile =
                FormUploadBackgroundNewVsExisting.ShowExistingVsNew(strDestPathToFileJPG_Old,
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
            Me.ImageFileInfo.CopyTo(strDestPathToFileJPG_New, bUserWantsToReplaceOldWithNew)
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
        If (Me.AutoShowOpenFileDialog) Then buttonUpload.PerformClick()

    End Sub

    Private Sub buttonCancel_Click(sender As Object, e As EventArgs) Handles buttonCancel.Click

        Me.Close() ''Added 11/26/2021 

    End Sub
End Class