using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
// Added 4/09/2025 thomas downes
//
namespace RSCLibraryDLLOperations
{
    //
    // Added 4/09/2025 thomas downes
    //
    public class DLLOperation1D_OfOf<TBase, TParallel> : DLLOperation1D_Of<TBase> // :IDoublyLinkedItem
        where TBase : class, IDoublyLinkedItem<TBase>
        where TParallel : class, IDoublyLinkedItem<TParallel>
    {
        //
        // Added 4/09/2025 thomas downes
        //

        //
        // --------------------------------------------------------------------------------
        // ---------------------------- IMPORTANT!! ---------------------------------------  
        // --------------------- Array of Parallel Ranges ---------------------------------  
        // -------------- This is why I created this derived class!! ----------------------
        // --------------------------------------------------------------------------------
        /// <summary>
        /// A Parallel range is the range which has the same index structure (begin, end)
        /// 
        /// </summary>
        public DLLRange<TParallel>[]? ArrayOfParallelRanges_ToInsert;
        /// <summary>
        /// 
        /// </summary>
        public DLLRange<TParallel>[]? ArrayOfParallelRanges_Deleted;
        // --------------------- End of IMPORTANT!! ---------------------------------------  
        // --------------------------------------------------------------------------------

        private DLLOperation1D_OfOf<TBase, TParallel>? mod_opPrior_ForUndo_OfT_OfT;
        private DLLOperation1D_OfOf<TBase, TParallel>? mod_opNext_ForRedo_OfT_OfT;


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
        //public DLLOperation1D(DLLRange<TControl>? par_range,
        //          bool par_forStartOfList, bool par_forEndOfList,
        //          bool par_isInsert, bool par_isDelete, bool par_isMove,
        //          StructureTypeOfMove par_structMoveType,
        //          DLLAnchorItem<TControl>? par_anchorItem,
        //          DLLAnchorCouplet<TControl>? par_anchorPair,
        public DLLOperation1D_OfOf(bool par_isSortAscending,
                  bool par_isSortDescending,
                  bool par_isUndoOfSortAscending,
                  bool par_isUndoOfSortDescending,
                  TBase par_itemStart_Sorting,
                  TBase par_itemEnding_ForSorting,
                  bool pbSortByArrayOfControls,
                  TBase[] par_arrayControls_Sorting,
                  bool pbSortByArrayOfIndices,
                  int[]? par_arrayIndices_Sorting) : base(par_isSortAscending, par_isSortDescending,
                                                          par_isUndoOfSortAscending, par_isUndoOfSortDescending,
                                                          par_itemStart_Sorting, par_itemEnding_ForSorting,
                                                          pbSortByArrayOfControls, par_arrayControls_Sorting,
                                                          pbSortByArrayOfIndices, par_arrayIndices_Sorting)
        {
            //
            // We simply pass the arguments to the base class.
            //
            // Added 4/10/2025 thomas downes
            //

        }


        public DLLOperation1D_OfOf(DLLRange<TBase>? par_range,
                      bool par_forStartOfList, bool par_forEndOfList,
                      bool par_isInsert, bool par_isDelete, bool par_isMove,
                      StructureTypeOfMove par_structMoveType,
                      DLLAnchorItem<TBase>? par_anchorItem,
                      DLLAnchorCouplet<TBase>? par_anchorPair,
                      DLLOperation1D_Of<TBase>? par_operationPrior = null,
                      DLLOperation1D_Of<TBase>? par_operationNext = null)
                                        : base(par_range, par_forStartOfList,
                                            par_forEndOfList, par_isInsert,
                                            par_isDelete, par_isMove,
                                            par_structMoveType, par_anchorItem,
                                            par_anchorPair, par_operationPrior, par_operationNext)
        {
            //
            // We simply pass the arguments to the base class.
            //
            // Added 4/10/2025 thomas downes
            //


        }


        public DLLOperation1D_OfOf(DLLOperation1D_Of<TBase> par_operation1D_Of)
                                                                  : base(par_operation1D_Of)
                                        //: base(par_operation1D_Of._range,
                                        //    par_operation1D_Of._isForStartOfList,
                                        //    par_operation1D_Of._isForEndOfList,
                                        //    par_operation1D_Of._isInsert,
                                        //    par_operation1D_Of._isDelete,
                                        //    par_operation1D_Of._isMove,
                                        //    par_operation1D_Of._moveType,
                                        //    par_operation1D_Of._anchorItem,
                                        //    par_operation1D_Of._anchorCouplet,
                                        //    par_operation1D_Of.mod_opPrior_ForUndo_OfT,
                                        //    par_operation1D_Of.mod_opNext_ForRedo_OfT,
                                        //    par_operation1D_Of._inverseAnchorItem_ForUndo,
                                        //    par_operation1D_Of._inverseAnchorPair_forUndo)
        {
            //
            // We simply pass the arguments to the base class.
            //
            // Added 4/12/2025 thomas downes
            //
            // See the base-constructor call...
            //
            //                            : base(par_operation1D_Of._range,
            //                                par_operation1D_Of._isForStartOfList,
            //                                par_operation1D_Of._isForEndOfList,
            //                                par_operation1D_Of._isInsert,
            //                                par_operation1D_Of._isDelete,
            //                                par_operation1D_Of._isMove,
            //                                par_operation1D_Of._moveType,
            //                                par_operation1D_Of._anchorItem,
            //                                par_operation1D_Of._anchorCouplet,
            //                                par_operation1D_Of.mod_opPrior_ForUndo_OfT,
            //                                par_operation1D_Of.mod_opNext_ForRedo_OfT)
            //


        }


        public DLLOperation1D_OfOf(DLLRange<TBase> par_range,
                       DLLAnchorCouplet<TBase>? par_anchorCouplet,
                       bool par_isInsert, bool par_isMove,
                       StructureTypeOfMove par_typeOfMove)
                        : base(par_range, par_anchorCouplet, par_isInsert, par_isMove, par_typeOfMove)
        {
            //
            // We simply pass the arguments to the base class.
            //
            // Added 4/10/2025 thomas downes
            //
            // See the base-constructor call...
            //
            //      : base(par_range, par_anchorCouplet,
            //           par_isInsert, par_isMove, par_typeOfMove)
            //   

        }


        public DLLOperation1D_OfOf(DLLOperationIndexStructure par_structure,
                          TBase par_firstItem, DLLRange<TBase>? par_range = null)
                : base(par_structure, par_firstItem, par_range)
        {
            //
            // We simply pass the arguments to the base class.
            //
            // Added 4/12/2025 thomas downes
            //
            // See the base-constructor call... 
            //
            //        : base(par_structure, par_firstItem, par_range)
            //

        }


        public DLLOperation1D_OfOf(EnumSortTypes par_enum) : base(par_enum)
        {
            //
            // We simply pass the arguments to the base class.
            //
            // Added 4/09/2025 thomas downes
            //
            // See the base-constructor call... ": base(par_structure, par_firstItem, par_range)"

        }


        /// <summary>
        /// Create the inverse (Undo) version, created when an "Undo" operation is needed.
        /// </summary>
        /// <returns>Inverse of the present operation</returns>
        public DLLOperation1D_OfOf<TBase, TParallel>? GetPrior_OfOf()
        {
            //
            // Added 5/25/2024 
            //
            return mod_opPrior_ForUndo_OfT_OfT;

        }

        /// <summary>
        /// Create the inverse (Undo) version, created when an "Undo" operation is needed.
        /// </summary>
        /// <returns>Inverse of the present operation</returns>
        public DLLOperation1D_OfOf<TBase, TParallel>? GetNext_OfOf()
        {
            //
            // Added 5/25/2024 
            //
            return mod_opNext_ForRedo_OfT_OfT;

        }


        public DLLOperation1D_OfOf<TBase, TParallel>? DLL_GetOpPrior_OfOf()
        {
            // Added 4/10/2025 & 12/02/2024 
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

            return mod_opPrior_ForUndo_OfT_OfT;

        }



        public void DLL_SetOpNext_OfT_OfT(DLLOperation1D_OfOf<TBase, TParallel> parOperation)
        {
            //
            // Added 4/11/2025 td (from DLLOperation_Of.cs)
            //
            this.mod_opNext_ForRedo_OfT_OfT = parOperation;
            this.mod_opPrior_ForUndo_OfT_OfT = parOperation;

            //
            //  Address the base members.
            //
            base.mod_opNext_ForRedo_OfT = parOperation;

            //Added 12/02/2024 td
            base.mod_opNext_ForRedo = parOperation;

            //Added 1/04/2024 
            base.mod_opNext_ForRedo_OfT = parOperation;

            // Added 4/18/2025
            base.mod_opNextIsNull = false;

        }



        public void DLL_SetOpNext_OfT_OfT(DLLOperation1D_OfOf<TBase, TParallel> parOperation, bool pbBirectional)
        {
            //
            // Added 4/11/2025 & 12/08/2024 td
            //
            DLL_SetOpNext_OfT_OfT(parOperation);

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
                //-----April 2025----parOperation.mod_opPrior_ForUndo = this as DLLOperationBase;
                parOperation.mod_opPrior_ForUndo = this;
                parOperation.mod_opPrior_ForUndo_OfT = this;
                parOperation.mod_opPrior_ForUndo_OfT_OfT = this;

            } // End If ''end of "" If (ENFORCE_BIDIRECTIONAL) Then""


        }


