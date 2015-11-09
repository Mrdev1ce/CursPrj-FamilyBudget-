using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FamilyBudget.Models
{
    public static class WalletsManager
    {
        static readonly string ConnectionStr = ConfigurationManager.ConnectionStrings["MainConnectStr"].ConnectionString;

        public static List<Wallet> GetWalletsByLogin(string userLogin)
        {
            var wallets = new List<Wallet>();
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("GetWalletsByLogin", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@userLogin", userLogin);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string name = (string)reader["Name"];
                    int funds = (int)reader["Funds"];
                    int ownerID = (int)reader["OwnerID"];
                    wallets.Add(new Wallet() {ID = id, Name = name, Funds = funds, OwnerID = ownerID });
                }
            }
            return wallets;
        }
    }
}