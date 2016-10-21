namespace AddProduct
{
    using System.Data.SqlClient;

    internal class AddProduct
    {
        private static void Main()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=.; Database=Northwind; Integrated Security = true");
            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Products(ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, " + 
                    "UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                    "VALUES (@productName, @supplierId, @categoryId, @quantityPerUnit, @unitPrice, @unitsInStock, " + 
                    "@unitsOnOrder, @reorderLevel, @discontinued)",
                    sqlConnection);

                command.Parameters.AddWithValue("@productName", "NewName");
                command.Parameters.AddWithValue("@supplierId", "1");
                command.Parameters.AddWithValue("@categoryId", "1");
                command.Parameters.AddWithValue("@quantityPerUnit", "1 box");
                command.Parameters.AddWithValue("@unitPrice", "5");
                command.Parameters.AddWithValue("@unitsInStock", "10");
                command.Parameters.AddWithValue("@unitsOnOrder", "15");
                command.Parameters.AddWithValue("@reorderLevel", "5");
                command.Parameters.AddWithValue("@discontinued", "false");
                command.ExecuteNonQuery();
            }
        }
    }
}