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

        public static bool AddOrEditCategory(Category category, string userLogin)
        {
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("AddCategory", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@userLogin", userLogin);
                command.Parameters.AddWithValue("@categoryId", category.ID);
                command.Parameters.AddWithValue("@categoryName", category.Name);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool RemoveCategory(int categoryId, string userLogin)
        {
            using (var connection = new SqlConnection(ConnectionStr))
            {
                var command = new SqlCommand("RemoveCategory", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@userLogin", userLogin);
                command.Parameters.AddWithValue("@categoryId", categoryId);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}