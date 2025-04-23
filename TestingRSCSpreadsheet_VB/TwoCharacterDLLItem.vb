
Imports System.CodeDom
Imports System.Runtime.Intrinsics
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ciBadgeInterfaces
Imports Windows.Win32.UI

Public Class TwoCharacterDLLItem
    Implements IDoublyLinkedItem(Of TwoCharacterDLLItem) ''---(Of String)

    ''' <summary>
    ''' This won't be in use, as this is an operation vs. a list item. --2/27/2024
    ''' </summary>
    ''' <returns></returns>
    Public Property Selected As Boolean Implements IDoublyLinkedItem.Selected

    ''' <summary>
    ''' This won't be in use, as this is an operation vs. a list item. --2/27/2024
    ''' </summary>
    ''' <returns></returns>
    Public Property HighlightInBlue As Boolean Implements IDoublyLinkedItem.HighlightInBlue
    Public Property HighlightInGreen As Boolean Implements IDoublyLinkedItem.HighlightInGreen
    Public Property HighlightInRed As Boolean Implements IDoublyLinkedItem.HighlightInRed
    Public Property HighlightInCyan As Boolean Implements IDoublyLinkedItem.HighlightInCyan

    Public Property _Control As Control ''Added 5/3/2024 td

    Private Const ENFORCE_BIDIRECTIONAL As Boolean = True ''Added 12/08/2024 

    Friend mod_prior As TwoCharacterDLLItem ''Using 'Friend' will allow sub-classess to access it.  12/12/2024 Private mod_prior
    Friend mod_next As TwoCharacterDLLItem ''Using 'Friend' will allow sub-classess to access it.  ''12/12/2024 Private mod_next 
    Friend mod_nextIsNull As Boolean = False ''Added 4/17/2025

    ''DIFFICULT AND CONFUSING -- 12/12/2024 TD
    Friend mod_next_priorSortOrder As TwoCharacterDLLItem ''Added 12/12/2024 TD

    ''July2024 Private mod_twoChars As  
    Private mod_char1 As Char ''String
    Private mod_char2 As Char ''String

    Public Sub New(par_twoChars As String) ''// , par_prior As TwoCharacterDLLItem)

        mod_prior = Nothing ''par_prior
        ''mod_next = par_next
        ''July2024 mod_twoChars = par_twoChars
        mod_char1 = par_twoChars(0) ''This is VB not C#.
        mod_char2 = par_twoChars(1) ''This is VB not C#.

    End Sub


    Public Sub New(par_twoChars As String, par_prior As TwoCharacterDLLItem)

        mod_prior = par_prior
        ''mod_next = par_next
        ''---mod_twoChars = par_twoChars
        mod_char1 = par_twoChars(0) ''This is VB not C#.
        mod_char2 = par_twoChars(1) ''This is VB not C#.

    End Sub


    Public Sub New(par_twoChars As String, par_prior As TwoCharacterDLLItem, par_next As TwoCharacterDLLItem)

        mod_prior = par_prior
        mod_next = par_next
        ''--mod_twoChars = par_twoChars
        mod_char1 = par_twoChars(0) ''This is VB not C#.
        mod_char2 = par_twoChars(1) ''This is VB not C#.

    End Sub ''End of ""Public Sub New(...)"


    Public Sub DLL_SetItemNext(param As IDoublyLinkedItem) _
           Implements IDoublyLinkedItem.DLL_SetItemNext

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        mod_next = param

    End Sub ''End of ""Public Sub DLL_SetItemNext(...) ...""


    Public Sub DLL_SetItemNext(param As IDoublyLinkedItem, pboolAllowNulls As Boolean, pboolDoublyLink As Boolean) Implements IDoublyLinkedItem.DLL_SetItemNext
        ''
        ''Added 12/22/2024 
        ''
        If (Not pboolAllowNulls) Then
            If (param Is Nothing) Then
                Throw New Exception("Primary parameter cannot be nothing.")
            End If
        End If ''End of ""If (Not pboolAllowNulls) Then""

        ''Added 12/22/2024 td
        mod_next = param

        ''Added 12/22/2024 
        If (pboolDoublyLink) Then param.DLL_SetItemPrior(Me)

    End Sub ''End of ""Public Sub DLL_SetItemNext(param As IDoublyLinkedItem, ...)





    Public Sub DLL_SetItemPrior(param As IDoublyLinkedItem) _
           Implements IDoublyLinkedItem.DLL_SetItemPrior

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        mod_prior = param

    End Sub ''End of ""Public Sub DLL_SetItemPrior(...)""



    Public Overloads Sub DLL_SetItemNext_OfT(param As TwoCharacterDLLItem) _
           Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_SetItemNext_OfT

        Dim bNextIsSameAsPrior As Boolean ''Added 2/25/2025 

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        If (param Is Me) Then Throw New ArgumentException("Can't link the item to itself.")

        If (Testing.TestingByDefault) Then
            If (Me.DLL_HasPrior()) Then ''2/25/2025 thomas 
                ''Added 2/25/2025 
                bNextIsSameAsPrior = Me.DLL_GetItemPrior_OfT() Is param ''Added 2/25/2025 
                If (bNextIsSameAsPrior) Then
                    System.Diagnostics.Debugger.Break()
                End If ''End of ""If (bNextIsSameAsPrior) Then""
            End If ''End of ""If (Me.DLL_HasPrior()) Then"
        End If ''End of ""If (Testing.TestingByDefault) Then""

        mod_next = param

    End Sub ''End of ""Public Sub DLL_SetItemNext_OfT(...) ...""


    Public Sub DLL_SetItemPrior_OfT(paramItem As TwoCharacterDLLItem) _
           Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_SetItemPrior_OfT

        ''Throw New NotImplementedException()
        If (paramItem Is Me) Then System.Diagnostics.Debugger.Break()
        ''---mod_next = param
        mod_prior = paramItem

        ''
        '' Adding bidirectionality.  ---12/08/2024 td
        ''
        ''If (ENFORCE_BIDIRECTIONAL) Then
        ''    ''
        ''    ''Set the "mod_prior" item for this parameter item,
        ''    ''  to be the present class (i.e. the procedure's implicit parameter).
        ''    ''
        ''    paramItem.mod_next = Me

        ''End If ''end of "" If (ENFORCE_BIDIRECTIONAL) Then""

    End Sub ''End of ""Public Sub DLL_SetItemNext_OfT(...) ...""


    Public Sub DLL_SetItemPrior_OfT(param As TwoCharacterDLLItem, pbAllowNulls As Boolean) _
           Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_SetItemPrior_OfT

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()

        ''11/4/2024 mod_next = param
        If (param Is Nothing And pbAllowNulls) Then
            mod_prior = Nothing
        Else
            mod_prior = param
        End If

    End Sub ''End of ""Public Sub DLL_SetItemPrior_OfT(...)""


    Public Overloads Sub DLL_SetItemNext_OfT(param As TwoCharacterDLLItem, pbAllowNulls As Boolean) _
           Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_SetItemNext_OfT

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()

        ''11/4/2024 mod_next = param
        If (param Is Nothing And pbAllowNulls) Then
            mod_next = Nothing
        ElseIf (param Is Nothing And (Not pbAllowNulls)) Then ''Added 12/22/2024 
            ''Added 12/22/2024 td
            Throw New Exception("A null value for Next is not allowed.")

        Else
            mod_next = param
        End If

        ''
        '' Adding bidirectionality.  ---12/08/2024 td
        ''
        If (ENFORCE_BIDIRECTIONAL) Then

            ''Set the "mod_prior" item for this parameter item,
            ''  to be the present class (i.e. the procedure's implicit parameter).
            ''
            If (param IsNot Nothing) Then
                param.mod_prior = Me
            End If ''ENd of ""If (param IsNot Nothing) Then""

        End If ''end of "" If (ENFORCE_BIDIRECTIONAL) Then""

        ''Added 2/25/2025 thomas d.
        If (Testing.TestingByDefault) Then
            Dim bNextIsSameAsPrior As Boolean ''Added 2/25/2025 thomas
            If (Me.DLL_HasPrior()) Then ''2/25/2025 thomas 
                ''Added 2/25/2025 
                bNextIsSameAsPrior = Me.DLL_GetItemPrior_OfT() Is param ''Added 2/25/2025 
                If (bNextIsSameAsPrior) Then
                    System.Diagnostics.Debugger.Break()
                End If ''End of ""If (bNextIsSameAsPrior) Then""
            End If ''End of ""If (Me.DLL_HasPrior()) Then"
        End If ''End of ""If (Testing.TestingByDefault) Then""

    End Sub ''End of ""Public Sub DLL_SetItemNext_OfT(...) ...""


    Public Sub DLL_ClearReferencePrior(par_typeOp As Char) Implements IDoublyLinkedItem.DLL_ClearReferencePrior
        ''Throw New NotImplementedException()
        mod_prior = Nothing
        mod_nextIsNull = True ''Added 4/17/2025

    End Sub ''End of ""Public Sub DLL_ClearReferencePrior(...)""


    Public Sub DLL_ClearReferenceNext(par_typeOp As Char) Implements IDoublyLinkedItem.DLL_ClearReferenceNext
        ''Throw New NotImplementedException()
        mod_next = Nothing
        mod_nextIsNull = True ''Added 4/17/2025

    End Sub ''End of ""Public Sub DLL_ClearReferenceNext(...)""


    ''' <summary>
    ''' Indicate that this item will serve as the final item in a list.
    ''' </summary>
    Public Sub DLL_MarkAsEndOfList(Optional pbUndoPrior As Boolean = True,
                                   Optional pbUndoThisMarker As Boolean = False) _
                                   Implements IDoublyLinkedItem.DLL_MarkAsEndOfList

        ''Added 4/17/2025  
        ''Apr22 2025 mod_next = Nothing

        ''Set this item as the final item in the list. 
        ''Apr22 2025 mod_nextIsNull = True ''Added 4/17/2025

        ''Added 4/2025
        If (pbUndoPrior AndAlso mod_prior IsNot Nothing) Then

            Const UNDO_PRIOR_OF_PRIOR As Boolean = False ''False, we don't want infinite recursion.
            Const UNDO_PRIOR As Boolean = True ''True, since parameter pbUndoPrior is True.
            mod_prior.DLL_MarkAsEndOfList(UNDO_PRIOR_OF_PRIOR, UNDO_PRIOR)

        End If ''End of ""If (pbUndoPrior AndAlso mod_prior IsNot Nothing) Then""

        ''Set the current one to False. 4/2025
        If (pbUndoThisMarker) Then
            ''Undo/Remove/Falsify the Null marker. 
            mod_nextIsNull = False
        Else
            ''Set this item as the final item in the list. 
            mod_next = Nothing
            mod_nextIsNull = True
        End If ''End of ""If (pbUndoThisMarker) Then... Else..."

    End Sub ''End of ""Public Sub DLL_MarkAsEndOfList()""


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


    Public Function DLL_GetItemNext_OfT() As TwoCharacterDLLItem _
           Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetItemNext_OfT
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


    Public Function DLL_GetItemNext_OfT(param_iterationsOfNext As Integer) As TwoCharacterDLLItem _
           Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetItemNext_OfT
        ''Throw New NotImplementedException()

        Dim tempNext As TwoCharacterDLLItem = mod_next
        If (param_iterationsOfNext > 1) Then
            For index = 2 To param_iterationsOfNext
                If (tempNext Is Nothing) Then Exit For ''12/9/2024 Debugger.Break() ''12/31/2023
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


    Public Function DLL_GetItemPrior_OfT() As TwoCharacterDLLItem _
           Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetItemPrior_OfT

        ''Throw New NotImplementedException()

        If (mod_prior Is Me) Then System.Diagnostics.Debugger.Break()
        Return mod_prior

    End Function ''End of ""Public Function DLL_GetItemPrior_OfT()""


    Public Function DLL_GetItemPrior_OfT(param_iterationsOfPrior As Integer) As TwoCharacterDLLItem _
          Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetItemPrior_OfT

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


    ''' <summary>
    ''' Returns the item at the specified index in the parent list. 
    ''' </summary>
    ''' <param name="par_index_b0">This is a 0-based index.</param>
    ''' <returns>Returns the item at the specified index.</returns>
    Public Function DLL_GetItemAtIndex_base0(par_index_b0 As Integer) As TwoCharacterDLLItem _
        Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetItemAtIndex_base0
        ''
        ''added 1/07/2024
        ''
        Dim objFirst As TwoCharacterDLLItem ''= DLL_GetItemFirst()
        Dim objResult As TwoCharacterDLLItem

        objFirst = DLL_GetItemFirst()
        ''----objResult = objFirst.DLL_GetItemNext_OfT(par_index_b0)
        Dim intIterationsOfNext As Integer = par_index_b0 ''Added 1/16/2025
        objResult = objFirst.DLL_GetItemNext_OfT(intIterationsOfNext)

        ''1/16/2025 Return objFirst
        Return objResult ''Fixed 1/16/2025

    End Function ''End of ""Public Function DLL_GetItemAtIndex_base0(par_index_b0 As Integer) As TwoCharacterDLLItem""


    ''' <summary>
    ''' Returns the item at the specified index in the parent list. 
    ''' </summary>
    ''' <param name="par_index_b1">This is a 1-based index.</param>
    ''' <returns>Returns the item at the specified index.</returns>
    Public Function DLL_GetItemAtIndex_base1(par_index_b1 As Integer) As TwoCharacterDLLItem Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetItemAtIndex_base1
        ''
        ''added 1/07/2024
        ''
        Dim objResult As TwoCharacterDLLItem
        objResult = DLL_GetItemAtIndex_base0(-1 + par_index_b1)
        Return objResult

    End Function ''End of ""Public Function DLL_GetItemAtIndex_base1(par_index_b1 As Integer) As TwoCharacterDLLItem""


    Public Function DLL_UnboxControl() As Control ''Jan24 2025 Implements IDoublyLinkedItem.DLL_UnboxControl

        Throw New NotImplementedException()

    End Function ''End of ""Public Function DLL_UnboxControl()""


    Public Function DLL_UnboxControl_OfT() As TwoCharacterDLLItem
        ''Jan24 2025        Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_UnboxControl_OfT

        ''//Throw New NotImplementedException()
        Return Me

    End Function ''End of ""Public Function DLL_UnboxControl_OfT()""


    Public Function DLL_IsEitherEndpoint() As Boolean Implements IDoublyLinkedItem.DLL_IsEitherEndpoint

        ''Throw New NotImplementedException()
        Return ((mod_next Is Nothing) Or (mod_prior Is Nothing))

    End Function


    Public Overrides Function ToString() As String

        ''Added 12/26/2023
        ''July2024 Return mod_twoChars
        ''Feb2025 td Return (mod_char1 + mod_char2)

        ''Added 2/15/2025 thomas
        If (Me.DLL_HasNext()) Then
            ''Return (mod_char1 + mod_char2 & " " & Me.DLL_GetItemNext_OfT().ToString(False)) ''(mod_char1 + mod_char2)
            Return (mod_char1 + mod_char2 & " (next is " & Me.DLL_GetItemNext_OfT().ToString(False) & ")") ''(mod_char1 + mod_char2)
        Else
            Return (mod_char1 + mod_char2 & " - No next item.")
        End If

    End Function ''Public Overrides Function ToString() As String


    Public Overloads Function ToString(par_doAppendNext As Boolean) As String Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).ToString
        ''---Feb2025---Public Overrides Function ToString() As String

        ''Added 12/26/2023
        ''July2024 Return mod_twoChars
        ''Feb2025 Return (mod_char1 + mod_char2)

        ''Feb2025 td
        If (par_doAppendNext) Then
            Return mod_char1 + mod_char2 & " followed by " & Me.DLL_GetItemNext_OfT().ToString(False)
        Else
            Return (mod_char1 + mod_char2)
        End If

    End Function ''Public Overrides Function ToString(par_doAppendNext As Boolean) As String


    Public Function DLL_GetValue() As String Implements IDoublyLinkedItem.DLL_GetValue

        ''Throw New NotImplementedException()
        ''July2024 Return mod_twoChars
        Return (mod_char1 + mod_char2)

    End Function ''end of ""Public Function DLL_GetValue() As String""


    Public Function DLL_CountItemsAllInList() As Integer Implements IDoublyLinkedItem.DLL_CountItemsAllInList

        ''---Throw New NotImplementedException()
        ''Debugger.Break()

        ''Return -1

        ''Coded 11/29/2024 thoma.s downe.s
        Dim intItemsPrior As Integer = DLL_CountItemsPrior()
        Dim intItemsAfter As Integer = DLL_CountItemsAfter()
        Return (1 + intItemsPrior + intItemsAfter)

    End Function ''Public Function DLL_CountItemsAllInList() 


    Public Function DLL_CountItemsPrior() As Integer Implements IDoublyLinkedItem.DLL_CountItemsPrior

        ''Throw New NotImplementedException()
        Dim result_count As Integer = 0
        Dim temp As IDoublyLinkedItem = Me.DLL_GetItemPrior()
        While temp IsNot Nothing
            result_count += 1
            temp = temp.DLL_GetItemPrior()
        End While ''End of ""While temp IsNot Nothing""
        Return result_count

    End Function ''ENd of ""Public Function DLL_CountItemsPrior()""


    Public Function DLL_CountItemsAfter() As Integer Implements IDoublyLinkedItem.DLL_CountItemsAfter

        ''Throw New NotImplementedException()
        Dim result_count As Integer = 0
        Dim temp As IDoublyLinkedItem = Me.DLL_GetItemNext()
        While temp IsNot Nothing
            result_count += 1
            temp = temp.DLL_GetItemNext()
        End While ''End of ""While temp IsNot Nothing""
        Return result_count

    End Function ''ENd of ""Public Function DLL_CountItemsAfter()""


    Public Function DLL_GetItemFirst() As TwoCharacterDLLItem Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetItemFirst
        ''
        ''Added 12/29/2024
        ''
        Dim temp As IDoublyLinkedItem = Me ''.DLL_GetItemNext()
        Dim temp_result As IDoublyLinkedItem = Me ''.DLL_GetItemNext()

        While temp.DLL_HasPrior()
            temp = temp.DLL_GetItemPrior()
        End While ''End of ""While temp.DLL_HasNext()""
        temp_result = temp
        Return temp_result

    End Function ''ENd of ""Public Function DLL_GetItemFirst() As TwoCharacterDLLItem""


    Public Function DLL_GetItemLast() As TwoCharacterDLLItem Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetItemLast
        ''
        ''Added 12/12/2024
        ''
        Dim temp As IDoublyLinkedItem = Me ''.DLL_GetItemNext()
        Dim temp_result As IDoublyLinkedItem = Me ''.DLL_GetItemNext()

        While temp.DLL_HasNext()
            temp = temp.DLL_GetItemNext()
        End While ''End of ""While temp.DLL_HasNext()""
        temp_result = temp
        Return temp_result

    End Function ''ENd of ""Public Function DLL_GetItemLast() As TwoCharacterDLLItem""


    Public Function DLL_GetNextItemFollowingRange_OfT(param_rangeSize As Integer, param_mayBeNull As Boolean) As TwoCharacterDLLItem _
           Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetNextItemFollowingRange_OfT
        ''
        ''Added 7/11/2024 
        ''
        ''---Return DLL_GetItemNext_OfT(param_rangeSize) '', param_mayBeNull)
        Dim result As TwoCharacterDLLItem
        result = DLL_GetItemNext_OfT(param_rangeSize)

        ''Added 1/24/2025 thomas d.
        If (result Is Nothing And Not param_mayBeNull) Then
            System.Diagnostics.Debugger.Break()
        End If ''End of ""If (result Is Nothing And Not param_mayBeNull) Then""

        Return result ''Added 1/24/2025 

    End Function ''End of ""Public Function DLL_GetNextItemFollowingRange_OfT""


    Public Function DLL_GetDistanceTo(paramItem As TwoCharacterDLLItem) As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetDistanceTo
        ''
        ''Added 11/18/2024  
        ''
        Dim bLocated As Boolean
        Dim result As Integer

        result = DLL_GetDistanceTo(paramItem, bLocated)
        If (Not bLocated) Then System.Diagnostics.Debugger.Break()
        Return result

    End Function ''ENd of ""Public Function DLL_GetDistanceTo(paramItem As TwoCharacterDLLItem)""


    Public Function DLL_GetDistanceTo(paramItem As TwoCharacterDLLItem, ByRef pbLocatedItem As Boolean) As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetDistanceTo
        ''
        '' Added "ByRef pbLocated As Boolean" on 11/18/2024
        ''
        ''---Throw New NotImplementedException()
        Dim tempItem As TwoCharacterDLLItem = Me
        Dim int_resultDistance As Integer = 0
        Dim b_resultFoundItem As Boolean = False
        Const LOOP_LIMIT As Integer = 2000
        pbLocatedItem = False ''Default value. 

        ''
        '' Part 1 of 2.  Go forward (NOT backward). 
        '' 
        Do
            If (tempItem Is paramItem) Then

                ''Return resultDistance
                b_resultFoundItem = True
                pbLocatedItem = True
                Exit Do

            ElseIf (tempItem.DLL_HasNext()) Then
                tempItem = tempItem.DLL_GetItemNext_OfT()
                int_resultDistance += 1
            Else
                ''
                ''The function DLL_HasNext() has returned a False, 
                ''   indicating the end of the list is here. 
                ''
                ''Exit Do
                ''Return -1
                ''Throw New RSCEndpointException("We have searched to the end of the DLL list.")
                If (int_resultDistance > LOOP_LIMIT) Then
                    System.Diagnostics.Debugger.Break()
                End If
                Exit Do

            End If ''ENd of ""If (tempItem Is paramItem) Then""

        Loop ''Look for "Exit Do" to break out of infinite loop. 

        ''
        '' Part 2 of 2.  Go backward (NOT forward). 
        '' 
        If (b_resultFoundItem) Then
            ''
            ''We don't have to do Part 2 of 2 - Going backward.
            ''
        Else
            ''
            ''Go backward. 
            ''
            int_resultDistance = 0 ''Restore default value 
            Do
                If (tempItem Is paramItem) Then
                    Return int_resultDistance
                ElseIf (tempItem.DLL_HasPrior()) Then
                    tempItem = tempItem.DLL_GetItemPrior_OfT()
                    int_resultDistance -= 1
                Else
                    ''
                    ''The function DLL_HasPrior() has returned a False, 
                    ''   indicating the very start of the list is here. 
                    ''
                    ''---Exit Do
                    ''---Return -1
                    ''---Throw New RSCEndpointException("We have searched to the end of the DLL list.")
                    Exit Do
                End If ''ENd of ""If (tempItem Is paramItem) Then... ElseIf... Else..."
            Loop ''Look for "Exit Do" to break out of infinite loop. 
        End If

        ''Added 11/18/2024 
        pbLocatedItem = b_resultFoundItem ''Added 11/18/2024 

        Return int_resultDistance

    End Function ''End of Public Function DLL_GetDistanceTo 


    Public Function SelectedAnyItemToFollow() As Boolean
        ''
        ''Added 11/12/2024  
        ''
        ''Throw New NotImplementedException()
        Dim result_anySelected As Boolean = False
        Dim bDoneLooping As Boolean = False

        Dim temp As IDoublyLinkedItem = Me.DLL_GetItemNext_OfT()

        ''Added 12/09/2024 
        bDoneLooping = (temp Is Nothing)

        While (Not bDoneLooping)

            result_anySelected = (result_anySelected Or temp?.Selected)
            temp = temp.DLL_GetItemNext()
            bDoneLooping = (temp Is Nothing Or result_anySelected)

        End While ''End of ""While (Not bDoneLooping)""

        Return result_anySelected

    End Function ''ENd of ""Public Function SelectedAnyItemToFollow()""


    ''' <summary>
    ''' This index is 1-based, not 0-based. 
    ''' </summary>
    ''' <returns>Returns a positive integer, starting with 1 (1-based).</returns>
    Public Function DLL_GetItemIndex_base1() As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetItemIndex_base1
        ''
        ''Added 11/12/2024  
        ''
        '' This index is 1-based, not 0-based. 
        ''
        Dim result_index As Integer = 0

        Dim temp As IDoublyLinkedItem = Me
        While (temp IsNot Nothing)

            result_index += 1
            temp = temp.DLL_GetItemPrior()

        End While ''End of ""While (temp IsNot Nothing)""

        Return result_index

    End Function ''end of Public Function GetItemIndex_base1() As Integer


    ''' <summary>
    ''' This index is 0-based, not 1-based. 
    ''' </summary>
    ''' <returns>Returns a non-negative integer, starting with 0 (0-based).</returns>
    Public Function DLL_GetItemIndex_base0() As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetItemIndex_base0
        ''
        ''Added 11/12/2024  
        ''
        '' This index is 1-based, not 0-based. 
        ''
        Dim result_index As Integer = 0
        result_index = (-1 + DLL_GetItemIndex_base1())
        Return result_index

    End Function ''end of Public Function GetItemIndex_base0() As Integer


    Public Sub DLL_InsertItemToNext(param As TwoCharacterDLLItem, pbDoubleLink As Boolean) _
          Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_InsertItemToNext
        ''
        '' This will take some weight off, from DLL_List(Of TControl). 
        ''
        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        If (param Is Nothing) Then System.Diagnostics.Debugger.Break()
        ''Test the level of awareness of the calling procedure. 
        If (Not pbDoubleLink) Then System.Diagnostics.Debugger.Break()

        If (mod_next IsNot Nothing) Then
            mod_next.DLL_SetItemPrior_OfT(param)
            param.DLL_SetItemNext_OfT(mod_next)
        End If ''End of ""If (mod_next IsNot Nothing) Then""

        ''
        ''Exiting procedure. 
        ''
        mod_next = param
        param.DLL_SetItemPrior_OfT(Me)

    End Sub ''End of ""Public Sub DLL_InsertItemToNext(...)""


    Public Sub DLL_InsertItemToPrior(param As TwoCharacterDLLItem,
                                     pbSetDoubleLink As Boolean) _
         Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_InsertItemToPrior
        ''
        '' This will take some weight off, from DLL_List(Of TControl). 
        ''
        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        If (param Is Nothing) Then System.Diagnostics.Debugger.Break()
        If (pbSetDoubleLink) Then
            ''
            ''Yes, the programmer knows what he or she is doing. ---10/17/2025
            ''
        Else
            ''This is a test of the calling procedure.  
            ''  The calling procedure has failed the test. 
            System.Diagnostics.Debugger.Break()
        End If ''End of "If (pbSetDoubleLink) Then... Else..."

        If (mod_prior IsNot Nothing) Then
            mod_prior.DLL_SetItemNext_OfT(param)
            param.DLL_SetItemPrior_OfT(mod_prior)
        End If ''End of ""If (mod_prior IsNot Nothing) Then""

        ''
        ''Exiting procedure. 
        ''
        mod_prior = param
        param.DLL_SetItemNext_OfT(Me)

    End Sub ''End of ""Public Sub DLL_InsertItemToPrior(...)""


    ''
    ''
    ''DIFFICULT AND CONFUSING -- PRIOR SORT ORDERS -- Added 12/12/2024
    ''
    ''
    ''Public Function DLL_GetItemNext_PriorSortOrder() As TwoCharacterDLLItem Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetItemNext_PriorSortOrder
    ''    ''DIFFICULT AND CONFUSING -- Added 12/12/2024 
    ''    Return mod_next_priorSortOrder
    ''End Function
    ''
    ''Public Sub DLL_SetItemNext_PriorSortOrder(param As TwoCharacterDLLItem) Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_SetItemNext_PriorSortOrder        ''Throw New NotImplementedException()
    ''    ''DIFFICULT AND CONFUSING -- Added 12/12/2024 
    ''    mod_next_priorSortOrder = param
    ''End Sub

    Public Sub DLL_SaveCurrentSortOrder_ToPrior(pbExecuteInCascade As Boolean) Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_SaveCurrentSortOrder_ToPrior

        ''Added 12/ 29/2024 
        Dim strThisItem As String = Me.DLL_GetValue() ''This may help in the debugging process.

        ''DIFFICULT AND CONFUSING -- Added 12/12/2024 
        mod_next_priorSortOrder = mod_next

        ''Added 12/12/2024  
        ''
        ''   Execute in cascade (recursively), if requested.
        ''   
        If (pbExecuteInCascade) Then mod_next?.DLL_SaveCurrentSortOrder_ToPrior(pbExecuteInCascade)

    End Sub ''End of ""Public Sub DLL_SaveCurrentSortOrder_ToPrior()""


    Public Sub DLL_RestorePriorSortOrder(par_countdownItems As Integer) Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_RestorePriorSortOrder

        ''Added 12/29/2024 
        Dim strThisItem As String = Me.DLL_GetValue() ''This may help in the debugging process.
        Dim preRestoration_next As TwoCharacterDLLItem = mod_next ''Added 12/29/2024 thomas d.
        Dim bNotDoneYet As Boolean ''Added 12/29/2024 thomas d.

        ''Added 12/29/2024 thomas d.
        preRestoration_next = mod_next ''Added 12/29/2024 thomas d.
        par_countdownItems -= 1 ''Added 12/29/2024 thomas d.
        If (mod_next_priorSortOrder Is Nothing) Then
            bNotDoneYet = (par_countdownItems > 0)
            If (bNotDoneYet) Then
                ''The programmer should check why this is happening.
                System.Diagnostics.Debugger.Break()
            End If ''End of ""If (bNotDoneYet) Then""
        End If ''End of ""If (mod_next_priorSortOrder Is Nothing) Then""

        ''DIFFICULT AND CONFUSING -- Added 12/12/2024 
        mod_next = mod_next_priorSortOrder

        ''DIFFICULT AND CONFUSING -- Added 12/29/2024
        ''  Make the connection bidirectional (doubly-linked).--12/29/2024 thom.down.
        ''See below. --12/29/2024  mod_next.mod_prior = Me ''Added 12/29/2024

        ''Added 12/12/2024
        ''   Execute in cascade. 
        ''====Modified 12/29/2024
        ''===mod_next?.DLL_RestorePriorSortOrder()

        Try
            If (mod_next IsNot Nothing) Then
                ''Added 12/29/2024 thomas d.
                ''DIFFICULT AND CONFUSING -- Added 12/29/2024
                ''  Make the connection bidirectional (doubly-linked).--12/29/2024 thom.down.
                mod_next.mod_prior = Me ''Added 12/29/2024
                preRestoration_next.DLL_RestorePriorSortOrder(par_countdownItems)

            Else
                ''Do nothing.
            End If ''End of ""If (preRestoration_next IsNot Nothing) Then ... Else""

        Catch par_ex As System.NullReferenceException
            ''Do nothing. 
            ''       ---12/29/2024 td
        End Try

    End Sub ''End of ""Public Sub DLL_SaveCurrentSortOrder_ToPrior()""


    Public Sub DLL_ClearPriorSortOrder(pbExecuteInCascade As Boolean) Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_ClearPriorSortOrder

        ''DIFFICULT AND CONFUSING -- Added 12/12/2024 
        mod_next_priorSortOrder = Nothing

        ''Added 12/12/2024
        ''
        ''   Execute in cascade (recursively), if requested.
        ''   
        If (pbExecuteInCascade) Then mod_next?.DLL_ClearPriorSortOrder(pbExecuteInCascade)

    End Sub ''End of ""Public Sub DLL_SaveCurrentSortOrder_ToPrior()""


    Public Overloads Sub DLL_SetItemNext_OfT(param As TwoCharacterDLLItem, paramAllowNulls As Boolean, paramDoublyLinkIt As Boolean) _
        Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_SetItemNext_OfT

        ''Added 12/22/2024 

        If (param Is Nothing And paramAllowNulls) Then
            ''Added 11/4/2024 
            DLL_ClearReferenceNext("S"c)

        ElseIf (param Is Nothing And (Not paramAllowNulls)) Then ''Added 12/22/2024 

            ''Added 12/22/2024 td
            Throw New Exception("A null value for Next is not allowed.")

        Else
            DLL_SetItemNext_OfT(param)

        End If

        ''
        ''Added 12/22/2024 
        ''
        If (paramDoublyLinkIt) Then

            ''Added 12/22/2024 
            param.DLL_SetItemPrior_OfT(Me)

        End If ''End of ""If (paramDoublyLinkIt) Then""


    End Sub ''ENd of '"Public Overloads Sub DLL_SetItemNext_OfT""


    Public Function GetConvertToGeneric_OfT(Of T_BaseOrParallel As IDoublyLinkedItem(Of T_BaseOrParallel))(firstItem As T_BaseOrParallel) _
              As T_BaseOrParallel Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).GetConvertToGeneric_OfT
        ''
        ''Added 1/07/2025 
        ''
        Dim intIndex_b0 As Integer
        intIndex_b0 = DLL_GetItemIndex_base0()
        firstItem = firstItem.DLL_GetItemFirst()
        Return firstItem.DLL_GetItemAtIndex_base0(intIndex_b0)

    End Function ''Public Function GetConvertToGeneric_OfT


    Public Function GetConvertToArray() As TwoCharacterDLLItem() Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).GetConvertToArray

        ''Throw New NotImplementedException()

        Dim intCount As Integer = DLL_CountItemsAllInList()
        Dim arrResult(intCount - 1) As TwoCharacterDLLItem
        Dim temp As TwoCharacterDLLItem ''= Me.DLL_GetItemFirst()

        temp = Me.DLL_GetItemFirst()
        For index = 0 To intCount - 1
            arrResult(index) = temp
            temp = temp.DLL_GetItemNext_OfT()
        Next index
        Return arrResult

    End Function ''End of Public Function GetConvertToArray() As TwoCharacterDLLItem()


    Public Sub DLL_DrawColors() Implements IDoublyLinkedItem.DLL_DrawColors
        ''
        ''Added 4/21/2024
        '' 
        ''//If (Me.Selected) Then TextBox1.BackColor = Color.Yellow
        ''//If (Not Me.Selected) Then TextBox1.BackColor = Color.White ''Yellow
        ''---If (Me.Selected) Then Me.BackColor = Color.Yellow
        ''---If (Not Me.Selected) Then Me.BackColor = Color.White ''Yellow

    End Sub


End Class






