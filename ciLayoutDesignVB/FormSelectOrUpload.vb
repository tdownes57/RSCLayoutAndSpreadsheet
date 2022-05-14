''
''Added 5/13/2022  
''

Public Class FormSelectOrUpload

    Public UserWantsToUpload As Boolean
    Public UserWantsToSelect As Boolean
    Public UserWantsToSeeDemos As Boolean

    Private Sub ButtonUploadImage_Click(sender As Object, e As EventArgs) Handles ButtonUploadImage.Click
        ''
        ''Added 5/13/2022  
        ''
        UserWantsToUpload = True
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonSelectLoaded_Click(sender As Object, e As EventArgs) Handles ButtonSelectLoaded.Click
        ''
        ''Added 5/13/2022  
        ''
        UserWantsToSelect = True
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonSelectDemos_Click(sender As Object, e As EventArgs) Handles ButtonSelectDemos.Click
        ''
        ''Added 5/13/2022  
        ''
        UserWantsToSeeDemos = True
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        ''
        ''Added 5/13/2022  
        ''
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub
End Class