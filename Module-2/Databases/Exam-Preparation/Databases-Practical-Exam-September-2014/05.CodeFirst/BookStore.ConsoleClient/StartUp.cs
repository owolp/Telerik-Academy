namespace BookStore.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using BookStore.Data;
    using Models;

    public class StartUp
    {
        private static BookStoreDbContext db;

        public static void Main()
        {
            Import();
            Search();
        }

        public static void Import()
        {
            db = new BookStoreDbContext();

            var xmlBooks = XElement.Load(@"..\..\..\complex-import.xml").Elements();

            foreach (var xmlBook in xmlBooks)
            {
                var currentBook = new Book();
                currentBook.Title = xmlBook.Element("title").Value;

                var isbn = xmlBook.Element("isbn");
                if (isbn != null)
                {
                    var bookExists = db.Books.Any(b => b.Isbn == isbn.Value);
                    if (bookExists)
                    {
                        throw new ArgumentException("Isbn already exists");
                    }

                    currentBook.Isbn = isbn.Value;
                }

                var price = xmlBook.Element("price");
                if (price != null)
                {
                    currentBook.Price = decimal.Parse(price.Value);
                }

                var website = xmlBook.Element("web-site");
                if (website != null)
                {
                    currentBook.WebSite = website.Value;
                }

                var xmlAuthors = xmlBook.Element("authors");
                if (xmlAuthors != null)
                {
                    var xmlAuthorsAuthor = xmlAuthors.Elements("author");
                    foreach (XElement xmlAuthor in xmlAuthorsAuthor)
                    {
                        var authorName = xmlAuthor.Value;
                        var author = GetAuthor(authorName);

                        currentBook.Authors.Add(author);
                    }
                }

                var xmlReviews = xmlBook.Element("reviews");
                if (xmlReviews != null)
                {
                    var xmlReviewsReview = xmlReviews.Elements("review");
                    foreach (XElement xmlReview in xmlReviewsReview)
                    {
                        var reviewContent = xmlReview.Value;
                        var createdOn = xmlReview.Attribute("date");

                        var authorName = xmlReview.Attribute("author");

                        var review = new Review
                        {
                            Content = reviewContent,
                            CreatedOn = createdOn == null ? DateTime.Now : DateTime.Parse(createdOn.Value)
                        };

                        if (authorName != null)
                        {
                            var name = GetAuthor(authorName.Value);
                            review.Author = name;
                        }

                        currentBook.Reviews.Add(review);
                    }
                }

                db.Books.Add(currentBook);
                db.SaveChanges();
            }
        }

        public static Author GetAuthor(string authorName)
        {
            var author = db.Authors.FirstOrDefault(a => a.Name == authorName);
            if (author == null)
            {
                author = new Author
                {
                    Name = authorName
                };
            }

            return author;
        }

        public static void Search()
        {
            db = new BookStoreDbContext();
            var result = new XElement("search-results");

            var xmlQueries = XElement.Load(@"..\..\..\reviews-queries.xml").Elements();

            foreach (var xmlQuery in xmlQueries)
            {
                var queryInReviews = db.Reviews;

                if (xmlQuery.Attribute("type").Value == "by-period")
                {
                    var startDate = DateTime.Parse(xmlQuery.Element("start-date").Value);
                    var endDate = DateTime.Parse(xmlQuery.Element("end-date").Value);

                    queryInReviews
                        .Where(r => startDate <= r.CreatedOn &&
                                    r.CreatedOn <= endDate);
                }

                if (xmlQuery.Attribute("type").Value == "by-author")
                {
                    var authorName = xmlQuery.Element("author-name").Value;

                    queryInReviews
                        .Where(r => r.Author.Name == authorName);
                }

                var resultSet = queryInReviews
                    .OrderBy(r => r.CreatedOn)
                    .ThenBy(r => r.Content)
                    .Select(r => new
                    {
                        Date = r.CreatedOn,
                        Content = r.Content,
                        Book = new
                        {
                            Title = r.Book.Title,
                            Author = r.Book.Authors
                                .OrderBy(a => a.Name).Select(a => a.Name)
                        },
                        ISBN = r.Book.Isbn,
                        URL = r.Book.WebSite
                    })
                    .ToList();

                var xmlResultSet = new XElement("result-set");

                foreach (var reviewInResult in resultSet)
                {
                    var xmlReview = new XElement("review");
                    xmlReview.Add(new XElement("date", reviewInResult.Date.ToString("d-MMM-yyyy")));
                    xmlReview.Add(new XElement("content", reviewInResult.Content));

                    xmlResultSet.Add(xmlReview);
                }

                result.Add(xmlResultSet);
            }

            result.Save(@"..\..\..\reviews-search-results.xml");
        }
    }
}