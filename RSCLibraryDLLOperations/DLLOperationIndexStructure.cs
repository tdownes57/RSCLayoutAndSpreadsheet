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

            //2025 RangeIsSpecified = false;  // Added 1/12/2025 thom.as down.es
            RangeIsSpecified_MoveOrDelete = false;  // Added 1/12/2025 thom.as down.es
            
            AnchorIsSpecified = false; 
            AnchorIndexLeft_b1 = -1;
            AnchorIndexRight_b1 = -1;
            TypeOfMove = new StructureTypeOfMove();
            TypeOfMove.IsMoveType = false;
            //Sorting = false;
            Sorting_ByItemValues = false; // Added 4/23/2025 td
            SortingAscending = false;
            SortingDescending = false;
            Sorting_ByArrayIndexMapping = false; // Added 4/23/2025 td
            IsUndoOfSort = false;
            // Added 2/01/2025 
            IsInsert_SoIgnoreRangeIndex = false;
            IsMoveOrDelete_UseRangeIndices = false;
            // Added 2/14/2025 td
            // Apr2025 ArrayToUndoSort = [];  // Added 2/14/2025
            ArrayOfIndicesToSort_Undo = [];  // Added 2/14/2025
            ArrayOfIndicesToSort_Redo = [];  // Added 2/14/2025
            
            IsInsert_SoMustCreateNewItems = false; //Added 2/14/2025 td

            // Added 4/14/2025
            InverseAnchorIndexLeft_b1 = -1;
            InverseAnchorIndexRight_b1 = -1;

        }

        public bool IsInsert;
        public bool IsDelete;
        public bool IsMove;

        //---------------------------------------------------------
        //---------------- DIFFICULT AND CONFUSING ----------------
        // Added 2/01/2025 
        public bool IsMoveOrDelete_UseRangeIndices;  // Is the range indices applicable?

        public bool IsInsert_SoIgnoreRangeIndex;  // Are NOT range indices applicable? 
        public int IsInsert_InsertionCount; // How many items to insert?
        // Added 2/14/2025 
        public bool IsInsert_SoMustCreateNewItems;  // Must new items be created from scratch? 
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
        /// <summary>
        /// This index is 1-based.  (Not zero-based.)
        /// </summary>
        public int AnchorIndexRight_b1; // = -1;

        public bool Sorting_ByItemValues; // Suffix added 4/23/2025
        public bool SortingAscending;
        public bool SortingDescending;

        public bool IsUndoOfSort;
        // April 2025  public int[] ArrayToUndoSort;
        // April 2025  public bool Sorting_ByArray; // Added 4/23/2025
        public bool Sorting_ByArrayIndexMapping; // Added 4/24/2025
        public int[] ArrayOfIndicesToSort_Undo; // Added "OfIndices" 4/23/2025
        public int[] ArrayOfIndicesToSort_Redo; // Added "OfIndices" 4/23/2025 

        // Added 4/14/2025
        /// <summary>
        /// This index is 1-based.  (Not zero-based.)
        /// </summary>
        public int InverseAnchorIndexLeft_b1; // = -1;

        // Added 4/14/2025
        /// <summary>
        /// This index is 1-based.  (Not zero-based.)
        /// </summary>
        public int InverseAnchorIndexRight_b1; // = -1;

        // Added 4/14/2025
        public bool InverseAnchorIsSpecified;
        public bool AnchorLeft_isNull; // = false;
        public bool AnchorRight_isNull; // = false;
        public bool InverseAnchorLeft_isNull; // = false;
        public bool InverseAnchorRight_isNull; // = false;


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

            //if (RangeIsSpecified) return_string += "Range: " +
            if (RangeIsSpecified_MoveOrDelete)
            {
                return_string += "Range: " +
                    RangeStartingIndex_b1.ToString() + " to " +
                    RangeEndingIndex_b1.ToString() + "\n";

                //return_string += "Range Size: " + RangeSize.ToString() + "\n";
                if (IsDelete)
                {
                    //return_string += "Range Size: " + RangeSize_MoveOrDelete.ToString() + "\n";
                    return_string += "Range Size (for Del): " + RangeSize_MoveOrDelete.ToString() + "\n";
                    return_string += "Range Index (for Del): " + RangeStartingIndex_b1.ToString() + "\n";
                }
                else if (IsMove)
                {
                    // Added 2/14/2025 
                    return_string += "Range Size (for Move): " + RangeSize_MoveOrDelete.ToString() + "\n";
                    return_string += "Range Index (for Move): " + RangeStartingIndex_b1.ToString() + "\n";
                }

            }
            else if (IsInsert)
            {
                // Added 2/14/2025 
                return_string += "Range Size (Insert): " + RangeSize_MoveOrDelete.ToString() + "\n";
            }

            return return_string;

        }



    }
}
