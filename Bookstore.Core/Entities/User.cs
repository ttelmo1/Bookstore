namespace Bookstore.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, DateTime birthDate, bool active)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Active = active;

            Loans = [];
        }


        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }
        public List<Loan> Loans { get; private set; }
    }
}
