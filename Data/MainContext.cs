using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class MainContext : DbContext
    {
        public MainContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]{
                new User {Id = 1, Name = "Gilmar"}
            });

        }
    }
}