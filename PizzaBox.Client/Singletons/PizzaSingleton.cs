using System;
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
    public static PizzaSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        _instance = new PizzaSingleton(context);
      }

      return _instance;
      
    }

    /// <summary>
    /// 
    /// </summary>
    private PizzaSingleton(PizzaBoxContext context)
    {
      // _context.Pizzas.AddRange(_fileRepository.ReadFromFile<List<APizza>>(_path));
      // var cp = new CustomPizza();
      // cp.Size = _context.Sizes.FirstOrDefault(s => s.Name == "Medium");
      // cp.Size = _context.Sizes.FirstOrDefault(s => s.Price = 3.90m);

      // cp.Crust = _context.Crusts.FirstOrDefault(c => c.Name == "Thin");
      // cp.Toppings = _context.Toppings.FirstOrDefault(s => s.Name == "Medium");

      // _context.Add(cp);
      _context = context;
      // _context.SaveChanges();

      Pizzas = _context.Pizzas.ToList();
    }
  }
}
