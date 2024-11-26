using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    public class DLLOperationsManager2x2_Redo<TBase, THorizontal, TVertical>
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







    }
}
