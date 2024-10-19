namespace Bookstore.API.Entities
{
    public class Loan
    {
        public Loan(int idUser, int idBook, DateTime loanDate, DateTime returnDate)
        {
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }

        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnDate { get; private set; }

        public void EndLoan(DateTime returnDate)
        {
            ReturnDate = returnDate;
        }
    }
}
