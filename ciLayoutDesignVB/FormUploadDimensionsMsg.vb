Public Class FormUploadDimensionsMsg

    ''Added 12/2/2021 thomas c. downes
    Public UploadedImage As Image
    Private mod_bSuppressEvents As Boolean
    Private mod_pathToImageFile As String

    Public Sub UploadedImageFile(par_pathToImageFile As String)
        ''
        ''Added 12/2/2021 td
        ''
        ''We'll set .BackgroundImage instead.  12/2/2012''PictureUploaded.ImageLocation = par_pathToImageFile
        ''
        mod_pathToImageFile = par_pathToImageFile
        Dim bitmapUploaded As New Bitmap(par_pathToImageFile)
        Me.UploadedImage = bitmapUploaded

        ''Set the background image. 
        pictureUploaded.BackgroundImage = Me.UploadedImage
        pictureUploaded.BackgroundImageLayout = ImageLayout.Zoom

        CtlWidthHeightUploaded.ImageToDescribe(Me.UploadedImage, True, True)
        CtlWidthHeightInputWidth.ImageToDescribe(Me.UploadedImage, True, False)
        CtlWidthHeightInputHeight.ImageToDescribe(Me.UploadedImage, False, True)

        ''------------------------
        ''Check image dimensions.
        ''-------------------------
        Dim boolImageHasDimensionsOfPVC As Boolean

        boolImageHasDimensionsOfPVC = ciBadgeInterfaces.ClassFixTheControlWidth.ProportionsAreSlightlyOff(Me.UploadedImage, False)

        ''PanelDimensionsAreOff.Visible = boolImageHasDimensionsOfPVC

        Dim intPixelsLost_Width As Integer '' = CtlWidthHeightInputHeight.GetNumberOfPixelsPotentiallyLost()
        Dim intPixelsLost_height As Integer '' = CtlWidthHeightInputWidth.GetNumberOfPixelsPotentiallyLost()
        Dim intSumOfPixelsLost As Integer
        Dim intPixelsLost_maximum As Integer

        ''-----DIFFICULT & CONFUSING-----
        ''In the next two lines, it might seem reversed. This is correct programming.
        ''  ----12/2/2021 Thomas D. 
        ''
        intPixelsLost_Width = CtlWidthHeightInputHeight.GetNumberOfPixelsPotentiallyLost()
        intPixelsLost_height = CtlWidthHeightInputWidth.GetNumberOfPixelsPotentiallyLost()
        intPixelsLost_maximum = CInt(IIf(intPixelsLost_height > intPixelsLost_Width, intPixelsLost_height, intPixelsLost_Width))

        If (0 > intPixelsLost_Width) Then Throw New Exception("This number (PixelsLost_Width) should not be negative!")
        If (0 > intPixelsLost_height) Then Throw New Exception("This number (PixelsLost_Height) should not be negative!")

        intSumOfPixelsLost = (intPixelsLost_Width + intPixelsLost_height)

        ''Do we need to show the detail panel?  
        Dim boolDimensionsAreOff As Boolean
        boolDimensionsAreOff = (intSumOfPixelsLost > 10)
        PanelDimensionsAreOff.Visible = boolDimensionsAreOff
        mod_bSuppressEvents = True
        checkShowDetail.Checked = boolDimensionsAreOff
        Application.DoEvents()
        mod_bSuppressEvents = False ''Restore the default. 
        LabelLossOfPixelsMaximum.Text = String.Format(LabelLossOfPixelsMaximum.Tag.ToString,
            intPixelsLost_maximum)

        ''Show the appropriate button(s) 
        ButtonHelpMeDecide.Visible = boolDimensionsAreOff
        ButtonSkipEditor.Visible = boolDimensionsAreOff

        Dim boolDimensionsAreFine As Boolean
        boolDimensionsAreFine = (Not boolDimensionsAreOff)
        LabelDimensionsAreAllOkay.Visible = boolDimensionsAreFine
        ButtonGreat.Visible = boolDimensionsAreFine

    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles PanelDimensionsAreOff.Paint

    End Sub

    Private Sub ButtonHelpMeDecide_Click(sender As Object, e As EventArgs) Handles ButtonHelpMeDecide.Click
        ''
        ''Added 12/2/2021 thomas downes 
        ''
        Dim objFormToShow As New FormUploadEditingImage

        objFormToShow.UploadedImageFile(mod_pathToImageFile)
        objFormToShow.ShowDialog()

    End Sub

    Private Sub ButtonSkipEditor_Click(sender As Object, e As EventArgs) Handles ButtonSkipEditor.Click

        Me.Close() ''Added 12/2/2021 td 

    End Sub

    Private Sub FormUploadDimensionsMsg_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonGreat_Click(sender As Object, e As EventArgs) Handles ButtonGreat.Click

        Me.Close() ''Added 12/2/2021 thomas downes

    End Sub

    Private Sub checkShowDetail_CheckedChanged(sender As Object, e As EventArgs) Handles checkShowDetail.CheckedChanged

        ''Added 12/2/2021 td
        If (mod_bSuppressEvents) Then Exit Sub
        PanelDimensionsAreOff.Visible = checkShowDetail.Checked

    End Sub

    Private Sub checkExpandBadgeView_CheckedChanged(sender As Object, e As EventArgs) Handles checkExpandBadgeView.CheckedChanged
        ''
        ''Added 12/2/2021
        ''
        If (checkExpandBadgeView.Checked) Then

            picturePVCCards.Visible = False
            pictureUploaded.Width = (picturePVCCards.Width + pictureAnchorOnly.Width)
            pictureUploaded.Left = picturePVCCards.Left
            checkExpandBadgeView.Left = pictureUploaded.Left

        Else

            picturePVCCards.Visible = True
            pictureUploaded.Width = pictureAnchorOnly.Width
            pictureUploaded.Left = pictureAnchorOnly.Left
            checkExpandBadgeView.Left = pictureUploaded.Left

        End If ''End of "If (checkExpandBadgeView.Checked) Then ... Else ...."


    End Sub

    Private Sub CtlWidthHeightInputHeight_Load(sender As Object, e As EventArgs) Handles CtlWidthHeightInputHeight.Load

    End Sub
End Class