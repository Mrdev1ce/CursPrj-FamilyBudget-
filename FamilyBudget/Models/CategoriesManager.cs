using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FamilyBudget.Models
{
    public static class CategoriesManager
    {
        static readonly string ConnectionStr = ConfigurationManager.ConnectionStrings["MainConnectStr"].ConnectionString;

        public static List<Category> GetAllCategories()
        {
            var categories = new List<Category>();
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("GetAllCategories", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string name = (string)reader["Name"];
                    categories.Add(new Category() { ID = id, Name = name });
                }
            }
            return categories;
        }
    }
}