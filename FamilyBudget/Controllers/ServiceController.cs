using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using FamilyBudget.Models;
using FamilyBudget.Models.HelpModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FamilyBudget.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        //
        // GET: /Service/
        [HttpGet]
        public JsonResult GetUserLogin()
        {
            return Json(new
            {
                Login = User.Identity.Name
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUserInfo()
        {
            var userLogin = User.Identity.Name;
            var user = UsersManager.GetUserInfo(userLogin);
            if (user != null)
            {
                user.Login = userLogin;
                if (user.IsAdmin)
                {
                    var users = UsersManager.GetAllUsersInfo(user.Login);
                    return Json(new
                    {
                        user = user,
                        users = users
                    }, JsonRequestBehavior.AllowGet);
                }
                return Json(new {user = user}, JsonRequestBehavior.AllowGet);
            }
            return Json(new {message = "No user with such login"});
        }

        [HttpGet]
        public JsonResult GetUserInfoAbout(int? userId)
        {
            if (userId != null)
            {
                var userLogin = User.Identity.Name;
                var user = UsersManager.GetUserInfoById(userLogin, (int)userId);
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            return Json(new { message = "No user with such login" });
        }

        [HttpPost]
        public JsonResult ChangeUserPassword(ChangePass data)
        {
            var userLogin = User.Identity.Name;
            if (data.NewPass != null && data.OldPass != null)
            {
                var isSuccess = UsersManager.ChangeUserPassword(userLogin, data.OldPass, data.NewPass);
                return Json(new {isSuccess = isSuccess});
            }
            return Json(new {isSuccess = false});
        }

        [Authorize(Roles="Admin")]
        [HttpPost]
        public JsonResult ChangeUserRole(ChangeRole data)
        {
            var userLogin = User.Identity.Name;
            if (!string.IsNullOrEmpty(data.UserForChangeLogin) && data.IsAdmin != null)
            {
                var isSuccess = UsersManager.ChangeUserRole(userLogin, data.UserForChangeLogin, (bool)data.IsAdmin);
                return Json(new { isSuccess = isSuccess });
            }
            return Json(new {isSuccess = false});
        }

        [HttpGet]
        public JsonResult GetUserWallets()
        {
            var userLogin = User.Identity.Name;
            var wallets = WalletsManager.GetWalletsByLogin(userLogin);
            return Json(wallets, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUserWalletsAbout(int? userId)
        {
            if (userId != null)
            {
                var wallets = WalletsManager.GetWalletsById((int) userId);
                return Json(wallets, JsonRequestBehavior.AllowGet);
            }
            return Json(new { message = "No user with such ID" });
        }

        [HttpGet]
        public JsonResult GetUserWalletByID(int? walletID)
        {
            if (walletID != null && walletID >= 0) 
            {
                var userLogin = User.Identity.Name;
                var wallet = WalletsManager.GetWalletsByLoginAndID(userLogin, (int)walletID);
                return Json(wallet, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpGet]
        public JsonResult GetOperationsByLogin()
        {
            var userLogin = User.Identity.Name;
            var operations = OperationsManager.GetOperationsByLogin(userLogin);
            return Json(operations, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetOperationsByWalletID(int? walletID)
        {
            if (walletID != null && walletID >= 0) 
            {
                var operations = OperationsManager.GetOperationsByWalletsID((int)walletID);
                return Json(operations, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpPost]
        public JsonResult AddOrEditWallet(Wallet wallet)
        {
            if (!string.IsNullOrEmpty(wallet.Name))
            {
                var userLogin = User.Identity.Name;
                bool isSuccess = WalletsManager.AddWallet(wallet, userLogin);
                return Json(new { success = isSuccess });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public JsonResult GetAllCategories()
        {
            var categories = CategoriesManager.GetAllCategories();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddOperation(Operation operation)
        {
            if (operation.WalletID > -1 && operation.CategoryID > -1 && operation.Sum > 0)
            {
                bool isSuccess = OperationsManager.AddOperation(operation);
                return Json(new { success = isSuccess });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult RemoveOperation(int? operationId)
        {
            if (operationId != null && operationId > -1)
            {
                var userLogin = User.Identity.Name;
                bool isSuccess = OperationsManager.RemoveOperation((int)operationId, userLogin);
                return Json(new { success = isSuccess });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult RemoveWallet(int? walletId)
        {
            if (walletId != null && walletId > -1)
            {
                var userLogin = User.Identity.Name;
                bool isSuccess = WalletsManager.RemoveWallet((int)walletId, userLogin);
                return Json(new { success = isSuccess });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult AddOrEditCategory(Category category)
        {
            if (!string.IsNullOrEmpty(category.Name))
            {
                var userLogin = User.Identity.Name;
                var isSuccess = CategoriesManager.AddOrEditCategory(category, userLogin);
                return Json(new { success = isSuccess });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult RemoveCategory(int? categoryId)
        {
            if (categoryId != null && categoryId > -1)
            {
                var userLogin = User.Identity.Name;
                bool isSuccess = CategoriesManager.RemoveCategory((int)categoryId, userLogin);
                return Json(new { success = isSuccess });
            }
            return Json(new { success = false });
        }

    }
}
