using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    internal class DLLRange<TControl> where TControl : IDoublyLinkedItem<TControl>
    {
        public readonly bool _isSingleItem;
        public readonly TControl? _itemSingle;
        public readonly TControl _itemStart;
        public readonly TControl? _itemEnding;
        public readonly int _itemCount;

        public DLLRange(bool isSingleItem, TControl? itemSingle, TControl itemStart, 
                          TControl? itemEnding, int itemCount)
        {
            _isSingleItem = isSingleItem;
            _itemSingle = itemSingle;
            _itemStart = itemStart;
            _itemCount = itemCount;

            if (itemEnding != null)
            {
                _itemEnding = itemEnding;
                
                //Administration.  Set _itemCount.
                if (_itemCount <= 0)
                {
                    //_itemCount = _itemStart.DLL_CountItemsAllInList(); // Won't work.  This
                    //     is a range, i.e. a subset of a list, not an entire list. 
                    //_itemCount = (1 + _itemEnding.DLL_Subtract(_itemStart));
                    _itemCount = (1 + DLL_Distance(_itemStart, _itemEnding));

                }
                else if (Testing.AreWeTesting)
                {
                    bool bTestMatch; 
                    if (itemCount > 0)
                    {
                        bTestMatch = (_itemEnding.Equals(_itemStart.DLL_GetItemNext(itemCount - 1)));
                        if (!bTestMatch) System.Diagnostics.Debugger.Break();
                    }
                }

            }
            else
            {
                _itemEnding = _itemStart.DLL_GetItemNext(itemCount - 1).DLL_UnboxControl();
            }

        }


        private int DLL_Distance(TControl par_start, TControl par_ending)
        {
            //
            // Added 4/17/2024  
            //
            if (par_start.Equals(par_ending)) return 0;
            if (par_ending == null) System.Diagnostics.Debugger.Break();
            if (par_start == null)
            {
                System.Diagnostics.Debugger.Break();
                throw new InvalidOperationException();
            }

            TControl item = par_start.DLL_GetItemNext().DLL_UnboxControl();
            int intResult = 0;

            while (item != null) 
            {
                intResult++;
                if (item.Equals(par_ending)) break;
                item = item.DLL_GetItemNext().DLL_UnboxControl();
            }

            //
            // Output the result.
            //
            if (item != null) return intResult;
            else
            {
                System.Diagnostics.Debugger.Break();
                throw new InvalidOperationException("Loop was unsuccessful.");
            }

        }


    }
}
