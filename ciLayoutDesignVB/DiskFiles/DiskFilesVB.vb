﻿Option Explicit On
Option Strict On

Imports System.IO ''Added 12/3/2021 thomas downes
''
''Added 10/12/2019 Thomas Downes    
''
Public Enum EnumHowToLinkXMLs
    ''
    ''How should the various XMLs be linked/joined?  
    ''
    Undetermined

    AutoSubfolders ''Main file "[name].xml" causes a subfolder [name]"
    ''  to be generated, to contain associated XML files. ---7/16/2022 td 
    SuffixXmlTitles ''Main file "[name].xml" has associated XML files 
    ''  of the form "[name][suffix].xml".  ---7/16/2022 td
    EmbeddingPaths ''Main file "[name].xml" contains as a XML-specified value
    ''    the entire path (as the "contents" of an XML leaf item).
    DontLinkXMLs ''The XML files are _NOT_ linked.  ---7/16/2022 td

End Enum ''End of ""Public Enum EnumHowToLinkXMLs""

Public Class DiskFilesVB
    ''
    ''Added 10/12/2019 Thomas Downes    
    ''
    Public Shared Function FilePathIsValid(pstrPathTofile As String) As Boolean
        ''
        ''Added 6/13/2022 td
        ''
        If (String.IsNullOrEmpty(pstrPathTofile)) Then Return False
        If (String.IsNullOrWhiteSpace(pstrPathTofile)) Then Return False
        If (IO.File.Exists(pstrPathTofile)) Then Return True
        Return False

    End Function ''End of ""ublic Shared Function FilePathIsValid(pstrPathTofile As String) As Boolean""


    Public Shared Function FilePathIsValid_Choose(pstrPathToFile1 As String,
                                                  pstrPathToFile2 As String) As String
        ''
        ''Added 6/18/2022 td
        ''
        If (FilePathIsValid(pstrPathToFile1)) Then Return pstrPathToFile1
        If (FilePathIsValid(pstrPathToFile2)) Then Return pstrPathToFile2
        Return ""

    End Function ''End of ""Public Shared Function FilePathIsValid_Choose(pstrPathToFile1 As String, ...) As String""


    Public Shared Function PathToFile_Background_FirstOrDefault(Optional ByRef pstrFileTitle As String = "") As String
        ''
        ''Added 12/03/2021 Thomas Downes    
        ''
        ''Return My.Application.Info.DirectoryPath & "\Images\Signatures\Declaration_bmp.bmp"
        ''Return System.IO.Path.Combine(DiskFolders.PathToFolder_BackExamples(), "Declaration_bmp.bmp")

        ''6/11/2022 Dim objFolderInfo As New DirectoryInfo(DiskFolders.PathToFolder_BackgroundExampleDemos())
        Dim objFolderInfo As New DirectoryInfo(DiskFolders.PathToFolder_BackgroundImages())
        Dim objFileInfo As FileInfo
        objFileInfo = objFolderInfo.GetFiles().FirstOrDefault
        pstrFileTitle = objFileInfo.Name ''Save the file title, i.e. the file's name (without the path preceding it).
        Return objFileInfo.FullName

    End Function ''Endo f "Public Shared Function PathToFile_Background_FirstOrDefault() As String"


    Public Shared Function PathToFile_BackgroundSuffixSeconds(ByVal pstrFilePrefix As String) As String
        ''
        ''Added 6/11/2022 Thomas Downes    
        ''
        ''----Dim objFolderInfo As New DirectoryInfo(DiskFolders.PathToFolder_BackgroundImages())
        Dim strPathToFolder As String = (DiskFolders.PathToFolder_BackgroundImages())

        Dim strFileTitle As String

        strFileTitle = pstrFilePrefix & DateTime.Now.ToString("ss") & ".jpg"

        Dim strFullPathToJpeg As String ''Added 6/11/2022 
        strFullPathToJpeg = IO.Path.Combine(strPathToFolder, strFileTitle)
        Return strFullPathToJpeg

    End Function ''Endo f "Public Shared Function PathToFile_BackgroundSuffixSeconds() As String"


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


    Public Shared Function PathToFile_XML_PersonalityRecipientsCache(p_enumHowToLink As EnumHowToLinkXMLs,
                                                         pbCreateSubfolderForPRCache As Boolean,
                                                         pbSubfolderNameMatchesEleCacheTitle As Boolean,
                                                         Optional pstrPathToElementsCacheXML As String = "") As String
        ''
        ''This models what happens when a HTML page is saved (by MS Internet Explorer). Example:
        ''
        ''    C:\ie\business.html
        ''    C:\ie\business\logo.jpg
        ''    C:\ie\business\header.jpg 
        ''
        ''Example of inputs & outputs:
        '' 
        ''    Input pbPlaceInMainCacheSubfolder : True 
        ''    Input pstrPathToMainCacheXML : "D:\yy.xml"
        ''    Output:  "D:\yy\Recipients.xml"
        ''
        ''Added 1/14/2020 Thomas Downes    
        ''
        Dim strPathToXML As String = ""
        Dim bLinkToElementsCache As Boolean ''Added 7/16/2022 thomas 
        Const c_strCacheTitle As String = "ConfigWRecipients.xml" ''Added 7/16/2022

        ''The following line will allow the File | Save As....
        ''   menu item to be effective. ----10/13/2019 td
        ''---JULY13 2022----strPathToXML = My.Settings.PathToXML_Saved_Personality

        ''Added 7/16/2022 td
        bLinkToElementsCache = (p_enumHowToLink <> EnumHowToLinkXMLs.DontLinkXMLs)

        ''Added 7/15/2022 thomas downes
        If (bLinkToElementsCache) Then
            ''Added 7/15/2022 thomas downes
            If (Not pbCreateSubfolderForPRCache) Then System.Diagnostics.Debugger.Break()
            If (Not pbSubfolderNameMatchesEleCacheTitle) Then System.Diagnostics.Debugger.Break()
        End If ''End of ""If (pbLinkToElementsCache) Then""

        ''Added 7/13/2022
        If bLinkToElementsCache Then
            ''Added 7/13/2022
            ''   Remove the ".xml" extension to 
            Dim strPathToSubfolder As String

            If (pbSubfolderNameMatchesEleCacheTitle) Then

                strPathToSubfolder = pstrPathToElementsCacheXML.Replace(".xml", "")

                If (pbCreateSubfolderForPRCache) Then
                    IO.Directory.CreateDirectory(strPathToSubfolder)
                End If ''End of ""If (pbCreateSubfolderForPRCache) Then""

            Else
                ''Shouldn't occur. 
                System.Diagnostics.Debugger.Break()
                strPathToSubfolder = FileSystem.CurDir()

            End If ''End of ""If (pbSubfolderNameMatchesEleCacheTitle) Then ... Else ...""

            ''
            ''Put "Recipients.xml" into the subfolder. ---7/16/2022
            ''
            strPathToXML = IO.Path.Combine(strPathToSubfolder, c_strCacheTitle) ''.Replace("\\", "\")


        ElseIf ("" = strPathToXML) Then
            ''1/24 td''strPathToXML = (My.Application.Info.DirectoryPath & "\ciLayoutDesignVB_Saved.xml").Replace("\\", "\")
            strPathToXML = (My.Application.Info.DirectoryPath & "\ciPersonality_Saved.xml").Replace("\\", "\")

        End If ''end of ""If pboolPlaceInSubfolder Then""

        ''July13 2022 ----If ("" = strPathToXML) Then
        ''    ''1/24 td''strPathToXML = (My.Application.Info.DirectoryPath & "\ciLayoutDesignVB_Saved.xml").Replace("\\", "\")
        ''    strPathToXML = (My.Application.Info.DirectoryPath & "\ciPersonality_Saved.xml").Replace("\\", "\")
        ''End If ''End of "If ("" = strPathToXML) Then"

        Return strPathToXML

    End Function ''End of "Public Shared Function PathToFile_XML_Personality() As String"


    Public Shared Function PathToFile_XML_Personality_NotInUse() As String
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


    Public Shared Function PathToFile_XML_Customers() As String
        ''
        ''Added 2/18/2020 Thomas Downes    
        ''
        Dim strPathToXML As String

        ''The following line will allow the File | Save As....
        ''   menu item to be effective. ----10/13/2019 td
        strPathToXML = My.Settings.PathToXML_Saved_Customers

        If ("" = strPathToXML) Then
            strPathToXML = IO.Path.Combine(My.Application.Info.DirectoryPath, "Customers.xml")
        End If ''End of "If ("" = strPathToXML) Then"

        Return strPathToXML

    End Function ''End of "Public Shared Function PathToFile_XML_Customers() As String"


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


    Public Shared Function PathToFile_XML_RSCFieldSpreadsheet() As String
        ''
        ''Added 3/16/2022 Thomas Downes    
        ''
        Dim strPathToXML As String = ""

        ''The following line will allow the File | Save As....
        ''   menu item to be effective. ----10/13/2019 td
        ''strPathToXML = My.Settings.PathToXML_Saved_ElementsCache

        If ("" = strPathToXML) Then
            strPathToXML = (My.Application.Info.DirectoryPath &
                "\RSCFieldSpreadsheet.xml").Replace("\\", "\")
        End If ''End of "If ("" = strPathToXML) Then"

        Return strPathToXML

    End Function ''End of "Public Shared Function PathToFile_XML_RSCFieldSpreadsheet() As String"


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
        ''02/2023 Dim intLengthOfFileExtension As Integer

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


    ''02/2023 Public Shared Function FullPathToTimestampedXML() As String
    ''
    ''Added 12/19/2021 thomas downes
    ''
    ''02/2023  End Function ''End of "Public Shared Function FullPathToTimestampedXML() As String"


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
