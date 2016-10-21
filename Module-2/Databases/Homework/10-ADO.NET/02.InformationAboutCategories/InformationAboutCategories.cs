namespace InformationAboutCategories
{
    using System;
    using System.Data.SqlClient;

    internal class InformationAboutCategories
    {
        private static void Main()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=.; Database=Northwind; Integrated Security = true");
            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Categories", sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine($"Category name: {categoryName}");
                        Console.WriteLine($"Description: {description}");
                        Console.WriteLine(new string('-', 20));
                    }
                }
            }
        }
    }
}