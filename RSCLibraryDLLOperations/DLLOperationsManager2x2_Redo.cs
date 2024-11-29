using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    public class DLLOperationsManager2x2_Redo<TBase, THorizontal, TVertical> 
                          // :InterfaceDLLManager_OfT<TBase>
            where TBase : IDoublyLinkedItem<TBase>
            where THorizontal : IDoublyLinkedItem<THorizontal>
            where TVertical : IDoublyLinkedItem<TVertical>
    {
        //
        //    2D = 2 dimensions, a 2-dimensional grid
        //
        // "_Redo" version started 11/25/2024 thom.a.s down.e.s
        //
        private DLLOperationsManager1D<THorizontal> mod_managerHoriz;
        private DLLOperationsManager1D<TVertical> mod_managerVerti;

        private TBase mod_firstOperation;
        private int mod_numberOfOperations;

        private DLLOperationsRedoMarker1D<TBase> mod_opRedoMarker;

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
