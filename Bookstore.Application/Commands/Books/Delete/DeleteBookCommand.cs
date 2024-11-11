using Bookstore.Application.Models;
using MediatR;

namespace Bookstore.Application.Commands.Books.Delete
{
    public class DeleteBookCommand : IRequest<ResultViewModel>
    {
        public DeleteBookCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
