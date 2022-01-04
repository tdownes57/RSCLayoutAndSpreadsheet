using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;  //Added 12/28/2021 td 
using ciBadgeInterfaces;  //Added 12/28/2021 td

namespace MoveAndResizeControls_Monem //.Interfaces
{
    //
    //Added 12/28/2021 td 
    //
    public interface IMoveOrResizeFunctionality // Dec28 2021 //InterfaceMoveOrResize
    {
        //
        //Added 12/28/2021 td 
        //
        //Jan4 2022 ''void Init(Control par_control, Control par_container, int par_margin, bool pbRepaintAfterResize,
        void Init(PictureBox par_pictureBox, Control par_container, int par_margin, bool pbRepaintAfterResize,
                                  InterfaceMoveEvents par_events, bool pbSetBreakpoint_AfterMove,
                                  ISaveToModel par_iSave, bool pbRemoveAnyHandlers = false);

        void Reverse_Init();
        void RemoveEventHandlers();

        bool RemoveAllFunctionality
        {
            get;
            set;
        }


        bool RemoveSizeability
        {
            //Added 12/28/2021 thomas downes
            get;
            set;
        }

        //Great for removing functionality!  
        //  (But potentially depressing, since your app won't work
        //    & you won't know why!)
        //          ----1/3/2022 td 
        void KillAllEvents_Blackhole();

        //
        //Add a Label, or a PictureBox, to be a possible target of a user's Click-and-Drag.
        //   ----1/4/2022 td 
        //
        void AddMoveability_ViaLabel(Label par_label);
        void AddMoveability_ViaPictureBox(PictureBox par_label);


    }
}
