using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ciBadgeInterfaces;  // Dec17 2021

/***
    ''
    ''   by Seyyed Hamed Monem
    ''     (modified by Thomas Downes) 
    ''
    '' https://www.codeproject.com/tips/709121/move-and-resize-controls-on-a-form-at-runtime-with 
    ''
    ''    Move And Resize Controls on a Form at Runtime(With Mouse)
    ''
    ''seyyed hamed monem
    ''
    ''Rate this :  
    ''
    ''
    ''4.97 (47 votes) 
    ''
    ''13 Jan 2014
    ''CPOL
    ''Move And resize controls on a form at runtime (with mouse)
    ''
    ''   https://www.codeproject.com/tips/709121/move-and-resize-controls-on-a-form-at-runtime-with 
    ''
    ''   https://www.codeproject.com/info/cpol10.aspx
    ''
***/

namespace MoveAndResizeControls_Monem //---9/9/2019 td---namespace ControlManager
{
    public class ControlResizeProportionally_TD : IMoveOrResizeFunctionality  // InterfaceMoveOrResize
    {
        //
        //  internal class ControlResizeProportionally_TD
        //
        //
        //  Class primarily authored by Seyyed Hamed Monem 
        //       https://www.codeproject.com/tips/709121/move-and-resize-controls-on-a-form-at-runtime-with 
        //       https://www.codeproject.com/info/cpol10.aspx
        //  This class was modified in August 2019 by Thomas C. Downes
        //
        //Moved below. 12/28/2021 //private static bool MouseMove_DontAskAgain = false; // Added 12/2/2021 td
        //Moved below. 12/28/2021 //private static bool MouseMove_Container = false;    // Added 12/2/2021 td

        // Dec28 2021 //public bool RemoveAllFunctionality = false; //Added 12/28/2021 td
        public bool RemoveAllFunctionality // = false;  //Added 12/28/2021 td//
        {
            get;
            set;
        }

        public bool RemoveSizeability // = false;  //Added 12/28/2021 td//
        {
            get;
            set;
        }


        private bool _moving;
        private bool _repaintAfterResize;  // Added 7/31/2019 td  
        /// </summary>
        /// 
        private Point _cursorPoint_StartOfDrag; //Suffixed 12/29/2021 thomas downes
        private Point _cursorPoint_LastRefresh;  //Added 12/29/2021 thomas downes
        private Point _cursorPoint_MoveControl;  //Added 12/29/2021 thomas downes

        private bool _moveIsInterNal;
        private bool _resizing;
        private Size _currentControlStartSize;

        //Debugging information. ----12/29/2021 thomas downes
        private int _indexOfDebugArray = 0;
        private const int _c_indexLengthOfDebugArray = 20;
        private string[] _arrayDebuggingInfo = new string[_c_indexLengthOfDebugArray];
        private double _countTotalCalls = 0;

        //Added 7/18/2019 thomas downes
        //
        private int _margin; //Added 7/18/2019 thomas downes

        //Added 10/9/2019 thomas downes
        //
        private decimal _proportionWH; //Added 10/9/2019 thomas downes
        internal InterfaceMoveEvents mod_events; //Added 10/9/2019 thomas downes

        internal bool MouseIsInLeftEdge { get; set; }
        internal bool MouseIsInRightEdge { get; set; }
        internal bool MouseIsInTopEdge { get; set; }
        internal bool MouseIsInBottomEdge { get; set; }
        internal bool SetBreakpoint_AfterMove { get; set; } //Added 9/13/2019 td 


        internal enum MoveOrResize
        {
            Move,
            Resize,
            MoveAndResize
        }

        private Control _controlCurrent; // Added 12/02/2021 td
        // Jan4 2022 //private Control _controlPictureBox;  // = par_controlPictureB;
        private PictureBox _controlPictureBox1;  // = par_controlPictureB;
        private PictureBox _controlPictureBox2;  // Added 1/4/2022 td
        private Control _controlMoveableElement; // = par_containerElement;
        private ISaveToModel _iSaveToModel; //Added 12-17-2021
        private Label _labelIfNeeded;  //Added 1/04/2022 thomas d.

        internal MoveOrResize WorkType { get; set; }

        private static bool MouseMove_DontAskAgain = false; // Added 12/2/2021 td
        private static bool MouseMove_Container = false;    // Added 12/2/2021 td

