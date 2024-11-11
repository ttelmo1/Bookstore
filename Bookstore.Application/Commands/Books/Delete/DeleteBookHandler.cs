using Bookstore.Application.Models;
using Bookstore.Application.Models.ViewModel.Books;
using Bookstore.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Commands.Books.Delete
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ResultViewModel>
    {
        private readonly ApplicationDbContext _context;
        public DeleteBookHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == request.Id);
            if (book == null)
                return ResultViewModel<BookViewModel>.Error("Book not found");

            _context.Books.Remove(book);
            _context.SaveChanges();
            return ResultViewModel.Success();
        }
    }
}
