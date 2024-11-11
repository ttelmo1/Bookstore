using Bookstore.Application.Models;
using Bookstore.Infraestructure.Persistence;
using MediatR;

namespace Bookstore.Application.Commands.Users.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ResultViewModel<int>>
    {
        private readonly ApplicationDbContext _context;
        public CreateUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.ToEntity();

            await _context.Users.AddAsync(user);
            _context.SaveChanges();
            return ResultViewModel<int>.Success(user.Id);
        }
    }
}
