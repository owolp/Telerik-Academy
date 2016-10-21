namespace NumberOfRows
{
    using System;
    using System.Data.SqlClient;

    internal class NumberOfRows
    {
        private static void Main()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=.; Database=Northwind; Integrated Security = true");
            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Categories", sqlConnection);
                int categoriesCount = (int)command.ExecuteScalar();
                Console.WriteLine("Categories count: {0}", categoriesCount);
            }
        }
    }
}