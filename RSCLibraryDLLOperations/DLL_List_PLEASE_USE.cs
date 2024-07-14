//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System;
using System.Diagnostics;
using ciBadgeInterfaces;  // Added 6/30/2024 thomas d.

namespace RSCLibraryDLLOperations
{

    /// <summary>
    /// We use explicit casting as a way to access crucial methods.
    /// TControl is RSCFieldColumn, RSCDataHeader, or RSCDataCell.
    /// </summary>
    /// <typeparam name="TControl"></typeparam>
    public class DLL_List_PLEASE_USE<TControl> // : IDoublyLinkedList<TControl>
    {

        private IDoublyLinkedItem<TControl>? mod_dllControlFirst; // Not necessarily needed, except for testing. DLL = Doubly-Linked List.
        private readonly bool mod_bTesting = false;
        private IDoublyLinkedItem<TControl>? mod_dllControlLast; // May not be needed.  DLL = Doubly-Linked List.
        private int mod_intCountOfItems = 0; // Added 12/19/2023

        // Added 2/29/2024
        //
        // The first integer is the unshifted (no use of shift-key) integer.
        // In other words, if the user uses the mouse to click the 2nd item
        // in the list (e.g. 2nd column of spreadsheet cells)--without having
        // the Shift key pressed simultaneously--then the first integer is
        // 2 (or 1, if 0-based).   ---4/29/2024 
        //
        /// <summary>
        /// The first integer is the unshifted (no use of shift-key) integer.
        // In other words, if the user uses the mouse to click the 2nd item
        // in the list (e.g. 2nd column of spreadsheet cells)--without having
        // the Shift key pressed simultaneously--then the first integer is
        // 2 (or 1, if 0-based).
        /// </summary>
        private Tuple<int, int> mod_tupSelect_NoShiftToShift; // Added 2/29/2024
                                                              // The first integer is the lower-endpoint index.
        private Tuple<int, int> mod_tupSelect_LowToUpper; // Added 2/29/2024

        private const bool WE_CHECK_RANGE_ENDPOINTS_ALWAYS = false; // Added 12/18/2023
        private const bool WE_CHECK_RANGE_ENDPOINTS_TESTING = true; // Added 12/18/2023
        private const bool WE_CLEAN_RANGE_ENDPOINTS_ALWAYS = true; // Added 12/18/2023

        public DLL_List_PLEASE_USE(TControl par_firstItem)
        {
            if (par_firstItem is null) throw new Exception("Null value");

            // Set the initial instance variable.
            // (Also, we'll test the TControl can be converted to IDoublyLinkedItem.)
            mod_dllControlFirst = (IDoublyLinkedItem<TControl>)par_firstItem;
            // Set the Last equal to the First, as there is only one(1) item currently.
            mod_dllControlLast = mod_dllControlFirst; // Nothing
            mod_bTesting = Testing.AreWeTesting;  // .TestingByDefault
            mod_intCountOfItems = 0;
            // Test the TControl can be converted to IDoublyLinkedItem.
        }

        public DLL_List_PLEASE_USE(TControl par_firstItem, TControl par_lastItem)
        {
            // Set the initial instance variable.
            // (Also, we'll test the TControl can be converted to IDoublyLinkedItem.)
            mod_dllControlFirst = (IDoublyLinkedItem<TControl>)par_firstItem;
            mod_bTesting = Testing.AreWeTesting;  //.TestingByDefault;
            mod_dllControlLast = (IDoublyLinkedItem<TControl>)par_lastItem;
            mod_intCountOfItems = 0;
            // Test the TControl can be converted to IDoublyLinkedItem.
        }

        /// <summary>
        /// Re-initialize the list.
        /// </summary>
        public void DLL_ClearAllItems()
        {
            mod_dllControlFirst = null;
            mod_intCountOfItems = 0;
            mod_dllControlLast = null;
        }

