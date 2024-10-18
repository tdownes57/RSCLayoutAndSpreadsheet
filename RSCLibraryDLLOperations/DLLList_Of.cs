using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ciBadgeInterfaces; //Added 6/30/2024  

namespace RSCLibraryDLLOperations
{
    public class DLLList<TControl> where TControl : IDoublyLinkedItem<TControl>
    {
        //
        // Added 4/17/2024  
        //
        //     We are aware that System.Collections.Generic contains:  
        //
        //           LinkedList<T>  
        //
        //     This is an "inhouse" linked-list collection. 
        //
        public TControl _itemStart;
        public TControl _itemEnding;
        public int _itemCount;
        public bool _isEmpty_OrTreatAsEmpty; // This means that some user-initiated operation
                                             // has removed all remaining items from the list (likely, per user's intention).  
                                             // (This will relieve us from the programmatic burden of trying to Nullify
                                             //   the _itemStart object. The C# compiler might not like that.) 

        //
        // The Anchor describes the location of the imminent Insert of a Range or Item (Singly). 
        //    (or Paste, per a Cut-Paste ("Move") action. 
        //
        private DLLAnchor<TControl>? _temp_o_anchor;  // o is for object
        //Temporary boolean variables
        private bool _temp_b_anchor_CheckBooleans; // b is for Boolean 
        private bool _temp_b_anchorWill_PrecedeRange;  // b is for Boolean
        private bool _temp_b_anchorWill_FollowRange;  // b is for Boolean
        private bool _temp_b_anchorWillBeMultiUse;  // b is for Boolean

        //public DLLList()
        //{
        //    _itemCount = 0;
        //    _isEmpty_OrTreatAsEmpty = true;
        //    //_itemStart = null;
        //    //_itemEnding = null;
        //}

        public DLLList(TControl par_itemStart,
                       TControl par_itemEnding, int par_itemCount)
        {
            if (par_itemStart == null) System.Diagnostics.Debugger.Break();
            if (par_itemEnding == null) System.Diagnostics.Debugger.Break();
            if (par_itemStart == null) return; // System.Diagnostics.Debugger.Break();
            if (par_itemEnding == null) return; // System.Diagnostics.Debugger.Break();

            _itemStart = par_itemStart;
            _itemEnding = par_itemEnding;
            _itemCount = par_itemCount;
            _isEmpty_OrTreatAsEmpty = false;

            //Testing
            if (Testing.AreWeTesting)
            {
                if (par_itemStart == null) throw new RSCEndpointException();
                if (par_itemEnding == null) throw new RSCEndpointException();

                if ((_itemCount == 1) != (par_itemStart.Equals(par_itemEnding)))
                {
                    System.Diagnostics.Debugger.Break();
                }
            }

        }


        public bool Contains(TControl par_item)
        {
            //
            // Check to see if the list contains the item.
            //
            if (_isEmpty_OrTreatAsEmpty) return false;
            
            if (par_item.Equals(_itemStart)) return true;
            if (par_item.Equals(_itemEnding)) return true;

            TControl itemLocal = _itemStart;
            bool boolMatches = false;
            while (!boolMatches && itemLocal != null)
            {
                if (par_item.Equals(itemLocal)) boolMatches = true;
                else itemLocal = itemLocal.DLL_GetItemNext_OfT()
                        .DLL_UnboxControl_OfT();
            }

            return boolMatches;
        
        }


        public TControl Get_ItemAtIndex(int par_index)
        {
            //
            // Added 4/30/2024 
            //
            TControl result = _itemStart;

            if (_itemStart != null)
            {
                result = _itemStart.DLL_GetItemNext_OfT(par_index)
                    .DLL_UnboxControl_OfT();
            }

            if (result == null)
            {
                return default(TControl);
            }
            else return result; 

        }


        public void DLL_AddItemAtEnd(TControl par_itemToAdd)
        {
            //
            // Added 10/14/2024 thomas downes   
            //
            if (0 == _itemCount || _isEmpty_OrTreatAsEmpty)
            {
                _itemStart = par_itemToAdd;
                _itemEnding = par_itemToAdd; 
                _itemCount = 1;
                _isEmpty_OrTreatAsEmpty = false;
            }
            else
            {
                //TControl temp_newPenultimate = _itemEnding;
                //_itemEnding.DLL_SetItemNext_OfT(par_itemToAdd);
                //par_itemToAdd.DLL_SetItemPrior_OfT(temp_newPenultimate);
                _itemEnding.DLL_InsertItemToNext(par_itemToAdd, true);
                _itemEnding = par_itemToAdd;
                _itemCount += 1;
                _isEmpty_OrTreatAsEmpty = false;  // Probably not needed.
            }

            //Testing
            if (Testing.AreWeTesting)
            {
                //Test for equality.
                if (!_itemEnding.Equals(par_itemToAdd)) throw new RSCEndpointException();
            }

        }


