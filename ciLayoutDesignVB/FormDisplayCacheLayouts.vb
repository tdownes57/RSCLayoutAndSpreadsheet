Public Class FormDisplayCacheLayouts
    ''
    ''Added 12/19/2021 Thomas Downes   
    ''
    Public PathToElementsCacheXML As String ''Added 12/19/2021 Thomas Downes
    Public UserChoosesABlankSlate As Boolean ''Added 12/20/2021 thomas downes  

    Public Shared Function FullPathToTimestampedXML() As String

        ''Added 12/19/2021 td
        Throw New Exception("Not implemented")

    End Function

    Private Sub pictureBackgroundFront_Click(sender As Object, e As EventArgs) Handles pictureBackgroundFront.Click

    End Sub

    Private Sub FormDisplayCacheLayouts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonOpenLayout_Click(sender As Object, e As EventArgs) Handles ButtonOpenLayout.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button.Click

        ''Added 12/20/2021 td  
        Me.UserChoosesABlankSlate = True
        Me.Close()

    End Sub

    Private Sub ButtonSelectDrive_Click(sender As Object, e As EventArgs) Handles ButtonSelectDrive.Click
        ''
        ''Added 12/20/2021 thomas downes
        ''
        Dim strPathToXML As String

        OpenFileDialog1.InitialDirectory = DiskFolders.PathToFolder_XML()
        OpenFileDialog1.FileName = ""

        Do
            OpenFileDialog1.ShowDialog()
            strPathToXML = OpenFileDialog1.FileName
            If (strPathToXML = "") Then Return
        Loop Until (Not DiskFilesVB.IsXMLFileMissing_OrEmpty(strPathToXML))

        If (DiskFilesVB.IsXMLFileMissing_OrEmpty(strPathToXML)) Then Return

        Me.PathToElementsCacheXML = strPathToXML
        Me.Close()

    End Sub


End Class