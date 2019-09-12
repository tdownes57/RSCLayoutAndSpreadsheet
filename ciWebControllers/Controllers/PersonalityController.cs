using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ciBadgeForWeb.Models;  //Added 7/11/2019 Thomas DOWNES

namespace ciBadgeForWeb.Controllers
{
    public class PersonalityController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        //
        //Added 7/10/2019 td
        //
        //
        //Recipient = Student or Employee receiving the Badge. 
        //
        public static IList<Models.Personality> mod_Personalities = new List<Models.Personality>() {
          new Models.Personality() { ConfigID = 1, ConfigNameBrief = "Students", ConfigNameFull = "Westmont High Students"  },
          new Models.Personality() { ConfigID = 2, ConfigNameBrief = "Staff", ConfigNameFull = "Westmont High Staff"   }
        };

        // GET: Personality
        public ActionResult Index()
        {
            return (ViewResult)View(mod_Personalities);
        }

        // GET: Personality/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personality/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personality/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personality/Edit/5
        public ActionResult Edit(int? id)
        {
            //Return View();

            //Added 7/9/2019 td
            if (!(id.HasValue)) id = 5;

            const bool c_boolSpecifyViewName = false; //Added 5/28/2019 td
            if (c_boolSpecifyViewName) return View("Edit");  //A ViewResult, i.e. a webpage, is the most popular type of ActionResult !!
            //return View();  //A ViewResult, i.e. a webpage, is the most popular type of ActionResult !!

            var id_doublecheck = Request.QueryString["parameter_id"];

            //Get the Personality and open it for Viewing. 
            var personality_by_id = mod_Personalities.Where(s => s.ConfigID == id).FirstOrDefault();
            return (ViewResult)View(personality_by_id);

        }

        // POST: Personality/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // Added 7/11/2019 thomas downes
                //
                // 7/11 td//UpdateModel(mod_Personalities[id], collection);

                Personality editedConfig = mod_Personalities.Where(s => s.ConfigID == id).FirstOrDefault();

                UpdateModel(editedConfig, collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personality/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personality/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
