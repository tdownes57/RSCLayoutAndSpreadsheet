using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    internal interface InterfaceDLLManager_OfT<TypeOperation>
    {

        public bool MarkerHasOperationPrior();

        public bool MarkerHasOperationNext();

        public void ProcessOperation_AnyType(TypeOperation parOperation,
                               bool par_changeOfEndpoint,
                               bool par_bRecordOperation);

        public void RedoMarkedOperation();

        public void UndoMarkedOperation(ref bool pbEndpointAffected);

        //
        // Added 11/29/2024 thomas dwones
        //
        public int HowManyOpsAreRecorded();












    }
}
