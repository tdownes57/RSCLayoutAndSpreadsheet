''
''Added 2/27/2024 thomas downes
''
Imports ciBadgeInterfaces

Public Class TwoCharacterDLLVerticalA
    Inherits TwoCharacterDLLItem
    Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA)
    ''
    ''Added 2/27/2024 thomas downes
    ''
    ''Probably not needed. ---12/12/2024  Dim mod_next As TwoCharacterDLLVertical ''Added 10/16/2024 td
    ''Probably not needed. ---12/12/2024  Dim mod_prior As TwoCharacterDLLVertical ''Added 10/16/2024 td

    ''DIFFICULT AND CONFUSING -- 12/12/2024 TD
    ''Probably not needed. ---12/12/2024  Dim mod_next_priorSortOrder As TwoCharacterDLLVertical ''Added 12/12/2024 td

    Public Sub New(par_twoChars As String)

        MyBase.New(par_twoChars)


    End Sub



    Public Overloads Sub DLL_SetItemNext_OfT(param As TwoCharacterDLLVerticalA) Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_SetItemNext_OfT
        ''Throw New NotImplementedException()
        ''Probably not needed. ---12/12/2024  MyBase.DLL_SetItemNext_OfT(param)
        ''Probably not needed. ---12/12/2024  mod_next = param ''Added 12/12/2024 td
        MyBase.mod_next = param ''Added 12/12/2024 td

    End Sub

    Public Overloads Sub DLL_SetItemPrior_OfT(param As TwoCharacterDLLVerticalA) Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_SetItemPrior_OfT
        ''Throw New NotImplementedException()
        ''Probably not needed. ---12/12/2024  MyBase.DLL_SetItemPrior_OfT(param)
        ''Probably not needed. ---12/12/2024  mod_prior = param ''Added 12/12/2024 td
        ''Feb2025 MyBase.mod_next = param ''Added 12/12/2024 td
        MyBase.mod_prior = param ''Added 12/12/2024 td

    End Sub

    Public Function GetItemNext_OfT() As TwoCharacterDLLVerticalA Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_GetItemNext_OfT
        ''Throw New NotImplementedException()
        Return MyBase.DLL_GetItemNext_OfT()

    End Function

    Public Overloads Function DLL_GetItemNext_OfT(param_iterationsOfNext As Integer) As TwoCharacterDLLVerticalA Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_GetItemNext_OfT
        ''
        ''Added 1/07/2025 td
        ''
        ''Throw New NotImplementedException()
        Return CType(MyBase.DLL_GetItemNext_OfT(param_iterationsOfNext), TwoCharacterDLLVerticalA)

    End Function

    Public Overloads Function DLL_GetItemPrior_OfT() As TwoCharacterDLLVerticalA Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_GetItemPrior_OfT
        ''
        ''Added 1/07/2025 td
        ''
        ''Throw New NotImplementedException()
        Return CType(MyBase.DLL_GetItemPrior_OfT(), TwoCharacterDLLVerticalA)

    End Function


    ''Public Overloads Function DLL_GetItemNext_PriorSortOrder() As TwoCharacterDLLVertical Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_GetItemNext_PriorSortOrder
    ''    ''DIFFICULT AND CONFUSING -- Added 12/12/2024 
    ''    Return MyBase.DLL_GetItemNext_PriorSortOrder()
    ''End Function
    ''
    ''Public Overloads Sub DLL_SetItemNext_PriorSortOrder(param As TwoCharacterDLLVertical) Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_SetItemNext_PriorSortOrder        ''Throw New NotImplementedException()
    ''    ''DIFFICULT AND CONFUSING -- Added 12/12/2024 
    ''    MyBase.DLL_SetItemNext_PriorSortOrder(param)
    ''End Sub


    Public Overloads Sub DLL_SetItemNext_OfT(param As TwoCharacterDLLVerticalA, pboolAllowNulls As Boolean) Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_SetItemNext_OfT
        ''Throw New NotImplementedException()

        ''---MyBase.DLL_SetItemNext_OfT(param)
        ''MyBase.mod_next = param
        MyBase.DLL_SetItemNext_OfT(param, pboolAllowNulls)

    End Sub


    Public Overloads Sub DLL_SetItemNext_OfT(param As TwoCharacterDLLVerticalA, pboolAllowNulls As Boolean, pboolDoublyLinkIt As Boolean) Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_SetItemNext_OfT
        ''Added 12/22/2024 

        ''---MyBase.DLL_SetItemNext_OfT(param)
        ''MyBase.mod_next = param
        MyBase.DLL_SetItemNext_OfT(param, pboolAllowNulls, pboolDoublyLinkIt)

    End Sub


    Public Overloads Sub DLL_SetItemPrior_OfT(param As TwoCharacterDLLVerticalA, pboolAllowNulls As Boolean) Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_SetItemPrior_OfT
        ''Throw New NotImplementedException()
        ''----MyBase.DLL_SetItemPrior_OfT(param)
        ''MyBase.mod_prior = param
        MyBase.DLL_SetItemPrior_OfT(param, pboolAllowNulls)

    End Sub


    Public Overloads Function IDoublyLinkedItem_DLL_GetItemPrior_OfT(param_iterationsOfPrior As Integer) As TwoCharacterDLLVerticalA Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_GetItemPrior_OfT
        Throw New NotImplementedException()
    End Function

    Public Overloads Function DLL_UnboxControl_OfT() As TwoCharacterDLLVerticalA ''Jan24 2025 Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_UnboxControl_OfT
        Throw New NotImplementedException()
    End Function

    Public Overloads Function DLL_GetNextItemFollowingRange_OfT(param_rangeSize As Integer, param_mayBeNull As Boolean) As TwoCharacterDLLVerticalA Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_GetNextItemFollowingRange_OfT
        ''Throw New NotImplementedException()
        Return MyBase.DLL_GetNextItemFollowingRange_OfT(param_rangeSize, param_mayBeNull)

    End Function


    Public Overloads Function DLL_GetDistanceTo(paramItem As TwoCharacterDLLVerticalA) As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_GetDistanceTo
        ''
        ''Added 11/2/2024 
        ''
        Return MyBase.DLL_GetDistanceTo(paramItem)

    End Function ''End of Public Function DLL_GetDistanceTo


    ''' <summary>
    ''' This gives the 1-based index of the current item.
    ''' </summary>
    ''' <returns>This gives the 1-based index of the current item.</returns>
    Public Overloads Function DLL_GetItemIndex_base1() As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_GetItemIndex_base1
        ''
        ''Added 11/12/2024 thomas downes
        ''
        Return MyBase.DLL_GetItemIndex_base1()


    End Function ''Public Function DLL_GetItemIndex_base1() As Integer


    Private Overloads Function DLL_GetItemAtIndex_base0(paramIndex_b0 As Integer) As TwoCharacterDLLVerticalA Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_GetItemAtIndex_base0

        ''Added 1/10/2025 & 1/07/2025 td
        Return MyBase.DLL_GetItemAtIndex_base0(paramIndex_b0)

    End Function

    Private Function IDoublyLinkedItem_DLL_GetItemAtIndex_base1(paramIndex_b1 As Integer) As TwoCharacterDLLVerticalA Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_GetItemAtIndex_base1

        ''Added 1/10/2025 & 1/07/2025 td
        Return MyBase.DLL_GetItemAtIndex_base1(paramIndex_b1)

    End Function ''End of Private Function IDoublyLinkedItem_DLL_GetItemAtIndex_b1


    ''' <summary>
    ''' This gives the 0-based index of the current item.
    ''' </summary>
    ''' <returns>This gives the 0-based index of the current item.</returns>
    Public Overloads Function DLL_GetItemIndex_base0() As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_GetItemIndex_base0
        ''
        ''Added 11/12/2024 thomas downes
        ''
        Return MyBase.DLL_GetItemIndex_base0()

    End Function ''Public Function DLL_GetItemIndex_base0() As Integer


    Public Overloads Sub DLL_InsertItemToNext(param As TwoCharacterDLLVerticalA, pbDoublyLinked As Boolean) _
      Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_InsertItemToNext
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


    Public Overloads Sub DLL_InsertItemToPrior(param As TwoCharacterDLLVerticalA, pbDoublyLinked As Boolean) _
    Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_InsertItemToPrior
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

    Public Overloads Function DLL_GetDistanceTo(paramItem As TwoCharacterDLLVerticalA,
                                      ByRef pbLocatedSuccessfully As Boolean) As Integer _
                                      Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_GetDistanceTo

        ''--Throw New NotImplementedException()
        Return MyBase.DLL_GetDistanceTo(paramItem, pbLocatedSuccessfully)

    End Function ''End of "Public Function DLL_GetDistanceTo""


    Public Overloads Function DLL_GetItemFirst() As TwoCharacterDLLVerticalA Implements ciBadgeInterfaces.IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_GetItemFirst
        ''
        ''Added 12/29/2024 td
        ''
        Return MyBase.DLL_GetItemFirst() ''---C#---As TwoCharacterDLLVertical

    End Function ''end of ""Public Overloads Function DLL_GetItemFirst()""


    Public Overloads Function DLL_GetItemLast() As TwoCharacterDLLVerticalA Implements ciBadgeInterfaces.IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_GetItemLast
        ''
        ''Added 12/12/2024 td
        ''
        Return MyBase.DLL_GetItemLast() ''---C#---As TwoCharacterDLLVertical

    End Function ''end of ""Public Overloads Function DLL_GetItemLast()""


    Public Overloads Function DLL_GetValue() As String Implements ciBadgeInterfaces.IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_GetValue

        ''Added 12/15/2024 
        Return MyBase.DLL_GetValue()

    End Function ''End of ""Public Overloads Function DLL_GetValue() As String""


    ''
    ''
    ''Restoring Sort-Order functions.  ---12/12/2024
    ''
    ''
    Public Overloads Sub DLL_SaveCurrentSortOrder_ToPrior(pbExecuteInCascade As Boolean) Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_SaveCurrentSortOrder_ToPrior


        ''Added 12/12/2024 
        MyBase.DLL_SaveCurrentSortOrder_ToPrior(pbExecuteInCascade)

    End Sub ''End of ""Public Sub DLL_SaveCurrentSortOrder_ToPrior()""


    Public Overloads Sub DLL_RestorePriorSortOrder(par_countdownItems As Integer) Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_RestorePriorSortOrder

        ''Added 12/12/2024 
        ''12-29-2024 td''MyBase.DLL_RestorePriorSortOrder()
        MyBase.DLL_RestorePriorSortOrder(par_countdownItems)

    End Sub ''End of ""Public Sub DLL_SaveCurrentSortOrder_ToPrior()""


    Public Overloads Sub DLL_ClearPriorSortOrder(pbExecuteInCascade As Boolean) Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).DLL_ClearPriorSortOrder

        ''Added 12/12/2024 
        MyBase.DLL_ClearPriorSortOrder(pbExecuteInCascade)

    End Sub ''End of ""Public Sub DLL_SaveCurrentSortOrder_ToPrior()""


    Public Overloads Function GetConvertToGeneric_OfT(Of T_BaseOrParallel As IDoublyLinkedItem(Of T_BaseOrParallel))(firstItem As T_BaseOrParallel) _
              As T_BaseOrParallel Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).GetConvertToGeneric_OfT
        ''
        ''Added 1/07/2025 
        ''
        Dim intIndex_b0 As Integer
        intIndex_b0 = DLL_GetItemIndex_base0()
        firstItem = firstItem.DLL_GetItemFirst()
        Return firstItem.DLL_GetItemAtIndex_base0(intIndex_b0)

    End Function ''Public Function GetConvertToGeneric_OfT


    Public Function GetConvertToArray() As TwoCharacterDLLVerticalA() Implements IDoublyLinkedItem(Of TwoCharacterDLLVerticalA).GetConvertToArray

        ''Throw New NotImplementedException()

        Dim intCount As Integer = DLL_CountItemsAllInList()
        Dim arrResult(intCount - 1) As TwoCharacterDLLVerticalA
        Dim temp As TwoCharacterDLLVerticalA ''= Me.DLL_GetItemFirst()

        temp = Me.DLL_GetItemFirst()
        For index = 0 To intCount - 1
            arrResult(index) = temp
            temp = temp.DLL_GetItemNext_OfT()
        Next index
        Return arrResult

    End Function ''End of Public Function GetConvertToArray() As TwoCharacterDLLVertical()





End Class
