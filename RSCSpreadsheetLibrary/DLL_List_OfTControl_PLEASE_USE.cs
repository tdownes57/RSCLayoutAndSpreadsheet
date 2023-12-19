using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCSpreadsheetLibrary
{
    using System;

    /// <summary>
    /// We use explicit casting as a way to access crucial methods. 
    /// TControl is RSCFieldColumn, RSCDataHeader, or RSCDataCell.
    /// </summary>
    /// <typeparam name="TControl"></typeparam>
    public class DLL_List_OfTControl_PLEASE_USE<TControl> : IDoublyLinkedList<TControl>
    {

        private IDoublyLinkedItem mod_dllControlFirst; // Not necessarily needed, except for testing. DLL = Doubly-Linked List.
        private bool mod_bTesting;
        private IDoublyLinkedItem mod_dllControlLast; // May not be needed. DLL = Doubly-Linked List.

        private const bool WE_CHECK_RANGE_ENDPOINTS_ALWAYS = false; // Added 12/18/2023
        private const bool WE_CHECK_RANGE_ENDPOINTS_TESTING = true; // Added 12/18/2023
        private const bool WE_CLEAN_RANGE_ENDPOINTS_ALWAYS = true; // Added 12/18/2023

        // Constructors...

        public DLL_List_OfTControl_PLEASE_USE(TControl par_firstItem)
            {

                 //''
        //''Set the initial instance variable.
        //''
        mod_dllControlFirst = (IDoublyLinkedItem) par_firstItem;

        mod_bTesting = Testing.TestingByDefault;


    }



        public void DLL_InsertOneItemAfter(TControl p_toBeInsertedSingleItem, TControl p_toUseAsAnchor_ItemPriorToSingle, bool p_isChangeOfEndpoint)
        {
            // Method implementation...
        }

        public void DLL_InsertOneItemBefore(TControl p_toBeInsertedSingleItem, TControl p_toUseAsAnchor_ItemNextToSingle, bool p_isChangeOfEndpoint)
        {
            // Method implementation...
        }

        public void DLL_InsertRangeAfter(TControl p_toBeInsertedRange_FirstItem, int p_toBeInsertedRange_ItemCount, TControl p_toUseAsAnchor_ItemPriorToRange, bool p_bIsChangeOfEndPoint)
        {
            // Method implementation...
        }

        public void DLL_InsertRangeBefore(TControl p_toBeInsertedRange_FirstItem, int p_toBeInsertedRange_ItemCount, TControl p_toUseAsAnchor_ItemNextToRange, bool p_bIsChangeOfEndPoint)
        {
            // Method implementation...
        }

        public void DLL_DeleteItem(TControl p_item_toDelete, bool p_isChangeOfEndpoint)
        {
            // Method implementation...
        }

        public void DLL_DeleteRange_Simpler(TControl item_toDeleteBegin, int count_of_deleteds, bool isChangeOfEndpoint)
        {
            // Method implementation...
        }

        public TControl DLL_GetItemAtIndex(int par_index)
        {
            // Method implementation...
        }

        public TControl DLL_GetItemAtIndex(int par_index, int ptest_cellAlignswHeader)
        {
            // Method implementation...
        }

        public int DLL_GetIndexOfItem(TControl input_item)
        {
            throw new NotImplementedException();
        }

        public int DLL_CountItemsBefore()
        {
            throw new NotImplementedException();
        }

        public int DLL_CountItemsAfter()
        {
            throw new NotImplementedException();
        }

        public int DLL_CountAllItems()
        {
            throw new NotImplementedException();
        }

        public TControl DLL_BuildListToIndex(int index)
        {
            throw new NotImplementedException();
        }

        public TControl DLL_BuildListToIndex(int index, ref int count_of_new_items)
        {
            throw new NotImplementedException();
        }

        public TControl DLL_PopItem(TControl item_toDelete)
        {
            throw new NotImplementedException();
        }

        public TControl DLL_PopItem(int index)
        {
            throw new NotImplementedException();
        }

        public TControl DLL_PopRange(int indexStart, int countOfItemsToPop)
        {
            throw new NotImplementedException();
        }

        // Implement the rest of the interface methods...
    }
}
