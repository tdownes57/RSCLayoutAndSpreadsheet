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
        //
        // Added 4/20/2024 Thomas Downes
        //
        public readonly bool _isSingleItem;
        public readonly TControl? _SingleItemInRange;
        public readonly TControl _StartingItem;
        public readonly TControl _EndingItem;
        public readonly int _ItemCount;

        // Added 4/20/2024 thomas downes
        public readonly TControl? _InverseAnchor_Prior;
        public readonly TControl? _InverseAnchor_After;



        public DLLRange(bool isSingleItem, TControl? itemSingle, TControl itemStart,
                          TControl? itemEnding, int itemCount)
        {
            _isSingleItem = isSingleItem;
            _SingleItemInRange = itemSingle;
            _StartingItem = itemStart;
            _ItemCount = itemCount;

            if (_isSingleItem && (itemSingle != null))
            {
                //
                // This is a single-item range.
                //
                _SingleItemInRange = itemSingle;
                _StartingItem = itemSingle;
                _EndingItem = itemSingle;

            }
            else if (itemEnding != null)
            {
                //
                // This is probably _NOT_ a single-item range.
                //   There is a ending item.
                //
                _EndingItem = itemEnding;
                
                //Administration.  Set _itemCount.
                if (_ItemCount <= 0)
                {
                    //_itemCount = _itemStart.DLL_CountItemsAllInList(); // Won't work.  This
                    //     is a range, i.e. a subset of a list, not an entire list. 
                    //_itemCount = (1 + _itemEnding.DLL_Subtract(_itemStart));
                    _ItemCount = (1 + DLL_Distance(_StartingItem, _EndingItem));

                }
                else if (Testing.AreWeTesting)
                {
                    bool bTestMatch; 
                    if (itemCount > 0)
                    {
                        bTestMatch = (_EndingItem.Equals(_StartingItem.DLL_GetItemNext(itemCount - 1)));
                        if (!bTestMatch) System.Diagnostics.Debugger.Break();
                    }
                }

            }
            else if (_StartingItem != null)
            {
                //
                // This is probably _NOT_ a single-item range.
                //   There is a distinct beginning and an end.
                //
                _EndingItem = _StartingItem.DLL_GetItemNext(itemCount - 1).DLL_UnboxControl();
            }

            //
            // Administrative--Set the Inverse Anchors. 
            //
            _InverseAnchor_Prior = _StartingItem.DLL_GetItemPrior().DLL_UnboxControl();
            _InverseAnchor_After = _EndingItem.DLL_GetItemNext().DLL_UnboxControl();

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
