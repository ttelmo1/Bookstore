using Bookstore.Core.Entities;

namespace Bookstore.Application.Models.ViewModel.Users
{
    public class UsersViewModel
    {
        public UsersViewModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            BirthDate = user.BirthDate;
            Active = user.Active;
            Loans = user.Loans;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public List<Loan> Loans { get; set; }

    }
}
