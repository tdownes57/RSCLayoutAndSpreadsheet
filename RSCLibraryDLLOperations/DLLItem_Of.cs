using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Added `1/23/2025 t/h/o/m/a/a d/o/w/n/e/s 
using ciBadgeInterfaces;
//using System.Windows.Forms; 

// Added `1/23/2025 t/h/o/m/a/a d/o/w/n/e/s 
namespace RSCLibraryDLLOperations
{
    // Added 1/23/2025 t/h/o/m/a/a d/o/w/n/e/s 
    public class DLLItem_Of<TControl> : ciBadgeInterfaces.IDoublyLinkedItem<TControl>
        where TControl : class, ciBadgeInterfaces.IDoublyLinkedItem<TControl>
    {
        //
        // Added `1/23/2025 t/h/o/m/a/a d/o/w/n/e/s 
        //
        private IDoublyLinkedItem mod_next;
        private IDoublyLinkedItem mod_prior;
        private IDoublyLinkedItem mod_next_priorSortOrder;
        private char mod_char1;
        private char mod_char2;

        public void DLL_SetItemNext(IDoublyLinkedItem param)
        {
            if (param == this) System.Diagnostics.Debugger.Break();
            mod_next = param;
        }

        public void DLL_SetItemNext(IDoublyLinkedItem param, bool allowNulls, bool doublyLink)
        {
            if (!allowNulls && param == null)
            {
                throw new Exception("Primary parameter cannot be null.");
            }
            mod_next = param;
            if (doublyLink && param != null)
            {
                param.DLL_SetItemPrior(this);
            }
        }

        public void DLL_SetItemPrior(IDoublyLinkedItem param)
        {
            if (param == this) System.Diagnostics.Debugger.Break();
            mod_prior = param;
        }

        public void DLL_SetItemNext_OfT(TControl param)
        {
            if (param == this) System.Diagnostics.Debugger.Break();
            mod_next = param;
        }

        public void DLL_SetItemNext_OfT(TControl param, bool allowNulls, bool doublyLink)
        {
            if (param == this) System.Diagnostics.Debugger.Break();

            if (param == null && allowNulls)
            {
                mod_next = null;
            }
            else if (param == null && !allowNulls)
            {
                throw new Exception("A null value for Next is not allowed.");
            }
            else
            {
                mod_next = param;
            }

            if (doublyLink && param != null)
            {
                param.DLL_SetItemPrior_OfT(this);
            }
        }

        public void DLL_SetItemPrior_OfT(TControl param)
        {
            if (param == this) System.Diagnostics.Debugger.Break();
            mod_prior = param;
        }

        public void DLL_ClearReferencePrior(char operation)
        {
            mod_prior = null;
        }

        public void DLL_ClearReferenceNext(char operation)
        {
            mod_next = null;
        }

        public bool DLL_NotAnyNext()
        {
            return mod_next == null;
        }

        public bool DLL_NotAnyPrior()
        {
            return mod_prior == null;
        }

        public bool DLL_HasNext()
        {
            return mod_next != null;
        }

        public bool DLL_HasPrior()
        {
            return mod_prior != null;
        }

        public IDoublyLinkedItem DLL_GetItemNext()
        {
            if (mod_next == this) System.Diagnostics.Debugger.Break();
            return mod_next;
        }

        public TControl DLL_GetItemNext_OfT()
        {
            if (mod_next == this) System.Diagnostics.Debugger.Break();
            return (TControl)mod_next;
        }

        public IDoublyLinkedItem DLL_GetItemPrior()
        {
            if (mod_prior == this) System.Diagnostics.Debugger.Break();
            return mod_prior;
        }

        public TControl DLL_GetItemPrior_OfT()
        {
            if (mod_prior == this) System.Diagnostics.Debugger.Break();
            return (TControl)mod_prior;
        }

        public override string ToString()
        {
            return mod_char1.ToString() + mod_char2.ToString();
        }

        public string DLL_GetValue()
        {
            return mod_char1.ToString() + mod_char2.ToString();
        }

        public int DLL_CountItemsAllInList()
        {
            return 1 + DLL_CountItemsPrior() + DLL_CountItemsAfter();
        }

        public int DLL_CountItemsPrior()
        {
            int count = 0;
            var temp = DLL_GetItemPrior();
            while (temp != null)
            {
                count++;
                temp = temp.DLL_GetItemPrior();
            }
            return count;
        }

        public int DLL_CountItemsAfter()
        {
            int count = 0;
            var temp = DLL_GetItemNext();
            while (temp != null)
            {
                count++;
                temp = temp.DLL_GetItemNext();
            }
            return count;
        }

        public TControl DLL_GetItemFirst()
        {
            var temp = this;
            while (temp.DLL_HasPrior())
            {
                temp = (TControl)temp.DLL_GetItemPrior();
            }
            return (TControl)temp;
        }

        public TControl DLL_GetItemLast()
        {
            var temp = this;
            while (temp.DLL_HasNext())
            {
                temp = (TControl)temp.DLL_GetItemNext();
            }
            return (TControl)temp;
        }

        public TControl[] GetConvertToArray()
        {
            int count = DLL_CountItemsAllInList();
            var array = new TControl[count];
            var temp = DLL_GetItemFirst();

            for (int i = 0; i < count; i++)
            {
                array[i] = temp;
                temp = temp.DLL_GetItemNext_OfT();
            }
            return array;
        }
    }




}
}
