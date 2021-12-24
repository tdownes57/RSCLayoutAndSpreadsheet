using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ciBadgeInterfaces; // Added Dec17 2021 

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
    public class ControlMoverOrResizer_TD
    {
        //
        //  internal class ControlMoverOrResizer_TD
        //
        //
        //  Class primarily authored by Seyyed Hamed Monem 
        //       https://www.codeproject.com/tips/709121/move-and-resize-controls-on-a-form-at-runtime-with 
        //       https://www.codeproject.com/info/cpol10.aspx
        //  This class was modified in August 2019 by Thomas C. Downes
        //
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

        //Added 11/29/2021 thomas downes
        internal static InterfaceEvents mod_eventsInterface;

        internal static MoveOrResize WorkType { get; set; }

        public static void Init(Control control, int par_margin, bool pbRepaintAfterResize, bool pbSetBreakpoint_AfterMove, 
                ISaveToModel par_iSave)
        {
            //  Added a new parameter, par_bRepaintAfterResize.   (Needed to apply 
            //     the preferred background color.)   ----7/31/2019 td
            //
            // 7-31-2019 td ----public static void Init(Control control, int par_margin)
            //
            //Init(control, control);

            // 7-31-2019 td----Init(control, control, par_margin

            // 9-13-2019 td----Init(control, control, par_margin, pbRepaintAfterResize);

            Init(control, control, par_margin, pbRepaintAfterResize,
                pbSetBreakpoint_AfterMove, par_iSave);

        }
        

        public static void Init(Control par_control, Control par_containerElement,
            int par_margin, bool pbRepaintAfterResize, bool pbSetBreakpoint_AfterMove, 
            ISaveToModel par_iSave)
        {
            //  Added a new parameter, par_bRepaintAfterResize.   (Needed to apply 
            //     the preferred background color.)   ----7/31/2019 td
            //
            // 7-31-2019 td--public static void Init(Control control, Control container, int par_margin)
            //
            //
            //   internal static void Init(Control control, Control container)
            //

            _iSaveToModel = par_iSave;  // Added Dec17 2021
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

            //==-== Likely bug?? Notice that, toward the end of the line, it references
            //   the parameter "par_containerElement".... which conflicts with "par_control"
            //   (unless the other Init() signature was utilized... in which the parameter par_container
            //   doesn't exist...
            //      That other Init() passes par_control in both parameters of this
            //   signature of Init()... namely, par_control & par_container).
            //==      On the other hand, it's the container's Top & Left properties
            //==    which has to be adjusted, in order to move both the container &
            //==    the graphic PictureBox control inside.  Confusing!! 
            //   ---12/1/2021 thomas downes
            //
            //==//par_control.MouseMove += (sender, e) => MoveControl(par_containerElement, e);
            par_control.MouseMove += (sender, e) => MoveControl(par_containerElement, e);
        
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
            bool bWasResizing = _resizing; // Added 11/29/2021 td

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

            //Added 11/29/2021 thomas downes
            if (bWasResizing) mod_eventsInterface.Resizing_Terminate(_iSaveToModel);

            //Added 9/13/2019 thomas downes
            // #1 Nov. 29 2021 //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate();
            // #2 Nov. 29 2021 //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate(par_controlJ);
            // Dec17 2021 //if (!(bWasResizing)) mod_eventsInterface.Moving_Terminate(_controlMoveableElement);
            if (!(bWasResizing)) mod_eventsInterface.Moving_Terminate(_controlMoveableElement, _iSaveToModel);

            //Added 11/29/2021 td
            //  Remove the object reference.
            _controlCurrent = null;

        }

        private static void MoveControl(Control par_control, MouseEventArgs e)
        {
            //   Should the PictureBox control be passed here, or the user-control
            //   which contains the PictureBox control??  ---12/1/2021 td
            //
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

            //Added 9/13/2019 td
            if (SetBreakpoint_AfterMove) System.Diagnostics.Debugger.Break();

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