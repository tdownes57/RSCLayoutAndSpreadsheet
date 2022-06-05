''
''Added 6/3/2022 thomas d  
''
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



    Private Sub ButtonUndoOkay1_Click(sender As Object, e As EventArgs) Handles ButtonUndoOkay1.Click
        ''
        ''Added 6/4/2022 thomas downes  
        ''
        picturePreview.Image.Dispose()
        picturePreview.Image = Nothing
        ButtonOkay1of3.Enabled = True
        ButtonUndoOkay1.Enabled = False

    End Sub


    Private Sub FormBackgroundScreenscape_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 6/3/2022 td
        ''
        If (Me.Input_ShowMoveableControl) Then
            pictureLeftOriginal.Visible = False
            CtlMoveableBackground1.Visible = True
            CtlMoveableBackground1.BringToFront()
            CtlMoveableBackground1.ImageBackgroundImage = Me.Input_BackgroundImage
            CtlMoveableBackground1.LoadImageFromImage(Me.Input_BackgroundImage)

        Else
            pictureLeftOriginal.Visible = True
            CtlMoveableBackground1.Visible = False
            pictureLeftOriginal.BringToFront()
            pictureLeftOriginal.Image = Me.Input_BackgroundImage
            pictureLeftOriginal.SizeMode = Me.Input_PictureBoxSizeMode

        End If ''ENd of ""If (Me.Input_ShowMoveableControl) Then ... Else...."""



    End Sub

    Private Sub ButtonOkay3of3_Click(sender As Object, e As EventArgs) Handles ButtonOkay3of3.Click




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

        imagePreview =
        TakeScreenShot_Modified(New Rectangle(pictureLeftOriginal.Location,
                                              pictureLeftOriginal.Size))

        picturePreview.Image = imagePreview

ExitHandler:
        ButtonOkay1of3.Enabled = False
        ButtonUndoOkay1.Enabled = True
        ButtonOkay2of3.Enabled = True

    End Sub




End Class