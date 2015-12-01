using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FamilyBudget.Models
{
    public static class UsersManager
    {
        static readonly string ConnectionStr = ConfigurationManager.ConnectionStrings["MainConnectStr"].ConnectionString;

        public static User GetUserByLoginAndPass(string userLogin, string password)
        {
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("GetUserByCredentional", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@login", userLogin);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int) reader["ID"];
                    string login = (string) reader["Login"];
                    string pass = (string) reader["Password"];
                    string mail = (string) reader["Mail"];
                    DateTime registrationDate = (DateTime) reader["RegistrationDate"];
                    bool isAdmin = (bool) reader["isAdmin"];
                    return new User() { ID = id, Login = login, Password = pass, Mail = mail, RegistrationDate = registrationDate, IsAdmin = isAdmin};
                }
            }
            return null;
        }

        public static void AddUser(User user)
        {
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("AddUser", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Mail", user.Mail);
                command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                connection.Open();
                command.ExecuteNonQuery();
            }
            
        }

        public static User GetUserInfo(string userLogin)
        {
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("GetUserInfo", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@userLogin", userLogin);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string mail = (string)reader["Mail"];
                    DateTime registrationDate = (DateTime)reader["RegistrationDate"];
                    bool isAdmin = (bool)reader["isAdmin"];
                    return new User() { ID = id, Mail = mail, RegistrationDate = registrationDate, IsAdmin = isAdmin };
                }
            }
            return null;
        }

        public static List<User> GetAllUsersInfo(string userLogin)
        {
            var users = new List<User>();
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("GetAllUsers", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@userLogin", userLogin);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string login = (string) reader["Login"];
                    string mail = (string)reader["Mail"];
                    DateTime registrationDate = (DateTime)reader["RegistrationDate"];
                    bool isAdmin = (bool)reader["isAdmin"];
                    users.Add(new User() { ID = id, Login = login, Mail = mail, RegistrationDate = registrationDate, IsAdmin = isAdmin });
                }
            }
            return users.Count > 0 ? users : null;
        }

        public static bool ChangeUserPassword(string userLogin, string userOldPass, string userNewPass)
        {
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("ChangeUserPassword", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@userLogin", userLogin);
                command.Parameters.AddWithValue("@userOldPassword", userOldPass);
                command.Parameters.AddWithValue("@userNewPassword", userNewPass);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}