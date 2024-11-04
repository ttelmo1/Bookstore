namespace Bookstore.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
