namespace DuckSimulator;


/*
 * This interface will be used in the Duck class
 * So we will be coding to interface not to the implementation
 * That helps us to have loosely coupled code and the modification to fly behavior has no impact on the Duck class
 * as it is dependent on the abstraction
 */
public interface IFlyBehavior
{
    void Fly();
}