using ciBadgeInterfaces;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{

    //
    // Added 12/11/2024 thomas c. downes
    //
    public struct StructureTypeOfMove // Added 12/11/2024 thomas c. downes
    {
        public bool IsMoveType;  // = false;
        public bool IsMoveToAnchor;  // = true;
        public bool IsMoveIncremental;  // "Swapping" positions with an adjacent item, especially if the range is a single item.
        public bool IsIncrementalToLeft;  // "Swapping" positions with a preceding adjacent item, especially if the range is a single item.
        public bool IsIncrementalToRight;  // "Swapping" positions with a succeeding adjacent item, especially if the range is a single item.
        public int HowManyItemsIncremental;  // How many items are swapped out, either preceding or succeeding. 

        public StructureTypeOfMove()
        {
            //
            // It is likely that the Operations Manager will "know" that the Operation is a Move 
            //   operation, so we have IsMoveType equal to True by default.  ----12/11/2024
            //
            // Added 12/11/2024 thomas c. downes
            IsMoveType = true;
            IsMoveToAnchor = true;
            IsMoveIncremental = false;
            HowManyItemsIncremental = 0;
        }

        public StructureTypeOfMove(bool par_IsForMove)
        {
            //
            // It is likely that the Operations Manager will "know" that the Operation is a Move 
            //   operation, so we have IsMoveType equal to True by default.  ----12/11/2024
            //
            // Added 12/11/2024 thomas c. downes
            IsMoveType = par_IsForMove;
            IsMoveToAnchor = par_IsForMove;
            IsMoveIncremental = false;
            HowManyItemsIncremental = 0;
        }


    }


    public class DLLAnchorItem<TControl>
         where TControl : class, IDoublyLinkedItem<TControl>
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
            // where TControlOut : class, IDoublyLinkedItem<TControlOut>
        {
            //
            // Added 11/08/2024 
            //
            DLLAnchorCouplet<TControl> resultCouplet; // = default(TControl);
 
            if (_isForEmptyList)  // Added 12/09/2024 t..d..
            {
                // Added 12/09/2024 t..d..
                resultCouplet = new DLLAnchorCouplet<TControl>(_isForEmptyList, false);

            }

            else if (_isForDeletionOperation)  // Added 12/09/2024 t..d..
            {
                // Added 12/09/2024 t..d..
                resultCouplet = new DLLAnchorCouplet<TControl>(false, _isForDeletionOperation);

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
            
            return resultCouplet;

        }


        public DLLAnchorCouplet<TControl> GetAnchorCouplet(bool pbIncludePriorItem)
           // where TControl : class, IDoublyLinkedItem<TControl>
        {
            //
            // Added 11/08/2024 
            //
            DLLAnchorCouplet<TControl> resultCouplet; // = default(TControl);

            if (_isForEmptyList)  // Added 12/09/2024 t..d..
            {
                // Added 12/09/2024 t..d..
                resultCouplet = new DLLAnchorCouplet<TControl>(_isForEmptyList, false);

            }

            else if (_isForDeletionOperation)  // Added 12/09/2024 t..d..
            {
                // Added 12/09/2024 t..d..
                resultCouplet = new DLLAnchorCouplet<TControl>(false, _isForDeletionOperation);

            }

            else if (pbIncludePriorItem)
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
            
            return resultCouplet;

        }




    }
}
