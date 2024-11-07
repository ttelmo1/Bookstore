using Bookstore.Application.Models;
using Bookstore.Application.Models.InputModel.Users;
using Bookstore.Application.Models.ViewModel.Users;

namespace Bookstore.Application.Services
{
    public interface IUserService
    {
        ResultViewModel<int> Create(CreateUserInputModel model);
        ResultViewModel Update(UpdateUserInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel<UserViewModel> GetById(int id);
        ResultViewModel<List<UserViewModel>> GetAll(string search = "");
    }
}