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
        Forward,
        Backward,
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
        public bool IsShiftingToLeft;  // "Swapping" positions with a preceding adjacent item, especially if the range is a single item.
        public bool IsShiftingToRight;  // "Swapping" positions with a succeeding adjacent item, especially if the range is a single item.
        public int HowManyItemsIncremental;  // How many items are swapped out, either preceding or succeeding. 

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
}
