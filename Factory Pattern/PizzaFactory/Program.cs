// See https://aka.ms/new-console-template for more information

// using PizzaFactory.AbstractFactory;
// using PizzaFactory.FrameworkForPizzaStore;

using PizzaFactory.AbstractFactory;

using PizzaFactory.SimpleFactoryPizzaStore;
using PizzaStore = PizzaFactory.SimpleFactoryPizzaStore.PizzaStore;
using Type = PizzaFactory.AbstractFactory.Type;


// ----------------------- Pizza Store ----------------------
// var pizzaStore = new PizzaStore();
// pizzaStore.OrderPizza(PizzaFactory.PizzaFactoryV1.Type.Greek);



// -------------------- Simple Factory Store ---------------------
// var factory = new SimplePizzaFactory();
// var simpleFactoryPizzaStore = new PizzaStore(factory);
// simpleFactoryPizzaStore.OrderPizza(PizzaFactory.SimpleFactoryPizzaStore.Type.Pepperoni);


// ------------------ Framework pizza store --------------
/*
 * Instead of having composition we are extending the functionalities in the framework
 * Create a framework that ties the store and the pizza creation together, yet still allows things to remain flexible
 */

//
// var nyPizzaStore = new NyPizzaStore();
// nyPizzaStore.OrderPizza(Type.Cheese);
//
// var chicagoPizzaStore = new ChicagoPizzaStore();
// chicagoPizzaStore.OrderPizza(Type.Pepperoni);
//



// ---------------------- Abstract Factory Introducing the Ingredient -----------------------------

var nyPizzaIngredients = new NyPizzaIngredients();
var nyPizzaStore = new NyStyledPizzaStore(nyPizzaIngredients);

var pizza = nyPizzaStore.OrderPizza(Type.Cheese);

