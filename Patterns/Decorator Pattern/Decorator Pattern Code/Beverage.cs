using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern_Code
{
    /// <summary>
    ///     Representation of the beverage
    /// </summary>
    internal class Beverage
    {
        public string Description { get; set; } = string.Empty;
        protected double Cost { get; set; } = 10;                                              // Represent the base price of the beverage

        public double MilkCost { get; set; } = 2;
        public double SoyaCost { get; set; } = 4;
        public double WhipCost { get; set; } = 3;
        public double MochaCost { get; set; } = 6;

        // States of the topping 

        public bool HasSoy { get; set; }
        public bool HasMocha { get; set; }
        public bool HasWhip { get; set; }
        public bool HasMilk { get; set; }
    }
}
