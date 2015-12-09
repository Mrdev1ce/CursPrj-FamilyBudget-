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
    [AllowAnonymous]
    public class AuthController : Controller
    {
        //
        // GET: /Auth/

        [HttpGet]
        public ActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("sp", "main");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "auth");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (!string.IsNullOrWhiteSpace(user.Login) || !string.IsNullOrWhiteSpace(user.Password))
            {
                //password = Security.GetHashString(password);
                if (LoginModel.IsLoginSuccess(user.Login, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Login, user.IsRemember);
                }
                else
                {
                    ViewBag.ErrorMessage = "Incorrect login or password!";
                    return View();
                }
            }
            return RedirectToAction("sp", "main");
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                if (UsersManager.GetUserInfo(user.Login) == null)
                {
                    UsersManager.AddUser(user);
                    return RedirectToAction("sp", "main");
                }
                else
                {
                    ViewBag.ErrorMessage = "This login is in use by another user!";
                    return View();
                }
            }

            return View();
        }
    }
}
