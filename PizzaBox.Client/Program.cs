using System;
using System.Linq;
using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Storing;
using PizzaBox.Storing.Repo;

namespace PizzaBox.Client
{
  /// <summary>
  /// 
  /// </summary>
  public class Program
  {
    private static readonly PizzaBoxContext _context = new PizzaBoxContext();
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance(_context);
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance(_context);
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance(_context);
    private static readonly OrderRepo _orderRepo = new OrderRepo(_context);

    private static readonly int MAX_PIZZAS = 50;
    private static readonly int MAX_COST = 250;


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
      Console.WriteLine("Welcome to PizzaBox");

      Console.WriteLine("Please enter your first & last name: ");      
      string fullname = Console.ReadLine();
      var names = fullname.Split(' ');       
      
      order.Customer = new Customer();
      order.Customer.FirstName = names[0];
      order.Customer.LastName = names[1];      
      order.Store = SelectStore();
      order.Pizzas = SelectPizza();     
      PrintFinal(order);

    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintFinal(Order order)
    {
      Console.WriteLine("Your order includes: ");
      foreach (var item in order.Pizzas)
      {
        Console.WriteLine($"{item} ");
      }
      var full = order.TotalCost;
      Console.WriteLine($"For a total of: ${full}", full);
      
      _orderRepo.Create(order);

      var orders = _context.Orders.Where(o => (o.Customer.FirstName == order.Customer.FirstName) &  (o.Customer.LastName == order.Customer.LastName));

      // PrintListToScreen(orders);
    }


    private static void PrintListToScreen(IEnumerable<object> items)
    {
      var index = 0;

      foreach (var item in items)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }


    private static Customer SelectCustomer()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }

      var customer = _customerSingleton.Customers[input - 1];

      PrintStoreList();

      return customer;
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintPizzaList()
    {
      var index = 0;

      if (_pizzaSingleton.Pizzas == null)
      {
         Console.WriteLine("There are no pizzas available at this time.");
      }
      else
      {
        Console.WriteLine("And we got some pizzas");
        foreach (var item in _pizzaSingleton.Pizzas)
        {
          Console.WriteLine($"{++index} - {item}");          
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintOrder(List<APizza> orderList)
    {
      // var index = 0;
      Console.WriteLine($"Your order consists of: ");
      
      foreach (var item in orderList)
      {
        Console.WriteLine($"{item}");
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
        
        var testM = new MeatPizza();
        testM.Crust.Name = "Brooklyn";
        testM.Crust.Price = 6.00M;
        testM.Size.Name = "XL";
        testM.Size.Price = 18.00M;

        var pizza = _pizzaSingleton.Pizzas[input1 - 1];
        orderPizza.Add(pizza);
        orderPizza.Add(testM);
        PrintOrder(orderPizza);
        
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

      decimal orderCost = orderPizza.Sum(t => t.TotalPrice());      
      
      while( (orderPizza.Count > 50) | (orderCost > 250) )
      {
        RemovePizza(orderPizza);
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


    private static void RemovePizza(List<APizza> pizzaList)
    {
      Console.WriteLine("Please select which pizza you would like to remove: ");
      var valid = int.TryParse(Console.ReadLine(), out int input);
      // var x = pizzaList.Count();
      if (!valid)
      {
        Console.WriteLine("That was an invalid value. Please try again.");
      }
      else if( (input - 1) > pizzaList.Count() )
      {
        Console.WriteLine("That was an invalid choice. Please try again.");
      }
      else
      {
        pizzaList.RemoveAt(input - 1);
      }
    }

  }
}


