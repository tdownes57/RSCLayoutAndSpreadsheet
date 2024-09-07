using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ciBadgeInterfaces;

namespace TestingRSCSpreadsheetCS
{
    //using System;
    

    // Added 2/27/2024 thomas downes
    public class TwoCharacterDLLHorizontal : TwoCharacterDLLItem, IDoublyLinkedItem<TwoCharacterDLLHorizontal>
    {
        // Added 9/4/2024 td 
        //private mod_item; 

        // Added 2/27/2024 thomas downes
        public TwoCharacterDLLHorizontal(string par_twoChars) : base(par_twoChars)
        {
        }

        public void DLL_SetItemNext_OfT(IDoublyLinkedItem<TwoCharacterDLLHorizontal> param)
        {
            // Throw New NotImplementedException()
            base.DLL_SetItemNext_OfT(param);
        }

        public new void DLL_SetItemPrior_OfT(IDoublyLinkedItem<TwoCharacterDLLItem> param)
        {
            // Throw New NotImplementedException()
            base.DLL_SetItemPrior_OfT(param);
        }

        public TwoCharacterDLLHorizontal DLL_GetItemNext_OfT()
        {
            // Throw New NotImplementedException()
            return base.DLL_GetItemNext_OfT() as TwoCharacterDLLHorizontal;
        }

        public new void DLL_SetItemPrior_OfT(IDoublyLinkedItem<TwoCharacterDLLItem> param)
        {
            // Throw New NotImplementedException()
            base.DLL_SetItemPrior_OfT(param);
        }

        public IDoublyLinkedItem<TwoCharacterDLLHorizontal> GetItemNext_OfT()
        {
            // Throw New NotImplementedException()
            return (TwoCharacterDLLHorizontal)base.DLL_GetItemNext_OfT();
        }

        public new IDoublyLinkedItem<TwoCharacterDLLHorizontal> DLL_GetItemNext_OfT(int param_iterationsOfNext)
        {
            // Throw New NotImplementedException()
            return (TwoCharacterDLLHorizontal)(base.DLL_GetItemNext_OfT(param_iterationsOfNext));
        }

        public new IDoublyLinkedItem<TwoCharacterDLLHorizontal> DLL_GetItemPrior_OfT()
        {
            // Throw New NotImplementedException()
            return (TwoCharacterDLLHorizontal)(base.DLL_GetItemNext_OfT());
        }

        public IDoublyLinkedItem<TwoCharacterDLLHorizontal> IDoublyLinkedItem_DLL_GetItemPrior_OfT(int param_iterationsOfPrior)
        {
            throw new NotImplementedException();
        }

        public TwoCharacterDLLHorizontal DLL_UnboxControl_OfT()
        {
            throw new NotImplementedException();
        }

        public IDoublyLinkedItem<TwoCharacterDLLHorizontal> DLL_GetNextItemFollowingRange_OfT(int param_rangeSize, bool param_mayBeNull)
        {
            throw new NotImplementedException();
        }
    }

}
