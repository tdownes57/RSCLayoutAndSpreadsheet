using ciBadgeInterfaces;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    public class DLLAnchorItem<TControl>
         where TControl : IDoublyLinkedItem<TControl>
    {
        /// <summary>
        /// This item will serve as an anchor (fixed point).
        /// The range of item(s) will be placed immediately BEFORE 
        /// or AFTER the anchor.
        /// </summary>
        public TControl? _anchorItem;

        /// <summary>
        /// Indicates that the range will be inserted BEFORE
        /// the anchor-item. 
        /// Ultimately, the anchor-item will FOLLOW 
        /// the inserted range. (Confusing!)
        /// </summary>
        public bool _doInsertRangeBeforeThis;

        /// <summary>
        /// Indicates that the range will be inserted AFTER
        /// the anchor-item. 
        /// Ultimately, the anchor-item will be located PRIOR 
        /// to the inserted range. (Confusing!)
        /// </summary>
        public bool _doInsertRangeAfterThis;

        /// <summary>
        /// For operations which are the (initial) load an empty list. 
        /// </summary>
        public bool _isForEmptyList;

        /// <summary>
        /// For operations which will delete items from a list. 
        /// </summary>
        public bool _isForDeletionOperation;


        public DLLAnchorItem(bool pbIsForEmptyList, bool pbIsForDeletionOp)
        {
            //
            // Added 10/20/2024 
            //
            _anchorItem = default(TControl);
            _isForEmptyList = pbIsForEmptyList;
            _isForDeletionOperation = pbIsForDeletionOp;
        }


        public DLLAnchorItem(TControl par_item)
        {
            //
            // Added 10/20/2024 
            //
            if (par_item == null) System.Diagnostics.Debugger.Break();
            _anchorItem = par_item;
            _isForEmptyList = false; // pbIsForEmptyList;
            _isForDeletionOperation = false; // pbIsForDeletionOp
        }


        public DLLAnchorCouplet<TControl> GetAnchorCouplet()
        {
            //
            // Added 11/08/2024 
            //
            DLLAnchorCouplet<TControl> resultCouplet; // = default(TControl);
 
            if (_doInsertRangeAfterThis)
            {
                resultCouplet = new DLLAnchorCouplet<TControl>(_anchorItem, _anchorItem.DLL_GetItemNext_OfT(), true);
                return resultCouplet;
            }
            else if (_doInsertRangeBeforeThis)
            {
                resultCouplet = new DLLAnchorCouplet<TControl>(_anchorItem.DLL_GetItemPrior_OfT(), _anchorItem, true);
                return resultCouplet;
            }
            else
            {
                System.Diagnostics.Debugger.Break();
                return null;
            }
            //return resultCouplet;

        }


        public DLLAnchorCouplet<TControl> GetAnchorCouplet(bool pbIncludePriorItem)
        {
            //
            // Added 11/08/2024 
            //
            DLLAnchorCouplet<TControl> resultCouplet; // = default(TControl);

            if (pbIncludePriorItem)
            {
                // Added 11/10/2024  
                resultCouplet = new DLLAnchorCouplet<TControl>(_anchorItem.DLL_GetItemPrior_OfT(), _anchorItem, true);
                return resultCouplet;
            }

            else if (_doInsertRangeAfterThis)
            {
                resultCouplet = new DLLAnchorCouplet<TControl>(_anchorItem, _anchorItem.DLL_GetItemNext_OfT(), true);
                return resultCouplet;
            }
            else if (_doInsertRangeBeforeThis)
            {
                resultCouplet = new DLLAnchorCouplet<TControl>(_anchorItem.DLL_GetItemPrior_OfT(), _anchorItem, true);
                return resultCouplet;
            }
            else
            {
                System.Diagnostics.Debugger.Break();
                return null;
            }
            //return resultCouplet;

        }




    }
}
