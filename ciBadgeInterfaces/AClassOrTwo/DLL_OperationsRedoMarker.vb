
''-----------------------------------------------------------
''  Please see CIBadgeDesigner / Classes RSC / RSC_DLL_OperationsManager.
''
''    ---12/07/2023 thomas dow_nes 
''-----------------------------------------------------------
''' <summary>
''' Similar to a Tuple(Of DLL_Operation, DLL_Operation) but 
''' has comments and better naming of First and Second.
''' </summary>
Public Class DLL_OperationsRedoMarker
    ''
    ''---DIFFICULT AND CONFUSING---
    ''  This is a "placeholder" for a user who is hitting the 
    ''  undo & redo buttons.  This is NOT for recording 
    ''  new operations. 
    ''
    ''The names below correspond to a "Redo" chain 
    ''   from first to last.
    ''
    ''(We do NOT think of it as an "Undo" chain, because 
    ''   it's easier to derive an "Undo" operation from a 
    ''   "Redo" operation (and there's a function for that).
    ''   (Versus deriving a "Redo" operation from an "Undo" 
    ''   operation.)
    ''   It's easier if the default is "going forward in time". 
    ''
    ''---DIFFICULT AND CONFUSING---
    ''  This is a "placeholder" for a user who is hitting the 
    ''  undo & redo buttons.  This is NOT for recording 
    ''  new operations. 
    ''
    ''' <summary>
    ''' If the user hits "Undo", this operation will be 
    ''' inversed and the inverse will be performed. 
    ''' </summary>
    Private mod_opPrior_ForUndo As DLL_OperationV1

    ''' <summary>
    ''' If the user hits "Redo", this operation will be 
    ''' performed as it is.  (In contrast to "Undo", we
    ''' do NOT need to get the inverse of the operation.) 
    ''' </summary>
    Private mod_opNext_ForRedo As DLL_OperationV1

    Public Sub New(opPrior As DLL_OperationV1, opNext As DLL_OperationV1)
        ''
        ''----NO LONGER TRUE, AS OF 1/10/2024 & 1/15/2024
        ''----Just like a Tuple, a DLL_OperationMarker is immutable.
        ''
        mod_opPrior_ForUndo = opPrior
        mod_opNext_ForRedo = opNext

    End Sub


    Public Sub New(opPrior As DLL_OperationV1)
        ''
        ''----NO LONGER TRUE, AS OF 1/10/2024 & 1/15/2024
        ''Just like a Tuple, a DLL_OperationMarker is immutable.
        ''
        mod_opPrior_ForUndo = opPrior
        mod_opNext_ForRedo = Nothing

    End Sub ''Public Sub New(opPrior As DLL_OperationV1)


    Public Sub Clear()

        ''Added 1/20/2024 
        mod_opPrior_ForUndo = Nothing
        mod_opNext_ForRedo = Nothing

    End Sub ''ENd of ""Public Sub Clear()""


    Public Function GetCurrentOp_Undo() As DLL_OperationV1

        Return mod_opPrior_ForUndo

    End Function


    Public Function GetCurrentOp_Redo() As DLL_OperationV1

        Return mod_opNext_ForRedo

    End Function


    Public Function GetPrior() As DLL_OperationV1

        Return mod_opPrior_ForUndo

    End Function


    Public Function GetNext() As DLL_OperationV1

        Return mod_opNext_ForRedo

    End Function


    Public Function GetCurrentIndex_Redo() As Integer

        ''Added 1/13/2024 
        Return mod_opNext_ForRedo.DLL_GetIndex()

    End Function


    Public Function GetCurrentIndex_Undo() As Integer

        ''Added 1/13/2024 
        Return mod_opPrior_ForUndo.DLL_GetIndex()

    End Function


    Public Sub ShiftMarker_AfterUndo_ToPrior()
        ''
        ''Just like a Tuple, a DLL_OperationMarker is immutable.  Or, 
        ''   it would be, if not for this procedure.  So, I guess it 
        ''   is mutable... unless I comment out this procedure!!!! 1/10/2024
        ''
        Dim temp_op As DLL_OperationV1
        temp_op = mod_opPrior_ForUndo

        mod_opPrior_ForUndo = mod_opPrior_ForUndo.DLL_GetItemPrior() ''Shift to the Left... to Prior() item.

        If (mod_opNext_ForRedo Is Nothing) Then ''Added 1/15/2024 td
            ''Added 1/15/2024 td
            mod_opNext_ForRedo = temp_op ''January 18, 2024 td ''mod_opPrior_ForUndo
        Else
            mod_opNext_ForRedo = mod_opNext_ForRedo.DLL_GetItemPrior() ''Shift to the Left... to Prior() item.
        End If ''End of ""If (mod_opNext_ForRedo Is Nothing) Then ... Else"

    End Sub ''End of ""Public Sub ShiftMarker_AfterUndo_ToPrior""


    Public Sub ShiftMarker_DueToNewOperation(par_newOperation As DLL_OperationV1)
        ''
        ''Added 1/15/2024

        ''---------------DIFFICULT AND CONFUSING------------------
        ''Why is this procedure so short (only two lines of code)?  BECAUSE
        ''  THIS CLASS IS __NOT__ A LINKED LIST, IT'S AN ORDERED PAIR (TUPLE)!!
        ''
        If (par_newOperation.CreatedAsUndoOperation) Then
            ''Do NOT record this operation. 
            Debugger.Break()

        Else
            mod_opPrior_ForUndo = par_newOperation
            mod_opNext_ForRedo = Nothing

        End If ''If (par_newOperation.CreatedAsUndoOperation) Then..else

    End Sub ''End of ""Public Sub ShiftMarker_DueToNewOperation""


    Public Sub ShiftMarker_AfterRedo_ToNext()
        ''
        ''Just like a Tuple, a DLL_OperationMarker is immutable.  Or, 
        ''   it would be, if not for this procedure.  So, I guess it 
        ''   is mutable... unless I comment out this procedure!!!!  1/10/2024
        ''
        If mod_opPrior_ForUndo Is Nothing Then Debugger.Break()
        If mod_opNext_ForRedo Is Nothing Then Debugger.Break()

        mod_opPrior_ForUndo = mod_opPrior_ForUndo.DLL_GetItemNext() ''Shift to the Right... to Next() item.
        mod_opNext_ForRedo = mod_opNext_ForRedo.DLL_GetItemNext() ''Shift to the Right... to Next() item.

    End Sub ''End of ""Public Sub ShiftMarker_AfterRedo_ToNext""


    ''' <summary>
    ''' This function provides the operation which was prior / earlier, in the recorded
    ''' sequence of operations (assuming the user did one or more list-order operations
    ''' prior to changing their mind and choosing to perform the Undo).  Here, the "prior"
    ''' is relative to our location within this queue of recorded operations. 
    ''' </summary>
    ''' <returns></returns>
    Public Function GetMarkersPrior_ShiftPositionLeft() As DLL_OperationV1
        ''
        ''Added 1/15/2024  Thomas Downes  
        ''
        Dim temp_output As DLL_OperationV1 = Nothing
        Dim result_operation As DLL_OperationV1 = Nothing

        If (mod_opPrior_ForUndo Is Nothing) Then

            ''We should NOT be calling this function.  The calling procedure 
            ''   should have called HasOperationNext() first, and omitted 
            ''   a call to this procedure in the case that HasOperationNext()
            ''   returns a False. ---1/18/2024 
            Diagnostics.Debugger.Break()

        Else
            temp_output = mod_opPrior_ForUndo
            result_operation = mod_opPrior_ForUndo

            ''
            ''Prepare for future calls to this function, NOT for the present call....
            ''
            mod_opPrior_ForUndo = temp_output.DLL_GetItemPrior()
            mod_opNext_ForRedo = temp_output

        End If ''End of ""If (mod_opNext_ForRedo Is Nothing) Then... Else..."

        Return result_operation

    End Function ''end of ""Public Function GetMarkersPrior_ShiftPositionLeft() As DLL_OperationV1""


    Public Function GetMarkersNext_ShiftPositionRight() As DLL_OperationV1
        ''
        ''Added 1/18/2024  Thomas Downes  
        ''
        Dim temp_output As DLL_OperationV1 = Nothing
        Dim result_operation As DLL_OperationV1 = Nothing

        If (mod_opNext_ForRedo Is Nothing) Then

            ''We should NOT be calling this function.  The calling procedure 
            ''   should have called HasOperationNext() first, and omitted 
            ''   a call to this procedure in the case that HasOperationNext()
            ''   returns a False. ---1/18/2024 
            Diagnostics.Debugger.Break()

        Else
            temp_output = mod_opNext_ForRedo
            result_operation = mod_opNext_ForRedo

            ''
            ''Prepare for future calls to this function, NOT for the present call....
            ''
            mod_opNext_ForRedo = temp_output.DLL_GetItemNext()
            mod_opPrior_ForUndo = temp_output

        End If ''End of ""If (mod_opNext_ForRedo Is Nothing) Then... Else..."

        Return result_operation

    End Function ''end of ""Public Function GetMarkersPrior_ShiftPositionLeft() As DLL_OperationV1""


    Public Sub ShiftMarker(opCurrentPrior As DLL_OperationV1, opCurrentNext As DLL_OperationV1)
        ''
        ''Just like a Tuple, a DLL_OperationMarker is immutable.  Or, 
        ''   it would be, if not for this procedure.  So, I guess it 
        ''   is mutable... unless I comment out this procedure!!!! 
        ''
        mod_opPrior_ForUndo = opCurrentPrior
        mod_opNext_ForRedo = opCurrentNext

    End Sub ''End of ""Public Sub ShiftMarker""


    Public Function HasOperationPrior() As Boolean
        ''
        ''Added 1/15/2024 td
        ''
        Return (mod_opPrior_ForUndo IsNot Nothing)

    End Function ''end of ""Public Function HasOperationPrior() As Boolean""


    Public Function HasOperationNext() As Boolean
        ''
        ''Added 1/15/2024 td
        ''
        Return (mod_opNext_ForRedo IsNot Nothing)

    End Function ''end of ""Public Function HasOperationNext() As Boolean""


    Public Function HasTypeOfOperation_Prior(par_desiredTypeOfOp As Char) As Boolean
        ''
        ''Added 1/15/2024 td
        ''
        Dim bCompletedWhileLoop As Boolean = False
        Dim eachPriorOperation As DLL_OperationV1 = mod_opPrior_ForUndo
        Dim eachPriorOpType As Char = "?"c
        Dim eachIsOfGivenType As Boolean = False
        Dim bFoundGivenOperationType As Boolean = False

        While (Not bCompletedWhileLoop) ''While bNotDone
            ''
            ''Look for an operation of the specified type (par_typeOfOp).
            ''
            ''---eachOperation = mod_stackOperations.ElementAt(eachIndex)

            eachPriorOpType = eachPriorOperation.OperationType
            eachIsOfGivenType = (eachPriorOpType = par_desiredTypeOfOp)

            ''Use the OR operator, to accumulate the Boolean across
            ''  all the repeated iterations. 
            bFoundGivenOperationType = (eachIsOfGivenType Or
                                        bFoundGivenOperationType)

            ''
            ''There are two(2) ways this loop can be completed
            ''
            If bFoundGivenOperationType Then ''If each_isDelete Then
                bCompletedWhileLoop = True
            Else
                bCompletedWhileLoop = eachPriorOperation.DLL_NotAnyPrior()
            End If ''END OF "'If each_isDelete Then... Else..."

            ''
            ''Prepare for next iteration.
            ''
            eachPriorOperation = eachPriorOperation.DLL_GetItemPrior()

        End While ''ENd of ""While Not bCompletedWhile""

        Return bFoundGivenOperationType

    End Function



End Class
