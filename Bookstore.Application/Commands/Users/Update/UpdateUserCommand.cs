using Bookstore.Application.Models;
using MediatR;

namespace Bookstore.Application.Commands.Users.Update
{
    public class UpdateUserCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
