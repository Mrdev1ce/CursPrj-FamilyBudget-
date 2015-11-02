using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FamilyBudget.Models;

namespace FamilyBudget.Controllers
{
    public class AuthController : Controller
    {
        //
        // GET: /Auth/

        public ActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("sp", "Main");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        public ActionResult Login(string userLogin, string userPassword, bool isRemember = false)
        {
            if (!string.IsNullOrWhiteSpace(userLogin) || !string.IsNullOrWhiteSpace(userPassword))
            {
                //password = Security.GetHashString(password);
                if (LoginModel.IsLoginSuccess(userLogin, userPassword))
                {
                    FormsAuthentication.SetAuthCookie(userLogin, isRemember);
                }
                else
                {
                    ViewBag.ErrorMessage = "Incorrect login or password!";
                    return View();
                }
            }
            return RedirectToAction("sp", "Main");
        }
    }
}
