using System;
using System.Collections.Generic;

namespace NewSpaceGame
{

    public  class App
    {
        List<Location> locations = new List<Location>();

        Location currentLocation;

        public App()
        {
            locations.Add(new Location("Earth", "A pale blue dot, even at your close distance. The birthplace of mankind, now deserted\n",
              0, 0));

            currentLocation = locations[0];
        }
        public void Run()
        {
            Story.Intro();

            var quitReason = EventLoop();

            Story.ClosingMessage(quitReason);
        }
        private QuitReason EventLoop()
        {
            var quitReason = QuitReason.DontQuit;

            do
            {
                Console.Clear();
                //Print the current location
                Console.WriteLine($"Location: {currentLocation.name}\n");

                //Print description
                Console.WriteLine(currentLocation.description);

                //Provide options to the user reagarding things they can do
                PrintOptionlist();

                var key = UI.ElicitInput();
                quitReason = HandleInput(key);                
            } while (quitReason == QuitReason.DontQuit);

            return quitReason;

        }

        private void PrintOptionlist()
        {
            Console.WriteLine("1. Travel to a new location");
            Console.WriteLine("q. Quit");
        }

        private QuitReason HandleInput(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.Q:
                    return QuitReason.UserQuit;
                case ConsoleKey.D1:
                    TravelMenu();
                    break;
            }

            return QuitReason.DontQuit;
        }

        private void TravelMenu()
        {
            Console.Clear();
            Console.WriteLine("Travel to: ");

            for (int i = 0; i < locations.Count; ++i) 
            {
                Location destination = locations[i];
                var distance = currentLocation.DistanceTo(destination);
                Console.WriteLine($"{i + 1}. {destination.name}: {distance}ly\n");
            }
            UI.ElicitInput();
        }
    }
}