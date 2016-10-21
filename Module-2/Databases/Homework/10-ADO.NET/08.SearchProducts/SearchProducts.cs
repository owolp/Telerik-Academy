namespace SearchProducts
{
    using System;
    using System.Data.SqlClient;

    internal class SearchProducts
    {
        private static void Main()
        {
            Console.WriteLine("Enter search criteria");
            var searchCriteria = Console.ReadLine().Replace("%", "[%]").Replace("_", "[_]");

            SqlConnection sqlConnection = new SqlConnection("Server=.; Database=Northwind; Integrated Security = true");

            sqlConnection.Open();
            using (sqlConnection)
            {
                SqlCommand command = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName like @searchCriteria GROUP BY ProductName", sqlConnection);
                command.Parameters.AddWithValue("@searchCriteria", "%" + searchCriteria + "%");

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var productName = (string)reader["ProductName"];
                    Console.WriteLine(productName);
                }
            }
        }
    }
}