namespace Medium;

internal class PizzaDirector
{
    public Pizza BuildMargherita(string size)
    {
        return new Pizza.Builder(size)
            .Crust("regular")
            .Sauce("tomato")
            .Cheese("mozzarella")
            .AddTopping("basil")
            .Build();
    }

    public Pizza BuildPepperoni(string size)
    {
        return new Pizza.Builder(size)
            .Crust("thin")
            .Sauce("tomato")
            .Cheese("mozzarella")
            .AddTopping("pepperoni")
            .AddTopping("olives")
            .Build();
    }

    public Pizza BuildVeggie(string size)
    {
        return new Pizza.Builder(size)
            .Crust("whole wheat")
            .Sauce("pesto")
            .Cheese("gouda")
            .AddTopping("mushrooms")
            .AddTopping("peppers")
            .AddTopping("onions")
            .AddTopping("olives")
            .Build();

    }
}