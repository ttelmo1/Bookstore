using Bookstore.Application.Models.InputModel.Books;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Application.Services;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult Create(CreateBookInputModel model)
        {
            var result = _bookService.Create(model);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpGet]
        public IActionResult GetAll(string search = "")
        {
            var result = _bookService.GetAll(search);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _bookService.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateBookInputModel model)
        {
            var result = _bookService.Update(model);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _bookService.Delete(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return NoContent();
        }
    }
}
