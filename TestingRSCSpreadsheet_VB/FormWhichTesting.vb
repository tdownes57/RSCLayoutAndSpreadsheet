
#Const UseCSharpLibrary = False ''Added Septembet 2024 

Public Class FormWhichTesting

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkOperationsManager.LinkClicked

        ''Added 1/22/2024 td
        ''---Dim objFormToShow As New FormTestUsingManager
        Dim objFormToShow As New FormSimpleDemoOfCSharp1D ''---TestUsingManager
        objFormToShow.Show()

    End Sub

    Private Sub LinkFormManagesOps_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkFormManagesOps.LinkClicked

        ''Added 1/22/2024 td
        Dim objFormToShow As New FormTestRSC_Obselete
        objFormToShow.Show()


    End Sub

    Private Sub LinkFormManagesTwoLists(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkOpsManagerTwoLists.LinkClicked

#If (UseCSharpLibrary) Then
        ''Added 2/04/2024 td
        Dim objFormToShow As New FormTestTwoLists2x2
        objFormToShow.Show()
#End If

    End Sub

    Private Sub LinkLabelCSharpSimple1D_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCSharpSimple1D.LinkClicked

        ''Added 1/22/2024 td
        ''---Dim objFormToShow As New FormTestUsingManager
        Dim objFormToShow As New FormSimpleDemoOfCSharp1D ''---TestUsingManager
        objFormToShow.Show()

    End Sub
End Class