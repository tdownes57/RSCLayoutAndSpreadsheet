//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Security;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;  
using ciBadgeInterfaces;
using System;
using System.Numerics;
using System.Text; //Added 6/20/2024  

namespace RSCLibraryDLLOperations
{
    public class DLLRange<TControl> where TControl : class, IDoublyLinkedItem<TControl>
    {
        //
        // Added 4/20/2024 Thomas Downes
        //
        //public readonly bool _isSingleItem;
        public bool _isSingleItem;
        //----public readonly TControl? _SingleItemInRange;
        public TControl? _SingleItemInRange;
        //public readonly TControl _StartingItem;
        //----public readonly TControl _StartingItem; // Modified 11/08/2024 thomas downes
        public readonly TControl _StartingItem; // Modified 11/08/2024 thomas downes
        //public readonly TControl _EndingItem;
        public TControl _EndingItem;
        public int _ItemCount; // readonly

        // Added 4/20/2024 thomas downes
        public readonly TControl? _InverseAnchor_Prior;
        public readonly TControl? _InverseAnchor_After;



        public DLLRange(TControl par_itemSingle, bool par_bMustBeCleanOfLinks)
        {
            //
            // A singleton item.
            // 
            if (par_bMustBeCleanOfLinks && Testing.AreWeTesting)
            {
                if (par_itemSingle.DLL_HasNext()) System.Diagnostics.Debugger.Break();
                if (par_itemSingle.DLL_HasPrior()) System.Diagnostics.Debugger.Break();
            }

            _isSingleItem = true;
            _SingleItemInRange = par_itemSingle;
            _StartingItem = par_itemSingle;
            _ItemCount = 1;
            // Added 11/10/2024 
            _EndingItem = par_itemSingle;

        }


        public DLLRange(TControl par_itemStarting, TControl par_itemEnding)
        {
            //
            // Added 11/13/2024 
            //
            //_SingleItemInRange = null;
            _StartingItem = par_itemStarting;
            _EndingItem = par_itemEnding;
            _ItemCount = (1 + _StartingItem.DLL_GetDistanceTo(_EndingItem));

        }


        public DLLRange(DLLList<TControl> par_list, Tuple<int, int> par_tuple)
        {
            //
            // Added 11/15/2024 thomas downes
            //
            _StartingItem = par_list.Get_ItemAtIndex(par_tuple.Item1);
            _EndingItem = par_list.Get_ItemAtIndex(par_tuple.Item2);  // Added 11/17/2024   .Item1);
            //return new DLLRange<TControl>(itemStart, item_Last);
            _ItemCount = (1 + par_tuple.Item2 - par_tuple.Item1);
            _isSingleItem = (par_tuple.Item1 == par_tuple.Item2);

        }


        public DLLRange(bool par_isSingleItem, TControl par_itemStart,
                          TControl? par_itemEnding,
                          TControl? par_itemSingle, int par_itemCount)
        {
            //_isSingleItem = par_isSingleItem;
            _SingleItemInRange = par_itemSingle;
            _StartingItem = par_itemStart;
            _ItemCount = par_itemCount;
            _EndingItem = par_itemStart;
            _isSingleItem = par_isSingleItem;

            if (_isSingleItem && (par_itemSingle != null))
            {
                //
                // This is a single-item range.
                //
                _SingleItemInRange = par_itemSingle;

                _StartingItem = par_itemSingle;
                _EndingItem = par_itemSingle;

            }
            else if (par_itemEnding != null)
            {
                //
                // This is probably _NOT_ a single-item range.
                //   There is a ending item.
                //
                _StartingItem = par_itemStart;
                _EndingItem = par_itemEnding;

                //Administration.  Set _itemCount.
                if (_ItemCount <= 0)
                {
                    //_itemCount = _itemStart.DLL_CountItemsAllInList(); // Won't work.  This
                    //     is a range, i.e. a subset of a list, not an entire list. 
                    //_itemCount = (1 + _itemEnding.DLL_Subtract(_itemStart));
                    _ItemCount = (1 + DLL_Distance(_StartingItem, _EndingItem));

                }
                else if (Testing.AreWeTesting)
                {
                    bool bTestMatch;
                    if (par_itemCount > 0)
                    {
                        var nextIterativelyByCount = _StartingItem
                            .DLL_GetItemNext_OfT(par_itemCount - 1);
                        bTestMatch = (_EndingItem.Equals(nextIterativelyByCount));
                        if (!bTestMatch) System.Diagnostics.Debugger.Break();
                    }
                }

            }
            else if (_StartingItem != null)
            {
                //
                // This is probably _NOT_ a single-item range.
                //   There is a distinct beginning and an end.
                //
                //--Jun30 2024-_EndingItem = _StartingItem.DLL_GetItemNext(itemCount - 1).DLL_UnboxControl();
                _EndingItem = _StartingItem
                    .DLL_GetItemNext_OfT(par_itemCount - 1)
                    .DLL_UnboxControl_OfT();

            }

            //
            // Administrative--Set the Inverse Anchors.  
            //
            _InverseAnchor_Prior = _StartingItem // par_itemStart
                .DLL_GetItemPrior_OfT();

            if (par_itemEnding != null)
            {
                //_InverseAnchor_After = par_itemEnding
                //    .DLL_GetItemNext_OfT();
                _InverseAnchor_After = _EndingItem
                    .DLL_GetItemNext_OfT();
            }
            else if (par_itemCount == 1)
            {
                //_InverseAnchor_After = par_itemStart
                //    .DLL_GetItemNext_OfT();
                _InverseAnchor_After = _StartingItem
                    .DLL_GetItemNext_OfT();
            }
            else
            {
                // Unclear what to do.  Stop & think about it.
                System.Diagnostics.Debugger.Break();
            }

            //Added 6/30/2024
            if (_StartingItem == null) _StartingItem = par_itemStart;
            if (_StartingItem == null) _StartingItem = par_itemSingle;
            if (_EndingItem == null) _EndingItem = par_itemStart;
            if (_EndingItem == null) _EndingItem = par_itemSingle;

        }


