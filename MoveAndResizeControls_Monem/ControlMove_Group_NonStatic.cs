using System;
//using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms; // Added 11/29/2021 thomas downes
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
    public class ControlMove_Group_NonStatic
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

        private bool _moving;
        private bool _repaintAfterResize;  // Added 7/31/2019 td  
        /// </summary>
        private Point _cursorStartPoint;
        private bool _moveIsInterNal;
        private bool _resizing;
        private Size _currentControlStartSize;

        private Control _controlCurrent; // Added 11/29/2021 td
        private Control _controlPictureBox;  // = par_controlPictureB;
        private Control _controlMoveableElement; // = par_containerElement;

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
        internal InterfaceEvents mod_groupedctl_events;

        internal MoveOrResize WorkType { get; set; }

        public void Init(Control par_controlA, int par_margin, bool pbRepaintAfterResize,
                                 InterfaceEvents par_events, bool pbSetBreakpoint_AfterMove)
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
            Init(par_controlA, par_controlA, par_margin, pbRepaintAfterResize, par_events, SetBreakpoint_AfterMove);

        }

        public void Init(Control par_controlPictureB, Control par_containerElement, 
                               int par_margin, bool pbRepaintAfterResize,
                               InterfaceEvents par_events, bool pbSetBreakpoint_AfterMove)
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

            SetBreakpoint_AfterMove = pbSetBreakpoint_AfterMove;  //Added 9/13/2019 td 

            mod_groupedctl_events = par_events;  // 8/3/2019 thomas downes   

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

            par_controlPictureB.MouseDown += (sender, e) => StartMovingOrResizing(par_controlPictureB, e);
            par_controlPictureB.MouseUp += (sender, e) => StopDragOrResizing(par_controlPictureB);
            par_controlPictureB.MouseMove += (sender, e) => MoveControl(par_containerElement, e);

            //Added 11/29/2021 td
            _controlCurrent = par_controlPictureB;
            _controlPictureBox = par_controlPictureB;
            _controlMoveableElement = par_containerElement;

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
                if (MouseIsInTopEdge)
                {
                    par_controlD.Cursor = Cursors.SizeNWSE;
                }
                else if (MouseIsInBottomEdge)
                {
                    par_controlD.Cursor = Cursors.SizeNESW;
                }
                else
                {
                    par_controlD.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInRightEdge)
            {
                if (MouseIsInTopEdge)
                {
                    par_controlD.Cursor = Cursors.SizeNESW;
                }
                else if (MouseIsInBottomEdge)
                {
                    par_controlD.Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    par_controlD.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInTopEdge || MouseIsInBottomEdge)
            {
                par_controlD.Cursor = Cursors.SizeNS;
            }
            else
            {
                par_controlD.Cursor = Cursors.Default;
            }

            //Added 11/29/2021 td
            _controlCurrent = par_controlD;

        }

        private void StartMovingOrResizing(Control par_controlE, MouseEventArgs e)
        {
            if (_moving || _resizing)
            {
                //
                //We are in the midst of one of the above above actions.   No Booleans need to be toggled on or off. 
                //
                return;
            }
            if (WorkType != MoveOrResize.Move &&
                (MouseIsInRightEdge || MouseIsInLeftEdge || MouseIsInTopEdge || MouseIsInBottomEdge))
            {
                //
                //We need to initiate the Resizing process. 
                //
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

        private void MoveControl(Control par_controlF, MouseEventArgs e)
        {
            //
            //Added 8/3/2019 thomas downes
            //
            if (mod_groupedctl_events != null) MoveControl_GroupMove(par_controlF, e);
            if (mod_groupedctl_events == null) MoveControl_NoEvents(par_controlF, e);

            //Added 11/29/2021 td
            _controlCurrent = par_controlF;

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
                    StopDragOrResizing(par_controlG);
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
                    StopDragOrResizing(par_controlH);
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

        private void StopDragOrResizing(Control par_controlJ)
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
            if (bWasResizing) mod_groupedctl_events.Resizing_Terminate();

            //Added 9/13/2019 thomas downes
            // #1 Nov. 29 2021 //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate();
            // #2 Nov. 29 2021 //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate(par_controlJ);
            if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate(_controlMoveableElement);

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