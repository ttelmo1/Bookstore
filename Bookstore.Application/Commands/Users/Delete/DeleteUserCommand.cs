using Bookstore.Application.Models;
using MediatR;

namespace Bookstore.Application.Commands.Users.Delete
{
    public class DeleteUserCommand : IRequest<ResultViewModel>
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
