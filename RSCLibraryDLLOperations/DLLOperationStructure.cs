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
    /// </summary>
    public struct DLLOperationStructure
    {
        //
        // Added 1/11/2025 thomas downes
        //
        public DLLOperationStructure()
        {
            IsInsert = false;
            IsDelete = false;
            IsMove = false;
            AnchorIsSpecified = false; 
            AnchorIndexLeft = -1;
            AnchorIndexRight = -1;
            TypeOfMove = new StructureTypeOfMove();
            TypeOfMove.IsMoveType = false;
            Sorting = false;
            SortingAscending = false;
            SortingDescending = false;
            IsUndoOfSort = false;
        }

        public bool IsInsert;
        public bool IsDelete;
        public bool IsMove;

        public StructureTypeOfMove TypeOfMove;

        /// <summary>
        /// This index is 1-based.  (Not zero-based.)
        /// </summary>
        public int RangeStartingIndex_b1;
        /// <summary>
        /// This index is 1-based.  (Not zero-based.)
        /// </summary>
        public int RangeEndingIndex_b1;
        public int RangeSize;

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

    }
}
