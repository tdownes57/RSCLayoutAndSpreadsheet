﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using ciBadgeInterfaces;  //Added 6/20/2024  

namespace RSCLibraryDLLOperations
{
    //
    // Added 10/12/2024 Thomas C. Downes
    //
    //    1D = 1 dimension, simply a list
    //            (versus a 2-dimensional grid)
    //
    //    Example...
    //       T_DLL : RSCDataRowHeader  
    //       T_DLLParallel: RSCDataColumn
    //           (parallel to the RowHeaders)
    //
    // March 2025 public class DLLOperationsManager1D<T_DLL>
    //                where T_DLL : class, IDoublyLinkedItem<T_DLL>
    //
    public class DLLOperationsManager1D<T_DLL, T_DLLParallel>
        where T_DLL : class, IDoublyLinkedItem<T_DLL>
        where T_DLLParallel : class, IDoublyLinkedItem<T_DLLParallel>
    {
        //    1D = 1 dimension, simply a list
        //            (versus a 2-dimensional grid)
        //
        private T_DLL? mod_firstItem;
        private T_DLL? mod_endingItem;
        private DLLList<T_DLL> mod_list;

        //private DLLOperation1D<T_DLL> mod_firstPriorOperation1D;
        //private DLLOperation1D<T_DLL> mod_lastPriorOperation1D;
        private DLLOperation1D_2TypesInParallel<T_DLL, T_DLLParallel>? mod_firstPriorOperation1D;
        private DLLOperation1D_2TypesInParallel<T_DLL, T_DLLParallel>? mod_lastPriorOperation1D;

        /// <summary>
        /// Allows an operation to be propagated to an array of parallel lists. For example, if the 
        /// operation delete the first item in the main list, the first item in each list of an array of 
        /// similar lists can be deleted.  This would allow a user to delete the first row in a 
        /// spreadsheet, for example. 
        /// </summary>
        private DLLList<T_DLLParallel>[]? mod_arrayOfParallelLists;

        /// <summary>
        /// Allows an INSERT operation to be propagated to an array of parallel lists. For example, if 
        /// the operation is an INSERT of 5 new items in the first item in the main list, we need to 
        /// insert five(5) new items in each list of an array of similar lists.  This would allow 
        /// a user to insert 5 new rows at any row-index location in a spreadsheet. 
        /// </summary>
        private DLLRange<T_DLLParallel>[]? mod_arrayOfParallelRangesToInsert;

        /// <summary>
        /// Records an DELETE operation executed to an array of parallel lists. For example, if 
        /// the operation is an DELETE of 5 new items in the first item in the main list, we need to 
        /// delete five(5) new items in each list of an array of similar lists.  This would allow 
        /// a user to insert 5 new rows at any row-index location in a spreadsheet. 
        /// </summary>
        private DLLRange<T_DLLParallel>[]? mod_arrayOfParallelRangesToDelete;

        //
        // As illustration of the moveable, user-controlled undo-redo marker:
        //                                               <----------------------------------->
        //                                               <----- Undo-Redo Marker ------------>
        //  List of recorded operations:                 <----------------------------------->
        //      o1_OperationInsert,  o2_OperationDelete, o3_OperationMove,  o4_OperationInsert, o5_OperationDelete, o6_OperationInsert
        //                                               <----------------||----------------->
        //                                               <---Undo-button--||-- Redo button--->
        //                                               <----------------||----------------->
        //
        //
        //April 2025 private DLLOpsUndoRedoMarker1D<T_DLL>
        //    mod_opUndoRedoMarker;  // new DLLOperationsRedoMarker1D<T_DLL>(); // As r ''Added 1/24/2024
        private DLLOpsUndoRedoMarker1DParallel<T_DLL, T_DLLParallel>
            mod_opUndoRedoMarker;  // new DLLOperationsRedoMarker1D<T_DLL>(); // As r ''Added 1/24/2024

        private int mod_intCountOperations = 0; // As Integer = 0 ''Added 1/24/2024 td


        //
        // Added 10/20/2024 
        //
        public DLLOperationsManager1D(T_DLL par_firstItem,
            DLLList<T_DLL> par_list,
            DLLOperation1D_2TypesInParallel<T_DLL, T_DLLParallel>? par_firstPriorOperationV1 = null)
        {
            this.mod_firstItem = par_firstItem;
            this.mod_list = par_list;

            if (par_firstPriorOperationV1 == null) // Added 4/11/2025 
            {

                // Added 4/11/2025 
                mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1DParallel<T_DLL, T_DLLParallel>();

            }

            else
            {
                this.mod_firstPriorOperation1D = par_firstPriorOperationV1;
                this.mod_lastPriorOperation1D = par_firstPriorOperationV1;

                const bool IS_CONSTRUCTOR = true;

                mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1DParallel<T_DLL, T_DLLParallel>
                    (par_firstPriorOperationV1, IS_CONSTRUCTOR);
                mod_intCountOperations++; // Added 10/26/2024 td 

            }

            //mod_intCountOperations++; // Added 10/26/2024 td 
            // this.mod_lastPriorOperationV1 = mod_lastPriorOperationV1;
            // this.mod_opRedoMarker = mod_opRedoMarker;
            // this.mod_intCountOperations = mod_intCountOperations;
            // April 2025  mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1D<T_DLL>(par_firstPriorOperationV1);


        }


        public DLLOperationsManager1D(T_DLL par_firstItem,
                                     DLLList<T_DLL> par_list)
        {
            this.mod_firstItem = par_firstItem;
            this.mod_list = par_list;

            //---this.mod_firstPriorOperation1D = par_firstPriorOperationV1;
            //---this.mod_lastPriorOperation1D = par_firstPriorOperationV1;
            //---mod_intCountOperations++; // Added 10/26/2024 td 

            // this.mod_lastPriorOperationV1 = mod_lastPriorOperationV1;
            // this.mod_opRedoMarker = mod_opRedoMarker;
            // this.mod_intCountOperations = mod_intCountOperations;
            //---mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_DLL>(par_firstPriorOperationV1);
            //April 2025  mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1D<T_DLL>();
            mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1DParallel<T_DLL, T_DLLParallel>();

        }


        public T_DLL GetFirstItem()
        {
            return mod_firstItem;
        }


        public int CountOfOperations()
        {
            //
            //  Added 10/13/2024 
            //
            int intCountOps_method1 = mod_firstItem.DLL_CountItemsAllInList();
            int intCountOps_method2 = mod_intCountOperations;
            if (intCountOps_method1 != intCountOps_method2)
            {
                Debugger.Break();
            }
            return intCountOps_method1;

        }


        public int CountOfOperations_QueuedForRedo()
        {
            //
            //  Added 10/13/2024 
            //
            int countOpsToRedo = mod_opUndoRedoMarker.CountsOpsToRedo();
            return (countOpsToRedo);

        }


        public bool AreOneOrMoreOpsToRedo_PerMarker()
        {
            //
            // Added 12/01/2024 thomas downes
            //
            int countOpsToRedo = mod_opUndoRedoMarker.CountsOpsToRedo();
            return (countOpsToRedo > 0);

        }


        public bool MarkerHasOperationPrior_Undo()
        {
            //
            // Suffixed with _Undo on 12/8/2024 td.
            //
            //---May2025---bool result_hasPrior = mod_opUndoRedoMarker.HasOperationPrior();
            bool result_hasPrior = mod_opUndoRedoMarker.HasOperationPrior_ForUndo();
            return result_hasPrior;
        }


        public bool MarkerHasOperationNext_Redo()
        {
            //
            // Suffixed with _Redo on 12/8/2024 td.
            //
            //bool result_hasNext = mod_opRedoMarker.HasOperationNext();
            //---May2025---bool result_hasNext = mod_opUndoRedoMarker.HasOperationNext();
            bool result_hasNext = mod_opUndoRedoMarker.HasOperationNext_ForRedo();
            return result_hasNext;

        }


        public int HowManyOpsAreRecorded()
        {
            //
            // Added 11/29/2024 Thomas Dwones, oops sorry it's a typo, Downes
            //
            mod_intCountOperations = (1 + mod_firstPriorOperation1D.DLL_CountOpsAfter());
            return mod_intCountOperations;

        }


        public void ExecuteOperation_AnyType(DLLOperation1D_Of<T_DLL> parOperation,
                           bool par_changeOfEndpoint_Expected,
                           out bool par_changeOfEndpoint_Occurred,
                           bool pbOperationIsNewSoRecordIt,
                           DLLOperationIndexStructure parOperationIndexed)
        {
            // Added 1/15/2024
            //
            //   This is an "alias" method.  It exists in case the programmer(s) 
            //   forget the name of the function. 
            //
            //Mar2025 ProcessOperation_AnyType(parOperation, 
            //    par_changeOfEndpoint_Expected, 
            //    out par_changeOfEndpoint_Occurred, 
            //    pbOperationIsNewSoRecordIt);
            ProcessOperation_AnyType(parOperation,
                par_changeOfEndpoint_Expected,
                out par_changeOfEndpoint_Occurred,
                pbOperationIsNewSoRecordIt, parOperationIndexed);

        }


        public void ProcessOperation_PrimaryAndParallel(DLLOperation1D_2TypesInParallel<T_DLL, T_DLLParallel> parOperation,
                       bool par_changeOfEndpoint_Expected,
                       out bool par_changeOfEndpoint_Occurred,
                       bool pbOperationIsNewSoRecordIt,
                       DLLOperationIndexStructure parOperationIndexed,
                       bool pbOnlyExecuteToPrimaryList)
        {
            // Added 1/15/2024

            DLLRange<T_DLLParallel>[]? array_of_insertRangesParallel;
            //array_of_insertRangesParallel = parOperation.ArrayOfParallelRanges_ToInsert;
            array_of_insertRangesParallel = parOperation.GetArrayOfParallelRanges_ToInsert();

            //
            // Major call!! 
            //
            ProcessOperation_AnyType(parOperation, par_changeOfEndpoint_Expected,
                out par_changeOfEndpoint_Occurred, pbOperationIsNewSoRecordIt,
                parOperationIndexed, pbOnlyExecuteToPrimaryList);

            // Added 12/03/2024 thomas 
            //    
            bool bUserRequestedUndoOrRedo = (!pbOperationIsNewSoRecordIt); // (!par_bRecordOperation); 

            //    //     // Added 1/01/2024
            if (bUserRequestedUndoOrRedo)
            {
                //
                // We've processed the "Undo" or "Redo" already.
                //
                // (See "parOperation.OperateOnList(...)" above.) 
                //
                // Other than moving the UndoRedo marker one way or another,
                //   we don't need to play any woodland games with the 
                //   "branching".
                //

            }
            else if (pbOperationIsNewSoRecordIt)
            {
                //
                //  RecordNewestOperation(operation);
                //
                //mod_lastPriorOperation1D = parOperation;
                if (mod_firstPriorOperation1D == null)
                {
                    mod_firstPriorOperation1D = parOperation;
                    mod_firstPriorOperation1D.DLL_MarkStartOfList(); // Added 5/18/2025 thomas d

                    mod_lastPriorOperation1D = parOperation;
                    // Added 12/04/2024
                    // April2025  mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1D<T_DLL>(parOperation);
                    mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1DParallel<T_DLL, T_DLLParallel>(parOperation, false);

                }

                else
                {
                    //
                    // First, we must clear any pending "Redo" operations. 
                    //
                    if (mod_opUndoRedoMarker.HasOperationNext_ForRedo())
                    {
                        //
                        // DIFFICULT AND CONFUSING -- We must "clean"/remove any Redo operations.
                        //
                        //    Logically speaking, any pending Redo operations must be deleted/cleared.
                        //
                        // Apr2025  mod_lastPriorOperation1D = mod_opUndoRedoMarker.GetCurrentOp_Undo();
                        mod_lastPriorOperation1D = mod_opUndoRedoMarker.GetCurrentOp_Undo_OfOf();
                        mod_lastPriorOperation1D?.DLL_ClearOpNext();
                        mod_opUndoRedoMarker.ClearPendingRedoOperation();

                    }

                    // Connect the operations in a doubly-linked list. 
                    //---parOperation.DLL_SetOpPrior(mod_lastPriorOperation1D);
                    parOperation.DLL_SetOpPrior_OfT(mod_lastPriorOperation1D);

                    //---mod_lastPriorOperation1D.DLL_SetOpNext(parOperation);
                    mod_lastPriorOperation1D?.DLL_SetOpNext_OfT_OfT(parOperation);

                    var temp_priorOp = mod_lastPriorOperation1D;
                    //mod_lastPriorOperation1D = parOperation;
                    //mod_opRedoMarker = new DLLOperationsRedoMarker1D<T_DLL>(temp_priorOp, parOperation);
                    mod_lastPriorOperation1D = parOperation;

                    //
                    //  Major call!!
                    //
                    //April2025  mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1D<T_DLL>(parOperation);
                    mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1DParallel<T_DLL, T_DLLParallel>(parOperation, false);

                    // Added 12/01/2028
                    //----mod_lastPriorOperation1D.DLL_SetOpPrior(temp_priorOp); // Added 12/01/2024 
                    if (temp_priorOp != null)
                    {
                        mod_lastPriorOperation1D.DLL_SetOpPrior_OfT(temp_priorOp); // Added 12/01/2024 
                    }

                    //
                    // DIFFICULT & CONFUSING -- Connect the first operation to this one, if needed.
                    //
                    if (mod_firstPriorOperation1D.DLL_MissingOpNext())
                    {
                        //---mod_firstPriorOperation1D.DLL_SetOpNext(parOperation);
                        mod_firstPriorOperation1D.DLL_SetOpNext_OfT_OfT(parOperation);
                    }

                    //
                    // Testing!!  
                    //
                    int intCountOfPriorOps;
                    int intCountOfPriorOps_PlusItself;
                    intCountOfPriorOps = (mod_lastPriorOperation1D.DLL_CountOpsBefore());
                    intCountOfPriorOps_PlusItself = (intCountOfPriorOps + 1); // We must count the operation itself !!!!!



                }


            }

        }


        public void ProcessOperation_AnyType(DLLOperation1D_Of<T_DLL> parOperation,
                               bool par_changeOfEndpoint_Expected,
                               out bool par_changeOfEndpoint_Occurred,
                               bool pbOperationIsNewSoRecordIt,
                               DLLOperationIndexStructure parOperationIndexed, 
                               bool pbOnlyExecuteOnPrimaryList = false)
        {
            // Added 1/15/2024

            //if (parOperation.IsHorizontal()) parOperation.OperateOnList(mod_listHoriz, par_changeOfEndpoint);
            //if (parOperation.IsVertical()) parOperation.OperateOnList(mod_listVerti, par_changeOfEndpoint);

            //-------------------------------------------------------------------
            //
            //------------- Major call!! (for main/primary list) -------------------
            //
            //-------------------------------------------------------------------
            //
            parOperation.OperateOnList(mod_list, true, par_changeOfEndpoint_Expected,
                  out par_changeOfEndpoint_Occurred);


            //-------------------------------------------------------------------
            //
            // Administrative work. 
            //     Needed for sorting to occur on parallel lists (if any).
            //     ---4/29/2025 td
            //-------------------------------------------------------------------
            //
            if (parOperationIndexed.Sorting_ByArrayIndexMapping)
            {
                if (parOperationIndexed.ArrayOfIndicesToSort_Redo == null)
                {
                    if (parOperation._arrayIndices_SortOrderRedoThisOp != null)
                    {
                        // Copy the array of index-mapping (for sorting)
                        parOperationIndexed.ArrayOfIndicesToSort_Redo =
                            parOperation._arrayIndices_SortOrderRedoThisOp;
                        // Added 4/30/2025
                        parOperationIndexed.ArrayOfIndicesToSort_Undo =
                            parOperation._arrayIndices_SortOrderIfUndo;
                    }
                }
            }

            //-------------------------------------------------------------------
            //
            //------------- Major call!! (for parallel lists) -------------------
            //
            //-------------------------------------------------------------------
            //
            //  Propagate operation to parallel lists, if any exist. 
            //
            bool pbProceedToParallelLists = !pbOnlyExecuteOnPrimaryList;

            if (pbProceedToParallelLists)  // Added 5/18/2025 td
            {
                //
                // Process an index-only version of the operation,
                //   executed to the array of parallel lists. 
                //
                ProcessOperation_ToArrayOfParallelLists(parOperationIndexed,
                      par_changeOfEndpoint_Expected,
                      ref par_changeOfEndpoint_Occurred);
            }

            //// Added 4/08/2025 td
            //foreach (var each_list in mod_arrayOfParallelLists)
            //{;
            //    T_DLLParallel each_1stParallelItem = each_list.DLL_GetFirstItem_OfT();

            //    DLLOperation1D<T_DLLParallel> each_operation = new DLLOperation1D<T_DLLParallel>
            //        (parOperationIndicized, each_1stParallelItem);

            //    bool bChangeOfEndpointInFact = false;

            //    each_operation.OperateOnList(each_list, true, par_changeOfEndpoint_Expected,
            //        out bChangeOfEndpointInFact);

            //    par_changeOfEndpoint_Occurred |= bChangeOfEndpointInFact;

            //}

            // Added 3/25/2025 td
            parOperation.ExecutionDate = DateTime.Now;

            //
            // Administration needed!!
            //
            mod_firstItem = mod_list._itemStart;
            mod_endingItem = mod_list._itemEnding;

            // Added 6/5/2025 td
            if (mod_list._itemStart == null && (! mod_list._isEmpty_OrTreatAsEmpty))
            {
                System.Diagnostics.Debugger.Break();
                mod_list._isEmpty_OrTreatAsEmpty = true;
            }

            // Added 12/03/2024 thomas 
            //    
            bool bUserRequestedUndoOrRedo = (!pbOperationIsNewSoRecordIt); // (!par_bRecordOperation); 

            //    //     // Added 1/01/2024
            if (bUserRequestedUndoOrRedo)
            {
                //
                // We've processed the "Undo" or "Redo" already.
                //
                // (See "parOperation.OperateOnList(...)" above.) 
                //
                // Other than moving the UndoRedo marker one way or another,
                //   we don't need to play any woodland games with the 
                //   "branching".
                //

            }
            else if (pbOperationIsNewSoRecordIt)
            {
                //
                //  RecordNewestOperation(operation);
                //
                //---mod_lastPriorOperation1D = parOperation;
                //
                RecordNewestOperation(parOperation);


            } 
        
        }


        /// <summary>
        /// Process an operation which must take place upon one of the columns of data ("parallel lists")
        ///   first, prior to executing a parallel operation on the other parallel lists.
        ///   (To my knowledge, such an operation is a sort-by-item-values operation (i.e. sorting by 
        ///   the data-cell contents (textbox.text), as the cell values are unique to each 
        ///   parallel list (i.e. each spreadsheet column.)
        ///   (Whether or not the operation must be execution upon the primary lists (the spreadsheet's
        ///   row headers) is another matter.)
        /// </summary>
        /// <param name="parOperation"></param>
        /// <param name="par_listParallel"></param>
        /// <param name="par_changeOfEndpoint_Expected"></param>
        /// <param name="par_changeOfEndpoint_Occurred"></param>
        /// <param name="pbOperationIsNewSoRecordIt"></param>
        /// <param name="parOperationIndexed"></param>
        public void ProcessOperation_ToParallelList(DLLList<T_DLLParallel> par_listParallelToProcessFirst, 
                       DLLOperation1D_Of<T_DLLParallel> parOperation,
                       bool par_changeOfEndpoint_Expected,
                       out bool par_changeOfEndpoint_Occurred,
                       bool pbOperationIsNewSoRecordIt,
                       DLLOperationIndexStructure parOperationIndexed, 
                       bool pbSortPrimaryListAfterParallels) 
        {
            //
            // For sorting parallel lists.  (Mostly for sorting.)
            //
            // Added 5/06/2025 and 1/15/2024
            //

            //-------------------------------------------------------------------
            //
            //------------- Major call!! (for main/primary list) -------------------
            //
            //-------------------------------------------------------------------
            //
            parOperation.OperateOnList(par_listParallelToProcessFirst, true, 
                  par_changeOfEndpoint_Expected,
                  out par_changeOfEndpoint_Occurred);


            //-------------------------------------------------------------------
            //
            // Administrative work. 
            //     Needed for sorting to occur on parallel lists (if any).
            //     ---4/29/2025 td
            //-------------------------------------------------------------------
            //
            if (parOperationIndexed.Sorting_ByArrayIndexMapping)
            {
                if (parOperationIndexed.ArrayOfIndicesToSort_Redo == null)
                {
                    if (parOperation._arrayIndices_SortOrderRedoThisOp != null)
                    {
                        // Copy the array of index-mapping (for sorting)
                        parOperationIndexed.ArrayOfIndicesToSort_Redo =
                            parOperation._arrayIndices_SortOrderRedoThisOp;
                        // Added 4/30/2025
                        parOperationIndexed.ArrayOfIndicesToSort_Undo =
                            parOperation._arrayIndices_SortOrderIfUndo;

                    }
                }
            }

            //-------------------------------------------------------------------
            //
            //------------- Major call!! (for parallel lists) -------------------
            //
            //-------------------------------------------------------------------
            //
            var list_whichWasAlreadySorted = par_listParallelToProcessFirst;

            //  Propagate operation to parallel lists, if any exist. 
            //
            ProcessOperation_ToArrayOfParallelLists(parOperationIndexed,
                  par_changeOfEndpoint_Expected,
                  ref par_changeOfEndpoint_Occurred, 
                  list_whichWasAlreadySorted);


            //----------------------------------------------------------------------------
            //
            //------------- Major call!! (for primary list) --May2025  -------------------
            //
            //----------------------------------------------------------------------------
            if (pbSortPrimaryListAfterParallels)
            {
                //
                // Added 5/18/2025 td
                //
                var operationFromIndex = new DLLOperation1D_Of<T_DLL>(parOperationIndexed, mod_firstItem);

                const bool ONLY_PROCESS_PRIMARY_LIST = true;

                ProcessOperation_AnyType(operationFromIndex, par_changeOfEndpoint_Expected,
                         out par_changeOfEndpoint_Occurred, false, parOperationIndexed, 
                         ONLY_PROCESS_PRIMARY_LIST);

            }

            //// Added 4/08/2025 td
            //foreach (var each_list in mod_arrayOfParallelLists)
            //{;
            //    T_DLLParallel each_1stParallelItem = each_list.DLL_GetFirstItem_OfT();

            //    DLLOperation1D<T_DLLParallel> each_operation = new DLLOperation1D<T_DLLParallel>
            //        (parOperationIndicized, each_1stParallelItem);

            //    bool bChangeOfEndpointInFact = false;

            //    each_operation.OperateOnList(each_list, true, par_changeOfEndpoint_Expected,
            //        out bChangeOfEndpointInFact);

            //    par_changeOfEndpoint_Occurred |= bChangeOfEndpointInFact;

            //}

            // Added 3/25/2025 td
            parOperation.ExecutionDate = DateTime.Now;

            //
            // Administration needed!!
            //
            mod_firstItem = mod_list._itemStart;
            mod_endingItem = mod_list._itemEnding;

            // Added 12/03/2024 thomas 
            //    
            bool bUserRequestedUndoOrRedo = (!pbOperationIsNewSoRecordIt); // (!par_bRecordOperation); 

            //    //     // Added 1/01/2024
            if (bUserRequestedUndoOrRedo)
            {
                //
                // We've processed the "Undo" or "Redo" already.
                //
                // (See "parOperation.OperateOnList(...)" above.) 
                //
                // Other than moving the UndoRedo marker one way or another,
                //   we don't need to play any woodland games with the 
                //   "branching".
                //

            }
            else if (pbOperationIsNewSoRecordIt)
            {
                //
                //  RecordNewestOperation(operation);
                //
                //---mod_lastPriorOperation1D = parOperation;
                //
                DLLOperation1D_Of<T_DLL> operationT_DLL = new DLLOperation1D_Of<T_DLL>(parOperationIndexed,
                     mod_list.DLL_GetFirstItem_OfT()); 

                //RecordNewestOperation<T_DLL>(operationT_DLL);
                RecordNewestOperation(operationT_DLL);

            }

        }



        private void RecordNewestOperation(DLLOperation1D_Of<T_DLL> parOperation)
        //    private void RecordNewestOperation(DLLOperation1D_Of<T_Control> parOperation)
        // where TControl: class, IDoublyLinkedItem<TControl>
        {
            //
            // Encapsulated 5/06/2025 Thomas Downes  
            //
            //---var operation1D_OfT_OfT = new DLLOperation1D_OfOf<T_DLL, T_DLLParallel>(parOperation);
            //---var operation1D_OfT_OfT = new DLLOperation1D_OfOf<TControl, T_DLLParallel>(parOperation);
            var operation1D_OfT_OfT = new DLLOperation1D_2TypesInParallel<T_DLL, T_DLLParallel>(parOperation);

            //Added 4/14/2025 td
            bool boolInserted = parOperation._isInsert;
            bool boolDeleted = parOperation._isDelete;

            //Added 4/14/2025 td
            //if (boolInserted) operation1D_OfT_OfT.ArrayOfParallelRanges_ToInsert = mod_arrayOfParallelRangesToInsert;
            //if (boolDeleted) operation1D_OfT_OfT.ArrayOfParallelRanges_Deleted = mod_arrayOfParallelRangesToDelete;
            if (boolInserted) operation1D_OfT_OfT.SetArrayOfParallelRanges_ToInsert(mod_arrayOfParallelRangesToInsert);
            if (boolDeleted) operation1D_OfT_OfT.SetArrayOfParallelRanges_Deleted(mod_arrayOfParallelRangesToDelete);

            //
            // Record the user's first operation a bit differently from an operation that is following other
            //  operation(s). 
            //
            if (mod_firstPriorOperation1D == null)
            {
                //mod_firstPriorOperation1D = parOperation;
                //mod_lastPriorOperation1D = parOperation;
                //Apr2025 mod_firstPriorOperation1D = new DLLOperation1D_OfOf<T_DLL, T_DLLParallel>(parOperation);

                parOperation.DLL_MarkStartOfList(); // Mark the parameter operation (needed!). --Added 4/18/2025
                mod_firstPriorOperation1D = operation1D_OfT_OfT;
                mod_firstPriorOperation1D.DLL_MarkStartOfList(); // Added 4/18/2025 td

                //mod_lastPriorOperation1D = new DLLOperation1D_OfOf<T_DLL, T_DLLParallel>(parOperation);
                if (mod_lastPriorOperation1D != null) System.Diagnostics.Debugger.Break();
                mod_lastPriorOperation1D = mod_firstPriorOperation1D; //Normal if there is only one(1) operation.
                mod_lastPriorOperation1D.DLL_MarkEndOfList(); // Added 4/18/2025
                // Somewhat surprisingly, we also have to call the same method
                //    on the parameter operation.---4/2025
                parOperation.DLL_MarkEndOfList(); // Added 4/18/2025

                // Added 12/04/2024
                //
                //April 2025  mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1D<T_DLL>(parOperation);
                mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1DParallel<T_DLL, T_DLLParallel>(mod_firstPriorOperation1D, false);

            }

            else
            {
                // Record the user's 2nd (& 3rd & 57th) operation a bit differently from an operation that is
                //   the very first operation(s). 
                //
                // First, we must clear any pending "Redo" operations. 
                //
                if (mod_opUndoRedoMarker.HasOperationNext_ForRedo())
                {
                    //
                    // DIFFICULT AND CONFUSING -- We must "clean"/remove any Redo operations.
                    //
                    //  Logically speaking, any pending Redo operations must be deleted/cleared.
                    //
                    //April2025  mod_lastPriorOperation1D = mod_opUndoRedoMarker.GetCurrentOp_Undo();
                    mod_lastPriorOperation1D = mod_opUndoRedoMarker.GetCurrentOp_Undo_OfOf();
                    mod_lastPriorOperation1D?.DLL_ClearOpNext();
                    mod_opUndoRedoMarker.ClearPendingRedoOperation();

                }

                //---May2025---else 
                else if (mod_opUndoRedoMarker.HasOperationPrior_ForUndo())
                {
                    // Added 4/14/2025 
                    if (mod_lastPriorOperation1D == null) System.Diagnostics.Debugger.Break();
                    if (mod_lastPriorOperation1D == null) throw new Exception("There should be a recorded last op.");
                }

                // Connect the operations in a doubly-linked list. 
                //---parOperation.DLL_SetOpPrior(mod_lastPriorOperation1D);
                //April2025 parOperation.DLL_SetOpPrior_OfT(mod_lastPriorOperation1D);
                //April2025 parOperation.DLL_SetOpPrior_OfT(mod_lastPriorOperation1D);

                if (mod_lastPriorOperation1D != null) // Added 5/16/2025 td
                {
                    operation1D_OfT_OfT.DLL_SetOpPrior_OfT_OfT(mod_lastPriorOperation1D);
                    // Somewhat surprisingly, we also have to call the same method
                    //    on the parameter operation.---4/2025
                    parOperation.DLL_SetOpPrior_OfT(mod_lastPriorOperation1D); // Added 4/20/2025
                }

                //---mod_lastPriorOperation1D.DLL_SetOpNext(parOperation);
                //April 2025  mod_lastPriorOperation1D.DLL_SetOpNext_OfT(parOperation);
                if (mod_lastPriorOperation1D == null)
                {
                    // Added 4/23/2025
                    mod_lastPriorOperation1D = operation1D_OfT_OfT;
                    if (mod_firstPriorOperation1D == null) mod_firstPriorOperation1D = operation1D_OfT_OfT;
                }
                else
                {
                    mod_lastPriorOperation1D.DLL_SetOpNext_OfT_OfT(operation1D_OfT_OfT);
                }

                var temp_priorOp = mod_lastPriorOperation1D;
                //mod_lastPriorOperation1D = parOperation;
                //mod_opRedoMarker = new DLLOperationsRedoMarker1D<T_DLL>(temp_priorOp, parOperation);
                //April2025  mod_lastPriorOperation1D = parOperation;
                //mod_lastPriorOperation1D = new DLLOperation1D_OfOf<T_DLL, T_DLLParallel>(parOperation);
                mod_lastPriorOperation1D = operation1D_OfT_OfT;
                mod_lastPriorOperation1D.DLL_MarkEndOfList();  // Added 4/18/2025
                // Somewhat surprisingly, we also have to call the same method
                //    on the parameter operation.---4/2025
                parOperation.DLL_MarkEndOfList(); // Added 4/20/2025 td

                //
                //  Major call!!
                //
                //April 2025  mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1D<T_DLL>(parOperation);
                mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1DParallel<T_DLL,
                    T_DLLParallel>(mod_lastPriorOperation1D, false);

                // Added 12/01/2028
                //----mod_lastPriorOperation1D.DLL_SetOpPrior(temp_priorOp); // Added 12/01/2024 
                if (temp_priorOp != null)
                {
                    if (mod_lastPriorOperation1D == temp_priorOp) //Added 5/17/2025
                    {
                        //System.Diagnostics.Debugger.Break();  //Added 5/17/2025
                    }
                    else mod_lastPriorOperation1D.DLL_SetOpPrior_OfT(temp_priorOp); // Added 12/01/2024 
                }

                //
                // DIFFICULT & CONFUSING -- Connect the first operation to this one, if needed.
                //
                if (mod_firstPriorOperation1D.DLL_MissingOpNext())
                {
                    //---mod_firstPriorOperation1D.DLL_SetOpNext(parOperation);
                    //--mod_firstPriorOperation1D.DLL_SetOpNext_OfT(parOperation);
                    if (operation1D_OfT_OfT != null && 
                        operation1D_OfT_OfT != mod_firstPriorOperation1D) //Added 5/17/2025 
                    {
                        //Modified 5/17/2025 
                        mod_firstPriorOperation1D.DLL_SetOpNext_OfT_OfT(operation1D_OfT_OfT);
                    }
                }

                //
                // Added 5/21/2025
                //
                mod_firstPriorOperation1D.DLL_MarkStartOfList();
                mod_lastPriorOperation1D.DLL_MarkEndOfList();

                //
                // Testing!!  
                //
                int intCountOfPriorOps;
                int intCountOfPriorOps_PlusItself;
                intCountOfPriorOps = (mod_lastPriorOperation1D.DLL_CountOpsBefore());
                intCountOfPriorOps_PlusItself = (intCountOfPriorOps + 1); // We must count the operation itself !!!!!

            }

        }


        public void RedoMarkedOperation(ref bool pbEndpointAffected, bool pbTestingIndexStructure) // (bool pbIsHoriz, bool pbIsVerti)
        {
            //DLLOperation1D_Of<T_DLL>  // <T_DLLHor, T_DLLVer>
            //    opReDo_Of = mod_opUndoRedoMarker.GetMarkersNext_ShiftPositionRight();
            DLLOperation1D_2TypesInParallel<T_DLL, T_DLLParallel>  // <T_DLLHor, T_DLLVer>
                opReDo_OfOf = mod_opUndoRedoMarker.GetCurrentOp_Redo_OfOf();

            //Added 4/23/2025 td
            mod_arrayOfParallelRangesToDelete = opReDo_OfOf.GetArrayOfParallelRanges_Deleted();
            mod_arrayOfParallelRangesToInsert = opReDo_OfOf.GetArrayOfParallelRanges_ToInsert();

            //Added 5.25.2024
            //bool bIsChangeOfEndpoint = opReDo.IsChangeOfEndpoint();
            bool bChangeOfEndpoint_Expected = opReDo_OfOf.IsChangeOfEndpoint();
            bool bChangeOfEndpoint_Occurred = false; // Added 12/15/2024 td

            const bool RECORD_OPERATION = false; // Not needed for REDO operations

            //opReDo.CreatedAsRedoOperation = true;
            //Mar2025 ProcessOperation_AnyType(opReDo, bChangeOfEndpoint_Expected, 
            //    out bChangeOfEndpoint_Occurred, RECORD_OPERATION); // , pbIsHoriz, pbIsVerti);
            ProcessOperation_AnyType(opReDo_OfOf, bChangeOfEndpoint_Expected,
                out bChangeOfEndpoint_Occurred, RECORD_OPERATION,
                opReDo_OfOf.GetOperationIndexStructure(false, true)); // , pbIsHoriz, pbIsVerti);

            // Added 4/23/2025
            mod_opUndoRedoMarker.ShiftMarkerRight_AfterRedo_ToNext();
            pbEndpointAffected = bChangeOfEndpoint_Occurred; // Added 4/23/2025

        }


        public void UndoMarkedOperation(ref bool pbEndpointAffected, bool pbTestingIndexStructure)
        {
            //Nov10 2024 ''UndoOfPriorOperation_AnyType();
            UndoOfPriorOperation_AnyType(ref pbEndpointAffected, pbTestingIndexStructure);

        }


        public void ClearAllRecordedOperations()
        {
            //
            // Added 12/04/2024 th..omas do..wnes  
            //
            mod_firstPriorOperation1D = null;
            mod_lastPriorOperation1D = null;
            mod_opUndoRedoMarker.ClearAllOperations();
            mod_intCountOperations = 0;

        }


        public void ClearAnyRedoOperations_IfQueued()
        {
            //
            // Added 12/8/2024 thomas downes
            //
            // As illustration of the moveable, user-controlled undo-redo marker:
            //                                               <----------------------------------->
            //                                               <----- Undo-Redo Marker ------------>
            //  List of recorded operations:                 <----------------------------------->
            //      o1_OperationInsert,  o2_OperationDelete, o3_OperationMove,  o4_OperationInsert, o5_OperationDelete, o6_OperationInsert
            //                                               <----------------||----------------->
            //                                               <---Undo-button--||-- Redo button--->
            //                                               <----------------||----------------->
            //
            //  The operations which will be deleted, are as follows: 
            //
            //       o3_OperationInsert, o4_OperationDelete, o5_OperationInsert
            //
            bool bMustRemoveOneOrMoreOpsQueuedForRedo;  // Added 5/18/2025 thomas d.
            // Added 5/18/2025 thomas d.
            bMustRemoveOneOrMoreOpsQueuedForRedo = this.MarkerHasOperationNext_Redo();

            // if (this.MarkerHasOperationNext_Redo())
            if (bMustRemoveOneOrMoreOpsQueuedForRedo)
            {
                //
                // Let's remove the operations that are slated for "Redo", so they are
                //   no longer part of the chain of consecutively executed operations.
                //
                //Added 5/18/2025 td 
                bool bFirstAndLastAreTheSame = (mod_firstPriorOperation1D == mod_lastPriorOperation1D);
                bool bSetLastPriorToNull; // Added 5/18/2025 thomas d.

                //Apr2025 DLLOperation1D_Of<T_DLL> markersCurrentUndoOperation_willBeLast;
                DLLOperation1D_2TypesInParallel<T_DLL, T_DLLParallel>? markersCurrentUndoOperation_willBeLast;
                //Apr2025 markersCurrentUndoOperation_willBeLast = mod_opUndoRedoMarker.GetCurrentOp_Undo();
                if (mod_opUndoRedoMarker.HasOperationPrior_ForUndo())
                {
                    markersCurrentUndoOperation_willBeLast = mod_opUndoRedoMarker.GetCurrentOp_Undo_OfOf();
                    mod_lastPriorOperation1D = markersCurrentUndoOperation_willBeLast;
                    bSetLastPriorToNull = false; // Added 5/2025
                }
                else // Added 5/16/2025 thomas d.
                {
                    // No Undo operation exists. All Redo operations are being excised/
                    //    removed.  So, logically, the "Last Prior" operation must be 
                    //    set to Null.    ---5/18/2025
                    mod_lastPriorOperation1D = null;
                    bSetLastPriorToNull = true; // Added 5/2025
                }

                mod_lastPriorOperation1D?.DLL_ClearOpNext();
                mod_opUndoRedoMarker.ClearPendingRedoOperation();

                if (mod_firstPriorOperation1D == null) mod_intCountOperations = 0;
                else mod_intCountOperations = 1 + mod_firstPriorOperation1D.DLL_CountOpsAfter();

                //Added 5/18/2025 
                //
                // Do we need to remove --ALL-- references to the Last-Prior operation? 
                //
                //bool bFirstAndLastAreTheSame = (mod_firstPriorOperation1D == mod_lastPriorOperation1D);
                bool bRemoveAllRefsToTheSingleOperation; //Added 5/18/2025 
                bRemoveAllRefsToTheSingleOperation = (bFirstAndLastAreTheSame && bSetLastPriorToNull);

                if (bRemoveAllRefsToTheSingleOperation)  //Added 5/18/2025 td
                {
                    //Added 5/18/2025 
                    //  We need to set the "First Prior" reference to Null, 
                    //  because the "Last Prior" operation and the "First Prior" operation
                    //  are one and the same operation.
                    //  --5/18/2025 td
                    mod_firstPriorOperation1D = null;
                }


            }

        }


        /// <summary>
        /// This will propagate an operation to the local array of DLLLists,
        ///   each list being of the parallel type (T_DLLParallel, e.g. RSCDataColumn).
        /// </summary>
        /// <param name="par_operationByIndex"></param>
        /// <param name="par_changeOfEndpoint_Expected"></param>
        /// <param name="par_changeOfEndpoint_InFact"></param>
        private void ProcessOperation_ToArrayOfParallelLists(DLLOperationIndexStructure par_operationStructure,
            bool par_changeOfEndpoint_Expected, 
            ref bool par_changeOfEndpoint_InFact,
            DLLList<T_DLLParallel>? par_listThatWasAlreadySorted = null)
        {
            //
            //This will propagate an operation to the local array of DLLLists,
            //   of the parallel type (e.g. RSCDataColumn).
            //
            //Called by the following:
            //    public void ProcessOperation_AnyType
            //
            if (mod_arrayOfParallelLists == null) return;

            int arrayIndex = 0;
            DLLRange<T_DLLParallel> each_range;
            //Added 4/14/2025 td
            int countOfParallelLists = mod_arrayOfParallelLists.Length;

            // Added 4/14/2025 
            if (par_operationStructure.IsDelete)
            {
                // Added 4/14/2025 
                mod_arrayOfParallelRangesToDelete = new DLLRange<T_DLLParallel>[countOfParallelLists];
            }
            else if (par_operationStructure.IsInsert)
            {
                //Added 4/14/2025 
                if (mod_arrayOfParallelRangesToInsert == null)
                {
                    //Added 4/14/2025 
                    System.Diagnostics.Debugger.Break();
                    throw new Exception("Missing array of ranges to insert.");
                }
            }

            // 
            //
            //  Process each parallel list (e.g. column of data cells) in
            //   turn. ---5/06/2025 
            //
            // Added 4/08/2025 td
            foreach (var each_list in mod_arrayOfParallelLists)
            {
                //Added 5/06/2025
                bool bSkipThisList_IsSorted = (each_list == par_listThatWasAlreadySorted); 
                if (bSkipThisList_IsSorted) continue;

                T_DLLParallel each_1stParallelItem = each_list.DLL_GetFirstItem_OfT();

                DLLOperation1D_Of<T_DLLParallel> each_operation; // = new DLLOperation1D<T_DLLParallel>
                                                                 //    (par_operationByIndex, each_1stParallelItem);

                bool bChangeOfEndpointInFact = false;

                //
                //For INSERT operations (& possibly MOVEs).  Added 04/08/2025 td
                //
                if (par_operationStructure.IsInsert)
                {
                    //
                    // For Inserts. (Eventually, we might include MOVE operations.)
                    //
                    if (mod_arrayOfParallelRangesToInsert == null)
                    {
                        System.Diagnostics.Debugger.Break();
                        throw new Exception("We are missing an array insert-range objects to pair with each list.");
                    }

                    each_range = mod_arrayOfParallelRangesToInsert[arrayIndex];

                    //Added 04/08/2025 td
                    //Apr2025 each_operation.SetRange_ForInserts(each_range);

                    each_operation = new DLLOperation1D_Of<T_DLLParallel>
                        (par_operationStructure, each_1stParallelItem, each_range);

                }

                else
                {
                    //
                    // Non-Insert operations.
                    //
                    each_operation = new DLLOperation1D_Of<T_DLLParallel>
                         (par_operationStructure, each_1stParallelItem);

                    // Added 4/14/2025 
                    if (each_operation._isDelete && mod_arrayOfParallelRangesToDelete != null)
                    {
                        // Added 4/14/2025 
                        mod_arrayOfParallelRangesToDelete[arrayIndex] = each_operation.GetRange();
                    }

                }

                //
                // Major call!!
                //
                each_operation.OperateOnList(each_list, true, par_changeOfEndpoint_Expected,
                    out bChangeOfEndpointInFact);
                //  mod_arrayOfParallelRanges[arrayIndex]);

                par_changeOfEndpoint_InFact |= bChangeOfEndpointInFact;

                arrayIndex++;

            }

        }


        private void UndoOfPriorOperation_AnyType(ref bool pbEndpointAffected,
            bool pbTestingIndexStructure)
        {
            //
            // Added 1/10/2024 thomas downes
            //
            int intCountFurtherUndoOps;
            DLLOperation1D_2TypesInParallel<T_DLL, T_DLLParallel> operationToUndo;
            bool bOperationPriorExists = false;

            // Added 10/25/2024  
            if (mod_opUndoRedoMarker == null)
            {
                // Added 10/25/2024  
                if (mod_lastPriorOperation1D == null) throw new RSCNoPriorOperationException();
                mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1DParallel<T_DLL, T_DLLParallel>(mod_lastPriorOperation1D, false);

            }
            else if (mod_opUndoRedoMarker.HasOperationPrior_ForUndo())
            {
                // Great, we will be able to do the "Undo" operation.
                bOperationPriorExists = true;

            }
            else
            {
                //MessageBoxTD.Show_Statement("No Undo operation is in queue."); // 1/15/24
                //throw new RSCEndpointException("No Undo operation is in queue.");
                System.Diagnostics.Debugger.Break();
                //return;
            }

            intCountFurtherUndoOps = 1 + mod_opUndoRedoMarker.GetCurrentIndex_Undo();

            if (intCountFurtherUndoOps == 0)
            {
                // Added 1/10/2024 
                //MessageBoxTD.Show_Statemen t("Sorry, no more (recorded) operations remain to Undo.");
                throw new RSCEndpointException("No operations exist to Undo.");
            }
            else
            {
                // Undo the operation which is the RedoMarker's currently-designated Undo operation.
                //Apr2025 operationToUndo = mod_opUndoRedoMarker.GetCurrentOp_Undo();
                operationToUndo = mod_opUndoRedoMarker.GetCurrentOp_Undo_OfOf();

                //Added 4/14/2025 
                if (operationToUndo._isDelete)
                {
                    // We need the array of deleted parallel ranges, so that the 
                    //   operation can be undone for all of the parallel lists. ---4/14/2025 td
                    // mod_arrayOfParallelRangesToDelete = operationToUndo.ArrayOfParallelRanges_Deleted;
                    // Apr2025  mod_arrayOfParallelRangesToDelete = operationToUndo.ArrayOfParallelRanges_ToInsert;
                    mod_arrayOfParallelRangesToDelete = operationToUndo.GetArrayOfParallelRanges_ToInsert();
                    // Added 4/23/2025 td
                    mod_arrayOfParallelRangesToInsert = operationToUndo.GetArrayOfParallelRanges_Deleted();

                }

                // Testing the DLLOperationStructure class.  Added 1/14/2025 tfd
                if (pbTestingIndexStructure)
                {
                    // Use the operation structure, to create a new, equivalent  operation.
                    DLLOperationIndexStructure opIndexStructure = operationToUndo.GetOperationIndexStructure(true);
                    //Apr2025 operationToUndo = new DLLOperation1D_Of<T_DLL>(opIndexStructure, mod_firstItem);
                    operationToUndo = new DLLOperation1D_2TypesInParallel<T_DLL, T_DLLParallel>(opIndexStructure, mod_firstItem);

                }

                // Major call!!
                //    UndoOperation_ViaInverseOf(operationToUndo);
                //    April2025  UndoOperation_ViaInverseOf(operationToUndo, ref pbEndpointAffected);
                UndoOperation_ViaInverse_OfOf(operationToUndo, ref pbEndpointAffected);

                // Major call!! --1/10/2024
                mod_opUndoRedoMarker.ShiftMarkerLeft_AfterUndo_ToPrior();

                // Refresh the Display. (Make the Insert visible to the user.)
                // RefreshTheUI_DisplayList();

                // Added 1/03/2024
                // RefreshTheUI_OperationsCount();
            }
        }


        private void UndoOperation_ViaInverse_OfOf(DLLOperation1D_2TypesInParallel<T_DLL, T_DLLParallel> parOperation, ref bool pbEndpointAffected)
        {
            //
            //''Added 4/14/2025 and 7/06/2024 and 1/15/2024
            //''
            const bool RECORD_UNDO_OPERATION = false; //Not needed for UNDO operations. ''Added 1 / 28 / 2024
            bool bIsChangeOfEndpoint_Expected = false;
            bool bChangeOfEndpoint_Occurred = false;
            DLLOperation1D_2TypesInParallel<T_DLL, T_DLLParallel> opUndoVersion_OfOf; // As DLL_OperationV1 ''Added 11 / 5 / 2024

            //Added 5/07/2025
            bool bUndoOfSortingByIndexing1 = parOperation.IsSorting_ByIndexMapping(); //Added 5/07/2025
            bool bUndoOfSortingByValues1 = parOperation.IsSorting_ByItemValues(); //Added 5/07/2025

            opUndoVersion_OfOf = parOperation.GetInverseForUndo_OfOf(Testing.AreWeTesting);

            //Added 4/12/2025 td
            //  Capture the INSERT (parallel) ranges, if any.
            //
            //    (These INSERT ranges were previously DELETE ranges!!)
            //
            if (opUndoVersion_OfOf._isInsert)
            {
                //---mod_arrayOfParallelRangesToInsert = opUndoVersion_OfOf.ArrayOfParallelRanges_ToInsert;
                mod_arrayOfParallelRangesToInsert = opUndoVersion_OfOf.GetArrayOfParallelRanges_ToInsert();
            }

            pbEndpointAffected = opUndoVersion_OfOf.IsChangeOfEndpoint();
            bIsChangeOfEndpoint_Expected = pbEndpointAffected;

            //
            //  Are we undoing a DELETE operation, and so the UNDO OPERATION
            //   is an INSERT?  
            //
            bool bUndoOfDelete = ('D' == parOperation.GetOperationType());
            if (bUndoOfDelete)
            {
                bool bEndpointsAreClean = opUndoVersion_OfOf.CheckEndPointsAreClean_PriorToInsert();
            }

            // Added 4/15/2025 td
            var operationIndexStructure = opUndoVersion_OfOf.GetOperationIndexStructure();

            //Added 5/06/2025 thomas 
            //---int intSortColumnIndex_base1 = opUndoVersion_OfOf 
            bool bUndoOfSortingByIndexing2 = opUndoVersion_OfOf.IsSorting_ByIndexMapping();
            bool bUndoOfSortingByValues2 = opUndoVersion_OfOf.IsSorting_ByItemValues(); //Added 5/07/2025
            //bool bUndoSortingOfParallelList = bUndoOfSorting && intSortingColumnIndex_base1 >= 1;

            //
            //''Major call!!
            //
            ProcessOperation_AnyType(opUndoVersion_OfOf,
                                     bIsChangeOfEndpoint_Expected,
                                     out bChangeOfEndpoint_Occurred,
                                     RECORD_UNDO_OPERATION,
                                     operationIndexStructure);

            if (bIsChangeOfEndpoint_Expected || bChangeOfEndpoint_Occurred)
            {
                mod_firstItem = mod_list.DLL_GetFirstItem_OfT();
                mod_endingItem = mod_list.DLL_GetLastItem_OfT();
            }

        }


        private void UndoOperation_ViaInverse_Of(DLLOperation1D_Of<T_DLL> parOperation, ref bool pbEndpointAffected)
        {
            //
            //''Added 7/06/2024 and 1/15/2024
            //''
            const bool RECORD_UNDO_OPERATION = false; //Not needed for UNDO operations. ''Added 1 / 28 / 2024
            bool bIsChangeOfEndpoint_Expected = false;
            bool bChangeOfEndpoint_Occurred = false;
            DLLOperation1D_Of<T_DLL> opUndoVersion; // As DLL_OperationV1 ''Added 11 / 5 / 2024
            //opUndoVersion = parOperation.GetUndoVersionOfOperation();
            opUndoVersion = parOperation.GetInverseForUndo_Of(Testing.AreWeTesting);

            // Added 11/10/2024 
            pbEndpointAffected = opUndoVersion.IsChangeOfEndpoint();
            bIsChangeOfEndpoint_Expected = pbEndpointAffected;

            //''Added 7/06/2024 and 1/31/2024
            //
            //  Are we undoing a DELETE operation, and so the UNDO OPERATION
            //   is an INSERT?  
            //
            //---opUndoVersion.CheckEndpointsAreClean(true, true, false, true);
            bool bUndoOfDelete = ('D' == parOperation.GetOperationType());
            if (bUndoOfDelete)
            {
                bool bEndpointsAreClean = opUndoVersion.CheckEndPointsAreClean_PriorToInsert();
            }

            //''Major call!!
            //ProcessOperation_AnyType(opUndoVersion,
            //                         opUndoVersion.IsChangeOfEndpoint(),
            //                         RECORD_UNDO_OPERATION);
            ProcessOperation_AnyType(opUndoVersion,
                                     bIsChangeOfEndpoint_Expected,
                                     out bChangeOfEndpoint_Occurred,
                                     RECORD_UNDO_OPERATION,
                                     opUndoVersion.GetOperationIndexStructure());

            //Added 11/10/2024 
            //---if (bIsChangeOfEndpoint)
            if (bIsChangeOfEndpoint_Expected || bChangeOfEndpoint_Occurred)
            {
                mod_firstItem = mod_list.DLL_GetFirstItem_OfT();
                mod_endingItem = mod_list.DLL_GetLastItem_OfT();
            }

        }


        ///<summary>
        /// Allows a UI class to load an array of parallel lists.
        ///</summary>
        ///<returns>An array of DLLLists (Of DLLUserControlRichbox)</returns>
        public void LoadParallelLists(DLLList<T_DLLParallel>[] param_arrayOfParallelLists,
            DLLRange<T_DLLParallel>[]? par_arrayOfParallelRanges = null)
        {
            //
            // Added 4/08/2025 thomas downes
            //
            //  Part 1 of 2.  Add the parallel lists. 
            //
            mod_arrayOfParallelLists = param_arrayOfParallelLists;

            //
            // Added 4/08/2025 
            //
            //  Part 2 of 2. For INSERTS--Add the parallel ranges, if needed, in cases of INSERTs. 
            //
            if (par_arrayOfParallelRanges != null)
            {
                //
                // Double-check the expected counts.
                // 
                int countOfRanges = par_arrayOfParallelRanges.Count();
                int countOfLists = param_arrayOfParallelLists.Count();
                bool bMatches = (countOfLists == countOfRanges);
                if (!bMatches)
                {
                    System.Diagnostics.Debugger.Break();
                }

                //  For INSERTS--Add the parallel ranges, if needed, in cases of INSERTs. 
                //----mod_arrayOfParallelRanges = par_arrayOfParallelRanges;
                mod_arrayOfParallelRangesToInsert = par_arrayOfParallelRanges;

            }

        } // End Function ''End of ""Public Function GetParallelLists()


        public override string ToString()
        {
            //
            // Added 11/29/2024 
            //
            //---Apr2025---return mod_opUndoRedoMarker.ToString();

            string output_string = mod_opUndoRedoMarker.ToString();
            return output_string; 

        }

        public string ToString(DLLOperation1D_Of<T_DLL> par_operation)
        {
            //
            // Added 11/29/2024 
            //
            return mod_opUndoRedoMarker.ToString(par_operation);

        }



    }
}
