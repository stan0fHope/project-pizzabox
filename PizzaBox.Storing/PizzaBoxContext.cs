using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstract;

namespace PizzaBox.Storing;
{
  public class PizzaBoxContext : DbContext
  {
    private static readonly IConfiguration _config;
    // The XML Includes is covered
    public DbSet<AStore> Stores {get; set;} //Implicit serialization & casting
    public DbSet<APizza> Pizzas {get; set;}

    public PizzaBoxContext(IConfiguration config)
    {
      _config = config;
    }

    // the writer & reader is covered
    protected void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_config["mssql"]); // needs a path 
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AStore>().HasKey(e => e.EntityId);
      builder.Entity<APizza>().HasKey(e => e.EntityId);
      //ranking does matter
    }
  }
}