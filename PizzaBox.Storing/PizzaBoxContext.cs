using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;

// sqladmin, yugioh120
namespace PizzaBox.Storing
{
  public class PizzaBoxContext : DbContext
  {
    private readonly Iconfig _config;
    public DbSet<AStore> Stores { get; set; } // implicit serialization, implicit casting
    public DbSet<APizza> Pizzas { get; set; }

    public 
    public PizzaBoxContext(Iconfig config)
    {
      _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_config["mssql"]);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AStore>().HasKey(e => e.EntityId);
      builder.Entity<APizza>().HasKey(e => e.EntityId);
    }
  }
}
