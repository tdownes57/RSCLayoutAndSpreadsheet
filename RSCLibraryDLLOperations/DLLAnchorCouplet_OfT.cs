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
          where TControl : class, IDoublyLinkedItem<TControl>
    {
        //
        //  Anchor Couplet 
        //
        private TControl? _itemLeft;
        private TControl? _itemRight;

        /// <summary>
        /// For operations which are the (initial) load an empty list. 
        /// </summary>
        public bool _isForEmptyList;

        /// <summary>
        /// For operations which will delete items from a list. 
        /// </summary>
        public bool _isForDeletionOperation;

        public DLLAnchorCouplet(TControl par_itemLeft, TControl par_itemRight)
        {
            _itemLeft = par_itemLeft;  // May be null.
            _itemRight = par_itemRight; // May be null.

        }


        public DLLAnchorCouplet(DLLAnchorItem<TControl> par_itemAnchor)
        {
            //
            // Added 11/10/2024  
            //
            bool bInsertRangeAfterAnchorItem;
            bool bIsForEmptyList;  // Added 12/09/2024

            bIsForEmptyList = par_itemAnchor._isForEmptyList;  // Added 12/09/2024

            bInsertRangeAfterAnchorItem = par_itemAnchor._doInsertRangeAfterThis;

            if (bIsForEmptyList) // Added 12/09/2024 
            {
                // Added 12/09/2024  
                _isForEmptyList = true;

            }

            else if (bInsertRangeAfterAnchorItem)
            {
                _itemLeft = par_itemAnchor._anchorItem;  // May be null.
                _itemRight = par_itemAnchor._anchorItem.DLL_GetItemNext_OfT();  // May be null.

            }
            else
            {
                _itemLeft = par_itemAnchor._anchorItem.DLL_GetItemPrior_OfT();  // May be null.
                _itemRight = par_itemAnchor._anchorItem;  // May be null.
            }

        }


        public DLLAnchorCouplet(TControl? par_itemLeft, TControl? par_itemRight, bool pbAllowNulls)
        {

            if (!pbAllowNulls && par_itemLeft == null) System.Diagnostics.Debugger.Break();
            else if (!pbAllowNulls && par_itemRight == null) System.Diagnostics.Debugger.Break();
            else
            {
                _itemLeft = par_itemLeft;  // May be null.
                _itemRight = par_itemRight; // May be null.
            }
        }


        public DLLAnchorCouplet(bool pbIsForEmptyList, bool pbIsForDeletionOp)
        {
            //
            // Added 10/20/2024 
            //
            _itemLeft = default(TControl);
            _itemRight = default(TControl);
            _isForEmptyList = pbIsForEmptyList;
            _isForDeletionOperation = pbIsForDeletionOp;
        }


        public DLLAnchorCouplet(TControl par_item, bool bRangeWillGoAfterItem)
        {
            //
            // Added 11/17/2024  
            //
            if (bRangeWillGoAfterItem)
            {
                _itemLeft = par_item; 
                _itemRight = par_item.DLL_GetItemNext_OfT(); // May be null.

            }
            else
            {
                _itemRight = par_item;
                _itemLeft = par_item.DLL_GetItemPrior_OfT(); // May be null.

            }
        }



        public DLLAnchorCouplet<T_Base> GetConvertToGeneric_OfT<T_Base>()
              where T_Base : class, IDoublyLinkedItem<T_Base>
        {
            //
            // Added 12/08/2024 
            //
            DLLAnchorCouplet<T_Base>? result;

            // 12/11/2024  T_Base? obj_item_Left = _itemLeft as T_Base;
            //             if (obj_item_Left != null)
            //
            // Fancy!!  Suggested by MS Visual Studio...
            //
            if (_itemLeft is T_Base obj_item_Left)
            {
                result = new DLLAnchorCouplet<T_Base>(obj_item_Left, _itemRight as T_Base, true);
                result._isForEmptyList = _isForEmptyList;
                result._isForDeletionOperation = _isForDeletionOperation;
            }
            else result = null;

            return result;

        }


        public DLLAnchorItem<TControl> GetAnchorItem()
        {
            DLLAnchorItem<TControl> result; 
            if (_itemLeft != null)
            {
                result = new DLLAnchorItem<TControl>(_itemLeft);
                result._doInsertRangeAfterThis = true;
            }
            else if (_itemRight != null)
            {
                result = new DLLAnchorItem<TControl>(_itemRight);
                result._doInsertRangeBeforeThis = true;
            }
            else
            {
                // Added 11/11/2024 
                result = new DLLAnchorItem<TControl>(true, true);
            }
            return result;

        }


        public bool ContainsEndpoint()
        {
            //
            //Added 11/17/2024  
            //
            return (ItemLefthandIsNull() || ItemRighthandIsNull() ||
                      _itemLeft == null ||
                      _itemRight == null);

        }


        /// <summary>
        /// This checks the null value of the "Left" (or prior) item.
        /// After an operation upon a range, this item will hopefully 
        /// be immediately prior (left) of the range. 
        /// </summary>
        /// <returns></returns>
        public bool ItemLefthandIsNull()
        {
            //Added 11/8/2024  

            return _itemLeft == null;
        }


        /// <summary>
        /// This checks the null value of the "Right" (or afterward) item.
        /// After an operation upon a range, this item will hopefully 
        /// be immediately after/following (right) of the range. 
        /// </summary>
        /// <returns></returns>
        public bool ItemRighthandIsNull()
        {
            //Added 11/8/2024  
            return _itemRight == null;
        }


        /// <summary>
        /// This checks the non-null value of the "Left" (or prior) item.
        /// After an operation upon a range, this item will hopefully 
        /// be immediately prior (left) of the range. 
        /// </summary>
        /// <returns></returns>
        public bool ItemFirstIsPresent()
        {
            //Added 11/8/2024  

            return _itemLeft != null;
        }

        /// <summary>
        /// This checks the non-null value of the "Righthand" (or following) item.
        /// After an operation upon a range, this item will hopefully 
        /// be immediately after (right) of the range. 
        /// </summary>
        /// <returns></returns>
        public bool ItemSecondIsPresent()
        {
            //Added 11/8/2024  

            return _itemRight != null;
        }


        //public DLLAnchorCouplet(TControl par_itemLeft)
        //{
        //    _itemLeft = par_itemLeft;
        //    //_itemRight = par_itemRight;
        //    _itemRight = null;
        //}


        public void EncloseRange(DLLRange<TControl> par_range)
        {
            //
            // Added 11/03/2024 
            //
            //  Let's set it up as follows...
            //
            //     _itemLeft, range's first, ..., range's last item, _itemRight 
            //
            //    Or, going downward...
            //
            //     _itemLeft,
            //     range's first, ...,
            //     ...
            //     range's last item,
            //     _itemRight 
            //
            par_range.ItemStart().DLL_SetItemPrior_OfT(_itemLeft, true);
            par_range.Item__End().DLL_SetItemNext_OfT(_itemRight, true);

            _itemLeft?.DLL_SetItemNext_OfT(par_range.ItemStart());
            _itemRight?.DLL_SetItemPrior_OfT(par_range.Item__End());

        }

        
        /// <summary>
        /// Returns the first item of the couplet/par.  Technically speaking, the item whose 
        /// function DLL_SetItemAfter() may be called in the course of implementing the relevant 
        /// operation.  Previously named "GetItemPrior()", but confusing. 
        /// </summary>
        /// <returns>The first(1st) of two(2) TControl items.</returns>
        public TControl? GetItemLeftOrFirst()
        {
            // Added 11/12/2024 td
            return _itemLeft;
        }

        /// <summary>
        /// Returns the second item of the couplet/par.  Technically speaking, the item whose 
        /// function DLL_SetItemAfter() may be called in the course of implementing the relevant 
        /// operation.  Previously named "GetItemAfter()", but confusing. 
        /// </summary>
        /// <returns>The second(2nd) of two(2) TControl items.</returns>
        public TControl? GetItemRightOrSecond()
        {
            // Added 11/12/2024 td
            return _itemRight;
        }


        public string ToString()
        {
            //
            //  Added 11/10/2024 thomas d. 
            //
            string result_pair;

            result_pair = (_itemLeft == null ? "null" : 
                _itemLeft.ToString()) + " "
                + (_itemRight == null ? "null" :
                _itemRight.ToString());

            return result_pair; 

        }


        public bool IsEquivalent(DLLAnchorCouplet<TControl> par_anchor)
        {
            //
            // Added 12/24/2024 td  
            //
            bool bLeft = (_itemLeft == par_anchor._itemLeft);
            bool bRight = (_itemRight == par_anchor._itemRight);
            bool bBoolean1 = (_isForEmptyList == par_anchor._isForEmptyList);
            bool bBoolean2 = (_isForDeletionOperation == par_anchor._isForDeletionOperation);

            bool bResult_All = (bLeft && bRight && bBoolean1 && bBoolean2);
            return bResult_All;

        }


        public bool Equals(DLLAnchorCouplet<TControl> par_anchor)
        {
            //
            // Added 12/24/2024 td  
            //
            return IsEquivalent(par_anchor);

        }



    }
}
