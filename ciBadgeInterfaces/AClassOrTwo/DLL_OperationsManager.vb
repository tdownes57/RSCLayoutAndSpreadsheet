''//
''//  Added 10/30/2023 t h o m a s d o w n e s  
''//
Public Class DLL_OperationsManager ''11/2/2023 (Of TControl)
    ''Moved to Partial Class. 11/2023  ---Implements IDoublyLinkedList
    ''11/2/2023 Implements IDoublyLinkedList(Of TControl)

    ''General question, is this sort of casting possible??  Probably not!!
    ''
    ''   (Impossible, since was are casting from parent to adult-child.)
    ''   (In contrast, yes it is permissible to cast from adult-child to parent. 
    ''   (I call it "adult-child" since it contains MORE knowledge than the parent... LOL)   
    ''
    ''   Dim rsc_item = CType(item_TControlToDelete, TControl)
    ''
    ''Not needed. 11/2023 Private mod_itemNext As IDoublyLinkedItem ''11/2/2023  TControl
    ''Not needed. 11/2023 Private mod_itemPrior As IDoublyLinkedItem ''11/2/2023   TControl

    Private mod_operationLastPrior As DLL_Operation

    ''' <summary>
    ''' This is the first operation in the chain, the operation the 
    ''' user performs first (e.g. 45 seconds after opening the 
    ''' spreadsheet).
    ''' </summary>
    Private mod_operation1stRecord As DLL_Operation

    ''---DIFFICULT AND CONFUSING----
    ''Private mod_operationMarkUndoPrior As DLL_Operation
    ''Private mod_operationMarkUndoNext As DLL_Operation
    ''Private mod_operationMarkRedoPrior As DLL_Operation
    ''Private mod_operationMarkRedoNext As DLL_Operation
    ''Private mod_operationMarker As Tuple(Of DLL_Operation, DLL_Operation)

    ''' <summary>
    ''' This provides a "current" Undo/Redo tracker-positional thing.
    ''' </summary>
    Private mod_operationMarker As DLL_OperationsRedoMarker

    ''Added 11/14/2023 Thomas Downes  
    Private mod_modeColumnNotRow As Boolean ''Added 11/14/2023
    Private mod_bModeHasBeenSet As Boolean ''Added 11/14/2023
    Private mod_bTesting As Boolean = ciBadgeInterfaces.Testing.TestingByDefault
    Private mod_datetimeModeSet As DateTime ''Added 11/14/2023 
    Private mod_datetimeModeSetToRow As DateTime ''Added 11/14/2023 
    Private mod_datetimeModeSetToCol As DateTime ''Added 11/14/2023 

    ''Private mod_list As RSCDoublyLinkedList(Of TControl)
    ''#1 11/2/2023 Private mod_list As List(Of TControl)
    ''#2 11/2/2023 Private mod_list As IDoublyLinkedList ''RSCDoublyLinkedList
    Private mod_listRowHeaders As IDoublyLinkedList ''RSCDoublyLinkedList
    Private mod_listColumns As IDoublyLinkedList ''RSCDoublyLinkedList


    Public Sub SetModeToColumnOperations()

        ''Added 11/14/2023 
        mod_modeColumnNotRow = True
        mod_bModeHasBeenSet = True
        ''For testing. 11/2023
        If (mod_bTesting) Then
            mod_datetimeModeSet = DateTime.Now
            mod_datetimeModeSetToCol = DateTime.Now
        End If ''End of ""If (mod_bTesting) Then""

    End Sub ''end of ""Public Sub SetModeToColumnOperations()""


    Public Sub SetModeToTesting()

        ''Added 11/14/2023 
        mod_bTesting = True

    End Sub


    Public Sub SetModeTo___RowOperations()
        ''Added 11/14/2023 
        mod_modeColumnNotRow = False
        mod_bModeHasBeenSet = True
        ''For testing. 11/2023
        If (mod_bTesting) Then
            mod_datetimeModeSet = DateTime.Now
            mod_datetimeModeSetToRow = DateTime.Now
        End If ''End of ""If (mod_bTesting) Then""
    End Sub


    Private Sub ProcessOperation(param_operation As DLL_Operation) ''11/2/2023 TControl))
        ''
        '' Here we "parse" (process) the properties of the DLL_Operation, 
        ''  in order to call the appropriate IDoublyLinkedList functions
        ''  represented by mod_list. 
        ''
        ''
        If (mod_bModeHasBeenSet = False) Then System.Diagnostics.Debugger.Break()

        ''Check for population. 
        With param_operation
            ''11/2023  If (.LefthandAnchor Is Nothing And .RighthandAnchor Is Nothing) Then
            If (.AnchorIs_Missing()) Then
                Debugger.Break()

            ElseIf (.InsertRangeStart Is Nothing And .ItemInsertSingly Is Nothing) Then
                If (.DeleteRangeStart Is Nothing And .ItemDeleteSingly Is Nothing) Then
                    If (.MovedRangeStart Is Nothing) Then
                        ''Oops, we have no subject-material for the operation.
                        Debugger.Break()
                    End If
                End If
            End If ''End of ""If (.AnchorIsLeftToPrior()) Then""
        End With ''End of ""With param_operation""

        ''
        ''Here, we check to make sure the Mode (Columns or Rows)
        ''  has been recently refreshed. 
        ''
        If (mod_bTesting) Then
            RaiseMessageIfModeNotRefreshed()
        End If ''ENd of ""If (mod_bTesting) Then""

        ''
        ''Let's process Inserts, Moves, and Deletes separately. 
        ''
        Select Case param_operation.OperationType ''Insert, Move, or Delete? 

            Case "I" ''I = Insert
                ''
                ''An insert operation. 
                ''
                ''11/17/2023 td''If (param_operation.InsertSingly IsNot Nothing) Then
                If (param_operation.ItemIs_HandledSingly()) Then
                    ''Is it a left-hand anchor, or a right-hand anchor?
                    ''  (Is it a prior-item anchor, or a next-item anchor?)
                    ''#1 11/2023 If (param_operation.AnchorLeftPrior IsNot Nothing) Then
                    ''#2 11/2023 If (param_operation.AnchorIs_LeftToPrevious()) Then
                    Dim bUsePrecedingAnchor As Boolean ''Added 11/28/2023
                    Dim bUseSucceedingAnchor As Boolean ''Added 11/28/2023

                    bUsePrecedingAnchor = param_operation.AnchorWillPrecedeRangeOrItem()
                    bUseSucceedingAnchor = (Not bUsePrecedingAnchor)

                    If (bUsePrecedingAnchor) Then
                        ''Left-hand (Prior Item) Preceding Anchor
                        Me.DLL_InsertItemAfter(param_operation.ItemInsertSingly,
                                            param_operation.AnchorToPrecedeItemOrRange)
                    ElseIf (bUseSucceedingAnchor) Then
                        ''Right-hand (Next Item), Succeeding Anchor
                        Me.DLL_InsertItemBefore(param_operation.ItemInsertSingly,
                                      param_operation.AnchorToSucceedItemOrRange)
                    End If ''End of ""If (bUsePrecedingAnchor) Then... Else..."


                ElseIf (param_operation.IsForRangeOfItems()) Then
                    ''
                    ''A range of items.
                    ''
                    ''Is it a left-hand anchor, or a right-hand anchor?
                    ''  (Is it a prior-item anchor, or a next-item anchor?)
                    ''#1 11/2023 If (param_operation.AnchorLeftToPrior IsNot Nothing) Then
                    ''#2 11/2023 If (param_operation.AnchorIs_LeftToPrevious()) Then

                    If (param_operation.AnchorWillPrecedeRangeOrItem()) Then
                        ''
                        ''Left-hand (Prior Item), Preceding Anchor
                        ''
                        Me.DLL_InsertItemAfter(param_operation.InsertRangeStart,
                                       param_operation.AnchorToPrecedeItemOrRange)
                    Else
                        ''
                        ''Right-hand (Next Item), Succeeding Anchor
                        ''
                        Me.DLL_InsertItemBefore(param_operation.InsertRangeStart,
                                        param_operation.AnchorToSucceedItemOrRange)

                    End If ''ENd of ""If (param_operation.AnchorWillPrecedeRangeOrItem()) Then... Else..."

                End If ''ENd of ""If (param_operation.ItemIs_HandledSingly()) Then... ElseIf..."

            Case "M" '' M = Move
                ''
                ''----DIFFICULT & CONFUSING-----
                ''
                ''A moving operation--combines Delete & Insert. 
                ''
                Dim itemPriorToDelete As IDoublyLinkedItem = Nothing
                Dim itemFollowsDelete As IDoublyLinkedItem = Nothing

                ''Is it a left-hand anchor, or a right-hand anchor?
                ''  (Is it a prior-item anchor, or a next-item anchor?)
                ''
                ''11/2023 If (param_operation.AnchorLeftToPrior IsNot Nothing) Then
                ''#2 11/2023 If (param_operation.AnchorIs_LeftToPrevious()) Then
                If (param_operation.AnchorWillPrecedeRangeOrItem()) Then
                    ''Left-hand (Prior Item) Anchor
                    ''Move Step 1 of 2 -- Delete
                    Me.DLL_DeleteRange_Simpler(param_operation.MovedRangeStart,
                                           param_operation.MovedCount,
                                           itemPriorToDelete, itemFollowsDelete)
                    ''Move Step 2 of 2 -- Insert
                    Me.DLL_InsertRangeAfter(param_operation.MovedRangeStart,
                                           param_operation.MovedCount,
                                           param_operation.AnchorToPrecedeItemOrRange) ''param_operation.AnchorLeftToPrior)

                ElseIf (param_operation.AnchorWillSucceedRangeOrItem()) Then
                    ''
                    ''Right-hand (Next Item) Anchor
                    ''
                    ''Move Step 1 of 2 -- Delete
                    Me.DLL_DeleteRange_Simpler(param_operation.MovedRangeStart,
                                       param_operation.MovedCount,
                                       itemPriorToDelete, itemFollowsDelete)
                    ''Move Step 2 of 2 -- Insert
                    Me.DLL_InsertRangeBefore(param_operation.MovedRangeStart,
                                       param_operation.MovedCount,
                                       param_operation.AnchorToSucceedItemOrRange)

                End If



            Case "D" '' D = Delete
                ''
                ''A deleting operation. 
                ''
                ''----------Second-Tier Priority (Admin for Undos)-----------------
                Dim objItemUndeleted_PriorLeft As IDoublyLinkedItem = Nothing ''Needs to be stored someplace.
                Dim objItemUndeleted_NextAfter As IDoublyLinkedItem = Nothing ''Needs to be stored someplace.

                If (param_operation.ItemDeleteSingly IsNot Nothing) Then
                    ''Delete the single item.

                    ''Me.DLL_DeleteItemSingly(param_operation.ItemDeleteSingly)  
                    Me.DLL_DeleteItemSingly(param_operation.ItemDeleteSingly,
                                               objItemUndeleted_PriorLeft,
                                               objItemUndeleted_NextAfter)

                    ''
                    ''----------Second-Tier Priority (Admin for Undos)-----------------
                    ''Administrative--record operation details for reversal, if requested
                    '' by the user.  (Lagniappe!  LOL)  
                    ''Make a record of the nearest un-deleted item. 
                    ''
                    param_operation.Delete_PriorToItemOrRange = objItemUndeleted_PriorLeft
                    param_operation.Delete_NextToItemOrRange = objItemUndeleted_NextAfter

                ElseIf (param_operation.DeleteRangeStart IsNot Nothing) Then
                    ''Delete the range.
                    Me.DLL_DeleteRange_Simpler(param_operation.DeleteRangeStart,
                               param_operation.DeleteCount,
                               objItemUndeleted_PriorLeft,
                               objItemUndeleted_NextAfter)
                    ''
                    ''----------Second-Tier Priority (Admin for Undos)-----------------
                    ''Make a record of the nearest un-deleted item. 
                    ''
                    ''11/2023 param_operation.Delete_PriorToItemOrRange = objItemUndeleted
                    param_operation.Delete_PriorToItemOrRange = objItemUndeleted_PriorLeft
                    param_operation.Delete_NextToItemOrRange = objItemUndeleted_NextAfter

                End If

        End Select




    End Sub ''End of ""Public Sub ProcessOperation""


    Public Function GetLastOperation() As DLL_Operation




    End Function



    Public Function GetRecentOperation() As DLL_Operation
        ''
        ''Allow the new operation to be stored on a stack of operations. 
        ''
        ''11/2023 Return mod_lastPriorOperation
        Return mod_operationLastPrior

    End Function ''Public Function GetRecentOperation()


    Public Sub RaiseMessageIfModeNotRefreshed(Optional pboolCheckIfTesting As Boolean = False)
        ''
        ''Added 11/14/2023  
        ''
        Dim timeDifference As TimeSpan = Now.Subtract(mod_datetimeModeSet)
        ''If (Now.) Then
        Dim bTooLongAgo As Boolean = False
        Dim bProgrammerForgotToSetMode As Boolean = False

        If (Me.mod_bTesting Or Not pboolCheckIfTesting) Then
            bTooLongAgo = (timeDifference.Milliseconds > 500)
            bProgrammerForgotToSetMode = bTooLongAgo
        End If

        If (bProgrammerForgotToSetMode Or bTooLongAgo) Then
            ''
            ''Check for the bug of the programmer not setting the 
            ''  mode--are we talking about Rows or Columns?
            ''
            Debugger.Break()

        End If ''End of ""If (bTooLongAgo) Then""

    End Sub ''End of ""Public Sub RaiseMessageIfModeNotRefreshed()""


    Private Sub ManageNewOperation(par_objOperationNew As DLL_Operation)
        ''
        ''Place a new operation in the context of the sequence
        ''  of operations. 11/2023
        ''
        ''Record the new operation! 
        ''
        Dim bNevermindRedoMarker As Boolean
        bNevermindRedoMarker = (mod_operationMarker Is Nothing)

        If (mod_operation1stRecord Is Nothing) Then
            ''
            ''Record the first one! 
            ''
            ''The very first record is both first & last. 
            mod_operation1stRecord = par_objOperationNew
            mod_operationLastPrior = par_objOperationNew
            ''---Not needed here. 11/2023
            ''---mod_operationMarkUndoNext = objOperationNew

        ElseIf (bNevermindRedoMarker) Then
            ''
            ''Good, we needn't concern ourselves about where we are
            ''   in the sequence of "post-operation" Undo/Redos.
            ''   (By "post-operation", I mean, the operation is NOT new,
            ''   but rather a retread of recorded operations.)
            ''
            ''A little more challenging, place the new operation at the end of 
            ''  the operations. 
            ''
            Dim tempLastPrior As DLL_Operation = mod_operationLastPrior
            ''Make sure we can travel foreward in the sequence of operations!
            mod_operationLastPrior.DLL_SetItemNext(par_objOperationNew)
            ''Make sure we can "start undoing" this & prior operations. 
            mod_operationLastPrior = par_objOperationNew
            ''Make sure we can travel backward in the sequence of operations!
            par_objOperationNew.DLL_SetItemPrior(tempLastPrior)


        ElseIf (mod_operationMarker IsNot Nothing) Then
            ''
            ''By creating a new Row or Column operation, the user has 
            ''   essentially stated, "I am happy with the Undo/Redos I have 
            ''   have done (by pressing the Undo/Redo buttons).  I am ready
            ''   to "clean the slate" of any Undo operations I have performed. 
            ''   Going forward, this new operation will be the next "Undo", 
            ''   (in case I do choose to perform an "Undo").  ---11/2023 td
            ''
            ''---DIFFICULT AND CONFUSING---
            ''Clear all succeeding recorded operations. We
            '' don't want to "track" branching-off from a pre-existing sequence.  We want
            '' to replace all "going forward" (i.e. redos forward from the marker) items. 
            ''
            Dim tempMarkerPrior As DLL_Operation = mod_operationMarker.GetPrior()
            mod_operationMarker = Nothing ''Clear the marker!!!!  
            ''---DIFFICULT AND CONFUSING---
            tempMarkerPrior.DLL_ClearReferenceNext("I"c) ''Clear all succeeding operations. We
            '' don't want to "track" branching-off from a pre-existing sequence.  We want
            '' to replace all "going forward" (i.e. redos forward from the marker) items. 
            mod_operationLastPrior = tempMarkerPrior

            ''Make sure we can travel foreward in the sequence of operations!
            mod_operationLastPrior.DLL_SetItemNext(par_objOperationNew)
            ''Make sure we can "start undoing" this & prior operations. 
            mod_operationLastPrior = par_objOperationNew
            ''Make sure we can travel backward in the sequence of operations!
            par_objOperationNew.DLL_SetItemPrior(tempMarkerPrior)

        End If ''End of ""If (mod_operation1stRecord Is Nothing) Then... Else...""

    End Sub




End Class

