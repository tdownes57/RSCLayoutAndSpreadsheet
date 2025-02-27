﻿Option Explicit On
Option Strict On

Public Class FormDisplayCacheLayouts
    ''
    ''Added 12/19/2021 Thomas Downes   
    ''
    Public PathToElementsCacheXML As String ''Added 12/19/2021 Thomas Downes
    Public UserChoosesABlankSlate As Boolean ''Added 12/20/2021 thomas downes  
    Public UserHasSelectedCancel As Boolean ''Added 12/20/2021 thomas downes
    Public PathToLastDirectoryForXMLFile As String ''Added 12/20/2021 thomas downes
    ''Added 12/26/2021
    Public ShowMessageForIllformedXML As Boolean ''Added 12/26/2021 thomas downes

    Public Shared Function FullPathToTimestampedXML() As String

        ''Added 12/19/2021 td
        Throw New Exception("Not implemented")

    End Function

    Private Function CheckingXmlFile_IsOkay(parLabelFullPathToXML As Label, parLabelWarningMessage As Label) As Boolean
        ''
        ''Added 12/20/2021 td
        ''
        Dim bCheckingFile_MissingOrEmpty As Boolean
        Dim boolCheckingFile_OK As Boolean

        ''Dec 20 2021''boolCheckingFile_OK = DiskFilesVB.IsXMLFileMissing_OrEmpty(LabelFullPathToXML.Text)
        bCheckingFile_MissingOrEmpty = DiskFilesVB.IsXMLFileMissing_OrEmpty(LabelFullPathToXML.Text)
        boolCheckingFile_OK = (Not bCheckingFile_MissingOrEmpty)

        If (boolCheckingFile_OK) Then
            parLabelFullPathToXML.Text = Me.PathToElementsCacheXML
            ''----Me.Close()
        Else
            parLabelWarningMessage.Text = "Warning, this file is missing or empty."
            parLabelWarningMessage.ForeColor = Color.Red
            parLabelWarningMessage.Visible = True
        End If ''End of "If (boolCheckingFile_OK) Then .... Else ....

        Return boolCheckingFile_OK

    End Function ''End of "Private Function CheckingXmlFile_IsOkay"


    Private Sub FormDisplayCacheLayouts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 12/20/2021 td
        ''
        Dim strPathToBadgeLayoutJPG As String ''Added 1/5/2022 td 

        LabelFullPathToXML.Text = Me.PathToElementsCacheXML

        ''Double-check the proportions are correct. ---9/6/2019 td
        ''ClassLabelToImage.ProportionsAreSlightlyOff(pictureBackgroundFront, True)

        ClassLabelToImage.Proportions_FixTheWidth(picturePreview) ''Added 12/23/2021 td 
        ClassLabelToImage.ProportionsAreSlightlyOff(picturePreview, True) ''Added Dec. 20 2021

        ''Added 12/20/2021 thomas downes
        CheckingXmlFile_IsOkay(LabelFullPathToXML, LabelWarningMessage)

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
        Me.picturePreview.ImageLocation = strPathToBadgeLayoutJPG
        Me.picturePreview.SizeMode = PictureBoxSizeMode.Zoom

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

        bCheckingFile_OK = (CheckingXmlFile_IsOkay(LabelFullPathToXML, LabelWarningMessage))
        If (bCheckingFile_OK) Then Me.Close()

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
        If (PathToLastDirectoryForXMLFile <> "") Then
            OpenFileDialog1.InitialDirectory = PathToLastDirectoryForXMLFile
        End If ''End of "If (PathToLastDirectoryForXMLFile <> "") Then"
        OpenFileDialog1.FileName = ""

        Do
            OpenFileDialog1.ShowDialog()
            strPathToXML = OpenFileDialog1.FileName
            If (strPathToXML = "") Then Return

        Loop Until (Not DiskFilesVB.IsXMLFileMissing_OrEmpty(strPathToXML))

        If (DiskFilesVB.IsXMLFileMissing_OrEmpty(strPathToXML)) Then Return

        Me.PathToElementsCacheXML = strPathToXML
        Me.PathToLastDirectoryForXMLFile = (New IO.FileInfo(strPathToXML)).DirectoryName

        ''Added 1/5/2022 thomas d.
        ''Jan5 2022 t. downes''My.Settings.PathToXML_Saved_ElementsCache = strPathToXML
        ''Jan5 2022 t. downes''My.Settings.Save()
        Startup.SaveFullPathToFileXML(strPathToXML)

        Me.Close()

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

    Private Sub picturePreview_Click(sender As Object, e As EventArgs) Handles picturePreview.Click

        ''Added 1/5/2022 td
        ButtonOpenCurrentLayout.PerformClick()

    End Sub

    Private Sub picturePreview_DoubleClick(sender As Object, e As EventArgs) Handles picturePreview.DoubleClick



    End Sub
End Class