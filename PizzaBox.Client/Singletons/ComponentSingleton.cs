using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class ComponentSingleton
  {
    private const string _path = @"data/Components.xml";
    private readonly FileRepo _fileRepoy = new FileRepo();
    private static ComponentSingleton _instance;

    public List<AComponent> Components { get; }
    public static ComponentSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new ComponentSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private ComponentSingleton()
    {
      if (Components == null)
      {
        Components = _fileRepo.ReadFromFile<List<AComponent>>(_path);
      }
    }
  }
}
