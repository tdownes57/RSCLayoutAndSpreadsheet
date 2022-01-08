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

using System;
//using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms; // Added 11/29/2021 thomas downes
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using ciBadgeInterfaces;  // Added 12/17/2021 td
//
//  This class is a copy of class ControlMove_GroupMove_TD,  
//    with the keyword "static" removed.  
//    ----11/29/2021 thomas downes
//
namespace MoveAndResizeControls_Monem

{
    //
    // Added 11/29/2021 thomas downes 
    //
    public class ControlMove_Group_NonStatic : IMoveOrResizeFunctionality // InterfaceMoveOrResize
    {
        //
        //  Class ControlMove_Group_NonStatic
        //     was copied from ControlMove_GroupMove_TD. 
        //     The keyword "static" was removed. 
        //     ----11/29/2021 
        //
        //  Class primarily authored by Seyyed Hamed Monem 
        //       https://www.codeproject.com/tips/709121/move-and-resize-controls-on-a-form-at-runtime-with 
        //       https://www.codeproject.com/info/cpol10.aspx
        //  This class was modified in August 2019 by Thomas C. Downes
        //
        // Dec28 2021 //public bool RemoveAllFunctionality = false; //Added 12/28/2021 td
        public bool RemoveAllFunctionality // = false;  //Added 12/28/2021 //
        {
            get;
            set;
        }

        public bool RemoveSizeability // = false;  //Added 12/28/2021 //
        {
            get;
            set;
        }

        private bool _moving = false; // Default value added 1/7/2022 td
        private bool _repaintAfterResize;  // Added 7/31/2019 td  
        /// </summary>
        private Point _cursorStartPoint;
        private bool _moveIsInterNal;
        private bool _resizing = false; // Default value added 1/7/2022 td
        private Size _currentControlStartSize;

        private Control _controlCurrent; // Added 11/29/2021 td
        //''1/4/2022 td''private Control _controlPictureBox;  // = par_controlPictureB;
        private PictureBox _controlPictureBox1;  // = par_controlPictureB;
        private PictureBox _controlPictureBox2;  // = par_controlPictureB;
        private Control _controlMoveableElement; // = par_containerElement;
        private ISaveToModel _iSaveToModel;  // Added 12/17/2021 td
        private Label _labelIfNeeded;  //Added 1/04/2022 thomas d.

        //Added 7/18/2019 thomas downes
        //
        private int _margin; //Added 7/18/2019 thomas downes

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

        //Added 8/03/2019 thomas downes
        //
        //---internal InterfaceEvents mod_groupedctl_events;
        public InterfaceMoveEvents mod_groupedctl_events;

        internal MoveOrResize WorkType { get; set; }


        public void Init(Control par_controlA, int par_margin, bool pbRepaintAfterResize,
                                 InterfaceMoveEvents par_events, bool pbSetBreakpoint_AfterMove,
                                 ISaveToModel par_iSave, 
                                 bool pbUndoAndReverseEverything = false,
                                 bool pbHookUpEventHandlers = true)
        {
            //  Added a new parameter, par_bRepaintAfterResize.   (Needed to apply 
            //     the preferred background color.)   ----7/31/2019 td
            //
            // 7-31-2019 td ----public static void Init(Control control, int par_margin)
            //
            //Init(control, control);

            // 7-31-2019 td----Init(control, control, par_margin

            // 8-03-2019 td//Init(control, control, par_margin, pbRepaintAfterResize);

            //Not needed here. 9/13 td.//SetBreakpoint_AfterMove = pbSetBreakpoint_AfterMove;  //Added 9/13/2019 td 

            // 9-13-2019 td//Init(control, control, par_margin, pbRepaintAfterResize, par_events);
            // Dec28 2021 td//Init(par_controlA, par_controlA, par_margin, pbRepaintAfterResize, par_events, SetBreakpoint_AfterMove, par_iSave);
            //''Jan4 2022''Init(par_controlA, par_controlA, par_margin, pbRepaintAfterResize, par_events, SetBreakpoint_AfterMove,
            //''    par_iSave, pbUndoAndReverseEverything);
            Init(null, par_controlA, par_margin, pbRepaintAfterResize, par_events, 
                SetBreakpoint_AfterMove,
                par_iSave, pbUndoAndReverseEverything, pbHookUpEventHandlers);

        }


