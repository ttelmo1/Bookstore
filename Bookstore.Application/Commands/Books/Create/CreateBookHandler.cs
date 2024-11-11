using Bookstore.Application.Models;
using Bookstore.Infraestructure.Persistence;
using MediatR;

namespace Bookstore.Application.Commands.Books.Create
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, ResultViewModel<int>>
    {
        private readonly ApplicationDbContext _context;
        public CreateBookHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.ToEntity();

            await _context.Books.AddAsync(book);
            _context.SaveChanges();
            return ResultViewModel<int>.Success(book.Id);
        }
    }
}
