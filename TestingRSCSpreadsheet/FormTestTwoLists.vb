Public Class FormTestTwoLists
    Private Sub labelItemsDisplay_Click(sender As Object, e As EventArgs) Handles labelItemsDisplay1.Click

        ''Added 1/24/2024 
        userControlOperationBoth.BackColor = CType(sender, Control).BackColor

    End Sub

    Private Sub labelItemsDisplay2_Click(sender As Object, e As EventArgs) Handles labelItemsDisplay2.Click

        ''Added 1/24/2024 
        userControlOperationBoth.BackColor = CType(sender, Control).BackColor

    End Sub
End Class