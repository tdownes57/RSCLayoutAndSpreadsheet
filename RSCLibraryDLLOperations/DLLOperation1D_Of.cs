//using System;
//using System.Collections.Generic;
using System.Diagnostics;
//using System.Reflection.Metadata.Ecma335;
using ciBadgeInterfaces; //Added 6/20/2024
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{

    //
    // Added 10/12/2024 Thomas C. Downes
    //
    //    1D = 1 dimension, simply a list
    //            (versus a 2-dimensional grid)
    //

    public class DLLOperation1D<TControl> // :IDoublyLinkedItem
        where TControl : IDoublyLinkedItem<TControl>
    {
        //''
        //''Added 4/17/2024 td
        //
        //    1D = 1 dimension, simply a list
        //            (versus a 2-dimensional grid)
        //
        //''
        private readonly bool _isHoriz;
        private readonly bool _isVerti;

        private readonly bool _isForStartOfList;
        private readonly bool _isForEndOfList;
        private readonly bool _isForAnchor;

        private readonly bool _isInsert;
        private readonly bool _isDelete;
        private readonly bool _isMove;
        private readonly bool _isSort_Ascending;
        private readonly bool _isSort_Descending;
        private readonly bool _isSort_UndoOfSort; //Added 4/18/2024 
        private readonly bool _isForUndoOperation;  //Added 5/22/2024

        // Added 4/21/2024 td
        private readonly DLLAnchor<TControl>? _anchorItem;

        // Added 11/03/2024 td
        private readonly DLLAnchorCouplet<TControl>? _anchorCouplet;

        //Added 4/18/2024 td 
        private readonly DLLAnchor<TControl>? _anchor_forUndo;
        private readonly DLLAnchorCouplet<TControl>? _anchorPair_forUndo;

        private readonly DLLRange<TControl>? _range;

        private DLLOperation1D<TControl>? mod_opPrior_ForUndo;
        private DLLOperation1D<TControl>? mod_opNext_ForRedo;


        /// <summary>
        /// Indicate whether the ENDPOINTS (outward-facing item references 
        /// at either end of a range of items) should be always set to NULL
        /// after a DELETE is performed.
        /// </summary>
        private const bool ALWAYS_CLEAN_ENDPOINTS = true;

        /// <summary>
        /// Is this operation created via GetUndo() or something similar?
        /// </summary>
        /// <returns></returns>
        public bool CreatedAsUndoOperation()
        {
            // Added 5/22/2024 td
            return _isForUndoOperation;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public bool CreatedAsRedoOperation()
        {
            return false;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public bool IsChangeOfEndpoint()
        {
            // Added 5/25/2024 td
            return (_isForStartOfList || _isForEndOfList);
        }


        public char GetOperationType()
        {
            if (_isInsert) return 'I';
            if (_isDelete) return 'D';
            if (_isMove) return 'M';
            if (_isSort_Ascending) return 'S';
            if (_isSort_Descending) return 'S';
            return ' ';

        }

        public bool IsHorizontal() { return _isHoriz; }
        public bool IsVertical() { return _isVerti; }

        public bool HasAnchor()
        {
            // Added 6/10/2024
            //-----return (_anchor_H != null || _anchor_H != null);
            return (_anchorItem != null);
        }


        public bool IsAnchorToPrecedeItemOrRange()
        {
            //
            // Added 6/10/2024 thomas downes
            //
            //----BACKWARDS AND CONFUSING----------------------------
            //if (_anchorItem_H != null && _isHoriz) return _anchorItem_H._doInsertRangeAfterThis;
            //if (_anchorItem_V != null && _isVerti) return _anchorItem_V._doInsertRangeAfterThis;
            if (_anchorItem != null) return _anchorItem._doInsertRangeAfterThis;
            throw new InvalidOperationException();

        }


        public bool IsAnchorToSucceedItemOrRange()
        {
            //
            // Added 6/10/2024 thomas downes
            //
            //----BACKWARDS AND CONFUSING----------------------------
            //if (_anchorItem_H != null && _isHoriz) return _anchorItem_H._doInsertRangeBeforeThis;
            //if (_anchorItem_V != null && _isVerti) return _anchorItem_V._doInsertRangeBeforeThis;
            if (_anchorItem != null) return _anchorItem._doInsertRangeBeforeThis;
            throw new InvalidOperationException();

        }



        /// <summary>
        /// Constructor overload is for horizontal (column) operations, 
        /// e.g. moving a worksheet column to the extreme left-hand side, 
        /// with TControl_H = RSDataColumn.  Overloaded.
        /// </summary>
        /// <param name="par_range"></param>
        /// <param name="par_forStartOfList"></param>
        /// <param name="par_forEndOfList"></param>
        /// <param name="par_isInsert"></param>
        /// <param name="par_isDelete"></param>
        /// <param name="par_isMove"></param>
        /// <param name="par_anchorItem"></param>
        /// <param name="par_isSortAscending"></param>
        /// <param name="par_isSortDescending"></param>
        /// <param name="par_isSortReversal"></param>
        public DLLOperation1D(DLLRange<TControl>? par_range,
                  bool par_forStartOfList, bool par_forEndOfList,
                  bool par_isInsert, bool par_isDelete, bool par_isMove,
                  DLLAnchor<TControl>? par_anchorItem,
                  bool par_isSortAscending, bool par_isSortDescending, bool par_isSortReversal)
        {
            //
            // Added 10/12/2024 thomas downes
            //

            //---_isHoriz = true;
            _range = par_range;
            _anchorItem = par_anchorItem;
            //---_isVerti = false; // NOT vertical.

            _isForStartOfList = par_forStartOfList;
            _isForEndOfList = par_forEndOfList;
            _isInsert = par_isInsert;
            _isDelete = par_isDelete;
            _isMove = par_isMove;
            _isSort_Ascending = par_isSortAscending;
            _isSort_Descending = par_isSortDescending;

            //Added 4/18/2024 
            _isSort_UndoOfSort = par_isSortReversal; // Undoing a sorting operation.

            //
            //  Preparing for UNDO... Determining an Anchor for a future UNDO operation.
            //
            //Think about undoing... an INSERT (hence, it's a DELETE)
            if (_isInsert) _anchor_forUndo = null; // par_range. // Deletes don't need an anchor! 
            //if (_isDelete && _isForStartOfList)
            //{
            //    //TControl_H item_afterRange = _range_H._itemEnding.DLL_GetItemNext();
            //    //_anchor_forUndo_H = new DLLAnchor<>(item_afterRange); 
            //}
            //else if (_isDelete && _isForEndOfList)
            //{
            //    //TControl_H item_afterRange = _range_H._itemStart.DLL_GetItemPrior();
            //    //_anchor_forUndo_H = new DLLAnchor<>(item_afterRange);
            //}

            if (_isDelete)
            {
                _anchorPair_forUndo = par_range.GetCoupletWhichEncloses_InverseAnchor();
                _anchorCouplet.GetAnchorItem();
            }



        }


        public DLLOperation1D(DLLRange<TControl> par_range,
                              DLLAnchorCouplet<TControl> par_anchorCouplet, 
                              bool par_isInsert, bool par_isMove)
        {
            //
            // Added 11/3/2024 
            //
            _range = par_range;
            _isDelete = false;
            _isMove = par_isMove;
            _isInsert = par_isInsert;
            _anchorCouplet = par_anchorCouplet;

        }


        public void OperateOnList(DLLList<TControl> par_list)
        {
            //
            // Added 4/17/2024
            //
            //   This is a sort of "inversion of control" procedure.
            //   Instead of the list accepting an operation, the 
            //   operation is given the list & operates upon the 
            //   given list. 
            //
            if (_isSort_Ascending)
            {

            }
            if (_isSort_Descending)
            {

            }
            else
            {
                OperateOnList<TControl>(par_list, _range, _anchorItem, false);
            }

        }


         /// <summary>
        /// 
        /// </summary>
        /// <param name="par_list"></param>
        /// <param name="par_doProtectEndpoints">If True, we will throw Exceptions when the Endpoint is impacted, unless the next Boolean parameter is True.</param>
        /// <param name="pbIsChangeOfEndpoint">Prevents exceptions from being raised when an endpoint is changed.</param>
        public void OperateOnList(DLLList<TControl> par_list,
                             bool par_doProtectEndpoints,
                             bool pbIsChangeOfEndpoint = false)
        {
            //
            // Added 6/10/2024
            //
            if (_isSort_Ascending)
            {

            }
            if (_isSort_Descending)
            {

            }
            else
            {
                // OperateOnList<TControl_H>(par_list, _range_H, _anchorItem_H);
                OperateOnList<TControl>(par_list, _range, _anchorItem,
                    par_doProtectEndpoints, pbIsChangeOfEndpoint);
            }

        }


        public void OperateOnList(DLLList<TControl> par_list,
                             bool par_doProtectEndpoints,
                             bool pbIsChangeOfEndpoint = false,
                             bool pbRunOtherChecks = false)
        {
            //
            // Added 4/17/2024
            //
            if (_isSort_Ascending)
            {

            }
            if (_isSort_Descending)
            {

            }
            else
            {
                //
                //   Let's leverage a private singly-generic method (Of TControl),
                //   to obey the DRY principle inside a doubly-generic class 
                //   (Of TControl_H, TControl_V). 
                //  
                OperateOnList<TControl>(par_list, _range, _anchorItem,
                      par_doProtectEndpoints, pbIsChangeOfEndpoint, pbRunOtherChecks);
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="par_list"></param>
        /// <param name="par_range"></param>
        /// <param name="par_anchorItem"></param>
        /// <param name="pbEndpointProtection">If True, we will throw Exceptions when the Endpoint is impacted, unless the next Boolean parameter is True.</param>
        /// <param name="pbIsChangeOfEndpoint">Prevents exceptions from being raised when an endpoint is changed.</param>
        private void OperateOnList<TControl>(DLLList<TControl> par_list,
                                     DLLRange<TControl> par_range,
                                     DLLAnchor<TControl>? par_anchorItem,
                                     bool pbEndpointProtection,
                                     bool pbIsChangeOfEndpoint = false,
                                     bool pbRunOtherChecks = false)
             where TControl : IDoublyLinkedItem<TControl>
        {
            //
            // Added 4/17/2024
            //
            //   This is a private singly-generic method (Of TControl),
            //   to obey the DRY principle inside a doubly-generic class 
            //   (Of TControl_H, TControl_V). 
            //  
            if (_isInsert)
            {
                OperateOnList_Insert<TControl>(par_list, par_range, par_anchorItem,
                                     pbEndpointProtection,
                                     pbIsChangeOfEndpoint, pbRunOtherChecks);
            }
            else if (_isDelete)
            {
                OperateOnList_Delete<TControl>(par_list, par_range,
                                     pbEndpointProtection,
                                     pbIsChangeOfEndpoint, pbRunOtherChecks);
            }
            else if (_isMove)
            {
                OperateOnList_Delete<TControl>(par_list, par_range,
                                     pbEndpointProtection,
                                     pbIsChangeOfEndpoint);
                OperateOnList_Insert<TControl>(par_list, par_range, par_anchorItem,
                                     pbEndpointProtection,
                                     pbIsChangeOfEndpoint, pbRunOtherChecks);
            }

        }


        /// <summary>
        /// Perform an insert operation, either for TControl_H or TControl_V.
        /// If appropriate, we perform some sanity testing prior to the operation.
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="par_list_NotReallyNeeded">This parameter provides a sanity check (debugging).</param>
        /// <param name="par_range">This is the range of items which are being placed into the list.</param>
        /// <param name="par_anchorItem">This is a simple wrapper for the item which provides the location for the insert operation.</param>
        private void OperateOnList_Insert<TControl>(DLLList<TControl> par_list_NotReallyNeeded,
                                             DLLRange<TControl> par_range,
                                             DLLAnchor<TControl>? par_anchorItem,
                                     bool pbEndpointProtection,
                                     bool pbIsChangeOfEndpoint = false,
                                     bool pbRunOtherChecks = false)
            where TControl : IDoublyLinkedItem<TControl>
        {
            //
            // Added 4/17/2024
            //
            //   This is a private singly-generic method (Of TControl),
            //   to obey the DRY principle inside a doubly-generic class 
            //   (Of TControl_H, TControl_V). 
            //  
            // Insertion operation
            //
            if (par_anchorItem == null)
            {
                //
                // Option #1 of 3...  
                //
                //    The list is empty (and therefore not any anchoring-item  
                //    included, i.e. the anchor is NULL,
                //    as it is irrelevant (or possible)).
                //
                if (par_list_NotReallyNeeded._isEmpty_OrTreatAsEmpty)
                {
                    //List is currently empty, or should be treated as such
                    //   because user has chosen to delete all of the items.
                    //Set the list to contain ALL & ONLY items in the range.
                    //   ---4/30/2024 td
                    par_list_NotReallyNeeded._itemStart = par_range._StartingItem;
                    par_list_NotReallyNeeded._itemEnding = par_range._EndingItem;
                    par_list_NotReallyNeeded._isEmpty_OrTreatAsEmpty = false;
                    par_list_NotReallyNeeded._itemCount = par_range._ItemCount;

                }
                else
                {
                    // Debugging is needed.
                    Debugger.Break();
                }

            }


            //if (par_anchorItem != null && _willInsertRange_AfterAnchor)
            else if (par_anchorItem != null && par_anchorItem._doInsertRangeAfterThis)
            {
                //
                // Option #2 of 3...  
                //
                // Insert the range AFTER (FOLLOWING) the anchoring item. 
                //
                TControl? itemOriginallyAfterAnchor = default(TControl);
                bool bAnchorHasItemAfter;
                bAnchorHasItemAfter = par_anchorItem._anchorItem.DLL_HasNext();

                if (par_anchorItem._anchorItem.DLL_HasNext())
                {
                    //
                    // #2a of 3. 
                    //
                    // Get the item AFTER the anchor; and also "unbox" it,
                    //   i.e. get the TControl object (vs. an interface).
                    itemOriginallyAfterAnchor = par_anchorItem._anchorItem
                        .DLL_GetItemNext_OfT(); // .DLL_UnboxControl_OfT()

                    if (Testing.AreWeTesting)
                    {
                        // Let's test two(2) things...
                        //
                        //   1) The anchor is in the list. 
                        //   2) The operation has already taken place, or is superfluous (not needed).
                        //
                        bool bListHasAnchor = par_list_NotReallyNeeded.Contains(par_anchorItem._anchorItem);
                        if (false == bListHasAnchor)
                        {
                            // Surprising situation. Some debugging ought to be performed. 
                            Debugger.Break();
                        }
                        // Has the operation already taken place?  Is it not needed? 
                        //    (If so, some debugging should be performed.)
                        if (bAnchorHasItemAfter)
                        {
                            bool bInsertIsAlreadyDone = itemOriginallyAfterAnchor.Equals(par_range._StartingItem);
                            if (bInsertIsAlreadyDone) System.Diagnostics.Debugger.Break();
                            if (bInsertIsAlreadyDone) return; // Don't repeat an unneeded operation.
                        }
                        else
                        {
                            //Confirm that the anchor is at the end of the list. 
                            bool bAnchor_Is_EndOfList;
                            bAnchor_Is_EndOfList = (par_anchorItem._anchorItem.Equals(par_list_NotReallyNeeded._itemEnding));
                            if (false == bAnchor_Is_EndOfList) Debugger.Break();
                        }

                    }

                    //Perform the operation !!
                    //   ---par_anchor.DLL_SetItemNext(par_list._itemStart);
                    par_anchorItem._anchorItem.DLL_SetItemNext(par_range._StartingItem);

                    // Administration (i.e. easy to forget!!)
                    // 10=2024  par_range._StartingItem.DLL_SetItemPrior(par_anchor._anchorItem);
                    // 10-2024  par_range._EndingItem.DLL_SetItemNext(itemOriginallyAfterAnchor);
                    par_range.ItemStart().DLL_SetItemPrior(par_anchorItem._anchorItem);
                    par_range.Item__End().DLL_SetItemNext(itemOriginallyAfterAnchor);
                    itemOriginallyAfterAnchor.DLL_SetItemPrior(par_range._EndingItem);
                }
                else
                {
                    //
                    // #2b of 3. Anchor is at the end of the list.
                    //
                    // Nothing originally (pre-operation) follows the anchor,
                    //    i.e. there is no item which is "Next" after the anchor.
                    //
                    if (Testing.AreWeTesting)
                    {
                        bool bListHasAnchor = par_list_NotReallyNeeded.Contains(par_anchorItem._anchorItem);
                        if (false == bListHasAnchor) Debugger.Break();
                        bool bAnchorIsEndOfList;
                        bAnchorIsEndOfList = (par_anchorItem._anchorItem.Equals(par_list_NotReallyNeeded._itemEnding));
                        if (false == bAnchorIsEndOfList) Debugger.Break();

                    }

                    //Perform the operation !!
                    par_anchorItem._anchorItem.DLL_SetItemNext(par_range._StartingItem);

                    // Administration (i.e. easy to forget!!)
                    par_range._StartingItem.DLL_SetItemPrior(par_anchorItem._anchorItem);

                }


            }

            //else if (par_anchorItem != null && _willInsertRange_PriorToAnchor)
            else if (par_anchorItem != null && par_anchorItem._doInsertRangeBeforeThis)
            {
                //
                // Option #3 of 3...  
                //
                // Insert the range PRIOR (PRECEDING) to the anchoring item.
                //
                IDoublyLinkedItem<TControl>
                    itemOriginallyBeforeAnchor = par_anchorItem._anchorItem.DLL_GetItemPrior_OfT();

                bool bAnchorHasItemBefore;
                bAnchorHasItemBefore = par_anchorItem._anchorItem.DLL_HasPrior();

                if (Testing.AreWeTesting)
                {
                    bool bAnchorIsMissingFromList; //Added 4/23/2024 td
                    bAnchorIsMissingFromList = (false == par_list_NotReallyNeeded.Contains(par_anchorItem._anchorItem));
                    if (bAnchorIsMissingFromList) Debugger.Break();

                    if (bAnchorHasItemBefore)
                    {
                        bool bInsertIs_AlreadyDone = itemOriginallyBeforeAnchor.Equals(par_range._EndingItem);
                        if (bInsertIs_AlreadyDone) System.Diagnostics.Debugger.Break();
                        if (bInsertIs_AlreadyDone) return; // Don't repeat an unneeded operation.
                    }
                    else
                    {
                        // Confirm that the anchor is the first item in the list.
                        bool bAnchorIs_StartOfList;
                        bAnchorIs_StartOfList = (par_anchorItem._anchorItem.Equals(par_list_NotReallyNeeded._itemEnding));
                        if (false == bAnchorIs_StartOfList) Debugger.Break();
                    }

                } // if (Testing.AreWeTesting )

                if (bAnchorHasItemBefore)  // (itemOriginallyBeforeAnchor != null)
                {
                    //
                    // #3a of 3. 
                    //
                    // Insert the range before the anchor. 
                    par_anchorItem._anchorItem.DLL_SetItemPrior(par_range._EndingItem);

                    // Administration (i.e. easy to forget!!)
                    par_range._EndingItem.DLL_SetItemNext(par_anchorItem._anchorItem);
                    par_range._StartingItem.DLL_SetItemPrior(itemOriginallyBeforeAnchor);
                    itemOriginallyBeforeAnchor.DLL_SetItemNext(par_range._StartingItem);
                }
                else
                {
                    //
                    // #3b of 3.  Anchor is at the start of the list. 
                    //
                    // Insert the range before the anchor. 
                    par_anchorItem._anchorItem.DLL_SetItemPrior(par_range._EndingItem);
                    // Administration (i.e. easy to forget!!)
                    par_range._EndingItem.DLL_SetItemNext(par_anchorItem._anchorItem);
                }

            }
            //
            // End of Insertion operation.  
            //
        }


        private void OperateOnList_Delete<TControl>(DLLList<TControl> par_list,
                                                DLLRange<TControl> par_range,
                                     bool pbEndpointProtection,
                                     bool pbIsChangeOfEndpoint = false,
                                     bool pbRunOtherChecks = false)
            where TControl : IDoublyLinkedItem<TControl>
        {
            //
            // Added 4/17/2024
            //
            //   This is a private singly-generic method (Of TControl),
            //   to obey the DRY principle inside a doubly-generic class 
            //   (Of TControl_H, TControl_V). 
            //  
            // De-link the item BEFORE the deletion range.
            //
            //IDoublyLinkedItem<TControl>
            //    itemOriginallyBeforeRange = par_range._StartingItem.DLL_GetItemPrior_OfT();
            TControl itemOriginallyBeforeRange = par_range.ItemStart().DLL_GetItemPrior_OfT();

            if (itemOriginallyBeforeRange != null)
            {
                itemOriginallyBeforeRange.DLL_ClearReferenceNext('D');
                if (ALWAYS_CLEAN_ENDPOINTS)
                {
                    par_range._StartingItem.DLL_ClearReferencePrior('D');
                }
            }

            //
            // De-link the item AFTER the deletion range.
            //
            //IDoublyLinkedItem<TControl>
            TControl itemOriginallyAfterRange = par_range.Item__End().DLL_GetItemNext_OfT();
                // itemOriginallyAfterRange = par_range._EndingItem.DLL_GetItemNext_OfT();

            if (itemOriginallyAfterRange != null)
            {
                itemOriginallyAfterRange.DLL_ClearReferencePrior('D');
                if (ALWAYS_CLEAN_ENDPOINTS)
                {
                    // par_range._EndingItem.DLL_ClearReferenceNext('D');
                    par_range.Item__End().DLL_ClearReferenceNext('D');
                }
            }

            // Administration.  Easy to forget!
            if (itemOriginallyAfterRange != null)
            {
                if (itemOriginallyBeforeRange != null)
                {
                    itemOriginallyBeforeRange.DLL_SetItemNext(itemOriginallyAfterRange);
                    itemOriginallyAfterRange.DLL_SetItemPrior(itemOriginallyBeforeRange);
                }
                else
                {
                    par_list._itemStart = itemOriginallyAfterRange;
                    par_list._itemCount -= par_range.GetItemCount();
                    par_list.NotifyOfModification();

                }
            }
            else
            {
                if (itemOriginallyBeforeRange != null)
                {
                    itemOriginallyBeforeRange.DLL_ClearReferenceNext('D');
                }
                else
                {
                    //
                    //  The range is the entire list.
                    //
                    //  Remove the entire list. 
                    //
                    par_list.DLL_RemoveAllItems();

                }

            }

            //
            // End of Deletion operation.  
            //

        }


        /****
         * 
         * 
         * public void OperateOnList(DLLList<TControl_H> par_list)
        {
            // public void OperateOnList(LinkedList<TControl_H> par_list)
            //
            // Added 4/17/2024
            //
            //if (_anchor_H != null && _willInsertRange_AfterAnchor)
            if (_anchor_H != null && _range_H != null 
                && _anchor_H._doInsertRangeAfterThis)
            {
                OperateOnList_Insert<TControl_H>(par_list, _range_H, _anchor_H);

                //foreach (TControl_H each_item in _range_H)
                //{
                //    LinkedListNode<TControl_H> linkedAnchor = new LinkedListNode<TControl_H>(_anchor_H);
                //    par_list.AddAfter(linkedAnchor, each_item);
                //}
                TControl_H? nextAfterAnchor = default(TControl_H); //null;
                if (_anchor_H._anchorItem.DLL_HasNext())
                {
                    nextAfterAnchor = _anchor_H._anchorItem.DLL_GetItemNext().DLL_UnboxControl();

                    // Testing for anomalies.
                    if (Testing.AreWeTesting)
                    {
                        bool bAlreadyDone = nextAfterAnchor.Equals(_range_H._StartingItem);
                        if (bAlreadyDone) System.Diagnostics.Debugger.Break();
                        if (bAlreadyDone) return;
                    }

                    _anchor_H._anchorItem.DLL_SetItemNext(_range_H._StartingItem);

                    //Administrative.  (Easy to overlook.)
                    _range_H._StartingItem.DLL_SetItemPrior(_anchor_H._anchorItem);
                    _range_H._EndingItem.DLL_SetItemNext(nextAfterAnchor);
                    nextAfterAnchor.DLL_SetItemPrior(_range_H._EndingItem);

                }
            }
        }
        *
        *
        **********/


        /// <summary>
        /// Create the inverse (Undo) version, created when an "Undo" operation is needed.
        /// </summary>
        /// <returns>Inverse of the present operation</returns>
        public DLLOperation1D<TControl> // <TControl_H, TControl_V>
            GetInverseForUndo()
        {

            DLLOperation1D<TControl> result_UNDO;
            //DLLRange<TControl_H> result_RangeOfItems_H = _range_H;
            //DLLRange<TControl_V> result_RangeOfItems_V = _range_V;
            //TControl_H? result_anchor_H = _anchor_H;
            //TControl_V? result_anchor_V = _anchor_V;

            bool result_isInsert = _isDelete; // DIFFICULT & CONFUSING... inverse/opposite.
            bool result_isDelete = _isInsert; // DIFFICULT & CONFUSING... inverse/opposite.
            bool result_isMove = _isMove;
            bool result_isForStartOfList = _isForStartOfList;
            bool result_isForEndOfList = _isForEndOfList;
            bool result_isSortAscending = false; // _isSortingDescending; // DIFFICULT & CONFUSING... inverse/opposite.
            bool result_isSortDescending = false; // _isSortingAscending; // DIFFICULT & CONFUSING... inverse/opposite.
            bool result_isSortUndo = true; // DIFFICULT & CONFUSING... inverse/opposite.

            //--- DIFFICULT & CONFUSING ---
            if (_isMove && _isForStartOfList) result_isForStartOfList = false;
            if (_isMove && _isForEndOfList) result_isForEndOfList = false;

            //
            // Create a new operation.
            //
            //---if (_isHoriz)
            //---{

            DLLRange<TControl>? result_RangeOfItems = _range;
            DLLAnchor<TControl>? result_anchor = _anchor_forUndo;  // Use the "forUndo" anchor.

            //
            // Use the constructor overload for horizontal operations.
            //
            result_UNDO = new DLLOperation1D<TControl>(result_RangeOfItems,
                result_isForStartOfList,
                result_isForEndOfList,
                result_isInsert,
                result_isDelete,
                result_isMove,
                result_anchor,
                result_isSortAscending,
                result_isSortDescending,
                result_isSortUndo);

            //----}

            return result_UNDO;

        }


        /// <summary>
        /// Create the inverse (Undo) version, created when an "Undo" operation is needed.
        /// </summary>
        /// <returns>Inverse of the present operation</returns>
        public DLLOperation1D<TControl> GetPrior()
        {
            //
            // Added 5/25/2024 
            //
            return mod_opPrior_ForUndo;

        }

        /// <summary>
        /// Create the inverse (Undo) version, created when an "Undo" operation is needed.
        /// </summary>
        /// <returns>Inverse of the present operation</returns>
        public DLLOperation1D<TControl> GetNext()
        {
            //
            // Added 5/25/2024 
            //
            return mod_opNext_ForRedo;

        }


        public bool HasPrior()
        {
            //
            // Added 5/25/2024 
            //
            return (mod_opPrior_ForUndo != null);

        }

        public bool HasNext()
        {
            //
            // Added 5/25/2024 
            //
            return (mod_opNext_ForRedo != null);

        }


        public IDoublyLinkedItem GetInitialItemInRange()
        {
            // Added 6/06/2024 td
            //if (_isHoriz && _range_H != null) return (IDoublyLinkedItem)(_range_H._StartingItem);
            //if (_isVerti && _range_V != null) return (IDoublyLinkedItem)(_range_V._StartingItem);

            return (IDoublyLinkedItem)(_range._StartingItem);
            //return null;
        }


        //public DLLRange<TControl_H> GetRange_Horiz()
        //{
        //    // Added 6/06/2024 td
        //    return _range_H;
        //}
        //public DLLRange<TControl_V> GetRange_Verti()
        //{
        //    // Added 6/06/2024 td
        //    return _range_V;
        //}

        public DLLRange<TControl> GetRange()
        {
            // Added 6/06/2024 td
            return _range;
        }


        public bool IsForSingleItem()
        {
            // Added 6/06/2024 td
            //if (_isHoriz && _range_H != null) return _range_H._isSingleItem;
            //if (_isVerti && _range_V != null) return _range_V._isSingleItem;
            //return false;

            return _range._isSingleItem;

        }


        public DLLOperation1D<TControl> DLL_GetOpPrior()
        {
            return mod_opPrior_ForUndo;

        }


        public DLLOperation1D<TControl> DLL_GetOpNext()
        {
            return mod_opNext_ForRedo;

        }


        public void DLL_SetOpPrior(DLLOperation1D<TControl> parOperation)
        {
            mod_opPrior_ForUndo = parOperation;

        }


        public void DLL_SetOpNext(DLLOperation1D<TControl> parOperation)
        {
            mod_opNext_ForRedo = parOperation;

        }


        public int DLL_GetIndex()
        {
            int result = 0;
            var temp = mod_opPrior_ForUndo;
            while (temp != null)
            {
                result++;
                temp = temp.DLL_GetOpPrior();
            } //until temp == null;  
            return result;
        }


        public bool CheckEndPointsAreClean_PriorToInsert()
        {
            //
            //  Added 7/07/2024  
            //
            //DLLRange<TControl_H> rangeH = _range_H;
            //DLLRange<TControl_V> rangeV = _range_V;
            bool result = false;

            //if (_range_H != null) result = _range_H.CheckEndpointsAreClean_PriorToInsert();
            //if (_range_V != null) result = _range_V.CheckEndpointsAreClean_PriorToInsert();
            //return result;

            result = _range.CheckEndpointsAreClean_PriorToInsert();
            return result;

        }


    }
}


