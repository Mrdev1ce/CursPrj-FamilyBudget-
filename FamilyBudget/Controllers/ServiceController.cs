using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyBudget.Controllers
{
    public class ServiceController : Controller
    {
        //
        // GET: /Service/
        [HttpGet]
        public JsonResult Test()
        {
            return Json(new { someData = "123"}, JsonRequestBehavior.AllowGet);
        }

    }
}
