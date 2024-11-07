using Bookstore.Application.Models.InputModel.Users;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Infraestructure.Persistence;
using Bookstore.Application.Services;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Create(CreateUserInputModel model)
        {
            var result = _userService.Create(model);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpGet]
        public IActionResult GetAll(string search = "")
        {
            var result = _userService.GetAll(search);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           var result = _userService.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateUserInputModel model)
        {
            var result = _userService.Update(model);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _userService.Delete(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return NoContent();
        }
        
    }
}
