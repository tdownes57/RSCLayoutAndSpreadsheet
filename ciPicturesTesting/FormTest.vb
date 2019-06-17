Public Class FormTest
    Private Sub FormTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 6/16/2019 thomas downes
        ''
        PictureBox1.Image = ciPictures_VB.PictureExamples.GetExample()

    End Sub
End Class