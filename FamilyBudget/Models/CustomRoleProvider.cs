//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.Security;

//namespace FamilyBudget.Models
//{
//    public class CustomRoleProvider : RoleProvider
//    {
//        //static readonly string ConnectionStr = ConfigurationManager.ConnectionStrings["MainConnectStr"].ConnectionString;

//        public override string[] GetAllRoles()
//        {
//            return new[] {"Admin", "User"};
//        }

//        //public override string[] GetRolesForUser(string userLogin)
//        //{
//        //    List<string> roles = new List<string>();
//        //    using (var connection = new SqlConnection(ConnectionStr))
//        //    {
//        //        var command = new SqlCommand("Select [Name] From [dbo].[UserRoles] Join [dbo].[Users] on [Users].[RoleID] = [UserRoles].[ID] Where [Users].[Login] = @userLogin", connection);
//        //        command.Parameters.AddWithValue("@userLogin", userLogin);
//        //        connection.Open();
//        //        var reader = command.ExecuteReader();
//        //        while (reader.Read())
//        //        {
//        //            roles.Add((string)reader["Name"]);
//        //        }
//        //    }
//        //    return roles.ToArray();
//        //}

//        //public override string[] GetUsersInRole(string roleName)
//        //{
//        //    List<string> users = new List<string>();
//        //    using (var connection = new SqlConnection(ConnectionStr))
//        //    {
//        //        var command = new SqlCommand("Select [Login] From [dbo].[Users] Join [dbo].[UserRoles] on [Users].[RoleID] = [UserRoles].[ID] Where [UserRoles].[Name] = @roleName", connection);
//        //        command.Parameters.AddWithValue("@roleName", roleName);
//        //        connection.Open();
//        //        var reader = command.ExecuteReader();
//        //        while (reader.Read())
//        //        {
//        //            users.Add((string)reader["Name"]);
//        //        }
//        //    }
//        //    return users.ToArray();
//        //}

//        //public override bool IsUserInRole(string userLogin, string roleName)
//        //{
//        //    using (var connection = new SqlConnection(ConnectionStr))
//        //    {
//        //        var command = new SqlCommand("Select [Login] From [dbo].[Users] Join [dbo].[UserRoles] on [Users].[RoleID] = [UserRoles].[ID] Where [UserRoles].[Name] = @roleName AND [Users].[Login] = @userLogin", connection);
//        //        command.Parameters.AddWithValue("@roleName", roleName);
//        //        command.Parameters.AddWithValue("@userLogin", userLogin);
//        //        connection.Open();
//        //        var reader = command.ExecuteReader();
//        //        return reader.Read();
//        //    }
//        //}
//        #region NotImp
//        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
//        {
//            throw new NotImplementedException();
//        }

//        public override string ApplicationName
//        {
//            get
//            {
//                throw new NotImplementedException();
//            }
//            set
//            {
//                throw new NotImplementedException();
//            }
//        }

//        public override void CreateRole(string roleName)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
//        {
//            throw new NotImplementedException();
//        }

//        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
//        {
//            throw new NotImplementedException();
//        }
//        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool RoleExists(string roleName)
//        {
//            throw new NotImplementedException();
//        }
//        #endregion
//    }
//}