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

            mod_dllControlFirst = par_itemStart;  // Added 10/31/2024nn
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


        public void DLL_InsertRangeBefore(DLLRange<TControl> par_range,
                 TControl par_itemAnchorToFollow)
        {
            //
            //Added 10/19/2024
            //
            if (par_itemAnchorToFollow.DLL_HasPrior())
            {
                TControl temp_prior = par_itemAnchorToFollow.DLL_GetItemPrior_OfT();
                temp_prior.DLL_SetItemNext(par_range._StartingItem);
                par_range._StartingItem.DLL_SetItemPrior(temp_prior);
            }

            par_itemAnchorToFollow.DLL_SetItemPrior_OfT(par_range._EndingItem);
            par_range._EndingItem.DLL_SetItemNext_OfT(par_itemAnchorToFollow);
             
        }


        public void DLL_InsertRangeAfter(DLLRange<TControl> par_range,
                 TControl par_itemAnchorToPrecede)
        {
            //
            //Added 10/19/2024
            //
            if (par_itemAnchorToPrecede.DLL_HasNext())
            {
                TControl temp_prior = par_itemAnchorToPrecede.DLL_GetItemPrior_OfT();
                temp_prior.DLL_SetItemNext(par_range._StartingItem);
                par_range._StartingItem.DLL_SetItemPrior(temp_prior);
            }

            par_itemAnchorToPrecede.DLL_SetItemNext_OfT(par_range._StartingItem);
            par_range._StartingItem.DLL_SetItemPrior_OfT(par_itemAnchorToPrecede);

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


        public void DLL_DeleteRange(DLLRange<TControl> par_rangeToDelete)
        {
            //
            // Added 10/31/2024 td  
            //
            //  Hypothetical list: 1 2 3 4 5.  Range is a subset of this list, 
            //   hypothetically speaking.           
            //
            TControl itemJustPrior_Eg1;
            TControl itemJustAfter_Eg5;
            bool boolDontDelete1;
            bool boolDontDelete5;
            bool bDeleteRangeIncludes1;
            bool bDeleteRangeIncludes5;

            itemJustPrior_Eg1 = par_rangeToDelete.Item_ImmediateltyPrior();
            itemJustAfter_Eg5 = par_rangeToDelete.Item__FirstToFollowButNotIncluded();

            bDeleteRangeIncludes1 = (itemJustPrior_Eg1 == null); // There is no "prior item".  Delete range includes item #1.
            bDeleteRangeIncludes5 = (itemJustAfter_Eg5 == null); // There is no "following item".  Delete range includes item #5.

            boolDontDelete1 = (itemJustPrior_Eg1 != null);  // There IS a prior item, which will REMAIN, & NOT in range. 
            boolDontDelete5 = (itemJustAfter_Eg5 != null);  // There IS a following item, which is NOT in range, & which will REMAIN.

            if (boolDontDelete1 && boolDontDelete5)
            {
                //
                // E.g. delete '2 3 4 ' from '1 2 3 4 5' to leave '1 5'.
                //
                //   The range does NOT include ANY of the END POINTS of the list...
                //     the range is fully WITHIN the list, NOT at the beginning
                //     NOR the end of the list. 
                //
                itemJustPrior_Eg1.DLL_SetItemNext_OfT(itemJustAfter_Eg5);
                itemJustAfter_Eg5.DLL_SetItemPrior_OfT(itemJustPrior_Eg1);
                _itemCount -= par_rangeToDelete.GetItemCount();
            }
            else if (bDeleteRangeIncludes1 && boolDontDelete5) 
            {
                //
                // E.g. delete '1 2 3 4' from '1 2 3 4 5' to leave '5'.
                //
                //   The DELETE range includes the STARTING POINT of the list.
                //    The DELETE range is at the extreme LEFT, or TOP, or BEGINNING, of the list. 
                //
                _itemStart = itemJustAfter_Eg5;  // Delete '1 2 3 4' from '1 2 3 4 5' to leave '5'.
                itemJustAfter_Eg5.DLL_ClearReferencePrior('D');  // 'D' for "DELETE"
                _itemCount -= par_rangeToDelete.GetItemCount();
            }
            else if (boolDontDelete1 && bDeleteRangeIncludes5)
            {
                //
                // E.g. delete '4 5' from '1 2 3 4 5' to leave '1 2 3'.
                //
                _itemEnding = itemJustPrior_Eg1;
                itemJustPrior_Eg1.DLL_ClearReferenceNext('d');
                _itemCount -= par_rangeToDelete.GetItemCount();
            }

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


        public TControl? DLL_GetItemAtIndex(int par_index)
        {
            //
            // Added 10/19/2024 thomas downes
            //
            TControl result_item = default(TControl);  // _itemStart;

            if (par_index == 0)
            {
                System.Diagnostics.Debugger.Break();
            }

            else if (par_index == 1)
            {
                return _itemStart;
            }
            else
            {
                TControl each_item = _itemStart;

                if (par_index > _itemCount)
                {
                    System.Diagnostics.Debugger.Break();
                    throw new Exception("the index exceeds the count of items");
                }

                for (int loopIndex = 1; loopIndex <= par_index; loopIndex++)
                {

                    each_item = each_item.DLL_GetItemNext_OfT();


                }

                result_item = each_item; 
                return result_item;
            }

            return result_item;  // default(TControl);  //null;

        }


        //
        //  Two methods for Selection Range: 
        //
        //      public Tuple<int, int> SelectionRange_ProcessList(
        //         int par_indexClicked,
        //         bool par_bShiftKeyPressed,
        //         bool par_bDontProcessList = false,
        //         bool par_bDontCleanPriors = false)
        //    
        private const int PLACEHOLDER = -1;
        private Tuple<int, int> mod_tupSelect_NoShiftToShift;
        private Tuple<int, int> mod_tupSelect_LowToUpper;
        private IDoublyLinkedItem mod_dllControlFirst;

        public Tuple<int, int> SelectionRange_ProcessList(
            int par_indexClicked,
            bool par_bShiftKeyPressed,
            bool par_bDontProcessList = false,
            bool par_bDontCleanPriors = false)
        {
            bool bShift = par_bShiftKeyPressed;
            int priorShifted, priorUnshifted, lowerIndex, upperIndex;

            if (mod_tupSelect_LowToUpper == null)
            {
                if (bShift)
                {
                    mod_tupSelect_NoShiftToShift = new Tuple<int, int>(PLACEHOLDER, par_indexClicked);
                }
                else
                {
                    mod_tupSelect_NoShiftToShift = new Tuple<int, int>(par_indexClicked, PLACEHOLDER);
                }

                mod_tupSelect_LowToUpper = new Tuple<int, int>(par_indexClicked, par_indexClicked);
            }
            else
            {
                priorUnshifted = mod_tupSelect_NoShiftToShift.Item1;
                priorShifted = mod_tupSelect_NoShiftToShift.Item2;

                if (bShift)
                {
                    mod_tupSelect_NoShiftToShift = new Tuple<int, int>(priorUnshifted, par_indexClicked);
                }
                else
                {
                    mod_tupSelect_NoShiftToShift = new Tuple<int, int>(par_indexClicked, PLACEHOLDER);
                }

                int index_unshifted = mod_tupSelect_NoShiftToShift.Item1;
                int index_shifted = mod_tupSelect_NoShiftToShift.Item2;

                lowerIndex = Math.Min(index_unshifted, index_shifted);
                upperIndex = Math.Max(index_unshifted, index_shifted);

                if (lowerIndex == PLACEHOLDER) lowerIndex = upperIndex;

                mod_tupSelect_LowToUpper = new Tuple<int, int>(lowerIndex, upperIndex);
            }

            if (!par_bDontProcessList)
            {
                SelectionRange_ProcessList(mod_tupSelect_LowToUpper, par_bDontCleanPriors);
            }

            return mod_tupSelect_LowToUpper;
        }


        private void SelectionRange_ProcessList(Tuple<int, int> par_range, bool par_bDontCleanPriors = false)
        {
            //IDoublyLinkedItem currentItem = mod_dllControlFirst;
            IDoublyLinkedItem currentItem = _itemStart;  // Added 10/31/2024 td 
            int currIndex = 0;
            bool bLoopIsDone = false;

            while (!bLoopIsDone)
            {
                bool bPriorToRange = currIndex < par_range.Item1;
                bool bInsideRange = !bPriorToRange && currIndex <= par_range.Item2;

                if (par_bDontCleanPriors)
                {
                    currentItem.Selected = bInsideRange || currentItem.Selected;
                }
                else
                {
                    currentItem.Selected = bInsideRange;
                }

                bool bNoMoreSettingOrCleaningLeft = par_bDontCleanPriors && currIndex > par_range.Item2;
                bLoopIsDone = currentItem.DLL_NotAnyNext() || bNoMoreSettingOrCleaningLeft;

                if (bLoopIsDone) break;

                currentItem = currentItem.DLL_GetItemNext();
                currIndex++;
            }

            //
            // End of function SelectionRange_ProcessList
            //
            //   private void SelectionRange_ProcessList
            //
        }

        //
        // End of class "public class DLLList<TControl> where TControl : IDoublyLinkedItem<TControl>"
        //

    }

}
