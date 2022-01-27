Option Explicit On
Option Strict On

Public Class FormDisplayCacheLayouts
    ''
    ''Added 12/19/2021 Thomas Downes   
    ''
    Public PathToElementsCacheXML As String ''Added 12/19/2021 Thomas Downes
    Public PathToElementsCacheXML_Prior1 As String ''Added 1/25/2025 Thomas Downes
    Public PathToElementsCacheXML_Prior2 As String ''Added 1/25/2025 Thomas Downes
    Public PathToElementsCacheXML_Prior3 As String ''Added 1/25/2025 Thomas Downes
    Public PathToElementsCacheXML_Prior4 As String ''Added 1/25/2025 Thomas Downes
    Public UserChoosesABlankSlate As Boolean ''Added 12/20/2021 thomas downes  
    Public UserHasSelectedCancel As Boolean ''Added 12/20/2021 thomas downes
    Public PathToLastDirectoryForXMLFile As String ''Added 12/20/2021 thomas downes
    Public FileTitleOfXMLFile As String ''Added 1/22/2022 thomas downes
    ''Added 12/26/2021
    Public ShowMessageForIllformedXML As Boolean ''Added 12/26/2021 thomas downes

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

        ''Jan26 2022 td''strPathToBadgeLayoutJPG = Me.PathToElementsCacheXML.Replace(".xml", ".jpg")
        strPathToBadgeLayoutJPG = pstrPriorXMLFile.Replace(".xml", ".jpg")
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

        End If ''End of "If (boolJpegConfirmed) Then"

    End Sub ''End of "Private Sub LoadPriorLayoutPictureBox(strPriorXMLFile1)"


    Public Function CheckPathXML_Okay(pstrPathToXML As String) As Boolean
        ''
        '' Added Jan. 26, 2022 thomas d.
        ''
        Dim boolXMLConfirmed As Boolean
        Dim boolJpegConfirmed As Boolean ''Added 1/25/2022 td
        Dim strPathToBadgeLayoutJPG As String

        strPathToBadgeLayoutJPG = Me.PathToElementsCacheXML.Replace(".xml", ".jpg")
        boolJpegConfirmed = IO.File.Exists(strPathToBadgeLayoutJPG)
        boolXMLConfirmed = IO.File.Exists(pstrPathToXML)

        Return (boolXMLConfirmed And boolJpegConfirmed)

    End Function ''Endof "Public Sub CheckPathXML_Okay()"


    Private Sub HandlePriorLayoutPictureBox_Click(sender As Object, e As EventArgs)
        ''
        ''Added 1/25/2022 thomas downes
        ''
        Dim objPictureControl As PictureBox
        Dim objTagObject As Object ''Added 1/26/2022 thomas downes 
        Dim strPathToXML As String

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

        End If ''End of "If (objTagObject Is Nothing) Then.... Else..."


    End Sub ''ENd of "Private Sub HandlePriorLayoutPictureBox_Click(sender As Object, e As EventArgs)"


    Private Sub FormDisplayCacheLayouts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 12/20/2021 td
        ''
        Dim strPathToBadgeLayoutJPG As String ''Added 1/5/2022 td 

        LabelFullPathToXML.Text = Me.PathToElementsCacheXML
        textboxPathToCacheXmlFile.Text = Me.PathToElementsCacheXML ''Added 1/25/2022 td

        ''Double-check the proportions are correct. ---9/6/2019 td
        ''ClassLabelToImage.ProportionsAreSlightlyOff(pictureBackgroundFront, True)

        ClassLabelToImage.Proportions_FixTheWidth(picturePreviewFront) ''Added 12/23/2021 td 
        ClassLabelToImage.ProportionsAreSlightlyOff(picturePreviewFront, True) ''Added Dec. 20 2021

        ''Added 12/20/2021 thomas downes
        ''Jan25 2022 td''CheckingXmlFile_IsOkay(LabelFullPathToXML, LabelWarningMessage)
        CheckingXmlFile_IsOkay(Me.PathToElementsCacheXML, LabelWarningMessage)

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
        strPathToBadgeLayoutJPG = Me.PathToElementsCacheXML.Replace(".xml", ".jpg")
        Me.picturePreviewFront.ImageLocation = strPathToBadgeLayoutJPG
        Me.picturePreviewFront.SizeMode = PictureBoxSizeMode.Zoom

        ''Added 1/25/2022 thomas d. 
        Dim strPriorXMLFile1 As String = Me.PathToElementsCacheXML_Prior1
        Dim strPriorXMLFile2 As String = Me.PathToElementsCacheXML_Prior2
        Dim strPriorXMLFile3 As String = Me.PathToElementsCacheXML_Prior3
        Dim strPriorXMLFile4 As String = Me.PathToElementsCacheXML_Prior4

        ''Added 1/25/2022 thomas d. 
        FlowLayoutPanelPriorLays.Controls.Clear()

        ''Added 1/25/2022 thomas d. 
        If (CheckPathXML_Okay(strPriorXMLFile1)) Then LoadPriorLayoutPictureBox(strPriorXMLFile1)
        If (CheckPathXML_Okay(strPriorXMLFile2)) Then LoadPriorLayoutPictureBox(strPriorXMLFile2)
        If (CheckPathXML_Okay(strPriorXMLFile3)) Then LoadPriorLayoutPictureBox(strPriorXMLFile3)
        If (CheckPathXML_Okay(strPriorXMLFile4)) Then LoadPriorLayoutPictureBox(strPriorXMLFile4)

    End Sub ''edn of "Public Sub Form_Load"

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
            Startup.SaveFullPathToFileXML(strPathToXML)
            Me.Close()
        End If ''Endo f "If (bCheckingFile_OK) Then"

    End Sub


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

        Me.PathToElementsCacheXML = strPathToXML
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

        If (boolTwoSidedBadge) Then
            ''
            ''Send __other__ PictureBox controls to the LOWEST Z-order, via the .SendToBack() command.  
            ''  --- 1/14/2022 td
            For Each eachControl In Me.Controls
                If (eachControl Is sender) Then Continue For
                If (TypeOf eachControl Is PictureBox) Then CType(sender, Control).SendToBack()
            Next eachControl

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
        boolTwoSidedBadge = picturePreviewBackside.Visible
        If (boolTwoSidedBadge) Then
            ''
            ''Send __other__ PictureBox controls to the LOWEST Z-order, via the .SendToBack() command.  
            ''  --- 1/14/2022 td
            For Each eachControl In Me.Controls
                If (eachControl Is sender) Then Continue For
                If (TypeOf eachControl Is PictureBox) Then CType(sender, Control).SendToBack()
            Next eachControl
        End If ''End of "If (boolTwoSidedBadge) Then... Else ..."

    End Sub
End Class