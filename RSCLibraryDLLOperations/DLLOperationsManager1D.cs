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
    public class DLLOperationsManager1D<T_LinkedCtl>
        where T_LinkedCtl : IDoublyLinkedItem<T_LinkedCtl>
    {
        //    1D = 1 dimension, simply a list
        //            (versus a 2-dimensional grid)
        //
        private T_LinkedCtl mod_firstItem;
        private T_LinkedCtl mod_endingItem;
        private DLLList<T_LinkedCtl> mod_list;
            
        private DLLOperation1D<T_LinkedCtl> mod_firstPriorOperation1D;
        private DLLOperation1D<T_LinkedCtl> mod_lastPriorOperation1D;

        private DLLOperationsUndoRedoMarker1D<T_LinkedCtl>
            mod_opUndoRedoMarker;  // new DLLOperationsRedoMarker1D<T_LinkedCtl>(); // As r ''Added 1/24/2024

        private int mod_intCountOperations = 0; // As Integer = 0 ''Added 1/24/2024 td


        //
        // Added 10/20/2024 
        //
        public DLLOperationsManager1D(T_LinkedCtl par_firstItem, 
            DLLList<T_LinkedCtl> par_list, 
            DLLOperation1D<T_LinkedCtl> par_firstPriorOperationV1)
        {
            this.mod_firstItem = par_firstItem;
            this.mod_list = par_list;

            this.mod_firstPriorOperation1D = par_firstPriorOperationV1;
            this.mod_lastPriorOperation1D = par_firstPriorOperationV1;
            mod_intCountOperations++; // Added 10/26/2024 td 

            // this.mod_lastPriorOperationV1 = mod_lastPriorOperationV1;
            // this.mod_opRedoMarker = mod_opRedoMarker;
            // this.mod_intCountOperations = mod_intCountOperations;
            mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_LinkedCtl>(par_firstPriorOperationV1);

        }

        public T_LinkedCtl GetFirstItem()
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


        public bool MarkerHasOperationPrior()
        {
            bool result_hasPrior = mod_opUndoRedoMarker.HasOperationPrior();
            return result_hasPrior;
        }


        public bool MarkerHasOperationNext()
        {
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





        public void ProcessOperation_AnyType(DLLOperation1D<T_LinkedCtl> parOperation,
                               bool par_changeOfEndpoint,
                               bool pbOperationIsNewSoRecordIt)
        {
            // Added 1/15/2024

            //if (parOperation.IsHorizontal()) parOperation.OperateOnList(mod_listHoriz, par_changeOfEndpoint);
            //if (parOperation.IsVertical()) parOperation.OperateOnList(mod_listVerti, par_changeOfEndpoint);

            //
            //Major call!! 
            //
            parOperation.OperateOnList(mod_list, true, par_changeOfEndpoint);

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
                        //
                        //    Logically speaking, any pending Redo operations must be deleted/cleared.
                        //
                        mod_lastPriorOperation1D = mod_opUndoRedoMarker.GetCurrentOp_Undo();
                        mod_lastPriorOperation1D.DLL_ClearOpNext();
                        mod_opUndoRedoMarker.ClearPendingRedoOperation();  

                    }

                    // Connect the operations in a doubly-linked list. 
                    //---parOperation.DLL_SetOpPrior(mod_lastPriorOperation1D);
                    parOperation.DLL_SetOpPrior_OfT(mod_lastPriorOperation1D);
                    
                    //---mod_lastPriorOperation1D.DLL_SetOpNext(parOperation);
                    mod_lastPriorOperation1D.DLL_SetOpNext_OfT(parOperation);

                    var temp_priorOp = mod_lastPriorOperation1D;
                    //mod_lastPriorOperation1D = parOperation;
                    //mod_opRedoMarker = new DLLOperationsRedoMarker1D<T_LinkedCtl>(temp_priorOp, parOperation);
                    mod_lastPriorOperation1D = parOperation;

                    //
                    //  Major call!!
                    //
                    mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_LinkedCtl>(parOperation);
                    
                    // Added 12/01/2028
                    //----mod_lastPriorOperation1D.DLL_SetOpPrior(temp_priorOp); // Added 12/01/2024 
                    mod_lastPriorOperation1D.DLL_SetOpPrior_OfT(temp_priorOp); // Added 12/01/2024 

                    //
                    // DIFFICULT & CONFUSING -- Connect the first operation to this one, if needed.
                    //
                    if (mod_firstPriorOperation1D.DLL_MissingOpNext())
                    {
                        //---mod_firstPriorOperation1D.DLL_SetOpNext(parOperation);
                        mod_firstPriorOperation1D.DLL_SetOpNext_OfT(parOperation);
                    }

                }

            }


        }


        public void RedoMarkedOperation() // (bool pbIsHoriz, bool pbIsVerti)
        {
            DLLOperation1D<T_LinkedCtl>  // <T_LinkedCtlHor, T_LinkedCtlVer>
                opReDo = mod_opUndoRedoMarker.GetMarkersNext_ShiftPositionRight();

            //Added 5.25.2024
            bool bIsChangeOfEndpoint = opReDo.IsChangeOfEndpoint();
            const bool RECORD_OPERATION = false; // Not needed for REDO operations

            //opReDo.CreatedAsRedoOperation = true;
            ProcessOperation_AnyType(opReDo, bIsChangeOfEndpoint, RECORD_OPERATION); // , pbIsHoriz, pbIsVerti);

        }


        public void UndoMarkedOperation(ref bool pbEndpointAffected)
        {
            //Nov10 2024 ''UndoOfPriorOperation_AnyType();
            UndoOfPriorOperation_AnyType(ref pbEndpointAffected);
        }


        private void UndoOfPriorOperation_AnyType(ref bool pbEndpointAffected)
        {
            //
            // Added 1/10/2024 thomas downes
            //
            int intCountFurtherUndoOps;
            DLLOperation1D<T_LinkedCtl> operationToUndo;
            bool bOperationPriorExists; 

            // Added 10/25/2024  
            if (mod_opUndoRedoMarker == null)
            {
                // Added 10/25/2024  
                if (mod_lastPriorOperation1D == null) throw new RSCNoPriorOperationException();
                mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_LinkedCtl>(mod_lastPriorOperation1D);

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


        private void UndoOperation_ViaInverseOf(DLLOperation1D<T_LinkedCtl> parOperation, ref bool pbEndpointAffected)
        {
            //
            //''Added 7/06/2024 and 1/15/2024
            //''
            const bool RECORD_UNDO_OPERATION = false; //Not needed for UNDO operations. ''Added 1 / 28 / 2024
            bool boolIsChangeOfEndpoint = false;
            DLLOperation1D<T_LinkedCtl> opUndoVersion; // As DLL_OperationV1 ''Added 11 / 5 / 2024
            //opUndoVersion = parOperation.GetUndoVersionOfOperation();
            opUndoVersion = parOperation.GetInverseForUndo();

            // Added 11/10/2024 
            pbEndpointAffected = opUndoVersion.IsChangeOfEndpoint();
            boolIsChangeOfEndpoint = pbEndpointAffected;

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
                                     boolIsChangeOfEndpoint,
                                     RECORD_UNDO_OPERATION);

            //Added 11/10/2024 
            if (boolIsChangeOfEndpoint) 
            { 
                mod_firstItem = mod_list.DLL_GetFirstItem_OfT();
                mod_endingItem = mod_list.DLL_GetLastItem_OfT();
            }

        }


        public override string ToString()
        {
            //
            // Added 11/29/2024 
            //
            return mod_opUndoRedoMarker.ToString();

        }

        public string ToString(DLLOperation1D<T_LinkedCtl> par_operation)
        {
            //
            // Added 11/29/2024 
            //
            return mod_opUndoRedoMarker.ToString(par_operation);

        }



    }
}
