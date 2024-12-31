using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    public partial class DLLOperation1D<TControl>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="par_list"></param>
        /// <param name="par_range"></param>
        /// <param name="par_anchorItem"></param>
        /// <param name="pbEndpointProtection">If True, we will throw Exceptions when the Endpoint is impacted, unless the next Boolean parameter is True.</param>
        /// <param name="pbIsChangeOfEndpoint">Prevents exceptions from being raised when an endpoint is changed.</param>
        private void OperateOnList_Private(DLLList<TControl> par_list_administrative,
                                     DLLRange<TControl> par_range,
                                     DLLAnchorItem<TControl>? par_anchorItem,
                                     DLLAnchorCouplet<TControl>? par_anchorPair,
                                     bool pbEndpointProtection,
                                     bool pbIsChangeOfEndpoint_Expected,
                                     out bool pbChangeOfEndpoint_Occurred,
                                     bool pbRunOtherChecks = false)
        // where TControl : IDoublyLinkedItem<TControl>
        {
            //
            // Added 4/17/2024
            //
            //   This is a private singly-generic method (Of TControl),
            //   to obey the DRY principle inside a doubly-generic class 
            //   (Of TControl_H, TControl_V). 
            //  
            pbChangeOfEndpoint_Occurred = false; //Default.  12/15/2024
            TControl tempListStart = par_list_administrative._itemStart;   // Added 12/17/2024 
            TControl tempListEnding = par_list_administrative._itemEnding;  // Added 12/17/2024 

            if (_isInsert)
            {
                //
                // Insert 
                //
                OperateOnList_Insert(par_list_administrative, par_range,
                                     par_anchorItem, par_anchorPair,
                                     pbEndpointProtection,
                                     pbIsChangeOfEndpoint_Expected,
                                     pbRunOtherChecks);

                // Tempoarary, as of 12/15/2024 
                pbChangeOfEndpoint_Occurred = pbIsChangeOfEndpoint_Expected;

            }
            else if (_isDelete)
            {
                //
                // Delete
                //
                OperateOnList_Delete(par_list_administrative, par_range,
                                     pbEndpointProtection,
                                     pbIsChangeOfEndpoint_Expected,
                                     pbRunOtherChecks);

                // Tempoarary, as of 12/15/2024 
                pbChangeOfEndpoint_Occurred = pbIsChangeOfEndpoint_Expected;

            }
            else if (_isMove)
            {
                //
                // Encapsulated 11/18/2024  
                //
                //OperateOnList_Delete(par_list, par_range,
                //                     pbEndpointProtection,
                //                     pbIsChangeOfEndpoint);
                //OperateOnList_Insert(par_list, par_range,
                //                     par_anchorItem, par_anchorPair,
                //                     pbEndpointProtection,
                //                     pbIsChangeOfEndpoint, pbRunOtherChecks);

                // Encapsulated 11/18/2024
                // 
                // Move
                //
                OperateOnList_Move(par_list_administrative, par_range,
                                     this._moveType, par_anchorItem, par_anchorPair,
                                     pbEndpointProtection,
                                     pbIsChangeOfEndpoint_Expected,
                                     out pbChangeOfEndpoint_Occurred,
                                     pbRunOtherChecks);

            }

            //
            // Added 12/17/2024 td
            //
            pbChangeOfEndpoint_Occurred = par_list_administrative
                .HasChangeOfEndPoint(tempListStart, tempListEnding);


        }


        /// <summary>
        /// Perform an insert operation, either for TControl_H or TControl_V.
        /// If appropriate, we perform some sanity testing prior to the operation.
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="par_list_NotReallyNeeded">This parameter provides a sanity check (debugging).</param>
        /// <param name="par_range">This is the range of items which are being placed into the list.</param>
        /// <param name="par_anchorItem">This is a simple wrapper for the item which provides the location for the insert operation.</param>
        private void OperateOnList_Insert(DLLList<TControl> par_list_administrative,
                                             DLLRange<TControl> par_range,
                                             DLLAnchorItem<TControl>? par_anchorItem,
                                             DLLAnchorCouplet<TControl>? par_anchorPair,
                                     bool pbEndpointProtection,
                                     bool pbIsChangeOfEndpoint = false,
                                     bool pbRunOtherChecks = false)
        // where TControl : IDoublyLinkedItem<TControl>
        {
            //
            // Added 12/17/2024 
            //
            //TControl tempListStart = par_list_administrative._itemStart;   // Added 12/17/2024 
            //TControl tempListEnding = par_list_administrative._itemEnding;  // Added 12/17/2024 

            //
            // Added 4/17/2024
            //
            //   This is a private singly-generic method (Of TControl),
            //   to obey the DRY principle inside a doubly-generic class 
            //   (Of TControl_H, TControl_V). 
            //  
            // Insertion operation
            //
            //        //bool bAnchorIsFirstItem;
            //        //bool bAnchorIsLastItem;
            //        //
            //        //bAnchorIsFirstItem = (par_anchorItem._anchorItem.Equals(
            //        //               par_list_MaybeNotNeeded._itemStart));
            //        //bAnchorIsLastItem = (par_anchorItem._anchorItem.Equals(
            //        //                           par_list_MaybeNotNeeded._itemEnding));

            if (par_anchorPair != null)
            {
                //
                // Encapsulated 11/10/2024
                //
                //   We will use par_anchorPair (DLLAnchorCouplet) to determine
                //   where to place the Range.
                //
                Operate_Insert_ByCouplet(par_list_administrative,
                                          par_range, par_anchorPair,
                                          pbIsChangeOfEndpoint);
            }

            else if (par_anchorItem != null)
            {
                //
                // Encapsulated 11/10/2024
                //
                //   We will use par_anchorItem (DLLAnchorItem) to determine
                //   where to place the Range.
                //
                Operate_Insert_ByAnchorItem(par_list_administrative,
                                          par_range, par_anchorItem,
                                          pbIsChangeOfEndpoint);

            }

            // Added 12/17/2024 td
            //pbIsChangeOfEndpoint = par_list_administrative
            //    .HasChangeOfEndPoint(tempListStart, tempListEnding);

            //
            // End of Insertion operation.  
            //
        }


        private void Operate_Insert_ByCouplet(DLLList<TControl> par_list_NeededForAdmin,
                             DLLRange<TControl> par_range,
                             DLLAnchorCouplet<TControl>? par_anchorPair,
                     bool pbIsChangeOfEndpoint)
        {
            //
            // Added 11/08/2024 thomas downes
            //
            //   An AnchorCouplet is called "AnchorPair" for short. 
            //
            bool bListWillChange_ItemStart = par_anchorPair.ItemLefthandIsNull(); // Added 11/10
            bool bListWillChange_ItemFinal = par_anchorPair.ItemRighthandIsNull(); // Added 11/10

            //
            // Major call!!  This is the main insertion work!!!
            //
            par_anchorPair.EncloseRange(par_range);

            //
            // Admin Work !!
            //
            // Added 11/10/2024 td
            par_list_NeededForAdmin._itemCount += par_range._ItemCountOfRange;

            //
            // Endpoint work. DIFFICULT AND CONFUSING
            //
            if (par_list_NeededForAdmin._isEmpty_OrTreatAsEmpty)
            {
                // Added 11/11/2024 td
                if (par_range._ItemCountOfRange > 0)
                {
                    par_list_NeededForAdmin._itemStart = par_range.ItemStart();
                    par_list_NeededForAdmin._itemEnding = par_range.Item__End();
                    par_list_NeededForAdmin._itemCount = par_range._ItemCountOfRange;
                    par_list_NeededForAdmin._isEmpty_OrTreatAsEmpty = false;

                }

            }
            else if (bListWillChange_ItemStart) // (par_anchorPair.ItemPriorIsNull())
            {
                par_list_NeededForAdmin._itemStart = par_range._StartingItemOfRange;

            }
            else if (bListWillChange_ItemFinal) // (par_anchorPair.ItemAfterIsNull())
            {
                par_list_NeededForAdmin._itemEnding = par_range._EndingItemOfRange;

            }

        }



        private void Operate_Insert_ByAnchorItem(DLLList<TControl> par_list_NotReallyNeeded,
                                     DLLRange<TControl> par_range,
                                     DLLAnchorItem<TControl>? par_anchorItem,
                             bool pbIsChangeOfEndpoint)
        {

            // November 8, 2024 //if (par_anchorItem == null)
            if (par_anchorItem == null) // && par_anchorPair == null)
            {
                //
                // Option #1 of 3...  
                //
                //    The list is empty (and therefore not any anchoring-item  
                //    included, i.e. the anchor is NULL,
                //    as it is irrelevant (or possible)).
                //
                if (par_list_NotReallyNeeded._isEmpty_OrTreatAsEmpty)
                {
                    //List is currently empty, or should be treated as such
                    //   because user has chosen to delete all of the items.
                    //Set the list to contain ALL & ONLY items in the range.
                    //   ---4/30/2024 td
                    par_list_NotReallyNeeded._itemStart = par_range._StartingItemOfRange;
                    par_list_NotReallyNeeded._itemEnding = par_range._EndingItemOfRange;
                    par_list_NotReallyNeeded._isEmpty_OrTreatAsEmpty = false;
                    par_list_NotReallyNeeded._itemCount = par_range._ItemCountOfRange;

                }
                else
                {
                    // Debugging is needed.
                    Debugger.Break();
                }

            }


            //if (par_anchorItem != null && _willInsertRange_AfterAnchor)
            else if (par_anchorItem != null && par_anchorItem._doInsertRangeAfterThis)
            {
                //
                // Option #2 of 3...  
                //
                // Insert the range AFTER (FOLLOWING) the anchoring item. 
                //
                TControl? itemOriginallyAfterAnchor = default(TControl);
                bool bAnchorHasItemAfter;
                bAnchorHasItemAfter = par_anchorItem._anchorItem.DLL_HasNext();

                if (par_anchorItem._anchorItem.DLL_HasNext())
                {
                    //
                    // #2a of 3. 
                    //
                    // Get the item AFTER the anchor; and also "unbox" it,
                    //   i.e. get the TControl object (vs. an interface).
                    itemOriginallyAfterAnchor = par_anchorItem._anchorItem
                        .DLL_GetItemNext_OfT(); // .DLL_UnboxControl_OfT()

                    if (Testing.AreWeTesting)
                    {
                        // Let's test two(2) things...
                        //
                        //   1) The anchor is in the list. 
                        //   2) The operation has already taken place, or is superfluous (not needed).
                        //
                        bool bListHasAnchor = par_list_NotReallyNeeded.Contains(par_anchorItem._anchorItem);
                        if (false == bListHasAnchor)
                        {
                            // Surprising situation. Some debugging ought to be performed. 
                            Debugger.Break();
                        }
                        // Has the operation already taken place?  Is it not needed? 
                        //    (If so, some debugging should be performed.)
                        if (bAnchorHasItemAfter)
                        {
                            bool bInsertIsAlreadyDone = itemOriginallyAfterAnchor.Equals(par_range._StartingItemOfRange);
                            if (bInsertIsAlreadyDone) System.Diagnostics.Debugger.Break();
                            if (bInsertIsAlreadyDone) return; // Don't repeat an unneeded operation.
                        }
                        else
                        {
                            //Confirm that the anchor is at the end of the list. 
                            bool bAnchor_Is_EndOfList;
                            bAnchor_Is_EndOfList = (par_anchorItem._anchorItem.Equals(par_list_NotReallyNeeded._itemEnding));
                            if (false == bAnchor_Is_EndOfList) Debugger.Break();
                        }

                    }

                    //Perform the operation !!
                    //   ---par_anchor.DLL_SetItemNext(par_list._itemStart);
                    par_anchorItem._anchorItem.DLL_SetItemNext(par_range._StartingItemOfRange);

                    // Administration (i.e. easy to forget!!)
                    // 10=2024  par_range._StartingItem.DLL_SetItemPrior(par_anchor._anchorItem);
                    // 10-2024  par_range._EndingItem.DLL_SetItemNext(itemOriginallyAfterAnchor);
                    par_range.ItemStart().DLL_SetItemPrior(par_anchorItem._anchorItem);
                    par_range.Item__End().DLL_SetItemNext(itemOriginallyAfterAnchor);
                    itemOriginallyAfterAnchor.DLL_SetItemPrior(par_range._EndingItemOfRange);
                }
                else
                {
                    //
                    // #2b of 3. Anchor is at the end of the list.
                    //
                    // Nothing originally (pre-operation) follows the anchor,
                    //    i.e. there is no item which is "Next" after the anchor.
                    //
                    if (Testing.AreWeTesting)
                    {
                        bool bListHasAnchor = par_list_NotReallyNeeded.Contains(par_anchorItem._anchorItem);
                        if (false == bListHasAnchor) Debugger.Break();
                        bool bAnchorIsEndOfList;
                        bAnchorIsEndOfList = (par_anchorItem._anchorItem.Equals(par_list_NotReallyNeeded._itemEnding));
                        if (false == bAnchorIsEndOfList) Debugger.Break();

                    }

                    //Perform the operation !!
                    par_anchorItem._anchorItem.DLL_SetItemNext(par_range._StartingItemOfRange);

                    // Administration (i.e. easy to forget!!)
                    par_range._StartingItemOfRange.DLL_SetItemPrior(par_anchorItem._anchorItem);

                }

                //
                // Added 11/10/2024 td 
                //
                //if (bAnchorIsFirstItem)
                //{
                //
                //}

                //if (bAnchorIsLastItem)
                //{
                //
                //}

            }

            //else if (par_anchorItem != null && _willInsertRange_PriorToAnchor)
            else if (par_anchorItem != null && par_anchorItem._doInsertRangeBeforeThis)
            {
                //
                // Option #3 of 3...  
                //
                // Insert the range PRIOR (PRECEDING) to the anchoring item.
                //
                IDoublyLinkedItem<TControl>
                    itemOriginallyBeforeAnchor = par_anchorItem._anchorItem.DLL_GetItemPrior_OfT();

                bool bAnchorHasItemBefore;
                bAnchorHasItemBefore = par_anchorItem._anchorItem.DLL_HasPrior();

                if (Testing.AreWeTesting)
                {
                    bool bAnchorIsMissingFromList; //Added 4/23/2024 td
                    bAnchorIsMissingFromList = (false == par_list_NotReallyNeeded.Contains(par_anchorItem._anchorItem));
                    if (bAnchorIsMissingFromList) Debugger.Break();

                    if (bAnchorHasItemBefore)
                    {
                        bool bInsertIs_AlreadyDone = itemOriginallyBeforeAnchor.Equals(par_range._EndingItemOfRange);
                        if (bInsertIs_AlreadyDone) System.Diagnostics.Debugger.Break();
                        if (bInsertIs_AlreadyDone) return; // Don't repeat an unneeded operation.
                    }
                    else
                    {
                        // Confirm that the anchor is the first item in the list.
                        bool bAnchorIs_StartOfList;
                        bAnchorIs_StartOfList = (par_anchorItem._anchorItem.Equals(par_list_NotReallyNeeded._itemStart));
                        if (false == bAnchorIs_StartOfList) Debugger.Break();
                    }

                } // if (Testing.AreWeTesting )

                if (bAnchorHasItemBefore)  // (itemOriginallyBeforeAnchor != null)
                {
                    //
                    // #3a of 3. 
                    //
                    // Insert the range before the anchor. 
                    par_anchorItem._anchorItem.DLL_SetItemPrior(par_range._EndingItemOfRange);

                    // Administration (i.e. easy to forget!!)
                    par_range._EndingItemOfRange.DLL_SetItemNext(par_anchorItem._anchorItem);
                    par_range._StartingItemOfRange.DLL_SetItemPrior(itemOriginallyBeforeAnchor);
                    itemOriginallyBeforeAnchor.DLL_SetItemNext(par_range._StartingItemOfRange);
                }
                else
                {
                    //
                    // #3b of 3.  Anchor is at the start of the list. 
                    //
                    // Insert the range before the anchor. 
                    par_anchorItem._anchorItem.DLL_SetItemPrior(par_range._EndingItemOfRange);
                    // Administration (i.e. easy to forget!!)
                    par_range._EndingItemOfRange.DLL_SetItemNext(par_anchorItem._anchorItem);
                }

            }


        }




        private void OperateOnList_Delete(DLLList<TControl> par_list,
                                            DLLRange<TControl> par_range,
                                 bool pbEndpointProtection,
                                 bool pbIsChangeOfEndpoint = false,
                                 bool pbRunOtherChecks = false)
        //  where TControl : IDoublyLinkedItem<TControl>
        {
            //
            // Added 11/12/2024
            //
            const bool USE_OBSELETE_CODE = false;
            if (USE_OBSELETE_CODE)
            {
                OperateOnList_Delete_OBSELETE(par_list, par_range,
                    pbEndpointProtection, pbIsChangeOfEndpoint, pbRunOtherChecks);
            }
            else
            {
                //
                // Added 11/12/2024
                //
                DLLAnchorCouplet<TControl> tempInverse = par_range.GetCoupletWhichEncloses_InverseAnchor();

                //
                // Major call!!!
                //
                const bool OUTSOURCE_ADMIN = true; // Added 11/12/2024 td

                if (OUTSOURCE_ADMIN)
                {
                    //--par_range.DeleteFromList();
                    par_range.DeleteFromList_wAdmin(par_list);
                }
                else
                {
                    par_range.DeleteFromList_noAdmin();

                    // Added 11/12/2024 
                    //  Reduce the item count, by using the -= operator. 
                    //
                    par_list._itemCount -= par_range.GetItemCount();

                    if (pbIsChangeOfEndpoint)
                    {
                        if (tempInverse.ItemLefthandIsNull())
                        {
                            if (tempInverse.ItemRighthandIsNull() == false)
                                par_list._itemStart = tempInverse.GetItemLeftOrFirst();
                        }
                        else if (tempInverse.ItemRighthandIsNull())
                        {
                            if (tempInverse.ItemLefthandIsNull() == false)
                                par_list._itemEnding = tempInverse.GetItemRightOrSecond();
                        }
                    }
                }
            }


        }


        private void OperateOnList_Delete_OBSELETE(DLLList<TControl> par_list,
                                                DLLRange<TControl> par_range,
                                     bool pbEndpointProtection,
                                     bool pbIsChangeOfEndpoint = false,
                                     bool pbRunOtherChecks = false)
        //  where TControl : IDoublyLinkedItem<TControl>
        {
            //
            // Added 4/17/2024
            //
            //   This is a private singly-generic method (Of TControl),
            //   to obey the DRY principle inside a doubly-generic class 
            //   (Of TControl_H, TControl_V). 
            //  
            // De-link the item BEFORE the deletion range.
            //
            //IDoublyLinkedItem<TControl>
            //    itemOriginallyBeforeRange = par_range._StartingItem.DLL_GetItemPrior_OfT();
            TControl itemOriginallyBeforeRange = par_range.ItemStart().DLL_GetItemPrior_OfT();

            if (itemOriginallyBeforeRange != null)
            {
                itemOriginallyBeforeRange.DLL_ClearReferenceNext('D');
                if (ALWAYS_CLEAN_ENDPOINTS)
                {
                    par_range._StartingItemOfRange.DLL_ClearReferencePrior('D');
                }
            }

            //
            // De-link the item AFTER the deletion range.
            //
            //IDoublyLinkedItem<TControl>
            TControl itemOriginallyAfterRange = par_range.Item__End().DLL_GetItemNext_OfT();
            // itemOriginallyAfterRange = par_range._EndingItem.DLL_GetItemNext_OfT();

            if (itemOriginallyAfterRange != null)
            {
                itemOriginallyAfterRange.DLL_ClearReferencePrior('D');
                if (ALWAYS_CLEAN_ENDPOINTS)
                {
                    // par_range._EndingItem.DLL_ClearReferenceNext('D');
                    par_range.Item__End().DLL_ClearReferenceNext('D');
                }
            }

            // Administration.  Easy to forget!
            if (itemOriginallyAfterRange != null)
            {
                if (itemOriginallyBeforeRange != null)
                {
                    itemOriginallyBeforeRange.DLL_SetItemNext(itemOriginallyAfterRange);
                    itemOriginallyAfterRange.DLL_SetItemPrior(itemOriginallyBeforeRange);
                    // Added 11/12/2024 
                    par_list._itemCount -= par_range.GetItemCount();
                }
                else
                {
                    par_list._itemStart = itemOriginallyAfterRange;
                    par_list._itemCount -= par_range.GetItemCount();
                    par_list.NotifyOfModification();

                }
            }
            else
            {
                if (itemOriginallyBeforeRange != null)
                {
                    itemOriginallyBeforeRange.DLL_ClearReferenceNext('D');
                }
                else
                {
                    //
                    //  The range is the entire list.
                    //
                    //  Remove the entire list. 
                    //
                    par_list.DLL_RemoveAllItems();

                }

            }

            //
            // End of Deletion operation.  
            //

        }


        /// <summary>
        /// Perform an insert operation, either for TControl_H or TControl_V.
        /// If appropriate, we perform some sanity testing prior to the operation.
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="par_list_NotReallyNeeded">This parameter provides a sanity check (debugging).</param>
        /// <param name="par_range">This is the range of items which are being placed into the list.</param>
        /// <param name="par_anchorItem">This is a simple wrapper for the item which provides the location for the insert operation.</param>
        private void OperateOnList_Move(DLLList<TControl> par_list_forFinalAdmin,
                                             DLLRange<TControl> par_range,
                                             StructureTypeOfMove par_typeOfMove,
                                             DLLAnchorItem<TControl>? par_anchorItem,
                                             DLLAnchorCouplet<TControl>? par_anchorPair,
                                     bool pbEndpointProtection,
                                     bool pbIsChangeOfEndpoint_Expected,
                                     out bool pbChangeOfEndpoint_Occurred,
                                     bool pbRunOtherChecks = false)
        {
            //
            // Encasulated/added 11/18/2024 Th.omas Do.wnes
            //;
            bool boolIsByAnchor = par_typeOfMove.IsMoveToAnchor; // true; // false;
            bool boolIsByShifts = par_typeOfMove.IsMoveIncrementalShift; // true; // false;
            pbChangeOfEndpoint_Occurred = false; // Default.  Added 12/15/2024 

            if (boolIsByAnchor)
            {
                // A Move is a Delete of a Range, and then an  Insert of the same range.
                //
                // Step 1 of 2. DELETE THE RANGE
                OperateOnList_Delete(par_list_forFinalAdmin, par_range,
                                     pbEndpointProtection,
                                     pbIsChangeOfEndpoint_Expected);

                // Step 2 of 2. INSERT THE RANGE 
                OperateOnList_Insert(par_list_forFinalAdmin, par_range,
                                     par_anchorItem, par_anchorPair,
                                     pbEndpointProtection,
                                     pbIsChangeOfEndpoint_Expected, pbRunOtherChecks);

            }

            else if (boolIsByShifts)
            {
                //
                // Shift the range left or right, one item at a time. 
                //    (The range itself will not directly mutate, only the items which 
                //    are adjacent to the range.)
                //
                int howManyShifts = par_typeOfMove.HowManyItemsIncremental;
                bool bShiftingLeft = par_typeOfMove.IsShiftingToLeft;  //Added 12/19/2024
                bool bShiftingRight = par_typeOfMove.IsShiftingToRight;  //Added 12/19/2024
                bool ref_not_possible = false;
                bool changeOfEndpoint_Expected = false; // (1 == par_range._StartingItem.DLL_GetItemIndex());
                bool changeOfEndpoint_Any = false;
                int intListItemCount = par_list_forFinalAdmin._itemCount; //Added 12/19/2024

                for (int index = 1; index <= howManyShifts; index++)
                {
                    // Added 12/15/2024 thomas downes
                    int indexOfRange; // = par_range._StartingItemOfRange.DLL_GetItemIndex();

                    // Change of endpoint likely? --12/15/2024 td
                    //changeOfEndpoint = (indexOfRange <= 2);
                    //--- changeOfEndpoint_Expected = (indexOfRange <= 2 ||
                    //---   indexOfRange >= -1 + par_list_forFinalAdmin._itemCount);

                    if (bShiftingLeft)
                    {
                        indexOfRange = par_range._StartingItemOfRange.DLL_GetItemIndex();
                        changeOfEndpoint_Expected = (indexOfRange <= 2) ||
                            par_range.ContainsEndpoint();

                    }
                    else if (bShiftingRight)
                    {
                        indexOfRange = par_range._EndingItemOfRange.DLL_GetItemIndex();
                        intListItemCount = par_list_forFinalAdmin._itemCount;
                        changeOfEndpoint_Expected = (indexOfRange >= -1 + intListItemCount) ||
                            par_range.ContainsEndpoint();

                    }

                    changeOfEndpoint_Any = (changeOfEndpoint_Any || changeOfEndpoint_Expected); //Added 12/15/2024

                    // par_range.Shift_ByOneItem(par_typeOfMove.IsIncrementalToRight);
                    par_range.Shift_ByOneItem(par_typeOfMove.IsShiftingToRight,
                        ref ref_not_possible, par_list_forFinalAdmin, changeOfEndpoint_Expected);

                    if (ref_not_possible) break;

                }

            }


        }




        /****
         * 
         * 
         * public void OperateOnList(DLLList<TControl_H> par_list)
        {
            // public void OperateOnList(LinkedList<TControl_H> par_list)
            //
            // Added 4/17/2024
            //
            //if (_anchor_H != null && _willInsertRange_AfterAnchor)
          

                }
            }
        }

        *
        *
        **********/



        /// <summary>
        /// Create the inverse (Undo) version, created when an "Undo" operation is needed.
        /// </summary>
        /// <returns>Inverse of the present operation</returns>
        public DLLOperation1D<TControl> // <TControl_H, TControl_V>
            GetInverseForUndo(bool pbTestForIdempotency)
        {

            DLLOperation1D<TControl> result_UNDO;

            //DLLRange<TControl_H> result_RangeOfItems_H = _range_H;
            //DLLRange<TControl_V> result_RangeOfItems_V = _range_V;
            //TControl_H? result_anchor_H = _anchor_H;
            //TControl_V? result_anchor_V = _anchor_V;

            bool result_isInsert = _isDelete; // DIFFICULT & CONFUSING... inverse/opposite.
            bool result_isDelete = _isInsert; // DIFFICULT & CONFUSING... inverse/opposite.
            bool result_isMove = _isMove;
            StructureTypeOfMove result_MoveType = new StructureTypeOfMove(_isMove);  // Added 12/11/2024  

            bool result_isForStartOfList = _isForStartOfList;
            bool result_isForEndOfList = _isForEndOfList;

            // DIFFICULT & CONFUSING... Let's do a switcheroo!!
            //bool result_isSortAscending = _isSort_Descending; //  _isSortingDescending; // DIFFICULT & CONFUSING... inverse/opposite.
            //bool result_isSortDescending =  _isSort_Ascending; // _isSortingAscending; // DIFFICULT & CONFUSING... inverse/opposite.
            bool result_isSortAscending = _isSort_UndoOfSortAscending; //  _isSortingDescending; // DIFFICULT & CONFUSING... inverse/opposite.
            bool result_isSortDescending = _isSort_UndoOfSortDescending; // _isSortingAscending; // DIFFICULT & CONFUSING... inverse/opposite.
            bool result_isUndoOfSort = (_isSort_Ascending || _isSort_Descending); // true; // DIFFICULT & CONFUSING... inverse/opposite.
            bool result_isUndoOfSortAscending = _isSort_Ascending; //  _isSortingDescending; // DIFFICULT & CONFUSING... inverse/opposite.
            bool result_isUndoOfSortDescending = _isSort_Descending; // _isSortingAscending; // DIFFICULT & CONFUSING... inverse/opposite.

            // Added 12/30/2024 td
            TControl result_itemStart_SortOrderThisOp = _itemStart_SortOrderIfUndo;
            TControl result_itemEnding_SortOrderThisOp = _itemEnding_SortOrderIfUndo;
            TControl[] result_array_SortOrderThisOp = _array_SortOrderIfUndo;

            //--- DIFFICULT & CONFUSING ---
            if (_isMove && _isForStartOfList) result_isForStartOfList = false;
            if (_isMove && _isForEndOfList) result_isForEndOfList = false;

            //
            // Create a new operation.
            //
            //---if (_isHoriz)
            //---{

            DLLRange<TControl>? result_RangeOfItems = _range;
            DLLAnchorItem<TControl>? result_anchorItem = _inverseAnchorItem_ForUndo;  // Use the "forUndo" anchor.

            // Added 11/08/2024  
            //   "Couplet" and "Pair" mean the same thing. 
            DLLAnchorCouplet<TControl>? result_anchorCouplet = _inverseAnchorPair_forUndo;  // Use the "forUndo" anchor.

            // Added 11/08/2024 
            if (result_anchorItem == null && result_anchorCouplet != null)
            {
                // Create a AnchorItem from the AnchorCouplet. 
                result_anchorItem = result_anchorCouplet.GetAnchorItem();

            }


            // Added 11/08/2024 
            if (result_anchorCouplet == null && result_anchorItem != null)
            {
                // Create a AnchorCouplet from the AnchorItem. 
                //---result_anchorCouplet = result_anchorItem.GetAnchorCouplet();
                //result_anchorCouplet = result_anchorItem.GetAnchorCouplet<TControl>();
                result_anchorCouplet = result_anchorItem.GetAnchorCouplet();

            }

            // Added 12/11/2024 thomas downes
            if (_isMove) // Added 12/11/2024 thomas downes
            {
                result_isMove = true; // Added 12/19/2024 

                result_MoveType = new StructureTypeOfMove(_isMove);
                result_MoveType.IsMoveToAnchor = _moveType.IsMoveToAnchor;
                result_MoveType.IsMoveIncrementalShift = _moveType.IsMoveIncrementalShift;
                result_MoveType.HowManyItemsIncremental = _moveType.HowManyItemsIncremental;

                // DIFFICULT AND CONFUSING.---12/11/2024
                result_MoveType.IsShiftingToLeft = _moveType.IsShiftingToRight;
                result_MoveType.IsShiftingToRight = _moveType.IsShiftingToLeft;

            }

            //
            // Use the constructor overload for horizontal operations.
            //
            if (_isInsert || _isDelete || _isMove)
            {
                result_UNDO = new DLLOperation1D<TControl>(
                    result_RangeOfItems,
                    result_isForStartOfList,
                    result_isForEndOfList,
                    result_isInsert,
                    result_isDelete,
                    result_isMove,
                    result_MoveType,
                    result_anchorItem,
                    result_anchorCouplet);
            }
            else
            {
                result_UNDO = new DLLOperation1D<TControl>(
                    result_isSortAscending,
                    result_isSortDescending,
                    result_isUndoOfSortAscending,
                    result_isUndoOfSortDescending,
                    result_itemStart_SortOrderThisOp,
                    result_itemEnding_SortOrderThisOp,
                    result_array_SortOrderThisOp);
            }

            //
            // Testing the inverse.   ---Added 12/30/2024 td
            //
            if (Testing.AreWeTesting && pbTestForIdempotency)
            {
                //
                // Is the inverse of the inverse, the equivalent of the original?
                //
                var test_idempotent = result_UNDO.GetInverseForUndo(false);
                bool bEquivalent = this.TestForEquivalence(test_idempotent);
                if (! bEquivalent) System.Diagnostics.Debugger.Break();

            }


            return result_UNDO;


        }




        public DLLOperation1D<T_Base> GetConvertToGenericOfT<T_Base>()
    where T_Base : class, IDoublyLinkedItem<T_Base>
        {
            //Added 12 /02/2024 td
            //----return this;
            //return (this as DLLOperationBase);

            DLLRange<T_Base>? objRange = _range?.GetConvertToGenericOfT<T_Base>();
            DLLAnchorCouplet<T_Base>? objAnchorCouplet = _anchorCouplet?.GetConvertToGeneric_OfT<T_Base>();

            // Added 12/11/2024 td 
            DLLAnchorItem<T_Base>? objAnchorItem = _anchorItem?.GetConvertToGeneric_OfT<T_Base>();

            //DLLOperation1D<T_Base> result =
            //    new DLLOperation1D<T_Base>(objRange, objCouplet, _isInsert, _isMove);
            //DLLOperation1D<T_Base> result =      // Added& modified 12/11/2024  
            //    new DLLOperation1D<T_Base>(objRange, objCouplet, _isInsert, _isMove, _moveType);

            DLLOperation1D<T_Base> result; // = null;

            // Modified 12/11/2024 
            if (_isInsert || _isDelete || _isMove)
            {
                //
                // Insert, Delete, or Move
                //
                result =
                    new DLLOperation1D<T_Base>(objRange, _isForStartOfList, _isForEndOfList, _isInsert, _isDelete,
                           _isMove, _moveType, objAnchorItem, objAnchorCouplet);
            }
            else
            {
                //
                // Sorting 
                // 
                result =
                    new DLLOperation1D<T_Base>(
                           _isSort_Ascending, _isSort_Descending,
                           _isSort_UndoOfSortAscending,
                           _isSort_UndoOfSortDescending,
                           _itemStart_SortOrderIfUndo as T_Base,
                           _itemEnding_SortOrderIfUndo as T_Base,
                           _array_SortOrderIfUndo as T_Base[]);
            }

            return result;

        }



        public bool TestForEquivalence(DLLOperation1D<TControl> par_op)
        {
            //
            // Added 12/24/2024 td  
            //
            bool b_01 = _isDelete == par_op._isDelete;                  
            bool b_02 = _isForAnchor == par_op._isForAnchor;
            bool b_03 = _isForEndOfList == par_op._isForEndOfList;
            bool b_04 = _isForStartOfList == par_op._isForStartOfList;
            bool b_05 = _isForUndoOperation == par_op._isForUndoOperation;
            bool b_06 = _isHoriz == par_op._isHoriz;
            bool b_07 = _isInsert == par_op._isInsert;
            bool b_08 = _isMove == par_op._isMove;
            bool b_09 = _isSort_Ascending == par_op._isSort_Ascending;
            bool b_10 = _isSort_Descending == par_op._isSort_Descending;
            bool b_11 = _isSort_UndoOfSortAscending == par_op._isSort_UndoOfSortAscending;
            bool b_12 = _isSort_UndoOfSortDescending == par_op._isSort_UndoOfSortDescending;
            bool b_13 = _isSort_UndoOfSortEither == par_op._isSort_UndoOfSortEither;
            bool b_14 = _isVerti == par_op._isVerti;
            bool b_15 = _moveType.HowManyItemsIncremental == par_op._moveType.HowManyItemsIncremental;
            bool b_16 = _moveType.IsMoveIncrementalShift == par_op._moveType.IsMoveIncrementalShift;
            bool b_17 = (_moveType.Equals(par_op._moveType));

            //
            // Check the _range property. 
            //
            bool b_18 = true;
            if (par_op._range != null && this._range != null)
            {
                b_18 = par_op._range.IsEquivalent(this._range);
            }
            else if (par_op._range != null && this._range == null)
            {
                b_18 = false;
            }
            else if (par_op._range == null && this._range != null)
            {
                b_18 = false;
            }
            else
            {
                b_18 = true;
            }

            //
            // Check the _anchorItem property. 
            //
            bool b_19 = true;
            if (par_op._anchorItem != null && this._anchorItem != null)
            {
                b_19 = par_op._anchorItem.IsEquivalent(this._anchorItem);
            }
            else if (par_op._anchorItem != null && this._anchorItem == null)
            {
                b_19 = false;
            }
            else if (par_op._range == null && this._range != null)
            {
                b_19 = false;
            }
            else
            {
                b_19 = true;
            }

            //
            // Check the _anchorCouplet property. 
            //
            bool b_20 = true;
            if (par_op._anchorCouplet != null && this._anchorCouplet != null)
            {
                b_20 = par_op._anchorCouplet.IsEquivalent(this._anchorCouplet);
            }
            else if (par_op._anchorCouplet != null && this._anchorCouplet == null)
            {
                b_20 = false;
            }
            else if (par_op._anchorCouplet == null && this._anchorCouplet != null)
            {
                b_20 = false;
            }
            else
            {
                b_20 = true;
            }

            //return (_isDelete == par_op._isDelete);
            bool b_01020304 = (b_01 && b_02 && b_03 && b_04);
            bool b_05060708 = (b_05 && b_06 && b_07 && b_08);
            bool b_09101112 = (b_09 && b_10 && b_11 && b_12);
            bool b_13141516 = (b_13 && b_14 && b_15 && b_16);
            bool b_17181920 = (b_17 && b_18 && b_19 && b_20);

            bool result1 = (b_01020304 && b_05060708 && b_09101112);
            bool result2 = (result1 && b_13141516 && b_17181920);
            return (result2);

        }


        public bool TestForIdempotence()
        {
            //
            // Added 12/24/2024 td  
            //
            DLLOperation1D<TControl> opInverse1st;
            DLLOperation1D<TControl> opInverse2nd;

            opInverse1st = GetInverseForUndo(false);
            opInverse2nd = opInverse1st.GetInverseForUndo(false);

            bool result_equivalent;
            result_equivalent = TestForEquivalence(opInverse2nd);
            return result_equivalent;

        }






    }
}
