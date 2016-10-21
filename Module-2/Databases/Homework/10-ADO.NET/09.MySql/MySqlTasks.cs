namespace MySql
{
    using System;
    using Data.MySqlClient;

    internal class MySqlTasks
    {
        private const string Connection = "Server=localhost; Port=3306; Database=books; Uid=root; Pwd=root; pooling=true";

        private static void Main()
        {
            ListBooks();
            FindBook("Intro to Programming");
            AddABook("Author1", "Title1");
            ListBooks();
        }

        private static void AddABook(string author, string title)
        {
            MySqlConnection connection = new MySqlConnection(Connection);

            connection.Open();
            using (connection)
            {
                MySqlCommand addBook = new MySqlCommand("INSERT INTO booksinfo (title,author) VALUES (@title, @author)", connection);
                addBook.Parameters.AddWithValue("@title", title);
                addBook.Parameters.AddWithValue("@author", author);
                addBook.ExecuteNonQuery();
            }
        }

        private static void FindBook(string bookName)
        {
            MySqlConnection connection = new MySqlConnection(Connection);

            connection.Open();
            using (connection)
            {
                MySqlCommand listBooks = new MySqlCommand("SELECT * FROM booksinfo WHERE Title = '" + bookName + "';", connection);
                var reader = listBooks.ExecuteReader();

                while (reader.Read())
                {
                    string author = (string)reader["Author"];
                    Console.WriteLine($"{bookName} - {author}");
                }
            }
        }

        private static void ListBooks()
        {
            MySqlConnection connection = new MySqlConnection(Connection);

            connection.Open();
            using (connection)
            {
                MySqlCommand listBooks = new MySqlCommand("SELECT Title FROM booksinfo;", connection);
                var reader = listBooks.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0]);
                }
            }
        }
    }
}