using System;

namespace NewSpaceGame
{
    public  class App
    {
        public App()
        {
        }
        public void Run()
        {
            Story.Intro();

            EventLoop();
        }
        private void EventLoop()
        {
            bool quit = false;

            do
            {
                //Print the current location
                //Print description
                //Provide options to the user reagarding things they can do
                //Ellicit input
                //Handle Input

                var key = UI.ElicitInput();
                quit = HandleInput(key);
                
            } while (!quit);
        }

        private bool HandleInput(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.Q:

                    return true;
            }

            return false;
        }
    }
}