using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

/***
    ''
    ''seyyed hamed monem
    ''
    '' https://www.codeproject.com/tips/709121/move-and-resize-controls-on-a-form-at-runtime-with 
    ''
    ''    Move And Resize Controls on a Form at Runtime(With Mouse)
    ''
    ''    by Seyyed Hamed Monem
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
    public class ControlMove_Static_Resizer
    {
        //
        //  internal class ControlMoverOrResizer
        //
        private static bool _moving;
        private static Point _cursorStartPoint;
        private static bool _moveIsInterNal;
        private static bool _resizing;
        private static Size _currentControlStartSize;
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

        internal static MoveOrResize WorkType { get; set; }

        public static void Init(Control control)
        {
            //  internal static void Init(Control control)

            Init(control, control);
        }

        public static void Init(Control control, Control container)
        {
            //   internal static void Init(Control control, Control container)  

            _moving = false;
            _resizing = false;
            _moveIsInterNal = false;
            _cursorStartPoint = Point.Empty;
            MouseIsInLeftEdge = false;
            MouseIsInLeftEdge = false;
            MouseIsInRightEdge = false;
            MouseIsInTopEdge = false;
            MouseIsInBottomEdge = false;
            WorkType = MoveOrResize.MoveAndResize;
            control.MouseDown += (sender, e) => StartMovingOrResizing(control, e);
            control.MouseUp += (sender, e) => StopDragOrResizing(control);

            //==-== Likely bug??  Notice that, toward the end of the line, it references
            //   the parameter "par_containerElement".... which conflicts with "par_control"
            //   (unless the other Init() signature was utilized... in which the parameter par_container
            //   doesn't exist...
            //      That other Init() passes par_control in both parameters of this
            //   signature of Init()... namely, par_control & par_container).
            //   ---12/1/2021 thomas downes
            //
            //==//control.MouseMove += (sender, e) => MoveControl(container, e);
            control.MouseMove += (sender, e) => MoveControl(container, e);

        }

        private static void UpdateMouseEdgeProperties(Control control, Point mouseLocationInControl)
        {
            if (WorkType == MoveOrResize.Move)
            {
                return;
            }

            MouseIsInLeftEdge = Math.Abs(mouseLocationInControl.X) <= 2;
            MouseIsInRightEdge = Math.Abs(mouseLocationInControl.X - control.Width) <= 2;
            MouseIsInTopEdge = Math.Abs(mouseLocationInControl.Y) <= 2;
            MouseIsInBottomEdge = Math.Abs(mouseLocationInControl.Y - control.Height) <= 2;

            //MouseIsInLeftEdge = Math.Abs(mouseLocationInControl.X) <= _margin;
            //MouseIsInRightEdge = Math.Abs(mouseLocationInControl.X - control.Width) <= _margin;
            //MouseIsInTopEdge = Math.Abs(mouseLocationInControl.Y) <= 2;
            //MouseIsInBottomEdge = Math.Abs(mouseLocationInControl.Y - control.Height) <= 2;

        }

        private static void UpdateMouseCursor(Control control)
        {
            if (WorkType == MoveOrResize.Move)
            {
                return;
            }
            if (MouseIsInLeftEdge )
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
                return;
            }
            if (WorkType!=MoveOrResize.Move &&
                (MouseIsInRightEdge || MouseIsInLeftEdge || MouseIsInTopEdge || MouseIsInBottomEdge))
            {
                _resizing = true;
                _currentControlStartSize = control.Size;
            }
            else if (WorkType!=MoveOrResize.Resize)
            {
                _moving = true;
                control.Cursor = Cursors.Hand;
            }
            _cursorStartPoint = new Point(e.X, e.Y);
            control.Capture = true;
        }

        private static void MoveControl(Control control, MouseEventArgs e)
        {
            if (!_resizing && ! _moving)
            {
                UpdateMouseEdgeProperties(control, new Point(e.X, e.Y));
                UpdateMouseCursor(control);
            }
            if (_resizing)
            {
                if (MouseIsInLeftEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        control.Width -= (e.X - _cursorStartPoint.X);
                        control.Left += (e.X - _cursorStartPoint.X); 
                        control.Height -= (e.Y - _cursorStartPoint.Y);
                        control.Top += (e.Y - _cursorStartPoint.Y);
                    }
                    else if (MouseIsInBottomEdge)
                    {
                        control.Width -= (e.X - _cursorStartPoint.X);
                        control.Left += (e.X - _cursorStartPoint.X);
                        control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;                    
                    }
                    else
                    {
                        control.Width -= (e.X - _cursorStartPoint.X);
                        control.Left += (e.X - _cursorStartPoint.X) ;
                    }
                }
                else if (MouseIsInRightEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        control.Height -= (e.Y - _cursorStartPoint.Y);
                        control.Top += (e.Y - _cursorStartPoint.Y);

                    }
                    else if (MouseIsInBottomEdge)
                    {
                        control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;                    
                    }
                    else
                    {
                        control.Width = (e.X - _cursorStartPoint.X)+_currentControlStartSize.Width;
                    }
                }
                else if (MouseIsInTopEdge)
                {
                    control.Height -= (e.Y - _cursorStartPoint.Y);
                    control.Top += (e.Y - _cursorStartPoint.Y);
                }
                else if (MouseIsInBottomEdge)
                {
                    control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;                    
                }
                else
                {
                     StopDragOrResizing(control);
                }
            }
            else if (_moving)
            {
                _moveIsInterNal = !_moveIsInterNal;
                if (!_moveIsInterNal)
                {
                    int x = (e.X - _cursorStartPoint.X) + control.Left;
                    int y = (e.Y - _cursorStartPoint.Y) + control.Top;
                    control.Location = new Point(x, y);
                }
            }
        }

        private static void StopDragOrResizing(Control control)
        {
            _resizing = false;
            _moving = false;
            control.Capture = false;
            UpdateMouseCursor(control);
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
            string[] controlsInfo = controlsInfoStr.Split(new []{"*"},StringSplitOptions.RemoveEmptyEntries );
            Dictionary<string, string> controlsInfoDictionary = new Dictionary<string, string>();
            foreach (string controlInfo in controlsInfo)
            {
                string[] info = controlInfo.Split(new [] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                controlsInfoDictionary.Add(info[0], info[1]);
            }
            foreach (Control control in controls)
            {
                string propertiesStr;
                controlsInfoDictionary.TryGetValue(control.Name, out propertiesStr);
                string[] properties = propertiesStr.Split(new [] { "," }, StringSplitOptions.RemoveEmptyEntries);
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