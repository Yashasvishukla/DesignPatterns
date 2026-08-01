/*
Implement PizzaBuilder with Director
medium
Problem: Implement a Pizza builder with a PizzaDirector that provides predefined pizza recipes.

Requirements:

Pizza has: size (required), crust, sauce, cheese, and a list of toppings
Builder allows adding toppings one at a time
PizzaDirector has methods for: buildMargherita(), buildPepperoni(), buildVeggie()
Each Director method takes a size parameter and returns a fully built Pizza
Client can also build custom pizzas directly
*/


using Medium;

public class Program
{
    public static void Main(string[] args)
    {
        var director = new PizzaDirector();

        var margherita = director.BuildMargherita("medium");
        var pepperoni = director.BuildPepperoni("large");
        var veggie = director.BuildVeggie("small");
        
        var custom = new Pizza.Builder("large")
            .Crust("stuffed")
            .Sauce("bbq")
            .Cheese("cheddar")
            .AddTopping("chicken")
            .AddTopping("bacon")
            .AddTopping("jalapenos")
            .Build();
        
        Console.WriteLine(margherita);
        Console.WriteLine(pepperoni);
        Console.WriteLine(veggie);
        Console.WriteLine(custom);
        
        
    }
}