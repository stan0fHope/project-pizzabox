using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Topping : AComponent
  {
    public IEnumerable<PizzaTops> PizzaTops{get; set;}
  }
}
