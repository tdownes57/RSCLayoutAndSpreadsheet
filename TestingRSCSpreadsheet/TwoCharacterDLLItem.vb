
Imports System.CodeDom
Imports System.Runtime.Intrinsics
Imports ciBadgeInterfaces
Imports Windows.Win32.UI

Public Class TwoCharacterDLLItem
    Implements IDoublyLinkedItem(Of String)

    ''' <summary>
    ''' This won't be in use, as this is an operation vs. a list item. --2/27/2024
    ''' </summary>
    ''' <returns></returns>
    Public Property Selected As Boolean Implements IDoublyLinkedItem.Selected
    Public Property _Control As Control ''Added 5/3/2024 td

    Private mod_prior As TwoCharacterDLLItem
    Private mod_next As TwoCharacterDLLItem
    Private mod_twoChars As String

    Public Sub New(par_twoChars As String) ''// , par_prior As TwoCharacterDLLItem)

        mod_prior = Nothing ''par_prior
        ''mod_next = par_next
        mod_twoChars = par_twoChars

    End Sub


    Public Sub New(par_twoChars As String, par_prior As TwoCharacterDLLItem)

        mod_prior = par_prior
        ''mod_next = par_next
        mod_twoChars = par_twoChars

    End Sub


    Public Sub New(par_twoChars As String, par_prior As TwoCharacterDLLItem, par_next As TwoCharacterDLLItem)

        mod_prior = par_prior
        mod_next = par_next
        mod_twoChars = par_twoChars

    End Sub ''End of ""Public Sub New(...)"


    Public Sub DLL_SetItemNext(param As IDoublyLinkedItem) _
           Implements IDoublyLinkedItem.DLL_SetItemNext

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        mod_next = param

    End Sub ''End of ""Public Sub DLL_SetItemNext(...) ...""


    Public Sub DLL_SetItemPrior(param As IDoublyLinkedItem) _
           Implements IDoublyLinkedItem.DLL_SetItemPrior

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        mod_prior = param

    End Sub ''End of ""Public Sub DLL_SetItemPrior(...)""



    Public Sub DLL_SetItemNext_OfT(param As IDoublyLinkedItem(Of String)) _
           Implements IDoublyLinkedItem(Of String).DLL_SetItemNext_OfT

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        mod_next = param

    End Sub ''End of ""Public Sub DLL_SetItemNext_OfT(...) ...""


    Public Sub DLL_SetItemPrior_OfT(param As IDoublyLinkedItem(Of String)) _
           Implements IDoublyLinkedItem(Of String).DLL_SetItemPrior_OfT

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        mod_prior = param

    End Sub ''End of ""Public Sub DLL_SetItemPrior_OfT(...)""


    Public Sub DLL_ClearReferencePrior(par_typeOp As Char) Implements IDoublyLinkedItem.DLL_ClearReferencePrior
        ''Throw New NotImplementedException()
        mod_prior = Nothing

    End Sub ''End of ""Public Sub DLL_ClearReferencePrior(...)""


    Public Sub DLL_ClearReferenceNext(par_typeOp As Char) Implements IDoublyLinkedItem.DLL_ClearReferenceNext
        ''Throw New NotImplementedException()
        mod_next = Nothing

    End Sub ''End of ""Public Sub DLL_ClearReferenceNext(...)""


    Public Function DLL_NotAnyNext() As Boolean Implements IDoublyLinkedItem.DLL_NotAnyNext
        ''Throw New NotImplementedException()
        Return (mod_next Is Nothing)

    End Function ''End of ""Public Function DLL_NotAnyNext()""


    Public Function DLL_NotAnyPrior() As Boolean Implements IDoublyLinkedItem.DLL_NotAnyPrior
        ''Throw New NotImplementedException()
        Return (mod_prior Is Nothing)

    End Function ''End of ""Public Function DLL_NotAnyPrior()""


    Public Function DLL_HasNext() As Boolean Implements IDoublyLinkedItem.DLL_HasNext
        ''Throw New NotImplementedException()
        Return (mod_next IsNot Nothing)

    End Function ''End of ""Public Function DLL_HasNext()""


    Public Function DLL_HasPrior() As Boolean Implements IDoublyLinkedItem.DLL_HasPrior
        ''Throw New NotImplementedException()
        Return (mod_prior IsNot Nothing)

    End Function ''End of ""Public Function DLL_HasPrior()""


    Public Function DLL_GetItemNext_OfT() As IDoublyLinkedItem(Of String) _
           Implements IDoublyLinkedItem(Of String).DLL_GetItemNext_OfT
        ''Throw New NotImplementedException()

        If (mod_next Is Me) Then System.Diagnostics.Debugger.Break()

        Return mod_next

    End Function ''End of ""Public Function DLL_GetItemNext_OfT()""


    ''Public Function DLL_GetItemNext() As IDoublyLinkedItem _
    ''       Implements IDoublyLinkedItem.DLL_GetItemNext
    ''    ''Throw New NotImplementedException()

    ''    If (mod_next Is Me) Then System.Diagnostics.Debugger.Break()

    ''    Return mod_next

    ''End Function ''End of ""Public Function DLL_GetItemNext()""


    Public Function DLL_GetItemNext() As IDoublyLinkedItem _
           Implements IDoublyLinkedItem.DLL_GetItemNext
        ''Throw New NotImplementedException()

        If (mod_next Is Me) Then System.Diagnostics.Debugger.Break()

        Return mod_next

    End Function ''End of ""Public Function DLL_GetItemNext()""


    Public Function DLL_GetItemNext_OfT(param_iterationsOfNext As Integer) As IDoublyLinkedItem(Of String) _
           Implements IDoublyLinkedItem(Of String).DLL_GetItemNext_OfT
        ''Throw New NotImplementedException()

        Dim tempNext As TwoCharacterDLLItem = mod_next
        If (param_iterationsOfNext > 1) Then
            For index = 2 To param_iterationsOfNext
                If (tempNext Is Nothing) Then Debugger.Break() ''12/31/2023
                tempNext = tempNext.mod_next
            Next index
        End If ''End of ""If (param_iterationsOfNext > 1) Then""
        If (param_iterationsOfNext = 0) Then Return Me
        If (param_iterationsOfNext = 1) Then Return mod_next
        Return tempNext

    End Function ''Endof ""Public Function DLL_GetItemNext_OfT""


    Public Function DLL_GetItemNext(param_iterationsOfNext As Integer) As IDoublyLinkedItem _
           Implements IDoublyLinkedItem.DLL_GetItemNext
        ''Throw New NotImplementedException()

        Dim tempNext As TwoCharacterDLLItem = mod_next
        If (param_iterationsOfNext > 1) Then
            For index = 2 To param_iterationsOfNext
                If (tempNext Is Nothing) Then Debugger.Break() ''12/31/2023
                tempNext = tempNext.mod_next
            Next index
        End If ''End of ""If (param_iterationsOfNext > 1) Then""
        If (param_iterationsOfNext = 0) Then Return Me
        If (param_iterationsOfNext = 1) Then Return mod_next
        Return tempNext

    End Function ''Endof ""Public Function DLL_GetItemNext""


    ''' <summary>
    ''' Get item following a range (if the implicit parameter is the first item in a range). Sometimes we need the Item which follows the Range, to prepare for a possible Undo.
    ''' </summary>
    ''' <param name="param_rangeSize">This is the item-count of the range, or size of the range.</param>
    ''' <returns>The first item which follows the range.</returns>
    Public Function DLL_GetNextItemFollowingRange(param_rangeSize As Integer,
                                                  param_mayBeNull As Boolean) As IDoublyLinkedItem _
        Implements IDoublyLinkedItem.DLL_GetNextItemFollowingRange

        ''Added 12/30/2023 
        ''---DIFFICULT AND CONFUSING---
        ''  By CS-related rules of iteration, by moving ahead
        ''  a number of jumps equal to the item-count of the range,
        ''  we get the first post-range item.
        ''                  ---12/30/2023 tdownes
        ''12/2023 Return DLL_GetItemNext(param_rangeSize)
        Dim result As IDoublyLinkedItem
        result = DLL_GetItemNext(param_rangeSize)

        ''Check for Nulls!
        If ((Not param_mayBeNull) AndAlso result Is Nothing) Then
            Debugger.Break()
        End If

        Return result

    End Function ''DLL_GetNextItemFollowingRange


    Public Function DLL_GetItemPrior() As IDoublyLinkedItem _
           Implements IDoublyLinkedItem.DLL_GetItemPrior

        ''Throw New NotImplementedException()

        If (mod_prior Is Me) Then System.Diagnostics.Debugger.Break()
        Return mod_prior

    End Function ''End of ""Public Function DLL_GetItemPrior()""


    Public Function DLL_GetItemPrior(param_iterationsOfPrior As Integer) As IDoublyLinkedItem _
           Implements IDoublyLinkedItem.DLL_GetItemPrior

        ''Throw New NotImplementedException()

        If (mod_prior Is Me) Then System.Diagnostics.Debugger.Break()
        Return mod_prior

    End Function ''End of ""Public Function DLL_GetItemPrior()""


    Public Function DLL_GetItemPrior_OfT() As IDoublyLinkedItem(Of String) _
           Implements IDoublyLinkedItem(Of String).DLL_GetItemPrior_OfT

        ''Throw New NotImplementedException()

        If (mod_prior Is Me) Then System.Diagnostics.Debugger.Break()
        Return mod_prior

    End Function ''End of ""Public Function DLL_GetItemPrior_OfT()""


    Public Function DLL_GetItemPrior_OfT(param_iterationsOfPrior As Integer) As IDoublyLinkedItem(Of String) _
          Implements IDoublyLinkedItem(Of String).DLL_GetItemPrior_OfT

        ''Throw New NotImplementedException()
        If (mod_prior Is Me) Then System.Diagnostics.Debugger.Break()

        Dim tempPrior As TwoCharacterDLLItem = mod_prior

        If (param_iterationsOfPrior > 1) Then
            For index = 2 To param_iterationsOfPrior
                tempPrior = tempPrior.mod_prior
            Next index
        End If
        If (param_iterationsOfPrior = 0) Then Return Me
        Return tempPrior

        Return mod_prior

    End Function ''End of ""Public Function DLL_GetItemPrior_OfT()""


    Public Function DLL_UnboxControl() As Control Implements IDoublyLinkedItem.DLL_UnboxControl

        Throw New NotImplementedException()

    End Function ''End of ""Public Function DLL_UnboxControl()""


    Public Function DLL_UnboxControl_OfT() As String _
        Implements IDoublyLinkedItem(Of String).DLL_UnboxControl_OfT

        Throw New NotImplementedException()

    End Function ''End of ""Public Function DLL_UnboxControl_OfT()""


    Public Function DLL_IsEitherEndpoint() As Boolean Implements IDoublyLinkedItem.DLL_IsEitherEndpoint

        ''Throw New NotImplementedException()
        Return ((mod_next Is Nothing) Or (mod_prior Is Nothing))

    End Function


    Public Overrides Function ToString() As String

        ''Added 12/26/2023
        Return mod_twoChars

    End Function

    Public Function DLL_GetValue() As String Implements IDoublyLinkedItem.DLL_GetValue

        ''Throw New NotImplementedException()
        Return mod_twoChars

    End Function


    Public Function DLL_CountItemsAllInList() As Integer Implements IDoublyLinkedItem.DLL_CountItemsAllInList

        ''---Throw New NotImplementedException()
        Debugger.Break()
        Return -1

    End Function


    Public Function DLL_CountItemsPrior() As Integer Implements IDoublyLinkedItem.DLL_CountItemsPrior

        ''Throw New NotImplementedException()
        Dim result_count As Integer = 0
        Dim temp As IDoublyLinkedItem = Me.DLL_GetItemPrior
        While temp IsNot Nothing
            result_count += 1
            temp = temp.DLL_GetItemPrior()
        End While ''End of ""While temp IsNot Nothing""
        Return result_count

    End Function ''ENd of ""Public Function DLL_CountItemsPrior()""


    Public Function DLL_GetNextItemFollowingRange_OfT(param_rangeSize As Integer, param_mayBeNull As Boolean) As IDoublyLinkedItem(Of String) _
           Implements IDoublyLinkedItem(Of String).DLL_GetNextItemFollowingRange_OfT
        ''
        ''Added 7/11/2024 
        ''
        Return DLL_GetItemNext_OfT(param_rangeSize) '', param_mayBeNull)

    End Function ''Endof ""Public Function DLL_GetNextItemFollowingRange_OfT""


End Class
