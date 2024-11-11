using Bookstore.Application.Models;
using Bookstore.Application.Models.ViewModel.Books;
using Bookstore.Infraestructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Commands.Books.Update
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
    {
        private readonly ApplicationDbContext _context;
        public UpdateBookHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == request.Id);
            if (book == null)
                return ResultViewModel<BookViewModel>.Error("Book not found");

            book.Update(request.Title);
            _context.Books.Update(book);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
