using System;
using System.Linq;
using System.IO;
using static System.Console;

namespace Quest
{
    class Program
    {
        public static string TodoText { get; set; }
        public static string QuestTodosPath { get; set; }
        
        static int Main(string[] args)
        {
            QuestTodosPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Quest";
            return CheckArgs(args);
        }
        public static int CheckArgs(string[] args)
        {
            if (args.Length == 0)
                WriteLine("Welcome to the Quest!");
            else
            {
                switch (args[0])
                {
                    case "new":
                        ExecuteNew(args);
                        break;
                    case "list":
                        ExecuteList();
                        break;
                }                
            }
            return 0;
        }

        public static int ExecuteNew(string[] args)
        {
            if (!args.Contains("--todo"))
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine(@"When the 'new' command is used, the '--todo' flag must be provided, as well as its text.");
                ResetColor();
                return 1;
            }
            else
            {
                int todoIndex = args.ToList().IndexOf("--todo");
                if (todoIndex + 1 < args.Length && !string.IsNullOrEmpty(args[todoIndex + 1]))
                {
                    TodoText = args[todoIndex + 1];                    
                    if (!Directory.Exists(QuestTodosPath))
                    {
                        Directory.CreateDirectory(QuestTodosPath);
                        using (_ = File.Create(@$"{QuestTodosPath}\todos.txt")) {; }
                    }
                    else if (!File.Exists(@$"{QuestTodosPath}\todos.txt"))
                    {
                        using (_ = File.Create(@$"{QuestTodosPath}\todos.txt")) {; }
                    }
                    using (StreamWriter sw = File.AppendText($@"{QuestTodosPath}\todos.txt"))
                        sw.WriteLine(TodoText);

                    return 0;
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("A text for the '--todo' flag must be provided.");
                    ResetColor();
                    return 1;
                }

            }
        }

        public static int ExecuteList()
        {
            string[] lines = File.ReadAllLines(@$"{QuestTodosPath}\todos.txt");
            foreach (string line in lines)
            {
                WriteLine(line);
            }
            return 0;
        }
    }
}
