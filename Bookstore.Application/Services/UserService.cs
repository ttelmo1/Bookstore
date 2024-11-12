using Bookstore.Application.Models;
using Bookstore.Application.Models.InputModel.Users;
using Bookstore.Application.Models.ViewModel.Users;
using Bookstore.Infraestructure.Persistence;

namespace Bookstore.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<int> Create(CreateUserInputModel model)
        {
            var user = model.ToEntity();

            _context.Users.Add(user);
            _context.SaveChanges();
            return ResultViewModel<int>.Success(user.Id);
        }

        public ResultViewModel Update(UpdateUserInputModel model)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == model.Id);
            if (user == null)
                return ResultViewModel<UserViewModel>.Error("User not found");

            user.Update(model.Name, model.Email);
            _context.Users.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user == null)
                return ResultViewModel<UserViewModel>.Error("User not found");

            _context.Users.Remove(user);
            _context.SaveChanges();
            return ResultViewModel.Success();
        }

        public ResultViewModel<List<UserViewModel>> GetAll(string search = "")
        {
            var users = _context.Users
                .Where(u => u.Name.Contains(search));
            var model = users.Select(UserViewModel.FromEntity).ToList();
            return ResultViewModel<List<UserViewModel>>.Success(model);
        }

        public ResultViewModel<UserViewModel> GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return ResultViewModel<UserViewModel>.Error("User not found");

            var model = UserViewModel.FromEntity(user);
            return ResultViewModel<UserViewModel>.Success(model);
        }
    }
}
