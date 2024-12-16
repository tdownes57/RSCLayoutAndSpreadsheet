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
    public class DLLOperationsManager2x2_Redo<T_Base, T_Hori, T_Vert> 
                          // :InterfaceDLLManager_OfT<T_Base>
            where T_Base : class, IDoublyLinkedItem<T_Base> // IDoublyLinkedItem<T_Base>
            where T_Hori : class, IDoublyLinkedItem<T_Hori> // IDoublyLinkedItem<T_Hori>
            where T_Vert : class, IDoublyLinkedItem<T_Vert> // IDoublyLinkedItem<T_Vert>
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
        private DLLOperationsManager1D<T_Hori> mod_managerHoriz;
        private DLLOperationsManager1D<T_Vert> mod_managerVerti;

        private DLLOperationBase mod_firstOperation;
        private DLLOperationBase mod_lastOperation;

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


        public DLLOperationsManager2x2_Redo(bool par_horizontalOnly,
                             T_Hori par_firstItemHorizontal,
                             DLLList<T_Hori> par_listHoriz,
                             DLLOperation1D<T_Hori>? par_firstOperationH = null)
        {
            //
            // Constructor
            //
            mod_horizontalOnlyMode = par_horizontalOnly;

            if (!mod_horizontalOnlyMode) Debugger.Break();
            if (!mod_horizontalOnlyMode) throw new Exception("The current constructor is for Horizontal-only mode.");

            this.mod_firstItemH = par_firstItemHorizontal;
            this.mod_listH = par_listHoriz;

            if (par_firstOperationH != null)
            {
                //
                // A non-null Operation has been supplied to the constructor.
                //
                this.mod_firstOperation = par_firstOperationH;
                this.mod_lastOperation = par_firstOperationH;

                mod_numberOfOperationsH++; // Added 10/26/2024 td 

                // this.mod_lastPriorOperationV1 = mod_lastPriorOperationV1;
                // this.mod_ mopRedoMarker = mod_opRedoMarker;
                // this.mod_intCountOperations = mod_intCountOperations;

                DLLOperationBase operation_base = par_firstOperationH.GetConvertToBaseClass();   //.DLL_GetBase();
                DLLOperation1D<T_Base> operation_base_ofT = par_firstOperationH.GetConvertToGenericOfT<T_Base>();   //.DLL_GetBase();

                //---mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_Base>(operation_base);
                mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_Base>(operation_base_ofT);
            }

        }


        public DLLOperationsManager2x2_Redo(bool par_BothDimensions,
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

            this.mod_firstOperation = par_firstPriorOperation_Hor;
            // Place the vertical(_V) operation after the horizontal(_H) operation.
            this.mod_firstOperation.DLL_SetOpNext(par_firstPriorOperation_Ver, true);
            this.mod_lastOperation = par_firstPriorOperation_Ver;
            
            mod_numberOfOperationsH++; // Added 12/07/2024 td 
            mod_numberOfOperationsV++; // Added 12/07/2024 td 

            // this.mod_lastPriorOperationV1 = mod_lastPriorOperationV1;
            // this.mod_opRedoMarker = mod_opRedoMarker;
            // this.mod_intCountOperations = mod_intCountOperations;
            // mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_Base>(par_firstPriorOperation_Hor,     
            //                               par_firstPriorOperation_Ver);

            // Added 12/08/2024 
            DLLOperation1D<T_Base> oper_FirstHorizontal = par_firstPriorOperation_Hor.GetConvertToGenericOfT<T_Base>();
            DLLOperation1D<T_Base> oper_FirstVertical = par_firstPriorOperation_Ver.GetConvertToGenericOfT<T_Base>();

            // Added 12/08/2024 
            mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_Base>(oper_FirstHorizontal, oper_FirstVertical);

        }


        public DLLOperationsManager2x2_Redo(T_Hori par_firstItemHorizontal, T_Vert par_firstItemVertical,
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
    
            mod_managerHoriz.ProcessOperation_AnyType(parOperation, 
                par_changeOfEndpoint_Expected, 
                out pbChangeOfEndpointOccurred,
                RECORDING_BY_COMPONENTS);

            if (par_bRecordOperation && RECORDING_BY_THISCLASS)
            {
                mod_lastOperation.DLL_SetOpNext(parOperation, true);

            }


        }


        public void ProcessOperation_AnyType(DLLOperation1D<T_Vert> parOperation,
                          bool par_changeOfEndpoint_Expected, out bool pbChangeOfEndpointOccurred,  bool par_bRecordOperation)
        {
            //
            //  Added 11/25/2024 
            //
            mod_managerVerti.ProcessOperation_AnyType(parOperation, par_changeOfEndpoint_Expected,
                out pbChangeOfEndpointOccurred,
                par_bRecordOperation);



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

    }
}
