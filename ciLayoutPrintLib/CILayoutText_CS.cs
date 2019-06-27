using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; //Added 5/28/2019 td
using System.ComponentModel.DataAnnotations; //Added 5/28/2019 td
using System.Drawing; //Added 6/13/2019 thomas d. 

namespace ciLayoutPrintLib
{
    public class CILayoutText_CS
    {
        //public int Mystring { get; set; }

			[Key]
        [Display(Name = "CI Layout Text ID")]
        public int CILayoutTextId { get; set; }

        [Display(Name = "Field Name")]
        public string FieldName { get; set; }

        [Display(Name = "Top-Edge Position in Pixels")]
        public int TopEdgePositionPixels { get; set; }

        [Display(Name = "Left-Edge Position in Pixels")]
        public int LeftEdgePositionPixels { get; set; }

        [Display(Name = "Width (or Length) in Pixels")]
        public int WidthLengthPixels { get; set; }

        [Display(Name = "Height of Text Area in Pixels")]
        public int HeightPixels { get; set; }

        [Display(Name = "Font Size")]
        public int FontSize { get; set; }

        [Display(Name = "Font Family Name")]
        public string FontFamilyName { get; set; }

        public CILayoutText()
        {
            //
            //Added 6/25/2019 thomas downes
            //
            this.CILayoutTextId = 1;
            this.FieldName = "Comic Sans";
            this.FontSize = 12;
            this.LeftEdgePositionPixels = 20;
            this.TopEdgePositionPixels = 20;

        }
            
        public string ErrorMessage()
        {
            //
            //  https://visualstudiomagazine.com/blogs/tool-tracker/2019/05/building-strings-at-runtime.aspx
            //
            /**   Your third option is string interpolation. This is the newest mechanism and is what all 
             * the "hip and happening" developers use. It looks much like using the Format method, but the
             * placeholders now hold the values to be inserted into the string. You need to flag the string 
             * with a dollar sign ($) to tell C# that the curly braces are to be treated as placeholders rather 
             * than included in the string: 
             *  string msg = $"Customer {cust.Id} has an invalid status {cust.Status}.";  **/

            string strOutput;
            strOutput = $"CILayoutText {this.FieldName} has a big problem.";
            return strOutput;
        }

    }
}
