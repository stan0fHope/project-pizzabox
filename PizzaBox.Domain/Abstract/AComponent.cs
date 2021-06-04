using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// 
  /// </summary>
  [XmlInclude(typeof(Crust))]
  [XmlInclude(typeof(Size))]
  [XmlInclude(typeof(Topping))]

  public class AComponent : AModel
  {
    public string Name { get; set; }
    public decimal Price { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return Name;
    }
  }
}

