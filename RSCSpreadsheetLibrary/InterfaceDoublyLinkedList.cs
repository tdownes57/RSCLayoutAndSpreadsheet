using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCSpreadsheetLibrary
{
    public interface IDoublyLinkedList<TControl>
    {
        // Thanks to Computer Science Department at Orange Coast College
        // (Profs. Gabriela Ernsberger & Hatice Aydin) 
        // ---10/25/2023 thomas downes

        // Function DLL_ItemNext() As TControl ''Control
        // Function DLL_ItemPrior() As TControl ''Control

        // Get the item at the specified index and location.
        // <param name="index"></param>
        // <param name="confirm_distanceInPixels">This will generally be an expected number of pixels from the top.</param>
        // <returns></returns>
        TControl DLL_GetItemAtIndex(int index);
        TControl DLL_GetItemAtIndex(int index, int confirm_distanceInPixels);
        int DLL_GetIndexOfItem(TControl input_item);
        int DLL_CountItemsBefore();
        int DLL_CountItemsAfter();
        int DLL_CountAllItems();

        // This is primarily a procedure; to make it responsive, it returns the ultimate item.
        // <param name="index">The expected index of the ultimate item.</param>
        // <returns>The ultimate item created.</returns>
        TControl DLL_BuildListToIndex(int index);
        TControl DLL_BuildListToIndex(int index, ref int count_of_new_items);

        // This inserts a single item after/below/right of the anchoring item.
        // <param name="toBeInsertedSingleItem">The item to be inserted.</param>
        // <param name="toUseAsAnchor_ItemPrior">This is the item which was right-clicked just before Insert (After/Below/Right) is selected.</param>
        // <param name="isChangeOfEndPoint">Whether the endpoint is affected.</param>
        void DLL_InsertOneItemAfter(TControl toBeInsertedSingleItem, TControl toUseAsAnchor_ItemPrior, bool isChangeOfEndPoint);

        // This inserts a single item before/above/left of the anchoring item.
        // <param name="toBeInsertedSingleItem">The item to be inserted.</param>
        // <param name="toUseAsAnchor_ItemNext">This is the item which was right-clicked just before Insert (Before/Above/Left) is selected.</param>
        // <param name="isChangeOfEndPoint">Whether the endpoint is affected.</param>
        void DLL_InsertOneItemBefore(TControl toBeInsertedSingleItem, TControl toUseAsAnchor_ItemNext, bool isChangeOfEndPoint);

        // This inserts a range of items after/below/right of the anchoring item.
        // <param name="toBeInsertedRange_FirstItem">The first item in the range.</param>
        // <param name="toBeInsertedRange_ItemCount">Number of items to be inserted.</param>
        // <param name="toUseAsAnchor_Preceding">The target for the insertion.</param>
        // <param name="isChangeOfEndPoint">Whether the endpoint is affected.</param>
        void DLL_InsertRangeAfter(TControl toBeInsertedRange_FirstItem, int toBeInsertedRange_ItemCount, TControl toUseAsAnchor_Preceding, bool isChangeOfEndPoint);

        // This inserts a range of items before/above/left of the anchoring item.
        // <param name="toBeInsertedRange_FirstItem">The first item in the range.</param>
        // <param name="toBeInsertedRange_ItemCount">Number of items to be inserted.</param>
        // <param name="toUseAsAnchor_Terminating">The target for the insertion.</param>
        // <param name="isChangeOfEndPoint">Whether the endpoint is affected.</param>
        void DLL_InsertRangeBefore(TControl toBeInsertedRange_FirstItem, int toBeInsertedRange_ItemCount, TControl toUseAsAnchor_Terminating, bool isChangeOfEndPoint);

        void DLL_DeleteItem(TControl item_toDelete, bool isChangeOfEndPoint);

        // Delete a range of items. (May be a single item!)
        // <param name="item_toDeleteBegin">First item in the operating range.</param>
        // <param name="count_of_deleteds">How many items are being deleted?</param>
        // <param name="isChangeOfEndPoint">Is a change of endpoint anticipated?</param>
        void DLL_DeleteRange_Simpler(TControl item_toDeleteBegin, int count_of_deleteds, bool isChangeOfEndPoint);

        TControl DLL_PopItem(TControl item_toDelete);
        TControl DLL_PopItem(int index);
        TControl DLL_PopRange(int indexStart, int countOfItemsToPop);
    }

}