        public DLLRange<TBase56> GetConvertToGenericOfT<TBase56>() 
            where TBase56 : class, IDoublyLinkedItem<TBase56>
        {
            //
            // Added 12/07/2024 thoma.s downe.s 
            //
            TBase56 object56_s = _StartingItem as TBase56;
            TBase56 object56_e = _EndingItem as TBase56;

            DLLRange<TBase56> result = new DLLRange<TBase56>(object56_s, object56_e);

            return result; 

        }


        public void DLL_InsertItemToTheEnd(TControl par_newItem)
        {
            //
            // First, a clean-up step!! 
            //
            //if (_StartingItem == null)
            //{
            //    //
            //    // Added 11/8/2024 thomas downes
            //    //
            //    _StartingItem = par_newItem;
            //    _EndingItem = par_newItem;
            //}
            if (_EndingItem == null)
            {
                if (_ItemCount == 1) _EndingItem = _StartingItem;
            }

            //if (_EndingItem != null)
            //{

            _EndingItem.DLL_SetItemNext(par_newItem);
            par_newItem.DLL_SetItemPrior(_EndingItem);
            _EndingItem = par_newItem;
            _ItemCount++;
            _isSingleItem = false; //Added 11/12/2024 
            _SingleItemInRange = default(TControl); // null;  // Added 11/12/2024 

            //}

        }


        private int DLL_Distance(TControl par_start, TControl par_ending)
        {
            //
            // Added 4/17/2024  
            //
            if (par_start.Equals(par_ending)) return 0;
            if (par_ending == null) System.Diagnostics.Debugger.Break();
            if (par_start == null)
            {
                System.Diagnostics.Debugger.Break();
                throw new InvalidOperationException();
            }

            TControl item = par_start.DLL_GetItemNext_OfT().DLL_UnboxControl_OfT();
            int intResult = 0;

            while (item != null)
            {
                intResult++;
                if (item.Equals(par_ending)) break;
                item = item.DLL_GetItemNext_OfT().DLL_UnboxControl_OfT();
            }

            //
            // Output the result.
            //
            if (item != null) return intResult;
            else
            {
                System.Diagnostics.Debugger.Break();
                throw new InvalidOperationException("Loop was unsuccessful.");
            }

        }


        public Boolean CheckEndpointsAreClean_PriorToInsert()
        {
            //
            // Added 7/11/2024  
            //
            bool bCleanStart = !_StartingItem.DLL_HasPrior();
            bool bCleanFinish = !_EndingItem.DLL_HasNext();

            bool result_cleanBoth = (bCleanStart && bCleanFinish);
            return result_cleanBoth;

        }


        public TControl ItemStart()
        {
            // Added 10/27/2024 
            //
            // Consistent with the theory of encapsulation, this Function is managing
            //   the internal class members & so we will avoid return 
            //   a Null value, as best we can. 
            //
            TControl result = (_StartingItem != null ? _StartingItem : _SingleItemInRange);
            return result;

        }


