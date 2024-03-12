using System;

namespace RSCLibraryDLLOperations
{

    public interface IDoublyLinkedList<TControl> where TControl : class
    {
        // Get the item at the specified index.
        TControl DLL_GetItemAtIndex(int index);

        // Get the last item in the list.
        TControl DLL_GetLastItem();

        // Get the item at the specified index with a confirmation distance in pixels.
        TControl DLL_GetItemAtIndex(int index, int confirm_distanceInPixels);

        // Get the index of a specific item in the list.
        int DLL_GetIndexOfItem(TControl input_item);

        // Count the number of items before the current item.
        int DLL_CountItemsBefore();

        // Count the number of items after the current item.
        int DLL_CountItemsAfter();

        // Count the total number of items in the list.
        int DLL_CountAllItems();

        // Build the list up to a specified index (deprecated).
        TControl DLL_BuildListToIndex_DEPRECATED(int index);

        // Build the list up to a specified index and count the number of new items created (deprecated).
        TControl DLL_BuildListToIndex_DEPRECATED(int index, ref int count_of_new_items);

        // Insert one item after a specified anchor item.
        void DLL_InsertOneItemAfter(TControl toBeInsertedSingleItem, TControl toUseAsAnchor_ItemPrior, bool isChangeOfEndPoint);

        // Insert one item before a specified anchor item.
        void DLL_InsertOneItemBefore(TControl toBeInsertedSingleItem, TControl toUseAsAnchor_ItemNext, bool isChangeOfEndPoint);

        // Insert a range of items after a specified anchor item.
        void DLL_InsertRangeAfter(TControl toBeInsertedRange_FirstItem, 
            int toBeInsertedRange_ItemCount, 
            TControl toUseAsAnchor_Preceding, 
            bool isChangeOfEndPoint, 
            TControl item_rangeEnd_Null = null);

        // Insert a range of items before a specified anchor item.
        void DLL_InsertRangeBefore(TControl toBeInsertedRange_FirstItem, int toBeInsertedRange_ItemCount, TControl toUseAsAnchor_Terminating, bool isChangeOfEndPoint, TControl item_rangeEnd_Null = null);

        // Insert a range of items into an empty list.
        void DLL_InsertRangeEmptyList(TControl toBeInsertedRange_FirstItem, int toBeInsertedRange_ItemCount);

        // Delete a single item from the list.
        void DLL_DeleteItem(TControl item_toDelete, bool isChangeOfEndPoint);

        // Delete a range of items from the list.
        void DLL_DeleteRange(TControl item_toDeleteBegin, int count_of_deleteds, bool isChangeOfEndPoint, TControl item_toDeleteEnd_Null = null);

        // Pop an item from the list.
        TControl DLL_PopItem(TControl item_toDelete);

        // Pop an item at a specified index from the list.
        TControl DLL_PopItem(int index);

        // Pop a range of items from the list.
        TControl DLL_PopRange(int indexStart, int countOfItemsToPop);
    }

}
