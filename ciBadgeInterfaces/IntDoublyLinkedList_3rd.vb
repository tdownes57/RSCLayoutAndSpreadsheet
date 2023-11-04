
''
''Added 11/02/2023 thomas downes
''
''11/02/2023 Imports System.Windows.Forms

Public Interface IDoublyLinkedList ''11/2023 td (Of IDoublyLinkedItem)
    ''
    ''Thanks to Computer Science Department at Orange Coast College
    ''   (Profs. Gabriela Ernsberger & Hatice Aydin) 
    ''    ---10/25/2023 thomas downes
    ''
    ''11/2/2023 Function DLL_ItemNext() As IDoublyLinkedItem ''Control
    ''11/2/2023 ''Function DLL_ItemPrior() As IDoublyLinkedItem ''Control

    Function DLL_GetItemAtIndex(index As Integer) As IDoublyLinkedItem ''Control

    ''' <summary>
    ''' Get the item at the specified index and location. 
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="confirm_distance">This will generally be an expected number of pixels from the top.</param>
    ''' <returns></returns>
    Function DLL_GetItemAtIndex(index As Integer, confirm_distance As Integer) As IDoublyLinkedItem ''Control

    Function DLL_GetIndexOfItem(input_item As IDoublyLinkedItem) As Integer

    Function DLL_CountItemsBefore() As Integer
    Function DLL_CountItemsAfter() As Integer
    Function DLL_CountAllItems() As Integer

    ''' <summary>
    ''' This is primarily a procedure; to make it responsive, it returns the ultimate item.
    ''' </summary>
    ''' <param name="index">The expected index of the ultimate item.</param>
    ''' <returns>The ultimate item created.</returns>
    Function DLL_BuildListToIndex(index As Integer) As IDoublyLinkedItem ''Control

    ''' <summary>
    ''' This is primarily a procedure; to make it responsive, we return the ultimate item and the number of items created.
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="count_of_new_items">This is the number of items newly created.</param>
    ''' <returns>The ultimate item created.</returns>
    Function DLL_BuildListToIndex(index As Integer,
        ByRef count_of_new_items As Integer) As IDoublyLinkedItem ''Control


    '' <summary>
    '' This is meant as a simpler procedure, vs. DLL_InsertItemAfter. Sets two(2) directional links.
    '' </summary>
    '' <param name="toBeNext"></param>
    ''11/2/2023 Sub DLL_SetNextAs(toBeNext As IDoublyLinkedItem)

    '' <summary>
    '' This is meant as a simpler procedure, vs. DLL_InsertItemAfter. Sets two(2) directional links.
    '' </summary>
    '' <param name="toBePrior"></param>
    ''11/2/2023 Sub DLL_SetPriorAs(toBePrior As IDoublyLinkedItem) ''Control)



    '' <summary>
    '' This is a bit more administrative than DLL_SetNextAs, since four(4) directional links are specified (not just two).
    '' </summary>
    '' <param name="toBeInserted"></param>
    ''----Sub DLL_InsertItemAfter(toBeInserted As IDoublyLinkedItem) ''Control)

    ''' <summary>
    ''' Overload of simpler, more likely used Sub.
    ''' </summary>
    ''' <param name="toBeInserted">The item to be inserted.</param>
    ''' <param name="toUseAsAnchor">The item whose "Next" property will lead to the inserted item.</param>
    Sub DLL_InsertItemAfter(toBeInserted As IDoublyLinkedItem, toUseAsAnchor As IDoublyLinkedItem)


    ''''' <summary>
    ''''' This is a bit more administrative than DLL_SetPriorAs, since four(4) directional links are specified (not just two).
    ''''' </summary>
    ''''' <param name="toBeInserted"></param>
    ''Sub DLL_InsertItemBefore(toBeInserted As IDoublyLinkedItem) ''Control)

    ''' <summary>
    ''' Overload of simpler, more likely used Sub.
    ''' </summary>
    ''' <param name="toBeInserted">The item to be inserted.</param>
    ''' <param name="toUseAsAnchor">Unlikely to be needed, as the likely anchor is the concrete object which owns the procedure.</param>
    Sub DLL_InsertItemBefore(toBeInserted As IDoublyLinkedItem, toUseAsAnchor As IDoublyLinkedItem)


    ''' <summary>
    ''' This inserts a range of items, likely to UNDO a deletion of >1 linked items.
    ''' </summary>
    ''' <param name="toBeInsertedFirst"></param>
    ''' <param name="toBeInsertedCount">Number of items to be inserted.</param>
    ''' <param name="toUseAsAnchorStart"></param>
    Sub DLL_InsertRangeAfter(toBeInsertedFirst As IDoublyLinkedItem,
                            toBeInsertedCount As Integer,
                            toUseAsAnchorStart As IDoublyLinkedItem)

    Sub DLL_DeleteItem(item_toDelete As IDoublyLinkedItem)

    ''' <summary> 
    ''' This deletes a range of items in the list, inclusive of specified ends.
    ''' </summary>
    ''' <param name="item_toDeleteBegin">Begin deleting with this item.</param>
    ''' <param name="item_toDeleteEndInclusive">Delete this item last.</param>
    ''' <param name="yes_return_list_of_deleteds">True if we want to keep the deleted range.</param>
    ''' <param name="count_of_deleteds">ByRef, how many items deleted</param>
    ''' <param name="item_prior_undeleted">ByRef, prior item where the deletion took place</param>
    ''' <param name="item_first_deleted">ByRef, return the first deleted item</param>
    Sub DLL_DeleteRange(item_toDeleteBegin As IDoublyLinkedItem,
                    item_toDeleteEndInclusive As IDoublyLinkedItem,
                    yes_return_list_of_deleteds As Boolean,
                    ByRef count_of_deleteds As Integer,
                    ByRef item_prior_undeleted As IDoublyLinkedItem,
                    ByRef item_first_deleted As IDoublyLinkedItem)

    ''//
    ''// Suggested by my Python class, Chapter 6: Lists
    ''/// 10/28/2023 td
    ''//
    Function DLL_PopItem(item_toDelete As IDoublyLinkedItem) As IDoublyLinkedItem
    Function DLL_PopItem(index As Integer) As IDoublyLinkedItem
    Function DLL_PopRange(indexStart As Integer, countOfItemsToPop As Integer) As IDoublyLinkedItem


End Interface



