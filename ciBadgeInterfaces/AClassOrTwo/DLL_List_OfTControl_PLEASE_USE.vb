''12/2023 Imports System.Data.SqlTypes

''-----------------------------------------------------------
''  Please see CIBadgeDesigner / Classes RSC / RSC_DLL_OperationsManager.
''
''    ---12/07/2023 thomas dow_nes 
''-----------------------------------------------------------
''
''---- DIFFICULT AND CONFUSING ----
''  Here is the "secret sauce" that allows this Generic Type (DLL_List_OfTControl_PLEASE_USE(Of TControl))
''  to work... EXPLICIT CASTING!!!   ---12/18/2023
''  EXPLICIT CASTING...
''    Dim itemToInsert As IDoublyLinkedItem = CType(toBeInsertedSingleItem, IDoublyLinkedItem)
''    Dim itemForAnchoring As IDoublyLinkedItem = CType(toUseAsAnchor, IDoublyLinkedItem)
''-----------------------------------------------------------------------------------------------------
''

''' <summary>
''' We use explicit casting as a way to access crucial methods. 
''' TControl is RSCFieldColumn, RSCDataHeader, or RSCDataCell.
''' </summary>
''' <typeparam name="TControl"></typeparam>
Public Class DLL_List_OfTControl_PLEASE_USE(Of TControl)
    Implements IDoublyLinkedList(Of TControl)

    Private mod_dllControlFirst As IDoublyLinkedItem ''Not necessarily needed, except for testing. DLL = Doubly-Linked List. 
    Private mod_bTesting As Boolean
    Private mod_dllControlLast As IDoublyLinkedItem ''May not be needed.  DLL = Doubly-Linked List. 

    Private Const WE_CHECK_RANGE_ENDPOINTS_ALWAYS As Boolean = False ''Added 12/18/2023
    Private Const WE_CHECK_RANGE_ENDPOINTS_TESTING As Boolean = True ''Added 12/18/2023
    Private Const WE_CLEAN_RANGE_ENDPOINTS_ALWAYS As Boolean = True ''Added 12/18/2023

    '' 12/2023
    ''Public Sub DLL_SetNextAs(toBeNext As TControl) Implements IDoublyLinkedList(Of TControl).DLL_SetNextAs
    ''    ''Throw New NotImplementedException()
    ''E nd Sub
    '' 12/2023
    ''Public Sub DLL_SetPriorAs(toBePrior As TControl) Implements IDoublyLinkedList(Of TControl).DLL_SetPriorAs
    ''    Throw New NotImplementedException()
    ''End Sub

    Public Sub New(par_firstItem As TControl)
        ''
        ''Set the initial instance variable. 
        ''
        mod_dllControlFirst = CType(par_firstItem, IDoublyLinkedItem)

        mod_bTesting = Testing.TestingByDefault

    End Sub


    Public Sub New(par_firstItem As TControl, par_lastItem As TControl)
        ''
        ''Set the initial instance variable. 
        ''
        mod_dllControlFirst = CType(par_firstItem, IDoublyLinkedItem)

        mod_bTesting = Testing.TestingByDefault

        ''Added 12/2023
        mod_dllControlLast = CType(par_lastItem, IDoublyLinkedItem)

    End Sub



    ''For IDoublyLinkedItem.---Public Sub DLL_InsertItemAfter(toBeInserted As TControl) Implements IDoublyLinkedList(Of TControl).DLL_InsertItemAfter
    ''    ''Throw New NotImplementedException()
    ''End Sub

    Public Sub DLL_InsertOneItemAfter(p_toBeInsertedSingleItem As TControl,
                                      p_toUseAsAnchor_ItemPriorToSingle As TControl,
                                      p_isChangeOfEndpoint As Boolean) _
                                      Implements IDoublyLinkedList(Of TControl).DLL_InsertOneItemAfter
        ''
        ''                Insert A after 7, the preceding anchor.
        ''                       |
        ''          1 2 3 4 5 6 7 8 9 10
        '' Result:  1 2 3 4 5 6 7 A 8 9 10
        ''
        ''12/2023 Throw New NotImplementedException()
        Dim itemSingleToInsert As IDoublyLinkedItem '' = CType(p_toBeInsertedSingleItem, IDoublyLinkedItem)
        ''Reminder, anchors are applicable AFTER (or DURING) the operation takes place.
        Dim itemForAnchoring_ItemPriorToSingle As IDoublyLinkedItem ''Will ultimately precede the range of inserted items.
        Dim bTesting As Boolean = ciBadgeInterfaces.Testing.TestingByDefault

        ''-----------------------------------------------------------------------------------------------------
        ''---- DIFFICULT AND CONFUSING ----
        ''  Here is the "secret sauce" that allows this Generic Type (DLL_List_OfTControl_PLEASE_USE(Of TControl))
        ''  to work... EXPLICIT CASTING!!!  ---12/18/2023
        ''-----------------------------------------------------------------------------------------------------
        itemSingleToInsert = CType(p_toBeInsertedSingleItem, IDoublyLinkedItem)
        itemForAnchoring_ItemPriorToSingle = CType(p_toUseAsAnchor_ItemPriorToSingle, IDoublyLinkedItem)

        ''Testing...
        If ((bTesting And WE_CHECK_RANGE_ENDPOINTS_TESTING) Or
            WE_CHECK_RANGE_ENDPOINTS_ALWAYS) Then
            ''Items passed as primary-operational (vs. anchors) must be cleaned
            ''  of references.
            If (itemSingleToInsert.DLL_HasNext()) Then Debugger.Break()
            If (itemSingleToInsert.DLL_HasPrior()) Then Debugger.Break()
        End If ''Testing

        ''
        ''Save the item prior to the anchor, if it exists.
        ''
        Dim temp_itemNextToAnchor As IDoublyLinkedItem = Nothing
        Dim anchorHasItemNext As Boolean
        anchorHasItemNext = itemForAnchoring_ItemPriorToSingle.DLL_HasNext()
        If (anchorHasItemNext) Then
            ''We are _NOT_ at the end of the list.
            temp_itemNextToAnchor = itemForAnchoring_ItemPriorToSingle.DLL_GetItemPrior()
        Else
            ''
            ''We _ARE_ at the end of the list.
            ''
            ''Testing...
            If (bTesting) Then
                Dim bMismatch As Boolean
                bMismatch = (mod_dllControlLast IsNot itemForAnchoring_ItemPriorToSingle)
                If (bMismatch) Then Debugger.Break()
            End If ''End of ""If (bTesting) Then""

            ''Added 12/18/2023 td
            mod_dllControlLast = p_toBeInsertedSingleItem

        End If ''end of ""If (anchorHasItemNext) Then... Else..."

        ''Set references #1 & #2 of 4
        Dim temp = itemForAnchoring_ItemPriorToSingle.DLL_GetItemNext()
        itemForAnchoring_ItemPriorToSingle.DLL_SetItemNext(itemSingleToInsert)
        itemSingleToInsert.DLL_SetItemPrior(itemForAnchoring_ItemPriorToSingle)

        ''If there is a next element, set references #3 & #4 of 4
        If (anchorHasItemNext) Then
            ''Set references #3 & #4 of 4
            temp_itemNextToAnchor.DLL_SetItemPrior(itemSingleToInsert)
            itemSingleToInsert.DLL_SetItemNext(temp_itemNextToAnchor)

        ElseIf (p_isChangeOfEndpoint) Then
            ''
            ''Do nothing. The calling procedure is already aware of the change of endpoint.
            ''
        Else
            ''Inform the calling procedures that the endpoint has changed. 
            Throw New RSCEndpointException("New starting ending point of list.")

        End If ''end of ""If (anchorHasItemNext) Then ... ElseIf... Else...""

    End Sub ''Public Sub DLL_InsertOneItemAfter


    ''Public Sub DLL_InsertItemBefore(toBeInserted As TControl) Implements IDoublyLinkedList(Of TControl).DLL_InsertItemBefore
    ''    Throw New NotImplementedException()
    ''End Sub

    Public Sub DLL_InsertOneItemBefore(ByVal p_toBeInsertedSingleItem As TControl,
                                       ByVal p_toUseAsAnchor_ItemNextToSingle As TControl,
                                       ByVal p_isChangeOfEndpoint As Boolean) _
                                       Implements IDoublyLinkedList(Of TControl).DLL_InsertOneItemBefore
        ''
        ''            Insert x before 6, the terminating anchor.
        ''                   |
        ''          1 2 3 4 5 6 7 8 9 10
        '' Result:  1 2 3 4 5 x 6 7 8 9 10
        ''
        ''12/2023 Throw New NotImplementedException()

        Dim itemSingleToInsert As IDoublyLinkedItem
        ''Reminder, anchors are applicable AFTER (or DURING) the operation takes place.
        Dim itemForAnchoring_ItemNextToSingle As IDoublyLinkedItem ''Will ultimate follow the inserted item.
        Dim bTesting As Boolean = ciBadgeInterfaces.Testing.TestingByDefault

        ''-----------------------------------------------------------------------------------------------------
        ''---- DIFFICULT AND CONFUSING ----
        ''  Here is the "secret sauce" that allows this Generic Type (DLL_List_OfTControl_PLEASE_USE(Of TControl))
        ''  to work... EXPLICIT CASTING!!!  ---12/18/2023
        ''-----------------------------------------------------------------------------------------------------
        itemSingleToInsert = CType(p_toBeInsertedSingleItem, IDoublyLinkedItem)
        itemForAnchoring_ItemNextToSingle = CType(p_toUseAsAnchor_ItemNextToSingle, IDoublyLinkedItem)

        If ((bTesting And WE_CHECK_RANGE_ENDPOINTS_TESTING) Or
            WE_CHECK_RANGE_ENDPOINTS_ALWAYS) Then
            ''
            ''-----POSSIBLY DIFFICULT AND CONFUSING----
            ''Items passed as primary-operational (vs. anchors) must be cleaned
            ''  of references.
            ''
            If (itemSingleToInsert.DLL_HasNext()) Then Debugger.Break()
            If (itemSingleToInsert.DLL_HasPrior()) Then Debugger.Break()
        End If ''Testing for clean endpoints

        ''Save the item prior to the anchor, if it exists. 
        Dim temp_itemPriorToAnchor As IDoublyLinkedItem = Nothing
        Dim anchorHasItemPrior As Boolean ''Added 12/18/2023
        anchorHasItemPrior = itemForAnchoring_ItemNextToSingle.DLL_HasPrior()
        If (anchorHasItemPrior) Then
            temp_itemPriorToAnchor = itemForAnchoring_ItemNextToSingle.DLL_GetItemPrior()
        Else
            ''
            ''We _ARE_ at the beginning of the list.
            ''
            ''Testing...
            If (bTesting) Then
                Dim bMismatch As Boolean
                bMismatch = (mod_dllControlLast IsNot itemForAnchoring_ItemNextToSingle)
                If (bMismatch) Then Debugger.Break()
            End If ''End of ""If (bTesting) Then""

            ''Added 12/18/2023 td
            mod_dllControlFirst = p_toBeInsertedSingleItem

        End If ''end of ""If (anchorHasItemPrior) Then ... Else...""

        ''Set references #1 & #2 of 4
        itemForAnchoring_ItemNextToSingle.DLL_SetItemPrior(itemSingleToInsert)
        itemSingleToInsert.DLL_SetItemNext(itemForAnchoring_ItemNextToSingle)

        ''Set references #3 & #4 of 4
        If (anchorHasItemPrior) Then
            ''Set references #3 & #4 of 4
            temp_itemPriorToAnchor.DLL_SetItemNext(itemSingleToInsert)
            itemSingleToInsert.DLL_SetItemPrior(temp_itemPriorToAnchor)

        ElseIf (p_isChangeOfEndpoint) Then
            ''Do nothing. The calling procedure is already aware of
            ''  the change of endpoint.
        Else
            ''Inform the calling procedures that the endpoint has changed. 
            Throw New RSCEndpointException("New starting point of list.")

        End If ''end of ""If (anchorHasItemPrior) Then ... Else...""

    End Sub ''Public Sub DLL_InsertOneItemBefore


    Public Sub DLL_InsertRangeAfter(p_toBeInsertedRange_FirstItem As TControl,
                                    p_toBeInsertedRange_ItemCount As Integer,
                                    p_toUseAsAnchor_ItemPriorToRange As TControl,
                                    p_bIsChangeOfEndPoint As Boolean) _
                                    Implements IDoublyLinkedList(Of TControl).DLL_InsertRangeAfter
        ''
        ''                Insert A B C after 7, the preceding anchor. (Three items.)
        ''                       |
        ''          1 2 3 4 5 6 7 8 9 10
        '' Result:  1 2 3 4 5 6 7 A B C 8 9 10
        ''
        ''Throw New NotImplementedException()
        ''12/2023 Throw New NotImplementedException()
        Dim itemFirstItemToInsert As IDoublyLinkedItem '' 
        Dim itemLastItemToInsert As IDoublyLinkedItem '' 
        ''Reminder, anchors are applicable AFTER (or DURING) the operation takes place.
        Dim itemForAnchoring_ItemPriorToRange As IDoublyLinkedItem ''Will ultimately precede the range.
        Dim bTesting As Boolean = ciBadgeInterfaces.Testing.TestingByDefault

        ''-----------------------------------------------------------------------------------------------------
        ''---- DIFFICULT AND CONFUSING ----
        ''  Here is the "secret sauce" that allows this Generic Type (DLL_List_OfTControl_PLEASE_USE(Of TControl))
        ''  to work... EXPLICIT CASTING!!!  ---12/18/2023
        ''-----------------------------------------------------------------------------------------------------
        itemFirstItemToInsert = CType(p_toBeInsertedRange_FirstItem, IDoublyLinkedItem)
        ''Reminder, anchors are applicable AFTER (or DURING) the operation takes place.
        itemForAnchoring_ItemPriorToRange = CType(p_toUseAsAnchor_ItemPriorToRange, IDoublyLinkedItem)
        ''Calculate the final item in the range.
        itemLastItemToInsert = itemFirstItemToInsert.DLL_GetItemNext(-1 + p_toBeInsertedRange_ItemCount)

        ''Testing...
        If ((bTesting And WE_CHECK_RANGE_ENDPOINTS_TESTING) Or
                          WE_CHECK_RANGE_ENDPOINTS_ALWAYS) Then
            ''Items passed as primary-operational (vs. anchors) must be cleaned
            ''  of references.
            If (itemFirstItemToInsert.DLL_HasPrior()) Then Debugger.Break()
            ''Check the last item.
            If (itemLastItemToInsert.DLL_HasNext()) Then Debugger.Break()
        End If ''Testing for clean endpoints.

        ''
        ''Save the item prior to the anchor, if it exists.
        ''
        Dim temp_itemNextToAnchor As IDoublyLinkedItem = Nothing
        Dim anchorHasItemNext As Boolean
        anchorHasItemNext = itemForAnchoring_ItemPriorToRange.DLL_HasNext()
        If (anchorHasItemNext) Then
            ''We are _NOT_ at the end of the list.
            temp_itemNextToAnchor = itemForAnchoring_ItemPriorToRange.DLL_GetItemPrior()
        Else
            ''
            ''We _ARE_ at the end of the list.
            ''
            ''Testing...
            If (bTesting) Then
                Dim bMismatch As Boolean
                bMismatch = (mod_dllControlLast IsNot itemForAnchoring_ItemPriorToRange)
                If (bMismatch) Then Debugger.Break()
            End If ''End of ""If (bTesting) Then""

            ''Added 12/18/2023 td
            mod_dllControlLast = itemLastItemToInsert

        End If ''end of ""If (anchorHasItemNext) Then... Else..."

        ''Set references #1 & #2 of 4
        Dim temp = itemForAnchoring_ItemPriorToRange.DLL_GetItemNext()
        itemForAnchoring_ItemPriorToRange.DLL_SetItemNext(itemFirstItemToInsert)
        itemFirstItemToInsert.DLL_SetItemPrior(itemForAnchoring_ItemPriorToRange)

        ''If there is a next element, set references #3 & #4 of 4
        If (anchorHasItemNext) Then
            ''Set references #3 & #4 of 4
            temp_itemNextToAnchor.DLL_SetItemPrior(itemLastItemToInsert)
            itemLastItemToInsert.DLL_SetItemNext(temp_itemNextToAnchor)

        ElseIf (p_bIsChangeOfEndpoint) Then
            ''
            ''Do nothing. The calling procedure is already aware of the change of endpoint.
            ''
        Else
            ''Inform  the calling procedures that the endpoint has changed. 
            Throw New RSCEndpointException("New ending point of list.")

        End If ''end of ""If (anchorHasItemNext) Then ... ElseIf... Else...""

    End Sub ''ENd Public Sub DLL_InsertRangeAfter


    Public Sub DLL_InsertRangeBefore(p_toBeInsertedRange_FirstItem As TControl,
                                     p_toBeInsertedRange_ItemCount As Integer,
                                     p_toUseAsAnchor_ItemNextToRange As TControl,
                                     p_bIsChangeOfEndPoint As Boolean) _
                                     Implements IDoublyLinkedList(Of TControl).DLL_InsertRangeBefore
        ''
        ''                Insert A B C before 8, the terminating anchor. (Three items.)
        ''                       |
        ''          1 2 3 4 5 6 7 8 9 10
        '' Result:  1 2 3 4 5 6 7 A B C 8 9 10
        ''
        ''12/2023 Throw New NotImplementedException()
        Dim itemFirstItemToInsert As IDoublyLinkedItem
        Dim itemLastItemToInsert As IDoublyLinkedItem '' 
        ''Reminder, anchors are applicable AFTER (or DURING) the operation takes place.
        Dim itemForAnchoring_ItemNextToRange As IDoublyLinkedItem ''Will ultimately follow the range.
        Dim bTesting As Boolean = ciBadgeInterfaces.Testing.TestingByDefault

        ''-----------------------------------------------------------------------------------------------------
        ''---- DIFFICULT AND CONFUSING ----
        ''  Here is the "secret sauce" that allows this Generic Type (DLL_List_OfTControl_PLEASE_USE(Of TControl))
        ''  to work... EXPLICIT CASTING!!!  ---12/18/2023
        ''-----------------------------------------------------------------------------------------------------
        itemFirstItemToInsert = CType(p_toBeInsertedRange_FirstItem, IDoublyLinkedItem)
        itemForAnchoring_ItemNextToRange = CType(p_toUseAsAnchor_ItemNextToRange, IDoublyLinkedItem)
        ''Calculate the final item in the range.
        itemLastItemToInsert = itemFirstItemToInsert.DLL_GetItemNext(-1 + p_toBeInsertedRange_ItemCount)

        If ((bTesting And WE_CHECK_RANGE_ENDPOINTS_TESTING) Or
                          WE_CHECK_RANGE_ENDPOINTS_ALWAYS) Then
            ''
            ''-----POSSIBLY DIFFICULT AND CONFUSING----
            ''Items passed as primary-operational (vs. anchors) must be cleaned
            ''  of references.
            ''
            If (itemFirstItemToInsert.DLL_HasPrior()) Then Debugger.Break()
            If (itemLastItemToInsert.DLL_HasNext()) Then Debugger.Break()

        End If ''Testing for clean endpoints

        ''Save the item prior to the anchor, if it exists. 
        Dim temp_itemPriorToAnchor As IDoublyLinkedItem = Nothing
        Dim anchorHasItemPrior As Boolean ''Added 12/18/2023
        anchorHasItemPrior = itemForAnchoring_ItemNextToRange.DLL_HasPrior()
        If (anchorHasItemPrior) Then
            temp_itemPriorToAnchor = itemForAnchoring_ItemNextToRange.DLL_GetItemPrior()
        Else
            ''
            ''We _ARE_ at the beginning of the list.
            ''
            ''Testing...
            If (bTesting) Then
                Dim bMismatch As Boolean
                bMismatch = (mod_dllControlLast IsNot itemForAnchoring_ItemNextToRange)
                If (bMismatch) Then Debugger.Break()
            End If ''End of ""If (bTesting) Then""

            ''Added 12/18/2023 td
            mod_dllControlFirst = p_toBeInsertedRange_FirstItem

        End If ''end of ""If (anchorHasItemPrior) Then ... Else...""

        ''Set references #1 & #2 of 4
        itemForAnchoring_ItemNextToRange.DLL_SetItemPrior(itemLastItemToInsert)
        itemLastItemToInsert.DLL_SetItemNext(itemForAnchoring_ItemNextToRange)

        ''Set references #3 & #4 of 4
        If (anchorHasItemPrior) Then
            ''Set references #3 & #4 of 4
            temp_itemPriorToAnchor.DLL_SetItemNext(itemFirstItemToInsert)
            itemFirstItemToInsert.DLL_SetItemPrior(temp_itemPriorToAnchor)

        ElseIf (p_bIsChangeOfEndpoint) Then
            ''Do nothing. The calling procedure is already aware of
            ''  the change of endpoint.
        Else
            ''Inform the calling procedures that the endpoint has changed. 
            Throw New RSCEndpointException("New starting point of list.")

        End If ''end of ""If (anchorHasItemPrior) Then ... Else...""

    End Sub ''End of Public Sub DLL_InsertRangeBefore


    Public Sub DLL_DeleteItem(ByVal p_item_toDelete As TControl,
                              ByVal p_isChangeOfEndpoint As Boolean) _
                              Implements IDoublyLinkedList(Of TControl).DLL_DeleteItem
        ''
        ''        Delete "4". (Single item.)
        ''                |
        ''          1 2 3 4 5 6 7 8 9 10
        '' Result:  1 2 3 5 6 7 8 9 10
        ''
        ''12/2023 Throw New NotImplementedException()

        Dim itemToDelete = CType(p_item_toDelete, IDoublyLinkedItem)
        Dim itemPriorToDelete As IDoublyLinkedItem = Nothing
        Dim itemFollowingDelete As IDoublyLinkedItem = Nothing
        Dim bDeletingEndOfList As Boolean
        Dim bDeletingStartOfList As Boolean

        bDeletingEndOfList = itemToDelete.DLL_NotAnyNext
        bDeletingStartOfList = itemToDelete.DLL_NotAnyPrior

        If (bDeletingStartOfList) Then

            If (Not p_isChangeOfEndpoint) Then Throw New RSCEndpointException("No endpoint specified.")

        Else
            itemPriorToDelete = itemToDelete.DLL_GetItemPrior()
            itemPriorToDelete.DLL_SetItemNext(itemFollowingDelete)
        End If

        If (bDeletingEndOfList) Then

            If (Not p_isChangeOfEndpoint) Then Throw New RSCEndpointException("No endpoint specified.")

        Else
            itemFollowingDelete = itemToDelete.DLL_GetItemNext()
            itemFollowingDelete.DLL_SetItemPrior(itemPriorToDelete)
        End If

        ''
        ''Clean range-of-items endpoints!!
        ''
        If (WE_CLEAN_RANGE_ENDPOINTS_ALWAYS) Then

            itemToDelete.DLL_ClearReferencePrior("D"c)
            itemToDelete.DLL_ClearReferenceNext("D"c)

        End If ''If (WE_CLEAN_RANGE_ENDPOINTS_ALWAYS) Then

    End Sub ''End of Public Sub DLL_DeleteItem


    ''Public Sub DLL_DeleteRange_NotUsed(item_toDeleteBegin As TControl, item_toDeleteEndInclusive As TControl,
    ''                           yes_return_list_of_deleteds As Boolean,
    ''                           ByRef count_of_deleteds As Integer,
    ''                           ByRef item_prior_undeleted As TControl, ByRef item_first_deleted As TControl) _
    ''                           Implements IDoublyLinkedList(Of TControl).DLL_DeleteRange_NotUsed
    ''12/18/2023
    ''    Throw New NotImplementedException()
    ''End Sub


    Public Sub DLL_DeleteRange_Simpler(ByVal item_toDeleteBegin As TControl,
                                       ByVal count_of_deleteds As Integer,
                                       ByVal isChangeOfEndpoint As Boolean) _
                                       Implements IDoublyLinkedList(Of TControl).DLL_DeleteRange_Simpler
        ''Not needed.            ByRef item_prior_undeleted As TControl,
        ''Not needed.            ByRef item_first_deleted As TControl) _

        Throw New NotImplementedException()
    End Sub

    '' 12/2023
    ''Public Function DLL_ItemNext() As TControl Implements IDoublyLinkedList(Of TControl).DLL_ItemNext
    ''    Throw New NotImplementedException()
    ''End Function
    '' 12/2023
    ''Public Function DLL_ItemPrior() As TControl Implements IDoublyLinkedList(Of TControl).DLL_ItemPrior
    ''    Throw New NotImplementedException()
    ''End Function

    Public Function DLL_GetItemAtIndex(par_index As Integer) As TControl Implements IDoublyLinkedList(Of TControl).DLL_GetItemAtIndex
        ''Throw New NotImplementedException()

        If (par_index = 0) Then

            Return mod_dllControlFirst

        Else

            Dim each_item As IDoublyLinkedItem = mod_dllControlFirst

            For indexFor = 1 To par_index

                If (True Or mod_bTesting) Then
                    If (each_item.DLL_NotAnyNext()) Then
                        Debugger.Break()
                    End If ''End of ""If (each_item.DLL_NotAnyNext()) Then""
                End If ''End of ""If (mod_bTesting) Then""

                each_item = each_item.DLL_GetItemNext()

            Next indexFor

            Return each_item

        End If ''End of ""If (par_index = 0) Then... Else..."

    End Function

    ''' <summary>
    ''' Get the indexed item, and if it's a data-cell, check the horizontal alignment.
    ''' </summary>
    ''' <param name="par_index"></param>
    ''' <param name="ptest_cellAlignswHeader">The Row Header's (.Top + .Height/2).</param>
    ''' <returns></returns>
    Public Function DLL_GetItemAtIndex(par_index As Integer,
                                       ptest_cellAlignswHeader As Integer) As TControl Implements IDoublyLinkedList(Of TControl).DLL_GetItemAtIndex
        ''Throw New NotImplementedException()

        Dim resultControl As Windows.Forms.Control ''IDoublyLinkedItem
        ''12/2023 resultControl = CType(DLL_GetItemAtIndex(par_index), TControl) ''Windows.Forms.Control)
        resultControl = CType(DLL_GetItemAtIndex(par_index),
                                IDoublyLinkedItem).DLL_UnboxControl()

        If (mod_bTesting) Then
            ''
            '' Confirm that the Data Cell is along the same horizontal line 
            '' as the Row Header.  (The parameter confirm_alignedHLine)
            ''
            Dim intHorizontalLineRow As Integer ''Added 12/2023 td
            Dim boolNearby As Boolean ''Added 12/2023 td
            Dim boolAtOrBelowTop As Boolean ''Added 12/2023 td
            Dim boolAboveBottom As Boolean ''Added 12/2023 td
            With resultControl
                intHorizontalLineRow = ptest_cellAlignswHeader
                boolAtOrBelowTop = (.Top <= intHorizontalLineRow)
                boolAboveBottom = (intHorizontalLineRow < (.Top + .Height))
                boolNearby = (boolAtOrBelowTop And boolAboveBottom)
            End With
            If (Not boolNearby) Then
                Debugger.Break()
            End If ''End of ""If (Not boolNearby) Then""
        End If ''End of ""If (mod_bTesting) Then""

    End Function ''enD OF ""Public Function DLL_GetItemAtIndex""

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
