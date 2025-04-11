using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        private DLLOperation1D_OfOf<T_DLL, T_DLLParallel> mod_firstPriorOperation1D;
        private DLLOperation1D_OfOf<T_DLL, T_DLLParallel> mod_lastPriorOperation1D;

        /// <summary>
        /// Allows an operation to be propagated to an array of parallel lists. For example, if the 
        /// operation delete the first item in the main list, the first item in each list of an array of 
        /// similar lists can be deleted.  This would allow a user to delete the first row in a 
        /// spreadsheet, for example. 
        /// </summary>
        private DLLList<T_DLLParallel>[] mod_arrayOfParallelLists;

        /// <summary>
        /// Allows an INSERT operation to be propagated to an array of parallel lists. For example, if 
        /// the operation is an INSERT of 5 new items in the first item in the main list, we need to 
        /// insert five(5) new items in each list of an array of similar lists.  This would allow 
        /// a user to insert 5 new rows at any row-index location in a spreadsheet. 
        /// </summary>
        private DLLRange<T_DLLParallel>[] mod_arrayOfParallelRanges;

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
            DLLOperation1D_OfOf<T_DLL, T_DLLParallel>? par_firstPriorOperationV1 = null)
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
                mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1DParallel<T_DLL, T_DLLParallel>
                    (par_firstPriorOperationV1);
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
            bool result_hasPrior = mod_opUndoRedoMarker.HasOperationPrior();
            return result_hasPrior;
        }


        public bool MarkerHasOperationNext_Redo()
        {
            //
            // Suffixed with _Redo on 12/8/2024 td.
            //
            //bool result_hasNext = mod_opRedoMarker.HasOperationNext();
            bool result_hasNext = mod_opUndoRedoMarker.HasOperationNext();
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


        public void ExecuteOperation_AnyType(DLLOperation1D<T_DLL> parOperation,
                           bool par_changeOfEndpoint_Expected,
                           out bool par_changeOfEndpoint_Occurred,
                           bool pbOperationIsNewSoRecordIt,
                           DLLOperationIndexStructure parOperationIndicized)
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
                pbOperationIsNewSoRecordIt, parOperationIndicized);

        }


        public void ProcessOperation_PrimaryAndParallel(DLLOperation1D_OfOf<T_DLL, T_DLLParallel> parOperation,
                       bool par_changeOfEndpoint_Expected,
                       out bool par_changeOfEndpoint_Occurred,
                       bool pbOperationIsNewSoRecordIt,
                       DLLOperationIndexStructure parOperationIndicized)
        {
            // Added 1/15/2024

            DLLRange<T_DLLParallel>[] array_of_insertRangesParallel;
            array_of_insertRangesParallel = parOperation.ArrayOfParallelRanges_ToInsert;

            //
            // Major call!! 
            //
            ProcessOperation_AnyType(parOperation, par_changeOfEndpoint_Expected,
                out par_changeOfEndpoint_Occurred, pbOperationIsNewSoRecordIt,
                parOperationIndicized);

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
                    mod_lastPriorOperation1D = parOperation;
                    // Added 12/04/2024
                    // April2025  mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1D<T_DLL>(parOperation);
                    mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1DParallel<T_DLL, T_DLLParallel>(parOperation);

                }

                else
                {
                    //
                    // First, we must clear any pending "Redo" operations. 
                    //
                    if (mod_opUndoRedoMarker.HasOperationNext())
                    {
                        //
                        // DIFFICULT AND CONFUSING -- We must "clean"/remove any Redo operations.

                        //    Logically speaking, any pending Redo operations must be deleted/cleared.
                        //
                        mod_lastPriorOperation1D = mod_opUndoRedoMarker.GetCurrentOp_Undo();
                        mod_lastPriorOperation1D?.DLL_ClearOpNext();
                        mod_opUndoRedoMarker.ClearPendingRedoOperation();

                    }

                    // Connect the operations in a doubly-linked list. 
                    //---parOperation.DLL_SetOpPrior(mod_lastPriorOperation1D);
                    parOperation.DLL_SetOpPrior_OfT(mod_lastPriorOperation1D);

                    //---mod_lastPriorOperation1D.DLL_SetOpNext(parOperation);
                    mod_lastPriorOperation1D?.DLL_SetOpNext_OfT(parOperation);

                    var temp_priorOp = mod_lastPriorOperation1D;
                    //mod_lastPriorOperation1D = parOperation;
                    //mod_opRedoMarker = new DLLOperationsRedoMarker1D<T_DLL>(temp_priorOp, parOperation);
                    mod_lastPriorOperation1D = parOperation;

                    //
                    //  Major call!!
                    //
                    mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1D<T_DLL>(parOperation);

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
                        mod_firstPriorOperation1D.DLL_SetOpNext_OfT(parOperation);
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

        public void ProcessOperation_AnyType(DLLOperation1D<T_DLL> parOperation,
                               bool par_changeOfEndpoint_Expected,
                               out bool par_changeOfEndpoint_Occurred, 
                               bool pbOperationIsNewSoRecordIt,
                               DLLOperationIndexStructure parOperationIndicized)
        {
            // Added 1/15/2024

            //if (parOperation.IsHorizontal()) parOperation.OperateOnList(mod_listHoriz, par_changeOfEndpoint);
            //if (parOperation.IsVertical()) parOperation.OperateOnList(mod_listVerti, par_changeOfEndpoint);

            //-------------------------------------------------------------------
            //
            //------------------ Major call!! --------------------------------------
            //
            //-------------------------------------------------------------------
            //
            parOperation.OperateOnList(mod_list, true, par_changeOfEndpoint_Expected, 
                  out par_changeOfEndpoint_Occurred);

            //
            //  Propagate operation to parallel lists, if any exist. 
            //
            ProcessOperation_ToParallelLists(parOperationIndicized, 
                  par_changeOfEndpoint_Expected,
                  ref par_changeOfEndpoint_Occurred);

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
                //mod_lastPriorOperation1D = parOperation;
                if (mod_firstPriorOperation1D == null)
                {
                    mod_firstPriorOperation1D = parOperation;
                    mod_lastPriorOperation1D = parOperation;
                    // Added 12/04/2024
                    mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1D<T_DLL>(parOperation);

                }

                else
                {
                    //
                    // First, we must clear any pending "Redo" operations. 
                    //
                    if (mod_opUndoRedoMarker.HasOperationNext())
                    {
                        //
                        // DIFFICULT AND CONFUSING -- We must "clean"/remove any Redo operations.

                        //    Logically speaking, any pending Redo operations must be deleted/cleared.
                        //
                        mod_lastPriorOperation1D = mod_opUndoRedoMarker.GetCurrentOp_Undo();
                        mod_lastPriorOperation1D?.DLL_ClearOpNext();
                        mod_opUndoRedoMarker.ClearPendingRedoOperation();  

                    }

                    // Connect the operations in a doubly-linked list. 
                    //---parOperation.DLL_SetOpPrior(mod_lastPriorOperation1D);
                    parOperation.DLL_SetOpPrior_OfT(mod_lastPriorOperation1D);
                    
                    //---mod_lastPriorOperation1D.DLL_SetOpNext(parOperation);
                    mod_lastPriorOperation1D?.DLL_SetOpNext_OfT(parOperation);

                    var temp_priorOp = mod_lastPriorOperation1D;
                    //mod_lastPriorOperation1D = parOperation;
                    //mod_opRedoMarker = new DLLOperationsRedoMarker1D<T_DLL>(temp_priorOp, parOperation);
                    mod_lastPriorOperation1D = parOperation;

                    //
                    //  Major call!!
                    //
                    mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1D<T_DLL>(parOperation);

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
                        mod_firstPriorOperation1D.DLL_SetOpNext_OfT(parOperation);
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


        public void RedoMarkedOperation() // (bool pbIsHoriz, bool pbIsVerti)
        {
            DLLOperation1D<T_DLL>  // <T_DLLHor, T_DLLVer>
                opReDo = mod_opUndoRedoMarker.GetMarkersNext_ShiftPositionRight();

            //Added 5.25.2024
            //bool bIsChangeOfEndpoint = opReDo.IsChangeOfEndpoint();
            bool bChangeOfEndpoint_Expected = opReDo.IsChangeOfEndpoint();
            bool bChangeOfEndpoint_Occurred = false; // Added 12/15/2024 td

            const bool RECORD_OPERATION = false; // Not needed for REDO operations

            //opReDo.CreatedAsRedoOperation = true;
            //Mar2025 ProcessOperation_AnyType(opReDo, bChangeOfEndpoint_Expected, 
            //    out bChangeOfEndpoint_Occurred, RECORD_OPERATION); // , pbIsHoriz, pbIsVerti);
            ProcessOperation_AnyType(opReDo, bChangeOfEndpoint_Expected,
                out bChangeOfEndpoint_Occurred, RECORD_OPERATION,
                opReDo.GetOperationIndexStructure()); // , pbIsHoriz, pbIsVerti);

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
            if (this.MarkerHasOperationNext_Redo())
            {
                DLLOperation1D<T_DLL> markersCurrentUndoOperation_willBeLast;
                markersCurrentUndoOperation_willBeLast = mod_opUndoRedoMarker.GetCurrentOp_Undo();
                mod_lastPriorOperation1D = markersCurrentUndoOperation_willBeLast;

                mod_lastPriorOperation1D?.DLL_ClearOpNext();
                mod_opUndoRedoMarker.ClearPendingRedoOperation();
                mod_intCountOperations = (1 + mod_firstPriorOperation1D.DLL_CountOpsAfter());
            }

        }


        /// <summary>
        /// This will propagate an operation to the local array of DLLLists,
        ///   each list being of the parallel type (T_DLLParallel, e.g. RSCDataColumn).
        /// </summary>
        /// <param name="par_operationByIndex"></param>
        /// <param name="par_changeOfEndpoint_Expected"></param>
        /// <param name="par_changeOfEndpoint_InFact"></param>
        private void ProcessOperation_ToParallelLists(DLLOperationIndexStructure par_operationByIndex, 
            bool par_changeOfEndpoint_Expected, ref bool par_changeOfEndpoint_InFact)
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

            // Added 4/08/2025 td
            foreach (var each_list in mod_arrayOfParallelLists)
            {
                     
                T_DLLParallel each_1stParallelItem = each_list.DLL_GetFirstItem_OfT();

                DLLOperation1D<T_DLLParallel> each_operation; // = new DLLOperation1D<T_DLLParallel>
                //    (par_operationByIndex, each_1stParallelItem);

                bool bChangeOfEndpointInFact = false;

                //
                //For INSERT operations (& possibly MOVEs).  Added 04/08/2025 td
                //
                if (par_operationByIndex.IsInsert)
                {
                    //
                    // For Inserts. (Eventually, we might include MOVE operations.)
                    //
                    each_range = mod_arrayOfParallelRanges[arrayIndex];

                    //Added 04/08/2025 td
                    //Apr2025 each_operation.SetRange_ForInserts(each_range);

                    each_operation = new DLLOperation1D<T_DLLParallel>
                        (par_operationByIndex, each_1stParallelItem, each_range);

                }

                else
                {
                    //
                    // Non-Insert operations.
                    //
                    each_operation = new DLLOperation1D<T_DLLParallel>
                         (par_operationByIndex, each_1stParallelItem);
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
            DLLOperation1D<T_DLL> operationToUndo;
            bool bOperationPriorExists = false; 

            // Added 10/25/2024  
            if (mod_opUndoRedoMarker == null)
            {
                // Added 10/25/2024  
                if (mod_lastPriorOperation1D == null) throw new RSCNoPriorOperationException();
                mod_opUndoRedoMarker = new DLLOpsUndoRedoMarker1D<T_DLL>(mod_lastPriorOperation1D);

            }
            else if (mod_opUndoRedoMarker.HasOperationPrior())
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
                //MessageBoxTD.Show_Statement("Sorry, no more (recorded) operations remain to Undo.");
                throw new RSCEndpointException("No operations exist to Undo.");
            }
            else
            {
                // Undo the operation which is the RedoMarker's currently-designated Undo operation.
                operationToUndo = mod_opUndoRedoMarker.GetCurrentOp_Undo();

                // Testing the DLLOperationStructure class.  Added 1/14/2025 tfd
                if (pbTestingIndexStructure)
                {
                    // Use the operation structure, to create a new, equivalent  operation.
                    DLLOperationIndexStructure opIndexStructure = operationToUndo.GetOperationIndexStructure(true);
                    operationToUndo = new DLLOperation1D<T_DLL>(opIndexStructure, mod_firstItem);

                }

                // Major call!!
                //UndoOperation_ViaInverseOf(operationToUndo);
                UndoOperation_ViaInverseOf(operationToUndo, ref pbEndpointAffected);

                // Major call!! --1/10/2024
                mod_opUndoRedoMarker.ShiftMarker_AfterUndo_ToPrior();

                // Refresh the Display. (Make the Insert visible to the user.)
                // RefreshTheUI_DisplayList();

                // Added 1/03/2024
                // RefreshTheUI_OperationsCount();
            }
        }


        private void UndoOperation_ViaInverseOf(DLLOperation1D<T_DLL> parOperation, ref bool pbEndpointAffected)
        {
            //
            //''Added 7/06/2024 and 1/15/2024
            //''
            const bool RECORD_UNDO_OPERATION = false; //Not needed for UNDO operations. ''Added 1 / 28 / 2024
            bool bIsChangeOfEndpoint_Expected = false;
            bool bChangeOfEndpoint_Occurred = false;
            DLLOperation1D<T_DLL> opUndoVersion; // As DLL_OperationV1 ''Added 11 / 5 / 2024
            //opUndoVersion = parOperation.GetUndoVersionOfOperation();
            opUndoVersion = parOperation.GetInverseForUndo(Testing.AreWeTesting);

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
                if (!bMatches) { 
                    System.Diagnostics.Debugger.Break();
                }

                //  For INSERTS--Add the parallel ranges, if needed, in cases of INSERTs. 
                mod_arrayOfParallelRanges = par_arrayOfParallelRanges;
            }

        } // End Function ''End of ""Public Function GetParallelLists()


        public override string ToString()
        {
            //
            // Added 11/29/2024 
            //
            return mod_opUndoRedoMarker.ToString();

        }

        public string ToString(DLLOperation1D<T_DLL> par_operation)
        {
            //
            // Added 11/29/2024 
            //
            return mod_opUndoRedoMarker.ToString(par_operation);

        }



    }
}
