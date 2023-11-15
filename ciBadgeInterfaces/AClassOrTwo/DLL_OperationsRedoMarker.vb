''' <summary>
''' Similar to a Tuple(Of DLL_Operation, DLL_Operation) but 
''' has comments & better naming of First & Second.
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
    Private mod_opPrior As DLL_Operation
    Public mod_opNext As DLL_Operation

    Public Sub New(opPrior As DLL_Operation, opNext As DLL_Operation)
        ''
        ''Just like a Tuple, a DLL_OperationMarker is immutable.
        ''
        mod_opPrior = opPrior
        mod_opNext = opNext

    End Sub

    Public Function GetPrior() As DLL_Operation

        Return mod_opPrior

    End Function

    Public Function GetNext() As DLL_Operation

        Return mod_opNext

    End Function


    Public Sub ShiftMarker(opCurrentPrior As DLL_Operation, opCurrentNext As DLL_Operation)
        ''
        ''Just like a Tuple, a DLL_OperationMarker is immutable.  Or, 
        ''   it would be, if not for this procedure.  So, I guess it 
        ''   is mutable... unless I comment out this procedure!!!! 
        ''
        mod_opPrior = opCurrentPrior
        mod_opNext = opCurrentNext

    End Sub ''End of ""Public Sub ShiftMarker""

End Class
