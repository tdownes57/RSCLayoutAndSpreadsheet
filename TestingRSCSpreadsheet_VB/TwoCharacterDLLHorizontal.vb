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
    End Sub

    Public Overloads Sub DLL_SetItemPrior_OfT(param As TwoCharacterDLLHorizontal) Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_SetItemPrior_OfT
        ''Throw New NotImplementedException()
        MyBase.DLL_SetItemPrior_OfT(param)
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
        Else
            MyBase.DLL_SetItemNext_OfT(param)
        End If

    End Sub

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


    Public Function DLL_GetDistanceTo(paramItem As TwoCharacterDLLHorizontal) As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_GetDistanceTo
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



    ''Public Function DLL_GetDistanceTo(paramItem As TwoCharacterDLLHorizontal) As Integer Implements IDoublyLinkedItem(Of TwoCharacterDLLHorizontal).DLL_GetDistanceTo
    ''    ''---Throw New NotImplementedException()
    ''    Dim tempItem As TwoCharacterDLLHorizontal = Me
    ''    Dim int_resultDistance As Integer = 0
    ''    Dim b_resultFoundItem As Boolean = False
    ''    Const LOOP_LIMIT As Integer = 2000

    ''    ''
    ''    '' Part 1 of 2.  Go forward (NOT backward). 
    ''    '' 
    ''    Do
    ''        If (tempItem Is paramItem) Then

    ''            ''Return resultDistance
    ''            b_resultFoundItem = True
    ''            Exit Do

    ''        ElseIf (tempItem.DLL_HasNext()) Then
    ''            tempItem = tempItem.DLL_GetItemNext_OfT()
    ''            int_resultDistance += 1
    ''        Else
    ''            ''
    ''            ''The function DLL_HasNext() has returned a False, 
    ''            ''   indicating the end of the list is here. 
    ''            ''
    ''            ''Exit Do
    ''            ''Return -1
    ''            ''Throw New RSCEndpointException("We have searched to the end of the DLL list.")
    ''            If (int_resultDistance > LOOP_LIMIT) Then System.Diagnostics.Debugger.Break()
    ''            Exit Do
    ''        End If
    ''    Loop ''Look for "Exit Do" to break out of infinite loop. 

    ''    ''
    ''    '' Part 2 of 2.  Go backward (NOT forward). 
    ''    '' 
    ''    If (b_resultFoundItem) Then
    ''        ''
    ''        ''We don't have to do Part 2 of 2 - Going backward.
    ''        ''
    ''    Else
    ''        ''
    ''        ''Go backward. 
    ''        ''
    ''        int_resultDistance = 0 ''Restore default value 
    ''        Do
    ''            If (tempItem Is paramItem) Then
    ''                Return int_resultDistance
    ''            ElseIf (tempItem.DLL_HasPrior()) Then
    ''                tempItem = tempItem.DLL_GetItemPrior_OfT()
    ''                int_resultDistance -= 1
    ''            Else
    ''                ''
    ''                ''The function DLL_HasPrior() has returned a False, 
    ''                ''   indicating the very start of the list is here. 
    ''                ''
    ''                ''---Exit Do
    ''                ''---Return -1
    ''                ''---Throw New RSCEndpointException("We have searched to the end of the DLL list.")
    ''                Exit Do
    ''            End If ''ENd of ""If (tempItem Is paramItem) Then... ElseIf... Else..."
    ''        Loop ''Look for "Exit Do" to break out of infinite loop. 
    ''    End If

    ''    Return int_resultDistance

    ''End Function ''End of Public Function DLL_GetDistanceTo 



End Class
