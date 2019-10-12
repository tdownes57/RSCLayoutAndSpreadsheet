using ciPictures_VB;  //Added 6/15/2019 thomas d.  
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ciBadgeForWeb.Controllers
{
    //
    //Recipient = Student or Employee receiving the Badge. 
    //

    public class RecipientController : Controller
    {
        //
        //Currently active Personality-Configuration ID
        //
        public static int PersonalityConfigID_current = 1; //Added 7/12/2019 td 
        public static int RecipientID_current = 1; //Needed for the future Steps1234 controller.  ----Added 7/17/2019 td 

        //
        //Recipient = Student or Employee receiving the Badge. 
        //
        public static IList<Models.CIRecipient> mod_recipientList = new List<Models.CIRecipient>() {
                    new Models.CIRecipient(){ CustomerID="CIS100", ConfigID=1, RecipientID ="1", FirstName="Johnny", LastName = "Davidson", Picture = PictureExamples.GetExample()  },
                    new Models.CIRecipient(){ CustomerID="CIS100", ConfigID=1, RecipientID ="2", FirstName="Stevie", LastName = "Austin", Picture = PictureExamples.GetExample() },
                    new Models.CIRecipient(){ CustomerID="CIS100", ConfigID=1, RecipientID ="3", FirstName="Billy", LastName = "Clinton", Picture = PictureExamples.GetExample()   },
                    new Models.CIRecipient(){ CustomerID="CIS100", ConfigID=1, RecipientID ="4", FirstName="Ronny", LastName = "Thegot", Picture = PictureExamples.GetExample()   },
                    new Models.CIRecipient(){ CustomerID="CIS100", ConfigID=1, RecipientID ="5", FirstName="Dorothy" , LastName = "Wood", Picture = PictureExamples.GetExample()  },
                    new Models.CIRecipient(){ CustomerID="CIS100", ConfigID=1, RecipientID ="6", FirstName="Christy", LastName = "Forbes", Picture = PictureExamples.GetExample()   },
                    new Models.CIRecipient(){ CustomerID="CIS100", ConfigID=1, RecipientID = "7", FirstName="Tommy", LastName = "Forbes", Picture = PictureExamples.GetExample()   },

            //new Models.CIRecipient(){ CustomerID="XYZ999", Personality="Student", RecipientID ="1", FirstName="John", LastName = "Davidson", Picture = PictureExamples.GetExample()  },
            //new Models.CIRecipient(){ CustomerID="XYZ999", Personality="Student", RecipientID ="2", FirstName="Steve", LastName = "Austin", Picture = PictureExamples.GetExample()  },
            //new Models.CIRecipient(){ CustomerID="XYZ999", Personality="Student", RecipientID ="3", FirstName="Bill", LastName = "Clinton", Picture = PictureExamples.GetExample()   },
            //new Models.CIRecipient(){ CustomerID="XYZ999", Personality="Student", RecipientID ="4", FirstName="Ram", LastName = "Thegot", Picture = PictureExamples.GetExample()   },
            //new Models.CIRecipient(){ CustomerID="XYZ999", Personality="Student", RecipientID ="5", FirstName="Ron" , LastName = "Wood", Picture = PictureExamples.GetExample()  },
            //new Models.CIRecipient(){ CustomerID="XYZ999", Personality="Student", RecipientID ="6", FirstName="Christopher", LastName = "Forbes", Picture = PictureExamples.GetExample()   },
            //new Models.CIRecipient(){ CustomerID="XYZ999", Personality="Student", RecipientID = "7", FirstName="Robin", LastName = "Forbes", Picture = PictureExamples.GetExample()   }

                            new Models.CIRecipient(){ CustomerID="CIS100", ConfigID=2, RecipientID ="1", FirstName="Jayce", LastName = "P.", Picture = PictureExamples.GetExample()  },
                    new Models.CIRecipient(){ CustomerID="CIS100", ConfigID=2, RecipientID ="2", FirstName="Chanin", LastName = "F.", Picture = PictureExamples.GetExample() },
                    new Models.CIRecipient(){ CustomerID="CIS100", ConfigID=2, RecipientID ="3", FirstName="Sammi", LastName = "F.", Picture = PictureExamples.GetExample()   },
                    new Models.CIRecipient(){ CustomerID="CIS100", ConfigID=2, RecipientID ="4", FirstName="Erick", LastName = "M.", Picture = PictureExamples.GetExample()   },
                    new Models.CIRecipient(){ CustomerID="CIS100", ConfigID=2, RecipientID ="5", FirstName="Erica" , LastName = "A.", Picture = PictureExamples.GetExample()  },
                    new Models.CIRecipient(){ CustomerID="CIS100", ConfigID=2, RecipientID ="6", FirstName="Jimmy", LastName = "A.", Picture = PictureExamples.GetExample()   },
                    new Models.CIRecipient(){ CustomerID="CIS100", ConfigID=2, RecipientID = "7", FirstName="Thomas", LastName = "D.", Picture = PictureExamples.GetExample()   }
};

        // GET: Recipient
        public ActionResult Index()
        {
            const bool c_boolSpecifyViewName = false;    //Added 5/28/2019 td
            if (c_boolSpecifyViewName) return View("Index");  //A View, i.e. a webpage, is the most popular type of ActionResult !!

            //Let's test it.  Does the List retain edits??? ----5/29/2019 td
            //mod_recipientList.FirstOrDefault().LastName += "P";

            //return View();  //A ViewResult, i.e. a webpage, is the most popular type of ActionResult !!
            //     7-12-2019 td//return (ViewResult)View(mod_recipientList);
            return (ViewResult)View(mod_recipientList.Where(s => s.ConfigID == PersonalityConfigID_current));
        }

        // GET: Recipient
        public ActionResult Index_Cfg1()
        {
            //
            //Added 7/12/2019 thomas downes
            //
            PersonalityConfigID_current = 1;  //Set Config #1 to be the Current Personality Config. 
            //return (ViewResult)View(mod_recipientList.Where(s => s.ConfigID == PersonalityConfigID_current));
            return (ViewResult)View("Index", mod_recipientList.Where(s => s.ConfigID == PersonalityConfigID_current));
        }

        // GET: Recipient
        public ActionResult Index_Cfg2()
        {
            //
            //Added 7/12/2019 thomas downes
            //
            PersonalityConfigID_current = 2;  //Set Config #1 to be the Current Personality Config. 
            //return (ViewResult)View(mod_recipientList.Where(s => s.ConfigID == PersonalityConfigID_current));
            return (ViewResult)View("Index", mod_recipientList.Where(s => s.ConfigID == PersonalityConfigID_current));
        }

        // GET: Recipient/Details/5
        public ActionResult Details(int parameter_id)
        {
            const bool c_boolSpecifyViewName = false;    //Added 5/28/2019 td
            if (c_boolSpecifyViewName) return View("Details");  //A View, i.e. a webpage, is the most popular type of ActionResult !!

            return (ViewResult)View();  //A ViewResult, i.e. a webpage,  is the most popular type of ActionResult !!
        }

        // GET: Recipient/Create
        public ActionResult Create()
        {
            const bool c_boolSpecifyViewName = false;    //Added 5/28/2019 td
            if (c_boolSpecifyViewName) return View("Create");  //A View, i.e. a webpage, is the most popular type of ActionResult !!

            return (ViewResult)View();   //A ViewResult, i.e. a webpage,  is the most popular type of ActionResult !!
        }

        // Recipient/ShowSearchResults   (Doesn't directly match an HTTP command.)
        public ActionResult ShowSearchResults(IList<Models.CIRecipient> par_results) => View("Index", par_results);

        //const bool c_boolSpecifyViewName = false;    / /Added 5/28/2019 td
        //if (c_boolSpecifyViewName) return View("Create");  //A View, i.e. a webpage, is the most popular type of ActionResult !!
        //return (ViewResult)View();   //A ViewResult, i.e. a webpage,  is the most popular type of ActionResult !!



        // POST: Recipient/Create
        [HttpPost]
        public ActionResult Create(Models.CIRecipient par_recip)     // (FormCollection collection)
        {
            try
            {
                // Added 6/5/2019 td
                //
                mod_recipientList.Add(par_recip);


                //Index = "Nothing specified, go to the root page or action."  
                return RedirectToAction("Index");
            }
            catch
            {
                return (ViewResult)View();  //A ViewResult, i.e. a webpage,  is the most popular type of ActionResult !!  ----5/24 td
            }
        }

        // GET: Recipient/Edit/5
        public ActionResult Edit(int? parameter_id)
        {
            //Added 7/9/2019 td
            if (!(parameter_id.HasValue)) parameter_id = 5;

            const bool c_boolSpecifyViewName = false; //Added 5/28/2019 td
            if (c_boolSpecifyViewName) return View("Edit");  //A ViewResult, i.e. a webpage, is the most popular type of ActionResult !!
            //return View();  //A ViewResult, i.e. a webpage, is the most popular type of ActionResult !!

            var id_doublecheck = Request.QueryString["parameter_id"];

            //Get the student from studentList sample collection for demo purpose.
            //Get the student from the database in the real application
            var recipients_by_id_list = mod_recipientList.Where(s => s.RecipientID == parameter_id.ToString());
            var recipient_by_id_onlyone = recipients_by_id_list.FirstOrDefault();
            //return View(recipients_by_id);
            //return View("Index", recipients_by_id);
            return (ViewResult)View(recipient_by_id_onlyone);

        }

        // GET: Recipient/CardsPrintedLog/5
        public ActionResult CardsPrintedLog(int parameter_id)
        {
            const bool c_boolSpecifyViewName = false; //Added 5/28/2019 td
            if (c_boolSpecifyViewName) return View("Index", "TrackPrints");  //A ViewResult, i.e. a webpage, is the most popular type of ActionResult !!
            //return View();  //A ViewResult, i.e. a webpage, is the most popular type of ActionResult !!

            var id_doublecheck = Request.QueryString["parameter_id"];

            //----10/12/2019 td''var printLog_by_id_list = TrackPrintsController.mod_trackPrintsLog.Where(s => s.RecipientID == parameter_id.ToString());
            //----10/12/2019 td''return (ViewResult)View(printLog_by_id_list);

            return null;

        }

        // POST: Recipient/Edit/5
        [HttpPost]
        public ActionResult Edit(int parameter_id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                //
                //Get the student from studentList sample collection for demo purpose.
                //Get the student from the database in the real application
                var edited_recip = mod_recipientList.Where(s => s.RecipientID == parameter_id.ToString()).FirstOrDefault();

                var name_first = Request["FirstName"];
                var name_last = Request["LastName"];

                edited_recip.FirstName = name_first;  // std.FirstName + "_Revised";
                edited_recip.LastName = name_last;  //  std.LastName + "_Revised";

                UpdateModel(edited_recip, collection);

                //Index = "Nothing specified, go to the root page or action."  
                return RedirectToAction("Index");  //A Redirect is a less-common ActionResult.  ----5/24 td
            }
            catch
            {
                return (ViewResult)View();  //A ViewResult, i.e. a webpage, is the most popular type of ActionResult !!
            }
        }

        // GET: Recipient/Delete/5
        public ActionResult Delete(int parameter_id)
        {
            //const bool c_boolSpecifyViewName = true; //Added 5/28/2019 td
            //if (c_boolSpecifyViewName) return View("Delete");  //A ViewResult, i.e. a webpage, is the most popular type of ActionResult !!

            var recipient_tobeDeleted = mod_recipientList.Where(s => s.RecipientID == parameter_id.ToString()).FirstOrDefault();
            mod_recipientList.Remove(recipient_tobeDeleted);

            //return View("Index");
            return RedirectToAction("Index");
        }

        // POST: Recipient/Delete/5
        [HttpPost]
        public ActionResult Delete(int parameter_id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                //Index = "Nothing specified, go to the root page or action."  
                //
                return RedirectToAction("Index");  //A Redirect is a less-common ActionResult.  ----5/24 td
            }
            catch
            {
                return (ViewResult)View();  //A ViewResult, i.e. a webpage,  is the most popular type of ActionResult !!  ----5/24 td
            }
        }




        public static IEnumerable<ciBadgeForWeb.Models.CIRecipient> GetRecipents_CurrentPC()
        {
            //
            //Added 7/12/2019 td 
            //
            return mod_recipientList.Where(s => s.ConfigID == RecipientController.PersonalityConfigID_current);

        }

        public static  IEnumerable<ciBadgeForWeb.Models.CIRecipient> GetStudents() 
        {
            //
            //Added 7/12/2019 td 
            //
            return mod_recipientList.Where(s => s.ConfigID == 1);

        }

        public static IEnumerable<ciBadgeForWeb.Models.CIRecipient> GetStaff()
        {
            //
            //Added 7/12/2019 td 
            //
            return mod_recipientList.Where(s => s.ConfigID == 2);

        }

    }
}
