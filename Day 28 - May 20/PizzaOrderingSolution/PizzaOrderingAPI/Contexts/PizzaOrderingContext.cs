using Microsoft.EntityFrameworkCore;
using PizzaOrderingAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace PizzaOrderingAPI.Contexts
{
    public class PizzaOrderingContext : DbContext
    {
        public PizzaOrderingContext(DbContextOptions<PizzaOrderingContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Margherita", Price = 290.0m, InStock = true },
                new Pizza { Id = 2, Name = "Pepperoni", Price = 400.0m, InStock = true },
                new Pizza { Id = 3, Name = "Pineapple", Price = 620.0m, InStock = false }
            );

            using var hmac = new HMACSHA512();
            modelBuilder.Entity<User>().HasData(
                new User{Id = 1,Username = "admin",PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")),PasswordSalt = hmac.Key,Role = "Admin"},
                new User {Id = 2,Username = "store1",PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")),PasswordSalt = hmac.Key,Role = "Admin"}
            );
        }
    }
}
