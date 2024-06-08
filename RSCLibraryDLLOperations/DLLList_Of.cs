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
        //     We are aware that System.Collections.Generic contains:  
        //
        //           LinkedList<T>  
        //
        //     This is an "inhouse" linked-list collection. 
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


        public TControl Get_ItemAtIndex(int par_index)
        {
            //
            // Added 4/30/2024 
            //
            TControl result = _itemStart;

            if (_itemStart != null)
            {
                result = _itemStart.DLL_GetItemNext(par_index).DLL_UnboxControl();
            }

            if (result == null)
            {
                return default(TControl);
            }
            else return result; 

        }


        public void DLL_InsertRangeBefore(DLLRange<TControl> par_range, 
                                DLLAnchor<TControl> par_anchor, 
                                bool par_isChangeOfEndpoint)
        {




        }


        public void DLL_InsertRangeIntoEmptyList(DLLRange<TControl> par_range)
        {
            //
            // Added 6/7/2024 thomas downes
            //
            _itemCount = par_range._ItemCount;
            if (0 == _itemCount) return; 

            _itemStart = par_range._StartingItem;
            //_itemEnding = _itemStart.DLL_GetItemNext(-1 + _itemCount).DLL_UnboxControl();
            _itemEnding = par_range._EndingItem;

        }










    }
}
