using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    internal class DLLOpsUndoRedoMarker_OfBase<TOperation>
    where TOperation : DLLOperationBase
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
        //''' If the user h its "Undo", this operation will be 
        //''' inversed and the inverse will be performed. 
        //''' </summary>
        private TOperation? mod_opPrior_ForUndo;

        //''' <summary>
        //''' If the user hits "Redo", this operation will be 
        //''' performed as it is.  (In contrast to "Undo", we
        //''' do NOT need to get the inverse of the operation.) 
        //''' </summary>
        private TOperation? mod_opNext_ForRedo;


        //public DLLOperationsRedoMarker1D(DLLOperation1D<TControl> par_2ndprior,
        //                                           DLLOperation1D<TControl> par_1stprior)
        //{
        //    // Added 10/25/2024 
        //    //
        //    mod_opPrior_ForUndo = par_2ndprior;
        //    mod_opPrior_ForRedo = par_1stprior;

        //}

        public DLLOpsUndoRedoMarker_OfBase(TOperation par_1stPrior)
        {
            // Added 10/25/2024 
            //
            //mod_opPrior_ForUndo = par_2ndprior;
            //mod_opNext_ForRedo = par_1stprior;
            mod_opPrior_ForUndo = par_1stPrior;
            mod_opNext_ForRedo = null;
        }



        public DLLOpsUndoRedoMarker_OfBase(TOperation par_1stPrior,
                                             TOperation par_2ndPrior)
        {
            // Added 10/25/2024 
            //
            mod_opPrior_ForUndo = par_1stPrior;
            mod_opNext_ForRedo = par_2ndPrior;

            // Administrative
            mod_opPrior_ForUndo.DLL_SetOpNext(par_2ndPrior, true);

        }



        public DLLOpsUndoRedoMarker_OfBase()
        {
            // Added 10/25/2024 
            //
            //mod_opPrior_ForUndo = par_2ndprior;
            //mod_opNext_ForRedo = par_1stprior;
            mod_opPrior_ForUndo = null;  // par_1stPrior;
            mod_opNext_ForRedo = null;
        }


        public void SetFirstOperation(TOperation par_1stPrior)
        {
            //
            // Added 12/04/2024
            //
            mod_opPrior_ForUndo = par_1stPrior;

        }


        public bool HasOperationNext()
        {
            // Added 5/22/2024
            return (mod_opNext_ForRedo != null);
        }

        public bool HasOperationPrior()
        {
            // Added 5/22/2024
            return (mod_opPrior_ForUndo != null);

        }


        public TOperation
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
                TOperation temp_output; // = null;
                TOperation result_operation; // = null;
                temp_output = mod_opNext_ForRedo;
                result_operation = mod_opNext_ForRedo;

                // Prepare for future calls to this function, NOT for the present call....
                mod_opNext_ForRedo = temp_output.DLL_GetOpNext() as TOperation; 
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
        public TOperation GetMarkersPrior_ShiftPositionLeft()
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
                TOperation temp_output; // = null;
                TOperation result_operation; // = null;
                temp_output = mod_opPrior_ForUndo;
                result_operation = mod_opPrior_ForUndo;

                // Prepare for future calls to this function, NOT for the present call....
                mod_opPrior_ForUndo = temp_output.DLL_GetOpNext() as TOperation;
                mod_opNext_ForRedo = temp_output;
                return result_operation;
            }

        }


        public void ShiftMarker_AfterUndo_ToPrior()
        {
            //''
            //''Just like a Tuple, a DLL_OperationMarker is immutable.Or, 
            //''   it would be, if not for this procedure.So, I guess it 
            //''   is mutable...unless I comment out this procedure!!!! 1/10/2024
            //''
            if (mod_opPrior_ForUndo == null) System.Diagnostics.Debugger.Break();
            if (mod_opPrior_ForUndo == null) throw new RSCEndpointException();

            TOperation? temp_op;
            temp_op = mod_opPrior_ForUndo;

            //mod_opPrior_ForUndo = mod_opPrior_ForUndo.DLL_GetOpPrior_OfT(); //''Shift to the Left...to Prior() item.
            mod_opPrior_ForUndo = mod_opPrior_ForUndo.DLL_GetOpNext() as TOperation; //''Shift to the Left...to Prior() item.

            if (mod_opNext_ForRedo == null)  //Then ''Added 1 / 15 / 2024 td
            {
                //''Added 1 / 15 / 2024 td
                mod_opNext_ForRedo = temp_op; //''January 18, 2024 td ''mod_opPrior_ForUndo
            }
            else
            {
                mod_opNext_ForRedo = mod_opNext_ForRedo.DLL_GetOpNext() as TOperation; // ''Shift to the Left...to Prior() item.
            } // End If ''End of ""If(mod_opNext_ForRedo Is Nothing) Then...Else"

        }  // End Sub ''End of ""Public Sub ShiftMarker_AfterUndo_ToPrior""


        public void ClearAllOperations()
        {
            //Added 12/04/2024 
            mod_opNext_ForRedo = null;
            mod_opPrior_ForUndo = null;

        }


        /// <summary>
        /// This provides the base-1 index of the Current Undo operation, 
        ///   relative to prior operations.
        /// </summary>
        /// <returns></returns>
        public int GetCurrentIndex_b1_Undo()
        {

            //''Added 1/13/2024
            return mod_opPrior_ForUndo.DLL_GetOpIndex_b1();

        }


        /// <summary>
        /// This provides the base-1 index of the Current Redo operation, 
        ///   relative to prior operations.
        /// </summary>
        public int GetCurrentIndex_b1_Redo()
        {
            //''Added 7/03/2024 and 1/13/2024
            //
            return mod_opNext_ForRedo.DLL_GetOpIndex_b1();

        }


        public TOperation GetCurrentOp_Undo()
        {
            // Added 7/03/2024 
            return mod_opPrior_ForUndo;
        }


        public TOperation GetCurrentOp_Redo()
        {
            // Added 7/03/2024 
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
            mod_opNext_ForRedo = null;

        }


        public string ToString(TOperation par_newOp)
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
                int intCountOpsTotal = (intCountOpsForUndo + intCountOpsForRedo); // Added Jan4 2025 td

                // Added 1/04/2024  thomas d.
                //
                if (par_expectedOpCount > -1)
                {
                    if (intCountOpsTotal != par_expectedOpCount) Debugger.Break();
                }

                result_describe = string.Format(template, intCountOpsTotal, intCountOpsForRedo, intCountOpsForUndo);
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
