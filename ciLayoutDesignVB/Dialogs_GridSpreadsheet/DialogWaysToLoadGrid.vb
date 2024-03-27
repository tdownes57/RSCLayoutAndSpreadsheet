Imports ciBadgeDesigner

Public Class DialogWaysToLoadGrid

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

    Private Sub DialogWaysToLoadGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 10/28/2023 td
        ''
        ''//If (RSCFieldSpreadsheet.TEST_CONFIRM_AND_VERIFY) Then
        Dim bTesting1 = RSCFieldSpreadsheet.TEST_CHECK_VERIFY_SLOWLY
        Dim bTesting2 = RSCFieldSpreadsheet.TEST_CHECK_VERIFY_SLOWLY

        If (bTesting2) Then
            LabelTEST_CHECK_CONFIRM.Visible = True
        Else
            LabelTEST_CHECK_CONFIRM.Visible = False

        End If ''Endof ""If (bTesting) Then... Else..."

    End Sub
End Class