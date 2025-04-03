using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    public class DLLOperationsManager2D_Redo<T_Base, T_Hori, T_Vert> 
                          // :InterfaceDLLManager_OfT<T_Base>
            where T_Base : class, IDoublyLinkedItem<T_Base> // IDoublyLinkedItem<T_Base>
            //where T_Hori : class, IDoublyLinkedItem<T_Hori>  // Modified 1/09/2025
            //where T_Vert : class, IDoublyLinkedItem<T_Vert> // Modified 1/09/2025
            where T_Hori : class, T_Base, IDoublyLinkedItem<T_Hori>  // Added T_Base as a base class. 1/09/2025
            where T_Vert : class, T_Base, IDoublyLinkedItem<T_Vert> // Added T_Base as a base class. 1/09/2025
    {
        //
        //    2D = 2 dimensions, a 2-dimensional grid
        //
        //    "Hor" = Horizontal
        //    "Ver" = Vertical 
        //
        // "_Redo" version started 11/25/2024 thom.a.s down.e.s
        //
        //---------------------------------------------------------------------------------------------------------------------
        //  REDO 
        //---------------------------------------------------------------------------------------------------------------------
        //  I have added these classes, and suffixed this class as _REDO, because I want to avoid using
        //      the following class:  
        //       DLLOperation2D<T_Hori, T_Vert> 
        //---------------------------------------------------------------------------------------------------------------------
        private DLLOperationsManager1D<T_Hori, T_Hori> mod_managerHoriz;
        private DLLOperationsManager1D<T_Vert, T_Vert> mod_managerVerti;

        private DLLOperationBase? mod_firstPriorOperationBase;
        private DLLOperationBase? mod_lastPriorOperationBase;

        //  Let's not delegate (to our class components)
        //   recording/saving references of operations.
        private const bool RECORDING_BY_COMPONENTS = false;  // False. Let's not delegate recording/saving references to operations.  
        private const bool RECORDING_BY_THISCLASS = true;   //This class will do the recording.
        
        private int mod_numberOfOperationsH;
        private int mod_numberOfOperationsV;

        private bool mod_horizontalOnlyMode = false;  //Added 12/04/2024 thomas downes
        private bool mod_bothDimensionsMode = false;  //Added 12/04/2024 thomas downes
                                                      
        private T_Hori mod_firstItemH;
        private T_Hori mod_endingItemH;
        private DLLList<T_Hori> mod_listH;
        
        private T_Vert mod_firstItemV;
        private T_Vert mod_endingItemV;
        private DLLList<T_Vert> mod_listV;
        
        // Use the Base-Type . 
        private DLLOperationsUndoRedoMarker1D<T_Base> mod_opUndoRedoMarker;

        private int mod_intCountOperations = 0; // As Integer = 0 ''Added 1/24/2024 td


        public DLLOperationsManager2D_Redo(bool par_horizontalOnly,
                             T_Hori par_firstItemHorizontal,
                             DLLList<T_Hori> par_listHoriz,
                             DLLOperation1D<T_Hori>? par_firstOperationHoriz = null)
        {
            //
            // Constructor
            //
            mod_horizontalOnlyMode = par_horizontalOnly;

            if (!mod_horizontalOnlyMode) Debugger.Break();
            if (!mod_horizontalOnlyMode) throw new Exception("The current constructor is for Horizontal-only mode.");

            this.mod_firstItemH = par_firstItemHorizontal;
            this.mod_listH = par_listHoriz;
            const bool BASE_CLASS = true; // Added 1/09/2025 td

            if (par_firstOperationHoriz != null)
            {
                //
                // A non-null Operation has been supplied to the constructor.
                //
                this.mod_firstPriorOperationBase = par_firstOperationHoriz;
                this.mod_lastPriorOperationBase = par_firstOperationHoriz;

                mod_numberOfOperationsH++; // Added 10/26/2024 td 

                // this.mod_lastPriorOperationV1 = mod_lastPriorOperationV1;
                // this.mod_ mopRedoMarker = mod_opRedoMarker;
                // this.mod_intCountOperations = mod_intCountOperations;

                //DLLOperationBase firstOperation_base = par_firstOperationHoriz.GetConvertToBaseClass();   //.DLL_GetBase();
                //DLLOperation1D<T_Base>firstOperation_Tbase = par_firstOperationHoriz.GetConvertToGenericOfT<T_Base>();   //.DLL_GetBase();
                //T_Base firstItemHoriz = (T_Base)par_firstItemHorizontal; // as T_Base;

                T_Base firstItem_Horiz_base = par_listHoriz.DLL_GetFirstItem_OfT();

                DLLOperation1D<T_Base> operation_base_ofT = 
                    par_firstOperationHoriz.GetConvertToGenericOfT<T_Base>(firstItem_Horiz_base, BASE_CLASS, false);   //.DLL_GetBase();

                //Added 1/4/2025 td
                mod_managerHoriz = new DLLOperationsManager1D<T_Hori, T_Hori>(par_firstItemHorizontal, 
                    par_listHoriz, par_firstOperationHoriz);

                //---mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_Base>(operation_base);
                mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_Base>(operation_base_ofT);

            }
            else
            {
                //
                // No first operation has been specified. (par_firstOperationH == null)
                //
                // Added 1/04/2025 
                mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_Base>();

                //Added 1/4/2025 td
                mod_managerHoriz = new DLLOperationsManager1D<T_Hori, T_Hori>(par_firstItemHorizontal, 
                    par_listHoriz, par_firstOperationHoriz);

            }

        }


        public DLLOperationsManager2D_Redo(bool par_BothDimensions,
                                         T_Hori par_firstItemHorizontal, 
                                         T_Vert par_firstItemVertical,
                                         DLLList<T_Hori> par_listHoriz,
                                         DLLList<T_Vert> par_listVerti,
                                         DLLOperation1D<T_Hori> par_firstPriorOperation_Hor,
                                         DLLOperation1D<T_Vert> par_firstPriorOperation_Ver)
        {
            //
            // Constructor
            //
            mod_bothDimensionsMode = par_BothDimensions;

            if (!mod_bothDimensionsMode) Debugger.Break();
            if (!mod_bothDimensionsMode) throw new Exception("The current constructor is for Horizontal-and-Vertical mode.");

            this.mod_firstItemH = par_firstItemHorizontal;
            this.mod_firstItemV = par_firstItemVertical;

            this.mod_listH = par_listHoriz;
            this.mod_listV = par_listVerti;

            this.mod_firstPriorOperationBase = par_firstPriorOperation_Hor;
            // Place the vertical(_V) operation after the horizontal(_H) operation.
            this.mod_firstPriorOperationBase.DLL_SetOpNext(par_firstPriorOperation_Ver, true);
            this.mod_lastPriorOperationBase = par_firstPriorOperation_Ver;
            
            mod_numberOfOperationsH++; // Added 12/07/2024 td 
            mod_numberOfOperationsV++; // Added 12/07/2024 td 

            // this.mod_lastPriorOperationV1 = mod_lastPriorOperationV1;
            // this.mod_opRedoMarker = mod_opRedoMarker;
            // this.mod_intCountOperations = mod_intCountOperations;
            // mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_Base>(par_firstPriorOperation_Hor,     
            //                               par_firstPriorOperation_Ver);

            const bool BASE_CLASS = true; // Added 1/09/2025

            // Added 12/08/2024 
            DLLOperation1D<T_Base> oper_FirstHorizontal = 
                par_firstPriorOperation_Hor.GetConvertToGenericOfT<T_Base>(par_firstItemHorizontal, BASE_CLASS, false);

            DLLOperation1D<T_Base> oper_FirstVertical = 
                par_firstPriorOperation_Ver.GetConvertToGenericOfT<T_Base>(par_firstItemVertical, BASE_CLASS, false);

            // Added 12/08/2024 
            mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_Base>(oper_FirstHorizontal, oper_FirstVertical);

        }


        public DLLOperationsManager2D_Redo(T_Hori par_firstItemHorizontal, T_Vert par_firstItemVertical,
                                         DLLList<T_Hori> par_listHoriz,
                                         DLLList<T_Vert> par_listVerti)
        {
            //
            // Constructor  
            //
            this.mod_firstItemH = par_firstItemHorizontal;
            this.mod_listH = par_listHoriz;

            this.mod_firstItemV = par_firstItemVertical;
            this.mod_listV = par_listVerti;

            //---this.mod_firstPriorOperation1D = par_firstPriorOperationV1;
            //---this.mod_lastPriorOperation1D = par_firstPriorOperationV1;
            //---mod_intCountOperations++; // Added 10/26/2024 td 

            // this.mod_lastPriorOperationV1 = mod_lastPriorOperationV1;
            // this.mod_opRedoMarker = mod_opRedoMarker;
            // this.mod_intCountOperations = mod_intCountOperations;
            //---mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_LinkedCtl>(par_firstPriorOperationV1);
            mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_Base>();

        }




        private void ProcessEither<T_Either> (T_Either par_item, bool pbHorizontal)
        {

            IDoublyLinkedItem firstItem;
            if (pbHorizontal) firstItem = mod_firstItemH; // as T_Either;
            if (!pbHorizontal) firstItem = mod_firstItemV; // as T_Either;




        }


        public bool MarkerHasOperationNext()
        {
            //
            //  Added 11/25/2024 
            //
            //bool result_hasNext = mod_opRedoMarker.HasOperationNext();
            bool result_hasNext = mod_opUndoRedoMarker.HasOperationNext();
            return result_hasNext;

        }

        public bool MarkerHasOperationPrior()
        {
            //
            //  Added 11/25/2024 ca
            //
            bool result_hasNext = mod_opUndoRedoMarker.HasOperationNext();
            return result_hasNext;

        }

        public void ProcessOperation_AnyType(DLLOperation1D<T_Hori> parOperation, 
                          bool par_changeOfEndpoint_Expected, 
                          out bool pbChangeOfEndpointOccurred,
                          bool par_bRecordOperation)
        {
            //
            //  Added 11/25/2024 
            //
            //See module level. --const bool RECORDING_BY_COMPONENTS = false;  // False. Let's not delegate.  
            //See module level. --const bool RECORDING_BY_THISCLASS = true;   //This class will do the recording.
    
            //
            //  Major call!!
            //
            //Mar2025  mod_managerHoriz.ProcessOperation_AnyType(parOperation, 
            //    par_changeOfEndpoint_Expected, 
            //    out pbChangeOfEndpointOccurred,
            //    RECORDING_BY_COMPONENTS);
            mod_managerHoriz.ProcessOperation_AnyType(parOperation,
                par_changeOfEndpoint_Expected,
                out pbChangeOfEndpointOccurred,
                RECORDING_BY_COMPONENTS, 
                parOperation.GetOperationIndexStructure());

            if (par_bRecordOperation && RECORDING_BY_THISCLASS)
            {
                //if (mod_lastOperation != null)
                //{
                //    // 1-04-2025 mod_lastOperation.DLL_SetOpNext(parOperation, true);
                //    mod_lastOperation?.DLL_SetOpNext(parOperation, true);
                //}
                //else
                //{
                //    // Added 1/4/2025 td
                //    mod_firstOperation = parOperation;
                //    mod_lastOperation = parOperation;
                //}

                const bool BASE_CLASS = true;  // Added 1/9/2025

                if (mod_firstPriorOperationBase == null)
                {
                    mod_firstPriorOperationBase = parOperation;
                    mod_lastPriorOperationBase = parOperation;

                    //
                    // Added 12/04/2024
                    //
                    // DLLOperation1D<T_Base> operationBase = parOperation.GetConvertToGenericOfT<T_Base>(mod_firstPriorOperationBase, false);
                    //DLLOperationBase operationBase = parOperation.GetConvertToGenericOfT<DLLOperationBase>(mod_firstPriorOperationBase, false);
                    DLLOperation1D<T_Base> operationBase = parOperation.GetConvertToGenericOfT<T_Base>(mod_firstItemH, BASE_CLASS, false);
                    mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_Base>(operationBase);

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
                        mod_lastPriorOperationBase = mod_opUndoRedoMarker.GetCurrentOp_Undo();
                        mod_lastPriorOperationBase?.DLL_ClearOpNext();
                        mod_opUndoRedoMarker.ClearPendingRedoOperation();

                    }

                    // Connect the operations in a doubly-linked list. 
                    //---parOperation.DLL_SetOpPrior(mod_lastPriorOperation1D);
                    //+++parOperation.DLL_SetOpPrior_OfT(mod_lastPriorOperationBase);
                    parOperation.DLL_SetOpPrior(mod_lastPriorOperationBase);

                    //---mod_lastPriorOperation1D.DLL_SetOpNext(parOperation);
                    mod_lastPriorOperationBase?.DLL_SetOpNext(parOperation, true);

                    var temp_priorOp = mod_lastPriorOperationBase;
                    //mod_lastPriorOperation1D = parOperation;
                    //mod_opRedoMarker = new DLLOperationsRedoMarker1D<T_LinkedCtl>(temp_priorOp, parOperation);
                    mod_lastPriorOperationBase = parOperation;

                    //
                    //  Major call!! 
                    //
                    DLLOperation1D<T_Base> operationBase = parOperation.GetConvertToGenericOfT<T_Base>(mod_firstItemH, BASE_CLASS, false);
                    mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_Base>(operationBase);

                    // Added 12/01/2028
                    //----mod_lastPriorOperation1D.DLL_SetOpPrior(temp_priorOp); // Added 12/01/2024 
                    if (temp_priorOp != null)
                    {
                        mod_lastPriorOperationBase.DLL_SetOpPrior(temp_priorOp); // Added 12/01/2024 
                    }

                    //
                    // DIFFICULT & CONFUSING -- Connect the first operation to this one, if needed.
                    //
                    if (mod_firstPriorOperationBase.DLL_MissingOpNext())
                    {
                        //---mod_firstPriorOperation1D.DLL_SetOpNext(parOperation);
                        mod_firstPriorOperationBase.DLL_SetOpNext(parOperation, true);
                    }

                    //
                    // Testing!!  
                    //
                    int intCountOfPriorOps;
                    int intCountOfPriorOps_PlusItself;
                    intCountOfPriorOps = (mod_lastPriorOperationBase.DLL_CountOpsBefore());
                    intCountOfPriorOps_PlusItself = (intCountOfPriorOps + 1); // We must count the operation itself !!!!!

                }





            }


        }


        public void ProcessOperation_AnyType(DLLOperation1D<T_Vert> parOperation,
                          bool par_changeOfEndpoint_Expected, out bool pbChangeOfEndpointOccurred,  
                          bool par_bRecordOperation)
        {
            //
            //  Added 11/25/2024 
            //
            // March2025  mod_managerVerti.ProcessOperation_AnyType(parOperation, par_changeOfEndpoint_Expected,
            //    out pbChangeOfEndpointOccurred,
            //    par_bRecordOperation)

            mod_managerVerti.ProcessOperation_AnyType(parOperation, par_changeOfEndpoint_Expected,
                out pbChangeOfEndpointOccurred,
                par_bRecordOperation, 
                parOperation.GetOperationIndexStructure());



        }

        public void RedoMarkedOperation()
        {
            //
            //  Added 11/25/2024 
            //


        }

        public void UndoMarkedOperation(ref bool pbEndpointAffected)
        {
            //
            //  Added 11/25/2024 
            //

        }


        public int CountOfOperations_QueuedForRedo()
        {
            //
            //  Added 1/01/2025 & 10/13/2024 
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


        public override string ToString()
        {
            //
            //  Added 01/01/2025 
            //
            int intCountOperations = 0; // Added 1/04/2025 td 

            // Added 1/04/2025 td
            if (mod_firstPriorOperationBase != null)
            {
                // Added 1/04/2025 td
                intCountOperations = 1 + mod_firstPriorOperationBase.DLL_CountOpsAfter();
            }

            //
            // Added 11/29/2024 
            //
            // Jan4 2025 return mod_opUndoRedoMarker.ToString();
            return mod_opUndoRedoMarker.ToString(intCountOperations);


        }


        public string ToString(DLLOperation1D<T_Base> par_operation)
        {
            //
            // Added 11/29/2024 
            //
            return mod_opUndoRedoMarker.ToString(par_operation);

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

        public void ClearAllRecordedOperations()
        {
            //
            // Added 12/04/2024 th..omas do..wnes  
            //
            mod_firstPriorOperationBase = null;
            mod_lastPriorOperationBase = null;
            mod_opUndoRedoMarker.ClearAllOperations();
            mod_intCountOperations = 0;

        }


    }
}
