using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// 
  /// </summary>
  [XmlInclude(typeof(CustomPizza))]
  [XmlInclude(typeof(MeatPizza))]
  [XmlInclude(typeof(VeggiePizza))]

  public abstract class APizza : AModel
  {
    public Crust Crust { get; set; }
    // public CrustEnum CrustEnum; if using enum, gotta recompile for chngs
    public Size Size { get; set; }
    public long SizeEntityId { get; set; }
    public long CrustEntityId { get; set; }
    public List<Topping> Toppings { get; set; }

    protected APizza()
    {
      Factory();
    }

    /// <summary>
    /// Systematic way to assemble pizza that must be followed.
    /// </summary>
    protected virtual void Factory() 
    {
      AddCrust();
      AddSize();
      AddToppings();
    }

     /// <summary>
    /// 
    /// </summary>
    public abstract void AddCrust(Crust crust = null);

    /// <summary>
    /// 
    /// </summary>
    public abstract void AddSize(Size size = null);

    /// <summary>
    /// 
    /// </summary>
    public abstract void AddToppings(params Topping[] toppings);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      var stringBuilder = new StringBuilder();
      var separator = ", ";
      // Console.WriteLine("Hello Stan");

      foreach (var item in Toppings)
      {
        stringBuilder.Append($"{item}{separator}");
      }

      return $"{Crust} - {Size} - {stringBuilder.ToString().TrimEnd(separator.ToCharArray())}";
      // return $"{Crust} - {Size} - {stringBuilder.ToString().TrimEnd(separator.ToCharArray())}";
    }

    public decimal TotalPrice
    {
      get
      {
        return (Crust.Price + Size.Price + Toppings.Sum(t => t.Price));
      }
    }
    
  }
}
