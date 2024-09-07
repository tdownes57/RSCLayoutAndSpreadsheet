using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using System.Diagnostics;
    //using System.Windows.Forms;
    using ciBadgeInterfaces;
    //using Windows.Win32.UI;

namespace TestingRSCSpreadsheetCS
{

    public class TwoCharacterDLLItem : IDoublyLinkedItem<TwoCharacterDLLItem>
    {
        // This won't be in use, as this is an operation vs. a list item. --2/27/2024
        public bool Selected { get; set; }
        public Control? _Control { get; set; } // Added 5/3/2024 td

        private TwoCharacterDLLItem? mod_prior;
        private TwoCharacterDLLItem? mod_next;
        // July2024 Private mod_twoChars As String
        private char mod_char1; // String
        private char mod_char2; // String

        public TwoCharacterDLLItem(string par_twoChars) // , par_prior As TwoCharacterDLLItem)
        {
            mod_prior = null; // par_prior
                              // mod_next = par_next
                              // July2024 mod_twoChars = par_twoChars
            mod_char1 = par_twoChars[0]; // This is VB not C#.
            mod_char2 = par_twoChars[1]; // This is VB not C#.
        }

        public TwoCharacterDLLItem(string par_twoChars, TwoCharacterDLLItem par_prior)
        {
            mod_prior = par_prior;
            // mod_next = par_next
            // July2024 mod_twoChars = par_twoChars
            mod_char1 = par_twoChars[0]; // This is VB not C#.
            mod_char2 = par_twoChars[1]; // This is VB not C#.
        }

        public TwoCharacterDLLItem(string par_twoChars, TwoCharacterDLLItem par_prior, TwoCharacterDLLItem par_next)
        {
            mod_prior = par_prior;
            mod_next = par_next;
            // July2024 mod_twoChars = par_twoChars
            mod_char1 = par_twoChars[0]; // This is VB not C#.
            mod_char2 = par_twoChars[1]; // This is VB not C#.
        }

        public void DLL_SetItemNext(IDoublyLinkedItem param)
        {
            // Throw New NotImplementedException()
            if (param == this) Debugger.Break();
            mod_next = (TwoCharacterDLLItem)param;
        }

        public void DLL_SetItemPrior(IDoublyLinkedItem param)
        {
            // Throw New NotImplementedException()
            if (param == this) Debugger.Break();
            mod_prior = (TwoCharacterDLLItem)param;
        }

        public void DLL_SetItemNext_OfT(IDoublyLinkedItem<TwoCharacterDLLItem> param)
        {
            // Throw New NotImplementedException()
            if (param == this) Debugger.Break();
            mod_next = (TwoCharacterDLLItem)param;
        }

        public void DLL_SetItemPrior_OfT(IDoublyLinkedItem<TwoCharacterDLLItem> param)
        {
            // Throw New NotImplementedException()
            if (param == this) Debugger.Break();
            mod_prior = (TwoCharacterDLLItem)param;
        }

        public void DLL_ClearReferencePrior(char par_typeOp)
        {
            // Throw New NotImplementedException()
            mod_prior = null;
        }

        public void DLL_ClearReferenceNext(char par_typeOp)
        {
            // Throw New NotImplementedException()
            mod_next = null;
        }

        public bool DLL_NotAnyNext()
        {
            // Throw New NotImplementedException()
            return (mod_next == null);
        }

        public bool DLL_NotAnyPrior()
        {
            // Throw New NotImplementedException()
            return (mod_prior == null);
        }

        public bool DLL_HasNext()
        {
            // Throw New NotImplementedException()
            return (mod_next != null);
        }

        public bool DLL_HasPrior()
        {
            // Throw New NotImplementedException()
            return (mod_prior != null);
        }

        public IDoublyLinkedItem<TwoCharacterDLLItem> DLL_GetItemNext_OfT()
        {
            // Throw New NotImplementedException()
            if (mod_next == this) Debugger.Break();
            return mod_next;
        }

        public IDoublyLinkedItem DLL_GetItemNext()
        {
            // Throw New NotImplementedException()
            if (mod_next == this) Debugger.Break();
            return mod_next;
        }

        public IDoublyLinkedItem<TwoCharacterDLLItem> DLL_GetItemNext_OfT(int param_iterationsOfNext)
        {
            // Throw New NotImplementedException()

            TwoCharacterDLLItem tempNext = mod_next;
            if (param_iterationsOfNext > 1)
            {
                for (int index = 2; index <= param_iterationsOfNext; index++)
                {
                    if (tempNext == null) Debugger.Break(); // 12/31/2023
                    tempNext = tempNext.mod_next;
                }
            }
            if (param_iterationsOfNext == 0) return this;
            if (param_iterationsOfNext == 1) return mod_next;
            return tempNext;
        }