        public TControl Item__End()
        {
            // Added 10/27/2024 
            //
            // Consistent with the theory of encapsulation, this Function is managing
            //   the internal class members & so we will avoid return 
            //   a Null value, as best we can. 
            //
            TControl result = (_EndingItem != null ? _EndingItem : _SingleItemInRange);
            return result;

        }


        public TControl Item__FirstToFollowButNotIncluded()
        {
            // Added 10/31/2024 
            //
            // Consistent with the theory of encapsulation, this Function is managing
            //   the internal class members & so we will avoid return 
            //   a Null value, as best we can. 
            //
            TControl result1 = (_EndingItem != null ? _EndingItem : _SingleItemInRange); //.DLL_GetItemNext_OfT();
            TControl result_final = result1.DLL_GetItemNext_OfT();
            return result_final;

        }


        public TControl? Item_ImmediatelyPrior()
        {
            // Added 10/31/2024 
            //
            // Consistent with the theory of encapsulation, this Function is managing
            //   the internal class members & so we will avoid return 
            //   a Null value, as best we can. 
            //
            TControl result1 = _StartingItem; //.DLL_GetItemNext_OfT();
            TControl? result_final = result1.DLL_GetItemPrior_OfT();
            return result_final;

        }


        public TControl? Item_ImmediatelyAfter()
        {
            // Added 11/22/2024 
            //
            // Consistent with the theory of encapsulation, this Function is managing
            //   the internal class members & so we will avoid return 
            //   a Null value, as best we can. 
            //
            TControl result1 = _EndingItem; //.DLL_GetItemNext_OfT();
            TControl? result_final = result1.DLL_GetItemNext_OfT();
            return result_final;

        }


        public int GetItemCount()
        {
            //
            // Added 10/31/2024 thomas downes
            //
            if (_ItemCount > 0)
            {
                return _ItemCount;
            }
            else
            {
                return (-1 + _StartingItem.DLL_GetDistanceTo(_EndingItem));

            }


        }


        public int GetFirstItemIndex()
        {
            //
            // Added 11/12/2024 td
            // 
            return _StartingItem.DLL_GetItemIndex();

        }


        public bool IsSingleItem()
        {
            // Added 11/10/2024 td
            return (1 == _ItemCount);

        }


        public bool ContainsEndpoint()
        {
            //
            // Added 11/17/2024 thomas downes
            //
            bool bResult;
            bool bNoPreceding;
            bool bNoFollowing;

            // Added 11/09/2024 t.downes
            if (_EndingItem == null && _ItemCount > 0)
            {
                // Populate the _EndingItem.
                _EndingItem = _StartingItem.DLL_GetItemNext_OfT(-1 + _ItemCount);
            }

            bNoPreceding = (false == _StartingItem.DLL_HasPrior());
            bNoFollowing = (false == _EndingItem.DLL_HasNext());
            bResult = (bNoPreceding || bNoFollowing);
            return bResult;

        }


        public bool ContainsItem(TControl par_item)
        {
            //
            // This is an "alias" function, the original function being
            //    Check_ContainsItem(). ----11/18/2024 
            //
            return Check_ContainsItem(par_item);
        }


        /// <summary>
        /// Check for anomaly--the range containing one (or both) of the elements of the anchor.
        /// </summary>
        /// <param name="tempAnchorPair"></param>
        /// <returns></returns>
        public bool Check_ContainsAnchorPair(DLLAnchorCouplet<TControl> par_pair)
        {
            //
            // Check for anomalies--specifically, the range containing one (or both) of the elements of the anchor. 
            //
            bool result_isAnomalous = false;
            bool bLocatedLeft = false;  // Default value
            bool bLocatedRight = false; // Default value
            bool bLocatedNeither = false;  // Default value
            bool bContainsAnchLeft = false;  // default value 
            bool bContainsAnchRight = false;  // default value 

            TControl itemAnchLeft = par_pair.GetItemLeftOrFirst();
            TControl itemAnchRight = par_pair.GetItemRightOrSecond();
            bContainsAnchLeft = ContainsItem(itemAnchLeft);
            bContainsAnchRight = ContainsItem(itemAnchRight);

            result_isAnomalous = (bContainsAnchLeft || bContainsAnchRight);
            return result_isAnomalous;

        }


