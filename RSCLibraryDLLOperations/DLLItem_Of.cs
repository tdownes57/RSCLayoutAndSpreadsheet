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
        private TControl mod_current; // Replace "this" with "mod_current".
        private TControl mod_next;
        private TControl mod_prior;
        private TControl mod_next_priorSortOrder;
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



        public TControl DLL_GetNextItemFollowingRange_OfT(int paramRangeSize, bool paramMayBeNull)
        {
            return DLL_GetItemNext_OfT(paramRangeSize);
        }

        public int DLL_GetDistanceTo(TControl paramItem)
        {
            bool located;
            int result = DLL_GetDistanceTo(paramItem, out located);
            if (!located) System.Diagnostics.Debugger.Break();
            return result;
        }

        public int DLL_GetDistanceTo(TControl paramItem, out bool locatedItem)
        {
            var tempItem = this;
            int resultDistance = 0;
            bool foundItem = false;
            const int LoopLimit = 2000;
            locatedItem = false;

            do
            {
                if (tempItem == paramItem)
                {
                    foundItem = true;
                    locatedItem = true;
                    break;
                }
                else if (tempItem.DLL_HasNext())
                {
                    tempItem = tempItem.DLL_GetItemNext_OfT();
                    resultDistance++;
                }
                else
                {
                    if (resultDistance > LoopLimit) System.Diagnostics.Debugger.Break();
                    break;
                }
            } while (true);

            if (!foundItem)
            {
                resultDistance = 0;
                do
                {
                    if (tempItem == paramItem)
                    {
                        return resultDistance;
                    }
                    else if (tempItem.DLL_HasPrior())
                    {
                        tempItem = tempItem.DLL_GetItemPrior_OfT();
                        resultDistance--;
                    }
                    else
                    {
                        break;
                    }
                } while (true);
            }

            locatedItem = foundItem;
            return resultDistance;
        }

        public bool SelectedAnyItemToFollow()
        {
            bool resultAnySelected = false;
            bool doneLooping = false;

            var temp = DLL_GetItemNext_OfT();
            doneLooping = temp == null;

            while (!doneLooping)
            {
                resultAnySelected = resultAnySelected || temp?.Selected == true;
                temp = temp.DLL_GetItemNext();
                doneLooping = temp == null || resultAnySelected;
            }

            return resultAnySelected;
        }

        public int DLL_GetItemIndex_b1()
        {
            int resultIndex = 0;
            var temp = this;
            while (temp != null)
            {
                resultIndex++;
                temp = temp.DLL_GetItemPrior();
            }
            return resultIndex;
        }

        public int DLL_GetItemIndex_b0()
        {
            return DLL_GetItemIndex_b1() - 1;
        }

        public void DLL_InsertItemToNext(TControl param, bool doubleLink)
        {
            if (param == this || param == null || !doubleLink) System.Diagnostics.Debugger.Break();

            if (mod_next != null)
            {
                mod_next.DLL_SetItemPrior_OfT(param);
                param.DLL_SetItemNext_OfT(mod_next);
            }

            mod_next = param;
            param.DLL_SetItemPrior_OfT(this);
        }

        public void DLL_InsertItemToPrior(TControl param, bool setDoubleLink)
        {
            if (param == this || param == null || !setDoubleLink) System.Diagnostics.Debugger.Break();

            if (mod_prior != null)
            {
                mod_prior.DLL_SetItemNext_OfT(param);
                param.DLL_SetItemPrior_OfT(mod_prior);
            }

            mod_prior = param;
            param.DLL_SetItemNext_OfT(this);
        }

        public void DLL_SaveCurrentSortOrder_ToPrior(bool executeInCascade)
        {
            string thisItem = DLL_GetValue();
            mod_next_priorSortOrder = mod_next;

            if (executeInCascade)
            {
                mod_next?.DLL_SaveCurrentSortOrder_ToPrior(executeInCascade);
            }
        }

        public void DLL_RestorePriorSortOrder(int countdownItems)
        {
            string thisItem = DLL_GetValue();
            var preRestorationNext = mod_next;
            bool notDoneYet;

            preRestorationNext = mod_next;
            countdownItems--;

            if (mod_next_priorSortOrder == null)
            {
                notDoneYet = countdownItems > 0;
                if (notDoneYet)
                {
                    System.Diagnostics.Debugger.Break();
                }
            }

            mod_next = mod_next_priorSortOrder;

            try
            {
                if (mod_next != null)
                {
                    mod_next.mod_prior = this;
                    preRestorationNext.DLL_RestorePriorSortOrder(countdownItems);
                }
            }
            catch (NullReferenceException)
            {
            }
        }

        public void DLL_ClearPriorSortOrder(bool executeInCascade)
        {
            mod_next_priorSortOrder = null;

            if (executeInCascade)
            {
                mod_next?.DLL_ClearPriorSortOrder(executeInCascade);
            }
        }

        public TControl GetConvertToGeneric_OfT<T_BaseOrParallel>(T_BaseOrParallel firstItem) where T_BaseOrParallel : IDoublyLinkedItem<T_BaseOrParallel>
        {
            int indexB0 = DLL_GetItemIndex_b0();
            firstItem = firstItem.DLL_GetItemFirst();
            return firstItem.DLL_GetItemAtIndex_b0(indexB0);
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