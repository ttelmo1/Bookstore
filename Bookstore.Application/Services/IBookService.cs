using Bookstore.Application.Models;
using Bookstore.Application.Models.InputModel.Books;
using Bookstore.Application.Models.ViewModel.Books;
using Bookstore.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Services
{
    public interface IBookService
    {
        ResultViewModel<int> Create(CreateBookInputModel model);
        ResultViewModel Update(UpdateBookInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel<BookViewModel> GetById(int id);
        ResultViewModel<List<BookViewModel>> GetAll(string search = "");
    }
}