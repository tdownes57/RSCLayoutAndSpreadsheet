using System;
using System.Collections.Generic;
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
        private DLLList<T_LinkedCtl> mod_list;
            
        private DLLOperation1D<T_LinkedCtl> mod_firstPriorOperationV1;
        private DLLOperation1D<T_LinkedCtl> mod_lastPriorOperationV1;

        private DLLOperationsRedoMarker1D<T_LinkedCtl>
            mod_opRedoMarker =
            new DLLOperationsRedoMarker1D<T_LinkedCtl>(); // As r ''Added 1/24/2024

        private int mod_intCountOperations = 0; // As Integer = 0 ''Added 1/24/2024 td






    
    }
}
