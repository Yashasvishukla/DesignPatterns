namespace PizzaFactory.SimpleFactoryPizzaStore
{
    internal class PizzaStore
    {


        private readonly ISimplePizzaFactory _simplePizzaFactory;

        public PizzaStore(ISimplePizzaFactory simplePizzaFactory)
        {
            _simplePizzaFactory = simplePizzaFactory;
        }



        public Pizza? OrderPizza(Type type)
        {
            Pizza? pizza = null;

            pizza = _simplePizzaFactory.CreatePizza(type);


            // I can prepare, bake, cut, box the pizza
            pizza?.Prepare();
            pizza?.Bake();
            pizza?.Cut();
            pizza?.Box();


            return pizza;
        }
        

    }

    /// <summary>
    /// Simple Pizza Factory
    /// 
    /// The place where the pizza is getting created.
    /// </summary>
    /// 

    public interface ISimplePizzaFactory
    {
        Pizza? CreatePizza(Type type);
    }

    public class SimplePizzaFactory : ISimplePizzaFactory
    {
        public Pizza? CreatePizza(Type type)
        {
            if (type == Type.Cheese) return new CheesePizza();
            
            if(type == Type.Greek) return new GreekPizza();
            
            if(type == Type.Pepperoni) return new PepperoniPizza();

            return null;
        }
    }

    public enum Type
    {
        Cheese,
        Greek,
        Pepperoni
    }

    /// <summary>
    ///  Varieties of the pizza available
    /// </summary>


    public abstract class Pizza
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

    public class CheesePizza : Pizza
    {

    }

    public class PepperoniPizza : Pizza
    {

    }

    public class GreekPizza : Pizza
    {

    }




}
