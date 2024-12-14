using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    public partial class DLLList<TControl>
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
        public void DLL_SortItems(bool par_descending = false)
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
            //
            //    firstItem = mod_dllControlFirst
            //    intHowManyItems = mod_intCountOfItems
            //
            //    ''
            //    '' Sorting Algorithm:  "Merge Sort"
            //    ''
            //    SortItemsOfSublist_Recursive(firstItem, intHowManyItems, 0,
            //                                 firstItem_AfterSorting,
            //                                 lastItem_AfterSorting, INITIAL_CALL,
            //                                  par_descending)
            //
            //    ''Clean the dangling references!!
            //    ''  S = Sorting
            //    firstItem_AfterSorting.DLL_ClearReferencePrior("S"c)
            //    lastItem_AfterSorting.DLL_ClearReferenceNext("S"c)
            //
            //    ''Added 1/8/2024 
            //    mod_dllControlFirst = firstItem_AfterSorting
            //    mod_dllControlLast = lastItem_AfterSorting
            //
            //End Sub ''eND OF ""Public Sub DLL_SortItems()""

        }   //End Sub ''eND OF ""public voide DLL_SortItems(bool par_descending)""


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
                                                   ref TControl? byref_firstOfSort,
                                                   ref TControl? byref_lastOfSort,
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
                                             ref itemFirstOfSort_1stHalf,
                                             ref itemLastOfSort_1stHalf,
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
                                                 ref itemFirstOfSort_2ndHalf,
                                                 ref itemLastOfSort_2ndHalf,
                                                    currentDepthOfRecursion, par_descending);
            }

            //    ''Testing--1/08/2024
            //    If (currentDepthOfRecursion <= 1) Then
            //        ''Debugger.Break()
            //    End If ''End of ""If(currentDepthOfRecursion <= 1) Then""

            if (currentDepthOfRecursion <= 1)
            {
                // Programmer, please check this unexpected situation.
                //    Should hopefully not be occurring.
                System.Diagnostics.Debugger.Break(); // Added 12/14/2024 
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
                                 ref itemFirstOfMerge,
                                 ref itemLastOfMerge,
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
            byref_firstOfSort?.DLL_ClearReferenceNext('S');

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
                                                   ref TControl? byref_firstOfMerge,
                                                   ref TControl? byref_lastOfMerge,
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

            //    postSort_itemFirstOfFirstHalf = par_startingItem1stSub ''itemFirstOfSort_1stHalf
            //    postSort_itemFirstOf_2nd_Half = par_startingItem2ndSub ''itemFirstOfSort_2ndHalf
            //    Dim postSort_queue1stHalf = New DLL_RangeQueue(postSort_itemFirstOfFirstHalf, par_countOfItems1stSub) ''countOfFirstHalf)
            //    Dim postSort_queue2ndHalf = New DLL_RangeQueue(postSort_itemFirstOf_2nd_Half, par_countOfItems2ndSub) ''countOf_2nd_Half)

            //    ''
            //    ''Merging the two halves!!
            //    ''
            //    Dim itemFirstOfMerge As IDoublyLinkedItem
            //    ''Not usedd Dim itemLastOfMerge As IDoublyLinkedItem = Nothing

            //    ''Dim bFirstArgumentIsLess As Boolean = False ''This is an output parameter.
            //    Dim bFirstArgumentIsChosen As Boolean = False ''This is an output parameter.

            //    If(par_descending) Then
            //        ''Added 1/08/2024
            //        itemFirstOfMerge = DLL_ItemOfGreaterValue(postSort_itemFirstOfFirstHalf,
            //                                             postSort_itemFirstOf_2nd_Half,
            //                                             bFirstArgumentIsChosen)
            //    Else
            //        itemFirstOfMerge = DLL_ItemOfLesserValue(postSort_itemFirstOfFirstHalf,
            //                                             postSort_itemFirstOf_2nd_Half,
            //                                             bFirstArgumentIsChosen)
            //    End If ''End of "If (par_descending) Then...Else..."

            //    ''Important for output!!!
            //    byref_firstOfMerge = itemFirstOfMerge

            //    Dim bFirstHalfItemIsSelected As Boolean
            //    bFirstHalfItemIsSelected = bFirstArgumentIsChosen ''bFirstArgumentIsLess
            //    If(bFirstHalfItemIsSelected) Then
            //        ''Remove the selected item from the queue.
            //        postSort_queue1stHalf.Dequeue()
            //    Else
            //        ''Remove the selected item from the queue.
            //        postSort_queue2ndHalf.Dequeue()
            //    End If ''Ednof "If (bFirstHalfItemIsSelected) Then... Else..."

            //    ''The following indices start from zero, regardless of the 
            //    ''  location of the sublist.
            //    Dim intRelativeIndex_1stHalf As Integer = 0
            //    Dim intRelativeIndex_2ndHalf As Integer = 0
            //    Dim bCompleted As Boolean = False
            //    Dim item_toCompare1stHalf As IDoublyLinkedItem
            //    Dim item_toCompare2ndHalf As IDoublyLinkedItem
            //    Dim itemLesser As IDoublyLinkedItem = Nothing
            //    Dim itemForMerge_Next As IDoublyLinkedItem = Nothing
            //    Dim itemForMerge_Prior As IDoublyLinkedItem = itemFirstOfMerge
            //    Dim mergedList_LastItem As IDoublyLinkedItem = itemFirstOfMerge
            //    Dim itemForMerge_Final As IDoublyLinkedItem = itemFirstOfMerge

            //    ''
            //    ''Loop to accomplish a sorted merge. 
            //    ''
            //    bCompleted = False
            //    Dim hasNoItems_queue1stHalf As Boolean = False
            //    Dim hasNoItems_queue2ndHalf As Boolean = False
            //    Dim hasOneItem_queue1stHalf As Boolean = False
            //    Dim hasOneItem_queue2ndHalf As Boolean = False
            //    Dim bLastItem_queue1stHalf As Boolean = False
            //    Dim bLastItem_queue2ndHalf As Boolean = False
            //    Dim bUseOnly_queue1stHalf As Boolean = False
            //    Dim bUseOnly_queue2ndHalf As Boolean = False
            //    Dim countLoopsCompleted As Integer = 0
            //    Dim bBothQueuesAreEmpty As Boolean = False

            //    ''Added 1/08/2024 thomas downes
            //    ''  P.S.Keep in mind, our "queue" is custom-built and may function a bit uniquely.
            //    hasNoItems_queue1stHalf = (0 = postSort_queue1stHalf.Count)
            //    hasNoItems_queue2ndHalf = (0 = postSort_queue2ndHalf.Count)
            //    bBothQueuesAreEmpty = (hasNoItems_queue1stHalf And hasNoItems_queue2ndHalf)

            //    While(Not bCompleted)

            //        ''Dummy code.
            //        If(countLoopsCompleted = 0) Then
            //        End If

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
            //  Link the newly-selected item for the next in the merged sublist.
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

            //    ''
            //    ''Done, so we'll pass back the first of the merged items. 
            //    ''
            //    byref_firstOfMerge = itemFirstOfMerge
            //    byref_lastOfMerge = itemForMerge_Final

            //End Sub ''end of ""Private Sub MergeSublists

        }  //End Sub ''end of ""private void MergeSublists(...)


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


        private IDoublyLinkedItem DLL_ItemOfLesserValue(TControl par_sort_item1,
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
            //
            //    ''We can't naively use the .ToString() here.
            //    ''  Let's add .DLL_GetValue() to the interface. 
            //    strValue_item1 = par_sort_item1.DLL_GetValue()
            //    strValue_item2 = par_sort_item2.DLL_GetValue()
            //
            //    ''Now we can compare the strings.
            //    byref_bFirstArgumentIsLess = (0 >= strValue_item1.CompareTo(strValue_item2))
            //
            //    If byref_bFirstArgumentIsLess Then
            //        ''The first item is less than, or equal to, the 2nd item.
            //        ''---bFirstArgumentIsLess = True
            //        Return par_sort_item1
            //    Else
            //        ''---bFirstArgumentIsLess = False
            //        Return par_sort_item2
            //    End If
            //
            //End Function ''Private Function DLL_ItemOfLesserValue

            if (byref_bFirstArgumentIsLess) return par_sort_item1;
            else return par_sort_item2;

        }


        //----------------------------------------------------------------------------------------------------
        //  Nested class. 
        //----------------------------------------------------------------------------------------------------
        private class DLL_RangeQueue
        {
            //Private Class DLL_RangeQueue
            //    ''
            //    ''Added 1/4/2024 thomas downes
            //    ''
            //    Public Count As Integer
            //    Private mod_firstItem As IDoublyLinkedItem
            public int Count;
            private TControl mod_firstItem; // IDoublyLinkedItem mod_firstItem;

            public DLL_RangeQueue(TControl par_first, int par_count) // (IDoublyLinkedItem par_first, int par_count)
            {
                //    Public Sub New(par_first As IDoublyLinkedItem, par_count As Integer)
                //        mod_firstItem = par_first
                //        Count = par_count
                //    End Sub

                mod_firstItem = par_first;
                this.Count = par_count;

            }

            public TControl Peek() //''IDoublyLinkedItem Peek()
            {
                //    Public Function Peek() As IDoublyLinkedItem
                //        Return mod_firstItem
                //    End Function
                return mod_firstItem;
            }

            public void Dequeue() 
            {
                //    Public Sub Dequeue()
                //
                //        If(Count = 0) Then
                //            ''This function should NOT have been called at all.
                //            Debugger.Break()
                //        End If ''ENd of ""If(Count = 0) Then""

                if (this.Count == 0) System.Diagnostics.Debugger.Break();

                //        ''mod_firstItem = mod_firstItem.DLL_GetItemNext
                //        Count -= 1 ''Decrease the count
                this.Count -= 1; // Decrease the count. 

                //
                //        ''Added 1/08/2024 thomas downes
                //        If(Count = 0) Then
                //            mod_firstItem = Nothing
                //        Else
                //            mod_firstItem = mod_firstItem.DLL_GetItemNext
                //        End If ''End of ""If(Count = 0) Then...Else..."
                if (Count == 0)
                {
                    mod_firstItem = null; // Nothing;
                }
                else
                {
                    mod_firstItem = mod_firstItem.DLL_GetItemNext_OfT();
                }

                //
                //    End Sub ''End of ""Public Sub Dequeue()""
            }

            // End Class ''End of ""Private Class DLL_RangeQueue""
        }  // End Class ''End of ""private class DLL_RangeQueue""

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


    } // End of ""public partial class DLLList<TControl>""


} // End of ""namespace RSCLibraryDLLOperations""


