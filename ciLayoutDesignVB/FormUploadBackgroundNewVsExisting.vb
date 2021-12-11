''
''Added 12/10/2021 thomas downes
''
Public Class FormUploadBackgroundNewVsExisting
    ''
    ''Added 12/10/2021 thomas downes
    ''
    Public DestPathToFileJPG_ExistingFile As String
    Public SourcePathToLocalCopyOfFileToUpload As String
    Public FileTitle_Existing As String
    Public FileTitle_Incremented As String

    Public Shared Function ShowExistingVsNew(pstrDestPathToFileJPG_Old As String,
                                pstrDestPathToFileJPG_New As String,
                                bUserWantsToReplaceOldWithNew As String) As Boolean
        ''
        ''Added 12/10/2021 thomas downes
        ''


    End Function

    Private Sub FormUploadBackgroundNewVsExisting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 12/10/2021 thomas d.
        ''
        CtlBackground1Existing.ImageFilePath = Me.DestPathToFileJPG_ExistingFile
        CtlBackground2Proposed.ImageFilePath = Me.SourcePathToLocalCopyOfFileToUpload
        textFiletitle_NewImage.Text = FileTitle_Incremented

    End Sub

    Private Sub ButtonReplaceOlderImage_Click(sender As Object, e As EventArgs) Handles ButtonReplaceOlderImage.Click

    End Sub

    Private Sub txtFiletitle_OriginalImage_TextChanged(sender As Object, e As EventArgs) Handles txtFiletitle_OriginalImage.TextChanged

    End Sub
End Class