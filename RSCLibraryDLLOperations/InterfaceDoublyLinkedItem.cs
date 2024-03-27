using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//Having trouble here. See "using" above. 3/2024  using System.Windows.Forms;

namespace RSCLibraryDLLOperations
{
    /// <summary>
    /// This is a generically-typed interface.  The non-generic base-interface  
    /// is a subset of methods, naturally those methods which are NOT repeat NOT 
    /// generically-typed.
    /// </summary>
    /// <typeparam name="TypeOfItem">Usually a type of user-control which is repeated many times.</typeparam>
    public interface IDoublyLinkedItem<TypeOfItem> : IDoublyLinkedItem
    {
        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------
        //  The following are generic-type methods. 
        //
        //    (I am moving these to generically-type public interface IDoublyLinkedItem<TypeOfItem>,
        //    versus public interface IDoublyLinkedItem.)
        //
        //    For the NON-generically-typed methods, see the following, declared below this
        //      current interface.
        //
        //               public interface IDoublyLinkedItem
        //
        //    As you can see, this generically-typed interface derives from the non-generic
        //       interface.  (See "...  : IDoublyLinkedItem" above).
        //
        //    ---Thomas C. Downes, 3/12/2024
        //
        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------

        IDoublyLinkedItem<TypeOfItem> DLL_GetItemNext();
        IDoublyLinkedItem<TypeOfItem> DLL_GetItemNext(int param_iterationsOfNext);

        IDoublyLinkedItem<TypeOfItem> DLL_GetItemPrior();
        IDoublyLinkedItem<TypeOfItem> DLL_GetItemPrior(int param_iterationsOfPrior);

        /// <summary>
        /// Gets the underlying control.
        /// </summary>
        /// <returns></returns>
        TypeOfItem DLL_UnboxControl();
        //Having trouble here. See "using" above. 3/2024  Control DLL_UnboxControl();

        void DLL_SetItemNext(IDoublyLinkedItem<TypeOfItem> param);
        void DLL_SetItemPrior(IDoublyLinkedItem<TypeOfItem> param);

        // Added 12/30/2023 
        // ---DIFFICULT AND CONFUSING---
        // By CS-related rules of iteration, by moving ahead
        // a number of jumps equal to the item-count of the range,
        // we get the first post-range item.
        // ---12/30/2023
        /// <summary>
        /// Get item following a range (if the implicit parameter is the first item in a range). Sometimes we need the Item which follows the Range, to prepare for a possible Undo.
        /// </summary>
        /// <param name="param_rangeSize">This is the item-count of the range, or size of the range.</param>
        /// <returns>The first item which follows the range.</returns>
        IDoublyLinkedItem<TypeOfItem> DLL_GetNextItemFollowingRange(int param_rangeSize, bool param_mayBeNull);

    }



    public interface IDoublyLinkedItem
    {
        // Added 11/02/2023 Thomas Downes
        bool Selected { get; set; }

        // Added 11/02/2023 Thomas Downes
        bool DLL_NotAnyNext();
        bool DLL_NotAnyPrior();

        /// <summary>
        /// Is this the end of the list, either the beginning or the endpoint?
        /// </summary>
        /// <returns></returns>
        bool DLL_IsEitherEndpoint();

        /// <summary>
        /// Is there a Next?
        /// </summary>
        /// <returns>Returns a True or False.</returns>
        bool DLL_HasNext();
        /// <summary>
        /// Is there a Next?
        /// </summary>
        /// <returns>Returns a True or False.</returns>
        bool DLL_HasPrior();


        // Whenever a Row or Column is deleted, and saved into a DLL Operation,
        // the outer edges ---MUST BE CLEANED--- of obselete references.
        // ---OTHERWISE, THE DELETE OPERATION CANNOT BE UNDONE & REDONE---.  
        //
        // If a surgeon was removing a section of your spine, so it could be 
        // transplanted into another person, they would probably clean (in some way) 
        // the two(2) exposed ends of the vertebra... would they not?  LOL
        //
        // ---11/07/2023 td
        void DLL_ClearReferencePrior(char par_typeOp);
        void DLL_ClearReferenceNext(char par_typeOp);

        // Added 1/4/2024 td
        string DLL_GetValue(); // Added 1/4/2024 td

        // Added 1/13/2024 thomas downes
        /// <summary>
        /// This provides a counting of all items in the entire list, regardless of the location of this item.
        /// (A count of all items...one(1) for present item, plus prior items, plus next items.)
        /// </summary>
        /// <returns>A count of all items...one(1) for present item, plus prior items, plus next items.</returns>
        int DLL_CountItemsAllInList();
        int DLL_CountItemsPrior();
        //1/13/2024 int DLL_CountItemsNext();

        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------
        //  The following are commented out, because they reference a generic type. 
        //
        //    (I am moving these to generically-type public interface IDoublyLinkedItem<TypeOfItem>,
        //    versus public interface IDoublyLinkedItem.)
        //
        //    For these commented methods, See the following, declared above.
        //
        //               public interface IDoublyLinkedItem<TypeOfItem>
        //
        //    ---Thomas C. Downes, 3/12/2024
        //
        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------

        //IDoublyLinkedItem<TypeOfItem> DLL_GetItemNext();
        //IDoublyLinkedItem<TypeOfItem> DLL_GetItemNext(int param_iterationsOfNext);

        //IDoublyLinkedItem<TypeOfItem> DLL_GetItemPrior();
        //IDoublyLinkedItem<TypeOfItem> DLL_GetItemPrior(int param_iterationsOfPrior);

        ///// <summary>
        ///// Gets the underlying control.
        ///// </summary>
        ///// <returns></returns>
        //TypeOfItem DLL_UnboxControl();
        ////Having trouble here. See "using" above. 3/2024  Control DLL_UnboxControl();

        //void DLL_SetItemNext(IDoublyLinkedItem<TypeOfItem> param);
        //void DLL_SetItemPrior(IDoublyLinkedItem<TypeOfItem> param);

        // Added 12/30/2023 
        // ---DIFFICULT AND CONFUSING---
        // By CS-related rules of iteration, by moving ahead
        // a number of jumps equal to the item-count of the range,
        // we get the first post-range item.
        // ---12/30/2023
        /// <summary>
        /// Get item following a range (if the implicit parameter is the first item in a range). Sometimes we need the Item which follows the Range, to prepare for a possible Undo.
        /// </summary>
        /// <param name="param_rangeSize">This is the item-count of the range, or size of the range.</param>
        /// <returns>The first item which follows the range.</returns>
        //IDoublyLinkedItem<TypeOfItem> DLL_GetNextItemFollowingRange(int param_rangeSize, bool param_mayBeNull);

    }


    public interface IDoublyLinkedItem_NOTINUSE
    {
        //
        // Added 3/12/2024 Thomas Downes
        //




    }


}
