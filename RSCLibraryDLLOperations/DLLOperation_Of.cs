//using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    internal class DLLOperation<TControl_H, TControl_V>
        where TControl_H : IDoublyLinkedItem<TControl_H>
        where TControl_V : IDoublyLinkedItem<TControl_V>
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
        private readonly bool _isSort_Ascending;
        private readonly bool _isSort_Descending;
        private readonly bool _isSort_UndoOfSort; //Added 4/18/2024 

        //private readonly bool _willInsertRange_PriorToAnchor;
        //private readonly bool _willInsertRange_AfterAnchor;

        //private readonly TControl_H? _anchor_H;
        ///private readonly TControl_V? _anchor_V;

        // Added 4/21/2024 td
        private readonly DLLAnchor<TControl_H>? _anchor_H;
        private readonly DLLAnchor<TControl_V>? _anchor_V;

        //Added 4/18/2024 td 
        private readonly DLLAnchor<TControl_H>? _anchor_forUndo_H;
        private readonly DLLAnchor<TControl_V>? _anchor_forUndo_V;

        private readonly DLLRange<TControl_H>? _range_H;
        private readonly DLLRange<TControl_V>? _range_V;

        /// <summary>
        /// Indicate whether the ENDPOINTS (outward-facing item references 
        /// at either end of a range of items) should be always set to NULL
        /// after a DELETE is performed.
        /// </summary>
        private const bool ALWAYS_CLEAN_ENDPOINTS = true;

        public DLLOperation(DLLRange<TControl_H> par_range, bool par_forStartOfList, bool par_forEndOfList,
                  bool par_isInsert, bool par_isDelete, bool par_isMove, 
                  DLLAnchor<TControl_H>? par_anchor,
                  bool par_isSortAscending, bool par_isSortDescending, bool par_isSortReversal)
        {
            _isHoriz = true;
            _range_H = par_range;
            _anchor_H = par_anchor;
            _isVerti = false; // NOT vertical.

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
            if (_isInsert) _anchor_forUndo_H = null; // par_range. // Deletes don't need an anchor! 
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


        public DLLOperation(bool par_dummy_vertical,
            DLLRange<TControl_V> par_range, bool par_forStartOfList, bool par_forEndOfList,
            bool par_isInsert, bool par_isDelete, bool par_isMove, 
            DLLAnchor<TControl_V>? par_anchor,
            bool par_isSortAscending, bool par_isSortDescending, bool par_isSortReversal)
        {
            _isVerti = true;
            _range_V = par_range;
            _anchor_V = par_anchor;
            _isHoriz = false; // NOT horizontal.

            _isForStartOfList = par_forStartOfList;
            _isForEndOfList = par_forEndOfList;
            _isInsert = par_isInsert;
            _isDelete = par_isDelete;
            _isMove = par_isMove;
            _isSort_Ascending = par_isSortAscending;
            _isSort_Descending = par_isSortDescending;

        }


        public void OperateOnList(DLLList<TControl_H> par_list)
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
                OperateOnList<TControl_H>(par_list, _range_H, _anchor_H);
            }

        }


        public void OperateOnList(DLLList<TControl_V> par_list)
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
                OperateOnList<TControl_V>(par_list, _range_V, _anchor_V);
            }

        }


        private void OperateOnList<TControl>(DLLList<TControl> par_list,
                                     DLLRange<TControl> par_range,
                                     DLLAnchor<TControl>? par_anchor)
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
                OperateOnList_Insert<TControl>(par_list, par_range, par_anchor);
            }
            else if (_isDelete)
            {
                OperateOnList_Delete<TControl>(par_list, par_range);
            }
            else if (_isMove)
            {
                OperateOnList_Delete<TControl>(par_list, par_range);
                OperateOnList_Insert<TControl>(par_list, par_range, par_anchor);
            }

        }

        private void OperateOnList_Insert<TControl>(DLLList<TControl> par_list, 
                                             DLLRange<TControl> par_range,
                                             DLLAnchor<TControl>? par_anchor) 
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


            //if (par_anchor != null && _willInsertRange_AfterAnchor)
            if (par_anchor != null && par_anchor._insertAfter)
            {
                if (Testing.AreWeTesting)
                {
                    if (false == par_list.Contains(par_anchor._item)) Debugger.Break();
                }

                IDoublyLinkedItem<TControl>
                    itemOriginallyAfterAnchor = par_anchor._item.DLL_GetItemNext();

                //par_anchor.DLL_SetItemNext(par_list._itemStart);
                par_anchor._item.DLL_SetItemNext(par_list._itemStart);

                // Administration (i.e. easy to forget!!)
                par_list._itemStart.DLL_SetItemPrior(par_anchor._item);
                par_list._itemEnding.DLL_SetItemNext(itemOriginallyAfterAnchor);
                itemOriginallyAfterAnchor.DLL_SetItemPrior(par_list._itemEnding);

            }

            //else if (par_anchor != null && _willInsertRange_PriorToAnchor)
            else if (par_anchor != null && par_anchor._insertBefore)
            {
                if (Testing.AreWeTesting)
                {
                    bool bAnchorIsMissingFromList; //Added 4/23/2024 td
                    bAnchorIsMissingFromList = (false == par_list.Contains(par_anchor._item));
                    if (bAnchorIsMissingFromList) Debugger.Break();
                } // if (Testing.AreWeTesting )

                IDoublyLinkedItem<TControl>
                    itemOriginallyBeforeAnchor = par_anchor._item.DLL_GetItemPrior();
                par_anchor._item.DLL_SetItemPrior(par_list._itemEnding);

                // Administration (i.e. easy to forget!!)
                par_list._itemEnding.DLL_SetItemNext(par_anchor._item);
                par_list._itemStart.DLL_SetItemPrior(itemOriginallyBeforeAnchor);
                itemOriginallyBeforeAnchor.DLL_SetItemNext(par_list._itemStart);

            }
            //
            // End of Insertion operation.  
            //
        }


        private void OperateOnList_Delete<TControl>(DLLList<TControl> par_list,
                                                DLLRange<TControl> par_range)
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
            IDoublyLinkedItem<TControl>
                itemOriginallyBeforeRange = par_range._StartingItem.DLL_GetItemPrior();

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
            IDoublyLinkedItem<TControl>
                itemOriginallyAfterRange = par_range._EndingItem.DLL_GetItemNext();
            if (itemOriginallyAfterRange != null)
            {
                itemOriginallyAfterRange.DLL_ClearReferencePrior('D');
                if (ALWAYS_CLEAN_ENDPOINTS)
                {
                    par_range._EndingItem.DLL_ClearReferenceNext('D');
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


        public void OperateOnList(LinkedList<TControl_H> par_list)
        {
            //
            // Added 4/17/2024
            //
            if (_anchor_H != null && _willInsertRange_AfterAnchor)
            {
                //foreach (TControl_H each_item in _range_H)
                //{
                //    LinkedListNode<TControl_H> linkedAnchor = new LinkedListNode<TControl_H>(_anchor_H);
                //    par_list.AddAfter(linkedAnchor, each_item);
                //}
            }

        }


        /// <summary>
        /// Create the inverse (Undo) version, created when an "Undo" operation is needed.
        /// </summary>
        /// <returns>Inverse of the present operation</returns>
        public DLLOperation<TControl_H, TControl_V> 
            GetInverseForUndo()
        {

            DLLOperation<TControl_H, TControl_V> result_UNDO;
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
            if (_isHoriz)
            {
                DLLRange<TControl_H> result_RangeOfItems_H = _range_H;
                TControl_H? result_anchor_H = _anchor_forUndo_H;  // Use the "forUndo" anchor.

                result_UNDO = new DLLOperation<TControl_H, TControl_V>(result_RangeOfItems_H,
                    result_isForStartOfList,
                    result_isForEndOfList,
                    result_isInsert,
                    result_isDelete,
                    result_isMove,
                    result_anchor_H,
                    result_isSortAscending,
                    result_isSortDescending,
                    result_isSortUndo);
            }
            else //if (_isVerti)
            {
                DLLRange<TControl_V> result_RangeOfItems_V = _range_V;
                TControl_V? result_anchor_V = _anchor_forUndo_V;  // Use the "forUndo" anchor.

                result_UNDO = new DLLOperation<TControl_H, TControl_V>(true, 
                    result_RangeOfItems_V,
                    result_isForStartOfList,
                    result_isForEndOfList,
                    result_isInsert,
                    result_isDelete,
                    result_isMove,
                    result_anchor_V,
                    result_isSortAscending,
                    result_isSortDescending,
                    result_isSortUndo);
            }

            return result_UNDO;

        }



    }
}
