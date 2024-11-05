using Bookstore.Application.Models.InputModel.Books;
using Bookstore.Application.Models.ViewModel.Books;
using Bookstore.Application.Models;
using Bookstore.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<int> Create(CreateBookInputModel model)
        {
            var book = model.ToEntity();

            _context.Books.Add(book);
            _context.SaveChanges();
            return ResultViewModel<int>.Success(book.Id);
        }

        public ResultViewModel Update(UpdateBookInputModel model)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == model.Id);
            if (book == null)
                return ResultViewModel<BookViewModel>.Error("Book not found");

            book.Update(model.Title);
            _context.Books.Update(book);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
                return ResultViewModel<BookViewModel>.Error("Book not found");

            _context.Books.Remove(book);
            _context.SaveChanges();
            return ResultViewModel.Success();
        }

        public ResultViewModel<BookViewModel> GetById(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return ResultViewModel<BookViewModel>.Error("Book not found");

            var model = BookViewModel.FromBook(book);
            return ResultViewModel<BookViewModel>.Success(model);
        }

        public ResultViewModel<List<BookViewModel>> GetAll(string search = "")
        {
            var books = _context.Books
                .Include(b => b.Loans)
                .Where(b => b.Title.Contains(search) || b.Author.Contains(search));
            var model = books.Select(BookViewModel.FromBook).ToList();

            return ResultViewModel<List<BookViewModel>>.Success(model);
        }
    }
}
