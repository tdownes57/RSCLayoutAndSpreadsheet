Option Explicit On
Option Strict On
''
''Added 5/18/2022 
''
''---Imports monem
Imports ciBadgeDesigner ''Added 6/3/2022 

Public Class FormBackgroundEditImage
    ''
    '' Added 11/30/2021 thomas downes
    ''
    Public UploadedImage As Image
    Public ImageFilePath_input As String = "" ''Added 5/18/2022 
    Public ImageFilePath_output As String = "" ''Added 5/18/2022 
    ''---Public ImageFileInfo As System.IO.FileInfo ''Added 5/18/2022 

    Private mod_bSuppressEvents As Boolean = True
    Private mod_bLoading As Boolean = True ''Added 6/04/2022 

    Private mod_pathToImageFile As String
    ''----Private mod_objEventsMoveGroupOfCtls As New 
    Private Const mc_boolEnlargeMoveable As Boolean = False ''Added 5/24/2022
    Private Const mc_boolEnlargeToPreviewForScrapeSize As Boolean = False ''Added 6/2/2022

    Public Sub Load_ImageFileToEdit(par_pathToImageFile As String)
        ''5/23/2022 ''Public Sub UploadedImageFile
        ''
        ''Added 12/2/2021 td
        ''
        ''We'll set .BackgroundImage instead.  12/2/2012''PictureUploaded.ImageLocation = par_pathToImageFile

        Dim bitmapUploaded As New Bitmap(par_pathToImageFile)
        Me.UploadedImage = bitmapUploaded

        ''Set the background image. 

        ''Center
        pictureLayoutCenter.BackgroundImage = Me.UploadedImage
        pictureLayoutCenter.BackgroundImageLayout = ImageLayout.Center

        ''None
        pictureLayoutNormal.BackgroundImage = Me.UploadedImage
        pictureLayoutNormal.BackgroundImageLayout = ImageLayout.None

        ''Stretch
        pictureLayoutStretch.BackgroundImage = Me.UploadedImage
        pictureLayoutStretch.BackgroundImageLayout = ImageLayout.Stretch

        ''Zoom
        pictureLayoutZoom.BackgroundImage = Me.UploadedImage
        pictureLayoutZoom.BackgroundImageLayout = ImageLayout.Zoom




    End Sub ''End of ""Public Sub Load_ImageFileToEdit""



    Private Sub TakeScreenshot_Master(par_ctlPictureBox As PictureBox)
        ''
        ''Added 6/03/2022  
        ''
        Dim stylePictureBoxSizeMode As PictureBoxSizeMode ''Added 5/22/2022 
        Dim intWidth, intHeight As Integer

        stylePictureBoxSizeMode = par_ctlPictureBox.SizeMode
        intWidth = par_ctlPictureBox.Width
        intHeight = par_ctlPictureBox.Height

        Dim objFormToShow As New FormBackgroundScreenscape

        With objFormToShow
            .Input_PictureBoxSizeMode = stylePictureBoxSizeMode
            .Input_BackgroundImage = par_ctlPictureBox.Image
            .Input_ShowMoveableControl = False

            Select Case par_ctlPictureBox.SizeMode
                Case PictureBoxSizeMode.AutoSize
                    .Input_ShowSizingControl = True
                Case PictureBoxSizeMode.CenterImage
                    .Input_ShowSizingControl = True
                Case PictureBoxSizeMode.Normal
                    .Input_ShowSizingControl = True
                Case PictureBoxSizeMode.StretchImage
                    .Input_ShowSizingControl = False
                Case PictureBoxSizeMode.Zoom
                    .Input_ShowSizingControl = False
            End Select

            ''
            ''Major call!!
            ''
            .ShowDialog()

            Dim imageEdited As Drawing.Image
            imageEdited = .Output_Image
            picturePreview.Image = imageEdited

        End With

    End Sub ''End of ""Private Sub TakeScreenshot_Master(par_ctlPictureBox As PictureBox)""


    Private Sub TakeScreenshot_Master(par_ctlMoveableImage As CtlMoveableBackground)
        ''
        ''Added 6/03/2022  
        ''
        Dim intWidth, intHeight As Integer
        Dim intPositionX, intPositionY As Integer

        intWidth = par_ctlMoveableImage.Width
        intHeight = par_ctlMoveableImage.Height
        intPositionX = par_ctlMoveableImage.GetPositionX()
        intPositionY = par_ctlMoveableImage.GetPositionY()

        Dim objFormToShow As New FormBackgroundScreenscape

        With objFormToShow

            .Input_PictureBoxSizeMode = PictureBoxSizeMode.Normal
            .Input_BackgroundImage = par_ctlMoveableImage.ImageBackgroundImage
            .Input_ShowMoveableControl = True
            .Input_MoveablePositionX = intPositionX
            .Input_MoveablePositionY = intPositionY
            .Input_MoveableWidth = intWidth
            .Input_MoveableHeight = intHeight

            ''
            ''Major call!!
            ''
            .ShowDialog()

            Dim imageEdited As Drawing.Image
            imageEdited = .Output_Image
            picturePreview.Image = imageEdited

        End With

    End Sub ''End of ""Private Sub TakeScreenshot_Master(par_ctlPictureBox As PictureBox)""


    Private Sub TakeScreenshot_Master_TemporarilyNotInUse(par_ctlPictureBox As PictureBox,
                          Optional pboolUseCenterPreviewLarge As Boolean = True)
        ''---5/18/2022 Private Sub TakeScreenshot_Master(par_ctlPictureBox As PictureBox)
        ''
        ''Added 5/18/2022  
        ''
        ''Dim objRectangle1 As Rectangle
        Dim objRectangle2 As Rectangle
        Dim bTryToOmitBorder As Boolean
        Dim stylePictureBoxSizeMode As PictureBoxSizeMode ''Added 5/22/2022 

        bTryToOmitBorder = True ''---checkOmitBorder.Checked

        ''objRectangle1 = New Rectangle(Me.Left + pictureLeft.Left,
        ''                             Me.Top + pictureLeft.Top,
        ''                              pictureLeft.Width, pictureLeft.Height)

        Dim intWidth, intHeight As Integer
        Dim objSourceControl As PictureBox ''Added 5/22/2022

        intWidth = par_ctlPictureBox.Width
        intHeight = par_ctlPictureBox.Height

        ''Added 5/22/2022
        ''
        ''  Let's use the bigger, hidden control picturePreviewForScrape 
        ''  in order to take the screen grab. 
        ''
        If (pboolUseCenterPreviewLarge) Then

            objSourceControl = picturePreviewForScrape

        Else

            objSourceControl = par_ctlPictureBox

        End If ''End of ""If (pboolUseCenterPreviewLarge) Then""

        ''
        ''
        ''

        stylePictureBoxSizeMode = par_ctlPictureBox.SizeMode ''Added 5/22/2022
        ''5/22/2022 With picturePreviewForScrape
        With objSourceControl
            .Visible = True
            .BringToFront()
            ''5/22/2022 .Image = par_ctlPictureBox.Image
            ''5/22/2022 .ImageLocation = mod_pathToImageFile
            If (pboolUseCenterPreviewLarge) Then
                ''Load the larger "Center Preview" box.---5/22/2022
                .ImageLocation = par_ctlPictureBox.ImageLocation
                .ImageLocation = Me.ImageFilePath_input
                .SizeMode = stylePictureBoxSizeMode
                ''Not needed?? 5/22/2022 thomas d ''.Load()
                .Load()
            Else
                ''Added 5/22/2022
                '' Temporarily enlarge the picture box.
                ''
                If (mc_boolEnlargeToPreviewForScrapeSize) Then
                    With par_ctlPictureBox
                        .Width = picturePreviewForScrape.Width
                        .Height = picturePreviewForScrape.Height
                    End With
                End If ''End of ""If (mc_boolEnlargeToPreviewForScrapeSize) Then""

            End If ''Endof ""If (pboolUseCenterPreviewLarge) Then""

            ''
            ''Give the application a chance to respond.
            ''
            Application.DoEvents() ''Added 5/22/2022 td

            ''5/22/2022 thomas d. ''With par_ctlPictureBox

            If (.BorderStyle = BorderStyle.FixedSingle) Then

                If (bTryToOmitBorder) Then
                    objRectangle2 = .RectangleToScreen(New Rectangle(0, 0, intWidth - 2, intHeight - 2))
                Else
                    objRectangle2 = .RectangleToScreen(New Rectangle(0, 0, intWidth, intHeight))
                End If

            ElseIf (.BorderStyle = BorderStyle.None) Then

                objRectangle2 = .RectangleToScreen(New Rectangle(0, 0, intWidth, intHeight))

            End If ''end of ""If (pictureLeft.BorderStyle = ...) ... ElseIf (pictureLeft.BorderStyle = ...)...

        End With ''End of ""With par_ctlPictureBox""

        picturePreview.Image = Nothing
        Application.DoEvents() ''Added 5/22/2022 td
        picturePreview.Image =
             TakeScreenShot_Modified(objRectangle2)
        picturePreview.SizeMode = PictureBoxSizeMode.Normal

        ''May 22, 2022 End If ''end of ""If (pboolUseCenterPreviewLarge) Then""

        ''
        ''Exit Handler
        ''
        ''Remove the "Preview for Scrape" box, not needed any longer. 
        ''
        picturePreviewForScrape.Image = Nothing
        picturePreviewForScrape.Visible = False
        picturePreviewForScrape.SendToBack()
        ''5/22/2022 picturePreviewForScrape.Load() ''Refresh the control, remove the image 

    End Sub ''end of ""Private Sub TakeScreenshot_Master()""



    Private Function TakeScreenShot_Modified(par_rectangle As Rectangle) As Bitmap
        ''
        ''Copied from StackOverflow.com on 5/17/2022 
        ''Modified 5/17/2022
        ''
        ''High Quality Full Screenshots VB.Net
        ''Asked 9 years, 11 months ago
        ''Modified 4 years, 9 months ago
        ''Viewed 32k times
        ''https://stackoverflow.com/questions/10930569/high-quality-full-screenshots-vb-net
        ''
        Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Dim rectangleSize As Size = New Size(par_rectangle.Width, par_rectangle.Height)
        Dim intX As Integer
        Dim intY As Integer

        ''----Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Dim screenGrab As New Bitmap(par_rectangle.Width, par_rectangle.Height)

        Dim g As Graphics = Graphics.FromImage(screenGrab)

        intX = par_rectangle.Left
        intY = par_rectangle.Top

        ''---g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
        g.CopyFromScreen(New Point(intX, intY), New Point(0, 0), screenSize)

        Return screenGrab

    End Function ''End of ""Private Function TakeScreenShot_ModifiedByTD() As Bitmap""



    Private Function TakeScreenShot_byStackOverflow() As Bitmap
        ''
        ''Copied from StackOverflow.com on 5/17/2022 
        ''
        ''High Quality Full Screenshots VB.Net
        ''Asked 9 years, 11 months ago
        ''Modified 4 years, 9 months ago
        ''Viewed 32k times
        ''https://stackoverflow.com/questions/10930569/high-quality-full-screenshots-vb-net
        ''
        Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)

        Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)

        Dim g As Graphics = Graphics.FromImage(screenGrab)

        g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)

        Return screenGrab

    End Function ''End of ""Private Function TakeScreenShot_byStackOverflow() As Bitmap""


    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub FormBackgroundEditImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 5/18/2022 
        ''
        If (pictureLayoutZoom.Image Is Nothing) Then

            If (Me.ImageFilePath_input <> "") Then

                pictureLayoutCenter.ImageLocation = Me.ImageFilePath_input
                pictureLayoutNormal.ImageLocation = Me.ImageFilePath_input
                pictureLayoutStretch.ImageLocation = Me.ImageFilePath_input
                pictureLayoutZoom.ImageLocation = Me.ImageFilePath_input

                ''Added 5/18/2022 td
                pictureLayoutCenter.SizeMode = PictureBoxSizeMode.CenterImage
                pictureLayoutNormal.SizeMode = PictureBoxSizeMode.Normal
                pictureLayoutStretch.SizeMode = PictureBoxSizeMode.StretchImage
                pictureLayoutZoom.SizeMode = PictureBoxSizeMode.Zoom

                ''Added 5/18/2022 td
                With CtlMoveableBackground1
                    .ImageFileLocation = Me.ImageFilePath_input
                    .Load_Control()
                    .BringToFront() ''Added 5/18/2022 

                    ''Make sure that the PictureBox exactly lies underneath.
                    ''  pictureLayoutMoveable.Left = .Left
                    ''  pictureLayoutMoveable.Top = .Top
                    ''  pictureLayoutMoveable.Width = .Width
                    ''  pictureLayoutMoveable.Height = .Height
                    ''June3 2022 td''---PictureBoxMustBeBeneathUserControl()
                    PictureBoxMustBeBeneathUserControl_ForScreenshot()
                    pictureLayoutMoveable.Visible = False

                End With

                pictureLayoutCenter.Load()
                pictureLayoutNormal.Load()
                pictureLayoutStretch.Load()
                pictureLayoutZoom.Load()

            End If ''End of ""If (Me.ImageFilePath <> "") Then""

        End If ''End of ""If (pictureLayoutZoom.Image Is Nothing) Then"" 

