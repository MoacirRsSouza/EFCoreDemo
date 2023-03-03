using InMemory_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace InMemory_MVC.DAL
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options) { }

        public UserDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryProvider");
        }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<UserModel>().HasAlternateKey(c => c.Id);
        }
    }
}
