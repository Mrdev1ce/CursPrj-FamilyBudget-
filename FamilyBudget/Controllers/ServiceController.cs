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

    }
}
