using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//----------------------------------------------------------------
// ---           THIS IS CODE FROM MICROSOFT                   ---
// ---     (namespace System.Collections.Generic)              ---  
//----------------------------------------------------------------

//namespace System.Collections.Generic
namespace RSCLibraryDLLOperations // System.Collections.Generic
{
    //----------------------------------------------------------------
    // ---           THIS IS CODE FROM MICROSOFT                   ---
    // ---     (namespace System.Collections.Generic)              ---  
    //----------------------------------------------------------------
    //
    // Summary:
    //     Represents a collection of objects that can be individually accessed by index.
    //
    //
    // Type parameters:
    //   T:
    //     The type of elements in the list.
    //
    //[DefaultMember("Item")]
    public interface IList<T> : ICollection<T>, IEnumerable<T>, IEnumerable
    {
        //----------------------------------------------------------------
        // ---           THIS IS CODE FROM MICROSOFT                   ---
        // ---     (namespace System.Collections.Generic)              ---  
        //----------------------------------------------------------------
        //
        // Summary:
        //     Gets or sets the element at the specified index.
        //
        // Parameters:
        //   index:
        //     The zero-based index of the element to get or set.
        //
        // Returns:
        //     The element at the specified index.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is not a valid index in the System.Collections.Generic.IList`1.
        //
        //   T:System.NotSupportedException:
        //     The property is set and the System.Collections.Generic.IList`1 is read-only.
        T this[int index] { get; set; }


        //
        // Summary:
        //     Determines the index of a specific item in the System.Collections.Generic.IList`1.
        //
        //
        // Parameters:
        //   item:
        //     The object to locate in the System.Collections.Generic.IList`1.
        //
        // Returns:
        //     The index of item if found in the list; otherwise, -1.
        int IndexOf(T item);


        //----------------------------------------------------------------
        // ---           THIS IS CODE FROM MICROSOFT                   ---
        // ---     (namespace System.Collections.Generic)              ---  
        //----------------------------------------------------------------
        //
        // Summary:
        //     Inserts an item to the System.Collections.Generic.IList`1 at the specified index.
        //
        //
        // Parameters:
        //   index:
        //     The zero-based index at which item should be inserted.
        //
        //   item:
        //     The object to insert into the System.Collections.Generic.IList`1.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is not a valid index in the System.Collections.Generic.IList`1.
        //
        //   T:System.NotSupportedException:
        //     The System.Collections.Generic.IList`1 is read-only.
        //
        void Insert(int index, T item);


        //----------------------------------------------------------------
        // ---           THIS IS CODE FROM MICROSOFT                   ---
        // ---     (namespace System.Collections.Generic)              ---  
        //----------------------------------------------------------------
        //
        // Summary:
        //     Removes the System.Collections.Generic.IList`1 item at the specified index.
        //
        // Parameters:
        //   index:
        //     The zero-based index of the item to remove.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is not a valid index in the System.Collections.Generic.IList`1.
        //
        //   T:System.NotSupportedException:
        //     The System.Collections.Generic.IList`1 is read-only.
        //
        void RemoveAt(int index);


    }

}
