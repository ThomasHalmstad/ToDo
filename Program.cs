﻿using System;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {

            bool shouldNotExit = true;

            Task[] toDo = new Task[20];

            int toDoCounter = 0;

            int idCounter = 1;

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

                        Console.SetCursorPosition(2, 1);

                        Console.WriteLine("Title: ");

                        Console.SetCursorPosition(2, 3);

                        Console.WriteLine("DueDate (yyyy-mm-dd hh:mm): ");

                        Console.SetCursorPosition("Title: ".Length + 2, 1);

                        string title = Console.ReadLine();

                        Console.SetCursorPosition("DueDate (yyyy-mm-dd hh:mm): ".Length + 2, 3);

                        DateTime dueDate = DateTime.Parse(Console.ReadLine());

                        Task newToDo = new Task(idCounter, title, dueDate);

                        toDo[toDoCounter] = newToDo;

                        ++toDoCounter;
                        ++idCounter;

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        Console.WriteLine("Id\tTitle\t\t\tDueDate");
                        Console.WriteLine("---------------------------------------------------------");

                        for (int i = 0; i < toDo.Length; i++)
                        {
                            if (toDo[i] == null) continue;

                            Console.WriteLine($"{toDo[i].id}\t{toDo[i].title}\t\t\t{toDo[i].dueDate}");
                        }

                        Console.ReadLine();

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

    class Task
    {
        public int id;
        public string title;
        public DateTime dueDate;

        public Task(int id, string title, DateTime dueDate)
        {
            this.id = id;
            this.title = title;
            this.dueDate = dueDate;
        }
    }
}
