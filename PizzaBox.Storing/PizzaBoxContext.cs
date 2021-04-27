using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Stores;

namespace PizzaBox.Storing
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaBoxContext : DbContext
  {
    private readonly IConfiguration _configuration;

    public DbSet<AStore> Stores { get; set; }
    public DbSet<APizza> Pizzas { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Crust> Crusts { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Topping> Toppings {get; set;}
    public DbSet<Order> Orders { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public PizzaBoxContext()
    {
      _configuration = new ConfigurationBuilder().AddUserSecrets<PizzaBoxContext>().Build();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_configuration["mssql"]);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AStore>().HasKey(e => e.EntityId);
      builder.Entity<ChicagoStore>().HasBaseType<AStore>();
      builder.Entity<NewYorkStore>().HasBaseType<AStore>();

      builder.Entity<APizza>().HasKey(e => e.EntityId);
      builder.Entity<CustomPizza>().HasBaseType<APizza>();
      builder.Entity<MeatPizza>().HasBaseType<APizza>();
      builder.Entity<VeggiePizza>().HasBaseType<APizza>();

      builder.Entity<Crust>().HasKey(e => e.EntityId);
      builder.Entity<Order>().HasKey(e => e.EntityId);
      builder.Entity<Size>().HasKey(e => e.EntityId);
      builder.Entity<Topping>().HasKey(e => e.EntityId);

      builder.Entity<Customer>().HasKey(e => e.EntityId);

      // builder.Entity<Size>().HasMany<APizza>().WithOne(); // orm is creating the has
      builder.Entity<APizza>().HasOne<Size>(p => p.Size).WithMany();
      builder.Entity<APizza>().HasOne<Crust>(p => p.Crust).WithMany();
      // builder.Entity<APizza>().HasMany<Topping>(p => p.Toppings).WithMany();
      // builder.Entity<APizza>().includes(Toppings);
      

      builder.Entity<AStore>().HasMany<Order>(s => s.Orders).WithOne(o => o.Store);
      builder.Entity<Customer>().HasMany<Order>().WithOne(o => o.Customer);
      // builder.Entity<APizza>().HasMany<Order>().WithOne(o => o.Pizzas);


      builder.Entity<ChicagoStore>().HasData(new ChicagoStore[]
      {
        new ChicagoStore() { EntityId = 1, Name = "Chitown Main Street" },
        new ChicagoStore() { EntityId = 3, Name = "Lowtown Best Slices" }
      });

      builder.Entity<NewYorkStore>().HasData(new NewYorkStore[]
      {
        new NewYorkStore() { EntityId = 2, Name = "Big Apple" }
      });

      builder.Entity<Crust>().HasData(new Crust[]
      {
        new Crust() { EntityId = 1, Name = "Thin", Price = 4.00M },
        new Crust() { EntityId = 2, Name = "Stuffed", Price = 6.00M },
        new Crust() { EntityId = 3, Name = "Brooklyn", Price = 6.00M },
        new Crust() { EntityId = 4, Name = "Deep-Dish", Price = 5.00M }
      });

      builder.Entity<Size>().HasData(new Size[]
      {
        new Size() { EntityId = 1, Name = "Small", Price = 6.00M },
        new Size() { EntityId = 2, Name = "Medium", Price = 10.00M },
        new Size() { EntityId = 3, Name = "Large", Price = 14.00M },
        new Size() { EntityId = 4, Name = "XL", Price = 18.00M }
      });

      builder.Entity<Topping>().HasData(new Topping[]
      {
        new Topping() { EntityId = 1, Name = "Pepperoni", Price = 1.50M },
        new Topping() { EntityId = 2, Name = "Chicken", Price = 1.50M },
        new Topping() { EntityId = 3, Name = "Bacon", Price = 1.50M },
        new Topping() { EntityId = 4, Name = "Mushrooms", Price = 1.00M },
        new Topping() { EntityId = 5, Name = "Spinach", Price = 1.00M },
        new Topping() { EntityId = 6, Name = "Anchovies", Price = 1.25M },
        new Topping() { EntityId = 7, Name = "Pineapples", Price = 1.00M },
        new Topping() { EntityId = 8, Name = "Jalapenos", Price = 1.00M }
      });


      // builder.Entity<MeatPizza>().HasData(new MeatPizza[]
      // {
      //   new MeatPizza(){EntityId = 1, Size.Name = "Medium", Size.Price = 10.00M, Crust.Name = "Stuffed", Crust.Price = 6.00M,
      //     Toppings.Add(Topping.Name = "Bacon", Topping.Price = 1.50M),
      //     Toppings.Add(Topping.Name = "Chicken", Topping.Price = 1.50M)};
      //   }

      // });

      // builder.Entity<VeggiePizza>().HasData(new VeggiePizza[]
      // {
      //   new VeggiePizza() { EntityId = 1, CrustEntityId = 1, SizeEntityId = 1, ToppingEntityId = {1, 2, 3} }

      // } );


      builder.Entity<Customer>().HasData(new Customer[]
      {
        new Customer() { EntityId = 1, FirstName = "Uncle", LastName = "John" },
        new Customer() { EntityId = 2, FirstName = "Kevin", LastName = "Spacer" },
        new Customer() { EntityId = 3, FirstName = "Sharon", LastName = "Carten" }

      });
    }
  }
}
