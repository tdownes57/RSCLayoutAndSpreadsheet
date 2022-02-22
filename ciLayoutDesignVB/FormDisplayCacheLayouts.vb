Option Explicit On
Option Strict On
''
''Added 12/19/2021 Thomas Downes 
''
Imports ciBadgeCachePersonality ''Added 2/16/2022 thomas d.

Public Class FormDisplayCacheLayouts
    ''
    ''Added 12/19/2021 Thomas Downes   
    ''
    Public PathToElementsCacheXML_Input As String ''Added 12/19/2021 Thomas Downes
    Public PathToElementsCacheXML_Output As String ''Added 02/09/2022 Thomas Downes

    Public PathToElementsCacheXML_Folder As String = "" ''Added 2/25/2025 Thomas Downes
    Public PathToElementsCacheXML_Prior1 As String = "" ''Added 1/25/2025 Thomas Downes
    Public PathToElementsCacheXML_Prior2 As String = "" ''Added 1/25/2025 Thomas Downes
    Public PathToElementsCacheXML_Prior3 As String = "" ''Added 1/25/2025 Thomas Downes
    Public PathToElementsCacheXML_Prior4 As String = "" ''Added 1/25/2025 Thomas Downes

    Public UserChoosesABlankSlate As Boolean ''Added 12/20/2021 thomas downes  
    Public UserHasSelectedCancel As Boolean ''Added 12/20/2021 thomas downes
    Public PathToLastDirectoryForXMLFile As String ''Added 12/20/2021 thomas downes
    Public FileTitleOfXMLFile As String ''Added 1/22/2022 thomas downes
    ''Added 12/26/2021
    Public ShowMessageForIllformedXML As Boolean ''Added 12/26/2021 thomas downes
    Public UserWantsToExitApplication As Boolean ''Added 2/05/2022 Thomas Downes
    Public CacheCustomers As ClassCacheListCustomers ''Added 2/20/2022 thomas d.  

    Private WithEvents mod_dummyControl As New Control() ''Added 2/6/2022 td 

    Public Shared Function FullPathToTimestampedXML() As String

        ''Added 12/19/2021 td
        Throw New Exception("Not implemented")

    End Function

    Private Function CheckingXmlFile_IsOkay(par_strFullPathToXML As String, parLabelWarningMessage As Label) As Boolean
        ''Jan25 2022 td''Private Function CheckingXmlFile_IsOkay(parLabelFullPathToXML As Label,
        ''       parLabelWarningMessage As Label) As Boolean
        ''
        ''Added 12/20/2021 td
        ''
        Dim bCheckingFile_MissingOrEmpty As Boolean
        Dim boolCheckingFile_OK As Boolean

        ''Dec 20 2021''boolCheckingFile_OK = DiskFilesVB.IsXMLFileMissing_OrEmpty(LabelFullPathToXML.Text)
        ''Jan25 2022 ''bCheckingFile_MissingOrEmpty = DiskFilesVB.IsXMLFileMissing_OrEmpty(LabelFullPathToXML.Text)
        bCheckingFile_MissingOrEmpty = DiskFilesVB.IsXMLFileMissing_OrEmpty(par_strFullPathToXML)
        boolCheckingFile_OK = (Not bCheckingFile_MissingOrEmpty)

        If (boolCheckingFile_OK) Then
            ''This makes no sense to me right now. 1/25/2022 td
            If ("" = LabelFullPathToXML.Text) Then ''Added 1/25/2022 td
                LabelFullPathToXML.Text = par_strFullPathToXML
            End If ''End of "If ("" = LabelFullPathToXML.Text) Then"
            ''----Me.Close()
        Else
            parLabelWarningMessage.Text = "Warning, this file is missing or empty."
            parLabelWarningMessage.ForeColor = Color.Red
            parLabelWarningMessage.Visible = True
        End If ''End of "If (boolCheckingFile_OK) Then .... Else ....

        Return boolCheckingFile_OK

    End Function ''End of "Private Function CheckingXmlFile_IsOkay"


    Private Sub LoadPriorLayoutPictureBox(pstrPriorXMLFile As String)
        ''
        ''Added 1/25/2022 thomas downes
        ''
        Dim strPathToBadgeLayoutJPG As String ''Added 1/5/2022 td 
        Dim boolJpegConfirmed As Boolean ''Added 1/25/2022 td

        ''Added 1//26/2022 thomas downes
        If (pstrPriorXMLFile Is Nothing) Then Exit Sub
        If (pstrPriorXMLFile = "") Then Exit Sub
        If (Not IO.File.Exists(pstrPriorXMLFile)) Then Exit Sub ''Added 2/6/2022

        For intTry = 1 To 2

            ''Jan26 2022 td''strPathToBadgeLayoutJPG = Me.PathToElementsCacheXML.Replace(".xml", ".jpg")

            strPathToBadgeLayoutJPG = pstrPriorXMLFile.Replace(".xml", ".jpg")
            If (intTry = 1) Then strPathToBadgeLayoutJPG = pstrPriorXMLFile.Replace(".xml", ".jpg")
            If (intTry = 2) Then strPathToBadgeLayoutJPG = pstrPriorXMLFile.Replace(".xml", "_Front.jpg")

            boolJpegConfirmed = IO.File.Exists(strPathToBadgeLayoutJPG)
            If (boolJpegConfirmed) Then
                Dim picturePreviewPrior As New PictureBox
                With picturePreviewPrior
                    .Width = CInt(0.6 * FlowLayoutPanelPriorLays.Width)
                    ''Jan25 2022 td''.Height = CInt(.Width *
                    ''       ciLayoutPrintLib.LayoutPrint.ShortSideToLongSideRatio_point63())
                    .Height = CInt(.Width * ciBadgeInterfaces.ShortSideToLongSideRatio_HW_63())
                    .ImageLocation = strPathToBadgeLayoutJPG
                    .Tag = pstrPriorXMLFile
                    .SizeMode = PictureBoxSizeMode.Zoom
                End With ''ENd of "With picturePreviewPrior"

                AddHandler picturePreviewPrior.Click, AddressOf HandlePriorLayoutPictureBox_Click
                FlowLayoutPanelPriorLays.Controls.Add(picturePreviewPrior)
                picturePreviewPrior.Visible = True
                Exit For ''Added 2/6/2022

            End If ''End of "If (boolJpegConfirmed) Then"

        Next intTry ''Added 2/6/2022

    End Sub ''End of "Private Sub LoadPriorLayoutPictureBox(strPriorXMLFile1)"


    Public Function CheckPathXML_Okay(pstrPathToXML As String) As Boolean
        ''
        '' Added Jan. 26, 2022 thomas d.
        ''
        Dim boolXMLConfirmed As Boolean
        Dim boolJpegConfirmed As Boolean ''Added 1/25/2022 td
        Dim strPathToBadgeLayoutJPG As String

        ''2/9/2022 td''strPathToBadgeLayoutJPG = Me.PathToElementsCacheXML_Input.Replace(".xml", ".jpg")
        strPathToBadgeLayoutJPG = pstrPathToXML.Replace(".xml", ".jpg")
        boolJpegConfirmed = IO.File.Exists(strPathToBadgeLayoutJPG)
        boolXMLConfirmed = IO.File.Exists(pstrPathToXML)

        Return (boolXMLConfirmed And boolJpegConfirmed)

    End Function ''Endof "Public Sub CheckPathXML_Okay()"


    Private Sub HandlePriorLayoutPictureBox_Click(sender As Object, e As EventArgs) Handles mod_dummyControl.Click
        ''
        ''Added 1/25/2022 thomas downes
        ''
        Dim objPictureControl As PictureBox
        Dim objTagObject As Object ''Added 1/26/2022 thomas downes 
        Dim strPathToXML As String

        ''Added 2/6/2022 td
        Static static_strPathToXML_Prior As String
        If (static_strPathToXML_Prior = "") Then
            static_strPathToXML_Prior = Me.PathToElementsCacheXML_Input
        End If

        ''Jan26 2022''strPathToXML = CType(sender, PictureBox).Tag.ToString()
        objPictureControl = CType(sender, PictureBox)
        objTagObject = objPictureControl.Tag
        If (objTagObject Is Nothing) Then
            ''Added 1/26/2022 td
            MessageBoxTD.Show_Statement("Sorry, we cannot determine the XML path.")

        Else
            ''Convert the .Tab object to a string object. 
            strPathToXML = objTagObject.ToString()
            textboxPathToCacheXmlFile.Text = strPathToXML
            objPictureControl.BorderStyle = BorderStyle.FixedSingle

            ''Added 2/6/2022 td
            LoadMainDisplayControls(strPathToXML)

            ''Added 2/6/2022 td
            RemoveXML_FromPriorLayoutBox(strPathToXML)
            LoadPriorLayoutPictureBox(static_strPathToXML_Prior)
            static_strPathToXML_Prior = strPathToXML ''Prepare for next time. 

        End If ''End of "If (objTagObject Is Nothing) Then.... Else..."


    End Sub ''ENd of "Private Sub HandlePriorLayoutPictureBox_Click(sender As Object, e As EventArgs)"


    Private Sub FormDisplayCacheLayouts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 12/20/2021 td
        ''
        LoadMainDisplayControls(Me.PathToElementsCacheXML_Input)

        ''
        ''Encapsulated 2/6/2022 td
        ''
        Dim b_ExcludeFollowingLayout As Boolean = True
        LoadPriorAndCurrentLayouts_All(b_ExcludeFollowingLayout, Me.PathToElementsCacheXML_Input)

    End Sub ''End of ""Public Sub Form_Load""


    Private Sub RemoveXML_FromPriorLayoutBox(pstrPathToXML_Remove As String)
        ''
        ''Added 2/6/2022 td
        ''
        Dim objPictureControl As PictureBox
        Dim objTagObject As Object ''Added 1/26/2022 thomas downes 
        Dim strPathToXML As String
        Dim boolMatchesParameter As Boolean ''Added 2/6/2022
        Dim objPictureControlToRemove As PictureBox = Nothing

        For Each each_Box As PictureBox In FlowLayoutPanelPriorLays.Controls

            objPictureControl = CType(each_Box, PictureBox)
            objTagObject = objPictureControl.Tag
            If (objTagObject Is Nothing) Then
                ''Added 1/26/2022 td
                ''MessageBoxTD.Show_Statement("Sorry, we cannot determine the XML path.")

            Else
                ''Convert the .Tab object to a string object. 
                strPathToXML = objTagObject.ToString()
                boolMatchesParameter = (strPathToXML = pstrPathToXML_Remove)
                If (boolMatchesParameter) Then
                    objPictureControlToRemove = each_Box
                    Exit For
                End If ''End of "If (boolMatchesParameter) Then"
            End If ''End of "If (objTagObject Is Nothing) Then ... Else ..."

        Next each_Box

        ''
        ''Final operation.
        ''
        If (objPictureControlToRemove IsNot Nothing) Then
            FlowLayoutPanelPriorLays.Controls.Remove(objPictureControlToRemove)
        End If

    End Sub ''End of "Private Sub RemoveXML_FromPriorLayoutBox(pstrPathToXML_Remove As String)"


    Private Sub LoadMainDisplayControls(pstrPathToElementsCacheXML As String)
        ''
        ''Encapsulated 2/6/2022 td
        ''
        Dim strPathToBadgeLayoutJPG As String ''Added 1/5/2022 td 
        Dim strPathToBadgeLayout_FrontJPG As String ''Added 2/01/2022 td 
        Dim strPathToBadgeLayout_BacksideJPG As String ''Added 2/01/2022 td 

        LabelFullPathToXML.Text = pstrPathToElementsCacheXML ''Me.PathToElementsCacheXML
        textboxPathToCacheXmlFile.Text = pstrPathToElementsCacheXML ''Me.PathToElementsCacheXML ''Added 1/25/2022 td

        ''Double-check the proportions are correct. ---9/6/2019 td
        ''ClassLabelToImage.ProportionsAreSlightlyOff(pictureBackgroundFront, True)

        ClassLabelToImage.Proportions_FixTheWidth(picturePreviewFront) ''Added 12/23/2021 td 
        ClassLabelToImage.ProportionsAreSlightlyOff(picturePreviewFront, True) ''Added Dec. 20 2021

        ''Added 12/20/2021 thomas downes
        ''Jan25 2022 td''CheckingXmlFile_IsOkay(LabelFullPathToXML, LabelWarningMessage)
        ''Feb6 2022 td''CheckingXmlFile_IsOkay(Me.PathToElementsCacheXML, LabelWarningMessage)
        CheckingXmlFile_IsOkay(pstrPathToElementsCacheXML, LabelWarningMessage)

        ''Added 12/26/2021 thomas downes
        If (LabelWarningMessage.Visible = False) Then

            If (Me.ShowMessageForIllformedXML) Then

                LabelWarningMessage.Visible = True
                LabelWarningMessage.Text = "XML file is ill-formed internally, e.g. unterminated elements."

            End If ''end of "If (Me.ShowMessageForIllformedXML) Then"

        End If ''End of "If (LabelWarningMessage.Visible = False) Then"

        ''
        ''Display the saved Badge-Layout Jpeg Image. ---1/5/2022 td
        ''
        Const c_obseleteCode As Boolean = False ''Added 2/6/2022 thomas d.
        If (c_obseleteCode) Then
            ''
            ''I predict the following code will be 100% obselete by March 1, 2022.
            ''
        Else
            ''Feb6 2022 td''strPathToBadgeLayoutJPG = Me.PathToElementsCacheXML.Replace(".xml", ".jpg")
            strPathToBadgeLayoutJPG = pstrPathToElementsCacheXML.Replace(".xml", ".jpg")

            If (IO.File.Exists(strPathToBadgeLayoutJPG)) Then
                Me.picturePreviewFront.ImageLocation = strPathToBadgeLayoutJPG
                Me.picturePreviewFront.SizeMode = PictureBoxSizeMode.Zoom
            End If ''End of "If (IO.File.Exists(strPathToBadgeLayoutJPG)) Then"
        End If ''End of "If (c_obseleteCode) Then ... Else ..."

        ''
        ''Display the saved Badge-Layout Jpeg Image, Front side. ---2/1/2022 td
        ''
        ''Feb6 2022''strPathToBadgeLayout_FrontJPG = Me.PathToElementsCacheXML.Replace(".xml", "_Front.jpg")
        strPathToBadgeLayout_FrontJPG = pstrPathToElementsCacheXML.Replace(".xml", "_Front.jpg")

        If (IO.File.Exists(strPathToBadgeLayout_FrontJPG)) Then
            Me.picturePreviewFront.ImageLocation = strPathToBadgeLayout_FrontJPG
            Me.picturePreviewFront.SizeMode = PictureBoxSizeMode.Zoom
        End If

        ''
        ''Display the saved Badge-Layout Jpeg Image, Back side. ---2/1/2022 td
        ''
        ''Feb6 2022''strPathToBadgeLayout_BacksideJPG = Me.PathToElementsCacheXML.Replace(".xml", "_Back.jpg")
        strPathToBadgeLayout_BacksideJPG = pstrPathToElementsCacheXML.Replace(".xml", "_Back.jpg")

        Dim bJpegIsFoundExists As Boolean ''Added 2/6/2022 td
        bJpegIsFoundExists = (IO.File.Exists(strPathToBadgeLayout_BacksideJPG))

        If bJpegIsFoundExists Then
            Me.picturePreviewBackside.ImageLocation = strPathToBadgeLayout_BacksideJPG
            Me.picturePreviewBackside.SizeMode = PictureBoxSizeMode.Zoom
        End If ''Endof ""If bJpegIsFoundExists Then""

    End Sub ''End of "Private Sub LoadMainDisplayControls


    Private Sub LoadPriorAndCurrentLayouts_All(par_bExcludeOneLayout As Boolean,
                                  Optional psPathToLayoutToExcludeXML As String = "")
        ''
        ''Addded 2/6/2022 td
        ''
        ''Added 1/25/2022 thomas d. 
        Dim strPriorXMLFile1 As String = Me.PathToElementsCacheXML_Prior1
        Dim strPriorXMLFile2 As String = Me.PathToElementsCacheXML_Prior2
        Dim strPriorXMLFile3 As String = Me.PathToElementsCacheXML_Prior3
        Dim strPriorXMLFile4 As String = Me.PathToElementsCacheXML_Prior4

        ''Added 2/6/2022 thomas d.
        Dim strPathCurrentXML As String = Me.PathToElementsCacheXML_Input
        Dim strPathToFolder As String = Me.PathToElementsCacheXML_Folder
        Dim objHashset As New HashSet(Of String)

        objHashset.Add("12")
        objHashset.Add("12")
        objHashset.Add("12")

        ''Added 1/25/2022 thomas d. 
        FlowLayoutPanelPriorLays.Controls.Clear()

        ''Added 2/6/2022 td 
        Dim bFileIncludeCurr As Boolean = (strPathCurrentXML <> psPathToLayoutToExcludeXML)
        Dim bFileInclude1 As Boolean = (strPriorXMLFile1 <> psPathToLayoutToExcludeXML)
        Dim bFileInclude2 As Boolean = (strPriorXMLFile2 <> psPathToLayoutToExcludeXML)
        Dim bFileInclude3 As Boolean = (strPriorXMLFile3 <> psPathToLayoutToExcludeXML)
        Dim bFileInclude4 As Boolean = (strPriorXMLFile4 <> psPathToLayoutToExcludeXML)

        ''Added 1/25/2022 thomas d. 
        If (bFileIncludeCurr AndAlso CheckPathXML_Okay(strPathCurrentXML)) Then
            If UniquePerHashset(objHashset, strPathCurrentXML) Then
                LoadPriorLayoutPictureBox(strPathCurrentXML)
            End If
        End If

        ''
        ''Go through the numbered files. 
        ''
        ''Added 1/25/2022 thomas d. 
        If (bFileInclude1 AndAlso CheckPathXML_Okay(strPriorXMLFile1)) Then
            If UniquePerHashset(objHashset, strPriorXMLFile1) Then
                LoadPriorLayoutPictureBox(strPriorXMLFile1)
            End If
        End If

        If (bFileInclude2 AndAlso CheckPathXML_Okay(strPriorXMLFile2)) Then
            If UniquePerHashset(objHashset, strPriorXMLFile2) Then
                LoadPriorLayoutPictureBox(strPriorXMLFile2)
            End If
        End If

        If (bFileInclude3 AndAlso CheckPathXML_Okay(strPriorXMLFile3)) Then
            If UniquePerHashset(objHashset, strPriorXMLFile3) Then
                LoadPriorLayoutPictureBox(strPriorXMLFile3)
            End If
        End If

        If (bFileInclude4 AndAlso CheckPathXML_Okay(strPriorXMLFile4)) Then
            If UniquePerHashset(objHashset, strPriorXMLFile4) Then
                LoadPriorLayoutPictureBox(strPriorXMLFile4)
            End If
        End If

        ''
        ''Iterate through the specified folder, if it is found & existing.
        ''
        LoadAllLayouts_FoundInFolder(Me.PathToElementsCacheXML_Folder, objHashset, psPathToLayoutToExcludeXML)

        ''
        ''Iterate through _ALL_ parent folders, of current & prior XML files. 
        ''
        LoadAllLayouts_AllParentFolders(objHashset,
                                        psPathToLayoutToExcludeXML,
                                        Me.PathToElementsCacheXML_Folder)

    End Sub ''End of "Public Sub LoadPriorAndCurrentLayouts_All"


    Private Sub LoadAllLayouts_AllParentFolders(pobjHashsetOfFiles As HashSet(Of String),
                                             Optional pstrPathToLayoutToExcludeXML As String = "",
                                             Optional pstrPathToFolderToExclude As String = "")
        ''
        ''Added 2/6/2022 thomas d. 
        ''
        Dim objHashsetOfFolderPaths As New HashSet(Of String)
        objHashsetOfFolderPaths.Add(pstrPathToFolderToExclude) ''Exclude already processed folder. 

        Dim strPathToParentFolderCurr As String = ""
        Dim strPathToParentFolder1 As String = ""
        Dim strPathToParentFolder2 As String = ""
        Dim strPathToParentFolder3 As String = ""
        Dim strPathToParentFolder4 As String = ""

        Try
            strPathToParentFolderCurr = (New IO.FileInfo(Me.PathToElementsCacheXML_Input)).DirectoryName
            strPathToParentFolder1 = (New IO.FileInfo(Me.PathToElementsCacheXML_Prior1)).DirectoryName
            strPathToParentFolder2 = (New IO.FileInfo(Me.PathToElementsCacheXML_Prior2)).DirectoryName
            strPathToParentFolder3 = (New IO.FileInfo(Me.PathToElementsCacheXML_Prior3)).DirectoryName
            strPathToParentFolder4 = (New IO.FileInfo(Me.PathToElementsCacheXML_Prior4)).DirectoryName
        Catch ex As Exception
            ''Added 2/6/2022 td
            ''   Today, the string (Me.PathToElementsCacheXML_Prior3) was identified as a 
            ''   Null reference.  Not really a big deal. ----2/6/2022
            If (False) Then
                Throw
            End If
        End Try

        ''Check the current-XML folder. 
        If UniquePerHashset(objHashsetOfFolderPaths, strPathToParentFolderCurr) Then
            LoadAllLayouts_FoundInFolder(strPathToParentFolderCurr, pobjHashsetOfFiles,
                                         pstrPathToLayoutToExcludeXML)
        End If

        ''Go through the numbered folders. 
        If UniquePerHashset(objHashsetOfFolderPaths, strPathToParentFolder1) Then
            LoadAllLayouts_FoundInFolder(strPathToParentFolder1, pobjHashsetOfFiles,
                                         pstrPathToLayoutToExcludeXML)
        End If
        If UniquePerHashset(objHashsetOfFolderPaths, strPathToParentFolder2) Then
            LoadAllLayouts_FoundInFolder(strPathToParentFolder2, pobjHashsetOfFiles,
                                         pstrPathToLayoutToExcludeXML)
        End If
        If UniquePerHashset(objHashsetOfFolderPaths, strPathToParentFolder3) Then
            LoadAllLayouts_FoundInFolder(strPathToParentFolder3, pobjHashsetOfFiles,
                                         pstrPathToLayoutToExcludeXML)
        End If
        If UniquePerHashset(objHashsetOfFolderPaths, strPathToParentFolder4) Then
            LoadAllLayouts_FoundInFolder(strPathToParentFolder4, pobjHashsetOfFiles,
                                         pstrPathToLayoutToExcludeXML)
        End If

    End Sub ''End of "Private Sub LoadAllLayouts_AllParentFolders"


    Private Sub LoadAllLayouts_FoundInFolder(pstrPathToFolder As String,
                                             pobjHashset As HashSet(Of String),
                                             Optional pstrPathToLayoutToExcludeXML As String = "")
        ''
        ''Added 2/6/2022 thomas d. 
        ''
        If (pstrPathToFolder Is Nothing) Then Return
        If (pstrPathToFolder = "") Then Return
        If (IO.Directory.Exists(pstrPathToFolder) = False) Then Return

        Dim objDirectoryInfo As IO.DirectoryInfo
        Dim bExclude As Boolean
        objDirectoryInfo = New IO.DirectoryInfo(pstrPathToFolder)
        For Each each_file As IO.FileInfo In objDirectoryInfo.GetFiles("*.xml")

            bExclude = (each_file.FullName = pstrPathToLayoutToExcludeXML)
            If (bExclude) Then Continue For

            If (UniquePerHashset(pobjHashset, each_file.FullName)) Then
                LoadPriorLayoutPictureBox(each_file.FullName)
            End If

        Next each_file

    End Sub ''End of "Public Sub LoadAllLayouts_FoundInFolder"


    Private Function UniquePerHashset(par_hashset As HashSet(Of String),
                                      pstrPathToAdd As String) As Boolean
        ''
        ''Added 2/6/2022 td
        ''
        Try
            par_hashset.Add(pstrPathToAdd)
        Catch ex As Exception
            Return False
        End Try
        Return True

    End Function ''end of "Private Function UniquePerHashset"


    Private Sub ButtonOpenLayout_Click(sender As Object, e As EventArgs) Handles ButtonOpenCurrentLayout.Click
        ''
        ''Added 12/20/2021 td
        ''
        Dim bCheckingFile_OK As Boolean

        ''boolCheckingFile_OK = DiskFilesVB.IsXMLFileMissing_OrEmpty(LabelFullPathToXML.Text)
        ''If (boolCheckingFile_OK) Then
        ''    LabelFullPathToXML.Text = Me.PathToElementsCacheXML
        ''    Me.Close()
        ''Else
        ''    LabelWarningMessage.Text = "Warning, this file is missing or empty."
        ''    LabelWarningMessage.ForeColor = Color.Red
        ''    LabelWarningMessage.Visible = True
        ''End If ''End of "If (boolCheckingFile_OK) Then .... Else ....

        Dim strPathToXML As String = ""
        strPathToXML = textboxPathToCacheXmlFile.Text

        ''Jan25 2022 td''bCheckingFile_OK = (CheckingXmlFile_IsOkay(LabelFullPathToXML, LabelWarningMessage))
        bCheckingFile_OK = (CheckingXmlFile_IsOkay(strPathToXML, LabelWarningMessage))
        If (bCheckingFile_OK) Then
            Startup.SaveFullPathToFileXML_Settings(strPathToXML)
            Me.PathToElementsCacheXML_Output = strPathToXML
            Me.Close()
        End If ''Endo f "If (bCheckingFile_OK) Then"

    End Sub ''Private Sub ButtonOpenLayout_Click(sender As Object, e As EventArgs)


    Private Sub ButtonOpenNewBlank_Click(sender As Object, e As EventArgs) Handles ButtonOpenNewBlank.Click

        ''Added 12/20/2021 td  
        Me.UserChoosesABlankSlate = True
        Me.Close()

    End Sub


    Private Sub ButtonSelectDrive_Click(sender As Object, e As EventArgs) Handles ButtonSelectLayoutFromDrive.Click
        ''
        ''Added 12/20/2021 thomas downes
        ''
        Dim strPathToXML As String

        OpenFileDialog1.InitialDirectory = DiskFolders.PathToFolder_XML()
        If (Me.PathToLastDirectoryForXMLFile <> "") Then
            OpenFileDialog1.InitialDirectory = Me.PathToLastDirectoryForXMLFile
        End If ''End of "If (PathToLastDirectoryForXMLFile <> "") Then"
        ''1/22/2022''OpenFileDialog1.FileName = ""
        OpenFileDialog1.FileName = Me.FileTitleOfXMLFile

        Do
            OpenFileDialog1.ShowDialog()
            strPathToXML = OpenFileDialog1.FileName
            If (strPathToXML = "") Then Return

        Loop Until (Not DiskFilesVB.IsXMLFileMissing_OrEmpty(strPathToXML))

        If (DiskFilesVB.IsXMLFileMissing_OrEmpty(strPathToXML)) Then Return

        ''2/9/2022 td''Me.PathToElementsCacheXML_Input = strPathToXML
        Me.PathToElementsCacheXML_Output = strPathToXML
        Me.PathToLastDirectoryForXMLFile = (New IO.FileInfo(strPathToXML)).DirectoryName
        ''Added 1/22/2022 td
        Me.FileTitleOfXMLFile = (New IO.FileInfo(strPathToXML)).Name

        ''Added 1/5/2022 thomas d.
        ''Jan5 2022 t. downes''My.Settings.PathToXML_Saved_ElementsCache = strPathToXML
        ''Jan5 2022 t. downes''My.Settings.Save()

        ''Jan25 2022 td''Startup.SaveFullPathToFileXML(strPathToXML)
        ''Jan25 2022 td''Me.Close()

        textboxPathToCacheXmlFile.Text = strPathToXML

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles LabelWarningMessage.Click

    End Sub

    Private Sub ButtonUserCancels_Click(sender As Object, e As EventArgs) Handles ButtonUserCancels.Click
        ''
        ''Added 12/20/2021 td
        ''
        Me.UserHasSelectedCancel = True
        Me.Close()

    End Sub

    Private Sub ButtonExitApp_Click(sender As Object, e As EventArgs) Handles ButtonExitApp.Click

        ''Added 12/23/2021 thomas downes
        Me.UserWantsToExitApplication = True
        Application.Exit()

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        ''Added 12/23/2021 thomas downes
        ButtonOpenCurrentLayout.PerformClick()

    End Sub

    Private Sub ButtonFindLayout_Click(sender As Object, e As EventArgs) Handles ButtonFindLayout.Click

        ''Added 12/23/2021 
        ButtonSelectLayoutFromDrive.PerformClick()

    End Sub

    Private Sub picturePreview_Click(sender As Object, e As EventArgs) Handles picturePreviewFront.Click

        Dim boolTwoSidedBadge As Boolean ''Added 1/14/2022 td
        boolTwoSidedBadge = picturePreviewBackside.Visible
        ''Feb1 2022''Const c_bBackwardsAndConfusing As Boolean = False ''True ''Added 2/1/2022 td
        Const c_bUseSimpleWay As Boolean = True ''Added 2/1/2022 td

        If (boolTwoSidedBadge) Then

            ''Feb1 2022''------DIFFICULT AND CONFUSING-----
            ''Feb1 2022''If (c_bBackwardsAndConfusing) Then
            If (c_bUseSimpleWay) Then
                ''2/1/2022 td''CType(sender, Control).SendToBack()
                CType(sender, Control).BringToFront()
                Me.Invalidate()
                Return
            End If ''End of "If (c_bBackwardsAndConfusing) Then"

            ''
            ''Send __other__ PictureBox controls to the LOWEST Z-order, via the .SendToBack() command.  
            ''  --- 1/14/2022 td
            For Each eachControl In Me.Controls
                If (eachControl Is sender) Then Continue For
                If (TypeOf eachControl Is PictureBox) Then
                    ''Oops....2/1/2022 td''CType(sender, Control).SendToBack()
                    CType(eachControl, Control).BringToFront() ''Needed??  Added 2/1/2022 td
                    CType(eachControl, Control).SendToBack()
                End If
            Next eachControl

            ''Added 2/1/2022 td
            ''Feb1 2022 td''picturePreviewFront.Refresh()
            ''Me.Refresh()
            Me.Invalidate()

        Else
            ''Added 1/5/2022 td
            ''   Confirm that the most-recently edited layout is AGAIN the 
            ''   layout which the user would like to edit now. 
            ''   --- 1/14/2022 td
            ButtonOpenCurrentLayout.PerformClick()
        End If ''End of "If (boolTwoSidedBadge) Then... Else ..."


    End Sub

    Private Sub picturePreviewBackside_Click(sender As Object, e As EventArgs) Handles picturePreviewBackside.Click

        Dim boolTwoSidedBadge As Boolean ''Added 1/14/2022 td
        ''Feb1 2022''Const c_bBackwardsAndConfusing As Boolean = False ''True ''Added 2/1/2022 td
        Const c_bUseSimpleWay As Boolean = True ''Added 2/1/2022 td

        boolTwoSidedBadge = picturePreviewBackside.Visible

        If (boolTwoSidedBadge) Then
            ''Feb1 2022''------DIFFICULT AND CONFUSING-----
            ''Feb1 2022''If (c_bBackwardsAndConfusing) Then
            If (c_bUseSimpleWay) Then
                CType(sender, Control).BringToFront()
                Me.Invalidate()
                Return
            End If ''End of "If (c_bBackwardsAndConfusing) Then"

            ''
            ''Send __other__ PictureBox controls to the LOWEST Z-order, via the .SendToBack() command.  
            ''  --- 1/14/2022 td
            ''
            For Each eachControl In Me.Controls
                If (eachControl Is sender) Then
                    Continue For
                End If ''end of "If (eachControl Is sender) Then"
                If (TypeOf eachControl Is PictureBox) Then
                    ''Oops....2/1/2022''CType(sender, Control).SendToBack()
                    CType(eachControl, Control).BringToFront() ''Needed??  Added 2/1/2022 td
                    CType(eachControl, Control).SendToBack()
                End If ''end of "If (TypeOf eachControl Is PictureBox) Then"
            Next eachControl

            ''Added 2/1/2022 td
            ''Feb1 2022 td''picturePreviewBackside.Refresh()
            ''Feb1 2022 td''Me.Refresh()
            Me.Invalidate()

        End If ''End of "If (boolTwoSidedBadge) Then... Else ..."

    End Sub

    Private Sub picturePreviewFront_DoubleClick(sender As Object, e As EventArgs) Handles picturePreviewFront.DoubleClick

        ''Added 2/01/2022 td
        ''   Confirm that the most-recently edited layout is AGAIN the 
        ''   layout which the user would like to edit now. 
        ''   --- 1/14/2022 td
        ButtonOpenCurrentLayout.PerformClick()

    End Sub


    Private Sub buttonCustomers_Click(sender As Object, e As EventArgs) Handles buttonCustomers.Click
        ''
        ''Added 2/16/2022 thomas d. 
        ''
        Dim frm_ToShow As New DialogEditCustomers
        Dim cache_customers As ciBadgeCachePersonality.ClassCacheListCustomers
        Dim objListCustomers As HashSet(Of ciBadgeCustomer.ClassCustomer)
        Dim strPathToXML As String

        strPathToXML = My.Settings.PathToXML_Saved_Customers

        ''Added 2/18/2022 Thomas DOWNEES
        If (strPathToXML = "") Then strPathToXML = DiskFilesVB.PathToFile_XML_Customers()

        If (String.IsNullOrEmpty(strPathToXML)) Then
            ''
            ''Added 2/16/2022 td
            ''
            frm_ToShow.StartingFromScratch_NoXML = True

        ElseIf (Not IO.File.Exists(strPathToXML)) Then
            ''
            ''Added 2/18/2022 td
            ''
            frm_ToShow.StartingFromScratch_NoXML = True
            frm_ToShow.PathToXML = strPathToXML

        Else
            ''
            ''Open the Cache of Customers. 
            ''
            ''--cache_customers = ClassCacheListCustomers.GetCache(strPathToXML)
            ''--objListCustomers = cache_customers.ListOfCustomers
            ''--frm_ToShow.Load_Customers(objListCustomers)

            frm_ToShow.PathToXML = strPathToXML
            ''---++--Let's call this from the Load procedure.
            ''---++frm_ToShow.Load_Customers(strPathToXML)

        End If ''End of "If (String.IsNullOrEmpty(strPathToXML)) Then... Else..."

        ''
        ''Show the user the list of customers!!!!
        ''
        frm_ToShow.ShowDialog()

        ''Added 2/20/2022
        ''
        '' Get the output(s)  
        ''
        '' Actually, this is not needed. It's handled by the form. 
        ''
        If (cache_customers IsNot Nothing) Then
            cache_customers.SplitContainerProps = frm_ToShow.UserControlWidths
        End If ''End of "If (cache_customers IsNot Nothing) Then"

    End Sub ''End of "Private Sub buttonCustomers_Click"

    Private Sub ButtonRecipients_Click(sender As Object, e As EventArgs) Handles ButtonRecipients.Click
        ''
        '' Added 2/22/2022 td
        ''
        Dim frm_ToShow As New DialogEditRecipients
        frm_ToShow.Show()

    End Sub
End Class