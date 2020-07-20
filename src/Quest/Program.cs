using System;
using System.Linq;
using System.IO;
using static System.Console;

namespace Quest
{
    class Program
    {
        public static string TodoText { get; set; }
        static int Main(string[] args)
        {
            // Refactor ASAP
            if (args.Length == 0)
                WriteLine("Welcome to the Quest!");
            else if (args.Contains("new"))
            {
                if (!args.Contains("--todo"))
                {
                    WriteLine(@"When the 'new' command is used, the '--todo' flag must be provided, as well as its text.");
                    return 1;
                }
                else
                {
                    int todoIndex = args.ToList().IndexOf("--todo");
                    if (todoIndex + 1 < args.Length && !string.IsNullOrEmpty(args[todoIndex + 1]))
                    {
                        TodoText = args[todoIndex + 1];                        
                        string questTodosPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Quest";
                        if (!Directory.Exists(questTodosPath)) 
                        {
                            Directory.CreateDirectory(questTodosPath);
                            using (_ = File.Create(@$"{questTodosPath}\todos.txt")) {;}
                        } 
                        else if (!File.Exists(@$"{questTodosPath}\todos.txt"))
                        {
                            using (_ = File.Create(@$"{questTodosPath}\todos.txt")) {; }
                        }
                        using (StreamWriter sw = File.AppendText($@"{questTodosPath}\todos.txt"))                        
                            sw.WriteLine(TodoText);
                        
                        return 0;
                    }
                    else
                    {
                        WriteLine("A text for the '--todo' flag must be provided.");
                        return 1;
                    }
                    
                }
            }
            return 0;
        }
    }
}
