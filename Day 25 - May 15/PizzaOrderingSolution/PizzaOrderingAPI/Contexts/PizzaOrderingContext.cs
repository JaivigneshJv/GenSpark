using Microsoft.EntityFrameworkCore;
using PizzaOrderingAPI.Models;

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
        }
    }
}
