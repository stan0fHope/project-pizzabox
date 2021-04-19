using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.AComponent;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// 
  /// </summary>
  [XmlInclude(typeof(Crust))]
  [XmlInclude(typeof(Size))]
  [XmlInclude(typeof(Topping))]

  public abstract class AComponent
  {
    public string Name { get; set; }
    public decimal Price { get; set; }
  }
  
}
