using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

//
// Added 4/09/2025 thomas downes
//
namespace RSCLibraryDLLOperations
{
    //
    // Added 4/09/2025 thomas downes
    //
    public class DLLOperation1D_2TypesInParallel<THeader, TParallel> : DLLOperation1D_Of<THeader> // :IDoublyLinkedItem
        where THeader : class, IDoublyLinkedItem<THeader>
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
        //---public DLLRange<TParallel>[]? ArrayOfParallelRanges_ToInsert;
        /// <summary>
        /// A Parallel range is the range which has the same index structure (begin, end)
        /// 
        /// </summary>
        private DLLRange<TParallel>[]? ArrayOfParallelRanges_ToInsert;

        //---public DLLRange<TParallel>[]? ArrayOfParallelRanges_Deleted;
        /// <summary>
        /// 
        /// </summary>
        private DLLRange<TParallel>[]? ArrayOfParallelRanges_Deleted;
        // --------------------- End of IMPORTANT!! ---------------------------------------  
        // --------------------------------------------------------------------------------

        public void SetArrayOfParallelRanges_ToInsert(DLLRange<TParallel>[]? par_array)
        {
            // Added 4/23/2025 td
            ArrayOfParallelRanges_ToInsert = par_array;

        }

        public void SetArrayOfParallelRanges_Deleted(DLLRange<TParallel>[]? par_array)
        {
            // Added 4/23/2025 td
            ArrayOfParallelRanges_Deleted = par_array;

        }

        public DLLRange<TParallel>[]? GetArrayOfParallelRanges_ToInsert()
        {
            // Added 4/23/2025 td     
            return ArrayOfParallelRanges_ToInsert; // = par_array;

        }

        public DLLRange<TParallel>[]? GetArrayOfParallelRanges_Deleted()
        {
            // Added 4/23/2025 td
            return ArrayOfParallelRanges_Deleted; // = par_array;

        }


        private DLLOperation1D_2TypesInParallel<THeader, TParallel>? mod_opPrior_ForUndo_OfT_OfT;
        private DLLOperation1D_2TypesInParallel<THeader, TParallel>? mod_opNext_ForRedo_OfT_OfT;


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
        public DLLOperation1D_2TypesInParallel(bool par_isSortByItemValues, 
                  bool par_isSortAscending,
                  bool par_isSortDescending,
                  bool par_isUndoOfSortAscending,
                  bool par_isUndoOfSortDescending,
                  bool par_isSortByArrayIndex,
                  THeader par_itemStart_Sorting,
                  THeader par_itemEnding_ForSorting,
                  bool pbSortByArrayOfControls,
                  THeader[] par_arrayControls_Sorting,
                  bool pbSortByArrayOfIndices,
                  int[]? par_arrayIndices_SortRedo, 
                  int[]? par_arrayIndices_SortUndo) : base(par_isSortByItemValues,
                                                          par_isSortAscending, par_isSortDescending,
                                                          par_isUndoOfSortAscending, par_isUndoOfSortDescending,
                                                          par_isSortByArrayIndex,
                                                          par_itemStart_Sorting, par_itemEnding_ForSorting,
                                                          par_arrayIndices_SortRedo, 
                                                          par_arrayIndices_SortUndo)
        {
            //
            // We simply pass the arguments to the base class.
            //
            // Added 4/10/2025 thomas downes
            //

        }


        public DLLOperation1D_2TypesInParallel(DLLRange<THeader>? par_range,
                      bool par_forStartOfList, bool par_forEndOfList,
                      bool par_isInsert, bool par_isDelete, bool par_isMove,
                      StructureTypeOfMove par_structMoveType,
                      bool pbRotateLeft, bool pbRotateRight,
                      DLLAnchorItem_Deprecated<THeader>? par_anchorItem,
                      DLLAnchorCouplet<THeader>? par_anchorPair,
                      DLLOperation1D_Of<THeader>? par_operationPrior = null,
                      DLLOperation1D_Of<THeader>? par_operationNext = null)

