using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Models
{
  public class Topping : AComponent
  {
    public List<APizza> Pizzas {get; set;}
  }
}
