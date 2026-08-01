namespace PizzaFactory.FrameworkForPizzaStore;

public abstract class PizzaStore
{
    
    /// <summary>
    ///  1. Order pizza is defined in the abstract PizzaStore.
    ///     The method has no idea which subclass is actually running the code and making the pizza.
    ///     It is decoupled. 
    /// </summary>

    protected abstract Pizza? CreatePizza(Type type);
    
    public Pizza? OrderPizza(Type type)
    {
        var pizza = CreatePizza(type);
        
        pizza?.Prepare();
        pizza?.Bake();
        pizza?.Cut();
        pizza?.Box();

        return pizza;
    }
}








/// <summary>
///  NYPizzaStore:  New York style customizations
/// </summary>

public class NyPizzaStore : PizzaStore
{
    protected override Pizza? CreatePizza(Type type)
    {
        if (type == Type.Cheese) return new NYCheesePizza();
        if (type == Type.Pepperoni) return new NYPepperoniPizza();
        if (type == Type.Greek) return new NYGreekPizza();


        return null;
    }
}


/// <summary>
///  ChicagoPizzaStore: Chicago Style customization
/// </summary>
public class ChicagoPizzaStore: PizzaStore
{
    protected override Pizza? CreatePizza(Type type)
    {
        if (type == Type.Cheese) return new ChicagoCheesePizza();
        if (type == Type.Greek) return new ChicagoGreekPizza();
        if (type == Type.Pepperoni) return new ChicagoPepperoniPizza();

        return null;
    }
}











public abstract class Pizza
{
    public string Name { get; }
    public string Dough { get; set; }
    
    public List<string> Veggies { get; set; }
    public string Sauce { get; set; }

    public Pizza(string name, string dough, List<string> veggies, string sauce)
    {
        Name = name;
        Dough = dough;
        Veggies = veggies;
        Sauce = sauce;
    }
    public virtual void Prepare()
    {
        Console.WriteLine($"Pizza is preparing {Name}");
        Console.WriteLine($"Dough {Dough}");
        Console.WriteLine($"Sauce {Sauce}");
    }
    public virtual void Bake()
    {
        Console.WriteLine("Pizza is now baking");
    }
    public virtual void Cut()
    {
        Console.WriteLine("Cut the pizza");
    }
    public virtual void Box()
    {
        Console.WriteLine("Box the pizza");
    }

}


/// <summary>
///  The values right now are pre-set in this case.
///  We will work on the improvement of these as well.
/// </summary>
public class NYCheesePizza: Pizza
{
    public NYCheesePizza(): base("NYCheese", "ThickCrust", null, "Sauce")
    {
        
    }

    public override void Cut()
    {
        Console.WriteLine("Cutting the pizza into square slices");
    }
}

public class NYPepperoniPizza : Pizza
{
    public NYPepperoniPizza(): base("NYPepperoni", "ThickCrust", null, "Sauce")
    {
        
    }
}

public class NYGreekPizza : Pizza
{
    public NYGreekPizza() : base("NYGreek", "ThinCrust", null, "Sauce")
    {
        
    }

    public override void Bake()
    {
        Console.WriteLine("Bake the pizza at 250 F temperature");
    }
}


public class ChicagoCheesePizza: Pizza
{
    public ChicagoCheesePizza() : base("ChicagoCheese", "ThinCrust", null, "Sauce")
    {
        
    }
}

public class ChicagoPepperoniPizza : Pizza
{
    public ChicagoPepperoniPizza(): base("ChicagoPepperoni", "ThinCrust", null, "Sauce")
    {
        
    }
}

public class ChicagoGreekPizza : Pizza
{
    public ChicagoGreekPizza() : base("ChicagoGreek", "ThickCrust", null, "Sauce")
    {
        
    }
}

public enum Type
{
    Cheese,
    Greek,
    Pepperoni
}