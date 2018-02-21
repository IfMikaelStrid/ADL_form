using ADL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADL.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit(FormValues formValues)
        {
            bool isSuccessfull = Handlers.ADLHandler.AdlFunction(formValues);
            //if (isSuccessfull)
            //{
            //    return Redirect("Error");
            //}
            return View(formValues);
        }
    }
}