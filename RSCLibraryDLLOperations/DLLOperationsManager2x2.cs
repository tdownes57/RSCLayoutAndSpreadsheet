using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{

    public class DLLOperationsManager2x2<T_LinkedCtlBase, T_LinkedCtlHor, T_LinkedCtlVer>
              where T_LinkedCtlBase : IDoublyLinkedItem<T_LinkedCtlBase>
              where T_LinkedCtlHor : IDoublyLinkedItem<T_LinkedCtlHor>
              where T_LinkedCtlVer : IDoublyLinkedItem<T_LinkedCtlVer>
    {
        //''Added 1/18/2024 
        private T_LinkedCtlHor mod_firstItemHoriz;
        private T_LinkedCtlVer mod_firstItemVerti;

        //''Added 2/01/2024 td
        private char mod_charTypeH = 'C'; // c '' C for Columns(Horizontal) C = RSCFieldColumnV2
        private char mod_charTypeV = 'R'; // c '' R for Rows(Vertical)      R = RSCRowHeaderV2

        //private RSLinkedList<T_LinkedCtlH> mod_listHoriz;
        //private RSLinkedList<T_LinkedCtlV> mod_listVerti;

        //private DLL_OperationV1<T_LinkedBase> mod_firstPriorOperationV1;
        //private DLL_OperationV1<T_LinkedBase> mod_lastPriorOperationV1;
        
        private DLLOperationsRedoMarker<T_LinkedCtlHor, T_LinkedCtlVer> 
            mod_opRedoMarker = 
            new DLLOperationsRedoMarker<T_LinkedCtlHor, T_LinkedCtlVer>(); // As r ''Added 1/24/2024
        
        private int mod_intCountOperations = 0; // As Integer = 0 ''Added 1/24/2024 td




        public T_LinkedCtlHor GetFirstItemH()
        {
            return mod_firstItemHoriz;
        }

        public T_LinkedCtlVer GetFirstItemV()
        {
            return mod_firstItemVerti;
        }

        public int CountOfOperations()
        {
            int intCountOps = mod_firstItemHoriz.DLL_CountItemsAllInList();
            return intCountOps;
        }


        public bool MarkerHasOperationPrior()
        {
            bool result_hasPrior = mod_opRedoMarker.HasOperationPrior();
            return result_hasPrior;
        }

        public bool MarkerHasOperationNext()
        {
            //bool result_hasNext = mod_opRedoMarker.HasOperationNext();
            bool result_hasNext = mod_opRedoMarker.HasOperationNext();
            return result_hasNext;
        }

        public void RedoMarkedOperation(bool pbIsHoriz, bool pbIsVerti)
        {
            DLLOperation<T_LinkedCtlHor, T_LinkedCtlVer> 
                opReDo = mod_opRedoMarker.GetMarkersNext_ShiftPositionRight();

            //opReDo.CreatedAsRedoOperation = true;
            ProcessOperation_AnyType(opReDo, opReDo.IsChangeOfEndpoint, false, pbIsHoriz, pbIsVerti);
        
        }

        public void UndoMarkedOperation()
        {
            UndoOfPriorOperation_AnyType();
        }









    }
}
