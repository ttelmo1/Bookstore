using Bookstore.API.Entities;

namespace Bookstore.API.Models.ViewModel.Books
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string author, string isbn, DateTime publishedOn)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = isbn;
            PublishedOn = publishedOn;
        }


        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN{ get; private set; }
        public DateTime PublishedOn { get; private set; }

        public static BookViewModel FromBook(Book book) 
            => new(book.Id, book.Title, book.Author, book.ISBN, book.PublishedOn);
    }
}
