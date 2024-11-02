''
''Added 2/27/2024 thomas downes
''
Imports ciBadgeInterfaces

Public Class TwoCharacterDLLVertical
    Inherits TwoCharacterDLLItem
    Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical)
    ''
    ''Added 2/27/2024 thomas downes
    ''
    Dim mod_next As TwoCharacterDLLVertical ''Added 10/16/2024 td
    Dim mod_prior As TwoCharacterDLLVertical ''Added 10/16/2024 td

    Public Sub New(par_twoChars As String)

        MyBase.New(par_twoChars)


    End Sub



    Public Overloads Sub DLL_SetItemNext_OfT(param As TwoCharacterDLLVertical) Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_SetItemNext_OfT
        ''Throw New NotImplementedException()
        MyBase.DLL_SetItemNext_OfT(param)
    End Sub

    Public Overloads Sub DLL_SetItemPrior_OfT(param As TwoCharacterDLLVertical) Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_SetItemPrior_OfT
        ''Throw New NotImplementedException()
        MyBase.DLL_SetItemPrior_OfT(param)
    End Sub

    Public Function GetItemNext_OfT() As TwoCharacterDLLVertical Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_GetItemNext_OfT
        ''Throw New NotImplementedException()
        Return MyBase.DLL_GetItemNext_OfT()
    End Function

    Public Overloads Function DLL_GetItemNext_OfT(param_iterationsOfNext As Integer) As TwoCharacterDLLVertical Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_GetItemNext_OfT
        ''Throw New NotImplementedException()
        Return MyBase.DLL_GetItemNext_OfT(param_iterationsOfNext)
    End Function

    Public Overloads Function DLL_GetItemPrior_OfT() As TwoCharacterDLLVertical Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_GetItemPrior_OfT
        ''Throw New NotImplementedException()
        Return MyBase.DLL_GetItemNext_OfT()
    End Function

    Public Overloads Function IDoublyLinkedItem_DLL_GetItemPrior_OfT(param_iterationsOfPrior As Integer) As TwoCharacterDLLVertical Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_GetItemPrior_OfT
        Throw New NotImplementedException()
    End Function

    Public Overloads Function DLL_UnboxControl_OfT() As TwoCharacterDLLVertical Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_UnboxControl_OfT
        Throw New NotImplementedException()
    End Function

    Public Overloads Function DLL_GetNextItemFollowingRange_OfT(param_rangeSize As Integer, param_mayBeNull As Boolean) As TwoCharacterDLLVertical Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_GetNextItemFollowingRange_OfT
        Throw New NotImplementedException()
    End Function


    Public Function DLL_GetDistanceTo(paramItem As TwoCharacterDLLVertical) As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_GetDistanceTo
        ''
        ''Added 11/2/2024 
        ''
        Return MyBase.DLL_GetDistanceTo(paramItem)

    End Function ''End of Public Function DLL_GetDistanceTo

    Public Overloads Sub DLL_InsertItemToNext(param As TwoCharacterDLLVertical, pbDoublyLinked As Boolean) _
      Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_InsertItemToNext
        ''
        '' This will take some weight off, from DLL_List(Of TControl). 
        ''
        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        If (param Is Nothing) Then System.Diagnostics.Debugger.Break()
        If (Not pbDoublyLinked) Then System.Diagnostics.Debugger.Break()

        If (mod_next IsNot Nothing) Then
            mod_next.DLL_SetItemPrior(param)
            param.DLL_SetItemNext(mod_next)
        End If ''End of ""If (mod_next IsNot Nothing) Then""

        ''
        ''Exiting procedure. 
        ''
        mod_next = param
        param.DLL_SetItemPrior(Me)

    End Sub ''End of ""Public Sub DLL_SInsertItemToNext(...)""


    Public Overloads Sub DLL_InsertItemToPrior(param As TwoCharacterDLLVertical, pbDoublyLinked As Boolean) _
    Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_InsertItemToPrior
        ''
        '' This will take some weight off, from DLL_List(Of TControl). 
        ''
        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        If (param Is Nothing) Then System.Diagnostics.Debugger.Break()
        If (Not pbDoublyLinked) Then System.Diagnostics.Debugger.Break()

        If (mod_prior IsNot Nothing) Then
            mod_prior.DLL_SetItemNext(param)
            param.DLL_SetItemPrior(mod_prior)
        End If ''End of ""If (mod_prior IsNot Nothing) Then""

        ''
        ''Exiting procedure. 
        ''
        mod_prior = param
        param.DLL_SetItemNext(Me)

    End Sub ''End of ""Public Sub DLL_SInsertItemToNext(...)""

End Class
