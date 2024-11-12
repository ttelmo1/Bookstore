using Bookstore.Application.Models;
using Bookstore.Infraestructure.Persistence;
using MediatR;

namespace Bookstore.Application.Commands.Loans.Start;

public class StartLoanHandler : IRequestHandler<StartLoanCommand, ResultViewModel>
{
    private readonly ApplicationDbContext _context;
    public StartLoanHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel> Handle(StartLoanCommand request, CancellationToken cancellationToken)
    {
        request.LoanDate = DateTime.Now;
        var loan = request.ToEntity();

        await _context.Loans.AddAsync(loan);
        _context.SaveChanges();
        return ResultViewModel.Success();
    }
}
