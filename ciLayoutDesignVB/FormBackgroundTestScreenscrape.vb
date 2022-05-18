''
''Added 5/17/2022 thomas 
''
Public Class FormBackgroundTestScreenscrape
    ''
    ''Added 5/17/2022 thomas 
    ''
    Public ImageFilePathInitial As String ''Added 5/17/2022 


    Private Sub picturePreview_Click(sender As Object, e As EventArgs) Handles pictureLeft.Click

    End Sub

    Private Sub FormBackgroundTestScreenscrape_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 5/17/2022 thomas 
        ''
        If (ImageFilePathInitial IsNot Nothing) Then

            pictureLeft.ImageLocation = ImageFilePathInitial
            pictureLeft.Load()

        End If ''Endof ""If (ImageFilePathInitial IsNot Nothing) Then"" 



    End Sub



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

    Private Sub LinkStackOverflow_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkToStackOverflow.LinkClicked
        ''
        ''Open web page
        ''
        ''  https://stackoverflow.com/questions/10930569/high-quality-full-screenshots-vb-net
        ''
        System.Diagnostics.Process.Start("https://stackoverflow.com/questions/10930569/high-quality-full-screenshots-vb-net")

    End Sub

    Private Sub LinkSizeModeZoom_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkSizeModeZoom.LinkClicked

        pictureLeft.SizeMode = PictureBoxSizeMode.Zoom

    End Sub

    Private Sub LinkSizeModeStretch_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkSizeModeStretch.LinkClicked

        pictureLeft.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

    Private Sub LinkSizeModeAuto_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkSizeModeAuto.LinkClicked

        pictureLeft.SizeMode = PictureBoxSizeMode.AutoSize

    End Sub

    Private Sub LinkSizeModeNormal_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkSizeModeNormal.LinkClicked

        pictureLeft.SizeMode = PictureBoxSizeMode.Normal


    End Sub

    Private Sub LinkLoadViaScrape_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLoadViaScrape.LinkClicked
        ''
        ''Added 5/17/2022  
        ''
        TakeScreenshot_Master()

    End Sub


    Private Sub TakeScreenshot_Master()
        ''
        ''Added 5/18/2022  
        ''
        ''Dim objRectangle1 As Rectangle
        Dim objRectangle2 As Rectangle
        Dim bTryToOmitBorder As Boolean

        bTryToOmitBorder = checkOmitBorder.Checked

        ''objRectangle1 = New Rectangle(Me.Left + pictureLeft.Left,
        ''                             Me.Top + pictureLeft.Top,
        ''                              pictureLeft.Width, pictureLeft.Height)

        Dim intWidth, intHeight As Integer
        intWidth = pictureLeft.Width
        intHeight = pictureLeft.Height

        If (pictureLeft.BorderStyle = BorderStyle.FixedSingle) Then

            If (bTryToOmitBorder) Then
                objRectangle2 = pictureLeft.RectangleToScreen(New Rectangle(0, 0, intWidth - 2, intHeight - 2))
            Else
                objRectangle2 = pictureLeft.RectangleToScreen(New Rectangle(0, 0, intWidth, intHeight))
            End If

        ElseIf (pictureLeft.BorderStyle = BorderStyle.None) Then

            objRectangle2 = pictureLeft.RectangleToScreen(New Rectangle(0, 0, intWidth, intHeight))

        End If ''end of ""If (pictureLeft.BorderStyle = ...) ... ElseIf (pictureLeft.BorderStyle = ...)...

        pictureRight.Image = Nothing
        pictureRight.Image =
             TakeScreenShot_Modified(objRectangle2)
        pictureRight.SizeMode = PictureBoxSizeMode.CenterImage


    End Sub ''end of ""Private Sub TakeScreenshot_Master()""


    Private Sub LinkBackcolorMistyRose_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkBackcolorMistyRose.LinkClicked

        ''Added 5/17/2022 
        pictureRight.BackColor = Color.MistyRose

    End Sub


    Private Sub LinkBackcolorWhite_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkBackcolorWhite.LinkClicked

        ''Added 5/17/2022 
        pictureRight.BackColor = Color.White

    End Sub

    Private Sub LinkAddBorder_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkAddBorder.LinkClicked

        ''Added 5/17/2022 
        pictureLeft.BorderStyle = BorderStyle.FixedSingle

    End Sub

    Private Sub LinkRemoveBorder_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkRemoveBorder.LinkClicked

        ''Added 5/17/2022 
        pictureLeft.BorderStyle = BorderStyle.None

    End Sub
End Class