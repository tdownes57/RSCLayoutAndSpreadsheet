using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{

    public class DLLOperationsManager2x2<T_LinkedCtlBase, T_LinkedCtlHor, T_LinkedCtlVer>
              where T_LinkedCtlBase : IDoublyLinkedItem<T_LinkedCtlBase>
              where T_LinkedCtlHor : IDoublyLinkedItem<T_LinkedCtlHor>
              where T_LinkedCtlVer : IDoublyLinkedItem<T_LinkedCtlVer>
    {
        //''Added 1/18/2024 
        private T_LinkedCtlHor mod_firstItemHoriz;
        private T_LinkedCtlVer mod_firstItemVerti;

        //''Added 2/01/2024 td
        private char mod_charTypeH = 'C'; // c '' C for Columns(Horizontal) C = RSCFieldColumnV2
        private char mod_charTypeV = 'R'; // c '' R for Rows(Vertical)      R = RSCRowHeaderV2

        //private RSLinkedList<T_LinkedCtlH> mod_listHoriz;
        //private RSLinkedList<T_LinkedCtlV> mod_listVerti;
        private DLLList<T_LinkedCtlHor> mod_listHoriz;
        private DLLList<T_LinkedCtlVer> mod_listVerti;

        private DLLOperation<T_LinkedCtlHor, T_LinkedCtlVer> mod_firstPriorOperationV1;
        private DLLOperation<T_LinkedCtlHor, T_LinkedCtlVer> mod_lastPriorOperationV1;
        
        private DLLOperationsRedoMarker<T_LinkedCtlHor, T_LinkedCtlVer> 
            mod_opRedoMarker = 
            new DLLOperationsRedoMarker<T_LinkedCtlHor, T_LinkedCtlVer>(); // As r ''Added 1/24/2024
        
        private int mod_intCountOperations = 0; // As Integer = 0 ''Added 1/24/2024 td




        public T_LinkedCtlHor GetFirstItemH()
        {
            return mod_firstItemHoriz;
        }

        public T_LinkedCtlVer GetFirstItemV()
        {
            return mod_firstItemVerti;
        }

        public int CountOfOperations()
        {
            int intCountOps = mod_firstItemHoriz.DLL_CountItemsAllInList();
            return intCountOps;
        }


        public bool MarkerHasOperationPrior()
        {
            bool result_hasPrior = mod_opRedoMarker.HasOperationPrior();
            return result_hasPrior;
        }

        public bool MarkerHasOperationNext()
        {
            //bool result_hasNext = mod_opRedoMarker.HasOperationNext();
            bool result_hasNext = mod_opRedoMarker.HasOperationNext();
            return result_hasNext;
        }


        internal void ProcessOperation_AnyType(DLLOperation<T_LinkedCtlHor, T_LinkedCtlVer> parOperation,
                                     bool par_changeOfEndpoint,
                                     bool par_bRecordOperation)
        {
            // Added 1/15/2024

            char opType = parOperation.GetOperationType();

            switch (opType)
            {
                case 'I':
                    // Insert (the inverse of Delete)
                    // 1/28/2024 ProcessOperation_Insert(parOperation, par_changeOfEndpoint)
                    ProcessOperation_Insert(parOperation, par_changeOfEndpoint, par_bRecordOperation);
                    break;

                case 'D':
                    // Delete (the inverse of Insert)
                    // 1/28/2024 ProcessOperation_Delete(parOperation, par_changeOfEndpoint)
                    ProcessOperation_Delete(parOperation, par_changeOfEndpoint, par_bRecordOperation);
                    break;

                case 'M':
                    // Move Range (the inverse of Move Range)
                    // 1/28/2024 ProcessOperation_MoveRange(parOperation, par_changeOfEndpoint)
                    ProcessOperation_MoveRange(parOperation, par_changeOfEndpoint, par_bRecordOperation);
                    break;

                default:
                    Debugger.Break();
                    break;
            }

            // Added 1/24/2024 td
        }


        public void ProcessOperation_Insert(DLL_OperationV1 par_operationV1, 
            bool par_changeOfEndpoint, bool par_bRecordOperation)
        {
            // Added 2/2/2024 
            // C = Columns, a Horizontal List
            // R = Row Headers, a Vertical List

            bool bHorizont = par_operationV1.IsClassTypeByChar('C'); // C = Columns, a Horizontal List
            bool bVertical = par_operationV1.IsClassTypeByChar('R'); // R = Row Headers, a Vertical List

            ProcessOperation_Insert_HorV(par_operationV1, par_changeOfEndpoint, par_bRecordOperation, bHorizont, bVertical);
        }


        public void ProcessOperation_Insert_HorV(DLL_OperationV1 par_operationV1, bool par_changeOfEndpoint, bool par_bRecordOperation, bool pbIsHoriz, bool pbIsVerti)
        {
            var operation = par_operationV1;

            if (operation.AnchorToPrecedeItemOrRange != null)
            {
                // Option #1 of 3.  Insert operational item(s) AFTER anchoring item.
                // Insert A after 7, the preceding anchor.
                // | 1 2 3 4 5 6 7 8 9 10
                // Result:  1 2 3 4 5 6 7 A 8 9 10

                if (operation.InsertItemSingly != null)
                {
                    // Insert a single item. 
                    if (pbIsHoriz)
                    {
                        // Added 4/8/2024 
                        var objSingleItemH = (T_DoublyLinkedItemH)operation.InsertItemSingly; // Added 4/8/2024 
                        var objAnchorPrecedingH = (T_DoublyLinkedItemH)operation.AnchorToPrecedeItemOrRange; // Added 4/8/2024 

                        mod_listHoriz.DLL_InsertOneItemAfter(objSingleItemH, objAnchorPrecedingH, operation.IsChangeOfEndpoint);
                    }
                    else if (pbIsVerti)
                    {
                        // Added 4/8/2024 
                        var objSingleItemVerti = (T_DoublyLinkedItemV)operation.InsertItemSingly; // Added 4/8/2024 
                        var objAnchorPrecedingV = (T_DoublyLinkedItemV)operation.AnchorToPrecedeItemOrRange; // Added 4/8/2024 

                        // Added 5/3/2024
                        const bool c_bPassTObjects = false; // Added 5/3/2024 
                        const bool c_bPassInterfaces = false; // Added 5/3/2024 

                        if (c_bPassTObjects)
                        {
                            // Existed prior to 5/3/2024
                            mod_listVerti.DLL_InsertOneItemAfter(objSingleItemVerti, objAnchorPrecedingV, operation.IsChangeOfEndpoint);
                        }
                        else if (c_bPassInterfaces)
                        {
                            // Added 5/3/2024
                            mod_listVerti.DLL_InsertOneItemAfter(operation.InsertItemSingly, operation.AnchorToPrecedeItemOrRange, operation.IsChangeOfEndpoint);
                        }
                    }
                }
                else if (operation.InsertRangeStart != null)
                {
                    // Insert a range of items, either the Horizontal or the Vertical list.
                    if (pbIsHoriz)
                    {
                        mod_listHoriz.DLL_InsertRangeAfter(operation.InsertRangeStart, operation.InsertCount, operation.AnchorToPrecedeItemOrRange, operation.IsChangeOfEndpoint);
                    }
                    else if (pbIsVerti)
                    {
                        mod_listVerti.DLL_InsertRangeAfter(operation.InsertRangeStart, operation.InsertCount, operation.AnchorToPrecedeItemOrRange, operation.IsChangeOfEndpoint);
                    }
                    else
                    {
                        Debugger.Break();
                    }
                }
            }
            else if (operation.AnchorToSucceedItemOrRange != null)
            {
                // Option #2 of 3. Insert BEFORE anchoring item. 
                // Insert operational item(s) BEFORE anchoring item.
                // | Insert x before 6, the terminating anchor.
                // | 1 2 3 4 5 6 7 8 9 10
                // Result:  1 2 3 4 5 x 6 7 8 9 10

                if (operation.InsertItemSingly != null)
                {
                    // Insert a single item. 
                    if (pbIsHoriz)
                    {
                        mod_listHoriz.DLL_InsertOneItemBefore(operation.InsertItemSingly, operation.AnchorToSucceedItemOrRange, operation.IsChangeOfEndpoint); // False));
                    }
                    else if (pbIsVerti)
                    {
                        mod_listVerti.DLL_InsertOneItemBefore(operation.InsertItemSingly, operation.AnchorToSucceedItemOrRange, operation.IsChangeOfEndpoint); // False));
                    }
                    else
                    {
                        Debugger.Break();
                    }
                }
                else if (operation.InsertRangeStart != null)
                {
                    // Insert a range of items. 
                    if (pbIsHoriz)
                    {
                        mod_listHoriz.DLL_InsertRangeBefore(operation.InsertRangeStart, operation.InsertCount, operation.AnchorToSucceedItemOrRange, operation.IsChangeOfEndpoint); // False);
                    }
                    else if (pbIsVerti)
                    {
                        mod_listVerti.DLL_InsertRangeBefore(operation.InsertRangeStart, operation.InsertCount, operation.AnchorToSucceedItemOrRange, operation.IsChangeOfEndpoint); // False);
                    }
                    else
                    {
                        Debugger.Break();
                    }
                }
                else
                {
                    Debugger.Break();
                }
            }
            else if (mod_firstItemHoriz == null)
            {
                // Empty list !!!!
                // We are populating an empty list, or as one might say,
                // inserting a range into an empty list.

                if (pbIsHoriz && operation.InsertItemSingly != null)
                {
                    // Insert a single item, into an empty list. (Horizontal)
                    mod_listHoriz.DLL_InsertRangeEmptyList(operation.InsertItemSingly, 1);
                }
                else if (pbIsHoriz && operation.InsertRangeStart != null)
                {
                    // Insert a range of items, into an empty list. (Horizontal)
                    mod_listHoriz.DLL_InsertRangeEmptyList(operation.InsertRangeStart, operation.InsertCount);
                }
                else if (pbIsVerti && operation.InsertItemSingly != null)
                {
                    // Insert a single item, into an empty list. (Vertical) 
                    mod_listHoriz.DLL_InsertRangeEmptyList(operation.InsertItemSingly, 1);
                }
                else if (pbIsVerti && operation.InsertRangeStart != null)
                {
                    // Insert a range of items, into an empty list. 
                    mod_listVerti.DLL_InsertRangeEmptyList(operation.InsertRangeStart, operation.InsertCount);
                }
                else
                {
                    Debugger.Break();
                }

                // Be sure to save the first item.
                // 1/2024 mod_firstTwoChar = mod_list.DLL_GetFirstItem()
                if (pbIsHoriz) mod_firstItemHoriz = mod_listHoriz.DLL_GetItemAtIndex(0);
                if (pbIsVerti) mod_firstItemVerti = mod_listVerti.DLL_GetItemAtIndex(0);
            }

            // Added 12/28/2023
            if (operation.IsChangeOfEndpoint)
            {
                // In the 50% chance the starting item is affected...
                // mod_firstTwoChar = mod_list.DLL_GetFirstItem()
                if (pbIsHoriz) mod_firstItemHoriz = mod_listHoriz.DLL_GetItemAtIndex(0);
                if (pbIsVerti) mod_firstItemVerti = mod_listVerti.DLL_GetItemAtIndex(0);
            }

            // Admin, if requested.
            // if (par_bIncludePostOpAdmin) 
            // {
            //     // Refresh the Display. (Make the Insert visible to the user.)
            //     RefreshTheUI_DisplayList()

            //     // Added 1/01/2024
            if (par_bRecordOperation)
            {
                RecordNewestOperation(operation);
            }

            //     // Added 1/03/2024
            //     RefreshTheUI_DisplayList()
            // }

            // #If DEBUG
            // Stop
            // #End If
        }


        public void ProcessOperation_Delete(DLL_OperationV1 par_operationV1, bool par_changeOfEndpoint, bool par_bRecordOperation)
        {
        }

        public void ProcessOperation_Delete(DLL_OperationV1 par_operationV1, bool par_changeOfEndpoint, bool par_bRecordOperation, bool pbHorizont, bool pbVertical)
        {
            // 1/2024 Optional par_bIncludePostOpAdmin As Boolean = False

            // Encapsulated 1/01/2024
            // Added 12/25/2023
            //
            // Version #1 (DLL_OperationV1) exposes more things than Version #2.
            IDoublyLinkedItem firstItemInList;

            if (pbHorizont)
            {
                firstItemInList = (IDoublyLinkedItem)mod_firstItemHoriz;
            }
            if (pbVertical)
            {
                firstItemInList = (IDoublyLinkedItem)mod_firstItemVerti;
            }

            bool bChangeOfEndpoint;
            TwoCharacterDLLItem objDeleteRangeStart; // 12/28/2023
            TwoCharacterDLLItem objDeleteRangeEndpt; // 12/28/2023

            if (par_operationV1.DeleteItemSingly != null)
            {
                // Only a single item is being deleted.
                // 1/2024 bChangeOfEndpoint_Start = (par_operationV1.DeleteItemSingly == mod_firstItem) // Is mod_firstTwoChar
                // 1/20/2024 TD bChangeOfEndpoint_Start = (par_operationV1.DeleteItemSingly == firstItemInList) // Is mod_firstTwoChar
                // 1/2024 bChangeOfEndpoint_Endpt = (par_operationV1.DeleteItemSingly == mod_list.DLL_GetLastItem())
                // 1/20/2024 TD bChangeOfEndpoint_Endpt = (par_operationV1.DeleteItemSingly == mod_list.DLL_GetLastItem())
            }
            else
            {
                // A range of items is being deleted.
                objDeleteRangeStart = par_operationV1.DeleteRangeStart;
                objDeleteRangeEndpt = par_operationV1.DeleteRangeStart.DLL_GetItemNext(-1 + par_operationV1.DeleteCount);
                // 1/20/2024 bChangeOfEndpoint_Start = (par_operationV1.DeleteRangeStart == mod_firstTwoChar)
                // 1/20/2024 TD // bChangeOfEndpoint_Start = (par_operationV1.DeleteRangeStart == firstItemInList)
                // 1/20/2024 TD // bChangeOfEndpoint_Endpt = (objDeleteRangeEndpt == mod_list.DLL_GetLastItem())
            }

            // V2 bChangeOfEndpoint = (par_operationV1.GetIndexOfStart() <= -1 + mod_list.DLL_CountAllItems())
            // 12/2023 bChangeOfEndpoint_Start = (par_operationV1.DeleteRangeStart == mod_list.DLL_GetLastItem())
            // 1/20/2024 TD bChangeOfEndpoint = (bChangeOfEndpoint_Start || bChangeOfEndpoint_Endpt)
            bChangeOfEndpoint = par_changeOfEndpoint;

            // V2 mod_list.DLL_DeleteItem(par_operationV1.GetSingleItem(), bChangeOfEndpoint)
            if (par_operationV1.DeleteItemSingly != null) // Added 12/28/2023
            {
                // Conditioned by If (...) on 12/28/2023
                if (pbHorizont) mod_listHoriz.DLL_DeleteItem(par_operationV1.DeleteItemSingly, bChangeOfEndpoint);
                if (pbVertical) mod_listVerti.DLL_DeleteItem(par_operationV1.DeleteItemSingly, bChangeOfEndpoint);
            }
            else if (par_operationV1.DeleteRangeStart != null)
            {
                // Added 12/28/2023 thomas downes
                if (pbHorizont)
                    mod_listHoriz.DLL_DeleteRange(par_operationV1.DeleteRangeStart, par_operationV1.DeleteCount,
                                                  bChangeOfEndpoint, par_operationV1.DeleteRangeEnd_Null);
                if (pbVertical)
                    mod_listVerti.DLL_DeleteRange(par_operationV1.DeleteRangeStart, par_operationV1.DeleteCount,
                                                  bChangeOfEndpoint, par_operationV1.DeleteRangeEnd_Null);
            }
            else
            {
                // Added 12/28/2023 thomas downes
                Debugger.Break();
            }

            // Added 12/28/2023
            // 1/20/2024 If (bChangeOfEndpoint_Start) Then
            if (bChangeOfEndpoint)
            {
                // 1/20/2024 mod_firstTwoChar = mod_list.DLL_GetFirstItem
                if (pbHorizont) mod_firstItemHoriz = mod_listHoriz.DLL_GetItemAtIndex(0);
                if (pbVertical) mod_firstItemVerti = mod_listVerti.DLL_GetItemAtIndex(0);
            }

            // Admin, if requested.
            // If (par_bIncludePostOpAdmin) Then
            //     // Make the Delete visible to the user.
            //     RefreshTheUI_DisplayList()

            // Added 1/01/2024
            if (par_bRecordOperation) // Added 1/28/2024
            {
                RecordNewestOperation(par_operationV1);
            }

            // Added 1/03/2024
            // RefreshTheUI_OperationsCount()

            // End If
        }

        public void ProcessOperation_MoveRange(DLL_OperationV1 par_operationV1, bool par_changeOfEndpoint, bool par_bRecordOperation)
        {
            // Added 2/02/2024 td
            bool bHorizont;
            bool bVertical;

            bHorizont = (par_operationV1.IsClassTypeByChar('C'));
            bVertical = (par_operationV1.IsClassTypeByChar('R'));

            ProcessOperation_MoveRange(par_operationV1, par_changeOfEndpoint, par_bRecordOperation, bHorizont, bVertical);
        }

        private void ProcessOperation_MoveRange(DLL_OperationV1 par_operationV1, bool par_changeOfEndpoint, bool par_bRecordOperation, bool pbHorizont, bool pbVertical)
        {
            // 1/2024 Optional par_bIncludePostOpAdmin As Boolean = False

            // Step 1 of 2. Cut (via "Delete") the range from the list.
            if (pbHorizont) mod_listHoriz.DLL_DeleteRange(par_operationV1.MovedRangeStart, par_operationV1.MovedCount, par_operationV1.IsChangeOfEndpoint);
            if (pbVertical) mod_listVerti.DLL_DeleteRange(par_operationV1.MovedRangeStart, par_operationV1.MovedCount, par_operationV1.IsChangeOfEndpoint);

            // Added 12/30/2023 td
            if (Testing.TestingByDefault)
            {
                // Test that the ends are CLEAN OF REFERENCES.
                IDoublyLinkedItem firstItem = par_operationV1.MovedRangeStart;
                IDoublyLinkedItem lastItem = par_operationV1.MovedRangeStart.DLL_GetItemNext(-1 + par_operationV1.MovedCount);
                // Test that the ends are CLEAN OF REFERENCES.
                if (firstItem.DLL_HasPrior()) Debugger.Break();
                if (lastItem.DLL_HasNext()) Debugger.Break();
            }

            // Step 2 of 2. Paste (via "Insert") the range into the list.
            if (par_operationV1.AnchorToPrecedeItemOrRange != null)
            {
                // Move operational item(s) AFTER anchoring item.
                //
                // Move 2_3_4 after 7, the preceding anchor.
                //      |
                // 1 2_3_4 5 6 7 8 9 10
                // Result: 1 5 6 7 2_3_4 8 9 10 <<< Note that 2_3_4 has been moved.
                if (pbHorizont)
                {
                    mod_listHoriz.DLL_InsertRangeAfter(par_operationV1.MovedRangeStart, par_operationV1.MovedCount,
                                                       par_operationV1.AnchorToPrecedeItemOrRange, par_operationV1.IsChangeOfEndpoint);
                }
                else if (pbVertical)
                {
                    mod_listVerti.DLL_InsertRangeAfter(par_operationV1.MovedRangeStart, par_operationV1.MovedCount,
                                                       par_operationV1.AnchorToPrecedeItemOrRange, par_operationV1.IsChangeOfEndpoint);
                }
                else
                {
                    Debugger.Break();
                }
            }
            else
            {
                // Move operational item(s) BEFORE anchoring item.
                //
                // Move 2_3_4 before 6, the terminating anchor.
                //      |
                // 1 2_3_4 5 6 7 8 9 10
                // Result: 1 5 2_3_4 6 7 8 9 10
                if (pbHorizont)
                {
                    mod_listHoriz.DLL_InsertRangeBefore(par_operationV1.MovedRangeStart, par_operationV1.MovedCount,
                                                        par_operationV1.AnchorToSucceedItemOrRange,
                                                        par_operationV1.IsChangeOfEndpoint);
                }
                else if (pbVertical)
                {
                    mod_listVerti.DLL_InsertRangeBefore(par_operationV1.MovedRangeStart, par_operationV1.MovedCount,
                                                        par_operationV1.AnchorToSucceedItemOrRange,
                                                        par_operationV1.IsChangeOfEndpoint);
                }
                else
                {
                    Debugger.Break();
                }

            }

            //''Added 12 / 28 / 2023
            if (par_operationV1.IsChangeOfEndpoint)
            {
                //''In the 50 % chance the starting item is affected...
                //''#1 1/20/2024 td mod_firstTwoChar = mod_list.DLL_GetFirstItem()
                //''#2 1/20/2024 mod_firstItem = mod_list.DLL_GetFirstItem()
                if (pbHorizont) mod_firstItemHoriz = mod_listHoriz.DLL_GetItemAtIndex(0);
                if (pbVertical) mod_firstItemVerti = mod_listVerti.DLL_GetItemAtIndex(0);

            } // End If ''End of ""If(.IsChangeOfEndpoint) Then""




                    public void RedoMarkedOperation(bool pbIsHoriz, bool pbIsVerti)
        {
            DLLOperation<T_LinkedCtlHor, T_LinkedCtlVer>
                opReDo = mod_opRedoMarker.GetMarkersNext_ShiftPositionRight();

            //Added 5.25.2024
            bool bIsChangeOfEndpoint = opReDo.IsChangeOfEndpoint();

            //opReDo.CreatedAsRedoOperation = true;
            ProcessOperation_AnyType(opReDo, bIsChangeOfEndpoint,
                false, pbIsHoriz, pbIsVerti);

        }

        public void UndoMarkedOperation()
        {
            UndoOfPriorOperation_AnyType();
        }








    }
}
