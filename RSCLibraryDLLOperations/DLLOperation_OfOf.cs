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
    public class DLLOperation1D_OfOf<TBase, TParallel> : DLLOperation1D<TBase> // :IDoublyLinkedItem
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
        private DLLRange<TParallel>[]? mod_arrayOfParallelRanges;
        // --------------------- End of IMPORTANT!! ---------------------------------------  
        // --------------------------------------------------------------------------------

        private DLLOperation1D_OfOf<TBase, TParallel>? mod_opPrior_ForUndo_OfT;
        private DLLOperation1D_OfOf<TBase, TParallel>? mod_opNext_ForRedo_OfT;


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
                      DLLOperation1D<TBase>? par_operationPrior = null,
                      DLLOperation1D<TBase>? par_operationNext = null)
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



        }

        public DLLOperation1D_OfOf(EnumSortTypes par_enum) : base(par_enum)
        {
            //
            // We simply pass the arguments to the base class.
            //
            // Added 4/09/2025 thomas downes
            //

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
            return mod_opPrior_ForUndo_OfT;

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
            return mod_opNext_ForRedo_OfT;

        }


        public DLLOperation1D_OfOf<TBase, TParallel> DLL_GetOpPrior_OfOf()
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


    }


}
