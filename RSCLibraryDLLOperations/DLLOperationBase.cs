using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public void DLL_SetOpPrior(DLLOperationBase par_item)
        {
            //
            // Added 11/23/2024  
            //
            //---mod_opPrior = par_item;
            mod_opPrior_ForUndo = par_item;

        }

        public void DLL_SetOpNext(DLLOperationBase par_item)
        {
            //
            // Added 11/23/2024
            // 
            // 12/02/2024 mod_opNext = par_item;
            mod_opNext_ForRedo = par_item;
        
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


    }

}
