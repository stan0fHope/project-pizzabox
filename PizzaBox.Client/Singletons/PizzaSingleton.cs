using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Storing;
using PizzaBox.Storing.Repo;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaSingleton
  {
    private readonly FileRepo _fileRepo = new FileRepo();
    private static PizzaSingleton _instance;
    private const string _path = @"data/pizzas.xml";
    private readonly PizzaBoxContext _context = new PizzaBoxContext();

    public List<APizza> Pizzas { get; set; }
    public static PizzaSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new PizzaSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private PizzaSingleton()
    {
      // _context.Pizzas.AddRange(_fileRepository.ReadFromFile<List<APizza>>(_path));
      var cp = new CustomPizza();
      cp.Size = _context.Sizes.FirstOrDefault(s => s.Name == "Medium", s.Price == 8.00);
      cp.Crust = _context.Crust.FirstOrDefault(c => c.Name == "Thin", c.Price == 5.00 );
      // cp.Toppings = _context.Toppings.FirstOrDefault(s => s.Name == "Medium");

      _context.Add(cp);
      _context.SaveChanges();

      Pizzas = _context.Pizzas.ToList();
    }
  }
}
