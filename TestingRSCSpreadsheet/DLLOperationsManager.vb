''
''Added 1/18/2024
''
Imports ciBadgeInterfaces
Imports ciBadgeSerialize

''' <summary>
''' Will process and record V1 operations. 
''' </summary>
''' <typeparam name="TDoublyLinkedItem"></typeparam>
Public Class DLLOperationsManager(Of T_DoublyLinkedItem As IDoublyLinkedItem)

    ''Added 1/18/2024
    Private mod_firstItem As T_DoublyLinkedItem
    Private ReadOnly mod_list As IDoublyLinkedList(Of T_DoublyLinkedItem)
    Private mod_firstPriorOperationV1 As DLL_OperationV1
    Private mod_lastPriorOperationV1 As DLL_OperationV1
    Private mod_opRedoMarker As DLL_OperationsRedoMarker ''Added 1/24/2024
    Private mod_intCountOperations As Integer = 0 ''Added 1/24/2024 td

    Public Sub New(par_list As IDoublyLinkedList(Of T_DoublyLinkedItem),
                   Optional par_firstOperationV1 As DLL_OperationV1 = Nothing)
        ''
        ''Added 1/20/2024 thomas d.
        ''
        mod_list = par_list
        ''mod_firstItem = par_firstItem
        mod_firstPriorOperationV1 = par_firstOperationV1
        mod_lastPriorOperationV1 = par_firstOperationV1

        ''Added 1/28/2024 
        mod_opRedoMarker = New DLL_OperationsRedoMarker(par_firstOperationV1)

    End Sub ''End of ""Public Sub New""  


    Public Function GetFirstItem() As T_DoublyLinkedItem

        ''Added 1/20/2024 td 
        Return mod_firstItem

    End Function ''ENd of ""Public Function GetFirstItem()""


    Public Function CountOfOperations() As Integer

        ''Added 1/24/2024 td
        Dim intCountOps As Integer ''Added 1/24/2024 td
        intCountOps = mod_firstPriorOperationV1.DLL_CountItemsAllInList
        Return intCountOps

    End Function ''End of ""Public Function CountOfOperations() As Integer""


    Public Function MarkerHasOperationPrior() As Boolean

        ''Added 1/24/2024 
        Dim result_hasPrior As Boolean ''Added 1/28/2024 
        result_hasPrior =
             mod_opRedoMarker.HasOperationPrior()
        Return result_hasPrior

    End Function ''ENd of ""Public Function MarkerHasOperationPrior() As Boolean""


    Public Function MarkerHasOperationNext() As Boolean

        ''Added 1/24/2024 
        Dim result_hasNext As Boolean
        result_hasNext =
            mod_opRedoMarker.HasOperationNext()
        Return result_hasNext

    End Function ''ENd of ""Public Function MarkerHasOperationNext() As Boolean""


    Public Sub RedoMarkedOperation()
        ''
        ''Added 1/27/2024 td
        ''
        Dim opReDo As DLL_OperationV1
        ''opReDo =
        ''   mod_opRedoMarker.GetMarkersPrior_ShiftPositionLeft()
        opReDo =
            mod_opRedoMarker.GetMarkersNext_ShiftPositionRight()

        ''added 1/16/2024 td
        opReDo.CreatedAsRedoOperation = True

        ''Major call!!
        ''1/28/2024 ProcessOperation_AnyType(opReDo, opReDo.IsChangeOfEndpoint)
        ProcessOperation_AnyType(opReDo, opReDo.IsChangeOfEndpoint,
                    par_bRecordOperation:=False)

    End Sub ''End of ""Public Sub RedoMarkedOperation()""


    Public Sub UndoMarkedOperation()
        ''
        ''Added 1/27/2024 td
        ''
        UndoOfPriorOperation_AnyType()

        ''Dim operationPrior As DLL_OperationV1
        ''Dim opUnDo As DLL_OperationV1
        ''
        ''operationPrior =
        ''    mod_opRedoMarker.GetMarkersPrior_ShiftPositionLeft()
        ''
        ''opUnDo = operationPrior.GetUndoVersionOfOperation()
        ''
        ''''added 1/16/2024 td
        ''opUnDo.CreatedAsUndoOperation = True
        ''
        ''''Major call!!
        ''ProcessOperation_AnyType(opUnDo, opUnDo.IsChangeOfEndpoint)

    End Sub ''End of ""Public Sub UndoMarkedOperation()""



    Public Sub ProcessOperation_AnyType(parOperation As DLL_OperationV1,
                                       par_changeOfEndpoint As Boolean,
                                        par_bRecordOperation As Boolean)
        ''
        ''Added 1/15/2024 
        ''
        Dim opType As Char
        opType = parOperation.OperationType

        Select Case opType
            Case "S"c
                ''Sorting 
                ''---ProcessOperation_Sort(parOperation, False, par_bRecordOperation)
                ''2/27/2024 td''ProcessOperation_Sort(parOperation, par_bRecordOperation, False)
                Dim boolUndoByQueue As Boolean ''Added 2/27/2024
                ''Added 2/27/2024
                boolUndoByQueue = parOperation.Sort_IsByQueue
                ProcessOperation_Sort(parOperation, par_bRecordOperation, boolUndoByQueue)


            Case "I"c
                ''Insert (the inverse of Delete)
                ''1/28/2024 ProcessOperation_Insert(parOperation, par_changeOfEndpoint) ''.GetUndoVersionOfOperation())
                ProcessOperation_Insert(parOperation, par_changeOfEndpoint, par_bRecordOperation)

            Case "D"c
                ''Delete (the inverse of Insert)
                ''1/28/2024 ProcessOperation_Delete(parOperation, par_changeOfEndpoint) ''.GetUndoVersionOfOperation())
                ProcessOperation_Delete(parOperation, par_changeOfEndpoint, par_bRecordOperation) ''.GetUndoVersionOfOperation())
            Case "M"c
                ''Move Range (the inverse of Move Range)
                ''1/28/2024 ProcessOperation_MoveRange(parOperation, par_changeOfEndpoint) ''.GetUndoVersionOfOperation())
                ProcessOperation_MoveRange(parOperation, par_changeOfEndpoint, par_bRecordOperation) ''.GetUndoVersionOfOperation())

            Case Else
                Debugger.Break()
        End Select ''End of ""Select Case inverse_opType""

        ''Added 1/24/2024 td


    End Sub ''ENd of ""Public Sub ProcessOperation_AnyType""


    Public Sub ProcessOperation_Sort(ByVal par_operationV1 As DLL_OperationV1,
                                     ByVal par_bRecordOperation As Boolean,
                                     Optional ByVal par_bUndoByQueue As Boolean = False)
        ''
        ''Added 2/5/2024 thomas d.
        ''
        Dim list As DLL_List_OfTControl_OBSELETE(Of T_DoublyLinkedItem)
        list = mod_list

        Select Case True
            Case par_bUndoByQueue
                ''
                ''We will undo a previous sorting.  ---2/5/2024 
                ''
                ''---list.DLL_SortByQueue(par_operationV1.Sort_UndoQueue)
                Dim queueForSort As Queue(Of IDoublyLinkedItem)
                queueForSort = par_operationV1.Queue_ForPredeterminedSort
                If (queueForSort Is Nothing) Then
                    queueForSort = par_operationV1.Queue_IfNeededForUndo
                End If ''End of ""If (queueForSort Is Nothing) Then""
                list.DLL_SortByQueue(queueForSort)

            Case par_operationV1.Sort_IsAscending

                ''list.DLL_SortItems(True)
                list.DLL_SortItems(False)

            Case par_operationV1.Sort_IsDescending

                ''list.DLL_SortItems(False)
                list.DLL_SortItems(True)

            Case Else

                Debugger.Break()

        End Select ''End of ""Select Case True""

        ''
        ''Admin, if requested.
        ''
        If (par_bRecordOperation) Then ''Added 1/28/2024 

            RecordNewestOperation(par_operationV1)

        End If ''ENd of ""If (par_bRecordOperation) Then""

    End Sub ''ENd of ""Public Sub ProcessOperation_Sort""


    Public Sub ProcessOperation_Insert(ByVal par_operationV1 As DLL_OperationV1,
                                       ByVal par_changeOfEndpoint As Boolean,
                                       ByVal par_bRecordOperation As Boolean) ''1/2024 ,
        ''1/2024 td                 Optional par_bIncludePostOpAdmin As Boolean = False)
        ''
        ''Encapsulation 1/1/2024 
        ''

        With par_operationV1

            ''objItemToInsert_First = mod_list.DLL_GetItemAtIndex(.)
            ''mod_list.DLL_InsertOneItemAfter(each_twoCharsItem, prior, True)
            ''.ImplementForList(mod_list)

            ''V2''mod_list.DLL_InsertOneItemAfter(.GetSingleItem(),
            ''                                .GetAnchor_precedingRange(),
            ''                                False)
            If (.AnchorToPrecedeItemOrRange IsNot Nothing) Then
                ''
                ''Option #1 of 3.  Insert operational item(s) AFTER anchoring item.
                ''
                ''                Insert A after 7, the preceding anchor.
                ''                       |
                ''          1 2 3 4 5 6 7 8 9 10
                '' Result:  1 2 3 4 5 6 7 A 8 9 10
                ''
                If (.InsertItemSingly IsNot Nothing) Then
                    ''Insert a single item. 
                    mod_list.DLL_InsertOneItemAfter(.InsertItemSingly,
                                            .AnchorToPrecedeItemOrRange,
                                            .IsChangeOfEndpoint) ''False)

                ElseIf (.InsertRangeStart IsNot Nothing) Then
                    ''Insert a range of items. 
                    mod_list.DLL_InsertRangeAfter(.InsertRangeStart, .InsertCount,
                                            .AnchorToPrecedeItemOrRange,
                                            .IsChangeOfEndpoint) ''False)
                Else
                    Debugger.Break()

                End If ''End of ""If (.InsertItemSingly IsNot Nothing) Then... ElseIf... Else"


            ElseIf (.AnchorToSucceedItemOrRange IsNot Nothing) Then
                ''
                ''Option #2 of 3. Insert BEFORE anchoring item. 
                ''
                ''Insert operational item(s) BEFORE anchoring item.
                ''
                ''            Insert x before 6, the terminating anchor.
                ''                   |
                ''          1 2 3 4 5 6 7 8 9 10
                '' Result:  1 2 3 4 5 x 6 7 8 9 10
                ''
                If (.InsertItemSingly IsNot Nothing) Then
                    ''Insert a single item. 
                    mod_list.DLL_InsertOneItemBefore(.InsertItemSingly,
                                            .AnchorToSucceedItemOrRange,
                                            .IsChangeOfEndpoint) ''False))

                ElseIf (.InsertRangeStart IsNot Nothing) Then
                    ''Insert a range of items. 
                    mod_list.DLL_InsertRangeBefore(.InsertRangeStart, .InsertCount,
                                            .AnchorToSucceedItemOrRange,
                                            .IsChangeOfEndpoint) ''False)
                Else
                    Debugger.Break()

                End If ''End of ""If (.InsertItemSingly IsNot Nothing) Then... ElseIf... Else"


            ElseIf (mod_firstItem Is Nothing) Then
                ''
                ''Empty list !!!!
                ''
                ''Added 12/31/2023 thomas 
                ''  We are populating an empty list, or as one might say,
                ''  inserting a range into an empty list. 
                ''
                If (.InsertItemSingly IsNot Nothing) Then
                    ''Insert a single item, into an empty list. 
                    mod_list.DLL_InsertRangeEmptyList(.InsertItemSingly, 1)

                ElseIf (.InsertRangeStart IsNot Nothing) Then
                    ''Insert a range of items, into an empty list. 
                    mod_list.DLL_InsertRangeEmptyList(.InsertRangeStart, .InsertCount)
                Else
                    Debugger.Break()
                End If ''End of ""If (.InsertItemSingly IsNot Nothing) Then... ElseIf... Else"

                ''Be sure to save the first item.
                ''1/2024 mod_firstTwoChar = mod_list.DLL_GetFirstItem()
                mod_firstItem = mod_list.DLL_GetItemAtIndex(0)

            End If ''End of ""If (.AnchorToPrecedeItemOrRange IsNot Nothing) Then ... ElseIf... Else..."

            ''Added 12/28/2023
            If (.IsChangeOfEndpoint) Then
                ''In the 50% chance the starting item is affected...
                ''----mod_firstTwoChar = mod_list.DLL_GetFirstItem()
                mod_firstItem = mod_list.DLL_GetItemAtIndex(0)
            End If ''End of ""If (.IsChangeOfEndpoint) Then""

        End With ''End of ""With par_operationV1""

        ''
        ''Admin, if requested.
        ''
        ''If (par_bIncludePostOpAdmin) Then
        ''    ''
        ''    ''Refresh the Display.  (Make the Insert visible to the user.)
        ''    ''
        ''    RefreshTheUI_DisplayList()
        ''
        ''    ''Added 1/01/2024

        If (par_bRecordOperation) Then ''Added 1/28/2024 

            RecordNewestOperation(par_operationV1)

        End If ''ENd of ""If (par_bRecordOperation) Then""

        ''
        ''    ''Added 1/03/2024
        ''    RefreshTheUI_OperationsCount()
        ''
        ''End If ''end of ""If (par_bIncludePostOpAdmin) Then""

    End Sub ''End of "Public Sub ProcessOperation_Insert"


    Public Sub ProcessOperation_Delete(ByVal par_operationV1 As DLL_OperationV1,
                                       ByVal par_changeOfEndpoint As Boolean,
                                       ByVal par_bRecordOperation As Boolean) ''1/2024 ,

        ''1/2024                       Optional par_bIncludePostOpAdmin As Boolean = False)
        ''
        ''Encapsulated 1/01/2024 
        ''Added 12/25/2023 
        ''
        ''   Version #1 (DLL_OperationV1) exposes more things than Version #2.
        ''
        Dim firstItemInList As IDoublyLinkedItem
        firstItemInList = CType(mod_firstItem, IDoublyLinkedItem)

        With par_operationV1

            ''objItemToInsert_First = mod_list.DLL_GetItemAtIndex(.)
            ''mod_list.DLL_InsertOneItemAfter(each_twoCharsItem, prior, True)
            ''.ImplementForList(mod_list)
            Dim bChangeOfEndpoint As Boolean
            ''1/20/2024 TD Dim bChangeOfEndpoint_Start As Boolean
            ''1/20/2024 TD Dim bChangeOfEndpoint_Endpt As Boolean
            Dim objDeleteRangeStart As TwoCharacterDLLItem ''12/28/2023
            Dim objDeleteRangeEndpt As TwoCharacterDLLItem ''12/28/2023

            If (.DeleteItemSingly IsNot Nothing) Then
                ''Only a single item is being deleted. 
                ''1/2024 bChangeOfEndpoint_Start = (.DeleteItemSingly Is mod_firstItem) '' Is mod_firstTwoChar)
                ''1/20/2024 TD bChangeOfEndpoint_Start = (.DeleteItemSingly Is firstItemInList) '' Is mod_firstTwoChar)
                ''1/2024 bChangeOfEndpoint_Endpt = (.DeleteItemSingly Is mod_list.DLL_GetLastItem())
                ''1/20/2024 TD bChangeOfEndpoint_Endpt = (.DeleteItemSingly Is mod_list.DLL_GetLastItem())
            Else
                ''A range of items is being deleted. 
                objDeleteRangeStart = .DeleteRangeStart
                objDeleteRangeEndpt = .DeleteRangeStart.DLL_GetItemNext(-1 + .DeleteCount)
                ''1/20/2024 bChangeOfEndpoint_Start = (.DeleteRangeStart Is mod_firstTwoChar)
                ''1/20/2024 TD ''bChangeOfEndpoint_Start = (.DeleteRangeStart Is firstItemInList)
                ''1/20/2024 TD ''bChangeOfEndpoint_Endpt = (objDeleteRangeEndpt Is mod_list.DLL_GetLastItem())
            End If ''End of ""If (.DeleteItemSingly IsNot Nothing) Then... Else..."

            ''V2''bChangeOfEndpoint = (.GetIndexOfStart() <= -1 + mod_list.DLL_CountAllItems())
            ''12/2023 bChangeOfEndpoint_Start = (.DeleteRangeStart Is mod_list.DLL_GetLastItem())
            ''1/20/2024 TD ''bChangeOfEndpoint = (bChangeOfEndpoint_Start Or bChangeOfEndpoint_Endpt)
            bChangeOfEndpoint = par_changeOfEndpoint

            ''V2''mod_list.DLL_DeleteItem(.GetSingleItem(), bChangeOfEndpoint)
            If (.DeleteItemSingly IsNot Nothing) Then ''Added 12/28/2023 
                ''Conditioned by If (...) on 12/28/2023 
                mod_list.DLL_DeleteItem(.DeleteItemSingly, bChangeOfEndpoint)

            ElseIf (.DeleteRangeStart IsNot Nothing) Then
                ''Added 12/28/2023 thomas downes 
                mod_list.DLL_DeleteRange(.DeleteRangeStart, .DeleteCount,
                                  bChangeOfEndpoint, .DeleteRangeEnd_Null)

            Else
                ''Added 12/28/2023 thomas downes 
                Debugger.Break()

            End If ''End of ""If (.DeleteItemSingly IsNot Nothing) Then... ElseIf... Else...

            ''Added 12/28/2023 
            ''1/20/2024 If (bChangeOfEndpoint_Start) Then
            If (bChangeOfEndpoint) Then
                ''1/20/2024 mod_firstTwoChar = mod_list.DLL_GetFirstItem
                mod_firstItem = mod_list.DLL_GetItemAtIndex(0)
            End If ''End of ""If (bChangeOfEndpoint_Start) Then"'

        End With ''End o f ""With par_operationV1"" 

        ''
        ''Admin, if requested.
        ''
        ''If (par_bIncludePostOpAdmin) Then
        ''    ''
        ''    '' Make the Delete visible to the user.
        ''    ''
        ''    RefreshTheUI_DisplayList()
        ''
        ''    ''Added 1/01/2024
        If (par_bRecordOperation) Then ''Added 1/28/2024 

            RecordNewestOperation(par_operationV1)

        End If ''ENd of ""If (par_bRecordOperation) Then""
        ''
        ''    ''Added 1/03/2024
        ''    RefreshTheUI_OperationsCount()
        ''  
        ''End If ''ENd of ""If (par_bIncludePostOpAdmin) Then""

    End Sub ''End of ""Public Sub ProcessOperation_Delete""


    Public Sub ProcessOperation_MoveRange(ByVal par_operationV1 As DLL_OperationV1,
                                       ByVal par_changeOfEndpoint As Boolean,
                                          ByVal par_bRecordOperation As Boolean) ''1/2024 ,
        ''1/2024                       Optional par_bIncludePostOpAdmin As Boolean = False)

        With par_operationV1
            ''
            ''Step 1 of 2.  Cut (via "Delete") the range from the list. 
            ''
            mod_list.DLL_DeleteRange(.MovedRangeStart, .MovedCount,
                                            .IsChangeOfEndpoint) ''False)

            ''Added 12/30/2023 td
            If (Testing.TestingByDefault) Then
                ''Test that the ends are CLEAN OF REFERENCES.
                Dim firstItem As IDoublyLinkedItem = .MovedRangeStart
                Dim lastItem As IDoublyLinkedItem = .MovedRangeStart.DLL_GetItemNext(-1 + .MovedCount)
                ''Test that the ends are CLEAN OF REFERENCES.
                If (firstItem.DLL_HasPrior()) Then Debugger.Break()
                If (lastItem.DLL_HasNext()) Then Debugger.Break()
            End If ''End of ""If (Testing.TestingByDefault) Then""

            ''
            ''Step 2 of 2.  Paste (via "Insert") the range into the list. 
            ''
            If (.AnchorToPrecedeItemOrRange IsNot Nothing) Then
                ''Move operational item(s) AFTER anchoring item.
                ''
                ''                  Move 2_3_4 after 7, the preceding anchor.
                ''                       |
                ''          1 2_3_4 5 6 7 8 9 10
                '' Result:  1 5 6 7 2_3_4 8 9 10   <<< Note that 2_3_4 has been moved.
                ''

                mod_list.DLL_InsertRangeAfter(.MovedRangeStart, .MovedCount,
                                            .AnchorToPrecedeItemOrRange,
                                            .IsChangeOfEndpoint) ''False)

            Else
                ''Move operational item(s) BEFORE anchoring item.
                ''
                ''              Move 2_3_4 before 6, the terminating anchor.
                ''                   |
                ''          1 2_3_4 5 6 7 8 9 10
                '' Result:  1 5 2_3_4 6 7 8 9 10
                ''
                mod_list.DLL_InsertRangeBefore(.MovedRangeStart, .MovedCount,
                                            .AnchorToSucceedItemOrRange,
                                            .IsChangeOfEndpoint) ''False))

            End If ''End of ""If (.AnchorToPrecedeItemOrRange IsNot Nothing) Then ... Else..."

            ''Added 12/28/2023
            If (.IsChangeOfEndpoint) Then
                ''In the 50% chance the starting item is affected...
                ''#1 1/20/2024 td mod_firstTwoChar = mod_list.DLL_GetFirstItem()
                ''#2 1/20/2024 mod_firstItem = mod_list.DLL_GetFirstItem()
                mod_firstItem = mod_list.DLL_GetItemAtIndex(0)

            End If ''End of ""If (.IsChangeOfEndpoint) Then""

        End With ''End of ""With par_operationV1""

        ''Record the operation
        If (par_bRecordOperation) Then ''Added 1/28/2024 

            RecordNewestOperation(par_operationV1)

        End If ''ENd of ""If (par_bRecordOperation) Then""

    End Sub ''End of ""Public Sub ProcessOperation_MoveRange""


    Private Sub RecordNewestOperation(par_newOpV1 As DLL_OperationV1)
        ''
        ''Added 1/01/2024
        ''
        If (par_newOpV1.CreatedAsUndoOperation) Then
            ''Process the Undo Operation.
            ''---mod_intCountOperations -= 1
            ''1/13/24 mod_intCountOperations = 0
            ''1/13/24 mod_lastPriorOpV1 = Nothing ''Clear the last operation.

            ''Added 1/02/2024
            ''1/13/24 If (0 < mod_stackOperations.Count()) Then
            ''    mod_lastPriorOpV1 = mod_stackOperations.Pop()
            ''End If ''Edn of ""If (0 < mod_stackOperations.Count()) Then""
            Debugger.Break()

        ElseIf (par_newOpV1.CreatedAsUndoOperation) Then
            ''Added 1/16/2024
            Debugger.Break()

        ElseIf (mod_firstPriorOperationV1 Is Nothing) Then
            ''
            ''This is the first recorded operation.
            ''
            mod_firstPriorOperationV1 = par_newOpV1
            mod_lastPriorOperationV1 = par_newOpV1
            mod_intCountOperations = 1
            mod_opRedoMarker = New DLL_OperationsRedoMarker(mod_firstPriorOperationV1)

        Else
            ''Increase the count of operations.
            mod_intCountOperations += 1

            ''Added 1/2/2024 
            ''If (mod_lastPriorOpV1 IsNot Nothing) Then
            ''    mod_stackOperations.Append(mod_lastPriorOpV1)
            ''End If ''End of ""If (mod_lastPriorOpV1 IsNot Nothing) Then""

            ''---mod_stackOperations.Append(par_lastPriorOpV1)
            ''1/13/24  mod_stackOperations.Push(par_lastPriorOpV1)

            ''---- SLIGHTLY DIFFICULT AND CONFUSING---------------
            ''
            Dim tempRef_penultimateOpV1 As DLL_OperationV1 ''Penultimate is "next to last". Temporary reference variable.
            Dim tempRef_ultimateOpV1 As DLL_OperationV1 ''Ultimate is "very last". Temporary reference variable.

            tempRef_penultimateOpV1 = mod_lastPriorOperationV1 ''The former last item.
            tempRef_ultimateOpV1 = par_newOpV1 ''The brand-new last item.

            If (tempRef_penultimateOpV1 Is Nothing) Then
                ''We either haven't collected an operation before this present function call,
                ''  or we have somehow "dispensed" with all of our recorded 
                ''  operations. --1/15/2024
            Else
                tempRef_penultimateOpV1.DLL_SetItemNext(tempRef_ultimateOpV1)
                tempRef_ultimateOpV1.DLL_SetItemPrior(tempRef_penultimateOpV1)
            End If ''If (tempRef_penultimateOpV1 Is Nothing) Then... Else...

            ''112014 mod_lastPriorOpV1 = par_lastPriorOpV1
            mod_lastPriorOperationV1 = tempRef_ultimateOpV1 ''Save tempRef_ultimateOpV1.

            ''Update the redo marker. 
            mod_opRedoMarker.ShiftMarker_DueToNewOperation(par_newOpV1)

        End If ''End of ""If (par_lastPriorOpV1.CreatedAsUndoOperation) Then... Else..."

        ''With LabelNumOperations
        ''    LabelNumOperations.Text = String.Format(.Tag, mod_intCountOperations)
        ''End With
        ''Added 1/03/2024 
        ''RefreshTheUI_OperationsCount()

    End Sub ''End of ""Private Sub RecordNewestOperation()""


    Private Sub UndoOfPriorOperation_AnyType() ''par_opRedoMarker As DLL_OperationsRedoMarker)
        ''
        ''Added 1/10/2024 thomas downes
        ''
        Dim intCountFurtherUndos As Integer
        Dim operationToUndo As DLL_OperationV1

        If (mod_opRedoMarker.HasOperationPrior()) Then
            ''
            ''Great, we will be able to do the "Undo" operation.
            ''
        Else
            MessageBoxTD.Show_Statement("No Undo operation is in queue.") ''1/15/24
            Exit Sub
        End If ''If (par_opRedoMarker.HasOperationPrior()) Then... else

        intCountFurtherUndos = (1 + mod_opRedoMarker.GetCurrentIndex_Undo())

        If (0 = intCountFurtherUndos) Then

            ''Added 1/10/2024 
            MessageBoxTD.Show_Statement("Sorry, no more (recorded) operations remain to Undo.")

        Else
            ''
            '' Undo the operation which is the RedoMarker's currently-designated
            ''   Undo operation.
            ''
            operationToUndo = mod_opRedoMarker.GetCurrentOp_Undo()

            ''Major call!!
            UndoOperation_ViaInverseOf(operationToUndo)

            ''Major call!!  --1/10/2024
            mod_opRedoMarker.ShiftMarker_AfterUndo_ToPrior()

            ''''
            ''''Refresh the Display.  (Make the Insert visible to the user.)
            ''''
            ''RefreshTheUI_DisplayList()

            ''''Added 1/03/2024
            ''RefreshTheUI_OperationsCount()

        End If ''End of ""If (0 = intCountOpsInStack) Then ... Else..."

    End Sub ''Public Sub UndoOfPriorOperation_AnyType


    Public Sub UndoOfSpecificOperationType(par_typeOfOp As Char, par_wordForOperation As String)
        ''--Private Sub UndoOfDelete_NoParams() Handles UserControlOperation1.UndoOfDelete_NoParams
        ''
        ''Encapsulated 1/3/2024 
        ''
        Dim eachOperationType As Char
        Dim bFoundDesiredOperationTypeOnStack As Boolean = False
        ''Dim bNotDone As Boolean = True
        Dim bCompletedWhileLoop As Boolean = False
        Dim eachOperation As DLL_OperationV1
        Dim each_boolIsOfSpecifiedType As Boolean

        If (mod_firstPriorOperationV1 Is Nothing) Then
            MessageBoxTD.Show_Statement("Sorry!!", "No operations are found.")
            Exit Sub
        End If

        Dim largestIndex As Integer ''= (-1 + mod_stackOperations.Count())
        largestIndex = -1 + mod_firstPriorOperationV1.DLL_CountItemsAllInList()

        ''Dim eachIndex As Integer = largestIn dex ''(-1 + mod_stackOperations.Count())
        Dim currentMarkerIndex_Redo As Integer = mod_opRedoMarker.GetCurrentIndex_Redo()
        Dim currentMarkerIndex_Undo As Integer = mod_opRedoMarker.GetCurrentIndex_Undo()

        ''
        ''Step #1 of 2.  Does the relevant operation type exist on the stack? 
        ''
        bFoundDesiredOperationTypeOnStack = mod_opRedoMarker.HasTypeOfOperation_Prior(par_typeOfOp)

        ''
        ''Step #2 of 2.  Execute "Undo" for all operations, down to & including
        ''   the largest-index Delete operation. 
        ''
        If (bFoundDesiredOperationTypeOnStack) Then
            ''
            ''Pop off the intervening operations, until we reach
            ''  the desired operation.
            ''
            ''1/15/2024 For eachIndex = largestIndex To index_ofDeleteOperation
            ''    ''---eachOperation = mod_stackOperations.ElementAt(eachIndex)
            ''    eachOperation = mod_stackOperations.Pop()
            ''    ''Major call!!
            ''    UndoOperation_ViaInverseOf(eachOperation)
            ''    RefreshTheUI_OperationsCount()
            ''Next eachIndex

            bCompletedWhileLoop = False ''Initialize.
            While (Not bCompletedWhileLoop) ''While bNotDone
                ''
                ''Look for an operation of the specified type (par_typeOfOp).
                ''
                eachOperation = mod_opRedoMarker.GetMarkersPrior_ShiftPositionLeft()
                UndoOperation_ViaInverseOf(eachOperation)
                eachOperationType = eachOperation.OperationType
                each_boolIsOfSpecifiedType = (eachOperationType = par_typeOfOp)
                If each_boolIsOfSpecifiedType Then ''If each_isDelete Then
                    bFoundDesiredOperationTypeOnStack = True
                    bCompletedWhileLoop = True
                Else
                    bCompletedWhileLoop = eachOperation.DLL_NotAnyPrior()
                End If ''END OF "'If each_isDelete Then... Else..."

            End While ''ENd of ""While Not bCompletedWhile""

            ''
            ''Refresh the Display.  (Make the Insert visible to the user.)
            ''
            ''RefreshTheUI_DisplayList()
            ''
            ''''Added 1/03/2024
            ''RefreshTheUI_OperationsCount()

        Else
            ''
            ''Added 1/3/2024
            ''
            ''#1 1/4/2024 MessageBoxTD.Show_Statement("Sorry, no Delete operations are found on the Stack!!")
            '' #2 1/4/2024 MessageBoxTD.Show_Formatting("Sorry, no {0} operations are found on the Stack!!",
            ''                           par_wordForOperation)
            MessageBoxTD.Show_InsertWordFormat_Line1(par_wordForOperation,
                        "Sorry, no {0} operations are found on the Stack!!")

        End If ''ENd of ""If (bFoundDeleteOperationOnStack) Then""


    End Sub ''End of ""Private Sub UndoOfSpecificOperationType()""



    Private Sub UndoOperation_ViaInverseOf(parOperation As DLL_OperationV1)
        ''
        ''Added 1/03/2024 td
        ''
        Dim opType As Char
        Dim inverse_opType As Char
        Const ENCAPSULATE As Boolean = True ''Added 1/15/2024
        Const RECORD_OPERATION As Boolean = False ''Added 1/28/2024 

        If (ENCAPSULATE) Then
            ''Added 1/15/2024
            Dim opUndoVersion As DLL_OperationV1 ''Added 11/5/2024
            opUndoVersion = parOperation.GetUndoVersionOfOperation()
            ''Added 1/31/2024
            opUndoVersion.CheckEndpointsAreClean(True, True, False, True)
            ''Major call!!
            ProcessOperation_AnyType(opUndoVersion,
                                     opUndoVersion.IsChangeOfEndpoint,
                                     RECORD_OPERATION)

        Else
            opType = parOperation.OperationType
            ''Added 2/5/2024 
            ''   "S" is for "Sorting". 
            If (opType = "S"c) Then inverse_opType = "S"c
            If (opType = "I"c) Then inverse_opType = "D"c '' "D" is for "Delete"
            If (opType = "D"c) Then inverse_opType = "I"c '' "I" is for "Insert"
            If (opType = "M"c) Then inverse_opType = "M"c '' "M" is for "Move" 

            Select Case inverse_opType
                Case "S"c
                    ''Sorting by Undo-Queue
                    ProcessOperation_Sort(parOperation, RECORD_OPERATION, True)

                Case "I"c
                    ''Insert (the inverse of Delete)
                    ProcessOperation_Insert(parOperation.GetUndoVersionOfOperation(),
                                            parOperation.IsChangeOfEndpoint,
                                            par_bRecordOperation:=False)

                Case "D"c
                    ''Delete (the inverse of Insert)
                    ProcessOperation_Delete(parOperation.GetUndoVersionOfOperation(),
                                            parOperation.IsChangeOfEndpoint,
                                            par_bRecordOperation:=False)
                Case "M"c
                    ''Move Range (the inverse of Move Range)
                    ProcessOperation_MoveRange(parOperation.GetUndoVersionOfOperation(),
                                            parOperation.IsChangeOfEndpoint,
                                            par_bRecordOperation:=False)
                Case Else
                    Debugger.Break()

            End Select ''End of ""Select Case inverse_opType""

        End If ''END OF ""If (ENCAPSULATE) Then... Else..."

    End Sub ''End of ""Private Sub UndoOperation_ViaInverseOf(eachOperation As DLL_OperationV1)""



End Class
