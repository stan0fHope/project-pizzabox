using System.Collections.Generic;
using System;
using PizzaBox.Domain.Models;
using sc = System.Console;
    namespace PizzaBox.Client
    {//client side (namespace)
        public class Program //class
        {
            private static void Main() //methods
            {
                //arrays are static; linked list easy to add, long to search
                //flex of linked, easy of array => list
                var stores = new List<AStore> {new ChicagoStore(), new NYStore()};
                List<string> storeList = new List<string> {"Store 01", "Store 02"};
                //^var runtime will fill in data-type info
                //aka var x = null

                for (var x = 0; x < stores.Count; x += 1)
                {
                    Console.WriteLine(x + " " + stores[x]);
                    Console.WriteLine($"{x} {stores[x]}");
                }

                Console.WriteLine("make a select: ");
                string input = sc.ReadLine();
                int entry = int.Parse(input);

                sc.WriteLine(stores[entry]);
                //focus on process & refining it
            }
        }
    }