                    : base(par_range, par_forStartOfList,
                        par_forEndOfList, par_isInsert,
                        par_isDelete, par_isMove,
                        par_structMoveType, pbRotateLeft, pbRotateRight,
                        par_anchorItem,
                        par_anchorPair, par_operationPrior, par_operationNext)
        {
            //  ---12/23/2025  bool par_IsRotateLeft, bool par_isRotateRight,
            //
            // We simply pass the arguments to the base class.
            //    (Note the base-class constructor call above, ": base(...)".)
            //
            // Added 4/10/2025 thomas downes
            //


        }


        public DLLOperation1D_2TypesInParallel(DLLOperation1D_Of<THeader> par_operation1D_Of)
                                                                  : base(par_operation1D_Of)
                                        //: base(par_operation1D_Of.DescriptionByUser,
                                        //:   par_operation1D_Of._range,
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
            this.DescriptionByUser += " (2 types in parallel)";

        }


        public DLLOperation1D_2TypesInParallel(DLLRange<THeader> par_range,
                       DLLAnchorCouplet<THeader>? par_anchorCouplet,
                       bool par_isInsert, bool par_isMove,
                       StructureTypeOfMove par_typeOfMove,
                       bool pbRotateLeft, bool pbRotateRight)

                        : base(par_range, par_anchorCouplet, par_isInsert, 
                              par_isMove, par_typeOfMove,
                              pbRotateLeft, pbRotateRight)
        {
            //
            // We simply pass the arguments to the base class.
            //    (Note the base-class constructor call above, ": base(...)".)
            //
            // Added 4/10/2025 thomas downes
            //
            // See the base-constructor call...
            //
            //      : base(par_range, par_anchorCouplet,
            //           par_isInsert, par_isMove, par_typeOfMove)
            //   

        }


        public DLLOperation1D_2TypesInParallel(DLLOperationIndexStructure par_structure,
                          THeader par_firstItem, DLLRange<THeader>? par_range = null)
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


        public DLLOperation1D_2TypesInParallel(EnumSortTypes par_enum) : base(par_enum)
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
        public DLLOperation1D_2TypesInParallel<THeader, TParallel>? GetPrior_OfOf()
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
        public DLLOperation1D_2TypesInParallel<THeader, TParallel>? GetNext_OfOf()
        {
            //
            // Added 5/25/2024 
            //
            return mod_opNext_ForRedo_OfT_OfT;

        }


        public DLLOperation1D_2TypesInParallel<THeader, TParallel>? DLL_GetOpPrior_OfOf()
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


        public DLLOperation1D_2TypesInParallel<THeader, TParallel>? DLL_GetOpNext_OfOf()
        {
            // Added 4/23/2025 & 4/10/2025 & 12/02/2024 
            //
            //  Sanity check. 
            //
            if (base.mod_opNext_ForRedo != mod_opNext_ForRedo_OfT?.GetConvertToBaseClass())
            {
                System.Diagnostics.Debugger.Break();
            }

            // Added 12/02/2024 
            //
            //  Sanity check.  (Equivalent to above.)  
            //
            if (base.mod_opNext_ForRedo != (mod_opNext_ForRedo_OfT as DLLOperationBase))
            {
                System.Diagnostics.Debugger.Break();
            }

            return mod_opNext_ForRedo_OfT_OfT;

        }


        public void DLL_SetOpNext_OfT_OfT(DLLOperation1D_2TypesInParallel<THeader, TParallel> parOperation)
        {
            //
            // Added 4/11/2025 td (from DLLOperation_Of.cs)
            //
            this.mod_opNext_ForRedo_OfT_OfT = parOperation;
            //-----this.mod_opPrior_ForUndo_OfT_OfT = parOperation;

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



        public void DLL_SetOpNext_OfT_OfT(DLLOperation1D_2TypesInParallel<THeader, TParallel> parOperation, bool pbBirectional)
        {
            //
            // Added 4/11/2025 & 12/08/2024 td
            //
            // Added 5/16/2025 td
            if (this == parOperation)
            {
                // Added 5/16/2025 td
                System.Diagnostics.Debugger.Break();
            }

            // Major call!!
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


        public void DLL_SetOpPrior_OfT_OfT(DLLOperation1D_2TypesInParallel<THeader, TParallel> parOperation)
        {
            //
            // Added 4/14/2025 thomas downes
            //
            // Added 5/16/2025 td
            if (this == parOperation)
            {
                // Added 5/16/2025 td
                System.Diagnostics.Debugger.Break();
            }

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
        public DLLOperation1D_2TypesInParallel<THeader, TParallel> // <T_DLLItem_H, T_DLLItem_V>
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

            // May2025 DLLOperation1D_Of<THeader> inverseOp_Of = base.GetInverseForUndo_Of(false);

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

            DLLOperation1D_Of<THeader> inverseOp_Of = base.GetInverseForUndo_Of(false);

            //Added 5/07/2025
            //  An inverse operation NEVER sorts by values. Reverse index-mapping is used instead.  ---5/06/2025
            bool bSortByValues = inverseOp_Of.IsSorting_ByItemValues();
            bool bSortByIndexing = inverseOp_Of.IsSorting_ByIndexMapping();
            if (bSortByValues) inverseOp_Of.SetToSortingByIndexMapping();

            var inverseOp_OfOf = new DLLOperation1D_2TypesInParallel<THeader, TParallel>(inverseOp_Of);

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



        /// <summary>
        /// This builds the integer arrays which will allow a sorting to be recorded & 
        /// then reversed to the original, prior sorting (or lack thereof).  And also 
        /// the integer array which would reverse the sorting.
        /// </summary>
        /// <param name="par_arrayOfControlsBeforeSort"></param>
        /// <param name="par_arrayOfControlsAfterSort"></param>
        /// <param name="par_arrayOfIndicesForRedo"></param>
        /// <param name="par_arrayOfIndicesForUndo"></param>
        public static void BuildMapperWithArrayIndices(TParallel[] par_arrayOfControlsBeforeSort, 
                                                 TParallel[] par_arrayOfControlsAfterSort,
                                                 out int[] par_arrayOfIndicesForRedo,
                                                 out int[] par_arrayOfIndicesForUndo)
        {
            //
            // Added 4/24/2025 td
            //
            TParallel[] array_Before = par_arrayOfControlsBeforeSort;
            TParallel[] array_After = par_arrayOfControlsAfterSort;

            // ----Direction: REDO (Before, After) --------
            // Build the mapping array of indices for ----REDO----
            BuildMapperWithArrayIndices(array_Before, array_After,
                                        out par_arrayOfIndicesForRedo);

            // ----Direction: UNDO (After, Before) --------
            // Build the mapping array of indices for ----UNDO----
            BuildMapperWithArrayIndices(array_After, array_Before,
                            out par_arrayOfIndicesForUndo);


        }


        private static void BuildMapperWithArrayIndices(TParallel[] par_arrayOfControlsBeforeSort,
                                                 TParallel[] par_arrayOfControlsAfterSort,
                                                 out int[] par_arrayOfIndicesToRecordSort)
        {
            //
            // Added 4/24/2025 td
            //
            int[] result_arrayOfIndices = new int[-1 + par_arrayOfControlsAfterSort.Length];
            int index_base0 = 0;
            int each_index_final;
            TParallel[] array_Before = par_arrayOfControlsBeforeSort;
            TParallel[] array_After = par_arrayOfControlsAfterSort;

            foreach (TParallel each_control in par_arrayOfControlsBeforeSort)
            {
                bool bFound = array_After.Contains(each_control);
                if (bFound)
                {
                    // Major call!!
                    each_index_final = Array.FindIndex(array_After, item => item == each_control);
                    result_arrayOfIndices[index_base0] = each_index_final;
                }
                else 
                {
                    System.Diagnostics.Debugger.Break();
                }
                index_base0++;
            }

            par_arrayOfIndicesToRecordSort = result_arrayOfIndices;

        }


        public override int DLL_CountAllOpsInTheList()
        {
            //
            // Added 6/24/2025 thomas downes  
            //
            int result_count = 0;

            // Please note, "After" and "Next" are synonyms.  
            //    So, "2 comes after 1" and "2 is the next number after 1"
            //    means the same thing. 
            //
            //DLLOperation1D_2TypesInParallel<THeader, TParallel>? each_operation = DLL_GetOpFirstInList()
            //    as DLLOperation1D_2TypesInParallel<THeader, TParallel>;
            DLLOperationBase? each_operation = DLL_GetOpFirstInList()
                as DLLOperation1D_2TypesInParallel<THeader, TParallel>;

            while (each_operation != null)
            {
                result_count++;
                each_operation = each_operation.DLL_GetOpNext();
            }
            return result_count;


        }





    }


}
