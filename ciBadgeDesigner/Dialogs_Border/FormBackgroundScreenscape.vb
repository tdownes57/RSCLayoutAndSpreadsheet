''
''Added 6/3/2022 thomas d  
''
Imports System.Drawing ''Added 8/2/2022 

Public Class FormBackgroundScreenscape
    ''
    ''Added 6/3/2022 thomas d  
    ''
    Public Input_PictureBoxSizeMode As PictureBoxSizeMode ''Added 6/3/2022 td 
    Public Input_ShowSizingControl As Boolean ''Added 6/3/2022 td
    Public Input_ShowMoveableControl As Boolean ''Added 6/3/2022 td
    Public Input_BackgroundImage As Drawing.Image ''Added 6/3/2022 td 

    ''Added 6/3/2022 td
    Public Input_MoveablePositionX As Integer '' = intPositionX
    Public Input_MoveablePositionY As Integer '' = intPositionY
    Public Input_MoveableWidth As Integer '' = intWidth
    Public Input_MoveableHeight As Integer '' = intHeight

    Public Output_Image As Drawing.Image ''Added 6/3/2022 td
    Public Output_Image_LocationPath As String ''Added 6/11/2022 td

    Private Function TakeScreenShot_Modified(par_rectangle As Rectangle,
                    Optional par_pictureBox As PictureBox = Nothing) As Bitmap
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

        intX = par_rectangle.Left ''6/11/2022 + Me.Left
        intY = par_rectangle.Top ''6/11/2022 + Me.Top

        ''Added 6/11/2022 thomas downes
        Dim objRectangleTest As Rectangle
        Dim boolMatches As Boolean
        If (par_pictureBox IsNot Nothing) Then
            With par_pictureBox
                objRectangleTest = New Rectangle(.Left, .Top, .Width, .Height)
                objRectangleTest = par_pictureBox.RectangleToScreen(objRectangleTest)
                boolMatches = (intY = objRectangleTest.Top)
                ''
                ''Trying not to capture the wrong Y coordinates!!  It is starting
                ''  from the wrong Y coordinate!!  ----6/11/20222 
                ''
                ''6/11/2022 intY = par_rectangle.Top + .Top
                intY = par_rectangle.Top - .Top
                intX = par_rectangle.Left - .Left

            End With
        End If ''end of ""If (par_pictureBox IsNot Nothing) Then""

        ''---g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
        g.CopyFromScreen(New Point(intX, intY), New Point(0, 0), screenSize)

        Return screenGrab

    End Function ''End of ""Private Function TakeScreenShot_Modified() As Bitmap""



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


    Private Function GetScreenRectangle(par_picturebox As PictureBox) As Rectangle
        ''
        ''Added 6/11/2022 td
        ''
        Dim objRectangleInput As Rectangle
        Dim objRectangleInput_OmitBorder As Rectangle ''Added 6/11/2022 td
        Dim objRectangleOutput As Rectangle
        Dim intWidth, intHeight As Integer
        Dim intLeft, intTop As Integer

        intWidth = par_picturebox.Width
        intHeight = par_picturebox.Height
        intLeft = par_picturebox.Left ''Added 6/11/2022 td
        intTop = par_picturebox.Top ''Added 6/11/2022 td

        Const c_bTryToOmitBorder As Boolean = True

        objRectangleInput = New Rectangle(intLeft, intTop, intWidth, intHeight)
        objRectangleInput_OmitBorder = New Rectangle(intLeft, intTop, intWidth - 2, intHeight - 2)

        With par_picturebox

            If (.BorderStyle = BorderStyle.FixedSingle) Then

                If (c_bTryToOmitBorder) Then
                    ''6/11/2022 objRectangleOutput = .RectangleToScreen(New Rectangle(0, 0, intWidth - 2, intHeight - 2))
                    objRectangleOutput = .RectangleToScreen(objRectangleInput_OmitBorder)
                Else
                    ''6/11/2022 objRectangleOutput = .RectangleToScreen(New Rectangle(0, 0, intWidth, intHeight))
                    objRectangleOutput = .RectangleToScreen(objRectangleInput)
                End If

            ElseIf (.BorderStyle = BorderStyle.None) Then

                ''6/11/2022 objRectangleOutput = .RectangleToScreen(New Rectangle(0, 0, intWidth, intHeight))
                objRectangleOutput = .RectangleToScreen(objRectangleInput)

            End If ''end of ""If (pictureLeft.BorderStyle = ...) ... ElseIf (pictureLeft.BorderStyle = ...)...

        End With ''End of ""With par_ctlPictureBox""

        Return objRectangleOutput

    End Function ''End of ""Private Function GetScreenRectangle""




    Private Sub ButtonUndoOkay1_Click(sender As Object, e As EventArgs) Handles ButtonUndoOkay1.Click
        ''
        ''Added 6/4/2022 thomas downes  
        ''
        picturePreview.Image?.Dispose()
        picturePreview.Image = Nothing
        pictureRight.Image?.Dispose()
        pictureRight.Image = Nothing

        ButtonOkay1of3.Enabled = True

        ButtonOkay2of3.Enabled = False
        ButtonOkay3of3.Enabled = False
        ButtonUndoOkay1.Enabled = False

    End Sub


    Private Sub FormBackgroundScreenscape_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 6/3/2022 td
        ''
        If (Me.Input_ShowMoveableControl) Then
            pictureLeftOriginal.Visible = False
            With CtlMoveableBackground1
                .Visible = True
                .BringToFront()
                .ImageBackgroundImage = Me.Input_BackgroundImage
                .LoadImageFromImage(Me.Input_BackgroundImage)
                .Load_Control()
            End With

        Else
            pictureLeftOriginal.Visible = True
            CtlMoveableBackground1.Visible = False
            pictureLeftOriginal.BringToFront()
            pictureLeftOriginal.Image = Me.Input_BackgroundImage
            pictureLeftOriginal.SizeMode = Me.Input_PictureBoxSizeMode

        End If ''ENd of ""If (Me.Input_ShowMoveableControl) Then ... Else...."""

        ''
        ''Added 6/12/2022 
        ''
        If (Me.Input_ShowSizingControl) Then

            ''Added 6/12/2022 
            LabelAdjustSize.Visible = True
            PanelSizing1.Visible = True
            HScrollBar1.Visible = True

        End If ''End of ""If (Me.Input_ShowSizingControl) Then""






    End Sub

    Private Sub ButtonOkay3of3_Click(sender As Object, e As EventArgs) Handles ButtonOkay3of3.Click
        ''
        ''Added 6/10/2022 td
        ''
        Me.Output_Image = pictureRight.Image
        Me.Output_Image_LocationPath = IO.Path.GetRandomFileName()
        pictureRight.Image.Save(Me.Output_Image_LocationPath)

ExitHandler:
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ButtonOkay1of3_Click(sender As Object, e As EventArgs) Handles ButtonOkay1of3.Click
        ''
        ''Added 6/4/2022 td
        ''
        Dim imagePreview As Image
        Dim rectangleInput As Rectangle

        ''imagePreview =
        ''TakeScreenShot_Modified(New Rectangle(pictureLeftOriginal.Location,
        ''                                      pictureLeftOriginal.Size))

        rectangleInput = GetScreenRectangle(pictureLeftOriginal)
        imagePreview = TakeScreenShot_Modified(rectangleInput, pictureLeftOriginal)

        ''6/10/2022  picturePreview.Image = imagePreview
        pictureRight.Image = imagePreview

ExitHandler:
        ButtonOkay1of3.Enabled = False
        ButtonUndoOkay1.Enabled = True
        ButtonOkay2of3.Enabled = True

    End Sub

    Private Sub ButtonOkay2of3_Click(sender As Object, e As EventArgs) Handles ButtonOkay2of3.Click
        ''
        ''Added 6/10/2022
        ''
        picturePreview.Image = pictureRight.Image
        picturePreview.SizeMode = PictureBoxSizeMode.Zoom ''Added 6/11/2022 td
        picturePreview.Visible = True
        picturePreview.BringToFront()

ExitHandler:
        ButtonOkay2of3.Enabled = False
        ButtonUndoOkay2.Enabled = True
        ButtonOkay3of3.Enabled = True

    End Sub

    Private Sub ButtonUndoOkay2_Click(sender As Object, e As EventArgs) Handles ButtonUndoOkay2.Click
        ''
        ''Added 6/11/2022 
        ''
        picturePreview.Image?.Dispose()
        picturePreview.Visible = False

ExitHandler:
        ButtonOkay2of3.Enabled = True
        ButtonUndoOkay2.Enabled = False
        ButtonOkay3of3.Enabled = False

    End Sub

    Private Sub pictureLeftOriginal_Click(sender As Object, e As EventArgs) Handles pictureLeftOriginal.Click

        ''Added 6/12/2022 
        ButtonOkay1of3.PerformClick()

    End Sub

    Private Sub pictureRight_Click(sender As Object, e As EventArgs) Handles pictureRight.Click

        ''Added 6/12/2022
        If (ButtonOkay2of3.Enabled) Then
            ButtonOkay2of3.PerformClick()
        End If

    End Sub


    Private Sub picturePreview_Click(sender As Object, e As EventArgs) Handles picturePreview.Click

        ''Added 6/12/2022
        If (ButtonOkay3of3.Enabled) Then
            ButtonOkay3of3.PerformClick()
        End If

    End Sub


End Class