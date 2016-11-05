namespace BookStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Author
    {
        private ICollection<Book> books;

        // private ICollection<BooksAuthors> books;
        private ICollection<Review> reviews;

        public Author()
        {
            this.books = new HashSet<Book>();
            this.reviews = new HashSet<Review>();
        }

        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }

        // public ICollection<BooksAuthors> Books
        // {
        //     get { return this.books; }
        //     set { this.books = value; }
        // }
        public ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }
    }
}