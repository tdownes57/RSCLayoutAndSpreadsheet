using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    /// <summary>
    /// This operation class is index-only, meaning that it relies on the class DLLOperationIndexStructure.
    /// </summary>
    internal class DLLOperation_2D_Indexed
    {

        // Operation represented by Boolean & Integer values.  
        private DLLOperationIndexStructure mod_operationByIndex;

        private bool mod_bInParallelOrVertical;   // For Row Headers &/or Columns of Data Cells.
        private bool mod_bPerpendicularOrHorizontal;  // For the horizontal arrangement of the Columns. 

        /// <summary>
        /// What is the operation that occurred prior to the present (this) operation?
        /// </summary>
        internal DLLOperation_2D_Indexed? mod_opPrior_ForUndo_OfT;
        /// <summary>
        /// What is the operation that occurred following the present (this) operation?
        /// </summary>
        internal DLLOperation_2D_Indexed? mod_opNext_ForRedo_OfT;

        /// <summary>
        /// This Boolean confirms that there is no following operation, i.e. this operation is the most recent freshly-executed (vs. Undo, Redo) operation.
        /// </summary>
        internal bool mod_opNextIsNull = false; //Added 4/18/2025 

        /// <summary>
        /// This  Boolean confirms that there is no prior operation, i.e. this operation is the first of a sequence of operations.
        /// </summary>
        internal bool mod_opPriorIsNull = false; //Added 4/18/2025 

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="par_bInParallelAndOrVertical">Will the operation propagate to a set of (parallelized) lists? Is the Operation related to re-ordering the rows of the spreadsheet?  E.g. Alphabetizing 80 employee records occupying 80 rows of a spreadsheet.</param>
        /// <param name="par_bPerpendicularOrHorizontal">Is the operation related to re-ordering the columns of the spreadsheet?</param>
        /// <param name="par_operationByIndex">The index-only version of the operation.</param>
        public DLLOperation_2D_Indexed(bool par_bInParallelAndOrVertical, 
                                       bool par_bPerpendicularOrHorizontal,
                                       DLLOperationIndexStructure par_operationByIndex)
        {
            //
            // Added 6/09/2025 
            //
            mod_operationByIndex = par_operationByIndex;

            //Will the operation propagate to a set of (parallelized) lists?
            //  i.e. Is the Operation related to re-ordering the rows (& row-headers)
            //  of the spreadsheet?  E.g. Alphabetizing 80 employee records which are
            //  spread across 80 rows of a spreadsheet, or adding a new employee record
            //  to the same spreadsheet.
            mod_bInParallelOrVertical = par_bInParallelAndOrVertical;

            //Is the operation related to re-ordering the columns of the spreadsheet?
            //  E.g. inserting a column for Social Security Number on a spreadsheet 
            // containing 80 employee records.
            mod_bPerpendicularOrHorizontal = par_bPerpendicularOrHorizontal;

        }


        /// <summary>
        /// Will the operation propagate to a set of (parallelized) lists?
        /// i.e. Is the Operation related to re-ordering the rows (& row-headers)
        ///  of the spreadsheet?  E.g. Alphabetizing 80 employee records which are
        ///  spread across 80 rows of a spreadsheet, or adding a new employee record.
        /// </summary>
        /// <returns></returns>
        public bool ForParallelListsAndOrVertical()
        {
            return mod_bInParallelOrVertical;

        }

        /// <summary>
        /// Is the operation related to re-ordering the columns of the spreadsheet?
        ///  E.g. inserting a column for Social Security Number on a spreadsheet 
        ///   containing 80 employee records.
        /// </summary>
        /// <returns></returns>
        public bool IsPerpendicularOrHorizontal()
        {
            return mod_bPerpendicularOrHorizontal;

        }



        /// <summary>
        /// Create the inverse (Undo) version, created when an "Undo" operation is needed.
        /// </summary>
        /// <returns>Inverse of the present operation</returns>
        public DLLOperation_2D_Indexed? GetPrior()
        {
            //
            // Added 5/25/2024 
            //
            return mod_opPrior_ForUndo_OfT;

        }

        /// <summary>
        /// Create the inverse (Undo) version, created when an "Undo" operation is needed.
        /// </summary>
        /// <returns>Inverse of the present operation</returns>
        public DLLOperation_2D_Indexed? GetNext()
        {
            //
            // Added 5/25/2024 
            //
            return mod_opNext_ForRedo_OfT;

        }


        public bool HasPrior()
        {
            //
            // Added 5/25/2024 
            //
            return (mod_opPrior_ForUndo_OfT != null);

        }

        public bool HasNext()
        {
            //
            // Added 5/25/2024 
            //
            return (mod_opNext_ForRedo_OfT != null);

        }





    }
}
