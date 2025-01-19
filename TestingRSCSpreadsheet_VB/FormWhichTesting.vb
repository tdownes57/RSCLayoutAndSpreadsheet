
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

    Private Sub LinkSimpleDemoOfCSharp1D_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCSharpSimple1D.LinkClicked

        ''Added 1/22/2024 td
        ''---Dim objFormToShow As New FormTestUsingManager
        Dim objFormToShow As New FormSimpleDemoOfCSharp1D ''---TestUsingManager
        ''---objFormToShow.Show()
        ''------objFormToShow.Show(Me)
        objFormToShow.ShowDialog(Me)

    End Sub

    ''Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs)
    ''    ''Added 1/22/2024 td
    ''    ''---Dim objFormToShow As New FormTestUsingManager
    ''    Dim objFormToShow As New FormSimpleDemoOfCSharp1D ''---TestUsingManager
    ''    objFormToShow.Show()
    ''End Sub

    Private Sub LinkLabelSimpleBackup1D_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelSimpleBackup1D.LinkClicked

        ''Added 12/04/2024 td
        Dim objFormToShow As New FormSimpleDemo1D_Backup '' FormSimpleDemoOfCSharp1D ''---TestUsingManager
        ''    objFormToShow.Show()
        objFormToShow.ShowDialog(Me)

    End Sub

    Private Sub LinkSimpleDemo1DHorizontal_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkSimpleDemo1DHorizontal.LinkClicked

        ''Added 12/04/2024 td
        Dim objFormToShow As New FormSimpleDemo1DHorizontal
        ''    objFormToShow.Show()
        objFormToShow.ShowDialog(Me)

    End Sub

    Private Sub FormWhichTesting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link1Dmode2Dmanager.LinkClicked

        ''Added 12/04/2024 td
        Dim objFormToShow As New Form1Dmode2Dmanager
        ''    objFormToShow.Show()
        objFormToShow.ShowDialog(Me)


    End Sub

    Private Sub LinkDemo1DVertical_LinkClicked_2(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkDemo1DVertical.LinkClicked
        ''
        ''Added 1/18/2025 
        ''
        Dim objFormToShow As New FormDemo1DVertical
        ''    objFormToShow.Show()
        objFormToShow.ShowDialog(Me)

    End Sub
End Class