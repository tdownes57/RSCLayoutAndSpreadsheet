Option Explicit On ''Added 12/5/2021 thomas downes 
Option Strict On ''Added 12/5/2021 thomas downes
''
''Added 12/5/2021 thomas downes 
''
Imports System.IO ''Added 12/5/2021 thomas downes

Public Module DiskFilesVB
    ''
    ''Added 12/5/2021 thomas downes 
    ''
    Public Sub DisplayStringDataInNotepad(ByRef par_stringData As String)
        ''
        ''Copied from Form__Main_Demo.vb on 12/5/2021 td   
        ''Added 11/28/2021 thomas downes  
        ''
        Dim strRandomFolder As String
        Dim strRandomFilePath As String
        Dim strRandomTitle As String

        strRandomFolder = DiskFolders.PathToFolder_Preview()
        strRandomTitle = String.Format("Elements {0:HHmmss}.txt", DateTime.Now)
        strRandomFilePath = System.IO.Path.Combine(strRandomFolder, strRandomTitle)
        System.IO.File.WriteAllText(strRandomFilePath, par_stringData)
        System.Threading.Thread.Sleep(1000)
        System.Threading.Thread.Sleep(1000)
        System.Diagnostics.Process.Start(strRandomFilePath)

    End Sub ''ENd of "Public Shared Sub DisplayStringDataInNotepad()"


    Public Function Path_RandomFileXML() As String
        ''
        ''Added 12/14/2021 td
        ''
        Dim strPathToFolder As String
        Dim strFileTitleTemporary As String
        Dim strFullFilePath As String

        ''Dec14 2021''strPathToFolder = DiskFolders.PathToFolder_XML()
        ''strFileTitleTemporary = IO.Path.GetTempFileName()
        strFileTitleTemporary = (IO.Path.GetRandomFileName() & ".xml")

        ''strFullFilePath = IO.Path.GetTempFileName()
        strPathToFolder = DiskFolders.PathToFolder_XML()
        strFullFilePath = IO.Path.Combine(strPathToFolder, strFileTitleTemporary)

        ''Return strFileTitleTemporary
        Return strFullFilePath

    End Function ''End of "Public Function Path_TemporaryFileXML() As String"


    Public Function Path_TemporaryFile() As String
        ''
        ''Added 12/14/2021 td
        ''
        ''Dim strPathToFolder As String
        Dim strFileTitleTemporary As String

        ''Dec14 2021''strPathToFolder = DiskFolders.PathToFolder_XML()
        strFileTitleTemporary = IO.Path.GetTempFileName()
        Return strFileTitleTemporary

    End Function ''End of "Public Function Path_TemporaryFile() As String"


    Public Function Path_ToSignatureImageFile() As String
        ''
        ''Added 12/22/2021 thomas downes
        ''
        Dim strPathToFolderForSigs As String

        strPathToFolderForSigs = DiskFolders.PathToFolder_Signatures

        Return IO.Path.Combine(strPathToFolderForSigs, "Declaration_jpg.jpg")

    End Function ''End of "Public Function Path_ToSignatureImageFile()"

End Module
