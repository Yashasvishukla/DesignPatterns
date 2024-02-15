namespace PizzaFactory.AbstractFactory;



/*
 *
 * Order process ->
 *
 *  0.1 Since the Pizza Store requires the Ingredients list based on the
 *      Type of store we are going to instantiate
 *
 *      PizzaIngredients ingredients = new NyPizzaIngredients()
 *
 *      This would set the Dough, Cheese, Clam, Veggies and other Pizza related
 *      Properties specific to NyPizzaStore
 *
 *
 *
 *  1. First we need a NYPizzaStore
 *      PizzaStore nyPizzaStore = NYStyledPizzaStore(ingredients);
 *
 *  2. Now that we have a store, we can take a order:
 *      nyPizzaStore.OrderPizza("cheese");
 *
 *  3. Pizza pizza = CreatePizza("Cheese");
 *
 *  4. When the CreatePizza() method is called, that's when
 *      out ingredient factory gets involved:
 *
 *      Pizza pizza = new CheesePizza(ingredients);
 *  5. Next we need to prepare the pizza. Once the prepare method
 *      is called, the factory is asked to prepare the ingredients
 *
 *      void prepare
 *      {
 *          dough = ingredients.CreateDough()
 *          dough = ingredients.CreateSauce()
 *          dough = ingredients.CreateCheese()
 *      }
 *
 *  6. Then it will bake, cut, box the pizza
 *  
 * 
 */
public abstract class PizzaStore
{
    protected abstract Pizza CreatePizza(Type type);

    public Pizza OrderPizza(Type pizzaType)
    {
        var pizza = CreatePizza(pizzaType);

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();

        return pizza;
    }
}


public class NyStyledPizzaStore : PizzaStore
{
    private readonly IPizzaIngredientFactory _factory;

    public NyStyledPizzaStore(IPizzaIngredientFactory factory)
    {
        _factory = factory;
    }
    protected override Pizza CreatePizza(Type type)
    {
        if (type == Type.Cheese)
        {
            return new CheesePizza(_factory);
        }
        if (type == Type.Garlic)
            return new GarlicPizza(_factory);
        if (type == Type.Onion)
            return new OnionPizza(_factory);

        return new CheesePizza(_factory); // Default pizza
    }
}










/// <summary>
///  This factory would now take the responsibility of creating the
///     cheese
///     sauce
///     veggies
///     Dough
///  based on the different regions
/// </summary>
public interface IPizzaIngredientFactory
{
    Dough CreateDough();
    Cheese CreateCheese();
    List<string> CreateVeggies();
    Sauce CreateSauce();
}


public class NyPizzaIngredients : IPizzaIngredientFactory
{
    public Dough CreateDough() => new ThickCrust();

    public Cheese CreateCheese() => new MozzarellaCheese();

    public List<string> CreateVeggies() => new() { "Aalo", "Shimla Mirch" };

    public Sauce CreateSauce() => new MarinaraSauce();
}




public class ChicagoPizzaIngredients : IPizzaIngredientFactory
{
    public Dough CreateDough() => new ThinCrust();

    public Cheese CreateCheese() => new GoatCheese();

    public List<string> CreateVeggies() => new() { "Aalo"};

    public Sauce CreateSauce() => new PlumTomatoSauce();
}











/// <summary>
///  Abstract Product
///     abstract Pizza class
/// </summary>

public abstract class Pizza
{

    public string Name { get; set; }
    
    
    /// <summary>
    ///  Is there any way we could encapsulate the creation of this based on different regions
    /// </summary>
    public Dough Dough { get; set; }
    public Sauce Sauce { get; set; }
    public List<string> Veggies { get; set; }
    public Cheese Cheese { get; set; }
    
    public abstract void Prepare();

    public virtual void Bake()
    {
        Console.WriteLine("Bake the pizza");
    }

    public virtual void Cut()
    {
        Console.WriteLine("Cut the pizza into default shape");
    }

    public virtual void Box()
    {
        Console.WriteLine("Box the pizza into in house boxes");
    }
    
    
}


public class CheesePizza: Pizza
{
    private readonly IPizzaIngredientFactory _factory;

    public CheesePizza(IPizzaIngredientFactory factory)
    {
        _factory = factory;
    }
    public override void Prepare()
    {
        Name = "Cheesy Pizza";
        Sauce = _factory.CreateSauce();
        Veggies = _factory.CreateVeggies();
        Cheese = _factory.CreateCheese();
        Dough = _factory.CreateDough();

        Console.WriteLine($"You have selected {Name}");
    }
}


public class GarlicPizza : Pizza
{
    private readonly IPizzaIngredientFactory _factory;

    public GarlicPizza(IPizzaIngredientFactory factory)
    {
        _factory = factory;
    }
    public override void Prepare()
    {
        Name = "Garlic Pizza";
        Sauce = _factory.CreateSauce();
        Veggies = _factory.CreateVeggies();
        Cheese = _factory.CreateCheese();
        Dough = _factory.CreateDough();
    }
}

public class OnionPizza : Pizza
{
    private readonly IPizzaIngredientFactory _factory;

    public OnionPizza(IPizzaIngredientFactory factory)
    {
        _factory = factory;
    }
    public override void Prepare()
    {
        Name = "Onion Pizza";
        Sauce = _factory.CreateSauce();
        Veggies = _factory.CreateVeggies();
        Cheese = _factory.CreateCheese();
        Dough = _factory.CreateDough();
    }
}


/// <summary>
///     Dough Options
/// </summary>
public abstract class Dough
{
    
}

public class ThinCrust : Dough
{
    
}

public class ThickCrust : Dough
{
    
}

public class VeryThinCrust : Dough
{
    
}


/// <summary>
///     Sauces Options
/// </summary>

public abstract class Sauce
{
    
}

public class PlumTomatoSauce : Sauce
{
    
}

public class MarinaraSauce : Sauce
{
    
}

public class BruschettaSauce : Sauce
{
    
}


/// <summary>
///  Cheese options available
/// </summary>

public abstract class Cheese
{
    
}

public class GoatCheese : Cheese
{
    
}

public class ReggianoCheese : Cheese
{
    
}

public class MozzarellaCheese : Cheese
{
    
}


public enum Type
{
    Cheese,
    Onion,
    Garlic
}