namespace BookStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        private ICollection<Review> reviews;
        private ICollection<Author> authors;

        // private ICollection<BooksAuthors> authors;
        public Book()
        {
            this.reviews = new HashSet<Review>();
            this.authors = new HashSet<Author>();
            //this.authors = new HashSet<BooksAuthors>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Index(IsUnique = true)]
        [MinLength(13)]
        [MaxLength(13)]
        public string Isbn { get; set; }

        [Required]
        public decimal? Price { get; set; }

        public string WebSite { get; set; }

        public ICollection<Author> Authors
        {
            get { return this.authors; }
            set { this.authors = value; }
        }

        // public ICollection<BooksAuthors> BooksAuthors
        // {
        //     get { return this.authors; }
        //     set { this.authors = value; }
        // }

        public ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }
    }
}