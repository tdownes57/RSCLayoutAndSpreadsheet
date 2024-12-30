''
''Added 2/27/2024 thomas downes
''
Imports ciBadgeInterfaces

Public Class TwoCharacterDLLHorizontal
    Inherits TwoCharacterDLLItem
    Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal)
    ''
    ''Added 2/27/2024 thomas downes
    ''
    Dim mod_next As TwoCharacterDLLHorizontal
    Dim mod_prior As TwoCharacterDLLHorizontal

    Public Sub New(par_twoChars As String)

        MyBase.New(par_twoChars)


    End Sub

    Public Overloads Sub DLL_SetItemNext_OfT(param As TwoCharacterDLLHorizontal) Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_SetItemNext_OfT
        ''Throw New NotImplementedException()
        MyBase.DLL_SetItemNext_OfT(param)
        mod_next = param ''Added 12/12/2024 td

    End Sub

    Public Overloads Sub DLL_SetItemPrior_OfT(param As TwoCharacterDLLHorizontal) Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_SetItemPrior_OfT
        ''Throw New NotImplementedException()
        MyBase.DLL_SetItemPrior_OfT(param)
        mod_prior = param ''Added 12/12/2024 td

    End Sub


    Public Overloads Function DLL_GetItemNext_OfT() As TwoCharacterDLLHorizontal Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_GetItemNext_OfT
        ''Throw New NotImplementedException()
        Return MyBase.DLL_GetItemNext_OfT()
    End Function

    Public Overloads Function DLL_GetItemNext_OfT(param_iterationsOfNext As Integer) As TwoCharacterDLLHorizontal Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_GetItemNext_OfT
        ''Throw New NotImplementedException()
        Return MyBase.DLL_GetItemNext_OfT(param_iterationsOfNext)
    End Function

    Public Overloads Function DLL_GetItemPrior_OfT() As TwoCharacterDLLHorizontal Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_GetItemPrior_OfT
        ''Throw New NotImplementedException()
        Return MyBase.DLL_GetItemNext_OfT()
    End Function

    Public Overloads Function IDoublyLinkedItem_DLL_GetItemPrior_OfT(param_iterationsOfPrior As Integer) As TwoCharacterDLLHorizontal Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_GetItemPrior_OfT
        Throw New NotImplementedException()
    End Function


    Public Overloads Sub DLL_SetItemNext_OfT(param As TwoCharacterDLLHorizontal, paramAllowNulls As Boolean) Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_SetItemNext_OfT

        ''Throw New NotImplementedException()

        If (param Is Nothing And paramAllowNulls) Then
            ''Added 11/4/2024 
            MyBase.DLL_ClearReferenceNext("S"c)

        ElseIf (param Is Nothing And (Not paramAllowNulls)) Then ''Added 12/22/2024 
            ''Added 12/22/2024 td
            Throw New Exception("A null value for Next is not allowed.")

        Else
            MyBase.DLL_SetItemNext_OfT(param)
        End If

    End Sub ''ENd of '"Public Overloads Sub DLL_SetItemNext_OfT""


    ''Public Overloads Sub DLL_SetItemNext_OfT(param As TwoCharacterDLLHorizontal, paramAllowNulls As Boolean, paramDoublyLinkIt As Boolean) Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_SetItemNext_OfT

    ''    ''Added 12/22/2024 

    ''    If (param Is Nothing And paramAllowNulls) Then
    ''        ''Added 11/4/2024 
    ''        MyBase.DLL_ClearReferenceNext("S"c)

    ''    ElseIf (param Is Nothing And (Not paramAllowNulls)) Then ''Added 12/22/2024 

    ''        ''Added 12/22/2024 td
    ''        Throw New Exception("A null value for Next is not allowed.")

    ''    Else
    ''        MyBase.DLL_SetItemNext_OfT(param)

    ''    End If

    ''    ''
    ''    ''Added 12/22/2024 
    ''    ''
    ''    If (paramDoublyLinkIt) Then

    ''        ''Added 12/22/2024 
    ''        param.DLL_SetItemPrior_OfT(Me)

    ''    End If ''End of ""If (paramDoublyLinkIt) Then""


    ''End Sub ''ENd of '"Public Overloads Sub DLL_SetItemNext_OfT""


    Public Overloads Sub DLL_SetItemNext_OfT(param As TwoCharacterDLLHorizontal, paramAllowNulls As Boolean, paramDoublyLinkIt As Boolean) Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_SetItemNext_OfT

        ''Added 12/22/2024 

        If (param Is Nothing And paramAllowNulls) Then
            ''Added 11/4/2024 
            MyBase.DLL_ClearReferenceNext("S"c)

        ElseIf (param Is Nothing And (Not paramAllowNulls)) Then ''Added 12/22/2024 

            ''Added 12/22/2024 td
            Throw New Exception("A null value for Next is not allowed.")

        Else
            MyBase.DLL_SetItemNext_OfT(param)

        End If

        ''
        ''Added 12/22/2024 
        ''
        If (paramDoublyLinkIt) Then

            ''Added 12/22/2024 
            param.DLL_SetItemPrior_OfT(Me)

        End If ''End of ""If (paramDoublyLinkIt) Then""


    End Sub ''ENd of '"Public Overloads Sub DLL_SetItemNext_OfT""


    Public Overloads Sub DLL_SetItemPrior_OfT(param As TwoCharacterDLLHorizontal, paramAllowNulls As Boolean) _
        Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_SetItemPrior_OfT

        ''Throw New NotImplementedException()
        If (param Is Nothing And paramAllowNulls) Then
            ''Added 11/4/2024 
            MyBase.DLL_ClearReferencePrior("S"c)
        Else
            MyBase.DLL_SetItemPrior_OfT(param)
        End If

    End Sub


    Public Overloads Function DLL_UnboxControl_OfT() As TwoCharacterDLLHorizontal Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_UnboxControl_OfT
        Throw New NotImplementedException()
    End Function

    Public Overloads Function DLL_GetNextItemFollowingRange_OfT(param_rangeSize As Integer, param_mayBeNull As Boolean) As TwoCharacterDLLHorizontal Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_GetNextItemFollowingRange_OfT
        Throw New NotImplementedException()
    End Function


    Public Sub DLL_InsertItemToNext(param As TwoCharacterDLLHorizontal, pbSetBothDirections As Boolean) _
         Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_InsertItemToNext
        ''
        '' This will take some weight off, from DLL_List(Of TControl). 
        ''
        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        If (param Is Nothing) Then System.Diagnostics.Debugger.Break()

        If (mod_next IsNot Nothing) Then
            mod_next.DLL_SetItemPrior(param)
            param.DLL_SetItemNext(mod_next)
        End If ''End of ""If (mod_next IsNot Nothing) Then""

        ''
        ''Exiting procedure. 
        ''
        mod_next = param
        param.DLL_SetItemPrior(Me)

    End Sub ''End of ""Public Sub DLL_SetItemPrior_OfT(...)""


    Public Sub DLL_InsertItemToPrior(param As TwoCharacterDLLHorizontal, pbSetBothDirections As Boolean) _
         Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_InsertItemToPrior
        ''
        '' This will take some weight off, from DLL_List(Of TControl). 
        ''
        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        If (param Is Nothing) Then System.Diagnostics.Debugger.Break()

        If (mod_prior IsNot Nothing) Then
            mod_prior.DLL_SetItemNext(param)
            param.DLL_SetItemNext(mod_prior)
        End If ''End of ""If (mod_next IsNot Nothing) Then""

        ''
        ''Exiting procedure. 
        ''
        mod_prior = param
        param.DLL_SetItemNext(Me)

    End Sub ''End of ""Public Sub DLL_SetItemPrior_OfT(...)""


    Public Overloads Function DLL_GetDistanceTo(paramItem As TwoCharacterDLLHorizontal) As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_GetDistanceTo
        ''
        ''Added 11/2/2024 
        ''
        Return MyBase.DLL_GetDistanceTo(paramItem)

    End Function ''End of Public Function DLL_GetDistanceTo


    Public Function DLL_GetIndexOfItem() As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_GetItemIndex
        ''
        ''Added 11/12/2024 thomas downes
        ''
        Return MyBase.DLL_GetItemIndex()


    End Function ''Public Function DLL_GetIndexOfItem() As Integer


    Public Overloads Function DLL_GetDistanceTo(paramItem As TwoCharacterDLLHorizontal, ByRef pbLocatedSuccessfully As Boolean) As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_GetDistanceTo
        ''//--Throw New NotImplementedException()

        ''--Throw New NotImplementedException()
        Return MyBase.DLL_GetDistanceTo(paramItem, pbLocatedSuccessfully)

    End Function


    Public Overloads Function DLL_GetItemLast() As TwoCharacterDLLHorizontal Implements ciBadgeInterfaces.IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_GetItemLast
        ''
        ''Added 12/12/2024 td
        ''
        Return MyBase.DLL_GetItemLast() ''---C#---As TwoCharacterDLLVertical

    End Function ''end of ""Public Overloads Function DLL_GetItemLast()""


    Public Overloads Function DLL_GetItemFirst() As TwoCharacterDLLHorizontal Implements ciBadgeInterfaces.IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_GetItemFirst
        ''
        ''Added 12/12/2024 td
        ''
        Return MyBase.DLL_GetItemFirst() ''---C#---As TwoCharacterDLLVertical

    End Function ''end of ""Public Overloads Function DLL_GetItemFirst()""


    Public Overloads Function DLL_GetValue() As String Implements ciBadgeInterfaces.IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_GetValue

        ''Added 12/15/2024 
        Return MyBase.DLL_GetValue()

    End Function ''End of ""Public Overloads Function DLL_GetValue() As String""


    ''Public Function DLL_GetDistanceTo(paramItem As TwoCharacterDLLHorizontal) As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_GetDistanceTo

    ''End Function ''End of Public Function DLL_GetDistanceTo 


    ''
    ''
    ''Restoring Sort-Order functions.  ---12/12/2024
    ''
    ''
    Public Overloads Sub DLL_SaveCurrentSortOrder_ToPrior(pbExecuteInCascade As Boolean) Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_SaveCurrentSortOrder_ToPrior


        ''Added 12/12/2024 
        MyBase.DLL_SaveCurrentSortOrder_ToPrior(pbExecuteInCascade)

    End Sub ''End of ""Public Sub DLL_SaveCurrentSortOrder_ToPrior(pbExecuteInCascade As Boolean)""


    Public Overloads Sub DLL_RestorePriorSortOrder(par_countdownItems As Integer) Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_RestorePriorSortOrder

        ''Added 12/12/2024 
        ''12/29/2024 td''MyBase.DLL_RestorePriorSortOrder()
        MyBase.DLL_RestorePriorSortOrder(par_countdownItems)

    End Sub ''End of ""Public Sub DLL_SaveCurrentSortOrder_ToPrior()""


    Public Overloads Sub DLL_ClearPriorSortOrder(pbExecuteInCascade As Boolean) Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_ClearPriorSortOrder

        ''Added 12/12/2024 
        MyBase.DLL_ClearPriorSortOrder(pbExecuteInCascade)

    End Sub ''End of ""Public Sub DLL_SaveCurrentSortOrder_ToPrior(pbExecuteInCascade As Boolean)""



End Class
