//using System;
//using System.Collections.Generic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;



//using System.Reflection.Metadata.Ecma335;
using ciBadgeInterfaces; //Added 6/20/2024
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{

    //
    // Added 10/12/2024 Thomas C. Downes
    //
    //    1D = 1 dimension, simply a list
    //            (versus a 2-dimensional grid)
    //

    public partial class DLLOperation1D<TControl> : DLLOperationBase // :IDoublyLinkedItem
        where TControl : class, IDoublyLinkedItem<TControl>
    {
        //''
        //''Added 4/17/2024 td
        //
        //    1D = 1 dimension, simply a list
        //            (versus a 2-dimensional grid)
        //
        //''
        private readonly bool _isHoriz;
        private readonly bool _isVerti;

        private readonly bool _isForStartOfList;
        private readonly bool _isForEndOfList;
        private readonly bool _isForAnchor;

        private readonly bool _isInsert;
        private readonly bool _isDelete;
        private readonly bool _isMove;
        private readonly StructureTypeOfMove _moveType;  // Added 12/11/2024 t_homas c. d_ownes

        private readonly bool _isSort_Ascending;
        private readonly bool _isSort_Descending;
        private readonly bool _isSort_UndoOfSortEither; //Added 4/18/2024 
        private readonly bool _isSort_UndoOfSortAscending; //Added 4/18/2024 
        private readonly bool _isSort_UndoOfSortDescending; //Added 4/18/2024 

        private readonly bool _isForUndoOperation;  //Added 5/22/2024

        // Added 4/21/2024 td
        private readonly DLLAnchorItem<TControl>? _anchorItem;

        // Added 11/03/2024 td
        //   An Anchor Couplet is a pair of Anchoring Items, which bookend a range
        //   (or more accurately WILL bookend a range). 
        private readonly DLLAnchorCouplet<TControl>? _anchorCouplet;

        //Added 4/18/2024 td 
        private readonly DLLAnchorItem<TControl>? _inverseAnchorItem_ForUndo;
        private readonly DLLAnchorCouplet<TControl>? _inverseAnchorPair_forUndo;

        private readonly DLLRange<TControl>? _range;

        private DLLOperation1D<TControl>? mod_opPrior_ForUndo_OfT;
        private DLLOperation1D<TControl>? mod_opNext_ForRedo_OfT;


        /// <summary>
        /// Ind icate whether the ENDPOINTS (outward-facing item references 
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
            if (_isSort_Ascending) return 'S';
            if (_isSort_Descending) return 'S';
            return ' ';

        }

        public bool IsHorizontal() { return _isHoriz; }
        public bool IsVertical() { return _isVerti; }

        public bool HasAnchor()
        {
            // Added 6/10/2024
            //-----return (_anchor_H != null || _anchor_H != null);
            return (_anchorItem != null);
        }


        public bool IsAnchorToPrecedeItemOrRange()
        {
            //
            // Added 6/10/2024 thomas downes
            //
            //----BACKWARDS AND CONFUSING----------------------------
            //if (_anchorItem_H != null && _isHoriz) return _anchorItem_H._doInsertRangeAfterThis;
            //if (_anchorItem_V != null && _isVerti) return _anchorItem_V._doInsertRangeAfterThis;
            if (_anchorItem != null) return _anchorItem._doInsertRangeAfterThis;
            throw new InvalidOperationException();

        }


        public bool IsAnchorToSucceedItemOrRange()
        {
            //
            // Added 6/10/2024 thomas downes
            //
            //----BACKWARDS AND CONFUSING----------------------------
            //if (_anchorItem_H != null && _isHoriz) return _anchorItem_H._doInsertRangeBeforeThis;
            //if (_anchorItem_V != null && _isVerti) return _anchorItem_V._doInsertRangeBeforeThis;
            if (_anchorItem != null) return _anchorItem._doInsertRangeBeforeThis;
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
        /// <param name="par_anchorItem"></param>
        /// <param name="par_isSortAscending"></param>
        /// <param name="par_isSortDescending"></param>
        /// <param name="par_isSortReversal"></param>
        public DLLOperation1D(DLLRange<TControl>? par_range,
                  bool par_forStartOfList, bool par_forEndOfList,
                  bool par_isInsert, bool par_isDelete, bool par_isMove,
                  StructureTypeOfMove par_structMoveType,
                  DLLAnchorItem<TControl>? par_anchorItem,
                  DLLAnchorCouplet<TControl>? par_anchorPair,
                  bool par_isSortAscending,
                  bool par_isSortDescending,
                  bool par_isUndoOfSortAscending,
                  bool par_isUndoOfSortDescending)
        {
            //
            // Added 10/12/2024 thomas downes
            //

            //---_isHoriz = true;
            _range = par_range;
            _anchorItem = par_anchorItem;
            _anchorCouplet = par_anchorPair;  //Added 11/08/2024 
            //---_isVerti = false; // NOT vertical.

            _isForStartOfList = par_forStartOfList;
            _isForEndOfList = par_forEndOfList;
            _isInsert = par_isInsert;
            _isDelete = par_isDelete;
            _isMove = par_isMove;
            _isSort_Ascending = par_isSortAscending;
            _isSort_Descending = par_isSortDescending;

            //Added 4/18/2024 
            //_isSort_UndoOfSort = par_isSortReversal; // Undoing a sorting operation.
            _isSort_UndoOfSortEither = (par_isUndoOfSortAscending ||
                                   par_isUndoOfSortDescending); // Undoing a sorting operation.
            //Added 12/24/2024 
            _isSort_UndoOfSortAscending = par_isUndoOfSortAscending;
            _isSort_UndoOfSortDescending = par_isUndoOfSortDescending;

            //
            //  Preparing for UNDO... Determining an Anchor for a future UNDO operation.
            //
            //Think about undoing... an INSERT (hence, it's a DELETE)
            if (_isInsert) _inverseAnchorItem_ForUndo = null; // par_range. // Deletes don't need an anchor! 
            //if (_isDelete && _isForStartOfList)
            //{
            //    //TControl_H item_afterRange = _range_H._itemEnding.DLL_GetItemNext();
            //    //_inverseAnchorItem_ForUndo_H = new DLLAnchor<>(item_afterRange); 
            //}
            //else if (_isDelete && _isForEndOfList)
            //{
            //    //TControl_H item_afterRange = _range_H._itemStart.DLL_GetItemPrior();
            //    //_inverseAnchorItem_ForUndo_H = new DLLAnchor<>(item_afterRange);
            //}

            // 12/9/2024  if (_isDelete)
            if (_isDelete || _isMove) // Both Deletions & Moves need the Inverse Anchor.--12/9/2024  // 12/9/2024  if (_isDelete)
            {
                _inverseAnchorPair_forUndo = par_range.GetCoupletWhichEncloses_InverseAnchor();
                //_anchorCouplet.GetAnchorItem();
            } // end of ""if (_isDelete || _isMove)"" 

            //
            // Added 12/09/2024  
            //
            if (_range?._ItemCountOfRange == 1)
            {
                if (_range._isSingleItem == false)
                {
                    //
                    // Fix the _isSingleItem status, it is incorrect. 
                    //
                    _range._isSingleItem = true;
                    _range._SingleItemInRange = _range._StartingItemOfRange;

                    TControl tempEnding = _range._EndingItemOfRange;
                    bool bMatchesStart = (tempEnding == _range._SingleItemInRange);
                    if (bMatchesStart == false) System.Diagnostics.Debugger.Break();

                }
            }

            //
            // Added 12/19/2024 Thomas Downes 
            //
            _moveType = par_structMoveType;


        }


        public DLLOperation1D(DLLRange<TControl> par_range,
                              DLLAnchorCouplet<TControl> par_anchorCouplet,
                              bool par_isInsert, bool par_isMove,
                              StructureTypeOfMove par_typeOfMove)
        {
            //
            // Added 11/3/2024 
            //
            _range = par_range;
            _isDelete = false;
            _isMove = par_isMove;
            _isInsert = par_isInsert;
            _anchorCouplet = par_anchorCouplet;

            // Added 12/11/2024 td
            _moveType = par_typeOfMove;

            // Added 12/09/2024  
            //
            if (_isDelete || _isMove) // Both Deletions & Moves need the Inverse Anchor.--12/9/2024  // 12/9/2024  if (_isDelete)
            {
                _inverseAnchorPair_forUndo = par_range.GetCoupletWhichEncloses_InverseAnchor();
                //_anchorCouplet.GetAnchorItem();
            } // end of ""if (_isDelete || _isMove)"" 

        }


        public DLLOperation1D(EnumSortTypes par_enum)
        {
            //
            // Added 12/20/2024 
            //
            if (par_enum == EnumSortTypes.Forward) _isSort_Ascending = true;
            if (par_enum == EnumSortTypes.Backward) _isSort_Descending = true;

        }


        public void ExecuteOnList(DLLList<TControl> par_list, out bool pbChangeOfEndpoint_Occurred)
        {
            //
            // Added 4/17/2024
            //
            // This is an "alias" method, added in case the programmer(s) gets forgetful 
            //  about the name. 
            //
            OperateOnList(par_list, out pbChangeOfEndpoint_Occurred);

        }

        public void OperateOnList(DLLList<TControl> par_list, out bool pbChangeOfEndpoint_Occurred)
        {
            //
            // Added 4/17/2024
            //
            //   This is a sort of "inversion of control" procedure.
            //   Instead of the list accepting an operation, the 
            //   operation is given the list & operates upon the 
            //   given list. 
            //
            const bool ENDPOINT_PROTECTION = true; // Added 12/16/2024  
            bool bChangeOfEndpoint_Expected = true;   // Added 12/16/2024 
            TControl tempStart = par_list._itemStart;
            TControl temp__End = par_list._itemEnding;

            if (_isSort_Ascending)
            {
                //
                // Sort - Ascending
                //
                par_list.DLL_SortItems(_isSort_Ascending, false);
                //pbChangeOfEndpoint_Occurred = false; // true;
                pbChangeOfEndpoint_Occurred = par_list.HasChangeOfEndPoint(tempStart, temp__End);

            }
            if (_isSort_Descending)
            {
                //
                // Sort - Ascending
                //
                par_list.DLL_SortItems(false, _isSort_Descending);
                //pbChangeOfEndpoint_Occurred = false; // true; 
                pbChangeOfEndpoint_Occurred = par_list.HasChangeOfEndPoint(tempStart, temp__End);

            }
            else
            {
                // Nov. 8, 2024 //OperateOnList<TControl>(par_list, _range, _anchorItem, false);
                // Dec. 16, 2024 //OperateOnList(par_list, _range, _anchorItem, _anchorCouplet, false, false);

                //
                // Major call!!
                //
                OperateOnList_Private(par_list, _range, _anchorItem, _anchorCouplet, 
                    ENDPOINT_PROTECTION, bChangeOfEndpoint_Expected, 
                    out pbChangeOfEndpoint_Occurred);

            }

            //
            // Added 12/16/2024 
            //
            pbChangeOfEndpoint_Occurred = par_list.HasChangeOfEndPoint(tempStart, temp__End);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="par_list"></param>
        /// <param name="par_doProtectEndpoints">If True, we will throw Exceptions when the Endpoint is impacted, unless the next Boolean parameter is True.</param>
        /// <param name="pbIsChangeOfEndpoint">Prevents exceptions from being raised when an endpoint is changed.</param>
        public void OperateOnList(DLLList<TControl> par_list,
                             bool par_doProtectEndpoints,
                             bool pbIsChangeOfEndpoint,
                             out bool pbChangeOfEndpoint_Occurred)
        {
            //
            // Added 6/10/2024
            //
            //----bool bChangeOfEndpointOccurred = false;

            if (_isSort_Ascending)
            {
                // Ascending Sort
                par_list.DLL_SortItems(_isSort_Ascending, false);
                pbChangeOfEndpoint_Occurred = true;
            }
            else if (_isSort_Descending)
            {
                // Descending Sort  
                const bool DESCENDING = true;
                par_list.DLL_SortItems(false, DESCENDING);
                pbChangeOfEndpoint_Occurred = true;
            }
            else if (_isSort_UndoOfSortEither || _isSort_UndoOfSortAscending || _isSort_UndoOfSortDescending)
            {
                // Added 12/29/2024 td 
                //
                par_list.DLL_UndoSort();
                pbChangeOfEndpoint_Occurred = true;
            }
            else
            {
                // OperateOnList<TControl_H>(par_list, _range_H, _anchorItem_H);
                OperateOnList_Private(par_list, _range, _anchorItem,
                    _anchorCouplet,
                    par_doProtectEndpoints, 
                    pbIsChangeOfEndpoint, 
                    out pbChangeOfEndpoint_Occurred, 
                    Testing.AreWeTesting);
            }

        }


        public void OperateOnList(DLLList<TControl> par_list,
                             bool par_doProtectEndpoints,
                             bool pbIsChangeOfEndpoint_Expected,
                             out bool pbChangeOfEndpoint_Occurred,
                             bool pbRunOtherChecks = false)
        {
            //
            // Added 4/17/2024
            //
            if (_isSort_Ascending)
            {
                // Ascending Sort
                par_list.DLL_SortItems(_isSort_Ascending,false);
                pbChangeOfEndpoint_Occurred = true;
            }
            if (_isSort_Descending)
            {
                // Descending Sort  
                const bool DESCENDING = true;
                par_list.DLL_SortItems(false, DESCENDING);
                pbChangeOfEndpoint_Occurred = true;
            }
            else
            {
                //
                //   Let's leverage a private singly-generic method (Of TControl),
                //   to obey the DRY principle inside a doubly-generic class 
                //   (Of TControl_H, TControl_V). 
                //  
                OperateOnList_Private(par_list, _range, _anchorItem, _anchorCouplet,
                      par_doProtectEndpoints, 
                      pbIsChangeOfEndpoint_Expected, 
                      out pbChangeOfEndpoint_Occurred,
                      pbRunOtherChecks);

                // Added 12/23/2024
                // 
                //    Is the list now newly empty?  
                //    Or, having just been empty, is the list now filled with at 
                //     least one(1) new item?   ---Thom. Dow.
                //
                bool bNoItemsInList = (0 >= par_list._itemCount);
                par_list._isEmpty_OrTreatAsEmpty = bNoItemsInList;

            }

        }


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="TControl"></typeparam>
        ///// <param name="par_list"></param>
        ///// <param name="par_range"></param>
        ///// <param name="par_anchorItem"></param>
        ///// <param name="pbEndpointProtection">If True, we will throw Exceptions when the Endpoint is impacted, unless the next Boolean parameter is True.</param>
        ///// <param name="pbIsChangeOfEndpoint">Prevents exceptions from being raised when an endpoint is changed.</param>
        //private void OperateOnList_Private(DLLList<TControl> par_list_administrative,
        //                             DLLRange<TControl> par_range,
        //                             DLLAnchorItem<TControl>? par_anchorItem,
        //                             DLLAnchorCouplet<TControl>? par_anchorPair,
        //                             bool pbEndpointProtection,
        //                             bool pbIsChangeOfEndpoint_Expected,
        //                             out bool pbChangeOfEndpoint_Occurred,
        //                             bool pbRunOtherChecks = false)
        //// where TControl : IDoublyLinkedItem<TControl>
        //{
        //    //
        //    // Added 4/17/2024
        //    //
        //    //   This is a private singly-generic method (Of TControl),
        //    //   to obey the DRY principle inside a doubly-generic class 
        //    //   (Of TControl_H, TControl_V). 
        //    //  
        //    pbChangeOfEndpoint_Occurred = false; //Default.  12/15/2024
        //    TControl tempListStart = par_list_administrative._itemStart;   // Added 12/17/2024 
        //    TControl tempListEnding = par_list_administrative._itemEnding;  // Added 12/17/2024 

        //    if (_isInsert)
        //    {
        //        //
        //        // Insert 
        //        //
        //        OperateOnList_Insert(par_list_administrative, par_range,
        //                             par_anchorItem, par_anchorPair,
        //                             pbEndpointProtection,
        //                             pbIsChangeOfEndpoint_Expected, 
        //                             pbRunOtherChecks);

        //        // Tempoarary, as of 12/15/2024 
        //        pbChangeOfEndpoint_Occurred = pbIsChangeOfEndpoint_Expected;

        //    }
        //    else if (_isDelete)
        //    {
        //        //
        //        // Delete
        //        //
        //        OperateOnList_Delete(par_list_administrative, par_range,
        //                             pbEndpointProtection,
        //                             pbIsChangeOfEndpoint_Expected, 
        //                             pbRunOtherChecks);

        //        // Tempoarary, as of 12/15/2024 
        //        pbChangeOfEndpoint_Occurred = pbIsChangeOfEndpoint_Expected;

        //    }
        //    else if (_isMove)
        //    {
        //        //
        //        // Encapsulated 11/18/2024  
        //        //
        //        //OperateOnList_Delete(par_list, par_range,
        //        //                     pbEndpointProtection,
        //        //                     pbIsChangeOfEndpoint);
        //        //OperateOnList_Insert(par_list, par_range,
        //        //                     par_anchorItem, par_anchorPair,
        //        //                     pbEndpointProtection,
        //        //                     pbIsChangeOfEndpoint, pbRunOtherChecks);

        //        // Encapsulated 11/18/2024
        //        // 
        //        // Move
        //        //
        //        OperateOnList_Move(par_list_administrative, par_range, 
        //                             this._moveType, par_anchorItem, par_anchorPair, 
        //                             pbEndpointProtection,
        //                             pbIsChangeOfEndpoint_Expected,
        //                             out pbChangeOfEndpoint_Occurred,
        //                             pbRunOtherChecks);

        //    }

        //    //
        //    // Added 12/17/2024 td
        //    //
        //    pbChangeOfEndpoint_Occurred = par_list_administrative
        //        .HasChangeOfEndPoint(tempListStart, tempListEnding);


        //}


        ///// <summary>
        ///// Perform an insert operation, either for TControl_H or TControl_V.
        ///// If appropriate, we perform some sanity testing prior to the operation.
        ///// </summary>
        ///// <typeparam name="TControl"></typeparam>
        ///// <param name="par_list_NotReallyNeeded">This parameter provides a sanity check (debugging).</param>
        ///// <param name="par_range">This is the range of items which are being placed into the list.</param>
        ///// <param name="par_anchorItem">This is a simple wrapper for the item which provides the location for the insert operation.</param>
        //private void OperateOnList_Insert(DLLList<TControl> par_list_administrative,
        //                                     DLLRange<TControl> par_range,
        //                                     DLLAnchorItem<TControl>? par_anchorItem,
        //                                     DLLAnchorCouplet<TControl>? par_anchorPair,
        //                             bool pbEndpointProtection,
        //                             bool pbIsChangeOfEndpoint = false,
        //                             bool pbRunOtherChecks = false)
        //// where TControl : IDoublyLinkedItem<TControl>
        //{
        //    //
        //    // Added 12/17/2024 
        //    //
        //    //TControl tempListStart = par_list_administrative._itemStart;   // Added 12/17/2024 
        //    //TControl tempListEnding = par_list_administrative._itemEnding;  // Added 12/17/2024 

        //    //
        //    // Added 4/17/2024
        //    //
        //    //   This is a private singly-generic method (Of TControl),
        //    //   to obey the DRY principle inside a doubly-generic class 
        //    //   (Of TControl_H, TControl_V). 
        //    //  
        //    // Insertion operation
        //    //
        //    //        //bool bAnchorIsFirstItem;
        //    //        //bool bAnchorIsLastItem;
        //    //        //
        //    //        //bAnchorIsFirstItem = (par_anchorItem._anchorItem.Equals(
        //    //        //               par_list_MaybeNotNeeded._itemStart));
        //    //        //bAnchorIsLastItem = (par_anchorItem._anchorItem.Equals(
        //    //        //                           par_list_MaybeNotNeeded._itemEnding));

        //    if (par_anchorPair != null)
        //    {
        //        //
        //        // Encapsulated 11/10/2024
        //        //
        //        //   We will use par_anchorPair (DLLAnchorCouplet) to determine
        //        //   where to place the Range.
        //        //
        //        Operate_Insert_ByCouplet(par_list_administrative,
        //                                  par_range, par_anchorPair,
        //                                  pbIsChangeOfEndpoint);
        //    }

        //    else if (par_anchorItem != null)
        //    {
        //        //
        //        // Encapsulated 11/10/2024
        //        //
        //        //   We will use par_anchorItem (DLLAnchorItem) to determine
        //        //   where to place the Range.
        //        //
        //        Operate_Insert_ByAnchorItem(par_list_administrative,
        //                                  par_range, par_anchorItem,
        //                                  pbIsChangeOfEndpoint);

        //    }

        //    // Added 12/17/2024 td
        //    //pbIsChangeOfEndpoint = par_list_administrative
        //    //    .HasChangeOfEndPoint(tempListStart, tempListEnding);

        //    //
        //    // End of Insertion operation.  
        //    //
        //}


        //private void Operate_Insert_ByCouplet(DLLList<TControl> par_list_NeededForAdmin,
        //                     DLLRange<TControl> par_range,
        //                     DLLAnchorCouplet<TControl>? par_anchorPair,
        //             bool pbIsChangeOfEndpoint)
        //{
        //    //
        //    // Added 11/08/2024 thomas downes
        //    //
        //    //   An AnchorCouplet is called "AnchorPair" for short. 
        //    //
        //    bool bListWillChange_ItemStart = par_anchorPair.ItemLefthandIsNull(); // Added 11/10
        //    bool bListWillChange_ItemFinal = par_anchorPair.ItemRighthandIsNull(); // Added 11/10

        //    //
        //    // Major call!!  This is the main insertion work!!!
        //    //
        //    par_anchorPair.EncloseRange(par_range);

        //    //
        //    // Admin Work !!
        //    //
        //    // Added 11/10/2024 td
        //    par_list_NeededForAdmin._itemCount += par_range._ItemCountOfRange;

        //    //
        //    // Endpoint work. DIFFICULT AND CONFUSING
        //    //
        //    if (par_list_NeededForAdmin._isEmpty_OrTreatAsEmpty)
        //    {
        //        // Added 11/11/2024 td
        //        if (par_range._ItemCountOfRange > 0)
        //        {
        //            par_list_NeededForAdmin._itemStart = par_range.ItemStart();
        //            par_list_NeededForAdmin._itemEnding = par_range.Item__End();
        //            par_list_NeededForAdmin._itemCount = par_range._ItemCountOfRange;
        //            par_list_NeededForAdmin._isEmpty_OrTreatAsEmpty = false;

        //        }

        //    }
        //    else if (bListWillChange_ItemStart) // (par_anchorPair.ItemPriorIsNull())
        //    {
        //        par_list_NeededForAdmin._itemStart = par_range._StartingItemOfRange;

        //    }
        //    else if (bListWillChange_ItemFinal) // (par_anchorPair.ItemAfterIsNull())
        //    {
        //        par_list_NeededForAdmin._itemEnding = par_range._EndingItemOfRange;

        //    }

        //}



        //private void Operate_Insert_ByAnchorItem(DLLList<TControl> par_list_NotReallyNeeded,
        //                             DLLRange<TControl> par_range,
        //                             DLLAnchorItem<TControl>? par_anchorItem,
        //                     bool pbIsChangeOfEndpoint)
        //{

        //    // November 8, 2024 //if (par_anchorItem == null)
        //    if (par_anchorItem == null) // && par_anchorPair == null)
        //    {
        //        //
        //        // Option #1 of 3...  
        //        //
        //        //    The list is empty (and therefore not any anchoring-item  
        //        //    included, i.e. the anchor is NULL,
        //        //    as it is irrelevant (or possible)).
        //        //
        //        if (par_list_NotReallyNeeded._isEmpty_OrTreatAsEmpty)
        //        {
        //            //List is currently empty, or should be treated as such
        //            //   because user has chosen to delete all of the items.
        //            //Set the list to contain ALL & ONLY items in the range.
        //            //   ---4/30/2024 td
        //            par_list_NotReallyNeeded._itemStart = par_range._StartingItemOfRange;
        //            par_list_NotReallyNeeded._itemEnding = par_range._EndingItemOfRange;
        //            par_list_NotReallyNeeded._isEmpty_OrTreatAsEmpty = false;
        //            par_list_NotReallyNeeded._itemCount = par_range._ItemCountOfRange;

        //        }
        //        else
        //        {
        //            // Debugging is needed.
        //            Debugger.Break();
        //        }

        //    }


        //    //if (par_anchorItem != null && _willInsertRange_AfterAnchor)
        //    else if (par_anchorItem != null && par_anchorItem._doInsertRangeAfterThis)
        //    {
        //        //
        //        // Option #2 of 3...  
        //        //
        //        // Insert the range AFTER (FOLLOWING) the anchoring item. 
        //        //
        //        TControl? itemOriginallyAfterAnchor = default(TControl);
        //        bool bAnchorHasItemAfter;
        //        bAnchorHasItemAfter = par_anchorItem._anchorItem.DLL_HasNext();

        //        if (par_anchorItem._anchorItem.DLL_HasNext())
        //        {
        //            //
        //            // #2a of 3. 
        //            //
        //            // Get the item AFTER the anchor; and also "unbox" it,
        //            //   i.e. get the TControl object (vs. an interface).
        //            itemOriginallyAfterAnchor = par_anchorItem._anchorItem
        //                .DLL_GetItemNext_OfT(); // .DLL_UnboxControl_OfT()

        //            if (Testing.AreWeTesting)
        //            {
        //                // Let's test two(2) things...
        //                //
        //                //   1) The anchor is in the list. 
        //                //   2) The operation has already taken place, or is superfluous (not needed).
        //                //
        //                bool bListHasAnchor = par_list_NotReallyNeeded.Contains(par_anchorItem._anchorItem);
        //                if (false == bListHasAnchor)
        //                {
        //                    // Surprising situation. Some debugging ought to be performed. 
        //                    Debugger.Break();
        //                }
        //                // Has the operation already taken place?  Is it not needed? 
        //                //    (If so, some debugging should be performed.)
        //                if (bAnchorHasItemAfter)
        //                {
        //                    bool bInsertIsAlreadyDone = itemOriginallyAfterAnchor.Equals(par_range._StartingItemOfRange);
        //                    if (bInsertIsAlreadyDone) System.Diagnostics.Debugger.Break();
        //                    if (bInsertIsAlreadyDone) return; // Don't repeat an unneeded operation.
        //                }
        //                else
        //                {
        //                    //Confirm that the anchor is at the end of the list. 
        //                    bool bAnchor_Is_EndOfList;
        //                    bAnchor_Is_EndOfList = (par_anchorItem._anchorItem.Equals(par_list_NotReallyNeeded._itemEnding));
        //                    if (false == bAnchor_Is_EndOfList) Debugger.Break();
        //                }

        //            }

        //            //Perform the operation !!
        //            //   ---par_anchor.DLL_SetItemNext(par_list._itemStart);
        //            par_anchorItem._anchorItem.DLL_SetItemNext(par_range._StartingItemOfRange);

        //            // Administration (i.e. easy to forget!!)
        //            // 10=2024  par_range._StartingItem.DLL_SetItemPrior(par_anchor._anchorItem);
        //            // 10-2024  par_range._EndingItem.DLL_SetItemNext(itemOriginallyAfterAnchor);
        //            par_range.ItemStart().DLL_SetItemPrior(par_anchorItem._anchorItem);
        //            par_range.Item__End().DLL_SetItemNext(itemOriginallyAfterAnchor);
        //            itemOriginallyAfterAnchor.DLL_SetItemPrior(par_range._EndingItemOfRange);
        //        }
        //        else
        //        {
        //            //
        //            // #2b of 3. Anchor is at the end of the list.
        //            //
        //            // Nothing originally (pre-operation) follows the anchor,
        //            //    i.e. there is no item which is "Next" after the anchor.
        //            //
        //            if (Testing.AreWeTesting)
        //            {
        //                bool bListHasAnchor = par_list_NotReallyNeeded.Contains(par_anchorItem._anchorItem);
        //                if (false == bListHasAnchor) Debugger.Break();
        //                bool bAnchorIsEndOfList;
        //                bAnchorIsEndOfList = (par_anchorItem._anchorItem.Equals(par_list_NotReallyNeeded._itemEnding));
        //                if (false == bAnchorIsEndOfList) Debugger.Break();

        //            }

        //            //Perform the operation !!
        //            par_anchorItem._anchorItem.DLL_SetItemNext(par_range._StartingItemOfRange);

        //            // Administration (i.e. easy to forget!!)
        //            par_range._StartingItemOfRange.DLL_SetItemPrior(par_anchorItem._anchorItem);

        //        }

        //        //
        //        // Added 11/10/2024 td 
        //        //
        //        //if (bAnchorIsFirstItem)
        //        //{
        //        //
        //        //}

        //        //if (bAnchorIsLastItem)
        //        //{
        //        //
        //        //}

        //    }

        //    //else if (par_anchorItem != null && _willInsertRange_PriorToAnchor)
        //    else if (par_anchorItem != null && par_anchorItem._doInsertRangeBeforeThis)
        //    {
        //        //
        //        // Option #3 of 3...  
        //        //
        //        // Insert the range PRIOR (PRECEDING) to the anchoring item.
        //        //
        //        IDoublyLinkedItem<TControl>
        //            itemOriginallyBeforeAnchor = par_anchorItem._anchorItem.DLL_GetItemPrior_OfT();

        //        bool bAnchorHasItemBefore;
        //        bAnchorHasItemBefore = par_anchorItem._anchorItem.DLL_HasPrior();

        //        if (Testing.AreWeTesting)
        //        {
        //            bool bAnchorIsMissingFromList; //Added 4/23/2024 td
        //            bAnchorIsMissingFromList = (false == par_list_NotReallyNeeded.Contains(par_anchorItem._anchorItem));
        //            if (bAnchorIsMissingFromList) Debugger.Break();

        //            if (bAnchorHasItemBefore)
        //            {
        //                bool bInsertIs_AlreadyDone = itemOriginallyBeforeAnchor.Equals(par_range._EndingItemOfRange);
        //                if (bInsertIs_AlreadyDone) System.Diagnostics.Debugger.Break();
        //                if (bInsertIs_AlreadyDone) return; // Don't repeat an unneeded operation.
        //            }
        //            else
        //            {
        //                // Confirm that the anchor is the first item in the list.
        //                bool bAnchorIs_StartOfList;
        //                bAnchorIs_StartOfList = (par_anchorItem._anchorItem.Equals(par_list_NotReallyNeeded._itemStart));
        //                if (false == bAnchorIs_StartOfList) Debugger.Break();
        //            }

        //        } // if (Testing.AreWeTesting )

        //        if (bAnchorHasItemBefore)  // (itemOriginallyBeforeAnchor != null)
        //        {
        //            //
        //            // #3a of 3. 
        //            //
        //            // Insert the range before the anchor. 
        //            par_anchorItem._anchorItem.DLL_SetItemPrior(par_range._EndingItemOfRange);

        //            // Administration (i.e. easy to forget!!)
        //            par_range._EndingItemOfRange.DLL_SetItemNext(par_anchorItem._anchorItem);
        //            par_range._StartingItemOfRange.DLL_SetItemPrior(itemOriginallyBeforeAnchor);
        //            itemOriginallyBeforeAnchor.DLL_SetItemNext(par_range._StartingItemOfRange);
        //        }
        //        else
        //        {
        //            //
        //            // #3b of 3.  Anchor is at the start of the list. 
        //            //
        //            // Insert the range before the anchor. 
        //            par_anchorItem._anchorItem.DLL_SetItemPrior(par_range._EndingItemOfRange);
        //            // Administration (i.e. easy to forget!!)
        //            par_range._EndingItemOfRange.DLL_SetItemNext(par_anchorItem._anchorItem);
        //        }

        //    }


        //}




        //private void OperateOnList_Delete(DLLList<TControl> par_list,
        //                                    DLLRange<TControl> par_range,
        //                         bool pbEndpointProtection,
        //                         bool pbIsChangeOfEndpoint = false,
        //                         bool pbRunOtherChecks = false)
        ////  where TControl : IDoublyLinkedItem<TControl>
        //{
        //    //
        //    // Added 11/12/2024
        //    //
        //    const bool USE_OBSELETE_CODE = false;
        //    if (USE_OBSELETE_CODE)
        //    {
        //        OperateOnList_Delete_OBSELETE(par_list, par_range,
        //            pbEndpointProtection, pbIsChangeOfEndpoint, pbRunOtherChecks);
        //    }
        //    else
        //    {
        //        //
        //        // Added 11/12/2024
        //        //
        //        DLLAnchorCouplet<TControl> tempInverse = par_range.GetCoupletWhichEncloses_InverseAnchor();

        //        //
        //        // Major call!!!
        //        //
        //        const bool OUTSOURCE_ADMIN = true; // Added 11/12/2024 td

        //        if (OUTSOURCE_ADMIN)
        //        {
        //            //--par_range.DeleteFromList();
        //            par_range.DeleteFromList_wAdmin(par_list);
        //        }
        //        else
        //        {
        //            par_range.DeleteFromList_noAdmin();

        //            // Added 11/12/2024 
        //            //  Reduce the item count, by using the -= operator. 
        //            //
        //            par_list._itemCount -= par_range.GetItemCount();

        //            if (pbIsChangeOfEndpoint)
        //            {
        //                if (tempInverse.ItemLefthandIsNull())
        //                {
        //                    if (tempInverse.ItemRighthandIsNull() == false)
        //                        par_list._itemStart = tempInverse.GetItemLeftOrFirst();
        //                }
        //                else if (tempInverse.ItemRighthandIsNull())
        //                {
        //                    if (tempInverse.ItemLefthandIsNull() == false)
        //                        par_list._itemEnding = tempInverse.GetItemRightOrSecond();
        //                }
        //            }
        //        }
        //    }


        //}


        //private void OperateOnList_Delete_OBSELETE(DLLList<TControl> par_list,
        //                                        DLLRange<TControl> par_range,
        //                             bool pbEndpointProtection,
        //                             bool pbIsChangeOfEndpoint = false,
        //                             bool pbRunOtherChecks = false)
        ////  where TControl : IDoublyLinkedItem<TControl>
        //{
        //    //
        //    // Added 4/17/2024
        //    //
        //    //   This is a private singly-generic method (Of TControl),
        //    //   to obey the DRY principle inside a doubly-generic class 
        //    //   (Of TControl_H, TControl_V). 
        //    //  
        //    // De-link the item BEFORE the deletion range.
        //    //
        //    //IDoublyLinkedItem<TControl>
        //    //    itemOriginallyBeforeRange = par_range._StartingItem.DLL_GetItemPrior_OfT();
        //    TControl itemOriginallyBeforeRange = par_range.ItemStart().DLL_GetItemPrior_OfT();

        //    if (itemOriginallyBeforeRange != null)
        //    {
        //        itemOriginallyBeforeRange.DLL_ClearReferenceNext('D');
        //        if (ALWAYS_CLEAN_ENDPOINTS)
        //        {
        //            par_range._StartingItemOfRange.DLL_ClearReferencePrior('D');
        //        }
        //    }

        //    //
        //    // De-link the item AFTER the deletion range.
        //    //
        //    //IDoublyLinkedItem<TControl>
        //    TControl itemOriginallyAfterRange = par_range.Item__End().DLL_GetItemNext_OfT();
        //    // itemOriginallyAfterRange = par_range._EndingItem.DLL_GetItemNext_OfT();

        //    if (itemOriginallyAfterRange != null)
        //    {
        //        itemOriginallyAfterRange.DLL_ClearReferencePrior('D');
        //        if (ALWAYS_CLEAN_ENDPOINTS)
        //        {
        //            // par_range._EndingItem.DLL_ClearReferenceNext('D');
        //            par_range.Item__End().DLL_ClearReferenceNext('D');
        //        }
        //    }

        //    // Administration.  Easy to forget!
        //    if (itemOriginallyAfterRange != null)
        //    {
        //        if (itemOriginallyBeforeRange != null)
        //        {
        //            itemOriginallyBeforeRange.DLL_SetItemNext(itemOriginallyAfterRange);
        //            itemOriginallyAfterRange.DLL_SetItemPrior(itemOriginallyBeforeRange);
        //            // Added 11/12/2024 
        //            par_list._itemCount -= par_range.GetItemCount();
        //        }
        //        else
        //        {
        //            par_list._itemStart = itemOriginallyAfterRange;
        //            par_list._itemCount -= par_range.GetItemCount();
        //            par_list.NotifyOfModification();

        //        }
        //    }
        //    else
        //    {
        //        if (itemOriginallyBeforeRange != null)
        //        {
        //            itemOriginallyBeforeRange.DLL_ClearReferenceNext('D');
        //        }
        //        else
        //        {
        //            //
        //            //  The range is the entire list.
        //            //
        //            //  Remove the entire list. 
        //            //
        //            par_list.DLL_RemoveAllItems();

        //        }

        //    }

        //    //
        //    // End of Deletion operation.  
        //    //

        //}


        ///// <summary>
        ///// Perform an insert operation, either for TControl_H or TControl_V.
        ///// If appropriate, we perform some sanity testing prior to the operation.
        ///// </summary>
        ///// <typeparam name="TControl"></typeparam>
        ///// <param name="par_list_NotReallyNeeded">This parameter provides a sanity check (debugging).</param>
        ///// <param name="par_range">This is the range of items which are being placed into the list.</param>
        ///// <param name="par_anchorItem">This is a simple wrapper for the item which provides the location for the insert operation.</param>
        //private void OperateOnList_Move(DLLList<TControl> par_list_forFinalAdmin,
        //                                     DLLRange<TControl> par_range,
        //                                     StructureTypeOfMove par_typeOfMove,
        //                                     DLLAnchorItem<TControl>? par_anchorItem,
        //                                     DLLAnchorCouplet<TControl>? par_anchorPair,
        //                             bool pbEndpointProtection,
        //                             bool pbIsChangeOfEndpoint_Expected,
        //                             out bool pbChangeOfEndpoint_Occurred,
        //                             bool pbRunOtherChecks = false)
        //{
        //    //
        //    // Encasulated/added 11/18/2024 Th.omas Do.wnes
        //    //;
        //    bool boolIsByAnchor = par_typeOfMove.IsMoveToAnchor; // true; // false;
        //    bool boolIsByShifts = par_typeOfMove.IsMoveIncrementalShift; // true; // false;
        //    pbChangeOfEndpoint_Occurred = false; // Default.  Added 12/15/2024 

        //    if (boolIsByAnchor)
        //    {
        //        // A Move is a Delete of a Range, and then an  Insert of the same range.
        //        //
        //        // Step 1 of 2. DELETE THE RANGE
        //        OperateOnList_Delete(par_list_forFinalAdmin, par_range,
        //                             pbEndpointProtection,
        //                             pbIsChangeOfEndpoint_Expected);

        //        // Step 2 of 2. INSERT THE RANGE 
        //        OperateOnList_Insert(par_list_forFinalAdmin, par_range,
        //                             par_anchorItem, par_anchorPair,
        //                             pbEndpointProtection,
        //                             pbIsChangeOfEndpoint_Expected, pbRunOtherChecks);
            
        //    }
           
        //    else if (boolIsByShifts)
        //    {
        //        //
        //        // Shift the range left or right, one item at a time. 
        //        //    (The range itself will not directly mutate, only the items which 
        //        //    are adjacent to the range.)
        //        //
        //        int howManyShifts = par_typeOfMove.HowManyItemsIncremental;
        //        bool bShiftingLeft = par_typeOfMove.IsShiftingToLeft;  //Added 12/19/2024
        //        bool bShiftingRight = par_typeOfMove.IsShiftingToRight;  //Added 12/19/2024
        //        bool ref_not_possible = false;
        //        bool changeOfEndpoint_Expected = false; // (1 == par_range._StartingItem.DLL_GetItemIndex());
        //        bool changeOfEndpoint_Any = false;
        //        int intListItemCount = par_list_forFinalAdmin._itemCount; //Added 12/19/2024

        //        for (int index = 1; index <= howManyShifts; index++)
        //        {
        //            // Added 12/15/2024 thomas downes
        //            int indexOfRange; // = par_range._StartingItemOfRange.DLL_GetItemIndex();

        //            // Change of endpoint likely? --12/15/2024 td
        //            //changeOfEndpoint = (indexOfRange <= 2);
        //            //--- changeOfEndpoint_Expected = (indexOfRange <= 2 ||
        //            //---   indexOfRange >= -1 + par_list_forFinalAdmin._itemCount);

        //            if (bShiftingLeft)
        //            {
        //                indexOfRange = par_range._StartingItemOfRange.DLL_GetItemIndex();
        //                changeOfEndpoint_Expected = (indexOfRange <= 2) || 
        //                    par_range.ContainsEndpoint();

        //            }
        //            else if (bShiftingRight)
        //            {
        //                indexOfRange = par_range._EndingItemOfRange.DLL_GetItemIndex();
        //                intListItemCount = par_list_forFinalAdmin._itemCount;
        //                changeOfEndpoint_Expected = (indexOfRange >= -1 + intListItemCount) || 
        //                    par_range.ContainsEndpoint();

        //            }

        //            changeOfEndpoint_Any = (changeOfEndpoint_Any || changeOfEndpoint_Expected); //Added 12/15/2024

        //            // par_range.Shift_ByOneItem(par_typeOfMove.IsIncrementalToRight);
        //            par_range.Shift_ByOneItem(par_typeOfMove.IsShiftingToRight, 
        //                ref ref_not_possible, par_list_forFinalAdmin, changeOfEndpoint_Expected);

        //            if (ref_not_possible) break;

        //        }

        //    }


        //}




        ///****
        // * 
        // * 
        // * public void OperateOnList(DLLList<TControl_H> par_list)
        //{
        //    // public void OperateOnList(LinkedList<TControl_H> par_list)
        //    //
        //    // Added 4/17/2024
        //    //
        //    //if (_anchor_H != null && _willInsertRange_AfterAnchor)
          

        //        }
        //    }
        //}

        //*
        //*
        //**********/


  

        /// <summary>
        /// Create the inverse (Undo) version, created when an "Undo" operation is needed.
        /// </summary>
        /// <returns>Inverse of the present operation</returns>
        public DLLOperation1D<TControl> GetPrior()
        {
            //
            // Added 5/25/2024 
            //
            return mod_opPrior_ForUndo_OfT;

        }

        /// <summary>
        /// Create the inverse (Undo) version, created when an "Undo" operation is needed.
        /// </summary>
        /// <returns>Inverse of the present operation</returns>
        public DLLOperation1D<TControl> GetNext()
        {
            //
            // Added 5/25/2024 
            //
            return mod_opNext_ForRedo_OfT;

        }


        public bool HasPrior()
        {
            //
            // Added 5/25/2024 
            //
            return (mod_opPrior_ForUndo_OfT != null);

        }

        public bool HasNext()
        {
            //
            // Added 5/25/2024 
            //
            return (mod_opNext_ForRedo_OfT != null);

        }


        public IDoublyLinkedItem GetInitialItemInRange()
        {
            // Added 6/06/2024 td
            //if (_isHoriz && _range_H != null) return (IDoublyLinkedItem)(_range_H._StartingItem);
            //if (_isVerti && _range_V != null) return (IDoublyLinkedItem)(_range_V._StartingItem);

            return (IDoublyLinkedItem)(_range._StartingItemOfRange);
            //return null;
        }


        //public DLLRange<TControl_H> GetRange_Horiz()
        //{
        //    // Added 6/06/2024 td
        //    return _range_H;
        //}
        //public DLLRange<TControl_V> GetRange_Verti()
        //{
        //    // Added 6/06/2024 td
        //    return _range_V;
        //}

        public DLLRange<TControl> GetRange()
        {
            // Added 6/06/2024 td
            return _range;
        }


        public bool IsForSingleItem()
        {
            // Added 6/06/2024 td
            //if (_isHoriz && _range_H != null) return _range_H._isSingleItem;
            //if (_isVerti && _range_V != null) return _range_V._isSingleItem;
            //return false;

            return _range._isSingleItem;

        }


        public DLLOperationBase GetConvertToBaseClass()
        {
            //---public DLLOperationBase DLL_GetBase()
            //Added 12 /02/2024 td
            //----return this;
            return (this as DLLOperationBase);

        }



        public DLLOperation1D<TControl> DLL_GetOpPrior_OfT()
        {
            // Added 12/02/2024 
            //
            //  Sanity check. 
            //
            if (base.mod_opPrior_ForUndo != mod_opPrior_ForUndo_OfT?.GetConvertToBaseClass())
            {
                System.Diagnostics.Debugger.Break();
            }

            // Added 12/02/2024 
            //
            //  Sanity check.  (Equivalent to above.)  
            //
            if (base.mod_opPrior_ForUndo != (mod_opPrior_ForUndo_OfT as DLLOperationBase))
            {
                System.Diagnostics.Debugger.Break();
            }

            return mod_opPrior_ForUndo_OfT;

        }


        public DLLOperation1D<TControl> DLL_GetOpNext_OfT()
        {
            // Added 12/02/2024 

            // Check to see that we haven't a bug on our hands.
            //
            if (base.mod_opNext_ForRedo != mod_opNext_ForRedo_OfT?.GetConvertToBaseClass())
            {
                System.Diagnostics.Debugger.Break();
            }

            // Added 12/02/2024 
            if (base.mod_opNext_ForRedo != (mod_opNext_ForRedo_OfT as DLLOperationBase))
            {
                System.Diagnostics.Debugger.Break();
            }

            return mod_opNext_ForRedo_OfT;

        }


        public void DLL_SetOpPrior_OfT(DLLOperation1D<TControl> parOperation)
        {
            mod_opPrior_ForUndo_OfT = parOperation;

            //Added 12/02/2024 td
            base.mod_opPrior_ForUndo = parOperation;

        }


        public void DLL_SetOpNext_OfT(DLLOperation1D<TControl> parOperation)
        {
            mod_opNext_ForRedo_OfT = parOperation;

            //Added 12/02/2024 td
            base.mod_opNext_ForRedo = parOperation;

        }



        public void DLL_SetOpNext_OfT(DLLOperation1D<TControl> parOperation, bool pbBirectional)
        {
            //
            //Added 12/08/2024 td
            //
            DLL_SetOpNext_OfT(parOperation);

            // Added 12/08/2024 
            //''
            //'' Adding bidirectionality.  ---12 / 08 / 2024 td
            //''
            if (pbBirectional)
            {
                //''
                //''Set the "mod_prior" item for this parameter item,
                //''  to be the present class (i.e.the procedure's implicit parameter).
                //''
                parOperation.mod_opPrior_ForUndo = this as DLLOperationBase;
                parOperation.mod_opPrior_ForUndo_OfT = this; 

             } // End If ''end of "" If (ENFORCE_BIDIRECTIONAL) Then""


        }


        public int DLL_GetIndex()
        {
            int result = 0;
            var temp = mod_opPrior_ForUndo_OfT;
            while (temp != null)
            {
                result++;
                temp = temp.DLL_GetOpPrior_OfT();
            } //until temp == null;  
            return result;
        }


        public int DLL_CountOpsAfter()
        {
            //
            // Added 11/29/2024  
            //
            int result_count = 0;

            //
            // Please note, "After" and "Next" are synonyms.  
            //    So, "2 comes after 1" and "2 is the next number after 1"
            //    means the same thing. 
            //
            DLLOperation1D<TControl> operationNextAfter = DLL_GetOpNext_OfT();
            
            while (operationNextAfter != null)
            {
                result_count++;
                operationNextAfter = operationNextAfter.DLL_GetOpNext_OfT();
            }
            return result_count;  

        }


        public int DLL_CountOpsBefore()
        {
            //
            // Added 11/29/2024  
            //
            int result_count = 0;

            //
            // Please note, "Before" and "Prior" are synonyms.  
            //    So, "3 comes before 4" and "3 is the number prior to 4"
            //    means the same thing. 
            //
            //---12/03/2024---DLLOperation1D<TControl> tempOperation = DLL_GetOpNext_OfT();
            DLLOperation1D<TControl> operationPriorBefore = DLL_GetOpPrior_OfT();

            while (operationPriorBefore != null)
            {
                result_count++;
                //---HARD TO FIND BUG--- = operationPriorBefore.DLL_GetOpNext_OfT();
                operationPriorBefore = operationPriorBefore.DLL_GetOpPrior_OfT();
            }

            return result_count;

        }


        public bool CheckEndPointsAreClean_PriorToInsert()
        {
            //
            //  Added 7/07/2024  
            //
            //DLLRange<TControl_H> rangeH = _range_H;
            //DLLRange<TControl_V> rangeV = _range_V;
            bool result = true;  // false;

            //if (_range_H != null) result = _range_H.CheckEndpointsAreClean_PriorToInsert();
            //if (_range_V != null) result = _range_V.CheckEndpointsAreClean_PriorToInsert();
            //return result;

            if (_range != null)
                result = _range.CheckEndpointsAreClean_PriorToInsert();

            else result = true;  // Added 12/02/2024 td
            return result;

        }


        public void DLL_ClearOpNext()
        {
            //
            // Added 12/02/2024 by Th.omas Do.wnes 
            //
            //    This is needed if the user has pressed the "Undo" button, 
            //    and now wants to move forward with a "brand new" operation. 
            //    Rather than following "Undo" with a "Redo", user wants to 
            //    permanently discard the his or her most recent operation. 
            //    (The operation being discarded was definitely a mistake in
            //    the user's perspective.)
            //    12/02/2024 th.omas do.wnes 
            //
            mod_opNext_ForRedo_OfT = null;

            // Added 12/02/2024
            base.mod_opNext_ForRedo = null;

        }




    }
}


