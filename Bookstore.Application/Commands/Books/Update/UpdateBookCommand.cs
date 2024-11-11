using Bookstore.Application.Models;
using MediatR;

namespace Bookstore.Application.Commands.Books.Update
{
    public class UpdateBookCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
