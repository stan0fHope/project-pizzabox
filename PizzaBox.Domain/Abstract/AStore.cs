using System.Collections.Generic;
using System;
using sc = System.Console;
using PizzaBox.Domain.Abstract;
    namespace PizzaBox.Client
    {//client side (namespace)
        public abstract class AStore //class
        {
            string Name;
            public AStore()
            {
                Name = DateTime.Now.Ticks.ToString();
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }