namespace DuckSimulator;

/*
 * This is the class which will be used by the client
 *
 * We will try to keep the common behaviors and properties
 * and we will carefully observe the things that varies and try to encapsulate them.
 */
public abstract class Duck
{
 protected IFlyBehavior _flyBehavior;
 protected IQuackBehavior _quackBehavior;
 
 public void Swim()
 {
  Console.WriteLine("The Duck has ability to swim");
 }

 public abstract void Display();

 public void PerformQuack()
 {
  _quackBehavior.Quack();
 }

 public void PerformFly()
 {
  _flyBehavior.Fly();
 }

 public void SetFlyBehavior(IFlyBehavior flyBehavior)
 {
  _flyBehavior = flyBehavior;
 }

 public void SetQuackBehavior(IQuackBehavior quackBehavior)
 {
  _quackBehavior = quackBehavior;
 }
 
 
}


/*
 * If we intend to add the
 * Fly()
 * Quack()
 * method in the duck then
 * all the duck may not quack and fly so it will not fulfill the inheritance completely
 * So we try to abstract those behavior out of Duck class
*/