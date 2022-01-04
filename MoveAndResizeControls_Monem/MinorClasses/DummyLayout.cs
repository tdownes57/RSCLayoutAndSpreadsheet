using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ciBadgeInterfaces;     //Added 1/3/2022 td

namespace MoveAndResizeControls_Monem
{
    //Added 1/3/2022 td
    class DummyLayout : ILayoutFunctions
    {
        //Added 1/3/2022 td
        //
        //   This is a dummy class, i.e. don't expect any functionality!!
        //   We are simply trying to avoid compiler errors
        //     (and also design-time errors, or errors which might
        //     occur while we are testing something fairly unrelated).
        //     ----1/3/2022 td 
        //
        public Control ControlBeingModified { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Control ControlBeingMoved { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AutoPreview_IfChecked(Control par_controlElement = null, bool par_stillMoving = false)
        {
            //throw new NotImplementedException();
        }

        public int Layout_Height_Pixels()
        {
            //throw new NotImplementedException();
            return 0;
        }

        public int Layout_Margin_Left_Add(int par_intPixelsLeft)
        {
            //throw new NotImplementedException();
            return 0;
        }

        public int Layout_Margin_Left_Omit(int par_intPixelsLeft)
        {
            //throw new NotImplementedException();
            return 0;
        }

        public int Layout_Margin_Top_Add(int par_intPixelsTop)
        {
            //throw new NotImplementedException();
            return 0;
        }

        public int Layout_Margin_Top_Omit(int par_intPixelsTop)
        {
            //throw new NotImplementedException();
            return 0;
        }

        public int Layout_Width_Pixels()
        {
            //throw new NotImplementedException();
            return 0;
        }

        public string NameOfForm()
        {
            //throw new NotImplementedException();
            return "dummy";
        }

        public bool OkayToShowFauxContextMenu()
        {
            //throw new NotImplementedException();
            return false;
        }

        public void RedrawForm()
        {
            //throw new NotImplementedException();
        }

        public ToolStripMenuItem RightClickMenu_Parent()
        {
            //throw new NotImplementedException();
            return null; 
        }
    }
}