        public void Init_NotInUse(Control par_control, int par_margin, bool pbRepaintAfterResize,
                                InterfaceMoveEvents par_events, bool pbSetBreakpoint_AfterMove,
                                ISaveToModel par_iSave)
        {
            //  Added a new parameter, par_bRepaintAfterResize.   (Needed to apply 
            //     the preferred background color.)   ----7/31/2019 td
            //
            // 7-31-2019 td ----public  void Init(Control control, int par_margin)
            //
            //Init(control, control);

            // 7-31-2019 td----Init(control, control, par_margin

            // 9-13-2019 td----Init(control, control, par_margin, pbRepaintAfterResize);

            Control obj_container = par_control; //Added 10/9/2019 td;;

            // Jan4 2022''Init(par_control, obj_container, par_margin, pbRepaintAfterResize,
            //    par_events, pbSetBreakpoint_AfterMove, par_iSave);
            Init(null, obj_container, par_margin, pbRepaintAfterResize,
                par_events, pbSetBreakpoint_AfterMove, par_iSave);

        }


        public void Init(PictureBox par_ctlPictureBox, Control par_container, int par_margin, bool pbRepaintAfterResize,
                                  InterfaceMoveEvents par_events, bool pbSetBreakpoint_AfterMove,
                                  ISaveToModel par_iSave, bool pbRemoveAnyHandlers = false)
        {
            //  Added a new parameter, par_bRepaintAfterResize.   (Needed to apply 
            //     the preferred background color.)   ----7/31/2019 td
            //
            // 7-31-2019 td--public  void Init(Control control, Control container, int par_margin)
            //
            //
            //   internal  void Init(Control control, Control container)
            //
            bool bControlIsStaticText = false; // par_ctlPictureBox.Name.Contains("Text") || par_container.Name.Contains("Text") ||
            //    par_ctlPictureBox.Name.Contains("Static") || par_container.Name.Contains("Static");
            if (par_ctlPictureBox != null) //Added 1/4/2022 td
            {
                bControlIsStaticText = par_ctlPictureBox.Name.Contains("Text") || par_container.Name.Contains("Text") ||
                    par_ctlPictureBox.Name.Contains("Static") || par_container.Name.Contains("Static");
            }
            else
            {
                //Added 1/4/2022 td
                bControlIsStaticText = par_container.Name.Contains("Text") ||
                    par_container.Name.Contains("Static");
            }

            if (bControlIsStaticText) System.Diagnostics.Debugger.Break();


            _iSaveToModel = par_iSave;  // Dec17 2021 
            _moving = false;
            _repaintAfterResize = pbRepaintAfterResize; //Added 7/31/2019 td 
            _resizing = false;
            _moveIsInterNal = false;
            _cursorPoint_StartOfDrag = Point.Empty;

            //
            //Added 7/18/2019 thomas downes 
            //
            _margin = par_margin;

            //
            //Added 10/09/2019 thomas downes 
            //
            _proportionWH = (decimal)par_container.Width /
                            (decimal)par_container.Height;

            mod_events = par_events;  // 10/09/2019 thomas downes   

            MouseIsInLeftEdge = false;
            MouseIsInLeftEdge = false;
            MouseIsInRightEdge = false;
            MouseIsInTopEdge = false;
            MouseIsInBottomEdge = false;
            WorkType = MoveOrResize.MoveAndResize;

            //Added 12/2/2021 thomas downes 
            _controlCurrent = par_ctlPictureBox;
            _controlMoveableElement = par_container;
            _controlPictureBox1 = par_ctlPictureBox;

            //
            //Encapsulated 1/4/2022 td
            //
            if (par_ctlPictureBox != null)
            {
                HookUpEventHandlers(par_ctlPictureBox, par_container, par_iSave, pbRemoveAnyHandlers);
            }

            //Added Jan4 2022 td
            if (par_container != null)
            {
                HookUpEventHandlers(par_container, par_container, par_iSave, pbRemoveAnyHandlers);
            }

        }


