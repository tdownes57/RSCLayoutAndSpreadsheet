using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ciBadgeInterfaces; // Added 12/17/2021 td

/***
    ''
    ''   by Seyyed Hamed Monem
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

namespace MoveAndResizeControls_Monem
{
    public class ControlMove_GroupMove_TD
    {
        //
        //  internal class ControlMove_GroupMove
        //
        //  Class primarily authored by Seyyed Hamed Monem 
        //       https://www.codeproject.com/tips/709121/move-and-resize-controls-on-a-form-at-runtime-with 
        //       https://www.codeproject.com/info/cpol10.aspx
        //  This class was modified in August 2019 by Thomas C. Downes
        //

        private static bool _moving;
        private static bool _repaintAfterResize;  // Added 7/31/2019 td  
        /// </summary>
        private static Point _cursorStartPoint;
        private static bool _moveIsInterNal;
        private static bool _resizing;
        private static Size _currentControlStartSize;

        private static Control _controlCurrent; // Added 11/29/2021 td
        private static Control _controlPictureBox;  // = par_controlPictureB;
        private static Control _controlMoveableElement; // = par_containerElement;
        private static ISaveToModel _iSaveToModel;  // Added 12/17/2021 td

        //Added 7/18/2019 thomas downes
        //
        private static int _margin; //Added 7/18/2019 thomas downes

        internal static bool MouseIsInLeftEdge { get; set; }
        internal static bool MouseIsInRightEdge { get; set; }
        internal static bool MouseIsInTopEdge { get; set; }
        internal static bool MouseIsInBottomEdge { get; set; }

        internal static bool SetBreakpoint_AfterMove { get; set; } //Added 9/13/2019 td 

        internal enum MoveOrResize
        {
            Move,
            Resize,
            MoveAndResize
        }

        //Added 8/03/2019 thomas downes
        //
        internal static InterfaceEvents mod_groupedctl_events;

        internal static MoveOrResize WorkType { get; set; }

        public static void Init(Control par_controlA, int par_margin, bool pbRepaintAfterResize, 
                                 InterfaceEvents par_events, bool pbSetBreakpoint_AfterMove,
                                 ISaveToModel par_iSave)
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
            // Dec17 2021 //Init(par_controlA, par_controlA, par_margin, pbRepaintAfterResize, par_events, SetBreakpoint_AfterMove );
            Init(par_controlA, par_controlA, par_margin, pbRepaintAfterResize, par_events, SetBreakpoint_AfterMove, par_iSave);

        }

        public static void Init(Control par_controlImage, 
                                Control par_containerElement, 
                                int par_margin, bool pbRepaintAfterResize, 
                               InterfaceEvents par_events, bool pbSetBreakpoint_AfterMove, 
                               ISaveToModel par_iSave)
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
            _iSaveToModel = par_iSave;  // Added 12/17/2021 

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

            par_controlImage.MouseDown += (sender, e) => StartMovingOrResizing(par_controlImage, e);
            par_controlImage.MouseUp += (sender, e) => StopDragOrResizing(par_controlImage);

            //==-== Likely bug??  Notice that, toward the end of the line, it references
            //==   the parameter "par_containerElement".... which conflicts with "par_control"
            //==   (unless the other Init() signature was utilized... in which the parameter par_container
            //==   doesn't exist...
            //==      That other Init() passes par_control in both parameters of this
            //==   signature of Init()... namely, par_control & par_container).
            //==      On the other hand, it's the container's Top & Left properties
            //==    which has to be adjusted, in order to move both the container &
            //==    the graphic PictureBox control inside.  Confusing!! 
            //==         ---12/1/2021 thomas downes
            //
            //==//par_controlImage.MouseMove += (sender, e) => MoveControl(par_containerElement, e);
            par_controlImage.MouseMove += (sender, e) => MoveControl(par_containerElement, e);

            //Added 11/29/2021 td
            _controlCurrent = par_controlImage;
            _controlMoveableElement = par_containerElement;
            _controlPictureBox = par_controlImage;

        }

        private static void UpdateMouseEdgeProperties(Control par_controlC, Point mouseLocationInControl)
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

        private static void UpdateMouseCursor(Control par_controlD)
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

        private static void StartMovingOrResizing(Control par_controlE, MouseEventArgs e)
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

        private static void MoveControl(Control par_controlF, MouseEventArgs e)
        {
            //
            //Added 8/3/2019 thomas downes
            //
            if (mod_groupedctl_events != null) MoveControl_GroupMove(par_controlF, e);
            if (mod_groupedctl_events == null) MoveControl_NoEvents(par_controlF, e);

            //Added 11/29/2021 td
            _controlCurrent = par_controlF;

        }

        private static void MoveControl_GroupMove(Control par_controlG, MouseEventArgs e)
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

            if (_moving && (delta_Left != 0 || delta_Top != 0 ))
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


        private static void MoveControl_NoEvents(Control par_controlH, MouseEventArgs e)
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

        private static void StopDragOrResizing(Control par_controlJ)
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
            // Nov. 29 2021 //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate();
            // 12/17/2021 //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate(_controlMoveableElement);
            if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate(_controlMoveableElement, _iSaveToModel);

            //Added 11/29/2021 td
            //  Remove the object reference.
            _controlCurrent = null;

        }

        #region Save And Load

        private static List<Control> GetAllChildControls(Control control, List<Control> list)
        {
            List<Control> controls = control.Controls.Cast<Control>().ToList();
            list.AddRange(controls);
            return controls.SelectMany(ctrl => GetAllChildControls(ctrl, list)).ToList();
        }

        internal static string GetSizeAndPositionOfControlsToString(Control container)
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
        internal static void SetSizeAndPositionOfControlsFromString(Control container, string controlsInfoStr)
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


