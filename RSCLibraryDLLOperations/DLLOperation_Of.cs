//using System;
//using System.Collections.Generic;
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

    }
}
