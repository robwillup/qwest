using Quest.Commands;
using Quest.Console;
using System.Linq;
using System;
using static System.Console;
using System.IO;

namespace Quest.Arguments
{
    public static class ArgumentManager
    {
        public static string QuestTodosPath { get; set; }
        public static int CheckArgs(string[] args)
        {
            QuestTodosPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Quest";
            if (args.Length == 0)
                WriteLine("Welcome to the Quest!");
            else
            {
                switch (args[0])
                {
                    case "help":
                        HelpCommandUi.GetHelp("default");
                        break;
                    case "new":
                        string text = NewCommandHandler(args);
                        if (text != null)
                            NewToDo.Create(text, QuestTodosPath);
                        break;
                    case "list":
                        ExecuteList();
                        break;
                }
            }
            return 0;
        }

        private static string NewCommandHandler(string[] args)
        {
            if (!args.Contains("todo"))
            {
                NewCommandUi.WriteNewCommandError(@"When the 'new' command is used, the 'todo' subcommand must be provided, as well as its text.");
                return null;
            }

            int todoIndex = args.ToList().IndexOf("todo");
            if (todoIndex + 1 < args.Length && !string.IsNullOrEmpty(args[todoIndex + 1]))
                return args[todoIndex + 1];

            NewCommandUi.WriteNewCommandError("A text for the 'todo' subcommand must be provided.");
            return null;            
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
