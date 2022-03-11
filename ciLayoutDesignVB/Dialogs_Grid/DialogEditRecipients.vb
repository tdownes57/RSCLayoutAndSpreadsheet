Option Explicit On
Option Strict On
''
'' Added 2/22/2022 thomas  
''
Imports ciBadgeDesigner ''Added 3/10/2022 t2h2o2m2a2s2 d2o2w2n2e2s

Public Class DialogEditRecipients
    ''
    '' Added 2/22/2022 thomas  
    ''
    Private mod_designer As ClassDesigner ''Added 3/10/2022 td
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


    Private Function ReviewPastedData_IsOkay(par_stringPastedData As String,
                                             ByRef pref_message As String) As Boolean
        ''
        ''Added 2/22/2022 Thomas Downes  
        ''
        Dim boolOneMoreLines As Boolean
        Dim intNumberOfColumns As Integer
        Dim intNumberOfColumns_Prior As Integer
        Dim boolOneOrMoreColumns As Boolean
        Dim array_rows As String()
        Dim array_values As String()
        Dim boolMismatchedColumnCount As Boolean
        Dim intRowIndex As Integer

        ''Added 2/22/2022 t4h4o4m4a4s4 d4o4w4n4e4s4
        If (String.IsNullOrEmpty(par_stringPastedData)) Then
            pref_message = "Pasted data is null or zero-length string."
            Return False
        End If ''End of "If (String.IsNullOrEmpty(par_stringPastedData)) Then"

        array_rows = par_stringPastedData.Split(New String() {vbCrLf, vbCr, vbLf}, StringSplitOptions.None)

        For Each each_row As String In array_rows

            intRowIndex += 1
            array_values = each_row.Split(New String() {vbTab}, StringSplitOptions.None)
            intNumberOfColumns = array_values.Count()
            If (intNumberOfColumns_Prior > 0) Then
                If (intNumberOfColumns <> intNumberOfColumns_Prior) Then
                    boolMismatchedColumnCount = True
                    pref_message = String.Format("Irregular data set. The number of columns goes from {0} to {1}, in row {2} of {3}.",
                             intNumberOfColumns_Prior, intNumberOfColumns,
                             intRowIndex, array_rows.Count())
                    Exit For
                End If
            End If
            intNumberOfColumns_Prior = intNumberOfColumns
        Next each_row

        Return (Not boolMismatchedColumnCount)

    End Function ''End of "Private Function ReviewPastedData_IsOkay()"

    Private Sub DialogEditRecipients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 3/10/2022 thomas d.
        ''
        mod_designer = New ClassDesigner()

        RscFieldSpreadsheet1.LoadRuntimeColumns_AfterClearingDesign(mod_designer)



    End Sub
End Class