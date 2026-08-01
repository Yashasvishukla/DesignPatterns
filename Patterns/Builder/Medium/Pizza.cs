namespace Medium;
internal class Pizza
{
    /// <summary>
    /// Gets the size of the pizza.
    /// </summary>
    public string Size { get; }

    /// <summary>
    /// Gets the type of crust for the pizza.
    /// </summary>
    public string? Crust { get; } = null;

    /// <summary>
    /// Gets the type of sauce for the pizza.
    /// </summary>
    public string? Sauce { get; } = null;

    /// <summary>
    /// Gets the type of cheese for the pizza.
    /// </summary>
    public string? Cheese { get; } = null;

    /// <summary>
    /// Gets the list of toppings for the pizza.
    /// </summary>
    public List<string> Toppings { get; }


    private Pizza(Builder builder)
    {
        Size = builder.Size;
        Crust = builder.CrustVal;
        Sauce = builder.SauceVal;
        Cheese = builder.CheeseVal;
        Toppings = builder.Toppings;
    }


    public override string ToString()
    {
        // Expected: Pizza{size='...', crust='...', sauce='...', cheese='...', toppings=[...]}
        return $"Pizza{{size='{Size}', crust='{Crust}', sauce='{Sauce}', cheese='{Cheese}', toppings=[{string.Join(", ", Toppings)}]}}";
    }


    public class Builder
    {
        // builder class maintains the state and the state is reassigned to pizza properties.
        internal readonly string Size;
        internal string CrustVal;
        internal string SauceVal;
        internal string CheeseVal;
        internal readonly List<string> Toppings = [];

        public Builder(string size)
        {
            Size = size;
        }

        public Builder Crust(string crust)
        {
            CrustVal = crust;
            return this;
        }

        public Builder Sauce(string sauce)
        {
            SauceVal = sauce;
            return this;
        }

        public Builder Cheese(string cheese)
        {
            CheeseVal = cheese;
            return this;
        }

        public Builder AddTopping(string topping)
        {
            Toppings.Add(topping);
            return this;
        }

        public Pizza Build()
        {
            return new Pizza(this);
        }
    }
}

/// <summary>
/// The size of the pizza.
/// </summary>
internal enum Size
{
    Small,
    Medium,
    Large
}