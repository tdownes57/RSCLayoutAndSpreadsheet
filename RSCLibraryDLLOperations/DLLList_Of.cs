using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    internal class DLLList<TControl> where TControl : IDoublyLinkedItem<TControl>
    {
        //
        // Added 4/17/2024  
        //
        public TControl _itemStart;
        public TControl _itemEnding;
        public int _itemCount;
        public bool _isEmpty_OrTreatAsEmpty; // This means that some user-initiated operation
           // has removed all remaining items from the list (likely, per user's intention).  
           // (This will relieve us from the programmatic burden of trying to Nullify
           //   the _itemStart object. The C# compiler might not like that.) 

        //public DLLList()
        //{
        //    _itemCount = 0;
        //    _isEmpty_OrTreatAsEmpty = true;
        //    //_itemStart = null;
        //    //_itemEnding = null;
        //}

        public DLLList(TControl itemStart,
                       TControl itemEnding, int itemCount)
        {
            _itemStart = itemStart;
            _itemEnding = itemEnding;
            _itemCount = itemCount;
            _isEmpty_OrTreatAsEmpty = false;

            //Testing
            if (Testing.AreWeTesting)
            {
                if ((_itemCount == 1) != (itemStart.Equals(itemEnding)))
                {
                    System.Diagnostics.Debugger.Break();
                }
            }

        }


        public bool Contains(TControl par_item)
        {
            //
            // Check to see if the list contains the item.
            //
            if (_isEmpty_OrTreatAsEmpty) return false;
            
            if (par_item.Equals(_itemStart)) return true;
            if (par_item.Equals(_itemEnding)) return true;

            TControl itemLocal = _itemStart;
            bool boolMatches = false;
            while (!boolMatches && itemLocal != null)
            {
                if (par_item.Equals(itemLocal)) boolMatches = true;
                else itemLocal = itemLocal.DLL_GetItemNext().DLL_UnboxControl();
            }
            return boolMatches;
        
        }



    }
}
