using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndResizeControls_Monem
{
    public interface InterfaceEvents
    {
        //
        // Added 8/3/2019 thomas downes. 
        //
        //bool AreGroupOfElements;   //Added 8/2/2019 td  
        //void ActivateGroupMoves(); //Added 8/3/2019 td 

        //public delegate void GroupControlsMoved(int DeltaLeft, int DeltaTop, int DeltaWidth, int DeltaHeight);  //Added 8/2/2019 td
        //public event GroupControlsMoved GroupMove;  //Added 8/2/2019 td

        void GroupMove(int DeltaLeft, int DeltaTop, int DeltaWidth, int DeltaHeight); 


    }
}
