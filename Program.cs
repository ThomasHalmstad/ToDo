using System;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool shouldNotExit = true;

            while (shouldNotExit)
            {

                Console.WriteLine("1. Add todo");
                Console.WriteLine("2. Lis todo");
                Console.WriteLine("3. Exit");

                ConsoleKeyInfo keyPressed = Console.ReadKey(true);

                Console.Clear();

                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:

                        shouldNotExit = false;

                        break;
                }

                Console.Clear();
            }

        }
    }
}
