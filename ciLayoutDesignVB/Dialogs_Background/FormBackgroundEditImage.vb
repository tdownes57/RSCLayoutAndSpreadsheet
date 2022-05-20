Option Explicit On
Option Strict On
''
''Added 5/18/2022 
''
''---Imports monem

Public Class FormBackgroundEditImage
    ''
    '' Added 11/30/2021 thomas downes
    ''
    Public UploadedImage As Image
    Public ImageFilePath_input As String = "" ''Added 5/18/2022 
    Public ImageFilePath_output As String = "" ''Added 5/18/2022 
    ''---Public ImageFileInfo As System.IO.FileInfo ''Added 5/18/2022 

    Private mod_bSuppressEvents As Boolean
    Private mod_pathToImageFile As String
    ''----Private mod_objEventsMoveGroupOfCtls As New 

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
        pictureLayoutNormal.BackgroundImage = Me.UploadedImage
        pictureLayoutNormal.BackgroundImageLayout = ImageLayout.None

        ''Stretch
        pictureLayoutStretch.BackgroundImage = Me.UploadedImage
        pictureLayoutStretch.BackgroundImageLayout = ImageLayout.Stretch

        ''Zoom
        pictureLayoutZoom.BackgroundImage = Me.UploadedImage
        pictureLayoutZoom.BackgroundImageLayout = ImageLayout.Zoom




    End Sub


    Private Sub TakeScreenshot_Master(par_ctlPictureBox As PictureBox)
        ''---5/18/2022 Private Sub TakeScreenshot_Master(par_ctlPictureBox As PictureBox)
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
                    PictureBoxMustBeBeneathUserControl()
                    pictureLayoutMoveable.Visible = False

                End With

                pictureLayoutCenter.Load()
                pictureLayoutNormal.Load()
                pictureLayoutStretch.Load()
                pictureLayoutZoom.Load()

            End If ''End of ""If (Me.ImageFilePath <> "") Then""

        End If ''End of ""If (pictureLayoutZoom.Image Is Nothing) Then"" 

    End Sub


    Private Sub RefreshPreview()
        ''
        ''Added 5/18/2022 thomas downes
        ''
        Select Case True
            Case radioLayoutCenter.Checked
                TakeScreenshot_Master(pictureLayoutCenter)
            Case radioLayoutMoveable.Checked
                TakeScreenshot_Master(pictureLayoutMoveable)
            Case radioLayoutNormal.Checked
                TakeScreenshot_Master(pictureLayoutNormal)
            Case radioLayoutStretch.Checked
                TakeScreenshot_Master(pictureLayoutStretch)
            Case radioLayoutZoom.Checked
                TakeScreenshot_Master(pictureLayoutZoom)
        End Select

    End Sub ''end of "" Private Sub RefreshPreview() ""


    Private Sub PictureBoxMustBeBeneathUserControl()
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

        ''Added 5/18/2022 
        If (radioLayoutNormal.Checked) Then
            TakeScreenshot_Master(pictureLayoutNormal)
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


    Private Sub radioLayoutMoveable_CheckedChanged(sender As Object, e As EventArgs) Handles radioLayoutMoveable.CheckedChanged

        ''Added 5/18/2022 
        If (radioLayoutMoveable.Checked) Then
            ''5/18/2022 TakeScreenshot_Master(CtlMoveableBackground1.GetPictureBox())
            PictureBoxMustBeBeneathUserControl
            TakeScreenshot_Master(pictureLayoutMoveable)

        End If

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

    Private Sub ButtonPushPreview_Click(sender As Object, e As EventArgs) Handles ButtonPushPreview.Click
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
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub


    Private Sub CtlMoveableBackground1_Click(sender As Object, e As EventArgs) Handles CtlMoveableBackground1.Click

        ''Added 5/18/2022 
        If (radioLayoutMoveable.Checked) Then
            ''5/18/2022 TakeScreenshot_Master(CtlMoveableBackground1.GetPictureBox())
            PictureBoxMustBeBeneathUserControl()
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
End Class