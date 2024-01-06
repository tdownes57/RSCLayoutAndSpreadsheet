''
''Added 1/05/2024 thomas downes
''
Imports ciBadgeInterfaces

Module _StructsEtc
    ''
    ''Added 1/05/2024 thomas downes
    ''

    Public Structure StructEndPoint

        ''Added 1/05/2024 thomas downes
        Public Endpoint As TwoCharacterDLLItem
        Public EndpointIndex As Integer
        Public EndpointIsInclusive As Boolean ''= True

        Public Sub New(par_list As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem),
                       Optional par_bUseFinalItem As Boolean = True,
                       Optional par_bUseSecondToLast As Boolean = False)
            ''
            ''Added 1/05/2024 thomas downes
            ''
            Endpoint = par_list.DLL_GetLastItem()
            EndpointIndex = -1 + par_list.DLL_CountAllItems
            EndpointIsInclusive = True

            If (par_bUseSecondToLast) Then

                Endpoint = Endpoint.DLL_GetItemPrior
                EndpointIndex -= 1

            End If ''End of ""If (par_bUseSecondToLast) Then""

        End Sub ''End of ""Public Sub New""

    End Structure









End Module