        private void HookUpEventHandlers(Control par_controlToHook, Control par_container, 
                       ISaveToModel par_iSave, bool pbRemoveAnyHandlers)
        { 
            //
            // Hook up the event handlers.  
            //
            //Notice that it references "par_container"
            //   which is different from "par_control" (unless the other Init() signature
            //   was utilized... in which the par_container parameter doesn't exist...
            //   That other Init() passes par_control in both parameters of this
            //   signature of Init()... namely, par_control & par_container).
            //   ---12/1/2021 thomas downes
            //
            bool bPassParentContainer; // Added 12/2/2021 td

            if (MouseMove_DontAskAgain) bPassParentContainer = MouseMove_Container;
            else bPassParentContainer = FormContainerVsPicture.LetsPassElementContainerToMouseControl();

            if (bPassParentContainer && !pbRemoveAnyHandlers) // Dec28 2021 //(bPassContainer)
            {
                // Yes, MoveParentControl(_controlMoveableElement is correct.... Jan4 2022 td
                //----if (par_controlToHook.MouseMove != null)
                par_controlToHook.MouseMove += (sender, e) => MoveParentControl(par_container, e);
                MouseMove_DontAskAgain = true;
                MouseMove_Container = true;
            }
            else if (bPassParentContainer && pbRemoveAnyHandlers)
            {
                //Added 12/28/2021   
                // Yes, MoveParentControl(_controlMoveableElement is correct.... Jan4 2022 td
                par_controlToHook.MouseMove -= (sender, e) => MoveParentControl(par_container, e);

            }
            else if ((!bPassParentContainer) && (!pbRemoveAnyHandlers))
            {
                // Added 12/28/2021 td
                //    We don't have the parent container to pass to MoveParentControl(), unfortunately. Jan4 2022 td
                //
                par_controlToHook.MouseMove += (sender, e) => MoveParentControl(par_controlToHook, e);
                MouseMove_DontAskAgain = true;
                MouseMove_Container = false;
            }
            else if (pbRemoveAnyHandlers)
            {
                // Added 12/28/2021 td
                //    We don't have the parent container to pass to MoveParentControl(), unfortunately & surprisingly. Jan4 2022 td
                par_controlToHook.MouseMove -= (sender, e) => MoveParentControl(par_controlToHook, e);
            }
            else
            {
                //    We don't have the parent container to pass to MoveParentControl(), unfortunately & surprisingly. Jan4 2022 td
                par_controlToHook.MouseMove += (sender, e) => MoveParentControl(par_controlToHook, e);
                MouseMove_DontAskAgain = true;
                MouseMove_Container = false;
            }


            par_controlToHook.MouseDown += (sender, e) => StartMovingOrResizing(par_controlToHook, e);
            //Jan4 2022 //par_control.MouseUp += (sender, e) => StopDragOrResizing(par_control);
            par_controlToHook.MouseUp += (sender, e) => StopDragOrResizing(par_controlToHook, par_iSave);


        }


        public void AddMoveability_ViaLabel(Label par_label)
        {
            //
            // Added 1/4/2022 td 
            //
            _labelIfNeeded = par_label;
            _labelIfNeeded.MouseDown += (sender, e) => StartMovingOrResizing(_labelIfNeeded, e);
            // Yes, MoveParentControl(_controlMoveableElement is correct.... Jan4 2022 td
            _labelIfNeeded.MouseMove += (sender, e) => MoveParentControl(_controlMoveableElement, e);  // Yes, MoveControl(_controlMoveableElement is correct....
            _labelIfNeeded.MouseUp += (sender, e) => StopDragOrResizing(_labelIfNeeded, _iSaveToModel);

        }


        public void AddMoveability_ViaPictureBox(PictureBox par_pictureBox)
        {
            //
            // Added 1/4/2022 td 
            //
            _controlPictureBox2 = par_pictureBox;
            _controlPictureBox2.MouseDown += (sender, e) => StartMovingOrResizing(_controlPictureBox2, e);
            // Yes, MoveParentControl(_controlMoveableElement is correct.... Jan4 2022 td
            _controlPictureBox2.MouseMove += (sender, e) => MoveParentControl(_controlMoveableElement, e);  // Yes, MoveControl(_controlMoveableElement is correct....
            _controlPictureBox2.MouseUp += (sender, e) => StopDragOrResizing(_controlPictureBox2, _iSaveToModel);

        }


        private void UpdateMouseEdgeProperties(Control control, Point mouseLocationInControl)
        {
            if (WorkType == MoveOrResize.Move)
            {
                return;
            }

            //MouseIsInLeftEdge = Math.Abs(mouseLocationInControl.X) <= 2;
            //MouseIsInRightEdge = Math.Abs(mouseLocationInControl.X - control.Width) <= 2;
            //MouseIsInTopEdge = Math.Abs(mouseLocationInControl.Y ) <= 2;
            //MouseIsInBottomEdge = Math.Abs(mouseLocationInControl.Y - control.Height) <= 2;

            MouseIsInLeftEdge = Math.Abs(mouseLocationInControl.X) <= _margin;
            MouseIsInRightEdge = Math.Abs(mouseLocationInControl.X - control.Width) <= _margin;
            MouseIsInTopEdge = Math.Abs(mouseLocationInControl.Y) <= _margin;
            MouseIsInBottomEdge = Math.Abs(mouseLocationInControl.Y - control.Height) <= _margin;

        }


