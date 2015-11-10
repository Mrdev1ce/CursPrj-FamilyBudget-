using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyBudget.Models;
using Newtonsoft.Json;

namespace FamilyBudget.Controllers
{
    [Authorize]
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

        [HttpGet]
        public JsonResult GetUserWallets()
        {
            var userLogin = User.Identity.Name;
            var wallets = WalletsManager.GetWalletsByLogin(userLogin);
            return Json(wallets, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetOperationsByLogin()
        {
            var userLogin = User.Identity.Name;
            var operations = OperationsManager.GetOperationsByLogin(userLogin);
            return Json(operations, JsonRequestBehavior.AllowGet);
        }

    }
}
