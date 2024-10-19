using Bookstore.API.Entities;

namespace Bookstore.API.Models.InputModel.Loans
{
    public class StartLoanInputModel
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Loan ToEntity()
            => new(IdUser, IdBook, LoanDate, ReturnDate);
    }
}
