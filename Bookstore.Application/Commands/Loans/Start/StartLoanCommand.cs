using Bookstore.Application.Models;
using Bookstore.Core.Entities;
using MediatR;

namespace Bookstore.Application.Commands.Loans.Start
{
    public class StartLoanCommand : IRequest<ResultViewModel>
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Loan ToEntity()
            => new(IdUser, IdBook, LoanDate, ReturnDate);
    }
}
