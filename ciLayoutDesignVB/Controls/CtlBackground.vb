
Imports System.IO   ''Added 11/25/2021 Thomas Downes  

Public Class CtlBackground
    ''
    ''Added 11/25/2021 Thomas Downes  
    ''
    Public ImageFilePath As String
    Public ImageFileTitle As String
    Public ImageFileInfo As System.IO.FileInfo
    Public ImageIsSelected As Boolean
    Public ParentListingForm As FormListBackgrounds
    Private _boolSkipEvents As Boolean

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

        intReply = MessageBox.Show("Please confirm your selection.", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If (intReply = DialogResult.Yes Or intReply = DialogResult.OK) Then

            checkSelection.Checked = True

        End If

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
                MessageBox.Show("Unfortunately the image selected cannot be fully selected")
                Throw New Exception("Unfortunately we don't have a link to the parent form!!")
            Else
                Me.ParentListingForm.LoadSelection(Me)
            End If ''End of "If (Me.ParentListingForm Is Nothing) Then .... Else ..."
        End If ''End of "If (boolSelected) Then"

    End Sub
End Class
