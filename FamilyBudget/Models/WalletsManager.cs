﻿using System;
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

        public static Wallet GetWalletsByLoginAndID(string userLogin, int walletID)
        {
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("GetWalletByLoginAndID", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@userLogin", userLogin);
                command.Parameters.AddWithValue("@walletID", walletID);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string name = (string)reader["Name"];
                    int funds = (int)reader["Funds"];
                    int ownerID = (int)reader["OwnerID"];
                    return new Wallet() { ID = id, Name = name, Funds = funds, OwnerID = ownerID };
                }
            }
            return null;
        }

        public static bool AddWallet(Wallet wallet, string userLogin)
        {
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("AddWallet", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@userLogin", userLogin);
                command.Parameters.AddWithValue("@walletID", wallet.ID);
                command.Parameters.AddWithValue("@walletName", wallet.Name);
                command.Parameters.AddWithValue("@walletFunds", wallet.Funds);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool RemoveWallet(int walletId, string userLogin)
        {
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("RemoveWallet", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@walletId", walletId);
                command.Parameters.AddWithValue("@userLogin", userLogin);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public static List<Wallet> GetWalletsById(int userId)
        {
            var wallets = new List<Wallet>();
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("GetWalletsByOwnerId", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@OwnerID", userId);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string name = (string)reader["Name"];
                    int funds = (int)reader["Funds"];
                    wallets.Add(new Wallet() { ID = id, Name = name, Funds = funds, OwnerID = userId });
                }
            }
            return wallets.Count > 0 ? wallets : null;
        }
    }
}