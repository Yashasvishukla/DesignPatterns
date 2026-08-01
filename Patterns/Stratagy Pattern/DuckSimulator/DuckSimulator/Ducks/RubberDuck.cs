using System;
using DuckSimulator.FlyBehavior;

namespace DuckSimulator.Ducks;

public class RubberDuck: Duck
{
    public RubberDuck()
    {
        _quackBehavior = new Squeak();
        _flyBehavior = new FlyNoWay();
    }
    public override void Display()
    {
        Console.WriteLine("Looks like a Rubber Duck");
    }
}