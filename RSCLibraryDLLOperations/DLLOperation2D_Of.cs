﻿//using System;
//using System.Collections.Generic;
using System.Diagnostics;
//using System.Reflection.Metadata.Ecma335;
using ciBadgeInterfaces; //Added 6/20/2024
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    /// <summary>
    /// Moving a column is a horizontal operation, 
    /// moving a row is a vertical operation.
    /// </summary>
    public enum EnumHorizontalOrVertical { Undetermined, Horizontal,  Vertical };


    public class DLLOperation2D<TControl_H, TControl_V> // :IDoublyLinkedItem
        where TControl_H : class, IDoublyLinkedItem<TControl_H>
        where TControl_V : class, IDoublyLinkedItem<TControl_V>
    {
        //''
        //''Added 4/17/2024 td
        //''
        private readonly bool _isHoriz;
        private readonly bool _isVerti;

        private readonly bool _isForStartOfList;
        private readonly bool _isForEndOfList;
        private readonly bool _isForAnchor;

        private readonly bool _isInsert;
        private readonly bool _isDelete;
        private readonly bool _isMove;
        private readonly bool _isSortByValues_Ascending;
        private readonly bool _isSortByValues_Descending;
        private readonly bool _isSort_UndoOfSort; //Added 4/18/2024 
        private readonly bool _isForUndoOperation;  //Added 5/22/2024

        //private readonly bool _willInsertRange_PriorToAnchor;
        //private readonly bool _willInsertRange_AfterAnchor;

        //private readonly TControl_H? _anchorItem_H;
        ///private readonly TControl_V? _anchorItem_V;

        // Added 4/21/2024 td
        private readonly DLLAnchorItem_Deprecated<TControl_H>? _anchorItem_H;
        private readonly DLLAnchorItem_Deprecated<TControl_V>? _anchorItem_V;

        // Added 11/08/2024 td
        private readonly DLLAnchorCouplet<TControl_H>? _anchorPair_H;
        private readonly DLLAnchorCouplet<TControl_V>? _anchorPair_V;

        //Added 4/18/2024 td 
        private readonly DLLAnchorItem_Deprecated<TControl_H>? _inverseAnchorItem_forUndo_H;
        private readonly DLLAnchorItem_Deprecated<TControl_V>? _inverseAnchorItem_forUndo_V;

        //Added 4/18/2024 td 
        private readonly DLLAnchorCouplet<TControl_H>? _inverseAnchorPair_forUndo_H;
        private readonly DLLAnchorCouplet<TControl_V>? _inverseAnchorPair_forUndo_V;

        private readonly DLLRange<TControl_H>? _range_H;
        private readonly DLLRange<TControl_V>? _range_V;

        //Added 5/25/2024 td 
        private readonly DLLOperation2D<TControl_H, TControl_V> mod_opPrior_ForUndo;
        private readonly DLLOperation2D<TControl_H, TControl_V> mod_opNext_ForRedo;


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
            if (_isSortByValues_Ascending) return 'S';
            if (_isSortByValues_Descending) return 'S';
            return ' ';

        }

        public bool IsHorizontal() { return _isHoriz;  }
        public bool IsVertical() { return _isVerti; }

        public bool HasAnchor()
        {
            // Added 6/10/2024
            return (_anchorItem_H != null || _anchorItem_V != null);
        }


        public bool IsAnchorToPrecedeItemOrRange()
        {
            //
            // Added 6/10/2024 thomas downes
            //
            //----BACKWARDS AND CONFUSING----------------------------
            if (_anchorItem_H != null && _isHoriz) return _anchorItem_H._doInsertRangeAfterThis;
            if (_anchorItem_V != null && _isVerti) return _anchorItem_V._doInsertRangeAfterThis;
            throw new InvalidOperationException();

        }


        public bool IsAnchorToSucceedItemOrRange()
        {
            //
            // Added 6/10/2024 thomas downes
            //
            //----BACKWARDS AND CONFUSING----------------------------
            if (_anchorItem_H != null && _isHoriz) return _anchorItem_H._doInsertRangeBeforeThis;
            if (_anchorItem_V != null && _isVerti) return _anchorItem_V._doInsertRangeBeforeThis;
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
        /// <param name="par_anchor"></param>
        /// <param name="par_isSortAscending"></param>
        /// <param name="par_isSortDescending"></param>
        /// <param name="par_isSortReversal"></param>
        public DLLOperation2D(EnumHorizontalOrVertical par_enum,
                  DLLRange<TControl_H>? par_range,
                  bool par_forStartOfList, bool par_forEndOfList,
                  bool par_isInsert, bool par_isDelete, bool par_isMove,
                  DLLAnchorItem_Deprecated<TControl_H>? par_anchorItem,
                  DLLAnchorCouplet<TControl_H>? par_anchorPair,
                  bool par_isSortAscending, bool par_isSortDescending, bool par_isSortReversal)
        {
            //
            // Let's confirm that the calling procedure intends for 
            //   this to be Horizontal operation.--6/10/2024
            //
            if (par_enum != EnumHorizontalOrVertical.Horizontal)
            {
                System.Diagnostics.Debugger.Break();
                throw new InvalidOperationException("Use constructor overload for non-horizontal operations.");
            }

            _isHoriz = true;
            _range_H = par_range;
            _anchorItem_H = par_anchorItem;
            _isVerti = false; // NOT vertical.

            _isForStartOfList = par_forStartOfList;
            _isForEndOfList = par_forEndOfList;
            _isInsert = par_isInsert;
            _isDelete = par_isDelete;
            _isMove = par_isMove;
            _isSortByValues_Ascending = par_isSortAscending;
            _isSortByValues_Descending = par_isSortDescending;

            //Added 4/18/2024 
            _isSort_UndoOfSort = par_isSortReversal; // Undoing a sorting operation.

            //
            //  Preparing for UNDO... Determining an Inverse Anchor for a future UNDO operation.
            //
            //Think about undoing... an INSERT (hence, it's a DELETE)
            if (_isInsert) _inverseAnchorItem_forUndo_H = null; // par_range. // No Inverse Anchor is needed, since Deletes don't need an anchor!
            if (_isInsert) _inverseAnchorPair_forUndo_H = null; // par_range. // No Inverse Anchor is needed, since Deletes don't need an anchor!
                                                                // 
            if (_isDelete && _isForStartOfList)
            {
                //TControl_H item_afterRange = _range_H._itemEnding.DLL_GetItemNext();
                //_anchor_forUndo_H = new DLLAnchor<>(item_afterRange); 
            }
            else if (_isDelete && _isForEndOfList)
            {
                //TControl_H item_afterRange = _range_H._itemStart.DLL_GetItemPrior();
                //_anchor_forUndo_H = new DLLAnchor<>(item_afterRange);
            }

        }


        /// <summary>
        /// Constructor overload is for vertical (row) operations, 
        /// e.g. moving a worksheet's entire row to the top, 
        /// with TControl_V = RSDataRowHeader.  Overloaded.
        /// </summary>
        /// <param name="pb_isOperationVertical">Must be true.</param>
        /// <param name="par_range"></param>
        /// <param name="par_forStartOfList"></param>
        /// <param name="par_forEndOfList"></param>
        /// <param name="par_isInsert"></param>
        /// <param name="par_isDelete"></param>
        /// <param name="par_isMove"></param>
        /// <param name="par_anchor"></param>
        /// <param name="par_isSortAscending"></param>
        /// <param name="par_isSortDescending"></param>
        /// <param name="par_isSortReversal"></param>
        public DLLOperation2D(bool pb_isOperationVertical,
            DLLRange<TControl_V>? par_range, bool par_forStartOfList, bool par_forEndOfList,
            bool par_isInsert, bool par_isDelete, bool par_isMove,
            DLLAnchorItem_Deprecated<TControl_V>? par_anchorItem,
            DLLAnchorCouplet<TControl_V>? par_anchorPair,
            bool par_isSortAscending, bool par_isSortDescending, bool par_isSortReversal)
        {
            //Added 4/30/2024 td
            if (!pb_isOperationVertical) System.Diagnostics.Debugger.Break();

            _isVerti = true;
            _range_V = par_range;
            _anchorItem_V = par_anchorItem;
            _anchorPair_V = par_anchorPair;
            _isHoriz = false; // NOT horizontal.

            _isForStartOfList = par_forStartOfList;
            _isForEndOfList = par_forEndOfList;
            _isInsert = par_isInsert;
            _isDelete = par_isDelete;
            _isMove = par_isMove;
            _isSortByValues_Ascending = par_isSortAscending;
            _isSortByValues_Descending = par_isSortDescending;

        }


        public void OperateOnList(DLLList<TControl_H> par_list)
        {
            //
            // Added 4/17/2024
            //
            if (_isSortByValues_Ascending)
            {

            }
            if (_isSortByValues_Descending)
            {

            }
            else
            {
                OperateOnList<TControl_H>(par_list, _range_H, _anchorItem_H, false);
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="par_list"></param>
        /// <param name="par_doProtectEndpoints">If True, we will throw Exceptions when the Endpoint is impacted, unless the next Boolean parameter is True.</param>
        /// <param name="pbIsChangeOfEndpoint">Prevents exceptions from being raised when an endpoint is changed.</param>
        public void OperateOnList(DLLList<TControl_H> par_list, 
                             bool par_doProtectEndpoints, 
                             bool pbIsChangeOfEndpoint = false)
        {
            //
            // Added 6/10/2024
            //
            if (_isSortByValues_Ascending)
            {

            }
            if (_isSortByValues_Descending)
            {

            }
            else
            {
                // OperateOnList<TControl_H>(par_list, _range_H, _anchorItem_H);
                OperateOnList<TControl_H>(par_list, _range_H, _anchorItem_H, 
                    par_doProtectEndpoints, pbIsChangeOfEndpoint);
            }

        }


        public void OperateOnList(DLLList<TControl_V> par_list)
        {
            //
            // Added 4/17/2024
            //
            if (_isSortByValues_Ascending)
            {

            }
            if (_isSortByValues_Descending)
            {

            }
            else
            {
                //
                //   Let's leverage a private singly-generic method (Of TControl),
                //   to obey the DRY principle inside a doubly-generic class 
                //   (Of TControl_H, TControl_V). 
                //  
                OperateOnList<TControl_V>(par_list, _range_V, _anchorItem_V, false);
            }

        }


        public void OperateOnList(DLLList<TControl_V> par_list,
                             bool par_doProtectEndpoints,
                             bool pbIsChangeOfEndpoint = false, 
                             bool pbRunOtherChecks = false)
        {
            //
            // Added 4/17/2024
            //
            if (_isSortByValues_Ascending)
            {

            }
            if (_isSortByValues_Descending)
            {

            }
            else
            {
                //
                //   Let's leverage a private singly-generic method (Of TControl),
                //   to obey the DRY principle inside a doubly-generic class 
                //   (Of TControl_H, TControl_V). 
                //  
                OperateOnList<TControl_V>(par_list, _range_V, _anchorItem_V, 
                      par_doProtectEndpoints, pbIsChangeOfEndpoint, pbRunOtherChecks);
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="par_list"></param>
        /// <param name="par_range"></param>
        /// <param name="par_anchor"></param>
        /// <param name="pbEndpointProtection">If True, we will throw Exceptions when the Endpoint is impacted, unless the next Boolean parameter is True.</param>
        /// <param name="pbIsChangeOfEndpoint">Prevents exceptions from being raised when an endpoint is changed.</param>
        private void OperateOnList<TControl>(DLLList<TControl> par_list,
                                     DLLRange<TControl> par_range,
                                     DLLAnchorItem_Deprecated<TControl>? par_anchor, 
                                     bool pbEndpointProtection, 
                                     bool pbIsChangeOfEndpoint = false,
                                     bool pbRunOtherChecks = false)
             where TControl : class, IDoublyLinkedItem<TControl>
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
                OperateOnList_Insert<TControl>(par_list, par_range, par_anchor,
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
                OperateOnList_Insert<TControl>(par_list, par_range, par_anchor,
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
        /// <param name="par_anchor">This is a simple wrapper for the item which provides the location for the insert operation.</param>
        private void OperateOnList_Insert<TControl>(DLLList<TControl> par_list_NotReallyNeeded,
                                             DLLRange<TControl> par_range,
                                             DLLAnchorItem_Deprecated<TControl>? par_anchor,
                                     bool pbEndpointProtection,
                                     bool pbIsChangeOfEndpoint = false,
                                     bool pbRunOtherChecks = false)
            where TControl : class, IDoublyLinkedItem<TControl>
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
            if (par_anchor == null)
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
                    par_list_NotReallyNeeded._itemStart = par_range._StartingItemOfRange;
                    par_list_NotReallyNeeded._itemEnding = par_range._EndingItemOfRange;
                    par_list_NotReallyNeeded._isEmpty_OrTreatAsEmpty = false;
                    par_list_NotReallyNeeded._itemCount = par_range._ItemCountOfRange;

                }
                else
                {
                    // Debugging is needed.
                    Debugger.Break();
                }

            }


            //if (par_anchor != null && _willInsertRange_AfterAnchor)
            else if (par_anchor != null && par_anchor._doInsertRangeAfterThis)
            {
                //
                // Option #2 of 3...  
                //
                // Insert the range AFTER (FOLLOWING) the anchoring item. 
                //
                TControl? itemOriginallyAfterAnchor = default(TControl);
                bool bAnchorHasItemAfter;
                bAnchorHasItemAfter = par_anchor._anchorItem.DLL_HasNext();

                if (par_anchor._anchorItem.DLL_HasNext())
                {
                    //
                    // #2a of 3. 
                    //
                    // Get the item AFTER the anchor; and also "unbox" it,
                    //   i.e. get the TControl object (vs. an interface).
                    itemOriginallyAfterAnchor = par_anchor._anchorItem
                        .DLL_GetItemNext_OfT(); 
                    //Jan24 2025    .DLL_UnboxControl_OfT();

                    if (Testing.AreWeTesting)
                    {
                        // Let's test two(2) things...
                        //
                        //   1) The anchor is in the list. 
                        //   2) The operation has already taken place, or is superfluous (not needed).
                        //
                        bool bListHasAnchor = par_list_NotReallyNeeded.Contains(par_anchor._anchorItem);
                        if (false == bListHasAnchor)
                        {
                            // Surprising situation. Some debugging ought to be performed. 
                            Debugger.Break();
                        }
                        // Has the operation already taken place?  Is it not needed? 
                        //    (If so, some debugging should be performed.)
                        if (bAnchorHasItemAfter)
                        {
                            bool bInsertIsAlreadyDone = itemOriginallyAfterAnchor.Equals(par_range._StartingItemOfRange);
                            if (bInsertIsAlreadyDone) System.Diagnostics.Debugger.Break();
                            if (bInsertIsAlreadyDone) return; // Don't repeat an unneeded operation.
                        }
                        else
                        {
                            //Confirm that the anchor is at the end of the list. 
                            bool bAnchor_Is_EndOfList;
                            bAnchor_Is_EndOfList = (par_anchor._anchorItem.Equals(par_list_NotReallyNeeded._itemEnding));
                            if (false == bAnchor_Is_EndOfList) Debugger.Break();
                        }

                    }

                    //Perform the operation !!
                    //   ---par_anchor.DLL_SetItemNext(par_list._itemStart);
                    par_anchor._anchorItem.DLL_SetItemNext(par_range._StartingItemOfRange);

                    // Administration (i.e. easy to forget!!)
                    par_range._StartingItemOfRange.DLL_SetItemPrior(par_anchor._anchorItem);
                    par_range._EndingItemOfRange.DLL_SetItemNext(itemOriginallyAfterAnchor);
                    itemOriginallyAfterAnchor.DLL_SetItemPrior(par_range._EndingItemOfRange);
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
                        bool bListHasAnchor = par_list_NotReallyNeeded.Contains(par_anchor._anchorItem);
                        if (false == bListHasAnchor) Debugger.Break();
                        bool bAnchorIsEndOfList;
                        bAnchorIsEndOfList = (par_anchor._anchorItem.Equals(par_list_NotReallyNeeded._itemEnding));
                        if (false == bAnchorIsEndOfList) Debugger.Break();

                    }

                    //Perform the operation !!
                    par_anchor._anchorItem.DLL_SetItemNext(par_range._StartingItemOfRange);

                    // Administration (i.e. easy to forget!!)
                    par_range._StartingItemOfRange.DLL_SetItemPrior(par_anchor._anchorItem);

                }


            }

            //else if (par_anchor != null && _willInsertRange_PriorToAnchor)
            else if (par_anchor != null && par_anchor._doInsertRangeBeforeThis)
            {
                //
                // Option #3 of 3...  
                //
                // Insert the range PRIOR (PRECEDING) to the anchoring item.
                //
                IDoublyLinkedItem<TControl>
                    itemOriginallyBeforeAnchor = par_anchor._anchorItem.DLL_GetItemPrior_OfT();
                
                bool bAnchorHasItemBefore;
                bAnchorHasItemBefore = par_anchor._anchorItem.DLL_HasPrior();

                if (Testing.AreWeTesting)
                {
                    bool bAnchorIsMissingFromList; //Added 4/23/2024 td
                    bAnchorIsMissingFromList = (false == par_list_NotReallyNeeded.Contains(par_anchor._anchorItem));
                    if (bAnchorIsMissingFromList) Debugger.Break();

                    if (bAnchorHasItemBefore)
                    {
                        bool bInsertIs_AlreadyDone = itemOriginallyBeforeAnchor.Equals(par_range._EndingItemOfRange);
                        if (bInsertIs_AlreadyDone) System.Diagnostics.Debugger.Break();
                        if (bInsertIs_AlreadyDone) return; // Don't repeat an unneeded operation.
                    }
                    else
                    {
                        // Confirm that the anchor is the first item in the list.
                        bool bAnchorIs_StartOfList;
                        bAnchorIs_StartOfList = (par_anchor._anchorItem.Equals(par_list_NotReallyNeeded._itemEnding));
                        if (false == bAnchorIs_StartOfList) Debugger.Break();
                    }

                } // if (Testing.AreWeTesting )

                if (bAnchorHasItemBefore)  // (itemOriginallyBeforeAnchor != null)
                {
                    //
                    // #3a of 3. 
                    //
                    // Insert the range before the anchor. 
                    par_anchor._anchorItem.DLL_SetItemPrior(par_range._EndingItemOfRange);

                    // Administration (i.e. easy to forget!!)
                    par_range._EndingItemOfRange.DLL_SetItemNext(par_anchor._anchorItem);
                    par_range._StartingItemOfRange.DLL_SetItemPrior(itemOriginallyBeforeAnchor);
                    itemOriginallyBeforeAnchor.DLL_SetItemNext(par_range._StartingItemOfRange);
                }
                else
                {
                    //
                    // #3b of 3.  Anchor is at the start of the list. 
                    //
                    // Insert the range before the anchor. 
                    par_anchor._anchorItem.DLL_SetItemPrior(par_range._EndingItemOfRange);
                    // Administration (i.e. easy to forget!!)
                    par_range._EndingItemOfRange.DLL_SetItemNext(par_anchor._anchorItem);
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
            where TControl : class, IDoublyLinkedItem<TControl>
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
            IDoublyLinkedItem<TControl>
                itemOriginallyBeforeRange = par_range._StartingItemOfRange.DLL_GetItemPrior_OfT();

            if (itemOriginallyBeforeRange != null)
            {
                itemOriginallyBeforeRange.DLL_ClearReferenceNext('D');
                if (ALWAYS_CLEAN_ENDPOINTS)
                {
                    par_range._StartingItemOfRange.DLL_ClearReferencePrior('D');
                }
            }

            //
            // De-link the item AFTER the deletion range.
            //
            IDoublyLinkedItem<TControl>
                itemOriginallyAfterRange = par_range._EndingItemOfRange.DLL_GetItemNext_OfT();   

            if (itemOriginallyAfterRange != null)
            {
                itemOriginallyAfterRange.DLL_ClearReferencePrior('D');
                if (ALWAYS_CLEAN_ENDPOINTS)
                {
                    par_range._EndingItemOfRange.DLL_ClearReferenceNext('D');
                }
            }

            // Administration.  Easy to forget!
            if (itemOriginallyAfterRange != null)
            {
                if (itemOriginallyBeforeRange != null)
                {
                    itemOriginallyBeforeRange.DLL_SetItemNext(itemOriginallyAfterRange);
                    itemOriginallyAfterRange.DLL_SetItemNext(itemOriginallyBeforeRange);
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
            //if (_anchorItem_H != null && _willInsertRange_AfterAnchor)
            if (_anchorItem_H != null && _range_H != null 
                && _anchorItem_H._doInsertRangeAfterThis)
            {
                OperateOnList_Insert<TControl_H>(par_list, _range_H, _anchorItem_H);

                //foreach (TControl_H each_item in _range_H)
                //{
                //    LinkedListNode<TControl_H> linkedAnchor = new LinkedListNode<TControl_H>(_anchorItem_H);
                //    par_list.AddAfter(linkedAnchor, each_item);
                //}
                TControl_H? nextAfterAnchor = default(TControl_H); //null;
                if (_anchorItem_H._anchorItem.DLL_HasNext())
                {
                    nextAfterAnchor = _anchorItem_H._anchorItem.DLL_GetItemNext().DLL_UnboxControl();

                    // Testing for anomalies.
                    if (Testing.AreWeTesting)
                    {
                        bool bAlreadyDone = nextAfterAnchor.Equals(_range_H._StartingItem);
                        if (bAlreadyDone) System.Diagnostics.Debugger.Break();
                        if (bAlreadyDone) return;
                    }

                    _anchorItem_H._anchorItem.DLL_SetItemNext(_range_H._StartingItem);

                    //Administrative.  (Easy to overlook.)
                    _range_H._StartingItem.DLL_SetItemPrior(_anchorItem_H._anchorItem);
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
        public DLLOperation2D<TControl_H, TControl_V>
            GetInverseForUndo()
        {

            DLLOperation2D<TControl_H, TControl_V> result_UNDO;
            //DLLRange<TControl_H> result_RangeOfItems_H = _range_H;
            //DLLRange<TControl_V> result_RangeOfItems_V = _range_V;
            //TControl_H? result_anchorItem_H = _anchorItem_H;
            //TControl_V? result_anchorItem_V = _anchorItem_V;

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
            if (_isHoriz)
            {
                DLLRange<TControl_H>? result_RangeOfItems_H = _range_H;
                DLLAnchorItem_Deprecated<TControl_H>? result_anchorItem_H = _inverseAnchorItem_forUndo_H;  // Use the "forUndo" anchor.
                DLLAnchorCouplet<TControl_H>? result_anchorPair_H = _inverseAnchorPair_forUndo_H;  // Use the "forUndo" anchor.

                //
                // Use the constructor overload for horizontal operations.
                //
                result_UNDO = new DLLOperation2D<TControl_H, TControl_V>(EnumHorizontalOrVertical.Horizontal,
                    result_RangeOfItems_H,
                    result_isForStartOfList,
                    result_isForEndOfList,
                    result_isInsert,
                    result_isDelete,
                    result_isMove,
                    result_anchorItem_H,
                    result_anchorPair_H,
                    result_isSortAscending,
                    result_isSortDescending,
                    result_isSortUndo);
            }
            else //if (_isVerti)
            {
                DLLRange<TControl_V> result_RangeOfItems_V = _range_V;
                DLLAnchorItem_Deprecated<TControl_V>? result_anchorItem_V = _inverseAnchorItem_forUndo_V;  // Use the "forUndo" anchor.
                DLLAnchorCouplet<TControl_V>? result_anchorPair_V = _inverseAnchorPair_forUndo_V;  // Use the "forUndo" anchor.

                //
                // Use the constructor overload for vertical operations.
                //
                result_UNDO = new DLLOperation2D<TControl_H, TControl_V>(true,
                    result_RangeOfItems_V,
                    result_isForStartOfList,
                    result_isForEndOfList,
                    result_isInsert,
                    result_isDelete,
                    result_isMove,
                    result_anchorItem_V,
                    result_anchorPair_V,
                    result_isSortAscending,
                    result_isSortDescending,
                    result_isSortUndo);
            }

            return result_UNDO;

        }


        /// <summary>
        /// Create the inverse (Undo) version, created when an "Undo" operation is needed.
        /// </summary>
        /// <returns>Inverse of the present operation</returns>
        public DLLOperation2D<TControl_H, TControl_V>
            GetPrior()
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
        public DLLOperation2D<TControl_H, TControl_V>
            GetNext()
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
            if (_isHoriz && _range_H != null) return (IDoublyLinkedItem)(_range_H._StartingItemOfRange);
            if (_isVerti && _range_V != null) return (IDoublyLinkedItem)(_range_V._StartingItemOfRange);
            return null; 
        }


        public DLLRange<TControl_H> GetRange_Horiz()
        {
            // Added 6/06/2024 td
            return _range_H;
        }

        public DLLRange<TControl_V> GetRange_Verti()
        {
            // Added 6/06/2024 td
            return _range_V;
        }


        public bool IsForSingleItem()
        {
            // Added 6/06/2024 td
            if (_isHoriz && _range_H != null) return _range_H._isSingleItem;
            if (_isVerti && _range_V != null) return _range_V._isSingleItem;
            return false;

        }


        public DLLOperation2D<TControl_H, TControl_V> DLL_GetOpPrior()
        {
            return mod_opPrior_ForUndo;

        }

        public DLLOperation2D<TControl_H, TControl_V> DLL_GetOpNext()
        {
            return mod_opNext_ForRedo;

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
            DLLRange<TControl_H> rangeH = _range_H;
            DLLRange<TControl_V> rangeV = _range_V;
            bool result = false;

            //if (_range_H != null) result = _range_H.CheckEndpointsAreClean_PriorToInsert();
            //if (_range_V != null) result = _range_V.CheckEndpointsAreClean_PriorToInsert();
            if (_range_H != null) result = _range_H.CheckEndpointsAreClean_PriorToInsert();
            if (_range_V != null) result = _range_V.CheckEndpointsAreClean_PriorToInsert();

            return result; 

        }


    }
}