        private void UpdateMouseCursor(Control control)
        {
            if (WorkType == MoveOrResize.Move)
            {
                return;
            }

            if (MouseIsInLeftEdge)
            {
                if (RemoveSizeability) return; //Return, i.e. Stop the resizing process!!  Added 12/29/2021 td

                if (MouseIsInTopEdge)
                {
                    //Mouse is at the Left Edge & Top Edge... i.e. the TopLeft corner.
                    control.Cursor = Cursors.SizeNWSE;
                }
                else if (MouseIsInBottomEdge)
                {
                    //Mouse is at the Left Edge & Bottom Edge... i.e. the BottomLeft corner.
                    control.Cursor = Cursors.SizeNESW;
                }
                else
                {
                    control.Cursor = Cursors.SizeWE;
                }
            }

            else if (MouseIsInRightEdge)
            {
                if (RemoveSizeability) return; //Return, i.e. Stop the resizing process!!  Added 12/29/2021 td

                if (MouseIsInTopEdge)
                {
                    //Mouse is at the Right Edge & Top Edge... i.e. the TopRight corner.
                    control.Cursor = Cursors.SizeNESW;
                }
                else if (MouseIsInBottomEdge)
                {
                    //Mouse is at the Right Edge & Bottom Edge... i.e. the BottomRight corner.
                    control.Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    control.Cursor = Cursors.SizeWE;
                }
            }

            else if (MouseIsInTopEdge || MouseIsInBottomEdge)
            {
                if (RemoveSizeability) return; //Return, i.e. Stop the resizing process!!  Added 12/29/2021 td
                control.Cursor = Cursors.SizeNS;
            }
            else
            {
                control.Cursor = Cursors.Default;
            }

        }


        public void UnloadEventHandlers()
        {
            //
            //Added 12/15/2021 td 
            //   This "alias" function provides a 2nd name for forgetful programmers. 
            //
            RemoveEventHandlers();

        }

        public void RemoveEventHandlers()
        {
            //
            // Added 11/30/2021 Thomas Downes  
            //
            Reverse_Init();  //Added 12/28/2021 td 

            if (false)
            {
                //
                // This way doesn't seem to work very well. ---12/28/2021 td 
                //
                //''The minimal listing. 
                //Use the subtraction operator, -=
                _controlCurrent.MouseDown -= (sender, e) => StartMovingOrResizing(_controlCurrent, e);
                // Jan4 2022 //_controlCurrent.MouseUp -= (sender, e) => StopDragOrResizing(_controlCurrent);
                _controlCurrent.MouseUp -= (sender, e) => StopDragOrResizing(_controlCurrent, _iSaveToModel);
                _controlCurrent.MouseMove -= (sender, e) => MoveParentControl(_controlCurrent, e);

                //''
                //''More extensive listing. May fail, since not all of these
                //''   event handlers are created. 
                //''  
                //Use the subtraction operator, -=
                _controlMoveableElement.MouseDown -= (sender, e) => StartMovingOrResizing(_controlMoveableElement, e);
                _controlMoveableElement.MouseUp -= (sender, e) => StopDragOrResizing(_controlMoveableElement, _iSaveToModel);
                _controlMoveableElement.MouseMove -= (sender, e) => MoveParentControl(_controlMoveableElement, e);

                //Use the subtraction operator, -=
                _controlPictureBox1.MouseDown -= (sender, e) => StartMovingOrResizing(_controlPictureBox1, e);
                _controlPictureBox1.MouseUp -= (sender, e) => StopDragOrResizing(_controlPictureBox1, _iSaveToModel);
                _controlPictureBox1.MouseMove -= (sender, e) => MoveParentControl(_controlMoveableElement, e);

                //Use the subtraction operator, -=
                _controlPictureBox2.MouseDown -= (sender, e) => StartMovingOrResizing(_controlPictureBox2, e);
                _controlPictureBox2.MouseUp -= (sender, e) => StopDragOrResizing(_controlPictureBox2, _iSaveToModel);
                _controlPictureBox2.MouseMove -= (sender, e) => MoveParentControl(_controlMoveableElement, e);

            }

        }


        public void Reverse_Init()
        {
            //
            // Added 12/28/2021 Thomas Downes  
            //
            const bool c_bRemoveHandlers = true; //Added 12/28/2021 td

            //Added 12/28/2021 td
            Init(_controlPictureBox1, _controlMoveableElement, _margin,
                _repaintAfterResize, mod_events, false, _iSaveToModel,
                c_bRemoveHandlers);
        }


        public void KillAllEvents_Blackhole()
        {
            //
            // Added 1/3/2022 thomas downes
            //
            // We create a new event-killing blackhole, by 
            //   replacing the universal-shared events object with
            //   a free-standing events object.
            //   ("United we stand, divided we fall.")
            //   ----1/3/2022 td
            //
            const bool c_yesBlackhole = true;
            var event_blackhole = new GroupMoveEvents_Singleton(new DummyLayout(), c_yesBlackhole);

            //Let's put the blackhole into action!!  
            mod_events = event_blackhole;

        }


