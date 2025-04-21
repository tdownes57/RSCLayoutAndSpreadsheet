using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ciBadgeInterfaces; //Added 01/05/2025

namespace RSCLibraryDLLOperations
{
    public class DLLOperationBase
    {
        //
        // Added 11/23/2024  
        //
        //--private DLLOperationBase? mod_opPrior = null;
        //--private DLLOperationBase? mod_opNext = null;

        internal DLLOperationBase? mod_opPrior_ForUndo = null;
        internal DLLOperationBase? mod_opNext_ForRedo = null;
        private bool mod_opNextIsNull = false; // Added 4/18/2025
        private bool mod_opPriorIsNull = false; // Added 4/18/2025


        public void OperateOnList<TSpecific>(DLLList<TSpecific> par_list) 
            where TSpecific : class, IDoublyLinkedItem<TSpecific>
        {
            //
            // Added 1/05/2025  
            //
            




        }   


        //public void SetArrayOfRanges<TRange>(DLLRange<TRange, TRange>[] par_arrayOfRanges)
        //{
        //}



        public void DLL_SetOpPrior(DLLOperationBase par_item)
        {
            //
            // Added 11/23/2024  
            //
            //---mod_opPrior = par_item;
            mod_opPrior_ForUndo = par_item;

            // Added 4/18/2025 
            if (par_item != null) mod_opPriorIsNull = false;

        }

        public void DLL_SetOpNext(DLLOperationBase par_item, bool par_bidirectional)
        {
            //
            // Added 11/23/2024
            // 
            // 12/02/2024 mod_opNext = par_item;
            mod_opNext_ForRedo = par_item;

            // Added 12/07/2024
            if (par_bidirectional) par_item.mod_opPrior_ForUndo = this;

            // Added 4/18/2025 
            if (par_item != null) mod_opNextIsNull = false; 
        
        }


        public DLLOperationBase? DLL_GetOpPrior()
        {
            //
            // Added 11/23/2024  
            //
            //----return mod_opPrior;
            return mod_opPrior_ForUndo; // = par_item;

        }

        public DLLOperationBase? DLL_GetOpNext()
        {
            //
            // Added 11/23/2024  
            //
            if (mod_opNext_ForRedo == null)
            {
                // Added 4/18/2025 td
                bool bConfirmedNull = mod_opNextIsNull;
                if (!bConfirmedNull) System.Diagnostics.Debugger.Break();
            }

            return mod_opNext_ForRedo;

        }


        /// <summary>
        /// This contains a confirmation when the return is False.
        /// </summary>
        /// <returns></returns>
        public bool DLL_HasOpPrior()
        {
            //
            // Added 11/23/2024  
            //
            //---return mod_opPrior != null; // = par_item;
            //return (mod_opPrior_ForUndo != null); // = par_item;

            if (mod_opPrior_ForUndo == null) //Added 4/18/2025 td
            {
                // Added 4/18/2025 td
                bool bConfirmedNull = mod_opPriorIsNull;
                if (!bConfirmedNull) System.Diagnostics.Debugger.Break();
                return false;
            }
            else return true;

            // return (mod_opPrior_ForUndo != null); // = par_item;

        }


        /// <summary>
        /// This contains a confirmation when the return is False.
        /// </summary>
        /// <returns></returns>
        public bool DLL_HasOpNext()
        {
            //
            // Added 11/23/2024  
            //
            //---return mod_opNext != null;
            //Apr2025 return (mod_opNext_ForRedo != null);

            if (mod_opNext_ForRedo == null) //Added 4/18/2025 td
            {
                // Added 4/18/2025 td
                bool bConfirmedNull = mod_opNextIsNull;
                if (!bConfirmedNull) System.Diagnostics.Debugger.Break();
                return false;
            }
            else return true;

        }


        public void DLL_ClearOpPrior()
        {
            //
            // Added 01/04/2025  
            //
            mod_opPrior_ForUndo = null; // = par_item;
            mod_opPriorIsNull = true; // Added 4/2025 

        }


        public void DLL_ClearOpNext()
        {
            //
            // Added 01/04/2025  
            //
            mod_opNext_ForRedo = null;
            mod_opNextIsNull = true; // Added 4/2025 

        }


        public virtual void DLL_MarkEndOfList()
        {
            //
            // Added 01/04/2025  
            //
            mod_opNext_ForRedo = null;
            mod_opNextIsNull = true; // Added 4/2025 

            // Added 4/18/2025 td
            //   Indicate that the //PRIOR// operation is //NOW NOT// the end of the list. 
            //-----this.mod_opPrior_ForUndo._isForEndOfList = false;
            if (mod_opPrior_ForUndo != null)
            { 
                mod_opPrior_ForUndo.mod_opNextIsNull = false;
            }
        }


