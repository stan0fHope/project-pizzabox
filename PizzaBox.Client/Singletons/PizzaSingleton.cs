using System.Collections.Generic;
// using PizzaBox.Domain.Abstract;
using PizzaBox.Domain.Models;
namespace PizzaBox.Client.Singletons
{//Make/In-chraged of Stores make/change
    public class PizzaSingleton
    {
        public static List<APizza> stores = new List<AStore>
        //make static list of stores, avoid changes to them
        {
            new CustomPizza(),
            new MeatPizza(),
            new VeggiePizza();
        }
    }
}