using Bookstore.Core.Entities;

namespace Bookstore.Application.Models.InputModel.Loans
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
