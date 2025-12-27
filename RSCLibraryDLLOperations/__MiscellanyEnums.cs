using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    //
    // Module:  __MiscellanyEnums.cs
    //
    public enum EnumSortTypes
    {
        //  Added 12/20/2024 
        Undetermined,
        ByValues_Forward,  //Apr2025 Forward,
        ByValues_Backward, //Apr2025 Backward
        ByArrayOfItemIndices, // Added April 2025 td
        UndoOfSortForward,
        UndoOfSortBackward

    }

    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum
    [Flags]
    public enum Days
    {
        //
        // Enumeration types as bit flags
        //    If you want an enumeration type to represent a combination of choices, define enum members
        //    for those choices such that an individual choice is a bit field.That is, the associated
        //    values of those enum members should be the powers of two.Then, you can use the bitwise
        //    logical operators | or & to combine choices or intersect combinations of choices,
        //    respectively.To indicate that an enumeration type declares bit fields, apply the Flags
        //    attribute to it. As the following example shows, you can also include some typical
        //    combinations in the definition of an enumeration type.
        //
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum
        //
                None = 0b_0000_0000,  // 0
        Monday = 0b_0000_0001,  // 1
        Tuesday = 0b_0000_0010,  // 2
        Wednesday = 0b_0000_0100,  // 4
        Thursday = 0b_0000_1000,  // 8
        Friday = 0b_0001_0000,  // 16
        Saturday = 0b_0010_0000,  // 32
        Sunday = 0b_0100_0000,  // 64
        Weekend = Saturday | Sunday

    }

    public struct StructureTypeOfMove // Added 12/11/2024 thomas c. downes
    {
        //
        // Added 12/11/2024
        // Moved on 12/20/2024 to module __MiscellanyEnums.cs
        // 
        public bool IsMoveType;  // = false;
        public bool IsMoveToAnchor;  // = true;
        public bool IsMoveIncrementalShift;  // "Swapping" positions with an adjacent item, especially if the range is a single item.
        public bool IsMoveRotation; // "Rotating" positions of all items in the list, either left or right.12/25/2025

        public bool IsShiftingToLeft;  // "Swapping" positions with a preceding adjacent item, especially if the range is a single item.
        public bool IsShiftingToRight;  // "Swapping" positions with a succeeding adjacent item, especially if the range is a single item.
        public int HowManyItemsIncremental;  // How many items are swapped out, either preceding or succeeding. 
        public bool IsRotationLeft;  // The very first item is moved to the very last position.  Added 12/24/2025 
        public bool IsRotationRight; // The very first item is moved to the very last position.  Added 12/24/2025  

        public StructureTypeOfMove()
        {
            //
            // It is likely that the Operations Manager will "know" that the Operation is a Move 
            //   operation, so we have IsMoveType equal to True by default.  ----12/11/2024
            //
            // Added 12/11/2024 thomas c. downes
            IsMoveType = true;
            IsMoveToAnchor = true;
            IsMoveIncrementalShift = false;
            HowManyItemsIncremental = 0;
        }

        public StructureTypeOfMove(bool par_IsForMove)
        {
            //
            // It is likely that the Operations Manager will "know" that the Operation is a Move 
            //   operation, so we have IsMoveType equal to True by default.  ----12/11/2024
            //
            // Added 12/11/2024 thomas c. downes
            IsMoveType = par_IsForMove;
            IsMoveToAnchor = par_IsForMove;
            IsMoveIncrementalShift = false;
            HowManyItemsIncremental = 0;
        }


    }


    public class DLL_RangeQueue_NotInUse<TControl> 
        where TControl: class, IDoublyLinkedItem<TControl>
    {
        //Private Class DLL_RangeQueue
        //    ''
        //    ''Added 1/4/2024 thomas downes
        //    ''
        //    Public Count As Integer
        //    Private mod_firstItem As IDoublyLinkedItem
        public int Count;
        private TControl mod_firstItem; // IDoublyLinkedItem mod_firstItem;

        public DLL_RangeQueue_NotInUse(TControl par_first, int par_count) // (IDoublyLinkedItem par_first, int par_count)
        {
            //    Public Sub New(par_first As IDoublyLinkedItem, par_count As Integer)
            //        mod_firstItem = par_first
            //        Count = par_count
            //    End Sub

            mod_firstItem = par_first;
            this.Count = par_count;

        }

        public TControl Peek() //''IDoublyLinkedItem Peek()
        {
            //    Public Function Peek() As IDoublyLinkedItem
            //        Return mod_firstItem
            //    End Function
            return mod_firstItem;
        }

        public void Dequeue()
        {
            //    Public Sub Dequeue()
            //
            //        If(Count = 0) Then
            //            ''This function should NOT have been called at all.
            //            Debugger.Break()
            //        End If ''ENd of ""If(Count = 0) Then""

            if (this.Count == 0) System.Diagnostics.Debugger.Break();

            //        ''mod_firstItem = mod_firstItem.DLL_GetItemNext
            //        Count -= 1 ''Decrease the count
            this.Count -= 1; // Decrease the count. 

            //
            //        ''Added 1/08/2024 thomas downes
            //        If(Count = 0) Then
            //            mod_firstItem = Nothing
            //        Else
            //            mod_firstItem = mod_firstItem.DLL_GetItemNext
            //        End If ''End of ""If(Count = 0) Then...Else..."
            if (Count == 0)
            {
                mod_firstItem = null; // Nothing;
            }
            else
            {
                mod_firstItem = mod_firstItem.DLL_GetItemNext_OfT();
            }

            //
            //    End Sub ''End of ""Public Sub Dequeue()""
        }

        // End Class ''End of ""Private Class DLL_RangeQueue""
    }  // End Class ''End of ""public class DLL_RangeQueue""



}
