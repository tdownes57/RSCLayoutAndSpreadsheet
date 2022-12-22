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
//12-20-2022 namespace MoveAndResizeControls_Monem //.Interfaces
namespace MoveAndResizeControls_Monem_Net70
{
    //
    // Added 2/2/2022 thomas downes
    //
    //public struct StructResizeParams_NotInUse //Not in use.  See public class ClassStructResizeParams
    //{
    //    //
    //    //Suffixed as "_NotInUse" on 3/4/2022 td.  See public class ClassStructResizeParams
    //    //
    //    // Added 2/2/2022 thomas downes
    //    //
    //    // Suffixed as "_NotInUse" on 3/4/2022 td
    //    //
    //    //  This will centralize the resizing information. ---2/2/2022 td
    //    //
    //    public bool KeepProportional_HtoW_NotInUse; //Not in use.  See public class ClassStructResizeParams
    //    //
    //    // Suffixed "_NotInUse" on 3/13/2022 td.  See public class ClassStructResizeParams
    //    //
    //    public float ProportionalRatio_HtoW_NotInUse;  // proportionWH
    //    // This will assist the layout program to enforcing a Width > Height rule. ---2/2/2022
    //    public bool KeepLandscape_WgtH;
    //    // This will assist the layout program to enforcing a Height > Width rule. ---2/2/2022
    //    public bool KeepPortrait_HgtW;
    //    //Added 3/13/2022 thomas Downes
    //    public bool InitiateResizing_NotInUse;  //Not in use.  See public class ClassStructResizeParams
    //    //Don't allow resizing.
    //    public bool StopAllResizing_NotInUse; //Not in use.  See public class ClassStructResizeParams
    //    //Repaint after resizing. 
    //    public bool RepaintAfterResize;
    //    //Only allow re-sizing of the right-hand edge.
    //    //   (No moving of the control allowed.)
    //    public bool RightEdgeResizing_Only;
    //}


    //
    // Added 11/29/2021 thomas downes 
    //
    public class MonemControlMove_AllFunctionality : IMonemMoveOrResizeFunctionality // InterfaceMoveOrResize
    {
        //ControlMove_Group_NonStatic : IMoveOrResizeFunctionality // InterfaceMoveOrResize
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
            get
            {
                // Added 3/3/2022 td
                //return this.ResizeParams.StopAllResizing;
                return _structResizingParams.StopAllResizing;
            }
            set
            {
                // Added 3/3/2022 td
                _structResizingParams.StopAllResizing = value;
            }

        }

        public bool RemoveProportionality // = false;  //Added 1/10/2022 td//
        {
            get
            {
                //Flip the Boolean value.  ----1/11/2022 td
                return (false == _SizeProportionally);
            }
            set
            {
                //Flip the Boolean value.  ----1/11/2022 td 
                _SizeProportionally = (false == value);
            }
        }

        public List<UserControl>? ListOfColumnsToBumpRight //Now nullable. 12/20/2022
        {
            //
            //Added 3/13/2022 tthhoommaass ddoowwnneess
            //
            //  //March13 2022 td//public List<Control> ColumnsToTheRight;  //Added 1/20/2022
            //  Formerly known as "ColumnsToTheRight". Renamed 3/13/2022 td
            //
            get;
            set;
        }


        public void AddColumnToBumpRight(UserControl par_column)
        {
            //
            // Added 4/1/2022 td
            //
            //''----If(Not mod_iMoveOrResizeFunctionality.ListOfColumnsToBumpRight.Contains(par_columnToBump)) Then
            //''----    mod_iMoveOrResizeFunctionality.AddBumpColumn(par_columnToBump)
            //''----End If

            if (ListOfColumnsToBumpRight == null) ListOfColumnsToBumpRight = new List<UserControl>();

            if (ListOfColumnsToBumpRight.Contains(par_column) == false)
            { 
                ListOfColumnsToBumpRight.Add(par_column);
            }

        }


        public void RemoveColumnToBumpRight(UserControl par_column)
        {
            //
            // Added 4/15/2022 td
            //

            if (ListOfColumnsToBumpRight == null) return; // ListOfColumnsToBumpRight = new List<UserControl>();

            if (ListOfColumnsToBumpRight.Contains(par_column))
            {
                ListOfColumnsToBumpRight.Remove(par_column);
            }

        }


        public void RemoveProportionalSizing()
        {
            //Added 1/10/2022 td
            _SizeProportionally = false;
        }

        private bool _moving = false; // Default value added 1/7/2022 td
        private bool _repaintAfterResize;  // Added 7/31/2019 td  
        /// </summary>
        private Point _cursorStartPoint;
        private bool _moveIsInterNal;
        private bool _resizing = false; // Default value added 1/7/2022 td
        private bool _resizingHeight = false; //A change of element height implies a possible change to font height.--Added 6/06/2022 td
        private Size _currentControlStartSize;

        //Added 1/10/2022 thomas downes
        private decimal _proportionWH; //Added 1/10/2022 thomas downes

        private Control? _controlCurrent; // Added 11/29/2021 td
        //''1/4/2022 td''private Control _controlPictureBox;  // = par_controlPictureB;
        private PictureBox? _controlPictureBox1;  // = par_controlPictureB;
        private PictureBox? _controlPictureBox2;  // = par_controlPictureB;
        private Control? _controlMoveableElement; // = par_containerElement;
        private ISaveToModel? _iSaveToModel;  // Added 12/17/2021 td
        private IRefreshElementImage? _iRefreshElementImage;  // Added 1/27/2022 td
        private IRefreshCardPreview? _iRefreshCardPreview;  // Added 1/27/2022 td
        private Label? _labelIfNeeded;  //Added 1/04/2022 thomas d.

        //Added 7/18/2019 thomas downes
        //
        private int _margin; //Added 7/18/2019 thomas downes

        internal bool MouseIsInLeftEdge { get; set; }
        internal bool MouseIsInRightEdge { get; set; }
        internal bool MouseIsInTopEdge { get; set; }
        internal bool MouseIsInBottomEdge { get; set; }

        internal bool SetBreakpoint_AfterMove { get; set; } //Added 9/13/2019 td 

        private bool _SizeProportionally = false;  //Added 1/10/2022 td
        //Dec2022
        private bool _SizeDisallowSquares = false;  //Added 2/2/2022 td
        //Dec2022
        private bool _SizeKeepHeightMoreThanWidth = true;  //Added 2/02/2022 td
        //Dec2022
        private bool _SizeKeepWidthMoreThanHeight = true;  //Added 2/02/2022 td
        private bool _bAllowMoves = true;  //Added 12-20-2022 

        //3/2/2022 //private StructResizeParams _structResizingParams;
        private ClassStructResizeParams _structResizingParams = new ClassStructResizeParams();
        public ClassStructResizeParams ResizeParams      //Added 2/2/2022 td 
        {
            get
            {
                return _structResizingParams;
            }
            set
            {
                _structResizingParams = value;
            }
        }

        private const bool mc_MonemEditsLocation = true; //Added 1/12/2022 td
        private const bool mc_MonemEditsLocation_TopAndLeft = true; //Added 1/12/2022 td

        // Added 2/20/2022 td
        //March13 2022 td//public List<Control> ColumnsToTheRight;  //Added 1/20/2022
        private Dictionary<Control, int> _dictColumnsStartingPositionLeft
            = new Dictionary<Control, int>();  //Added 1/20/2022

        internal enum MoveOrResize
        {
            Move,
            Resize,
            MoveAndResize
        }

        //Added 8/03/2019 thomas downes
        //
        //---internal InterfaceEvents mod_groupedctl_events;
        //Jan10 2022 td''public InterfaceMoveEvents mod_groupedctl_events;
        public InterfaceMoveEvents? mod_events_groupedCtls; //Modified Jan10 2022 td
        public InterfaceMoveEvents? mod_events_singleCtl;  //Added 1/10/2022 td

