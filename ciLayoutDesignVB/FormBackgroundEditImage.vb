Public Class FormBackgroundEditImage
    ''
    '' Added 11/30/2021 thomas downes
    ''
    Public UploadedImage As Image
    Public ImageFilePath As String = "" ''Added 5/18/2022 
    Public ImageFileInfo As System.IO.FileInfo ''Added 5/18/2022 

    Private mod_bSuppressEvents As Boolean
    Private mod_pathToImageFile As String

    Public Sub UploadedImageFile(par_pathToImageFile As String)
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
        pictureLayoutNone.BackgroundImage = Me.UploadedImage
        pictureLayoutNone.BackgroundImageLayout = ImageLayout.None

        ''Stretch
        pictureLayoutStretch.BackgroundImage = Me.UploadedImage
        pictureLayoutStretch.BackgroundImageLayout = ImageLayout.Stretch

        ''Zoom
        pictureLayoutZoom.BackgroundImage = Me.UploadedImage
        pictureLayoutZoom.BackgroundImageLayout = ImageLayout.Zoom




    End Sub


    Private Sub TakeScreenshot_Master(par_ctlPictureBox As PictureBox)
        ''
        ''Added 5/18/2022  
        ''
        ''Dim objRectangle1 As Rectangle
        Dim objRectangle2 As Rectangle
        Dim bTryToOmitBorder As Boolean

        bTryToOmitBorder = True ''---checkOmitBorder.Checked

        ''objRectangle1 = New Rectangle(Me.Left + pictureLeft.Left,
        ''                             Me.Top + pictureLeft.Top,
        ''                              pictureLeft.Width, pictureLeft.Height)

        Dim intWidth, intHeight As Integer
        intWidth = par_ctlPictureBox.Width
        intHeight = par_ctlPictureBox.Height

        With par_ctlPictureBox

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
        picturePreview.Image =
             TakeScreenShot_Modified(objRectangle2)
        picturePreview.SizeMode = PictureBoxSizeMode.Normal


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

    Private Sub FormUploadEditingImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 5/18/2022 
        ''
        If (pictureLayoutZoom.Image Is Nothing) Then

            If (Me.ImageFilePath <> "") Then

                pictureLayoutCenter.ImageLocation = Me.ImageFilePath
                pictureLayoutNone.ImageLocation = Me.ImageFilePath
                pictureLayoutStretch.ImageLocation = Me.ImageFilePath
                pictureLayoutZoom.ImageLocation = Me.ImageFilePath

                pictureLayoutCenter.Load()
                pictureLayoutNone.Load()
                pictureLayoutStretch.Load()
                pictureLayoutZoom.Load()

            End If ''End of ""If (Me.ImageFilePath <> "") Then""

        End If ''End of ""If (pictureLayoutZoom.Image Is Nothing) Then"" 

    End Sub

    Private Sub radioLayoutNone_CheckedChanged(sender As Object, e As EventArgs) Handles radioLayoutNone.CheckedChanged

        ''Added 5/18/2022 
        If (radioLayoutNone.Checked) Then
            TakeScreenshot_Master(pictureLayoutNone)
        End If

    End Sub

    Private Sub radioLayoutZoom_CheckedChanged(sender As Object, e As EventArgs) Handles radioLayoutZoom.CheckedChanged

        ''Added 5/18/2022 
        If (radioLayoutZoom.Checked) Then
            TakeScreenshot_Master(pictureLayoutZoom)
        End If

    End Sub

    Private Sub RadioLayoutCenter_CheckedChanged(sender As Object, e As EventArgs) Handles radioLayoutCenter.CheckedChanged

        ''Added 5/18/2022 
        If (radioLayoutCenter.Checked) Then
            TakeScreenshot_Master(pictureLayoutCenter)
        End If


    End Sub

    Private Sub RadioLayoutStretch_CheckedChanged(sender As Object, e As EventArgs) Handles radioLayoutStretch.CheckedChanged

        ''Added 5/18/2022 
        If (radioLayoutStretch.Checked) Then
            TakeScreenshot_Master(pictureLayoutStretch)
        End If


    End Sub
End Class