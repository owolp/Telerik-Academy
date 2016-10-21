namespace ExcelReader
{
    using System;
    using System.Data.OleDb;

    internal class Excel
    {
        private const string Connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= ..\\..\\students.xlsx; Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";

        private static void Main(string[] args)
        {
            ListContent();
            InsertRow("Telerik Student", 30);
            ListContent();
        }

        private static void ListContent()
        {
            /*6. Create an Excel file with 2 columns: name and score:
             * Write a program that reads your MS Excel file through the OLE DB
             * data provider and displays the name and score row by row.
             */

            OleDbConnection sqlConnection = new OleDbConnection(Connection);
            sqlConnection.Open();
            using (sqlConnection)
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM [Results$]", sqlConnection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var name = (string)reader["Name"];
                    var score = (double)reader["Score"];
                    Console.WriteLine($"{name} - {score}");
                }
            }
        }

        private static void InsertRow(string name, double score)
        {
            /*7. Implement appending new rows to the Excel file. */

            OleDbConnection sqlConnection = new OleDbConnection(Connection);
            sqlConnection.Open();
            using (sqlConnection)
            {
                OleDbCommand insertIntoExcell = new OleDbCommand("INSERT INTO [Results$] (Name,Score) VALUES (@Name,@Score)", sqlConnection);

                insertIntoExcell.Parameters.AddWithValue("@Name", name);
                insertIntoExcell.Parameters.AddWithValue("@Score", score);
                insertIntoExcell.ExecuteNonQuery();
            }
        }
    }
}