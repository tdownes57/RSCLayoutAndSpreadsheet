  
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MoveAndResizeControls_Monem
{
    //
    //Added 8/2/2019 thomas downes  
    //

    public class ControlMove_RaiseEvents_NotUsed
    {
        //
        //  https://www.tutorialsteacher.com/csharp/csharp-event
        //
        public bool AreGroupOfElements;   //Added 8/2/2019 td  
        public delegate void GroupControlsMoved(int DeltaLeft, int DeltaTop, int DeltaWidth, int DeltaHeight);  //Added 8/2/2019 td
        public event GroupControlsMoved GroupMove;  //Added 8/2/2019 td

        //
        //  internal class ControlMoverOrResizer_TD
        //
        private bool _moving;
        private  bool _repaintAfterResize;  // Added 7/31/2019 td  
        /// </summary>
        private  Point _cursorStartPoint;
        private  bool _moveIsInterNal;
        private  bool _resizing;
        private  Size _currentControlStartSize;

        //Added 7/18/2019 thomas downes
        //
        private  int _margin; //Added 7/18/2019 thomas downes

        internal  bool MouseIsInLeftEdge { get; set; }
        internal  bool MouseIsInRightEdge { get; set; }
        internal  bool MouseIsInTopEdge { get; set; }
        internal  bool MouseIsInBottomEdge { get; set; }

        internal enum MoveOrResize
        {
            Move,
            Resize,
            MoveAndResize
        }

        internal  MoveOrResize WorkType { get; set; }

        public  void Init(Control control, int par_margin, bool pbRepaintAfterResize)
        {
            //  Added a new parameter, par_bRepaintAfterResize.   (Needed to apply 
            //     the preferred background color.)   ----7/31/2019 td
            //
            // 7-31-2019 td ----public  void Init(Control control, int par_margin)
            //
            //Init(control, control);

            // 7-31-2019 td----Init(control, control, par_margin

            Init(control, control, par_margin, pbRepaintAfterResize);
        }

        public  void Init(Control par_control, Control par_container, int par_margin, bool pbRepaintAfterResize)
        {
            //  Added a new parameter, par_bRepaintAfterResize.   (Needed to apply 
            //     the preferred background color.)   ----7/31/2019 td
            //
            // 7-31-2019 td--public  void Init(Control control, Control container, int par_margin)
            //
            //
            //   internal  void Init(Control control, Control container)
            //

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

        private  void UpdateMouseEdgeProperties(Control control, Point mouseLocationInControl)
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

        private  void UpdateMouseCursor(Control control)
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

        private  void StartMovingOrResizing(Control par_control, MouseEventArgs e)
        {
            if (_moving || _resizing)
            {
                return;
            }
            if (WorkType != MoveOrResize.Move &&
                (MouseIsInRightEdge || MouseIsInLeftEdge || MouseIsInTopEdge || MouseIsInBottomEdge))
            {
                _resizing = true;
                _currentControlStartSize = par_control.Size;
            }
            else if (WorkType != MoveOrResize.Resize)
            {
                _moving = true;
                par_control.Cursor = Cursors.Hand;
            }
            _cursorStartPoint = new Point(e.X, e.Y);
            par_control.Capture = true;
        }

        private void MoveControl(Control par_control, MouseEventArgs e)
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
                        delta_Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;

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
                        delta_Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
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
            if (delta_Height != 0 || delta_Left != 0 || delta_Top != 0 || delta_Width != 0)
            {
                //
                //Allow a group of controls to be affected in unison.   
                //
                const bool c_boolUseFunkyNewSyntax = false;
                if (c_boolUseFunkyNewSyntax)
                { 
                    GroupMove?.Invoke(delta_Left, delta_Top, delta_Width, delta_Height);
                }

                if (!c_boolUseFunkyNewSyntax)
                {
                    if (GroupMove != null) GroupMove.Invoke(delta_Left, delta_Top, delta_Width, delta_Height);
                }


            }

        }

        private  void StopDragOrResizing(Control par_control)
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

            //Added 10/14/2019 thomas downes
            //if (bWasResizing) mod_events.Resizing_Terminate();

            //Added 10/14/2019 thomas downes
            //if (!(bWasResizing)) mod_events.Moving_Terminate();

        }

        #region Save And Load

        private  List<Control> GetAllChildControls(Control control, List<Control> list)
        {
            List<Control> controls = control.Controls.Cast<Control>().ToList();
            list.AddRange(controls);
            return controls.SelectMany(ctrl => GetAllChildControls(ctrl, list)).ToList();
        }

        internal  string GetSizeAndPositionOfControlsToString(Control container)
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
        internal  void SetSizeAndPositionOfControlsFromString(Control container, string controlsInfoStr)
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