        public void DLL_SetOpPrior_OfT_OfT(DLLOperation1D_OfOf<TBase, TParallel> parOperation)
        {
            //
            // Added 4/14/2025 thomas downes
            //
            this.mod_opPrior_ForUndo_OfT_OfT = parOperation;

            //Added 12/02/2024 td
            base.mod_opPrior_ForUndo = parOperation;

            //Added 1/04/2024 
            base.mod_opPrior_ForUndo_OfT = parOperation;

        }



        /// <summary>
        /// Create the inverse (Undo) version, created when an "Undo" operation is needed.
        /// </summary>
        /// <returns>Inverse of the present operation</returns>
        public DLLOperation1D_OfOf<TBase, TParallel> // <T_DLLItem_H, T_DLLItem_V>
            GetInverseForUndo_OfOf(bool pbTestForIdempotency)
        {
            //
            // Added 4/12/2025 
            //

            //if (ArrayOfParallelRanges_Deleted != null)
            //{
            //    ArrayOfParallelRanges_ToInsert = ArrayOfParallelRanges_Deleted;
            //}

            //else if (ArrayOfParallelRanges_ToInsert  != null)
            //{
            //    ArrayOfParallelRanges_Deleted = ArrayOfParallelRanges_ToInsert;
            //}

            //par_operation1D_Of._range,
            //par_operation1D_Of._isForEndOfList,
            //par_operation1D_Of._isInsert,
            //par_operation1D_Of._isDelete,
            //par_operation1D_Of._isMove,
            //par_operation1D_Of._moveType,
            //par_operation1D_Of._anchorItem,
            //par_operation1D_Of._anchorCouplet,
            //par_operation1D_Of.mod_opPrior_ForUndo_OfT,
            //par_operation1D_Of.mod_opNext_ForRedo_OfT

            DLLOperation1D_Of<TBase> inverseOp_Of = base.GetInverseForUndo_Of(false);

            //base._range = inverseOp._range;
            //base._isForStartOfList = inverseOp._isForStartOfList;
            //base._isForEndOfList = inverseOp._isForEndOfList;
            //base._isInsert = inverseOp
            //      par_operation1D_Of._isDelete,
            //      par_operation1D_Of._isMove,
            //      par_operation1D_Of._moveType,
            //      par_operation1D_Of._anchorItem,
            //      par_operation1D_Of._anchorCouplet,
            //      par_operation1D_Of.mod_opPrior_ForUndo_OfT,
            //      par_operation1D_Of.mod_opNext_ForRedo_OfT
            //

            var inverseOp_OfOf = new DLLOperation1D_OfOf<TBase, TParallel>(inverseOp_Of);

            //-------------------------------------------------------
            //-----  DIFFICULT & CONFUSING  -------------------------
            //-----   Let's play switcheroo! ------------------------
            //-----   We are creating the inverse operation.  -------
            //-----   (ToInsert --> Delete, Delete --> ToInsert) ----
            //-------------------------------------------------------
            inverseOp_OfOf.ArrayOfParallelRanges_Deleted = ArrayOfParallelRanges_ToInsert; // Switching ToInsert --> Delete.
            inverseOp_OfOf.ArrayOfParallelRanges_ToInsert = ArrayOfParallelRanges_Deleted; // Switching Delete --> ToInsert. 

            return inverseOp_OfOf;

        }




    }


}