        private IRefreshElementImage? mod_iRefreshElementImage; //Added 6/6/2022 td

        internal MoveOrResize WorkType { get; set; }


        public void Init(Control par_controlA, int par_margin, bool pbRepaintAfterResize,
                                 InterfaceMoveEvents par_eventsForGroups,
                                 InterfaceMoveEvents par_eventsSingleCtl,
                                 bool pbSetBreakpoint_AfterMove,
                                 ISaveToModel par_iSave,
                                 bool pbUndoAndReverseEverything = false,
                                 bool pbHookUpEventHandlers = true,
                                 bool pbResizeProportionally = false,
                                 float par_proportionWH = 0)
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

            //Jan27 2022 ''Init(null, par_controlA, par_margin, pbRepaintAfterResize,
            //Dec20 2022 Init_V1(null, par_controlA, par_margin, pbRepaintAfterResize,
            PictureBox objBoxDummy = new PictureBox();
            objBoxDummy.Name = "Dummy_1957";
            Init_V1(objBoxDummy, par_controlA, par_margin, 
                    pbRepaintAfterResize,
                    par_eventsForGroups,
                    par_eventsSingleCtl,
                    SetBreakpoint_AfterMove,
                    par_iSave,
                    pbUndoAndReverseEverything,
                    pbHookUpEventHandlers,
                    pbResizeProportionally,
                    par_proportionWH);

        }


        public void Init_V1(PictureBox par_controlPictureB, Control par_containerElement,
                               int par_margin, bool pbRepaintAfterResize,
                               InterfaceMoveEvents par_eventsForGroups,
                               InterfaceMoveEvents par_eventsSingleCtl,
                               bool pbSetBreakpoint_AfterMove,
                               ISaveToModel par_iSave,
                               bool pbUndoAndReverseEverything = false,
                               bool pbHookUpEventHandlers = true,
                               bool pbResizeProportionally = false,
                               float par_proportionWH = 0)
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
            _SizeProportionally = pbResizeProportionally; //Added 1/12/2022 td

            //
            //Added 1/12/2022 & 10/09/2019 thomas downes 
            //
            if (par_proportionWH != 0) _proportionWH = (decimal)par_proportionWH;
            else _proportionWH = (decimal)par_containerElement.Width /
                            (decimal)par_containerElement.Height;

            //Dec28 //_iSaveToModel = par_iSave; //Added 12/17/2021 td
            //Dec20 2022 //if (pbUndoAndReverseEverything) _iSaveToModel = null; //Added 12/28/2021
            if (pbUndoAndReverseEverything) _bAllowMoves = false; //Modified 12/26/2022
            else
            {
                _bAllowMoves = true;  //Added 12/20/2022 
                _iSaveToModel = par_iSave;  //Added 12/28/2021
            }

            //Dec28 //_controlPictureBox = par_controlPictureB; //Added 12/27/2021 td
            if (pbUndoAndReverseEverything) { } //Dec2022 _controlPictureBox1 = null; //Added 12/28/2021
            else _controlPictureBox1 = par_controlPictureB; //Added 12/28/2021

            SetBreakpoint_AfterMove = pbSetBreakpoint_AfterMove;  //Added 9/13/2019 td 

            //Dec28 2021 //mod_groupedctl_events = par_events;  // 8/3/2019 thomas downes   
            if (pbUndoAndReverseEverything) { } //Dec2022 mod_events_groupedCtls = null; //Added 12/28/2021
            else mod_events_groupedCtls = par_eventsForGroups; //Added 12/28/2021

            //Added 1/10/2022 td
            if (pbUndoAndReverseEverything) { } //Dec2022 mod_events_singleCtl = null; //Added 1/10/2022
            else mod_events_singleCtl = par_eventsSingleCtl; //Added 1/10/2022

            _moving = false;
            _repaintAfterResize = pbRepaintAfterResize; //Added 7/31/2019 td 
            _resizing = false;
            _resizingHeight = false; //Added 6/6/2022 td
            _moveIsInterNal = false;
            _cursorStartPoint = Point.Empty;

            //
            //Added 7/18/2019 thomas downes 
            //
            _margin = par_margin;

            //
            //Added 6/6/2022 td 
            //
            mod_iRefreshElementImage = (IRefreshElementImage)par_containerElement;

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
                // 
                //Dec2022 _controlCurrent = null;  // par_controlPictureB;
                //Dec2022 _controlPictureBox1 = null; // par_controlPictureB;
                //Dec2022 _controlPictureBox2 = null; // par_controlPictureB;
                //Dec2022 _controlMoveableElement = null; // par_containerElement;
                //Dec2022 _labelIfNeeded = null;  //Added 1/4/2022 td
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


        public void Init_V2(PictureBox par_controlPictureB, Control par_containerElement,
                       int par_margin, bool pbRepaintAfterResize,
                       InterfaceMoveEvents par_eventsForGroups,
                       InterfaceMoveEvents par_eventsSingleCtl,
                       bool pbSetBreakpoint_AfterMove,
                       ISaveToModel par_iSave,
                       IRefreshElementImage par_iRefreshElementImage,
                       IRefreshCardPreview par_iRefreshCardPreview,
                       bool pbUndoAndReverseEverything = false,
                       bool pbHookUpEventHandlers = true,
                       bool pbResizeProportionally = false,
                       float par_proportionWH = 0)
        {
            //
            // Added 1/27/2022 thomas d.
            //
            _iRefreshElementImage = par_iRefreshElementImage;
            _iRefreshCardPreview = par_iRefreshCardPreview;

            //
            // Major call !!
            //
            Init_V1(par_controlPictureB, par_containerElement,
                par_margin, pbRepaintAfterResize,
                par_eventsForGroups,
                par_eventsSingleCtl,
                pbSetBreakpoint_AfterMove,
                par_iSave,
                pbUndoAndReverseEverything,
                pbHookUpEventHandlers,
                pbResizeProportionally,
                par_proportionWH);

        }


        public void Init_V3(PictureBox par_controlPictureB, Control par_containerElement,
               int par_margin,
               InterfaceMoveEvents par_eventsForGroups,
               InterfaceMoveEvents par_eventsSingleCtl,
               bool pbSetBreakpoint_AfterMove,
               ISaveToModel par_iSave,
               IRefreshElementImage par_iRefreshElementImage,
               IRefreshCardPreview par_iRefreshCardPreview,
               ClassStructResizeParams pobj_objectResizeParams,
               bool pbUndoAndReverseEverything = false,
               bool pbHookUpEventHandlers = true)
        {
            //
            // Added 2/02/2022 thomas d.
            //
            // This will assist the layout program to enforcing Height > Width
            //     (or  Width > Height) rules. 
            // 2/2/2022 td//_SizeDisallowSquares = pbResizeWithoutSquaring; //Added 2/2/2022 td
            
            _SizeKeepHeightMoreThanWidth = pobj_objectResizeParams.KeepPortrait_HgtW;
            _SizeKeepWidthMoreThanHeight = pobj_objectResizeParams.KeepLandscape_WgtH;
            _SizeDisallowSquares = (pobj_objectResizeParams.KeepPortrait_HgtW ||
                                    pobj_objectResizeParams.KeepLandscape_WgtH);

            //Added 3/13/2022 td
            if (!pobj_objectResizeParams.InitiateResizing) System.Diagnostics.Debugger.Break();

            // March3 2022 //_resizingParams = pstructResize;
            this.ResizeParams = pobj_objectResizeParams;

            Init_V2(par_controlPictureB, par_containerElement,
                par_margin,
                pobj_objectResizeParams.RepaintAfterResize,
                par_eventsForGroups,
                par_eventsSingleCtl,
                pbSetBreakpoint_AfterMove,
                par_iSave,
                par_iRefreshElementImage,
                par_iRefreshCardPreview,
                pbUndoAndReverseEverything,
                pbHookUpEventHandlers,
                pobj_objectResizeParams.KeepProportional_HtoW,
                pobj_objectResizeParams.ProportionalRatio_HtoW);

        }


        private void HookUpEventHandlers(Control par_controlToHook, Control par_container,
                       ISaveToModel par_iSave, bool pbUndoAndReverseEverything)
        {
            //
            // Hook up the event handlers.  
            //
            if (par_iSave == null) throw new NullReferenceException(); //Added 12/20/2022 
            _iSaveToModel = par_iSave; //Added 12/20/2022 

            if (pbUndoAndReverseEverything)
            {
                // Remove these EventHandlers. ---12/28/2021 td
                par_controlToHook.MouseDown -= (sender, e) => StartMovingOrResizing(par_controlToHook, e);
                par_controlToHook.MouseUp -= (sender, e) => StopDragOrResizingV1(par_controlToHook, _iSaveToModel);
                _bAllowMoves = false; //Added 12/20/2022

            }
            else
            {
                par_controlToHook.MouseDown += (sender, e) => StartMovingOrResizing(par_controlToHook, e);
                //Dec17 2021 td//par_controlPictureB.MouseUp += (sender, e) => StopDragOrResizing(par_controlToHook);
                //Jan4 2022 //if (par_controlToHook.MouseUp != null) throw new Exception("This MouseUp may already be assigned.");
                par_controlToHook.MouseUp += (sender, e) => StopDragOrResizingV1(par_controlToHook, _iSaveToModel);
                _bAllowMoves = true; //Added 12/20/2022

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
                _bAllowMoves = false;  //Added 12/20/2022 td

                if (_labelIfNeeded != null)
                {
                    _labelIfNeeded.MouseDown -= (sender, e) => StartMovingOrResizing(_labelIfNeeded, e);
                    // Yes, MoveParentControl(_controlMoveableElement is correct.... Jan4 2022 td
                    //Dec2022 _labelIfNeeded.MouseMove -= (sender, e) => MoveParentControl(_controlMoveableElement, e);
                    _labelIfNeeded.MouseMove -= (sender, e) => MoveParentControl((Control)sender, e);  // (null, e); // _controlMoveableElement, e);
                    _labelIfNeeded.MouseUp -= (sender, e) => StopDragOrResizingV1(_labelIfNeeded, _iSaveToModel);
                }
            }



        }


        public void AddMoveability_ViaLabel(Label par_label)
        {
            //
            // Added 1/4/2022 td 
            //
            if (par_label == null) throw new NullReferenceException();  //Added 12/20/2022
            if (_controlMoveableElement == null) throw new NullReferenceException();  //Added 12/20/2022
            if (_iSaveToModel == null) throw new NullReferenceException();  //Added 12/20/2022

            _bAllowMoves = true;  //Added 12/20/2022 td
            _labelIfNeeded = par_label;
            _labelIfNeeded.MouseDown += (sender, e) => StartMovingOrResizing(_labelIfNeeded, e);
            // Yes, MoveParentControl(_controlMoveableElement is correct.... Jan4 2022 td
            _labelIfNeeded.MouseMove += (sender, e) => MoveParentControl(_controlMoveableElement, e);
            _labelIfNeeded.MouseUp += (sender, e) => StopDragOrResizingV1(_labelIfNeeded, _iSaveToModel);

        }


        public void AddMoveability_ViaPictureBox(PictureBox par_pictureBox)
        {
            //
            // Added 1/4/2022 td 
            //
            _bAllowMoves = true; //Added 12/20/2022 thomas downes
            _controlPictureBox2 = par_pictureBox;
            _controlPictureBox2.MouseDown += (sender, e) => StartMovingOrResizing(_controlPictureBox2, e);
            // Yes, MoveParentControl(_controlMoveableElement is correct.... Jan4 2022 td
            _controlPictureBox2.MouseMove += (sender, e) => MoveParentControl(_controlMoveableElement, e);  // Yes, MoveParentControl(_controlMoveableElement
            _controlPictureBox2.MouseUp += (sender, e) => StopDragOrResizingV1(_controlPictureBox2, _iSaveToModel);

        }


        public void AddProportionality(float par_proportionWH)
        {
            //
            //Added 1/10/2022 thomas downes 
            //
            if (par_proportionWH != 0) _proportionWH = (decimal)par_proportionWH;
            else _proportionWH = (decimal)_controlPictureBox1.Width /
                            (decimal)_controlPictureBox1.Height;

            //Jan10 2022 td //this.RemoveProportionality = false;
            _SizeProportionally = true;

        }


        public void Reverse_Init()
        {
            //
            //Added 12/28/2021 td
            //
            //Not currentl used. Dec2022//const bool c_bReverseEverything = true;

            //
            //Major call !!
            //
            //Jan10 2022//Init(_controlPictureBox1, _controlMoveableElement, 0, _repaintAfterResize,
            //Jan10 2022//    mod_events_groupedCtls, false, _iSaveToModel, c_bReverseEverything);
            //Jan27 2022//  Init(_controlPictureBox1, _controlMoveableElement, 0, _repaintAfterResize,

            _bAllowMoves = false; //Set Boolean to false. 12/20/2022 

            //Dec2022 Not needed. Init_V2(_controlPictureBox1, _controlMoveableElement, 0, _repaintAfterResize,
            //    mod_events_groupedCtls,
            //    mod_events_singleCtl,
            //    false, _iSaveToModel,
            //    _iRefreshElementImage,
            //    _iRefreshCardPreview,
            //    c_bReverseEverything);

            //Null out the references. ----12/28/2021 td
            //
            //Dec2022 _controlPictureBox1 = null;
            //Dec2022 _controlPictureBox2 = null;
            //Dec2022 _controlMoveableElement = null;
            //Dec2022 _controlCurrent = null;
            //Dec2022 mod_events_groupedCtls = null;
            //Dec2022 _iSaveToModel = null;


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
            var event_blackhole = new GroupMoveEvents_Singleton(new DummyLayout(), false, c_yesBlackhole);

            //Let's put the blackhole into action!!  
            mod_events_groupedCtls = event_blackhole;

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
            mod_events_groupedCtls = par_sharedEventsObject;

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

            //Added 3/13/2022 thomas downes 
            if (!_structResizingParams.InitiateResizing) return;

            bool bCtlIsWideEnoughToAllowFullMargin; //Added 5/16/2022 
            bCtlIsWideEnoughToAllowFullMargin = (par_controlC.Width > (_margin * 4)); //Added 5/16/2022
            if (bCtlIsWideEnoughToAllowFullMargin)   //Added 5/16/2022
            {
                MouseIsInLeftEdge = Math.Abs(mouseLocationInControl.X) <= _margin;
                MouseIsInRightEdge = Math.Abs(mouseLocationInControl.X - par_controlC.Width) <= _margin;
            }
            else   //Added 5/16/2022
            {
                //
                // The control is narrow, so let's halve the margin that triggers
                //    the width-resizing. ---5/16/2022 td
                //
                MouseIsInLeftEdge = Math.Abs(mouseLocationInControl.X) <= (_margin / 2); // 5/16/2022 _margin;
                MouseIsInRightEdge = Math.Abs(mouseLocationInControl.X - par_controlC.Width) <= (_margin / 2); // 5/16/2022 _margin;
            }


            bool bCtlIsTallEnoughToAllowFullMargin; //Added 5/16/2022 
            bCtlIsTallEnoughToAllowFullMargin = (par_controlC.Height > (_margin * 4)); //Added 5/16/2022
            if (bCtlIsTallEnoughToAllowFullMargin)   //Added 5/16/2022
            {
                MouseIsInTopEdge = Math.Abs(mouseLocationInControl.Y) <= _margin;
                MouseIsInBottomEdge = Math.Abs(mouseLocationInControl.Y - par_controlC.Height) <= _margin;
            }
            else   //Added 5/16/2022
            {
                //
                // The control is rather short, so let's halve the margin that triggers
                //     the height-resizing. ---5/16/2022 td
                //
                MouseIsInTopEdge = Math.Abs(mouseLocationInControl.Y) <= (_margin / 2); // 5/16/2022 _margin;
                MouseIsInBottomEdge = Math.Abs(mouseLocationInControl.Y - par_controlC.Height) <= (_margin / 2); // 5/16/2022 _margin;
            }


            //Added 11/29/2021 td
            _controlCurrent = par_controlC;

        }

        private void UpdateMouseCursor(Control par_controlD)
        {
            if (WorkType == MoveOrResize.Move)
            {
                //
                // We are currently moving the control.  No need to change the mouse cursor.
                //
                return;
            }

            if (MouseIsInLeftEdge)
            {
                //Added 3/13/2022 thomas downes 
                if (!_structResizingParams.InitiateResizing) return; //Return, i.e. Stop the resizing process!! 
                // March3 2022 //if (this.RemoveSizeability) return; //Return, i.e. Stop the resizing process!!  Added 12/29/2021 td
                if (this.RemoveSizeability) return; //Return, i.e. Stop the resizing process!!---Restored 3/13/2022
                if (_structResizingParams.StopAllResizing) return; //Return, i.e. Stop the resizing process!!  Added 12/29/2021 td
                if (_structResizingParams.RightEdgeResizing_Only) return; //Return, i.e. Stop the resizing process!!  Added 3/3/2022

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
                    //Mouse is at the Left Edge.
                    //  ---3/13/2022
                    par_controlD.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInRightEdge)
            {
                //Added 3/13/2022 thomas downes 
                if (!_structResizingParams.InitiateResizing) return; //Return, i.e. Stop the resizing process!! 
                // March3 2022 //if (RemoveSizeability) return; //Return, i.e. Stop the resizing process!!  Added 12/29/2021 td
                if (_structResizingParams.StopAllResizing) return; //Return, i.e. Stop the resizing process!!  Added 12/29/2021 td
                if (RemoveSizeability) return; //Return, i.e. Stop the resizing process!!  Restored 3/13/2022 & added 12/29/2021 td

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
                    //Mouse is at the Right Edge.
                    //  ---3/13/2022
                    par_controlD.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInTopEdge || MouseIsInBottomEdge)
            {
                //Added 3/13/2022 thomas downes 
                if (!_structResizingParams.InitiateResizing) return; //Return, i.e. Stop the resizing process!! 

                if (RemoveSizeability) return; //Return, i.e. Stop the resizing process!!  Added 12/29/2021 td
                if (_structResizingParams.StopAllResizing) return; //Return, i.e. Stop the resizing process!!  Added 12/29/2021 td
                if (_structResizingParams.RightEdgeResizing_Only) return; //Return, i.e. Stop the resizing process!!  Added 3/3/2022

                //Mouse is at the Top & Bottom Edge... i.e. the TopRight corner.
                par_controlD.Cursor = Cursors.SizeNS;
            }
            else
            {
                //Mouse is likely well inside the control & not close to any edge.
                //  ---3/13/2022
                par_controlD.Cursor = Cursors.Default;
            }

            //Added 11/29/2021 td
            _controlCurrent = par_controlD;

        }


        public void StartMovingOrResizing(Control par_controlE, MouseEventArgs par_eMouse)
        {
            //
            //Added by the programmer Monem, long before 12/28/2021.  ---12/28/2021 thomas downes
            //
            if (RemoveAllFunctionality) return; //Added 12/28/2021 td
            if (false == _bAllowMoves) return; //Added 12/20/2022 thomas d.

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
            // ''//''Might be causing moveability problems. Jan10 2022
            UpdateMouseEdgeProperties(par_controlE, new Point(par_eMouse.X, par_eMouse.Y));

            //
            // Initiate resizing or moving, as the case may be. ---1/11/2022 td
            //
            if (WorkType != MoveOrResize.Move &&
                (MouseIsInRightEdge || MouseIsInLeftEdge || MouseIsInTopEdge || MouseIsInBottomEdge))
            {
                //
                //We need to initiate the Resizing process. 
                //
                if (false == _structResizingParams.InitiateResizing) return; //Return, i.e. Stop the resizing process!! --3/13/2022
                if (RemoveSizeability) return; //Return, i.e. Stop the resizing process!!  Added 12/29/2021 td
                if (_structResizingParams.StopAllResizing) return; //Return, i.e. Stop the resizing process!!  Added 3/03/2022 td
                if (_structResizingParams.RightEdgeResizing_Only && !MouseIsInRightEdge) return; //Return, i.e. Stop the resizing process!!  Added 3/03/2022 td

                _resizing = true;
                _resizingHeight = (MouseIsInTopEdge || MouseIsInBottomEdge);  //Added 6/6/2022

                _currentControlStartSize = par_controlE.Size;

                // Added 2/21/2022 td
                _dictColumnsStartingPositionLeft = new Dictionary<Control, int>();

                if (this.ListOfColumnsToBumpRight != null)
                    foreach (Control each_column in this.ListOfColumnsToBumpRight)
                        _dictColumnsStartingPositionLeft.Add(each_column, each_column.Left);

                // 1-10-2022 //mod_events.Resizing_Initiate(); //Added 1/10/2022 td 
                mod_events_singleCtl.Resizing_Initiate(); //Added 1/10/2022 td 
                if (mod_events_groupedCtls != null)
                    mod_events_groupedCtls.Resizing_Initiate(); //Added 8/5/2019 td 

            }

            else if (WorkType != MoveOrResize.Resize)
            {
                //
                //We need to initiate the Moving process. 
                //
                _moving = true;
                par_controlE.Cursor = Cursors.Hand;
            }

            _cursorStartPoint = new Point(par_eMouse.X, par_eMouse.Y);
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
            //--(--Not needed, causes problems here (e.g. the Update functions
            //--(--  are never called). ---1/12/2022 td 
            //--if (!(_moving || _resizing)) return; //Added 1/11/2022 td 

            //Renamed 1/4/2022 td
            //Added 8/3/2019 thomas downes
            //
            //   Should the PictureBox control be passed here (above parameter), or the user-control
            //     which contains the PictureBox control??  The latter, let's pass the user-control
            //     which is the Parent of the PictureBox. ---12/1/2021 td
            //
            // Jan11 2022 ''if (mod_events_groupedCtls != null)
            if (mod_events_groupedCtls != null || mod_events_singleCtl != null)
            {
                MoveControl_GroupMove(par_controlParentF, e);

                //Added 12/6/2021 td
                mod_events_groupedCtls.Control_IsMoving();

            }
            if (mod_events_groupedCtls == null)
            {
                MoveControl_NoEvents(par_controlParentF, e);
            }

            //Added 11/29/2021 td
            _controlCurrent = par_controlParentF;

        }


        public void ClickedParentControl(Control par_controlParentF, MouseEventArgs e)
        {
            //
            // Added 9/01/2022 thomas downes
            //
            if (mod_events_groupedCtls != null)
            {
                //Added 9/01/2021 td
                mod_events_groupedCtls.Control_WasClicked(par_controlParentF);
            }


        }

        private void MoveControl_GroupMove(Control par_controlG, MouseEventArgs par_e)
        {
            //
            //Modified 8/2/2019 thomas downes  
            //
            if (_bAllowMoves == false) return; //Added 12/20/2022 

            int delta_Width = 0;
            int delta_Height = 0;
            int delta_Left = 0;
            int delta_Top = 0;
            bool bEditedLocation = false; //Added 1/12/2022 td

            //Added 10/14/2019 td
            bool bMouseIsInRightEdge_Only = false;
            bool bMouseIsInTopEdge_Only = false;
            bool bMouseIsInBottomEdge_Only = false;
            bool bMouseIsInLeftEdge_Only = false;

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
                UpdateMouseEdgeProperties(par_controlG, new Point(par_e.X, par_e.Y));
                UpdateMouseCursor(par_controlG);
                return; //Added 1/12/2022 td
            }

            if (_resizing)
            {
                if (MouseIsInLeftEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        par_controlG.Width -= (par_e.X - _cursorStartPoint.X);
                        par_controlG.Left += (par_e.X - _cursorStartPoint.X);
                        par_controlG.Height -= (par_e.Y - _cursorStartPoint.Y);
                        par_controlG.Top += (par_e.Y - _cursorStartPoint.Y);

                        //Added 8/2/2019 thomas downes 
                        delta_Width = -1 * (par_e.X - _cursorStartPoint.X);
                        delta_Left = (par_e.X - _cursorStartPoint.X);
                        delta_Height = -1 * (par_e.Y - _cursorStartPoint.Y);
                        delta_Top = (par_e.Y - _cursorStartPoint.Y);
                    }
                    else if (MouseIsInBottomEdge)
                    {
                        par_controlG.Width -= (par_e.X - _cursorStartPoint.X);
                        par_controlG.Left += (par_e.X - _cursorStartPoint.X);
                        par_controlG.Height = (par_e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;

                        //Added 8/2/2019 thomas downes 
                        delta_Width = -1 * (par_e.X - _cursorStartPoint.X);
                        delta_Left = (par_e.X - _cursorStartPoint.X);
                        delta_Height = (par_e.Y - _cursorStartPoint.Y); // + _currentControlStartSize.Height;

                    }
                    else
                    {
                        //
                        //Left-hand edge only.  (No other edges are in play.) 
                        //
                        bMouseIsInLeftEdge_Only = true; //Added 1/10/2022

                        par_controlG.Width -= (par_e.X - _cursorStartPoint.X);
                        par_controlG.Left += (par_e.X - _cursorStartPoint.X);

                        //Added 8/2/2019 thomas downes 
                        delta_Width = -1 * (par_e.X - _cursorStartPoint.X);
                        delta_Left = (par_e.X - _cursorStartPoint.X);
                    }
                }
                else if (MouseIsInRightEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        par_controlG.Width = (par_e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        par_controlG.Height -= (par_e.Y - _cursorStartPoint.Y);
                        par_controlG.Top += (par_e.Y - _cursorStartPoint.Y);

                        //Added 8/2/2019 thomas downes 
                        delta_Width = (par_e.X - _cursorStartPoint.X); // + _currentControlStartSize.Width;
                        delta_Height = -1 * (par_e.Y - _cursorStartPoint.Y);
                        delta_Top = (par_e.Y - _cursorStartPoint.Y);

                    }
                    else if (MouseIsInBottomEdge)
                    {
                        par_controlG.Width = (par_e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        par_controlG.Height = (par_e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;

                        //Added 8/2/2019 thomas downes 
                        delta_Width = (par_e.X - _cursorStartPoint.X);  //+ _currentControlStartSize.Width;
                        delta_Height = (par_e.Y - _cursorStartPoint.Y);  // + _currentControlStartSize.Height;

                    }
                    else
                    {
                        //
                        //Right-hand edge only.  (No other edges are in play.) 
                        //
                        bMouseIsInRightEdge_Only = true; //Added 1/10/2022

                        par_controlG.Width = (par_e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;

                        //Added 8/2/2019 thomas downes 
                        delta_Width = (par_e.X - _cursorStartPoint.X); // + _currentControlStartSize.Width;

                        //Added 2/20/2022 td
                        if (ListOfColumnsToBumpRight != null)
                        {
                            foreach (Control each_column in ListOfColumnsToBumpRight)
                            {
                                if (each_column == _controlCurrent) throw new Exception("self reference");
                                if (each_column == _controlMoveableElement) throw new Exception("self reference");

                                //
                                //Push columns to the left.  ---2/20/2022 td 
                                //
                                //----each_column.Left += (par_e.X - _cursorStartPoint.X);
                                each_column.Left = (par_e.X - _cursorStartPoint.X) +
                                    _dictColumnsStartingPositionLeft[each_column];
                            }
                        }


                    }
                }
                else if (MouseIsInTopEdge)
                {
                    //
                    //Top edge only.  (No other edges are in play.) 
                    //
                    bMouseIsInTopEdge_Only = true; //Added 1/10/2022

                    par_controlG.Height -= (par_e.Y - _cursorStartPoint.Y);
                    par_controlG.Top += (par_e.Y - _cursorStartPoint.Y);

                    //Added 8/2/2019 thomas downes 
                    delta_Height = -1 * (par_e.Y - _cursorStartPoint.Y);
                    delta_Top = (par_e.Y - _cursorStartPoint.Y);
                }
                else if (MouseIsInBottomEdge)
                {
                    //
                    //Bottom edge only.  (No other edges are in play.) 
                    //
                    bMouseIsInBottomEdge_Only = true; //Added 1/10/2022

                    par_controlG.Height = (par_e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;

                    //Added 8/2/2019 thomas downes 
                    delta_Height = (par_e.Y - _cursorStartPoint.Y);  //  + _currentControlStartSize.Height;
                }
                else
                {
                    // Dec17 2021 //StopDragOrResizing(par_controlG);
                    StopDragOrResizingV1(par_controlG, _iSaveToModel);
                }


                //Control the proportionality.
                //    ----10/14/2019
                //
                if (_SizeProportionally)
                {
                    //
                    // Enforce (or "control", "check") proportionalilty of Width & Height.
                    //    ----1/10/2022 thomas d. 
                    //
                    ControlProportionality(par_controlG,
                            bMouseIsInTopEdge_Only, bMouseIsInBottomEdge_Only,
                            bMouseIsInLeftEdge_Only, bMouseIsInRightEdge_Only);

                }


            } //end of "if (_resizing)"

            else if (_moving)
            {
                // Why toggle this Boolean value? ---8/6/2022 td
                _moveIsInterNal = !_moveIsInterNal;

                if (!_moveIsInterNal)
                {
                    //
                    // Calculate the new location !!!!!-----1/11/2022 td
                    //
                    int newLocation_x = (par_e.X - _cursorStartPoint.X) + par_controlG.Left;
                    int newLocation_y = (par_e.Y - _cursorStartPoint.Y) + par_controlG.Top;

                    //
                    // Huge!!!!!!   Moves the control !!!!!!!
                    //
                    if (mc_MonemEditsLocation)
                    {
                        //
                        // Encapsulated 1/13/2022 td
                        //
                        MoveControl_EditLocation(par_controlG, newLocation_x,
                            newLocation_y, ref bEditedLocation);

                        //if (mc_MonemEditsLocation_TopAndLeft)
                        //{
                        //    //We will edit .Left and .Top, instead of the .Location property.
                        //    par_controlG.Left = newLocation_x;
                        //    par_controlG.Top = newLocation_y;
                        //}
                        //else
                        //{
                        //    //We will edit .Location, instead of the .Top & Left properties.
                        //    par_controlG.Location = new Point(newLocation_x, newLocation_y);
                        //}

                        // We will inform outside entities that the .Location property (or .Top/.Left)
                        //   that the parent control's Location has been adjusted/moved. 
                        //   ----1/12/2022 td
                        //--)----Now encapsulated w/ keyword "ref". 1/13/2022 td 
                        //--)--bEditedLocation = true;

                    }

                    //Added 8/2/2019 thomas downes 
                    delta_Left = (par_e.X - _cursorStartPoint.X);
                    delta_Top = (par_e.Y - _cursorStartPoint.Y);

                    //Added 12/6/2021 td 
                    // Jan10 2022 td//mod_events.ControlBeingMoved(par_controlG);
                    mod_events_singleCtl.ControlBeingMoved(par_controlG);
                    if (mod_events_groupedCtls != null)
                    {
                        mod_events_groupedCtls.ControlBeingMoved(par_controlG);
                    }
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
                mod_events_groupedCtls.ControlBeingMoved(par_controlG);

                // 8-12-2019 td//delta_Top = 0;
                // 8-12-2019 td//delta_Left = 0;

                // 8-5-2019 td //mod_events.GroupMove(delta_Left, delta_Top, delta_Width, delta_Height);
                // 1-10-2022 td//mod_events.GroupMove_Change(delta_Left, delta_Top, delta_Width, delta_Height);
                // 1-12-2022 td//mod_events_singleCtl.GroupMove_Change(delta_Left, delta_Top, delta_Width, delta_Height);
                mod_events_singleCtl.GroupMove_Change(delta_Left, delta_Top,
                                                        delta_Width, delta_Height,
                                                        bEditedLocation);

                if (mod_events_groupedCtls != null)
                {
                    // 1-12-2022 td//mod_events_groupedCtls.GroupMove_Change(delta_Left, delta_Top, delta_Width, delta_Height);
                    mod_events_groupedCtls.GroupMove_Change(delta_Left, delta_Top,
                                                           delta_Width, delta_Height, 
                                                           bEditedLocation);
                }

                // Added 1/11/2022 td
                //===/===No, this should start at the MouseDown() event.----1/11/2022 td 
                //=== _cursorStartPoint = new Point(par_e.X, par_e.Y);

            }

            if (_moving && (delta_Left != 0 || delta_Top != 0))
            {
                //
                //Allow a group of controls to be affected in unison.   
                //
                if (mod_events_groupedCtls != null)
                    mod_events_groupedCtls.ControlBeingMoved(par_controlG);
                delta_Width = 0;
                delta_Height = 0;

                // 8-5-2019 td //mod_events.GroupMove(delta_Left, delta_Top, delta_Width, delta_Height);
                // 1-10-2022 td//mod_events.GroupMove_Change(delta_Left, delta_Top, delta_Width, delta_Height);
                if (mod_events_singleCtl != null)
                    mod_events_singleCtl.GroupMove_Change(delta_Left, delta_Top, delta_Width, delta_Height, bEditedLocation);

                if (mod_events_groupedCtls != null)
                {
                    mod_events_groupedCtls.GroupMove_Change(delta_Left, delta_Top, delta_Width, delta_Height, bEditedLocation);
                }

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
            //
            // Don't issue events.  ---1/10/2022 td
            //
            if (!_resizing && !_moving)
            {
                UpdateMouseEdgeProperties(par_controlH, new Point(e.X, e.Y));
                UpdateMouseCursor(par_controlH);
                return; //Added 1/12/2022 td
            }
            if (_resizing)
            {
                //
                //Encapsulated 1/13/2022 td
                //
                ResizeControl_NoEvents(par_controlH, e);



                //if (MouseIsInLeftEdge)
                //{
                //    if (MouseIsInTopEdge)
                //    {
                //        par_controlH.Width -= (e.X - _cursorStartPoint.X);
                //        par_controlH.Left += (e.X - _cursorStartPoint.X);
                //        par_controlH.Height -= (e.Y - _cursorStartPoint.Y);
                //        par_controlH.Top += (e.Y - _cursorStartPoint.Y);
                //    }
                //    else if (MouseIsInBottomEdge)
                //    {
                //        par_controlH.Width -= (e.X - _cursorStartPoint.X);
                //        par_controlH.Left += (e.X - _cursorStartPoint.X);
                //        par_controlH.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                //    }
                //    else
                //    {
                //        par_controlH.Width -= (e.X - _cursorStartPoint.X);
                //        par_controlH.Left += (e.X - _cursorStartPoint.X);
                //    }
                //}
                //else if (MouseIsInRightEdge)
                //{
                //    if (MouseIsInTopEdge)
                //    {
                //        par_controlH.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                //        par_controlH.Height -= (e.Y - _cursorStartPoint.Y);
                //        par_controlH.Top += (e.Y - _cursorStartPoint.Y);

                //    }
                //    else if (MouseIsInBottomEdge)
                //    {
                //        par_controlH.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                //        par_controlH.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                //    }
                //    else
                //    {
                //        par_controlH.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                //    }
                //}
                //else if (MouseIsInTopEdge)
                //{
                //    par_controlH.Height -= (e.Y - _cursorStartPoint.Y);
                //    par_controlH.Top += (e.Y - _cursorStartPoint.Y);
                //}
                //else if (MouseIsInBottomEdge)
                //{
                //    par_controlH.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                //}
                //else
                //{
                //    //Dec17 2021 td//StopDragOrResizing(par_controlH);
                //    StopDragOrResizing(par_controlH, _iSaveToModel);
                //}

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


        private void MoveControl_EditLocation(Control par_controlG,
                          int newLocation_x,
                          int newLocation_y,
                          ref bool pbEditedLocation)
        {
            //
            // Encapsulated 1//13/2022 td
            //
            //
            // Huge!!!!!!   Moves the control !!!!!!!
            //
            if (mc_MonemEditsLocation)
            {
                if (mc_MonemEditsLocation_TopAndLeft)
                {
                    //We will edit .Left and .Top, instead of the .Location property.
                    par_controlG.Left = newLocation_x;
                    par_controlG.Top = newLocation_y;
                }
                else
                {
                    //We will edit .Location, instead of the .Top & Left properties.
                    par_controlG.Location = new Point(newLocation_x, newLocation_y);
                }

                // We will inform outside entities that the .Location property (or .Top/.Left)
                //   that the parent control's Location has been adjusted/moved. 
                //   ----1/12/2022 td
                pbEditedLocation = true;
            }


        }


        private void ResizeControl_NoEvents(Control par_controlH, MouseEventArgs e)
        {
            //
            // Don't issue events.  ---1/10/2022 td
            //
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

                    //Added 2/20/2022 td
                    if (this.ListOfColumnsToBumpRight != null)
                    {
                        foreach (Control each_column in ListOfColumnsToBumpRight)
                        {
                            //Push columns to the left. ---2/20/2022 td 
                            //   ----each_column.Left += (e.X - _cursorStartPoint.X);
                            each_column.Left = (e.X - _cursorStartPoint.X) +
                                   _dictColumnsStartingPositionLeft[each_column];

                        }
                    }

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
                if (_iSaveToModel == null) throw new NullReferenceException(); //Added 12/21/2022
                StopDragOrResizingV1(par_controlH, _iSaveToModel);
            }

            //
            //Added 12/21/2022 Thomas downes
            //   Limit the resizing that can be done. 
            //
            //   For example, disallowing Squares (if requested via module Boolean)
            //   For example, disallowing Tall (or Narrow) shapes (if requested via module Boolean)
            //   For example, disallowing Short (or Fat) shapes (if requested via module Boolean)
            //
            bool bWasNarrowBefore; //Added 12/2022
            bool bWasFatBefore; //Added 12/2022
            bool bWasShortBefore; //Added 12/2022
            bool bWasTallBefore; //Added 12/2022

            //if (_SizeDisallowSquares)
            if (_SizeDisallowSquares || _SizeKeepHeightMoreThanWidth) //  #1 of 8.
            {
                //
                // Disallowing Squares 
                //
                //if (_SizeDisallowSquares) [See same condition, line 1548 on 12/21/2022.]
                if (MouseIsInLeftEdge && (e.X < _cursorStartPoint.X)) // User is expanding the Left edge leftward.
                {
                    // User is expanding the Left edge outward.  Check to see if we need to
                    //   keep the shape narrow (if it's fat now, whereas it used to be narrow).
                    //   (If it's fat now & it used to be fat, leave things alone!)
                    //    (We are only addressing _changes__ in status!)
                    if (par_controlH.Width >= par_controlH.Height) //Is it fat now?
                    {
                        // Was it narrow before?  If so, we need to keep it narrow.
                        bWasNarrowBefore = (par_controlH.Width - (_cursorStartPoint.X - e.X) < par_controlH.Height);
                        // If narrow before, keep it a bit narrow.
                        if (bWasNarrowBefore) par_controlH.Width = -10 + par_controlH.Height; // Keep it a bit narrow.  
                    }
                }
            }


            if (_SizeDisallowSquares || _SizeKeepWidthMoreThanHeight) //  #2 of 8.
            {
                //if (_SizeDisallowSquares) [See same condition, line 1548 on 12/21/2022.]
                if (MouseIsInLeftEdge && (e.X > _cursorStartPoint.X)) // User is contracting the Left edge inward.
                {
                    // User is contracting the Left edge inward.  Check to see if we need to
                    //   keep the shape fat (if it's narrow now, whereas it used to be fat).
                    //   (If it's narrow now & it used to be narrow, leave things alone!)
                    //    (We are only addressing _changes__ in status!)
                    if (par_controlH.Width <= par_controlH.Height) //Is it narrow now?
                    {
                        bWasFatBefore = (par_controlH.Width + (e.X - _cursorStartPoint.X) > par_controlH.Height);
                        // If fat before, keep it a bit fat.
                        if (bWasFatBefore) par_controlH.Width = +10 + par_controlH.Height; // Keep it a bit fat. 
                    }
                }
            }


            if (_SizeDisallowSquares || _SizeKeepHeightMoreThanWidth) //  #3 of 8.
            {
                //if (_SizeDisallowSquares) [See same condition, line 1548 on 12/21/2022.]
                if (MouseIsInRightEdge && (e.X > _cursorStartPoint.X)) // User is expanding the Right edge outward.
                {
                    // User is expanding the Right edge outward.  Check to see if we need to
                    //   keep the shape narrow (if it's fat now, whereas it used to be narrow).
                    //   (If it's fat now & it used to be fat, leave things alone!)
                    //    (We are only addressing _changes__ in status!)
                    if (par_controlH.Width >= par_controlH.Height) //Is it fat now?
                    {
                        bWasNarrowBefore = (par_controlH.Width - (_cursorStartPoint.X - e.X) < par_controlH.Height);
                        if (bWasNarrowBefore) par_controlH.Width = -10 + par_controlH.Height; // Keep it a bit narrow. 
                    }
                }
            }


            if (_SizeDisallowSquares || _SizeKeepWidthMoreThanHeight) //  #4 of 8.
            {
               //if (_SizeDisallowSquares) [See same condition, line 1548 on 12/21/2022.]
                if (MouseIsInRightEdge && (e.X < _cursorStartPoint.X)) // User is contracting the Right edge inward.
                {
                    // User is contracting the Right edge inward.  Check to see if we need to
                    //   keep the shape fat (if it's narrow now, whereas it used to be fat).
                    //   (If it's narrow now & it used to be narrow, leave things alone!)
                    //    (We are only addressing _changes__ in status!)
                    if (par_controlH.Width <= par_controlH.Height) //Is it narrow now?
                    {
                        bWasFatBefore = (par_controlH.Width + (e.X - _cursorStartPoint.X) > par_controlH.Height);
                        // If fat before, keep it a bit fat.
                        if (bWasFatBefore) par_controlH.Width = +10 + par_controlH.Height; // Keep it a bit fat. 
                    }
                }
            }


            if (_SizeDisallowSquares || _SizeKeepWidthMoreThanHeight) //  #5 of 8.
            {
                //if (_SizeDisallowSquares) [See same condition, line 1548 on 12/21/2022.]
                if (MouseIsInTopEdge && (e.Y < _cursorStartPoint.Y)) // User is expanding the top edge upward.
                {
                    // User is expanding the Top edge upward.  Check to see if we need to
                    //   keep the shape short (if it's tall now, whereas it used to be short).
                    //   (If it's tall now & it used to be tall, leave things alone!)
                    //    (We are only addressing _changes__ in status!)
                    if (par_controlH.Height >= par_controlH.Width) //Is it tall now?
                    {
                        bWasShortBefore = (par_controlH.Height - (_cursorStartPoint.Y - e.Y) < par_controlH.Width);
                        // If short before, keep it a bit short.
                        if (bWasShortBefore) par_controlH.Height = -10 + par_controlH.Width; // Keep it a bit short. 
                    }
                }
            }


            if (_SizeDisallowSquares || _SizeKeepHeightMoreThanWidth) //  #6 of 8.
            {
                //if (_SizeDisallowSquares) [See same condition, line 1548 on 12/21/2022.]
                if (MouseIsInTopEdge && (e.Y > _cursorStartPoint.Y)) // User is contracting the top edge downward.
                {
                    // User is contracting the Top edge downward.  Check to see if we need to
                    //   keep the shape tall (if it's short now, whereas it used to be tall).
                    //   (If it's short now & it used to be short, leave things alone!)
                    //    (We are only addressing _changes__ in status!)
                    if (par_controlH.Height <= par_controlH.Width) //Is it short now?
                    {
                        bWasTallBefore = (par_controlH.Height + (e.Y - _cursorStartPoint.Y) > par_controlH.Width);
                        // If tall before, keep it a bit tall.
                        if (bWasTallBefore) par_controlH.Height = +10 + par_controlH.Width; // Keep it a bit tall. 
                    }
                }
            }


            //if (_SizeDisallowSquares) [See same condition, line 1548 on 12/21/2022.]
            if (_SizeDisallowSquares || _SizeKeepWidthMoreThanHeight) //  #7 of 8.
            {
                if (MouseIsInBottomEdge && (e.Y > _cursorStartPoint.Y)) // User is expanding the bottom edge downward.
                {
                    // User is expanding the Bottom edge downward.  Check to see if we need to
                    //   keep the shape short (if it's tall now, whereas it used to be short).
                    //   (If it's tall now & it used to be tall, leave things alone!)
                    //    (We are only addressing _changes__ in status!)
                    if (par_controlH.Height >= par_controlH.Width) //Is it tall now?
                    {
                        bWasShortBefore = (par_controlH.Height - (e.Y - _cursorStartPoint.Y) < par_controlH.Width);
                        // If short before, keep it a bit short.
                        if (bWasShortBefore) par_controlH.Height = -10 + par_controlH.Width; // Keep it a bit short. 
                    }
                }
            }


            //if (_SizeDisallowSquares) [See same condition, line 1548 on 12/21/2022.]
            if (_SizeDisallowSquares || _SizeKeepHeightMoreThanWidth) //  #8 of 8.
            {
                if (MouseIsInBottomEdge && (e.Y < _cursorStartPoint.Y)) // User is contracting the bottom edge upward.
                {
                    // User is contracting the Bottom edge upward.  Check to see if we need to
                    //   keep the shape tall (if it's short now, whereas it used to be tall).
                    //   (If it's short now & it used to be short, leave things alone!)
                    //    (We are only addressing _changes__ in status!)
                    if (par_controlH.Height <= par_controlH.Width) //Is it short now?
                    {
                        bWasTallBefore = (par_controlH.Height + (_cursorStartPoint.Y - e.Y) > par_controlH.Width);
                        // If tall before, keep it a bit tall.
                        if (bWasTallBefore) par_controlH.Height = +10 + par_controlH.Width; // Keep it a bit tall. 
                    }
                }
            }

        }


        private void ControlProportionality(Control par_control,
            bool pbMouseIsInTopEdge_Only, bool pbMouseIsInBottomEdge_Only,
            bool pbMouseIsInLeftEdge_Only, bool pbMouseIsInRightEdge_Only)
        {
            //
            //Encapsulated 1/10/2022 thomas d.
            //
            //Control the proportionality.
            //    ----10/14/2019
            //
            decimal intAmtWrong_Width = Math.Abs(par_control.Width - (par_control.Height * _proportionWH));
            decimal intAmtWrong_Height = Math.Abs(par_control.Height - (par_control.Width / _proportionWH));

            //Fix whichever of the two is worse.  ---10/14
            if (intAmtWrong_Height > intAmtWrong_Width)
            {
                par_control.Height = (int)((decimal)par_control.Width / _proportionWH);
            }

            else if (pbMouseIsInTopEdge_Only || pbMouseIsInBottomEdge_Only)
            {
                //Added 10/14/2019 td 
                par_control.Width = (int)((decimal)par_control.Height * _proportionWH);
            }

            else if (pbMouseIsInLeftEdge_Only || pbMouseIsInRightEdge_Only)
            {
                //Added 10/14/2019 td 
                par_control.Height = (int)((decimal)par_control.Width / _proportionWH);
            }
            else
            {
                par_control.Width = (int)((decimal)par_control.Height * _proportionWH);
            }


        } //End of "private void CheckProportionality()"


        public void StopDragOrResizingV1(Control par_controlJ,
            ISaveToModel par_iSave)
        {
            //---Jan27 2022---public void StopDragOrResizing(Control par_controlJ, ISaveToModel par_iSave)
            //
            // Suffied 1/27/2022 td
            //
            bool bWasResizing = _resizing; // Added 7/31/2019 td
            bool bWasResizingHeight = _resizingHeight; // Added 6/06/2022 td

            _resizing = false;
            _resizingHeight = false; //Revert to default of false. ---6/6/2022 
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
            if (bWasResizing)
            {
                //Jan10 2022 //mod_events.Resizing_Terminate(par_iSave);
                if (mod_events_singleCtl != null)
                    mod_events_singleCtl.Resizing_TerminateV1(par_iSave);
                if (mod_events_groupedCtls != null)
                    mod_events_groupedCtls.Resizing_TerminateV1(par_iSave);

                //Added 2/2/2022 thomas d. 
                //mod_events_singleCtl.Resizing_TerminateV2(par_iSave,
                //    _iRefreshElementImage,
                //    _iRefreshCardPreview);

                //Modified 6/06/2022 thomas d. 
                if (mod_events_singleCtl != null)
                    mod_events_singleCtl.Resizing_TerminateV2(par_iSave,
                    _iRefreshElementImage,
                    _iRefreshCardPreview, 
                    bWasResizingHeight);
            }

            //Added 9/13/2019 thomas downes
            //  #1 Nov. 29 2021 //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate();
            //  #2 Nov. 29 2021 //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate(par_controlJ);
            //  12/17/2021 td //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate(_controlMoveableElement);
            if (!(bWasResizing))
            {
                // Jan10 2022 //mod_events.Moving_Terminate(_controlMoveableElement, _iSaveToModel);
                if (mod_events_singleCtl != null)
                    mod_events_singleCtl.Moving_Terminate(_controlMoveableElement, _iSaveToModel);
                if (mod_events_groupedCtls != null)
                    mod_events_groupedCtls.Moving_Terminate(_controlMoveableElement, _iSaveToModel);
            }

            //Added 11/29/2021 td
            //  Remove the object reference.
            //
            //--((--UnloadEventHandlers needs this reference.---Dec28 2021 td
            //--controlCurrent = null;

        }


        public void StopDragOrResizingV2(Control par_controlJ,
                            ISaveToModel par_iSave,
                            IRefreshElementImage par_iRefreshElemImage,
                            IRefreshCardPreview par_iRefreshCardPreview)
        // Interface can't be nulled?    IRefreshElementImage par_iRefreshElemImage = null,
        // Interface can't be nulled?    IRefreshCardPreview par_iRefreshCardPreview = null)
        {
            bool bWasResizing = _resizing; // Added 7/31/2019 td
            bool bWasResizingHeight = _resizingHeight; //Added 6/6/2022 td

            _resizing = false;
            _resizingHeight = false; //Revert to default of false. 6/06/2022 td
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
            if (bWasResizing)
            {
                //Jan10 2022 //mod_events.Resizing_Terminate(par_iSave);
                //June 4 2022 // mod_events_singleCtl.Resizing_TerminateV1(par_iSave);
                
                //See same call below.6/6/2022//mod_events_singleCtl.Resizing_TerminateV2(par_iSave, 
                //                       //    par_iRefreshElemImage, 
                //                       //    par_iRefreshCardPreview);

                if (mod_events_groupedCtls != null)
                    mod_events_groupedCtls.Resizing_TerminateV1(par_iSave);

                //Added 6/4/2022 
                //.... ///// new idea....
                //((IRefreshElementImage)mod_events_singleCtl).RefreshElementImage();
                //
                //June6 2022---Redundant for the following: CtlGraphicFieldV3.vb
                //June6 2022 mod_iRefreshElementImage.RefreshElementImage();

                //Added 2/2/2022 thomas d. 
                if (mod_events_singleCtl != null)
                    mod_events_singleCtl.Resizing_TerminateV2(par_iSave,
                    par_iRefreshElemImage,
                    par_iRefreshCardPreview, 
                    bWasResizingHeight);

            }

            //Added 9/13/2019 thomas downes
            // #1 Nov. 29 2021 //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate();
            // #2 Nov. 29 2021 //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate(par_controlJ);
            // 12/17/2021 td //if (!(bWasResizing)) mod_groupedctl_events.Moving_Terminate(_controlMoveableElement);

            bool bWasMoving_NotResizing;  // Added 2/02/2022 td
            bWasMoving_NotResizing = (!(bWasResizing)); // Added 2/02/2022 td

            if (bWasMoving_NotResizing)  // 2/02/2022 // (!(bWasResizing))
            {
                // Jan10 2022 //mod_events.Moving_Terminate(_controlMoveableElement, _iSaveToModel);
                if (mod_events_singleCtl != null) //Added Dec2022
                    mod_events_singleCtl.Moving_Terminate(_controlMoveableElement, _iSaveToModel);

                if (mod_events_groupedCtls != null)
                    mod_events_groupedCtls.Moving_Terminate(_controlMoveableElement, _iSaveToModel);
            }

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
            if (_controlCurrent != null)
            {
                _controlCurrent.MouseDown -= (sender, e) => StartMovingOrResizing(_controlCurrent, e);

                // Dec17 2021//_controlCurrent.MouseUp -= (sender, e) => StopDragOrResizing(_controlCurrent);
                _controlCurrent.MouseUp -= (sender, e) => StopDragOrResizingV1(_controlCurrent, _iSaveToModel);
                _controlCurrent.MouseMove -= (sender, e) => MoveParentControl(_controlCurrent, e);
            }

            //Added 1/4/2022 td

            if (_controlPictureBox1 != null)
            {
                _controlPictureBox1.MouseUp -= (sender, e) => StopDragOrResizingV1(_controlPictureBox1, _iSaveToModel);
                _controlPictureBox1.MouseMove -= (sender, e) => MoveParentControl(_controlPictureBox1, e);
            }

            if (_controlPictureBox2 != null)
            {
                //Added 1/4/2022 td
                _controlPictureBox2.MouseUp -= (sender, e) => StopDragOrResizingV1(_controlPictureBox2, _iSaveToModel);
                _controlPictureBox2.MouseMove -= (sender, e) => MoveParentControl(_controlPictureBox2, e);
            }

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


        public bool NowInMotion()
        {
            //
            // Added 1/10/2022 td
            //
            //throw new NotImplementedException();
            return _moving;
        }

        #endregion

    }
}