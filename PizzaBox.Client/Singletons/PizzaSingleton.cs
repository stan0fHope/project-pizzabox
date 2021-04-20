using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
// using PizzaBox.Storing.Repo;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaSingleton
  {
    private const string _path = @"data/Pizzas.xml";
    private readonly FileRepository _fileRepository = new FileRepository();
    private static PizzaSingleton _instance;

    public List<APizza> Pizzas { get; }
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
      if (Pizzas == null)
      {
        Pizzas = _fileRepository.ReadFromFile<List<APizza>>(_path);
      }
    }
  }
}
