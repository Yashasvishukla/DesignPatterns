using System;

namespace DuckSimulator;

public class MallardDuck: Duck
{
    public MallardDuck()
    {
        _flyBehavior = new FlyWithWings();
        _quackBehavior = new Quacking();
    }
    public override void Display()
    {
        Console.WriteLine("Duck looks like Mallard");
    }
}