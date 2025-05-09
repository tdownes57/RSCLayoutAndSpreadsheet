﻿Imports ciBadgeInterfaces

''' <summary>
''' This is an abstract class which implements ciBadgeInterfaces.IDoublyLinkedList(Of RSCListItem) 
''' </summary>
Public Class RSCListItem
    Inherits Control
    Implements ciBadgeInterfaces.IDoublyLinkedList(Of RSCListItem)

    ''General question, is this sort of casting possible??  Probably not!!
    ''
    ''   (Impossible, since was are casting from parent to adult-child.)
    ''   (In contrast, yes it is permissible to cast from adult-child to parent. 
    ''   (I call it "adult-child" since it contains MORE knowledge than the parent... LOL)   
    ''
    ''   Dim rsc_item = CType(item_RSCListItemToDelete, RSCListItem)
    ''
    Private mod_itemNext As RSCListItem
    Private mod_itemPrior As RSCListItem

    ''Public Sub DLL_InsertItemAfter(toBeInserted As RSCListItem, toUseAsAnchor As RSCListItem) Implements IDoublyLinkedList(Of RSCListItem).DLL_InsertItemAfter
    ''    ''
    ''    ''This should set four(4) directional links (not just two(2))
    ''    ''
    ''    Throw New NotImplementedException()
    ''End Sub

    ''Public Sub DLL_InsertItemAfter(toBeInserted As RSCListItem) Implements IDoublyLinkedList(Of RSCListItem).DLL_InsertItemAfter
    ''    ''
    ''    ''This should set four(4) directional links (not just two(2))
    ''    ''
    ''    Throw New NotImplementedException()
    ''End Sub

    ''Public Sub DLL_InsertItemBefore(toBeInserted As RSCListItem, toUseAsAnchor As RSCListItem) Implements IDoublyLinkedList(Of RSCListItem).DLL_InsertItemBefore
    ''    ''
    ''    ''This should set four(4) directional links (not just two(2))
    ''    ''
    ''    Throw New NotImplementedException()
    ''End Sub

    ''Public Sub DLL_InsertItemBefore(toBeInserted As RSCListItem) Implements IDoublyLinkedList(Of RSCListItem).DLL_InsertItemBefore
    ''    ''
    ''    ''This should set four(4) directional links (not just two(2))
    ''    ''
    ''    Throw New NotImplementedException()
    ''End Sub

    ''Public Sub DLL_InsertRangeAfter(toBeInsertedFirst As RSCListItem, toBeInsertedCount As Integer, toUseAsAnchorStart As RSCListItem) Implements IDoublyLinkedList(Of RSCListItem).DLL_InsertRangeAfter
    ''    ''
    ''    ''This should set four(4) directional links (not just two(2))
    ''    ''
    ''    Throw New NotImplementedException()
    ''End Sub

    Public Sub DLL_InsertRangeAfter(toBeInsertedRange_FirstItem As RSCListItem, toBeInsertedRange_ItemCount As Integer, toUseAsAnchor_Preceding As RSCListItem, isChangeOfEndPoint As Boolean,
                                   Optional item_endRange_null As RSCListItem = Nothing) Implements IDoublyLinkedList(Of RSCListItem).DLL_InsertRangeAfter

        Throw New NotImplementedException()

    End Sub

    ''Public Sub DLL_DeleteItem(item_toDelete As RSCListItem) Implements IDoublyLinkedList(Of RSCListItem).DLL_DeleteItem
    ''    ''
    ''    ''This should set four(4) directional links (not just two(2))
    ''    ''
    ''    ''Is this sort of casting possible??  Probably not!!
    ''    ''   (Impossible, since was are casting from parent to adult-child.)
    ''    ''   (In contrast, it is permissible to cast from adult-child to parent. 
    ''    ''   (I call it "adult-child" since it contains MORE knowledge than the parent... LOL)   
    ''    ''
    ''    Dim rsc_toDelete = CType(item_toDelete, RSCListItem)
    ''    Dim rsc_prior = CType(rsc_toDelete.DLL_ItemPrior, RSCListItem)
    ''    Dim rsc_next = CType(rsc_toDelete.DLL_ItemNext, RSCListItem)

    ''    rsc_prior.DLL_SetNextAs(rsc_next)
    ''    rsc_next.DLL_SetPriorAs(rsc_prior)

    ''End Sub

    Public Sub DLL_DeleteItem(item_toDelete As RSCListItem, isChangeOfEndPoint As Boolean) Implements IDoublyLinkedList(Of RSCListItem).DLL_DeleteItem
        Throw New NotImplementedException()
    End Sub

    ''Public Sub DLL_DeleteRange(item_toDeleteBegin As RSCListItem, item_toDeleteEndInclusive As RSCListItem, yes_return_list_of_deleteds As Boolean, ByRef count_of_deleteds As Integer, ByRef item_prior_undeleted As RSCListItem, ByRef item_first_deleted As RSCListItem) Implements IDoublyLinkedList(Of RSCListItem).DLL_DeleteRange
    ''    ''
    ''    ''This should set four(4) directional links (not just two(2))
    ''    ''
    ''End Sub


    ''Public Sub DLL_SetNextAs(toBeNext As RSCListItem) Implements IDoublyLinkedList(Of RSCListItem).DLL_SetNextAs
    ''    ''
    ''    ''This is simple. It should set two(2) directional links (not four(4))
    ''    ''
    ''    Dim rsc_toBeNext = CType(toBeNext, RSCListItem)
    ''
    ''    Me.mod_itemNext = rsc_toBeNext ''Directional Link #1 of 2
    ''    rsc_toBeNext.DLL_SetPriorAs(Me) ''Directional Link #2 of 2
    ''
    ''End Sub

    ''Public Sub DLL_SetPriorAs(toBePrior As RSCListItem) Implements IDoublyLinkedList(Of RSCListItem).DLL_SetPriorAs
    ''    ''
    ''    ''This is simple. It should set two(2) directional links (not four(4))
    ''    ''
    ''    Dim rsc_toBePrior = CType(toBePrior, RSCListItem)
    ''
    ''    Me.mod_itemPrior = rsc_toBePrior ''Directional Link #1 of 2
    ''    rsc_toBePrior.DLL_SetNextAs(Me) ''Directional Link #2 of 2
    ''
    ''End Sub

    Public Sub DLL_InsertOneItemAfter(toBeInsertedSingleItem As RSCListItem, toUseAsAnchor_ItemPrior As RSCListItem, isChangeOfEndPoint As Boolean) Implements IDoublyLinkedList(Of RSCListItem).DLL_InsertOneItemAfter
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_InsertOneItemBefore(toBeInsertedSingleItem As RSCListItem, toUseAsAnchor_ItemNext As RSCListItem, isChangeOfEndPoint As Boolean) Implements IDoublyLinkedList(Of RSCListItem).DLL_InsertOneItemBefore
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_InsertRangeBefore(toBeInsertedRange_FirstItem As RSCListItem, toBeInsertedRange_ItemCount As Integer, toUseAsAnchor_Terminating As RSCListItem, isChangeOfEndPoint As Boolean, Optional item_endRange_null As RSCListItem = Nothing) Implements IDoublyLinkedList(Of RSCListItem).DLL_InsertRangeBefore
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_DeleteRange_Simpler(item_toDeleteBegin As RSCListItem, count_of_deleteds As Integer, isChangeOfEndPoint As Boolean, Optional item_endRange_null As RSCListItem = Nothing) Implements IDoublyLinkedList(Of RSCListItem).DLL_DeleteRange '' .DLL_DeleteRange_Simpler
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_InsertRangeEmptyList(toBeInsertedRange_FirstItem As RSCListItem, toBeInsertedRange_ItemCount As Integer) Implements IDoublyLinkedList(Of RSCListItem).DLL_InsertRangeEmptyList
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_ClearAllItems() Implements IDoublyLinkedList(Of RSCListItem).DLL_ClearAllItems
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_AddFirstAndOnlyItem(item_toAdd As RSCListItem) Implements IDoublyLinkedList(Of RSCListItem).DLL_AddFirstAndOnlyItem
        Throw New NotImplementedException()
    End Sub

    ''Public Function DLL_ItemNext() As RSCListItem Implements IDoublyLinkedList(Of RSCListItem).DLL_ItemNext
    ''    ''
    ''    ''It is permissible to cast from adult-child to parent. 
    ''    ''
    ''    '' (I call it "adult child" since it contains MORE knowledge than the parent... LOL)   
    ''    ''
    ''    Return mod_itemNext ''Implicit casting (from adult-child to parent)
    ''
    ''End Function


    ''Public Function DLL_ItemPrior() As RSCListItem Implements IDoublyLinkedList(Of RSCListItem).DLL_ItemPrior
    ''
    ''    Return mod_itemPrior ''Implicit casting (from adult-child to parent)
    ''
    ''End Function


    Public Function DLL_GetItemAtIndex(index As Integer) As RSCListItem Implements IDoublyLinkedList(Of RSCListItem).DLL_GetItemAtIndex
        Throw New NotImplementedException()
    End Function

    Public Function DLL_GetItemAtIndex(index As Integer, confirm_distance As Integer) As RSCListItem Implements IDoublyLinkedList(Of RSCListItem).DLL_GetItemAtIndex
        Throw New NotImplementedException()
    End Function

    Public Function DLL_GetIndexOfItem(input_item As RSCListItem) As Integer Implements IDoublyLinkedList(Of RSCListItem).DLL_GetIndexOfItem
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountItemsBefore() As Integer Implements IDoublyLinkedList(Of RSCListItem).DLL_CountItemsBefore
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountItemsAfter() As Integer Implements IDoublyLinkedList(Of RSCListItem).DLL_CountItemsAfter
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountAllItems() As Integer Implements IDoublyLinkedList(Of RSCListItem).DLL_CountAllItems
        Throw New NotImplementedException()
    End Function

    Public Function DLL_BuildListToIndex_DEPRECATED(index As Integer) As RSCListItem Implements IDoublyLinkedList(Of RSCListItem).DLL_BuildListToIndex_DEPRECATED
        Throw New NotImplementedException()
    End Function

    Public Function DLL_BuildListToIndex_DEPRECATED(index As Integer, ByRef count_of_new_items As Integer) As RSCListItem Implements IDoublyLinkedList(Of RSCListItem).DLL_BuildListToIndex_DEPRECATED
        Throw New NotImplementedException()
    End Function

    Public Function DLL_PopItem(item_toDelete As RSCListItem) As RSCListItem Implements IDoublyLinkedList(Of RSCListItem).DLL_PopItem
        Throw New NotImplementedException()
    End Function

    Public Function DLL_PopItem(index As Integer) As RSCListItem Implements IDoublyLinkedList(Of RSCListItem).DLL_PopItem
        Throw New NotImplementedException()
    End Function

    Public Function DLL_PopRange(indexStart As Integer, countOfItemsToPop As Integer) As RSCListItem Implements IDoublyLinkedList(Of RSCListItem).DLL_PopRange
        Throw New NotImplementedException()
    End Function

    Public Function DLL_GetLastItem() As RSCListItem Implements IDoublyLinkedList(Of RSCListItem).DLL_GetLastItem
        Throw New NotImplementedException()
    End Function

    Public Function DLL_IsListEmpty() As Boolean Implements IDoublyLinkedList(Of RSCListItem).DLL_IsListEmpty
        Throw New NotImplementedException()
    End Function
End Class
