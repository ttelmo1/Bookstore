using Bookstore.Application.Models;
using Bookstore.Application.Models.ViewModel.Users;
using Bookstore.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Bookstore.Application.Commands.Users.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly ApplicationDbContext _context;
        public DeleteUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id);
            if (user == null)
                return ResultViewModel<UserViewModel>.Error("User not found");

            _context.Users.Remove(user);
            _context.SaveChanges();
            return ResultViewModel.Success();
        }
        
    }
}
