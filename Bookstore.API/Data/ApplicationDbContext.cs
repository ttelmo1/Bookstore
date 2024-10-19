using Bookstore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Book>(e =>
                { 
                    e.HasKey(b => b.Id);
                });


            modelBuilder
                .Entity<User>(e =>
                {
                    e.HasKey(u => u.Id);
                });

            modelBuilder
                .Entity<Loan>(e =>
                {
                    e.HasKey(ub => new {ub.IdUser, ub.IdBook});

                    e.HasOne(ub => ub.User)
                        .WithMany(u => u.Loans)
                        .HasForeignKey(ub => ub.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(ub => ub.Book)
                        .WithMany(b => b.Loans)
                        .HasForeignKey(ub => ub.IdBook)
                        .OnDelete(DeleteBehavior.Restrict);
                });
        }
    }
}
