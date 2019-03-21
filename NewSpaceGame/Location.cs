using System;
using System.Collections.Generic;

namespace NewSpaceGame
{
    public class Location
    {
        public string name;
        public string description;

        double xPos;
        double yPos;

        decimal tradeRate;
        public List<Item> items;

        public Location(string name, string description, double xPos, double yPos, List<Item> items, decimal tradeRate = 1.0M )
        {
            this.name        = name;
            this.description = description;
            this.xPos        = xPos;
            this.yPos        = yPos;
            this.tradeRate   = tradeRate;
            this.items = items;
        }

        public double DistanceTo(Location destination)
        {
            var left  = Math.Pow(this.xPos - destination.xPos, 2);
            var right = Math.Pow(this.yPos - destination.yPos, 2);

            return Math.Sqrt(left + right);
        }
        public decimal CostOf(Item item) =>
            item.cost * tradeRate;
    }
}