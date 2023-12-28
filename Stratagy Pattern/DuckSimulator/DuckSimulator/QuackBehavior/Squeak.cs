namespace DuckSimulator;

public class Squeak: IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine("Rubber Duck Squeak");
    }
}