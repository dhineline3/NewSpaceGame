using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSpaceGame
{
    class UI
    {
        public static ConsoleKey ElicitInput(string prompt = "> ")
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write(prompt);

            return Console.ReadKey(true).Key;
        }
    }
}
