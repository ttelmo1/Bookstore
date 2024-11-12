using Bookstore.Application.Models;
using MediatR;

namespace Bookstore.Application.Commands.Loans.End;

public class EndLoanCommand : IRequest<ResultViewModel>
{
    public EndLoanCommand(int idBook, int idUser)
    {
        IdBook = idBook;
        IdUser = idUser;
    }
    public int IdBook { get; private set; }
    public int IdUser { get; private set; }
}
