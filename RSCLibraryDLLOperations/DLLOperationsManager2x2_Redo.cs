using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    public class DLLOperationsManager2x2_Redo<T_Base, T_Hori, T_Vert> 
                          // :InterfaceDLLManager_OfT<T_Base>
            where T_Base : IDoublyLinkedItem<T_Base>
            where T_Hori : IDoublyLinkedItem<T_Hori>
            where T_Vert : IDoublyLinkedItem<T_Vert>
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

        private T_Base mod_firstOperation;
        private int mod_numberOfOperations;
        private bool mod_horizontalOnlyMode = false;  //Added 12/04/2024 thomas downes
        private bool mod_bothDimensionsMode = false;  //Added 12/04/2024 thomas downes

        private DLLOperationsUndoRedoMarker1D<T_Base> mod_opRedoMarker;

        public DLLOperationsManager2x2_Redo(bool par_horizontalOnly,
                             T_Hori par_firstItemHorizontal,
                             DLLList<T_Hori> par_listHoriz,
                             DLLOperation1D<T_Hori> par_firstPriorOperationHor)
        {
            //
            // Constructor
            //
            mod_horizontalOnlyMode = par_horizontalOnly;

            if (!mod_horizontalOnlyMode) Debugger.Break();
            if (!mod_horizontalOnlyMode) throw new Exception("The current constructor is for Horizontal-only mode.");

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
        

        public DLLOperationsManager2x2_Redo(bool par_BothDimensions,
                                         T_Hori par_firstItemHorizontal, 
                                         T_Vert par_firstItemVertical,
                                         DLLList<T_Hori> par_listHoriz,
                                         DLLList<T_Vert> par_listVerti,
                                         DLLOperation1D<T_Hori> par_firstPriorOperationHor,
                                         DLLOperation1D<T_Vert> par_firstPriorOperationVer)
        {
            //
            // Constructor
            //
            mod_BothDimensions = par_BothDimensions;

            if (!mod_bothDimensionsMode) Debugger.Break();
            if (!mod_bothDimensionsMode) throw new Exception("The current constructor is for Horizontal-and-Vertical mode.");

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


        public DLLOperationsManager2x2_Redo(T_Hori par_firstItemHorizontal, T_Hori par_firstItemVertical,
                                         DLLList<T_Hori> par_listHoriz,
                                         DLLList<T_Vert> par_listVerti)
        {
            //
            // Constructor  
            //
            this.mod_firstItem = par_firstItem;
            this.mod_list = par_list;

            //---this.mod_firstPriorOperation1D = par_firstPriorOperationV1;
            //---this.mod_lastPriorOperation1D = par_firstPriorOperationV1;
            //---mod_intCountOperations++; // Added 10/26/2024 td 

            // this.mod_lastPriorOperationV1 = mod_lastPriorOperationV1;
            // this.mod_opRedoMarker = mod_opRedoMarker;
            // this.mod_intCountOperations = mod_intCountOperations;
            //---mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_LinkedCtl>(par_firstPriorOperationV1);
            mod_opUndoRedoMarker = new DLLOperationsUndoRedoMarker1D<T_LinkedCtl>();

        }



        public bool MarkerHasOperationNext()
        {
            //
            //  Added 11/25/2024 
            //
            //bool result_hasNext = mod_opRedoMarker.HasOperationNext();
            bool result_hasNext = mod_opRedoMarker.HasOperationNext();
            return result_hasNext;

        }

        public bool MarkerHasOperationPrior()
        {
            //
            //  Added 11/25/2024 ca
            //
            bool result_hasNext = mod_opRedoMarker.HasOperationNext();
            return result_hasNext;

        }

        public void ProcessOperation_AnyType(DLLOperation1D<THorizontal> parOperation, 
                          bool par_changeOfEndpoint, bool par_bRecordOperation)
        {
            //
            //  Added 11/25/2024 
            //
            mod_managerHoriz.ProcessOperation_AnyType(parOperation, par_changeOfEndpoint, par_bRecordOperation);


        }


        public void ProcessOperation_AnyType(DLLOperation1D<TVertical> parOperation,
                          bool par_changeOfEndpoint, bool par_bRecordOperation)
        {
            //
            //  Added 11/25/2024 
            //
            mod_managerVerti.ProcessOperation_AnyType(parOperation, par_changeOfEndpoint, par_bRecordOperation);



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
