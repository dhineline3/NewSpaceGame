using System;

namespace NewSpaceGame
{
    internal class Player
    {
        public double age = 20;
        public decimal money;
        public Location location;

        public Player(Location location)
        {
            this.location = location;
        }

        public void TravelTo(Location destination, double warpSpeed)
        {
            var distance = location.DistanceTo(destination);
            var speed    = Utility.WarpSpeedToLightSpeed(warpSpeed);

            age += distance / speed;

            location = destination;
        }
    }
}