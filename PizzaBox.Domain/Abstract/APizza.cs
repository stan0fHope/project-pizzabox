using System.Collections.Generic;
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
    /// Virtual so subclass can override & improve.
    /// Ie. Meat/Veggie can make themselves accordingly
    /// Custom can use user input 
    /// </summary>
    protected virtual void AddCrust() 
    {
      Crust = new Crust() { Name = "Org"};
      //Crust = new Crust() { Name = CrustEnum.ThinCrust}

    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void AddSize()
    {
      Size = new Size() {Name = "Big"};
    }

    /// <summary>
    /// 
    /// Abstract could work too, as parent has no default
    /// ie. protected abstract void AddToppings(); must be overriden
    /// </summary>
    protected virtual void AddToppings()
    {
      Toppings.Add(new Topping() { Name = "Mozzarella"});
      Toppings.Add(new Topping() { Name = "Marinara Sauce"});
      Toppings.Add(new Topping() { Name = "Pepperoni"});
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      var stringBuilder = new StringBuilder();
      var separator = ", ";

      foreach (var item in Toppings)
      {
        stringBuilder.Append($"{item}{separator}");
      }

      return $"{Crust} - {Size} - {stringBuilder.ToString().TrimEnd(separator.ToCharArray())}";
    }
  }
}
