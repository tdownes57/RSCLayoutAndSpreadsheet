''
''Added 5/13/2022  
''

Public Class FormBackgroundSelectOrUpload

    Public UserWantsToUpload As Boolean
    Public UserWantsToSelect As Boolean
    Public UserWantsToSeeDemos As Boolean

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

    End Sub
End Class