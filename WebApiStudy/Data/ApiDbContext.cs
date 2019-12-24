using Microsoft.EntityFrameworkCore;
using WebApiStudy.Data.Entity;

namespace WebApiStudy.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<User> UsersList { get; set; }
        public DbSet<Bid> BidsList { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
