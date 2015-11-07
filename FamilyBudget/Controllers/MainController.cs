using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyBudget.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        //
        // GET: /Main/

        public ActionResult sp()
        {
            return View();
        }

    }
}
