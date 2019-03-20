using System;
using System.Collections.Generic;

namespace NewSpaceGame
{
    public  class App
    {
        List<Location> locations = new List<Location>();

        Player hero;

        public App()
        {
            locations.Add(new Location("Earth", "A pale blue dot, even at your close distance. The birthplace of mankind, now deserted\n", 0, 0));
            locations.Add(new Location("Alpha Centauri 3", "The new home world of the human race, such as it is.", 0, 4.367));
            locations.Add(new Location("Gazorpazorp", "The planet of I don't need no man.", 5.294, 12.004));
            locations.Add(new Location("Reach", "Beautiful vacation location and hotspot for glassing.", 17.250, 34.103));
            locations.Add(new Location("Pandora", "Dangerous crime planet with no rules. Home of the vault hunters.", 2.140, 9.726));
            locations.Add(new Location("Krypton", "Shattered planet once belonging to the race known as kryptonians", 111.601, 41.222));

            hero = new Player(locations[0]);
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
                Console.WriteLine($"Location: {hero.location.name}\t\tAge: {hero.age:f2} years\n");

                //Print description
                Console.WriteLine(hero.location.description);

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
            var done = false;
            int selector = 0;
            int count = locations.Count;

            do
            {
                Console.Clear();
                Console.WriteLine("Travel to: ");

                PrintLocationsAndDistances(selector);

                var key = UI.ElicitInput();


                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        selector++;
                        selector %= count;
                        break;
                    case ConsoleKey.UpArrow:
                        selector--;
                        selector = (selector + count) % count;
                        break;
                    case ConsoleKey.Q:
                        done = true;
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.Enter:
                        done = true;
                        var warpSpeed = UI.ElicitInput("At what warp speed would you like to travel? ", 0.0, 9.5);
                        hero.TravelTo(locations[selector], warpSpeed);
                        break;


                }

            } while (!done);
        }
        private void PrintLocationsAndDistances(int selector)
        {
            for (int i = 0; i < locations.Count; ++i)
            {
                Location destination = locations[i];

                var distance = hero.location.DistanceTo(destination);

                Console.Write($"{i + 1}. ");

                if (i == selector)
                {
                    UI.Highlight();
                }
                Console.WriteLine($"{destination.name}: {distance:f2} ly");

                UI.ResetColors();
            }
        }
    }
}