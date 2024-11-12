using System;
using Bookstore.Application.Models;
using Bookstore.Application.Models.ViewModel.Books;
using Bookstore.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Queries.Books.GetAllBooks;

public class GetAllBookHandler : IRequestHandler<GetAllBooksQuery, ResultViewModel<List<BookViewModel>>>
{
    private readonly ApplicationDbContext _context;
    public GetAllBookHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<List<BookViewModel>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _context.Books
            .Include(b => b.Loans)
            .Where(b => b.Title.Contains(request.Search) || b.Author.Contains(request.Search))
            .ToListAsync();
        
        var model = books.Select(BookViewModel.FromBook).ToList();

        return ResultViewModel<List<BookViewModel>>.Success(model);
    }
}
