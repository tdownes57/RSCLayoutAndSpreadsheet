Imports ciBadgeInterfaces

''' <summary>
''' This is an abstract class which implements ciBadgeInterfaces.IDoublyLinkedListDLL 
''' </summary>
Public Class RSCListItem
    Inherits Control
    Implements ciBadgeInterfaces.IDoublyLinkedListDLL

    ''General question, is this sort of casting possible??  Probably not!!
    ''
    ''   (Impossible, since was are casting from parent to adult-child.)
    ''   (In contrast, yes it is permissible to cast from adult-child to parent. 
    ''   (I call it "adult-child" since it contains MORE knowledge than the parent... LOL)   
    ''
    ''   Dim rsc_item = CType(item_controlToDelete, RSCListItem)
    ''
    Private mod_itemNext As RSCListItem
    Private mod_itemPrior As RSCListItem

    Public Sub DLL_InsertItemAfter(toBeInserted As Control, toUseAsAnchor As Control) Implements IDoublyLinkedListDLL.DLL_InsertItemAfter
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_InsertItemAfter(toBeInserted As Control) Implements IDoublyLinkedListDLL.DLL_InsertItemAfter
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_InsertItemBefore(toBeInserted As Control, toUseAsAnchor As Control) Implements IDoublyLinkedListDLL.DLL_InsertItemBefore
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_InsertItemBefore(toBeInserted As Control) Implements IDoublyLinkedListDLL.DLL_InsertItemBefore
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_InsertRangeAfter(toBeInsertedFirst As Control, toBeInsertedCount As Integer, toUseAsAnchorStart As Control) Implements IDoublyLinkedListDLL.DLL_InsertRangeAfter
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        Throw New NotImplementedException()
    End Sub


    Public Sub DLL_DeleteItem(item_toDelete As Control) Implements IDoublyLinkedListDLL.DLL_DeleteItem
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        ''Is this sort of casting possible??  Probably not!!
        ''   (Impossible, since was are casting from parent to adult-child.)
        ''   (In contrast, it is permissible to cast from adult-child to parent. 
        ''   (I call it "adult-child" since it contains MORE knowledge than the parent... LOL)   
        ''
        Dim rsc_toDelete = CType(item_toDelete, RSCListItem)
        Dim rsc_prior = CType(rsc_toDelete.DLL_ItemPrior, RSCListItem)
        Dim rsc_next = CType(rsc_toDelete.DLL_ItemNext, RSCListItem)

        rsc_prior.DLL_SetNextAs(rsc_next)
        rsc_next.DLL_SetPriorAs(rsc_prior)

    End Sub


    Public Sub DLL_DeleteRange(item_toDeleteBegin As Control, item_toDeleteEndInclusive As Control, yes_return_list_of_deleteds As Boolean, ByRef count_of_deleteds As Integer, ByRef item_prior_undeleted As Control, ByRef item_first_deleted As Control) Implements IDoublyLinkedListDLL.DLL_DeleteRange
        ''
        ''This should set four(4) directional links (not just two(2))
        ''


    End Sub


    Public Sub DLL_SetNextAs(toBeNext As Control) Implements IDoublyLinkedListDLL.DLL_SetNextAs
        ''
        ''This is simple. It should set two(2) directional links (not four(4))
        ''
        Dim rsc_toBeNext = CType(toBeNext, RSCListItem)

        Me.mod_itemNext = rsc_toBeNext ''Directional Link #1 of 2
        rsc_toBeNext.DLL_SetPriorAs(Me) ''Directional Link #2 of 2

    End Sub

    Public Sub DLL_SetPriorAs(toBePrior As Control) Implements IDoublyLinkedListDLL.DLL_SetPriorAs
        ''
        ''This is simple. It should set two(2) directional links (not four(4))
        ''
        Dim rsc_toBePrior = CType(toBePrior, RSCListItem)

        Me.mod_itemPrior = rsc_toBePrior ''Directional Link #1 of 2
        rsc_toBePrior.DLL_SetNextAs(Me) ''Directional Link #2 of 2

    End Sub


    Public Function DLL_ItemNext() As Control Implements IDoublyLinkedListDLL.DLL_ItemNext
        ''
        ''It is permissible to cast from adult-child to parent. 
        ''
        '' (I call it "adult child" since it contains MORE knowledge than the parent... LOL)   
        ''
        Return mod_itemNext ''Implicit casting (from adult-child to parent)

    End Function


    Public Function DLL_ItemPrior() As Control Implements IDoublyLinkedListDLL.DLL_ItemPrior

        Return mod_itemPrior ''Implicit casting (from adult-child to parent)

    End Function


    Public Function DLL_GetItemAtIndex(index As Integer) As Control Implements IDoublyLinkedListDLL.DLL_GetItemAtIndex
        Throw New NotImplementedException()
    End Function

    Public Function DLL_GetItemAtIndex(index As Integer, confirm_distance As Integer) As Control Implements IDoublyLinkedListDLL.DLL_GetItemAtIndex
        Throw New NotImplementedException()
    End Function

    Public Function DLL_GetIndexOfItem(input_item As Control) As Integer Implements IDoublyLinkedListDLL.DLL_GetIndexOfItem
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountItemsBefore() As Integer Implements IDoublyLinkedListDLL.DLL_CountItemsBefore
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountItemsAfter() As Integer Implements IDoublyLinkedListDLL.DLL_CountItemsAfter
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountAllItems() As Integer Implements IDoublyLinkedListDLL.DLL_CountAllItems
        Throw New NotImplementedException()
    End Function

    Public Function DLL_BuildListToIndex(index As Integer) As Control Implements IDoublyLinkedListDLL.DLL_BuildListToIndex
        Throw New NotImplementedException()
    End Function

    Public Function DLL_BuildListToIndex(index As Integer, ByRef count_of_new_items As Integer) As Control Implements IDoublyLinkedListDLL.DLL_BuildListToIndex
        Throw New NotImplementedException()
    End Function

End Class
