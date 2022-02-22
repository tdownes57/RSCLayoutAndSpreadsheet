Option Explicit On
Option Strict On
''
'' Added 2/22/2022 thomas  
''

Public Class DialogEditRecipients
    ''
    '' Added 2/22/2022 thomas  
    ''
    Private mod_stringPastedData As String ''Added 2/22/2022  

    Private Sub ButtonPasteData_Click(sender As Object, e As EventArgs) Handles ButtonPasteData.Click
        ''
        '' Added 2/22/2022 thomas  
        ''
        mod_stringPastedData = Clipboard.GetText()


ExitHandler:
        ''
        ''Pass the data on.  
        ''
        RscFieldSpreadsheet1.PasteData(mod_stringPastedData)

    End Sub


    Private Function ReviewPastedData_IsOkay(par_stringPastedData As String)
        ''
        ''Added 2/22/2022 Thomas Downes  
        ''
        Dim boolOneMoreLines As Boolean
        Dim intNumberOfColumns As Integer
        Dim boolOneOrMoreColumns As Boolean
        Dim array_rows As String()
        Dim array_values As String()

        array_rows = par_stringPastedData.Split()

        For Each each_row As String In par_stringPastedData.Split()

        Next each_row


    End Function ''End of "Private Function ReviewPastedData_IsOkay()"


End Class