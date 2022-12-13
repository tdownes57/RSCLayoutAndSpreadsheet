using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndResizeControls_Monem //''.MinorClasses
{
    //
    // Added 3/4/2022 & 2/2/2022 t//dow//
    //
    public class ClassStructResizeParams
    {
        //-----March4 2022---public struct StructResizeParams
        //
        // Added 3/4/2022 & 2/2/2022 thomas downes
        //
        //  This will centralize the resizing information. ---2/2/2022 td
        //
        public bool KeepProportional_HtoW  // Aliased below as "ResizeProportionally".
        {
            //
            // This is the original version of the alias-property "ResizeProportionally".  ---3/4/2022
            //
            get 
            { 
                return mod_bKeepProportional_HtoW;
            }
            set 
            { 
                mod_bKeepProportional_HtoW = value;
                
                //Added 3/13/2022 Thomas Downes  
                if (value)
                {
                    if (!this.InitiateResizing) throw new Exception("Resizing not initiated.");
                }
            }
        }

        public float ProportionalRatio_HtoW;  // proportionWH
        // This will assist the layout program to enforcing a Width > Height rule. ---2/2/2022
        public bool KeepLandscape_WgtH;
        // This will assist the layout program to enforcing a Height > Width rule. ---2/2/2022
        public bool KeepPortrait_HgtW;

        //Initiate resizing.  ---3/13/2022 td
        public bool InitiateResizing;   // Required for resizing to take place. ----3/13/2022 td
        //Don't allow resizing. 
        public bool StopAllResizing;

        //Repaint after resizing. 
        public bool RepaintAfterResize;
        //Only allow re-sizing of the right-hand edge.
        //   (No moving of the control allowed.)
        public bool RightEdgeResizing_Only;

        //Added 3/4/2022 td
        public bool ResizeProportionally  // Let's provide an alias for "KeepProportional_HtoW".
        {
            //
            // Let's provide an alias for "KeepProportional_HtoW".  ---3/4/2022
            //
            get { 
                return mod_bKeepProportional_HtoW;
            }
            set { 
                mod_bKeepProportional_HtoW = value;

                //Added 3/13/2022 Thomas Downes  
                if (value)
                {
                    if (!this.InitiateResizing) throw new Exception("Resizing not initiated.");
                }

            }
        }

        //Added 3/13/2022 td
        private bool mod_bKeepProportional_HtoW = false; 

    }


}
