''-----------------------------------------------------------
''  Please see CIBadgeDesigner / Classes RSC / RSC_DLL_OperationsManager.
''
''    ---12/17/2023 thomas dow_nes 
''-----------------------------------------------------------
Imports System.Windows.Forms

''' <summary>
''' This class records a Doubly-Linked operation, but V2 does so with less 
''' instance members and without exposing details.
''' </summary>
Public Class DLL_OperationV2
    Implements IDoublyLinkedItem ''DLL_GetItemNext, DLL_GetItemPrior

    Private mod_operationType As Char
    Private mod_operationRangeFirstItem As IDoublyLinkedItem
    Private mod_countOfItems As Integer

    ''
    ''Doubly-Linked List!!!  ---11/14/2023 
    ''
    Private mod_operationPrior As DLL_OperationV2 ''Added 11/14/2023 
    Private mod_operationNext As DLL_OperationV2 ''Added 11/14/2023 

    ''' <summary>
    ''' Anchor items are NOT in the operation range. They help locate the placement of the range.
    ''' </summary>
    Private mod_anchorFinalPrior As IDoublyLinkedItem

    ''' <summary>
    ''' Anchor items are NOT in the operation range. They help locate the placement of the range.
    ''' </summary>
    Private mod_anchorFinalNext As IDoublyLinkedItem

    ''' <summary>
    ''' Inverse Anchor items are NOT in the operation range. They help UNDO/INVERSE the operation.
    ''' </summary>
    Private mod_inverseFinalPrior As IDoublyLinkedItem

    ''' <summary>
    ''' Inverse Anchor items are NOT in the operation range. They help UNDO/INVERSE the operation.
    ''' </summary>
    Private mod_inverseFinalNext As IDoublyLinkedItem

    ''' <summary>
    ''' (Maybe for V3. Not currently used. 12/23/2023) Sort Order items are NOT actual list items, although they may appear so. They exist to point to side data cells. They record the sort with respect to adjacent (left or right) list items.
    ''' </summary>
    Private mod_sortOrder_TopCopy As IDoublyLinkedItem
    Private mod_operationRangeFirstIndex As Integer = -1 ''Added 12/26/2023 
    Private mod_forEitherEndpoint As Boolean = False ''Added 12/26/203 

    ''' <summary>
    ''' Uncle Bob (R.C. Martin) says that the best functions have no parameters.
    ''' So let's add a constructor, so we can cut down on parameters on other 
    ''' methods.  This object can be passed as a parameter.
    ''' </summary>
    Public Sub New(p_opType As Char, p_firstInOperationRange As IDoublyLinkedItem,
                   p_intCountOfItems As Integer,
                   p_anchorFinalPrior As IDoublyLinkedItem,
                   Optional p_anchorFinalNext As IDoublyLinkedItem = Nothing,
                   Optional p_forEitherEndpoint As Boolean = False)
        ''
        ''Added 12/7/2023  
        ''
        '' Uncle Bob (R.C. Martin) says that the best functions have no parameters.
        '' I don't think he was talking about constructors. 
        '' So let's add a constructor, so we can cut down on parameters on other 
        '' methods.  This object can be passed as a parameter.
        ''
        mod_anchorFinalNext = p_anchorFinalNext
        mod_anchorFinalPrior = p_anchorFinalPrior
        mod_countOfItems = p_intCountOfItems
        mod_operationType = p_opType
        mod_operationRangeFirstItem = p_firstInOperationRange

        ''Added 12/26/2023
        mod_forEitherEndpoint = p_forEitherEndpoint

        ''
        ''Inverse Anchors--Anchors for the UNDO operation.
        ''
        If (p_firstInOperationRange.DLL_HasPrior()) Then
            ''Get the prior item. 
            mod_inverseFinalPrior = p_firstInOperationRange.DLL_GetItemPrior()
        Else
            ''If we iterate "Next" by p_intCountOfItem times,
            ''  we get the item __following__ the range. 
            mod_inverseFinalNext = p_firstInOperationRange.DLL_GetItemNext(p_intCountOfItems)
        End If

    End Sub ''\end of ""Public Sub New""


    ''Public Sub ImplementOperationForList(par_list As DLL_List_OfTControl_PLEASE_USE)
    ''    ''
    ''    ''Added 12/26/2023 
    ''    ''
    ''End Sub ''End of ""Public Sub ImplementOperationForList(par_list As DLL_List_OfTControl_PLEASE_USE)""

    Public Function GetAnchor_precedingRange() As IDoublyLinkedItem

        Return mod_anchorFinalPrior

    End Function


    Public Function GetAnchor_followingRange() As IDoublyLinkedItem

        Return mod_anchorFinalNext

    End Function


    Public Function GetCountOfItems() As Integer '' IDoublyLinkedItem

        Return mod_countOfItems ''mod_anchorFinalNext

    End Function


    Public Function GetIndexOfStart() As Integer

        ''Added 12/26/2023 
        Return mod_operationRangeFirstIndex

    End Function ''End of ""Public Function GetIndexOfStart()""


    Public Function GetSingleItem() As IDoublyLinkedItem

        ''Return mod_countOfItems ''mod_anchorFinalNext
        If (mod_countOfItems = 1) Then

            ''Return mod_operationRangeFirstItem
            Return mod_operationRangeFirstItem

        Else
            Debugger.Break()

        End If ''End of "" If (mod_countOfItems = 1) Then .. Else...""

    End Function



    Public Function DLL_GetItemNext() As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemNext
        ''11/2023 td''Throw New NotImplementedException()
        Return mod_operationNext

    End Function

    Public Function DLL_GetItemPrior() As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemPrior
        ''11/2023 td''Throw New NotImplementedException()
        Return mod_operationPrior

    End Function

    Public Sub DLL_SetItemNext(param As IDoublyLinkedItem) Implements IDoublyLinkedItem.DLL_SetItemNext
        ''Throw New NotImplementedException()
        mod_operationNext = param
    End Sub

    Public Sub DLL_SetItemPrior(param As IDoublyLinkedItem) Implements IDoublyLinkedItem.DLL_SetItemPrior
        ''Throw New NotImplementedException()
        mod_operationPrior = param
    End Sub

    Public Sub DLL_ClearReferencePrior(par_opType As Char) Implements IDoublyLinkedItem.DLL_ClearReferencePrior
        ''Throw New NotImplementedException()
        Debugger.Break() ''Shouldn't be needed. 
        mod_operationPrior = Nothing
    End Sub

    Public Sub DLL_ClearReferenceNext(par_opType As Char) Implements IDoublyLinkedItem.DLL_ClearReferenceNext
        ''Throw New NotImplementedException()
        Debugger.Break() ''Shouldn't be needed. 
        mod_operationNext = Nothing
    End Sub

    Public Function DLL_NotAnyNext() As Boolean Implements IDoublyLinkedItem.DLL_NotAnyNext
        ''11/2023 Throw New NotImplementedException()
        Dim bNextIsNothing As Boolean
        bNextIsNothing = (mod_operationNext Is Nothing)
        Return bNextIsNothing
    End Function

    Public Function DLL_NotAnyPrior() As Boolean Implements IDoublyLinkedItem.DLL_NotAnyPrior
        ''11/2023 Throw New NotImplementedException()
        Dim bPriorIsNothing As Boolean
        bPriorIsNothing = (mod_operationPrior Is Nothing)
        Return bPriorIsNothing
    End Function


    Public Function DLL_IsEitherEndpoint() As Boolean Implements IDoublyLinkedItem.DLL_IsEitherEndpoint

        ''Added 12/24/2023 td
        Return (DLL_NotAnyPrior() Or DLL_NotAnyNext())

    End Function


    Public Function DLL_HasNext() As Boolean Implements IDoublyLinkedItem.DLL_HasNext
        Dim bNextIsSomething As Boolean ''12/17/2023
        bNextIsSomething = (mod_operationNext IsNot Nothing)
        Return bNextIsSomething
    End Function

    Public Function DLL_HasPrior() As Boolean Implements IDoublyLinkedItem.DLL_HasPrior
        Dim bPriorIsSomething As Boolean ''12/17/2023
        bPriorIsSomething = (mod_operationPrior IsNot Nothing)
        Return bPriorIsSomething
    End Function


    Public Function DLL_GetItemNext(param_iterationsOfNext As Integer) As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemNext
        ''Throw New NotImplementedException()

        ''Added 12/17/2023 & 11/25/2023 td
        Dim result As IDoublyLinkedItem = mod_operationNext ''--Nothing ''--mod_operationNext

        If (param_iterationsOfNext = 0) Then
            System.Diagnostics.Debugger.Break()
            Return Me
        ElseIf (param_iterationsOfNext = 1) Then
            Return result
        ElseIf (param_iterationsOfNext > 1) Then
            ''Let's iterate. 
            For index = 2 To param_iterationsOfNext
                ''Not necessary! ''If (result IsNot Nothing) Then
                result = result.DLL_GetItemNext()
                ''End If
            Next index
            Return result
        End If ''End If (param_iterationsOfNext = 0) Then... ElseIf

        System.Diagnostics.Debugger.Break()
        Return Nothing ''Not needed.

    End Function ''Public Function DLL_GetItemNext(param_iterationsOfNext As Integer)


    Public Function DLL_GetItemPrior(param_iterationsOfPrior As Integer) As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemPrior

        ''Added 12/17/2023 td
        Dim result As IDoublyLinkedItem = mod_operationPrior ''--Nothing ''--mod_operationNext

        If (param_iterationsOfPrior = 0) Then
            System.Diagnostics.Debugger.Break()
            Return Me
        ElseIf (param_iterationsOfPrior = 1) Then
            Return result
        ElseIf (param_iterationsOfPrior > 1) Then
            For index = 2 To param_iterationsOfPrior
                If (result IsNot Nothing) Then
                    result = result.DLL_GetItemPrior()
                End If
            Next index
            Return result
        End If

        System.Diagnostics.Debugger.Break()
        Return Nothing ''Not needed.

    End Function ''Public Function DLL_GetItemPrior(param_iterationsOfNext As Integer)


    ''' <summary>
    ''' Not implemented for Operations, so don't use. (See list(s) of controls, for usage.)
    ''' </summary>
    ''' <returns></returns>
    Public Function DLL_UnboxControl() As Control Implements IDoublyLinkedItem.DLL_UnboxControl
        ''
        '' Won't be implemented.  12/01/2023 td
        ''
        Throw New NotImplementedException()

    End Function ''End of ""Public Function DLL_UnboxControl() As Control""


    Public Function GetCopyV1() As DLL_OperationV1
        ''
        ''Added 12/26/2023
        ''
        Dim result As New DLL_OperationV1

        With result

            .AnchorToPrecedeItemOrRange = mod_anchorFinalPrior
            .AnchorToSucceedItemOrRange = mod_anchorFinalNext

            If (mod_operationType = "I"c) Then

                .InsertRangeStart = mod_operationRangeFirstItem
                .InsertCount = mod_countOfItems

                If (.InsertCount = 1) Then
                    .ItemInsertSingly = mod_operationRangeFirstItem
                    .InsertRangeStart = Nothing
                End If ''End of ""If (.InsertCount = 1) Then""

            ElseIf (mod_operationType = "D"c) Then

                .DeleteRangeStart = mod_operationRangeFirstItem
                .DeleteCount = mod_countOfItems
                .DeleteLocation_ItemPrior = mod_inverseFinalPrior
                .DeleteLocation_ItemNext = mod_inverseFinalNext

                If (.DeleteCount = 1) Then
                    .ItemDeleteSingly = mod_operationRangeFirstItem
                    .DeleteRangeStart = Nothing
                End If ''End of ""If (.DeleteCount = 1) Then""

            ElseIf (mod_operationType = "M"c) Then

                .MovedRangeStart = mod_operationRangeFirstItem
                .MovedCount = mod_countOfItems
                .MoveCut_NextToRange = mod_inverseFinalNext

            End If ''End of ""If (mod_operationType = "I"c) Then ... ElseIf ... ElseIf..."

        End With ''End of ""With result""

        Return result

    End Function ''End of ""Public Function GeCopyV1() As DLL_OperationV1""

End Class
