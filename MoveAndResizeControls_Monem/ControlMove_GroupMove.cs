using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

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
    public class ControlMove_GroupMove
    {
        //
        //  internal class ControlMove_GroupMove
        //

        private static bool _moving;
        private static bool _repaintAfterResize;  // Added 7/31/2019 td  
        /// </summary>
        private static Point _cursorStartPoint;
        private static bool _moveIsInterNal;
        private static bool _resizing;
        private static Size _currentControlStartSize;

        //Added 7/18/2019 thomas downes
        //
        private static int _margin; //Added 7/18/2019 thomas downes

        internal static bool MouseIsInLeftEdge { get; set; }
        internal static bool MouseIsInRightEdge { get; set; }
        internal static bool MouseIsInTopEdge { get; set; }
        internal static bool MouseIsInBottomEdge { get; set; }

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

        public static void Init(Control control, int par_margin, bool pbRepaintAfterResize, InterfaceEvents par_events)
        {
            //  Added a new parameter, par_bRepaintAfterResize.   (Needed to apply 
            //     the preferred background color.)   ----7/31/2019 td
            //
            // 7-31-2019 td ----public static void Init(Control control, int par_margin)
            //
            //Init(control, control);

            // 7-31-2019 td----Init(control, control, par_margin

            // 8-03-2019 td//Init(control, control, par_margin, pbRepaintAfterResize);

            Init(control, control, par_margin, pbRepaintAfterResize, par_events);

        }

        public static void Init(Control par_control, Control par_container, int par_margin, bool pbRepaintAfterResize, InterfaceEvents par_events)
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

            par_control.MouseDown += (sender, e) => StartMovingOrResizing(par_control, e);
            par_control.MouseUp += (sender, e) => StopDragOrResizing(par_control);
            par_control.MouseMove += (sender, e) => MoveControl(par_container, e);
        }

        private static void UpdateMouseEdgeProperties(Control control, Point mouseLocationInControl)
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

        private static void UpdateMouseCursor(Control control)
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

        private static void StartMovingOrResizing(Control control, MouseEventArgs e)
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
                _currentControlStartSize = control.Size;
                mod_groupedctl_events.Resizing_Initiate(); //Added 8/5/2019 td 
            }
            else if (WorkType != MoveOrResize.Resize)
            {
                //
                //We need to initiate the Moving process. 
                //
                _moving = true;
                control.Cursor = Cursors.Hand;
            }

            _cursorStartPoint = new Point(e.X, e.Y);
            control.Capture = true;

            //
            //Added 8/4/2019 td
            //
            //ParentForm.ControlBeingMoved = control

        }

        private static void MoveControl(Control par_control, MouseEventArgs e)
        {
            //
            //Added 8/3/2019 thomas downes
            //
            if (mod_groupedctl_events != null) MoveControl_GroupMove(par_control, e);
            if (mod_groupedctl_events == null) MoveControl_NoEvents(par_control, e);

        }

        private static void MoveControl_GroupMove(Control par_control, MouseEventArgs e)
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

                        //Added 8/2/2019 thomas downes 
                        delta_Width = -1 * (e.X - _cursorStartPoint.X);
                        delta_Left = (e.X - _cursorStartPoint.X);
                        delta_Height = -1 * (e.Y - _cursorStartPoint.Y);
                        delta_Top = (e.Y - _cursorStartPoint.Y);
                    }
                    else if (MouseIsInBottomEdge)
                    {
                        par_control.Width -= (e.X - _cursorStartPoint.X);
                        par_control.Left += (e.X - _cursorStartPoint.X);
                        par_control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;

                        //Added 8/2/2019 thomas downes 
                        delta_Width = -1 * (e.X - _cursorStartPoint.X);
                        delta_Left = (e.X - _cursorStartPoint.X);
                        delta_Height = (e.Y - _cursorStartPoint.Y); // + _currentControlStartSize.Height;

                    }
                    else
                    {
                        par_control.Width -= (e.X - _cursorStartPoint.X);
                        par_control.Left += (e.X - _cursorStartPoint.X);

                        //Added 8/2/2019 thomas downes 
                        delta_Width = -1 * (e.X - _cursorStartPoint.X);
                        delta_Left = (e.X - _cursorStartPoint.X);
                    }
                }
                else if (MouseIsInRightEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        par_control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        par_control.Height -= (e.Y - _cursorStartPoint.Y);
                        par_control.Top += (e.Y - _cursorStartPoint.Y);

                        //Added 8/2/2019 thomas downes 
                        delta_Width = (e.X - _cursorStartPoint.X); // + _currentControlStartSize.Width;
                        delta_Height = -1 * (e.Y - _cursorStartPoint.Y);
                        delta_Top = (e.Y - _cursorStartPoint.Y);

                    }
                    else if (MouseIsInBottomEdge)
                    {
                        par_control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        par_control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;

                        //Added 8/2/2019 thomas downes 
                        delta_Width = (e.X - _cursorStartPoint.X);  //+ _currentControlStartSize.Width;
                        delta_Height = (e.Y - _cursorStartPoint.Y);  // + _currentControlStartSize.Height;
                    }
                    else
                    {
                        par_control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;

                        //Added 8/2/2019 thomas downes 
                        delta_Width = (e.X - _cursorStartPoint.X); // + _currentControlStartSize.Width;
                    }
                }
                else if (MouseIsInTopEdge)
                {
                    par_control.Height -= (e.Y - _cursorStartPoint.Y);
                    par_control.Top += (e.Y - _cursorStartPoint.Y);

                    //Added 8/2/2019 thomas downes 
                    delta_Height = -1 * (e.Y - _cursorStartPoint.Y);
                    delta_Top = (e.Y - _cursorStartPoint.Y);
                }
                else if (MouseIsInBottomEdge)
                {
                    par_control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;

                    //Added 8/2/2019 thomas downes 
                    delta_Height = (e.Y - _cursorStartPoint.Y);  //  + _currentControlStartSize.Height;
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
                    mod_groupedctl_events.ControlBeingMoved(par_control);
                    delta_Top = 0;
                    delta_Left = 0;
                    // 8-5-2019 td //mod_events.GroupMove(delta_Left, delta_Top, delta_Width, delta_Height);
                    mod_groupedctl_events.GroupMove_Change(delta_Left, delta_Top, delta_Width, delta_Height);

            }

            if (_moving && (delta_Left != 0 || delta_Top != 0 ))
            {
                   //
                   //Allow a group of controls to be affected in unison.   
                   //
                   mod_groupedctl_events.ControlBeingMoved(par_control);
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



        }


        private static void MoveControl_NoEvents(Control par_control, MouseEventArgs e)
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
                }
            }
        }

        private static void StopDragOrResizing(Control par_control)
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

            //Added 8/5/2019 thomas downes
            //
            if (bWasResizing) mod_groupedctl_events.Resizing_Terminate();

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


