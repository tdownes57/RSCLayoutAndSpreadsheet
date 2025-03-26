using ciBadgeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    public class DLLCollectionOfLists<TControl>
        where TControl : class, IDoublyLinkedItem<TControl>
    {
        //
        //
        //

        public DLLList<TControl>[] ArrayOfLists;
        public int NumberOfLists;

        private int _numberOfListsExpected;
        private int _numberOfListsLoaded = 0;

        public DLLCollectionOfLists()
        {

            ArrayOfLists = new DLLList<TControl>[0];

        }


        public DLLCollectionOfLists(DLLList<TControl>[] par_arrayOfLists)
        {

            ArrayOfLists = par_arrayOfLists;

        }


        public DLLCollectionOfLists(int par_numberOfLists)
        {

            ArrayOfLists = new DLLList<TControl>[par_numberOfLists];

        }


        public void AddList(DLLList<TControl> par_listToAdd)
        {
            //
            // 
            //
            bool bAlreadyFull;
            bAlreadyFull = (_numberOfListsLoaded == _numberOfListsExpected);

            if (bAlreadyFull)
            {
                System.Diagnostics.Debugger.Break();
                throw new Exception("Already full of lists");
            }

            ArrayOfLists[_numberOfListsLoaded++] = par_listToAdd;

            bAlreadyFull = (_numberOfListsLoaded >= _numberOfListsExpected);
            if (bAlreadyFull) { NumberOfLists = _numberOfListsExpected; }


        }




    }
}