        private void KillTheBlackhole(InterfaceMoveEvents par_sharedEventsObject)
        {
            //
            // Added 1/3/2022 thomas downes
            //
            // We remove ("kill") the event-killing blackhole, by 
            //   replacing the blackhole with a universally-shared
            //   events object. 
            //   ----1/3/2022 td
            //
            //Jan3 2002 td //mod_groupedctl_events = par_sharedEventsObject;
            mod_events = par_sharedEventsObject;

        }




        private void StartMovingOrResizing(Control par_control, MouseEventArgs e)
        {
            //
            //Added 10/09/2019 thomas downes 
            //
            if (RemoveAllFunctionality) return;  //Return, i.e. don't allow stuff to happen. Added 12/28/2021 td 

            const bool c_bRefreshProportion = false; //False, not needed here. ----Added 10/9/2019 td

            if (c_bRefreshProportion) _proportionWH = (decimal)par_control.Width /
                            (decimal)par_control.Height;

            if (_moving || _resizing)
            {
                //We don't need to do any initiating work. We've already initiated. 
                return;
            }
            if (WorkType != MoveOrResize.Move &&
                (MouseIsInRightEdge || MouseIsInLeftEdge || MouseIsInTopEdge || MouseIsInBottomEdge))
            {
                if (RemoveSizeability) return; //Return, i.e. Stop the resizing process!!  Added 12/29/2021 td
                _resizing = true;
                _currentControlStartSize = par_control.Size;
                mod_events.Resizing_Initiate(); //Added 10/09/2019 td 

            }
            else if (WorkType != MoveOrResize.Resize)
            {
                _moving = true;
                par_control.Cursor = Cursors.Hand;
            }

            _cursorPoint_StartOfDrag = new Point(e.X, e.Y);
            par_control.Capture = true;
        }


        private void MoveParentControl(Control par_control, MouseEventArgs e)
        {
            //--Jan4 2022---private void MoveControl(Control par_control, MouseEventArgs e)
            //
            //Modified 10/9/2019 td
            //     Added 8/3/2019 thomas downes
            //
            //10/9/2019 td//if (mod_events != null) MoveControl_GroupMove(par_control, e);
            //10/9/2019 td //if (mod_groupedctl_events == null) MoveControl_NoEvents(par_control, e);
            if (mod_events == null) throw new Exception("The EventsObject (mod_events) reference is missing/uninstantiated.");

            MoveControl_IssueEvents(par_control, e);

        }

