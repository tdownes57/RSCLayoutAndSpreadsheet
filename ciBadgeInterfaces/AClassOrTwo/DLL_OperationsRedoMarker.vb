
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
        ''Just like a Tuple, a DLL_OperationMarker is immutable.
        ''
        mod_opPrior_ForUndo = opPrior
        mod_opNext_ForRedo = opNext

    End Sub


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
        ''   is mutable... unless I comment out this procedure!!!! 
        ''
        mod_opPrior_ForUndo = mod_opPrior_ForUndo.DLL_GetItemPrior() ''Shift to the Left... to Prior() item.
        mod_opNext_ForRedo = mod_opNext_ForRedo.DLL_GetItemPrior() ''Shift to the Left... to Prior() item.

    End Sub ''End of ""Public Sub ShiftMarker_AfterUndo_ToPrior""


    Public Sub ShiftMarker_AfterRedo_ToNext()
        ''
        ''Just like a Tuple, a DLL_OperationMarker is immutable.  Or, 
        ''   it would be, if not for this procedure.  So, I guess it 
        ''   is mutable... unless I comment out this procedure!!!! 
        ''
        mod_opPrior_ForUndo = mod_opPrior_ForUndo.DLL_GetItemNext() ''Shift to the Right... to Next() item.
        mod_opNext_ForRedo = mod_opNext_ForRedo.DLL_GetItemNext() ''Shift to the Right... to Next() item.

    End Sub ''End of ""Public Sub ShiftMarker_AfterRedo_ToNext""


    Public Sub ShiftMarker(opCurrentPrior As DLL_OperationV1, opCurrentNext As DLL_OperationV1)
        ''
        ''Just like a Tuple, a DLL_OperationMarker is immutable.  Or, 
        ''   it would be, if not for this procedure.  So, I guess it 
        ''   is mutable... unless I comment out this procedure!!!! 
        ''
        mod_opPrior_ForUndo = opCurrentPrior
        mod_opNext_ForRedo = opCurrentNext

    End Sub ''End of ""Public Sub ShiftMarker""

End Class
