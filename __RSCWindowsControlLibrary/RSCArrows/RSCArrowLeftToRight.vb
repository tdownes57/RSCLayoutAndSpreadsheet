Public Class RSCArrowLeftToRight
    Private Sub RSCElementArrowLeft_Click(sender As Object, e As EventArgs) Handles MyBase.Click

        ''Added 12/6/2022 td
        RaiseEvent_ControlClicked()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        ''Added 12/6/2022 td
        RaiseEvent_ControlClicked()

    End Sub
End Class
