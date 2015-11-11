using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FamilyBudget.Models
{
    public static class OperationsManager
    {
        static readonly string ConnectionStr = ConfigurationManager.ConnectionStrings["MainConnectStr"].ConnectionString;

        public static List<Operation> GetOperationsByLogin(string userLogin)
        {
            var operations = new List<Operation>();
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("GetOperationsByLogin", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@userLogin", userLogin);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string walletName = (string)reader["WalletName"];
                    int walletId = (int)reader["WalletID"];
                    bool type = (bool)reader["Type"];
                    int sum = (int)reader["Sum"];
                    DateTime date = (DateTime)reader["Date"];
                    string categoryName = (string)reader["CategoryName"];
                    operations.Add(new Operation() { ID = id, WalletName = walletName, WalletID = walletId, Type = type, Sum = sum, Date = date, CategoryName = categoryName });
                }
            }
            return operations;
        }

        public static List<Operation> GetOperationsByWalletsID(int walletID)
        {
            var operations = new List<Operation>();
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("GetOperationsByWalletID", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@WalletID", walletID);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    int walletId = (int)reader["WalletID"];
                    bool type = (bool)reader["Type"];
                    int sum = (int)reader["Sum"];
                    DateTime date = (DateTime)reader["Date"];
                    string categoryName = (string)reader["CategoryName"];
                    operations.Add(new Operation() { ID = id, WalletID = walletId, Type = type, Sum = sum, Date = date, CategoryName = categoryName });
                }
            }
            return operations;
        }
    }
}