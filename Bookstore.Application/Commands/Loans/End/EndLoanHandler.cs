using Bookstore.Application.Models;
using Bookstore.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Commands.Loans.End;

public class EndLoanHandler : IRequestHandler<EndLoanCommand, ResultViewModel>
{
    private readonly ApplicationDbContext _context;
    public EndLoanHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel> Handle(EndLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _context.Loans.SingleOrDefaultAsync(l => l.IdBook == request.IdBook && l.IdUser == request.IdUser);
        if (loan == null)
            return ResultViewModel.Error("Loan not found");
        
        if(loan.ReturnDate < DateTime.Now)
            return ResultViewModel.Error("Data de devolução ultrapassada");
        
        loan.EndLoan(DateTime.Now);
        _context.Loans.Update(loan);
        await _context.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}