        public void DLL_AddFirstOnlyRange(TControl p_toAddFirstItemToEmptyList, int p_intNumberOfItems)
        {
            // Insert 1 2 3 4 5 6 7 8 9 10 into empty list.
            // |
            // Start:
            // Result: 1 2 3 4 5 6 7 A 8 9 10
            bool bTesting = Testing.AreWeTesting; //ciBadgeInterfaces.Testing.TestingByDefault;
            IDoublyLinkedItem<TControl> itemFirst; // = null;

            // Testing...
            if ((bTesting && WE_CHECK_RANGE_ENDPOINTS_TESTING) || WE_CHECK_RANGE_ENDPOINTS_ALWAYS)
            {
                // Items passed as primary-operational (vs. anchors) must be cleaned
                // of references.
                if (mod_dllControlFirst != null)
                {
                    Debugger.Break();
                    throw new RSCEndpointException("First is already there");
                }
                else if (mod_dllControlLast != null)
                {
                    Debugger.Break();
                    throw new RSCEndpointException("Last is already there");
                }
                else if (mod_intCountOfItems != 0)
                {
                    Debugger.Break();
                    throw new RSCEndpointException("Count is nonzero");
                }
            }

            // Seem unnecessary, but double-check that the parameter is non-null.  
            if (p_toAddFirstItemToEmptyList != null)
            {
                itemFirst = (IDoublyLinkedItem<TControl>)p_toAddFirstItemToEmptyList;
                mod_dllControlFirst = itemFirst; // toAddFirstItemToEmptyList
                mod_dllControlLast = itemFirst.DLL_GetItemNext_OfT(-1 + p_intNumberOfItems);
                mod_intCountOfItems = p_intNumberOfItems;
            }
        }

        public void DLL_AddFirstAndOnlyItem(object each_twoCharsItem)
        {
            // Add a single item to an empty list.
            // Insert 1 into empty list.
            // |
            // Start:
            // Result: 1
            // Added 12/19/2023
            DLL_AddFirstOnlyRange((TControl)each_twoCharsItem, 1);
        }

        public void DLL_AppendRange(TControl p_firstItemOfRange, int p_intNumberOfItems)
        {
            // Insert 1 2 3 4 5 6 7 8 9 10 into empty list.
            // |
            // Start:
            // Result: 1 2 3 4 5 6 7 A 8 9 10
            DLL_InsertRangeAfter(p_firstItemOfRange, p_intNumberOfItems, 
                mod_dllControlLast.DLL_UnboxControl_OfT(), true);
        }

        public void DLL_InsertOneItemAfter(TControl p_toBeInsertedSingleItem, TControl p_toUseAsAnchor_ItemPriorToSingle, bool p_atEitherEndpoint)
        {
            // Insert A after 7, the preceding anchor.
            // |
            // 1 2 3 4 5 6 7 8 9 10
            // Result: 1 2 3 4 5 6 7 A 8 9 10
            // 12/2023
            throw new NotImplementedException();
        }

        public void DLL_InsertOneItemBefore(TControl p_toBeInsertedSingleItem, TControl p_toUseAsAnchor_ItemNextToSingle, bool p_isChangeOfEndpoint)
        {
            // Insert x before 6, the terminating anchor (6).
            // |
            // 1 2 3 4 5 6 7 8 9 10
            // Result: 1 2 3 4 5 x 6 7 8 9 10
            // 12/2023
            throw new NotImplementedException();
        }

        public void DLL_InsertRangeEmptyList(TControl p_toBeInsertedRange_FirstItem, int p_toBeInsertedRange_ItemCount)
        {
            // Added 12/31/2023 td
            IDoublyLinkedItem<TControl> itemFirstItemToInsert = null;
            IDoublyLinkedItem<TControl> itemLastItemToInsert = null;
            int intHowManyItems = p_toBeInsertedRange_ItemCount;

            //-----------------------------------------------------------------------------------------------------
            //---- DIFFICULT AND CONFUSING ----
            // If possible, capture a reference to the last item in the list at the time of the insertion.
            // It is possible because the list is empty.  But if it is not possible, because the list is empty,
            // then the first item in the list (dllControlFirst) is set to a reference to the first item to be inserted
            // (a.k.a., p_toBeInsertedRange_FirstItem).
            //-----------------------------------------------------------------------------------------------------
            if (mod_dllControlFirst != null)
            {
                Debugger.Break();
                throw new RSCEndpointException("List not empty");
            }
            if (mod_dllControlLast != null)
            {
                Debugger.Break();
                throw new RSCEndpointException("Last exists");
            }

            mod_dllControlFirst = itemFirstItemToInsert;
            mod_dllControlLast = itemLastItemToInsert;
            mod_intCountOfItems = intHowManyItems;
        }

