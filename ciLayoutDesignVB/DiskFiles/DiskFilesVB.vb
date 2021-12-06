Option Explicit On
Option Strict On

Imports System.IO ''Added 12/3/2021 thomas downes
''
''Added 10/12/2019 Thomas Downes    
''
Public Class DiskFilesVB
    ''
    ''Added 10/12/2019 Thomas Downes    
    ''
    Public Shared Function PathToFile_Background_FirstOrDefault(Optional ByRef pstrFileTitle As String = "") As String
        ''
        ''Added 12/03/2021 Thomas Downes    
        ''
        ''Return My.Application.Info.DirectoryPath & "\Images\Signatures\Declaration_bmp.bmp"
        ''Return System.IO.Path.Combine(DiskFolders.PathToFolder_BackExamples(), "Declaration_bmp.bmp")

        Dim objFolderInfo As New DirectoryInfo(DiskFolders.PathToFolder_BackExamples())
        Dim objFileInfo As FileInfo
        objFileInfo = objFolderInfo.GetFiles().FirstOrDefault
        pstrFileTitle = objFileInfo.Name ''Save the file title, i.e. the file's name (without the path preceding it).
        Return objFileInfo.FullName

    End Function ''Endo f "Public Shared Function PathToFile_Sig() As String"

    Public Shared Function PathToFile_Sig() As String
        ''
        ''Added 10/12/2019 Thomas Downes    
        ''
        Return My.Application.Info.DirectoryPath & "\Images\Signatures\Declaration_bmp.bmp"

    End Function ''Endo f "Public Shared Function PathToFile_Sig() As String"

    Public Shared Function PathToFile_XML_Personality() As String
        ''
        ''Added 1/14/2020 Thomas Downes    
        ''
        Dim strPathToXML As String

        ''The following line will allow the File | Save As....
        ''   menu item to be effective. ----10/13/2019 td
        strPathToXML = My.Settings.PathToXML_Saved_Personality

        If ("" = strPathToXML) Then
            ''1/24 td''strPathToXML = (My.Application.Info.DirectoryPath & "\ciLayoutDesignVB_Saved.xml").Replace("\\", "\")
            strPathToXML = (My.Application.Info.DirectoryPath & "\ciPersonality_Saved.xml").Replace("\\", "\")
        End If ''End of "If ("" = strPathToXML) Then"

        Return strPathToXML

    End Function ''End of "Public Shared Function PathToFile_XML_Personality() As String"

    Public Shared Function PathToFile_XML_ElementsCache() As String
        ''1/14/2020 td'Public Shared Function PathToFile_XML_ElementsCache() As String
        ''
        ''Added 10/12/2019 Thomas Downes    
        ''
        Dim strPathToXML As String

        ''The following line will allow the File | Save As....
        ''   menu item to be effective. ----10/13/2019 td
        strPathToXML = My.Settings.PathToXML_Saved_ElementsCache

        If ("" = strPathToXML) Then
            strPathToXML = (My.Application.Info.DirectoryPath & "\ciLayoutDesignVB_Saved.xml").Replace("\\", "\")
        End If ''End of "If ("" = strPathToXML) Then"

        Return strPathToXML

    End Function ''End of "Public Shared Function PathToFile_XML_ElementsCache() As String"


    Public Shared Sub DisplayStringDataInNotepad(par_stringData As String)
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
        System.Diagnostics.Process.Start(strRandomFilePath)

    End Sub ''ENd of "Public Shared Sub DisplayStringDataInNotepad()"


End Class ''eND OF "Public Class DiskFiles"