        public IDoublyLinkedItem DLL_GetItemNext(int param_iterationsOfNext)
        {
            // Throw New NotImplementedException()

            TwoCharacterDLLItem tempNext = mod_next;
            if (param_iterationsOfNext > 1)
            {
                for (int index = 2; index <= param_iterationsOfNext; index++)
                {
                    if (tempNext == null) Debugger.Break(); // 12/31/2023
                    tempNext = tempNext.mod_next;
                }
            }
            if (param_iterationsOfNext == 0) return this;
            if (param_iterationsOfNext == 1) return mod_next;
            return tempNext;
        }

        /// <summary>
        /// Get item following a range (if the implicit parameter is the first item in a range). 
        /// Sometimes we need the Item which follows the Range, to prepare for a possible Undo.
        /// </summary>
        /// <param name="param_rangeSize">This is the item-count of the range, or size of the range.</param>
        /// <returns>The first item which follows the range.</returns>
        public IDoublyLinkedItem DLL_GetNextItemFollowingRange(int param_rangeSize, bool param_mayBeNull)
        {
            // Added 12/30/2023 
            // ---DIFFICULT AND CONFUSING---
            // By CS-related rules of iteration, by moving ahead
            // a number of jumps equal to the item-count of the range,
            // we get the first post-range item.
            // ---12/30/2023 tdownes
            // 12/2023 Return DLL_GetItemNext(param_rangeSize)

            IDoublyLinkedItem result = DLL_GetItemNext(param_rangeSize);

            // Check for Nulls!
            if (!param_mayBeNull && result == null)
            {
                Debugger.Break();
            }

            return result;
        }

        public IDoublyLinkedItem DLL_GetItemPrior()
        {
            // Throw New NotImplementedException()

            if (mod_prior == this) Debugger.Break();
            return mod_prior;
        }

        public IDoublyLinkedItem DLL_GetItemPrior(int param_iterationsOfPrior)
        {
            // Throw New NotImplementedException()

            if (mod_prior == this) Debugger.Break();
            return mod_prior;
        }

        public IDoublyLinkedItem<TwoCharacterDLLItem> DLL_GetItemPrior_OfT()
        {
            // Throw New NotImplementedException()

            if (mod_prior == this) Debugger.Break();
            return mod_prior;
        }

        public IDoublyLinkedItem<TwoCharacterDLLItem> DLL_GetItemPrior_OfT(int param_iterationsOfPrior)
        {
            // Throw New NotImplementedException()
            if (mod_prior == this) Debugger.Break();

            TwoCharacterDLLItem tempPrior = mod_prior;

            if (param_iterationsOfPrior > 1)
            {
                for (int index = 2; index <= param_iterationsOfPrior; index++)
                {
                    tempPrior = tempPrior.mod_prior;
                }
            }
            if (param_iterationsOfPrior == 0) return this;
            return tempPrior;
        }

        public Control DLL_UnboxControl()
        {
            throw new NotImplementedException();
        }

        public TwoCharacterDLLItem DLL_UnboxControl_OfT()
        {
            throw new NotImplementedException();
        }

        public bool DLL_IsEitherEndpoint()
        {
            // Throw New NotImplementedException()
            return (mod_next == null || mod_prior == null);
        }

        public override string ToString()
        {
            // Added 12/26/2023
            // July2024 Return mod_twoChars
            return (mod_char1.ToString() + mod_char2.ToString());
        }

        public string DLL_GetValue()
        {
            // Throw New NotImplementedException()
            // July2024 Return mod_twoChars
            return (mod_char1.ToString() + mod_char2.ToString());
        }

        public int DLL_CountItemsAllInList()
        {
            // ---Throw New NotImplementedException()
            Debugger.Break();
            return -1;
        }

        public int DLL_CountItemsPrior()
        {
            // Throw New NotImplementedException()
            int result_count = 0;
            IDoublyLinkedItem temp = DLL_GetItemPrior();
            while (temp != null)
            {
                result_count += 1;
                temp = temp.DLL_GetItemPrior();
            }
            return result_count;
        }

        public IDoublyLinkedItem<TwoCharacterDLLItem> DLL_GetNextItemFollowingRange_OfT(int param_rangeSize, bool param_mayBeNull)
        {
            // Added 7/11/2024 
            return DLL_GetItemNext_OfT(param_rangeSize);
        }
    }


}
