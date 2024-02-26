using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern_Code
{
    internal class HouseBlend: Beverage
    {
        public double CalculateCost()
        {
            var cost = Cost;

            if (HasMocha) cost += MochaCost;
            if (HasSoy) cost += SoyaCost;
            if (HasWhip) cost += WhipCost;
            if (HasMilk) cost += MilkCost;

            return cost;
        }

                
    }
}
