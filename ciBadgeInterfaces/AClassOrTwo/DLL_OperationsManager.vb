''//
''//  Added 10/30/2023 t h o m a s d o w n e s  
''//
Public Class DLL_OperationsManager ''11/2/2023 (Of TControl)
    Implements IDoublyLinkedList
    ''11/2/2023 Implements IDoublyLinkedList(Of TControl)

    ''Private mod_list As RSCDoublyLinkedList(Of TControl)
    ''11/2/2023 Private mod_list As List(Of TControl)
    Private mod_list As RSCDoublyLinkedList

    Public Sub ProcessOperation(param_operation As DLL_Operation) ''11/2/2023 TControl))




    End Sub

    Public Function GetLastOperation()

    End Function

    ''General question, is this sort of casting possible??  Probably not!!
    ''
    ''   (Impossible, since was are casting from parent to adult-child.)
    ''   (In contrast, yes it is permissible to cast from adult-child to parent. 
    ''   (I call it "adult-child" since it contains MORE knowledge than the parent... LOL)   
    ''
    ''   Dim rsc_item = CType(item_TControlToDelete, TControl)
    ''
    Private mod_itemNext As IDoublyLinkedItem ''11/2/2023  TControl
    Private mod_itemPrior As IDoublyLinkedItem ''11/2/2023   TControl

    Public Sub DLL_InsertItemAfter(toBeInserted As IDoublyLinkedItem,
                                   toUseAsAnchor As IDoublyLinkedItem) Implements IDoublyLinkedList.DLL_InsertItemAfter
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_InsertItemAfter(toBeInserted As IDoublyLinkedItem) Implements IDoublyLinkedList.DLL_InsertItemAfter
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_InsertItemBefore(toBeInserted As IDoublyLinkedItem,
                                    toUseAsAnchor As IDoublyLinkedItem) Implements IDoublyLinkedList.DLL_InsertItemBefore
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_InsertItemBefore(toBeInserted As IDoublyLinkedItem) Implements IDoublyLinkedList.DLL_InsertItemBefore
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_InsertRangeAfter(toBeInsertedFirst As IDoublyLinkedItem, toBeInsertedCount As Integer, toUseAsAnchorStart As TControl) Implements IDoublyLinkedList(Of TControl).DLL_InsertRangeAfter
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        Throw New NotImplementedException()
    End Sub


    Public Sub DLL_DeleteItem(item_toDelete As IDoublyLinkedItem) Implements IDoublyLinkedList.DLL_DeleteItem
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
                               ByRef item_prior_undeleted As TControl,
                               ByRef item_first_deleted As TControl) Implements IDoublyLinkedList.DLL_DeleteRange
        ''
        ''This should set four(4) directional links (not just two(2))
        ''


    End Sub


    Public Sub DLL_SetNextAs(toBeNext As TControl) Implements IDoublyLinkedList(Of TControl).DLL_SetNextAs
        ''
        ''This is simple. It should set two(2) directional links (not four(4))
        ''
        Dim rsc_toBeNext = CType(toBeNext, TControl)

        Me.mod_itemNext = rsc_toBeNext ''Directional Link #1 of 2
        ''11/2/2023 rsc_toBeNext.DLL_SetPriorAs(Me) ''Directional Link #2 of 2

    End Sub

    Public Sub DLL_SetPriorAs(toBePrior As TControl) Implements IDoublyLinkedList(Of TControl).DLL_SetPriorAs
        ''
        ''This is simple. It should set two(2) directional links (not four(4))
        ''
        Dim rsc_toBePrior = CType(toBePrior, TControl)

        Me.mod_itemPrior = rsc_toBePrior ''Directional Link #1 of 2
        ''11/2/2023 rsc_toBePrior.DLL_SetNextAs(Me) ''Directional Link #2 of 2

    End Sub


    Public Function DLL_ItemNext() As TControl Implements IDoublyLinkedList(Of TControl).DLL_ItemNext
        ''
        ''It is permissible to cast from adult-child to parent. 
        ''
        '' (I call it "adult child" since it contains MORE knowledge than the parent... LOL)   
        ''
        Return mod_itemNext ''Implicit casting (from adult-child to parent)

    End Function


    Public Function DLL_ItemPrior() As TControl Implements IDoublyLinkedList(Of TControl).DLL_ItemPrior

        Return mod_itemPrior ''Implicit casting (from adult-child to parent)

    End Function


    Public Function DLL_GetItemAtIndex(index As Integer) As TControl Implements IDoublyLinkedList(Of TControl).DLL_GetItemAtIndex
        Throw New NotImplementedException()
    End Function

    Public Function DLL_GetItemAtIndex(index As Integer, confirm_distance As Integer) As TControl Implements IDoublyLinkedList(Of TControl).DLL_GetItemAtIndex
        Throw New NotImplementedException()
    End Function

    Public Function DLL_GetIndexOfItem(input_item As TControl) As Integer Implements IDoublyLinkedList(Of TControl).DLL_GetIndexOfItem
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountItemsBefore() As Integer Implements IDoublyLinkedList(Of TControl).DLL_CountItemsBefore
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountItemsAfter() As Integer Implements IDoublyLinkedList(Of TControl).DLL_CountItemsAfter
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountAllItems() As Integer Implements IDoublyLinkedList(Of TControl).DLL_CountAllItems
        Throw New NotImplementedException()
    End Function

    Public Function DLL_BuildListToIndex(index As Integer) As TControl Implements IDoublyLinkedList(Of TControl).DLL_BuildListToIndex
        Throw New NotImplementedException()
    End Function

    Public Function DLL_BuildListToIndex(index As Integer, ByRef count_of_new_items As Integer) As TControl Implements IDoublyLinkedList(Of TControl).DLL_BuildListToIndex
        Throw New NotImplementedException()
    End Function

    Public Function DLL_PopItem(item_toDelete As TControl) As TControl Implements IDoublyLinkedList(Of TControl).DLL_PopItem
        Throw New NotImplementedException()
    End Function

    Public Function DLL_PopItem(index As Integer) As TControl Implements IDoublyLinkedList(Of TControl).DLL_PopItem
        Throw New NotImplementedException()
    End Function

    Public Function DLL_PopRange(indexStart As Integer, countOfItemsToPop As Integer) As TControl Implements IDoublyLinkedList(Of TControl).DLL_PopRange
        Throw New NotImplementedException()
    End Function

End Class

