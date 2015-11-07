using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyBudget.Models;

namespace FamilyBudget.Controllers
{
    public class ServiceController : Controller
    {
        //
        // GET: /Service/
        [HttpGet]
        public JsonResult GetUserInfo()
        {
            return Json(new
            {
                Login = User.Identity.Name
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
