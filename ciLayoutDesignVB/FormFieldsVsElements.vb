''
'' Added 5/11/2022 thomas downes
''
Public Class FormFieldsVsElements

    Public AddFields As Boolean
    Public AddBackgroundImage As Boolean ''Added 5/13/2022 td
    Public AddElements As Boolean

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        ''
        '' Added 5/11/2022 thomas downes
        ''
        ''Added 5/11/2022 td
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ButtonAddFields_Click(sender As Object, e As EventArgs) Handles ButtonAddFields.Click

        ''Added 5/11/2022 td
        Me.AddFields = True
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonAddElements_Click(sender As Object, e As EventArgs) Handles ButtonAddElements.Click

        ''Added 5/11/2022 td
        Me.AddElements = True
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonBackground_Click(sender As Object, e As EventArgs) Handles ButtonBackgroundImage.Click

        ''Added 5/11/2022 td
        Me.AddBackgroundImage = True
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub
End Class