        public virtual void DLL_MarkStartOfList()
        {
            //
            // Added 01/04/2025  
            //
            mod_opPrior_ForUndo = null;
            mod_opPriorIsNull = true; // Added 4/2025 
   

        }


        public bool DLL_MissingOpPrior()
        {
            //
            // Added 11/23/2024  
            //
            //---return mod_opPrior == null; // = par_item;
            //return mod_opPrior_ForUndo == null; // = par_item;

            if (mod_opPrior_ForUndo == null) //Added 4/18/2025 td
            {
                // Added 4/18/2025 td
                bool bConfirmedNull = mod_opPriorIsNull;
                if (!bConfirmedNull) System.Diagnostics.Debugger.Break();
                return true;
            }
            else return false;


        }


        public bool DLL_MissingOpNext()
        {
            //
            // Added 11/23/2024  
            //
            //--return mod_opNext == null;
            // April 2025 return mod_opNext_ForRedo == null;

            if (mod_opNext_ForRedo == null) //Added 4/18/2025 td
            {
                // Added 4/18/2025 td
                bool bConfirmedNull = mod_opNextIsNull;
                if (!bConfirmedNull) System.Diagnostics.Debugger.Break();
                return true; // yes, missing a "next" object
            }
            else return false;

        }


        public int DLL_CountAllOpsInTheList()
        {
            //
            // Added 04/18/2025  
            //
            int result_count = 0;

            //
            // Please note, "After" and "Next" are synonyms.  
            //    So, "2 comes after 1" and "2 is the next number after 1"
            //    means the same thing. 
            //
            DLLOperationBase? each_operation = DLL_GetOpFirstInList();

            while (each_operation != null)
            {
                result_count++;
                each_operation = each_operation.DLL_GetOpNext();
            }
            return result_count;

        }



        public int DLL_CountOpsAfter()
        {
            //
            // Added 11/29/2024  
            //
            int result_count = 0;

            //
            // Please note, "After" and "Next" are synonyms.  
            //    So, "2 comes after 1" and "2 is the next number after 1"
            //    means the same thing. 
            //
            DLLOperationBase? operationNextAfter = DLL_GetOpNext();

            while (operationNextAfter != null)
            {
                result_count++;
                operationNextAfter = operationNextAfter.DLL_GetOpNext();
            }
            return result_count;

        }


        public DLLOperationBase DLL_GetOpFirstInList()
        {
            //
            // Added 4/18/2025
            //
            DLLOperationBase operation_temp1 = this;
            DLLOperationBase? operation_temp2 = null;
            DLLOperationBase operation_output = this;

            while (operation_temp1.DLL_HasOpPrior())
            {
                operation_temp2 = operation_temp1.DLL_GetOpPrior();
                bool bIsPriorNotNull = (operation_temp2 != null);  // For the programmer's
                // edification.   This Boolean will always be true, assuming that
                // function DLL_HasOpPrior() is well-formed. --4/18/2025
                if (operation_temp2 != null) operation_temp1 = operation_temp2;
            }

            operation_output = operation_temp1;

            return operation_output;

        }



        public int DLL_CountOpsBefore()
        {
            //
            // Added 11/29/2024  
            //
            int result_count = 0;

            //
            // Please note, "Before" and "Prior" are synonyms.  
            //    So, "3 comes before 4" and "3 is the number prior to 4"
            //    means the same thing. 
            //
            //---12/03/2024---DLLOperation1D<TControl> tempOperation = DLL_GetOpNext_OfT();
            //---01/04/2025---DLLOperation1D<TControl> operationPriorBefore = DLL_GetOpPrior_OfT();
            DLLOperationBase? operationPriorBefore = DLL_GetOpPrior();

            while (operationPriorBefore != null)
            {
                result_count++;
                //---HARD TO FIND BUG--- = operationPriorBefore.DLL_GetOpNext_OfT();
                // jan4 2025  operationPriorBefore = operationPriorBefore.DLL_GetOpPrior_OfT();
                operationPriorBefore = operationPriorBefore.DLL_GetOpPrior();
            }

            return result_count;

        }




        public int DLL_GetOpIndex_b0()
        {
            //
            // Added 4/17/2025
            //
            return -1 + DLL_GetOpIndex_b1();
        }

        public int DLL_GetOpIndex_b1()
        {
            //
            // Added 4/17/2025
            //
            int resultIndex = 0;
            //var temp = mod_current;
            DLLOperationBase? temp = this;

            while (temp != null)
            {
                resultIndex++;
                temp = temp.DLL_GetOpPrior();
            }
            return resultIndex;

        }



    }

}
