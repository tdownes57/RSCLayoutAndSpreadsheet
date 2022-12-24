using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//dec2022 using System.Windows.Forms;  //Added 12/28/2021 td 
using ciBadgeInterfaces;  //Added 12/28/2021 td


//12-20-2022 namespace MoveAndResizeControls_Monem //.Interfaces
namespace MoveAndResizeControls_Monem_Net70 //.Interfaces
{
    //
    //Added 12/28/2021 td 
    //
    //Jan11 2022 td//public interface IMoveOrResizeFunctionality // Dec28 2021 //InterfaceMoveOrResize
    public interface IMonemMoveOrResizeFunctionality // Dec28 2021 //InterfaceMoveOrResize
    {
        //
        //Added 12/28/2021 td 
        //
        //Jan4 2022 ''void Init(Control par_control, Control par_container, int par_margin, bool pbRepaintAfterResize,
        //Jan10 2022 ''void Init(PictureBox par_pictureBox, Control par_container, int par_margin, bool pbRepaintAfterResize,
        //                          InterfaceMoveEvents par_events, bool pbSetBreakpoint_AfterMove,
        //                          ISaveToModel par_iSave, bool pbRemoveAnyHandlers = false, 
        //                          bool pbHookUpEventHandlers = true, float par_proportionWH = 0);
        //
        //Feb02 2022 ''       void Init_V1(PictureBox par_pictureBox, Control par_container, int par_margin, bool pbRepaintAfterResize,
        //                          InterfaceMoveEvents par_eventsGroupOfCtls,
        //                          InterfaceMoveEvents par_eventsSingleCtl,
        //                          bool pbSetBreakpoint_AfterMove,
        //                          ISaveToModel par_iSave, bool pbRemoveAnyHandlers = false,
        //                          bool pbHookUpEventHandlers = true,
        //                          bool pbResizeViaProportionWH = false,
        //                          float par_proportionWH = 0)
        //
        void Init_V1(PictureBox par_pictureBox, Control par_container, int par_margin, bool pbRepaintAfterResize,
                                  InterfaceMoveEvents par_eventsGroupOfCtls, 
                                  InterfaceMoveEvents par_eventsSingleCtl,
                                  bool pbSetBreakpoint_AfterMove,
                                  ISaveToModel par_iSave, bool pbRemoveAnyHandlers = false,
                                  bool pbHookUpEventHandlers = true, 
                                  bool pbResizeViaProportionWH = false,
                                  float par_proportionWH = 0,
                                  bool pbNotADesignElement = false);

        //Added 1/27/2022 thomas downes
        void Init_V2(PictureBox par_pictureBox, Control par_container, int par_margin, bool pbRepaintAfterResize,
                          InterfaceMoveEvents par_eventsGroupOfCtls,
                          InterfaceMoveEvents par_eventsSingleCtl,
                          bool pbSetBreakpoint_AfterMove,
                          ISaveToModel par_iSave,
                          IRefreshElementImage par_iRefreshImage,
                          IRefreshCardPreview par_iRefreshPreview,
                          bool pbRemoveAnyHandlers = false,
                          bool pbHookUpEventHandlers = true,
                          bool pbResizeViaProportionWH = false,
                          float par_proportionWH = 0);

        //Added 2/02/2022 thomas downes
        void Init_V3(PictureBox par_pictureBox, Control par_container, int par_margin, 
                          InterfaceMoveEvents par_eventsGroupOfCtls,
                          InterfaceMoveEvents par_eventsSingleCtl,
                          bool pbSetBreakpoint_AfterMove,
                          ISaveToModel par_iSave,
                          IRefreshElementImage par_iRefreshImage,
                          IRefreshCardPreview par_iRefreshPreview,
                          ClassStructResizeParams par_structResize,
                          bool pbRemoveAnyHandlers = false,
                          bool pbHookUpEventHandlers = true);

        bool NowInMotion(); //Added 1/10/2022 td

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

        bool RemoveProportionality
        {
            //Added 2/02/2022 thomas downes
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

        // Added 1/4/2022 thomas downes
        void StartMovingOrResizing(Control control, MouseEventArgs e);
        void MoveParentControl(Control par_controlParent, MouseEventArgs e);
        void StopDragOrResizingV1(Control par_control, ISaveToModel par_iSave);

        //Added 1/27/2022 thomas downes
        void StopDragOrResizingV2(Control par_control, ISaveToModel par_iSave,
            IRefreshElementImage par_iRefreshElemImage,
            IRefreshCardPreview par_iRefreshCardPreview);
        //Dec20 2022  IRefreshElementImage par_iRefreshElemImage = null,
        //Dec20 2022      IRefreshCardPreview par_iRefreshCardPreview = null); 
        //June6 2022 bool par_bHeightAdjusted = false);

        //Added 9/01/2022 thomas downes
        void ClickedParentControl(Control par_controlParent, MouseEventArgs e);

        //Added 3/3/2022 thomas downes
        //StructResizeParams ResizeParams
        //{
        //    get;
        //    set;
        //}

        ClassStructResizeParams ResizeParams
        {
            get;
            set;
        }

        //
        //Added 3/13/2022 thomas downes
        //
         List<UserControl> ListOfColumnsToBumpRight 
        {
            get;
            set;
        }

        // Add 4/1/2022 td
        void AddColumnToBumpRight(UserControl par_column);
        
        // Add 4/15/2022 td
        void RemoveColumnToBumpRight(UserControl par_column);


    }
}