        public void Init(PictureBox par_controlPictureB, Control par_containerElement, 
                               int par_margin, bool pbRepaintAfterResize,
                               InterfaceMoveEvents par_events, bool pbSetBreakpoint_AfterMove, 
                               ISaveToModel par_iSave, 
                               bool pbUndoAndReverseEverything = false,
                               bool pbHookUpEventHandlers = true,
                               float par_unused = 0)
        {
            //  Added a new parameter, par_bRepaintAfterResize.   (Needed to apply 
            //     the preferred background color.)   ----7/31/2019 td
            //
            // 8-03-2019 td--
            // 7-31-2019 td--public static void Init(Control control, Control container, int par_margin)
            //
            //
            //   internal static void Init(Control control, Control container)
            //
            //Dec28 //_iSaveToModel = par_iSave; //Added 12/17/2021 td
            if (pbUndoAndReverseEverything) _iSaveToModel = null; //Added 12/28/2021
            else _iSaveToModel = par_iSave;  //Added 12/28/2021

            //Dec28 //_controlPictureBox = par_controlPictureB; //Added 12/27/2021 td
            if (pbUndoAndReverseEverything) _controlPictureBox1 = null; //Added 12/28/2021
            else _controlPictureBox1 = par_controlPictureB; //Added 12/28/2021

            SetBreakpoint_AfterMove = pbSetBreakpoint_AfterMove;  //Added 9/13/2019 td 

            //Dec28 2021 //mod_groupedctl_events = par_events;  // 8/3/2019 thomas downes   
            if (pbUndoAndReverseEverything) mod_groupedctl_events = null; //Added 12/28/2021
            else mod_groupedctl_events = par_events; //Added 12/28/2021

            _moving = false;
            _repaintAfterResize = pbRepaintAfterResize; //Added 7/31/2019 td 
            _resizing = false;
            _moveIsInterNal = false;
            _cursorStartPoint = Point.Empty;

            //
            //Added 7/18/2019 thomas downes 
            //
            _margin = par_margin;

            MouseIsInLeftEdge = false;
            MouseIsInLeftEdge = false;
            MouseIsInRightEdge = false;
            MouseIsInTopEdge = false;
            MouseIsInBottomEdge = false;
            WorkType = MoveOrResize.MoveAndResize;

            //Added 11/29/2021 td
            if (pbUndoAndReverseEverything)
            {
                // Remove the object references. ---Dec28 2021  
                _controlCurrent = null;  // par_controlPictureB;
                _controlPictureBox1 = null; // par_controlPictureB;
                _controlPictureBox2 = null; // par_controlPictureB;
                _controlMoveableElement = null; // par_containerElement;
                _labelIfNeeded = null;  //Added 1/4/2022 td
            }
            else
            {
                //Added 1/4/2022 //_controlCurrent = par_controlPictureB;
                _controlCurrent = par_containerElement;
                _controlPictureBox1 = par_controlPictureB;
                _controlMoveableElement = par_containerElement;
                //Added 1/4/2022 td
                //---if (_controlCurrent == null) _controlCurrent = par_containerElement;
                if (_controlCurrent == null) _controlCurrent = par_controlPictureB;

            }

            //
            //Encapsulated 1/4/2022 td
            //
            if (pbHookUpEventHandlers)
            {
                if (par_controlPictureB != null)
                {
                    HookUpEventHandlers(par_controlPictureB, par_containerElement,
                        par_iSave, pbUndoAndReverseEverything);
                }
                //Added Jan4 2022 td
                if (par_containerElement != null)
                {
                    HookUpEventHandlers(par_containerElement, par_containerElement,
                     par_iSave, pbUndoAndReverseEverything);
                }
            }

        }


