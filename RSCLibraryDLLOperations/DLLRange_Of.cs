using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    internal class DLLRange<TControl> where TControl : IDoublyLinkedItem<TControl>
    {
        public readonly bool _isSingleItem;
        public readonly TControl? _itemSingle;
        public readonly TControl? _itemStart;
        public readonly TControl? _itemEnding;
        public readonly int _itemCount;

        public DLLRange(bool isSingleItem, TControl? itemSingle, TControl? itemStart, 
                          TControl? itemEnding, int itemCount)
        {
            _isSingleItem = isSingleItem;
            _itemSingle = itemSingle;
            _itemStart = itemStart;
            _itemEnding = itemEnding;
            _itemCount = itemCount;
        }

    }
}