        public void DLL_InsertRangeAfter(TControl p_firstItemToInsert, int p_itemCount, TControl p_anchorItemPriorToRangeToInsert, bool p_atEitherEndpoint)
        {
            // Insert A 8 9 10 after 7.
            // |
            // 1 2 3 4 5 6 7 8 9 10
            // Result: 1 2 3 4 5 6 7 A 8 9 10
            // 12/2023
            throw new NotImplementedException();
        }

        public void DLL_InsertRangeBefore(TControl p_firstItemToInsert, int p_itemCount, TControl p_anchorItemNextToRangeToInsert, bool p_isChangeOfEndpoint)
        {
            // Insert x 8 9 10 before 6.
            // |
            // 1 2 3 4 5 6 7 8 9 10
            // Result: 1 2 3 4 5 x 6 7 8 9 10
            // 12/2023
            throw new NotImplementedException();
        }

        public void DLL_RemoveSingleItem(TControl p_toBeRemovedSingleItem)
        {
            // Remove 7.
            // |
            // 1 2 3 4 5 6 7 8 9 10
            // Result: 1 2 3 4 5 6 8 9 10
            // 12/2023
            throw new NotImplementedException();
        }

        public void DLL_RemoveRange(TControl p_firstItemInToRemoveRange, int p_countOfItemsToRemove)
        {
            // Remove A 8 9 10.
            // |
            // 1 2 3 4 5 6 7 A 8 9 10
            // Result: 1 2 3 4 5 6 7
            // 12/2023
            throw new NotImplementedException();
        }

        public TControl DLL_GetAnItem(int p_Index)
        {
            // Added 12/2023
            TControl result_item; // = default;
            //bool bTesting = ciBadgeInterfaces.Testing.TestingByDefault;
            bool bTesting = Testing.AreWeTesting;
            // Will be changed
            IDoublyLinkedItem<TControl> temp = mod_dllControlFirst;
            int each_index = 1;

            while (each_index < p_Index && temp.DLL_GetItemNext() != null)
            {
                temp = temp.DLL_GetItemNext_OfT();
                each_index += 1;
            }
            if (each_index != p_Index)
            {
                Debugger.Break();
                throw new RSCEndpointException("Not found");
            }

            result_item = (TControl)temp;
            return result_item;

        }

        public TControl DLL_GetFirstItem()
        {
            // Added 12/2023
            return (TControl)mod_dllControlFirst;
        }

        public TControl DLL_GetLastItem()
        {
            // Added 12/2023
            return (TControl)mod_dllControlLast;
        }

        public int DLL_Count()
        {
            // Added 12/2023
            return mod_intCountOfItems;
        }

        public TControl DLL_RetrieveRemoveFirstItem()
        {
            // Added 12/2023
            throw new NotImplementedException();
        }

        public TControl DLL_RetrieveRemoveLastItem()
        {
            // Added 12/2023
            throw new NotImplementedException();
        }

        public void DLL_TestValuesInList()
        {
            // Added 12/2023
            throw new NotImplementedException();
        }

        public void DLL_RemoveEmptyList()
        {
            // Added 12/2023
            throw new NotImplementedException();
        }

        public bool DLL_IsEmpty()
        {
            // Added 12/2023
            return mod_intCountOfItems == 0;
        }


