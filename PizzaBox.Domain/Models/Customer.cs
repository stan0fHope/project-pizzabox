using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Abstracts.AModel;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class Customer : AModel
  {
    public string Name { get; set; }
    // idk

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return $"{Name}";
    }
  }
}