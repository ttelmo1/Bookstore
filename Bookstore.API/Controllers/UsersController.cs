using Bookstore.API.Models.InputModel.Users;
using Microsoft.AspNetCore.Mvc;
using Bookstore.API.Data;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserInputModel model)
        {
            var user = model.ToEntity();
            
            _context.Users.Add(user);
            _context.SaveChanges();

            return Created();
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if(user == null)
                return NotFound();
            return Ok(user);
        }
        
    }
}
