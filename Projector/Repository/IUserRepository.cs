using Domain.dao;
using Microsoft.EntityFrameworkCore;

namespace Projector.Repository
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"");
        }
    }
}