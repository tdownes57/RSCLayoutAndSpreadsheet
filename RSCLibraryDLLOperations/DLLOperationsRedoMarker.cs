using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    internal class DLLOperationsRedoMarker<TControl_H, TControl_V>
        where TControl_H : IDoublyLinkedItem<TControl_H>
        where TControl_V : IDoublyLinkedItem<TControl_V>
    {
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
        private DLLOperation<TControl_H, TControl_V> mod_opPrior_ForUndo;

        //''' <summary>
        //''' If the user hits "Redo", this operation will be 
        //''' performed as it is.  (In contrast to "Undo", we
        //''' do NOT need to get the inverse of the operation.) 
        //''' </summary>
        private DLLOperation<TControl_H, TControl_V> mod_opNext_ForRedo;


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


        public DLLOperation<TControl_H, TControl_V> 
            GetMarkersNext_ShiftPositionRight()
        {
            //
            // Added 5/22/2024 td
            //


        }


    }
}
