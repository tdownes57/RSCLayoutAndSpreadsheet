using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    internal class DLLOperationsManager2x2<T_LinkedCtlBase, T_LinkedCtlH, T_LinkedCtlV>
    {
        //''Added 1/18/2024 
        private T_LinkedCtlH mod_firstItemHoriz;
        private T_LinkedCtlV mod_firstItemVerti;

        //''Added 2/01/2024 td
        private char mod_charTypeH = 'C'; // c '' C for Columns(Horizontal) C = RSCFieldColumnV2
        private char mod_charTypeV = 'R'; // c '' R for Rows(Vertical)      R = RSCRowHeaderV2

        //private RSLinkedList<T_LinkedCtlH> mod_listHoriz;
        //private RSLinkedList<T_LinkedCtlV> mod_listVerti;

        //private DLL_OperationV1<T_LinkedBase> mod_firstPriorOperationV1;
        //private DLL_OperationV1<T_LinkedBase> mod_lastPriorOperationV1;
        
        //private DLL_OperationsRedoMarker<T_LinkedBase> mod_opRedoMarker; // As r ''Added 1/24/2024
        private int mod_intCountOperations = 0; // As Integer = 0 ''Added 1/24/2024 td






    }
}
