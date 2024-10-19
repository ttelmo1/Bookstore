using Bookstore.API.Entities;

namespace Bookstore.API.Models.InputModel.Users
{
    public class CreateUserInputModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; } = true;

        public User ToEntity()
            => new(Name, Email, BirthDate, Active);
    }
}
