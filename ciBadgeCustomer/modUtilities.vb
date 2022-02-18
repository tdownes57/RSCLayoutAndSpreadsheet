''
''Added 2/18/2022 td
''
Module modUtilities
    ''
    ''Added 2/18/2022 td
    ''
    Public Function GuidIsFine(par_guid As Guid) As Boolean
        ''
        ''Added 2/18/2022 td
        ''
        Dim bDoneGuid As Boolean ''Added 2/18/2022 td
        bDoneGuid = String.IsNullOrEmpty(par_guid.ToString()) = False _
                AndAlso (par_guid.ToString().StartsWith("00000000") = False)
        Return bDoneGuid

    End Function


End Module
