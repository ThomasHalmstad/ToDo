using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ToDo
{
    class Program
    {
        static string connectionString = "Data Source=(local);Initial Catalog=ToDo;Integrated Security=true";

        static void Main(string[] args)
        {
            bool shouldNotExit = true;

            while (shouldNotExit)
            {

                Console.WriteLine("1. Add todo");
                Console.WriteLine("2. List todo");
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

                        CreateTask(title, dueDate);

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        List<Task> taskList = FetchAllTasks();

                        Console.WriteLine("Id\tTitle\t\t\tDueDate");
                        Console.WriteLine("---------------------------------------------------------------");

                        foreach (Task task in taskList)
                        {
                            if (task == null) continue;

                            Console.WriteLine($"{task.id}\t{task.title} {task.dueDate}");
                        }

                        Console.ReadKey();

                        break;



                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:

                        shouldNotExit = false;

                        break;
                }

                Console.Clear();
            }


        }

        static void CreateTask(string title, DateTime dueDate)
        {
            string queryString = @"INSERT INTO Task (Title, DueDate)
                                              VALUES(@Title, @DueDate)";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@DueDate", dueDate);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();

            }
        }

        static List<Task> FetchAllTasks()
        {
            string queryString = @"SELECT [Id],
                                          [Title],
                                          [DueDate]
                                     FROM[ToDo].[dbo].[Task]";

            List<Task> taskList = new List<Task>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = int.Parse(reader["Id"].ToString()); ;
                        string title = reader["Title"].ToString(); ;
                        DateTime dueDate = DateTime.Parse(reader["dueDate"].ToString());

                        Task task = new Task(id, title, dueDate);

                        taskList.Add(task);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return taskList;

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
