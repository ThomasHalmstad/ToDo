using System;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool exit = false;

            //string[] toDo = new string[20];

            //int toDoCounter = 0;

            //while (!exit)
            //{
            //    Console.Clear();

            //    Console.WriteLine("1. Add todo");
            //    Console.WriteLine("2. List todos");
            //    Console.WriteLine("3. Exit");

            //    ConsoleKeyInfo input = Console.ReadKey();

            //    Console.Clear();

            //    switch (input.Key)
            //    {
            //        case ConsoleKey.D1:

            //            Console.WriteLine("To do: ");

            //            string answer = Console.ReadLine();

            //            toDo[toDoCounter] = answer;

            //            ++toDoCounter;

            //            break;

            //        case ConsoleKey.D2:

            //            foreach (string thingsToDo in toDo)
            //            {
            //                Console.WriteLine(thingsToDo);
            //            }

            //            break;

            //        case ConsoleKey.D3:

            //            exit = true;

            //            break;

            //    }
            //}


            while (true)
            {
                Console.WriteLine("1. Add todo");
                Console.WriteLine("2. Lis todo");
                Console.WriteLine("3. Exit");

                ConsoleKeyInfo keyPressed = Console.ReadKey(true);

                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        break;
                }
            }

        }
    }
}
