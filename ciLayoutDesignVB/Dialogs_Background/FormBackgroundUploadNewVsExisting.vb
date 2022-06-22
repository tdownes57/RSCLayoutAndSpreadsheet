''
''Added 12/10/2021 thomas downes
''
Public Class FormBackgroundUploadNewVsExisting
    ''
    ''Added 12/10/2021 thomas downes
    ''
    Public Input_DestPathToFileJPG_ExistingFile As String
    Public Input_SourcePathToLocalCopyOfFileToUpload As String

    Public FileTitle_Existing As String
    Public Input_FileTitle_Incremented As String

    Public Input_UserWantsToReplaceOldWithNew As Boolean ''Added 6/20/2022 td


    Public Shared Function ShowExistingVsNew(pstrDestPathToFileJPG_Old As String,
                                pstrDestPathToFileJPG_New As String,
                                pboolUserWantsToReplaceOldWithNew As Boolean) As Boolean
        ''
        ''Added 12/10/2021 thomas downes
        ''
        Dim objFormToShow As New FormBackgroundUploadNewVsExisting

        With objFormToShow
            .Input_DestPathToFileJPG_ExistingFile = pstrDestPathToFileJPG_Old
            .Input_SourcePathToLocalCopyOfFileToUpload = pstrDestPathToFileJPG_New

            ''Me.textFiletitle_NewImage = IO.Path.GetFileName(pstrDestPathToFileJPG_New)
            ''Me.textFileTitle_OriginalImage = IO.Path.GetFileName(pstrDestPathToFileJPG_Old)

            .Input_UserWantsToReplaceOldWithNew = pboolUserWantsToReplaceOldWithNew

        End With

    End Function ''End of ""Public Shared Function ShowExistingVsNew""


    Private Sub FormUploadBackgroundNewVsExisting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 12/10/2021 thomas d.
        ''
        CtlBackground1Existing.ImageFilePath = Me.Input_DestPathToFileJPG_ExistingFile
        CtlBackground2Proposed.ImageFilePath = Me.Input_SourcePathToLocalCopyOfFileToUpload

        ''June20 2022''Me.textFiletitle_NewImage = IO.Path.GetFileName(pstrDestPathToFileJPG_New)
        ''June20 2022''Me.textFileTitle_OriginalImage = IO.Path.GetFileName(pstrDestPathToFileJPG_Old)

        textFiletitle_NewImage.Text = Me.Input_FileTitle_Incremented
        textFileTitle_OriginalImage.Text = IO.Path.GetFileName(Me.Input_DestPathToFileJPG_ExistingFile)


    End Sub

    Private Sub ButtonReplaceOlderImage_Click(sender As Object, e As EventArgs) Handles ButtonReplaceOlderImage.Click

    End Sub

    Private Sub txtFiletitle_OriginalImage_TextChanged(sender As Object, e As EventArgs) Handles textFileTitle_OriginalImage.TextChanged

    End Sub
End Class