// See https://aka.ms/new-console-template for more information
using Decorator_Pattern_Code;
using System.Reflection;





var beverage = new HouseBlend();
beverage.HasMocha = true;
beverage.HasSoy = true;

Console.WriteLine(beverage.CalculateCost());






var darkRoatBeverage = new HouseBlend();
darkRoatBeverage.HasMocha = true;
darkRoatBeverage.HasSoy = false;
darkRoatBeverage.HasMilk = true;

Console.WriteLine(darkRoatBeverage.CalculateCost());

