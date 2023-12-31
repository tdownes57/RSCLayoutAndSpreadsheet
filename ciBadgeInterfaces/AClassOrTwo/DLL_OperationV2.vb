''-----------------------------------------------------------
''  Please see CIBadgeDesigner / Classes RSC / RSC_DLL_OperationsManager.
''
''   Version #2 (DLL_OperationV2) exposes less instance-members than Version #1 (DLL_OperationV1).
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

    ''
    ''Reminder, the "Inverse Anchor" is by definition the situation
    ''  which exists _BEFORE_IN_TIME_ prior to the Move-Cut operation.
    ''  --12/30/2023
    ''
    ''' <summary>
    ''' Inverse-Anchor items are pre-operational locators. They help UNDO/INVERSE the operation. Inverse Anchor items are NOT in the operation range.
    ''' </summary>
    Private mod_inverseAnchorPrior As IDoublyLinkedItem

    ''' <summary>
    ''' Inverse Anchor items are NOT in the operation range. They help UNDO/INVERSE the operation.
    ''' </summary>
    Private mod_inverseAnchorNext As IDoublyLinkedItem

    ''' <summary>
    ''' (Maybe for V3. Not currently used. 12/23/2023) Sort Order items are NOT actual list items, although they may appear so. They exist to point to side data cells. They record the sort with respect to adjacent (left or right) list items.
    ''' </summary>
    Private mod_sortOrder_TopCopy As IDoublyLinkedItem
    Private mod_operationRangeFirstIndex As Integer = -1 ''Added 12/26/2023 
    Private mod_isChangeOfEndpoint As Boolean = False ''Added 12/26/203 

    ''' <summary>
    ''' Uncle Bob (R.C. Martin) says that the best functions have no parameters.
    ''' So let's add a constructor, so we can cut down on parameters on other 
    ''' methods.  This object can be passed as a parameter.
    ''' </summary>
    ''' <param name="p_opType">I for Insert, D for Delete, M for Move.</param>
    ''' <param name="p_firstInOperationRange">First item in the set of contiguous items which is being Deleted or Moved.</param>
    ''' <param name="p_anchorFinalPrior">May be Nothing. The listed item which will be immediately PRIOR to the Inserted or Moved items.</param>
    ''' <param name="p_anchorFinalNext">May be Nothing. The listed item which will immediately FOLLOW the Inserted or Moved items.</param>
    ''' <param name="p_forEitherEndpoint">Indicates that an operation will result in a new starting or ending item.</param>
    Public Sub New(p_opType As Char, p_firstInOperationRange As IDoublyLinkedItem,
                   p_intCountOfItems As Integer,
                   p_anchorFinalPrior As IDoublyLinkedItem,
                   Optional p_anchorFinalNext As IDoublyLinkedItem = Nothing,
                   Optional p_forEitherEndpoint As Boolean = False,
                   Optional p_fillingEmptyList As Boolean = False)
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
        mod_isChangeOfEndpoint = p_forEitherEndpoint

        ''
        ''Inverse Anchors--Anchors for the UNDO operation.
        ''
        If (p_firstInOperationRange.DLL_HasPrior()) Then
            ''Get the prior item. 
            mod_inverseAnchorPrior = p_firstInOperationRange.DLL_GetItemPrior()
        End If

        ''Added 12/28/2023 td 
        Dim lastInOperationRange As IDoublyLinkedItem ''Added 12/28/2023 td 
        lastInOperationRange = p_firstInOperationRange.DLL_GetItemNext(-1 + mod_countOfItems)
        If (lastInOperationRange.DLL_HasNext()) Then
            ''If we iterate "Next" by p_intCountOfItem times,
            ''  we get the item __following__ the range. 
            ''mod_inverseFinalNext = p_firstInOperationRange.DLL_GetItemNext(p_intCountOfItems)
            mod_inverseAnchorNext = lastInOperationRange.DLL_GetItemNext()

        End If ''End of ""If (lastInOperationRange.DLL_HasNext()) Then""

        ''
        ''Added 12/28/2023
        ''
        If (Testing.TestingByDefault) Then

            If (p_opType = "M"c) Then
                ''
                ''Give it some time, prior to testing Move-Undos.
                ''
                ''We need to test the Move itself (original, not the Undo) first.
                ''
                ''   ---12/30/2023 td
                ''
            Else
                ''Added 12/28/2023
                Dim copyOfOpV1 As DLL_OperationV1
                copyOfOpV1 = GetCopyV1()
                Dim inverseOfOp As DLL_OperationV1
                inverseOfOp = copyOfOpV1.GetUndoVersionOfOperation()
                Dim double_inverse As DLL_OperationV1
                double_inverse = inverseOfOp.GetUndoVersionOfOperation()
                Dim bEqualMatch As Boolean
                bEqualMatch = double_inverse.Equals(copyOfOpV1)
                If (Not bEqualMatch) Then Debugger.Break()

            End If ''Endof ""If (p_opType = "M"c) Then""

            ''added 12/28
            ''Infinitely recursive loop. (prefixed by ''+++) 12/30/2023 
            ''+++Dim copyOfOpV2 As DLL_OperationV2
            ''+++copyOfOpV2 = double_inverse.GetCopyV2()
            ''+++If (Not Me.Equals(copyOfOpV2)) Then Debugger.Break()

        End If ''ENd of ""If (Testing.TestingByDefault) Then""

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


    Public Function GetCopyV1() As DLL_OperationV1
        ''
        ''Added 12/26/2023
        ''
        Dim result As New DLL_OperationV1

        With result

            .AnchorToPrecedeItemOrRange = mod_anchorFinalPrior
            .AnchorToSucceedItemOrRange = mod_anchorFinalNext
            ''12/28/2023
            .IsChangeOfEndpoint = mod_isChangeOfEndpoint

            If (mod_operationType = "I"c) Then

                .OperationType = "I"c ''Added 12/30/2023 
                .InsertRangeStart = mod_operationRangeFirstItem
                .InsertCount = mod_countOfItems

                If (.InsertCount = 1) Then
                    .InsertItemSingly = mod_operationRangeFirstItem
                    .InsertRangeStart = Nothing
                End If ''End of ""If (.InsertCount = 1) Then""

            ElseIf (mod_operationType = "D"c) Then

                .OperationType = "D"c ''Added 12/30/2023 
                .DeleteRangeStart = mod_operationRangeFirstItem
                .DeleteCount = mod_countOfItems
                .DeleteLocation_ItemPrior = mod_inverseAnchorPrior
                .DeleteLocation_ItemNext = mod_inverseAnchorNext

                If (.DeleteCount = 1) Then
                    .DeleteItemSingly = mod_operationRangeFirstItem
                    .DeleteRangeStart = Nothing
                End If ''End of ""If (.DeleteCount = 1) Then""

            ElseIf (mod_operationType = "M"c) Then

                .OperationType = "M"c ''Added 12/30/2023 
                .MovedRangeStart = mod_operationRangeFirstItem
                .MovedCount = mod_countOfItems

                ''Added 12/30/2023
                ''
                ''Reminder, the "Inverse Anchor" is by definition the situation
                ''  which exists _BEFORE_IN_TIME_ prior to the Move-Cut operation.
                ''
                ''Dim temp_moveCut_prior As IDoublyLinkedItem
                ''Dim temp_moveRange_last As IDoublyLinkedItem
                If (mod_inverseAnchorPrior Is Nothing) Then
                    ''Easy, let's grab the item which precedes
                    ''  the first item in the range (may be Null).
                    mod_inverseAnchorPrior = mod_operationRangeFirstItem.DLL_GetItemPrior()
                End If ''If (mod_inverseAnchorPrior Is Nothing) Then

                If (mod_inverseAnchorNext Is Nothing) Then
                    ''---DIFFICULT AND CONFUSING---
                    ''  By CS-related rules of iteration, by moving ahead
                    ''  a number of jumps equal to the length of the range,
                    ''  we get the first post-range item.
                    ''  
                    ''12/2023 mod_inverseFinalNext = mod_operationRangeFirstItem.DLL_GetNextOfRange(.MovedCount)
                    mod_inverseAnchorNext = mod_operationRangeFirstItem.DLL_GetNextItemFollowingRange(.MovedCount,
                          .IsChangeOfEndpoint)
                End If ''If (mod_inverseAnchorNext Is Nothing) Then

                ''
                ''Reminder, the "Inverse Anchor" is by definition the situation
                ''  which exists _BEFORE_IN_TIME_ prior to the Move-Cut operation.
                ''
                .MoveCut_PriorToRange = mod_inverseAnchorPrior
                .MoveCut_NextToRange = mod_inverseAnchorNext

                ''===See top of function for this.
                ''==.AnchorToPrecedeItemOrRange = 

            End If ''End of ""If (mod_operationType = "I"c) Then ... ElseIf ... ElseIf..."

        End With ''End of ""With result""

        Return result

    End Function ''End of ""Public Function GeCopyV1() As DLL_OperationV1""


    Public Overloads Function Equals(lets_check As DLL_OperationV2) As Boolean
        ''12/2023 Private Overloads Function Equals(lets_check As DLL_Operation(Of TControl)) As Boolean
        ''Private Function Equals(lets_check As TControl) As Boolean
        ''
        ''This will check the Idempotency of a Undo(Undo()), i.e.
        ''   double-Undo.
        ''
        Dim boolEqual1 As Boolean
        Dim boolEqual2 As Boolean
        Dim boolEqual3 As Boolean
        Dim boolEqual4 As Boolean
        Dim boolEqual5 As Boolean
        Dim boolEqual6 As Boolean
        Dim boolEqual7 As Boolean
        Dim boolEqual8 As Boolean
        Dim boolEqual9 As Boolean

        Dim boolEqual91 As Boolean
        Dim boolEqual92 As Boolean
        Dim boolEqual93 As Boolean
        Dim boolEqual94 As Boolean
        Dim boolEqual95 As Boolean

        With lets_check

            boolEqual1 = (.mod_anchorFinalNext Is Me.mod_anchorFinalNext)
            boolEqual2 = (.mod_anchorFinalPrior Is Me.mod_anchorFinalPrior)
            boolEqual3 = (.mod_countOfItems = Me.mod_countOfItems)
            boolEqual4 = (.mod_inverseAnchorNext Is Me.mod_inverseAnchorPrior)
            boolEqual5 = (.mod_inverseAnchorPrior Is Me.mod_inverseAnchorPrior)
            boolEqual6 = (.mod_isChangeOfEndpoint = Me.mod_isChangeOfEndpoint)
            boolEqual7 = (.mod_operationNext Is Me.mod_operationNext)
            boolEqual8 = (.mod_operationPrior Is Me.mod_operationPrior)
            boolEqual9 = (.mod_operationRangeFirstIndex = .mod_operationRangeFirstIndex)
            boolEqual91 = (.mod_operationRangeFirstItem Is Me.mod_operationRangeFirstItem)

            boolEqual92 = (.mod_operationType = Me.mod_operationType)
            boolEqual93 = (.mod_sortOrder_TopCopy Is .mod_sortOrder_TopCopy)

        End With ''End of ""With lets_check""

        Dim bEqual1to5 As Boolean
        Dim bEqual6to9 As Boolean
        Dim bEqual91to93 As Boolean

        bEqual1to5 = (boolEqual1 And boolEqual2 And boolEqual3 And
                      boolEqual4 And boolEqual5)
        bEqual6to9 = (boolEqual6 And boolEqual7 And boolEqual8 And boolEqual9)
        bEqual91to93 = (boolEqual91 And boolEqual92 And boolEqual93)

        Dim bEqual_All As Boolean
        bEqual_All = (bEqual1to5 And bEqual6to9 And bEqual91to93)

        Return bEqual_All

    End Function ''End of Private Function Overrides Equals() as Boolean



End Class
