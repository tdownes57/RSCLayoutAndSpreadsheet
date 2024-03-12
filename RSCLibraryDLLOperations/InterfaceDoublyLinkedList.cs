using System;

namespace RSCLibraryDLLOperations
{
    /// <summary>
    /// This is a list of methods for a doubly-linked list of UI controls.
    /// </summary>
    /// <typeparam name="TControl">UI Control class, usually a UserControl class.</typeparam>
    public interface IDoublyLinkedList<TUserControl> where TUserControl : IDoublyLinkedItem<TUserControl>
    {
        // Get the item at the specified index.
        TUserControl DLL_GetItemAtIndex(int index);

        // Get the last item in the list.
        TUserControl DLL_GetLastItem();

        // Get the item at the specified index with a confirmation distance in pixels.
        TUserControl DLL_GetItemAtIndex(int index, int confirm_distanceInPixels);

        // Get the index of a specific item in the list.
        int DLL_GetIndexOfItem(TUserControl input_item);

        // Count the number of items before the current item.
        int DLL_CountItemsBefore();

        // Count the number of items after the current item.
        int DLL_CountItemsAfter();

        // Count the total number of items in the list.
        int DLL_CountAllItems();

        // Build the list up to a specified index (deprecated).
        TUserControl DLL_BuildListToIndex_DEPRECATED(int index);

        // Build the list up to a specified index and count the number of new items created (deprecated).
        TUserControl DLL_BuildListToIndex_DEPRECATED(int index, ref int count_of_new_items);

        // Insert one item after a specified anchor item.
        void DLL_InsertOneItemAfter(TUserControl toBeInsertedSingleItem, TUserControl toUseAsAnchor_ItemPrior, bool isChangeOfEndPoint);

        // Insert one item before a specified anchor item.
        void DLL_InsertOneItemBefore(TUserControl toBeInsertedSingleItem, TUserControl toUseAsAnchor_ItemNext, bool isChangeOfEndPoint);


        // Insert a range of items after a specified anchor item.  Overloaded!
        void DLL_InsertRangeAfter(TUserControl toBeInsertedRange_FirstItem,
                int toBeInsertedRange_ItemCount,
                TUserControl toUseAsAnchor_Preceding,
                bool isChangeOfEndPoint);

        // Insert a range of items after a specified anchor item.  Overloaded!
        //    (This overloaded signature includes a 2nd parameter of type TUserControl,
        //    TUserControl item_rangeEnd_Null.)
        void DLL_InsertRangeAfter(TUserControl toBeInsertedRange_FirstItem,
            int toBeInsertedRange_ItemCount,
            TUserControl toUseAsAnchor_Preceding,
            bool isChangeOfEndPoint,
            TUserControl item_rangeEnd_Null);

        // Insert a range of items before a specified anchor item.  Overloaded.
        void DLL_InsertRangeBefore(TUserControl toBeInsertedRange_FirstItem, 
            int toBeInsertedRange_ItemCount, 
            TUserControl toUseAsAnchor_Terminating, 
            bool isChangeOfEndPoint);

        // Insert a range of items before a specified anchor item.
        //    (This overloaded signature includes a 2nd parameter of type TUserControl,
        //    TUserControl item_rangeEnd_Null. It's overloaded because the C# compiler
        //    didn't like my use of the Optional-Paramter syntex. ---3/12/2024)
        void DLL_InsertRangeBefore(TUserControl toBeInsertedRange_FirstItem,
            int toBeInsertedRange_ItemCount,
            TUserControl toUseAsAnchor_Terminating,
            bool isChangeOfEndPoint,
            TUserControl item_rangeEnd_Null);


        // Insert a range of items into an empty list.
        void DLL_InsertRangeEmptyList(TUserControl toBeInsertedRange_FirstItem, 
            int toBeInsertedRange_ItemCount);

        // Delete a single item from the list.
        void DLL_DeleteItem(TUserControl item_toDelete, bool isChangeOfEndPoint);

        // Delete a range of items from the list.
        void DLL_DeleteRange(TUserControl item_toDeleteBegin, int count_of_deleteds, bool isChangeOfEndPoint, TControl item_toDeleteEnd_Null = null);

        // Pop an item from the list.
        TUserControl DLL_PopItem(TUserControl item_toDelete);

        // Pop an item at a specified index from the list.
        TUserControl DLL_PopItem(int index);

        // Pop a range of items from the list.
        TUserControl DLL_PopRange(int indexStart, int countOfItemsToPop);
    }

}
