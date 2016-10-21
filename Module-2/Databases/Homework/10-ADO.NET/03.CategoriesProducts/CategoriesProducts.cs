namespace CategoriesProducts
{
    using System;
    using System.Data.SqlClient;

    internal class CategoriesProducts
    {
        private static void Main()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=.; Database=Northwind; Integrated Security = true");
            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT p.ProductName AS [Product], " +
                    "c.CategoryName AS [Category] FROM Products p " +
                    "JOIN Categories c ON p.CategoryID = c.CategoryID",
                    sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["Product"];
                        string products = (string)reader["Category"];
                        Console.WriteLine($"Product: {categoryName}");
                        Console.WriteLine($"Category: {products}");
                        Console.WriteLine(new string('-', 20));
                    }
                }
            }
        }
    }
}