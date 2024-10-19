namespace Bookstore.API.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string iSBN, DateTime publishedOn) : base()
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublishedOn = publishedOn;
        }

        public string Title { get; private set; }
        public string  Author { get; private set; }
        public string ISBN { get; private set; }
        public DateTime PublishedOn { get; private set; }
        public List<Loan> Loans { get; private set; }

        public void Update(string title)
        {
            Title = title;
        }
    }
}
