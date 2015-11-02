using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyBudget.Models
{
    public class LoginModel
    {
        public static bool IsLoginSuccess(string login, string password)
        {
            return UsersManager.GetUserByLoginAndPass(login, password) != null;
        }
    }
}