        public  bool Check_EnclosedByAnchorPair(DLLAnchorCouplet<TControl> par_pair)
        {
            //
            // Added 11/18/2024 thomas downes
            //
            bool result_bothSides = false; 
            bool bMatchesPriorToRange = true;  // default to true
            bool bMatchesAfterRange = true;  // default to true 

            //--if (par_pair.ItemFirstIsPresent())
            //--{
                //---bMatchesPriorToRange = (Item_ImmeditelyPrior().Equals(par_pair.GetItemLeftOrFirst()));
                TControl? itemPriorToRange = Item_ImmediatelyPrior();
                TControl? itemAnchorLeft = par_pair.GetItemLeftOrFirst();

                if (itemPriorToRange == null && itemAnchorLeft != null)
                {
                    bMatchesPriorToRange = false;
                }
                else if (itemPriorToRange != null && itemAnchorLeft == null)
                {
                    bMatchesPriorToRange = false;
                }
                else if (itemPriorToRange == null && itemAnchorLeft == null)
                {
                    bMatchesPriorToRange = true;
                }
                else if (itemPriorToRange != null && itemAnchorLeft != null)
                { 
                    //bMatchesPriorToRange = (bool)(itemPriorToRange.Equals(itemAnchorLeft));
                    bMatchesPriorToRange = (itemPriorToRange == itemAnchorLeft);
                }

            //---}

            //---if (par_pair.ItemSecondIsPresent())
            //---{
                //---bMatchesAfterRange = (Item_ImmediatelyPrior().Equals(par_pair.GetItemLeftOrFirst()));
                TControl? itemAfterRange = Item_ImmediatelyAfter();
                TControl? itemAnchorRight = par_pair.GetItemRightOrSecond();

                //bMatchesAfterRange = (bool)(itemAfterRange?.Equals(itemAnchorRight));
                if (itemAfterRange == null && itemAnchorRight != null)
                {
                    bMatchesAfterRange = false;
                }
                else if (itemAfterRange != null && itemAnchorRight == null)
                {
                    bMatchesAfterRange = false;
                }
                else if (itemAfterRange == null && itemAnchorRight == null)
                {
                    bMatchesAfterRange = true;
                }
                else if(itemAfterRange != null && itemAnchorRight != null)
                {
                    //bMatchesAfterRange = (bool)(itemAfterRange?.Equals(itemAnchorRight));
                    bMatchesAfterRange = (itemAfterRange == itemAnchorRight);
                }

            //--}

            result_bothSides = (bMatchesPriorToRange && bMatchesAfterRange);
            return result_bothSides;

        }


        public bool Check_ContainsItem(TControl par_item)
        {
            //
            // Added 11/18/2024 
            //
            bool bLocatedItem = false;
            bool result_inRange = false;

            // Added 12/9/2024 thomas d.
            if (par_item == null) 
            { 
                return false; 
            }

            int intDistanceToItem = _StartingItem.DLL_GetDistanceTo(par_item, ref bLocatedItem);

            if (bLocatedItem)
            {
                //result_inRange = (0 < intDistanceToItem && intDistanceToItem < _ItemCount);
                result_inRange = (0 <= intDistanceToItem && intDistanceToItem < _ItemCount);
            }
            else
            {
                result_inRange = false;
            }

            return result_inRange;

        }



        public void DeleteFromList_noAdmin()
        {
            //
            // Added 11/3/2024 td  
            //
            //   Top-tier DLL connection work will be done here. 
            //
            //   (Any second-tier administration will NOT be done here.) 
            //
            TControl? itemPriorToRange = ItemStart().DLL_GetItemPrior_OfT();
            TControl? itemAfterRange = Item__End().DLL_GetItemNext_OfT();

            ItemStart().DLL_ClearReferencePrior('D');
            Item__End().DLL_ClearReferenceNext('D');

            if (itemPriorToRange != null) itemPriorToRange.DLL_SetItemNext_OfT(itemAfterRange, true);
            if (itemAfterRange != null) itemAfterRange.DLL_SetItemPrior_OfT(itemPriorToRange, true);

        }