        private void HookUpEventHandlers(Control par_controlToHook, Control par_container,
                       ISaveToModel par_iSave, bool pbUndoAndReverseEverything)
        {
            //
            // Hook up the event handlers.  
            //
            if (pbUndoAndReverseEverything)
            {
                // Remove these EventHandlers. ---12/28/2021 td
                par_controlToHook.MouseDown -= (sender, e) => StartMovingOrResizing(par_controlToHook, e);
                par_controlToHook.MouseUp -= (sender, e) => StopDragOrResizing(par_controlToHook, _iSaveToModel);
                
            }
            else
            {
                par_controlToHook.MouseDown += (sender, e) => StartMovingOrResizing(par_controlToHook, e);
                //Dec17 2021 td//par_controlPictureB.MouseUp += (sender, e) => StopDragOrResizing(par_controlToHook);
                //Jan4 2022 //if (par_controlToHook.MouseUp != null) throw new Exception("This MouseUp may already be assigned.");
                par_controlToHook.MouseUp += (sender, e) => StopDragOrResizing(par_controlToHook, _iSaveToModel);
                
            }

            //==     Notice that, toward the end of the line, it references
            //==   the parameter "par_containerElement".... which conflicts with "par_control"
            //==   (unless the other Init() signature was utilized... in which the parameter par_container
            //==   doesn't exist...
            //==      That other Init() passes par_control in both parameters of this
            //==   signature of Init()... namely, par_control & par_container).
            //==   ---12/1/2021 thomas downes
            //==      On the other hand, it's the container's Top & Left properties
            //==    which has to be adjusted, in order to move both the container &
            //==    the graphic PictureBox control inside.  Confusing!! 
            //==   ---12/1/2021 thomas downes
            //
            //==//par_controlPictureB.MouseMove += (sender, e) => MoveControl(par_containerElement, e);
            //
            //--Helpful??? 12/1/2021--par_containerElement.MouseMove += (sender, e) => MoveControl(par_containerElement, e);
            //Dec28 2021 //par_controlPictureB.MouseMove += (sender, e) => MoveControl(par_containerElement, e);
            
            if (pbUndoAndReverseEverything)
            {
                //Remove the event handler.
                par_controlToHook.MouseMove -= (sender, e) => MoveParentControl(par_container, e);
            }
            else
            {
                // Yes, MoveParentControl(par_containterElement is correct.... Jan4 2022 td
                par_controlToHook.MouseMove += (sender, e) => MoveParentControl(par_container, e);
            }

            //Added 1/4/2022 td
            //
            //  Remove the functionality of moving the Element Control via a Label Control. 
            //
            if (pbUndoAndReverseEverything)
            {
                if (_labelIfNeeded != null) 
                {
                    _labelIfNeeded.MouseDown -= (sender, e) => StartMovingOrResizing(_labelIfNeeded, e);
                    // Yes, MoveParentControl(_controlMoveableElement is correct.... Jan4 2022 td
                    _labelIfNeeded.MouseMove -= (sender, e) => MoveParentControl(_controlMoveableElement, e);
                    _labelIfNeeded.MouseUp -= (sender, e) => StopDragOrResizing(_labelIfNeeded, _iSaveToModel);
                }
            }



        }


        public void AddMoveability_ViaLabel(Label par_label)
        {
            //
            // Added 1/4/2022 td 
            //
            _labelIfNeeded = par_label;
            _labelIfNeeded.MouseDown += (sender, e) => StartMovingOrResizing(_labelIfNeeded, e);
            // Yes, MoveParentControl(_controlMoveableElement is correct.... Jan4 2022 td
            _labelIfNeeded.MouseMove += (sender, e) => MoveParentControl(_controlMoveableElement, e);
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
            _controlPictureBox2.MouseMove += (sender, e) => MoveParentControl(_controlMoveableElement, e);  // Yes, MoveParentControl(_controlMoveableElement
            _controlPictureBox2.MouseUp += (sender, e) => StopDragOrResizing(_controlPictureBox2, _iSaveToModel);

        }


        public void Reverse_Init()
        {
            //
            //Added 12/28/2021 td
            //
            const bool c_bReverseEverything = true;

            //Major call !!
            Init(_controlPictureBox1, _controlMoveableElement, 0, _repaintAfterResize,
                mod_groupedctl_events, false, _iSaveToModel, c_bReverseEverything);

            //Null out the references. ----12/28/2021 td 
            _controlPictureBox1 = null;
            _controlPictureBox2 = null;
            _controlMoveableElement = null;
            _controlCurrent = null;
            mod_groupedctl_events = null;
            _iSaveToModel = null;


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
            mod_groupedctl_events = event_blackhole; 

        }