        public void DLL_InsertRange(DLLRange<TControl> par_range, 
                                DLLAnchor<TControl> par_anchor, 
                                bool par_isChangeOfEndpoint)
        {
            //
            // Added 10/17/2027 td
            //
            TControl? itemAnchorLeftPrior = default(TControl);
            TControl? itemAnchorRightAft = default(TControl);

            if (par_anchor._doInsertRangeAfterThis)
            {
                itemAnchorLeftPrior = par_anchor._anchorItem;
                itemAnchorRightAft = par_anchor._anchorItem.DLL_GetItemNext_OfT();
            }
            else if (par_anchor._doInsertRangeBeforeThis)
            {
                itemAnchorLeftPrior = par_anchor._anchorItem.DLL_GetItemPrior_OfT();
                itemAnchorRightAft = par_anchor._anchorItem;
            }

            DLL_InsertRange(par_range._StartingItem, par_range._EndingItem,
                           itemAnchorLeftPrior,
                           itemAnchorRightAft);

        }


        private void DLL_InsertRange(TControl par_rangeItemFirst,
                        TControl par_rangeItemLast,
                        TControl? par_itemAnchorLeftPrior,
                        TControl? par_itemAnchorRightAft)
        {
            //
            // This private procedure does not actually expect
            //    a range object.  It expects the four(4) relevant
            //    list items. ---10/17/2024
            //
            par_itemAnchorLeftPrior?.DLL_InsertItemToNext(par_rangeItemFirst, true);
            par_itemAnchorRightAft?.DLL_InsertItemToPrior(par_rangeItemLast, true);

        }





        public void DLL_SetAnchor(DLLAnchor<TControl> par_anchor, 
                                    bool pbAnchorWill_FollowRange, 
                                    bool pbAnchorWill_PrecedeRange, 
                                    bool pbAnchorWillBeMultiUse)
        {
            //
            // Added 10/16/2024 thomas d
            //

            _temp_o_anchor = par_anchor;

            _temp_o_anchor._doInsertRangeAfterThis = pbAnchorWill_PrecedeRange;
            _temp_o_anchor._doInsertRangeBeforeThis = pbAnchorWill_FollowRange;

            _temp_b_anchorWill_FollowRange = pbAnchorWill_FollowRange;
            _temp_b_anchorWill_PrecedeRange = pbAnchorWill_PrecedeRange;
            _temp_b_anchor_CheckBooleans = true;
            _temp_b_anchorWillBeMultiUse = pbAnchorWillBeMultiUse;

        }


        public void DLL_ClearAnchor()
        {

            _temp_o_anchor = null;
            _temp_b_anchor_CheckBooleans = false;

        }


        public void DLL_InsertItemSingly(TControl par_item,
                        DLLAnchor<TControl> par_anchor,
                        bool par_isChangeOfEndpoint)
        {
            //
            // Added 10/15/2024 
            //
            if (par_anchor._doInsertRangeBeforeThis)
            {
                par_anchor._anchorItem.DLL_GetItemPrior().DLL_SetItemNext(par_item);
                par_anchor._anchorItem.DLL_SetItemPrior(par_item);
            }
            else
            { 
                par_anchor._anchorItem.DLL_GetItemNext().DLL_SetItemPrior(par_item);
                par_anchor._anchorItem.DLL_SetItemNext(par_item);
            }
        
            _itemCount++;

        }


        public void DLL_InsertItemSingly(TControl par_item)
        {
            //
            // Added 10/15/2024 
            //
            if (_temp_o_anchor == null) System.Diagnostics.Debugger.Break();
            if (_temp_o_anchor == null) throw new RSCEndpointException("InsertItemSingly");

            if (_temp_b_anchor_CheckBooleans && _temp_b_anchorWill_PrecedeRange)
            {
                _temp_o_anchor._anchorItem.DLL_InsertItemToNext(par_item, true);
            }
            else
            {
                //added 10/17/2024 
                _temp_o_anchor._anchorItem.DLL_InsertItemToPrior(par_item, true);
            }

            // Added 10/2024 
            if (_temp_b_anchorWillBeMultiUse)
            {
                // Leave temporary variables at current values. 
            }
            else
            {
                _temp_o_anchor = null;
                _temp_b_anchorWill_FollowRange = false;
                _temp_b_anchor_CheckBooleans = false;
                _temp_b_anchorWill_PrecedeRange = false;
            }
         
            _itemCount++;

        }


        public void DLL_InsertRangeIntoEmptyList(DLLRange<TControl> par_range)
        {
            //
            // Added 6/7/2024 thomas downes
            //
            _itemCount = par_range._ItemCount;
            if (0 == _itemCount) return; 

            _itemStart = par_range._StartingItem;
            //_itemEnding = _itemStart.DLL_GetItemNext(-1 + _itemCount).DLL_UnboxControl();
            _itemEnding = par_range._EndingItem;

        }


        public int DLL_CountAllItems()
        {
            //
            // Added 10/15/2024 thomas downes
            //
            return _itemCount; 


        }


        public IDoublyLinkedItem DLL_GetFirstItem()
        {
            //
            // Added 10/15/2024 thomas downes
            //
            return _itemStart;

        }

        public TControl DLL_GetFirstItem_OfT()
        {
            //
            // Added 10/15/2024 thomas downes
            //
            return _itemStart;

        }




        public IDoublyLinkedItem DLL_GetLastItem()
        {
            //
            // Added 10/15/2024 thomas downes
            //
            return _itemEnding;

        }

        public TControl DLL_GetLastItem_OfT()
        {
            //
            // Added 10/15/2024 thomas downes
            //
            return _itemEnding;

        }







    }
}
