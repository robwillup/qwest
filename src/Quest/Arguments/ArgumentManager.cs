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
        public static int HandleArgs(string[] args)
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
                    case "do":
                        string text = DoCommandHandler(args);
                        if (text != null)
                            DoRoutines.Create(text, QuestTodosPath);
                        break;
                    case "todo":
                        ToDosUi.ShowToDos(QuestTodosPath);
                        break;
                }
            }
            return 0;
        }

        private static string DoCommandHandler(string[] args)
        {
            int doIndex = args.ToList().IndexOf("do");
            if (doIndex + 1 < args.Length && !string.IsNullOrEmpty(args[doIndex + 1]))
                return args[doIndex + 1];

            NewCommandUi.WriteNewCommandError("A text for the 'do' command must be provided.");
            return null;            
        }
    }
}