        private void MoveControl_IssueEvents(Control par_control, MouseEventArgs par_eMouse)
        {
            //
            //Renamed 10/9/2019 td. ----private  void MoveControl_GroupMove(Control par_control, MouseEventArgs e)
            //
            //Modified 8/2/2019 thomas downes  
            //
            int drag_delta_Width = 0;  //Just initializing. The module-level _cursorPoint_StartOfDrag will be compared to par_eMouse.  Prefixed drag_ on dec2021
            int drag_delta_Height = 0; // Just initializing. The module-level _cursorPoint_StartOfDrag will be compared to par_eMouse. Prefixed drag_ on dec2021
            int drag_delta_Left = 0;  // Just initializing. The module-level _cursorPoint_StartOfDrag will be compared to par_eMouse. Prefixed drag_ on dec2021
            int drag_delta_Top = 0;   // Just initializing. The module-level _cursorPoint_StartOfDrag will be compared to par_eMouse. Prefixed drag_ on dec2021

            //Added 12/29/2021 td
            //  If we haven't moved, don't bother. 
            bool boolDidWeMove = (_cursorPoint_MoveControl.X != par_eMouse.X) || (_cursorPoint_MoveControl.Y != par_eMouse.Y);
            if (!boolDidWeMove) return;
            //Save the new current spot.
            _cursorPoint_MoveControl = new Point(par_eMouse.X, par_eMouse.Y);


            //Added 10/14/2019 td
            bool bMouseIsInRightEdge_Only = false;
            bool bMouseIsInTopEdge_Only = false;
            bool bMouseIsInBottomEdge_Only = false;
            bool bMouseIsInLeftEdge_Only = false;

            if (!_resizing && !_moving)
            {
                UpdateMouseEdgeProperties(par_control, new Point(par_eMouse.X, par_eMouse.Y));
                UpdateMouseCursor(par_control);
            }

            if (_resizing)
            {
                if (MouseIsInLeftEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        par_control.Width -= (par_eMouse.X - _cursorPoint_StartOfDrag.X);
                        par_control.Left += (par_eMouse.X - _cursorPoint_StartOfDrag.X);
                        par_control.Height -= (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);
                        par_control.Top += (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);

                        //Added 8/2/2019 thomas downes 
                        drag_delta_Width = -1 * (par_eMouse.X - _cursorPoint_StartOfDrag.X);
                        drag_delta_Left = (par_eMouse.X - _cursorPoint_StartOfDrag.X);
                        drag_delta_Height = -1 * (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);
                        drag_delta_Top = (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);
                    }
                    else if (MouseIsInBottomEdge)
                    {
                        par_control.Width -= (par_eMouse.X - _cursorPoint_StartOfDrag.X);
                        par_control.Left += (par_eMouse.X - _cursorPoint_StartOfDrag.X);
                        par_control.Height = (par_eMouse.Y - _cursorPoint_StartOfDrag.Y) + _currentControlStartSize.Height;

                        //Added 8/2/2019 thomas downes 
                        drag_delta_Width = -1 * (par_eMouse.X - _cursorPoint_StartOfDrag.X);
                        drag_delta_Left = (par_eMouse.X - _cursorPoint_StartOfDrag.X);
                        drag_delta_Height = (par_eMouse.Y - _cursorPoint_StartOfDrag.Y); // + _currentControlStartSize.Height;

                    }
                    else
                    {
                        //
                        //Left-hand edge only.  (No other edges are in play.) 
                        //
                        bMouseIsInLeftEdge_Only = true; //Added 10/14/2019

                        par_control.Width -= (par_eMouse.X - _cursorPoint_StartOfDrag.X);
                        par_control.Left += (par_eMouse.X - _cursorPoint_StartOfDrag.X);

                        //Added 8/2/2019 thomas downes 
                        drag_delta_Width = -1 * (par_eMouse.X - _cursorPoint_StartOfDrag.X);
                        drag_delta_Left = (par_eMouse.X - _cursorPoint_StartOfDrag.X);
                    }
                }
                else if (MouseIsInRightEdge)
                {
                    //
                    //Right-hand edge. 
                    //
                    if (MouseIsInTopEdge)
                    {
                        //
                        //Top-right corner.  
                        //
                        par_control.Width = (par_eMouse.X - _cursorPoint_StartOfDrag.X) + _currentControlStartSize.Width;
                        par_control.Height -= (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);
                        par_control.Top += (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);

                        //Added 8/2/2019 thomas downes 
                        drag_delta_Width = (par_eMouse.X - _cursorPoint_StartOfDrag.X); // + _currentControlStartSize.Width;
                        drag_delta_Height = -1 * (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);
                        drag_delta_Top = (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);

                    }
                    else if (MouseIsInBottomEdge)
                    {
                        //
                        //Bottom-right corner.  
                        //
                        par_control.Width = (par_eMouse.X - _cursorPoint_StartOfDrag.X) + _currentControlStartSize.Width;
                        par_control.Height = (par_eMouse.Y - _cursorPoint_StartOfDrag.Y) + _currentControlStartSize.Height;

                        //Added 8/2/2019 thomas downes 
                        drag_delta_Width = (par_eMouse.X - _cursorPoint_StartOfDrag.X);  //+ _currentControlStartSize.Width;
                        drag_delta_Height = (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);  // + _currentControlStartSize.Height;
                    }
                    else
                    {
                        //
                        //Only the right-hand edge is in play. 
                        //
                        bMouseIsInRightEdge_Only = true;

                        par_control.Width = (par_eMouse.X - _cursorPoint_StartOfDrag.X) + _currentControlStartSize.Width;

                        //Added 8/2/2019 thomas downes 
                        drag_delta_Width = (par_eMouse.X - _cursorPoint_StartOfDrag.X); // + _currentControlStartSize.Width;
                    }
                }
                else if (MouseIsInTopEdge)
                {
                    //
                    //Only the top edge is in play.  (No corners.) 
                    //
                    bMouseIsInTopEdge_Only = true; //Added 10/14/2019

                    par_control.Height -= (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);
                    par_control.Top += (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);

                    //Added 8/2/2019 thomas downes 
                    drag_delta_Height = -1 * (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);
                    drag_delta_Top = (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);
                }
                else if (MouseIsInBottomEdge)
                {
                    //
                    //Only the bottom edge is in play.  (No corners.) 
                    //
                    bMouseIsInBottomEdge_Only = true; //Added 10/14/2019

                    par_control.Height = (par_eMouse.Y - _cursorPoint_StartOfDrag.Y) + _currentControlStartSize.Height;

                    //Added 8/2/2019 thomas downes 
                    drag_delta_Height = (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);  //  + _currentControlStartSize.Height;
                }
                else
                {
                    // Jan4 2022 td//StopDragOrResizing(par_control);
                    StopDragOrResizing(par_control, _iSaveToModel);
                }

                //Control the proportionality.
                //    ----10/14/2019
                decimal intAmtWrong_Width = Math.Abs(par_control.Width - (par_control.Height * _proportionWH));
                decimal intAmtWrong_Height = Math.Abs(par_control.Height - (par_control.Width / _proportionWH));

                //Fix whichever of the two is worse.  ---10/14
                if (intAmtWrong_Height > intAmtWrong_Width)
                {
                    par_control.Height = (int)((decimal)par_control.Width / _proportionWH);
                }
                else if (bMouseIsInTopEdge_Only || bMouseIsInBottomEdge_Only)
                {
                    //Added 10/14/2019 td 
                    par_control.Width = (int)((decimal)par_control.Height * _proportionWH);
                }
                else if (bMouseIsInLeftEdge_Only || bMouseIsInRightEdge_Only)
                {
                    //Added 10/14/2019 td 
                    par_control.Height = (int)((decimal)par_control.Width / _proportionWH);
                }
                else
                {
                    par_control.Width = (int)((decimal)par_control.Height * _proportionWH);
                }

            }
            else if (_moving)
            {
                _moveIsInterNal = !_moveIsInterNal;
                if (!_moveIsInterNal)
                {
                    int x = (par_eMouse.X - _cursorPoint_StartOfDrag.X) + par_control.Left;
                    int y = (par_eMouse.Y - _cursorPoint_StartOfDrag.Y) + par_control.Top;
                    par_control.Location = new Point(x, y);

                    //Added 8/2/2019 thomas downes 
                    drag_delta_Left = (par_eMouse.X - _cursorPoint_StartOfDrag.X);
                    drag_delta_Top = (par_eMouse.Y - _cursorPoint_StartOfDrag.Y);

                }
            }

