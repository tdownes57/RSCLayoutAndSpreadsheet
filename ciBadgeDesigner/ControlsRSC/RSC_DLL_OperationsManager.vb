﻿''//
''//  Moved 12/2/203 td.  Added 10/30/2023 t h o m a s d o w n e s  
''//
Imports ciBadgeInterfaces ''Added 12/02/2023 

Public Class RSC_DLL_OperationsManager ''11/2/2023 (Of TControl)
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

    ''--Private mod_operationLastPrior As DLL_OperationV1
    ''' <summary>
    ''' This is the most recent operation in the chain of recorded operations. 
    ''' </summary>
    Private mod_operationLastPrior As DLL_OperationV2

    ''' <summary>
    ''' This controls the DLL (doubly-linked list) manipulation of the rows.  
    ''' </summary>
    Private mod_listDLLRowHeaders As DLL_List_OfTControl_OBSELETE(Of IDoublyLinkedItem) ''RSCDoublyLinkedList
    ''----Private mod_listDLLRowHeaders As DLL_List_OfTControl_PLEASE_USE(Of RSCRowHeader) ''RSCDoublyLinkedList

    ''' <summary>
    ''' This controls the DLL  (doubly-linked list) manipulation of the columns.  
    ''' </summary>
    Private mod_listDLLColumns As DLL_List_OfTControl_OBSELETE(Of IDoublyLinkedItem) ''RSCDoublyLinkedList
    ''----Private mod_listDLLColumns As DLL_List_OfTControl_PLEASE_USE(Of RSCFieldColumnV2) ''RSCDoublyLinkedList

    ''' <summary>
    ''' For testing purposes. 12/7/2023
    ''' </summary>
    Private mod_listDLLIntegersForTest As DLL_List_OfTControl_OBSELETE(Of IDoublyLinkedItem)

    ''12/2023 Private mod_operation1stRecord As DLL_OperationV1
    ''' <summary>
    ''' This is the first operation in the chain, the operation the 
    ''' user performs first (e.g. 35 seconds after opening the 
    ''' spreadsheet).
    ''' </summary>
    Private mod_operation1stRecord As DLL_OperationV2

    ''---DIFFICULT AND CONFUSING----
    ''Private mod_operationMarkUndoPrior As DLL_Operation
    ''Private mod_operationMarkUndoNext As DLL_Operation
    ''Private mod_operationMarkRedoPrior As DLL_Operation
    ''Private mod_operationMarkRedoNext As DLL_Operation
    ''Private mod_operationMarker As Tuple(Of DLL_Operation, DLL_Operation)

    ''' <summary>
    ''' This provides a "current" Undo/Redo tracker-positional thing.
    ''' </summary>
    Private mod_operationMarker As RSC_DLL_OperationsRedoMarker

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
    ''12/2023  Private mod_listRowHeaders As IDoublyLinkedList ''RSCDoublyLinkedList
    ''12/2023  Private mod_listColumns As IDoublyLinkedList ''RSCDoublyLinkedList



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


    Private Sub ProcessOperation(param_operation As DLL_OperationV1) ''11/2/2023 TControl))
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

            ElseIf (.InsertRangeStart Is Nothing And .InsertItemSingly Is Nothing) Then
                If (.DeleteRangeStart Is Nothing And .DeleteItemSingly Is Nothing) Then
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

        If (mod_modeColumnNotRow) Then

            ProcessOperation_Columns(param_operation)

        Else

            ProcessOperation_RowHeaders(param_operation)

        End If ''End of ""If (mod_modeColumnNotRow) Then.. Else...

    End Sub ''End of ""Private Sub ProcessOperation""


    ''' <summary>
    ''' Column mode, so use the mod_list...(Of RSCFieldColumnV2) member to process the operation.
    ''' </summary>
    ''' 
    Private Sub ProcessOperation_Columns(param_operation As DLL_OperationV1)
        ''
        ''Let's process Inserts, Moves, and Deletes separately. 
        ''
        ProcessOperation_ViaInterface(param_operation, mod_listDLLColumns)

    End Sub

    Private Sub ProcessOperation_RowHeaders(param_operation As DLL_OperationV1)
        ''
        ''Let's process Inserts, Moves, and Deletes separately. 
        ''
        ProcessOperation_ViaInterface(param_operation, mod_listDLLRowHeaders)

    End Sub


    Private Sub ProcessOperation_ViaInterface(param_operation As DLL_OperationV1, par_listDLLItems As DLL_List_OfTControl_OBSELETE(Of IDoublyLinkedItem))
        ''
        ''Let's process Inserts, Moves, and Deletes separately. 
        ''

        ''
        ''Let's process Inserts, Moves, and Deletes separately. 
        ''
        Select Case param_operation.OperationType ''Insert, Move, or Delete? 

            Case "I"c ''I = Insert
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
                        ''
                        ''Left-hand (Prior Item) Preceding Anchor
                        ''
                        With par_listDLLItems ''mod_listDLLColumns
                            ''.DLL_InsertItemAfter(param_operation.ItemInsertSingly,
                            ''              param_operation.AnchorToPrecedeItemOrRange)
                            .DLL_InsertOneItemAfter(param_operation.InsertItemSingly,
                                            param_operation.AnchorToPrecedeItemOrRange,
                                            param_operation.IsChangeOfEndpoint)

                        End With ''End of ""With par_listDLLItems""

                    ElseIf (bUseSucceedingAnchor) Then
                        ''
                        ''Right-hand (Next Item), Succeeding Anchor
                        ''
                        With par_listDLLItems ''mod_listDLLColumns
                            ''.DLL_InsertItemBefore(param_operation.ItemInsertSingly,
                            ''            param_operation.AnchorToSucceedItemOrRange)
                            .DLL_InsertOneItemBefore(param_operation.InsertItemSingly,
                                          param_operation.AnchorToSucceedItemOrRange,
                                          param_operation.IsChangeOfEndpoint)
                        End With ''End of ""With par_listDLLItems""

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
                        With par_listDLLItems ''mod_listDLLColumns
                            ''.DLL_InsertItemAfter(param_operation.InsertRangeStart,
                            ''                     param_operation.AnchorToPrecedeItemORange)
                            .DLL_InsertRangeAfter(CType(param_operation.InsertRangeStart, IDoublyLinkedItem),
                                                  param_operation.InsertCount,
                                                 CType(param_operation.AnchorToPrecedeItemOrRange, IDoublyLinkedItem),
                                                    param_operation.IsChangeOfEndpoint,
                                                 CType(param_operation.InsertRangeEnd_Null, IDoublyLinkedItem))
                        End With

                    Else
                        ''
                        ''Right-hand (Next Item), Succeeding Anchor
                        ''
                        With mod_listDLLColumns
                            ''.DLL_InsertItemBefore(param_operation.InsertRangeStart,
                            ''                      param_operation.AnchorToSucceedItemOrRange)
                            ''.DLL_InsertItemBefore(CType(param_operation.InsertRangeStart, RSCFieldColumnV2),
                            ''                      CType(param_operation.AnchorToSucceedItemOrRange, RSCFieldColumnV2))
                            .DLL_InsertRangeBefore(CType(param_operation.InsertRangeStart, IDoublyLinkedItem),
                                                  param_operation.InsertCount,
                                                  CType(param_operation.AnchorToSucceedItemOrRange, IDoublyLinkedItem),
                                                  param_operation.IsChangeOfEndpoint,
                                                 CType(param_operation.InsertRangeEnd_Null, IDoublyLinkedItem))
                        End With ''End of ""With mod_listDLLColumns""

                    End If ''ENd of ""If (param_operation.AnchorWillPrecedeRangeOrItem()) Then... Else..."

                End If ''ENd of ""If (param_operation.ItemIs_HandledSingly()) Then... ElseIf..."

            Case "M"c '' M = Move
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
                    With mod_listDLLColumns
                        ''.DLL_DeleteRange_Simpler(param_operation.MovedRangeStart,
                        ''   param_operation.MovedCount,
                        ''   itemPriorToDelete, itemFollowsDelete)
                        .DLL_DeleteRange(param_operation.MovedRangeStart,
                                               param_operation.MovedCount,
                                               param_operation.IsChangeOfEndpoint,
                                               param_operation.MovedRangeEnd_Null)
                    End With

                    ''Move Step 2 of 2 -- Insert
                    With mod_listDLLColumns
                        ''.DLL_InsertRangeAfter(param_operation.MovedRangeStart,
                        ''                   param_operation.MovedCount,
                        ''                   param_operation.AnchorToPrecedeItemOrRange) ''param_operation.AnchorLeftToPrior)
                        .DLL_InsertRangeAfter(param_operation.MovedRangeStart,
                                           param_operation.MovedCount,
                                           param_operation.AnchorToPrecedeItemOrRange,
                                           param_operation.IsChangeOfEndpoint,
                                           param_operation.MovedRangeEnd_Null)
                        ''                 ''param_operation.AnchorLeftToPrior)
                    End With ''End of ""With mod_listDLLColumns""

                ElseIf (param_operation.AnchorWillSucceedRangeOrItem()) Then
                    ''
                    ''Right-hand (Next Item) Anchor
                    ''
                    ''Move Step 1 of 2 -- Delete
                    With mod_listDLLColumns
                        ''.DLL_DeleteRange_Simpler(param_operation.MovedRangeStart,
                        .DLL_DeleteRange(param_operation.MovedRangeStart,
                                           param_operation.MovedCount,
                                           param_operation.IsChangeOfEndpoint,
                                           param_operation.MovedRangeEnd_Null)
                        ''                 12/2023 itemPriorToDelete, itemFollowsDelete)
                    End With ''End of ""With mod_listDLLColumns""

                    ''Move Step 2 of 2 -- Insert
                    With mod_listDLLColumns
                        .DLL_InsertRangeBefore(param_operation.MovedRangeStart,
                                           param_operation.MovedCount,
                                           param_operation.AnchorToSucceedItemOrRange,
                                           param_operation.IsChangeOfEndpoint,
                                           param_operation.MovedRangeEnd_Null)
                    End With ''End of "With mod_listDLLColumns

                End If ''End of ""If (param_operation.AnchorWillPrecedeRangeOrItem()) Then... ElseIf..."



            Case "D"c '' D = Delete
                ''
                ''A d eleting operation. 
                ''
                ''----------Second-Tier Priority (Admin for Undos)-----------------
                Dim objItemUndeleted_PriorLeft As IDoublyLinkedItem = Nothing ''Needs to be stored someplace.
                Dim objItemUndeleted_NextAfter As IDoublyLinkedItem = Nothing ''Needs to be stored someplace.

                If (param_operation.DeleteItemSingly IsNot Nothing) Then
                    ''Delete the single item.

                    With mod_listDLLColumns
                        ''Me.DLL_DeleteItemSingly(param_operation.ItemDeleteSingly)  
                        .DLL_DeleteItem(param_operation.DeleteItemSingly,
                                        param_operation.IsChangeOfEndpoint)
                        ''                       ''objItemUndeleted_PriorLeft,
                        ''                       ''objItemUndeleted_NextAfter)
                    End With ''End of "With mod_listDLLColumns

                    ''
                    ''----------Second-Tier Priority (Admin for Undos)-----------------
                    ''Administrative--record operation details for reversal, if requested
                    '' by the user.  (Lagniappe!  LOL)  
                    ''Make a record of the nearest un-deleted item. 
                    ''
                    ''1/6/2024 param_operation.Delete_PriorToItemOrRange = objItemUndeleted_PriorLeft
                    ''1/6/2024 param_operation.Delete_NextToItemOrRange = objItemUndeleted_NextAfter
                    param_operation.InverseAnchor_Preceding = objItemUndeleted_PriorLeft
                    param_operation.InverseAnchor_Following = objItemUndeleted_NextAfter

                ElseIf (param_operation.DeleteRangeStart IsNot Nothing) Then
                    ''Delete the range.
                    ''Me.DLL_DeleteRange(param_operation.DeleteRangeStart,
                    ''               param_operation.DeleteCount,
                    ''               objItemUndeleted_PriorLeft,
                    ''               objItemUndeleted_NextAfter)
                    With mod_listDLLColumns
                        .DLL_DeleteRange(param_operation.DeleteRangeStart,
                                   param_operation.DeleteCount,
                                   param_operation.IsChangeOfEndpoint,
                                   param_operation.DeleteRangeEnd_Null)

                    End With ''End of "With mod_listDLLColumns

                    ''
                    ''----------Second-Tier Priority (Admin for Undos)-----------------
                    ''Make a record of the nearest un-deleted item. 
                    ''
                    ''11/2023 param_operation.Delete_PriorToItemOrRange = objItemUndeleted
                    ''1/6/2024 param_operation.Delete_PriorToItemOrRange = objItemUndeleted_PriorLeft
                    ''1/6/2024 param_operation.Delete_NextToItemOrRange = objItemUndeleted_NextAfter
                    param_operation.InverseAnchor_Preceding = objItemUndeleted_PriorLeft
                    param_operation.InverseAnchor_Following = objItemUndeleted_NextAfter

                End If

        End Select ''nd of ""Select Case param_operation.OperationType""




    End Sub ''End of ""Public Sub ProcessOperation""


    Public Function GetLastOperation() As DLL_OperationV1




    End Function



    Public Function GetRecentOperationV1() As DLL_OperationV1
        ''
        ''Allow the new operation to be stored on a stack of operations. 
        ''
        ''11/2023 Return mod_lastPriorOperation
        Return mod_operationLastPrior.GetCopyV1()

    End Function ''Public Function GetRecentOperationV1()


    Public Function GetRecentOperationV2() As DLL_OperationV2
        ''
        ''Allow the new operation to be stored on a stack of operations. 
        ''
        ''11/2023 Return mod_lastPriorOperation
        Return mod_operationLastPrior

    End Function ''Public Function GetRecentOperationV2()


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


    Private Sub ManageNewOperation(par_objOperationNew As DLL_OperationV2)
        ''Private Sub ManageNewOperation(par_objOperationNew As DLL_OperationV1)
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
            Dim tempLastPrior As DLL_OperationV2 = mod_operationLastPrior
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
            Dim tempMarkerPrior As DLL_OperationV2 = mod_operationMarker.GetPrior()
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