ExitHandler:
        mod_bLoading = False ''Added 6/4/2022
        mod_bSuppressEvents = False ''Added 6/4/2022 

    End Sub


    Private Sub RefreshPreview()
        ''
        ''Added 5/18/2022 thomas downes
        ''
        Select Case True
            Case radioLayoutCenter.Checked
                TakeScreenshot_Master(pictureLayoutCenter)
            Case radioLayoutMoveable.Checked
                ''TakeScreenshot_Master(pictureLayoutMoveable, False)
                ''6/3/2022 td''TakeScreenshot_Master(pictureLayoutMoveable, False)
                TakeScreenshot_Master(CtlMoveableBackground1)

            Case radioLayoutNormal.Checked
                TakeScreenshot_Master(pictureLayoutNormal)
            Case radioLayoutStretch.Checked
                TakeScreenshot_Master(pictureLayoutStretch)
            Case radioLayoutZoom.Checked
                TakeScreenshot_Master(pictureLayoutZoom)

        End Select ''End of ""Select Case True""  

    End Sub ''end of "" Private Sub RefreshPreview() ""


    Private Sub PictureBoxMustBeBeneathUserControl_ForScreenshot()
        ''
        ''Place the pictureBox called pictureLayoutMoveable 
        ''   directly underneath the user-control CtlMoveableBackground1, 
        ''   so that the TakeScreenshot_Master() function knows where the 
        ''   screengrab should be.  ----5/18/2022 td
        ''
        ''Added 5/18/2022 td
        If (CtlMoveableBackground1 IsNot Nothing) Then

            With Me.CtlMoveableBackground1

                ''Make sure that the PictureBox exactly lies underneath.
                pictureLayoutMoveable.Left = .Left
                pictureLayoutMoveable.Top = .Top
                pictureLayoutMoveable.Width = .Width
                pictureLayoutMoveable.Height = .Height
                pictureLayoutMoveable.Visible = False

            End With ''ENd of ""With CtlMoveableBackground1""

        End If


    End Sub ''End of ""Private Sub PictureBoxMustBeBeneathUserControl()""

    Private Sub radioLayoutNormal_CheckedChanged(sender As Object, e As EventArgs) Handles radioLayoutNormal.CheckedChanged

        If (mod_bLoading) Then Exit Sub ''Added 6/4/2022 td
        If (mod_bSuppressEvents) Then Exit Sub ''Added 6/4/2022 td

        ''Added 5/18/2022 
        If (radioLayoutNormal.Checked) Then
            TakeScreenshot_Master(pictureLayoutNormal)
        End If

    End Sub

    Private Sub radioLayoutZoom_CheckedChanged(sender As Object, e As EventArgs) Handles radioLayoutZoom.CheckedChanged

        If (mod_bLoading) Then Exit Sub ''Added 6/4/2022 td
        If (mod_bSuppressEvents) Then Exit Sub ''Added 6/4/2022 td

        ''Added 5/18/2022 
        If (radioLayoutZoom.Checked) Then
            TakeScreenshot_Master(pictureLayoutZoom)
        End If

    End Sub

    Private Sub RadioLayoutCenter_CheckedChanged(sender As Object, e As EventArgs) Handles radioLayoutCenter.CheckedChanged

        If (mod_bLoading) Then Exit Sub ''Added 6/4/2022 td
        If (mod_bSuppressEvents) Then Exit Sub ''Added 6/4/2022 td

        ''Added 5/18/2022 
        If (radioLayoutCenter.Checked) Then
            TakeScreenshot_Master(pictureLayoutCenter)
        End If


    End Sub

    Private Sub RadioLayoutStretch_CheckedChanged(sender As Object, e As EventArgs) Handles radioLayoutStretch.CheckedChanged

        If (mod_bLoading) Then Exit Sub ''Added 6/4/2022 td
        If (mod_bSuppressEvents) Then Exit Sub ''Added 6/4/2022 td

        ''Added 5/18/2022 
        If (radioLayoutStretch.Checked) Then
            TakeScreenshot_Master(pictureLayoutStretch)
        End If


    End Sub


    Private Sub radioLayoutMoveable_CheckedChanged(sender As Object, e As EventArgs) Handles radioLayoutMoveable.CheckedChanged

        If (mod_bLoading) Then Exit Sub ''Added 6/4/2022 td

        ''Added 5/18/2022 
        If (radioLayoutMoveable.Checked) Then

            ''5/18/2022 TakeScreenshot_Master(CtlMoveableBackground1.GetPictureBox())
            PictureBoxMustBeBeneathUserControl_ForScreenshot()

            ''6/3/2022 TakeScreenshot_Master(pictureLayoutMoveable)
            ''6/3/2022 TakeScreenshot_Master(CtlMoveableBackground1)

        End If ''End of ""If (radioLayoutMoveable.Checked) Then""

    End Sub


    Private Sub pictureLayoutNormal_Click(sender As Object, e As EventArgs) Handles pictureLayoutNormal.Click

        ''Added 5/18/2022
        If (radioLayoutNormal.Checked) Then
            ''Refresh the preview.
            TakeScreenshot_Master(pictureLayoutNormal)
        Else
            radioLayoutNormal.Checked = True
        End If

    End Sub

    Private Sub pictureLayoutZoom_Click(sender As Object, e As EventArgs) Handles pictureLayoutZoom.Click

        ''Added 5/18/2022
        If (radioLayoutZoom.Checked) Then
            ''Refresh the preview.
            TakeScreenshot_Master(pictureLayoutZoom)
        Else
            radioLayoutZoom.Checked = True
        End If

    End Sub

    Private Sub pictureLayoutStretch_Click(sender As Object, e As EventArgs) Handles pictureLayoutStretch.Click
        ''Added 5/18/2022
        ''5/18/2022 radioLayoutStretch.Checked = True

        ''Added 5/18/2022
        If (radioLayoutStretch.Checked) Then
            ''Refresh the preview.
            TakeScreenshot_Master(pictureLayoutStretch)
        Else
            radioLayoutStretch.Checked = True
        End If

    End Sub

    Private Sub pictureLayoutCenter_Click(sender As Object, e As EventArgs) Handles pictureLayoutCenter.Click
        ''Added 5/18/2022
        ''5/18/2022 radioLayoutCenter.Checked = True

        ''Added 5/18/2022
        If (radioLayoutCenter.Checked) Then
            ''Refresh the preview.
            TakeScreenshot_Master(pictureLayoutCenter)
        Else
            radioLayoutCenter.Checked = True
        End If

    End Sub

    Private Sub ButtonPushPreview_Click(sender As Object, e As EventArgs) Handles labelPushPreviewToBoxes.Click
        ''
        ''Added 5/18/2022 td
        ''
        pictureLayoutCenter.Image = picturePreview.Image
        pictureLayoutNormal.Image = picturePreview.Image
        pictureLayoutStretch.Image = picturePreview.Image
        pictureLayoutZoom.Image = picturePreview.Image

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        ''Added 5/18/2022
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ''
        ''Added 5/18/2022
        ''
        If (picturePreview.Image Is Nothing) Then
            ''
            ''Let the user know that they haven't made a selection.
            ''
            MessageBoxTD.Show_Statement("Have you made a selection?  ",
                                        "Please click on a ""Select below"" selection circle.")
            ''Exit without closing. 
            Exit Sub

        End If ''End of ""If (picturePreview.Image Is Nothing) Then""

        ''Added 5/18/2022 td
        ''   t = temp
        Me.ImageFilePath_output = (Me.ImageFilePath_input.Replace(".jpg", "") & "_t.jpg")
        If (IO.File.Exists(Me.ImageFilePath_output)) Then
            Me.ImageFilePath_output = (Me.ImageFilePath_input.Replace(".jpg", "") & "_u.jpg")
            If (IO.File.Exists(Me.ImageFilePath_output)) Then
                Me.ImageFilePath_output = (Me.ImageFilePath_input.Replace(".jpg", "") & "_v.jpg")
                If (IO.File.Exists(Me.ImageFilePath_output)) Then
                    Me.ImageFilePath_output = (Me.ImageFilePath_input.Replace(".jpg", "") & "_w.jpg")
                End If
            End If
        End If

        Me.picturePreview.Image.Save(Me.ImageFilePath_output, Imaging.ImageFormat.Jpeg)

        ''Searched Bing.com for ""vb.net picturebox. when do i dispose""
        ''https://stackoverflow.com/questions/19802405/vb-net-dispose-pictureboxes-and-load-them-again
        ''https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.picturebox.dispose?view=windowsdesktop-6.0
        ''https://www.daniweb.com/programming/software-development/threads/435337/disposing-picture-boxes
        Me.picturePreview.Image?.Dispose() ''Recommended by the above links. 
        Me.pictureLayoutCenter.Image?.Dispose() ''Recommended by the above links.
        Me.pictureLayoutMoveable.Image?.Dispose() ''Recommended by the above links. 
        Me.pictureLayoutNormal.Image?.Dispose() ''Recommended by the above links.
        Me.pictureLayoutStretch.Image?.Dispose() ''Recommended by the above links. 
        Me.pictureLayoutZoom.Image?.Dispose() ''Recommended by the above links.

        Me.picturePreview.BackgroundImage?.Dispose() ''Recommended by the above links. 
        Me.pictureLayoutCenter.BackgroundImage?.Dispose() ''Recommended by the above links.
        Me.pictureLayoutMoveable.BackgroundImage?.Dispose() ''Recommended by the above links. 
        Me.pictureLayoutNormal.BackgroundImage?.Dispose() ''Recommended by the above links.
        Me.pictureLayoutStretch.BackgroundImage?.Dispose() ''Recommended by the above links. 
        Me.pictureLayoutZoom.BackgroundImage?.Dispose() ''Recommended by the above links.

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub


    Private Sub CtlMoveableBackground1_Click(sender As Object, e As EventArgs) Handles CtlMoveableBackground1.Click

        ''Added 5/18/2022 
        If (radioLayoutMoveable.Checked) Then
            ''5/18/2022 TakeScreenshot_Master(CtlMoveableBackground1.GetPictureBox())
            ''6/03/2022 PictureBoxMustBeBeneathUserControl()
            PictureBoxMustBeBeneathUserControl_ForScreenshot()
            TakeScreenshot_Master(pictureLayoutMoveable)

        End If

    End Sub

    Private Sub LabelHeaderPreview_Click(sender As Object, e As EventArgs) Handles LabelHeaderPreview.Click
        ''
        ''Added 5/18/2022 
        ''
        RefreshPreview()

        ''Select Case True
        ''    Case radioLayoutCenter.Checked
        ''        TakeScreenshot_Master(pictureLayoutCenter)
        ''    Case radioLayoutMoveable.Checked
        ''        TakeScreenshot_Master(pictureLayoutMoveable)
        ''    Case radioLayoutNormal.Checked
        ''        TakeScreenshot_Master(pictureLayoutNormal)
        ''    Case radioLayoutStretch.Checked
        ''        TakeScreenshot_Master(pictureLayoutStretch)
        ''    Case radioLayoutZoom.Checked
        ''        TakeScreenshot_Master(pictureLayoutZoom)
        ''End Select

    End Sub

    Private Sub picturePreview_Click(sender As Object, e As EventArgs) Handles picturePreview.Click
        ''
        ''Added 5/18/2022 
        ''
        RefreshPreview()

    End Sub

    Private Sub ElementGraphic_LeftClicked(par_control As UserControl) Handles CtlMoveableBackground1.ElementGraphic_LeftClicked
        ''
        ''Added 5/18/2022 
        ''
        radioLayoutMoveable.Checked = True
        RefreshPreview()

    End Sub

    ''Private Sub CtlMoveableBackground1_Load(sender As Object, e As EventArgs) Handles CtlMoveableBackground1.Load

    ''End Sub

    ''Private Sub CtlMoveableBackground1_MouseEnter(sender As Object, e As EventArgs) Handles CtlMoveableBackground1.MouseEnter

    ''    ''Added 5/22/2022
    ''    ''5/23/2022 With CtlMoveableBackground1
    ''    ''    .Width = picturePreviewForScrape.Width
    ''    ''    .Height = picturePreviewForScrape.Height
    ''    ''    .Invalidate()
    ''    ''End With


    ''End Sub

    ''Private Sub CtlMoveableBackground1_MouseLeave(sender As Object, e As EventArgs) Handles CtlMoveableBackground1.MouseLeave

    ''    ''Added 5/22/2022
    ''    ''5/23/2022  With CtlMoveableBackground1
    ''    ''    .Width = pictureLayoutCenter.Width
    ''    ''    .Height = pictureLayoutCenter.Height
    ''    ''    .Invalidate()
    ''    ''End With


    ''End Sub

    ''Private Sub CtlMoveableBackground1_MouseHover(sender As Object, e As EventArgs) Handles CtlMoveableBackground1.MouseHover
    ''    ''Added 5/22/2022

    ''    ''5/23/2022 Dim intWidthDiff As Integer

    ''    ''5/23/2022 With CtlMoveableBackground1
    ''    ''    intWidthDiff = (picturePreviewForScrape.Width - .Width)
    ''    ''    .Width = picturePreviewForScrape.Width
    ''    ''    .Left = (.Left - intWidthDiff) ''Move it to the left
    ''    ''    .Height = picturePreviewForScrape.Height
    ''    ''    ''.Invalidate()
    ''    ''End With

    ''End Sub

    Private Sub FormBackgroundEditImage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ''
        ''Added 5/23/2022 thomas 
        ''
        Me.UploadedImage?.Dispose() ''Helps to prevent problems!!

        ''Added 5/24/2022 thomas 
        Me.pictureLayoutCenter.Image?.Dispose()
        Me.pictureLayoutMoveable.Image?.Dispose()
        Me.pictureLayoutNormal.Image?.Dispose()
        Me.pictureLayoutStretch.Image?.Dispose()
        Me.pictureLayoutZoom.Image?.Dispose()

        ''Added 6/02/2022 thomas 
        Me.pictureLayoutCenter.BackgroundImage?.Dispose()
        Me.pictureLayoutMoveable.BackgroundImage?.Dispose()
        Me.pictureLayoutNormal.BackgroundImage?.Dispose()
        Me.pictureLayoutStretch.BackgroundImage?.Dispose()
        Me.pictureLayoutZoom.BackgroundImage?.Dispose()

    End Sub

    Private Sub CtlMoveableBackground1_MouseDown(sender As Object, e As MouseEventArgs) Handles CtlMoveableBackground1.MouseDown
        ''
        ''Added 5/23/2022 thomas 
        ''
        Dim intWidthDiff As Integer

        If (mc_boolEnlargeMoveable) Then ''Added 5/24/2022 thomas downes
            With CtlMoveableBackground1
                If (.Width > pictureLayoutCenter.Width) Then
                    ''
                    ''The control () has already been enlarged. No need to execute the
                    ''   code that makes it larger.  ---5/23/2022
                    ''
                Else
                    intWidthDiff = (picturePreviewForScrape.Width - .Width)
                    .Width = picturePreviewForScrape.Width
                    .Left = (.Left - intWidthDiff) ''Move it to the left
                    .Height = picturePreviewForScrape.Height
                    .Refresh()
                End If ''End of ""If (.Width > pictureLayoutCenter.Width) Then... Else..."
            End With ''End of ""With CtlMoveableBackground1""
        End If ''End of ""If (mc_boolEnlargeMoveable) Then""

    End Sub

    Private Sub CtlMoveableBackground1_MouseUp(sender As Object, e As MouseEventArgs) Handles CtlMoveableBackground1.MouseUp

        ''Added 5/24/2022 thomas downes
        ''
        If (mc_boolEnlargeMoveable) Then ''Added 5/24/2022 thomas downes
            ''  Restore the control CtlMoveableBackground1 to its original size & position
            ''
            With CtlMoveableBackground1
                .Width = picturePreview.Width
                .Left = picturePreview.Left
                .Height = picturePreview.Height
                .Refresh()
            End With ''
        End If ''End of ""If (mc_boolEnlargeMoveable) Then""

    End Sub

    Private Sub CtlMoveableBackground1_Load(sender As Object, e As EventArgs) Handles CtlMoveableBackground1.Load

    End Sub

    Private Sub LinkLabel1UpdatePreview_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1UpdatePreview.LinkClicked

        ''Added 6/3/2022
        RefreshPreview()

        ''If (radioLayoutMoveable.Checked) Then
        ''    TakeScreenshot_Master(CtlMoveableBackground1)
        ''Else
        ''    TakeScreenshot_Master()
        ''End If ''End of ""If (radioLayoutMoveable.Checked) Then... Else..." 

    End Sub
End Class