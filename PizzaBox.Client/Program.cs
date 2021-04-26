using System;
using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Client
{
  /// <summary>
  /// 
  /// </summary>
  public class Program
  {
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;

    /// <summary>
    /// 
    /// </summary>
    private static void Main()
    {
      Run();
    }

    /// <summary>
    /// 
    /// </summary>
    private static void Run()
    {
      var order = new Order();
      order.Customer = new Customer();

      Console.WriteLine("Welcome to PizzaBox");
      order.Store = SelectStore();

      Console.WriteLine("Please enter your first name (only): ");
      order.Customer.Name = Console.ReadLine();
      // Console.WriteLine(order.Customer.Name);

      //  'Server=tcp:pizzaboxsql12.database.windows.net,1433;Initial Catalog=PizzaBoxDB;Persist Security Info=False;User ID=sqladmin;Password={Yugioh120};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'
      
      // order.Store = SelectStore();
      order.Pizzas = SelectPizza();
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintOrder(APizza pizza)
    {
      Console.WriteLine($"Your order includes: {pizza}");
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintPizzaList()
    {
      var index = 0;

      foreach (var item in _pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintStoreList()
    {
      var index = 0;

      foreach (var item in _storeSingleton.Stores)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static List<APizza> SelectPizza()
    {
      List<APizza> orderPizza = new List<APizza>();
      bool extra = true;
      while (extra)
      {
        PrintPizzaList();
        Console.WriteLine("Please select the pizza you would order from: ");      

        var valid1 = int.TryParse(Console.ReadLine(), out int input1);

        if (!valid1)
        {
          return null;
        }

        var pizza = _pizzaSingleton.Pizzas[input1 - 1];
        PrintOrder(pizza);
        orderPizza.Add(pizza);

        Console.WriteLine("If you would like to add another pizza, enter 1. If ready to submit order, enter 0: "); 
        var valid2 = int.TryParse(Console.ReadLine(), out int input2);

        if (!valid2)
        {
          return null;
        }

        if(input2 == 0)
        {
          extra = false;
        }
      }
      return orderPizza;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static AStore SelectStore()
    {
      PrintStoreList();
      Console.WriteLine("Please enter the number of the store you would like to order from: ");
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }
      return _storeSingleton.Stores[input - 1];
    }
  }
}
