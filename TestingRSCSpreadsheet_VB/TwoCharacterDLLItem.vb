
Imports System.CodeDom
Imports System.Runtime.Intrinsics
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

    Private mod_prior As TwoCharacterDLLItem
    Private mod_next As TwoCharacterDLLItem
    ''July2024 Private mod_twoChars As String
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


    Public Sub DLL_SetItemPrior(param As IDoublyLinkedItem) _
           Implements IDoublyLinkedItem.DLL_SetItemPrior

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        mod_prior = param

    End Sub ''End of ""Public Sub DLL_SetItemPrior(...)""



    Public Sub DLL_SetItemNext_OfT(param As TwoCharacterDLLItem) _
           Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_SetItemNext_OfT

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        mod_next = param

    End Sub ''End of ""Public Sub DLL_SetItemNext_OfT(...) ...""

    Public Sub DLL_SetItemPrior_OfT(param As TwoCharacterDLLItem) _
           Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_SetItemPrior_OfT

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        ''---mod_next = param
        mod_prior = param

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


    Public Sub DLL_SetItemNext_OfT(param As TwoCharacterDLLItem, pbAllowNulls As Boolean) _
           Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_SetItemNext_OfT

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()

        ''11/4/2024 mod_next = param
        If (param Is Nothing And pbAllowNulls) Then
            mod_next = Nothing
        Else
            mod_next = param
        End If

    End Sub ''End of ""Public Sub DLL_SetItemNext_OfT(...) ...""


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


    Public Function DLL_UnboxControl() As Control Implements IDoublyLinkedItem.DLL_UnboxControl

        Throw New NotImplementedException()

    End Function ''End of ""Public Function DLL_UnboxControl()""


    Public Function DLL_UnboxControl_OfT() As TwoCharacterDLLItem _
        Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_UnboxControl_OfT

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
        Return (mod_char1 + mod_char2)

    End Function ''Public Overrides Function ToString() As String


    Public Function DLL_GetValue() As String Implements IDoublyLinkedItem.DLL_GetValue

        ''Throw New NotImplementedException()
        ''July2024 Return mod_twoChars
        Return (mod_char1 + mod_char2)

    End Function


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


    Public Function DLL_GetNextItemFollowingRange_OfT(param_rangeSize As Integer, param_mayBeNull As Boolean) As TwoCharacterDLLItem _
           Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetNextItemFollowingRange_OfT
        ''
        ''Added 7/11/2024 
        ''
        Return DLL_GetItemNext_OfT(param_rangeSize) '', param_mayBeNull)

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
        While (Not bDoneLooping)

            result_anySelected = (result_anySelected Or temp.Selected)
            temp = temp.DLL_GetItemNext()
            bDoneLooping = (temp Is Nothing Or result_anySelected)

        End While ''End of ""While (Not bDoneLooping)""

        Return result_anySelected

    End Function ''ENd of ""Public Function SelectedAnyItemToFollow()""


    Public Function DLL_GetItemIndex() As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLItem).DLL_GetItemIndex
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

        End While ''End of ""While (Not bDoneLooping)""

        Return result_index

    End Function ''end of Public Function GetItemIndex() As Integer



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





End Class






