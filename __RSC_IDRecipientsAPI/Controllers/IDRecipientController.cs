using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//
// Added 9/10/2022 thomas downes
//

namespace __RSC_IDRecipients_API_NoAzureAD.Controllers
{
    //
    // Added 9/10/2022 thomas downes
    //
    public class IDRecipientController : Controller
    {
        //
        // Added 9/10/2022 thomas downes
        //
        // GET: IDRecipientController
        public ActionResult Index()
        {
            return View();
        }

        // GET: IDRecipientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IDRecipientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IDRecipientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IDRecipientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IDRecipientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IDRecipientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IDRecipientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
