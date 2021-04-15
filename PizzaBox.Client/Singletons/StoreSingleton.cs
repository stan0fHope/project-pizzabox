using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Stores;
using System.Xml.Serialization;
using System.IO;

namespace PizzaBox.Client.Singletons
{
    /// <summary>
    /// 
    /// </summary>
    public class StoreSingleton
    {
        private static readonly StoreSingleton _instance;
        public List<AStore> Stores { get; }

        public static StoreSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    return new StoreSingleton();
                }

                return _instance;
            }
        }

        private StoreSingleton()
        {
            Stores = new List<AStore>()
            {
                new ChicagoStore(),
                new NewYorkStore()
                // okay but not too good for state
                // maybe something DB or filereaders better
            };
        }

        // serialization: system dat into another
        // (ie: C# to text, vice-versa)
        private void WriteToFile()
        {
            // need file + access
            // var path = @"store.xml"; // done
            var path = @"revature/project_pizzabox/store.xml";

            // open file
            var writer = new StreamWriter(path); // done
            // convert obj to txt
            var xml = new XmlSerializer(typeof(List<AStore>)); // done
            // write txt to file
            xml.Serialize(writer, Stores); // done
            // close file
            writer.Close(); // done tho not needed, nvr opened
        }

    }
}