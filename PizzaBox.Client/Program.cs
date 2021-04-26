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
      // Yugioh120!

      // Console.WriteLine("Please enter your first & last name: ");
      string fullname = Console.ReadLine();
      var names = fullname.Split(' '); 
      // order.Customer.FirstName = names[0];
      // order.Customer.LastName = names[1];
      // Console.WriteLine(order.Customer.Name);

      // dotnet user-secrets set mssql 'Server=tcp:pizzaboxsql12.database.windows.net,1433;Initial Catalog=PizzaBoxDB;Persist Security Info=False;User ID=sqladmin;Password={Yugioh120};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'
      
      // order.Store = SelectStore();
      // order.Pizzas = SelectPizza();
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
      Console.WriteLine("Please select the store you'd like to order from: ");
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }
      return _storeSingleton.Stores[input - 1];
    }


    private static void RemovePizza()
    {
      Console.WriteLine("Please select which pizza you would like to remove: ");
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }
      else if((input -1) > order.Pizzas.Count())
      {
        Console.WriteLine("That was an invalid choice. Please try again.");
      }
      else
      {
        order.Pizzas.RemoveAt(input - 1);
      }
    }


    
  }
}


