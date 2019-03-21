using System;
using System.Collections.Generic;

namespace NewSpaceGame
{
    internal class Player
    {
        public double age = 20;
        public decimal money;

        public Location location;
        private List<Item> inventory;

        public Player(Location location)
        {
            this.location = location;
            money         = 1000M;
        }

        public void TravelTo(Location destination, double warpSpeed)
        {
            var distance = location.DistanceTo(destination);
            var speed    = Utility.WarpSpeedToLightSpeed(warpSpeed);

            age += distance / speed;

            location = destination;
        }

        public void BuyItem(Item item)
        {
            money -= location.CostOf(item);
            inventory.Add(item);
        }
        public void SellItem(Item item)
        {
            money += location.CostOf(item);
            inventory.Remove(item);
        }
    }
}