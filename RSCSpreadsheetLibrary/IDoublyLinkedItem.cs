using System;
using System.Collections.Generic;
using System.Windows.Forms; 
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Collections.Specialized.BitVector32;

namespace RSCSpreadsheetLibrary
{
    public interface IDoublyLinkedItem
    {

        //''
        //''Added 12/19/2023 & 11/02/2023 Thomas Downes
        //''
        //Public Interface IDoublyLinkedItem
        //''
        //''Added 11/02/2023 Thomas Downes
        //''
        bool DLL_NotAnyNext(); //Function As Boolean
        bool DLL_NotAnyPrior(); //Function As Boolean

        ///<summary>
        ///Is there a Next?
        ///</summary>
        ///<returns>Returns a True or False.</returns>
        bool DLL_HasNext(); // Function As Boolean


        /// <summary>
        /// Is there a Next?
        /// </summary>
        /// <returns>Returns a True or False.</returns>
        bool DLL_HasPrior(); // Function As Boolean

        IDoublyLinkedItem DLL_GetItemNext(); // Function As IDoublyLinkedItem
        IDoublyLinkedItem DLL_GetItemNext(int param_iterationsOfNext); // Function As IDoublyLinkedItem

        IDoublyLinkedItem DLL_GetItemPrior();  // Function As IDoublyLinkedItem
        IDoublyLinkedItem DLL_GetItemPrior(int param_iterationsOfPrior); // Function As IDoublyLinkedItem

        /// <summary>
        /// Gets the underlying control.
        /// </summary>
        /// <returns></returns>
        Control DLL_UnboxControl(); // Function As Windows.Forms.Control

        void DLL_SetItemNext(IDoublyLinkedItem paramItem); // As IDoublyLinkedItem) // Sub 
        void DLL_SetItemPrior(IDoublyLinkedItem paramItem); // As IDoublyLinkedItem) // Sub

        //''
        //'' Whenever a Row or Column is deleted, and saved into a DLL Operation,
        //''   the outer edges ---MUST BE CLEANED--- of obselete references.
        //''   ---OTHERWISE, THE DELETE OPERATION CANNOT BE UNDONE & REDONE---.  
        //''
        //'' If a surgeon was removing a section of your spine, so it could be 
        //''   transplanted into aonother person, they would probably clean(in some way)
        //''   the two(2) exposed ends of the vertebra...would they not? LOL
        //''
        //''   ---11/07/2023 td
        //''
        void DLL_ClearReferencePrior(char par_typeOp); // As Char); // Sub  
        void DLL_ClearReferenceNext(char par_typeOp); // As Char); // Sub 

        // End Interface

    }
}

