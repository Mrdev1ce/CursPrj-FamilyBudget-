using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FamilyBudget.Models
{
    public class CustomRoleProvider : RoleProvider
    {
        static readonly string ConnectionStr = ConfigurationManager.ConnectionStrings["MainConnectStr"].ConnectionString;

        public override string[] GetAllRoles()
        {
            return new[] { "Admin", "User" };
        }

        public override string[] GetRolesForUser(string userLogin)
        {
            var roles = new List<string>();
            using (var connection = new SqlConnection(ConnectionStr))
            {
                SqlParameter isAdmin = new SqlParameter("@isAdmin", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                var command = new SqlCommand("IsAdmin", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@userLogin", userLogin);
                command.Parameters.Add(isAdmin);
                connection.Open();
                command.ExecuteNonQuery();
                if (isAdmin.Value != null)
                {
                    roles.Add((bool)isAdmin.Value ? "Admin" : "User");
                }
            }

            return roles.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            List<string> users = new List<string>();
            var role = roleName == "Admin";
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("GetAllUsersInRole", connection) {CommandType = CommandType.StoredProcedure};
                command.Parameters.AddWithValue("@role", role);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add((string)reader["Login"]);
                }
            }
            return users.ToArray();
        }

        public override bool IsUserInRole(string userLogin, string roleName)
        {
            var role = roleName == "Admin";
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("IsUserInRole", connection) {CommandType = CommandType.StoredProcedure};
                command.Parameters.AddWithValue("@role", role);
                command.Parameters.AddWithValue("@userLogin", userLogin);
                connection.Open();
                var reader = command.ExecuteReader();
                return reader.Read();
            }
        }
        #region NotImp
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}