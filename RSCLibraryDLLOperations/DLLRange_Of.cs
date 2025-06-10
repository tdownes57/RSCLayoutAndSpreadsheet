//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Security;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;  
using ciBadgeInterfaces;
using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text; //Added 6/20/2024  

namespace RSCLibraryDLLOperations
{
    public class DLLRange<TControl> 
        where TControl : class, IDoublyLinkedItem<TControl>
        // where TControlParallel : class, IDoublyLinkedItem<TControlParallel>
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
        //---March 14, 2025---public readonly TControl _StartingItemOfRange; // Modified 11/08/2024 thomas downes
        public TControl _StartingItemOfRange; // Modified 11/08/2024 thomas downes

        //public readonly TControl _EndingItem;
        public TControl _EndingItemOfRange;
        public int _ItemCountOfRange; // readonly

        // Added 4/20/2024 thomas downes
        public readonly TControl? _InverseAnchor_Prior;
        public readonly TControl? _InverseAnchor_After;

        //Added 3/05/2025
        public bool _isTemporarilyEmpty;
        private bool _pleaseIgnoreDummyEndItems; // Added 3/14/2025  v

        public DLLRange()
        {
            //
            // Deprecated.  Used the following instead:
            //
            //     public DLLRange(bool par_temporarilyEmpty, TControl par_dummy)
            //
            // Added 3/05/2025 thomas d
            _isTemporarilyEmpty = true;
            _ItemCountOfRange = 0;

            _StartingItemOfRange = null;
            _EndingItemOfRange = null;

        }


