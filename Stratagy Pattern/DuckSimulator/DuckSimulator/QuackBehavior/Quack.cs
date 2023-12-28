namespace DuckSimulator;

public class Quacking: IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine("Quacking Sound by the Duck");
    }
}