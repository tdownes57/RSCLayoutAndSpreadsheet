using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ciBadgeInterfaces; // Added 12/17/2021 td

/***
    //
    //  This class is a copy of class ControlMoverOrResizer_TD,  
    //    with the keyword "static" removed.  
    //    ----11/29/2021 thomas downes
    //
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
    public class ControlMove_NonStatic_TD
    {
        //
        //  This class is a copy of class ControlMoverOrResizer_TD,  
        //    with the keyword "static" removed.  
        //    ----11/29/2021 thomas downes
        //
        //  Class primarily authored by Seyyed Hamed Monem 
        //       https://www.codeproject.com/tips/709121/move-and-resize-controls-on-a-form-at-runtime-with 
        //       https://www.codeproject.com/info/cpol10.aspx
        //  This class was modified in August 2019 by Thomas C. Downes
        //
        //
        private bool _moving;
        private bool _repaintAfterResize;  // Added 7/31/2019 td  
        /// </summary>
        private Point _cursorStartPoint;
        private bool _moveIsInterNal;
        private bool _resizing;
        private Size _currentControlStartSize;

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

        private Control _controlCurrent; // Added 11/29/2021 td
        private Control _controlPictureBox;  // = par_controlPictureB;
        private Control _controlMoveableElement; // = par_containerElement;
        private ISaveToModel _iSaveToModel;  //added 12/17/2021 td

        //Added 11/29/2021 thomas downes
        internal InterfaceEvents mod_eventsInterface;

        internal MoveOrResize WorkType { get; set; }

        public void Init(Control control, int par_margin, bool pbRepaintAfterResize, InterfaceEvents par_events, 
            bool pbSetBreakpoint_AfterMove, ISaveToModel par_iSave)
        {
            //  Added a new parameter, par_bRepaintAfterResize.   (Needed to apply 
            //     the preferred background color.)   ----7/31/2019 td
            //
            // 7-31-2019 td ----public void Init(Control control, int par_margin)
            //
            //Init(control, control);

            // 7-31-2019 td----Init(control, control, par_margin

            // 9-13-2019 td----Init(control, control, par_margin, pbRepaintAfterResize);

            // Dec. 3, 2021 //Init(control, control, par_margin, pbRepaintAfterResize,
            // Dec. 3, 2021 //       pbSetBreakpoint_AfterMove);
            
            Init(control, control, par_margin, pbRepaintAfterResize,
                   par_events, pbSetBreakpoint_AfterMove, par_iSave);

        }

        public void Init(Control par_control, Control par_container, int par_margin, 
            bool pbRepaintAfterResize, InterfaceEvents par_events, bool pbSetBreakpoint_AfterMove, 
            ISaveToModel par_iSave)
        {
            //  Added a new parameter, par_bRepaintAfterResize.   (Needed to apply 
            //     the preferred background color.)   ----7/31/2019 td
            //
            // 7-31-2019 td--public void Init(Control control, Control container, int par_margin)
            //
            //
            //   internal void Init(Control control, Control container)
            //
            _iSaveToModel = par_iSave;  // Dec17 2021 thomas d

            mod_eventsInterface = par_events;  // 12/3/2021 thomas downes   

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

            //==-== Likely bug.  Notice that it references "par_container"
            //   which conflicts with "par_control" (unless the other Init() signature
            //   was utilized... in which the par_container parameter doesn't exist...
            //   That other Init() passes par_control in both parameters of this
            //   signature of Init()... namely, par_control & par_container).
            //   ---12/1/2021 thomas downes
            //
            //==//par_control.MouseMove += (sender, e) => MoveControl(par_container, e);
            par_control.MouseMove += (sender, e) => MoveControl(par_control, e);
            par_control.MouseDown += (sender, e) => StartMovingOrResizing(par_control, e);
            par_control.MouseUp += (sender, e) => StopDragOrResizing(par_control);

            // Added 11/30/2021 thomas downes
            _controlCurrent = par_control;
            _controlMoveableElement = par_container;
            _controlPictureBox = par_control; 

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

            //''The minimal listing. 
            _controlCurrent.MouseDown -= (sender, e) => StartMovingOrResizing(_controlCurrent, e);
            _controlCurrent.MouseUp -= (sender, e) => StopDragOrResizing(_controlCurrent);
            _controlCurrent.MouseMove -= (sender, e) => MoveControl(_controlCurrent, e);

            //''
            //''More extensive listing. May fail, since not all of these
            //''   event handlers are created. 
            //''  
            _controlMoveableElement.MouseDown -= (sender, e) => StartMovingOrResizing(_controlMoveableElement, e);
            _controlMoveableElement.MouseUp -= (sender, e) => StopDragOrResizing(_controlMoveableElement);
            _controlMoveableElement.MouseMove -= (sender, e) => MoveControl(_controlMoveableElement, e);

            _controlPictureBox.MouseDown -= (sender, e) => StartMovingOrResizing(_controlPictureBox, e);
            _controlPictureBox.MouseUp -= (sender, e) => StopDragOrResizing(_controlPictureBox);
            _controlPictureBox.MouseMove -= (sender, e) => MoveControl(_controlPictureBox, e);

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
                if (MouseIsInTopEdge)
                {
                    control.Cursor = Cursors.SizeNWSE;
                }
                else if (MouseIsInBottomEdge)
                {
                    control.Cursor = Cursors.SizeNESW;
                }
                else
                {
                    control.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInRightEdge)
            {
                if (MouseIsInTopEdge)
                {
                    control.Cursor = Cursors.SizeNESW;
                }
                else if (MouseIsInBottomEdge)
                {
                    control.Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    control.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInTopEdge || MouseIsInBottomEdge)
            {
                control.Cursor = Cursors.SizeNS;
            }
            else
            {
                control.Cursor = Cursors.Default;
            }
        }

        private void StartMovingOrResizing(Control control, MouseEventArgs e)
        {
            if (_moving || _resizing)
            {
                return;
            }
            if (WorkType != MoveOrResize.Move &&
                (MouseIsInRightEdge || MouseIsInLeftEdge || MouseIsInTopEdge || MouseIsInBottomEdge))
            {
                _resizing = true;
                _currentControlStartSize = control.Size;
            }
            else if (WorkType != MoveOrResize.Resize)
            {
                _moving = true;
                control.Cursor = Cursors.Hand;
            }
            _cursorStartPoint = new Point(e.X, e.Y);
            control.Capture = true;
        }

        private void MoveControl(Control par_control, MouseEventArgs e)
        {
            if (!_resizing && !_moving)
            {
                UpdateMouseEdgeProperties(par_control, new Point(e.X, e.Y));
                UpdateMouseCursor(par_control);
            }
            if (_resizing)
            {
                if (MouseIsInLeftEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        par_control.Width -= (e.X - _cursorStartPoint.X);
                        par_control.Left += (e.X - _cursorStartPoint.X);
                        par_control.Height -= (e.Y - _cursorStartPoint.Y);
                        par_control.Top += (e.Y - _cursorStartPoint.Y);
                    }
                    else if (MouseIsInBottomEdge)
                    {
                        par_control.Width -= (e.X - _cursorStartPoint.X);
                        par_control.Left += (e.X - _cursorStartPoint.X);
                        par_control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                    }
                    else
                    {
                        par_control.Width -= (e.X - _cursorStartPoint.X);
                        par_control.Left += (e.X - _cursorStartPoint.X);
                    }
                }
                else if (MouseIsInRightEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        par_control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        par_control.Height -= (e.Y - _cursorStartPoint.Y);
                        par_control.Top += (e.Y - _cursorStartPoint.Y);

                    }
                    else if (MouseIsInBottomEdge)
                    {
                        par_control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        par_control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                    }
                    else
                    {
                        par_control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                    }
                }
                else if (MouseIsInTopEdge)
                {
                    par_control.Height -= (e.Y - _cursorStartPoint.Y);
                    par_control.Top += (e.Y - _cursorStartPoint.Y);
                }
                else if (MouseIsInBottomEdge)
                {
                    par_control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                }
                else
                {
                    StopDragOrResizing(par_control);
                }
            }
            else if (_moving)
            {
                _moveIsInterNal = !_moveIsInterNal;
                if (!_moveIsInterNal)
                {
                    int x = (e.X - _cursorStartPoint.X) + par_control.Left;
                    int y = (e.Y - _cursorStartPoint.Y) + par_control.Top;
                    par_control.Location = new Point(x, y);

                    //Added 12/6/2021 td
                    int intDeltaLeft = (e.X - _cursorStartPoint.X);
                    int intDeltaTop = (e.Y - _cursorStartPoint.Y);   
                    //mod_eventsInterface.GroupMove_Change(intDeltaLeft, intDeltaTop, 0, 0);

                }

                //Added 12/6/2021 thomas d. 
                //----mod_eventsInterface.Moving_InProgress();
                mod_eventsInterface.ControlBeingMoved(par_control);

            }
        }


        private void StopDragOrResizing(Control par_control)
        {
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

            //Added 8/5/2019 thomas downes
            if (bWasResizing) mod_eventsInterface.Resizing_Terminate(_iSaveToModel);

            //Added 9/13/2019 thomas downes
            // #1 Nov. 29 2021 //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate();
            // #2 Nov. 29 2021 //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate(par_controlJ);
            // Dec17 2021 // if (!(bWasResizing)) mod_eventsInterface.Moving_Terminate(_controlMoveableElement);
            if (!(bWasResizing)) mod_eventsInterface.Moving_Terminate(_controlMoveableElement, _iSaveToModel);

            //Added 11/29/2021 td
            //  Remove the object reference.
            _controlCurrent = null;


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
