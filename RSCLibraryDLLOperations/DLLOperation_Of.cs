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
        private readonly bool _isSortingAscending;
        private readonly bool _isSortingDescending;

        private readonly bool _willInsertRange_PriorToAnchor;
        private readonly bool _willInsertRange_AfterAnchor;

        private readonly TControl_H? _anchor_H;
        private readonly TControl_V? _anchor_V;

        private readonly DLLRange<TControl_H>? _range_H;
        private readonly DLLRange<TControl_V>? _range_V;

        private const bool ALWAYS_CLEAN_ENDPOINTS = true;

        public DLLOperation(DLLRange<TControl_H> par_range, bool par_forStartOfList, bool par_forEndOfList, 
                  bool par_isInsert, bool par_isDelete, bool par_isMove, TControl_H? par_anchor,
                  bool par_isSortAscending, bool par_isSortDescending)
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
            _isSortingAscending = par_isSortAscending;
            _isSortingDescending = par_isSortDescending;

        }


        public DLLOperation(DLLRange<TControl_V> par_range, bool par_forStartOfList, bool par_forEndOfList,
          bool par_isInsert, bool par_isDelete, bool par_isMove, TControl_V? par_anchor,
          bool par_isSortAscending, bool par_isSortDescending)
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
            _isSortingAscending = par_isSortAscending;
            _isSortingDescending = par_isSortDescending;

        }


        public void OperateOnList(DLLList<TControl_H> par_list)
        {
            //
            // Added 4/17/2024
            //
            if (_isInsert)
            { 
                //
                // Insertion operation
                //
                if (_anchor_H != null && _willInsertRange_AfterAnchor)
                {
                    if (Testing.AreWeTesting)
                    {
                        if (false == par_list.Contains(_anchor_H)) Debugger.Break();
                    }

                    IDoublyLinkedItem<TControl_H>
                        itemOriginallyAfterAnchor = _anchor_H.DLL_GetItemNext();
                    _anchor_H.DLL_SetItemNext(par_list._itemStart);

                    // Administration (i.e. easy to forget!!)
                    par_list._itemStart.DLL_SetItemPrior(_anchor_H);
                    par_list._itemEnding.DLL_SetItemNext(itemOriginallyAfterAnchor);
                    itemOriginallyAfterAnchor.DLL_SetItemPrior(par_list._itemEnding);

                }

                else if (_anchor_H != null && _willInsertRange_PriorToAnchor)
                {
                    if (Testing.AreWeTesting)
                    {
                        if (false == par_list.Contains(_anchor_H)) Debugger.Break();
                    }

                    IDoublyLinkedItem<TControl_H>
                        itemOriginallyBeforeAnchor = _anchor_H.DLL_GetItemPrior();
                    _anchor_H.DLL_SetItemPrior(par_list._itemEnding);

                    // Administration (i.e. easy to forget!!)
                    par_list._itemEnding.DLL_SetItemNext(_anchor_H);
                    par_list._itemStart.DLL_SetItemPrior(itemOriginallyBeforeAnchor);
                    itemOriginallyBeforeAnchor.DLL_SetItemNext(par_list._itemStart);

                }
                //
                // End of Insertion operation.  
                //
            }


            else if (_isDelete)
            {
                //
                // De-link the item BEFORE the deletion range.
                //
                IDoublyLinkedItem<TControl_H>
                    itemOriginallyBeforeRange = _range_H._itemStart.DLL_GetItemPrior();
                if (itemOriginallyBeforeRange != null)
                {
                    itemOriginallyBeforeRange.DLL_ClearReferenceNext('D');
                    if (ALWAYS_CLEAN_ENDPOINTS)
                    {
                        _range_H._itemStart.DLL_ClearReferencePrior('D');
                    }
                }

                //
                // De-link the item AFTER the deletion range.
                //
                IDoublyLinkedItem<TControl_H>
                    itemOriginallyAfterRange = _range_H._itemEnding.DLL_GetItemNext();
                if (itemOriginallyAfterRange != null)
                {
                    itemOriginallyAfterRange.DLL_ClearReferencePrior('D');
                    if (ALWAYS_CLEAN_ENDPOINTS)
                    {
                        _range_H._itemEnding.DLL_ClearReferenceNext('D');
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



    }
}
