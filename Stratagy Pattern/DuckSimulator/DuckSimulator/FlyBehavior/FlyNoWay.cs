namespace DuckSimulator.FlyBehavior;

public class FlyNoWay: IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("Do nothing, Can't fly");
    }
}