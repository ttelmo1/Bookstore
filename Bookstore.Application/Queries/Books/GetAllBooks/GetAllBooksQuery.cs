using System;
using Bookstore.Application.Models;
using Bookstore.Application.Models.ViewModel.Books;
using MediatR;

namespace Bookstore.Application.Queries.Books.GetAllBooks;

public class GetAllBooksQuery : IRequest<ResultViewModel<List<BookViewModel>>>
{
    public string Search { get; set; }
    public GetAllBooksQuery(string search)
    {
        Search = search;
    }
}
