''
''Added 5/20/2022 Thomas downes  
''
Imports System.Drawing ''Added 5/20/2022  

Public Class DialogDisplayIDCardSides
    ''
    ''Added 5/20/2022 Thomas downes  
    ''
    Public BadgeImage_FrontSide As Image
    Public BadgeImage_BackSide As Image

    Private Sub LabelReturnToFrontSide_Click(sender As Object, e As EventArgs) Handles LabelReturnToFrontSide.Click

        ''Added 5/20/2022 td
        pictureBadgeFrontside.BringToFront()

    End Sub

    Private Sub labelProceedToBackside_Click(sender As Object, e As EventArgs) Handles labelProceedToBackside.Click

        ''Added 5/20/2022 td
        pictureBadgeBackside.BringToFront()

    End Sub

    Private Sub pictureBadgeBackside_Click(sender As Object, e As EventArgs) Handles pictureBadgeBackside.Click

        ''Added 5/20/2022 td
        pictureBadgeBackside.BringToFront()


    End Sub

    Private Sub pictureBadgeFrontside_Click(sender As Object, e As EventArgs) Handles pictureBadgeFrontside.Click

        ''Added 5/20/2022 td
        pictureBadgeFrontside.BringToFront()

    End Sub

    Private Sub DialogDisplayIDCardSides_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Added 5/20/2022 td
        pictureBadgeFrontside.Image = Me.BadgeImage_FrontSide

        ''
        ''Backside-related work. 
        ''
        If (Me.BadgeImage_BackSide Is Nothing) Then

            pictureBadgeBackside.Visible = False
            labelProceedToBackside.Visible = False
            LabelReturnToFrontSide.Visible = False

        Else
            ''
            ''There is a backside of the ID Card. 
            ''
            pictureBadgeBackside.Image = Me.BadgeImage_BackSide
            pictureBadgeBackside.Visible = True
            labelProceedToBackside.Visible = True
            LabelReturnToFrontSide.Visible = True

        End If ''End of ""If (Me.BadgeImage_BackSide Is Nothing) Then... Else..."




    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        ''Added 5/20/2022 td
        Me.Close()

    End Sub
End Class