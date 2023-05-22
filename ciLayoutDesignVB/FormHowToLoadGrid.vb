Public Class FormHowToLoadGrid

    Public LoadColumnByColumn As Boolean ''Added 5/23/2023 
    Public LoadRecipientsAsRows As Boolean ''Added 5/23/2023 
    Public LoadBothWays As Boolean ''Added 5/23/2023 
    Public UserHasCancelled As Boolean ''Added 5/23/2023 

    Private Sub ButtonLoadBoth_Click(sender As Object, e As EventArgs) Handles ButtonLoadBothAboveMethods.Click

        ''Added 5/23/2023 
        LoadBothWays = True
        LoadColumnByColumn = True
        LoadRecipientsAsRows = True
        Me.Close()

    End Sub

    Private Sub ButtonLoadByRecipientRows_Click(sender As Object, e As EventArgs) Handles ButtonLoadByRecipientRows.Click

        ''Added 5/23/2023 
        LoadRecipientsAsRows = True
        Me.Close()

    End Sub

    Private Sub ButtonColumnPrimary_Click(sender As Object, e As EventArgs) Handles ButtonColumnPrimary.Click

        ''Added 5/23/2023 
        LoadColumnByColumn = True
        Me.Close()

    End Sub

End Class