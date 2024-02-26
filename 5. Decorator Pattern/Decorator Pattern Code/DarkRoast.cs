using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern_Code
{
    internal class DarkRoast: Beverage
    {
        public double CalcuateCost()
        {
            var cost = Cost;

            if (HasMocha) cost += MochaCost;
            if (HasMilk) cost += MilkCost;
            if (HasSoy) cost += SoyaCost;
            if (HasWhip) cost += WhipCost;


            return cost;
        }
    }
}
