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

    Private Sub ButtonUndoOkay1_Click(sender As Object, e As EventArgs) Handles ButtonUndoOkay1.Click


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

        End If



    End Sub

    Private Sub ButtonOkay3of3_Click(sender As Object, e As EventArgs) Handles ButtonOkay3of3.Click




    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub
End Class