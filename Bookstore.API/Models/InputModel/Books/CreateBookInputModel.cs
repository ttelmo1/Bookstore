using Bookstore.API.Entities;

namespace Bookstore.API.Models.InputModel.Books
{
    public class CreateBookInputModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedOn { get; set; }

        public Book ToEntity()
            => new(Title, Author, ISBN, PublishedOn);

        public void Validate()
        {
            if (string.IsNullOrEmpty(Title))
                throw new System.Exception("Title is required");
            if (string.IsNullOrEmpty(Author))
                throw new System.Exception("Author is required");
            if (string.IsNullOrEmpty(ISBN))
                throw new System.Exception("ISBN is required");
            if (PublishedOn == default)
                throw new System.Exception("PublishedOn is required");
        }
    }
}
