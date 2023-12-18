

''11/2023 Imports System.Windows.Forms

Public Interface IDoublyLinkedList(Of TControl)
    ''
    ''Thanks to Computer Science Department at Orange Coast College
    ''   (Profs. Gabriela Ernsberger & Hatice Aydin) 
    ''    ---10/25/2023 thomas downes
    ''
    ''11/2023 td Function DLL_ItemNext() As TControl ''Control
    ''11/2023 td Function DLL_ItemPrior() As TControl ''Control

    Function DLL_GetItemAtIndex(index As Integer) As TControl ''Control

    ''' <summary>
    ''' Get the item at the specified index and location. 
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="confirm_distanceInPixels">This will generally be an expected number of pixels from the top.</param>
    ''' <returns></returns>
    Function DLL_GetItemAtIndex(index As Integer, confirm_distanceInPixels As Integer) As TControl ''Control

    Function DLL_GetIndexOfItem(input_item As TControl) As Integer

    Function DLL_CountItemsBefore() As Integer
    Function DLL_CountItemsAfter() As Integer
    Function DLL_CountAllItems() As Integer

    ''' <summary>
    ''' This is primarily a procedure; to make it responsive, it returns the ultimate item.
    ''' </summary>
    ''' <param name="index">The expected index of the ultimate item.</param>
    ''' <returns>The ultimate item created.</returns>
    Function DLL_BuildListToIndex(index As Integer) As TControl ''Control

    ''' <summary>
    ''' This is primarily a procedure; to make it responsive, we return the ultimate item and the number of items created.
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="count_of_new_items">This is the number of items newly created.</param>
    ''' <returns>The ultimate item created.</returns>
    Function DLL_BuildListToIndex(index As Integer,
        ByRef count_of_new_items As Integer) As TControl ''Control


    '' <summary>
    '' This is meant as a simpler procedure, vs. DLL_InsertItemAfter. Sets two(2) directional links.
    '' </summary>
    '' <param name="toBeNext"></param>
    ''11/2023 td  Sub DLL_SetNextAs(toBeNext As TControl)

    '' <summary>
    '' This is meant as a simpler procedure, vs. DLL_InsertItemAfter. Sets two(2) directional links.
    '' </summary>
    '' <param name="toBePrior"></param>
    ''11/2023 td  Sub DLL_SetPriorAs(toBePrior As TControl) ''Control)



    '' <summary>
    '' ----Deprecated, originally for IDoublyLinkedItem.12/2023---This is a bit more administrative than DLL_SetNextAs, since four(4) directional links are specified (not just two).
    '' </summary>
    '' <param name="toBeInserted"></param>
    ''----Deprecated, originally for IDoublyLinkedItem.12/2023---Sub DLL_InsertItemAfter(toBeInserted As TControl) ''Control)

    ''' <summary>
    ''' A single item is being inserted after/below/right of the anchoring item.
    ''' </summary>
    ''' <param name="toBeInsertedSingleItem">The item to be inserted.</param>
    ''' <param name="toUseAsAnchor_ItemPrior">This is the item which was right-clicked just before Insert (After/Below/Right) is selected.</param>
    Sub DLL_InsertOneItemAfter(toBeInsertedSingleItem As TControl, toUseAsAnchor_ItemPrior As TControl)


    '' <summary>
    '' ----Deprecated, originally for IDoublyLinkedItem.12/2023---This is a bit more administrative than DLL_SetPriorAs, since four(4) directional links are specified (not just two).
    '' </summary>
    '' <param name="toBeInserted"></param>
    ''----Deprecated, originally for IDoublyLinkedItem.12/2023---Sub DLL_InsertItemBefore(toBeInserted As TControl) ''Control)

    ''' <summary>
    ''' A single item is being inserted before/above/left of the anchoring item.
    ''' </summary>
    ''' <param name="toBeInsertedSingleItem">The item to be inserted.</param>
    ''' <param name="toUseAsAnchor_ItemNext">This is the item which was right-clicked just before Insert (Before/Above/Left) is selected.</param>
    Sub DLL_InsertOneItemBefore(toBeInsertedSingleItem As TControl, toUseAsAnchor_ItemNext As TControl)


    ''' <summary>
    ''' This inserts a range of items, likely to UNDO a deletion of >1 linked items.
    ''' </summary>
    ''' <param name="toBeInsertedRange_FirstItem"></param>
    ''' <param name="toBeInsertedRange_ItemCount">Number of items to be inserted.</param>
    ''' <param name="toUseAsAnchor_Preceding"></param>
    Sub DLL_InsertRangeAfter(toBeInsertedRange_FirstItem As TControl,
                            toBeInsertedRange_ItemCount As Integer,
                            toUseAsAnchor_Preceding As TControl)

    ''' <summary>
    ''' This inserts a range of items, likely to UNDO a deletion of >1 linked items.
    ''' </summary>
    ''' <param name="toBeInsertedRange_FirstItem"></param>
    ''' <param name="toBeInsertedRange_ItemCount">Number of items to be inserted.</param>
    ''' <param name="toUseAsAnchor_Terminating"></param>
    Sub DLL_InsertRangeBefore(toBeInsertedRange_FirstItem As TControl,
                            toBeInsertedRange_ItemCount As Integer,
                            toUseAsAnchor_Terminating As TControl)

    Sub DLL_DeleteItem(item_toDelete As TControl)

    ''' <summary> 
    ''' This deletes a range of items in the list, inclusive of specified ends.
    ''' </summary>
    ''' <param name="item_toDeleteBegin">Begin deleting with this item.</param>
    ''' <param name="item_toDeleteEndInclusive">Delete this item last.</param>
    ''' <param name="yes_return_list_of_deleteds">True if we want to keep the deleted range.</param>
    ''' <param name="count_of_deleteds">ByRef, how many items deleted</param>
    ''' <param name="item_prior_undeleted">ByRef, prior item where the deletion took place</param>
    ''' <param name="item_first_deleted">ByRef, return the first deleted item</param>
    Sub DLL_DeleteRange_NotUsed(item_toDeleteBegin As TControl,
                    item_toDeleteEndInclusive As TControl,
                    yes_return_list_of_deleteds As Boolean,
                    ByRef count_of_deleteds As Integer,
                    ByRef item_prior_undeleted As TControl,
                    ByRef item_first_deleted As TControl)

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="item_toDeleteBegin"></param>
    ''' <param name="count_of_deleteds">How many items are being deleted?</param>
    ''' <param name="ref_prior_undeleted">Needed for Administrative Undo.</param>
    ''' <param name="ref_next_undeleted">Needed for Administrative Undo.</param>
    Sub DLL_DeleteRange_Simpler(item_toDeleteBegin As TControl,
                    ByVal count_of_deleteds As Integer,
                    ByRef ref_prior_undeleted As TControl,
                    ByRef ref_next_undeleted As TControl)

    ''//
    ''// Suggested by my Python class, Chapter 6: Lists
    ''/// 10/28/2023 td
    ''//
    Function DLL_PopItem(item_toDelete As TControl) As TControl
    Function DLL_PopItem(index As Integer) As TControl
    Function DLL_PopRange(indexStart As Integer, countOfItemsToPop As Integer) As TControl


End Interface


