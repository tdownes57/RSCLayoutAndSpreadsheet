Imports ciBadgeInterfaces
Imports ciBadgeRecipients

Public Class FormTestRSCViaDigits

    Private mod_list As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterItem)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim each_twoCharsItem As TwoCharacterItem
        Dim each_strTwoChars As String
        Dim prior As TwoCharacterItem = Nothing
        Dim bListIsEmpty As Boolean = True

        For index = 1 To 30

            each_strTwoChars = String.Format("{0:99}", index)
            each_twoCharsItem = New TwoCharacterItem(each_strTwoChars, prior)
            If (prior IsNot Nothing) Then prior.DLL_SetItemNext(each_twoCharsItem)

            If (bListIsEmpty) Then
                mod_list.DLL_InsertOneItemFromEmpty(each_twoCharsItem)
            Else
                mod_list.DLL_InsertOneItemAfter(each_twoCharsItem, prior, True)
            End If

            ''Prepare.
            prior = each_twoCharsItem
            bListIsEmpty = False

        Next index


    End Sub
End Class
