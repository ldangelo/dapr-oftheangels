using Domain.dao;
using Microsoft.EntityFrameworkCore;

namespace Projector.Repository
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public UserContext() 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=userdb;Username=postgres;Password=Pass2020!");
        }
    }
}