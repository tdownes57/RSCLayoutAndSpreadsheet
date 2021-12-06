Public Class FormDisplayBadge

    Public ImageLarge_OrientLandscape As Image
    Public ImageSmall_OrientPortrait As Image


    Private Sub FormDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''5/15/2019 td''pictureboxFinalPrint.Image = ImageLarge_OrientLandscape
        pictureboxFinalPrint.Image = ImageSmall_OrientPortrait
        pictureboxLandscape.Image = ImageLarge_OrientLandscape


    End Sub

    Private Sub ButtonPrintBadge_Click(sender As Object, e As EventArgs) Handles ButtonPrintBadge.Click

        ''If PrintDialog1.ShowDialog = DialogResult.OK Then
        ''   mod_PrintDoc.Print()
        ''End If

    End Sub

    Private Sub ButtonSaveAsXML_Click(sender As Object, e As EventArgs) Handles ButtonSaveAsXML.Click
        ''
        ''Added 7/15/2019 thomas downes
        ''
        ''   Copy the elements of the layout to a class which is not a Windows Form
        ''   but which will act as a "container" for the layout-relevant Windows controls.
        ''
        ''   The container class will have Serialize and Deserialize commands. 
        ''
        ''

    End Sub
End Class