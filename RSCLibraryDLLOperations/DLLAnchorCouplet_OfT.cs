using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    public class DLLAnchorCouplet<TControl>
          where TControl : IDoublyLinkedItem<TControl>
    {
        //
        //  Anchor Couplet 
        //
        private TControl? _itemAnchorPrior;
        private TControl? _itemAnchorAfter;

        public DLLAnchorCouplet(TControl par_itemAnchorPrior, TControl par_itemAnchorAfter)
        {
            _itemAnchorPrior = par_itemAnchorPrior;  // May be null.
            _itemAnchorAfter = par_itemAnchorAfter; // May be null.

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


        public DLLAnchor<TControl> GetAnchorItem()
        {
            DLLAnchor<TControl> result; 
            if (_itemAnchorPrior != null)
            {
                result = new DLLAnchor<TControl>(_itemAnchorPrior);
                result._doInsertRangeAfterThis = true;
            }
            else
            {
                result = new DLLAnchor<TControl>(_itemAnchorAfter);
                result._doInsertRangeBeforeThis = true;
            }
            return result;

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
            par_range.ItemStart().DLL_SetItemPrior_OfT(_itemAnchorPrior, true);
            par_range.Item__End().DLL_SetItemNext_OfT(_itemAnchorAfter, true);

            _itemAnchorPrior?.DLL_SetItemNext_OfT(par_range.ItemStart());
            _itemAnchorAfter?.DLL_SetItemPrior_OfT(par_range.Item__End());

        }


    }
}
