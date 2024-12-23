using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    public class DLLRangeQueue<TControl>
        where TControl : class, IDoublyLinkedItem<TControl>
    {
        //Private Class DLL_RangeQueue
        //    ''
        //    ''Added 1/4/2024 thomas downes
        //    ''
        //    Public Count As Integer
        //    Private mod_firstItem As IDoublyLinkedItem
        public int Count;
        private TControl mod_firstItem; // IDoublyLinkedItem mod_firstItem;

        public DLLRangeQueue(TControl par_first, int par_count) // (IDoublyLinkedItem par_first, int par_count)
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


    }

}