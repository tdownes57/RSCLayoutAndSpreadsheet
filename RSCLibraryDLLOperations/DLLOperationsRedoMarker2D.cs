using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ciBadgeInterfaces;  //Added 6/30/2024  

namespace RSCLibraryDLLOperations
{
    //
    //    2D = 2 dimensions, a 2-dimensional grid
    //
    internal class DLLOperationsRedoMarker2D<TControl_H, TControl_V>
        where TControl_H : class, IDoublyLinkedItem<TControl_H>
        where TControl_V : class, IDoublyLinkedItem<TControl_V>
    {
        //
        //    2D = 2 dimensions, a 2-dimensional grid
        //
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
        private DLLOperation2D<TControl_H, TControl_V> mod_opPrior_ForUndo;

        //''' <summary>
        //''' If the user hits "Redo", this operation will be 
        //''' performed as it is.  (In contrast to "Undo", we
        //''' do NOT need to get the inverse of the operation.) 
        //''' </summary>
        private DLLOperation2D<TControl_H, TControl_V> mod_opNext_ForRedo;


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


        public DLLOperation2D<TControl_H, TControl_V> 
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
                DLLOperation2D<TControl_H, TControl_V> temp_output; // = null;
                DLLOperation2D<TControl_H, TControl_V> result_operation; // = null;
                temp_output = mod_opNext_ForRedo;
                result_operation = mod_opNext_ForRedo;

                // Prepare for future calls to this function, NOT for the present call....
                mod_opNext_ForRedo = temp_output.GetNext(); //.DLL_GetItemNext();
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
        public DLLOperation2D<TControl_H, TControl_V> GetMarkersPrior_ShiftPositionLeft()
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
                DLLOperation2D<TControl_H, TControl_V> temp_output; // = null;
                DLLOperation2D<TControl_H, TControl_V> result_operation; // = null;
                temp_output = mod_opPrior_ForUndo;
                result_operation = mod_opPrior_ForUndo;

                // Prepare for future calls to this function, NOT for the present call....
                mod_opPrior_ForUndo = temp_output.GetPrior();
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
            DLLOperation2D<TControl_H, TControl_V> temp_op;
            temp_op = mod_opPrior_ForUndo;

            mod_opPrior_ForUndo = mod_opPrior_ForUndo.DLL_GetOpPrior(); //''Shift to the Left...to Prior() item.

            if(mod_opNext_ForRedo == null)  //Then ''Added 1 / 15 / 2024 td
            {
                //''Added 1 / 15 / 2024 td
                mod_opNext_ForRedo = temp_op; //''January 18, 2024 td ''mod_opPrior_ForUndo
            }
            else
            {
                mod_opNext_ForRedo = mod_opNext_ForRedo.DLL_GetOpPrior(); // ''Shift to the Left...to Prior() item.
            } // End If ''End of ""If(mod_opNext_ForRedo Is Nothing) Then...Else"

        }  // End Sub ''End of ""Public Sub ShiftMarker_AfterUndo_ToPrior""


        public int GetCurrentIndex_Undo()
        {

            //''Added 1/13/2024
            return mod_opPrior_ForUndo.DLL_GetIndex();

        }

        public int GetCurrentIndex_Redo()
        {
            //''Added 7/03/2024 and 1/13/2024
            //
            return mod_opNext_ForRedo.DLL_GetIndex();

        }

        public DLLOperation2D<TControl_H, TControl_V> GetCurrentOp_Undo()
        {
            // Added 7/03/2024 
            return mod_opPrior_ForUndo;
        }

        public DLLOperation2D<TControl_H, TControl_V> GetCurrentOp_Redo()
        {
            // Added 7/03/2024 
            return mod_opNext_ForRedo;
        }


    }
}
