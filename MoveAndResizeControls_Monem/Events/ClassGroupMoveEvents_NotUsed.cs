using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ciBadgeInterfaces; //Added 1/3/2022 thomas d.

namespace MoveAndResizeControls_Monem
{   //
    //Added 1/3/2022 thomas d.
    //
    class ClassGroupMoveEvents_NotUsed : InterfaceMoveEvents
    {
        //Added 1/3/2022 thomas d.
        // 1-12-2022 td//public delegate void DelegateMoveInUnison(int deltaLeft, int deltaTop, int deltaWidth, int deltaHeight);
        public delegate void DelegateMoveInUnison(int deltaLeft, int deltaTop, int deltaWidth, int deltaHeight, bool pbLeadControlLocationWasEdited);
        public delegate void DelegateResizing_Start();
        public delegate void DelegateResizing_EndV1(ISaveToModel par_iSave);  //Suffixed w/ V1 on 1/26/2022
        public delegate void DelegateResizing_EndV2(ISaveToModel par_iSave, 
                                                    IRefreshElementImage par_iRefreshElem, 
                                                    IRefreshCardPreview par_iRefreshCard); //Jan 26 2022
        public delegate void DelegateMoving_End(Control par_control);
        public delegate void DelegateControlIsMoving();

        //''Added 1/3/2022 based on 8/3/2019 code. --thomas downes
        public event DelegateMoveInUnison EventMoveInUnison;
        public event DelegateResizing_Start EventResizing_Start;
        public event DelegateResizing_EndV1 EventResizing_EndV1;
        public event DelegateResizing_EndV2 EventResizing_EndV2;  //Added 1/26/2022 td
        public event DelegateMoving_End EventMoving_End;
        public event DelegateControlIsMoving EventControlIsMoving;

        public ILayoutFunctions LayoutFunctions;  // = null; // As ILayoutFunctions ''Added 9/20/2019 td


        public ClassGroupMoveEvents_NotUsed(ILayoutFunctions par_layoutFun)
        {
            //''
            //''Added 9/20/2019 td  
            //''
            //LayoutFunctions = CType(par_layoutFun, ILayoutFunctions);
            LayoutFunctions = (ILayoutFunctions)par_layoutFun; 

        } // End Sub


        public ClassGroupMoveEvents_NotUsed()
        {
            //Default constructor. ----1/3/2022 td  
        }


        public void Resizing_Initiate()
        {
            //throw new NotImplementedException();

            //---Resizing_Start.Invoke();

            // Calling event delegate to check subscription.
            //     https://www.tutlane.com/tutorial/csharp/csharp-events
            //
            if (EventResizing_Start != null)
            {
                // Raise the event by using () operator
                //     https://www.tutlane.com/tutorial/csharp/csharp-events
                //
                EventResizing_Start();
            }

        }


        public void GroupMove_Change(int DeltaLeft, int DeltaTop, 
                                    int DeltaWidth, int DeltaHeight, 
                                    bool pbLeadControlLocationWasEdited)
        {
            //throw new NotImplementedException();

            //---Resizing_Start.Invoke();

            // Calling event delegate to check subscription.
            //     https://www.tutlane.com/tutorial/csharp/csharp-events
            //
            if (EventMoveInUnison != null)
            {
                // Raise the event by using () operator
                //     https://www.tutlane.com/tutorial/csharp/csharp-events
                //
                //Jan12 2022''EventMoveInUnison(DeltaLeft, DeltaTop, DeltaWidth, DeltaHeight);
                EventMoveInUnison(DeltaLeft, DeltaTop, DeltaWidth, DeltaHeight, 
                    pbLeadControlLocationWasEdited);

            }

        }


        public void ControlBeingMoved(Control par_control)
        {
            //throw new NotImplementedException();

            LayoutFunctions.ControlBeingMoved = par_control;

        }


        public void ControlThatWasClicked(Control par_control)
        {
            //Added 9/01/2022

            LayoutFunctions.ControlThatWasClicked = par_control;

        }


        public void Control_WasClicked(Control par_control)
        {
            //Added 9/01/2022

            LayoutFunctions.ControlThatWasClicked = par_control;

        }


        public void MouseDown(Control par_control)
        {
            //Added 12/24/2022

            LayoutFunctions.ControlThatWasClicked = par_control;

        }


        public void Control_IsMoving()
        {
            //throw new NotImplementedException();

            // Calling event delegate to check subscription.
            //     https://www.tutlane.com/tutorial/csharp/csharp-events
            //
            if (EventControlIsMoving != null)
            {
                // Raise the event by using () operator
                //     https://www.tutlane.com/tutorial/csharp/csharp-events
                //
                EventControlIsMoving();

            }


        }


        public void Moving_Terminate(Control par_control, ISaveToModel par_iSave)
        {
            //throw new NotImplementedException();

            // Calling event delegate to check subscription.
            //     https://www.tutlane.com/tutorial/csharp/csharp-events
            //
            if (EventMoving_End != null)
            {
                // Raise the event by using () operator
                //     https://www.tutlane.com/tutorial/csharp/csharp-events
                //
                EventMoving_End(par_control);   // , par_iSave);
            }

        }




        public void Resizing_TerminateV1(ISaveToModel par_iSave)
        {
            //throw new NotImplementedException();
            // Calling event delegate to check subscription.
            //     https://www.tutlane.com/tutorial/csharp/csharp-events
            //
            if (EventResizing_EndV1 != null)
            {
                // Raise the event by using () operator
                //     https://www.tutlane.com/tutorial/csharp/csharp-events
                //
                EventResizing_EndV1(par_iSave);

            }

        }


        public void Resizing_TerminateV2(ISaveToModel par_iSave, 
                                        IRefreshElementImage par_iRefreshImage,
                                        IRefreshCardPreview par_iRefreshPreview,
                                        bool pbResizedHeight)
        {
            //throw new NotImplementedException();
            //
            // Calling event delegate to check subscription.
            //     https://www.tutlane.com/tutorial/csharp/csharp-events
            //
            if (EventResizing_EndV2 != null)
            {
                // Raise the event by using () operator
                //     https://www.tutlane.com/tutorial/csharp/csharp-events
                //
                //Jan26 2022 td''EventResizing_End(par_iSave);
                EventResizing_EndV2(par_iSave, par_iRefreshImage, par_iRefreshPreview);

            }

        }



    }
}


