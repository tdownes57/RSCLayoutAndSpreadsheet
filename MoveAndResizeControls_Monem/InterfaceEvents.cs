//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms; //added 8/4/2019 td
using ciBadgeInterfaces;  //Added 12/17/2021 td

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

        // 8-5-2019 td //void GroupMove(int DeltaLeft, int DeltaTop, int DeltaWidth, int DeltaHeight);
        void GroupMove_Change(int DeltaLeft, int DeltaTop, int DeltaWidth, int DeltaHeight);

        //
        //Added 8-4-2019 thomas downes
        //
        void ControlBeingMoved(Control par_control);

        //
        //Added 8-5-2019 thomas downes
        //
        void Resizing_Initiate();
        void Resizing_Terminate();

        // Dec17 2021 td//void Moving_Terminate(Control par_control); //Modified 11/29/2021 //Added 9/13/2019 td 
        void Moving_Terminate(Control par_control, ISaveToModel par_iSave); //Modified 12/17/2021 //Added 9/13/2019 td 

        //
        //Added 12-6-2021 thomas downes
        //
        void Control_IsMoving();

    }
}
