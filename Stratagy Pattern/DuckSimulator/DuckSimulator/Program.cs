// See https://aka.ms/new-console-template for more information

/*
    In this module we are going to learn about the strategy pattern
    
    The Strategy Pattern defines a family of algorithm,
    encapsulates each one and make them interchangeable.
    
    Strategy lets the algorithm vary independently from client that use it.
*/


using DuckSimulator;
using DuckSimulator.FlyBehavior;

Duck duck = new MallardDuck();
duck.PerformFly();
duck.PerformQuack();

Duck duck1 = new RedheadDuck();
duck1.SetFlyBehavior(new FlyNoWay());
duck1.SetQuackBehavior(new Squeak());
duck1.PerformFly();
duck1.PerformQuack();


duck.SetFlyBehavior(new FlyRocketBehavior());
duck.PerformFly();
duck.PerformQuack();


/*
  In Case if we have to support new type of behavior
  like FlyRocketPowered() 
  then we just need to add the behavior and with the help of setFlyBehavior we can 
  set the fly behavior at the run time.
  So minimal code changes required

*/