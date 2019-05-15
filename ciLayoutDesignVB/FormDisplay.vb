Public Class FormDisplay

    Public ImageLarge_OrientLandscape As Image
    Public ImageSmall_OrientPortrait As Image


    Private Sub FormDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''5/15/2019 td''pictureboxFinalPrint.Image = ImageLarge_OrientLandscape
        pictureboxFinalPrint.Image = ImageSmall_OrientPortrait
        pictureboxLandscape.Image = ImageLarge_OrientLandscape


    End Sub
End Class