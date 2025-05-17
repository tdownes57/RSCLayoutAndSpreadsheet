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
    /// <summary>
    /// This manager class will manage the rows & columns (& row headers) of a spreadsheet.---5/16/2025 
    /// </summary>
    /// <typeparam name="TVertRowHdr"></typeparam>
    /// <typeparam name="TVertParallel"></typeparam>
    /// <typeparam name="THorizontal"></typeparam>
    public class DLLOperationsManager2D_3rd<TVertRowHdr, TVertParallel, THorizontal>
            // :InterfaceDLLManager_OfT<T_Base>
            where TVertRowHdr : class, IDoublyLinkedItem<TVertRowHdr> // IDoublyLinkedItem<T_Base>
                                                            //where TVertRowHdr : class, IDoublyLinkedItem<TVertRowHdr>  // Modified 1/09/2025
                                                            //where THorizontal : class, IDoublyLinkedItem<THorizontal> // Modified 1/09/2025
            where TVertParallel : class, IDoublyLinkedItem<TVertParallel>  // Added T_Base as a base class. 1/09/2025
            where THorizontal : class, IDoublyLinkedItem<THorizontal> // Added T_Base as a base class. 1/09/2025
    {
        //
        //   This manager class will manage the rows & columns (& row headers) of a spreadsheet.---5/16/2025 
        //




    }
}
