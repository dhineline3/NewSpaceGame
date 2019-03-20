using System;

namespace NewSpaceGame
{
    public static class Story
    {
        public static void Intro()
        {
            string prompt = "Press any key to continue...";

            Console.Clear();
            Console.WriteLine("Wlcome to the year 2525 where man is still alive.");
           UI.ElicitInput(prompt);

            Console.Clear();
            Console.WriteLine("You're the captain of a space cruiser. It's slow and honestly a piece of junk by today's standards" +
                " but it is fully \ncapable of taking you to the stars!");
            UI.ElicitInput(prompt);

            Console.Clear();
            Console.WriteLine("Make as much money as you can in you set 70 year lifespan");
            UI.ElicitInput(prompt);

        }
    }
}