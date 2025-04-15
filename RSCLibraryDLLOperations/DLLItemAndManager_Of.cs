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
    public class DLLItemAndManager<TControl> // : ciBadgeInterfaces.IDoublyLinkedItem<TControl>
        where TControl : class, ciBadgeInterfaces.IDoublyLinkedItem<TControl>
    {
        // 
        // Added 01/23/2025 t/h/o/m/a/a d/o/w/n/e/s 
        //
        /// <summary>
        /// This won't be in use, as this is an operation vs. a list item. --2/27/2024
        /// </summary>
        public bool Selected { get; set; } // Implements IDoublyLinkedItem.Selected

        /// <summary>
        /// This won't be in use, as this is an operation vs. a list item. --2/27/2024
        /// </summary>
        public bool HighlightInBlue { get; set; } // Implements IDoublyLinkedItem.HighlightInBlue

        public bool HighlightInGreen { get; set; } // Implements IDoublyLinkedItem.HighlightInGreen
        public bool HighlightInRed { get; set; } // Implements IDoublyLinkedItem.HighlightInRed
        public bool HighlightInCyan { get; set; } // Implements IDoublyLinkedItem.HighlightInCyan

        //public Control _Control { get; set; } // Added 5/3/2024 td

        private const bool ENFORCE_BIDIRECTIONAL = true; // Added 12/08/2024


        private TControl mod_current; // Replace "mod_current" with "mod_current".
        private TControl? mod_next;
        private TControl? mod_prior;
        private TControl? mod_next_priorSortOrder;
        //private char mod_char1;
        //private char mod_char2;
        private bool mod_nextIsNull = false;  // Added 4/15/2025 thomas downes


        public DLLItemAndManager(TControl par_currentMod_current)
        {
            //
            // Added 1/24/2025
            //
            mod_current = par_currentMod_current;
        }


        public void DLL_SetItemNext(TControl param)
        {
            if (param == mod_current) System.Diagnostics.Debugger.Break();
            mod_next = param;
        }


        public void DLL_SetItemNext(IDoublyLinkedItem param)
        {
            if (param == mod_current) System.Diagnostics.Debugger.Break();
            //mod_next = param;
            mod_next = param as TControl;

            // Added 1/24/2025 td
            if (mod_next == null) System.Diagnostics.Debugger.Break();
        }


        public void DLL_SetItemNext(TControl param, bool allowNulls, bool doublyLink)
        {
            if (!allowNulls && param == null)
            {
                throw new Exception("Primary parameter cannot be null.");
            }
            mod_next = param;
            if (doublyLink && param != null)
            {
                param.DLL_SetItemPrior(mod_current);
            }
        }


        public void DLL_SetItemPrior(TControl param) // (IDoublyLinkedItem param)
        {
            if (param == mod_current) System.Diagnostics.Debugger.Break();
            mod_prior = param;
        }

        
        public void DLL_SetItemPrior(IDoublyLinkedItem param)
        {
            if (param == mod_current) System.Diagnostics.Debugger.Break();
            //mod_next = param;
            mod_prior = param as TControl;

            // Added 1/24/2025 td
            if (mod_prior == null) System.Diagnostics.Debugger.Break();

        }


        public void DLL_SetItemNext_OfT(TControl param)
        {
            if (param == mod_current) System.Diagnostics.Debugger.Break();
            mod_next = param;
        }


        public void DLL_SetItemNext_OfT(TControl param, bool pbAllowNulls)
        {
            // If the parameter is the same as the current instance, trigger a breakpoint
            if (param == mod_current)
            {
                System.Diagnostics.Debugger.Break();
            }

            // Handle the setting of the "mod_next" field
            if (param == null && pbAllowNulls)
            {
                mod_next = null;
            }
            else if (param == null && !pbAllowNulls) // Added 12/22/2024
            {
                // Throw an exception if null values are not allowed
                throw new Exception("A null value for Next is not allowed.");
            }
            else
            {
                mod_next = param;
            }

            // Adding bidirectionality --- 12/08/2024
            if (ENFORCE_BIDIRECTIONAL)
            {
                // If param is not null, set its "mod_prior" field to the current instance
                if (param != null)
                {
                    //param.mod_prior = this;
                    param.DLL_SetItemPrior_OfT(mod_current);
                }
            }
        }


        public void DLL_SetItemNext_OfT(TControl param, bool allowNulls, bool doublyLink)
        {
            //
            // Modified 1/24/2025 td
            //
            if (param == mod_current) System.Diagnostics.Debugger.Break();

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

                // Added 4/15/2025 td
                //   Let's re-initialized the Boolean value.
                //  Relevant:  DLL_HasNext(), DLL_NotAnyNext(), DLL_ClearReferenceNext(),
                //     DLL_MarkAsEndOfList(), and DLL_SetItemNext_OfT().
                //
                if (mod_nextIsNull && mod_next != null)
                { 
                    mod_nextIsNull = false;
                }
                

            }

            if (doublyLink && param != null)
            {
                //param.DLL_SetItemPrior_OfT(mod_current);
                param.DLL_SetItemPrior_OfT(mod_current);
            }
        }


        public void DLL_SetItemNext(IDoublyLinkedItem param, bool allowNulls, bool doublyLink)
        {
            //
            // Modified 1/24/2025 td
            //
            if (param == mod_current) System.Diagnostics.Debugger.Break();

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
                mod_next = param as TControl;

                // Added 1/24/2025 
                if (param != null && mod_next == null) System.Diagnostics.Debugger.Break();

            }

            if (doublyLink && param != null)
            {
                //param.DLL_SetItemPrior_OfT(mod_current);
                param.DLL_SetItemPrior(mod_current);
            }
        }


        public void DLL_SetItemPrior_OfT(TControl param)
        {
            if (param == mod_current) System.Diagnostics.Debugger.Break();
            mod_prior = param;
        }


        public void DLL_SetItemPrior_OfT(TControl param, bool pbAllowNulls)
        {
            // If the parameter is the same as the current instance, trigger a breakpoint
            if (param == mod_current)
            {
                System.Diagnostics.Debugger.Break();
            }

            // Handle the setting of the "mod_next" field
            if (param == null && pbAllowNulls)
            {
                //Apr2025  mod_next = null;
                mod_prior = null;
            }
            else if (param == null && !pbAllowNulls) // Added 12/22/2024
            {
                // Throw an exception if null values are not allowed
                throw new Exception("A null value for Next is not allowed.");
            }
            else
            {
                //
                // Set the "prior" placeholder to the parameter.
                //
                mod_prior = param;
            }

            // Adding bidirectionality --- 12/08/2024
            if (ENFORCE_BIDIRECTIONAL)
            {
                // If param is not null, set its "mod_prior" field to the current instance
                if (param != null)
                {
                    //param.mod_prior = this;

                    //---DIFFICULT & CONFUSING----
                    //  Set the new prior item to point to the current one. 
                    //
                    param.DLL_SetItemNext_OfT(mod_current);
                }
            }
        }


        public void DLL_ClearReferencePrior(char operation)
        {
            mod_prior = null;
        }


        /// <summary>
        /// This procedure indicates a terminating endpoint to the list.
        /// </summary>
        /// <param name="operation"></param>
        public void DLL_MarkAsEndOfList()
        {
            mod_next = null;

            // The endpoint will be properly marked. 
            //
            //  The function DLL_HasNext() will check the following Boolean.
            //
            //  Relevant:  DLL_HasNext(), DLL_NotAnyNext(), DLL_ClearReferenceNext(),
            //     DLL_MarkAsEndOfList(), and DLL_SetItemNext_OfT().
            //
            //    ---Added 4/15/2025 td
            //
            mod_nextIsNull = true;

        }


        /// <summary>
        /// This procedure indicates a terminating endpoint to the list.
        /// </summary>
        /// <param name="par_operation">This may help the programmer to know why the reference is being cleared.</param>
        public void DLL_ClearReferenceNext(char par_operation)
        {
            mod_next = null;

            // The endpoint will be properly cleared. 
            //
            //  The function DLL_HasNext() will check the following Boolean.
            //
            //  Relevant:  DLL_HasNext(), DLL_NotAnyNext(), DLL_ClearReferenceNext(),
            //     DLL_MarkAsEndOfList(), and DLL_SetItemNext_OfT().
            //
            //    ---Added 4/15/2025 td
            //
            mod_nextIsNull = true;  

        }

        public bool DLL_NotAnyNext()
        {
            //Apr2025  return mod_next == null;

            // Modified 4/15/2025 td
            if (mod_next == null && (! mod_nextIsNull))
            {
                // The endpoint is not properly cleared. 
                //
                //  Programmer must use DLL_ClearReferenceNext() for endpoints.
                //
                //  Find "mod_nextIsNull = true;" in Sub DLL_ClearReferenceNext().
                //
                //  Relevant:  DLL_HasNext(), DLL_NotAnyNext(), DLL_ClearReferenceNext(),
                //     DLL_MarkAsEndOfList(), and DLL_SetItemNext_OfT().
                //
                //    ---Added 4/15/2025 td
                //
                System.Diagnostics.Debugger.Break();
                return true;  // false ;
            }
            else
            {
                //return (mod_next != null);
                return (mod_next == null);
            }

        }

        public bool DLL_NotAnyPrior()
        {
            return mod_prior == null;
        }

        public bool DLL_HasNext()
        {
            //return mod_next != null;

            // Modified 4/15/2025 td
            if (mod_next == null && (! mod_nextIsNull))
            {
                // The endpoint is not properly cleared. 
                //
                //  Programmer must use DLL_ClearReferenceNext() for endpoints.
                //
                //  Find "mod_nextIsNull = true;" in Sub DLL_ClearReferenceNext().
                //
                //  Relevant:  DLL_HasNext(), DLL_NotAnyNext(), DLL_ClearReferenceNext(),
                //     and DLL_MarkAsEndOfList().
                //
                //    ---Added 4/15/2025 td
                //
                System.Diagnostics.Debugger.Break();
                return false;
            }
            else
            {
                return (mod_next != null);
            }

        }

        public bool DLL_HasPrior()
        {
            return mod_prior != null;
        }

        public IDoublyLinkedItem DLL_GetItemNext()
        {
            if (mod_next == mod_current) System.Diagnostics.Debugger.Break();
            return mod_next;
        }


        public IDoublyLinkedItem DLL_GetItemNext(int param_iterationsOfNext)
        {
            // Throw new NotImplementedException();

            TControl? tempNext = mod_next;

            if (param_iterationsOfNext > 1)
            {
                for (int index = 2; index <= param_iterationsOfNext; index++)
                {
                    if (tempNext == null)
                    {
                        System.Diagnostics.Debugger.Break(); // 12/31/2023
                    }
                    //tempNext = tempNext.mod_next;
                    tempNext = tempNext.DLL_GetItemNext_OfT();
                }
            }

            if (param_iterationsOfNext == 0)
                //return this;
                return mod_current;

            if (param_iterationsOfNext == 1)
                return mod_next;

            return tempNext;

        }



        public TControl DLL_GetItemNext_OfT()
        {
            if (mod_next == mod_current) System.Diagnostics.Debugger.Break();
            return (TControl)mod_next;
        }


        public TControl DLL_GetItemNext_OfT(int par_intHowManyIterations)
        {
            //
            // Added 1/24/2025 
            //
            if (0 == par_intHowManyIterations) return mod_current;
            TControl temp = DLL_GetItemNext_OfT();
            if (1 == par_intHowManyIterations) return temp;
            int count = 1;
            while (temp != null && count < par_intHowManyIterations)
            {
                //count++;
                temp = temp.DLL_GetItemNext_OfT();
                count++;
            }
            return temp;


        }


        public IDoublyLinkedItem DLL_GetItemPrior()
        {
            if (mod_prior == mod_current) System.Diagnostics.Debugger.Break();
            return mod_prior;
        }


        public IDoublyLinkedItem DLL_GetItemPrior(int param_iterationsOfNext)
        {
            // Throw new NotImplementedException();

            TControl? tempPrior = mod_next;

            if (param_iterationsOfNext > 1)
            {
                for (int index = 2; index <= param_iterationsOfNext; index++)
                {
                    if (tempPrior == null)
                    {
                        System.Diagnostics.Debugger.Break(); // 12/31/2023
                    }
                    //tempPrior = tempPrior.mod_prior;
                    tempPrior = tempPrior.DLL_GetItemPrior_OfT();
                }
            }

            if (param_iterationsOfNext == 0)
                //return this;
                return mod_current;

            if (param_iterationsOfNext == 1)
                return mod_prior;

            return tempPrior;

        }


        public TControl DLL_GetItemPrior_OfT()
        {
            if (mod_prior == mod_current) System.Diagnostics.Debugger.Break();
            return (TControl)mod_prior;
        }


        public TControl DLL_GetItemPrior_OfT(int par_intHowManyIterations)
        {
            //
            // Added 1/24/2025 
            //
            if (0 == par_intHowManyIterations) return mod_current;
            TControl temp = DLL_GetItemPrior_OfT();
            if (1 == par_intHowManyIterations) return temp;
            int count = 1;
            while (temp != null && count < par_intHowManyIterations)
            {
                //count++;
                temp = temp.DLL_GetItemPrior_OfT();
                count++;
            }
            return temp;


        }


        public override string ToString()
        {
            //return mod_char1.ToString() + mod_char2.ToString();
            return mod_current.ToString();
        }

        public string DLL_GetValue()
        {
            //return mod_char1.ToString() + mod_char2.ToString();
            return mod_current.ToString();
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
            //var temp = mod_current;
            TControl temp = mod_current; 
            while (temp.DLL_HasPrior())
            {
                //temp = (TControl)temp.DLL_GetItemPrior();
                temp = temp.DLL_GetItemPrior_OfT();
            }
            //return (TControl)temp;
            return temp;
        }

        public TControl DLL_GetItemLast()
        {
            //var temp = mod_current;
            TControl temp = mod_current;
            
            while (temp.DLL_HasNext())
            {
                //temp = (TControl)temp.DLL_GetItemNext();
                temp = temp.DLL_GetItemNext_OfT();
            }
            //return (TControl)temp;
            return temp;

        }



        public TControl DLL_GetNextItemFollowingRange_OfT(int paramRangeSize, bool paramMayBeNull)
        {
            return DLL_GetItemNext_OfT(paramRangeSize);
        }


        public int DLL_GetDistanceTo(TControl paramItem)
        {
            bool located = false;
            //int result = DLL_GetDistanceTo(paramItem, out located);
            int result = DLL_GetDistanceTo(paramItem, ref located);
            if (!located) System.Diagnostics.Debugger.Break();
            return result;
        }


        public int DLL_GetDistanceTo(TControl paramItem, ref bool locatedItem)
        {
            //public int DLL_GetDistanceTo(TControl paramItem, out bool locatedItem)
            //var tempItem = mod_current;
            TControl tempItem = mod_current;
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

            TControl temp = DLL_GetItemNext_OfT();
            doneLooping = (temp == null);

            while (!doneLooping && temp != null)
            {
                resultAnySelected = resultAnySelected || temp.Selected == true;
                if (temp != null) temp = temp.DLL_GetItemNext_OfT();
                doneLooping = temp == null || resultAnySelected;
            }

            return resultAnySelected;
        }



        /// <summary>
        /// mod_current gets the items which is (par_index_b0) iterations from the very first item.  The index is 0-based.
        /// </summary>
        /// <param name="par_index"></param>
        /// <returns></returns>
        public TControl DLL_GetItemAtIndex_b0(int par_index_b0)
        {
            TControl itemFirst = DLL_GetItemFirst();
            int iterationsOfNext = par_index_b0;
            return itemFirst.DLL_GetItemNext_OfT(iterationsOfNext);
        }


        /// <summary>
        /// mod_current gets the items which is (par_index_b1 minus 1) iterations from the very first item.  The index is 1-based.
        /// </summary>
        /// <param name="par_index"></param>
        /// <returns></returns>
        public TControl DLL_GetItemAtIndex_b1(int par_index_b1)
        {
            TControl itemFirst = DLL_GetItemFirst();
            int iterationsOfNext = -1 + par_index_b1;
            return itemFirst.DLL_GetItemNext_OfT(iterationsOfNext);
        }


        public int DLL_GetItemIndex_b1()
        {
            int resultIndex = 0;
            //var temp = mod_current;
            TControl temp = mod_current;
            while (temp != null)
            {
                resultIndex++;
                temp = temp.DLL_GetItemPrior_OfT();
            }
            return resultIndex;

        }

        public int DLL_GetItemIndex_b0()
        {
            return DLL_GetItemIndex_b1() - 1;
        }


        public bool DLL_IsEitherEndpoint()
        {
            // Throw new NotImplementedException();
            return (mod_next == null || mod_prior == null);
        }


        public void DLL_InsertItemToNext(TControl param, bool doubleLink)
        {
            if (param == mod_current || param == null || !doubleLink) System.Diagnostics.Debugger.Break();

            if (mod_next != null)
            {
                mod_next.DLL_SetItemPrior_OfT(param);
                param.DLL_SetItemNext_OfT(mod_next);
            }

            mod_next = param;
            param.DLL_SetItemPrior_OfT(mod_current);

        }


        public void DLL_InsertItemToPrior(TControl param, bool setDoubleLink)
        {
            if (param == mod_current || param == null || !setDoubleLink) System.Diagnostics.Debugger.Break();

            if (mod_prior != null)
            {
                mod_prior.DLL_SetItemNext_OfT(param);
                param.DLL_SetItemPrior_OfT(mod_prior);
            }

            mod_prior = param;
            param.DLL_SetItemNext_OfT(mod_current);
        }

        public void DLL_SaveCurrentSortOrder_ToPrior(bool executeInCascade)
        {
            string mod_currentItem = DLL_GetValue();
            mod_next_priorSortOrder = mod_next;

            if (executeInCascade)
            {
                mod_next?.DLL_SaveCurrentSortOrder_ToPrior(executeInCascade);
            }
        }

        public void DLL_RestorePriorSortOrder(int countdownItems)
        {
            string mod_currentItem = DLL_GetValue();
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
                    //mod_next.mod_prior = mod_current;
                    mod_next.DLL_SetItemPrior_OfT(mod_current);
                    preRestorationNext.DLL_RestorePriorSortOrder(countdownItems);
                }
            }
            catch (NullReferenceException)
            {
                //''Do nothing. 
                //''-- - 12 / 29 / 2024 td
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


        public T_BaseOrParallel GetConvertToGeneric_OfT<T_BaseOrParallel>(T_BaseOrParallel par_firstItem) 
            where T_BaseOrParallel : IDoublyLinkedItem<T_BaseOrParallel>
        {
            int indexB0 = DLL_GetItemIndex_b0();
            // Let's make sure we have the first item in the list.
            T_BaseOrParallel firstItem = par_firstItem.DLL_GetItemFirst();
            T_BaseOrParallel result = firstItem.DLL_GetItemAtIndex_b0(indexB0);
            return result;
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