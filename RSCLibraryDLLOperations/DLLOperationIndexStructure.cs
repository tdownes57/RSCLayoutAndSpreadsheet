using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    //
    // Added 1/11/2025 thomas downes
    //
    /// <summary>       
    ///  This is a Boolean-and-Integer description of the operation.
    ///    It does not rely on object references.  The purpose is to provide a simple,
    ///    value-type description of the operation.  This will enable the easy
    ///    propagation of the operation description to parallel lists of controls.
    ///    (Object references are avoided.)
    /// </summary>
    public struct DLLOperationIndexStructure
    {
        //
        // Added 1/11/2025 thomas downes
        //
        public DLLOperationIndexStructure()
        {
            IsInsert = false;
            IsDelete = false;
            IsMove = false;
            RangeIsSpecified = false;  // Added 1/12/2025 thom.as down.es
            AnchorIsSpecified = false; 
            AnchorIndexLeft_b1 = -1;
            AnchorIndexRight_b1 = -1;
            TypeOfMove = new StructureTypeOfMove();
            TypeOfMove.IsMoveType = false;
            Sorting = false;
            SortingAscending = false;
            SortingDescending = false;
            IsUndoOfSort = false;
            // Added 2/01/2025 
            IsInsert_IgnoreRange = false; 
            IsMoveOrDelete_UseRangeIndices = false;
        }

        public bool IsInsert;
        public bool IsDelete;
        public bool IsMove;

        //---------------------------------------------------------
        //---------------- DIFFICULT AND CONFUSING ----------------
        // Added 2/01/2025 
        public bool IsInsert_IgnoreRangeIndices;  // Are NOT range indices applicable? 
        public int IsInsert_InsertionCount; // How many items to insert?
        public bool IsMoveOrDelete_UseRangeIndices;  // Is the range indices applicable?
        //---------------------------------------------------------

        public StructureTypeOfMove TypeOfMove;

        /// <summary>
        /// Index is relevant to Moves & Deletes only!! This index is 1-based.  (Not zero-based.)
        /// </summary>
        public int RangeStartingIndex_b1;
        /// <summary>
        /// Index is relevant to Moves & Deletes only!! This index is 1-based.  (Not zero-based.)
        /// </summary>
        public int RangeEndingIndex_b1;

        // public int RangeSize; // This is not used for Inserts. 
        public int RangeSize_MoveOrDelete; // This is used for Deletes Or Moves. 
        public int RangeSize_Inserts; // This is not used for Inserts.

        // public bool RangeIsSpecified;  // Added 1/12/2025 thomas downes
        public bool RangeIsSpecified_MoveOrDelete;  // Added 1/12/2025 thomas downes
        public bool AnchorIsSpecified;

        /// <summary>
        /// This index is 1-based.  (Not zero-based.)
        /// </summary>
        public int AnchorIndexLeft_b1; // = -1;
        public int AnchorIndexRight_b1; // = -1;

        public bool Sorting;
        public bool SortingAscending;
        public bool SortingDescending;

        public bool IsUndoOfSort;
        public int[] ArrayToUndoSort; 


        public override string ToString()
        {
            //
            // Added 1/14/2025 thomas downes
            //
            string return_string = ""; 
            if (IsInsert) return_string += "Insert \n";
            if (IsDelete) return_string += "Delete \n";
            if (IsMove) return_string += "Move \n";

            if (IsUndoOfSort) return_string += "Undo of Sort \n";
            if (SortingAscending) return_string += "Sort Ascending \n";
            if (SortingDescending) return_string += "Sort Descending \n";

            if (RangeIsSpecified) return_string += "Range: " + 
                    RangeStartingIndex_b1.ToString() + " to " + 
                    RangeEndingIndex_b1.ToString() + "\n";

            if (RangeIsSpecified) return_string += "Range Size: " + RangeSize.ToString() + "\n";

            return return_string;

        }



    }
}
