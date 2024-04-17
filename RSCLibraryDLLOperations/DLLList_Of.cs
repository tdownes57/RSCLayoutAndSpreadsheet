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
        public readonly TControl? _itemStart;
        public readonly TControl? _itemEnding;
        public readonly int _itemCount;
        public readonly bool _isEmpty;

        public DLLList()
        {
            _itemCount = 0;
            _isEmpty = true;
            //_itemStart = null;
            //_itemEnding = null;
        }

        public DLLList(TControl itemStart,
                       TControl itemEnding, int itemCount)
        {
            _itemStart = itemStart;
            _itemEnding = itemEnding;
            _itemCount = itemCount;
            _isEmpty = false;
        }


        public bool Contains(TControl par_item)
        {
            if (_isEmpty) return true;
            if (par_item.Equals(_itemStart)) return true;
            if (par_item.Equals(_itemEnding)) return true;

            TControl? itemLocal = _itemStart;
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