        public void DLL_DeleteItem(TControl p_item_toDelete, bool p_isChangeOfEndpoint)
        {
            IDoublyLinkedItem<TControl> itemToDelete = (IDoublyLinkedItem<TControl>)p_item_toDelete;
            IDoublyLinkedItem<TControl> itemPriorToDelete = null;
            IDoublyLinkedItem<TControl> itemFollowingDelete = null;
            bool bDeletingEndOfList;
            bool bDeletingStartOfList;

            bDeletingEndOfList = itemToDelete.DLL_NotAnyNext();
            bDeletingStartOfList = itemToDelete.DLL_NotAnyPrior();

            if (bDeletingStartOfList)
            {
                if (!p_isChangeOfEndpoint)
                    throw new RSCEndpointException("No endpoint specified.");

                itemFollowingDelete = itemToDelete.DLL_GetItemNext_OfT();

                if (itemFollowingDelete == null)
                {
                    // We are probably deleting the ONE & ONLY item in the list.
                }
                else
                {
                    itemFollowingDelete.DLL_ClearReferencePrior('D');
                }
            }
            else if (bDeletingEndOfList)
            {
                if (!p_isChangeOfEndpoint)
                    throw new RSCEndpointException("No endpoint specified.");

                itemPriorToDelete = itemToDelete.DLL_GetItemPrior_OfT();
                itemPriorToDelete.DLL_ClearReferenceNext('D');
            }
            else
            {
                itemPriorToDelete = itemToDelete.DLL_GetItemPrior_OfT();
                itemFollowingDelete = itemToDelete.DLL_GetItemNext_OfT();
                itemPriorToDelete.DLL_SetItemNext(itemFollowingDelete);
                itemFollowingDelete.DLL_SetItemPrior(itemPriorToDelete);
            }

            if (bDeletingStartOfList && bDeletingEndOfList)
            {
                mod_dllControlFirst = null;
                mod_dllControlLast = null;
            }
            else if (bDeletingStartOfList)
            {
                mod_dllControlFirst = itemFollowingDelete;
            }
            else if (bDeletingEndOfList)
            {
                mod_dllControlLast = itemPriorToDelete;
            }

            if (WE_CLEAN_RANGE_ENDPOINTS_ALWAYS)
            {
                itemToDelete.DLL_ClearReferencePrior('D');
                itemToDelete.DLL_ClearReferenceNext('D');
            }

            mod_intCountOfItems--;
        }

        private IDoublyLinkedItem GetLastItemInRange(IDoublyLinkedItem<TControl> p_itemFirstInRange, 
                                       int p_countOfItemsInRange, 
                                       IDoublyLinkedItem<TControl> p_itemLast_Nullable)
        {
            //
            // Modified 4/29/2024 thomas downes
            //
            IDoublyLinkedItem result_itemLast;
            bool bNoLastItemProvided = (p_itemLast_Nullable == null);

            if (bNoLastItemProvided)
            {
                result_itemLast = p_itemFirstInRange.DLL_GetItemNext(-1 + p_countOfItemsInRange);
            }
            else if (Testing.AreWeTesting)  // .TestingByDefault)
            {
                IDoublyLinkedItem<TControl> itemTemp1;
                IDoublyLinkedItem<TControl> itemTemp2;
                itemTemp1 = p_itemLast_Nullable;
                itemTemp2 = p_itemFirstInRange.DLL_GetItemNext_OfT(-1 + p_countOfItemsInRange);
                bool boolMatches = itemTemp1.Equals(itemTemp2);
                if (!boolMatches) Debugger.Break();
                result_itemLast = p_itemLast_Nullable;
            }
            else
            {
                result_itemLast = p_itemLast_Nullable;
            }

            return result_itemLast;
        }

