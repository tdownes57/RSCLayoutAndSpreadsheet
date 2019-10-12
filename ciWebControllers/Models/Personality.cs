using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; //Added 7/10/2019 td
using System.ComponentModel.DataAnnotations; //Added 7/10/2019 td
using System.Drawing; //Added 7/10/2019 thomas d. 
using System.Web.Mvc.Razor;  //Added 10/12/2019 td 

namespace ciBadgeForWeb.Models
{
    public class Personality
    {
        //Personality Configuration ID

        //Long Name (e.g. Students at Fullbright High School, Teachers & Staff of Fullbright High School) 

        //Short Name (e.g. Students, Staff) 

        //Settings....
        //
        //  Middle Name?
        //  Address?
        //  Expiration Date?
        //  Add New Badge Recipients?
        //  

        //Custom Fields....

        [Key]
        [Display(Name = "Personality Configuration ID")]
        public int ConfigID { get; set; }

        [Display(Name = "Brief Name (e.g. Cardholders/Staff/Students)")]
        public string ConfigNameBrief { get; set; }

        [Display(Name = "Name in Full (Optional)")]
        public string ConfigNameFull { get; set; }

        [Display(Name = "Address? (Street, etc.")]
        public bool AddressInfo { get; set; }

        [Display(Name = "Middle Name?")]
        public bool MiddleName { get; set; }

        [Display(Name = "Full Name (for edits if required)?")]
        public bool AllowEditsToFullName { get; set; }  // Added 7/13/2019

        [Display(Name = "Expiration Date?")]
        public bool ExpirationDate { get; set; }

        /// <summary>
        /// Whether a new Recipient receives a ID which is calculated by the CI Badge program.  
        /// </summary>
        [Display(Name = "Auto-Increment ID?")]
        public bool AutoIncrementedID { get; set; }


    }
}