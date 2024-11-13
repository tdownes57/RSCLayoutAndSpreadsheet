using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    /// <summary>
    /// Also called Anchor Pair, an Anchor Couplet is a pair of Anchoring Items, 
    /// which bookend a range (or more accurately WILL bookend a range, after 
    /// an operation takes place). Couplets do NOT (directly) contain any range 
    /// items, although (after a DLL list operation) it may "enclose" the range. 
    /// ... Furthermore, a list operation (e.g. an insert) probably won't need to 
    /// check the DLL_Get() functions, but will simply call the DLL_Set() methods
    /// (in contrast
    /// </summary>
    /// <typeparam name="TControl"></typeparam>
    public class DLLAnchorCouplet<TControl>
          where TControl : IDoublyLinkedItem<TControl>
    {
        //
        //  Anchor Couplet 
        //
        private TControl? _itemAnchorPrior;
        private TControl? _itemAnchorAfter;

        /// <summary>
        /// For operations which are the (initial) load an empty list. 
        /// </summary>
        public bool _isForEmptyList;

        /// <summary>
        /// For operations which will delete items from a list. 
        /// </summary>
        public bool _isForDeletionOperation;

        public DLLAnchorCouplet(TControl par_itemAnchorPrior, TControl par_itemAnchorAfter)
        {
            _itemAnchorPrior = par_itemAnchorPrior;  // May be null.
            _itemAnchorAfter = par_itemAnchorAfter; // May be null.

        }


        public DLLAnchorCouplet(DLLAnchorItem<TControl> par_itemAnchor)
        {
            //
            // Added 11/10/2024  
            //
            bool bInsertRangeAfterAnchorItem;
            bInsertRangeAfterAnchorItem = par_itemAnchor._doInsertRangeAfterThis;

            if (bInsertRangeAfterAnchorItem)
            {
                _itemAnchorPrior = par_itemAnchor._anchorItem;  // May be null.
                _itemAnchorAfter = par_itemAnchor._anchorItem.DLL_GetItemNext_OfT();  // May be null.

            }
            else
            {
                _itemAnchorPrior = par_itemAnchor._anchorItem.DLL_GetItemPrior_OfT();  // May be null.
                _itemAnchorAfter = par_itemAnchor._anchorItem;  // May be null.
            }

        }


        public DLLAnchorCouplet(TControl? par_itemAnchorPrior, TControl? par_itemAnchorAfter, bool pbAllowNulls)
        {

            if (!pbAllowNulls && par_itemAnchorPrior == null) System.Diagnostics.Debugger.Break();
            else if (!pbAllowNulls && par_itemAnchorAfter == null) System.Diagnostics.Debugger.Break();
            else
            {
                _itemAnchorPrior = par_itemAnchorPrior;  // May be null.
                _itemAnchorAfter = par_itemAnchorAfter; // May be null.
            }
        }


        public DLLAnchorCouplet(bool pbIsForEmptyList, bool pbIsForDeletionOp)
        {
            //
            // Added 10/20/2024 
            //
            _itemAnchorPrior = default(TControl);
            _itemAnchorAfter = default(TControl);
            _isForEmptyList = pbIsForEmptyList;
            _isForDeletionOperation = pbIsForDeletionOp;
        }



        public DLLAnchorItem<TControl> GetAnchorItem()
        {
            DLLAnchorItem<TControl> result; 
            if (_itemAnchorPrior != null)
            {
                result = new DLLAnchorItem<TControl>(_itemAnchorPrior);
                result._doInsertRangeAfterThis = true;
            }
            else if (_itemAnchorAfter != null)
            {
                result = new DLLAnchorItem<TControl>(_itemAnchorAfter);
                result._doInsertRangeBeforeThis = true;
            }
            else
            {
                // Added 11/11/2024 
                result = new DLLAnchorItem<TControl>(true, true);
            }
            return result;

        }


        public bool ItemPriorIsNull()
        {
            //Added 11/8/2024  

            return _itemAnchorPrior == null;
        }

        public bool ItemAfterIsNull()
        {
            //Added 11/8/2024  
            return _itemAnchorAfter == null;
        }


        //public DLLAnchorCouplet(TControl par_itemAnchorPrior)
        //{
        //    _itemAnchorPrior = par_itemAnchorPrior;
        //    //_itemAnchorAfter = par_itemAnchorAfter;
        //    _itemAnchorAfter = null;
        //}


        public void EncloseRange(DLLRange<TControl> par_range)
        {
            //
            // Added 11/03/2024 
            //
            //  Let's set it up as follows...
            //
            //     _itemAnchorPrior, range's first, ..., range's last item, _itemAnchorAfter 
            //
            //    Or, going downward...
            //
            //     _itemAnchorPrior,
            //     range's first, ...,
            //     ...
            //     range's last item,
            //     _itemAnchorAfter 
            //
            par_range.ItemStart().DLL_SetItemPrior_OfT(_itemAnchorPrior, true);
            par_range.Item__End().DLL_SetItemNext_OfT(_itemAnchorAfter, true);

            _itemAnchorPrior?.DLL_SetItemNext_OfT(par_range.ItemStart());
            _itemAnchorAfter?.DLL_SetItemPrior_OfT(par_range.Item__End());

        }


        public TControl GetItemPrior()
        {
            // Added 11/12/2024 td
            return _itemAnchorPrior;
        }

        public TControl GetItemAfter()
        {
            // Added 11/12/2024 td
            return _itemAnchorAfter;
        }


        public string ToString()
        {
            //
            //  Added 11/10/2024 thomas d. 
            //
            string result_pair;

            result_pair = (_itemAnchorPrior == null ? "null" : 
                _itemAnchorPrior.ToString()) + " "
                + (_itemAnchorAfter == null ? "null" :
                _itemAnchorAfter.ToString());

            return result_pair; 

        }


    }
}
