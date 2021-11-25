Public Class FormUploadBackground
    ''
    ''Added 11/25/2021 Thomas Downes
    ''
    Public ImageFilePath As String
    Public ImageFileInfo As System.IO.FileInfo
    Public Selected As Boolean

    Private Sub buttonUpload_Click(sender As Object, e As EventArgs) Handles buttonUpload.Click
        ''
        ''Added 11/25/2021 Thomas Downes
        ''
        Static s_strFolder As String
        Dim objCache As ciBadgeElements.ClassElementsCache_Deprecated

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

        Else
            ''Exit the Sub. 
            Return
        End If ''End of "If (bConfirmFileExists) Then ... Else ..."

    End Sub

    Private Sub buttonOK_Click(sender As Object, e As EventArgs) Handles buttonOK.Click
        ''
        ''Added 11/25/2021 thomas downes
        ''
        Me.Selected = CtlBackground1.Selected
        Me.ImageFileInfo = CtlBackground1.ImageFileInfo
        Dim strDestFilePath As String ''Dest = Destination
        Dim strDestFolderPath As String ''Dest = Destination
        strDestFilePath = modFileFolders.ImageBackgroundFolder
        strDestFilePath = System.IO.Path.Combine(strDestFilePath, Me.ImageFileInfo.Name)
        Me.ImageFileInfo.CopyTo(strDestFilePath)

    End Sub

    Private Sub FormUploadBackground_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class