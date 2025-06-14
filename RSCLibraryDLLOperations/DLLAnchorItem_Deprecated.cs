﻿using ciBadgeInterfaces;
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
    //public struct StructureTypeOfMove // Added 12/11/2024 thomas c. downes
    //{
    //    public bool IsMoveType;  // = false;
    //    public bool IsMoveToAnchor;  // = true;
    //    public bool IsMoveIncrementalShift;  // "Swapping" positions with an adjacent item, especially if the range is a single item.
    //    public bool IsShiftingToLeft;  // "Swapping" positions with a preceding adjacent item, especially if the range is a single item.
    //    public bool IsShiftingToRight;  // "Swapping" positions with a succeeding adjacent item, especially if the range is a single item.
    //    public int HowManyItemsIncremental;  // How many items are swapped out, either preceding or succeeding. 
    //
    //    public StructureTypeOfMove()
    //    {
    //        //
    //        // It is likely that the Operations Manager will "know" that the Operation is a Move 
    //        //   operation, so we have IsMoveType equal to True by default.  ----12/11/2024
    //        //
    //        // Added 12/11/2024 thomas c. downes
    //        IsMoveType = true;
    //        IsMoveToAnchor = true;
    //        IsMoveIncrementalShift = false;
    //        HowManyItemsIncremental = 0;
    //    }
    //
    //    public StructureTypeOfMove(bool par_IsForMove)
    //    {
    //        //
    //        // It is likely that the Operations Manager will "know" that the Operation is a Move 
    //        //   operation, so we have IsMoveType equal to True by default.  ----12/11/2024
    //        //
    //        // Added 12/11/2024 thomas c. downes
    //        IsMoveType = par_IsForMove;
    //        IsMoveToAnchor = par_IsForMove;
    //        IsMoveIncrementalShift = false;
    //        HowManyItemsIncremental = 0;
    //    }
    //}


    /// <summary>
    /// This class is deprecated June 9, 2025 in favor of DLLAnchorCouplet.
    /// </summary>
    /// <typeparam name="TControl"></typeparam>
    public class DLLAnchorItem_Deprecated<TControl>
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


        public DLLAnchorItem_Deprecated(bool pbIsForEmptyList, bool pbIsForDeletionOp)
        {
            //
            // Added 10/20/2024 
            //
            _anchorItem = default(TControl);
            _isForEmptyList = pbIsForEmptyList;
            _isForDeletionOperation = pbIsForDeletionOp;
        }


        public DLLAnchorItem_Deprecated(TControl par_item)
        {
            //
            // Added 10/20/2024 
            //
            if (par_item == null) System.Diagnostics.Debugger.Break();
            _anchorItem = par_item;
            _isForEmptyList = false; // pbIsForEmptyList;
            _isForDeletionOperation = false; // pbIsForDeletionOp
        }


        public DLLAnchorItem_Deprecated<T_BaseOrParallel> GetConvertToGeneric_OfT<T_BaseOrParallel>(T_BaseOrParallel par_firstItem,
                        bool pbTargetListIsOfBaseClass,
                        bool pbTargetListIsParallel)
            where T_BaseOrParallel : class, IDoublyLinkedItem<T_BaseOrParallel>
        {
            //
            // Added 12/11/2024 
            //
            DLLAnchorItem_Deprecated<T_BaseOrParallel>? result;

            //Added 1/09/2025 thomas d.
            bool bAsExpected = (pbTargetListIsOfBaseClass == (_anchorItem is T_BaseOrParallel));
            if (!bAsExpected) System.Diagnostics.Debugger.Break();

            // 12/11/2024  T_Base? obj_item_Left = _itemLeft as T_Base;
            //             if (obj_item_Left != null)
            //
            // Fancy!!  Suggested by MS Visual Studio...
            //
            if (_anchorItem is T_BaseOrParallel itemAnchorTHeader) // We are declaring a new variable, itemAnchorTHeader.
            {
                //
                //  The type (THeaderOrParallel) is a base type (relative to TControl). 
                //
                //  For example, TwoCharacterDLLItem is a base type relative to TwoCharacterDLLHorizontal.
                //  For example, Control is a base type relative to RSCDataColumn.
                //
                result = new DLLAnchorItem_Deprecated<T_BaseOrParallel>(itemAnchorTHeader);
                result._isForEmptyList = _isForEmptyList;
                result._isForDeletionOperation = _isForDeletionOperation;
                result._doInsertRangeBeforeThis = _doInsertRangeBeforeThis;
                result._doInsertRangeAfterThis = _doInsertRangeAfterThis;
            }

            //else result = null;
            else if (pbTargetListIsParallel)
            {
                //
                // The type is NOT a base type.  Instead, the list is parallel to the primary list.
                //
                //  For example, a list of RSCDataCells is parallel to the list of RSCRowHeaders.
                //<>
                var itemAnchorTParallel = _anchorItem.GetConvertToGeneric_OfT<T_BaseOrParallel>(par_firstItem);
                result = new DLLAnchorItem_Deprecated<T_BaseOrParallel>(itemAnchorTParallel);
                result._isForEmptyList = _isForEmptyList;
                result._isForDeletionOperation = _isForDeletionOperation;
                result._doInsertRangeBeforeThis = _doInsertRangeBeforeThis;
                result._doInsertRangeAfterThis = _doInsertRangeAfterThis;
            }

            // Added 1/10/2025 thomas downes
            else
            {
                // Programmer needs to investigate this situation. ---01/10/2025 td
                System.Diagnostics.Debugger.Break(); 
                throw new Exception("One of the parameter Booleans must be True.");
            }

            return result;

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


        public bool IsEquivalent(DLLAnchorItem_Deprecated<TControl> par_anchor)
        {
            //
            // Added 12/24/2024 td  
            //
            bool bItemMatch = (_anchorItem == par_anchor._anchorItem);
            bool bInsertBeforeMatch = (_doInsertRangeBeforeThis == par_anchor._doInsertRangeBeforeThis);
            bool bInsertAfterMatch = (_doInsertRangeAfterThis == par_anchor._doInsertRangeAfterThis);
            return (bItemMatch && bInsertBeforeMatch && bInsertAfterMatch);

        }

        public bool Equals(DLLAnchorItem_Deprecated<TControl> par_anchor)
        {
            //
            // Added 12/24/2024 td  
            //
            return IsEquivalent(par_anchor);

        }


        public override string ToString() // Feb2025 public string ToString()
        {
            //
            //  Added 12/30/2024 thomas d. 
            //
            string result_string = "null";

            //  Modified 12/30/2024 thomas d. 
            if (_anchorItem != null)
            {
                //result_string = (_doInsertRangeBeforeThis ?
                //    ("__" + _anchorItem.ToString() + " ") :
                //    (_anchorItem.ToString() + "__ "));
                result_string = (_doInsertRangeBeforeThis ?
                    ("__" + _anchorItem.ToString(false) + " ") :
                    (_anchorItem.ToString(false) + "__ "));
            }

            return result_string;

        }


    }
}



