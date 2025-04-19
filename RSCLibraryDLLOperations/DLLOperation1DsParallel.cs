using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    //
    //  Suffixed "_NotUsed" in April 2025. (I could be wrong.)
    //  
    //  Use "DLLOperations1D_OfOf.cs" instead.  ---4/17/2025
    //
    internal class DLLOperation1DsParallel_NotUsed<T1Primary, T2Parallel>
        where T1Primary : class, IDoublyLinkedItem<T1Primary>
        where T2Parallel : class, IDoublyLinkedItem<T2Parallel>
    {
        //
        //  This class may or may not be used.  Probably not.  I created the class prior to realizing that 
        //  there was a better way to handle the parallel operations.  The better way is to execute the 
        //  parallel operations first, and then the primary operation.
        //
        //  The better way is to operate on the parallel lists (e.g. RSCDataCells) **FIRST**, then (**SECONDLY**)
        //    operate on the primary list.
        //  Otherwise, if you operate on the primary-type list first (e.g. RSCRowHeader), then the objects of the operation 
        //    (e.g. the Range) will be in their final position.  The parallel-version RANGE will be incorrect, because
        //    parallelism depends on the numeric indices.  If the primary list (e.g. the RCSDataSheet row headers)
        //    the indices will be out-of-sync. 
        //
        //  Example types:
        //       T1Primary, example: RSCRowHeader
        //       T2Parallel, example: RSCDataCell    
        //         (Property HasParallelOps will be True.)) 
        //
        //  Example types:
        //       T1Primary, example: RSCColumn
        //       T2Parallel, example: Control (just a placeholder type).    
        //         (Property HasParallelOps will be False.)) 
        //
        //  This class is used to hold a primary operation and a set of secondary operations that are to be executed
        //  in parallel.
        //
        //  This class was conceived after the DLLOperation1D.GetConvertedOperationToType<> method was created.
        //
        //  Example types... The list of RSCRowHeaders gets operated/modified, and then the lists of RSCDataCell
        //    controls have to be operated/modified in parallel.
        //
        //  (If type T1Primary is RSCColumn, then the T2Parallel will be moot.
        //     (Possibly set to Control, as a placeholder.)
        //     (Property HasParallelOps will be False.)) 
        //
        public DLLOperation1D_Of<T1Primary> mod_primaryOp;

        public bool HasParallelOps = false;  

        public DLLOperation1D_Of<T2Parallel>[] _array_secondaryOps;

        public DLLOperation1DsParallel_NotUsed(DLLOperation1D_Of<T1Primary> primaryOp, DLLOperation1D_Of<T2Parallel>[] secondaryOps)
        {
            mod_primaryOp = primaryOp;
            _array_secondaryOps = secondaryOps;
            HasParallelOps = true;

        }


        public DLLOperation1DsParallel_NotUsed(DLLOperation1D_Of<T1Primary> primaryOp)
        {
            //
            // No secondary, parallel operations. 
            //
            mod_primaryOp = primaryOp;
            //_array_secondaryOps = secondaryOps;
            HasParallelOps = false;

            //
            //  This is a bit of a hack.  We need to have a non-null array of secondary operations, even if there are none.
            //
            //_array_secondaryOps = new DLLOperation1D<TSecondary>[0];
            _array_secondaryOps = Array.Empty<DLLOperation1D_Of<T2Parallel>>();

        }


    }
}
