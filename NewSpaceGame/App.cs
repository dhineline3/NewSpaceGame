using System;
using System.Collections.Generic;
using System.Linq;

namespace NewSpaceGame
{
    public class App
    {
        Random random;
        Events events;

        List<Location> locations = new List<Location>();

        Player hero;

        public App()
        {
            random = new Random();
            events = new Events(random);

            //List of all possible items available for purchase.
            var beer = new Item("Space Beer", 1.2M);

            //Different locations with corresponding items available for purchase.
            locations.Add(new Location("Earth",
                "A pale blue dot, even at your close distance." +
                "The birthplace of mankind, now deserted\n",
                0, 0,            //Distance
                                 //Price multiplier here is 1
                new List<Item>() { beer, })); //Items available to purchase on this system
            locations.Add(new Location("Alpha Centauri 3",
                "The new home world of the human race, such as it is.",
                0, 4.367,                        
                new List<Item>() { beer, },
                0.9M));          //Price multiplier in relation to earth (1)
            locations.Add(new Location("Gazorpazorp",
                "The planet of I don't need no man.",
                5.294, 12.004,                               
                new List<Item>() { beer, },
                1.7M));
            locations.Add(new Location("Reach",
                "Beautiful vacation location and hotspot for glassing.",
                17.250, 34.103,                              
                new List<Item>() { beer, },
                1.4M));
            locations.Add(new Location("Pandora",
                "Dangerous crime planet with no rules. Home of the vault hunters.",
                2.140, 9.726,                                
                new List<Item>() { beer, },
                1.3M));
            locations.Add(new Location("Krypton",
                "Shattered planet once belonging to the race known as kryptonians",
                111.601, 41.222,                               
                new List<Item>() { beer, },
                3.0M));

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
            QuitReason quitReason;

            do
            {
                Console.Clear();
                //Print the current location
                Console.WriteLine($"Location: {hero.location.name}    Age: {hero.age:f2} years    Credits: {hero.money:f1}\n");

                //Print description
                Console.WriteLine(hero.location.description);

                //Provide options to the user reagarding things they can do
                PrintOptionlist();

                var key = UI.ElicitInput(" ");
                quitReason = ShouldQuit(HandleInput(key));
            } while (quitReason == QuitReason.DontQuit);

            return quitReason;
        }

        //Reasons to end game - If age > 70 || (money && goods = 0)
        private QuitReason ShouldQuit(QuitReason quitReason)
        {

            QuitReason AgeCheck() => hero.age >= 70 ? QuitReason.Age :
            QuitReason.DontQuit;
            QuitReason MoneyCheck() => hero.money < 0 ? QuitReason.OutOfMoney :
                QuitReason.DontQuit;
            if (quitReason == QuitReason.DontQuit)
            {
                quitReason = AgeCheck();
            }
            if (quitReason == QuitReason.DontQuit)
            {
                quitReason = MoneyCheck();
            }


            return quitReason;
        }

        //Standard operating menu
        private void PrintOptionlist()
        {
            Console.WriteLine();
            Console.WriteLine("1. Travel to a new location");
            Console.WriteLine("2. Buy items.");
            Console.WriteLine("3. Sell items.");
            Console.WriteLine("q. Quit");
        }
        private QuitReason HandleInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Q:
                    return QuitReason.UserQuit;
                case ConsoleKey.D1:
                    TravelMenu();
                    break;
                case ConsoleKey.D2:
                    BuyMenu();
                    break;
                case ConsoleKey.D3:
                    SellMenu();
                    break;
            }

            return QuitReason.DontQuit;
        }

        //Main Sell menu
        private void SellMenu()
        {
            Console.Clear();

            if (hero.inventory.Any())
            {
                PrintItems(hero.inventory);

                var itemIndex = UI.ElicitInput("Which item would you like to sell: ", 1, hero.inventory.Count);

                if (!itemIndex.cancelled)
                {
                    hero.SellItem(hero.inventory[itemIndex.input - 1]);
                }
            }
            else
            {
                Console.WriteLine("Nothing to sell...");
                UI.ElicitInput("Press any key to continue...");
            }
        }


        //Main Buy menu
        private void BuyMenu()
        {



            Console.Clear();

            List<Item> items = hero.location.items;
            PrintItems(items);

            var itemIndex = UI.ElicitInput("Which item would you like to buy? ", 1, items.Count);


            if (!itemIndex.cancelled)
            {
                hero.BuyItem(items[itemIndex.input - 1]);
            }
        }

        private void PrintItems(List<Item> items)
        {
            for (int i = 0; i < items.Count; ++i)
            {
                var item = items[i];
                var cost = hero.location.CostOf(item);

                Console.WriteLine($"{i + 1}. {item.name} - {cost:f2}cr");
            }
        }
        //Travel menu for different systems
        private void TravelMenu()
        {
            var done     = false;
            int selector = 0;
            int count    = locations.Count;

            do
            {
                Console.Clear();
                Console.WriteLine("Travel to: ");

                PrintLocationsAndDistances(selector);

                var key = UI.ElicitInput();

                //Ability to use up and down and 'enter' to navigate system destination options
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

                        if (random.Next(0, 3) == 0)
                        {
                            events.SelectEvent().Present(hero);
                        }

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

                Console.Write($" - ");

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