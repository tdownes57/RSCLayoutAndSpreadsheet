//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Security;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;  
using ciBadgeInterfaces; //Added 6/20/2024  

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



        public DLLRange(bool par_isSingleItem, TControl par_itemStart,
                          TControl? par_itemEnding, 
                          TControl? par_itemSingle, int par_itemCount)
        {
            _isSingleItem = par_isSingleItem;
            _SingleItemInRange = par_itemSingle;
            _StartingItem = par_itemStart;
            _ItemCount = par_itemCount;

            if (_isSingleItem && (par_itemSingle != null))
            {
                //
                // This is a single-item range.
                //
                _SingleItemInRange = par_itemSingle;
                
                _StartingItem = par_itemSingle;
                _EndingItem = par_itemSingle;

            }
            else if (par_itemEnding != null)
            {
                //
                // This is probably _NOT_ a single-item range.
                //   There is a ending item.
                //
                _EndingItem = par_itemEnding;
                
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
                    if (par_itemCount > 0)
                    {
                        var nextIterativelyByCount = _StartingItem
                            .DLL_GetItemNext_OfT(par_itemCount - 1);
                        bTestMatch = (_EndingItem.Equals(nextIterativelyByCount));
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
                //--Jun30 2024-_EndingItem = _StartingItem.DLL_GetItemNext(itemCount - 1).DLL_UnboxControl();
                _EndingItem = _StartingItem
                    .DLL_GetItemNext_OfT(par_itemCount - 1)
                    .DLL_UnboxControl_OfT();

            }

            //
            // Administrative--Set the Inverse Anchors. 
            //
            _InverseAnchor_Prior = par_itemStart
                .DLL_GetItemPrior_OfT()
                .DLL_UnboxControl_OfT();

            if (par_itemEnding != null)
            {
                _InverseAnchor_After = par_itemEnding
                    .DLL_GetItemNext_OfT()
                    .DLL_UnboxControl_OfT();
            }
            else if (par_itemCount == 1)
            {
                _InverseAnchor_After = par_itemStart
                    .DLL_GetItemNext_OfT()
                    .DLL_UnboxControl_OfT();
            }
            else
            {
                // Unclear what to do.  Stop & think about it.
                System.Diagnostics.Debugger.Break();
            }

            //Added 6/30/2024
            if (_StartingItem == null) _StartingItem = par_itemStart;
            if (_StartingItem == null) _StartingItem = par_itemSingle;
            if (_EndingItem == null) _EndingItem = par_itemStart;
            if (_EndingItem == null) _EndingItem = par_itemSingle;

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

            TControl item = par_start.DLL_GetItemNext_OfT().DLL_UnboxControl_OfT();
            int intResult = 0;

            while (item != null) 
            {
                intResult++;
                if (item.Equals(par_ending)) break;
                item = item.DLL_GetItemNext_OfT().DLL_UnboxControl_OfT();
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


        public Boolean CheckEndpointsAreClean_PriorToInsert()
        {
            //
            // Added 7/11/2024  
            //
            bool bCleanStart = ! _StartingItem.DLL_HasPrior();
            bool bCleanFinish = !_EndingItem.DLL_HasNext();

            bool result_cleanBoth = (bCleanStart && bCleanFinish);
            return result_cleanBoth;

        }



    }
}
