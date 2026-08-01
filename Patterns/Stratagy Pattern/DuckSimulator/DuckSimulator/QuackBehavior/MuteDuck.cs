using System;

namespace DuckSimulator;

public class MuteDuck: IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine("DO nothing, Can't Quack");
    }
}