            //
            //Added 8/2/2019 thomas downes
            //
            //---Dec29/2021 td// if (_resizing && (delta_Height != 0 || delta_Width != 0))

            //bool bResizingRefreshNeeded = (drag_delta_Height != 0 || drag_delta_Width != 0);
            int refresh_delta_Height = Math.Abs(par_eMouse.Y - _cursorPoint_LastRefresh.Y); //Dec29 2021
            int refresh_delta_Width = Math.Abs(par_eMouse.X - _cursorPoint_LastRefresh.X); //Dec29 2021
            bool bResizingRefreshNeeded = (refresh_delta_Height > 1 || refresh_delta_Width > 1); //Dec29 2021

            //---Dec29/2021 td// if (_resizing && (delta_Height != 0 || delta_Width != 0))
            if (_resizing && (bResizingRefreshNeeded))
            {
                //
                //Allow a group of controls to be affected in unison.   
                //
                mod_events.ControlBeingMoved(par_control);

                // 8-12-2019 td//delta_Top = 0;
                // 8-12-2019 td//delta_Left = 0;

                // 8-5-2019 td //mod_events.GroupMove(delta_Left, delta_Top, delta_Width, delta_Height);
                mod_events.GroupMove_Change(drag_delta_Left, drag_delta_Top, drag_delta_Width, drag_delta_Height);

                //Added 12/29/2021 thomas downes
                LogDebuggingInformation("_resizing ", drag_delta_Left, drag_delta_Top, drag_delta_Width, drag_delta_Height);

                //
                // Save the location of this refresh of the screen.  ---12/29/2021 thomas downes
                //
                _cursorPoint_LastRefresh = new Point(par_eMouse.X, par_eMouse.Y);

            }

            else if (_moving && (drag_delta_Left != 0 || drag_delta_Top != 0))
            {
                //
                //Allow a group of controls to be affected in unison.   
                //
                mod_events.ControlBeingMoved(par_control);
                drag_delta_Width = 0;
                drag_delta_Height = 0;
                // 8-5-2019 td //mod_events.GroupMove(delta_Left, delta_Top, delta_Width, delta_Height);
                mod_events.GroupMove_Change(drag_delta_Left, drag_delta_Top, drag_delta_Width, drag_delta_Height);

                //Added 12/29/2021 thomas downes
                LogDebuggingInformation("_moving ", drag_delta_Left, drag_delta_Top, drag_delta_Width, drag_delta_Height);

            }


            //const bool c_boolUseFunkyNewSyntax = false;
            //if (c_boolUseFunkyNewSyntax)
            //{
            //    GroupMove?.Invoke(delta_Left, delta_Top, delta_Width, delta_Height);
            //}

            //if (!c_boolUseFunkyNewSyntax)
            //{
            //    if (GroupMove != null) GroupMove.Invoke(delta_Left, delta_Top, delta_Width, delta_Height);
            //}

        }


