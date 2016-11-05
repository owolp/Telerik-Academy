namespace BookStore.Data
{
    using System.Data.Entity;
    using Models;

    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext()
            : base("BookStore")
        {
        }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Book> Books { get; set; }

        //public IDbSet<BooksAuthors> BooksAuthors { get; set; }

        public IDbSet<Review> Reviews { get; set; }
    }
}