        public void DeleteFromList_wAdmin(DLLList<TControl> par_listForAdmin)
        {
            //
            // Added 11/3/2024 td  
            //
            //  This will include "DIFFICULT & CONFUSING" 2nd-tier
            //    administrative work. 
            //
            TControl? itemPriorToRange = ItemStart().DLL_GetItemPrior_OfT();
            TControl? itemAfterRange = Item__End().DLL_GetItemNext_OfT();

            bool bRangeIsAtStartOfList = (itemPriorToRange == null);
            bool bRangeIsAtEndingOfList = (itemAfterRange == null);

            //
            // Major call!!   Do the top-tier DLL work. 
            //
            DeleteFromList_noAdmin();

            //
            // DIFFICULT & CONFUSING -- ADMINISTRATION OF LIST 
            //
            //   Set the new endpoints, and reduce the list's item count. 
            //
            //oops!! 12/09/2024  if (bRangeIsAtStartOfList) par_listForAdmin._itemStart = this.ItemStart();
            //oops!! 12/09/2024  if (bRangeIsAtEndingOfList) par_listForAdmin._itemEnding = this.Item__End();
            if (bRangeIsAtStartOfList) par_listForAdmin._itemStart = itemAfterRange; // this.ItemStart();
            if (bRangeIsAtEndingOfList) par_listForAdmin._itemEnding = itemPriorToRange; // this.Item__End();

            // Reduce the item count of the list, by the number of items in the range. 
            //   (Notice we are using the subtraction -= operator.)
            int numberOfRangeItems = this._ItemCount;
            par_listForAdmin._itemCount -= numberOfRangeItems; // Notice the -= operator.

        }


        public void EncloseRangeInCouplet(DLLAnchorCouplet<TControl> par_anchorPair)
        {
            //
            // Added 11/03/2024 
            //
            par_anchorPair.EncloseRange(this);

        }


        public DLLAnchorCouplet<TControl> GetCoupletWhichEncloses_InverseAnchor()
        {
            //
            // Added 11/-7/2024 T. Downes 
            //
            DLLAnchorCouplet<TControl> resultInverseAnchor;
            TControl? itemPrior = ItemStart().DLL_GetItemPrior_OfT();
            TControl? itemAfter = Item__End().DLL_GetItemNext_OfT();
            resultInverseAnchor = new DLLAnchorCouplet<TControl>(itemPrior, itemAfter, ContainsEndpoint());
            return resultInverseAnchor;
        }


        public void HighlightEndpoints_Green(bool pbToggleStatusToOn = true)
        {
            //
            // Added 11/09/2024 td
            //
            _StartingItem.HighlightInGreen = pbToggleStatusToOn;
            if (_EndingItem != null)
                _EndingItem.HighlightInGreen = pbToggleStatusToOn;

        }


        public void HighlightEndpoints_Blue(bool pbToggleStatusToOn = true)
        {
            //
            // Added 11/09/2024 td
            //
            _StartingItem.HighlightInBlue = pbToggleStatusToOn;
            if (_EndingItem != null)
                _EndingItem.HighlightInBlue = pbToggleStatusToOn;

        }


        public void HighlightEndpoints_Cyan(bool pbToggleStatusToOn = true)
        {
            //
            // Added 11/09/2024 td
            //
            _StartingItem.HighlightInCyan = pbToggleStatusToOn;
            if (_EndingItem != null)
                _EndingItem.HighlightInCyan = pbToggleStatusToOn;
        }


        public void ExtendRangeToIncludeListItem(TControl par_item)
        {
            //
            // Added 11/12/2024 thomas downes 
            //
            int intDistance = _StartingItem.DLL_GetDistanceTo(par_item);
            
            if (par_item.Equals( _StartingItem))
            {
                //
                //  Surprisingly, they are the same item. Nothing needs to be done.
                //
            }
            else if ((intDistance > 0) && (intDistance > -1 + _ItemCount))
            {
                _ItemCount = (intDistance + 1);
                //_EndingItem = _StartingItem.DLL_GetItemNext_OfT(intDistance);
                _EndingItem = par_item;
                _isSingleItem = false;
                _SingleItemInRange = default(TControl);  // null;

            }
            else if (intDistance < 0)
            {
                //TControl temp = _StartingItem;
                //_StartingItem = par_item;
                System.Diagnostics.Debugger.Break();

            }

        }


        public override string ToString()
        {
            //
             // Added 11/10/2024 thomas downes
            //
            int intNumberOfItems = _ItemCount;
            int intCountItemsOutput = 0;
            StringBuilder result = new StringBuilder(200);
            result.Append("DLLRange: ");
            TControl temp = _StartingItem;
            bool bNotAllItemsOutput = (intNumberOfItems > 0); 

            while (temp != null && bNotAllItemsOutput)
            {
                result.Append(temp.ToString() + " ");
                temp = temp.DLL_GetItemNext_OfT();
                intCountItemsOutput++;
                bNotAllItemsOutput = (intCountItemsOutput < intNumberOfItems);
            }
            return result.ToString();

        }



    }
}
