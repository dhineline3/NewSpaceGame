using System;

namespace NewSpaceGame
{

    public  class App
    {
        Location location;

        public App()
        {
            location = new Location("Earth", "A pale blue dot, even at your close distance. The birthplace of mankind, now deserted");
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
                Console.WriteLine(location.name);

                //Print description
                Console.WriteLine(location.description);

                //Provide options to the user reagarding things they can do


                var key = UI.ElicitInput();
                quitReason = HandleInput(key);
                
            } while (quitReason == QuitReason.DontQuit);

            return quitReason;

        }

        private QuitReason HandleInput(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.Q:

                    return QuitReason.UserQuit;
            }

            return QuitReason.DontQuit;
        }
    }
}