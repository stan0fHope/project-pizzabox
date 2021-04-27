using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
// using PizzaBox.Storing;

namespace PizzaBox.Storing.Repo
{
  public class OrderRepo
  {
    private readonly PizzaBoxContext _context;

    public OrderRepo(PizzaBoxContext context)
    {
      _context = context;
    }

    public void Create(Order order)
    {
      _context.Orders.Add(order);
      _context.SaveChanges();
    }
  }
}