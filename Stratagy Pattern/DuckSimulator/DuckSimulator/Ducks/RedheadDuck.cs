using System;

namespace DuckSimulator;

public class RedheadDuck: Duck
{
    public RedheadDuck()
    {
        _quackBehavior = new Quacking();
        _flyBehavior = new FlyWithWings();
    }
    public override void Display()
    {
        Console.WriteLine("Looks like a Redhead Duck");
    }
}