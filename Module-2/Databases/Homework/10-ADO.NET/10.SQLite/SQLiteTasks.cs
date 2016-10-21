namespace SQLite
{
    using System;
    using System.Data.SQLite;

    internal class SQLiteTasks
    {
        private const string Connection = "Data Source= ..\\..\\Books.db; Version=3";

        private static void Main()
        {
            ListBooks();
            FindBook("Intro to Programming with C#");
            AddABook("Earle Castledine", "jQuery: Novice To Ninja");
            ListBooks();
        }

        private static void AddABook(string author, string title)
        {
            SQLiteConnection connection = new SQLiteConnection(SQLiteTasks.Connection);

            connection.Open();
            using (connection)
            {
                SQLiteCommand addBook = new SQLiteCommand("INSERT INTO booksinfo (title,author) VALUES (@title, @author)", connection);
                addBook.Parameters.AddWithValue("@title", title);
                addBook.Parameters.AddWithValue("@author", author);
                addBook.ExecuteNonQuery();
            }
        }

        private static void FindBook(string bookName)
        {
            SQLiteConnection connection = new SQLiteConnection(SQLiteTasks.Connection);

            connection.Open();
            using (connection)
            {
                SQLiteCommand listBooks = new SQLiteCommand("SELECT * FROM booksinfo WHERE Title = '" + bookName + "';", connection);
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
            SQLiteConnection connection = new SQLiteConnection(SQLiteTasks.Connection);

            connection.Open();
            using (connection)
            {
                SQLiteCommand listBooks = new SQLiteCommand("SELECT Title FROM booksinfo;", connection);
                var reader = listBooks.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0]);
                }
            }
        }
    }
}