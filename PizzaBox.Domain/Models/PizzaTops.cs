using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class PizzaTops
    {
      public long PizzaID{get; set;}
      public APizza PizzaLink{get; set;}

      public long ToppingID{get; set;}
      public Topping ToppingLink{get; set;}

    }
}