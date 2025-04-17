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
            return mod_opNext_ForRedo;

        }


        public bool DLL_HasOpPrior()
        {
            //
            // Added 11/23/2024  
            //
            //---return mod_opPrior != null; // = par_item;
            return mod_opPrior_ForUndo != null; // = par_item;

        }


        public bool DLL_HasOpNext()
        {
            //
            // Added 11/23/2024  
            //
            //---return mod_opNext != null;
            return mod_opNext_ForRedo != null;

        }


        public void DLL_ClearOpPrior()
        {
            //
            // Added 01/04/2025  
            //
            mod_opPrior_ForUndo = null; // = par_item;

        }


        public void DLL_ClearOpNext()
        {
            //
            // Added 01/04/2025  
            //
            mod_opNext_ForRedo = null;

        }


        public bool DLL_MissingOpPrior()
        {
            //
            // Added 11/23/2024  
            //
            //---return mod_opPrior == null; // = par_item;
            return mod_opPrior_ForUndo == null; // = par_item;

        }


        public bool DLL_MissingOpNext()
        {
            //
            // Added 11/23/2024  
            //
            //--return mod_opNext == null;
            return mod_opNext_ForRedo == null;

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
