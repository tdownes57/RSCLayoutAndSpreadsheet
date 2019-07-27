Public Class FormSubsection
    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ''Added 7/26/2019 thomas d. 
        Me.Close()
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        ''Added 7/26/2019 thomas d. 
        Me.Close()
        Me.DialogResult = DialogResult.OK
    End Sub
End Class