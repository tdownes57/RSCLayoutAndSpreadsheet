''
''Added 11/14/2023 td
''

''-----------------------------------------------------------
''  Please see CIBadgeDesigner / Classes RSC / RSC_DLL_OperationsManager.
''
''    ---12/07/2023 thomas dow_nes 
''-----------------------------------------------------------
Imports System.CodeDom.Compiler

Partial Public Class DLL_OperationsManager_SeeCIBadgeDesigner ''This module is Partial, i.e.
    ''   extends a sister class module.  11/2023 '' _Implementation
    Implements IDoublyLinkedList
    ''
    ''Added 11/14/2023 td
    ''
    Private Const ADMIN_FOR_UNDOS As Boolean = True ''Added 11/17/2023


    Public Sub DLL_Insert1ItemAfter(ByVal ptoBeInserted As IDoublyLinkedItem,
                                    ByVal ptoUseAsAnchor As IDoublyLinkedItem,
                                    ByVal pisEitherEndpoint As Boolean) Implements IDoublyLinkedList.DLL_Insert1ItemAfter
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        RaiseMessageIfModeNotRefreshed()

        ''Added 12/24/2023
        Dim bIsEitherEndpoint As Boolean ''Added 12/24/2023
        ''12/2023 bIsEitherEndpoint = toUseAsAnchor.DLL_IsEitherEndpoint()
        bIsEitherEndpoint = pisEitherEndpoint

        If (mod_modeColumnNotRow) Then

            mod_listColumns.DLL_InsertOneItemAfter(ptoBeInserted, ptoUseAsAnchor, bIsEitherEndpoint)

        Else

            ''12/24/2023 td''mod_listRowHeaders.DLL_InsertOneItemAfter(toBeInserted, toUseAsAnchor)
            mod_listRowHeaders.DLL_InsertOneItemAfter(ptoBeInserted, ptoUseAsAnchor, bIsEitherEndpoint)

        End If ''End of ""If (mod_modeColumnNotRow) Then... Else..."

        ''
        ''Operations Management 
        ''
        ''//mod_lastPriorOperation = New DLL_Operation()
        ''mod_operationLastPrior = New DLL_Operation()
        ''With mod_operationLastPrior
        ''    ''.InsertSingly = toBeInserted
        ''    .ItemInsertSingly = toBeInserted
        ''    .OperationType = "I"
        ''    ''.LefthandAnchor = toUseAsAnchor
        ''    .AnchorToPrecedeItemOrRange = toUseAsAnchor
        ''End With
        mod_operationLastPrior = New DLL_OperationV1_Deprecated("I"c,
                   ptoBeInserted, 1, ptoUseAsAnchor, Nothing)

    End Sub ''End of ""Public Sub DLL_InsertItemAfter""


    Public Sub DLL_Insert1ItemBefore(ByVal ptoBeInserted As IDoublyLinkedItem,
                                     ByVal ptoUseAsAnchor As IDoublyLinkedItem,
                                     ByVal pisForEitherEndpoint As Boolean) Implements IDoublyLinkedList.DLL_Insert1ItemBefore
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        RaiseMessageIfModeNotRefreshed()

        ''Added 12/24/2023
        Dim bIsForEitherEndpoint As Boolean ''12/24/2023
        ''12/24/2023 bIsForEitherEndpoint = ptoUseAsAnchor.DLL_IsEitherEndpoint()
        bIsForEitherEndpoint = pisForEitherEndpoint

        If (mod_modeColumnNotRow) Then
            ''Spreadsheet columns.
            mod_listColumns.DLL_InsertOneItemBefore(ptoBeInserted, ptoUseAsAnchor, bIsForEitherEndpoint)
        Else
            ''Spreadsheet rows.
            mod_listRowHeaders.DLL_InsertOneItemBefore(ptoBeInserted, ptoUseAsAnchor, bIsForEitherEndpoint)
        End If

        ''
        ''Operations Management 
        ''
        ''Modularized! Const ADMIN_FOR_UNDOS As Boolean = True ''Added 11/17/2023    

        Dim objOperationNew As DLL_OperationV1_Deprecated '' New DLL_Operation()
        If (ADMIN_FOR_UNDOS) Then
            ''With objOperationNew ''mod_lastPriorOperation
            ''    .InsertSingly = toBeInserted
            ''    .OperationType = "I"
            ''    .AnchorToSucceedItemOrRange = toUseAsAnchor
            ''End With
            ''mod_operationLastPrior = objOperationNew

            objOperationNew = New DLL_OperationV1_Deprecated("I"c, ptoBeInserted, 1, Nothing, ptoUseAsAnchor)

            ''
            ''Record/store this operation. 
            ''
            ManageNewOperation(objOperationNew)

        End If ''End of ""If (ADMIN_FOR_UNDOS) Then""

    End Sub



    Public Sub DLL_InsertRangeAfter(ByVal toBeInsertedFirst As IDoublyLinkedItem,
                                    ByVal toBeInsertedCount As Integer,
                                    ByVal toUseAsAnchorPreceding As IDoublyLinkedItem,
                                    ByVal pisEitherEndpoint As Boolean) _
                                    Implements IDoublyLinkedList.DLL_InsertRangeAfter
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        If (mod_modeColumnNotRow) Then
            ''
            '' Columns!!!
            ''
            mod_listColumns.DLL_InsertRangeAfter(toBeInsertedFirst, toBeInsertedCount, toUseAsAnchorPreceding,
                                    pisEitherEndpoint)

        Else
            ''
            '' Rows!!!
            ''
            mod_listRowHeaders.DLL_InsertRangeAfter(toBeInsertedFirst, toBeInsertedCount, toUseAsAnchorPreceding,
                                    pisEitherEndpoint)

        End If ''ENd of ""If (mod_modeColumnNotRow) Then... Else..."

        ''
        ''Operations Management 
        ''
        Const ADMIN_FOR_UNDOS As Boolean = True ''Added 11/17/2023
        Dim objOperationNew As New DLL_OperationV1_Deprecated()
        If (ADMIN_FOR_UNDOS) Then
            ''mod_lastPriorOperation = New DLL_Operation()
            With objOperationNew
                .ModeColumns_notRows = mod_modeColumnNotRow
                .ModeRows____notCols = mod_modeRowNotColumn ''Added 4/08/2024
                .InsertRangeStart = toBeInsertedFirst
                .OperationType = "I"
                ''.LefthandAnchor = toUseAsAnchorStart
                ''12/17/2023 .AnchorLeftPrior = toUseAsAnchorPreceding
                .AnchorToPrecedeItemOrRange = toUseAsAnchorPreceding
            End With
            ''
            ''Record/store this operation. 
            ''
            ManageNewOperation(objOperationNew)

        End If ''END OF ""If (ADMIN_FOR_UNDOS) Then""


        ''Encapsulated 11/2023 
        ''If (mod_operation1stRecord Is Nothing) Then
        ''    ''The very first record is both first & last. 
        ''    mod_operation1stRecord = objOperationNew
        ''    mod_operationLastPrior = objOperationNew
        ''    ''---Not needed here. 11/2023
        ''    ''---mod_operationMarkUndoNext = objOperationNew
        ''Else
        ''    Dim tempLastPrior As DLL_Operation = mod_operationLastPrior
        ''    ''Make sure we can travel foreward in the sequence of operations!
        ''    mod_operationLastPrior.DLL_SetItemNext(objOperationNew)
        ''    ''Make sure we can "start undoing" this & prior operations. 
        ''    mod_operationLastPrior = objOperationNew
        ''    ''Make sure we can travel backward in the sequence of operations!
        ''    objOperationNew.DLL_SetItemPrior(tempLastPrior)
        ''
        ''End If ''End of ""If (mod_operation1stRecord Is Nothing) Then... Else...""

    End Sub ''End Of ""Public Sub DLL_InsertRangeAfter""


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="toBeInsertedFirst">This is the first item in the range.</param>
    ''' <param name="toBeInsertedCount">How many items in the range of items to be inserted.</param>
    ''' <param name="toUseAsAnchorTerminal">Must already be in the list, not the range. This will be the end-cap.</param>
    Public Sub DLL_InsertRangeBefore(ByVal toBeInsertedFirst As IDoublyLinkedItem, toBeInsertedCount As Integer,
                                    ByVal toUseAsAnchorTerminal As IDoublyLinkedItem,
                                    ByVal pisForEitherEndpoint As Boolean) _
                                    Implements IDoublyLinkedList.DLL_InsertRangeBefore
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        If (mod_modeColumnNotRow) Then
            ''
            '' Columns!!!
            ''
            mod_listColumns.DLL_InsertRangeBefore(toBeInsertedFirst, toBeInsertedCount,
                                                  toUseAsAnchorTerminal, pisForEitherEndpoint)
        Else
            ''
            '' Rows!!!
            ''
            mod_listRowHeaders.DLL_InsertRangeBefore(toBeInsertedFirst, toBeInsertedCount,
                                                     toUseAsAnchorTerminal, pisForEitherEndpoint)
        End If ''ENd of ""If (mod_modeColumnNotRow) Then... Else..."

        ''
        ''Operations Manag ement 
        ''
        Const ADMIN_FOR_UNDOS As Boolean = True ''Added 11/17/2023
        If (ADMIN_FOR_UNDOS) Then
            ''mod_lastPriorOperation = New DLL_Operation()
            Dim objOperationNew As New DLL_OperationV1_Deprecated()
            With objOperationNew
                .ModeColumns_notRows = mod_modeColumnNotRow
                .ModeRows____notCols = mod_modeRowNotColumn ''Added 4/8/2024 td
                .InsertRangeStart = toBeInsertedFirst
                .OperationType = "I"
                ''.AnchorLeftPrior = toUseAsAnchorStart
                .AnchorToSucceedItemOrRange = toUseAsAnchorTerminal
            End With

            ''
            ''Record/store this operation. 
            ''
            ManageNewOperation(objOperationNew)

        End If ''END OF ""If (ADMIN_FOR_UNDOS) Then""

    End Sub ''End Of ""Public Sub DLL_InsertRangeAfter""


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="item_toDelete"></param>
    ''' <param name="ref_itemUndeleted_Preceding">This must be recorded for Undo.</param>
    ''' <param name="ref_itemUndeleted_Suceeding">This must be recorded for Undo.</param>
    Public Sub DLL_DeleteItemSingly(ByVal item_toDelete As IDoublyLinkedItem,
                             ByRef ref_itemUndeleted_Preceding As IDoublyLinkedItem,
                             ByRef ref_itemUndeleted_Suceeding As IDoublyLinkedItem) _
        Implements IDoublyLinkedList.DLL_DeleteItemSingly
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        ''Is this sort of casting possible??  Probably not!!
        ''   (Impossible, since was are casting from parent to adult-child.)
        ''   (In contrast, it is permissible to cast from adult-child to parent. 
        ''   (I call it "adult-child" since it contains MORE knowledge than the parent... LOL)   
        ''
        ''11/2/2023  Dim rsc_toDelete = CType(item_toDelete, TControl)
        ''11/2/2023  Dim rsc_prior = CType(rsc_toDelete.DLL_ItemPrior, TControl)
        ''11/2/2023  Dim rsc_next = CType(rsc_toDelete.DLL_ItemNext, TControl)

        ''rsc_prior.DLL_SetNextAs(rsc_next)
        ''rsc_next.DLL_SetPriorAs(rsc_prior)

    End Sub


    Public Sub DLL_DeleteRange_NotUsed(item_toDeleteBegin As IDoublyLinkedItem,
                               item_toDeleteEndInclusive As IDoublyLinkedItem,
                               yes_return_list_of_deleteds As Boolean,
                               ByRef ref_count_of_deleteds As Integer,
                               ByRef ref_prior_undeleted As IDoublyLinkedItem,
                               ByRef ref_first_deleted As IDoublyLinkedItem) _
                               Implements IDoublyLinkedList.DLL_DeleteRange_NotUsed
        ''
        ''This should set four(4) directional links (not just two(2))
        ''


    End Sub ''End of "Public Sub DLL_DeleteRange_NotUsed" 


    Public Sub DLL_DeleteRange_Simpler(ByVal p_item_toDeleteBegin As IDoublyLinkedItem,
                               ByVal p_count_of_deleteds As Integer,
                                       ByVal p_isForEitherEndpoint As Boolean,
                               ByRef pref_item_prior_undeleted As IDoublyLinkedItem,
                               ByRef pref_item_next_undeleted As IDoublyLinkedItem) _
                               Implements IDoublyLinkedList.DLL_DeleteRange_Simpler
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        ''
        ''Will likely be needed for "UnDo" operation!!
        ''
        Dim item_ToDeleteLastItem As IDoublyLinkedItem ''Added 12/24/2023
        Dim recordDeleteLocation_ItemPrior As IDoublyLinkedItem ''Administrative!!
        Dim recordDeleteLocation_ItemNext As IDoublyLinkedItem ''Administrative!!
        Dim bNothingIsPrior As Boolean

        bNothingIsPrior = (p_item_toDeleteBegin.DLL_NotAnyPrior())
        pref_item_prior_undeleted = p_item_toDeleteBegin.DLL_GetItemPrior

        ''Added 12/24/2023
        item_ToDeleteLastItem = p_item_toDeleteBegin.DLL_GetItemNext(-1 + p_count_of_deleteds)
        recordDeleteLocation_ItemPrior = p_item_toDeleteBegin.DLL_GetItemPrior()
        recordDeleteLocation_ItemNext = item_ToDeleteLastItem.DLL_GetItemNext()

        ''
        ''Operations Management (Administrative)
        ''
        If (ADMIN_FOR_UNDOS) Then
            ''Will likely be needed for "UnDo" operation!!
            With p_item_toDeleteBegin
                If (bNothingIsPrior) Then
                    ''We can't go above/left/prior. So,
                    ''  get the next. 
                    recordDeleteLocation_ItemNext = .DLL_GetItemNext(p_count_of_deleteds)
                Else
                    ''Will likely be needed for "UnDo" operation!!
                    recordDeleteLocation_ItemPrior = p_item_toDeleteBegin.DLL_GetItemPrior()
                End If ''En dof ""If (bNothingIsPrior) Then... Else..."
            End With ''With p_item_toDeleteBegin
        End If ''ENd of ""If (ADMIN_FOR_UNDOS) Then""


        If (mod_modeColumnNotRow) Then
            ''
            '' Columns!!!
            ''
            ''12/2023 mod_listColumns.DLL_DeleteRange_Simpler(p_item_toDeleteBegin, p_count_of_deleteds,
            mod_listColumns.DLL_DeleteRange(p_item_toDeleteBegin, p_count_of_deleteds,
                                                    p_isForEitherEndpoint)
            ''12/2023 td                            pref_item_prior_undeleted,
            ''12/2023 td                            pref_item_next_undeleted)
        Else
            ''
            '' Rows!!!
            ''
            ''12/2023 mod_listRowHeaders.DLL_DeleteRange_Simpler(p_item_toDeleteBegin, p_count_of_deleteds,
            mod_listRowHeaders.DLL_DeleteRange(p_item_toDeleteBegin, p_count_of_deleteds,
                                                    p_isForEitherEndpoint)
            ''12/2023 td                            pref_item_prior_undeleted,
            ''12/2023 td                            pref_item_next_undeleted)
        End If ''ENd of ""If (mod_modeColumnNotRow) Then... Else..."

        ''
        ''Operations Management (Administrative)
        ''
        If (ADMIN_FOR_UNDOS) Then
            ''mod_lastPriorOperation = New DLL_Operation()
            Dim objOperationNew As New DLL_OperationV1_Deprecated()
            With objOperationNew
                .OperationType = "D"

                ''Modified 4/08/2024
                .ModeColumns_notRows = mod_modeColumnNotRow
                .ModeRows____notCols = mod_modeRowNotColumn ''Added 4/8/2024

                .DeleteRangeStart = p_item_toDeleteBegin
                .DeleteCount = p_count_of_deleteds

                ''------------ADMINISTRATIVE, POSSIBLY CONFUSING--------
                ''Deletes (considered in isolation) probably don't need anchor(s). The range
                '' ... range provides the anchor(s).  However, to undo the delete later,
                '' ... we probably need the anchor.  ---11/25/2023
                '' #1 11/2023 .AnchorLeftPrior = toUseAsAnchorStart
                '' #2 11/2023 .AnchorToSucceedItemOrRange = toUseAsAnchorTerminal
                .DeleteLocation_ItemPriorToItemOrRange = recordDeleteLocation_ItemPrior
                .DeleteLocation_ItemNextToItemOrRange = recordDeleteLocation_ItemNext
                ''------------END ADMINISTRATIVE, POSSIBLY CONFUSING--------

            End With ''With objOperationNew

            ''
            ''Record/store this operation. 
            ''
            ManageNewOperation(objOperationNew)

        End If ''END OF ""If (ADMIN_FOR_UNDOS) Then""

    End Sub ''End of "Public Sub DLL_DeleteRange" 


    ''Public Sub DLL_SetNextAs(toBeNext As IDoublyLinkedItem) Implements IDoublyLinkedList ''(Of TControl).DLL_SetNextAs
    ''    ''
    ''    ''This is simple. It should set two(2) directional links (not four(4))
    ''    ''
    ''    Dim rsc_toBeNext = CType(toBeNext, TControl)
    ''    Me.mod_itemNext = rsc_toBeNext ''Directional Link #1 of 2
    ''    ''11/2/2023 rsc_toBeNext.DLL_SetPriorAs(Me) ''Directional Link #2 of 2
    ''End Sub

    ''Public Sub DLL_SetPriorAs(toBePrior As TControl) Implements IDoublyLinkedList(Of TControl).DLL_SetPriorAs
    ''    ''
    ''    ''This is simple. It should set two(2) directional links (not four(4))
    ''    ''
    ''    Dim rsc_toBePrior = CType(toBePrior, TControl)
    ''    Me.mod_itemPrior = rsc_toBePrior ''Directional Link #1 of 2
    ''    ''11/2/2023 rsc_toBePrior.DLL_SetNextAs(Me) ''Directional Link #2 of 2
    ''End Sub


    ''Public Function DLL_ItemNext() As TControl Implements IDoublyLinkedList(Of TControl).DLL_ItemNext
    ''    ''
    ''    ''It is permissible to cast from adult-child to parent. 
    ''    ''
    ''    '' (I call it "adult child" since it contains MORE knowledge than the parent... LOL)   
    ''    ''
    ''    Return mod_itemNext ''Implicit casting (from adult-child to parent)
    ''End Function


    ''Public Function DLL_ItemPrior() As TControl Implements IDoublyLinkedList(Of TControl).DLL_ItemPrior
    ''    Return mod_itemPrior ''Implicit casting (from adult-child to parent)
    ''End Function


    Public Function DLL_GetItemAtIndex(index As Integer) As IDoublyLinkedItem Implements IDoublyLinkedList.DLL_GetItemAtIndex ''(Of IDoublyLinkedItem).DLL_GetItemAtIndex
        Throw New NotImplementedException()
    End Function

    Public Function DLL_GetItemAtIndex(index As Integer, confirm_distance As Integer) As IDoublyLinkedItem Implements IDoublyLinkedList.DLL_GetItemAtIndex ''(Of TControl).DLL_GetItemAtIndex
        Throw New NotImplementedException()
    End Function

    Public Function DLL_GetIndexOfItem(input_item As IDoublyLinkedItem) As Integer Implements IDoublyLinkedList.DLL_GetIndexOfItem ''(Of TControl).DLL_GetIndexOfItem
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountItemsBefore() As Integer Implements IDoublyLinkedList.DLL_CountItemsBefore ''(Of TControl).DLL_CountItemsBefore
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountItemsAfter() As Integer Implements IDoublyLinkedList.DLL_CountItemsAfter ''(Of TControl).DLL_CountItemsAfter
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountAllItems() As Integer Implements IDoublyLinkedList.DLL_CountAllItems ''(Of TControl).DLL_CountAllItems
        Throw New NotImplementedException()
    End Function

    Public Function DLL_BuildListToIndex_Denigrated(index As Integer) As IDoublyLinkedItem _
            Implements IDoublyLinkedList.DLL_BuildListToIndex_Denigrated
        Throw New NotImplementedException()
    End Function

    Public Function DLL_BuildListToIndex_Denigrated(index As Integer, ByRef count_of_new_items As Integer) As IDoublyLinkedItem _
            Implements IDoublyLinkedList.DLL_BuildListToIndex_Denigrated
        Throw New NotImplementedException()
    End Function

    Public Function DLL_PopItem(item_toDelete As IDoublyLinkedItem) As IDoublyLinkedItem Implements IDoublyLinkedList.DLL_PopItem
        Throw New NotImplementedException()
    End Function

    Public Function DLL_PopItem(index As Integer) As IDoublyLinkedItem Implements IDoublyLinkedList.DLL_PopItem
        Throw New NotImplementedException()
    End Function

    Public Function DLL_PopRange(indexStart As Integer, countOfItemsToPop As Integer) As IDoublyLinkedItem Implements IDoublyLinkedList.DLL_PopRange
        Throw New NotImplementedException()
    End Function


End Class
