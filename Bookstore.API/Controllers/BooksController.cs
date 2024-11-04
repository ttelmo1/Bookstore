using Bookstore.Infraestructure.Persistence;
using Bookstore.Application.Models.InputModel.Books;
using Bookstore.Application.Models.ViewModel.Books;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateBook(CreateBookInputModel model)
        {
            var book = model.ToEntity();

            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBookById), new { id = 1 }, model);
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _context.Books.Select(b => BookViewModel.FromBook(b)).ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if(book == null)
                return NotFound();
            var model = BookViewModel.FromBook(book);
            return Ok(model); 
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, UpdateBookInputModel model)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if(book == null)
                return NotFound();

            book.Update(model.Title);
            _context.Books.Update(book);
            _context.SaveChanges();
               
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
