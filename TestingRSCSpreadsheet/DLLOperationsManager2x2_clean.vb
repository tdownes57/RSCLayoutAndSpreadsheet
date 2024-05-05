Imports ciBadgeInterfaces
Imports ciBadgeSerialize

Public Class DLLOperationsManager2x2_clean(Of T_DoublyLinkedItemH As IDoublyLinkedItem,
                                         T_DoublyLinkedItemV As IDoublyLinkedItem)

    Private mod_firstItemHoriz As T_DoublyLinkedItemH
    Private mod_firstItemVerti As T_DoublyLinkedItemV

    Private mod_charTypeH As Char = "C"c '' C for Columns (Horizontal) C = RSCFieldColumnV2
    Private mod_charTypeV As Char = "R"c '' R for Rows (Vertical)      R = RSCRowHeaderV2

    Private ReadOnly mod_listHoriz As IDoublyLinkedList(Of T_DoublyLinkedItemH)
    Private ReadOnly mod_listVerti As IDoublyLinkedList(Of T_DoublyLinkedItemV)

    Private mod_firstPriorOperationV1 As DLL_OperationV1
    Private mod_lastPriorOperationV1 As DLL_OperationV1
    Private mod_opRedoMarker As DLL_OperationsRedoMarker
    Private mod_intCountOperations As Integer = 0


    Public Sub New(par_listH As IDoublyLinkedList(Of T_DoublyLinkedItemH),
                   par_listV As IDoublyLinkedList(Of T_DoublyLinkedItemV),
                   pbIncludeLoadOperations As Boolean,
                   Optional par_initialOperationV1_1of2 As DLL_OperationV1 = Nothing,
                   Optional par_initialOperationV1_2of2 As DLL_OperationV1 = Nothing)

        mod_listHoriz = par_listH
        mod_listVerti = par_listV

        ''
        ''Check the ClassType Character, to make sure it's been specified
        ''   as one ClassType or the other.
        ''
        ''   C = RSCFieldColumnV2
        ''   R = RSCRowHeaderV2
        ''
        If (par_initialOperationV1_1of2 IsNot Nothing) Then
            With par_initialOperationV1_1of2
                Select Case (.ClassTypeToChar)
                    Case mod_charTypeH
                    Case mod_charTypeV
                    Case Else
                        Debugger.Break()
                End Select
            End With
        End If

        If (par_initialOperationV1_2of2 IsNot Nothing) Then
            With par_initialOperationV1_2of2
                Select Case (.ClassTypeToChar)
                    Case mod_charTypeH
                    Case mod_charTypeV
                    Case Else
                        Debugger.Break()
                End Select
            End With
        End If

        mod_firstPriorOperationV1 = par_initialOperationV1_1of2
        mod_lastPriorOperationV1 = par_initialOperationV1_2of2

        ''  Connect the two operations to each other.
        If (mod_lastPriorOperationV1 Is Nothing) Then
            If (pbIncludeLoadOperations) Then
                Debugger.Break()
            End If
        Else
            mod_firstPriorOperationV1.DLL_SetItemNext(mod_lastPriorOperationV1)
            mod_lastPriorOperationV1.DLL_SetItemPrior(mod_firstPriorOperationV1)
        End If

        ''Initialize the Redo Marker to the most recent operation. ---3/2024 
        If (par_initialOperationV1_2of2 Is Nothing) Then
            If (pbIncludeLoadOperations) Then
                Debugger.Break()
            Else
                ''Load operations are --NOT-- being included for potential Undo requests.
            End If
        Else
            ''
            ''Set the Redo marker. 
            ''
            mod_opRedoMarker = New DLL_OperationsRedoMarker(par_initialOperationV1_2of2)

        End If

    End Sub


    Public Function GetFirstItemH() As T_DoublyLinkedItemH

        Return mod_firstItemHoriz

    End Function


    Public Function GetFirstItemV() As T_DoublyLinkedItemV

        Return mod_firstItemVerti

    End Function


    Public Function CountOfOperations() As Integer

        Dim intCountOps As Integer
        intCountOps = mod_firstPriorOperationV1.DLL_CountItemsAllInList
        Return intCountOps

    End Function


    Public Function MarkerHasOperationPrior() As Boolean

        Dim result_hasPrior As Boolean
        result_hasPrior =
             mod_opRedoMarker.HasOperationPrior()
        Return result_hasPrior

    End Function


    Public Function MarkerHasOperationNext() As Boolean

        Dim result_hasNext As Boolean
        result_hasNext =
            mod_opRedoMarker.HasOperationNext()
        Return result_hasNext

    End Function


    Public Sub RedoMarkedOperation(pbIsHoriz As Boolean, pbIsVerti As Boolean)

        Dim opReDo As DLL_OperationV1
        opReDo =
            mod_opRedoMarker.GetMarkersNext_ShiftPositionRight()

        opReDo.CreatedAsRedoOperation = True

        ProcessOperation_AnyType(opReDo, opReDo.IsChangeOfEndpoint,
                    par_bRecordOperation:=False, pbIsHoriz, pbIsVerti)

    End Sub


    Public Sub UndoMarkedOperation()
        UndoOfPriorOperation_AnyType()

    End Sub



    Public Sub ProcessOperation_AnyType(parOperation As DLL_OperationV1,
                                       par_changeOfEndpoint As Boolean,
                                        par_bRecordOperation As Boolean,
                                        pbIsHoriz As Boolean,
                                        pbIsVerti As Boolean)
        Dim opType As Char
        opType = parOperation.OperationType

        Select Case opType
            Case "I"c
                ''Insert (the inverse of Delete)
                ProcessOperation_Insert(parOperation, par_changeOfEndpoint, par_bRecordOperation)

            Case "D"c
                ''Delete (the inverse of Insert)
                ProcessOperation_Delete(parOperation, par_changeOfEndpoint,
                                        par_bRecordOperation, pbIsHoriz, pbIsVerti)
            Case "M"c
                ''Move Range (the inverse of Move Range)
                ProcessOperation_MoveRange(parOperation, par_changeOfEndpoint,
                                           par_bRecordOperation, pbIsHoriz, pbIsVerti)

            Case Else
                Debugger.Break()
        End Select


    End Sub



    Public Sub ProcessOperation_Insert(ByVal par_operationV1 As DLL_OperationV1,
                                       ByVal par_changeOfEndpoint As Boolean,
                                       ByVal par_bRecordOperation As Boolean) ''1/2024 ,
        '' C = Columns, a Horizontal List
        '' R = Row Headers, a Vertical List
        ''
        Dim bHorizont As Boolean
        Dim bVertical As Boolean
        bHorizont = (par_operationV1.IsClassTypeByChar("C"c)) '' C = Columns, a Horizontal List
        bVertical = (par_operationV1.IsClassTypeByChar("R"c)) '' R = Row Headers, a Vertical List
        ProcessOperation_Insert_HorV(par_operationV1,
                                     par_changeOfEndpoint,
                                     par_bRecordOperation,
                                     bHorizont, bVertical)

    End Sub


    Public Sub ProcessOperation_Insert_HorV(ByVal par_operationV1 As DLL_OperationV1,
                                            ByVal pbIsHoriz As Boolean,
                                            ByVal pbIsVerti As Boolean,
                                       ByVal par_changeOfEndpoint As Boolean,
                                       ByVal par_bRecordOperation As Boolean)

        With par_operationV1

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
                    If (pbIsHoriz) Then
                        ''
                        Dim objSingleItemH As T_DoublyLinkedItemH ''Added 4/8/2024 
                        Dim objAnchorPrecedingH As T_DoublyLinkedItemH ''Added 4/8/2024 
                        objSingleItemH = CType(.InsertItemSingly, T_DoublyLinkedItemH)
                        objAnchorPrecedingH = .AnchorToPrecedeItemOrRange ''--.DLL_UnboxControl()

                        mod_listHoriz.DLL_InsertOneItemAfter(objSingleItemH,
                                            objAnchorPrecedingH,
                                            .IsChangeOfEndpoint)

                    ElseIf (pbIsVerti) Then
                        ''
                        Dim objSingleItemVerti As T_DoublyLinkedItemV
                        Dim objSingleItemHoriz_TESTING As T_DoublyLinkedItemH
                        Dim objAnchorPrecedingV As T_DoublyLinkedItemV

                        objSingleItemVerti = CType(.InsertItemSingly, T_DoublyLinkedItemV)
                        objAnchorPrecedingV = .AnchorToPrecedeItemOrRange

                        Const c_bPassTObjects As Boolean = False
                        Const c_bPassInterfaces As Boolean = False

                        If (c_bPassTObjects) Then ''Added 5/3/2024
                            mod_listVerti.DLL_InsertOneItemAfter(objSingleItemVerti,
                                            objAnchorPrecedingV,
                                            .IsChangeOfEndpoint)
                        ElseIf (c_bPassInterfaces) Then
                            mod_listVerti.DLL_InsertOneItemAfter(.InsertItemSingly,
                                            .AnchorToPrecedeItemOrRange,
                                            .IsChangeOfEndpoint)
                        End If

                    End If

                ElseIf (.InsertRangeStart IsNot Nothing) Then
                    ''
                    ''Insert a range of items, either the Horizontal or the Vertical list.
                    ''
                    Select Case (True)
                        Case (pbIsHoriz)
                            mod_listHoriz.DLL_InsertRangeAfter(.InsertRangeStart,
                                            .InsertCount, .AnchorToPrecedeItemOrRange,
                                            .IsChangeOfEndpoint)
                        Case (pbIsVerti)
                            mod_listVerti.DLL_InsertRangeAfter(.InsertRangeStart,
                                            .InsertCount, .AnchorToPrecedeItemOrRange,
                                            .IsChangeOfEndpoint)
                        Case Else
                            Debugger.Break()
                    End Select

                End If


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
                    Select Case True
                        Case pbIsHoriz
                            mod_listHoriz.DLL_InsertOneItemBefore(.InsertItemSingly,
                                            .AnchorToSucceedItemOrRange,
                                            .IsChangeOfEndpoint) ''False))
                        Case pbIsVerti
                            mod_listVerti.DLL_InsertOneItemBefore(.InsertItemSingly,
                                            .AnchorToSucceedItemOrRange,
                                            .IsChangeOfEndpoint) ''False))
                        Case Else
                            Debugger.Break()
                    End Select

                ElseIf (.InsertRangeStart IsNot Nothing) Then
                    ''Insert a range of items. 
                    Select Case True
                        Case pbIsHoriz
                            mod_listHoriz.DLL_InsertRangeBefore(.InsertRangeStart, .InsertCount,
                                                    .AnchorToSucceedItemOrRange,
                                                    .IsChangeOfEndpoint) ''False)
                        Case pbIsVerti
                            mod_listVerti.DLL_InsertRangeBefore(.InsertRangeStart, .InsertCount,
                                                    .AnchorToSucceedItemOrRange,
                                                    .IsChangeOfEndpoint) ''False)
                        Case Else
                            Debugger.Break()
                    End Select

                Else
                    Debugger.Break()

                End If


            ElseIf (mod_firstItemHoriz Is Nothing) Then
                ''
                ''Empty list !!!!
                ''
                ''  We are populating an empty list, or as one might say,
                ''  inserting a range into an empty list. 
                ''
                Select Case True
                    Case (pbIsHoriz And .InsertItemSingly IsNot Nothing)
                        ''Insert a single item, into an empty list.   (Horizontal)
                        mod_listHoriz.DLL_InsertRangeEmptyList(.InsertItemSingly, 1)

                    Case (pbIsHoriz And .InsertRangeStart IsNot Nothing)
                        ''Insert a range of items, into an empty list. (Horizontal)
                        mod_listHoriz.DLL_InsertRangeEmptyList(.InsertRangeStart, .InsertCount)

                    Case (pbIsVerti And .InsertItemSingly IsNot Nothing)
                        ''Insert a single item, into an empty list. (Vertical) 
                        mod_listHoriz.DLL_InsertRangeEmptyList(.InsertItemSingly, 1)

                    Case (pbIsVerti And .InsertRangeStart IsNot Nothing)
                        ''Insert a range of items, into an empty list. 
                        mod_listVerti.DLL_InsertRangeEmptyList(.InsertRangeStart, .InsertCount)

                    Case (pbIsVerti And .InsertRangeStart IsNot Nothing)
                        ''Insert a range of items, into an empty list. 
                        mod_listVerti.DLL_InsertRangeEmptyList(.InsertRangeStart, .InsertCount)

                    Case Else
                        Debugger.Break()
                End Select ''End of ""If (.InsertItemSingly IsNot Nothing) Then... ElseIf... Else"

                ''Be sure to save the first item.
                If (pbIsHoriz) Then mod_firstItemHoriz = mod_listHoriz.DLL_GetItemAtIndex(0)
                If (pbIsVerti) Then mod_firstItemVerti = mod_listVerti.DLL_GetItemAtIndex(0)

            End If

            If (.IsChangeOfEndpoint) Then
                ''In the 50% chance the starting item is affected...
                If (pbIsHoriz) Then mod_firstItemHoriz = mod_listHoriz.DLL_GetItemAtIndex(0)
                If (pbIsVerti) Then mod_firstItemVerti = mod_listVerti.DLL_GetItemAtIndex(0)

            End If

        End With ''End of ""With par_operationV1""

        If (par_bRecordOperation) Then

            RecordNewestOperation(par_operationV1)

        End If


    End Sub


    Public Sub ProcessOperation_Delete(ByVal par_operationV1 As DLL_OperationV1,
                                       ByVal par_changeOfEndpoint As Boolean,
                                       ByVal par_bRecordOperation As Boolean,
                                       ByVal pbHorizont As Boolean,
                                       ByVal pbVertical As Boolean)
        ''
        ''   Version #1 (DLL_OperationV1) exposes more things than Version #2.
        ''
        Dim firstItemInList As IDoublyLinkedItem

        If (pbHorizont) Then firstItemInList = CType(mod_firstItemHoriz, IDoublyLinkedItem)
        If (pbVertical) Then firstItemInList = CType(mod_firstItemVerti, IDoublyLinkedItem)

        With par_operationV1

            Dim bChangeOfEndpoint As Boolean
            Dim objDeleteRangeStart As TwoCharacterDLLItem
            Dim objDeleteRangeEndpt As TwoCharacterDLLItem

            If (.DeleteItemSingly IsNot Nothing) Then
                ''Only a single item is being deleted. 
            Else
                ''A range of items is being deleted. 
                objDeleteRangeStart = .DeleteRangeStart
                objDeleteRangeEndpt = .DeleteRangeStart.DLL_GetItemNext(-1 + .DeleteCount)
            End If ''End of ""If (.DeleteItemSingly IsNot Nothing) Then... Else..."

            bChangeOfEndpoint = par_changeOfEndpoint

            If (.DeleteItemSingly IsNot Nothing) Then
                ''Conditioned by If (...) 
                If (pbHorizont) Then mod_listHoriz.DLL_DeleteItem(.DeleteItemSingly, bChangeOfEndpoint)
                If (pbVertical) Then mod_listVerti.DLL_DeleteItem(.DeleteItemSingly, bChangeOfEndpoint)

            ElseIf (.DeleteRangeStart IsNot Nothing) Then
                ''
                If (pbHorizont) Then mod_listHoriz.DLL_DeleteRange(.DeleteRangeStart, .DeleteCount,
                                  bChangeOfEndpoint, .DeleteRangeEnd_Null)
                If (pbVertical) Then mod_listVerti.DLL_DeleteRange(.DeleteRangeStart, .DeleteCount,
                                  bChangeOfEndpoint, .DeleteRangeEnd_Null)

            Else
                ''
                Debugger.Break()

            End If

            If (bChangeOfEndpoint) Then
                If (pbHorizont) Then mod_firstItemHoriz = mod_listHoriz.DLL_GetItemAtIndex(0)
                If (pbVertical) Then mod_firstItemVerti = mod_listVerti.DLL_GetItemAtIndex(0)
            End If

        End With

        ''
        ''Admin, if requested.
        ''
        If (par_bRecordOperation) Then

            RecordNewestOperation(par_operationV1)

        End If

    End Sub


    Public Sub ProcessOperation_MoveRange(ByVal par_operationV1 As DLL_OperationV1,
                                       ByVal par_changeOfEndpoint As Boolean,
                                          ByVal par_bRecordOperation As Boolean) ''1/2024 ,
        ''
        Dim bHorizont As Boolean
        Dim bVertical As Boolean

        bHorizont = (par_operationV1.IsClassTypeByChar("C"c))
        bVertical = (par_operationV1.IsClassTypeByChar("R"c))

        ProcessOperation_MoveRange(par_operationV1, par_changeOfEndpoint,
                              par_bRecordOperation,
                               bHorizont, bVertical)

    End Sub


    Private Sub ProcessOperation_MoveRange(ByVal par_operationV1 As DLL_OperationV1,
                                       ByVal par_changeOfEndpoint As Boolean,
                                          ByVal par_bRecordOperation As Boolean,
                                          ByVal pbHorizont As Boolean,
                                          ByVal pbVertical As Boolean) ''1/2024 ,

        With par_operationV1
            ''
            ''Step 1 of 2.  Cut (via "Delete") the range from the list. 
            ''
            If (pbHorizont) Then mod_listHoriz.DLL_DeleteRange(.MovedRangeStart, .MovedCount,
                                            .IsChangeOfEndpoint) ''False)
            If (pbVertical) Then mod_listVerti.DLL_DeleteRange(.MovedRangeStart, .MovedCount,
                                            .IsChangeOfEndpoint) ''False)

            If (Testing.TestingByDefault) Then
                ''Test that the ends are CLEAN OF REFERENCES.
                Dim firstItem As IDoublyLinkedItem = .MovedRangeStart
                Dim lastItem As IDoublyLinkedItem = .MovedRangeStart.DLL_GetItemNext(-1 + .MovedCount)
                ''Test that the ends are CLEAN OF REFERENCES.
                If (firstItem.DLL_HasPrior()) Then Debugger.Break()
                If (lastItem.DLL_HasNext()) Then Debugger.Break()
            End If

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
                Select Case True
                    Case pbHorizont
                        mod_listHoriz.DLL_InsertRangeAfter(.MovedRangeStart, .MovedCount,
                                                    .AnchorToPrecedeItemOrRange,
                                                    .IsChangeOfEndpoint)
                    Case pbHorizont
                        mod_listVerti.DLL_InsertRangeAfter(.MovedRangeStart, .MovedCount,
                                                    .AnchorToPrecedeItemOrRange,
                                                    .IsChangeOfEndpoint)
                    Case Else
                        Debugger.Break()
                End Select

            Else
                ''Move operational item(s) BEFORE anchoring item.
                ''
                ''              Move 2_3_4 before 6, the terminating anchor.
                ''                   |
                ''          1 2_3_4 5 6 7 8 9 10
                '' Result:  1 5 2_3_4 6 7 8 9 10
                ''
                Select Case True
                    Case pbHorizont
                        mod_listHoriz.DLL_InsertRangeBefore(.MovedRangeStart, .MovedCount,
                                                    .AnchorToSucceedItemOrRange,
                                                    .IsChangeOfEndpoint)
                    Case pbVertical
                        mod_listVerti.DLL_InsertRangeBefore(.MovedRangeStart, .MovedCount,
                                                    .AnchorToSucceedItemOrRange,
                                                    .IsChangeOfEndpoint)
                    Case Else
                        Debugger.Break()
                End Select

            End If

            If (.IsChangeOfEndpoint) Then
                ''In the 50% chance the starting item is affected...
                If (pbHorizont) Then mod_firstItemHoriz = mod_listHoriz.DLL_GetItemAtIndex(0)
                If (pbVertical) Then mod_firstItemVerti = mod_listVerti.DLL_GetItemAtIndex(0)

            End If

        End With

        ''Record the operation
        If (par_bRecordOperation) Then

            RecordNewestOperation(par_operationV1)

        End If

    End Sub


    Private Sub RecordNewestOperation(par_newOpV1 As DLL_OperationV1)
        ''
        If (par_newOpV1.CreatedAsUndoOperation) Then
            ''Process the Undo Operation.
            Debugger.Break()

        ElseIf (par_newOpV1.CreatedAsUndoOperation) Then
            ''
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

            mod_lastPriorOperationV1 = tempRef_ultimateOpV1 ''Save tempRef_ultimateOpV1.

            ''Update the redo marker. 
            mod_opRedoMarker.ShiftMarker_DueToNewOperation(par_newOpV1)

        End If

    End Sub


    Private Sub UndoOfPriorOperation_AnyType()
        ''
        Dim intCountFurtherUndos As Integer
        Dim operationToUndo As DLL_OperationV1

        If (mod_opRedoMarker.HasOperationPrior()) Then
            ''
            ''Great, we will be able to do the "Undo" operation.
            ''
        Else
            MessageBoxTD.Show_Statement("No Undo operation is in queue.")
            Exit Sub
        End If ''If (par_opRedoMarker.HasOperationPrior()) Then... else

        intCountFurtherUndos = (1 + mod_opRedoMarker.GetCurrentIndex_Undo())

        If (0 = intCountFurtherUndos) Then

            MessageBoxTD.Show_Statement("Sorry, no more (recorded) operations remain to Undo.")

        Else
            ''
            '' Undo the operation which is the RedoMarker's currently-designated
            ''   Undo operation.
            ''
            operationToUndo = mod_opRedoMarker.GetCurrentOp_Undo()

            ''Major call!!
            UndoOperation_ViaInverseOf(operationToUndo)

            ''Major call!!  
            mod_opRedoMarker.ShiftMarker_AfterUndo_ToPrior()

        End If

    End Sub


    Public Sub UndoOfSpecificOperationType(par_typeOfOp As Char, par_wordForOperation As String)
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

            End While

        Else
            ''
            MessageBoxTD.Show_InsertWordFormat_Line1(par_wordForOperation,
                        "Sorry, no {0} operations are found on the Stack!!")

        End If


    End Sub


    Private Sub UndoOperation_ViaInverseOf(parOperation As DLL_OperationV1,
                                           pbIsHoriz As Boolean, pbIsVerti As Boolean)
        ''
        Dim opType As Char
        Dim inverse_opType As Char
        Const ENCAPSULATE As Boolean = True
        Const RECORD_OPERATION As Boolean = False

        If (ENCAPSULATE) Then
            Dim opUndoVersion As DLL_OperationV1
            opUndoVersion = parOperation.GetUndoVersionOfOperation()
            opUndoVersion.CheckEndpointsAreClean(True, True, False, True)
            ''Major call!!
            ProcessOperation_AnyType(opUndoVersion,
                                     opUndoVersion.IsChangeOfEndpoint,
                                     RECORD_OPERATION, pbIsHoriz, pbIsVerti)

        Else
            opType = parOperation.OperationType
            If (opType = "I"c) Then inverse_opType = "D"c
            If (opType = "D"c) Then inverse_opType = "I"c
            If (opType = "M"c) Then inverse_opType = "M"c

            Select Case inverse_opType
                Case "I"c
                    ''Insert (the inverse of Delete)
                    ProcessOperation_Insert(parOperation.GetUndoVersionOfOperation(),
                                            parOperation.IsChangeOfEndpoint, False)

                Case "D"c
                    ''Delete (the inverse of Insert)
                    ProcessOperation_Delete(parOperation.GetUndoVersionOfOperation(),
                                            parOperation.IsChangeOfEndpoint, False,
                                            pbIsHoriz, pbIsVerti)
                Case "M"c
                    ''Move Range (the inverse of Move Range)
                    ProcessOperation_MoveRange(parOperation.GetUndoVersionOfOperation(),
                                            parOperation.IsChangeOfEndpoint, False)
                Case Else
                    Debugger.Break()

            End Select

        End If

    End Sub

End Class

