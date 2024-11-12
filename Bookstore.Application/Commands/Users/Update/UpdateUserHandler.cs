using Bookstore.Application.Models;
using Bookstore.Application.Models.ViewModel.Users;
using Bookstore.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Commands.Users.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly ApplicationDbContext _context;
        public UpdateUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id);
            if (user == null)
                return ResultViewModel<UserViewModel>.Error("User not found");

            user.Update(request.Name, request.Email);
            _context.Users.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
