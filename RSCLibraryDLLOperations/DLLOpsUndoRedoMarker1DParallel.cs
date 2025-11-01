using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{

    /// <summary>
    /// If we imagine the marker as a pair of square brackets, then 
    /// we can write the following as an illustration.
    /// Imagine a list of executed operations:  
    ///       Operation1, Operation2, Operation3, Operation4, Operation5
    /// and the following is the current marker:
    ///                               [Operation3, Operation4]
    /// After Operation#2 is reversed using the  [Undo] button, and this 
    ///    function is called, the marker will be: [Operation2, Operation3]
    /// Another illustration, before and after:
    /// Before:
    ///       Operation1, Operation2, [ Operation3  ,  Operation4  ], Operation5
    ///                                ^_will Undo_^   ^Prior Undo^   ^Prior Undo^
    /// After:      
    ///       Operation1, [Operation2, Operation3]  , Operation4,    Operation5
    ///                                ^Prior Undo^   ^Prior Undo^   ^Prior Undo^
    ///                                
    /// Thus, the marker has shifted left, toward the prior (lower-numbered) operation.                              
    /// </summary>
    internal class DLLOpsUndoRedoMarker1DParallel<TControl, TParallel>
       where TControl : class, IDoublyLinkedItem<TControl>
       where TParallel : class, IDoublyLinkedItem<TParallel>
    {
        //
        // As illustration of the moveable, user-controlled undo-redo marker:
        //
        //                                               <----------------------------------->
        //                                               <----- Undo-Redo Marker ------------>
        //  List of recorded operations:                 <----------------------------------->
        //      o1_OperationInsert,  o2_OperationDelete, o3_OperationMove,  o4_OperationInsert, o5_OperationDelete, o6_OperationInsert
        //                                               <----------------||----------------->
        //                                               <---Undo-button--||-- Redo button--->
        //                                               <----------------||----------------->
        //
        // User-case illustrations of the moveable, user-controlled undo-redo marker:
        //
        // User-Case #1 of 6
        //       <---------------------------------------------------------->
        //       <----- Undo-Redo Marker (may be a Null object) ------------>
        //       <---------------------------------------------------------->
        //         (No operations have been done. Perhaps the Marker is Null.)
        //
        // User-Case #2 of 6  User has executed an initial insert operation, no other
        //    operations been executed, undone, or redone).
        //       <----------------------------------->
        //       <----- Undo-Redo Marker ------------>
        //       <----------------------------------->
        //      o1_OperationInsert
        //       <----------------||----------------->
        //       <---Undo-button--||-- Redo button--->
        //       <----------------||----------------->
        //
        // User-Case #3 of 6  User has executed two operations, an insert & delete.
        //                          <----------------------------------->
        //                          <----- Undo-Redo Marker ------------>
        //                          <----------------------------------->
        //      o1_OperationInsert,  o2_OperationDelete
        //                          <------------------||----------------->
        //                          <---Undo-button----||-- Redo button--->
        //                          <------------------||----------------->
        //
        // User-Case #4 of 6  User has executed three(3) operations, and pressed
        //     the Undo button two(2) times.
        //      <-------------------------------------->
        //      <-------- Undo-Redo Marker ------------>
        //      <-------------------------------------->
        //      o1_OperationInsert,  o2_OperationDelete, o3_OperationMove
        //      <------------------||------------------>
        //      <----Undo-button---||--- Redo button--->
        //      <------------------||------------------>
        //
        // User-Case #5 of 6  User has executed one(1) operation, and pressed the Undo 
        //      button one(1) time.
        //       <----------------------------------->
        //       <----- Undo-Redo Marker ------------>
        //       <----------------------------------->
        //                          o1_OperationInsert
        //       <----------------||----------------->
        //       <---Undo-button--||-- Redo button--->
        //       <----------------||----------------->
        //
        // User-Case #6 of 6  User has executed one(1) operation, pressed the Undo 
        //      button one(1) time, and lastly has performed a new (& possibly unique)
        //      insert operation, o2_OperationInsert.
        //       <----------------------------------->
        //       <----- Undo-Redo Marker ------------>
        //       <----------------------------------->
        //       o2_OperationInsert
        //       <-----------------||----------------->
        //       <---Undo-button---||-- Redo button--->
        //       <-----------------||----------------->
        //
        // User-Case #7 of 6  User has executed six(6) operations, and pressed
        //     the Undo button three(3) times.
        //                                               <----------------------------------->
        //                                               <----- Undo-Redo Marker ------------>
        //  List of recorded operations:                 <----------------------------------->
        //      o1_OperationInsert,  o2_OperationDelete, o3_OperationMove,  o4_OperationInsert, o5_OperationDelete, o6_OperationInsert
        //                                               <----------------||----------------->
        //                                               <---Undo-button--||-- Redo button--->
        //                                               <----------------||----------------->
        //
        //

        //
        //    1D = 1 dimension, simply a list
        //            (versus a 2-dimensional grid)
        //
        //    This is similar to a DLLAnchorCouplet. 
        //      Maybe this class should inherit from DLLAnchorCouplet??
        //      --11/17/2024 th_omas dow_nes
        //

        //public DLLOperationsRedoMarker1D(DLLOperation1D<TControl> par_1stPrior)
        //{
        //    // Added 10/25/2024 
        //    //
        //    //mod_opPrior_ForUndo = par_2ndprior;
        //    //mod_opNext_ForRedo = par_1stprior;
        //    mod_opPrior_ForUndo = par_1stPrior;
        //    mod_opNext_ForRedo = null;  
        //}

        //
        //''---DIFFICULT AND CONFUSING---
        //''  This is a "placeholder" for a user who is hitting the 
        //''  undo & redo buttons.This is NOT for recording
        //''  new operations.
        //''
        //''The names below correspond to a "Redo" chain 
        //''   from first to last.
        //''
        //''(We do NOT think of it as an "Undo" chain, because
        //''   it's easier to derive an "Undo" operation from a 
        //''   "Redo" operation (and there's a function for that).
        //''   (Versus deriving a "Redo" operation from an "Undo" 
        //''   operation.)
        //''   It's easier if the default is "going forward in time". 
        //''
        //''---DIFFICULT AND CONFUSING---
        //''  This is a "placeholder" for a user who is hitting the 
        //''  undo & redo buttons.This is NOT for recording
        //''  new operations.
        //''
        //''' <summary>
        //''' If the user hits "Undo", this operation will be 
        //''' inversed and the inverse will be performed. 
        //''' </summary>
        private DLLOperation1D_2TypesInParallel<TControl, TParallel>? mod_opPrior_ForUndo;

        //''' <summary>
        //''' If the user hits "Redo", this operation will be 
        //''' performed as it is.  (In contrast to "Undo", we
        //''' do NOT need to get the inverse of the operation.) 
        //''' </summary>
        private DLLOperation1D_2TypesInParallel<TControl, TParallel>? mod_opNext_ForRedo;

        // Added 5/17/2025 
        private Tuple<DLLOperation1D_2TypesInParallel<TControl, TParallel>?,
                      DLLOperation1D_2TypesInParallel<TControl, TParallel>?> mod_tuplePriorNext;


        //public DLLOperationsRedoMarker1D(DLLOperation1D<TControl> par_2ndprior,
        //                                           DLLOperation1D<TControl> par_1stprior)
        //{
        //    // Added 10/25/2024 
        //    //
        //    mod_opPrior_ForUndo = par_2ndprior;
        //    mod_opPrior_ForRedo = par_1stprior;

        //}

        public DLLOpsUndoRedoMarker1DParallel(DLLOperation1D_2TypesInParallel<TControl, TParallel> par_1stPrior, bool onlyOperationExecutedYet)
        {
            // Added 10/25/2024 
            //
            //mod_opPrior_ForUndo = par_2ndprior;
            //mod_opNext_ForRedo = par_1stprior;
            mod_opPrior_ForUndo = par_1stPrior;
            mod_opNext_ForRedo = null;

            //Added 4/20/2025 
            if (onlyOperationExecutedYet) mod_opPrior_ForUndo.DLL_MarkStartOfList();
            if (onlyOperationExecutedYet) mod_opPrior_ForUndo.DLL_MarkEndOfList();

            //
            //Added 5/17/2025 td
            //
            mod_tuplePriorNext = new Tuple<DLLOperation1D_2TypesInParallel<TControl, TParallel>?,
                                           DLLOperation1D_2TypesInParallel<TControl, TParallel>?>
                                           (par_1stPrior, null);

        }



        public DLLOpsUndoRedoMarker1DParallel(DLLOperation1D_2TypesInParallel<TControl, TParallel> par_1stPrior,
                         DLLOperation1D_2TypesInParallel<TControl, TParallel> par_2ndPrior)
        {
            //
            // Added 10/25/2024 
            //
            bool bBothOpsAreTheSame; //Added 5/18/2025 td
            //Added 5/18/2025 td
            bBothOpsAreTheSame = (par_1stPrior == par_2ndPrior);
            if (bBothOpsAreTheSame)
            {
                //Added 5/18/2025 td
                System.Diagnostics.Debugger.Break();
            }

            mod_opPrior_ForUndo = par_1stPrior;
            mod_opNext_ForRedo = par_2ndPrior;

            // Administrative
            mod_opPrior_ForUndo.DLL_SetOpNext_OfT(par_2ndPrior, true);

        }



        public DLLOpsUndoRedoMarker1DParallel()
        {
            // Added 10/25/2024 
            //
            //mod_opPrior_ForUndo = par_2ndprior;
            //mod_opNext_ForRedo = par_1stprior;
            mod_opPrior_ForUndo = null;  // par_1stPrior;
            mod_opNext_ForRedo = null;
        }


        public void SetFirstOperation(DLLOperation1D_2TypesInParallel<TControl, TParallel> par_1stPrior)
        {
            //
            // Added 12/04/2024
            //
            //Moved below.  mod_opPrior_ForUndo = par_1stPrior;

            bool bBothOpsAreTheSame; //Added 5/18/2025 td
            //Added 5/18/2025 td
            bBothOpsAreTheSame = (par_1stPrior == mod_opNext_ForRedo);
            if (bBothOpsAreTheSame)
            {
                //Added 5/18/2025 td
                System.Diagnostics.Debugger.Break();
            }

            //
            // Proceed.
            //
            mod_opPrior_ForUndo = par_1stPrior;


        }


        public bool HasOperationNext_ForRedo()
        {
            // Added 5/22/2024
            return (mod_opNext_ForRedo != null);
        }

        public bool HasOperationPrior_ForUndo()
        {
            // Added 5/22/2024
            return (mod_opPrior_ForUndo != null);

        }


        public bool BothOperationsAreTheSame_Error()
        {
            //
            // Added 5/18/2025 
            //
            bool bBothOpsAreTheSame; //Added 5/18/2025 td
            //Added 5/18/2025 td
            bBothOpsAreTheSame = (mod_opPrior_ForUndo == mod_opNext_ForRedo);
            if (bBothOpsAreTheSame)
            {
                //Added 5/18/2025 td
                System.Diagnostics.Debugger.Break();
                return true;
            }
            else return false;

        }


        public DLLOperation1D_Of<TControl>
            GetMarkersNext_ShiftPositionRight()
        {
            //
            // Added 5/22/2024 td
            //

            if (mod_opNext_ForRedo == null)
            {
                // We should NOT be calling this function. The calling procedure 
                // should have called HasOperationNext() first, and omitted 
                // a call to this procedure in the case that HasOperationNext()
                // returns a False. ---1/18/2024 
                System.Diagnostics.Debugger.Break();
                return null;
            }
            else
            {
                DLLOperation1D_2TypesInParallel<TControl, TParallel> temp_output; // = null;
                DLLOperation1D_2TypesInParallel<TControl, TParallel> result_operation; // = null;
                 
                temp_output = mod_opNext_ForRedo;
                result_operation = mod_opNext_ForRedo;

                // Prepare for future calls to this function, NOT for the present call....
                // April2025  mod_opNext_ForRedo = temp_output.GetNext(); //.DLL_GetItemNext();
                mod_opNext_ForRedo = temp_output.GetNext_OfOf(); //.DLL_GetItemNext();
                mod_opPrior_ForUndo = temp_output;
                return result_operation;
            }

       

            // End of "if (mod_opNext_ForRedo == null)... else..."

        }


        /// <summary>
        /// This function provides the operation which was prior / earlier, in the recorded
        /// sequence of operations (assuming the user did one or more list-order operations
        /// prior to changing their mind and choosing to perform the Undo). Here, the "prior"
        /// is relative to our location within this queue of recorded operations.
        /// </summary>
        /// <returns></returns>
        public DLLOperation1D_Of<TControl> GetMarkersPrior_ShiftPositionLeft()
        {
            // Added 1/15/2024  Thomas Downes

            if (mod_opPrior_ForUndo == null)
            {
                // We should NOT be calling this function. The calling procedure 
                // should have called HasOperationNext() first, and omitted 
                // a call to this procedure in the case that HasOperationNext()
                // returns a False. ---1/18/2024 
                System.Diagnostics.Debugger.Break();
                return null; // result_operation;
            }
            else
            {
                DLLOperation1D_2TypesInParallel<TControl, TParallel> temp_output; // = null;
                DLLOperation1D_2TypesInParallel<TControl, TParallel> result_operation; // = null;
                temp_output = mod_opPrior_ForUndo;
                result_operation = mod_opPrior_ForUndo;

                // Prepare for future calls to this function, NOT for the present call...
                //April 2025  mod_opPrior_ForUndo = temp_output.GetPrior();
                mod_opPrior_ForUndo = temp_output.GetPrior_OfOf();
                mod_opNext_ForRedo = temp_output;
                return result_operation as DLLOperation1D_Of<TControl>;
            }

        }


        /// <summary>
        /// If we imagine the marker as a pair of square brackets, then 
        /// we can write the following as an illustration.
        /// Imagine a list of executed operations:  
        ///       Operation1, Operation2, Operation3, Operation4, Operation5
        /// and the following is the current marker:
        ///                               [Operation3, Operation4]
        /// After Operation#2 is reversed using the  [Undo] button, and this 
        ///    function is called, the marker will be:
        ///                   [Operation2, Operation3]
        /// Another illustration, before and after:
        /// Before:
        ///       Operation1, Operation2, [ Operation3  ,  Operation4  ], Operation5
        ///                                ^_will Undo_^   ^Prior Undo^   ^Prior Undo^
        /// After:      
        ///       Operation1, [Operation2, Operation3]  , Operation4,    Operation5
        ///                                ^Prior Undo^   ^Prior Undo^   ^Prior Undo^
        ///                                
        /// Thus, the marker has shifted left, toward the prior (lower-numbered) operation.                              
        /// </summary>
        public void ShiftMarkerLeft_AfterUndo_ToPrior()
        {
            //''
            //''Just like a Tuple, a DLL_OperationMarker is immutable.Or, 
            //''   it would be, if not for this procedure.So, I guess it 
            //''   is mutable...unless I comment out this procedure!!!! 1/10/2024
            //''

            // Encapsulated 5/18/2025 
            GetMarkersPrior_ShiftPositionLeft();


            //if (mod_opPrior_ForUndo == null) System.Diagnostics.Debugger.Break();
            //if (mod_opPrior_ForUndo == null) throw new RSCEndpointException();
            //
            //DLLOperation1D_OfOf<TControl, TParallel>? temp_op;
            //temp_op = mod_opPrior_ForUndo;
            //
            //mod_opPrior_ForUndo = mod_opPrior_ForUndo.DLL_GetOpPrior_OfOf(); //''Shift to the Left...to Prior() item.
            //
            //if (mod_opNext_ForRedo == null)  //Then ''Added 1 / 15 / 2024 td
            //{
            //    //''Added 1 / 15 / 2024 td
            //    mod_opNext_ForRedo = temp_op; //''January 18, 2024 td ''mod_opPrior_ForUndo
            //}
            //else
            //{
            //    mod_opNext_ForRedo = mod_opNext_ForRedo.DLL_GetOpPrior_OfOf(); // ''Shift to the Left...to Prior() item.
            //
            //} // End If ''End of ""If(mod_opNext_ForRedo Is Nothing) Then...Else"

        }  // End Sub ''End of ""Public Sub ShiftMarker_AfterUndo_ToPrior""



        /// <summary>
        /// If we imagine the marker as a pair of square brackets, then 
        /// we can write the following as an illustration.
        /// Imagine a list of executed operations:  
        ///       Operation1, Operation2, Operation3, Operation4, Operation5
        /// and the following is the current marker:
        ///                   [Operation2, Operation3]
        /// After Operation#3 is re-executed [Redo] button, and this 
        ///    function is called, the marker will be shifted one position to right:
        ///                               [Operation3, Operation4]
        ///                               
        /// Another illustration, before and after:
        /// Before:
        ///       Operation1, [Operation2, Operation3] , Operation4   , Operation5
        ///                                ^will Redo^   ^Prior Undo^   ^Prior Undo^
        /// After:      
        ///       Operation1, Operation2 , [Operation3 , Operation4 ],    Operation5
        ///                                              ^Prior Undo^   ^Prior Undo^
        ///                                
        /// Thus, the marker has shifted right, toward the next, higher-numbered operation.  
        /// 
        /// </summary>
        /// <exception cref="RSCEndpointException"></exception>
        public void ShiftMarkerRight_AfterRedo_ToNext()
        {
            //
            // Added 4/23/2025 td
            //
            //''Just like a Tuple, a DLL_OperationMarker is immutable.Or, 
            //''   it would be, if not for this procedure.So, I guess it 
            //''   is mutable...unless I comment out this procedure!!!! 1/10/2024
            //''

            // Encapsulated 5/18/2025 
            GetMarkersNext_ShiftPositionRight();

            //if (mod_opNext_ForRedo == null) System.Diagnostics.Debugger.Break();
            //if (mod_opNext_ForRedo == null) throw new RSCEndpointException();
            //
            //DLLOperation1D_OfOf<TControl, TParallel>? temp_op;
            //temp_op = mod_opNext_ForRedo;
            //
            //mod_opNext_ForRedo = mod_opNext_ForRedo.DLL_GetOpNext_OfOf(); //''Shift to the Left...to Prior() item.
            //
            //if (mod_opPrior_ForUndo == null)  //Then ''Added 1 / 15 / 2024 td
            //{
            //    //''Added 1 / 15 / 2024 td
            //    mod_opPrior_ForUndo = temp_op; //''January 18, 2024 td ''mod_opPrior_ForUndo
            //}
            //else
            //{
            //    mod_opPrior_ForUndo = mod_opPrior_ForUndo.DLL_GetOpNext_OfOf(); // ''Shift to the Left...to Prior() item.
            //} // End If ''End of ""If(mod_opNext_ForRedo Is Nothing) Then...Else"

        }  // End Sub ''End of ""Public Sub ShiftMarker_AfterUndo_ToPrior""



        public void ClearAllOperations()
        {
            //Added 12/04/2024 
            mod_opNext_ForRedo = null;
            mod_opPrior_ForUndo = null;

        }


        public int GetCurrentIndex_Undo()
        {
            //''Added 5/18/2025
            if (mod_opPrior_ForUndo == null)
            {
                System.Diagnostics.Debugger.Break();
                throw new Exception("No Redo operation.");
            }

            //''Added 1/13/2024
            return mod_opPrior_ForUndo.DLL_GetIndex();

        }

        public int GetCurrentIndex_Redo()
        {
            //''Added 5/18/2025
            if (mod_opNext_ForRedo == null)
            {
                System.Diagnostics.Debugger.Break();
                throw new Exception("No Redo operation.");
            }

            //''Added 7/03/2024 and 1/13/2024
            //
            return mod_opNext_ForRedo.DLL_GetIndex();

        }

        /// <summary>
        /// Returns the <typeparamref name="TControl"/> version of the Current Undo.
        /// </summary>
        /// <returns>The <typeparamref name="TControl"/> version of the Current Undo.</returns>
        public DLLOperation1D_Of<TControl>? GetCurrentOp_Undo_Of()
        {
            // Added 7/03/2024 
            return mod_opPrior_ForUndo;
        }


        /// <summary>
        /// Returns the <<typeparamref name="TControl"/>, TParallel> version of the Current Undo.
        /// </summary>
        /// <returns>The <<typeparamref name="TControl"/>, TParallel> version of the Current Undo.</returns>
        public DLLOperation1D_2TypesInParallel<TControl, TParallel>? GetCurrentOp_Undo_OfOf()
        {
            // Added 7/03/2024 
            return mod_opPrior_ForUndo;

        }


        /// <summary>
        /// Returns the <<typeparamref name="TControl"/>, TParallel> version of the Current Undo.
        /// </summary>
        /// <returns>The <<typeparamref name="TControl"/>, TParallel> version of the Current Undo.</returns>
        public DLLOperation1D_Of<TControl> GetCurrentOp_Redo_Of()
        {
            // Added 4/08/2025 
            return mod_opNext_ForRedo;
        }


        /// <summary>
        /// Returns the <<typeparamref name="TControl"/>, TParallel> version of the Current Undo.
        /// </summary>
        /// <returns>The <<typeparamref name="TControl"/>, TParallel> version of the Current Undo.</returns>
        public DLLOperation1D_2TypesInParallel<TControl, TParallel> GetCurrentOp_Redo_OfOf()
        {
            // Added 4/08/2025 
            return mod_opNext_ForRedo;
        }



        public int CountsOpsToRedo()
        {
            //
            // Added 12/01/2024 as an Alias function.
            //
            return HowManyOpsExistForRedo();

        }

        public int CountsOpsToUndo()
        {
            //
            // Added 12/01/2024 as an Alias function.
            //
            return HowManyOpsExistForUndo();

        }



        public int HowManyOpsExistForRedo()
        {
            //
            // Added 11/29/2024 
            //
            int result_count;

            if (mod_opNext_ForRedo == null)
            {
                result_count = 0;
            }

            else
            {
                result_count = (1 + mod_opNext_ForRedo.DLL_CountOpsAfter());
            }

            return result_count;

        }


        public int HowManyOpsExistForUndo()
        {
            //
            // Added 11/29/2024 
            //
            int result_count;

            if (mod_opPrior_ForUndo == null)
            {
                result_count = 0;
            }

            else
            {
                result_count = (1 + mod_opPrior_ForUndo.DLL_CountOpsBefore());
            }

            return result_count;

        }


        public int HowManyOpsExist_Total()
        {
            //
            // Added 11/29/2024 
            //
            int result_count;
            result_count = HowManyOpsExistForRedo();
            result_count += HowManyOpsExistForUndo();
            return result_count;

        }


        public void ClearPendingRedoOperation()
        {
            //
            // Added 12/02/2024
            //
            //    This is needed if the user has pressed the "Undo" button, 
            //    and now wants to move forward with a "brand new" operation. 
            //    Rather than following "Undo" with a "Redo", user wants to 
            //    permanently discard the his or her most recent operation. 
            //    (The operation being discarded was definitely a mistake in
            //    the user's perspective.)
            //    12/02/2024 th.omas do.wnes 
            //
            bool bBothOpsAreTheSame; //Added 5/18/2025 td
            //Added 5/18/2025 td
            bBothOpsAreTheSame = (mod_opPrior_ForUndo == mod_opNext_ForRedo);
            if (bBothOpsAreTheSame)
            {
                //Added 5/18/2025 td
                System.Diagnostics.Debugger.Break();
            }

            mod_opNext_ForRedo = null;

            //Added 5/16/2025 
            if (mod_opPrior_ForUndo != null)
            {
                // Added 5/16/2025 
                //
                //   Remove the reference to any "Next" Redo operation.
                //
                mod_opPrior_ForUndo.DLL_ClearOpNext();
            }


        }


        public string ToString(DLLOperation1D_Of<TControl> par_newOp)
        {

            //
            //  Added 12/02/2027 t..homas d..ownes
            //
            int intCountOpsForUndo = HowManyOpsExistForUndo();
            int intCountOpsPriorToParam = par_newOp.DLL_CountOpsBefore();
            bool boolMatch;
            boolMatch = (intCountOpsForUndo == (1 + intCountOpsPriorToParam));
            if (!boolMatch) Debugger.Break();

            return ToString();

        }



        public string ToString(int par_expectedOpCount = -1) // Added optional parameter Jan4 2025
        {
            //public overrides string ToString() // Added optional parameter Jan4 2025
            //
            // Added 11/29/2024 
            //
            string result_describe;

            string template = "" +
                "Count of ops total: {0}    " + Environment.NewLine +
                "Count of ops for redo: {1} " + Environment.NewLine +
                "Count of ops for undo: {2} ";

            try
            {
                //int intCountOpsTotal = HowManyOpsExist_Total();
                int intCountOpsForRedo = HowManyOpsExistForRedo();
                int intCountOpsForUndo = HowManyOpsExistForUndo();

                //
                // Let's make two(2) attempts to find the total number of operations part are
                //   part of the history queue of operations. 
                //
                //  Try #1 of 2 -- Add the Undo & Redo counts. 
                //
                int intCountOpsTotal_Try1of2;
                if (mod_opPrior_ForUndo == mod_opNext_ForRedo)
                {
                    intCountOpsTotal_Try1of2 = (-1 + intCountOpsForUndo + intCountOpsForRedo);
                }
                else
                {
                    intCountOpsTotal_Try1of2 = (intCountOpsForUndo + intCountOpsForRedo); // Added Jan4 2025 td

                }

                //
                // Try #2 of 2 -- Use a DLL method to find a count of all operations.
                //
                int intCountOpsTotal_Final = 0; //Added 4/17/2025
                int intCountOpsTotal_Try2of2 = 0; //Added 4/17/2025
                bool bBothOpReferencesAreNull; // Added 4/20/2025

                bBothOpReferencesAreNull = (mod_opNext_ForRedo == null &&
                                            mod_opPrior_ForUndo == null);

                if (bBothOpReferencesAreNull)
                {
                    //
                    // Added 4/19/2025 td
                    //
                }
                else if (mod_opNext_ForRedo != null) //Added 4/17/2025
                {
                    intCountOpsTotal_Try2of2 = mod_opNext_ForRedo.DLL_CountAllOpsInTheList();
                }
                else if (mod_opPrior_ForUndo != null) //Added 4/17/2025
                {
                    intCountOpsTotal_Try2of2 = mod_opPrior_ForUndo.DLL_CountAllOpsInTheList();
                }

                //Added 4/17/2025  
                bool bTwoCountTriesMatch = (intCountOpsTotal_Try1of2 == intCountOpsTotal_Try2of2);

                if (bBothOpReferencesAreNull) // Added 4/19/2025 td
                {
                    // Added 4/19/2025 td
                    intCountOpsTotal_Final = 0; // intCountOpsTotal_Try1of2;
                }
                else if (bTwoCountTriesMatch)
                {
                    intCountOpsTotal_Final = intCountOpsTotal_Try1of2; 
                }
                else
                {
                    // Added 4/18/2025
                    System.Diagnostics.Debugger.Break();
                }


                // Added 1/04/2024  thomas d.
                //
                if (par_expectedOpCount > -1)
                {
                    if (intCountOpsTotal_Try1of2 != par_expectedOpCount) Debugger.Break();
                }

                result_describe = string.Format(template, intCountOpsTotal_Final, intCountOpsForRedo, intCountOpsForUndo);
                return result_describe;
            }
            catch (Exception ex_any)
            {
                // Added 1/04/2024  thomas d.
                return ex_any.Message;
            }

        }



    }
}


