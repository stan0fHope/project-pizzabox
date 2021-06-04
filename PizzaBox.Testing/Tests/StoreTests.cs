using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Stores;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class StoreTests
  {
    public static IEnumerable<object[]> values = new List<object[]>()
    {
      new object[] { new ChicagoStore() },
      new object[] { new NewYorkStore() }
    };

    public static IEnumerable<object[]> pizza_values = new List<object[]>()
    {
      new object[] { new MeatPizza() },
      new object[] { new VeggiePizza() }
    };

    //  public static IEnumerable<object[]> orders = new List<object[]>()
    // {
    //   new object[] { new Order(){new ChicagoStore(), new MeatPizza(), new Customer(){FirstName = "Mark", LastName = "Apile"} } },
    //   new object[] { new Order(){new NewYorkStore(), new VeggiePizza(), new Customer(){FirstName = "Bomily", LastName = "Baker"} } }
    // };

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_ChicagoStore()
    {
      // arrange
      var sut = new ChicagoStore();

      // act
      var actual = sut.Name;

      // assert
      Assert.True(actual == "ChicagoStore");
      Assert.True(sut.ToString() == actual);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_NewYorkStore()
    {
      var sut = new NewYorkStore();

      Assert.True(sut.Name.Equals("NewYorkStore"));
    }

    [Fact]
    public void Test_MeatPizza()
    {
      var meat_pie = new MeatPizza();
      // Assert.True(meat_pie.Size.Name.Equal("Medium"));
      Assert.NotNull(meat_pie);
      Assert.NotNull(meat_pie.Toppings);
    }

    [Fact]
    public void Test_VeggiePizza()
    {
      var veg_pie = new VeggiePizza();
      // Assert.True(veg_pie.Size.Name.Equal("Medium"));
      Assert.NotNull(veg_pie);
      Assert.NotNull(veg_pie.Toppings);

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="store"></param>
    [Theory]
    [MemberData(nameof(values))]
    public void Test_StoreName(AStore store)
    {
      Assert.NotNull(store.Name);
      Assert.Equal(store.Name, store.ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="storeName"></param>
    /// <param name="x"></param>
    [Theory]
    [InlineData("ChicagoStore", 1)]
    [InlineData("NewYorkStore", 1)]
    public void Test_StoreNameSimple(string storeName, int x)
    {
      Assert.NotNull(storeName);
    }

    [Theory]
    [InlineData("Ken", "Rogers")]
    public void Test_Customer1(string first, string last)
    {
      Assert.NotNull(first);
      Assert.NotNull(last);
    }


    [Theory]
    [InlineData("Ken Rogers")]
    [InlineData("Space Dandi")]
    [InlineData("LeePenguin")]
    public void Test_Customer2(string name)
    {
      Assert.NotNull(name);
      Assert.True(name.Length >= 5);
      Assert.True(name.Contains(" "));

      var name_break = name.Split(" ");
      string first = name_break[0];
      string last = name_break[1];

      Assert.NotNull(first);
      Assert.NotNull(last);

      Assert.True(first.Length >= 3);
      Assert.True(last.Length >= 3);
    }

    [Theory]
    [MemberData(nameof(pizza_values))]

    public void Test_PizzaPrice(APizza pizza)
    {
      Assert.NotNull(pizza.TotalPrice);
      Assert.True(pizza.TotalPrice <= 250.00M);
    }

    [Theory]
    [MemberData(nameof(pizza_values))]

    public void Test_ToppingCount(APizza pizza)
    {
      Assert.NotNull(pizza.Toppings);
      Assert.True(pizza.Toppings.Count <= 5);
    }

  }
}