        public void DLL_DeleteRange(TControl p_item_toDeleteFirst, int p_count_of_deleteds, 
                                  bool p_isChangeOfEndpoint, 
                                  TControl p_item_toDeleteEnd)
        {
            IDoublyLinkedItem<TControl> itemToDeleteFirst = (IDoublyLinkedItem<TControl>)p_item_toDeleteFirst;
            IDoublyLinkedItem<TControl> itemToDeleteLast = (IDoublyLinkedItem<TControl>)p_item_toDeleteEnd;

            //itemToDeleteLast = GetLastItemInRange(p_item_toDeleteFirst, p_count_of_deleteds, 
            //                       p_item_toDeleteEnd_Nullable);
            //itemToDeleteLast = GetLastItemInRange(itemToDeleteFirst, p_count_of_deleteds,
            //                                       itemToDeleteLast);

            IDoublyLinkedItem<TControl> itemPriorToDeleteRange = null;
            IDoublyLinkedItem<TControl> itemFollowingDeleteRange = null;
            bool bDeletingListStartingPoint;
            bool bDeletingListEndingPoint;

            bDeletingListStartingPoint = itemToDeleteFirst.DLL_NotAnyPrior();
            bDeletingListEndingPoint = itemToDeleteLast.DLL_NotAnyNext();

            if (bDeletingListStartingPoint)
            {
                if (!p_isChangeOfEndpoint)
                    throw new RSCEndpointException("No endpoint specified.");

                itemFollowingDeleteRange = itemToDeleteFirst.DLL_GetItemNext_OfT();
            }
            else
            {
                itemPriorToDeleteRange = itemToDeleteFirst.DLL_GetItemPrior_OfT();
            }

            if (bDeletingListEndingPoint)
            {
                if (!p_isChangeOfEndpoint)
                    throw new RSCEndpointException("No endpoint specified.");
            }
            else
            {
                itemFollowingDeleteRange = itemToDeleteLast.DLL_GetItemNext_OfT();
            }

            if (bDeletingListStartingPoint && bDeletingListEndingPoint)
            {
                mod_dllControlFirst = null;
                mod_dllControlLast = null;
            }
            else if (bDeletingListStartingPoint)
            {
                mod_dllControlFirst = itemFollowingDeleteRange;
                mod_dllControlFirst.DLL_ClearReferencePrior('D');
            }
            else if (bDeletingListEndingPoint)
            {
                mod_dllControlLast = itemPriorToDeleteRange;
                mod_dllControlLast.DLL_ClearReferenceNext('D');
            }
            else
            {
                itemPriorToDeleteRange.DLL_SetItemNext(itemFollowingDeleteRange);
                itemFollowingDeleteRange.DLL_SetItemPrior(itemPriorToDeleteRange);
            }

            if (WE_CLEAN_RANGE_ENDPOINTS_ALWAYS)
            {
                itemToDeleteFirst.DLL_ClearReferencePrior('D');
                itemToDeleteLast.DLL_ClearReferenceNext('D');
            }

            mod_intCountOfItems -= p_count_of_deleteds;
        }

        public TControl DLL_GetItemAtIndex(int par_index)
        {
            if (par_index == 0)
            {
                return mod_dllControlFirst.DLL_UnboxControl_OfT();
            }
            else
            {
                IDoublyLinkedItem<TControl> each_item = mod_dllControlFirst;

                for (int indexFor = 1; indexFor <= par_index; indexFor++)
                {
                    if (each_item.DLL_NotAnyNext())
                    {
                        Debugger.Break();
                    }

                    each_item = each_item.DLL_GetItemNext_OfT();    
                }

                return (TControl)each_item;

            }
        }

        public bool DLL_IsListEmpty()
        {
            bool result_bEmptyList;
            bool bMatchesCount;

            result_bEmptyList = (mod_dllControlFirst == null);
            bMatchesCount = (result_bEmptyList == (mod_intCountOfItems == 0));

            if (!bMatchesCount) Debugger.Break();

            return result_bEmptyList;
        }

        public int DLL_GetIndexOfItem(TControl input_item)
        {
            IDoublyLinkedItem<TControl> linkedItem;
            int index;

            linkedItem = (IDoublyLinkedItem<TControl>)input_item;
            index = 0;

            while (linkedItem != mod_dllControlFirst)
            {
                linkedItem = linkedItem.DLL_GetItemPrior_OfT();    
                index++;
            }

            return index;
        }






    }


}
