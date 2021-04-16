using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class ComponentSingleton
  {
    private const string _path = @"data/Components.xml";
    private readonly FileRepository _fileRepository = new FileRepository();
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
        Components = _fileRepository.ReadFromFile<List<AComponent>>(_path);
      }
    }
  }
}
