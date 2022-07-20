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
    Public Enum EnumHowToLinkXMLs
        ''
        ''How should the various XMLs be linked/joined?  
        ''
        Undetermined

        AutoSubfolders ''Main file "[name].xml" causes a subfolder [name]"
        ''  to be generated, to contain associated XML files. This models what happens when 
        ''  a HTML page is saved (by MS Internet Explorer). Example:
        ''
        ''    C:\ie\business.html
        ''    C:\ie\business\logo.jpg
        ''    C:\ie\business\header.jpg 
        ''
        ''  Notice that the "business" in the first file becomes
        ''  the subfolder's name in the path of the other files.
        ''
        ''  Example XML files:
        ''
        ''    C:\RSC\IDCardLayout.xml
        ''          \IDCardLayout\RecipientsPersonality.xml
        ''          \IDCardLayout\SpreadsheetData.xml
        ''
        ''---7/16/2022 td 

        SuffixXmlTitles ''Main file "[name].xml" has associated XML files 
        ''  of the form "[name][suffix].xml".  ---7/16/2022 td
        ''
        ''  Example XML files:
        ''
        ''    C:\RSC\IDCardLayout.xml
        ''          \IDCardLayout_RecipsPers.xml
        ''          \IDCardLayout_SpreadData.xml
        ''
        ''---7/16/2022 td 
        ''
        EmbeddingPaths ''Main file "[name].xml" contains as a XML-specified value
        ''    the entire path (as the "contents" of an XML leaf item).
        DontLinkXMLs ''The XML files are _NOT_ linked.  ---7/16/2022 td

    End Enum ''End of ""Public Enum EnumHowToLinkXMLs""


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


    Public Function Path_ToGraphicsImageFile() As String
        ''
        ''Added 5/14/2022 thomas downes
        ''
        Dim strPathToFolderForGraphics As String

        strPathToFolderForGraphics = DiskFolders.PathToFolder_Graphics

        Return IO.Path.Combine(strPathToFolderForGraphics, "code-ninjas-logo.jpg")

    End Function ''End of "Public Function Path_ToGraphicsImageFile()"


    Public Function PathToNotes_HowContextMenusAreGenerated() As String
        ''
        ''Added 12/12/2021 Thomas Downes    
        ''
        ''
        Return IO.Path.Combine(DiskFolders.PathToFolder_Notes, "How_Context_Menus_Are_Generated.txt")

    End Function ''Endo f "Public Shared Function PathToNotes_HowContextMenusAreGenerated() As String"


End Module
