using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Repo;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class ToppingSingleton
  {
    private const string _path = @"data/Toppings.xml";
    private readonly FileRepo _fileRepo = new FileRepo();
    private static ToppingSingleton _instance;

    public List<AComponent> Toppings { get; }
    public static ToppingSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new ToppingSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private ToppingSingleton()
    {
      if (Toppings == null)
      {
        Toppings = _fileRepo.ReadFromFile<List<AComponent>>(_path);
      }
    }
  }
}
