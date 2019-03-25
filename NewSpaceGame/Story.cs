using System;

namespace NewSpaceGame
{
    public static class Story
    {
        public static void Intro()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Main Title
            Console.WriteLine(@"
                                                    ███████╗ ██████╗ ██╗         ████████╗██████╗  █████╗ ██████╗ ███████╗██████╗                         ^
                                                    ██╔════╝██╔═══██╗██║         ╚══██╔══╝██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔══██╗                      /SSS\
                                                    ███████╗██║   ██║██║            ██║   ██████╔╝███████║██║  ██║█████╗  ██████╔╝                     |SPACE|
                                                    ╚════██║██║   ██║██║            ██║   ██╔══██╗██╔══██║██║  ██║██╔══╝  ██╔══██╗                     |SPACE|
                                                    ███████║╚██████╔╝███████╗       ██║   ██║  ██║██║  ██║██████╔╝███████╗██║  ██║                     |SPACE|
                                                    ╚══════╝ ╚═════╝ ╚══════╝       ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝                     |SPACE|   
                                                                                                                                                      /|SPACE|\
                                                                                                                                                     /S |SSS| S\
                                                                                                                                                    /SS |S S| SS\
                                                                                                                                                        |S S|
                                                                                                                                                  ****************
                                                                                                                                                  ****************
                                                                                                           ");

            //Main Title Text Color
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press enter to being your adventure...");
            Console.ReadKey();
            string myText = "Welcome to Sol Trader young adventurer!\n\n" +
            "The year is 2147. Exploring the stars has become a hobby for many as space travel becomes commonplace.\n\n" +
            "You have just graduated from the stellar business academy with a degree in intergalatic finance! Congratulations!\n" +
            "Unfortunately your father and only relative has died.\n" +
            "Fortunately he left you his spaceship! Awesome!\n" +
            "Unfortunately it isn't in the best shape....but it is fully capable of taking you to the stars!\n\n" +
            "Will you fulfill your dreams of becoming a space trading mogul?\n" +
            "Or will you die alone, penniless, drifting through space, living through your dreams in crysosleep?\n\n" +
            "Choose your path. Your journey begins now!\n\n" +
            "Press enter to continue...";
            

            //Loop that makes main title text write out like a typewriter
            for (int i = 0; i < myText.Length; i++)
            {
                Console.Write(myText[i]);
                System.Threading.
                Thread.Sleep(5);
            }

            //Clearing the prior specific line
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();

            //Method to set up way to clear lines 
            void ClearCurrentConsoleLine()
            {
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
            }
            Console.ReadKey();

        }

        //Ask player for a name and save it


        public static void ClosingMessage(QuitReason quitReason)
        {
            Console.Clear();

            switch (quitReason)
            {
                case QuitReason.UserQuit:
                    Console.WriteLine("Sorry to see you go...\n\n");
                    break;
                case QuitReason.Age:
                    Console.WriteLine("You're 70 years old...The time has come for you to retire.\n\n");
                    break;
                case QuitReason.OutOfMoney:
                    Console.WriteLine("Your last penny is spent, a debtor's prison colony awaits");
                    break;
                    throw new NotImplementedException("Shouldnt be quitting with DontQuit reason");

            }
    }
    }
}