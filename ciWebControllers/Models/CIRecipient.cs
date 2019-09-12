using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; //Added 5/28/2019 td
using System.ComponentModel.DataAnnotations; //Added 5/28/2019 td
using System.Drawing; //Added 6/13/2019 thomas d. 

namespace ciBadgeForWeb.Models
{
    public class CIRecipient
    {
        //public int Mystring { get; set; }

        [Key]
        [Display(Name = "Customer ID")]
        public string CustomerID { get; set; }

        [Key]
        [Display(Name = "Config ID")]
        public int ConfigID { get; set; }

        [Key]
        [Display(Name = "ID")]
        public string RecipientID { get; set; }

        [Display(Name = "Picture")]
        public Image Picture { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        //
        //Added 7/13/2019 THOMAS DOWNES
        //
        public string FullNameOnBadge { get; set; }

        //
        //Added 7/14/2019 THOMAS DOWNES
        //
        public string RFIDValue { get; set; }

        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<string> TextFields { get; set; }
        public List<DateTime> DateFields { get; set; }

        public string EffectiveDate_Text
        {
            //Added 5/30/2019
            get
            {
                if (EffectiveDate.Year < 2000) return ""; //Added 7/8/2019 td 
                return EffectiveDate.ToString("MM/dd/yyyy");
            }
            set
            {
                if (value == null) return;  //Added 7/8/2019 td
                EffectiveDate = DateTime.Parse(value);
            }
        }

        public string ExpirationDate_Text
        {
            //Added 5/30/2019
            get {
                if (ExpirationDate.Year < 2000) return ""; //Added 7/8/2019 td 
                return ExpirationDate.ToString("MM/dd/yyyy");
            }
            set
            {
                if (value == null) return;  //Added 7/8/2019 td
                ExpirationDate = DateTime.Parse(value);
            }
        }

        //
        //Added 7-13-2019 thomas d.
        //
        public Models.Personality GetRecipientsPersonality()
        {
            //
            //Added 7-13-2019 thomas d.
            //
            return Controllers.PersonalityController.mod_Personalities[this.ConfigID];
        }

        //
        //Added 7/13/2019 Thomas C. Downes
        //
        public bool UseMiddleNameOnBadge()
        {
            //Added 7/13/2019 Thomas C. Downes
            return GetRecipientsPersonality().MiddleName;
        }

        //
        //Added 7/13/2019 THOMAS DOWNES
        //
        public string FullNameOnBadge_Composed()
        {
            bool boolUseOverride; //Added 7/13/2019
            bool boolEditsToFullnameOkay;

            //
            //Account for possible operator-judgement overrides. (Operators must use sparingly!)   
            //
            boolEditsToFullnameOkay = GetRecipientsPersonality().AllowEditsToFullName;
            boolUseOverride = (boolEditsToFullnameOkay && (!(String.IsNullOrEmpty(FullNameOnBadge.Trim()))));
            if (boolUseOverride) boolUseOverride = (3 + 1 + 2 <= FullNameOnBadge.Length);
            if (boolUseOverride) return FullNameOnBadge;

            if (UseMiddleNameOnBadge()) return (FirstName + " " + MiddleName + " " + LastName);

            return (FirstName + " " + LastName);

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
            strOutput = $"Student or Employee {this.FirstName} {this.LastName} has a big problem.";
            return strOutput;  
        }

    }
}
 