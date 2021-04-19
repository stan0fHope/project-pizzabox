using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Order
  {
    public Customer Customer { get; set; }
    public AStore Store { get; set; }
    public APizza Pizza { get; set; }

    public decimal TotalCost
    {
      get
      {
        return (Pizza.Crust.Price + Pizza.Size.Price + Pizza.Toppings.Price);
      }
    }
  }
}
