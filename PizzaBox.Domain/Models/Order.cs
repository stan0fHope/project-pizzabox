using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public Customer Customer { get; set; }
    public AStore Store { get; set; }
    public List<APizza> Pizzas { get; set; }

    public decimal TotalCost
    {
      get
      {
        return Pizzas.Sum(t => t.TotalPrice);
      }
    }

    // public void Save()
    // {
      // dotnet dotnet-ef migrations add 'add orders dbset' -p PizzaBox.Storing/ -s PizzaBox.Client/
      // dotnet dotnet-ef migrations update

      
    //   // need instance of context
    //   context.Orders.Add(this);
    //   context.SaveChanges();
    //   // has a problem

    //   // for it to be in client, need helper
    //   // SIngletons design pattern for Cleint
    //   // Repos design pattern for storing
    // }
  }
}
