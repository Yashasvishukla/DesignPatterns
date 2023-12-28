using DuckSimulator.FlyBehavior;

namespace DuckSimulator.Ducks;

public class DecoyDuck: Duck
{
    public DecoyDuck()
    {
        _quackBehavior = new MuteDuck();
        _flyBehavior = new FlyNoWay();
    }
    public override void Display()
    {
        Console.WriteLine("Looks like a Decoy Duck");
    }
}