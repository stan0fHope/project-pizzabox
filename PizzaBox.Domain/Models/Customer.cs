using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class Customer : AModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    // idk

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return $"{FirstName} + {LastName}";
    }
  }
}