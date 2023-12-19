''//
''//  Added 10/30/2023 t h o m a s d o w n e s  
''//

''-----------------------------------------------------------
''  Please see CIBadgeDesigner / Classes RSC / RSC_DLL_OperationsManager.
''
''    ---12/07/2023 thomas dow_nes 
''-----------------------------------------------------------

Public Class DLL_OperationsManager_Deprecated(Of TControl)
    Implements IDoublyLinkedList(Of TControl)

    ''Private mod_list As RSCDoublyLinkedList(Of TControl)
    Private mod_list As List(Of TControl)

    Public Sub ProcessOperation(param_operation As DLL_Operation(Of TControl))




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
    Private mod_itemNext As TControl
    Private mod_itemPrior As TControl

    Public Sub DLL_InsertOneItemAfter(ByVal toBeInserted As TControl,
                                      ByVal toUseAsAnchor As TControl,
                                      ByVal isChangeOfEndpoint As Boolean) _
                                      Implements IDoublyLinkedList(Of TControl).DLL_InsertOneItemAfter
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        Throw New NotImplementedException()
    End Sub

    ''Public Sub DLL_InsertItemAfter(toBeInserted As TControl) Implements IDoublyLinkedList(Of TControl).DLL_InsertItemAfter
    ''    ''
    ''    ''This should set four(4) directional links (not just two(2))
    ''    ''
    ''    Throw New NotImplementedException()
    ''End Sub

    Public Sub DLL_InsertOneItemBefore(ByVal toBeInserted As TControl,
                                       ByVal toUseAsAnchor As TControl,
                                       ByVal isChangeOfEndPoint As Boolean) _
                                       Implements IDoublyLinkedList(Of TControl).DLL_InsertOneItemBefore
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        Throw New NotImplementedException()
    End Sub

    ''Public Sub DLL_InsertItemBefore(toBeInserted As TControl) Implements IDoublyLinkedList(Of TControl).DLL_InsertItemBefore
    ''    ''
    ''    ''This should set four(4) directional links (not just two(2))
    ''    ''
    ''    Throw New NotImplementedException()
    ''End Sub


    Public Sub DLL_InsertRangeAfter(ByVal toBeInserted_FirstItem As TControl,
                                    ByVal toBeInsertedRange_ItemCount As Integer,
                                    ByVal toUseAsAnchorStart As TControl,
                                    ByVal isChangeOfEndpoint As Boolean) _
                                    Implements IDoublyLinkedList(Of TControl).DLL_InsertRangeAfter
        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        Throw New NotImplementedException()

    End Sub


    Public Sub DLL_InsertRangeBefore(ByVal toBeInsertedRange_FirstItem As TControl,
                                     ByVal toBeInsertedRange_ItemCount As Integer,
                                     ByVal toUseAsAnchorStart As TControl,
                                     ByVal isChangeOfEndpoint As Boolean) _
        Implements IDoublyLinkedList(Of TControl).DLL_InsertRangeBefore

        ''
        ''This should set four(4) directional links (not just two(2))
        ''
        Throw New NotImplementedException()
    End Sub


    Public Sub DLL_DeleteItem(ByVal item_toDelete As TControl,
                              ByVal isChangeOfEndpoint As Boolean) _
                              Implements IDoublyLinkedList(Of TControl).DLL_DeleteItem
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


    ''Public Sub DLL_DeleteRange_NotUsed(item_toDeleteBegin As TControl, item_toDeleteEndInclusive As TControl, yes_return_list_of_deleteds As Boolean, ByRef count_of_deleteds As Integer, ByRef item_prior_undeleted As TControl, ByRef item_first_deleted As TControl) Implements IDoublyLinkedList(Of TControl).DLL_DeleteRange_NotUsed
    ''    ''
    ''    ''This should set four(4) directional links (not just two(2))
    ''    ''
    ''12/18/2023 td
    ''End Sub


    Public Sub DLL_DeleteRange_Simpler(ByVal item_toDeleteBegin As TControl,
                                       ByVal count_of_deleteds As Integer,
                                       ByVal isChangeOfEndpoint As Boolean) _
                                       Implements IDoublyLinkedList(Of TControl).DLL_DeleteRange_Simpler
        ''12/2023                      ByRef item_prior_undeleted As TControl, _
        ''12/2023                      ByRef item_first_deleted As TControl) _
        ''
        ''This should set four(4) directional links (not just two(2))
        ''


    End Sub


    ''12/2023 
    ''Public Sub DLL_SetNextAs(toBeNext As TControl) Implements IDoublyLinkedList(Of TControl).DLL_SetNextAs
    ''    ''
    ''    ''This is simple. It should set two(2) directional links (not four(4))
    ''    ''
    ''    Dim rsc_toBeNext = CType(toBeNext, TControl)
    ''12/2023 
    ''    Me.mod_itemNext = rsc_toBeNext ''Directional Link #1 of 2
    ''    ''11/2/2023 rsc_toBeNext.DLL_SetPriorAs(Me) ''Directional Link #2 of 2
    ''12/2023 
    ''End Sub

    ''12/2023 
    ''Public Sub DLL_SetPriorAs(toBePrior As TControl) Implements IDoublyLinkedList(Of TControl).DLL_SetPriorAs
    ''    ''
    ''    ''This is simple. It should set two(2) directional links (not four(4))
    ''    ''
    ''    Dim rsc_toBePrior = CType(toBePrior, TControl)
    ''12/2023 
    ''    Me.mod_itemPrior = rsc_toBePrior ''Directional Link #1 of 2
    ''    ''11/2/2023 rsc_toBePrior.DLL_SetNextAs(Me) ''Directional Link #2 of 2
    ''12/2023 
    ''End Sub


    ''Public Function DLL_ItemNext() As TControl Implements IDoublyLinkedList(Of TControl).DLL_ItemNext
    ''    ''
    ''    ''It is permissible to cast from adult-child to parent. 
    ''    ''
    ''    '' (I call it "adult child" since it contains MORE knowledge than the parent... LOL)   
    ''    ''
    ''    Return mod_itemNext ''Implicit casting (from adult-child to parent)
    ''12/2023 
    ''End Function

    ''Public Function DLL_ItemPrior() As TControl Implements IDoublyLinkedList(Of TControl).DLL_ItemPrior
    ''12/2023 
    ''    Return mod_itemPrior ''Implicit casting (from adult-child to parent)
    ''12/2023 
    ''End Function


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
