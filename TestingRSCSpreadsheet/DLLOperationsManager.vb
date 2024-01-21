''
''Added 1/18/2024
''
Imports ciBadgeInterfaces

''' <summary>
''' Will process and record V1 operations. 
''' </summary>
''' <typeparam name="TDoublyLinkedItem"></typeparam>
Public Class DLLOperationsManager(Of T_DoublyLinkedItem)

    ''Added 1/18/2024
    Private mod_firstItem As T_DoublyLinkedItem
    Private mod_list As IDoublyLinkedList(Of T_DoublyLinkedItem)
    Private mod_firstPriorOperationV1 As DLL_OperationV1
    Private mod_lastPriorOperationV1 As DLL_OperationV1

    Public Sub New(par_list As IDoublyLinkedList(Of T_DoublyLinkedItem),
                   Optional par_firstOperationV1 As DLL_OperationV1 = Nothing)
        ''
        ''Added 1/20/2024 thomas d.
        ''
        mod_list = par_list
        ''mod_firstItem = par_firstItem
        mod_firstPriorOperationV1 = par_firstOperationV1
        mod_lastPriorOperationV1 = par_firstOperationV1

    End Sub ''End of ""Public Sub New""  


    Public Function GetFirstItem() As T_DoublyLinkedItem

        ''Added 1/20/2024 td 
        Return mod_firstItem

    End Function ''ENd of ""Public Function GetFirstItem()""



    Public Sub ProcessOperation_Insert(par_operationV1 As DLL_OperationV1,
                                       par_changeOfEndpoing As Boolean) ''1/2024 ,
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
        ''    RecordNewestOperation(par_operationV1)
        ''
        ''    ''Added 1/03/2024
        ''    RefreshTheUI_OperationsCount()
        ''
        ''End If ''end of ""If (par_bIncludePostOpAdmin) Then""

    End Sub ''End of "Public Sub ProcessOperation_Insert"


    Public Sub ProcessOperation_Delete(ByVal par_operationV1 As DLL_OperationV1,
                                       ByVal par_changeOfEndpoint As Boolean) ''1/2024 ,

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
        ''    RecordNewestOperation(par_operationV1)
        ''
        ''    ''Added 1/03/2024
        ''    RefreshTheUI_OperationsCount()
        ''  
        ''End If ''ENd of ""If (par_bIncludePostOpAdmin) Then""

    End Sub ''End of ""Public Sub ProcessOperation_Delete""


    Public Sub ProcessOperation_MoveRange(par_operationV1 As DLL_OperationV1) ''1/2024 ,
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


    End Sub ''End of ""Public Sub ProcessOperation_MoveRange""



End Class
