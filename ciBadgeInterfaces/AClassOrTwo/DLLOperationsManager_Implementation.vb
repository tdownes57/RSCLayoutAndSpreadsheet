''
''Added 11/14/2023 td
''
Partial Public Class DLL_OperationsManager ''This module is Partial, i.e.
    ''   extends a sister class module.  11/2023 '' _Implementation
    Implements IDoublyLinkedList
    ''
    ''Added 11/14/2023 td
    ''
    Public Sub DLL_InsertItemAfter(toBeInserted As IDoublyLinkedItem,
                                   toUseAsAnchor As IDoublyLinkedItem) Implements IDoublyLinkedList.DLL_InsertItemAfter
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        If (mod_modeColumnNotRow) Then

            mod_listColumns.DLL_InsertItemAfter(toBeInserted, toUseAsAnchor)

        Else

            mod_listRowHeaders.DLL_InsertItemAfter(toBeInserted, toUseAsAnchor)

        End If ''End of ""If (mod_modeColumnNotRow) Then... Else..."

        ''
        ''Operations Management 
        ''
        mod_lastPriorOperation = New DLL_Operation()
        With mod_lastPriorOperation
            .InsertSingly = toBeInserted
            .OperationType = "I"
            .LefthandAnchor = toUseAsAnchor
        End With

    End Sub ''End of ""Public Sub DLL_InsertItemAfter""


    Public Sub DLL_InsertItemBefore(toBeInserted As IDoublyLinkedItem,
                                    toUseAsAnchor As IDoublyLinkedItem) Implements IDoublyLinkedList.DLL_InsertItemBefore
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        mod_list.DLL_InsertItemBefore(toBeInserted, toUseAsAnchor)

        ''
        ''Operations Management 
        ''
        mod_lastPriorOperation = New DLL_Operation()
        With mod_lastPriorOperation
            .InsertSingly = toBeInserted
            .OperationType = "I"
            .RighthandAnchor = toUseAsAnchor
        End With

    End Sub


    Public Sub DLL_InsertRangeAfter(toBeInsertedFirst As IDoublyLinkedItem, toBeInsertedCount As Integer,
                                    toUseAsAnchorStart As IDoublyLinkedItem) Implements IDoublyLinkedList.DLL_InsertRangeAfter
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        mod_list.DLL_InsertRangeAfter(toBeInsertedFirst, toBeInsertedCount, toUseAsAnchorStart)

        ''
        ''Operations Management 
        ''
        mod_lastPriorOperation = New DLL_Operation()
        With mod_lastPriorOperation
            .InsertRangeStart = toBeInsertedFirst
            .OperationType = "I"
            .LefthandAnchor = toUseAsAnchorStart
        End With

    End Sub ''End Of ""Public Sub DLL_InsertRangeAfter""


    Public Sub DLL_DeleteItemSingly(item_toDelete As IDoublyLinkedItem) Implements IDoublyLinkedList.DLL_DeleteItemSingly
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


    Public Sub DLL_DeleteRange(item_toDeleteBegin As IDoublyLinkedItem,
                               item_toDeleteEndInclusive As IDoublyLinkedItem,
                               yes_return_list_of_deleteds As Boolean,
                               ByRef count_of_deleteds As Integer,
                               ByRef item_prior_undeleted As IDoublyLinkedItem,
                               ByRef item_first_deleted As IDoublyLinkedItem) _
                               Implements IDoublyLinkedList.DLL_DeleteRange
        ''
        ''This should set four(4) directional links (not just two(2))
        ''


    End Sub


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

    Public Function DLL_BuildListToIndex(index As Integer) As IDoublyLinkedItem Implements IDoublyLinkedList.DLL_BuildListToIndex
        Throw New NotImplementedException()
    End Function

    Public Function DLL_BuildListToIndex(index As Integer, ByRef count_of_new_items As Integer) As IDoublyLinkedItem Implements IDoublyLinkedList.DLL_BuildListToIndex
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
