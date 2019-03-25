using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSpaceGame
{
    public class Events
    {
        private Random random;

        public Events(Random random)
        {
            this.random = random;
        }

        List<Event> possibleEvents = new List<Event>()
        {
            new Event("You see something glittering in the distance.",
                    new Option("Investigate", "You find a floating treasure chest!", 100),
                    new Option("Stay on-course", "", 0)),
            new Event("You're being raided by space pirates",
                    new Option("Negotiate", "The pirates, impressed by your mettle, offer you 100 credits as a token of goodwill", 100),
                    new Option("Fight back", "Your puny ship offers little resistance. You barely escape with your life...", -100)),
            new Event("You are hailed by a fleet of robot ships.",
                    new Option("Attack!", "You destroy their peace loving civilization, but all you find of value is 100 credits.", 100),
                    new Option("Trade.", "The robots take pity on your puny ship, offering all the money in their coffers.", 500)),
            new Event("You come in contact with a nearby meteor. Your advisors claim they can see man made material on it.",
                    new Option("Investigate?", "You discover remnants of an old exploratory mission. They left behind little.", 100),
                    new Option("Continue course", "", 0)),
            new Event("You're under attack by space pirates!",
                new Option("Fire lasers!", "Success! The raiders back off, leaving you a gift.", 100),
                new Option("Fire missles!", "Unfortunately the priate anti missle shield is very effective. They board you ship and steal some credits.", 300)),
            new Event("You come across a friendly trader!",
                new Option("Trade", "You develop a successful trading partnership. He gives you credits as a token of goodwill", 100),
                new Option("Fire!", "The trader attacks! He ship is better equipped. He takes credits as payment but spares you with your life.", -200)),
        };

        public Event SelectEvent()
        {
            var selectedEvent = random.Next(0, possibleEvents.Count);

            return possibleEvents[selectedEvent];
        }
    }

    public class Event
    {
        private string header;
        private Option option1;
        private Option option2;

        public Event(string header, Option option1, Option option2)
        {
            this.header = header;
            this.option1 = option1;
            this.option2 = option2;
        }

        public void Present(Player player)
        {
            Console.Clear();
            Console.WriteLine(header);
            Console.WriteLine("\nDo you want to:");
            Console.WriteLine($"  1. {option1.choice}");
            Console.WriteLine($"  2. {option2.choice}");

            bool valid = false;

            do
            {
                switch (UI.ElicitInput("Choice: "))
                {
                    case ConsoleKey.D1:
                        Console.WriteLine($"\n{option1.result}");
                        player.money += option1.costChange;
                        valid = true;
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine($"\n{option2.result}");
                        player.money += option2.costChange;
                        valid = true;
                        break;
                }
            } while (!valid);

            UI.ElicitInput("Press any key to continue...");
        }
    }

    public class Option
    {
        public string choice;
        public string result;

        public decimal costChange;

        public Option(string choice, string result, decimal costChange)
        {
            this.choice = choice;
            this.result = result;
            this.costChange = costChange;
        }
    }
}