        private void FillTheBlackhole(InterfaceMoveEvents par_sharedEventsObject)
        {
            //
            // Added 1/3/2022 thomas downes
            //
            // We remove ("Fill") the event-killing blackhole, by 
            //   replacing the blackhole with a universally-shared
            //   events object. 
            //   ----1/3/2022 td
            //
            mod_groupedctl_events = par_sharedEventsObject;

        }


        private void UpdateMouseEdgeProperties(Control par_controlC, Point mouseLocationInControl)
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
            MouseIsInRightEdge = Math.Abs(mouseLocationInControl.X - par_controlC.Width) <= _margin;
            MouseIsInTopEdge = Math.Abs(mouseLocationInControl.Y) <= _margin;
            MouseIsInBottomEdge = Math.Abs(mouseLocationInControl.Y - par_controlC.Height) <= _margin;

            //Added 11/29/2021 td
            _controlCurrent = par_controlC;

        }

        private void UpdateMouseCursor(Control par_controlD)
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
                    par_controlD.Cursor = Cursors.SizeNWSE;
                }
                else if (MouseIsInBottomEdge)
                {
                    //Mouse is at the Left Edge & Bottom Edge... i.e. the BottomLeft corner.
                    par_controlD.Cursor = Cursors.SizeNESW;
                }
                else
                {
                    par_controlD.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInRightEdge)
            {
                if (RemoveSizeability) return; //Return, i.e. Stop the resizing process!!  Added 12/29/2021 td

                if (MouseIsInTopEdge)
                {
                    //Mouse is at the Right Edge & Top Edge... i.e. the TopRight corner.
                    par_controlD.Cursor = Cursors.SizeNESW;
                }
                else if (MouseIsInBottomEdge)
                {
                    //Mouse is at the Right Edge & Bottom Edge... i.e. the BottomRight corner.
                    par_controlD.Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    par_controlD.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInTopEdge || MouseIsInBottomEdge)
            {
                if (RemoveSizeability) return; //Return, i.e. Stop the resizing process!!  Added 12/29/2021 td

                //Mouse is at the Top & Bottom Edge... i.e. the TopRight corner.
                par_controlD.Cursor = Cursors.SizeNS;
            }
            else
            {
                //Mouse is at the Right Edge & Bottom Edge... i.e. the BottomRight corner.
                par_controlD.Cursor = Cursors.Default;
            }

            //Added 11/29/2021 td
            _controlCurrent = par_controlD;

        }


        public void StartMovingOrResizing(Control par_controlE, MouseEventArgs e)
        {
            //
            //Added by the programmer Monem, long before 12/28/2021.  ---12/28/2021 thomas downes
            //
            if (RemoveAllFunctionality) return; //Added 12/28/2021 td

            if (_moving || _resizing)
            {
                //
                //We are in the midst of one of the above above actions.   No Booleans need to be toggled on or off. 
                //
                return;
            }

            // Added 1/7/2022 thomas downes
            // Let's update the following values:
            //
            //    MouseIsInRightEdge
            //    MouseIsInLeftEdge
            //    MouseIsInTopEdge
            //    MouseIsInBottomEdge
            //
            UpdateMouseEdgeProperties(par_controlE, new Point(e.X, e.Y));

            if (WorkType != MoveOrResize.Move &&
                (MouseIsInRightEdge || MouseIsInLeftEdge || MouseIsInTopEdge || MouseIsInBottomEdge))
            {
                //
                //We need to initiate the Resizing process. 
                //
                if (RemoveSizeability) return; //Return, i.e. Stop the resizing process!!  Added 12/29/2021 td
                _resizing = true;
                _currentControlStartSize = par_controlE.Size;
                mod_groupedctl_events.Resizing_Initiate(); //Added 8/5/2019 td 
            }

            else if (WorkType != MoveOrResize.Resize)
            {
                //
                //We need to initiate the Moving process. 
                //
                _moving = true;
                par_controlE.Cursor = Cursors.Hand;
            }

            _cursorStartPoint = new Point(e.X, e.Y);
            par_controlE.Capture = true;

            //
            //Added 8/4/2019 td
            //
            //ParentForm.ControlBeingMoved = control

            //Added 11/29/2021 td
            _controlCurrent = par_controlE;

        }

        public void MoveParentControl(Control par_controlParentF, MouseEventArgs e)
        {
            //--Jan4 2022---private void MoveControl(Control par_control, MouseEventArgs e)
            //
            //Renamed 1/4/2022 td
            //Added 8/3/2019 thomas downes
            //
            //   Should the PictureBox control be passed here (above parameter), or the user-control
            //   which contains the PictureBox control??  The latter, let's pass the user-control
            //   which is the Parent of the PictureBox. ---12/1/2021 td
            //
            if (mod_groupedctl_events != null)
            {
                MoveControl_GroupMove(par_controlParentF, e);

                //Added 12/6/2021 td
                mod_groupedctl_events.Control_IsMoving();

            }
            if (mod_groupedctl_events == null) MoveControl_NoEvents(par_controlParentF, e);

            //Added 11/29/2021 td
            _controlCurrent = par_controlParentF;

        }

        private void MoveControl_GroupMove(Control par_controlG, MouseEventArgs e)
        {
            //
            //Modified 8/2/2019 thomas downes  
            //
            int delta_Width = 0;
            int delta_Height = 0;
            int delta_Left = 0;
            int delta_Top = 0;

            if (!_resizing && !_moving)
            {
                // Added 1/7/2022 thomas downes
                // Let's update the following values:
                //
                //    MouseIsInRightEdge
                //    MouseIsInLeftEdge
                //    MouseIsInTopEdge
                //    MouseIsInBottomEdge
                //
                UpdateMouseEdgeProperties(par_controlG, new Point(e.X, e.Y));
                UpdateMouseCursor(par_controlG);
            }

            if (_resizing)
            {
                if (MouseIsInLeftEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        par_controlG.Width -= (e.X - _cursorStartPoint.X);
                        par_controlG.Left += (e.X - _cursorStartPoint.X);
                        par_controlG.Height -= (e.Y - _cursorStartPoint.Y);
                        par_controlG.Top += (e.Y - _cursorStartPoint.Y);

                        //Added 8/2/2019 thomas downes 
                        delta_Width = -1 * (e.X - _cursorStartPoint.X);
                        delta_Left = (e.X - _cursorStartPoint.X);
                        delta_Height = -1 * (e.Y - _cursorStartPoint.Y);
                        delta_Top = (e.Y - _cursorStartPoint.Y);
                    }
                    else if (MouseIsInBottomEdge)
                    {
                        par_controlG.Width -= (e.X - _cursorStartPoint.X);
                        par_controlG.Left += (e.X - _cursorStartPoint.X);
                        par_controlG.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;

                        //Added 8/2/2019 thomas downes 
                        delta_Width = -1 * (e.X - _cursorStartPoint.X);
                        delta_Left = (e.X - _cursorStartPoint.X);
                        delta_Height = (e.Y - _cursorStartPoint.Y); // + _currentControlStartSize.Height;

                    }
                    else
                    {
                        par_controlG.Width -= (e.X - _cursorStartPoint.X);
                        par_controlG.Left += (e.X - _cursorStartPoint.X);

                        //Added 8/2/2019 thomas downes 
                        delta_Width = -1 * (e.X - _cursorStartPoint.X);
                        delta_Left = (e.X - _cursorStartPoint.X);
                    }
                }
                else if (MouseIsInRightEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        par_controlG.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        par_controlG.Height -= (e.Y - _cursorStartPoint.Y);
                        par_controlG.Top += (e.Y - _cursorStartPoint.Y);

                        //Added 8/2/2019 thomas downes 
                        delta_Width = (e.X - _cursorStartPoint.X); // + _currentControlStartSize.Width;
                        delta_Height = -1 * (e.Y - _cursorStartPoint.Y);
                        delta_Top = (e.Y - _cursorStartPoint.Y);

                    }
                    else if (MouseIsInBottomEdge)
                    {
                        par_controlG.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        par_controlG.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;

                        //Added 8/2/2019 thomas downes 
                        delta_Width = (e.X - _cursorStartPoint.X);  //+ _currentControlStartSize.Width;
                        delta_Height = (e.Y - _cursorStartPoint.Y);  // + _currentControlStartSize.Height;
                    }
                    else
                    {
                        par_controlG.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;

                        //Added 8/2/2019 thomas downes 
                        delta_Width = (e.X - _cursorStartPoint.X); // + _currentControlStartSize.Width;
                    }
                }
                else if (MouseIsInTopEdge)
                {
                    par_controlG.Height -= (e.Y - _cursorStartPoint.Y);
                    par_controlG.Top += (e.Y - _cursorStartPoint.Y);

                    //Added 8/2/2019 thomas downes 
                    delta_Height = -1 * (e.Y - _cursorStartPoint.Y);
                    delta_Top = (e.Y - _cursorStartPoint.Y);
                }
                else if (MouseIsInBottomEdge)
                {
                    par_controlG.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;

                    //Added 8/2/2019 thomas downes 
                    delta_Height = (e.Y - _cursorStartPoint.Y);  //  + _currentControlStartSize.Height;
                }
                else
                {
                    // Dec17 2021 //StopDragOrResizing(par_controlG);
                    StopDragOrResizing(par_controlG, _iSaveToModel);
                }
            }
            else if (_moving)
            {
                _moveIsInterNal = !_moveIsInterNal;
                if (!_moveIsInterNal)
                {
                    int x = (e.X - _cursorStartPoint.X) + par_controlG.Left;
                    int y = (e.Y - _cursorStartPoint.Y) + par_controlG.Top;
                    par_controlG.Location = new Point(x, y);

                    //Added 8/2/2019 thomas downes 
                    delta_Left = (e.X - _cursorStartPoint.X);
                    delta_Top = (e.Y - _cursorStartPoint.Y);

                    //Added 12/6/2021 td 
                    mod_groupedctl_events.ControlBeingMoved(par_controlG);

                }
            }

            //
            //Added 8/2/2019 thomas downes
            //
            if (_resizing && (delta_Height != 0 || delta_Width != 0))
            {
                //
                //Allow a group of controls to be affected in unison.   
                //
                mod_groupedctl_events.ControlBeingMoved(par_controlG);

                // 8-12-2019 td//delta_Top = 0;
                // 8-12-2019 td//delta_Left = 0;

                // 8-5-2019 td //mod_events.GroupMove(delta_Left, delta_Top, delta_Width, delta_Height);
                mod_groupedctl_events.GroupMove_Change(delta_Left, delta_Top, delta_Width, delta_Height);

            }

            if (_moving && (delta_Left != 0 || delta_Top != 0))
            {
                //
                //Allow a group of controls to be affected in unison.   
                //
                mod_groupedctl_events.ControlBeingMoved(par_controlG);
                delta_Width = 0;
                delta_Height = 0;
                // 8-5-2019 td //mod_events.GroupMove(delta_Left, delta_Top, delta_Width, delta_Height);
                mod_groupedctl_events.GroupMove_Change(delta_Left, delta_Top, delta_Width, delta_Height);

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

            //Added 11/29/2021 td
            _controlCurrent = par_controlG;

        }


        private void MoveControl_NoEvents(Control par_controlH, MouseEventArgs e)
        {
            if (!_resizing && !_moving)
            {
                UpdateMouseEdgeProperties(par_controlH, new Point(e.X, e.Y));
                UpdateMouseCursor(par_controlH);
            }
            if (_resizing)
            {
                if (MouseIsInLeftEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        par_controlH.Width -= (e.X - _cursorStartPoint.X);
                        par_controlH.Left += (e.X - _cursorStartPoint.X);
                        par_controlH.Height -= (e.Y - _cursorStartPoint.Y);
                        par_controlH.Top += (e.Y - _cursorStartPoint.Y);
                    }
                    else if (MouseIsInBottomEdge)
                    {
                        par_controlH.Width -= (e.X - _cursorStartPoint.X);
                        par_controlH.Left += (e.X - _cursorStartPoint.X);
                        par_controlH.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                    }
                    else
                    {
                        par_controlH.Width -= (e.X - _cursorStartPoint.X);
                        par_controlH.Left += (e.X - _cursorStartPoint.X);
                    }
                }
                else if (MouseIsInRightEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        par_controlH.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        par_controlH.Height -= (e.Y - _cursorStartPoint.Y);
                        par_controlH.Top += (e.Y - _cursorStartPoint.Y);

                    }
                    else if (MouseIsInBottomEdge)
                    {
                        par_controlH.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        par_controlH.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                    }
                    else
                    {
                        par_controlH.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                    }
                }
                else if (MouseIsInTopEdge)
                {
                    par_controlH.Height -= (e.Y - _cursorStartPoint.Y);
                    par_controlH.Top += (e.Y - _cursorStartPoint.Y);
                }
                else if (MouseIsInBottomEdge)
                {
                    par_controlH.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                }
                else
                {
                    //Dec17 2021 td//StopDragOrResizing(par_controlH);
                    StopDragOrResizing(par_controlH, _iSaveToModel);
                }
            }
            else if (_moving)
            {
                _moveIsInterNal = !_moveIsInterNal;
                if (!_moveIsInterNal)
                {
                    int x = (e.X - _cursorStartPoint.X) + par_controlH.Left;
                    int y = (e.Y - _cursorStartPoint.Y) + par_controlH.Top;
                    par_controlH.Location = new Point(x, y);
                }
            }

            //Added 11/29/2021 td
            _controlCurrent = par_controlH;

        }


        public void StopDragOrResizing(Control par_controlJ, ISaveToModel par_iSave)
        {
            bool bWasResizing = _resizing; // Added 7/31/2019 td

            _resizing = false;
            _moving = false;
            par_controlJ.Capture = false;
            UpdateMouseCursor(par_controlJ);

            //Added 7/31/2019 td
            //  Added a new parameter, par_bRepaintAfterResize.   (Needed to apply 
            //     the preferred background color.)   
            //
            if (_repaintAfterResize && bWasResizing) par_controlJ.Refresh();
            if (_repaintAfterResize && bWasResizing) par_controlJ.Parent.Refresh();

            //Added 9/13/2019 td
            //if (SetBreakpoint_AfterMove) System.Diagnostics.Debugger.Break();

            //Added 8/5/2019 thomas downes
            if (bWasResizing) mod_groupedctl_events.Resizing_Terminate(par_iSave);

            //Added 9/13/2019 thomas downes
            // #1 Nov. 29 2021 //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate();
            // #2 Nov. 29 2021 //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate(par_controlJ);
            // 12/17/2021 td //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate(_controlMoveableElement);
            if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate(_controlMoveableElement, _iSaveToModel);

            //Added 11/29/2021 td
            //  Remove the object reference.
            //
            //--((--UnloadEventHandlers needs this reference.---Dec28 2021 td
            //--controlCurrent = null;

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
            // Added 12/15/2021 copied from 11/30/2021 code. --- Thomas Downes  
            //

            //''The minimal listing. 
            _controlCurrent.MouseDown -= (sender, e) => StartMovingOrResizing(_controlCurrent, e);

            // Dec17 2021//_controlCurrent.MouseUp -= (sender, e) => StopDragOrResizing(_controlCurrent);
            _controlCurrent.MouseUp -= (sender, e) => StopDragOrResizing(_controlCurrent, _iSaveToModel);
            _controlCurrent.MouseMove -= (sender, e) => MoveParentControl(_controlCurrent, e);

            //Added 1/4/2022 td

            _controlPictureBox1.MouseUp -= (sender, e) => StopDragOrResizing(_controlPictureBox1, _iSaveToModel);
            _controlPictureBox1.MouseMove -= (sender, e) => MoveParentControl(_controlPictureBox1, e);

            //Added 1/4/2022 td
            _controlPictureBox2.MouseUp -= (sender, e) => StopDragOrResizing(_controlPictureBox2, _iSaveToModel);
            _controlPictureBox2.MouseMove -= (sender, e) => MoveParentControl(_controlPictureBox2, e);

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