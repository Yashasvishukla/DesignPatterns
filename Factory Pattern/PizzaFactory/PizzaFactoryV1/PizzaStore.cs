using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.PizzaFactoryV1
{

    /// <summary>
    /// Pizza store is responsible for create and order pizza
    /// </summary>
    public class PizzaStore
    {
        
        public Pizza OrderPizza(Type type)
        {


            /*
             * 1. This section will vary
             *    as the pizza selection changes over time,
             *    you will have to modify this code over and over
             *    
             *    
             * 2. This code is not closed for modification
             *    If the pizza shop changes its pizza offering,
             *    we have to get into this code and modify it.
             */



            Pizza? pizza = null;
            if(type == Type.Greek)
            {
                pizza = new GreekPizza();
            }
            else if(type == Type.Cheese)
            {
                pizza = new CheesePizza();
            }
            else if(type == Type.Pepperoni)
            {
                pizza = new PepperoniPizza();
            }



            /*
             * This is what stay the same. For the most part,
             * Preparing, Cooking, Packing a pizza has remained the same
             * for years and years.
             */

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza!;
        }
    }


    public enum Type
    {
        Cheese,
        Greek,
        Pepperoni
    }

    /// <summary>
    ///  Varities of the pizza available
    /// </summary>


    public class Pizza
    {


        public void Prepare()
        {
            Console.WriteLine($"Pizza is preparing {GetType()}");
        }
        public void Bake()
        {
            Console.WriteLine("Pizza is now baking");
        }
        public void Cut()
        {
            Console.WriteLine("Cut the pizza");
        }
        public void Box()
        {
            Console.WriteLine("Box the pizza");
        }

    }

    public class CheesePizza: Pizza
    {

    }

    public class PepperoniPizza : Pizza
    {

    }

    public class GreekPizza : Pizza
    {

    }


}



