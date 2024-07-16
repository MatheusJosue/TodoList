using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Infrastructure.Data.Repositories.Interface.Context
{
    public class MySQLContext(DbContextOptions<MySQLContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<User> User { get; set; }
        public DbSet<Card> Card { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
