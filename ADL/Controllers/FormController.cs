using ADL.Handlers;
using ADL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ActionResult> Submit(CookieValues cookieValues)
        {
            ADLHandler adlHandler = new ADLHandler();
            var client = await adlHandler.GetAdlCredentials();
            adlHandler.AppendToFile(client, cookieValues);
            return View();
        }
    }
}