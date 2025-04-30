using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RSCLibraryDLLOperations
{
    // April2025  public partial class DLLList<TControl>
    public partial class DLLList<TControl> //, TControlParallel>
    {
        //
        // Added 12/12/2024 thomas d. 
        //
        //----------------------------------------------------------------------------------------------------------------
        // Following commented-out VB code is from:
        //
        //         Module DLL_List_OfTControl_SORTING.vb
        //             (located in project ciBadgeInterfaces\AClassOrTwo)
        //
        //         Full path is as follows:
        //
        //             C:\Users\tomdo\source\repos\ciLayout\ciBadgeInterfaces\AClassOrTwo\DLL_List_OfTControl_SORTING.vb
        //----------------------------------------------------------------------------------------------------------------
        //
        //
        public TControl? _itemStart_PriorSortOrder;  //Moved to this module from DLLList_Of.cs, on 12/30/2024 --Added 12/12/2024 td
        public TControl? _itemEnding_PriorSortOrder;  //Moved to this module from DLLList_Of.cs, on 12/30/2024 --Added 12/29/2024 td

        //Go to DLLOperation_Of.cs  public TControl[] _array_SortOrderIfUndo;  //Added 12/29/2024 td  
        //Go to DLLOperation_Of.cs  public TControl[] _array_SortOrderThisOp;  //Added 12/29/2024 td  


        public void SaveCurrentSortOrder_ToPrior(DLLOperation1D_Of<TControl> par_op, 
                 bool pbOutputArrayOfControls, 
                 out TControl[] out_arrayControls)
        {
            //
            // Added 12/12/2024 thomas downes 
            //
            TControl[] arrayControls_SortOrderIfUndo;  
            _itemStart.DLL_SaveCurrentSortOrder_ToPrior(true);

            // Added 12/29/2024 thomas downes
            _itemStart_PriorSortOrder = _itemStart;
            _itemEnding_PriorSortOrder = _itemEnding;

            //
            // Added 12/30/2024 thomas downes
            //
            // Place the sort order into the operation, for possible undo.
            //   (As opposed to, inside the list itself.)
            //
            par_op._itemStart_SortOrderIfUndo = _itemStart;
            par_op._itemEnding_SortOrderIfUndo = _itemEnding;
            TControl currentItem = _itemStart;
            arrayControls_SortOrderIfUndo = new TControl[_itemCount];

            // Save all of the items, in their current order. 
            for (int index = 0; index < _itemCount; index++)
            {
                arrayControls_SortOrderIfUndo[index] = currentItem;
                currentItem = currentItem.DLL_GetItemNext_OfT();
            }

            // Added 1/13/2025 thomas downes
            out_arrayControls = arrayControls_SortOrderIfUndo;

        }


        public void SaveCurrentSortOrder_ToControlArray(out TControl[] out_arrayControls)
        {
            //
            // Added 12/12/2024 thomas downes 
            //
            TControl[] arrayControls_SortOrderForRedo;
            TControl currentItem = _itemStart;
            arrayControls_SortOrderForRedo = new TControl[_itemCount];

            // Save all of the items, in their current order. 
            for (int index = 0; index < _itemCount; index++)
            {
                arrayControls_SortOrderForRedo[index] = currentItem;
                currentItem = currentItem.DLL_GetItemNext_OfT();
            }

            // Added 1/13/2025 thomas downes
            out_arrayControls = arrayControls_SortOrderForRedo;

        }

        /// <summary>
        /// Returns a list of indices, which can be used to undo-sort the items by index.
        /// For the RSCColumn controls, each control contains a list of controls (RSCDataCells),
        ///  and the RSCDataCells are not directly linked to the RSCRowHeaders.  So, we need
        ///  Control-independent indices, to easily sort the RSCDataCell controls (by index alone).
        /// </summary>
        /// <param name="arrayControls_priorToSort"></param>
        /// <returns></returns>
        public int[] GetPriorSortOrderForUndo_ByIndex(TControl[] par_arrayControls_priorToSort)
        {
            //
            // Added 1/13/2025 thomas downes
            //
            int[] return_arrayIndicesForUndo = new int[_itemCount];
            TControl? tempItem = _itemStart;
            int each_index; // Added 4/23/2025

            //
            // Create an array of indices, which will be used to sort the items by index.
            //
            //+++for (int index = 0; index < _itemCount; index++)
            //+++while (tempItem != null)
            for (int index = 0; index < _itemCount; index++)
            {
                //-----This may NOT be what we are looking for.
                //-----  We may be looking for the index of the items in the Prior-To-Sorting 
                //-----  list, instead of index relative to the current sort order.
                //-----   ---1/13/2025 td
                //---return_arrayIndices[index] = par_arrayControls_priorToSort[index].DLL_GetItemIndex_b1();
                
                const bool STORE_INDICES_FOR_SORT_REDO = false; // Jan. 13 2025 td
                const bool STORE_INDICES_FOR_SORT_UNDO = true;  // Jan. 13 2025 td

                if (STORE_INDICES_FOR_SORT_UNDO)
                {
                    each_index = par_arrayControls_priorToSort[index].DLL_GetItemIndex_base1();
                    return_arrayIndicesForUndo[index] = each_index;
                }
                if (STORE_INDICES_FOR_SORT_REDO)
                {
                    // NOT THE CORRECT WAY TO DO IT.  ---1/13/2025 td
                    return_arrayIndicesForUndo[index] = Array.FindIndex(par_arrayControls_priorToSort, item => item == tempItem);
                }

                //Prepare for next iteration. 
                tempItem = tempItem.DLL_GetItemNext_OfT();

            }

            //
            // Output.
            //
            return return_arrayIndicesForUndo;

        }



        public void RestorePriorSortOrder(bool pbAlsoClearPriorSortOrder)
        {
            //
            // Added 12/12/2024 thomas downes 
            //
            // 12-29-2024 td //_itemStart_PriorSortOrder.DLL_RestorePriorSortOrder();
            // 12-29-2024 td //__itemStart_PriorSortOrder.DLL_RestorePriorSortOrder(_itemCount);
            _itemStart.DLL_RestorePriorSortOrder(_itemCount);

            _itemStart = _itemStart_PriorSortOrder;
            // 12-29-2024 td //_itemEnding = _itemStart.DLL_GetItemLast();
            _itemEnding = _itemEnding_PriorSortOrder;
            _itemCount = _itemStart.DLL_CountItemsAllInList();

            // Added 12/12/2024 thomas downes 
            if (pbAlsoClearPriorSortOrder) _itemStart.DLL_ClearPriorSortOrder(true);

        }


        public void ImplementSortOrder_ByOp_ByArray(DLLOperation1D_Of<TControl> par_op,
                                          bool pbAlsoClearPriorSortOrder)
        {
            //
            // Added 12/30/2024 thomas downes 
            //
            //April 2025 if (par_op._arrayControls_SortOrderThisOp == null)
            //{
            //    System.Diagnostics.Debugger.Break();
            //}

            //if (par_op._itemStart_SortOrderThisOp == null)
            //{
            //    System.Diagnostics.Debugger.Break();
            //}
            if (_isEmpty_OrTreatAsEmpty)
            {
                System.Diagnostics.Debugger.Break();
            }
            if (0 == _itemCount)
            {
                System.Diagnostics.Debugger.Break();
            }
            if (par_op._arrayIndices_SortOrderRedoThisOp == null)
            {
                System.Diagnostics.Debugger.Break();
            }

            // April 2025 _itemStart = par_op._itemStart_SortOrderThisOp;  // Use the sort order suffixed "ThisOp".
            // April 2025 _itemStart.DLL_ClearReferencePrior('S'); // Added 12/30/2024 
            TControl? currentItem = null; // _itemStart;
            TControl priorItem = _itemStart;
            TControl each_item = _itemStart;
            const bool DOUBLY_LINK = true;
            TControl[] arrayControls_CurrentOrder = new TControl[_itemCount];  // new TControl[-1 + _itemCount];
            TControl[] arrayControls_RestoredOrder = new TControl[_itemCount];  // new TControl[-1 + _itemCount];
            int each_restoredIndex;
            bool bPrepareForNextIter; 

            //
            // Step #1 of 3: Build an array of controls as they are currently ordered. 
            //
            for (int index = 0; index < _itemCount; index++)
            {
                // Read the current item from  the array which saves all of the items, in order.
                //currentItem = par_op._arrayControls_SortOrderThisOp[index];  // Use the sort order suffixed "ThisOp".
                arrayControls_CurrentOrder[index] = each_item;

                // Prepare for the next iteration of the loop. --12/30/2024
                bPrepareForNextIter = index < _itemCount - 1;
                if (bPrepareForNextIter) 
                {
                    bool bHasNext = each_item.DLL_HasNext();
                    if (!bHasNext) System.Diagnostics.Debugger.Break();
                    each_item = each_item.DLL_GetItemNext_OfT();
                    // Added 4/30/2025
                    if (each_item == null) System.Diagnostics.Debugger.Break();
                }
            }

            //
            // Step #2 of 3: Change the order of the items in the "RestoredOrder" array,
            //   using the index pulled from the par_op._arrayIndices_SortOrderIfUndo array.
            //
            for (int index = 0; index < _itemCount; index++)
            {
                each_item = arrayControls_CurrentOrder[index];
                //each_restoredIndex = par_op._arrayIndices_SortOrderIfUndo[index];
                each_restoredIndex = par_op._arrayIndices_SortOrderRedoThisOp[index];
                arrayControls_RestoredOrder[each_restoredIndex] = each_item;
            }

            //
            // Step #3 of 3: Convert the array to a DLL (dynamically linked list). 
            //
            for (int index = 0; index < _itemCount; index++)
            {
                // Read the current item from the array which saves all of the items, in order.
                currentItem = arrayControls_RestoredOrder[index];  // Use the sort order suffixed "ThisOp".
                priorItem.DLL_SetItemNext_OfT(currentItem, false, DOUBLY_LINK);

                // Prepare for the next iteration of the loop. --12/30/2024
                priorItem = currentItem;
            }

            currentItem.DLL_ClearReferenceNext('S');
            _itemStart = arrayControls_RestoredOrder[0];
            //_itemEnding = par_op._itemEnding_SortOrderThisOp;  // Use the sort order suffixed "ThisOp".
            _itemEnding = currentItem;

            // Added 4/30/2025
            _itemEnding.DLL_MarkAsEndOfList();
            _itemStart.DLL_ClearReferencePrior('S');

        }

        public void ClearPriorSortOrder()
        {
            //
            // Added 12/12/2024 thomas downes 
            //
            _itemStart.DLL_ClearPriorSortOrder(true);

        }



        public void DLL_SortItemsByIndexArray(int[] par_arrayOfIndices)
        {
            //
            // Added 1/13/2025  by thomas downes
            //
            TControl[] arrayItemsInput; // = new TControl[_itemCount];
            TControl[] arrayItemsOutput; // = new TControl[_itemCount];
            // arrayItems = _itemStart.DLL_GetConvertToArray_AllItemsInList(_itemCount);
            arrayItemsInput = _itemStart.GetConvertToArray();
            arrayItemsOutput = new TControl[_itemCount];

            // Copy the items, in the order specified by the array of indices.
            for (int index = 0; index < _itemCount; index++)
            {
                arrayItemsOutput[index] = arrayItemsInput[par_arrayOfIndices[index]];
            }

            _itemStart = arrayItemsOutput[0];
            _itemStart.DLL_ClearReferencePrior('S'); //Added 4/30/2025

            TControl tempItem = _itemStart;

            // foreach (TControl item in arrayItemsOutput.Skip(1))
            for (int index = 1; index < _itemCount; index++)
            {
                TControl each_item = arrayItemsOutput[index];
                tempItem.DLL_SetItemNext_OfT(each_item, false, true);
                tempItem = each_item;
            }

            //
            // Exit handler.
            //
            _itemEnding = tempItem;

            // Added 4/30/2025 td
            _itemEnding.DLL_ClearReferenceNext('S');
            _itemEnding.DLL_MarkAsEndOfList();

        }


        public void DLL_SortItems(bool par_ascending, bool par_descending)
        {
            //
            //    Public Sub DLL_SortItems(Optional par_descending As Boolean = False)
            //
            //    ''
            //    ''Added 1/04/2024
            //    ''
            //    '' Sorting Algorithm:  "Merge Sort"
            //    ''
            //    Dim firstItem As IDoublyLinkedItem
            //    Dim firstItem_AfterSorting As IDoublyLinkedItem = Nothing
            //    Dim lastItem_AfterSorting As IDoublyLinkedItem = Nothing
            //    Dim intHowManyItems As Integer
            //    Const INITIAL_CALL As Integer = 0 ''1 ''0

            TControl firstItem;
            TControl? firstItem_AfterSorting = null;
            TControl? lastItem_AfterSorting = null;
            int intHowManyItems;
            const int INITIAL_CALL = 0; // 1

            //    firstItem = mod_dllControlFirst
            //    intHowManyItems = mod_intCountOfItems
            firstItem = _itemStart;
            intHowManyItems = _itemCount;

            // Added 12/23/2024  
            if (_itemCount <= 0)
            {
                //
                // The list is empty, it cannot be sorted. ---12/23/2024 t__d__
                //
            }
            else
            {
                //    ''
                //    '' Sorting Algorithm:  "Merge Sort"
                //    ''
                //    SortItemsOfSublist_Recursive(firstItem, intHowManyItems, 0,
                //                                 firstItem_AfterSorting,
                //                                 lastItem_AfterSorting, INITIAL_CALL,
                //                                  par_descending)
                SortItemsOfSublist_Recursive(firstItem, intHowManyItems, 0,
                                                 out firstItem_AfterSorting,
                                                 out lastItem_AfterSorting, INITIAL_CALL,
                                                  par_descending);

                //    ''Clean the dangling references!!
                //    ''  S = Sorting
                //    firstItem_AfterSorting.DLL_ClearReferencePrior("S"c)
                //    lastItem_AfterSorting.DLL_ClearReferenceNext("S"c)
                if (firstItem_AfterSorting == null)
                {
                    // Programmer, please check this unexpected situation.---12/29/2024
                    System.Diagnostics.Debugger.Break(); // Added 12/29/2024
                }
                else
                {
                    firstItem_AfterSorting.DLL_ClearReferencePrior('S');
                    lastItem_AfterSorting.DLL_ClearReferenceNext('S');

                    //    ''Added 1/8/2024 
                    //    mod_dllControlFirst = firstItem_AfterSorting
                    //    mod_dllControlLast = lastItem_AfterSorting
                    //
                    //End Sub ''eND OF ""Public Sub DLL_SortItems()""

                    // Added 12/22/2024 Thomas D. 
                    _itemStart = firstItem_AfterSorting;
                    _itemEnding = lastItem_AfterSorting;
                }

            }


        }   //End Sub ''eND OF ""public void DLL_SortItems(bool par_descending)""


        /// <summary>
        /// Sorting a sub-list of the overall list. We will break the sub-list into two halves,
        /// call this same function (recursion) twice (each of the two(2) halves), then finally
        /// merge the two sorted halves.  I think this is called the Merge Sort.
        /// </summary>
        /// <param name="par_startingItem">First item of the sublist being sorted.</param>
        /// <param name="par_countOfItems">The count of items in the sublist.</param>
        /// <param name="par_indexOfStart">Index (location) of starting item of sublist.</param>
        /// <param name="byref_firstOfSort">The starting item of final (merged) sublist.</param>
        /// <param name="byref_lastOfSort">The last item of final (merged) sublist.</param>
        /// <param name="par_depthRecursion">How far down the recursion tree, are we?</param>
        private void SortItemsOfSublist_Recursive(TControl par_startingItem,
                                                   int par_countOfItems,
                                                   int par_indexOfStart,
                                                   out TControl byref_firstOfSort,
                                                   out TControl byref_lastOfSort,
                                                   int par_depthRecursion,
                                                   bool par_descending)
        {
            //Private Sub SortItemsOfSublist_Recursive(par_startingItem As IDoublyLinkedItem,
            //                               par_countOfItems As Integer,
            //                               par_indexOfStart As Integer,
            //                               ByRef byref_firstOfSort As IDoublyLinkedItem,
            //                               ByRef byref_lastOfSort As IDoublyLinkedItem,
            //                               ByVal par_depthRecursion As Integer,
            //                               ByVal par_descending As Boolean)
            //    ''
            //    ''Added 1/04/2024
            //    ''
            //    Dim currentDepthOfRecursion As Integer
            //    currentDepthOfRecursion = (+1 + par_depthRecursion)

            int currentDepthOfRecursion;
            currentDepthOfRecursion = (+1 + par_depthRecursion);

            if (par_countOfItems <= 1)
            {
                //    If(par_countOfItems <= 1) Then
                //        ''
                //        ''Base Case
                //        ''
                //        byref_firstOfSort = par_startingItem
                //        ''The first and last item of sort is the same item!!
                //        byref_lastOfSort = par_startingItem
                //        Exit Sub
                byref_firstOfSort = par_startingItem;
                //''The first and last item of sort is the same item!!
                byref_lastOfSort = par_startingItem;
                return;

                //    End If ''End of ""If(par_countOfItems <= 1) Then""
            }

            //    Dim itemPrecedingFirstHalf As IDoublyLinkedItem = Nothing
            //    Dim hasItemPrecedingFirstHalf As Boolean = False
            TControl itemPrecedingFirstHalf = null;
            //Not used.--bool hasItemPrecedingFirstHalf = false;

            if (par_startingItem.DLL_HasPrior())
            {
                //    If(par_startingItem.DLL_HasPrior()) Then
                //        ''This preceding item will be used to "Anchor" the first merged item.
                //        itemPrecedingFirstHalf = par_startingItem.DLL_GetItemPrior()
                //        hasItemPrecedingFirstHalf = True
                itemPrecedingFirstHalf = par_startingItem.DLL_GetItemPrior_OfT();
                //Not used.--hasItemPrecedingFirstHalf = true;

                //    End If ''End of ""If (par_startingItem.DLL_HasPrior()) Then""
            }

            //    Dim itemFirstOf_2nd_Half As IDoublyLinkedItem
            //    Dim countOfFirstHalf As Integer
            //    Dim countOf_2nd_Half As Integer
            //    Dim indexOf_2nd_Half As Integer
            TControl itemFirstOf_2ndHalf;  // IDoublyLinkedItem
            int countOfFirstHalf;
            int countOf_2nd_Half;
            int indexOf_2nd_Half;

            //    countOfFirstHalf = par_countOfItems / 2
            countOfFirstHalf = (int)(Math.Floor(par_countOfItems / 2.0));

            //    ''The following will get the first item of the second half, 
            //    ''  _NOT_ the last item of the first half.
            //
            //    itemFirstOf_2nd_Half = par_startingItem.DLL_GetItemNext(countOfFirstHalf)
            itemFirstOf_2ndHalf = par_startingItem.DLL_GetItemNext_OfT(countOfFirstHalf);

            //    indexOf_2nd_Half = (par_indexOfStart + countOfFirstHalf)
            //    countOf_2nd_Half = (par_countOfItems - countOfFirstHalf)

            indexOf_2nd_Half = (par_indexOfStart + countOfFirstHalf);
            countOf_2nd_Half = (par_countOfItems - countOfFirstHalf);

            //    Dim itemFirstOfSort_1stHalf As IDoublyLinkedItem = Nothing
            //    Dim itemFirstOfSort_2ndHalf As IDoublyLinkedItem = Nothing
            //    Dim itemLastOfSort_1stHalf As IDoublyLinkedItem = Nothing
            //    Dim itemLastOfSort_2ndHalf As IDoublyLinkedItem = Nothing

            TControl? itemFirstOfSort_1stHalf = null;
            TControl? itemFirstOfSort_2ndHalf = null;
            TControl? itemLastOfSort_1stHalf = null;
            TControl? itemLastOfSort_2ndHalf = null;

            //    ''
            //    ''
            //    ''
            //    '' Part One of Two:  Recursive Calls!!
            //    ''
            //    ''
            //    ''

            //    ''First half.
            //
            //    SortItemsOfSublist_Recursive(par_startingItem, countOfFirstHalf, par_indexOfStart,
            //                                 itemFirstOfSort_1stHalf,
            //                                 itemLastOfSort_1stHalf,
            //                                    currentDepthOfRecursion, par_descending)
            SortItemsOfSublist_Recursive(par_startingItem, countOfFirstHalf, par_indexOfStart,
                                             out itemFirstOfSort_1stHalf,
                                             out itemLastOfSort_1stHalf,
                                                currentDepthOfRecursion, par_descending);


            //    ''Second half.
            //
            //    SortItemsOfSublist_Recursive(itemFirstOf_2nd_Half, countOf_2nd_Half, indexOf_2nd_Half,
            //                                 itemFirstOfSort_2ndHalf,
            //                                 itemLastOfSort_2ndHalf,
            //                                    currentDepthOfRecursion, par_descending)
            if (itemFirstOf_2ndHalf == null)
            {
                // Programmer, please check this unexpected situation.
                //    Should hopefully not be occurring.
                System.Diagnostics.Debugger.Break(); // Added 12/14/2024 
            }
            else
            {
                SortItemsOfSublist_Recursive(itemFirstOf_2ndHalf, countOf_2nd_Half, indexOf_2nd_Half,
                                                 out itemFirstOfSort_2ndHalf,
                                                 out itemLastOfSort_2ndHalf,
                                                    currentDepthOfRecursion, par_descending);
            }

            //    ''Testing--1/08/2024
            //     If (currentDepthOfRecursion <= 1) Then
            //        ''Debugger.Break()
            //    End If ''End of ""If(currentDepthOfRecursion <= 1) Then""

            if (currentDepthOfRecursion <= 1 && Testing.AreWeTesting)
            {
                // Programmer, please check this unexpected situation.
                //    Should hopefully not be occurring.
                //System.Diagnostics.Debugger.Break(); // Added 12/14/2024 
            }

            //    ''
            //    ''
            //    ''
            //    '' Part Two of Two:  Merging the sublists!!
            //    ''
            //    ''
            //    ''
            //    Dim itemFirstOfMerge As IDoublyLinkedItem = Nothing ''Added 1/8/2024
            //    Dim itemLastOfMerge As IDoublyLinkedItem = Nothing ''Added 1/8/2024
            TControl? itemFirstOfMerge = null;
            TControl? itemLastOfMerge = null;

            //    ''Encapsulated 1/8/2024
            //    MergeSublists(itemFirstOfSort_1stHalf, countOfFirstHalf,
            //                 itemFirstOfSort_2ndHalf, countOf_2nd_Half,
            //                 itemFirstOfMerge, itemLastOfMerge,
            //                 currentDepthOfRecursion, par_descending)
            if (itemFirstOfSort_1stHalf == null || itemFirstOfSort_2ndHalf == null)
            {
                // Programmer, please check this unexpected situation.
                //    Should hopefully not be occurring.
                System.Diagnostics.Debugger.Break(); // Added 12/14/2024 

            }
            else
            {
                //
                // Major Call!!
                //
                MergeSublists(itemFirstOfSort_1stHalf, countOfFirstHalf,
                                 itemFirstOfSort_2ndHalf, countOf_2nd_Half,
                                 out itemFirstOfMerge,
                                 out itemLastOfMerge,
                                 currentDepthOfRecursion, par_descending);
            }

            //    ''
            //    ''Done, so we'll pass back the first of the merged items. 
            //    ''
            //    byref_firstOfSort = itemFirstOfMerge
            //    byref_lastOfSort = itemLastOfMerge ''itemForMerge_Final
            byref_firstOfSort = itemFirstOfMerge;
            byref_lastOfSort = itemLastOfMerge; // ''itemForMerge_Final

            //    ''Clean dangling references, shall we?
            //    byref_firstOfSort.DLL_ClearReferencePrior("S"c)
            //    byref_lastOfSort.DLL_ClearReferenceNext("S"c)

            byref_firstOfSort?.DLL_ClearReferencePrior('S');
            byref_lastOfSort?.DLL_ClearReferenceNext('S');

            //End Sub ''eND OF ""Public Sub SortItems_Recursive()""

        }   //End Sub ''eND OF ""public void SortItems_Recursive()""


        //''' <summary>
        //''' Sorting a sub-list of the overall list. We will break the sub-list into two halves,
        //''' call this same function (recursion) twice (each of the two(2) halves), then finally
        //''' merge the two sorted halves.
        //''' </summary>
        //''' <param name="par_startingItem1stSub">First item of the sublist being merged.</param>
        //''' <param name="par_countOfItems1stSub">The count of items in the sublist.</param>
        //''' <param name="par_startingItem2ndSub">First item of the sublist being merged.</param>
        //''' <param name="par_countOfItems2ndSub">The count of items in the sublist.</param>
        //''' <param name="byref_firstOfMerge">The starting item of final (merged) sublist.</param>
        //''' <param name="byref_lastOfMerge">The last item of final (merged) sublist.</param>
        //''' <param name="par_depthRecursion">How far down the recursion tree, are we?</param>
        private void MergeSublists(TControl par_startingItem1stSub,
                                                   int par_countOfItems1stSub,
                                                   TControl par_startingItem2ndSub,
                                                   int par_countOfItems2ndSub,
                                                   out TControl byref_firstOfMerge,
                                                   out TControl byref_lastOfMerge,
                                                   int par_depthRecursion,
                                                   bool par_descending)
        {
            //Private Sub MergeSublists(par_startingItem1stSub As IDoublyLinkedItem,
            //                               par_countOfItems1stSub As Integer,
            //                               par_startingItem2ndSub As IDoublyLinkedItem,
            //                               par_countOfItems2ndSub As Integer,
            //                               ByRef byref_firstOfMerge As IDoublyLinkedItem,
            //                               ByRef byref_lastOfMerge As IDoublyLinkedItem,
            //                               ByVal par_depthRecursion As Integer,
            //                               ByVal par_descending As Boolean)
            //    ''
            //    ''Added 1/04/2024
            //    ''
            //    Dim postSort_itemFirstOfFirstHalf As IDoublyLinkedItem
            //    Dim postSort_itemFirstOf_2nd_Half As IDoublyLinkedItem
            TControl postSort_itemFirstOfFirstHalf;
            TControl postSort_itemFirstOf_2nd_Half;

            //    postSort_itemFirstOfFirstHalf = par_startingItem1stSub ''itemFirstOfSort_1stHalf
            //    postSort_itemFirstOf_2nd_Half = par_startingItem2ndSub ''itemFirstOfSort_2ndHalf
            postSort_itemFirstOfFirstHalf = par_startingItem1stSub; // ''itemFirstOfSort_1stHalf
            postSort_itemFirstOf_2nd_Half = par_startingItem2ndSub; // ''itemFirstOfSort_2ndHalf

            //    Dim postSort_queue1stHalf = New DLL_RangeQueue(postSort_itemFirstOfFirstHalf, par_countOfItems1stSub) ''countOfFirstHalf)
            //    Dim postSort_queue2ndHalf = New DLL_RangeQueue(postSort_itemFirstOf_2nd_Half, par_countOfItems2ndSub) ''countOf_2nd_Half)
            var postSort_queue1stHalf = new DLLRangeQueue<TControl>(postSort_itemFirstOfFirstHalf, par_countOfItems1stSub);
            var postSort_queue2ndHalf = new DLLRangeQueue<TControl>(postSort_itemFirstOf_2nd_Half, par_countOfItems2ndSub);

            //    ''
            //    ''Merging the two halves!!
            //    ''
            //    Dim itemFirstOfMerge As IDoublyLinkedItem
            //    ''Not used Dim itemLastOfMerge As IDoublyLinkedItem = Nothing
            TControl itemFirstOfMerge;

            //    ''Dim bFirstArgumentIsLess As Boolean = False ''This is an output parameter.
            //    Dim bFirstArgumentIsChosen As Boolean = False ''This is an output parameter.
            bool bFirstArgumentIsChosen = false;  //''This is an output parameter. 

            //    If(par_descending) Then
            if (par_descending)
            {
                //  'Added 1/08/2024
                //  itemFirstOfMerge = DLL_ItemOfGreaterValue(postSort_itemFirstOfFirstHalf,
                //                                             postSort_itemFirstOf_2nd_Half,
                //                                             bFirstArgumentIsChosen
                itemFirstOfMerge = DLL_ItemOfGreaterValue(postSort_itemFirstOfFirstHalf,
                                                             postSort_itemFirstOf_2nd_Half,
                                                             ref bFirstArgumentIsChosen);
            }
            //    Else
            else
            {
                //        itemFirstOfMerge = DLL_ItemOfLesserValue(postSort_itemFirstOfFirstHalf,
                //                                             postSort_itemFirstOf_2nd_Half,
                //                                             bFirstArgumentIsChosen)
                itemFirstOfMerge = DLL_ItemOfLesserValue(postSort_itemFirstOfFirstHalf,
                                                             postSort_itemFirstOf_2nd_Half,
                                                             ref bFirstArgumentIsChosen);
                //    End If ''End of "If (par_descending) Then...Else..."
            }

            //    ''Important for output!!!
            //    byref_firstOfMerge = itemFirstOfMerge
            byref_firstOfMerge = itemFirstOfMerge;

            //    Dim bFirstHalfItemIsSelected As Boolean
            bool bFirstHalfItemIsSelected;

            //    bFirstHalfItemIsSelected = bFirstArgumentIsChosen ''bFirstArgumentIsLess
            bFirstHalfItemIsSelected = bFirstArgumentIsChosen;

            //    If(bFirstHalfItemIsSelected) Then
            //        ''Remove the selected item from the queue.
            //        postSort_queue1stHalf.Dequeue()
            //    Else
            //        ''Remove the selected item from the queue.
            //        postSort_queue2ndHalf.Dequeue()
            //    End If ''End of "If (bFirstHalfItemIsSelected) Then... Else..."

            //''If it is selected, then remove the selected item from the queue.
            if (bFirstHalfItemIsSelected)
            {
                //''Remove the selected item from the queue.
                postSort_queue1stHalf.Dequeue();
            }
            else
            {
                //''Remove the selected item from the queue.
                postSort_queue2ndHalf.Dequeue();
                 
            }  //''End of "If (bFirstHalfItemIsSelected) Then... Else..."

            //    ''The following indices start from zero, regardless of the 
            //    ''  location of the sub-list.
            //    Dim intRelativeIndex_1stHalf As Integer = 0
            //    Dim intRelativeIndex_2ndHalf As Integer = 0
            //    Dim bCompleted As Boolean = False
            //    Dim item_toCompare1stHalf As IDoublyLinkedItem
            //    Dim item_toCompare2ndHalf As IDoublyLinkedItem

            // The following indices start from zero, regardless of the 
            //    location of the sub-list.
            //int intRelativeIndex_1stHalf = 0; // As Integer = 0
            //int intRelativeIndex_2ndHalf = 0; // As Integer = 0
            bool bCompleted = false; // As Boolean = false
            //TControl item_toCompare1stHalf;  // As IDoublyLinkedItem
            //TControl item_toCompare2ndHalf;  // As IDoublyLinkedItem

            //    Dim itemLesser As IDoublyLinkedItem = Nothing
            //    Dim itemForMerge_Next As IDoublyLinkedItem = Nothing
            //    Dim itemForMerge_Prior As IDoublyLinkedItem = itemFirstOfMerge
            //    Dim mergedList_LastItem As IDoublyLinkedItem = itemFirstOfMerge
            //    Dim itemForMerge_Final As IDoublyLinkedItem = itemFirstOfMerge

            //The following indices start from zero, regardless of the 
            //   location of the sub-list.   WAIT--AREN'T THE LISTS ONE-BASED?
            //TControl? itemLesser = null;
            //TControl? itemForMerge_Next = null;
            TControl itemForMerge_Prior = itemFirstOfMerge;
            //TControl mergedList_LastItem = itemFirstOfMerge;
            //TControl itemForMerge_Final = itemFirstOfMerge;

            //    ''
            //    ''Loop to accomplish a sorted merge. 
            //    ''
            //    bCompleted = False
            //    Dim hasNoItems_queue1stHalf As Boolean = False
            //    Dim hasNoItems_queue2ndHalf As Boolean = False
            //    Dim hasOneItem_queue1stHalf As Boolean = False
            //    Dim hasOneItem_queue2ndHalf As Boolean = False

            //   
            // Loop to accomplish a sorted merge. 
            //   
            bCompleted = false;
            //bool hasNoItems_queue1stHalf = false;
            //bool hasNoItems_queue2ndHalf = false;
            //bool hasOneItem_queue1stHalf = false;
            //bool hasOneItem_queue2ndHalf = false;

            //    Dim bLastItem_queue1stHalf As Boolean = False
            //    Dim bLastItem_queue2ndHalf As Boolean = False
            //    Dim bUseOnly_queue1stHalf As Boolean = False
            //    Dim bUseOnly_queue2ndHalf As Boolean = False
            //    Dim countLoopsCompleted As Integer = 0
            //    Dim bBothQueuesAreEmpty As Boolean = False

            //bool bLastItem_queue1stHalf = false;
            //bool bLastItem_queue2ndHalf = false;
            //bool bUseOnly_queue1stHalf = false;
            //bool bUseOnly_queue2ndHalf = false;
            int countLoopsCompleted = 0;
            //bool bBothQueuesAreEmpty = false;

            //    ''Added 1/08/2024 thomas downes
            //    ''  P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
            //    hasNoItems_queue1stHalf = (0 = postSort_queue1stHalf.Count)
            //    hasNoItems_queue2ndHalf = (0 = postSort_queue2ndHalf.Count)
            //    bBothQueuesAreEmpty = (hasNoItems_queue1stHalf And hasNoItems_queue2ndHalf)

            // P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
            //hasNoItems_queue1stHalf = (0 == postSort_queue1stHalf.Count());
            //hasNoItems_queue2ndHalf = (0 == postSort_queue2ndHalf.Count());
            //bBothQueuesAreEmpty = (hasNoItems_queue1stHalf && hasNoItems_queue2ndHalf);

            while (!bCompleted)
            {
                //    While(Not bCompleted)
                //
                //        ''Dummy code.
                //        If(countLoopsCompleted = 0) Then
                //        End If

                // Dummy code.
                if (countLoopsCompleted == 0) 
                { 
                }

                //
                // Encapsulated 12/22/2024 td
                //
                MergeSublists_Helper(par_descending, 
                                     postSort_queue1stHalf,
                                     postSort_queue2ndHalf,
                                     ref countLoopsCompleted,
                                     ref bCompleted,
                                     ref itemForMerge_Prior);

                //countLoopsCompleted++;

                //        ''item_toCompare1stHalf = postSort_itemFirstOfFirstHalf.DLL_GetItemNext(intRelativeIndex_1stHalf)
                //        ''item_toCompare2ndHalf = postSort_itemFirstOf_2nd_Half.DLL_GetItemNext(intRelativeIndex_2ndHalf)

                //        ''Added 1/8/2024 td
                //        ''  Determine if we should focus exclusively on one of the halves.
                //        ''  P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
                //        ''
                //        bUseOnly_queue1stHalf = (postSort_queue1stHalf.Count > 0 And hasNoItems_queue2ndHalf)
                //        bUseOnly_queue2ndHalf = (postSort_queue2ndHalf.Count > 0 And hasNoItems_queue1stHalf)
                //        bBothQueuesAreEmpty = (hasNoItems_queue1stHalf And hasNoItems_queue2ndHalf)

                //        If(bBothQueuesAreEmpty) Then
                //            ''Added 1/08/2024 td
                //            bCompleted = True

                //        ElseIf(bUseOnly_queue1stHalf) Then
                //            ''
                //            ''Use __1st__ half's (custom-built) queue, and ignore the 2nd half since it's empty.
                //            ''  P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
                //            ''
                //            itemLesser = postSort_queue1stHalf.Peek()
                //            ''We must dequeue prior to "Linkage step!!" below.
                //            postSort_queue1stHalf.Dequeue()

                //        ElseIf (bUseOnly_queue2ndHalf) Then
                //            ''
                //            ''Use __2nd__ half's (custom-built) queue, and ignore the 1st half since it's empty.
                //            ''  P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
                //            ''
                //            itemLesser = postSort_queue2ndHalf.Peek()
                //            ''We must dequeue prior to "Linkage step!!" below.
                //            postSort_queue2ndHalf.Dequeue()

                //        Else
                //            item_toCompare1stHalf = postSort_queue1stHalf.Peek()
                //            item_toCompare2ndHalf = postSort_queue2ndHalf.Peek()
                //            bFirstArgumentIsChosen = False ''Re-initialize.

                //            If (par_descending) Then
                //                ''Major call.
                //                ''Added 1/08/2024
                //                itemLesser = DLL_ItemOfGreaterValue(item_toCompare1stHalf,
                //                                               item_toCompare2ndHalf,
                //                                               bFirstArgumentIsChosen)
                //            Else
                //                ''Major call.
                //                itemLesser = DLL_ItemOfLesserValue(item_toCompare1stHalf,
                //                                               item_toCompare2ndHalf,
                //                                               bFirstArgumentIsChosen)
                //            End If ''Edn of ""If (par_descending) Then... Else..."

                //            ''
                //            ''We must dequeue prior to "Linkage step!!" below.
                //            ''
                //            If (bFirstArgumentIsChosen) Then
                //                ''  P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
                //                postSort_queue1stHalf.Dequeue()
                //            Else
                //                ''  P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
                //                postSort_queue2ndHalf.Dequeue()
                //            End If

                //        End If ''End of ""If (hasNoItems_queue1stHalf) Then... ElseIf...Else..."

                //-------------------------------------------------------------------------
                //  Linkage step!!  This is what you're looking for!!  LOL 
                //        
                //  Link the newly-selected item for the next in the merged sub-list.
                //        
                //        ''itemLesser_Prior.DLL_SetItemNext(itemLesser)
                //        ''itemLesser.DLL_SetItemPrior(itemLesser_Prior)

                //        itemForMerge_Next = itemLesser ''The least item is the next selected for the merge.
                //        mergedList_LastItem = itemForMerge_Prior ''We need the previously-merged item, as
                //        '' it is the last item in the merged list.

                //        ''Set up the two-way connection.
                //        If (itemForMerge_Next IsNot Nothing) Then
                //            If(mergedList_LastItem IsNot Nothing) Then
                //                mergedList_LastItem.DLL_SetItemNext(itemForMerge_Next)
                //            End If
                //            itemForMerge_Next.DLL_SetItemPrior(mergedList_LastItem)
                //        End If ''ENd of ""If(itemForMerge_Next IsNot Nothing) Then""
                //-------------------------------------------------------------------------

                //        ''
                //        ''Prepare for next iteration of the While loop.
                //        ''
                //        ''---itemLesser_Prior = itemLesser
                //        itemForMerge_Prior = itemForMerge_Next

                //        ''If (bFirstArgumentIsLess) Then
                //        ''    intRelativeIndex_1stHalf += 1
                //        ''Else
                //        ''    intRelativeIndex_2ndHalf += 1
                //        ''End If
                //        hasNoItems_queue1stHalf = (0 = postSort_queue1stHalf.Count)
                //        hasNoItems_queue2ndHalf = (0 = postSort_queue2ndHalf.Count)
                //        bCompleted = (hasNoItems_queue1stHalf And hasNoItems_queue2ndHalf)

                //        ''It's okay if we repeatedly assign this. 
                //        itemForMerge_Final = itemForMerge_Prior
                //        countLoopsCompleted += 1

                //    End While ''End of ""While(Not bCompleted)""
            } //   End of ""while (! bCompleted)""

            //    ''
            //    ''Done, so we'll pass back the first of the merged items. 
            //    ''
            //    byref_firstOfMerge = itemFirstOfMerge
            //    byref_lastOfMerge = itemForMerge_Final

            // Done, so we'll pass back the first of the merged items.
            byref_firstOfMerge = itemFirstOfMerge;
            // 12/22/2024 byref_lastOfMerge = itemForMerge_Final;
            byref_lastOfMerge = itemForMerge_Prior;

            //End Sub ''end of ""Private S ub MergeSublists

        }  //End Sub ''end of ""private void MergeSublists(...)


        private void MergeSublists_Helper(bool par_descending, 
                                          DLLRangeQueue<TControl> par_postSort_queue1stHalf,
                                          DLLRangeQueue<TControl> par_postSort_queue2ndHalf,
                                          ref int ref_countTimesCalled,
                                          ref bool ref_bCompleted,
                                          ref TControl ref_itemForMerge_Prior)
        {
            //
            // Select the next high-priority item from the two DLLRangeQueue objects. 
            //    Process that high-priority item appropriately.
            //    Remove that high-priority item from the applicable DLLRangeQueue 
            //    object. ---12/22/2024 td
            //
            // Added 12/22/2024 td 
            //
            //The following indices start from zero, regardless of the 
            //   location of the sub-list.   WAIT--AREN'T THE LISTS ONE-BASED?
            TControl? itemPriority = null;
            TControl? itemForMerge_Next = null;
            //TControl itemForMerge_Prior = itemFirstOfMerge;
            TControl mergedList_LastItem; // = itemFirstOfMerge;
            TControl itemForMerge_Final; // = itemFirstOfMerge;

            //    ''
            //    ''Loop to accomplish a sorted merge. 
            //    ''
            //    bCompleted = False
            //    Dim hasNoItems_queue1stHalf As Boolean = False
            //    Dim hasNoItems_queue2ndHalf As Boolean = False
            //    Dim hasOneItem_queue1stHalf As Boolean = False
            //    Dim hasOneItem_queue2ndHalf As Boolean = False

            //   
            // Loop to accomplish a sorted merge. 
            //   
            ref_bCompleted = false;
            bool hasNoItems_queue1stHalf = false;
            bool hasNoItems_queue2ndHalf = false;
            //--bool hasOneItem_queue1stHalf = false;
            //--bool hasOneItem_queue2ndHalf = false;

            //    Dim bLastItem_queue1stHalf As Boolean = False
            //    Dim bLastItem_queue2ndHalf As Boolean = False
            //    Dim bUseOnly_queue1stHalf As Boolean = False
            //    Dim bUseOnly_queue2ndHalf As Boolean = False
            //    Dim countLoopsCompleted As Integer = 0
            //    Dim bBothQueuesAreEmpty As Boolean = False

            //--bool bLastItem_queue1stHalf = false;
            //--bool bLastItem_queue2ndHalf = false;
            bool bUseOnly_queue1stHalf = false;
            bool bUseOnly_queue2ndHalf = false;
            //--int countLoopsCompleted = 0;
            bool bBothQueuesAreEmpty = false;

            hasNoItems_queue1stHalf = (0 == par_postSort_queue1stHalf.Count);
            hasNoItems_queue2ndHalf = (0 == par_postSort_queue2ndHalf.Count);
            bBothQueuesAreEmpty = (hasNoItems_queue1stHalf && hasNoItems_queue2ndHalf);

            //        ''  Determine if we should focus exclusively on one of the halves.
            //        ''  P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
            //        ''
            //        bUseOnly_queue1stHalf = (postSort_queue1stHalf.Count > 0 And hasNoItems_queue2ndHalf)
            //        bUseOnly_queue2ndHalf = (postSort_queue2ndHalf.Count > 0 And hasNoItems_queue1stHalf)
            //        bBothQueuesAreEmpty = (hasNoItems_queue1stHalf And hasNoItems_queue2ndHalf)
            bUseOnly_queue1stHalf = (par_postSort_queue1stHalf.Count > 0 && hasNoItems_queue2ndHalf);
            bUseOnly_queue2ndHalf = (par_postSort_queue2ndHalf.Count > 0 && hasNoItems_queue1stHalf);
            bBothQueuesAreEmpty = (hasNoItems_queue1stHalf && hasNoItems_queue2ndHalf);

            //        If(bBothQueuesAreEmpty) Then
            //            ''Added 1/08/2024 td
            //            bCompleted = True
            if (bBothQueuesAreEmpty)
            {
                ref_bCompleted = true;
            }

            //        ElseIf(bUseOnly_queue1stHalf) Then
            //            ''
            //            ''Use __1st__ half's (custom-built) queue, and ignore the 2nd half since it's empty.
            //            ''  P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
            //            ''
            //            itemLesser = postSort_queue1stHalf.Peek()
            //            ''We must dequeue prior to "Linkage step!!" below.
            //            postSort_queue1stHalf.Dequeue()

            else if (bUseOnly_queue1stHalf)
            {
                //            
                // Use __1st__ half's (custom-built) queue, and ignore the 2nd half since it's empty.
                //    P.S.Keep in mind, our "que ue" is custom-built and may function a bit uniquely.
                //            
                itemPriority = par_postSort_queue1stHalf.Peek();
                //''We must dequeue prior to "Linkage step!!" below.
                par_postSort_queue1stHalf.Dequeue();

            }

            //        ElseIf (bUseOnly_queue2ndHalf) Then
            //            ''
            //            ''Use __2nd__ half's (custom-built) queue, and ignore the 1st half since it's empty.
            //            ''  P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
            //            ''
            //            itemLesser = postSort_queue2ndHalf.Peek()
            //            ''We must dequeue prior to "Linkage step!!" below.
            //            postSort_queue2ndHalf.Dequeue()

            else if (bUseOnly_queue2ndHalf)
            {
                // Use __2nd__ half's (custom-built) queue, and ignore the 1st half since it's empty.
                //   P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
                itemPriority = par_postSort_queue2ndHalf.Peek();
                //We must dequeue prior to "Linkage step!!" below.
                par_postSort_queue2ndHalf.Dequeue();

            }


            //        Else
            //            item_toCompare1stHalf = postSort_queue1stHalf.Peek()
            //            item_toCompare2ndHalf = postSort_queue2ndHalf.Peek()
            //            bFirstArgumentIsChosen = False ''Re-initialize.

            else
            {
                TControl item_toCompare1stHalf = par_postSort_queue1stHalf.Peek();
                TControl item_toCompare2ndHalf = par_postSort_queue2ndHalf.Peek();
                bool bFirstArgumentIsChosen_1stHalf = false; //''Re - initialize.

                //If (par_descending) Then
                //                ''Major call.
                //                ''Added 1/08/2024
                //                itemLesser = DLL_ItemOfGreaterValue(item_toCompare1stHalf,
                //                                               item_toCompare2ndHalf,
                //                                               bFirstArgumentIsChosen)
                if (par_descending)
                {
                    //
                    // DESCENDING -- We are sorting from greatest to least.
                    //
                    TControl itemGreater = DLL_ItemOfGreaterValue(item_toCompare1stHalf,
                         item_toCompare2ndHalf, ref bFirstArgumentIsChosen_1stHalf);
                    itemPriority = itemGreater;

                }
                else // else if (par_ascending)
                {
                    //
                    // ASCENDING -- We are sorting from least to greatest.
                    //
                    //            Else
                    //                ''Major call.
                    //                itemLesser = DLL_ItemOfLesserValue(item_toCompare1stHalf,
                    //                                               item_toCompare2ndHalf,
                    //                                               bFirstArgumentIsChosen)
                    //            End If ''Edn of ""If (par_descending) Then... Else..."
                    TControl itemLesser = DLL_ItemOfLesserValue(item_toCompare1stHalf,
                       item_toCompare2ndHalf, ref bFirstArgumentIsChosen_1stHalf);
                    itemPriority = itemLesser;

                }

                //            ''
                //            ''We must dequeue prior to "Linkage step!!" below.
                //            ''
                //            If (bFirstArgumentIsChosen) Then
                //                ''  P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
                //                postSort_queue1stHalf.Dequeue()
                //            Else
                //                ''  P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
                //                postSort_queue2ndHalf.Dequeue()
                //            End If

                // We must dequeue prior to "Linkage step!!" below.
                if (bFirstArgumentIsChosen_1stHalf)
                {
                    // P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
                    par_postSort_queue1stHalf.Dequeue();

                }
                else
                {
                    // P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
                    par_postSort_queue2ndHalf.Dequeue();

                }

                //        End If ''End of ""If (hasNoItems_queue1stHalf) Then... ElseIf...Else..."

            } // End of "if (bBothQueuesAreEmpty) ... else if (...) ... else if (...) ... else..."


            //-------------------------------------------------------------------------
            //  Linkage step!!  This is what you're looking for!!  LOL 
            //-------------------------------------------------------------------------
            //        
            //  Link the newly-selected item for the next in the merged sub-list.
            //        
            //        ''itemLesser_Prior.DLL_SetItemNext(itemLesser)
            //        ''itemLesser.DLL_SetItemPrior(itemLesser_Prior)

            //        itemForMerge_Next = itemLesser ''The least item is the next selected for the merge.
            //        mergedList_LastItem = itemForMerge_Prior ''We need the previously-merged item, as
            //        '' it is the last item in the merged list.

            itemForMerge_Next = itemPriority; // intLesser;  
            mergedList_LastItem = ref_itemForMerge_Prior;

            //        ''Set up the two-way connection.
            //        If (itemForMerge_Next IsNot Nothing) Then
            //            If(mergedList_LastItem IsNot Nothing) Then
            //                mergedList_LastItem.DLL_SetItemNext(itemForMerge_Next)
            //            End If
            //            itemForMerge_Next.DLL_SetItemPrior(mergedList_LastItem)
            //        End If ''ENd of ""If(itemForMerge_Next IsNot Nothing) Then""

            if (itemForMerge_Next != null)
            {
                if (mergedList_LastItem != null)
                {
                    //mergedList_LastItem.DLL_SetItemNext(itemForMerge_Next);
                    //Apr2025 mergedList_LastItem.DLL_SetItemNext_OfT(itemForMerge_Next, true, false);
                    mergedList_LastItem.DLL_SetItemNext_OfT(itemForMerge_Next, false, true);
                }
            }

            //-------------------------------------------------------------------------
            //  End of Linkage Step
            //-------------------------------------------------------------------------

            //        ''
            //        ''Prepare for next iteration of the While loop.
            //        ''
            //        ''---itemLesser_Prior = itemLesser
            //        itemForMerge_Prior = itemForMerge_Next

            //Prepare for next iteration of the While loop.
            ref_itemForMerge_Prior = itemForMerge_Next;

            //        ''If (bFirstArgumentIsLess) Then
            //        ''    intRelativeIndex_1stHalf += 1
            //        ''Else
            //        ''    intRelativeIndex_2ndHalf += 1
            //        ''End If
            //        hasNoItems_queue1stHalf = (0 = postSort_queue1stHalf.Count)
            //        hasNoItems_queue2ndHalf = (0 = postSort_queue2ndHalf.Count)
            //        bCompleted = (hasNoItems_queue1stHalf And hasNoItems_queue2ndHalf)

            //        ''It's okay if we repeatedly assign this. 
            //        itemForMerge_Final = itemForMerge_Prior
            //        countLoopsCompleted += 1

            hasNoItems_queue1stHalf = (0 == par_postSort_queue1stHalf.Count);
            hasNoItems_queue2ndHalf = (0 == par_postSort_queue2ndHalf.Count);
            ref_bCompleted = (hasNoItems_queue1stHalf && hasNoItems_queue2ndHalf);

            // ''It's okay if we repeatedly assign this.
            itemForMerge_Final = ref_itemForMerge_Prior;
            ref_countTimesCalled += 1;

            //End of "private void MergeSublists_Helper"
        } //End of "private void MergeSublists_Helper"



        private TControl DLL_ItemOfGreaterValue(TControl par_sort_item1,
                                        TControl par_sort_item2,
                                        ref bool byref_bFirstArgumentIsMore)
        {
            //Private Function DLL_ItemOfGreaterValue(ByVal par_sort_item1 As IDoublyLinkedItem,
            //                                       ByVal par_sort_item2 As IDoublyLinkedItem,
            //                                       ByRef byref_bFirstArgumentIsMore As Boolean) As IDoublyLinkedItem
            //    ''
            //    ''Added 1/4/2024 thomas downes
            //    ''
            //    Dim bFirstArgumentIsLess As Boolean = False
            bool bFirstArgumentIsLess = false;

            //    DLL_ItemOfLesserValue(par_sort_item1, par_sort_item2, bFirstArgumentIsLess)
            DLL_ItemOfLesserValue(par_sort_item1, par_sort_item2, ref bFirstArgumentIsLess);

            //    ''----DIFFICULT AND CONFUSING, INVOLVES A SWITCHEROO---
            //    If(bFirstArgumentIsLess) Then
            //        byref_bFirstArgumentIsMore = False
            //        ''----DIFFICULT AND CONFUSING---
            //        ''Return the NON-LESS item, Item #2
            //        Return par_sort_item2
            //    Else
            //        byref_bFirstArgumentIsMore = True
            //        ''----DIFFICULT AND CONFUSING---
            //        ''Return the NON-LESS item, Item #1
            //        Return par_sort_item1
            //    End If ''END OF ""If(bFirstArgumentIsLess) Then...Else..."

            //----DIFFICULT AND CONFUSING, INVOLVES A SWITCHEROO---
            if (bFirstArgumentIsLess)
            {
                byref_bFirstArgumentIsMore = false;
                //----DIFFICULT AND CONFUSING---
                //Return the NON-LESS item, Item #2
                return par_sort_item2;
            }
            else
            {
                byref_bFirstArgumentIsMore = true;
                //----DIFFICULT AND CONFUSING---
                //Return the NON-LESS item, Item #1
                return par_sort_item1;
            }

            //End Function ''end of ""Private Function DLL_ItemOfGreaterValue""
        }   //End Function ''end of ""private IDoublyLinkedItem DLL_ItemOfGreaterValue""


        private TControl DLL_ItemOfLesserValue(TControl par_sort_item1,
                                               TControl par_sort_item2,
                                               ref bool byref_bFirstArgumentIsLess)
        {

            //Private Function DLL_ItemOfLesserValue(ByVal par_sort_item1 As IDoublyLinkedItem,
            //                                       ByVal par_sort_item2 As IDoublyLinkedItem,
            //                                       ByRef byref_bFirstArgumentIsLess As Boolean) As IDoublyLinkedItem
            //    ''
            //    ''Added 1/4/2024 thomas downes
            //    ''
            //    Dim strValue_item1 As String
            //    Dim strValue_item2 As String
            string strValue_item1;
            string strValue_item2;

            //
            //    ''We can't naively use the .ToString() here.
            //    ''  Let's add .DLL_GetValue() to the interface. 
            //    strValue_item1 = par_sort_item1.DLL_GetValue()
            //    strValue_item2 = par_sort_item2.DLL_GetValue()
            strValue_item1 = par_sort_item1.DLL_GetValue();
            strValue_item2 = par_sort_item2.DLL_GetValue();
            //
            //    ''Now we can compare the strings.
            //    byref_bFirstArgumentIsLess = (0 >= strValue_item1.CompareTo(strValue_item2))
            byref_bFirstArgumentIsLess = (0 >= strValue_item1.CompareTo(strValue_item2));

            //    If byref_bFirstArgumentIsLess Then
            //        ''The first item is less than, or equal to, the 2nd item.
            //        ''---bFirstArgumentIsLess = True
            //        Return par_sort_item1
            //    Else
            //        ''---bFirstArgumentIsLess = False
            //        Return par_sort_item2
            //    End If

            if (byref_bFirstArgumentIsLess) return par_sort_item1;
            else return par_sort_item2;

            //End Function ''Private Function DLL_ItemOfLesserValue
        }  //End Function ''private bool DLL_ItemOfLesserValue


        //----------------------------------------------------------------------------------------------------
        //  Nested class. 
        //----------------------------------------------------------------------------------------------------
        //private class DLL_RangeQueue
        //{
        //    //Private Class DLL_RangeQueue
        //    //    ''
        //    //    ''Added 1/4/2024 thomas downes
        //    //    ''
        //    //    Public Count As Integer
        //    //    Private mod_firstItem As IDoublyLinkedItem
        //    public int Count;
        //    private TControl mod_firstItem; // IDoublyLinkedItem mod_firstItem;

        //    public DLL_RangeQueue(TControl par_first, int par_count) // (IDoublyLinkedItem par_first, int par_count)
        //    {
        //        //    Public Sub New(par_first As IDoublyLinkedItem, par_count As Integer)
        //        //        mod_firstItem = par_first
        //        //        Count = par_count
        //        //    End Sub

        //        mod_firstItem = par_first;
        //        this.Count = par_count;

        //    }

        //    public TControl Peek() //''IDoublyLinkedItem Peek()
        //    {
        //        //    Public Function Peek() As IDoublyLinkedItem
        //        //        Return mod_firstItem
        //        //    End Function
        //        return mod_firstItem;
        //    }

        //    public void Dequeue() 
        //    {
        //        //    Public Sub Dequeue()
        //        //
        //        //        If(Count = 0) Then
        //        //            ''This function should NOT have been called at all.
        //        //            Debugger.Break()
        //        //        End If ''ENd of ""If(Count = 0) Then""

        //        if (this.Count == 0) System.Diagnostics.Debugger.Break();

        //        //        ''mod_firstItem = mod_firstItem.DLL_GetItemNext
        //        //        Count -= 1 ''Decrease the count
        //        this.Count -= 1; // Decrease the count. 

        //        //
        //        //        ''Added 1/08/2024 thomas downes
        //        //        If(Count = 0) Then
        //        //            mod_firstItem = Nothing
        //        //        Else
        //        //            mod_firstItem = mod_firstItem.DLL_GetItemNext
        //        //        End If ''End of ""If(Count = 0) Then...Else..."
        //        if (Count == 0)
        //        {
        //            mod_firstItem = null; // Nothing;
        //        }
        //        else
        //        {
        //            mod_firstItem = mod_firstItem.DLL_GetItemNext_OfT();
        //        }

        //        //
        //        //    End Sub ''End of ""Public Sub Dequeue()""
        //    }

        //    // End Class ''End of ""Private Class DLL_RangeQueue""
        //}  // End Class ''End of ""private class DLL_RangeQueue""

        //
        //----------------------------------------------------------------------------------------------------------------
        // Above commented-out VB code is from:
        //
        //         Module DLL_List_OfTControl_SORTING.vb
        //             (located in project ciBadgeInterfaces\AClassOrTwo)
        //
        //         Full path is as follows:
        //
        //             C:\Users\tomdo\source\repos\ciLayout\ciBadgeInterfaces\AClassOrTwo\DLL_List_OfTControl_SORTING.vb
        //----------------------------------------------------------------------------------------------------------------
        //


        public void DLL_SortByRedoArray(DLLOperation1D_Of<TControl> par_op)
        {
            //
            // Added 04/29/2025  
            //
                ImplementSortOrder_ByOp_ByArray(par_op, false);

        }


        public void DLL_UndoSort(DLLOperation1D_Of<TControl> par_op)
        {
            //
            // Added 12/29/2024  
            //
            // 12-29-2024 _itemStart.DLL_RestorePriorSortOrder();
            // 12-29-2024 _itemStart.DLL_RestorePriorSortOrder(_itemCount);
            // 12-30-2024 RestorePriorSortOrder(false);
            const bool SORT_ORDER_BY_OPERATION = true;
            if (SORT_ORDER_BY_OPERATION)
            {
                ImplementSortOrder_ByOp_ByArray(par_op, false);
            }
            else
            {
                RestorePriorSortOrder(false);
            }

            // ---- DIFFICULT & CONFUSING -------------------
            //   REFRESH THE START & ENDING ITEMS.
            //
            // //_itemStart = _itemStart.DLL_GetItemFirst();
            // //_itemEnding = _itemStart.DLL_GetItemLast();
            // //_itemStart = _itemStart_PriorSortOrder;
            // //_itemEnding = _itemEnding_PriorSortOrder;

            //Moved up, to conditional statement. 12/30 ---RestorePriorSortOrder_ByOp(par_op, false);

        }


        public bool HasChangeOfEndPoint(TControl par_itemOriginalStart, TControl par_itemOriginalEnd)
        {
            //
            // Added 12/16/2024 td 
            //
            //bool bChangeOfStart = (_itemStart == par_itemOriginalStart);
            //bool bChangeOfEnding = (_itemEnding == par_itemOriginalEnd);
            bool bChangeOfStart = (_itemStart != par_itemOriginalStart);
            bool bChangeOfEnding = (_itemEnding != par_itemOriginalEnd);
            bool result_change;
            result_change = (bChangeOfStart || bChangeOfEnding);
            return result_change;

        }


        /// <summary>
        /// This builds the integer arrays which will allow a sorting to be recorded & 
        /// then reversed to the original, prior sorting (or lack thereof).  And also 
        /// the integer array which would reverse the sorting.
        /// </summary>
        /// <param name="par_arrayOfControlsBeforeSort"></param>
        /// <param name="par_arrayOfControlsAfterSort"></param>
        /// <param name="par_arrayOfIndicesForRedo"></param>
        /// <param name="par_arrayOfIndicesForUndo"></param>
        public void BuildMapperWithArrayIndices(TControl[] par_arrayOfControlsBeforeSort,
                                                 TControl[] par_arrayOfControlsAfterSort,
                                                 out int[] par_arrayOfIndicesForRedo,
                                                 out int[] par_arrayOfIndicesForUndo)
        {
            //
            // Added 4/24/2025 td
            //
            TControl[] array_Before = par_arrayOfControlsBeforeSort;
            TControl[] array_After = par_arrayOfControlsAfterSort;

            // ----Direction: REDO (Before, After) --------
            // Build the mapping array of indices for ----REDO----
            BuildMapperWithArrayIndices(array_Before, array_After,
                                        out par_arrayOfIndicesForRedo);

            // ----Direction: UNDO (After, Before) --------
            // Build the mapping array of indices for ----UNDO----
            BuildMapperWithArrayIndices(array_After, array_Before,
                            out par_arrayOfIndicesForUndo);


        }


        private void BuildMapperWithArrayIndices(TControl[] par_arrayOfControlsBeforeSort,
                                                 TControl[] par_arrayOfControlsAfterSort,
                                                 out int[] par_arrayOfIndicesToRecordSort)
        {
            //
            // Added 4/24/2025 td
            //
            //---int[] result_arrayOfIndices = new int[-1 + par_arrayOfControlsAfterSort.Length];
            int[] result_arrayOfIndices = new int[par_arrayOfControlsAfterSort.Length];
            int index_base0 = 0;
            int each_index_final;
            TControl[] array_Before = par_arrayOfControlsBeforeSort;
            TControl[] array_After = par_arrayOfControlsAfterSort;

            foreach (TControl each_control in par_arrayOfControlsBeforeSort)
            {
                bool bFound = array_After.Contains(each_control);
                if (bFound)
                {
                    // Major call!!
                    each_index_final = Array.FindIndex(array_After, item => item == each_control);
                    result_arrayOfIndices[index_base0] = each_index_final;
                }
                else
                {
                    System.Diagnostics.Debugger.Break();
                }
                index_base0++;
            }

            par_arrayOfIndicesToRecordSort = result_arrayOfIndices;

        }



    } // End of ""public partial class DLLList<TControl>""


} // End of ""namespace RSCLibraryDLLOperations""


