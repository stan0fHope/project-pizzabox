using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing.Repo
{
  /// <summary>
  /// 
  /// </summary>
  public class FileRepo
  {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public T ReadFromFile<T>(string path) where T : class
    {
      try
      {
        var reader = new StreamReader(path);
        var xml = new XmlSerializer(typeof(T));

        return xml.Deserialize(reader) as T;
      }
      catch
      {
        return null;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool WriteToFile<T>(string path, List<AStore> stores) where T : class
    {
      try
      {
        var writer = new StreamWriter(path);
        var xml = new XmlSerializer(typeof(T));

        xml.Serialize(writer, stores);

        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}