        private void LogDebuggingInformation(string par_header, int deltaLeft, int deltaTop, int deltaWidth, int deltaHeight)
        {
            //
            // Added 12/29/2021 thomas downes
            //
            //    I don't like the flickering I am noticing when I resize Jane Mulvey's photo.
            //
            _indexOfDebugArray++;
            if (_indexOfDebugArray >= _c_indexLengthOfDebugArray) _indexOfDebugArray = 0;

            //
            // Record the data. 
            //
            _arrayDebuggingInfo[_indexOfDebugArray] = $"{par_header} Left: {deltaLeft} Top: {deltaTop} " +
                                                                   $" Width: {deltaWidth} Height: {deltaHeight}";

            int indexFutureEntries1 = (_indexOfDebugArray + 1);
            int indexFutureEntries2 = (_indexOfDebugArray + 2);
            if (indexFutureEntries1 >= _c_indexLengthOfDebugArray) indexFutureEntries1 = 0;
            if (indexFutureEntries2 >= _c_indexLengthOfDebugArray) indexFutureEntries2 = (indexFutureEntries1 + 1);
            if (indexFutureEntries2 >= _c_indexLengthOfDebugArray) indexFutureEntries2 = 0;

            _arrayDebuggingInfo[indexFutureEntries1] = "";   //Clear it out, to make it obvious which entries are most recent.
            _arrayDebuggingInfo[indexFutureEntries2] = "";  //Clear it out, to make it obvious which entries are most recent.

            //Added 12/29/2021 td
            //  Break when we have run through the total array a few times.
            //
            //---_countTotalCalls++;
            //---if (_countTotalCalls > (3 * _c_indexLengthOfDebugArray)) System.Diagnostics.Debugger.Break();

        }



        private void StopDragOrResizing(Control par_control, ISaveToModel par_iSave)
        {
            //---Jan4 2022--private void StopDragOrResizing(Control par_control)
            //
            bool bWasResizing = _resizing; // Added 7/31/2019 td

            _resizing = false;
            _moving = false;
            par_control.Capture = false;
            UpdateMouseCursor(par_control);

            //Added 7/31/2019 td
            //  Added a new parameter, par_bRepaintAfterResize.   (Needed to apply 
            //     the preferred background color.)   
            //
            if (_repaintAfterResize && bWasResizing) par_control.Refresh();
            if (_repaintAfterResize && bWasResizing) par_control.Parent.Refresh();

            //Added 9/13/2019 td
            if (SetBreakpoint_AfterMove) System.Diagnostics.Debugger.Break();

            //Added 10/14 & 8/5/2019 thomas downes
            //---if (bWasResizing) mod_events.Resizing_Terminate(_iSaveToModel);
            if (bWasResizing) mod_events.Resizing_Terminate(par_iSave);

            //Added 10/14 & 9/13/2019 thomas downes
            // 12/17/2021 td //if (!(bWasResizing)) mod_events.Moving_Terminate(par_control);
            // 1/04/2022 td //if (!(bWasResizing)) mod_events.Moving_Terminate(par_control, _iSaveToModel);
            if (!(bWasResizing)) mod_events.Moving_Terminate(par_control, par_iSave);

        }

        #region Save And Load

        private List<Control> GetAllChildControls(Control control, List<Control> list)
        {
            List<Control> controls = control.Controls.Cast<Control>().ToList();
            list.AddRange(controls);
            return controls.SelectMany(ctrl => GetAllChildControls(ctrl, list)).ToList();
        }

        internal string GetSizeAndPositionOfControlsToString(Control container)
        {
            List<Control> controls = new List<Control>();
            GetAllChildControls(container, controls);
            CultureInfo cultureInfo = new CultureInfo("en");
            string info = string.Empty;
            foreach (Control control in controls)
            {
                info += control.Name + ":" + control.Left.ToString(cultureInfo) + "," + control.Top.ToString(cultureInfo) + "," +
                        control.Width.ToString(cultureInfo) + "," + control.Height.ToString(cultureInfo) + "*";
            }
            return info;
        }
        internal void SetSizeAndPositionOfControlsFromString(Control container, string controlsInfoStr)
        {
            List<Control> controls = new List<Control>();
            GetAllChildControls(container, controls);
            string[] controlsInfo = controlsInfoStr.Split(new[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> controlsInfoDictionary = new Dictionary<string, string>();
            foreach (string controlInfo in controlsInfo)
            {
                string[] info = controlInfo.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                controlsInfoDictionary.Add(info[0], info[1]);
            }
            foreach (Control control in controls)
            {
                string propertiesStr;
                controlsInfoDictionary.TryGetValue(control.Name, out propertiesStr);
                string[] properties = propertiesStr.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (properties.Length == 4)
                {
                    control.Left = int.Parse(properties[0]);
                    control.Top = int.Parse(properties[1]);
                    control.Width = int.Parse(properties[2]);
                    control.Height = int.Parse(properties[3]);
                }
            }
        }

        #endregion
    }
}