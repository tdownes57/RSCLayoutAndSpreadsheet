using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    /// <summary>
    /// This operation object allows 
    /// </summary>
    /// <typeparam name="THeader"></typeparam>
    /// <typeparam name="TParallel"></typeparam>
    /// <typeparam name="TAcross"></typeparam>
    internal class DLLOperation2D_Composition_NotUsed<THeader, TParallel, TAcross>
           where THeader : class, IDoublyLinkedItem<THeader>
           where TParallel : class, IDoublyLinkedItem<TParallel>
           where TAcross : class, IDoublyLinkedItem<TAcross>
    {
        //
        // Added 6/09/2025 thomas downes
        //
        private DLLOperation1D_2TypesInParallel<THeader, TParallel>? mod_operationVertical;
        private DLLOperation1D_Of<TAcross>? mod_operationAcross;

        public DLLOperation2D_Composition_NotUsed(DLLOperation1D_2TypesInParallel<THeader, TParallel> par_operationVertical)
        {

            mod_operationVertical = par_operationVertical;

         }


        public DLLOperation2D_Composition_NotUsed(DLLOperation1D_Of<TAcross> par_operationAcross)
        {

            mod_operationAcross = par_operationAcross;
             

        }


    }
}
