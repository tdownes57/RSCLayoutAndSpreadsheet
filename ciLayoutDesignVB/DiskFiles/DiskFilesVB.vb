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

    End Function ''Endo f "Public Shared Function PathToFile_Background_FirstOrDefault() As String"

    Public Shared Function PathToFile_Sig() As String
        ''
        ''Added 10/12/2019 Thomas Downes    
        ''
        '' "Declaration" = "Declaration of Independence" = John Hancock's famous big signature. 
        ''
        Return My.Application.Info.DirectoryPath & "\Images\Signatures\Declaration_bmp.bmp"

    End Function ''Endo f "Public Shared Function PathToFile_Sig() As String"

    Public Shared Function PathToNotes_HowContextMenusAreGenerated() As String
        ''
        ''Added 12/12/2021 Thomas Downes    
        ''
        ''
        Return IO.Path.Combine(DiskFolders.PathToFolder_Notes, "How_Context_Menus_Are_Generated.txt")

    End Function ''Endo f "Public Shared Function PathToNotes_HowContextMenusAreGenerated() As String"


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


    Public Shared Function PathToFile_BadgeLayout(pstrFileTitleOfCacheXML As String) As String
        ''
        ''Added 10/12/2019 Thomas Downes    
        ''
        ''  Let's assume, as an organizational rule, that the image of the badge-layout design (which will be
        ''  used to represent the XML file which is the serialization of the elements cache) will be saved with
        ''  the same name as the XML file--e.g. the image file representing "CI Badge Dec.2021.xml" will be 
        ''  named "CI Badge Dec.2021.jpg".   ---12/10/2021 thomas d.
        ''
        Dim strFileTitleJPG As String

        strFileTitleJPG = (pstrFileTitleOfCacheXML.Replace(".xml", "") & ".jpg")

        Return Path.Combine(DiskFolders.PathToFolder_BadgeLayoutImages, strFileTitleJPG)

    End Function ''End of "Public Shared Function PathToFile_BadgeLayout() As String"


    Public Shared Function IncrementFileTitle_UntilFree(pstrPathToFolder As String, pstrFileTitle_OriginalTry As String,
                                                        Optional ByRef pstrFullPathToNewFile As String = "") As String
        ''
        ''Added 12/10/2021 thomas downes
        ''
        ''Added 12/10/2021 td
        ''Dim strFileTitle_Original As String = ""
        Dim strFileTitle_Incremented As String = ""
        Dim bFilePathIsFree_Good As Boolean
        Dim strDestinationFilePath_Try As String = ""
        Dim strFileExtension As String = ""
        Dim objFileInfo As FileInfo
        Dim bOriginalTryFileIsNew_SoWeAreDone As Boolean

        bOriginalTryFileIsNew_SoWeAreDone = (Not File.Exists(IO.Path.Combine(pstrPathToFolder, pstrFileTitle_OriginalTry)))

        If (bOriginalTryFileIsNew_SoWeAreDone) Then
            pstrFullPathToNewFile = IO.Path.Combine(pstrPathToFolder, pstrFileTitle_OriginalTry)
            Return pstrFileTitle_OriginalTry
        Else
            ''
            ''The "Original Try" file exists, so let's create an object to represent the existing file. 
            ''
            objFileInfo = New FileInfo(IO.Path.Combine(pstrPathToFolder, pstrFileTitle_OriginalTry))
            strFileExtension = objFileInfo.Extension

        End If ''End of " If (bOriginalTryFileIsNew_SoWeAreDone) Then"

        ''strFileTitle_Original = pstrFileTitle_OriginalTry ''Me.ImageFileInfo.Name
        strFileExtension = objFileInfo.Extension

        For intTryForNewFile As Integer = 1 To 10
            ''strDestFilePath = System.IO.Path.Combine(strDestFilePath, Me.ImageFileInfo.Name)
            strFileTitle_Incremented = DiskFilesVB.IncrementFileTitle(pstrFileTitle_OriginalTry, strFileExtension, intTryForNewFile)
            strDestinationFilePath_Try = System.IO.Path.Combine(pstrPathToFolder, strFileTitle_Incremented)
            bFilePathIsFree_Good = Not IO.File.Exists(strDestinationFilePath_Try)
            If (bFilePathIsFree_Good) Then Exit For
        Next intTryForNewFile

        If (bFilePathIsFree_Good) Then
            pstrFullPathToNewFile = strDestinationFilePath_Try
            Return strFileTitle_Incremented
        End If ''End of "If (bFilePathIsFree_Good) Then"

        Throw New Exception("Cannot find a free (unused) file path & title.")  ''--Return ""

    End Function ''End of "Public Shared Function IncrementFileTitle_UntilFree()"


    Public Shared Function IncrementFileTitle(pstrFileTitle As String, pstrFileExtension As String,
                                              pintIncrement As Integer) As String
        ''
        ''Added 12/10/2021 thomas downes 
        ''
        ''  If the input string is "Thomas Downes.jpg", the function may return "Thomas Downes (4).jpg". 
        ''
        Dim intLengthOfFileExtension As Integer

        ''Dim objNewFileInfo As New FileInfo(pstrFileTitle)
        ''Dim strFileExention As String
        ''strFileExtension = objNewFileInfo.Extension

        Dim strOutputFileTitle_Format As String
        Dim strFileTitle_NoExt As String
        Dim strOutputFileTitle As String

        ''Save a string without the file extension.  
        strFileTitle_NoExt = pstrFileTitle.Replace("." & pstrFileExtension, "")

        ''E.g. "Thomas Downes ({0}).jpg" will become
        ''     "Thomas Downes (4).jpg".  
        strOutputFileTitle_Format = (strFileTitle_NoExt & " ({0})." & pstrFileExtension)

        strOutputFileTitle = String.Format(strOutputFileTitle_Format, pintIncrement)
        Return strOutputFileTitle

    End Function ''End of "Public Shared Function IncrementFileTitle"


    Public Shared Function FullPathToTimestampedXML() As String
        ''
        ''Added 12/19/2021 thomas downes
        ''

    End Function ''End of "Public Shared Function FullPathToTimestampedXML() As String"


    Public Shared Function IsXMLFileMissing_OrEmpty(pstrPathToElementsCacheXML As String) As Boolean
        ''Dec19 2021 ''Public Shared Function IsXMLFileEmpty
        ''
        ''Added 12/19/2021 thomas downes
        ''
        Dim boolNewFileXML As Boolean

        If (String.IsNullOrEmpty(pstrPathToElementsCacheXML)) Then Return True

        boolNewFileXML = (Not System.IO.File.Exists(pstrPathToElementsCacheXML))
        If (boolNewFileXML) Then Return True

        ''Added 12/19/2021 thomas downes
        Dim strTextOfFile As String
        strTextOfFile = IO.File.ReadAllText(pstrPathToElementsCacheXML)

        If (String.IsNullOrEmpty(strTextOfFile)) Then Return True

        Return False

    End Function ''ENd of "Public Shared Function IsXMLFileEmpty"


    Public Sub CopyPasteImageFile(pstrPathToImageFile_Existing As String,
                                  pstrPathToImageFolder_Proposed As String)
        ''
        ''Added 1/22/2022 td
        ''
        Dim objFileInfo As New FileInfo(pstrPathToImageFile_Existing)

        objFileInfo.CopyTo(Path.Combine(pstrPathToImageFolder_Proposed, objFileInfo.Name))


    End Sub ''End of "Public Sub CopyPasteImageFile(pstrPathToImageFile_Existing ...."


End Class ''eND OF "Public Class DiskFiles"
