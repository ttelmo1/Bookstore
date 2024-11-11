using Bookstore.Application.Models;
using Bookstore.Core.Entities;
using MediatR;

namespace Bookstore.Application.Commands.Users.Create
{
    public class CreateUserCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; } = true;

        public User ToEntity()
            => new(Name, Email, BirthDate, Active);

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new System.Exception("Name is required");

            if (string.IsNullOrEmpty(Email))
                throw new System.Exception("Email is required");
            
            if (BirthDate == default)
                throw new System.Exception("BirthDate is required");
        }
    }
}
