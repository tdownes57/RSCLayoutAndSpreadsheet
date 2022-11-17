
Imports System.IO   ''Added 11/25/2021 Thomas Downes  

Public Class CtlBackground
    ''
    ''Added 11/25/2021 Thomas Downes  
    ''
    Public Event SelectedImageFilePathV1(strImageFilePath As String) ''Added 5/17/2022 td
    Public Event SelectedImageFilePathV2(sender As CtlBackground, strImageFilePath As String) ''Added 5/23/2022 td
    Public Event DeletingImageFilePath(sender As UserControl,
                                       strImageFilePath As String) ''Added 6/15/2022 td

    Public ImageFilePath As String
    Public ImageFileTitle As String
    Public ImageFileInfo As System.IO.FileInfo
    Public ImageIsSelected As Boolean
    Public ParentListingForm As FormBackgroundsSelect

    Private _boolSkipEvents As Boolean
    Private _isNotDisplayedAsListItem As Boolean

    Public Property IsNotSelectableItemOfAList() As Boolean
        Get
            ''Added 12/10/2021
            Return _isNotDisplayedAsListItem
        End Get
        Set(value As Boolean)
            ''Added 12/10/2021
            _isNotDisplayedAsListItem = value
            If (checkSelection.Visible And (value)) Then checkSelection.Visible = False
        End Set
    End Property


    Public Sub HideCheckbox()
        ''
        ''Added 11/25/2021 Thomas Downes  
        ''
        checkSelection.Visible = False

    End Sub


    Public Sub LoadIsSelectedValue(par_IsSelected As Boolean)
        ''
        ''Added 11/25/2021 Thomas Downes  
        ''
        Me.ImageIsSelected = par_IsSelected

        Me.checkSelection.AutoEllipsis = True
        _boolSkipEvents = True
        Me.checkSelection.Checked = par_IsSelected
        Application.DoEvents()
        _boolSkipEvents = False ''Revert to the default value. 

    End Sub

    Public Sub LoadImageFileByFileInfo(par_fileInfo As FileInfo,
                                       Optional par_isSelected As Boolean = False)
        ''
        ''Added 11/25/2021 Thomas Downes  
        ''
        ImageFilePath = par_fileInfo.FullName
        ImageFileTitle = par_fileInfo.Name
        ImageFileInfo = par_fileInfo
        LabelFileName.Text = par_fileInfo.Name

        ''Display the image. 
        ''---picturePreview.ImageLocation = par_fileInfo.FullName
        picturePreview.BackgroundImage = (New Bitmap(par_fileInfo.FullName))
        picturePreview.BackgroundImageLayout = ImageLayout.Zoom

        If (par_isSelected) Then
            ''Implement the IsSelected = True parameter.
            _boolSkipEvents = True
            checkSelection.Checked = True
            Application.DoEvents()
            _boolSkipEvents = False ''Revert to default value. 
            Me.ImageIsSelected = True
        End If ''If (par_isSelected) Then 

    End Sub ''End of "Public Sub LoadImageFileByFileInfo"

    Private Sub CtlBackground_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub picturePreview_Click(sender As Object, e As EventArgs) Handles picturePreview.Click
        ''
        ''Added 12/2/2021 td 
        ''
        Dim intReply As DialogResult
        Dim strNameOfImage As String ''----12/10/2021 td
        Const c_boolUserMustConfirm As Boolean = False ''Added 5/17/2022 td  

        If (_isNotDisplayedAsListItem) Then Return ''added 12/10/2021 

        strNameOfImage = Me.ImageFileTitle ''----12/10/2021 td

        ''This may help to prevent odd shifting after the selection is confirmed. ''----12/10/2021 td 
        Me.Parent.Focus() ''----12/10/2021 td

        ''
        ''If specified by the Boolean constant, have the user confirm selection.
        ''
        If (c_boolUserMustConfirm) Then
            intReply = MessageBox.Show("Please confirm your selection." & vbCrLf_Deux & strNameOfImage, "",
                                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        Else
            intReply = DialogResult.Yes

        End If ''End of ""If (c_boolUserMustConfirm) Then... Else...." 

        If (intReply = DialogResult.Yes Or intReply = DialogResult.OK) Then

            checkSelection.Checked = True

            ''Added 5/17/2022 thomas downes
            ''  The below RaiseEvent is probably not needed. See the call to
            ''       Me.ParentListingForm.LoadSelection(Me)
            ''  in the following event-handler below.  
            ''       Private Sub checkSelection_CheckedChanged
            ''  which contains the command
            ''       Me.ParentListingForm.LoadSelection(Me)
            ''  and propagates the image selection to the parent form.
            ''    ---5/17/2022 td
            ''5/23/2022 RaiseEvent SelectedImageFilePath(Me.ImageFilePath)
            RaiseEvent SelectedImageFilePathV1(Me.ImageFilePath)
            RaiseEvent SelectedImageFilePathV2(Me, Me.ImageFilePath)

        End If ''end of " If (intReply = DialogResult.Yes Or intReply = DialogResult.OK) Then"

    End Sub

    Private Sub checkSelection_CheckedChanged(sender As Object, e As EventArgs) Handles checkSelection.CheckedChanged
        ''
        ''Added 11/25/2021 td 
        ''
        Dim boolSelected As Boolean

        If (_boolSkipEvents) Then Exit Sub

        boolSelected = checkSelection.Checked
        Me.ImageIsSelected = boolSelected
        If (boolSelected) Then
            ''Me.ParentListingForm.TemporarySelectedFileInfo = Me.ImageFileInfo
            ''Dec.7 2021 ''Me.ParentListingForm.LoadSelection(Me)
            If (Me.ParentListingForm Is Nothing) Then
                ''Dec. 7 2021 thomas downes
                ''11/16/2022 MessageBox.Show("Unfortunately the image selected cannot be fully selected")
                MessageBoxTD.Show_Statement("Unfortunately the image selected cannot be fully selected")
                ''11/16/2022 Throw New Exception("Unfortunately we don't have a link to the parent form!!")
                __RSC_Error_Logging.RSCErrorLogging.Log(124, "We don't have a link to the parent form.",
                        "checkSelection_CheckedChanged")

            Else
                ''
                ''Propagate the selection to the parent form. ---5/17/2022
                ''
                ''5/23/2022 Me.ParentListingForm.LoadSelection(Me)
                Me.ParentListingForm.LoadSelection_ByUserControl(Me)

            End If ''End of "If (Me.ParentListingForm Is Nothing) Then .... Else ..."
        End If ''End of "If (boolSelected) Then"

    End Sub


    Public Sub Dispose_Image()

        ''Added 5/24/2022 td 
        Me.picturePreview.Image?.Dispose()


    End Sub

    Private Sub LinkRemoveImage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkRemoveImage.LinkClicked

        ''Added 6/14/2022 
        Dim strPathToFile As String
        Dim boolConfirmed As Boolean

        ''
        ''Clear the Preview box. 
        ''
        ''June2022''Me.picturePreview.Image = Nothing ''Added 6/15/2022
        ''June2022''Me.picturePreview.BackgroundImage = Nothing ''Added 6/15/2022

        boolConfirmed = MessageBoxTD.Show_Confirm("Want to remove this background image from the list of uploaded images?")
        If (boolConfirmed) Then
            Try
                strPathToFile = Me.ImageFilePath
                Me.picturePreview.Image?.Dispose()
                Application.DoEvents()
                Me.picturePreview.BackgroundImage?.Dispose() ''Added 6/14/2022
                Application.DoEvents()
                Me.picturePreview.Image = Nothing
                Me.picturePreview.Dispose()
                Application.DoEvents()
                Me.Dispose_Image()
                Application.DoEvents()
                Me.Dispose()
                Application.DoEvents()
                BackgroundImage?.Dispose()
                BackgroundImage = Nothing
                Application.DoEvents()

                ''Added 6/15/2022 thomas d.
                RaiseEvent DeletingImageFilePath(Me, Me.ImageFilePath)
                Application.DoEvents()
                Application.DoEvents()
                Application.DoEvents()
                Application.DoEvents()
                IO.File.Move(strPathToFile, strPathToFile & ".hide")

            Catch ex_hh As Exception
                System.Diagnostics.Debugger.Break()
            End Try
        End If ''End of ""If (boolConfirmed) Then""

    End Sub
End Class
