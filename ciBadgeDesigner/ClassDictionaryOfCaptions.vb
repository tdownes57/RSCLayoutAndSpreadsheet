Public Class ClassDictionaryOfCaptions
    ''
    '' Added 12/21/2021 td
    ''
    Private mod_dictionary As New Dictionary(Of String, Integer)

    Public Function AddCaption_GetSuffix(par_caption As String) As String
        ''
        '' Added 12/21/2021 td
        ''
        Dim boolHasKey As Boolean
        Dim intCurrentCount As Integer = 0
        Dim intIncrementCount As Integer = 0

        boolHasKey = mod_dictionary.ContainsKey(par_caption)

        If (boolHasKey) Then

            intCurrentCount = mod_dictionary.Item(par_caption)
            intIncrementCount = (intCurrentCount + 1)
            mod_dictionary.Item(par_caption) = intIncrementCount ''Save the incremented count. 
            Return ("#" & intIncrementCount.ToString)

        Else

            intCurrentCount = 0
            intIncrementCount = 1
            mod_dictionary.Add(par_caption, intIncrementCount)
            Return "" ''Added 12/21/2021 

        End If ''End of "If (boolHasKey) Then ... Else ...."

        ''Won't likely execute. 
        Return ("#" & intIncrementCount.ToString)

    End Function

End Class