        public DLLRange(bool par_temporarilyEmpty, TControl par_dummy)
        {
            //
            // Added 3/14/2025 thomas d
            //
            if (! par_temporarilyEmpty) throw new ArgumentException("Boolean parameter must be true");

            _isTemporarilyEmpty = par_temporarilyEmpty; // true;
            _pleaseIgnoreDummyEndItems = par_temporarilyEmpty; // true;
            _ItemCountOfRange = 0;

            _StartingItemOfRange = par_dummy;
            _EndingItemOfRange = par_dummy;

        }


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
            _StartingItemOfRange = par_itemSingle;
            _ItemCountOfRange = 1;
            // Added 11/10/2024 
            _EndingItemOfRange = par_itemSingle;

        }


        public DLLRange(TControl par_itemStarting, TControl par_itemEnding)
        {
            //
            // Added 11/13/2024 
            //
            //_SingleItemInRange = null;
            _StartingItemOfRange = par_itemStarting;
            _EndingItemOfRange = par_itemEnding;
            _ItemCountOfRange = (1 + _StartingItemOfRange.DLL_GetDistanceTo(_EndingItemOfRange));

        }


        public DLLRange(TControl par_itemStarting, TControl par_itemEnding, int par_countItemsOfRange)
        {
            //
            // Added 1/04/2025 Thomas D. 
            //
            _StartingItemOfRange = par_itemStarting;
            _EndingItemOfRange = par_itemEnding;
            _ItemCountOfRange = par_countItemsOfRange;

        }


        public DLLRange(DLLList<TControl> par_list, Tuple<int, int> par_tuple_base1)
        {
            //
            // Added 11/15/2024 thomas downes
            //
            _StartingItemOfRange = par_list.Get_ItemAtIndex_base1(par_tuple_base1.Item1);
            _EndingItemOfRange = par_list.Get_ItemAtIndex_base1(par_tuple_base1.Item2);  // Added 11/17/2024   .Item1);
            //return new DLLRange<TControl>(itemStart, item_Last);
            _ItemCountOfRange = (1 + par_tuple_base1.Item2 - par_tuple_base1.Item1);
            _isSingleItem = (par_tuple_base1.Item1 == par_tuple_base1.Item2);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="par_list">List which is the source of range.</param>
        /// <param name="par_isSingleItem"></param>
        /// <param name="pStartAtIndex_b1">Index, base 1</param>
        /// <param name="pNumberOfItems">Count of items in the range</param>
        public DLLRange(DLLList<TControl> par_list, bool par_isSingleItem, int pStartAtIndex_b1, int pNumberOfItems)
        {
            //
            // Added 04/20/2025 thomas downes
            //
            _StartingItemOfRange = par_list.Get_ItemAtIndex_base1(pStartAtIndex_b1);
            _EndingItemOfRange = par_list.Get_ItemAtIndex_base1(pStartAtIndex_b1 - 1 + pNumberOfItems);  // Added 11/17/2024   .Item1);
            //return new DLLRange<TControl>(itemStart, item_Last);
            _ItemCountOfRange = pNumberOfItems; // (1 + par_tuple.Item2 - par_tuple.Item1);
            _isSingleItem = (pNumberOfItems == 1);
            if (par_isSingleItem != _isSingleItem) System.Diagnostics.Debugger.Break();

        }


        public DLLRange(bool par_isSingleItem, TControl par_itemStart,
                          TControl? par_itemEnding,
                          TControl? par_itemSingle, int par_itemCount)
        {
            //_isSingleItem = par_isSingleItem;
            _SingleItemInRange = par_itemSingle;
            _StartingItemOfRange = par_itemStart;
            _ItemCountOfRange = par_itemCount;
            _EndingItemOfRange = par_itemStart;
            _isSingleItem = par_isSingleItem;

            if (_isSingleItem && (par_itemSingle != null))
            {
                //
                // This is a single-item range.
                //
                _SingleItemInRange = par_itemSingle;

                _StartingItemOfRange = par_itemSingle;
                _EndingItemOfRange = par_itemSingle;

            }
            else if (par_itemEnding != null)
            {
                //
                // This is probably _NOT_ a single-item range.
                //   There is a ending item.
                //
                _StartingItemOfRange = par_itemStart;
                _EndingItemOfRange = par_itemEnding;

                //Administration.  Set _itemCount.
                if (_ItemCountOfRange <= 0)
                {
                    //_itemCount = _itemStart.DLL_CountItemsAllInList(); // Won't work.  This
                    //     is a range, i.e. a subset of a list, not an entire list. 
                    //_itemCount = (1 + _itemEnding.DLL_Subtract(_itemStart));
                    _ItemCountOfRange = (1 + DLL_Distance(_StartingItemOfRange, _EndingItemOfRange));

                }
                else if (Testing.AreWeTesting)
                {
                    bool bTestMatch;
                    if (par_itemCount > 0)
                    {
                        var nextIterativelyByCount = _StartingItemOfRange
                            .DLL_GetItemNext_OfT(par_itemCount - 1);
                        bTestMatch = (_EndingItemOfRange.Equals(nextIterativelyByCount));
                        if (!bTestMatch) System.Diagnostics.Debugger.Break();
                    }
                }

            }
            else if (_StartingItemOfRange != null)
            {
                //
                // This is probably _NOT_ a single-item range.
                //   There is a distinct beginning and an end.
                //
                //--Jun30 2024-_EndingItem = _StartingItem.DLL_GetItemNext(itemCount - 1).DLL_UnboxControl();
                _EndingItemOfRange = _StartingItemOfRange
                    .DLL_GetItemNext_OfT(par_itemCount - 1);
                //Jan24 2025    .DLL_UnboxControl_OfT();

            }

            //
            // Administrative--Set the Inverse Anchors.  
            //
            _InverseAnchor_Prior = _StartingItemOfRange // par_itemStart
                .DLL_GetItemPrior_OfT();

            if (par_itemEnding != null)
            {
                //_InverseAnchor_After = par_itemEnding
                //    .DLL_GetItemNext_OfT();
                _InverseAnchor_After = _EndingItemOfRange
                    .DLL_GetItemNext_OfT();
            }
            else if (par_itemCount == 1)
            {
                //_InverseAnchor_After = par_itemStart
                //    .DLL_GetItemNext_OfT();
                _InverseAnchor_After = _StartingItemOfRange
                    .DLL_GetItemNext_OfT();
            }
            else
            {
                // Unclear what to do.  Stop & think about it.
                System.Diagnostics.Debugger.Break();
            }

            //Added 6/30/2024
            if (_StartingItemOfRange == null) _StartingItemOfRange = par_itemStart;
            if (_StartingItemOfRange == null) _StartingItemOfRange = par_itemSingle;
            if (_EndingItemOfRange == null) _EndingItemOfRange = par_itemStart;
            if (_EndingItemOfRange == null) _EndingItemOfRange = par_itemSingle;

        }


        /// <summary>
        /// This creates a new range, which is same-indexed (item by item) version of the current range.
        /// </summary>
        /// <typeparam name="T_BaseOrParallel">This is the item-by-item Type of the range to be output.</typeparam>
        /// <param name="par_startOfList">This is the first item in the target list.</param>
        /// <param name="par_bTargetListIsBaseClass">Should be True if we are attempting to create a base-class 
        ///     version, e.g. DLLList<T_Base> instead of DLLList<THoriz>.  Every item in the new list is the 
        ///     piecewise base item of the items in the current list (the list which this current range (this) is derived).</param>
        /// <param name="par_bTargetListIsParallel">Should be True if we are attempting to create an operation 
        ///     on a parallel but (OOP-wise) independent list.  The objects are NOT piecewise parents.</param>
        /// <returns>A range of the desired, specified Type (T_BaseOrParallel).</returns>
        /// <exception cref="Exception"></exception>
        public DLLRange<T_BaseOrParallel> GetConvertToGenericOfT<T_BaseOrParallel>(T_BaseOrParallel par_startOfList,
                   bool pbTargetListIsOfBaseClass,
                   bool pbTargetListIsParallel)
            where T_BaseOrParallel : class, IDoublyLinkedItem<T_BaseOrParallel>
        {
            //
            // Added 12/07/2024 thoma.s downe.s  
            //
            DLLRange<T_BaseOrParallel> result_range = null;
            // T_BaseOrParallel? object56_s = _StartingItemOfRange as T_BaseOrParallel;
            // T_BaseOrParallel? object56_e = _EndingItemOfRange as T_BaseOrParallel;

            //Added 1/09/2025 thomas d.
            bool bAsExpected = (pbTargetListIsOfBaseClass == (_StartingItemOfRange is T_BaseOrParallel));
            if (!bAsExpected) System.Diagnostics.Debugger.Break();

            //
            // Added for parallel lists, in which the items are parallel but non-overlapping. ---1/05/2025 td
            //
            //if (object56_s == null)
            if (_StartingItemOfRange is T_BaseOrParallel startingItemBase)
            {
                //
                //  Example types:  T_BaseOrParallel = TwoCharacterDLLItem, TControl = TwoCharacterDLLItemHorizontal.
                //
                //if (! par_listIsParallel) System.Diagnostics.Debugger.Break();
                if (pbTargetListIsParallel) System.Diagnostics.Debugger.Break();
                //object56_s = par_startOfList.DLL_GetItemNext_OfT(-1 + _StartingItemOfRange.DLL_GetItemIndex());
                //object56_e = par_startOfList.DLL_GetItemNext_OfT(-1 + _EndingItemOfRange.DLL_GetItemIndex());
                //result_range = new DLLRange<T_BaseOrParallel>(object56_s, object56_e, _ItemCountOfRange);
                T_BaseOrParallel? endingItemBase = _EndingItemOfRange as T_BaseOrParallel;
                if (endingItemBase == null) System.Diagnostics.Debugger.Break();
                if (endingItemBase == null) throw new Exception("Not likely to occur, since starting & ending items are the same type.");
                result_range = new DLLRange<T_BaseOrParallel>(startingItemBase, endingItemBase, _ItemCountOfRange);

            }
            else if (pbTargetListIsParallel)
            {
                //
                // The list is a parallel list, *NOT* the same list (as, or converted to, the base type). 
                //
                //  Example types:  T_BaseOrParallel = RSCDataCell, TControl = RSCRowHeader.
                //
                //----var parallel_start = par_startOfList.DLL_GetItemNext_OfT(-1 + _StartingItemOfRange.DLL_GetItemIndex());
                //----var parallel_ending = par_startOfList.DLL_GetItemNext_OfT(-1 + _EndingItemOfRange.DLL_GetItemIndex());

                var parallel_start = _StartingItemOfRange.GetConvertToGeneric_OfT(par_startOfList);
                var parallel_ending = _EndingItemOfRange.GetConvertToGeneric_OfT(par_startOfList);


            }

            //if (object56_s == null || object56_e == null)
            //{
            //    // Programmer must investigate this case.
            //    System.Diagnostics.Debugger.Break();
            //}
            //else
            //{
            //    //+++1/04/2025  DLLRange<THeader56> result = new DLLRange<THeader56>(object56_s, object56_e);
            //    result_range = new DLLRange<T_BaseOrParallel>(object56_s, object56_e, _ItemCountOfRange);
            //}

            return result_range;

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
            if (_EndingItemOfRange == null)
            {
                if (_ItemCountOfRange == 1) _EndingItemOfRange = _StartingItemOfRange;
            }

            //if (_EndingItem != null)
            //{

            _EndingItemOfRange.DLL_SetItemNext(par_newItem);
            par_newItem.DLL_SetItemPrior(_EndingItemOfRange);
            _EndingItemOfRange = par_newItem;
            _ItemCountOfRange++;
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

            TControl item = par_start.DLL_GetItemNext_OfT(); //Jan24 2025  .DLL_UnboxControl_OfT();
            int intResult = 0;

            while (item != null)
            {
                intResult++;
                if (item.Equals(par_ending)) break;
                item = item.DLL_GetItemNext_OfT(); //Jan24 2025  .DLL_UnboxControl_OfT();
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
            bool bCleanStart = !_StartingItemOfRange.DLL_HasPrior();
            bool bCleanFinish = !_EndingItemOfRange.DLL_HasNext();

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
            TControl result = (_StartingItemOfRange != null ? _StartingItemOfRange : _SingleItemInRange);
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
            TControl result = (_EndingItemOfRange != null ? _EndingItemOfRange : _SingleItemInRange);
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
            TControl result1 = (_EndingItemOfRange != null ? _EndingItemOfRange : _SingleItemInRange); //.DLL_GetItemNext_OfT();
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
            TControl result1 = _StartingItemOfRange; //.DLL_GetItemNext_OfT();
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
            TControl result1 = _EndingItemOfRange; //.DLL_GetItemNext_OfT();
            TControl? result_final = result1.DLL_GetItemNext_OfT();
            return result_final;

        }


        public int GetItemCount()
        {
            //
            // Added 10/31/2024 thomas downes
            //
            if (_ItemCountOfRange > 0)
            {
                return _ItemCountOfRange;
            }
            else
            {
                return (-1 + _StartingItemOfRange.DLL_GetDistanceTo(_EndingItemOfRange));

            }


        }


        /// <summary>
        /// This method is used to determine the index-location of the first item in the range, relative to the parent list.  It is 1-based.
        /// </summary>
        /// <returns></returns>
        public int GetFirstItemIndex_base1()
        {
            //
            // Added 11/12/2024 td
            //
            if (_StartingItemOfRange == null)
            {
                Debugger.Break();
                return -1;
            }

            return _StartingItemOfRange.DLL_GetItemIndex_base1();

        }


        public bool IsSingleItem()
        {
            // Added 11/10/2024 td
            return (1 == _ItemCountOfRange);

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
            if (_EndingItemOfRange == null && _ItemCountOfRange > 0)
            {
                // Populate the _EndingItem.
                _EndingItemOfRange = _StartingItemOfRange.DLL_GetItemNext_OfT(-1 + _ItemCountOfRange);
            }

            bNoPreceding = (false == _StartingItemOfRange.DLL_HasPrior());
            bNoFollowing = (false == _EndingItemOfRange.DLL_HasNext());
            bResult = (bNoPreceding || bNoFollowing);
            return bResult;

        }


        public bool ContainsEndpoint(bool par_checkPrior, bool par_checkNext)
        {
            //
            // Added 12/19/2024 thomas downes
            //
            bool bResult_missingAdjacentItem;
            bool bNoPreceding;
            bool bNoFollowing;

            // Added 11/09/2024 t.downes
            if (_EndingItemOfRange == null && _ItemCountOfRange > 0)
            {
                // Populate the _EndingItem.
                _EndingItemOfRange = _StartingItemOfRange.DLL_GetItemNext_OfT(-1 + _ItemCountOfRange);
            }

            bNoPreceding = (false == _StartingItemOfRange.DLL_HasPrior());
            bNoFollowing = (false == _EndingItemOfRange.DLL_HasNext());
            bResult_missingAdjacentItem = (bNoPreceding && par_checkPrior ||
                       bNoFollowing && par_checkNext);

            return bResult_missingAdjacentItem;

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


        public bool Check_EnclosedByAnchorPair(DLLAnchorCouplet<TControl> par_pair)
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
            else if (itemAfterRange != null && itemAnchorRight != null)
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
            else if (_StartingItemOfRange == null)
            {
                return false; // Added 4/25/2025
            }

            int intDistanceToItem = _StartingItemOfRange.DLL_GetDistanceTo(par_item, ref bLocatedItem);

            if (bLocatedItem)
            {
                //result_inRange = (0 < intDistanceToItem && intDistanceToItem < _ItemCount);
                result_inRange = (0 <= intDistanceToItem && intDistanceToItem < _ItemCountOfRange);
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
            //Apr2025  bool bRangeIsAtEndingOfList = (itemAfterRange == null);
            bool bRangeIsAtEndingOfList = Item__End().DLL_NotAnyNext();

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
            if (bRangeIsAtEndingOfList)
            {
                par_listForAdmin._itemEnding = itemPriorToRange; // this.Item__End();
                // Added 4/17/2025
                par_listForAdmin._itemEnding?.DLL_MarkAsEndOfList(); // Added 4/17/2025
            }

            // Reduce the item count of the list, by the number of items in the range. 
            //   (Notice we are using the subtraction -= operator.)
            int numberOfRangeItems = this._ItemCountOfRange;
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
            _StartingItemOfRange.HighlightInGreen = pbToggleStatusToOn;
            if (_EndingItemOfRange != null)
                _EndingItemOfRange.HighlightInGreen = pbToggleStatusToOn;

        }


        public void HighlightEndpoints_Blue(bool pbToggleStatusToOn = true)
        {
            //
            // Added 11/09/2024 td
            //
            _StartingItemOfRange.HighlightInBlue = pbToggleStatusToOn;
            if (_EndingItemOfRange != null)
                _EndingItemOfRange.HighlightInBlue = pbToggleStatusToOn;

        }


        public void HighlightEndpoints_Cyan(bool pbToggleStatusToOn = true)
        {
            //
            // Added 11/09/2024 td
            //
            _StartingItemOfRange.HighlightInCyan = pbToggleStatusToOn;
            if (_EndingItemOfRange != null)
                _EndingItemOfRange.HighlightInCyan = pbToggleStatusToOn;
        }



        /// <summary>
        /// If the parent list is 1, 2, 3, 4, 5, 6 (six items) and this range (the current object)
        /// is 2, 3, 4 (3  items) then this method can be called with "5" (or "6") as the 
        /// parameter.  The resulting mutated range is 2, 3, 4, 5 (or 2, 3, 4, 5, 6).
        /// </summary>
        /// <param name="par_item">The item in the list which follows (is greater in position) than </param>
        public void AddItemToTheEndOfRange_NewItem(TControl par_item)
        {
            //
            // This is an "alias" function, which allows the programmer to have more than one
            // memorable name to a function.----3/14/2025 td
            // Added 3/14/2025 td
            //
            //----ExtendRangeToIncludeListItem(par_item);
            //----ExtendRangeToIncludeListItem_FromList(par_item);
            const bool DOUBLY_LINK = true;

            if (_isTemporarilyEmpty || _pleaseIgnoreDummyEndItems)
            {
                //
                // Add the initial item!! 
                //
                _StartingItemOfRange = par_item;
                _EndingItemOfRange = par_item;
                _ItemCountOfRange = 1;
                // Make sure that this code block 
                //  only runs once.
                _pleaseIgnoreDummyEndItems = false; // re-initialize
                _isTemporarilyEmpty = false;
            }
            else
            {
                _EndingItemOfRange.DLL_SetItemNext_OfT(par_item, false, DOUBLY_LINK);
                _EndingItemOfRange = par_item;
                _ItemCountOfRange++;
            }

        }


        /// <summary>
        /// If the parent list is 1, 2, 3, 4, 5, 6 (six items) and this range (the current object)
        /// is 2, 3, 4 (3  items) then this method can be called with "5" (or "6") as the 
        /// parameter.  The resulting mutated range is 2, 3, 4, 5 (or 2, 3, 4, 5, 6).
        /// </summary>
        /// <param name="par_item">The item in the list which follows (is greater in position) than </param>
        public void AddItemToTheEndOfRange_FromList(TControl par_item)
        {
            //
            // This is an "alias" function, which allows the programmer to have more than one
            // memorable name to a function.----3/14/2025 td
            // Added 3/14/2025 td
            //
            ExtendRangeToIncludeListItem(par_item);

        }


        /// <summary>
        /// If the parent list is 1, 2, 3, 4, 5, 6 (six items) and this range (the current object)
        /// is 2, 3, 4 (3 items) then this method can be called with "5" (or "6") as the 
        /// parameter.  The resulting mutated range is 2, 3, 4, 5 (or 2, 3, 4, 5, 6).
        /// </summary>
        /// <param name="par_item">The item in the list which follows (is greater in position) than </param>
        public void ExtendRangeToIncludeListItem(TControl par_item)
        {
            //
            // Added 11/12/2024 thomas downes 
            //
            if (_isTemporarilyEmpty || _pleaseIgnoreDummyEndItems)
            {
                _StartingItemOfRange = par_item;
                _EndingItemOfRange = par_item;
                _ItemCountOfRange = 1; 
                // Re-initialized Booleans.
                _isTemporarilyEmpty = false; // re-initialize
                _pleaseIgnoreDummyEndItems = false; // re-initialize
                return; // Exit the procedure.

            }

            //--March 2025---int intDistance = _StartingItemOfRange.DLL_GetDistanceTo(par_item);
            bool bWasLocated = false; 
            int intDistance = _StartingItemOfRange.DLL_GetDistanceTo(par_item, ref bWasLocated);

            if (par_item.Equals( _StartingItemOfRange))
            {
                //
                //  Surprisingly, they are the same item. Nothing needs to be done.
                //
            }

            //---else if ((intDistance > 0) && (intDistance > -1 + _ItemCountOfRange))
            else if (bWasLocated && (intDistance > 0) && (intDistance > -1 + _ItemCountOfRange))
            {
                _ItemCountOfRange = (intDistance + 1);
                //_EndingItem = _StartingItem.DLL_GetItemNext_OfT(intDistance);
                _EndingItemOfRange = par_item;
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


        /// <summary>
        /// If Boolean parameter is False, then we will move an item from the range's immediate prior position (Left)
        /// to the range's immediate posterior position. (The range doesn't mutate,
        /// but the parent list does.  This will not change the count of items in the list.) 
        /// If Boolean parameter is True, then we will move an item from the range's immediate 
        /// following position (Right) to the range's immediate prior position.
        /// </summary>
        /// <param name="par_shiftRightOrDown"></param>
        public void Shift_ByOneItem(bool par_shiftRightOrDown, ref bool ref_bNotPossible, 
                              DLLList<TControl> par_listForAdmin, bool pbLikelyChangeOfEndpoint)
        {
            //
            // Added 12/15/2024  
            //
            bool bChangeOfListEndpoint_ListStart = false;
            bool bChangeOfListEndpoint_ListEnd = false;

            //
            // Right  -  Shift Right (by one item)
            //
            #region RegionOfCode__ShiftRight

            if (par_shiftRightOrDown)
            {
                //
                //---------------------------------------------------------------------------------
                //  ----------------------        RIGHT        ------------------------------
                //  ---------------------- SHIFTING RIGHT-WARD ------------------------------
                // Shift Right (or Up, if the list is vertical, starting from top of sheet).  
                //---------------------------------------------------------------------------------
                //
                TControl afterSwap_precedingItem; // Added 12/18/2024 td
                ref_bNotPossible = (!_EndingItemOfRange.DLL_HasNext());
                if (ref_bNotPossible) return;
                TControl? following_item = _EndingItemOfRange.DLL_GetItemNext_OfT();
                
                bChangeOfListEndpoint_ListStart = (! _StartingItemOfRange.DLL_HasPrior());
                bChangeOfListEndpoint_ListEnd = (! following_item.DLL_HasNext());

                DLLRange<TControl> following_item_as_range = new DLLRange<TControl>(following_item, false);
                following_item_as_range.DeleteFromList_noAdmin();
                following_item.DLL_ClearReferencePrior('M');  // Temporarily deleted, so clean up the Next & Prior references. M = Move
                following_item.DLL_ClearReferenceNext('M');  // Clean up the Next & Prior references.  M = Move
                //-----_EndingItem.DLL_InsertItemToNext(following_item, true);
                // DIFFICULT & CONFUSING -- Perform a switcheroo!! --12/15/2024
                _StartingItemOfRange.DLL_InsertItemToPrior(following_item, true);
                afterSwap_precedingItem = following_item;  // Added 12/18/2024 td

                //
                // List Administration!!
                // 

                if (bChangeOfListEndpoint_ListEnd)
                {
                    // The range was (pre-shift) within one item of the end of the parent list.
                    //   Post-shift, the range is now at the very end of the parent list.
                    //     ---12/18/2024
                    par_listForAdmin._itemEnding = this._EndingItemOfRange;
                    if (!pbLikelyChangeOfEndpoint) Debugger.Break();
                    par_listForAdmin._itemEnding.DLL_MarkAsEndOfList(); //Added 4/2025 td

                }

                // Added 12/18/2024 td 
                //
                //   Let's address the situation in which the range was (pre-shift) at the very beginning
                //   of the list.  In other words, before the Range's shift, there were not any items
                //   to the Left (or Above) the Range.
                //
                if (bChangeOfListEndpoint_ListStart)
                {
                    if (afterSwap_precedingItem.DLL_NotAnyPrior())
                    {
                        par_listForAdmin._itemStart = afterSwap_precedingItem;
                        if (!pbLikelyChangeOfEndpoint) Debugger.Break();
                    }
                    else
                    {
                        // Programmer must investigate this case.
                        Debugger.Break();
                    }
                }

            }

            #endregion

            //
            // Left   -   Shift Left (by one item)
            //
            #region RegionOfCode__ShiftLeft

            else
            {
                //---------------------------------------------------------------------------------
                //  ----------------------        LEFT        ------------------------------
                //  ---------------------- SHIFTING LEFT-WARD ------------------------------
                //  Shift Left (or Up, if the list is vertical, starting from top of sheet). 
                //---------------------------------------------------------------------------------
                //
                TControl afterSwap_followingItem; // Added 12/18/2024 td
                ref_bNotPossible = (!_StartingItemOfRange.DLL_HasPrior());
                
                if (ref_bNotPossible)
                { 
                    // The starting item of the range has NOT ANY prior (lefthand) items,
                    //   so logically, we will be unable to shift the range 
                    //   to the left. ---1/16/2025 
                    return; 
                }

                TControl? prior_item = _StartingItemOfRange.DLL_GetItemPrior_OfT();
                
                bChangeOfListEndpoint_ListStart = (! prior_item.DLL_HasPrior());
                bChangeOfListEndpoint_ListEnd = (! _EndingItemOfRange.DLL_HasNext());

                DLLRange<TControl> prior_item_as_range = new DLLRange<TControl>(prior_item, false);
                prior_item_as_range.DeleteFromList_noAdmin();
                prior_item.DLL_ClearReferencePrior('M');  // M = Move
                prior_item.DLL_ClearReferenceNext('M');  // M = Move
                //-----_StartingItem.DLL_InsertItemToPrior(prior_item, true);
                // DIFFICULT & CONFUSING -- Perform a switcheroo!!
                //------_StartingItemOfRange.DLL_InsertItemToNext(prior_item, true);
                _EndingItemOfRange.DLL_InsertItemToNext(prior_item, true);
                afterSwap_followingItem = prior_item;

                // List Administration 
                //if (bChangeOfListEndpoint) par_listForAdmin._itemStart = this._StartingItem;

                if (bChangeOfListEndpoint_ListStart)
                {
                    // The range was (pre-shift) within one item of the start of the parent list.
                    //   Post-shift, the range is now at the very start of the parent list.
                    //     ---12/18/2024
                    par_listForAdmin._itemStart = this._StartingItemOfRange;
                    if (!pbLikelyChangeOfEndpoint) Debugger.Break();
                }

                // Added 12/18/2024 td 
                //
                //   Let's address the situation in which the range was (pre-shift) at the very end
                //   of the list.  In other words, before the Range's shift, there were not any items
                //   to the Right (or Below) the Range.
                //
                if (bChangeOfListEndpoint_ListEnd)
                {
                    if (afterSwap_followingItem.DLL_NotAnyNext())
                    {
                        par_listForAdmin._itemEnding = afterSwap_followingItem;
                        if (!pbLikelyChangeOfEndpoint) Debugger.Break();
                    }
                    else
                    {
                        // Programmer must investigate this case.
                        System.Diagnostics.Debugger.Break();
                    }
                }

            }

            #endregion

        }


        public override string ToString()
        {
            //
             // Added 11/10/2024 thomas downes
            //
            int intNumberOfItems = _ItemCountOfRange;
            int intCountItemsOutput = 0;
            StringBuilder result = new StringBuilder(200);
            result.Append("DLLRange: ");
            TControl each_item = _StartingItemOfRange;
            bool bNotAllItemsOutput = (intNumberOfItems > 0); 

            while (each_item != null && bNotAllItemsOutput)
            {
                //Feb2025 result.Append(each_item.ToString() + " ");
                result.Append(each_item.ToString(false) + " ");

                each_item = each_item.DLL_GetItemNext_OfT();
                intCountItemsOutput++;
                bNotAllItemsOutput = (intCountItemsOutput < intNumberOfItems);
            }
            return result.ToString();

        }


        public bool IsEquivalent(DLLRange<TControl> par_otherRange)
        {
            //
            // Added 12/29/2024 thomas downes
            //
            bool bResult = false;
            bool bMatchingStart = (_StartingItemOfRange.Equals(par_otherRange._StartingItemOfRange));
            bool bMatchingEnd = (_EndingItemOfRange.Equals(par_otherRange._EndingItemOfRange));
            bool bMatchingCount = (_ItemCountOfRange == par_otherRange._ItemCountOfRange);
            bool bMatchingSingle = (_isSingleItem == par_otherRange._isSingleItem);

            //bool bMatchingSingle = (bool)(_SingleItemInRange?.Equals(par_otherRange._SingleItemInRange));
            bResult = (bMatchingStart && bMatchingEnd && 
                bMatchingCount && bMatchingSingle);

            if (bResult && _isSingleItem && _SingleItemInRange != null)
            {
                bResult = (bResult && _SingleItemInRange.Equals(par_otherRange._SingleItemInRange));
            }

            return bResult;

        }


        public bool Equals(DLLRange<TControl> par_otherRange)
        {
            // Added 12/29/2024 thomas downes
            return IsEquivalent(par_otherRange);


        }


        /// <summary>
        /// This gives the 0-based index of the first item in the range.
        /// </summary>
        /// <returns>The 0-based integer index of the first item in the range, in the context of the parent list.</returns>
        public int GetFirstItemIndex_b0()
        {

            // Added 1/10/2025 thomas d.
            return _StartingItemOfRange.DLL_GetItemIndex_base0();

        }


        /// <summary>
        /// This gives the 1-based index of the first item in the range.
        /// </summary>
        /// <returns>The 1-based integer index of the first item in the range, in the context of the parent list.</returns>
        public int GetFirstItemIndex()
        {

            // Added 1/10/2025 thomas d.
            return _StartingItemOfRange.DLL_GetItemIndex_base1();

        }


        public void UpdateEndpoints_UserClick(int par_rowClicked_base1, bool par_wShiftKey, DLLList<TControl> mod_listA)
        {
            //
            // Added 4/05/2025  
            //
            int intRangeItemIndexMinimum_base1;
            int intRangeItemIndexMaximum_base1;

            intRangeItemIndexMinimum_base1 = _StartingItemOfRange.DLL_GetItemIndex_base1();

            //---intRangeItemIndexMaximum_base1 = _EndingItemOfRange.DLL_GetItemIndex_base1();
            if (_EndingItemOfRange == null)
            {
                intRangeItemIndexMaximum_base1 = intRangeItemIndexMinimum_base1 + _ItemCountOfRange - 1;
            }
            else
            {
                intRangeItemIndexMaximum_base1 = _EndingItemOfRange.DLL_GetItemIndex_base1();
            }

            //---if (par_wShiftKey && par_row_base1 >= intRangeItemIndexMaximum_base1)
            if (par_wShiftKey && par_rowClicked_base1 >= intRangeItemIndexMinimum_base1)
            {
                _ItemCountOfRange = (1 + par_rowClicked_base1 - intRangeItemIndexMinimum_base1);
                _EndingItemOfRange = _StartingItemOfRange.DLL_GetItemNext_OfT(-1 + _ItemCountOfRange);

            }

            else if (par_wShiftKey && par_rowClicked_base1 < intRangeItemIndexMinimum_base1)
            {
                //
                // Should we act as if the Shift key is OFF ??  The user has clicked on the 
                //   lower-index side of the initial, unshifted click.  ----4/25/2025
                //
                //_StartingItemOfRange = mod_listA.DLL_GetItemAtIndex_1based(par_row_base1);
                TControl temp_FormerStart = _StartingItemOfRange;
                TControl? temp_ShiftClicked = mod_listA.DLL_GetItemAtIndex_1based(par_rowClicked_base1);
                if (temp_ShiftClicked != null) 
                {
                    _ItemCountOfRange = (1 + intRangeItemIndexMinimum_base1 - par_rowClicked_base1);
                    _StartingItemOfRange = temp_ShiftClicked;  // Added 4/22/2025 td
                    _EndingItemOfRange = temp_FormerStart;  // Added 4/22/2025 td

                    //intRangeItemIndexMinimum_base1 = par_row_base1;
                    //intRangeItemIndexMaximum_base1 = _EndingItemOfRange.DLL_GetItemIndex_base1();
                    //_ItemCountOfRange = (1 + intRangeItemIndexMaximum_base1 - par_row_base1);
                    //if (_StartingItemOfRange != null)
                    //{
                    //    _EndingItemOfRange = _StartingItemOfRange.DLL_GetItemNext_OfT(-1 + _ItemCountOfRange);
                    //}

                }

            }

            else if (!par_wShiftKey)
            {
                _ItemCountOfRange = 1;
                //_StartingItemOfRange = mod_listA.DLL_GetItemAtIndex_1based(par_rowClicked_base1);
                //_EndingItemOfRange = _StartingItemOfRange;
                TControl? temp_ShiftClicked = mod_listA.DLL_GetItemAtIndex_1based(par_rowClicked_base1);
                if (temp_ShiftClicked != null)
                {
                    _StartingItemOfRange = temp_ShiftClicked;
                    _EndingItemOfRange = temp_ShiftClicked;
                }
            
            }

        }




    }
}
